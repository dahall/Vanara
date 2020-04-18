using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class NetApi32
	{
		/// <summary>
		/// <para>Specifies the possible ways that a device can be joined to Microsoft Azure Active Directory.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmjoin/ne-lmjoin-_dsreg_join_type typedef enum _DSREG_JOIN_TYPE {
		// DSREG_UNKNOWN_JOIN, DSREG_DEVICE_JOIN, DSREG_WORKPLACE_JOIN } DSREG_JOIN_TYPE, *PDSREG_JOIN_TYPE;
		[PInvokeData("lmjoin.h", MSDNShortId = "E29BCBE0-222F-4CA8-97BC-6FE1B6F97A67")]
		public enum DSREG_JOIN_TYPE
		{
			/// <summary>The type of join is not known.</summary>
			DSREG_UNKNOWN_JOIN,

			/// <summary>The device is joined to Azure Active Directory (Azure AD).</summary>
			DSREG_DEVICE_JOIN,

			/// <summary>An Azure AD work account is added on the device.</summary>
			DSREG_WORKPLACE_JOIN,
		}

		/// <summary>The type of the name queried in <c>NetEnumerateComputerNames</c>.</summary>
		[PInvokeData("lmjoin.h", MSDNShortId = "c657ae33-404e-4c36-a956-5fbcfa540be7")]
		public enum NET_COMPUTER_NAME_TYPE
		{
			/// <summary>The primary computer name.</summary>
			NetPrimaryComputerName,

			/// <summary>Alternate computer names.</summary>
			NetAlternateComputerNames,

			/// <summary>All computer names.</summary>
			NetAllComputerNames,

			/// <summary>Indicates the end of the range that specifies the possible values for the type of name to be queried.</summary>
			NetComputerNameTypeMax
		}

		/// <summary>A set of bit flags defining domain join options.</summary>
		[PInvokeData("lmjoin.h", MSDNShortId = "4efcb399-03af-4312-9f1d-6bc38f356cac")]
		[Flags]
		public enum NETSETUP
		{
			/// <summary>Joins the computer to a domain. If this value is not specified, joins the computer to a workgroup.</summary>
			NETSETUP_JOIN_DOMAIN = 0x00000001,

			/// <summary>Creates the account on the domain.</summary>
			NETSETUP_ACCT_CREATE = 0x00000002,

			/// <summary>The account is disabled when the unjoin occurs.</summary>
			NETSETUP_ACCT_DELETE = 0x00000004,

			/// <summary>The join operation is occurring as part of an upgrade.</summary>
			NETSETUP_WIN9X_UPGRADE = 0x00000010,

			/// <summary>Allows a join to a new domain even if the computer is already joined to a domain.</summary>
			NETSETUP_DOMAIN_JOIN_IF_JOINED = 0x00000020,

			/// <summary>
			/// Performs an unsecured join.
			/// <para>
			/// This option requests a domain join to a pre-created account without authenticating with domain user credentials. This option
			/// can be used in conjunction with NETSETUP_MACHINE_PWD_PASSED option. In this case, lpPassword is the password of the
			/// pre-created machine account.
			/// </para>
			/// <para>
			/// Prior to Windows Vista with SP1 and Windows Server 2008, an unsecure join did not authenticate to the domain controller. All
			/// communication was performed using a null (unauthenticated) session.Starting with Windows Vista with SP1 and Windows Server
			/// 2008, the machine account name and password are used to authenticate to the domain controller.
			/// </para>
			/// </summary>
			NETSETUP_JOIN_UNSECURE = 0x00000040,

			/// <summary>
			/// Indicates that the lpPassword parameter specifies a local machine account password rather than a user password. This flag is
			/// valid only for unsecured joins, which you must indicate by also setting the NETSETUP_JOIN_UNSECURE flag.
			/// <para>
			/// If you set this flag, then after the join operation succeeds, the machine password will be set to the value of lpPassword, if
			/// that value is a valid machine password.
			/// </para>
			/// </summary>
			NETSETUP_MACHINE_PWD_PASSED = 0x00000080,

			/// <summary>
			/// Indicates that the service principal name (SPN) and the DnsHostName properties on the computer object should not be updated
			/// at this time.
			/// <para>
			/// Typically, these properties are updated during the join operation. Instead, these properties should be updated during a
			/// subsequent call to the NetRenameMachineInDomain function. These properties are always updated during the rename operation.
			/// For more information, see the following Remarks section.
			/// </para>
			/// </summary>
			NETSETUP_DEFER_SPN_SET = 0x00000100,

			/// <summary>
			/// Allow the domain join if existing account is a domain controller. <note type="note">This flag is supported on Windows Vista
			/// and later.</note>
			/// </summary>
			NETSETUP_JOIN_DC_ACCOUNT = 0x00000200,

			/// <summary>
			/// Join the target machine specified in lpServer parameter with a new name queried from the registry on the machine specified in
			/// the lpServer parameter.
			/// <para>
			/// This option is used if SetComputerNameEx has been called prior to rebooting the machine. The new computer name will not take
			/// effect until a reboot.With this option, the caller instructs the NetJoinDomain function to use the new name during the domain
			/// join operation.A reboot is required after calling NetJoinDomain successfully at which time both the computer name change and
			/// domain membership change will have taken affect.
			/// </para>
			/// <note type="note">This flag is supported on Windows Vista and later.</note>
			/// </summary>
			NETSETUP_JOIN_WITH_NEW_NAME = 0x00000400,

			/// <summary>
			/// Join the target machine specified in lpServer parameter using a pre-created account without requiring a writable domain controller.
			/// <para>
			/// This option provides the ability to join a machine to domain if an account has already been provisioned and replicated to a
			/// read-only domain controller. The target read-only domain controller is specified as part of the lpDomain parameter, after the
			/// domain name delimited by a ‘\’ character. This provisioning must include the machine secret. The machine account must be
			/// added via group membership into the allowed list for password replication policy, and the account password must be replicated
			/// to the read-only domain controller prior to the join operation. For more information, see the information on Password
			/// Replication Policy Administration.
			/// </para>
			/// <para>
			/// Starting with Windows 7, an alternate mechanism is to use the offline domain join mechanism. For more information, see the
			/// NetProvisionComputerAccount and NetRequestOfflineDomainJoin functions.
			/// </para>
			/// <note type="note">This flag is supported on Windows Vista and later.</note>
			/// </summary>
			NETSETUP_JOIN_READONLY = 0x00000800,

			/// <summary>Limits any updates to DNS-based names only.</summary>
			NETSETUP_DNS_NAME_CHANGES_ONLY = 0x00001000,

			/// <summary>Indicates that the protocol method was invoked during installation.</summary>
			NETSETUP_INSTALL_INVOCATION = 0x00040000,

			/// <summary>
			/// When joining the domain don't try to set the preferred domain controller in the registry. <note type="note">This flag is
			/// supported on Windows 7, Windows Server 2008 R2, and later.</note>
			/// </summary>
			NETSETUP_AMBIGUOUS_DC = 0x00001000,

			/// <summary>
			/// When joining the domain don't create the Netlogon cache. <note type="note">This flag is supported on Windows 7, Windows
			/// Server 2008 R2, and later.</note>
			/// </summary>
			NETSETUP_NO_NETLOGON_CACHE = 0x00002000,

			/// <summary>
			/// When joining the domain don't force Netlogon service to start. <note type="note">This flag is supported on Windows 7, Windows
			/// Server 2008 R2, and later.</note>
			/// </summary>
			NETSETUP_DONT_CONTROL_SERVICES = 0x00004000,

			/// <summary>
			/// When joining the domain for offline join only, set target machine hostname and NetBIOS name. <note type="note">This flag is
			/// supported on Windows 7, Windows Server 2008 R2, and later.</note>
			/// </summary>
			NETSETUP_SET_MACHINE_NAME = 0x00008000,

			/// <summary>
			/// When joining the domain, override other settings during domain join and set the service principal name (SPN).
			/// <note type="note">This flag is supported on Windows 7, Windows Server 2008 R2, and later.</note>
			/// </summary>
			NETSETUP_FORCE_SPN_SET = 0x00010000,

			/// <summary>
			/// When joining the domain, do not reuse an existing account. <note type="note">This flag is supported on Windows 7, Windows
			/// Server 2008 R2, and later.</note>
			/// </summary>
			NETSETUP_NO_ACCT_REUSE = 0x00020000,

			/// <summary>Undocumented.</summary>
			NETSETUP_ALT_SAMACCOUNTNAME = 0x00020000,

			/// <summary>
			/// If this bit is set, unrecognized flags will be ignored by the NetJoinDomain function and NetJoinDomain will behave as if the
			/// flags were not set.
			/// </summary>
			NETSETUP_IGNORE_UNSUPPORTED_FLAGS = 0x10000000,

			/// <summary>Valid unjoin flags.</summary>
			NETSETUP_VALID_UNJOIN_FLAGS = NETSETUP_ACCT_DELETE | NETSETUP_IGNORE_UNSUPPORTED_FLAGS | NETSETUP_JOIN_DC_ACCOUNT,

			/// <summary>Undocumented.</summary>
			NETSETUP_PROCESS_OFFLINE_FLAGS = NETSETUP_JOIN_DOMAIN | NETSETUP_DOMAIN_JOIN_IF_JOINED | NETSETUP_JOIN_WITH_NEW_NAME | NETSETUP_DONT_CONTROL_SERVICES | NETSETUP_MACHINE_PWD_PASSED,
		}

		/// <summary>The join status of the specified computer.</summary>
		[PInvokeData("lmjoin.h", MSDNShortId = "c7cc1cf2-4530-4039-806b-fbee572f564d")]
		public enum NETSETUP_JOIN_STATUS
		{
			/// <summary>The status is unknown.</summary>
			NetSetupUnknownStatus = 0,

			/// <summary>The computer is not joined.</summary>
			NetSetupUnjoined,

			/// <summary>The computer is joined to a workgroup.</summary>
			NetSetupWorkgroupName,

			/// <summary>The computer is joined to a domain.</summary>
			NetSetupDomainName
		}

		/// <summary>The type of the name passed in the lpName parameter of <see cref="NetValidateName"/> to validate.</summary>
		[PInvokeData("lmjoin.h", MSDNShortId = "772603df-ec17-4a83-a715-2d9a14d5c2bb")]
		public enum NETSETUP_NAME_TYPE
		{
			/// <summary>The nametype is unknown. If this value is used, the NetValidateName function fails with ERROR_INVALID_PARAMETER.</summary>
			NetSetupUnknown = 0,

			/// <summary>Verify that the NetBIOS computer name is valid and that it is not in use.</summary>
			NetSetupMachine,

			/// <summary>Verify that the workgroup name is valid.</summary>
			NetSetupWorkgroup,

			/// <summary>Verify that the domain name exists and that it is a domain.</summary>
			NetSetupDomain,

			/// <summary>Verify that the domain name is not in use.</summary>
			NetSetupNonExistentDomain,

			/// <summary>
			/// Verify that the DNS computer name is valid.
			/// <para>
			/// This value is supported on Windows 2000 and later. The application must be compiled with _WIN32_WINNT &gt;= 0x0500 to use
			/// this value.
			/// </para>
			/// </summary>
			NetSetupDnsMachine
		}

		/// <summary>Bit flags that define provisioning options.</summary>
		[PInvokeData("lmjoin.h", MSDNShortId = "4c854258-b84d-4ef3-a6da-ce0a9540ffd5")]
		[Flags]
		public enum NETSETUP_PROVISION : uint
		{
			/// <summary>
			/// If the caller requires account creation by privilege, this option will cause a retry on failure using account creation
			/// functions enabling interoperability with domain controllers running on earlier versions of Windows.
			/// <para>The lpMachineAccountOU is not supported when using downlevel privilege support.</para>
			/// </summary>
			NETSETUP_PROVISION_DOWNLEVEL_PRIV_SUPPORT = 0x00000001,

			/// <summary>
			/// If the named account already exists, an attempt will be made to reuse the existing account.
			/// <para>This option requires sufficient credentials for this operation (Domain Administrator or the object owner).</para>
			/// </summary>
			NETSETUP_PROVISION_REUSE_ACCOUNT = 0x00000002,

			/// <summary>
			/// Use the default machine account password which is the machine name in lowercase. This is largely to support the older
			/// unsecure join model where the pre-created account typically used this default password. <note type="note">Applications should
			/// avoid using this option if possible.This option as well as NetJoinDomain function with dwOptions set to
			/// NETSETUP_JOIN_UNSECURE for unsecure join should only be used on earlier versions of Windows.</note>
			/// </summary>
			NETSETUP_PROVISION_USE_DEFAULT_PASSWORD = 0x00000004,

			/// <summary>
			/// Do not try to find the account on any domain controller in the domain. This option makes the operation faster, but should
			/// only be used when the caller is certain that an account by the same name hasn't recently been created.
			/// <para>
			/// This option is only valid when the lpDcName parameter is specified. When the prerequisites are met, this option allows for
			/// must faster provisioning useful for scenarios such as batch processing.
			/// </para>
			/// </summary>
			NETSETUP_PROVISION_SKIP_ACCOUNT_SEARCH = 0x00000008,

			/// <summary>
			/// This option retrieves all of the root Certificate Authority certificates on the local machine and adds them to the
			/// provisioning package when no certificate template names are provided as part of the provisioning package (the
			/// aCertTemplateNames member of the NETSETUP_PROVISIONING_PARAMS struct passed in the pProvisioningParams parameter to the
			/// NetCreateProvisioningPackage function is NULL). <note type="note">This flag is only supported by the
			/// NetCreateProvisioningPackage function on Windows 8, Windows Server 2012, and later.</note>
			/// </summary>
			NETSETUP_PROVISION_ROOT_CA_CERTS = 0x00000010,

			/// <summary>Undocumented.</summary>
			NETSETUP_PROVISION_PERSISTENTSITE = 0x00000020,

			/// <summary>
			/// This flag is required if the lpWindowsPath parameter references the currently running Windows operating system directory
			/// rather than an offline Windows operating system image mounted on an accessible volume. If this flag is specified, the
			/// NetRequestProvisioningPackageInstall function must be invoked by a member of the local Administrators group.
			/// </summary>
			NETSETUP_PROVISION_ONLINE_CALLER = 0x40000000,

			/// <summary>Undocumented.</summary>
			NETSETUP_PROVISION_CHECK_PWD_ONLY = 0x80000000,
		}

		/// <summary>The <c>NetAddAlternateComputerName</c> function adds an alternate name for the specified computer.</summary>
		/// <param name="Server">
		/// A pointer to a constant string that specifies the name of the computer on which to execute this function. If this parameter is
		/// <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="AlternateName">
		/// A pointer to a constant string that specifies the alternate name to add. This name must be in the form of a fully qualified DNS name.
		/// </param>
		/// <param name="DomainAccount">
		/// <para>
		/// A pointer to a constant string that specifies the domain account to use for accessing the machine account object for the computer
		/// specified in the Server parameter in Active Directory. If this parameter is <c>NULL</c>, then the credentials of the user
		/// executing this routine are used.
		/// </para>
		/// <para>This parameter is not used if the server to execute this function is not joined to a domain.</para>
		/// </param>
		/// <param name="DomainAccountPassword">
		/// <para>
		/// A pointer to a constant string that specifies the password matching the domain account passed in the DomainAccount parameter. If
		/// this parameter is <c>NULL</c>, then the credentials of the user executing this routine are used.
		/// </para>
		/// <para>
		/// This parameter is ignored if the DomainAccount parameter is <c>NULL</c>. This parameter is not used if the server to execute this
		/// function is not joined to a domain.
		/// </para>
		/// </param>
		/// <param name="Reserved">Reserved for future use. This parameter should be <c>NULL</c>.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes or one of the system error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Access is denied. This error is returned if the caller was not a member of the Administrators local group on the target computer.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_NAME</term>
		/// <term>A name parameter is incorrect. This error is returned if the AlternateName parameter does not contain valid name.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// A parameter is incorrect. This error is returned if the DomainAccount parameter does not contain a valid domain. This error is
		/// also returned if the DomainAccount parameter is not NULL and the DomainAccountPassword parameter is not NULL but does not contain
		/// a Unicode string.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>Not enough memory is available to process this command.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if the target computer specified in the Server parameter on which this
		/// function executes is running on Windows 2000 and earlier.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NERR_WkstaNotStarted</term>
		/// <term>The Workstation service has not been started.</term>
		/// </item>
		/// <item>
		/// <term>RPC_S_CALL_IN_PROGRESS</term>
		/// <term>A remote procedure call is already in progress for this thread.</term>
		/// </item>
		/// <item>
		/// <term>RPC_S_PROTSEQ_NOT_SUPPORTED</term>
		/// <term>The remote procedure call protocol sequence is not supported.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>NetAddAlternateComputerName</c> function is supported on Windows XP and later.</para>
		/// <para>
		/// The <c>NetAddAlternateComputerName</c> function is used to set secondary network names for computers. The primary name is the
		/// name used for authentication and maps to the machine account name.
		/// </para>
		/// <para>
		/// The <c>NetAddAlternateComputerName</c> function requires that the caller is a member of the Administrators local group on the
		/// target computer.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmjoin/nf-lmjoin-netaddalternatecomputername NET_API_STATUS NET_API_FUNCTION
		// NetAddAlternateComputerName( LPCWSTR Server, LPCWSTR AlternateName, LPCWSTR DomainAccount, LPCWSTR DomainAccountPassword, ULONG
		// Reserved );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmjoin.h", MSDNShortId = "710865c6-e327-439c-931d-de8674d69233")]
		public static extern Win32Error NetAddAlternateComputerName([Optional] string Server, string AlternateName, [Optional] string DomainAccount, [Optional] string DomainAccountPassword, uint Reserved = 0);

		/// <summary>
		/// The NetCreateProvisioningPackage function creates a provisioning package that provisions a computer account for later use in an
		/// offline domain join operation. The package may also contain information about certificates and policies to add to the machine
		/// during provisioning.
		/// </summary>
		/// <param name="pProvisioningParams">
		/// <para>A pointer to a NETSETUP_PROVISIONING_PARAMS structure that contains information about the provisioning package.</para>
		/// <para>The following values are defined for the members of this structure:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>dwVersion</term>
		/// <term>
		/// The version of Windows in the provisioning package. This member should use the following value defined in the Lmjoin.h header
		/// file: NETSETUP_PROVISIONING_PARAMS_CURRENT_VERSION (0x00000001)
		/// </term>
		/// </item>
		/// <item>
		/// <term>lpDomain</term>
		/// <term>
		/// A pointer to a constant null-terminated character string that specifies the name of the domain where the computer account is created.
		/// </term>
		/// </item>
		/// <item>
		/// <term>lpMachineName</term>
		/// <term>
		/// A pointer to a constant null-terminated character string that specifies the short name of the machine from which the computer
		/// account attribute sAMAccountName is derived by appending a '$'. This parameter must contain a valid DNS or NetBIOS machine name.
		/// </term>
		/// </item>
		/// <item>
		/// <term>lpMachineAccountOU</term>
		/// <term>
		/// An optional pointer to a constant null-terminated character string that contains the RFC 1779 format name of the organizational
		/// unit (OU) where the computer account will be created. If you specify this parameter, the string must contain a full path, for
		/// example, OU=testOU,DC=domain,DC=Domain,DC=com. Otherwise, this parameter must be NULL. If this parameter is NULL, the well known
		/// computer object container will be used as published in the domain.
		/// </term>
		/// </item>
		/// <item>
		/// <term>lpDcName</term>
		/// <term>
		/// An optional pointer to a constant null-terminated character string that contains the name of the domain controller to target.
		/// </term>
		/// </item>
		/// <item>
		/// <term>dwProvisionOptions</term>
		/// <term>
		/// A set of bit flags that define provisioning options. This parameter can be one or more of the values specified for the dwOptions
		/// parameter passed to the NetProvisionComputerAccount function. These possible values are defined in the Lmjoin.h header file. The
		/// NETSETUP_PROVISION_ROOT_CA_CERTS option is only supported on Windows 8 and Windows Server 2012.
		/// </term>
		/// </item>
		/// <item>
		/// <term>aCertTemplateNames</term>
		/// <term>A optional pointer to an array of NULL-terminated certificate template names.</term>
		/// </item>
		/// <item>
		/// <term>cCertTemplateNames</term>
		/// <term>When aCertTemplateNames is not NULL, this member provides an explicit count of the number of items in the array.</term>
		/// </item>
		/// <item>
		/// <term>aMachinePolicyNames</term>
		/// <term>An optional pointer to an array of NULL-terminated machine policy names.</term>
		/// </item>
		/// <item>
		/// <term>cMachinePolicyNames</term>
		/// <term>When aMachinePolicyNames is not NULL, this member provides an explicit count of the number of items in the array.</term>
		/// </item>
		/// <item>
		/// <term>aMachinePolicyPaths</term>
		/// <term>
		/// An optional pointer to an array of character strings. Each array element is a NULL-terminated character string which specifies
		/// the full or partial path to a file in the Registry Policy File format. For more information on the Registry Policy File Format ,
		/// see Registry Policy File Format The path could be a UNC path on a remote server.
		/// </term>
		/// </item>
		/// <item>
		/// <term>cMachinePolicyPaths</term>
		/// <term>When aMachinePolicyPaths is not NULL, this member provides an explicit count of the number of items in the array.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="ppPackageBinData">
		/// <para>
		/// An optional pointer that will receive the package required by NetRequestOfflineDomainJoin function to complete an offline domain
		/// join, if the NetProvisionComputerAccount function completes successfully. The data is returned as an opaque binary buffer which
		/// may be passed to <c>NetRequestOfflineDomainJoin</c> function.
		/// </para>
		/// <para>
		/// If this parameter is <c>NULL</c>, then pPackageTextData parameter must not be <c>NULL</c>. If this parameter is not <c>NULL</c>,
		/// then the pPackageTextData parameter must be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="pdwPackageBinDataSize">
		/// <para>A pointer to a value that receives the size, in bytes, of the buffer returned in the pProvisionBinData parameter.</para>
		/// <para>
		/// This parameter must not be <c>NULL</c> if the pPackageBinData parameter is not <c>NULL</c>. This parameter must be <c>NULL</c>
		/// when the pPackageBinData parameter is <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="ppPackageTextData">
		/// <para>
		/// An optional pointer that will receive the package required by NetRequestOfflineDomainJoin function to complete an offline domain
		/// join, if the NetProvisionComputerAccount function completes successfully. The data is returned in string form for embedding in an
		/// unattended setup answer file.
		/// </para>
		/// <para>
		/// If this parameter is <c>NULL</c>, then the pPackageBinData parameter must not be <c>NULL</c>. If this parameter is not
		/// <c>NULL</c>, then the the pPackageBinData parameter must be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes or one of the system error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>Access is denied. This error is returned if the caller does not have sufficient privileges to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_DOMAIN_ROLE</term>
		/// <term>
		/// This operation is only allowed for the Primary Domain Controller of the domain. This error is returned if a domain controller
		/// name was specified in the lpDcName of the NETSETUP_PROVISIONING_PARAMS struct pointed to by the pProvisioningParams parameter,
		/// but the computer specified could not be validated as a domain controller for the target domain specified in the lpDomain of the NETSETUP_PROVISIONING_PARAMS.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// A parameter is incorrect. This error is also returned if both the pProvisioningParams parameter is NULL. This error is also
		/// returned if the lpDomain or lpMachineName member of the NETSETUP_PROVISIONING_PARAMS struct pointed to by the pProvisioningParams
		/// parameter is NULL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_SUCH_DOMAIN</term>
		/// <term>The specified domain did not exist.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if the lpMachineAccountOU member was specified in the
		/// NETSETUP_PROVISIONING_PARAMS struct pointed to by the pProvisioningParams parameter and the domain controller is running on an
		/// earlier versions of Windows that does not support this parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NERR_DS8DCRequired</term>
		/// <term>The specified domain controller does not meet the version requirement for this operation.</term>
		/// </item>
		/// <item>
		/// <term>NERR_LDAPCapableDCRequired</term>
		/// <term>This operation requires a domain controller which supports LDAP.</term>
		/// </item>
		/// <item>
		/// <term>NERR_UserExists</term>
		/// <term>
		/// The account already exists in the domain and the NETSETUP_PROVISION_REUSE_ACCOUNT bit was not specified in the dwProvisionOptions
		/// member of the NETSETUP_PROVISIONING_PARAMS struct pointed to by the pProvisioningParams parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NERR_WkstaNotStarted</term>
		/// <term>The Workstation service has not been started.</term>
		/// </item>
		/// <item>
		/// <term>RPC_S_CALL_IN_PROGRESS</term>
		/// <term>A remote procedure call is already in progress for this thread.</term>
		/// </item>
		/// <item>
		/// <term>RPC_S_PROTSEQ_NOT_SUPPORTED</term>
		/// <term>The remote procedure call protocol sequence is not supported.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>NetCreateProvisioningPackage</c> function is supported on Windows 8 and Windows Server 2012 for offline join operations.
		/// For Windows 7, use the NetProvisionComputerAccount function.
		/// </para>
		/// <para>
		/// The <c>NetCreateProvisioningPackage</c> function is used to provision a computer account for later use in an offline domain join
		/// operation using the NetRequestProvisioningPackageInstall function.
		/// </para>
		/// <para>The offline domain join scenario uses two functions:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// <c>NetCreateProvisioningPackage</c> is a provisioning function that is first called to perform the network operations necessary
		/// to create and configure the computer object in Active Directory. The output from the <c>NetCreateProvisioningPackage</c> is a
		/// package used for the next step.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// NetRequestProvisioningPackageInstall, an image initialization function, is called to inject the output from the
		/// <c>NetCreateProvisioningPackage</c> provisioning function into a Windows operating system image for use during pre-installation
		/// and post-installation.
		/// </term>
		/// </item>
		/// </list>
		/// <para>Changes to Windows initialization code will detect this saved state and affect the local-only portion of domain join.</para>
		/// <para>
		/// When the pPackageBinData and pdwPackageBinDataSize out pointers are used, set the pPackageTextData out pointer to NULL. When
		/// pPackageTextData is used, set the pPackageBinData and pdwPackageBinDataSize out pointers to NULL.
		/// </para>
		/// <para>
		/// The pProvisioningParams parameter specifies data to include in the provisioning package. The package includes information
		/// relevant to the domain join, and it can also include information about policies and certificates to install on the machine. The
		/// provisioning package can be used in four ways:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Domain join</term>
		/// </item>
		/// <item>
		/// <term>Domain join and installation of certificates</term>
		/// </item>
		/// <item>
		/// <term>Domain join and installation of policies</term>
		/// </item>
		/// <item>
		/// <term>Domain join and installation of certificates and policies</term>
		/// </item>
		/// </list>
		/// <para>
		/// The <c>NetCreateProvisioningPackage</c> function creates or reuses the machine account in the domain, collects all necessary
		/// metadata and returns it in a package. The package can be consumed by the offline domain join request operation supplying all the
		/// necessary input to complete the domain join during first boot without any network operations (local state updates only).
		/// </para>
		/// <para>
		/// <c>Security Note:</c> The package returned by the <c>NetCreateProvisioningPackage</c> function contains very sensitive data. It
		/// should be treated just as securely as a plaintext password. The package contains the machine account password and other
		/// information about the domain, including the domain name, the name of a domain controller, and the security ID (SID) of the
		/// domain. If the package is being transported physically or over the network, care must be taken to transport it securely. The
		/// design makes no provisions for securing this data. This problem exists today with unattended setup answer files which can carry a
		/// number of secrets including domain user passwords. The caller must secure the package. Solutions to this problem are varied. As
		/// an example, a pre-exchanged key could be used to encrypt a session between the consumer and provisioning entity enabling a secure
		/// transfer of the package.
		/// </para>
		/// <para>
		/// The package returned in the pPackageBinData parameter by the <c>NetCreateProvisioningPackage</c> function is versioned to allow
		/// interoperability and serviceability scenarios between different versions of Windows (such as joining a client, provisioning a
		/// machine, and using a domain controller). A package created on Windows 8 or Windows Server 2012 can be used Windows 7 or Windows
		/// Server 2008 R2, however only domain join information will take effect (certificates and policies are not supported). The offline
		/// join scenario currently does not limit the lifetime of the package returned by the <c>NetCreateProvisioningPackage</c> function.
		/// </para>
		/// <para>
		/// For offline domain joins, the access check performed depends on the configuration of the domain. Computer account creation is
		/// enabled using three methods:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Domain administrators have rights to create computer accounts.</term>
		/// </item>
		/// <item>
		/// <term>The SD on a container can delegate the rights to create computer accounts.</term>
		/// </item>
		/// <item>
		/// <term>
		/// By default, authenticated users may create computer accounts by privilege. Authenticated users are limited to creating a limited
		/// number of accounts that is specified as a quota on the domain (the default value is 10). For more information, see the
		/// ms-DS-MachineAccountQuota attribute in the Active Directory schema.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// The <c>NetCreateProvisioningPackage</c> function works only with a writable domain controller and does not function against a
		/// read-only domain controller. Once provisioning is done against a writable domain controller and the account is replicated to a
		/// read-only domain controller, the other portions of the offline domain join operation do not require access to a domain controller.
		/// </para>
		/// <para>
		/// If the <c>NetCreateProvisioningPackage</c> function is successful, the pointer in the pPackageBinData or pPackageTextData
		/// parameter (depending on which parameter was not <c>NULL</c>) is returned with the serialized data for use in an offline join
		/// operation or as text in an unattended setup file.
		/// </para>
		/// <para>
		/// All phases of the provisioning process append to a NetSetup.log file on the local computer. The provisoning process can include
		/// up to three different computers: the computer where the provisioning package is created, the computer that requests the
		/// installation of the package, and the computer where the package is installed. There will be NetSetup.log file information stored
		/// on all three computers according to the operation performed. Reviewing the contents of these files is the most common means of
		/// troubleshooting online and offline provisioning errors. Provisioning operations undertaken by admins are logged to the
		/// NetSetup.log file in the %WINDIR%\Debug. Provisioning operations performed by non-admins are logged to the NetSetup.log file in
		/// the %USERPROFILE%\Debug folder.
		/// </para>
		/// <para>For more information on offline domain join operations, see the Offline Domain Join Step-by-Step Guide.</para>
		/// <para>
		/// Joining (and unjoining) a computer to a domain using NetJoinDomain and NetUnjoinDomain is performed only by a member of the
		/// Administrators local group on the target computer. Note that the domain administrator can set additional requirements for joining
		/// the domain using delegation and assignment of privileges.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmjoin/nf-lmjoin-netcreateprovisioningpackage NET_API_STATUS NET_API_FUNCTION
		// NetCreateProvisioningPackage( PNETSETUP_PROVISIONING_PARAMS pProvisioningParams, PBYTE *ppPackageBinData, DWORD
		// *pdwPackageBinDataSize, LPWSTR *ppPackageTextData );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmjoin.h", MSDNShortId = "6E2A5578-8308-41E2-B5E9-5E34E9E76C0B")]
		public static extern Win32Error NetCreateProvisioningPackage(ref NETSETUP_PROVISIONING_PARAMS pProvisioningParams, out IntPtr ppPackageBinData,
			out uint pdwPackageBinDataSize, IntPtr ppPackageTextData = default);

		/// <summary>
		/// The NetCreateProvisioningPackage function creates a provisioning package that provisions a computer account for later use in an
		/// offline domain join operation. The package may also contain information about certificates and policies to add to the machine
		/// during provisioning.
		/// </summary>
		/// <param name="pProvisioningParams">
		/// <para>A pointer to a NETSETUP_PROVISIONING_PARAMS structure that contains information about the provisioning package.</para>
		/// <para>The following values are defined for the members of this structure:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>dwVersion</term>
		/// <term>
		/// The version of Windows in the provisioning package. This member should use the following value defined in the Lmjoin.h header
		/// file: NETSETUP_PROVISIONING_PARAMS_CURRENT_VERSION (0x00000001)
		/// </term>
		/// </item>
		/// <item>
		/// <term>lpDomain</term>
		/// <term>
		/// A pointer to a constant null-terminated character string that specifies the name of the domain where the computer account is created.
		/// </term>
		/// </item>
		/// <item>
		/// <term>lpMachineName</term>
		/// <term>
		/// A pointer to a constant null-terminated character string that specifies the short name of the machine from which the computer
		/// account attribute sAMAccountName is derived by appending a '$'. This parameter must contain a valid DNS or NetBIOS machine name.
		/// </term>
		/// </item>
		/// <item>
		/// <term>lpMachineAccountOU</term>
		/// <term>
		/// An optional pointer to a constant null-terminated character string that contains the RFC 1779 format name of the organizational
		/// unit (OU) where the computer account will be created. If you specify this parameter, the string must contain a full path, for
		/// example, OU=testOU,DC=domain,DC=Domain,DC=com. Otherwise, this parameter must be NULL. If this parameter is NULL, the well known
		/// computer object container will be used as published in the domain.
		/// </term>
		/// </item>
		/// <item>
		/// <term>lpDcName</term>
		/// <term>
		/// An optional pointer to a constant null-terminated character string that contains the name of the domain controller to target.
		/// </term>
		/// </item>
		/// <item>
		/// <term>dwProvisionOptions</term>
		/// <term>
		/// A set of bit flags that define provisioning options. This parameter can be one or more of the values specified for the dwOptions
		/// parameter passed to the NetProvisionComputerAccount function. These possible values are defined in the Lmjoin.h header file. The
		/// NETSETUP_PROVISION_ROOT_CA_CERTS option is only supported on Windows 8 and Windows Server 2012.
		/// </term>
		/// </item>
		/// <item>
		/// <term>aCertTemplateNames</term>
		/// <term>A optional pointer to an array of NULL-terminated certificate template names.</term>
		/// </item>
		/// <item>
		/// <term>cCertTemplateNames</term>
		/// <term>When aCertTemplateNames is not NULL, this member provides an explicit count of the number of items in the array.</term>
		/// </item>
		/// <item>
		/// <term>aMachinePolicyNames</term>
		/// <term>An optional pointer to an array of NULL-terminated machine policy names.</term>
		/// </item>
		/// <item>
		/// <term>cMachinePolicyNames</term>
		/// <term>When aMachinePolicyNames is not NULL, this member provides an explicit count of the number of items in the array.</term>
		/// </item>
		/// <item>
		/// <term>aMachinePolicyPaths</term>
		/// <term>
		/// An optional pointer to an array of character strings. Each array element is a NULL-terminated character string which specifies
		/// the full or partial path to a file in the Registry Policy File format. For more information on the Registry Policy File Format ,
		/// see Registry Policy File Format The path could be a UNC path on a remote server.
		/// </term>
		/// </item>
		/// <item>
		/// <term>cMachinePolicyPaths</term>
		/// <term>When aMachinePolicyPaths is not NULL, this member provides an explicit count of the number of items in the array.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="ppPackageBinData">
		/// <para>
		/// An optional pointer that will receive the package required by NetRequestOfflineDomainJoin function to complete an offline domain
		/// join, if the NetProvisionComputerAccount function completes successfully. The data is returned as an opaque binary buffer which
		/// may be passed to <c>NetRequestOfflineDomainJoin</c> function.
		/// </para>
		/// <para>
		/// If this parameter is <c>NULL</c>, then pPackageTextData parameter must not be <c>NULL</c>. If this parameter is not <c>NULL</c>,
		/// then the pPackageTextData parameter must be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="pdwPackageBinDataSize">
		/// <para>A pointer to a value that receives the size, in bytes, of the buffer returned in the pProvisionBinData parameter.</para>
		/// <para>
		/// This parameter must not be <c>NULL</c> if the pPackageBinData parameter is not <c>NULL</c>. This parameter must be <c>NULL</c>
		/// when the pPackageBinData parameter is <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="ppPackageTextData">
		/// <para>
		/// An optional pointer that will receive the package required by NetRequestOfflineDomainJoin function to complete an offline domain
		/// join, if the NetProvisionComputerAccount function completes successfully. The data is returned in string form for embedding in an
		/// unattended setup answer file.
		/// </para>
		/// <para>
		/// If this parameter is <c>NULL</c>, then the pPackageBinData parameter must not be <c>NULL</c>. If this parameter is not
		/// <c>NULL</c>, then the the pPackageBinData parameter must be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes or one of the system error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>Access is denied. This error is returned if the caller does not have sufficient privileges to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_DOMAIN_ROLE</term>
		/// <term>
		/// This operation is only allowed for the Primary Domain Controller of the domain. This error is returned if a domain controller
		/// name was specified in the lpDcName of the NETSETUP_PROVISIONING_PARAMS struct pointed to by the pProvisioningParams parameter,
		/// but the computer specified could not be validated as a domain controller for the target domain specified in the lpDomain of the NETSETUP_PROVISIONING_PARAMS.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// A parameter is incorrect. This error is also returned if both the pProvisioningParams parameter is NULL. This error is also
		/// returned if the lpDomain or lpMachineName member of the NETSETUP_PROVISIONING_PARAMS struct pointed to by the pProvisioningParams
		/// parameter is NULL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_SUCH_DOMAIN</term>
		/// <term>The specified domain did not exist.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if the lpMachineAccountOU member was specified in the
		/// NETSETUP_PROVISIONING_PARAMS struct pointed to by the pProvisioningParams parameter and the domain controller is running on an
		/// earlier versions of Windows that does not support this parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NERR_DS8DCRequired</term>
		/// <term>The specified domain controller does not meet the version requirement for this operation.</term>
		/// </item>
		/// <item>
		/// <term>NERR_LDAPCapableDCRequired</term>
		/// <term>This operation requires a domain controller which supports LDAP.</term>
		/// </item>
		/// <item>
		/// <term>NERR_UserExists</term>
		/// <term>
		/// The account already exists in the domain and the NETSETUP_PROVISION_REUSE_ACCOUNT bit was not specified in the dwProvisionOptions
		/// member of the NETSETUP_PROVISIONING_PARAMS struct pointed to by the pProvisioningParams parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NERR_WkstaNotStarted</term>
		/// <term>The Workstation service has not been started.</term>
		/// </item>
		/// <item>
		/// <term>RPC_S_CALL_IN_PROGRESS</term>
		/// <term>A remote procedure call is already in progress for this thread.</term>
		/// </item>
		/// <item>
		/// <term>RPC_S_PROTSEQ_NOT_SUPPORTED</term>
		/// <term>The remote procedure call protocol sequence is not supported.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>NetCreateProvisioningPackage</c> function is supported on Windows 8 and Windows Server 2012 for offline join operations.
		/// For Windows 7, use the NetProvisionComputerAccount function.
		/// </para>
		/// <para>
		/// The <c>NetCreateProvisioningPackage</c> function is used to provision a computer account for later use in an offline domain join
		/// operation using the NetRequestProvisioningPackageInstall function.
		/// </para>
		/// <para>The offline domain join scenario uses two functions:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// <c>NetCreateProvisioningPackage</c> is a provisioning function that is first called to perform the network operations necessary
		/// to create and configure the computer object in Active Directory. The output from the <c>NetCreateProvisioningPackage</c> is a
		/// package used for the next step.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// NetRequestProvisioningPackageInstall, an image initialization function, is called to inject the output from the
		/// <c>NetCreateProvisioningPackage</c> provisioning function into a Windows operating system image for use during pre-installation
		/// and post-installation.
		/// </term>
		/// </item>
		/// </list>
		/// <para>Changes to Windows initialization code will detect this saved state and affect the local-only portion of domain join.</para>
		/// <para>
		/// When the pPackageBinData and pdwPackageBinDataSize out pointers are used, set the pPackageTextData out pointer to NULL. When
		/// pPackageTextData is used, set the pPackageBinData and pdwPackageBinDataSize out pointers to NULL.
		/// </para>
		/// <para>
		/// The pProvisioningParams parameter specifies data to include in the provisioning package. The package includes information
		/// relevant to the domain join, and it can also include information about policies and certificates to install on the machine. The
		/// provisioning package can be used in four ways:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Domain join</term>
		/// </item>
		/// <item>
		/// <term>Domain join and installation of certificates</term>
		/// </item>
		/// <item>
		/// <term>Domain join and installation of policies</term>
		/// </item>
		/// <item>
		/// <term>Domain join and installation of certificates and policies</term>
		/// </item>
		/// </list>
		/// <para>
		/// The <c>NetCreateProvisioningPackage</c> function creates or reuses the machine account in the domain, collects all necessary
		/// metadata and returns it in a package. The package can be consumed by the offline domain join request operation supplying all the
		/// necessary input to complete the domain join during first boot without any network operations (local state updates only).
		/// </para>
		/// <para>
		/// <c>Security Note:</c> The package returned by the <c>NetCreateProvisioningPackage</c> function contains very sensitive data. It
		/// should be treated just as securely as a plaintext password. The package contains the machine account password and other
		/// information about the domain, including the domain name, the name of a domain controller, and the security ID (SID) of the
		/// domain. If the package is being transported physically or over the network, care must be taken to transport it securely. The
		/// design makes no provisions for securing this data. This problem exists today with unattended setup answer files which can carry a
		/// number of secrets including domain user passwords. The caller must secure the package. Solutions to this problem are varied. As
		/// an example, a pre-exchanged key could be used to encrypt a session between the consumer and provisioning entity enabling a secure
		/// transfer of the package.
		/// </para>
		/// <para>
		/// The package returned in the pPackageBinData parameter by the <c>NetCreateProvisioningPackage</c> function is versioned to allow
		/// interoperability and serviceability scenarios between different versions of Windows (such as joining a client, provisioning a
		/// machine, and using a domain controller). A package created on Windows 8 or Windows Server 2012 can be used Windows 7 or Windows
		/// Server 2008 R2, however only domain join information will take effect (certificates and policies are not supported). The offline
		/// join scenario currently does not limit the lifetime of the package returned by the <c>NetCreateProvisioningPackage</c> function.
		/// </para>
		/// <para>
		/// For offline domain joins, the access check performed depends on the configuration of the domain. Computer account creation is
		/// enabled using three methods:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Domain administrators have rights to create computer accounts.</term>
		/// </item>
		/// <item>
		/// <term>The SD on a container can delegate the rights to create computer accounts.</term>
		/// </item>
		/// <item>
		/// <term>
		/// By default, authenticated users may create computer accounts by privilege. Authenticated users are limited to creating a limited
		/// number of accounts that is specified as a quota on the domain (the default value is 10). For more information, see the
		/// ms-DS-MachineAccountQuota attribute in the Active Directory schema.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// The <c>NetCreateProvisioningPackage</c> function works only with a writable domain controller and does not function against a
		/// read-only domain controller. Once provisioning is done against a writable domain controller and the account is replicated to a
		/// read-only domain controller, the other portions of the offline domain join operation do not require access to a domain controller.
		/// </para>
		/// <para>
		/// If the <c>NetCreateProvisioningPackage</c> function is successful, the pointer in the pPackageBinData or pPackageTextData
		/// parameter (depending on which parameter was not <c>NULL</c>) is returned with the serialized data for use in an offline join
		/// operation or as text in an unattended setup file.
		/// </para>
		/// <para>
		/// All phases of the provisioning process append to a NetSetup.log file on the local computer. The provisoning process can include
		/// up to three different computers: the computer where the provisioning package is created, the computer that requests the
		/// installation of the package, and the computer where the package is installed. There will be NetSetup.log file information stored
		/// on all three computers according to the operation performed. Reviewing the contents of these files is the most common means of
		/// troubleshooting online and offline provisioning errors. Provisioning operations undertaken by admins are logged to the
		/// NetSetup.log file in the %WINDIR%\Debug. Provisioning operations performed by non-admins are logged to the NetSetup.log file in
		/// the %USERPROFILE%\Debug folder.
		/// </para>
		/// <para>For more information on offline domain join operations, see the Offline Domain Join Step-by-Step Guide.</para>
		/// <para>
		/// Joining (and unjoining) a computer to a domain using NetJoinDomain and NetUnjoinDomain is performed only by a member of the
		/// Administrators local group on the target computer. Note that the domain administrator can set additional requirements for joining
		/// the domain using delegation and assignment of privileges.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmjoin/nf-lmjoin-netcreateprovisioningpackage NET_API_STATUS NET_API_FUNCTION
		// NetCreateProvisioningPackage( PNETSETUP_PROVISIONING_PARAMS pProvisioningParams, PBYTE *ppPackageBinData, DWORD
		// *pdwPackageBinDataSize, LPWSTR *ppPackageTextData );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmjoin.h", MSDNShortId = "6E2A5578-8308-41E2-B5E9-5E34E9E76C0B")]
		public static extern Win32Error NetCreateProvisioningPackage(ref NETSETUP_PROVISIONING_PARAMS pProvisioningParams, [Optional] IntPtr ppPackageBinData,
			[Optional] IntPtr pdwPackageBinDataSize, ref StringBuilder ppPackageTextData);

		/// <summary>The <c>NetEnumerateComputerNames</c> function enumerates names for the specified computer.</summary>
		/// <param name="Server">
		/// A pointer to a constant string that specifies the name of the computer on which to execute this function. If this parameter is
		/// <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="NameType">
		/// <para>
		/// The type of the name queried. This member can be one of the following values defined in the <c>NET_COMPUTER_NAME_TYPE</c>
		/// enumeration defined in the Lmjoin.h header file.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NetPrimaryComputerName</term>
		/// <term>The primary computer name.</term>
		/// </item>
		/// <item>
		/// <term>NetAlternateComputerNames</term>
		/// <term>Alternate computer names.</term>
		/// </item>
		/// <item>
		/// <term>NetAllComputerNames</term>
		/// <term>All computer names.</term>
		/// </item>
		/// <item>
		/// <term>NetComputerNameTypeMax</term>
		/// <term>Indicates the end of the range that specifies the possible values for the type of name to be queried.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Reserved">Reserved for future use. This parameter should be <c>NULL</c>.</param>
		/// <param name="EntryCount">
		/// A pointer to a DWORD value that returns the number of names returned in the buffer pointed to by the ComputerNames parameter if
		/// the function succeeds.
		/// </param>
		/// <param name="ComputerNames">
		/// <para>
		/// A pointer to an array of pointers to names. If the function call is successful, this parameter will return the computer names
		/// that match the computer type name specified in the NameType parameter.
		/// </para>
		/// <para>When the application no longer needs this array, this buffer should be freed by calling NetApiBufferFree function.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes or one of the system error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Access is denied. This error is returned if the caller was not a member of the Administrators local group on the target computer.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>A parameter is incorrect.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>Not enough memory is available to process this command.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if the target computer specified in the Server parameter on which this
		/// function executes is running on Windows 2000 and earlier.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NERR_WkstaNotStarted</term>
		/// <term>The Workstation service has not been started.</term>
		/// </item>
		/// <item>
		/// <term>RPC_S_CALL_IN_PROGRESS</term>
		/// <term>A remote procedure call is already in progress for this thread.</term>
		/// </item>
		/// <item>
		/// <term>RPC_S_PROTSEQ_NOT_SUPPORTED</term>
		/// <term>The remote procedure call protocol sequence is not supported.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>NetEnumerateComputerNames</c> function is supported on Windows Vista and later.</para>
		/// <para>The <c>NetEnumerateComputerNames</c> function is used to request the names a computer currently has configured.</para>
		/// <para>
		/// The <c>NetEnumerateComputerNames</c> function requires that the caller is a member of the Administrators local group on the
		/// target computer.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmjoin/nf-lmjoin-netenumeratecomputernames NET_API_STATUS NET_API_FUNCTION
		// NetEnumerateComputerNames( LPCWSTR Server, NET_COMPUTER_NAME_TYPE NameType, ULONG Reserved, PDWORD EntryCount, LPWSTR
		// **ComputerNames );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmjoin.h", MSDNShortId = "c657ae33-404e-4c36-a956-5fbcfa540be7")]
		public static extern Win32Error NetEnumerateComputerNames(string Server, NET_COMPUTER_NAME_TYPE NameType, [Optional] uint Reserved,
			out uint EntryCount, out SafeNetApiBuffer ComputerNames);

		/// <summary>
		/// Frees the memory allocated for the specified DSREG_JOIN_INFO structure, which contains join information for a tenant and which
		/// you retrieved by calling the NetGetAadJoinInformation function.
		/// </summary>
		/// <param name="pJoinInfo">Pointer to the DSREG_JOIN_INFO structure for which you want to free the memory.</param>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmjoin/nf-lmjoin-netfreeaadjoininformation VOID NET_API_FUNCTION
		// NetFreeAadJoinInformation( PDSREG_JOIN_INFO pJoinInfo );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("lmjoin.h", MSDNShortId = "BDFB6179-4B8C-43E3-8D34-A2B470EA0D0B")]
		public static extern void NetFreeAadJoinInformation(HANDLE pJoinInfo);

		/// <summary>
		/// Retrieves the join information for the specified tenant. This function examines the join information for Microsoft Azure Active
		/// Directory and the work account that the current user added.
		/// </summary>
		/// <param name="pcszTenantId">
		/// <para>
		/// The tenant identifier for the joined account. If the device is not joined to Azure Active Directory (Azure AD), and the user
		/// currently logged into Windows added no Azure AD work accounts for the specified tenant, the buffer that the ppJoinInfo parameter
		/// points to is set to NULL.
		/// </para>
		/// <para>
		/// If the specified tenant ID is NULL or empty, ppJoinInfo is set to the default join account information, or NULL if the device is
		/// not joined to Azure AD and the current user added no Azure AD work accounts.
		/// </para>
		/// </param>
		/// <param name="ppJoinInfo">
		/// The join information for the tenant that the pcszTenantId parameter specifies. If this parameter is NULL, the device is not
		/// joined to Azure AD and the current user added no Azure AD work accounts. You must call the NetFreeAadJoinInformation function to
		/// free the memory allocated for this structure.
		/// </param>
		/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmjoin/nf-lmjoin-netgetaadjoininformation HRESULT NET_API_FUNCTION
		// NetGetAadJoinInformation( LPCWSTR pcszTenantId, PDSREG_JOIN_INFO *ppJoinInfo );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("lmjoin.h", MSDNShortId = "C63B3AA7-FC7E-4CB9-9318-BD25560591AB")]
		public static extern HRESULT NetGetAadJoinInformation([MarshalAs(UnmanagedType.LPWStr), Optional] string pcszTenantId, out DSREG_JOIN_INFO ppJoinInfo);

		/// <summary>
		/// The <c>NetGetJoinableOUs</c> function retrieves a list of organizational units (OUs) in which a computer account can be created.
		/// </summary>
		/// <param name="lpServer">Pointer to a constant string that specifies the DNS or NetBIOS name of the computer on which to call the function. If this
		/// parameter is <c>NULL</c>, the local computer is used.</param>
		/// <param name="lpDomain">Pointer to a constant string that specifies the name of the domain for which to retrieve the list of OUs that can be joined.</param>
		/// <param name="lpAccount">Pointer to a constant string that specifies the account name to use when connecting to the domain controller. The string must
		/// specify either a domain NetBIOS name and user account (for example, "REDMOND\user") or the user principal name (UPN) of the user
		/// in the form of an Internet-style login name (for example, "someone@example.com"). If this parameter is <c>NULL</c>, the caller's
		/// context is used.</param>
		/// <param name="lpPassword">If the lpAccount parameter specifies an account name, this parameter must point to the password to use when connecting to the
		/// domain controller. Otherwise, this parameter must be <c>NULL</c>.</param>
		/// <param name="OUCount">Receives the count of OUs returned in the list of joinable OUs.</param>
		/// <param name="OUs">Pointer to an array that receives the list of joinable OUs. This array is allocated by the system and must be freed using a
		/// single call to the NetApiBufferFree function. For more information, see Network Management Function Buffers and Network
		/// Management Function Buffer Lengths.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes or one of the system error codes.</para>
		/// <list type="table">
		///   <listheader>
		///     <term>Return code</term>
		///     <term>Description</term>
		///   </listheader>
		///   <item>
		///     <term>ERROR_NOT_ENOUGH_MEMORY</term>
		///     <term>Not enough storage is available to process this command.</term>
		///   </item>
		///   <item>
		///     <term>NERR_DefaultJoinRequired</term>
		///     <term>The destination domain controller does not support creating computer accounts in OUs.</term>
		///   </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>No special group membership is required to successfully execute the <c>NetGetJoinableOUs</c> function.</para>
		/// <para>For more information about organizational units, see Managing Users in the Active Directory documentation.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmjoin/nf-lmjoin-netgetjoinableous NET_API_STATUS NET_API_FUNCTION
		// NetGetJoinableOUs( LPCWSTR lpServer, LPCWSTR lpDomain, LPCWSTR lpAccount, LPCWSTR lpPassword, DWORD *OUCount, LPWSTR **OUs );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmjoin.h", MSDNShortId = "1faa912b-c56d-431c-95d5-d36790b0d467")]
		public static extern Win32Error NetGetJoinableOUs([Optional] string lpServer, string lpDomain, [Optional] string lpAccount, [Optional] string lpPassword, out uint OUCount,
			out SafeNetApiBuffer OUs);

		/// <summary>The <c>NetGetJoinInformation</c> function retrieves join status information for the specified computer.</summary>
		/// <param name="lpServer">
		/// Pointer to a constant string that specifies the DNS or NetBIOS name of the computer on which to call the function. If this
		/// parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="lpNameBuffer">
		/// Pointer to the buffer that receives the NetBIOS name of the domain or workgroup to which the computer is joined. This buffer is
		/// allocated by the system and must be freed using the NetApiBufferFree function. For more information, see Network Management
		/// Function Buffers and Network Management Function Buffer Lengths.
		/// </param>
		/// <param name="BufferType">Receives the join status of the specified computer. This parameter can have one of the following values.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be the following error code or one of the system error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>Not enough storage is available to process this command.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>No special group membership is required to successfully execute the <c>NetGetJoinInformation</c> function.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmjoin/nf-lmjoin-netgetjoininformation NET_API_STATUS NET_API_FUNCTION
		// NetGetJoinInformation( LPCWSTR lpServer, LPWSTR *lpNameBuffer, PNETSETUP_JOIN_STATUS BufferType );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmjoin.h", MSDNShortId = "c7cc1cf2-4530-4039-806b-fbee572f564d")]
		public static extern Win32Error NetGetJoinInformation([Optional] string lpServer,
			[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NetApiBufferUnicodeStringMarshaler))] out string lpNameBuffer, out NETSETUP_JOIN_STATUS BufferType);

		/// <summary>The <c>NetJoinDomain</c> function joins a computer to a workgroup or domain.</summary>
		/// <param name="lpServer">
		/// A pointer to a constant string that specifies the DNS or NetBIOS name of the computer on which to execute the domain join
		/// operation. If this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="lpDomain">
		/// <para>A pointer to a constant null-terminated character string that specifies the name of the domain or workgroup to join.</para>
		/// <para>
		/// Optionally, you can specify the preferred domain controller to perform the join operation. In this instance, the string must be
		/// of the form DomainName\MachineName, where DomainName is the name of the domain to join, and MachineName is the name of the domain
		/// controller to perform the join.
		/// </para>
		/// </param>
		/// <param name="lpMachineAccountOU">
		/// Optionally specifies the pointer to a constant null-terminated character string that contains the RFC 1779 format name of the
		/// organizational unit (OU) for the computer account. If you specify this parameter, the string must contain a full path, for
		/// example, OU=testOU,DC=domain,DC=Domain,DC=com. Otherwise, this parameter must be <c>NULL</c>.
		/// </param>
		/// <param name="lpAccount">
		/// A pointer to a constant null-terminated character string that specifies the account name to use when connecting to the domain
		/// controller. The string must specify either a domain NetBIOS name and user account (for example, REDMOND\user) or the user
		/// principal name (UPN) of the user in the form of an Internet-style login name (for example, "someone@example.com"). If this
		/// parameter is <c>NULL</c>, the caller's context is used.
		/// </param>
		/// <param name="lpPassword">
		/// <para>
		/// If the lpAccount parameter specifies an account name, this parameter must point to the password to use when connecting to the
		/// domain controller. Otherwise, this parameter must be <c>NULL</c>.
		/// </para>
		/// <para>
		/// You can specify a local machine account password rather than a user password for unsecured joins. For more information, see the
		/// description of the NETSETUP_MACHINE_PWD_PASSED flag described in the fJoinOptions parameter.
		/// </para>
		/// </param>
		/// <param name="fJoinOptions">
		/// <para>
		/// A set of bit flags defining the join options. This parameter can be one or more of the following values defined in the Lmjoin.h
		/// header file.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NETSETUP_JOIN_DOMAIN 0x00000001</term>
		/// <term>Joins the computer to a domain. If this value is not specified, joins the computer to a workgroup.</term>
		/// </item>
		/// <item>
		/// <term>NETSETUP_ACCT_CREATE 0x00000002</term>
		/// <term>Creates the account on the domain.</term>
		/// </item>
		/// <item>
		/// <term>NETSETUP_WIN9X_UPGRADE 0x00000010</term>
		/// <term>The join operation is occurring as part of an upgrade.</term>
		/// </item>
		/// <item>
		/// <term>NETSETUP_DOMAIN_JOIN_IF_JOINED 0x00000020</term>
		/// <term>Allows a join to a new domain even if the computer is already joined to a domain.</term>
		/// </item>
		/// <item>
		/// <term>NETSETUP_JOIN_UNSECURE 0x00000040</term>
		/// <term>
		/// Performs an unsecured join. This option requests a domain join to a pre-created account without authenticating with domain user
		/// credentials. This option can be used in conjunction with NETSETUP_MACHINE_PWD_PASSED option. In this case, lpPassword is the
		/// password of the pre-created machine account. Prior to Windows Vista with SP1 and Windows Server 2008, an unsecure join did not
		/// authenticate to the domain controller. All communication was performed using a null (unauthenticated) session. Starting with
		/// Windows Vista with SP1 and Windows Server 2008, the machine account name and password are used to authenticate to the domain controller.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NETSETUP_MACHINE_PWD_PASSED 0x00000080</term>
		/// <term>
		/// Indicates that the lpPassword parameter specifies a local machine account password rather than a user password. This flag is
		/// valid only for unsecured joins, which you must indicate by also setting the NETSETUP_JOIN_UNSECURE flag. If you set this flag,
		/// then after the join operation succeeds, the machine password will be set to the value of lpPassword, if that value is a valid
		/// machine password.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NETSETUP_DEFER_SPN_SET 0x00000100</term>
		/// <term>
		/// Indicates that the service principal name (SPN) and the DnsHostName properties on the computer object should not be updated at
		/// this time. Typically, these properties are updated during the join operation. Instead, these properties should be updated during
		/// a subsequent call to the NetRenameMachineInDomain function. These properties are always updated during the rename operation. For
		/// more information, see the following Remarks section.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NETSETUP_JOIN_DC_ACCOUNT 0x00000200</term>
		/// <term>Allow the domain join if existing account is a domain controller.</term>
		/// </item>
		/// <item>
		/// <term>NETSETUP_JOIN_WITH_NEW_NAME 0x00000400</term>
		/// <term>
		/// Join the target machine specified in lpServer parameter with a new name queried from the registry on the machine specified in the
		/// lpServer parameter. This option is used if SetComputerNameEx has been called prior to rebooting the machine. The new computer
		/// name will not take effect until a reboot. With this option, the caller instructs the NetJoinDomain function to use the new name
		/// during the domain join operation. A reboot is required after calling NetJoinDomain successfully at which time both the computer
		/// name change and domain membership change will have taken affect.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NETSETUP_JOIN_READONLY 0x00000800</term>
		/// <term>
		/// Join the target machine specified in lpServer parameter using a pre-created account without requiring a writable domain
		/// controller. This option provides the ability to join a machine to domain if an account has already been provisioned and
		/// replicated to a read-only domain controller. The target read-only domain controller is specified as part of the lpDomain
		/// parameter, after the domain name delimited by a ‘\’ character. This provisioning must include the machine secret. The machine
		/// account must be added via group membership into the allowed list for password replication policy, and the account password must
		/// be replicated to the read-only domain controller prior to the join operation. For more information, see the information on
		/// Password Replication Policy Administration. Starting with Windows 7, an alternate mechanism is to use the offline domain join
		/// mechanism. For more information, see the NetProvisionComputerAccount and NetRequestOfflineDomainJoin functions.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NETSETUP_AMBIGUOUS_DC 0x00001000</term>
		/// <term>When joining the domain don't try to set the preferred domain controller in the registry.</term>
		/// </item>
		/// <item>
		/// <term>NETSETUP_NO_NETLOGON_CACHE 0x00002000</term>
		/// <term>When joining the domain don't create the Netlogon cache.</term>
		/// </item>
		/// <item>
		/// <term>NETSETUP_DONT_CONTROL_SERVICES 0x00004000</term>
		/// <term>When joining the domain don't force Netlogon service to start.</term>
		/// </item>
		/// <item>
		/// <term>NETSETUP_SET_MACHINE_NAME 0x00008000</term>
		/// <term>When joining the domain for offline join only, set target machine hostname and NetBIOS name.</term>
		/// </item>
		/// <item>
		/// <term>NETSETUP_FORCE_SPN_SET 0x00010000</term>
		/// <term>When joining the domain, override other settings during domain join and set the service principal name (SPN).</term>
		/// </item>
		/// <item>
		/// <term>NETSETUP_NO_ACCT_REUSE 0x00020000</term>
		/// <term>When joining the domain, do not reuse an existing account.</term>
		/// </item>
		/// <item>
		/// <term>NETSETUP_IGNORE_UNSUPPORTED_FLAGS 0x10000000</term>
		/// <term>
		/// If this bit is set, unrecognized flags will be ignored by the NetJoinDomain function and NetJoinDomain will behave as if the
		/// flags were not set.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes or one of the system error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Access is denied. This error is returned if the caller was not a member of the Administrators local group on the target computer.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>A parameter is incorrect. This error is returned if the lpDomain parameter is NULL.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_SUCH_DOMAIN</term>
		/// <term>The specified domain did not exist.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if the computer specified in the lpServer parameter does not support some of
		/// the options passed in the fJoinOptions parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NERR_InvalidWorkgroupName</term>
		/// <term>The specified workgroup name is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NERR_SetupAlreadyJoined</term>
		/// <term>The computer is already joined to a domain.</term>
		/// </item>
		/// <item>
		/// <term>NERR_WkstaNotStarted</term>
		/// <term>The Workstation service has not been started.</term>
		/// </item>
		/// <item>
		/// <term>RPC_S_CALL_IN_PROGRESS</term>
		/// <term>A remote procedure call is already in progress for this thread.</term>
		/// </item>
		/// <item>
		/// <term>RPC_S_PROTSEQ_NOT_SUPPORTED</term>
		/// <term>The remote procedure call protocol sequence is not supported.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Joining (and unjoining) a computer to a domain or workgroup can be performed only by a member of the Administrators local group
		/// on the target computer. Note that the domain administrator can set additional requirements for joining the domain using
		/// delegation and assignment of privileges.
		/// </para>
		/// <para>
		/// If you call the <c>NetJoinDomain</c> function remotely, you must supply credentials because you cannot delegate credentials under
		/// these circumstances.
		/// </para>
		/// <para>
		/// Different processes, or different threads of the same process, should not call the <c>NetJoinDomain</c> function at the same
		/// time. This situation can leave the computer in an inconsistent state.
		/// </para>
		/// <para>
		/// If you encounter a problem during a join operation, you should not delete a computer account and immediately follow the deletion
		/// with another join attempt. This can lead to replication-related problems that are difficult to investigate. When you delete a
		/// computer account, wait until the change has replicated to all domain controllers before attempting another join operation.
		/// </para>
		/// <para>A system reboot is required after calling the <c>NetJoinDomain</c> function for the operation to complete.</para>
		/// <para>
		/// <c>Windows Server 2003 and Windows XP:</c> When a call to the <c>NetJoinDomain</c> function precedes a call to the
		/// NetRenameMachineInDomain function, you should defer the update of the SPN and DnsHostName properties on the computer object until
		/// the rename operation. This is because the join operation can fail in certain situations. An example of such a situation is when
		/// the SPN that is derived from the current computer name is not valid in the new domain that the computer is joining, but the SPN
		/// derived from the new name that the computer will have after the rename operation is valid in the new domain. In this situation,
		/// the call to <c>NetJoinDomain</c> fails unless you defer the update of the two properties until the rename operation by specifying
		/// the NETSETUP_DEFER_SPN_SET flag in the fJoinOptions parameter when you call <c>NetJoinDomain</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmjoin/nf-lmjoin-netjoindomain NET_API_STATUS NET_API_FUNCTION NetJoinDomain(
		// LPCWSTR lpServer, LPCWSTR lpDomain, LPCWSTR lpMachineAccountOU, LPCWSTR lpAccount, LPCWSTR lpPassword, DWORD fJoinOptions );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmjoin.h", MSDNShortId = "4efcb399-03af-4312-9f1d-6bc38f356cac")]
		public static extern Win32Error NetJoinDomain([Optional] string lpServer, string lpDomain, [Optional] string lpMachineAccountOU, [Optional] string lpAccount, [Optional] string lpPassword, NETSETUP fJoinOptions);

		/// <summary>
		/// The <c>NetProvisionComputerAccount</c> function provisions a computer account for later use in an offline domain join operation.
		/// </summary>
		/// <param name="lpDomain">
		/// A pointer to a <c>NULL</c>-terminated character string that specifies the name of the domain where the computer account is created.
		/// </param>
		/// <param name="lpMachineName">
		/// A pointer to a <c>NULL</c>-terminated character string that specifies the short name of the machine from which the computer
		/// account attribute sAMAccountName is derived by appending a '$'. This parameter must contain a valid DNS or NetBIOS machine name.
		/// </param>
		/// <param name="lpMachineAccountOU">
		/// <para>
		/// An optional pointer to a <c>NULL</c>-terminated character string that contains the RFC 1779 format name of the organizational
		/// unit (OU) where the computer account will be created. If you specify this parameter, the string must contain a full path, for
		/// example, OU=testOU,DC=domain,DC=Domain,DC=com. Otherwise, this parameter must be <c>NULL</c>.
		/// </para>
		/// <para>If this parameter is <c>NULL</c>, the well known computer object container will be used as published in the domain.</para>
		/// </param>
		/// <param name="lpDcName">
		/// An optional pointer to a <c>NULL</c>-terminated character string that contains the name of the domain controller to target.
		/// </param>
		/// <param name="dwOptions">
		/// <para>
		/// A set of bit flags that define provisioning options. This parameter can be one or more of the following values defined in the
		/// Lmjoin.h header file.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NETSETUP_PROVISION_DOWNLEVEL_PRIV_SUPPORT 0x00000001</term>
		/// <term>
		/// If the caller requires account creation by privilege, this option will cause a retry on failure using account creation functions
		/// enabling interoperability with domain controllers running on earlier versions of Windows. The lpMachineAccountOU is not supported
		/// when using downlevel privilege support.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NETSETUP_PROVISION_REUSE_ACCOUNT 0x00000002</term>
		/// <term>
		/// If the named account already exists, an attempt will be made to reuse the existing account. This option requires sufficient
		/// credentials for this operation (Domain Administrator or the object owner).
		/// </term>
		/// </item>
		/// <item>
		/// <term>NETSETUP_PROVISION_USE_DEFAULT_PASSWORD 0x00000004</term>
		/// <term>
		/// Use the default machine account password which is the machine name in lowercase. This is largely to support the older unsecure
		/// join model where the pre-created account typically used this default password.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NETSETUP_PROVISION_SKIP_ACCOUNT_SEARCH 0x00000008</term>
		/// <term>
		/// Do not try to find the account on any domain controller in the domain. This option makes the operation faster, but should only be
		/// used when the caller is certain that an account by the same name hasn't recently been created. This option is only valid when the
		/// lpDcName parameter is specified. When the prerequisites are met, this option allows for must faster provisioning useful for
		/// scenarios such as batch processing.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NETSETUP_PROVISION_ROOT_CA_CERTS 0x00000010</term>
		/// <term>
		/// This option retrieves all of the root Certificate Authority certificates on the local machine and adds them to the provisioning
		/// package when no certificate template names are provided as part of the provisioning package (the aCertTemplateNames member of the
		/// NETSETUP_PROVISIONING_PARAMS struct passed in the pProvisioningParams parameter to the NetCreateProvisioningPackage function is NULL).
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pProvisionBinData">
		/// <para>
		/// An optional pointer that will receive the opaque binary blob of serialized metadata required by NetRequestOfflineDomainJoin
		/// function to complete an offline domain join, if the <c>NetProvisionComputerAccount</c> function completes successfully. The data
		/// is returned as an opaque binary buffer which may be passed to <c>NetRequestOfflineDomainJoin</c> function.
		/// </para>
		/// <para>
		/// If this parameter is <c>NULL</c>, then pProvisionTextData parameter must not be <c>NULL</c>. If this parameter is not
		/// <c>NULL</c>, then the pProvisionTextData parameter must be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="pdwProvisionBinDataSize">
		/// <para>A pointer to a value that receives the size, in bytes, of the buffer returned in the pProvisionBinData parameter.</para>
		/// <para>
		/// This parameter must not be <c>NULL</c> if the pProvisionBinData parameter is not <c>NULL</c>. This parameter must be <c>NULL</c>
		/// when the pProvisionBinData parameter is <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="pProvisionTextData">
		/// <para>
		/// An optional pointer that will receive the opaque binary blob of serialized metadata required by NetRequestOfflineDomainJoin
		/// function to complete an offline domain join, if the <c>NetProvisionComputerAccount</c> function completes successfully. The data
		/// is returned in string form for embedding in an unattended setup answer file.
		/// </para>
		/// <para>
		/// If this parameter is <c>NULL</c>, then the pProvisionBinData parameter must not be <c>NULL</c>. If this parameter is not
		/// <c>NULL</c>, then the the pProvisionBinData parameter must be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes or one of the system error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>Access is denied. This error is returned if the caller does not have sufficient privileges to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_DOMAIN_ROLE</term>
		/// <term>
		/// This operation is only allowed for the Primary Domain Controller of the domain. This error is returned if a domain controller
		/// name was specified in the lpDcName parameter, but the computer specified could not be validated as a domain controller for the
		/// target domain specified in the lpDomain parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// A parameter is incorrect. This error is returned if the lpDomain or lpMachineName parameter is NULL. This error is also returned
		/// if both the pProvisionBinData and pProvisionTextData parameters are NULL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_SUCH_DOMAIN</term>
		/// <term>The specified domain did not exist.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if the lpMachineAccountOU parameter was specified and the domain controller
		/// is running on an earlier versions of Windows that does not support this parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NERR_DS8DCRequired</term>
		/// <term>The specified domain controller does not meet the version requirement for this operation.</term>
		/// </item>
		/// <item>
		/// <term>NERR_LDAPCapableDCRequired</term>
		/// <term>This operation requires a domain controller which supports LDAP.</term>
		/// </item>
		/// <item>
		/// <term>NERR_UserExists</term>
		/// <term>
		/// The account already exists in the domain and the NETSETUP_PROVISION_REUSE_ACCOUNT bit was not specified in the dwOptions parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NERR_WkstaNotStarted</term>
		/// <term>The Workstation service has not been started.</term>
		/// </item>
		/// <item>
		/// <term>RPC_S_CALL_IN_PROGRESS</term>
		/// <term>A remote procedure call is already in progress for this thread.</term>
		/// </item>
		/// <item>
		/// <term>RPC_S_PROTSEQ_NOT_SUPPORTED</term>
		/// <term>The remote procedure call protocol sequence is not supported.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>NetProvisionComputerAccount</c> function is supported on Windows 7 and Windows Server 2008 R2 for offline join operations.
		/// On Windows 8 or Windows Server 2008 R2, it is recommended that the NetCreateProvisioningPackage function be used instead of the
		/// <c>NetProvisionComputerAccount</c> function.
		/// </para>
		/// <para>
		/// The <c>NetProvisionComputerAccount</c> function is used to provision a computer account for later use in an offline domain join
		/// operation using the NetRequestOfflineDomainJoin function. The offline domain join scenario uses these functions as follows:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// <c>NetProvisionComputerAccount</c> is a provisioning function that is first called to perform the network operations necessary to
		/// create and configure the computer object in Active Directory. The output from the <c>NetProvisionComputerAccount</c> is an opaque
		/// binary blob of serialized metadata used for the next step.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// NetRequestOfflineDomainJoin, an image initialization function, is then called to inject the output from the
		/// <c>NetProvisionComputerAccount</c> provisioning function into a Windows operating system image to be used during installation.
		/// </term>
		/// </item>
		/// </list>
		/// <para>Changes to Windows initialization code will detect this saved state and affect the local only portion of domain join.</para>
		/// <para>
		/// The <c>NetProvisionComputerAccount</c> function will create or reuse the machine account in the domain, collect all necessary
		/// metadata and return it in an opaque versioned binary blob or as text for embedding in an unattended setup answer file. The opaque
		/// binary blob can be consumed by the offline domain join request operation supplying all the necessary input to complete the domain
		/// join during first boot without any network operations (local state updates only).
		/// </para>
		/// <para>
		/// <c>Security Note:</c> The blob returned by the <c>NetProvisionComputerAccount</c> function contains very sensitive data. It
		/// should be treated just as securely as a plaintext password. The blob contains the machine account password and other information
		/// about the domain, including the domain name, the name of a domain controller, and the security ID (SID) of the domain. If the
		/// blob is being transported physically or over the network, care must be taken to transport it securely. The design makes no
		/// provisions for securing this data. This problem exists today with unattended setup answer files which can carry a number of
		/// secrets including domain user passwords. The caller must secure the blob and the unattended setup files. Solutions to this
		/// problem are varied. As an example, a pre-exchanged key could be used to encrypt a session between the consumer and provisioning
		/// entity enabling a secure transfer of the opaque blob.
		/// </para>
		/// <para>
		/// The opaque blob returned in the pProvisionBinData parameter by the <c>NetProvisionComputerAccount</c> function is versioned to
		/// allow interoperability and serviceability scenarios between different versions of Windows (joining client, provisioning machine,
		/// and domain controller). The offline join scenario currently does not limit the lifetime of the blob returned by the
		/// <c>NetProvisionComputerAccount</c> function.
		/// </para>
		/// <para>
		/// For offline domain joins, the access check performed depends on the configuration of the domain. Computer account creation is
		/// enabled using three methods:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Domain administrators have rights to create computer accounts.</term>
		/// </item>
		/// <item>
		/// <term>The SD on a container can delegate the rights to create computer accounts.</term>
		/// </item>
		/// <item>
		/// <term>
		/// By default, authenticated users may create computer accounts by privilege. Authenticated users are limited to creating a limited
		/// number of accounts that is specified as a quota on the domain (the default value is 10). For more information, see the
		/// ms-DS-MachineAccountQuota attribute in the Active Directory schema.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// The <c>NetProvisionComputerAccount</c> function works only with a writable domain controller and does not function against a
		/// read-only domain controller. Once provisioning is done against a writable domain controller and the account is replicated to a
		/// read-only domain controller, then the other portions of offline domain join operation do not require access to a domain controller.
		/// </para>
		/// <para>
		/// If the <c>NetProvisionComputerAccount</c> function is successful, the pointer in the pProvisionBinData or pProvisionTextData
		/// parameter (depending on which was parameter was not <c>NULL</c>) is returned with the serialized data for use in an offline join
		/// operation or as text in an unattended setup file.
		/// </para>
		/// <para>For more information on offline domain join operations, see the Offline Domain Join Step-by-Step Guide.</para>
		/// <para>
		/// Joining (and unjoining) a computer to a domain using NetJoinDomain and NetUnjoinDomain can be performed only by a member of the
		/// Administrators local group on the target computer. Note that the domain administrator can set additional requirements for joining
		/// the domain using delegation and assignment of privileges.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmjoin/nf-lmjoin-netprovisioncomputeraccount NET_API_STATUS NET_API_FUNCTION
		// NetProvisionComputerAccount( LPCWSTR lpDomain, LPCWSTR lpMachineName, LPCWSTR lpMachineAccountOU, LPCWSTR lpDcName, DWORD
		// dwOptions, PBYTE *pProvisionBinData, DWORD *pdwProvisionBinDataSize, LPWSTR *pProvisionTextData );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmjoin.h", MSDNShortId = "4c854258-b84d-4ef3-a6da-ce0a9540ffd5")]
		public static extern Win32Error NetProvisionComputerAccount(string lpDomain, string lpMachineName, [Optional] string lpMachineAccountOU, string lpDcName, NETSETUP_PROVISION dwOptions,
			out IntPtr pProvisionBinData, out uint pdwProvisionBinDataSize, [Optional] IntPtr pProvisionTextData);

		/// <summary>
		/// The <c>NetProvisionComputerAccount</c> function provisions a computer account for later use in an offline domain join operation.
		/// </summary>
		/// <param name="lpDomain">
		/// A pointer to a <c>NULL</c>-terminated character string that specifies the name of the domain where the computer account is created.
		/// </param>
		/// <param name="lpMachineName">
		/// A pointer to a <c>NULL</c>-terminated character string that specifies the short name of the machine from which the computer
		/// account attribute sAMAccountName is derived by appending a '$'. This parameter must contain a valid DNS or NetBIOS machine name.
		/// </param>
		/// <param name="lpMachineAccountOU">
		/// <para>
		/// An optional pointer to a <c>NULL</c>-terminated character string that contains the RFC 1779 format name of the organizational
		/// unit (OU) where the computer account will be created. If you specify this parameter, the string must contain a full path, for
		/// example, OU=testOU,DC=domain,DC=Domain,DC=com. Otherwise, this parameter must be <c>NULL</c>.
		/// </para>
		/// <para>If this parameter is <c>NULL</c>, the well known computer object container will be used as published in the domain.</para>
		/// </param>
		/// <param name="lpDcName">
		/// An optional pointer to a <c>NULL</c>-terminated character string that contains the name of the domain controller to target.
		/// </param>
		/// <param name="dwOptions">
		/// <para>
		/// A set of bit flags that define provisioning options. This parameter can be one or more of the following values defined in the
		/// Lmjoin.h header file.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NETSETUP_PROVISION_DOWNLEVEL_PRIV_SUPPORT 0x00000001</term>
		/// <term>
		/// If the caller requires account creation by privilege, this option will cause a retry on failure using account creation functions
		/// enabling interoperability with domain controllers running on earlier versions of Windows. The lpMachineAccountOU is not supported
		/// when using downlevel privilege support.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NETSETUP_PROVISION_REUSE_ACCOUNT 0x00000002</term>
		/// <term>
		/// If the named account already exists, an attempt will be made to reuse the existing account. This option requires sufficient
		/// credentials for this operation (Domain Administrator or the object owner).
		/// </term>
		/// </item>
		/// <item>
		/// <term>NETSETUP_PROVISION_USE_DEFAULT_PASSWORD 0x00000004</term>
		/// <term>
		/// Use the default machine account password which is the machine name in lowercase. This is largely to support the older unsecure
		/// join model where the pre-created account typically used this default password.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NETSETUP_PROVISION_SKIP_ACCOUNT_SEARCH 0x00000008</term>
		/// <term>
		/// Do not try to find the account on any domain controller in the domain. This option makes the operation faster, but should only be
		/// used when the caller is certain that an account by the same name hasn't recently been created. This option is only valid when the
		/// lpDcName parameter is specified. When the prerequisites are met, this option allows for must faster provisioning useful for
		/// scenarios such as batch processing.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NETSETUP_PROVISION_ROOT_CA_CERTS 0x00000010</term>
		/// <term>
		/// This option retrieves all of the root Certificate Authority certificates on the local machine and adds them to the provisioning
		/// package when no certificate template names are provided as part of the provisioning package (the aCertTemplateNames member of the
		/// NETSETUP_PROVISIONING_PARAMS struct passed in the pProvisioningParams parameter to the NetCreateProvisioningPackage function is NULL).
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pProvisionBinData">
		/// <para>
		/// An optional pointer that will receive the opaque binary blob of serialized metadata required by NetRequestOfflineDomainJoin
		/// function to complete an offline domain join, if the <c>NetProvisionComputerAccount</c> function completes successfully. The data
		/// is returned as an opaque binary buffer which may be passed to <c>NetRequestOfflineDomainJoin</c> function.
		/// </para>
		/// <para>
		/// If this parameter is <c>NULL</c>, then pProvisionTextData parameter must not be <c>NULL</c>. If this parameter is not
		/// <c>NULL</c>, then the pProvisionTextData parameter must be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="pdwProvisionBinDataSize">
		/// <para>A pointer to a value that receives the size, in bytes, of the buffer returned in the pProvisionBinData parameter.</para>
		/// <para>
		/// This parameter must not be <c>NULL</c> if the pProvisionBinData parameter is not <c>NULL</c>. This parameter must be <c>NULL</c>
		/// when the pProvisionBinData parameter is <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="pProvisionTextData">
		/// <para>
		/// An optional pointer that will receive the opaque binary blob of serialized metadata required by NetRequestOfflineDomainJoin
		/// function to complete an offline domain join, if the <c>NetProvisionComputerAccount</c> function completes successfully. The data
		/// is returned in string form for embedding in an unattended setup answer file.
		/// </para>
		/// <para>
		/// If this parameter is <c>NULL</c>, then the pProvisionBinData parameter must not be <c>NULL</c>. If this parameter is not
		/// <c>NULL</c>, then the the pProvisionBinData parameter must be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes or one of the system error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>Access is denied. This error is returned if the caller does not have sufficient privileges to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_DOMAIN_ROLE</term>
		/// <term>
		/// This operation is only allowed for the Primary Domain Controller of the domain. This error is returned if a domain controller
		/// name was specified in the lpDcName parameter, but the computer specified could not be validated as a domain controller for the
		/// target domain specified in the lpDomain parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// A parameter is incorrect. This error is returned if the lpDomain or lpMachineName parameter is NULL. This error is also returned
		/// if both the pProvisionBinData and pProvisionTextData parameters are NULL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_SUCH_DOMAIN</term>
		/// <term>The specified domain did not exist.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if the lpMachineAccountOU parameter was specified and the domain controller
		/// is running on an earlier versions of Windows that does not support this parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NERR_DS8DCRequired</term>
		/// <term>The specified domain controller does not meet the version requirement for this operation.</term>
		/// </item>
		/// <item>
		/// <term>NERR_LDAPCapableDCRequired</term>
		/// <term>This operation requires a domain controller which supports LDAP.</term>
		/// </item>
		/// <item>
		/// <term>NERR_UserExists</term>
		/// <term>
		/// The account already exists in the domain and the NETSETUP_PROVISION_REUSE_ACCOUNT bit was not specified in the dwOptions parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NERR_WkstaNotStarted</term>
		/// <term>The Workstation service has not been started.</term>
		/// </item>
		/// <item>
		/// <term>RPC_S_CALL_IN_PROGRESS</term>
		/// <term>A remote procedure call is already in progress for this thread.</term>
		/// </item>
		/// <item>
		/// <term>RPC_S_PROTSEQ_NOT_SUPPORTED</term>
		/// <term>The remote procedure call protocol sequence is not supported.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>NetProvisionComputerAccount</c> function is supported on Windows 7 and Windows Server 2008 R2 for offline join operations.
		/// On Windows 8 or Windows Server 2008 R2, it is recommended that the NetCreateProvisioningPackage function be used instead of the
		/// <c>NetProvisionComputerAccount</c> function.
		/// </para>
		/// <para>
		/// The <c>NetProvisionComputerAccount</c> function is used to provision a computer account for later use in an offline domain join
		/// operation using the NetRequestOfflineDomainJoin function. The offline domain join scenario uses these functions as follows:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// <c>NetProvisionComputerAccount</c> is a provisioning function that is first called to perform the network operations necessary to
		/// create and configure the computer object in Active Directory. The output from the <c>NetProvisionComputerAccount</c> is an opaque
		/// binary blob of serialized metadata used for the next step.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// NetRequestOfflineDomainJoin, an image initialization function, is then called to inject the output from the
		/// <c>NetProvisionComputerAccount</c> provisioning function into a Windows operating system image to be used during installation.
		/// </term>
		/// </item>
		/// </list>
		/// <para>Changes to Windows initialization code will detect this saved state and affect the local only portion of domain join.</para>
		/// <para>
		/// The <c>NetProvisionComputerAccount</c> function will create or reuse the machine account in the domain, collect all necessary
		/// metadata and return it in an opaque versioned binary blob or as text for embedding in an unattended setup answer file. The opaque
		/// binary blob can be consumed by the offline domain join request operation supplying all the necessary input to complete the domain
		/// join during first boot without any network operations (local state updates only).
		/// </para>
		/// <para>
		/// <c>Security Note:</c> The blob returned by the <c>NetProvisionComputerAccount</c> function contains very sensitive data. It
		/// should be treated just as securely as a plaintext password. The blob contains the machine account password and other information
		/// about the domain, including the domain name, the name of a domain controller, and the security ID (SID) of the domain. If the
		/// blob is being transported physically or over the network, care must be taken to transport it securely. The design makes no
		/// provisions for securing this data. This problem exists today with unattended setup answer files which can carry a number of
		/// secrets including domain user passwords. The caller must secure the blob and the unattended setup files. Solutions to this
		/// problem are varied. As an example, a pre-exchanged key could be used to encrypt a session between the consumer and provisioning
		/// entity enabling a secure transfer of the opaque blob.
		/// </para>
		/// <para>
		/// The opaque blob returned in the pProvisionBinData parameter by the <c>NetProvisionComputerAccount</c> function is versioned to
		/// allow interoperability and serviceability scenarios between different versions of Windows (joining client, provisioning machine,
		/// and domain controller). The offline join scenario currently does not limit the lifetime of the blob returned by the
		/// <c>NetProvisionComputerAccount</c> function.
		/// </para>
		/// <para>
		/// For offline domain joins, the access check performed depends on the configuration of the domain. Computer account creation is
		/// enabled using three methods:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Domain administrators have rights to create computer accounts.</term>
		/// </item>
		/// <item>
		/// <term>The SD on a container can delegate the rights to create computer accounts.</term>
		/// </item>
		/// <item>
		/// <term>
		/// By default, authenticated users may create computer accounts by privilege. Authenticated users are limited to creating a limited
		/// number of accounts that is specified as a quota on the domain (the default value is 10). For more information, see the
		/// ms-DS-MachineAccountQuota attribute in the Active Directory schema.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// The <c>NetProvisionComputerAccount</c> function works only with a writable domain controller and does not function against a
		/// read-only domain controller. Once provisioning is done against a writable domain controller and the account is replicated to a
		/// read-only domain controller, then the other portions of offline domain join operation do not require access to a domain controller.
		/// </para>
		/// <para>
		/// If the <c>NetProvisionComputerAccount</c> function is successful, the pointer in the pProvisionBinData or pProvisionTextData
		/// parameter (depending on which was parameter was not <c>NULL</c>) is returned with the serialized data for use in an offline join
		/// operation or as text in an unattended setup file.
		/// </para>
		/// <para>For more information on offline domain join operations, see the Offline Domain Join Step-by-Step Guide.</para>
		/// <para>
		/// Joining (and unjoining) a computer to a domain using NetJoinDomain and NetUnjoinDomain can be performed only by a member of the
		/// Administrators local group on the target computer. Note that the domain administrator can set additional requirements for joining
		/// the domain using delegation and assignment of privileges.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmjoin/nf-lmjoin-netprovisioncomputeraccount NET_API_STATUS NET_API_FUNCTION
		// NetProvisionComputerAccount( LPCWSTR lpDomain, LPCWSTR lpMachineName, LPCWSTR lpMachineAccountOU, LPCWSTR lpDcName, DWORD
		// dwOptions, PBYTE *pProvisionBinData, DWORD *pdwProvisionBinDataSize, LPWSTR *pProvisionTextData );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmjoin.h", MSDNShortId = "4c854258-b84d-4ef3-a6da-ce0a9540ffd5")]
		public static extern Win32Error NetProvisionComputerAccount(string lpDomain, string lpMachineName, [Optional] string lpMachineAccountOU, string lpDcName, NETSETUP_PROVISION dwOptions,
			[Optional] IntPtr pProvisionBinData, [Optional] IntPtr pdwProvisionBinDataSize, ref StringBuilder pProvisionTextData);

		/// <summary>The <c>NetRemoveAlternateComputerName</c> function removes an alternate name for the specified computer.</summary>
		/// <param name="Server">
		/// A pointer to a constant string that specifies the name of the computer on which to execute this function. If this parameter is
		/// <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="AlternateName">
		/// A pointer to a constant string that specifies the alternate name to remove. This name must be in the form of a fully qualified
		/// DNS name.
		/// </param>
		/// <param name="DomainAccount">
		/// <para>
		/// A pointer to a constant string that specifies the domain account to use for accessing the machine account object for the computer
		/// specified in the Server parameter in Active Directory. If this parameter is <c>NULL</c>, then the credentials of the user
		/// executing this routine are used.
		/// </para>
		/// <para>This parameter is not used if the server to execute this function is not joined to a domain.</para>
		/// </param>
		/// <param name="DomainAccountPassword">
		/// <para>
		/// A pointer to a constant string that specifies the password matching the domain account passed in the DomainAccount parameter. If
		/// this parameter is <c>NULL</c>, then the credentials of the user executing this routine are used.
		/// </para>
		/// <para>
		/// This parameter is ignored if the DomainAccount parameter is <c>NULL</c>. This parameter is not used if the server to execute this
		/// function is not joined to a domain.
		/// </para>
		/// </param>
		/// <param name="Reserved">Reserved for future use. This parameter should be <c>NULL</c>.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes or one of the system error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Access is denied. This error is returned if the caller was not a member of the Administrators local group on the target computer.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_NAME</term>
		/// <term>A name parameter is incorrect. This error is returned if the AlternateName parameter does not contain valid name.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// A parameter is incorrect. This error is returned if the DomainAccount parameter does not contain a valid domain. This error is
		/// also returned if the DomainAccount parameter is not NULL and the DomainAccountPassword parameter is not NULL but does not contain
		/// a Unicode string.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>Not enough memory is available to process this command.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if the target computer specified in the Server parameter on which this
		/// function executes is running on Windows 2000 and earlier.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NERR_WkstaNotStarted</term>
		/// <term>The Workstation service has not been started.</term>
		/// </item>
		/// <item>
		/// <term>RPC_S_CALL_IN_PROGRESS</term>
		/// <term>A remote procedure call is already in progress for this thread.</term>
		/// </item>
		/// <item>
		/// <term>RPC_S_PROTSEQ_NOT_SUPPORTED</term>
		/// <term>The remote procedure call protocol sequence is not supported.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>NetRemoveAlternateComputerName</c> function is supported on Windows XP and later.</para>
		/// <para>
		/// The <c>NetRemoveAlternateComputerName</c> function is used to remove secondary computer names configured for the target computer.
		/// </para>
		/// <para>
		/// The <c>NetRemoveAlternateComputerName</c> function requires that the caller is a member of the Administrators local group on the
		/// target computer.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmjoin/nf-lmjoin-netremovealternatecomputername NET_API_STATUS
		// NET_API_FUNCTION NetRemoveAlternateComputerName( LPCWSTR Server, LPCWSTR AlternateName, LPCWSTR DomainAccount, LPCWSTR
		// DomainAccountPassword, ULONG Reserved );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmjoin.h", MSDNShortId = "3c7ab44e-d5fa-40da-83fe-a44bf85b2ba5")]
		public static extern Win32Error NetRemoveAlternateComputerName([Optional] string Server, string AlternateName, [Optional] string DomainAccount, [Optional] string DomainAccountPassword, uint Reserved = 0);

		/// <summary>The <c>NetRenameMachineInDomain</c> function changes the name of a computer in a domain.</summary>
		/// <param name="lpServer">
		/// A pointer to a constant string that specifies the DNS or NetBIOS name of the computer on which to call the function. If this
		/// parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="lpNewMachineName">
		/// A pointer to a constant string that specifies the new name of the computer. If specified, the local computer name is changed as
		/// well. If this parameter is <c>NULL</c>, the function assumes you have already called the SetComputerNameEx function.
		/// </param>
		/// <param name="lpAccount">
		/// A pointer to a constant string that specifies an account name to use when connecting to the domain controller. If this parameter
		/// is <c>NULL</c>, the caller's context is used.
		/// </param>
		/// <param name="lpPassword">
		/// If the lpAccount parameter specifies an account name, this parameter must point to the password to use when connecting to the
		/// domain controller. Otherwise, this parameter must be <c>NULL</c>.
		/// </param>
		/// <param name="fRenameOptions">
		/// The rename options. If this parameter is NETSETUP_ACCT_CREATE, the function renames the account in the domain.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes or one of the system error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Access is denied. This error is returned if the account name passed in the lpAccount parameter did not have sufficient access
		/// rights for the operation.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>A parameter is incorrect.</term>
		/// </item>
		/// <item>
		/// <term>NERR_SetupNotJoined</term>
		/// <term>The computer is not currently joined to a domain.</term>
		/// </item>
		/// <item>
		/// <term>NERR_SetupDomainController</term>
		/// <term>This computer is a domain controller and cannot be unjoined from a domain.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Renaming a domain computer can be performed only by a user that is a member of the Administrators local group on the target
		/// computer and that also is a member of the Administrators group on the domain or has the Account Operator privilege on the domain.
		/// If you call the <c>NetRenameMachineInDomain</c> function remotely, you must supply credentials because you cannot delegate
		/// credentials under these circumstances.
		/// </para>
		/// <para>
		/// Different processes, or different threads of the same process, should not call the <c>NetRenameMachineInDomain</c> function at
		/// the same time. This situation can leave the computer in an inconsistent state.
		/// </para>
		/// <para>
		/// The <c>NERR_SetupNotJoined</c> and <c>NERR_SetupDomainController</c> return values are defined in the Lmerr.h header file. This
		/// header file is automatically included by the Lm.h header file and should not be included directly.
		/// </para>
		/// <para>A system reboot is required after calling the <c>NetRenameMachineInDomain</c> function for the operation to complete.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmjoin/nf-lmjoin-netrenamemachineindomain NET_API_STATUS NET_API_FUNCTION
		// NetRenameMachineInDomain( LPCWSTR lpServer, LPCWSTR lpNewMachineName, LPCWSTR lpAccount, LPCWSTR lpPassword, DWORD fRenameOptions );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmjoin.h", MSDNShortId = "1f7ddaa1-a349-49a6-856d-a2fde2f1dc3b")]
		public static extern Win32Error NetRenameMachineInDomain([Optional] string lpServer, [Optional] string lpNewMachineName, [Optional] string lpAccount, [Optional] string lpPassword, NETSETUP fRenameOptions);

		/// <summary>
		/// The <c>NetRequestOfflineDomainJoin</c> function executes locally on a machine to modify a Windows operating system image mounted
		/// on a volume. The registry is loaded from the image and provisioning blob data is written where it can be retrieved during the
		/// completion phase of an offline domain join operation.
		/// </summary>
		/// <param name="pProvisionBinData">
		/// <para>
		/// A pointer to a buffer required to initialize the registry of a Windows operating system image to process the final local state
		/// change during the completion phase of the offline domain join operation.
		/// </para>
		/// <para>
		/// The opaque binary blob of serialized metadata passed in the pProvisionBinData parameter is returned by the
		/// NetProvisionComputerAccount function.
		/// </para>
		/// </param>
		/// <param name="cbProvisionBinDataSize">
		/// <para>The size, in bytes, of the buffer pointed to by the pProvisionBinData parameter.</para>
		/// <para>This parameter must not be <c>NULL</c>.</para>
		/// </param>
		/// <param name="dwOptions">
		/// <para>
		/// A set of bit flags that define options for this function. This parameter can be one or more of the following values defined in
		/// the Lmjoin.h header file.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NETSETUP_PROVISION_ONLINE_CALLER 0x40000000</term>
		/// <term>
		/// This flag is required if the lpWindowsPath parameter references the currently running Windows operating system directory rather
		/// than an offline Windows operating system image mounted on an accessible volume. If this flag is specified, the
		/// NetRequestOfflineDomainJoin function must be invoked by a member of the local Administrators group.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lpWindowsPath">
		/// <para>
		/// A pointer to a constant null-terminated character string that specifies the path to a Windows operating system image under which
		/// the registry hives are located. This image must be offline and not currently booted unless the dwOptions parameter contains
		/// <c>NETSETUP_PROVISION_ONLINE_CALLER</c> in which case the locally running operating system directory is allowed.
		/// </para>
		/// <para>This path could be a UNC path on a remote server.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes or one of the system error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>Access is denied. This error is returned if the caller does not have sufficient privileges to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_ELEVATION_REQUIRED</term>
		/// <term>The requested operation requires elevation.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// A parameter is incorrect. This error is returned if the pProvisionBinData, cbProvisionBinDataSize, or lpWindowsPath parameters
		/// are NULL. This error is also returned if the buffer pointed to by the pProvisionBinData parameter does not contain valid data in
		/// the blob for the domain, machine account name, or machine account password. This error is also returned if the string pointed to
		/// lpWindowsPath parameter does not specific the path to a Windows operating system image.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if the specified server does not support this operation. For example, if the
		/// lpWindowsPath parameter references a Windows installation configured as a domain controller.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NERR_WkstaNotStarted</term>
		/// <term>The Workstation service has not been started.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>NetRequestOfflineDomainJoin</c> function is supported on Windows 7 for offline domain join operations.</para>
		/// <para>
		/// The <c>NetRequestOfflineDomainJoin</c> function is used locally on a machine to modify a Windows operating system image mounted
		/// on a volume. The registry is loaded for the image and provisioning blob data is written where it can be retrieved during the
		/// completion phase of an offline domain join operation. The offline domain join scenario uses these functions as follows:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// NetProvisionComputerAccount is a provisioning function that is first called to perform the network operations necessary to create
		/// and configure the computer object in Active Directory. The output from the <c>NetProvisionComputerAccount</c> is an opaque binary
		/// blob of serialized metadata used for the next step.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <c>NetRequestOfflineDomainJoin</c> , an image initialization function, is then called to inject the output from the
		/// NetProvisionComputerAccount provisioning function into a Windows operating system image to be used during installation. Changes
		/// to Windows initialization code will detect this saved state and affect the local only portion of domain join.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// The NetProvisionComputerAccount function will create or reuse the machine account in the domain, collect all necessary metadata
		/// and return it in an opaque versioned binary blob or as text for embedding in an unattended setup answer file. The opaque binary
		/// blob can be consumed by the offline domain join request operation supplying all the necessary input to complete the domain join
		/// during first boot without any network operations (local state updates only). Note that the blob contains machine account password
		/// material essentially in the clear. The design makes no provisions for securing this data. This problem exists today with
		/// unattended setup answer files which can carry a number of secrets including domain user passwords. The caller must secure the
		/// blob and the unattended setup files. Solutions to this problem are varied. As an example, a pre-exchanged key could be used to
		/// encrypt a session between the consumer and provisioning entity enabling a secure transfer of the opaque blob .
		/// </para>
		/// <para>
		/// The opaque blob returned in the pProvisionBinData parameter by the NetProvisionComputerAccount function is versioned to allow
		/// interoperability and serviceability scenarios between different versions of Windows (joining client, provisioning machine, and
		/// domain controller). The offline join scenario currently does not limit the lifetime of the blob returned by the
		/// <c>NetProvisionComputerAccount</c> function.
		/// </para>
		/// <para>For more information on offline domain join operations, see the Offline Domain Join Step-by-Step Guide.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmjoin/nf-lmjoin-netrequestofflinedomainjoin NET_API_STATUS NET_API_FUNCTION
		// NetRequestOfflineDomainJoin( BYTE *pProvisionBinData, DWORD cbProvisionBinDataSize, DWORD dwOptions, LPCWSTR lpWindowsPath );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmjoin.h", MSDNShortId = "f3f8fe00-d6f7-4d59-a4e7-6aef7f507e1a")]
		public static extern Win32Error NetRequestOfflineDomainJoin([In] IntPtr pProvisionBinData, uint cbProvisionBinDataSize, NETSETUP_PROVISION dwOptions, string lpWindowsPath);

		/// <summary>
		/// The <c>NetRequestProvisioningPackageInstall</c> function executes locally on a machine to modify a Windows operating system image
		/// mounted on a volume. The registry is loaded from the image and provisioning package data is written where it can be retrieved
		/// during the completion phase of an offline domain join operation.
		/// </summary>
		/// <param name="pPackageBinData">
		/// <para>
		/// A pointer to a buffer required to initialize the registry of a Windows operating system image to process the final local state
		/// change during the completion phase of the offline domain join operation.
		/// </para>
		/// <para>
		/// The opaque binary blob of serialized metadata passed in the pPackageBinData parameter is returned by the
		/// NetCreateProvisioningPackage function.
		/// </para>
		/// </param>
		/// <param name="dwPackageBinDataSize">
		/// <para>The size, in bytes, of the buffer pointed to by the pPackageBinData parameter.</para>
		/// <para>This parameter must not be <c>NULL</c>.</para>
		/// </param>
		/// <param name="dwProvisionOptions">
		/// <para>
		/// A set of bit flags that define options for this function. This parameter uses one or more of the following values defined in the
		/// Lmjoin.h header file.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NETSETUP_PROVISION_ONLINE_CALLER 0x40000000</term>
		/// <term>
		/// This flag is required if the lpWindowsPath parameter references the currently running Windows operating system directory rather
		/// than an offline Windows operating system image mounted on an accessible volume. If this flag is specified, the
		/// NetRequestProvisioningPackageInstall function must be invoked by a member of the local Administrators group.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lpWindowsPath">
		/// <para>
		/// A pointer to a <c>NULL</c>-terminated character string that specifies the path to a Windows operating system image under which
		/// the registry hives are located. This image must be offline and not currently booted unless the dwProvisionOptions parameter
		/// contains <c>NETSETUP_PROVISION_ONLINE_CALLER</c>, in which case, the locally running operating system directory is allowed.
		/// </para>
		/// <para>This path could be a UNC path on a remote server.</para>
		/// </param>
		/// <param name="pvReserved">Reserved for future use.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following Network Management error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>NERR_NoOfflineJoinInfo</term>
		/// <term>The offline join completion information was not found.</term>
		/// </item>
		/// <item>
		/// <term>NERR_BadOfflineJoinInfo</term>
		/// <term>The offline join completion information was bad.</term>
		/// </item>
		/// <item>
		/// <term>NERR_CantCreateJoinInfo</term>
		/// <term>
		/// Unable to create offline join information. Please ensure you have access to the specified path location and permissions to modify
		/// its contents. Running as an elevated administrator may be required.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NERR_BadDomainJoinInfo</term>
		/// <term>The domain join info being saved was incomplete or bad.</term>
		/// </item>
		/// <item>
		/// <term>NERR_JoinPerformedMustRestart</term>
		/// <term>Offline join operation successfully completed but a restart is needed.</term>
		/// </item>
		/// <item>
		/// <term>NERR_NoJoinPending</term>
		/// <term>There was no offline join operation pending.</term>
		/// </item>
		/// <item>
		/// <term>NERR_ValuesNotSet</term>
		/// <term>Unable to set one or more requested machine or domain name values on the local computer.</term>
		/// </item>
		/// <item>
		/// <term>NERR_CantVerifyHostname</term>
		/// <term>Could not verify the current machine's hostname against the saved value in the join completion information.</term>
		/// </item>
		/// <item>
		/// <term>NERR_CantLoadOfflineHive</term>
		/// <term>
		/// Unable to load the specified offline registry hive. Please ensure you have access to the specified path location and permissions
		/// to modify its contents. Running as an elevated administrator may be required.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NERR_ConnectionInsecure</term>
		/// <term>The minimum session security requirements for this operation were not met.</term>
		/// </item>
		/// <item>
		/// <term>NERR_ProvisioningBlobUnsupported</term>
		/// <term>Computer account provisioning blob version is not supported.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The NetRequestProvisioningPackageInstall function is supported on Windows 8 for offline domain join operations. For Windows 7,
		/// use <c>NetRequestOfflineDomainJoin</c>.
		/// </para>
		/// <para>The offline domain join scenario uses two functions:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// NetCreateProvisioningPackage is a provisioning function that is first called to perform the network operations necessary to
		/// create and configure the computer object in Active Directory. The output from the <c>NetCreateProvisioningPackage</c> is a
		/// package used for the next step.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <c>NetRequestProvisioningPackageInstall</c>, an image initialization function, is called to inject the output from the
		/// NetCreateProvisioningPackage provisioning function into a Windows operating system image for use during installation.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// Changes to Windows initialization code will detect this saved state and affect the local-only portion of domain join and install
		/// any certificate and policy information that may have been present in the package.
		/// </para>
		/// <para>
		/// The NetCreateProvisioningPackage function will create or reuse the machine account in the domain, collect all necessary metadata
		/// and return it in a package. The package can be consumed by the offline domain join request operation supplying all the necessary
		/// input to complete the domain join during first boot without any network operations (local state updates only).
		/// </para>
		/// <para>
		/// <c>Security Note:</c> The package created by the NetCreateProvisioningPackage function contains very sensitive data. It should be
		/// treated just as securely as a plaintext password. The package contains the machine account password and other information about
		/// the domain, including the domain name, the name of a domain controller, and the security ID (SID) of the domain. If the package
		/// is being transported physically or over the network, care must be taken to transport it securely. The design makes no provisions
		/// for securing this data. This problem exists today with unattended setup answer files which can carry a number of secrets
		/// including domain user passwords. The caller must secure the package. Solutions to this problem are varied. As an example, a
		/// pre-exchanged key could be used to encrypt a session between the consumer and provisioning entity enabling a secure transfer of
		/// the package.
		/// </para>
		/// <para>
		/// The package returned in the pPackageBinData parameter by the NetCreateProvisioningPackage function is versioned to allow
		/// interoperability and serviceability scenarios between different versions of Windows (such as joining a client, provisioning a
		/// machine, and using a domain controller). The offline join scenario currently does not limit the lifetime of the package returned
		/// by the <c>NetCreateProvisioningPackage</c> function.
		/// </para>
		/// <para>
		/// All phases of the provisioning process append to a NetSetup.log file on the local computer. The provisoning process can include
		/// up to three different computers: the computer where the provisioning package is created, the computer that requests the
		/// installation of the package, and the computer where the package is installed. There will be NetSetup.log file information stored
		/// on all three computers according to the operation performed. Reviewing the contents of these files is the most common means of
		/// troubleshooting online and offline provisioning errors. Provisioning operations undertaken by admins are logged to the
		/// NetSetup.log file in the %WINDIR%\Debug. Provisioning operations performed by non-admins are logged to the NetSetup.log file in
		/// the %USERPROFILE%\Debug folder.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmjoin/nf-lmjoin-netrequestprovisioningpackageinstall NET_API_STATUS
		// NET_API_FUNCTION NetRequestProvisioningPackageInstall( BYTE *pPackageBinData, DWORD dwPackageBinDataSize, DWORD
		// dwProvisionOptions, LPCWSTR lpWindowsPath, PVOID pvReserved );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmjoin.h", MSDNShortId = "107ED0F7-8DDD-4C18-8C34-3A67F771FA62")]
		public static extern Win32Error NetRequestProvisioningPackageInstall([In] IntPtr pPackageBinData, uint dwPackageBinDataSize, NETSETUP_PROVISION dwProvisionOptions, string lpWindowsPath, IntPtr pvReserved = default);

		/// <summary>The <c>NetSetPrimaryComputerName</c> function sets the primary computer name for the specified computer.</summary>
		/// <param name="Server">
		/// A pointer to a constant string that specifies the name of the computer on which to execute this function. If this parameter is
		/// <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="PrimaryName">
		/// A pointer to a constant string that specifies the primary name to set. This name must be in the form of a fully qualified DNS name.
		/// </param>
		/// <param name="DomainAccount">
		/// <para>
		/// A pointer to a constant string that specifies the domain account to use for accessing the machine account object for the computer
		/// specified in the Server parameter in Active Directory. If this parameter is <c>NULL</c>, then the credentials of the user
		/// executing this routine are used.
		/// </para>
		/// <para>This parameter is not used if the server to execute this function is not joined to a domain.</para>
		/// </param>
		/// <param name="DomainAccountPassword">
		/// <para>
		/// A pointer to a constant string that specifies the password matching the domain account passed in the DomainAccount parameter. If
		/// this parameter is <c>NULL</c>, then the credentials of the user executing this routine are used.
		/// </para>
		/// <para>
		/// This parameter is ignored if the DomainAccount parameter is <c>NULL</c>. This parameter is not used if the server to execute this
		/// function is not joined to a domain.
		/// </para>
		/// </param>
		/// <param name="Reserved">Reserved for future use. This parameter should be <c>NULL</c>.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes or one of the system error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Access is denied. This error is returned if the caller was not a member of the Administrators local group on the target computer.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_NAME</term>
		/// <term>A name parameter is incorrect. This error is returned if the PrimaryName parameter does not contain valid name.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// A parameter is incorrect. This error is returned if the DomainAccount parameter does not contain a valid domain. This error is
		/// also returned if the DomainAccount parameter is not NULL and the DomainAccountPassword parameter is not NULL but does not contain
		/// a Unicode string.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>Not enough memory is available to process this command.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if the target computer specified in the Server parameter on which this
		/// function executes is running on Windows 2000 and earlier.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NERR_WkstaNotStarted</term>
		/// <term>The Workstation service has not been started.</term>
		/// </item>
		/// <item>
		/// <term>RPC_S_CALL_IN_PROGRESS</term>
		/// <term>A remote procedure call is already in progress for this thread.</term>
		/// </item>
		/// <item>
		/// <term>RPC_S_PROTSEQ_NOT_SUPPORTED</term>
		/// <term>The remote procedure call protocol sequence is not supported.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>NetSetPrimaryComputerName</c> function is supported on Windows XP and later.</para>
		/// <para>
		/// The <c>NetSetPrimaryComputerName</c> function is used as part of computer rename operations. The specified name will be removed
		/// from the alternate name list configured for the target computer and configured as the primary name. The computer account name
		/// will be changed to match the primary name. The previous primary computer name is moved to the alternate computer name list
		/// configured for the computer.
		/// </para>
		/// <para>
		/// The <c>NetSetPrimaryComputerName</c> function requires that the caller is a member of the Administrators local group on the
		/// target computer.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmjoin/nf-lmjoin-netsetprimarycomputername NET_API_STATUS NET_API_FUNCTION
		// NetSetPrimaryComputerName( LPCWSTR Server, LPCWSTR PrimaryName, LPCWSTR DomainAccount, LPCWSTR DomainAccountPassword, ULONG
		// Reserved );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmjoin.h", MSDNShortId = "524c8219-a303-45ab-95e2-91319b477568")]
		public static extern Win32Error NetSetPrimaryComputerName([Optional] string Server, string PrimaryName, [Optional] string DomainAccount, [Optional] string DomainAccountPassword, uint Reserved = 0);

		/// <summary>The <c>NetUnjoinDomain</c> function unjoins a computer from a workgroup or a domain.</summary>
		/// <param name="lpServer">
		/// A pointer to a constant string that specifies the DNS or NetBIOS name of the computer on which the function is to execute. If
		/// this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="lpAccount">
		/// A pointer to a constant string that specifies the account name to use when connecting to the domain controller. The string must
		/// specify either a domain NetBIOS name and user account (for example, REDMOND\user) or the user principal name (UPN) of the user in
		/// the form of an Internet-style login name (for example, "someone@example.com"). If this parameter is <c>NULL</c>, the caller's
		/// context is used.
		/// </param>
		/// <param name="lpPassword">
		/// If the lpAccount parameter specifies an account name, this parameter must point to the password to use when connecting to the
		/// domain controller. Otherwise, this parameter must be <c>NULL</c>.
		/// </param>
		/// <param name="fUnjoinOptions">
		/// Specifies the unjoin options. If this parameter is NETSETUP_ACCT_DELETE, the account is disabled when the unjoin occurs. Note
		/// that this option does not delete the account. Currently, there are no other unjoin options defined.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes or one of the system error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>A parameter is incorrect.</term>
		/// </item>
		/// <item>
		/// <term>NERR_SetupNotJoined</term>
		/// <term>The computer is not currently joined to a domain.</term>
		/// </item>
		/// <item>
		/// <term>NERR_SetupDomainController</term>
		/// <term>This computer is a domain controller and cannot be unjoined from a domain.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Unjoining (and joining) a computer to a domain or workgroup can be performed only by a member of the Administrators local group
		/// on the target computer. If you call the <c>NetUnjoinDomain</c> function remotely, you must supply credentials because you cannot
		/// delegate credentials under these circumstances.
		/// </para>
		/// <para>
		/// Different processes, or different threads of the same process, should not call the <c>NetUnjoinDomain</c> function at the same
		/// time. This situation can leave the computer in an inconsistent state.
		/// </para>
		/// <para>A system reboot is required after calling the NetRenameMachineInDomain function for the operation to complete.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmjoin/nf-lmjoin-netunjoindomain NET_API_STATUS NET_API_FUNCTION
		// NetUnjoinDomain( LPCWSTR lpServer, LPCWSTR lpAccount, LPCWSTR lpPassword, DWORD fUnjoinOptions );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmjoin.h", MSDNShortId = "cc755c22-1fd6-4787-999e-a43258287a05")]
		public static extern Win32Error NetUnjoinDomain([Optional] string lpServer, [Optional] string lpAccount, [Optional] string lpPassword, NETSETUP fUnjoinOptions);

		/// <summary>
		/// The <c>NetValidateName</c> function verifies that a name is valid for name type specified(computer name, workgroup name, domain
		/// name, or DNS computer name).
		/// </summary>
		/// <param name="lpServer">
		/// A pointer to a constant string that specifies the DNS or NetBIOS name of the computer on which to call the function. If this
		/// parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="lpName">
		/// A pointer to a constant string that specifies the name to validate. Depending on the value specified in the NameType parameter,
		/// the lpName parameter can point to a computer name, workgroup name, domain name, or DNS computer name.
		/// </param>
		/// <param name="lpAccount">
		/// If the lpName parameter is a domain name, this parameter points to an account name to use when connecting to the domain
		/// controller. The string must specify either a domain NetBIOS name and user account (for example, "REDMOND\user") or the user
		/// principal name (UPN) of the user in the form of an Internet-style login name (for example, "someone@example.com"). If this
		/// parameter is <c>NULL</c>, the caller's context is used.
		/// </param>
		/// <param name="lpPassword">
		/// If the lpAccount parameter specifies an account name, this parameter must point to the password to use when connecting to the
		/// domain controller. Otherwise, this parameter must be <c>NULL</c>.
		/// </param>
		/// <param name="NameType">
		/// <para>
		/// The type of the name passed in the lpName parameter to validate. This parameter can be one of the values from the
		/// NETSETUP_NAME_TYPE enumeration type defined in the Lmjoin.h header file.
		/// </para>
		/// <para>
		/// Note that the Lmjoin.h header is automatically included by the Lm.h header file. The Lmjoin.h header files should not be used directly.
		/// </para>
		/// <para>The following list shows the possible values for this parameter.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NetSetupUnknown 0</term>
		/// <term>The nametype is unknown. If this value is used, the NetValidateName function fails with ERROR_INVALID_PARAMETER.</term>
		/// </item>
		/// <item>
		/// <term>NetSetupMachine 1</term>
		/// <term>Verify that the NetBIOS computer name is valid and that it is not in use.</term>
		/// </item>
		/// <item>
		/// <term>NetSetupWorkgroup 2</term>
		/// <term>Verify that the workgroup name is valid.</term>
		/// </item>
		/// <item>
		/// <term>NetSetupDomain 3</term>
		/// <term>Verify that the domain name exists and that it is a domain.</term>
		/// </item>
		/// <item>
		/// <term>NetSetupNonExistentDomain 4</term>
		/// <term>Verify that the domain name is not in use.</term>
		/// </item>
		/// <item>
		/// <term>NetSetupDnsMachine 5</term>
		/// <term>
		/// Verify that the DNS computer name is valid. This value is supported on Windows 2000 and later. The application must be compiled
		/// with _WIN32_WINNT &gt;= 0x0500 to use this value.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>DNS_ERROR_INVALID_NAME_CHAR</term>
		/// <term>
		/// The DNS name contains an invalid character. This error is returned if the NameType parameter specified is NetSetupDnsMachine and
		/// the DNS name in the lpName parameter contains an invalid character.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DNS_ERROR_NON_RFC_NAME</term>
		/// <term>
		/// The DNS name does not comply with RFC specifications. This error is returned if the NameType parameter specified is
		/// NetSetupDnsMachine and the DNS name in the lpName parameter does not comply with RFC specifications.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_DUP_NAME</term>
		/// <term>A duplicate name already exists on the network.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_COMPUTERNAME</term>
		/// <term>The format of the specified computer name is not valid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// A parameter is incorrect. This error is returned if the lpName parameter is NULL or the NameType parameter is specified as
		/// NetSetupUnknown or an unknown nametype.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_SUCH_DOMAIN</term>
		/// <term>The specified domain does not exist.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if a remote computer was specified in the lpServer parameter and this call
		/// is not supported on the remote computer.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NERR_InvalidComputer</term>
		/// <term>
		/// The specified computer name is not valid. This error is returned if the NameType parameter specified is NetSetupDnsMachine or
		/// NetSetupMachine and the specified computer name is not valid.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NERR_InvalidWorkgroupName</term>
		/// <term>
		/// The specified workgroup name is not valid. This error is returned if the NameType parameter specified is NetSetupWorkgroup and
		/// the specified workgroup name is not valid.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_S_SERVER_UNAVAILABLE</term>
		/// <term>
		/// The RPC server is not available. This error is returned if a remote computer was specified in the lpServer parameter and the RPC
		/// server is not available.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_E_REMOTE_DISABLED</term>
		/// <term>
		/// Remote calls are not allowed for this process. This error is returned if a remote computer was specified in the lpServer
		/// parameter and remote calls are not allowed for this process.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>NetValidateName</c> function validates a name based on the nametype specified.</para>
		/// <para>
		/// If the NameType parameter is <c>NetSetupMachine</c>, the name passed in the lpName parameter must be syntactically correct as a
		/// NetBIOS name and the name must not currently be in use on the network.
		/// </para>
		/// <para>
		/// If the NameType parameter is <c>NetSetupWorkgroup</c>, the name passed in the lpName parameter must be syntactically correct as a
		/// NetBIOS name, the name must not currently be in use on the network as a unique name, and the name must be different from the
		/// computer name.
		/// </para>
		/// <para>
		/// If the NameType parameter is <c>NetSetupDomain</c>, the name passed in the lpName parameter must be syntactically correct as a
		/// NetBIOS or DNS name and the name must currently be registered as a domain name.
		/// </para>
		/// <para>
		/// If the NameType parameter is <c>NetSetupNonExistentDomain</c>, the name passed in the lpName parameter must be syntactically
		/// correct as a NetBIOS or DNS name and the name must currently not be registered as a domain name.
		/// </para>
		/// <para>
		/// If the NameType parameter is <c>NetSetupDnsMachine</c>, the name passed in the lpName parameter must be syntactically correct as
		/// a DNS name.
		/// </para>
		/// <para>NetBIOS names are limited to maximum length of 16 characters.</para>
		/// <para>No special group membership is required to successfully execute the <c>NetValidateName</c> function.</para>
		/// <para>Examples</para>
		/// <para>The following example validates a name for a specific type.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmjoin/nf-lmjoin-netvalidatename NET_API_STATUS NET_API_FUNCTION
		// NetValidateName( LPCWSTR lpServer, LPCWSTR lpName, LPCWSTR lpAccount, LPCWSTR lpPassword, NETSETUP_NAME_TYPE NameType );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmjoin.h", MSDNShortId = "772603df-ec17-4a83-a715-2d9a14d5c2bb")]
		public static extern Win32Error NetValidateName([Optional] string lpServer, string lpName, [Optional] string lpAccount, [Optional] string lpPassword, NETSETUP_NAME_TYPE NameType);

		/// <summary>Contains information about a user account that is used to join a device to Microsoft Azure Active Directory.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmjoin/ns-lmjoin-_dsreg_user_info typedef struct _DSREG_USER_INFO { LPWSTR
		// pszUserEmail; LPWSTR pszUserKeyId; LPWSTR pszUserKeyName; } DSREG_USER_INFO, *PDSREG_USER_INFO;
		[PInvokeData("lmjoin.h", MSDNShortId = "5E639988-0F53-40D7-BBEC-F78B3D124CC0")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct DSREG_USER_INFO
		{
			/// <summary>The email address of the user.</summary>
			public string pszUserEmail;

			/// <summary>The identifier of the Microsoft Passport key that is provisioned for the user.</summary>
			public string pszUserKeyId;

			/// <summary>The name of the Microsoft Passport key that is provisioned for the user.</summary>
			public string pszUserKeyName;
		}

		/// <summary>
		/// The <c>NETSETUP_PROVISIONING_PARAMS</c> structure contains information that is used when creating a provisioning package using
		/// the NetCreateProvisionPackage function.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>NETSETUP_PROVISIONING_PARAMS</c> structure provides flags for the NetCreateProvisioningPackage function which is supported
		/// on Windows 8 and Windows Server 2012 for offline join operations.
		/// </para>
		/// <para>
		/// In addition to domain joins, the provisioning package can provide certificates and policies to the machine. The provisioning
		/// package can be used in four ways:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Domain join</term>
		/// </item>
		/// <item>
		/// <term>Domain join and installation of certificates</term>
		/// </item>
		/// <item>
		/// <term>Domain join and installation of policies</term>
		/// </item>
		/// <item>
		/// <term>Domain join and installation of certificates and policies</term>
		/// </item>
		/// </list>
		/// <para>
		/// When certificates need to be added to the package, this structure provides the <c>aCertTemplateNames</c> member as an array of
		/// <c>NULL</c>-terminated certificate template names. The <c>aCertTemplateNames</c> member requires the <c>cCertTemplateNames</c>
		/// member to provide an explicit count of the number of items in the array.
		/// </para>
		/// <para>There are two different ways to add policies. You can use one or both methods:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// Policy name—An array of <c>NULL</c>-terminated policy names is provided in the <c>aMachinePolicyNames</c> member. During runtime,
		/// the policy name is mapped to the policy name in AD and the GUID that represents the policy in the enterprise space is retrieved.
		/// The <c>aMachinePolicyNames</c> member requires the <c>cMachinePolicyNames</c> member to provide an explicit count of the number
		/// of items in the array.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Policy path—A pointer to an array of <c>NULL</c>-terminated character strings provided in the <c>aMachinePolicyPaths</c> member
		/// which specify the path to a file in the Registry Policy File format. For more information on the Registry Policy File Format ,
		/// see Registry Policy File Format. The policy path is a full or relative path to the policy file.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmjoin/ns-lmjoin-_netsetup_provisioning_params typedef struct
		// _NETSETUP_PROVISIONING_PARAMS { DWORD dwVersion; LPCWSTR lpDomain; LPCWSTR lpHostName; LPCWSTR lpMachineAccountOU; LPCWSTR
		// lpDcName; DWORD dwProvisionOptions; LPCWSTR *aCertTemplateNames; DWORD cCertTemplateNames; LPCWSTR *aMachinePolicyNames; DWORD
		// cMachinePolicyNames; LPCWSTR *aMachinePolicyPaths; DWORD cMachinePolicyPaths; LPWSTR lpNetbiosName; LPWSTR lpSiteName; LPWSTR
		// lpPrimaryDNSDomain; } NETSETUP_PROVISIONING_PARAMS, *PNETSETUP_PROVISIONING_PARAMS;
		[PInvokeData("lmjoin.h", MSDNShortId = "E965804F-145A-4D8F-BB8E-466580AC65DA")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct NETSETUP_PROVISIONING_PARAMS
		{
			/// <summary>
			/// <para>
			/// The version of Windows in the provisioning package. This parameter should use the following value defined in the Lmjoin.h
			/// header file.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>NETSETUP_PROVISIONING_PARAMS_CURRENT_VERSION 0x00000001</term>
			/// <term>The version for this package is Windows Server 2012.</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint dwVersion;

			/// <summary>
			/// A pointer to a <c>NULL</c>-terminated character string that specifies the name of the domain where the computer account is created.
			/// </summary>
			public string lpDomain;

			/// <summary>The lp host name</summary>
			public string lpHostName;

			/// <summary>
			/// <para>
			/// A optional pointer to a <c>NULL</c>-terminated character string that contains the RFC 1779 format name of the organizational
			/// unit (OU) where the computer account will be created. If you specify this parameter, the string must contain a full path, for
			/// example, OU=testOU,DC=domain,DC=Domain,DC=com. Otherwise, this parameter must be <c>NULL</c>.
			/// </para>
			/// <para>If this parameter is <c>NULL</c>, the well known computer object container will be used as published in the domain.</para>
			/// </summary>
			public string lpMachineAccountOU;

			/// <summary>
			/// An optional pointer to a <c>NULL</c>-terminated character string that contains the name of the domain controller to target.
			/// </summary>
			public string lpDcName;

			/// <summary>
			/// <para>
			/// A set of bit flags that define provisioning options. This parameter can be one or more of the following values defined in the
			/// Lmjoin.h header file.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>NETSETUP_PROVISION_DOWNLEVEL_PRIV_SUPPORT 0x00000001</term>
			/// <term>
			/// If the caller requires account creation by privilege, this option will cause a retry on failure using account creation
			/// functions enabling interoperability with domain controllers running on earlier versions of Windows. The lpMachineAccountOU is
			/// not supported when using downlevel privilege support.
			/// </term>
			/// </item>
			/// <item>
			/// <term>NETSETUP_PROVISION_REUSE_ACCOUNT 0x00000002</term>
			/// <term>
			/// If the named account already exists, an attempt will be made to reuse the existing account. This option requires sufficient
			/// credentials for this operation (Domain Administrator or the object owner).
			/// </term>
			/// </item>
			/// <item>
			/// <term>NETSETUP_PROVISION_USE_DEFAULT_PASSWORD 0x00000004</term>
			/// <term>
			/// Use the default machine account password which is the machine name in lowercase. This is largely to support the older
			/// unsecure join model where the pre-created account typically used this default password.
			/// </term>
			/// </item>
			/// <item>
			/// <term>NETSETUP_PROVISION_SKIP_ACCOUNT_SEARCH 0x00000008</term>
			/// <term>
			/// Do not try to find the account on any domain controller in the domain. This option makes the operation faster, but should
			/// only be used when the caller is certain that an account by the same name hasn't recently been created. This option is only
			/// valid when the lpDcName parameter is specified. When the prerequisites are met, this option allows for must faster
			/// provisioning useful for scenarios such as batch processing.
			/// </term>
			/// </item>
			/// <item>
			/// <term>NETSETUP_PROVISION_ROOT_CA_CERTS 0x00000010</term>
			/// <term>
			/// This option retrieves all of the root Certificate Authority certificates on the local machine and adds them to the
			/// provisioning package.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public uint dwProvisionOptions;

			/// <summary>A pointer to an array of <c>NULL</c>-terminated certificate template names.</summary>
			public IntPtr aCertTemplateNames;

			/// <summary>
			/// When <c>aCertTemplateNames</c> is not <c>NULL</c>, this member provides an explicit count of the number of items in the array.
			/// </summary>
			public uint cCertTemplateNames;

			/// <summary>A pointer to an array of <c>NULL</c>-terminated machine policy names.</summary>
			public IntPtr aMachinePolicyNames;

			/// <summary>
			/// When <c>aMachinePolicyNames</c> is not <c>NULL</c>, this member provides an explicit count of the number of items in the array.
			/// </summary>
			public uint cMachinePolicyNames;

			/// <summary>
			/// <para>
			/// A pointer to an array of character strings. Each array element is a NULL-terminated character string which specifies the full
			/// or partial path to a file in the Registry Policy File format. For more information on the Registry Policy File Format , see
			/// Registry Policy File Format
			/// </para>
			/// <para>This path could be a UNC path on a remote server.</para>
			/// </summary>
			public IntPtr aMachinePolicyPaths;

			/// <summary>
			/// When <c>aMachinePolicyPaths</c> is not <c>NULL</c>, this member provides an explicit count of the number of items in the array.
			/// </summary>
			public uint cMachinePolicyPaths;

			/// <summary>The lp netbios name</summary>
			public string lpNetbiosName;

			/// <summary>The lp site name</summary>
			public string lpSiteName;

			/// <summary>The lp primary DNS domain</summary>
			public string lpPrimaryDNSDomain;
		}

		/// <summary>Contains information about how a device is joined to Microsoft Azure Active Directory.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmjoin/ns-lmjoin-_dsreg_join_info typedef struct _DSREG_JOIN_INFO {
		// DSREG_JOIN_TYPE joinType; PCCERT_CONTEXT pJoinCertificate; LPWSTR pszDeviceId; LPWSTR pszIdpDomain; LPWSTR pszTenantId; LPWSTR
		// pszJoinUserEmail; LPWSTR pszTenantDisplayName; LPWSTR pszMdmEnrollmentUrl; LPWSTR pszMdmTermsOfUseUrl; LPWSTR pszMdmComplianceUrl;
		// LPWSTR pszUserSettingSyncUrl; DSREG_USER_INFO *pUserInfo; } DSREG_JOIN_INFO, *PDSREG_JOIN_INFO;
		[PInvokeData("lmjoin.h", MSDNShortId = "9B0F7BE3-BDCD-437E-9157-9A646A2A20E2")]
		public class DSREG_JOIN_INFO : SafeHANDLE
		{
			/// <summary>An enumeration value that specifies the type of the join.</summary>
			public DSREG_JOIN_TYPE joinType => Value.joinType;

			/// <summary>
			/// Representations of the certification for the join. This is a pointer to <c>CERT_CONTEXT</c> structure which can be found in <c>Vanara.PInvoke.Cryptography</c>.
			/// </summary>
			public Crypt32.CERT_CONTEXT? pJoinCertificate => Value.pJoinCertificate.ToNullableStructure<Crypt32.CERT_CONTEXT>();

			/// <summary>The PSZ device identifier</summary>
			public string pszDeviceId => Value.pszDeviceId;

			/// <summary>A string that represents Azure Active Directory (Azure AD).</summary>
			public string pszIdpDomain => Value.pszIdpDomain;

			/// <summary>The identifier of the joined Azure AD tenant.</summary>
			public string pszTenantId => Value.pszTenantId;

			/// <summary>The email address for the joined account.</summary>
			public string pszJoinUserEmail => Value.pszJoinUserEmail;

			/// <summary>The display name for the joined account.</summary>
			public string pszTenantDisplayName => Value.pszTenantDisplayName;

			/// <summary>The URL to use to enroll in the Mobile Device Management (MDM) service.</summary>
			public string pszMdmEnrollmentUrl => Value.pszMdmEnrollmentUrl;

			/// <summary>The URL that provides information about the terms of use for the MDM service.</summary>
			public string pszMdmTermsOfUseUrl => Value.pszMdmTermsOfUseUrl;

			/// <summary>The URL that provides information about compliance for the MDM service.</summary>
			public string pszMdmComplianceUrl => Value.pszMdmComplianceUrl;

			/// <summary>The URL for synchronizing user settings.</summary>
			public string pszUserSettingSyncUrl => Value.pszUserSettingSyncUrl;

			/// <summary>Information about the user account that was used to join a device to Azure AD.</summary>
			public DSREG_USER_INFO? pUserInfo => Value.pUserInfo.ToNullableStructure<DSREG_USER_INFO>();

			/// <summary>
			/// Internal method that actually releases the handle. This is called by <see cref="M:Vanara.PInvoke.SafeHANDLE.ReleaseHandle"/>
			/// for valid handles and afterwards zeros the handle.
			/// </summary>
			/// <returns><c>true</c> to indicate successful release of the handle; <c>false</c> otherwise.</returns>
			protected override bool InternalReleaseHandle() { NetFreeAadJoinInformation(handle); return true; }

			private _DSREG_JOIN_INFO Value => handle.ToStructure<_DSREG_JOIN_INFO>();

			[StructLayout(LayoutKind.Sequential)]
			struct _DSREG_JOIN_INFO
			{
				public DSREG_JOIN_TYPE joinType; 
				public IntPtr pJoinCertificate;
				public StrPtrUni pszDeviceId;
				public StrPtrUni pszIdpDomain;
				public StrPtrUni pszTenantId;
				public StrPtrUni pszJoinUserEmail;
				public StrPtrUni pszTenantDisplayName;
				public StrPtrUni pszMdmEnrollmentUrl;
				public StrPtrUni pszMdmTermsOfUseUrl;
				public StrPtrUni pszMdmComplianceUrl;
				public StrPtrUni pszUserSettingSyncUrl;
				public IntPtr pUserInfo;
			}
		}
	}
}