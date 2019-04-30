using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.PInvoke
{
	/// <summary>Functions, enumerations and structures found in Secur32.dll.</summary>
	public static partial class Secur32
	{
		/// <summary>The Kerberos authentication package name.</summary>
		[PInvokeData("Ntsecapi.h")]
		public const string MICROSOFT_KERBEROS_NAME = "Kerberos";

		/// <summary>The MSV1_0 authentication package name.</summary>
		[PInvokeData("Ntsecapi.h")]
		public const string MSV1_0_PACKAGE_NAME = "MICROSOFT_AUTHENTICATION_PACKAGE_V1_0";

		/// <summary>The Negotiate authentication package name.</summary>
		[PInvokeData("Security.h")]
		public const string NEGOSSP_NAME = "Negotiate";

		/// <summary>
		/// The <c>POLICY_AUDIT_EVENT_TYPE</c> enumeration defines values that indicate the types of events the system can audit. The
		/// LsaQueryInformationPolicy and LsaSetInformationPolicy functions use this enumeration when their InformationClass parameters are
		/// set to PolicyAuditEventsInformation.
		/// </summary>
		/// <remarks>
		/// The <c>POLICY_AUDIT_EVENT_TYPE</c> enumeration may expand in future versions of Windows. Because of this, you should not compute
		/// the number of values in this enumeration directly. Instead, you should obtain the count of values by calling
		/// LsaQueryInformationPolicy with the InformationClass parameter set to PolicyAuditEventsInformation and extract the count from the
		/// <c>MaximumAuditEventCount</c> member of the returned POLICY_AUDIT_EVENTS_INFO structure.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ne-ntsecapi-policy_audit_event_type typedef enum
		// _POLICY_AUDIT_EVENT_TYPE { AuditCategorySystem, AuditCategoryLogon, AuditCategoryObjectAccess, AuditCategoryPrivilegeUse,
		// AuditCategoryDetailedTracking, AuditCategoryPolicyChange, AuditCategoryAccountManagement, AuditCategoryDirectoryServiceAccess,
		// AuditCategoryAccountLogon } POLICY_AUDIT_EVENT_TYPE, *PPOLICY_AUDIT_EVENT_TYPE;
		[PInvokeData("ntsecapi.h", MSDNShortId = "e8dbd1d5-37d5-4a97-9d1c-c645871dc7a5")]
		public enum POLICY_AUDIT_EVENT_TYPE
		{
			/// <summary>Determines whether the operating system must audit any of the following attempts:</summary>
			AuditCategorySystem = 0,

			/// <summary>
			/// Determines whether the operating system must audit each time this computer validates the credentials of an account. Account
			/// logon events are generated whenever a computer validates the credentials of one of its local accounts. The credential
			/// validation can be in support of a local logon or, in the case of an Active Directory domain account on a domain controller,
			/// can be in support of a logon to another computer. Audited events for local accounts must be logged on the local security log
			/// of the computer. Account logoff does not generate an event that can be audited.
			/// </summary>
			AuditCategoryLogon,

			/// <summary>
			/// Determines whether the operating system must audit each instance of user attempts to access a non-Active Directory object,
			/// such as a file, that has its own system access control list (SACL) specified. The type of access request, such as Write,
			/// Read, or Modify, and the account that is making the request must match the settings in the SACL.
			/// </summary>
			AuditCategoryObjectAccess,

			/// <summary>Determines whether the operating system must audit each instance of user attempts to use privileges.</summary>
			AuditCategoryPrivilegeUse,

			/// <summary>
			/// Determines whether the operating system must audit specific events, such as program activation, some forms of handle
			/// duplication, indirect access to an object, and process exit.
			/// </summary>
			AuditCategoryDetailedTracking,

			/// <summary>
			/// Determines whether the operating system must audit attempts to change Policy object rules, such as user rights assignment
			/// policy, audit policy, account policy, or trust policy.
			/// </summary>
			AuditCategoryPolicyChange,

			/// <summary>
			/// Determines whether the operating system must audit attempts to create, delete, or change user or group accounts. Also, audit
			/// password changes.
			/// </summary>
			AuditCategoryAccountManagement,

			/// <summary>
			/// Determines whether the operating system must audit attempts to access the directory service. The Active Directory object has
			/// its own SACL specified. The type of access request, such as Write, Read, or Modify, and the account that is making the
			/// request must match the settings in the SACL.
			/// </summary>
			AuditCategoryDirectoryServiceAccess,

			/// <summary>
			/// Determines whether the operating system must audit each instance of a user attempt to log on or log off this computer. Also
			/// audits logon attempts by privileged accounts that log on to the domain controller. These audit events are generated when the
			/// Kerberos Key Distribution Center (KDC) logs on to the domain controller. Logoff attempts are generated whenever the logon
			/// session of a logged-on user account is terminated.
			/// </summary>
			AuditCategoryAccountLogon,
		}

		/// <summary>
		/// The <c>POLICY_NOTIFICATION_INFORMATION_CLASS</c> enumeration defines the types of policy information and policy domain
		/// information for which your application can request notification of changes.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ne-ntsecapi-policy_notification_information_class typedef enum
		// _POLICY_NOTIFICATION_INFORMATION_CLASS { PolicyNotifyAuditEventsInformation, PolicyNotifyAccountDomainInformation,
		// PolicyNotifyServerRoleInformation, PolicyNotifyDnsDomainInformation, PolicyNotifyDomainEfsInformation,
		// PolicyNotifyDomainKerberosTicketInformation, PolicyNotifyMachineAccountPasswordInformation, PolicyNotifyGlobalSaclInformation,
		// PolicyNotifyMax } POLICY_NOTIFICATION_INFORMATION_CLASS, *PPOLICY_NOTIFICATION_INFORMATION_CLASS;
		[PInvokeData("ntsecapi.h", MSDNShortId = "cf8eea7a-d3b0-4c3a-b05b-3027024ab025")]
		public enum POLICY_NOTIFICATION_INFORMATION_CLASS
		{
			/// <summary>Notify when any of the audited categories are changed.</summary>
			PolicyNotifyAuditEventsInformation = 1,

			/// <summary>Notify when the account domain information changes.</summary>
			PolicyNotifyAccountDomainInformation,

			/// <summary>Notify when the LSA server changes its role from primary to backup, or vice versa.</summary>
			PolicyNotifyServerRoleInformation,

			/// <summary>Notify when the DNS domain information changes or if the primary domain information changes.</summary>
			PolicyNotifyDnsDomainInformation,

			/// <summary>Notify when the Encrypting File System (EFS) domain information changes.</summary>
			PolicyNotifyDomainEfsInformation,

			/// <summary>Notify when the Kerberos ticket for the domain changes.</summary>
			PolicyNotifyDomainKerberosTicketInformation,

			/// <summary>Notify when the machine account password changes.</summary>
			PolicyNotifyMachineAccountPasswordInformation,

			/// <summary/>
			PolicyNotifyGlobalSaclInformation,
		}

		/// <summary>The <c>SECURITY_LOGON_TYPE</c> enumeration indicates the type of logon requested by a logon process.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ne-ntsecapi-_security_logon_type typedef enum _SECURITY_LOGON_TYPE {
		// UndefinedLogonType, Interactive, Network, Batch, Service, Proxy, Unlock, NetworkCleartext, NewCredentials, RemoteInteractive,
		// CachedInteractive, CachedRemoteInteractive, CachedUnlock } SECURITY_LOGON_TYPE, *PSECURITY_LOGON_TYPE;
		[PInvokeData("ntsecapi.h", MSDNShortId = "d775d782-9403-47b2-bb43-8f677db49eb9")]
		public enum SECURITY_LOGON_TYPE
		{
			/// <summary>The undefined logon type</summary>
			UndefinedLogonType = 0,

			/// <summary>The security principal is logging on interactively.</summary>
			Interactive = 2,

			/// <summary>The security principal is logging using a network.</summary>
			Network,

			/// <summary>The logon is for a batch process.</summary>
			Batch,

			/// <summary>The logon is for a service account.</summary>
			Service,

			/// <summary>Not supported.</summary>
			Proxy,

			/// <summary>The logon is an attempt to unlock a workstation.</summary>
			Unlock,

			/// <summary>The logon is a network logon with plaintext credentials.</summary>
			NetworkCleartext,

			/// <summary>
			/// Allows the caller to clone its current token and specify new credentials for outbound connections. The new logon session has
			/// the same local identity but uses different credentials for other network connections.
			/// </summary>
			NewCredentials,

			/// <summary>A terminal server session that is both remote and interactive.</summary>
			RemoteInteractive,

			/// <summary>Attempt to use the cached credentials without going out across the network.</summary>
			CachedInteractive,

			/// <summary>Same as RemoteInteractive, except used internally for auditing purposes.</summary>
			CachedRemoteInteractive,

			/// <summary>The logon is an attempt to unlock a workstation.</summary>
			CachedUnlock,
		}

		/// <summary>
		/// <para>
		/// The <c>LsaCallAuthenticationPackage</c> function is used by a logon application to communicate with an authentication package.
		/// </para>
		/// <para>This function is typically used to access services provided by the authentication package.</para>
		/// </summary>
		/// <param name="LsaHandle">A handle obtained from a previous call to LsaRegisterLogonProcess or LsaConnectUntrusted.</param>
		/// <param name="AuthenticationPackage">
		/// Supplies the identifier of the authentication package. This value is obtained by calling LsaLookupAuthenticationPackage.
		/// </param>
		/// <param name="ProtocolSubmitBuffer">
		/// <para>An authentication package–specific message buffer passed to the authentication package.</para>
		/// <para>For information about the format and content of this buffer, see the documentation for the individual authentication package.</para>
		/// </param>
		/// <param name="SubmitBufferLength">Indicates the length, in bytes, of the ProtocolSubmitBuffer buffer.</param>
		/// <param name="ProtocolReturnBuffer">
		/// <para>A pointer that receives the address of the buffer returned by the authentication package.</para>
		/// <para>For information about the format and content of this buffer, see the documentation for the individual authentication package.</para>
		/// <para>
		/// This buffer is allocated by this function. When you have finished using this buffer, free the memory by calling the
		/// LsaFreeReturnBuffer function.
		/// </para>
		/// </param>
		/// <param name="ReturnBufferLength">A pointer to a <c>ULONG</c> that receives the length of the returned buffer, in bytes.</param>
		/// <param name="ProtocolStatus">
		/// If the function succeeds, this parameter receives a pointer to an <c>NTSTATUS</c> code that indicates the completion status of
		/// the authentication package.
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is STATUS_SUCCESS. Check the ProtocolStatus parameter to obtain the status returned by
		/// the authentication package.
		/// </para>
		/// <para>If the function fails, the return value is an <c>NTSTATUS</c> code. The following are possible error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_QUOTA_EXCEEDED</term>
		/// <term>The call could not be completed because the client's memory quota is not sufficient to allocate the return buffer.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_NO_SUCH_PACKAGE</term>
		/// <term>The specified authentication package is not recognized by the LSA.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_PKINIT_FAILURE</term>
		/// <term>
		/// The Kerberos client received a KDC certificate that is not valid. For device logon, strict KDC validation is required, so the KDC
		/// must have certificates that use the "Kerberos Authentication" template or equivalent. Also the KDC certificate could be expired,
		/// revoked, or the client is under active attack of sending requests to the wrong server.
		/// </term>
		/// </item>
		/// <item>
		/// <term>STATUS_PKINIT_CLIENT_FAILURE</term>
		/// <term>
		/// The Kerberos client is using a system certificate that is not valid. For device logon, there must be a DNS name. Also, the system
		/// certificate could be expired or the wrong one could be selected.
		/// </term>
		/// </item>
		/// </list>
		/// <para>For more information, see LSA Policy Function Return Values.</para>
		/// <para>The LsaNtStatusToWinError function converts an <c>NTSTATUS</c> code to a Windows error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Logon applications can call <c>LsaCallAuthenticationPackage</c> to communicate with an authentication package. There are several
		/// reasons why an application may do this:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>To implement multiple-message authentication protocols, such as the NTLM Challenge-Response protocol.</term>
		/// </item>
		/// <item>
		/// <term>
		/// To pass state change information to the authentication package. For example, the NTLM might notify the MSV1_0 package that a
		/// previously unreachable domain controller is now reachable. The authentication package would then re-logon any users logged on to
		/// that domain controller.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// Typically, this function is used to exchange information with a custom authentication package. This function is not needed by an
		/// application that is using one of the authentication packages supplied with Windows, such as MSV1_0 or Kerberos.
		/// </para>
		/// <para>
		/// You must call <c>LsaCallAuthenticationPackage</c> to clean up PKINIT device credentials for LOCAL_SYSTEM and NETWORK_SERVICE.
		/// When there is no PKINIT device credential, a successful call does no operation. When there is a PKINIT device credential, a
		/// successful call cleans up the PKINIT device credential so that only the password credential remains.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsacallauthenticationpackage NTSTATUS
		// LsaCallAuthenticationPackage( HANDLE LsaHandle, ULONG AuthenticationPackage, PVOID ProtocolSubmitBuffer, ULONG SubmitBufferLength,
		// PVOID *ProtocolReturnBuffer, PULONG ReturnBufferLength, PNTSTATUS ProtocolStatus );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntsecapi.h", MSDNShortId = "b891fa60-28b3-4819-9a92-e4524677fa4f")]
		public static extern NTStatus LsaCallAuthenticationPackage(LsaConnectionHandle LsaHandle, uint AuthenticationPackage, [In] IntPtr ProtocolSubmitBuffer, uint SubmitBufferLength, out SafeLsaReturnBufferHandle ProtocolReturnBuffer,
			out uint ReturnBufferLength, out NTStatus ProtocolStatus);

		/// <summary>
		/// <para>The <c>LsaConnectUntrusted</c> function establishes an untrusted connection to the LSA server.</para>
		/// </summary>
		/// <param name="LsaHandle">
		/// <para>Pointer to a handle that receives the connection handle, which must be provided in future authentication services.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is STATUS_SUCCESS.</para>
		/// <para>If the function fails, the return value is an NTSTATUS code. For more information, see LSA Policy Function Return Values.</para>
		/// <para>The LsaNtStatusToWinError function converts an NTSTATUS code to a Windows error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>LsaConnectUntrusted</c> returns a handle to an untrusted connection; it does not verify any information about the caller. The
		/// handle should be closed using the LsaDeregisterLogonProcess function.
		/// </para>
		/// <para>
		/// If your application simply needs to query information from authentication packages, you can use the handle returned by this
		/// function in calls to LsaCallAuthenticationPackage and LsaLookupAuthenticationPackage.
		/// </para>
		/// <para>Applications with the SeTcbPrivilege privilege may create a trusted connection by calling LsaRegisterLogonProcess.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsaconnectuntrusted NTSTATUS LsaConnectUntrusted(
		// PHANDLE LsaHandle );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntsecapi.h", MSDNShortId = "b54917c8-51cd-4891-9613-f37a4a46448b")]
		public static extern NTStatus LsaConnectUntrusted(out SafeLsaConnectionHandle LsaHandle);

		/// <summary>
		/// The LsaDeregisterLogonProcess function deletes the caller's logon application context and closes the connection to the LSA server.
		/// </summary>
		/// <param name="LsaHandle">Handle obtained from a LsaRegisterLogonProcess or LsaConnectUntrusted call.</param>
		/// <returns>
		/// If the function succeeds, the return value is STATUS_SUCCESS.
		/// <para>If the function fails, the return value is an NTSTATUS code. For more information, see LSA Policy Function Return Values.</para>
		/// <para>The LsaNtStatusToWinError function converts an NTSTATUS code to a Windows error code.</para>
		/// </returns>
		[DllImport(Lib.Secur32, ExactSpelling = true)]
		[PInvokeData("Ntsecapi.h", MSDNShortId = "aa378269")]
		public static extern NTStatus LsaDeregisterLogonProcess(LsaConnectionHandle LsaHandle);

		/// <summary>
		/// The <c>LsaEnumerateLogonSessions</c> function retrieves the set of existing logon session identifiers (LUIDs) and the number of sessions.
		/// </summary>
		/// <param name="LogonSessionCount">
		/// Pointer to a long integer that receives the number of elements returned in the array returned in LogonSessionList parameter.
		/// </param>
		/// <param name="LogonSessionList">
		/// Address of a pointer to a LUID. The pointer receives the first element of an array of logon session identifiers. The memory used
		/// by the array is allocated by the LSA. When the array is no longer needed, call the LSAFreeReturnBuffer function to free it.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is STATUS_SUCCESS.</para>
		/// <para>If the function fails, the return value is an NTSTATUS code indicating the reason.</para>
		/// </returns>
		/// <remarks>
		/// To retrieve information about the logon sessions returned by <c>LsaEnumerateLogonSessions</c>, call the LsaGetLogonSessionData function.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsaenumeratelogonsessions NTSTATUS
		// LsaEnumerateLogonSessions( PULONG LogonSessionCount, PLUID *LogonSessionList );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntsecapi.h", MSDNShortId = "ddf3b9ec-dea7-4333-9ffe-142811048c83")]
		public static extern NTStatus LsaEnumerateLogonSessions(out uint LogonSessionCount, out SafeLsaReturnBufferHandle LogonSessionList);

		/// <summary>
		/// <para>The <c>LsaFreeReturnBuffer</c> function frees the memory used by a buffer previously allocated by the LSA.</para>
		/// </summary>
		/// <param name="Buffer">
		/// <para>Pointer to the buffer to be freed.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is STATUS_SUCCESS.</para>
		/// <para>If the function fails, the return value is an NTSTATUS code. For more information, see LSA Policy Function Return Values.</para>
		/// <para>The LsaNtStatusToWinError function converts an NTSTATUS code to a Windows error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Some of the LSA authentication functions allocate memory buffers to hold returned information, for example, LsaLogonUser and
		/// LsaCallAuthenticationPackage. Your application should call <c>LsaFreeReturnBuffer</c> to free these buffers when they are no
		/// longer needed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsafreereturnbuffer _IRQL_requires_same_ NTSTATUS
		// LsaFreeReturnBuffer( PVOID Buffer );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntsecapi.h", MSDNShortId = "e814ed68-07e7-4936-ba96-5411086f43f6")]
		public static extern uint LsaFreeReturnBuffer(IntPtr Buffer);

		/// <summary>
		///   <para>The <c>LsaGetLogonSessionData</c> function retrieves information about a specified logon session.</para><para>To retrieve information about a logon session, the caller must be the owner of the session or a local system administrator.</para>
		/// </summary>
		/// <param name="LogonId">Specifies a pointer to a <c>LUID</c> that identifies the logon session whose information will be retrieved. For information about valid values for this parameter, see Remarks.</param>
		/// <param name="ppLogonSessionData">Address of a pointer to a SECURITY_LOGON_SESSION_DATA structure containing information on the logon session specified by LogonId. This structure is allocated by the LSA. When the information is no longer needed, call the LSAFreeReturnBuffer function to free the memory used by this structure.</param>
		/// <returns>
		///   <para>If the function succeeds, the return value is STATUS_SUCCESS.</para><para>If the function fails, the return value is an <c>NTSTATUS</c> code indicating the reason.</para>
		/// </returns>
		/// <remarks>
		///   <para>To obtain valid logon session identifiers that may be passed to this function's LogonId parameter, call the LsaEnumerateLogonSessions function.</para><para>If LogonID specifies the LocalSystem account (0x0:0x3e7), then this function returns zero for the logon session data retrieved in ppLogonSessionData. The reason is that the LocalSystem account does not get logged on in the typical logon manner. Rather, the LocalSystem account is active after the system starts.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsagetlogonsessiondata
		// NTSTATUS LsaGetLogonSessionData( PLUID LogonId, PSECURITY_LOGON_SESSION_DATA *ppLogonSessionData );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntsecapi.h", MSDNShortId = "b1478a7a-f508-4b98-8c7b-adeb2f07bb86")]
		public static extern NTStatus LsaGetLogonSessionData(in LUID LogonId, out SafeLsaReturnBufferHandle ppLogonSessionData);

		/// <summary>
		/// <para>The <c>LsaLogonUser</c> function authenticates a security principal's logon data by using stored credentials information.</para>
		/// <para>If the authentication is successful, this function creates a new logon session and returns a user token.</para>
		/// <para>
		/// When a new ticket granting ticket (TGT) is obtained by using new certificate credentials, then all of the system's TGTs and
		/// service tickets are purged. Any user service tickets that are of a compound identity are also purged.
		/// </para>
		/// </summary>
		/// <param name="LsaHandle">
		/// <para>A handle obtained from a previous call to LsaRegisterLogonProcess.</para>
		/// <para>The caller is required to have <c>SeTcbPrivilege</c> only if one or more of the following is true:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>A Subauthentication package is used.</term>
		/// </item>
		/// <item>
		/// <term>KERB_S4U_LOGON is used, and the caller requests an impersonation token.</term>
		/// </item>
		/// <item>
		/// <term>The LocalGroups parameter is not <c>NULL</c>.</term>
		/// </item>
		/// </list>
		/// <para>If</para>
		/// <para>SeTcbPrivilege</para>
		/// <para>is not required, call</para>
		/// <para>LsaConnectUntrusted</para>
		/// <para>to obtain the handle.</para>
		/// </param>
		/// <param name="OriginName">
		/// <para>A string that identifies the origin of the logon attempt. For more information, see Remarks.</para>
		/// </param>
		/// <param name="LogonType">
		/// <para>
		/// A value of the SECURITY_LOGON_TYPE enumeration that specifies the type of logon requested. If LogonType is Interactive or Batch,
		/// a primary token is generated to represent the new user. If LogonType is Network, an impersonation token is generated.
		/// </para>
		/// </param>
		/// <param name="AuthenticationPackage">
		/// <para>An identifier of the authentication package to use for the authentication. You can obtain this value by calling LsaLookupAuthenticationPackage.</para>
		/// </param>
		/// <param name="AuthenticationInformation">
		/// <para>
		/// A pointer to an input buffer that contains authentication information, such as user name and password. The format and content of
		/// this buffer are determined by the authentication package.
		/// </para>
		/// <para>This parameter can be one of the following input buffer structures for the MSV1_0 and Kerberos authentication packages.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MSV1_0_INTERACTIVE_LOGON MSV1_0</term>
		/// <term>
		/// Authenticating an interactive user logon. The LogonDomainName, UserName, and Password members of the MSV1_0_INTERACTIVE_LOGON
		/// structure must point to buffers in memory that are contiguous to the structure itself. The value of the
		/// AuthenticationInformationLength parameter must take into account the length of these buffers.
		/// </term>
		/// </item>
		/// <item>
		/// <term>KERB_INTERACTIVE_LOGON Kerberos</term>
		/// <term>Authenticating an interactive user logon.</term>
		/// </item>
		/// <item>
		/// <term>KERB_TICKET_LOGON Kerberos</term>
		/// <term>Authenticating a user on initial network logon or disconnect.</term>
		/// </item>
		/// <item>
		/// <term>KERB_TICKET_UNLOCK_LOGON Kerberos</term>
		/// <term>Authenticating a user on ticket refresh, a variation of the normal workstation unlock logon.</term>
		/// </item>
		/// <item>
		/// <term>KERB_CERTIFICATE_LOGON Kerberos</term>
		/// <term>Authenticating a user using an interactive smart card logon.</term>
		/// </item>
		/// <item>
		/// <term>KERB_CERTIFICATE_S4U_LOGON Kerberos</term>
		/// <term>Authenticating a user using a service for user (S4U) logon.</term>
		/// </item>
		/// <item>
		/// <term>KERB_CERTIFICATE_UNLOCK_LOGON Kerberos</term>
		/// <term>Authenticating a user to unlock a workstation that has been locked during an interactive smart card logon session.</term>
		/// </item>
		/// <item>
		/// <term>KERB_SMARTCARD_LOGON Kerberos</term>
		/// <term>Authenticating a user smart card logon using LOGON32_PROVIDER_WINNT50 or LOGON32_PROVIDER_DEFAULT.</term>
		/// </item>
		/// <item>
		/// <term>KERB_SMARTCARD_UNLOCK_LOGON Kerberos</term>
		/// <term>Authenticating a user to unlock a workstation that has been locked during a smart card logon session.</term>
		/// </item>
		/// <item>
		/// <term>KERB_S4U_LOGON Kerberos</term>
		/// <term>
		/// Authenticating a user using S4U client requests. For constrained delegation, a call to LsaLogonUser is not necessary if the
		/// client logged on using an LSA-mode authentication package. On Windows operating systems, these include Kerberos, NTLM, Secure
		/// Channel, and Digest. For this call to succeed, the following must be true: The ClientUpn and ClientRealm members of the
		/// KERB_S4U_LOGON structure must point to buffers in memory that are contiguous to the structure itself. The value of the
		/// AuthenticationInformationLength parameter must take into account the length of these buffers.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MSV1_0_LM20_LOGON MSV1_0</term>
		/// <term>
		/// Processing the second half of an NTLM 2.0 protocol logon. The first half of this type of logon is performed by calling
		/// LsaCallAuthenticationPackage with the MsV1_0Lm20ChallengeRequest message. For more information, see the description of
		/// MsV1_0Lm20ChallengeRequest in MSV1_0_PROTOCOL_MESSAGE_TYPE. This type of logon can use a subauthentication package.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MSV1_0_SUBAUTH_LOGON MSV1_0</term>
		/// <term>Authenticating a user with subauthentication.</term>
		/// </item>
		/// </list>
		/// <para>
		/// For more information about the buffer used by other authentication packages, see the documentation for those authentication packages.
		/// </para>
		/// </param>
		/// <param name="AuthenticationInformationLength">
		/// <para>The length, in bytes, of the AuthenticationInformation buffer.</para>
		/// </param>
		/// <param name="LocalGroups">
		/// <para>
		/// A list of additional group identifiers to add to the token of the authenticated user. These group identifiers will be added,
		/// along with the default group WORLD and the logon type group (Interactive, Batch, or Network), which are automatically included in
		/// every user token.
		/// </para>
		/// </param>
		/// <param name="SourceContext">
		/// <para>
		/// A TOKEN_SOURCE structure that identifies the source module—for example, the session manager—and the context that may be useful to
		/// that module. This information is included in the user token and can be retrieved by calling GetTokenInformation.
		/// </para>
		/// </param>
		/// <param name="ProfileBuffer">
		/// <para>
		/// A pointer to a void pointer that receives the address of an output buffer that contains authentication information, such as the
		/// logon shell and home directory.
		/// </para>
		/// <para>This parameter can be one of the following output buffer structures for the MSV1_0 and Kerberos authentication packages.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MSV1_0_INTERACTIVE_PROFILE MSV1_0</term>
		/// <term>An interactive user's logon profile.</term>
		/// </item>
		/// <item>
		/// <term>KERB_TICKET_PROFILE Kerberos</term>
		/// <term>Logon, disconnect, and ticket refresh authentication output.</term>
		/// </item>
		/// <item>
		/// <term>MSV1_0_LM20_LOGON MSV1_0</term>
		/// <term>Output when processing the second half of a NTLM 2.0 protocol logon.</term>
		/// </item>
		/// <item>
		/// <term>MSV1_0_LM20_LOGON_PROFILE MSV1_0</term>
		/// <term>Output when using authentication with subauthentication.</term>
		/// </item>
		/// </list>
		/// <para>
		/// For more information about the buffer used by other authentication packages, see the documentation for that authentication package.
		/// </para>
		/// <para>
		/// When this buffer is no longer needed, the calling application must free this buffer by calling the LsaFreeReturnBuffer function.
		/// </para>
		/// </param>
		/// <param name="ProfileBufferLength">
		/// <para>A pointer to a <c>ULONG</c> that receives the length, in bytes, of the returned profile buffer.</para>
		/// </param>
		/// <param name="LogonId">
		/// <para>
		/// A pointer to a buffer that receives an LUID that uniquely identifies the logon session. This <c>LUID</c> is assigned by the
		/// domain controller that authenticated the logon information.
		/// </para>
		/// </param>
		/// <param name="Token">
		/// <para>
		/// A pointer to a handle that receives the new user token created for this session. When you have finished using the token, release
		/// it by calling the CloseHandle function.
		/// </para>
		/// </param>
		/// <param name="Quotas">
		/// <para>
		/// When a primary token is returned, this parameter receives a QUOTA_LIMITS structure that contains the process quota limits
		/// assigned to the newly logged on user's initial process.
		/// </para>
		/// </param>
		/// <param name="SubStatus">
		/// <para>
		/// If the logon failed due to account restrictions, this parameter receives information about why the logon failed. This value is
		/// set only if the account information of the user is valid and the logon is rejected.
		/// </para>
		/// <para>This parameter can be one of the following SubStatus values for the MSV1_0 authentication package.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_INVALID_LOGON_HOURS</term>
		/// <term>The user account has time restrictions and cannot be used to log on at this time.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_INVALID_WORKSTATION</term>
		/// <term>The user account has workstation restrictions and cannot be used to log on from the current workstation.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_PASSWORD_EXPIRED</term>
		/// <term>The user-account password has expired.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_ACCOUNT_DISABLED</term>
		/// <term>The user account is currently disabled and cannot be used to log on.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns STATUS_SUCCESS.</para>
		/// <para>If the function fails, it returns an <c>NTSTATUS</c> code, which can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_QUOTA_EXCEEDED</term>
		/// <term>The caller's memory quota is insufficient to allocate the output buffer returned by the authentication package.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_ACCOUNT_RESTRICTION</term>
		/// <term>
		/// The user account and password are legitimate, but the user account has a restriction that prevents logon at this time. For more
		/// information, see the value stored in the SubStatus parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>STATUS_BAD_VALIDATION_CLASS</term>
		/// <term>The authentication information provided is not recognized by the authentication package.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_LOGON_FAILURE</term>
		/// <term>
		/// The logon attempt failed. The reason for the failure is not specified, but typical reasons include misspelled user names and
		/// misspelled passwords.
		/// </term>
		/// </item>
		/// <item>
		/// <term>STATUS_NO_LOGON_SERVERS</term>
		/// <term>No domain controllers are available to service the authentication request.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_NO_SUCH_PACKAGE</term>
		/// <term>The specified authentication package is not recognized by the LSA.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_PKINIT_FAILURE</term>
		/// <term>
		/// The Kerberos client received a KDC certificate that is not valid. For device logon, strict KDC validation is required, so the KDC
		/// must have certificates that use the "Kerberos Authentication" template or equivalent. Also, the KDC certificate could be expired,
		/// revoked, or the client is under active attack of sending requests to the wrong server.
		/// </term>
		/// </item>
		/// <item>
		/// <term>STATUS_PKINIT_CLIENT_FAILURE</term>
		/// <term>
		/// The Kerberos client is using a system certificate that is not valid. For device logon, there must be a DNS name. Also, the system
		/// certificate could be expired or the wrong one could be selected.
		/// </term>
		/// </item>
		/// </list>
		/// <para>For more information, see LSA Policy Function Return Values.</para>
		/// <para>The LsaNtStatusToWinError function converts an <c>NTSTATUS</c> code to a Windows error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The OriginName parameter should specify meaningful information. For example, it might contain "TTY1" to indicate terminal one or
		/// "NTLM - remote node JAZZ" to indicate a network logon that uses NTLM through a remote node called "JAZZ".
		/// </para>
		/// <para>
		/// You must call <c>LsaLogonUser</c> separately to update PKINIT device credentials for LOCAL_SYSTEM and NETWORK_SERVICE. When there
		/// is no PKINIT device credential, a successful call does no operation. When there is a PKINIT device credential, a successful call
		/// cleans up the PKINIT device credential so that only the password credential remains.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsalogonuser NTSTATUS LsaLogonUser( HANDLE LsaHandle,
		// PLSA_STRING OriginName, SECURITY_LOGON_TYPE LogonType, ULONG AuthenticationPackage, PVOID AuthenticationInformation, ULONG
		// AuthenticationInformationLength, PTOKEN_GROUPS LocalGroups, PTOKEN_SOURCE SourceContext, PVOID *ProfileBuffer, PULONG
		// ProfileBufferLength, PLUID LogonId, PHANDLE Token, PQUOTA_LIMITS Quotas, PNTSTATUS SubStatus );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntsecapi.h", MSDNShortId = "75968d53-5af2-4d77-9486-26403b73c954")]
		public static extern NTStatus LsaLogonUser(LsaConnectionHandle LsaHandle, [In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LsaStringMarshaler))] string OriginName, SECURITY_LOGON_TYPE LogonType,
			uint AuthenticationPackage, [In] IntPtr AuthenticationInformation, uint AuthenticationInformationLength, in TOKEN_GROUPS LocalGroups, in TOKEN_SOURCE SourceContext, out SafeLsaReturnBufferHandle ProfileBuffer,
			out uint ProfileBufferLength, out LUID LogonId, out SafeHTOKEN Token, out QUOTA_LIMITS Quotas, out NTStatus SubStatus);

		/// <summary>The LsaLookupAuthenticationPackage function obtains the unique identifier of an authentication package.</summary>
		/// <param name="LsaHandle">Handle obtained from a previous call to LsaRegisterLogonProcess or LsaConnectUntrusted.</param>
		/// <param name="PackageName">A string that specifies the name of the authentication package. The package name must not exceed 127 bytes in length. The following table lists the names of the Microsoft-provided authentication packages.
		/// <list type="table">
		/// <listheader><term>Value</term><term>Meaning</term></listheader>
		/// <item><term>MSV1_0_PACKAGE_NAME</term><description>The MSV1_0 authentication package name.</description></item>
		/// <item><term>MICROSOFT_KERBEROS_NAME</term><description>The Kerberos authentication package name.</description></item>
		/// <item><term>NEGOSSP_NAME</term><description>The Negotiate authentication package name.</description></item>
		/// </list>
		///</param>
		/// <param name="AuthenticationPackage">Pointer to a ULONG that receives the authentication package identifier.</param>
		/// <returns>If the function succeeds, the return value is STATUS_SUCCESS.
		/// <para>If the function fails, the return value is an NTSTATUS code. The following are possible error codes.</para>
		/// <list type="table">
		/// <listheader><term>Return code</term><term>Description</term></listheader>
		/// <item><term>STATUS_NO_SUCH_PACKAGE</term><description>The specified authentication package is unknown to the LSA.</description></item>
		/// <item><term>STATUS_NAME_TOO_LONG</term><description>The authentication package name exceeds 127 bytes.</description></item>
		/// </list></returns>
		[DllImport(Lib.Secur32, ExactSpelling = true)]
		[PInvokeData("Ntsecapi.h", MSDNShortId = "aa378297")]
		public static extern NTStatus LsaLookupAuthenticationPackage(LsaConnectionHandle LsaHandle, [In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LsaStringMarshaler))] string PackageName, out int AuthenticationPackage);

		/// <summary>
		/// The LsaRegisterLogonProcess function establishes a connection to the LSA server and verifies that the caller is a logon application.
		/// </summary>
		/// <param name="LogonProcessName">
		/// String identifying the logon application. This should be a printable name suitable for display to administrators. For example,
		/// the Windows logon application might use the name "User32LogonProcess". This name is used by the LSA during auditing.
		/// LsaRegisterLogonProcess does not check whether the name is already in use. This string must not exceed 127 bytes.
		/// </param>
		/// <param name="LsaHandle">Pointer that receives a handle used in future authentication function calls.</param>
		/// <param name="SecurityMode">The value returned is not meaningful and should be ignored.</param>
		/// <returns>
		/// If the function succeeds, the return value is STATUS_SUCCESS.
		/// <para>If the function fails, the return value is an NTSTATUS code. For more information, see LSA Policy Function Return Values.</para>
		/// <para>The LsaNtStatusToWinError function converts an NTSTATUS code to a Windows error code.</para>
		/// </returns>
		[DllImport(Lib.Secur32, ExactSpelling = true)]
		[PInvokeData("Ntsecapi.h", MSDNShortId = "aa378318")]
		public static extern NTStatus LsaRegisterLogonProcess([In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LsaStringMarshaler))] string LogonProcessName, out SafeLsaConnectionHandle LsaHandle, out uint SecurityMode);

		/// <summary>
		/// The <c>LsaRegisterPolicyChangeNotification</c> function registers an event handle with the local security authority (LSA). This
		/// event handle is signaled whenever the indicated LSA policy is modified.
		/// </summary>
		/// <param name="InformationClass">
		/// <para>
		/// A POLICY_NOTIFICATION_INFORMATION_CLASS value that specifies the type of policy changes about which your application will be
		/// notified. Specify one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PolicyNotifyAuditEventsInformation</term>
		/// <term>Auditing policy changes.</term>
		/// </item>
		/// <item>
		/// <term>PolicyNotifyAccountDomainInformation</term>
		/// <term>Account domain information changes.</term>
		/// </item>
		/// <item>
		/// <term>PolicyNotifyServerRoleInformation</term>
		/// <term>Server role changes.</term>
		/// </item>
		/// <item>
		/// <term>PolicyNotifyDomainEfsInformation</term>
		/// <term>EFS policy information changes.</term>
		/// </item>
		/// <item>
		/// <term>PolicyNotifyDomainKerberosTicketInformation</term>
		/// <term>Kerberos ticket policy information changes.</term>
		/// </item>
		/// <item>
		/// <term>PolicyNotifyDnsDomainInformation</term>
		/// <term>Domain Name System (DNS) information, name, or SID of the system's primary domain changes.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="NotificationEventHandle">
		/// A handle to an event obtained by calling the CreateEvent function. The event can be either named or unnamed.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is STATUS_SUCCESS.</para>
		/// <para>If the function fails, the return value is an NTSTATUS code. For more information, see LSA Policy Function Return Values.</para>
		/// <para>You can use the LsaNtStatusToWinError function to convert the NTSTATUS code to a Windows error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When you have finished using a notification event that has been registered by the <c>LsaRegisterPolicyChangeNotification</c>
		/// function, unregister it by calling the LsaUnregisterPolicyChangeNotification function.
		/// </para>
		/// <para>For an example that demonstrates calling this function, see Receiving Policy Change Events.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsaregisterpolicychangenotification NTSTATUS
		// LsaRegisterPolicyChangeNotification( POLICY_NOTIFICATION_INFORMATION_CLASS InformationClass, HANDLE NotificationEventHandle );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntsecapi.h", MSDNShortId = "0c713d2b-e13a-44e0-8b48-68b233d1c562")]
		public static extern NTStatus LsaRegisterPolicyChangeNotification(POLICY_NOTIFICATION_INFORMATION_CLASS InformationClass, Kernel32.SafeEventHandle NotificationEventHandle);

		/// <summary>The <c>LsaUnregisterPolicyChangeNotification</c> function disables a previously registered notification event.</summary>
		/// <param name="InformationClass">
		/// <para>
		/// A POLICY_NOTIFICATION_INFORMATION_CLASS value that specifies the policy changes that your application will stop receiving
		/// notifications for. Specify one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PolicyNotifyAuditEventsInformation</term>
		/// <term>Auditing policy changes.</term>
		/// </item>
		/// <item>
		/// <term>PolicyNotifyAccountDomainInformation</term>
		/// <term>Account domain information changes.</term>
		/// </item>
		/// <item>
		/// <term>PolicyNotifyServerRoleInformation</term>
		/// <term>Server role changes.</term>
		/// </item>
		/// <item>
		/// <term>PolicyNotifyDomainEfsInformation</term>
		/// <term>EFS policy information changes.</term>
		/// </item>
		/// <item>
		/// <term>PolicyNotifyDomainKerberosTicketInformation</term>
		/// <term>Kerberos ticket policy information changes.</term>
		/// </item>
		/// <item>
		/// <term>PolicyNotifyDnsDomainInformation</term>
		/// <term>Domain Name System (DNS) information, name, or SID of the system's primary domain changes.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="NotificationEventHandle">A handle to the notification event to unregister.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is STATUS_SUCCESS.</para>
		/// <para>If the function fails, the return value is an NTSTATUS code. For more information, see LSA Policy Function Return Values.</para>
		/// <para>You can use the LsaNtStatusToWinError function to convert the NTSTATUS code to a Windows error code.</para>
		/// </returns>
		/// <remarks>For an example that demonstrates calling this function see Receiving Policy Change Events.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsaunregisterpolicychangenotification NTSTATUS
		// LsaUnregisterPolicyChangeNotification( POLICY_NOTIFICATION_INFORMATION_CLASS InformationClass, HANDLE NotificationEventHandle );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntsecapi.h", MSDNShortId = "c1000904-20a6-40db-9b59-2cbb79e00a67")]
		public static extern NTStatus LsaUnregisterPolicyChangeNotification(POLICY_NOTIFICATION_INFORMATION_CLASS InformationClass, Kernel32.SafeEventHandle NotificationEventHandle);

		/// <summary>Provides a handle to an LSA connection.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct LsaConnectionHandle : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="LsaConnectionHandle"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public LsaConnectionHandle(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="LsaConnectionHandle"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static LsaConnectionHandle NULL => new LsaConnectionHandle(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="LsaConnectionHandle"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(LsaConnectionHandle h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="LsaConnectionHandle"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator LsaConnectionHandle(IntPtr h) => new LsaConnectionHandle(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(LsaConnectionHandle h1, LsaConnectionHandle h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(LsaConnectionHandle h1, LsaConnectionHandle h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is LsaConnectionHandle h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="LsaConnectionHandle"/> that is disposed using <see cref="LsaDeregisterLogonProcess"/>.</summary>
		public class SafeLsaConnectionHandle : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeLsaConnectionHandle"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeLsaConnectionHandle(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeLsaConnectionHandle"/> class.</summary>
			private SafeLsaConnectionHandle() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeLsaConnectionHandle"/> to <see cref="LsaConnectionHandle"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator LsaConnectionHandle(SafeLsaConnectionHandle h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => LsaDeregisterLogonProcess(this).Succeeded;
		}
	}
}