using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	/// <summary>Functions, enumerations and structures found in Secur32.dll.</summary>
	public static partial class Secur32
	{
		/// <summary>Microsoft CredSSP Security Provider.</summary>
		[PInvokeData("credssp.h")]
		public const string CREDSSP_NAME = "CREDSSP";

		/// <summary>The Kerberos authentication package name.</summary>
		[PInvokeData("Ntsecapi.h")]
		public const string MICROSOFT_KERBEROS_NAME = "Kerberos";

		/// <summary>The MSV1_0 authentication package name.</summary>
		[PInvokeData("Ntsecapi.h")]
		public const string MSV1_0_PACKAGE_NAME = "MICROSOFT_AUTHENTICATION_PACKAGE_V1_0";

		/// <summary>The Negotiate authentication package name.</summary>
		[PInvokeData("Security.h")]
		public const string NEGOSSP_NAME = "Negotiate";

		/// <summary>The NTLM authentication package name.</summary>
		[PInvokeData("Security.h")]
		public const string NTLMSP_NAME = "NTLM";

		/// <summary>TS Service Security Package</summary>
		[PInvokeData("Ntsecapi.h")]
		public const string PKU2U_PACKAGE_NAME = "pku2u";

		/// <summary>TS Service Security Package</summary>
		[PInvokeData("credssp.h")]
		public const string TS_SSP_NAME = "TSSSP";

		/// <summary>Digest Authentication for Windows.</summary>
		[PInvokeData("wdigest.h")]
		public const string WDIGEST_SP_NAME = "WDigest";
		/// <summary>Kerberos encryption types.</summary>
		[PInvokeData("Ntsecapi.h", MSDNShortId = "3b088c94-810b-44c7-887a-58e8dbd13603")]
		public enum KERB_ETYPE
		{
			KERB_ETYPE_NULL = 0,
			KERB_ETYPE_DES_CBC_CRC = 1,
			KERB_ETYPE_DES_CBC_MD4 = 2,
			KERB_ETYPE_DES_CBC_MD5 = 3,
			KERB_ETYPE_AES128_CTS_HMAC_SHA1_96 = 17,
			KERB_ETYPE_AES256_CTS_HMAC_SHA1_96 = 18,
			KERB_ETYPE_RC4_MD4 = -128,
			KERB_ETYPE_RC4_PLAIN2 = -129,
			KERB_ETYPE_RC4_LM = -130,
			KERB_ETYPE_RC4_SHA = -131,
			KERB_ETYPE_DES_PLAIN = -132,
			KERB_ETYPE_RC4_HMAC_OLD = -133,
			KERB_ETYPE_RC4_PLAIN_OLD = -134,
			KERB_ETYPE_RC4_HMAC_OLD_EXP = -135,
			KERB_ETYPE_RC4_PLAIN_OLD_EXP = -136,
			KERB_ETYPE_RC4_PLAIN = -140,
			KERB_ETYPE_RC4_PLAIN_EXP = -141,
			KERB_ETYPE_AES128_CTS_HMAC_SHA1_96_PLAIN = -148,
			KERB_ETYPE_AES256_CTS_HMAC_SHA1_96_PLAIN = -149,
			KERB_ETYPE_NTLM_HASH = -150,
			KERB_ETYPE_DSA_SHA1_CMS = 9,
			KERB_ETYPE_RSA_MD5_CMS = 10,
			KERB_ETYPE_RSA_SHA1_CMS = 11,
			KERB_ETYPE_RC2_CBC_ENV = 12,
			KERB_ETYPE_RSA_ENV = 13,
			KERB_ETYPE_RSA_ES_OEAP_ENV = 14,
			KERB_ETYPE_DES_EDE3_CBC_ENV = 15,
			KERB_ETYPE_DSA_SIGN = 8,
			KERB_ETYPE_RSA_PRIV = 9,
			KERB_ETYPE_RSA_PUB = 10,
			KERB_ETYPE_RSA_PUB_MD5 = 11,
			KERB_ETYPE_RSA_PUB_SHA1 = 12,
			KERB_ETYPE_PKCS7_PUB = 13,
			KERB_ETYPE_DES3_CBC_MD5 = 5,
			KERB_ETYPE_DES3_CBC_SHA1 = 7,
			KERB_ETYPE_DES3_CBC_SHA1_KD = 16,
			KERB_ETYPE_DES_CBC_MD5_NT = 20,
			KERB_ETYPE_RC4_HMAC_NT = 23,
			KERB_ETYPE_RC4_HMAC_NT_EXP = 24
		}

		/// <summary>The <c>KERB_LOGON_SUBMIT_TYPE</c> enumeration identifies the type of logon being requested.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ne-ntsecapi-kerb_logon_submit_type
		// typedef enum _KERB_LOGON_SUBMIT_TYPE { KerbInteractiveLogon, KerbSmartCardLogon, KerbWorkstationUnlockLogon, KerbSmartCardUnlockLogon, KerbProxyLogon, KerbTicketLogon, KerbTicketUnlockLogon, KerbS4ULogon, KerbCertificateLogon, KerbCertificateS4ULogon, KerbCertificateUnlockLogon, KerbNoElevationLogon, KerbLuidLogon } KERB_LOGON_SUBMIT_TYPE, *PKERB_LOGON_SUBMIT_TYPE;
		[PInvokeData("ntsecapi.h", MSDNShortId = "500bee53-638b-4782-b42d-1df158396fb6")]
		public enum KERB_LOGON_SUBMIT_TYPE
		{
			/// <summary>Perform an interactive logon.</summary>
			KerbInteractiveLogon = 2,
			/// <summary>Logon using a smart card.</summary>
			KerbSmartCardLogon = 6,
			/// <summary>Unlock a workstation.</summary>
			KerbWorkstationUnlockLogon,
			/// <summary>Unlock a workstation using a smart card.</summary>
			KerbSmartCardUnlockLogon,
			/// <summary>Logon using a proxy server.</summary>
			KerbProxyLogon,
			/// <summary>Logon using a valid Kerberos ticket as a credential.</summary>
			KerbTicketLogon,
			/// <summary>Unlock a workstation by using a Kerberos ticket.</summary>
			KerbTicketUnlockLogon,
			/// <summary>Perform a service for user logon.</summary>
			KerbS4ULogon,
			/// <summary>Logon interactively using a certificate stored on a smart card.</summary>
			KerbCertificateLogon,
			/// <summary>Perform a service for user logon using a certificate stored on a smart card.</summary>
			KerbCertificateS4ULogon,
			/// <summary>Unlock a workstation using a certificate stored on a smart card.</summary>
			KerbCertificateUnlockLogon,
			/// <summary />
			KerbNoElevationLogon = 83,
			/// <summary />
			KerbLuidLogon,
		}

		/// <summary>
		/// <para>
		/// The <c>KERB_PROTOCOL_MESSAGE_TYPE</c> enumeration lists the types of messages that can be sent to the Kerberos authentication
		/// package by calling the LsaCallAuthenticationPackage function.
		/// </para>
		/// <para>Each message corresponds to a dispatch routine and causes the Kerberos authentication package to perform a different task.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ne-ntsecapi-_kerb_protocol_message_type typedef enum
		// _KERB_PROTOCOL_MESSAGE_TYPE { KerbDebugRequestMessage, KerbQueryTicketCacheMessage, KerbChangeMachinePasswordMessage,
		// KerbVerifyPacMessage, KerbRetrieveTicketMessage, KerbUpdateAddressesMessage, KerbPurgeTicketCacheMessage,
		// KerbChangePasswordMessage, KerbRetrieveEncodedTicketMessage, KerbDecryptDataMessage, KerbAddBindingCacheEntryMessage,
		// KerbSetPasswordMessage, KerbSetPasswordExMessage, KerbAddExtraCredentialsMessage, KerbQueryTicketCacheExMessage,
		// KerbPurgeTicketCacheExMessage, KerbRefreshSmartcardCredentialsMessage, KerbQuerySupplementalCredentialsMessage,
		// KerbTransferCredentialsMessage, KerbQueryTicketCacheEx2Message, KerbSubmitTicketMessage, KerbAddExtraCredentialsExMessage,
		// KerbQueryKdcProxyCacheMessage, KerbPurgeKdcProxyCacheMessage, KerbQueryTicketCacheEx3Message,
		// KerbCleanupMachinePkinitCredsMessage, KerbAddBindingCacheEntryExMessage, KerbQueryBindingCacheMessage,
		// KerbPurgeBindingCacheMessage, KerbPinKdcMessage, KerbUnpinAllKdcsMessage, KerbQueryDomainExtendedPoliciesMessage,
		// KerbQueryS4U2ProxyCacheMessage } KERB_PROTOCOL_MESSAGE_TYPE, *PKERB_PROTOCOL_MESSAGE_TYPE;
		[PInvokeData("ntsecapi.h", MSDNShortId = "8ad183d2-3fe8-4f52-bfa4-16f2a711f0c3")]
		public enum KERB_PROTOCOL_MESSAGE_TYPE
		{
			/// <summary>Reserved.</summary>
			KerbDebugRequestMessage,

			/// <summary>This dispatch routine returns information about all of the cached tickets for the specified user logon session.</summary>
			KerbQueryTicketCacheMessage,

			/// <summary>This constant is reserved.</summary>
			KerbChangeMachinePasswordMessage,

			/// <summary>This constant is reserved.</summary>
			KerbVerifyPacMessage,

			/// <summary>
			/// This dispatch routine retrieves the ticket-granting ticket from the ticket cache of the specified user logon session.
			/// </summary>
			KerbRetrieveTicketMessage,

			/// <summary>This constant is reserved.</summary>
			KerbUpdateAddressesMessage,

			/// <summary>
			/// This dispatch routine allows selected tickets to be removed from the user logon session's ticket cache. It can also remove
			/// all cached tickets.
			/// </summary>
			KerbPurgeTicketCacheMessage,

			/// <summary>
			/// This message causes the use of Kerberos Password Change Protocol to change the user's password in a Windows domain or
			/// configured non-Windows Kerberos realm that supports this service. The caller must know the current password to change the
			/// password for an account. When changing the password of an account in a non-Windows Kerberos realm, the local computer's
			/// registry is consulted to locate the Kerberos password service for the requested domain name.
			/// </summary>
			KerbChangePasswordMessage,

			/// <summary>
			/// This message retrieves the specified ticket, either from the cache, if it is already there, or by requesting it from the
			/// Kerberos key distribution center (KDC).
			/// </summary>
			KerbRetrieveEncodedTicketMessage,

			/// <summary>This constant is reserved.</summary>
			KerbDecryptDataMessage,

			/// <summary>This constant is reserved.</summary>
			KerbAddBindingCacheEntryMessage,

			/// <summary>
			/// This message uses a modified Kerberos Password Change Protocol to change the user's password in the domain or configured
			/// non-Windows Kerberos realm that supports this service. The caller must have permission to set the password for the target
			/// account. The caller does not need to know the current password for the account. When changing the password for an account in
			/// a non-Windows Kerberos realm, the local computer registry is used to locate the Kerberos password service for the requested
			/// domain name.
			/// </summary>
			KerbSetPasswordMessage,

			/// <summary>This message extends KerbSetPasswordMessage by specifying the client name and realm.</summary>
			KerbSetPasswordExMessage,

			/// <summary>
			/// This message is to add, remove, or replace an extra credential. The SeTcbPrivilege is required to alter another logon
			/// account's credentials.
			/// </summary>
			KerbVerifyCredentialsMessage,

			/// <summary>This message extends KerbQueryTicketCacheMessage by specifying the client name and realm.</summary>
			KerbQueryTicketCacheExMessage,

			/// <summary>This message extends KerbPurgeTicketCacheMessage by specifying the client name and realm.</summary>
			KerbPurgeTicketCacheExMessage,

			/// <summary>This message is a request to refresh the smart card credentials.</summary>
			KerbRefreshSmartcardCredentialsMessage,

			KerbAddExtraCredentialsMessage,

			/// <summary>This constant is reserved.</summary>
			KerbQuerySupplementalCredentialsMessage,

			/// <summary>
			/// The dispatch routine transfers credentials from one LUID to another LUID. The SeTcbPrivilege is required. Windows Server 2003
			/// and Windows XP: This constant is not supported.
			/// </summary>
			KerbTransferCredentialsMessage,

			KerbQueryTicketCacheEx2Message,

			/// <summary>
			/// The dispatch routine gets the tickets from the KDC and updates the ticket cache. The SeTcbPrivilege is required to access
			/// another logon account's ticket cache. Windows Server 2003 and Windows XP: This constant is not supported.
			/// </summary>
			KerbSubmitTicketMessage,

			KerbAddExtraCredentialsExMessage,

			/// <summary>
			/// This message returned information about the KDC proxy cached tickets. Windows Server 2008, Windows Vista, Windows Server 2003
			/// and Windows XP: This constant is not supported.
			/// </summary>
			KerbQueryKdcProxyCacheMessage,

			KerbPurgeKdcProxyCacheMessage,

			/// <summary>
			/// The dispatch routine queries the Kerberos ticket cache for the specified logon session. The number of tickets information is
			/// returned in addition to the other information returned when using the KerbQueryTicketCacheEx2Message message type. The
			/// SeTcbPrivilege is required. Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This constant is not supported.
			/// </summary>
			KerbQueryTicketCacheEx3Message,

			KerbCleanupMachinePkinitCredsMessage,

			/// <summary>
			/// This message is for adding a binding cache entry. The SeTcbPrivilege is required. Windows Server 2008, Windows Vista, Windows
			/// Server 2003 and Windows XP: This constant is not supported.
			/// </summary>
			KerbAddBindingCacheEntryExMessage,

			KerbQueryBindingCacheMessage,

			/// <summary>
			/// This message is to clean up entries in the binding cache. Windows Server 2008, Windows Vista, Windows Server 2003 and Windows
			/// XP: This constant is not supported.
			/// </summary>
			KerbPurgeBindingCacheMessage,

			KerbPinKdcMessage,
			KerbUnpinAllKdcsMessage,
			KerbQueryDomainExtendedPoliciesMessage,

			/// <summary>
			/// This message queries the proxy cache for the information about a service for user (S4U) logon. Windows Server 2008, Windows
			/// Vista, Windows Server 2003 and Windows XP: This constant is not supported.
			/// </summary>
			KerbQueryS4U2ProxyCacheMessage,
		}

		/// <summary>Ticket flags, as defined in Internet RFC 4120. This parameter can be one or more of the following values.</summary>
		[PInvokeData("ntsecapi.h", MSDNShortId = "742e2795-ec74-4856-a680-7a1c233a2934")]
		[Flags]
		public enum KERB_TICKET_FLAGS : uint
		{
			/// <summary>
			/// The ticket-granting server can issue a new ticket-granting ticket with a different network address, based on the presented ticket.
			/// </summary>
			KERB_TICKET_FLAGS_forwardable = 0x40000000,

			/// <summary>
			/// The ticket has either been forwarded or was issued based on authentication that involved a forwarded ticket-granting ticket.
			/// </summary>
			KERB_TICKET_FLAGS_forwarded = 0x20000000,

			/// <summary>
			/// The protocol employed for initial authentication required the use of hardware expected to be possessed solely by the named
			/// client. The hardware authentication method is selected by the KDC, and the strength of the method is not indicated.
			/// </summary>
			KERB_TICKET_FLAGS_hw_authent = 0x00100000,

			/// <summary>
			/// The ticket was issued by using the Authentication Service protocol instead of being based on a ticket-granting ticket.
			/// </summary>
			KERB_TICKET_FLAGS_initial = 0x00400000,

			/// <summary>The ticket is not valid.</summary>
			KERB_TICKET_FLAGS_invalid = 0x01000000,

			/// <summary>
			/// Indicates to the ticket-granting server that a postdated ticket can be issued based on this ticket-granting ticket.
			/// </summary>
			KERB_TICKET_FLAGS_may_postdate = 0x04000000,

			/// <summary>
			/// The target of the ticket is trusted by the directory service for delegation. Thus, the clients may delegate their
			/// credentials to the server, which lets the server act as the client when talking to other services.
			/// </summary>
			KERB_TICKET_FLAGS_ok_as_delegate = 0x00040000,

			/// <summary>
			/// The ticket has been postdated. The end service can check the ticket's authtime member to determine when the original
			/// authentication occurred.
			/// </summary>
			KERB_TICKET_FLAGS_postdated = 0x02000000,

			/// <summary>
			/// During initial authentication, the client was authenticated by the KDC before a ticket was issued. The strength of the
			/// preauthentication method is not indicated but is acceptable to the KDC.
			/// </summary>
			KERB_TICKET_FLAGS_pre_authent = 0x00200000,

			/// <summary>
			/// Indicates to the ticket-granting server that only nonticket-granting tickets can be issued with different network addresses.
			/// </summary>
			KERB_TICKET_FLAGS_proxiable = 0x10000000,

			/// <summary>The ticket is a proxy.</summary>
			KERB_TICKET_FLAGS_proxy = 0x08000000,

			/// <summary>
			/// The ticket is renewable. If this flag is set, the time limit for renewing the ticket is set in the RenewTime member of a
			/// KERB_TICKET_CACHE_INFO structure. A renewable ticket can be used to obtain a replacement ticket that expires at a later date.
			/// </summary>
			KERB_TICKET_FLAGS_renewable = 0x00800000,

			/// <summary>Reserved for future use. Do not set this flag.</summary>
			KERB_TICKET_FLAGS_reserved = 0x80000000,

			/// <summary>Reserved.</summary>
			KERB_TICKET_FLAGS_reserved1 = 0x00000001,
		}

		[PInvokeData("ntsecapi.h", MSDNShortId = "8ed37546-6443-4010-a078-4359dd1c2861")]
		public enum KRB_NT : short
		{
			/// <summary>Unknown name type.</summary>
			KRB_NT_UNKNOWN = 0,

			/// <summary>Name of the user or a Kerberos name type principal in the case of a DCE.</summary>
			KRB_NT_PRINCIPAL = 1,

			/// <summary>Name of the principal and its SID.</summary>
			KRB_NT_PRINCIPAL_AND_ID = -131,

			/// <summary>Service name and other unique name as instance (krbtgt).</summary>
			KRB_NT_SRV_INST = 2,

			/// <summary>SPN and SID</summary>
			KRB_NT_SRV_INST_AND_ID = -132,

			/// <summary>Service name with host name as instance (telnet, rcommands).</summary>
			KRB_NT_SRV_HST = 3,

			/// <summary>Service name with host as instance other than krbtgt, telnet, or rcommands.</summary>
			KRB_NT_SRV_XHST = 4,

			/// <summary>Unique ID.</summary>
			KRB_NT_UID = 5,

			/// <summary>User principal name (UPN) or service principal name (SPN).</summary>
			KRB_NT_ENTERPRISE_PRINCIPAL = 10,

			/// <summary>Well-known principal names</summary>
			KRB_NT_WELLKNOWN = 11,

			/// <summary>UPN and security identifier (SID).</summary>
			KRB_NT_ENT_PRINCIPAL_AND_ID = -130,

			/// <summary>Windows NT 4.0–style name.</summary>
			KRB_NT_MS_PRINCIPAL = -128,

			/// <summary>Windows NT 4.0–style name with SID.</summary>
			KRB_NT_MS_PRINCIPAL_AND_ID = -129,

			/// <summary>Branch ID</summary>
			KRB_NT_MS_BRANCH_ID = -133,
		}

		/// <summary>The user flags for the logon session.</summary>
		[PInvokeData("ntsecapi.h", MSDNShortId = "284ddb9a-fd08-4f38-b1d0-242596c114a8")]
		[Flags]
		public enum LogonUserFlags : uint
		{
			/// <summary>The logon is an optimized logon session.</summary>
			LOGON_OPTIMIZED = 0x4000,

			/// <summary>The logon was created for Winlogon.</summary>
			LOGON_WINLOGON = 0x8000,

			/// <summary>The Kerberos PKINIT extension was used to authenticate the user in this logon session.</summary>
			LOGON_PKINIT = 0x10000,

			/// <summary>Optimized logon has been disabled for this account.</summary>
			LOGON_NOT_OPTIMIZED = 0x20000,
		}

		/// <summary>
		/// <para>The <c>MSV1_0_LOGON_SUBMIT_TYPE</c> enumeration indicates the kind of logon being requested.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ne-ntsecapi-_msv1_0_logon_submit_type typedef enum
		// _MSV1_0_LOGON_SUBMIT_TYPE { MsV1_0InteractiveLogon, MsV1_0Lm20Logon, MsV1_0NetworkLogon, MsV1_0SubAuthLogon,
		// MsV1_0WorkstationUnlockLogon, MsV1_0S4ULogon, MsV1_0VirtualLogon, MsV1_0NoElevationLogon, MsV1_0LuidLogon }
		// MSV1_0_LOGON_SUBMIT_TYPE, *PMSV1_0_LOGON_SUBMIT_TYPE;
		[PInvokeData("ntsecapi.h", MSDNShortId = "03bf43f0-44f4-40c6-8d5d-381f36ebdd0e")]
		public enum MSV1_0_LOGON_SUBMIT_TYPE
		{
			/// <summary>
			/// Requests an interactive user logon. This dispatch routine handles NTLM interactive logons initiated by LsaLogonUser or LogonUser.
			/// </summary>
			MsV1_0InteractiveLogon = 2,

			/// <summary>
			/// Requests the second half of an NTLM 2.0 protocol logon. The first half of this type of logon is performed by calling
			/// LsaCallAuthenticationPackage with the MsV1_0Lm20ChallengeRequest message. For more information see, MSV1_0_PROTOCOL_MESSAGE_TYPE.
			/// </summary>
			MsV1_0Lm20Logon,

			/// <summary>
			/// Requests a network logon. The only difference between this dispatch routine and MsV1_0Lm20Logon is that MsV1_0NetworkLogon
			/// uses a ParameterControl member.
			/// </summary>
			MsV1_0NetworkLogon,

			/// <summary>
			/// Requests the second half of an NTLM 2.0 protocol logon using a subauthentication package. When MSV1_0 initializes itself, it
			/// checks a registry key to determine whether it should load a subauthentication package. For more information about
			/// subauthentication packages used with MSV1_0, see the subauthentication sample included in the Platform SDK.
			/// </summary>
			MsV1_0SubAuthLogon,

			/// <summary>Requests a logon unlock of a workstation. Note Windows Server 2003Windows XPThis constant is not supported.</summary>
			MsV1_0WorkstationUnlockLogon,

			/// <summary>
			/// Requests a service for user (S4U) logon. Note Windows Server 2003 with SP2Windows VistaWindows Server 2003Windows XPThis
			/// constant is not supported.
			/// </summary>
			MsV1_0S4ULogon = 12,

			/// <summary>
			/// Requests a logon from a remote session. Note Windows Server 2003 with SP2Windows VistaWindows Server 2003Windows XPThis
			/// constant is not supported.
			/// </summary>
			MsV1_0VirtualLogon = 82,

			/// <summary/>
			MsV1_0NoElevationLogon = 83,

			/// <summary/>
			MsV1_0LuidLogon = 84,
		}

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
		/// <para>The <c>LsaGetLogonSessionData</c> function retrieves information about a specified logon session.</para>
		/// <para>To retrieve information about a logon session, the caller must be the owner of the session or a local system administrator.</para>
		/// </summary>
		/// <param name="LogonId">
		/// Specifies a pointer to a <c>LUID</c> that identifies the logon session whose information will be retrieved. For information about
		/// valid values for this parameter, see Remarks.
		/// </param>
		/// <param name="ppLogonSessionData">
		/// Address of a pointer to a SECURITY_LOGON_SESSION_DATA structure containing information on the logon session specified by LogonId.
		/// This structure is allocated by the LSA. When the information is no longer needed, call the LSAFreeReturnBuffer function to free
		/// the memory used by this structure.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is STATUS_SUCCESS.</para>
		/// <para>If the function fails, the return value is an <c>NTSTATUS</c> code indicating the reason.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To obtain valid logon session identifiers that may be passed to this function's LogonId parameter, call the
		/// LsaEnumerateLogonSessions function.
		/// </para>
		/// <para>
		/// If LogonID specifies the LocalSystem account (0x0:0x3e7), then this function returns zero for the logon session data retrieved in
		/// ppLogonSessionData. The reason is that the LocalSystem account does not get logged on in the typical logon manner. Rather, the
		/// LocalSystem account is active after the system starts.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsagetlogonsessiondata NTSTATUS LsaGetLogonSessionData(
		// PLUID LogonId, PSECURITY_LOGON_SESSION_DATA *ppLogonSessionData );
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
			uint AuthenticationPackage, [In] IntPtr AuthenticationInformation, uint AuthenticationInformationLength, [Optional] IntPtr LocalGroups, in TOKEN_SOURCE SourceContext, out SafeLsaReturnBufferHandle ProfileBuffer,
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
		public static extern NTStatus LsaLookupAuthenticationPackage(LsaConnectionHandle LsaHandle, [In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LsaStringMarshaler))] string PackageName, out uint AuthenticationPackage);

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

		/// <summary>The <c>KERB_CRYPTO_KEY</c> structure contains information about a Kerberos cryptographic session key.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ns-ntsecapi-kerb_crypto_key typedef struct KERB_CRYPTO_KEY { LONG
		// KeyType; ULONG Length; PUCHAR Value; } KERB_CRYPTO_KEY, *PKERB_CRYPTO_KEY;
		[PInvokeData("ntsecapi.h", MSDNShortId = "ac7ea61c-b1e0-4dc0-931e-81bb6fd74888")]
		[StructLayout(LayoutKind.Sequential)]
		public struct KERB_CRYPTO_KEY
		{
			/// <summary>
			/// <para>Indicates the type of session key stored in the structure. It can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>KERB_ETYPE_DES_CBC_CRC</term>
			/// <term>Use DES encryption in cipher-block-chaining mode with a CRC-32 checksum.</term>
			/// </item>
			/// <item>
			/// <term>KERB_ETYPE_DES_CBC_MD4</term>
			/// <term>Use DES encryption in cipher-block-chaining mode with a MD4 checksum.</term>
			/// </item>
			/// <item>
			/// <term>KERB_ETYPE_DES_CBC_MD5</term>
			/// <term>Use DES encryption in cipher-block-chaining mode with a MD5 checksum.</term>
			/// </item>
			/// <item>
			/// <term>KERB_ETYPE_NULL</term>
			/// <term>Use no encryption.</term>
			/// </item>
			/// <item>
			/// <term>KERB_ETYPE_RC4_HMAC_NT</term>
			/// <term>Use the RC4 stream cipher with a hash-based Message Authentication Code (MAC).</term>
			/// </item>
			/// <item>
			/// <term>KERB_ETYPE_RC4_MD4</term>
			/// <term>Use the RC4 stream cipher with the MD4 hash function.</term>
			/// </item>
			/// </list>
			/// <para>Values greater than 127 are reserved for local values and may change without notice.</para>
			/// </summary>
			public int KeyType;

			/// <summary>Specifies the length, in bytes, of the cryptographic session key.</summary>
			public uint Length;

			/// <summary>Contains the cryptographic session key.</summary>
			public IntPtr Value;
		}

		/// <summary>
		/// <para>The <c>KERB_EXTERNAL_NAME</c> structure contains information about an external name.</para>
		/// <para>An external name is one used by external users. This structure is used by the KERB_EXTERNAL_TICKET structure.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ns-ntsecapi-_kerb_external_name typedef struct _KERB_EXTERNAL_NAME {
		// SHORT NameType; USHORT NameCount; UNICODE_STRING Names[ANYSIZE_ARRAY]; } KERB_EXTERNAL_NAME, *PKERB_EXTERNAL_NAME;
		[PInvokeData("ntsecapi.h", MSDNShortId = "8ed37546-6443-4010-a078-4359dd1c2861")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		public struct KERB_EXTERNAL_NAME
		{
			/// <summary>
			/// <para>Indicates the type of the names stored in this structure.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>KRB_NT_UNKNOWN</term>
			/// <term>Unknown name type.</term>
			/// </item>
			/// <item>
			/// <term>KRB_NT_PRINCIPAL</term>
			/// <term>Name of the user or a Kerberos name type principal in the case of a DCE.</term>
			/// </item>
			/// <item>
			/// <term>KRB_NT_SRV_INST</term>
			/// <term>Service name and other unique name as instance (krbtgt).</term>
			/// </item>
			/// <item>
			/// <term>KRB_NT_SRV_HST</term>
			/// <term>Service name with host name as instance (telnet, rcommands).</term>
			/// </item>
			/// <item>
			/// <term>KRB_NT_SRV_XHST</term>
			/// <term>Service name with host as instance other than krbtgt, telnet, or rcommands.</term>
			/// </item>
			/// <item>
			/// <term>KRB_NT_UID</term>
			/// <term>Unique ID.</term>
			/// </item>
			/// <item>
			/// <term>KRB_NT_ENTERPRISE_PRINCIPAL</term>
			/// <term>User principal name (UPN) or service principal name (SPN).</term>
			/// </item>
			/// <item>
			/// <term>KRB_NT_ENT_PRINCIPAL_AND_ID</term>
			/// <term>UPN and security identifier (SID).</term>
			/// </item>
			/// <item>
			/// <term>KRB_NT_MS_PRINICPAL</term>
			/// <term>Windows NT 4.0–style name.</term>
			/// </item>
			/// <item>
			/// <term>KRB_NT_MS_PRINCIPAL_AND_ID</term>
			/// <term>Windows NT 4.0–style name with SID.</term>
			/// </item>
			/// </list>
			/// </summary>
			[FieldOffset(0)]
			public KRB_NT NameType;

			/// <summary>Indicates the number of names stored in <c>Names</c>.</summary>
			[FieldOffset(2)]
			public ushort NameCount;

			/// <summary>Array of UNICODE_STRINGS containing the names.</summary>
			[FieldOffset(8)]
			public IntPtr Names;

			/// <summary>Extracts the names from <see cref="Names"/>.</summary>
			/// <returns>A sequence of names.</returns>
			public IEnumerable<string> GetNames()
			{
				if (NameCount == 0)
					yield break;
				using var pin = new PinnedObject(this);
				foreach (var us in ((IntPtr)pin).ToIEnum<LSA_UNICODE_STRING>(NameCount, 8))
					yield return us.ToString();
			}
		}

		/// <summary>
		/// <para>The <c>KERB_EXTERNAL_TICKET</c> structure contains information about an external ticket.</para>
		/// <para>
		/// An external ticket is a Kerberos ticket exported to external users. The Kerberos ticket is defined in Internet RFC 4120. For more
		/// information, see http://www.ietf.org. This structure is used by the KERB_RETRIEVE_TKT_RESPONSE structure.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ns-ntsecapi-_kerb_external_ticket typedef struct
		// _KERB_EXTERNAL_TICKET { PKERB_EXTERNAL_NAME ServiceName; PKERB_EXTERNAL_NAME TargetName; PKERB_EXTERNAL_NAME ClientName;
		// UNICODE_STRING DomainName; UNICODE_STRING TargetDomainName; UNICODE_STRING AltTargetDomainName; KERB_CRYPTO_KEY SessionKey; ULONG
		// TicketFlags; ULONG Flags; LARGE_INTEGER KeyExpirationTime; LARGE_INTEGER StartTime; LARGE_INTEGER EndTime; LARGE_INTEGER
		// RenewUntil; LARGE_INTEGER TimeSkew; ULONG EncodedTicketSize; PUCHAR EncodedTicket; } KERB_EXTERNAL_TICKET, *PKERB_EXTERNAL_TICKET;
		[PInvokeData("ntsecapi.h", MSDNShortId = "742e2795-ec74-4856-a680-7a1c233a2934")]
		[StructLayout(LayoutKind.Sequential)]
		public struct KERB_EXTERNAL_TICKET
		{
			/// <summary>A KERB_EXTERNAL_NAME structure that contains a multiple part, canonical, returned service name.</summary>
			public IntPtr ServiceName;

			/// <summary>A KERB_EXTERNAL_NAME structure that contains the multiple part service principal name (SPN).</summary>
			public IntPtr TargetName;

			/// <summary>
			/// A KERB_EXTERNAL_NAME structure that contains the client name in the ticket. This name is relative to the current domain.
			/// </summary>
			public IntPtr ClientName;

			/// <summary>
			/// A UNICODE_STRING that contains the name of the domain that corresponds to the <c>ServiceName</c> member. This is the domain
			/// that issued the ticket.
			/// </summary>
			public LSA_UNICODE_STRING DomainName;

			/// <summary>
			/// A UNICODE_STRING that contains the name of the domain in which the ticket is valid. For an interdomain ticket, this is the
			/// destination domain.
			/// </summary>
			public LSA_UNICODE_STRING TargetDomainName;

			/// <summary>
			/// A UNICODE_STRING that contains a synonym for the destination domain. Every domain has two names: a DNS name and a NetBIOS
			/// name. If the name returned in the ticket is different from the name used to request the ticket (the Kerberos Key Distribution
			/// Center (KDC) may do name mapping), this string contains the original name.
			/// </summary>
			public LSA_UNICODE_STRING AltTargetDomainName;

			/// <summary>A KERB_CRYPTO_KEY structure that contains the session key for the ticket.</summary>
			public KERB_CRYPTO_KEY SessionKey;

			/// <summary>
			/// <para>Ticket flags, as defined in Internet RFC 4120. This parameter can be one or more of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>KERB_TICKET_FLAGS_forwardable (0x40000000)</term>
			/// <term>
			/// The ticket-granting server can issue a new ticket-granting ticket with a different network address, based on the presented ticket.
			/// </term>
			/// </item>
			/// <item>
			/// <term>KERB_TICKET_FLAGS_forwarded (0x20000000)</term>
			/// <term>
			/// The ticket has either been forwarded or was issued based on authentication that involved a forwarded ticket-granting ticket.
			/// </term>
			/// </item>
			/// <item>
			/// <term>KERB_TICKET_FLAGS_hw_authent (0x00100000)</term>
			/// <term>
			/// The protocol employed for initial authentication required the use of hardware expected to be possessed solely by the named
			/// client. The hardware authentication method is selected by the KDC, and the strength of the method is not indicated.
			/// </term>
			/// </item>
			/// <item>
			/// <term>KERB_TICKET_FLAGS_initial (0x00400000)</term>
			/// <term>The ticket was issued by using the Authentication Service protocol instead of being based on a ticket-granting ticket.</term>
			/// </item>
			/// <item>
			/// <term>KERB_TICKET_FLAGS_invalid (0x01000000)</term>
			/// <term>The ticket is not valid.</term>
			/// </item>
			/// <item>
			/// <term>KERB_TICKET_FLAGS_may_postdate (0x04000000)</term>
			/// <term>Indicates to the ticket-granting server that a postdated ticket can be issued based on this ticket-granting ticket.</term>
			/// </item>
			/// <item>
			/// <term>KERB_TICKET_FLAGS_ok_as_delegate (0x00040000)</term>
			/// <term>
			/// The target of the ticket is trusted by the directory service for delegation. Thus, the clients may delegate their credentials
			/// to the server, which lets the server act as the client when talking to other services.
			/// </term>
			/// </item>
			/// <item>
			/// <term>KERB_TICKET_FLAGS_postdated (0x02000000)</term>
			/// <term>
			/// The ticket has been postdated. The end service can check the ticket's authtime member to determine when the original
			/// authentication occurred.
			/// </term>
			/// </item>
			/// <item>
			/// <term>KERB_TICKET_FLAGS_pre_authent (0x00200000)</term>
			/// <term>
			/// During initial authentication, the client was authenticated by the KDC before a ticket was issued. The strength of the
			/// preauthentication method is not indicated but is acceptable to the KDC.
			/// </term>
			/// </item>
			/// <item>
			/// <term>KERB_TICKET_FLAGS_proxiable (0x10000000)</term>
			/// <term>
			/// Indicates to the ticket-granting server that only nonticket-granting tickets can be issued with different network addresses.
			/// </term>
			/// </item>
			/// <item>
			/// <term>KERB_TICKET_FLAGS_proxy (0x08000000)</term>
			/// <term>The ticket is a proxy.</term>
			/// </item>
			/// <item>
			/// <term>KERB_TICKET_FLAGS_renewable (0x00800000)</term>
			/// <term>
			/// The ticket is renewable. If this flag is set, the time limit for renewing the ticket is set in the RenewTime member of a
			/// KERB_TICKET_CACHE_INFO structure. A renewable ticket can be used to obtain a replacement ticket that expires at a later date.
			/// </term>
			/// </item>
			/// <item>
			/// <term>KERB_TICKET_FLAGS_reserved (0x80000000)</term>
			/// <term>Reserved for future use. Do not set this flag.</term>
			/// </item>
			/// <item>
			/// <term>KERB_TICKET_FLAGS_reserved1 (0x00000001)</term>
			/// <term>Reserved.</term>
			/// </item>
			/// </list>
			/// </summary>
			public KERB_TICKET_FLAGS TicketFlags;

			/// <summary>Reserved for future use. Set this member to zero.</summary>
			public uint Flags;

			/// <summary>A FILETIME structure that contains the time at which the key expires.</summary>
			public FILETIME KeyExpirationTime;

			/// <summary>A FILETIME structure that contains the time at which the ticket becomes valid.</summary>
			public FILETIME StartTime;

			/// <summary>A FILETIME structure that contains the time at which the ticket expires.</summary>
			public FILETIME EndTime;

			/// <summary>
			/// A FILETIME structure that contains the latest time a ticket can be renewed. Renewal requests sent after this time will be rejected.
			/// </summary>
			public FILETIME RenewUntil;

			/// <summary>
			/// A FILETIME structure that contains the measured time difference between the current time on the computer issuing the ticket
			/// and the computer where the ticket will be used.
			/// </summary>
			public FILETIME TimeSkew;

			/// <summary>The size, in bytes, of the encoded ticket.</summary>
			public uint EncodedTicketSize;

			/// <summary>A buffer that contains the Abstract Syntax Notation One (ASN.1)-encoded ticket.</summary>
			public IntPtr EncodedTicket;

			// /// <summary>ServiceName value.</summary> public string ServiceNameValue => ServiceName == default ? null :
			// ServiceName.ToStructure<KERB_EXTERNAL_NAME>().ToString(); /// <summary>TargetName value.</summary> public string
			// TargetNameValue => TargetName == default ? null : TargetName.ToStructure<KERB_EXTERNAL_NAME>().ToString(); ///
			// <summary>ClientName value.</summary> public string ClientNameValue => ClientName == default ? null : ClientName.ToStructure<KERB_EXTERNAL_NAME>().ToString();
		}

		/// <summary>
		/// <para>The <c>KERB_INTERACTIVE_LOGON</c> structure contains information about an interactive logon session.</para>
		/// <para>It is used by LsaLogonUser with the Kerberos security package using LOGON32_PROVIDER_WINNT50 or LOGON32_PROVIDER_DEFAULT.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ns-ntsecapi-_kerb_interactive_logon typedef struct
		// _KERB_INTERACTIVE_LOGON { KERB_LOGON_SUBMIT_TYPE MessageType; UNICODE_STRING LogonDomainName; UNICODE_STRING UserName;
		// UNICODE_STRING Password; } KERB_INTERACTIVE_LOGON, *PKERB_INTERACTIVE_LOGON;
		[PInvokeData("ntsecapi.h", MSDNShortId = "96aec0cc-b3e1-4b4b-aa0e-ecf05b9fabbe")]
		[StructLayout(LayoutKind.Sequential)]
		public struct KERB_INTERACTIVE_LOGON
		{
			/// <summary>KERB_LOGON_SUBMIT_TYPE value identifying the type of logon request being made. This member must be set to <c>KerbInteractiveLogon</c>.</summary>
			public KERB_LOGON_SUBMIT_TYPE MessageType;

			/// <summary>UNICODE_STRING specifying the name of the target logon domain.</summary>
			public LSA_UNICODE_STRING LogonDomainName;

			/// <summary>UNICODE_STRING specifying the user name.</summary>
			public LSA_UNICODE_STRING UserName;

			/// <summary>
			/// UNICODE_STRING specifying the user password. When you have finished using the password, remove the sensitive information from
			/// memory by calling SecureZeroMemory. For more information on protecting the password, see Handling Passwords.
			/// </summary>
			public LSA_UNICODE_STRING Password;
		}

		/// <summary>
		/// <para>The <c>KERB_PURGE_TKT_CACHE_REQUEST</c> structure contains information used to delete entries from the ticket cache.</para>
		/// <para>It is used by LsaCallAuthenticationPackage.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If both <c>ServerName</c> and <c>RealmName</c> are of zero length, LsaCallAuthenticationPackage will delete all tickets for the
		/// logon session identified by <c>LogonId</c>. Otherwise, <c>LsaCallAuthenticationPackage</c> will search the cache tickets for
		/// <c>ServerName</c>@ <c>RealmName</c>, and will delete all such tickets.
		/// </para>
		/// <para>
		/// LsaCallAuthenticationPackage does not return this buffer. It returns STATUS_SUCCESS if one or more tickets are deleted. If no
		/// tickets are found, the function returns SEC_E_NO_CREDENTIALS.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ntsecapi/ns-ntsecapi-kerb_purge_tkt_cache_request typedef struct
		// _KERB_PURGE_TKT_CACHE_REQUEST { KERB_PROTOCOL_MESSAGE_TYPE MessageType; LUID LogonId; UNICODE_STRING ServerName; UNICODE_STRING
		// RealmName; } KERB_PURGE_TKT_CACHE_REQUEST, *PKERB_PURGE_TKT_CACHE_REQUEST;
		[PInvokeData("ntsecapi.h", MSDNShortId = "4e5e944a-8163-42de-b534-3b0478d9f334")]
		[StructLayout(LayoutKind.Sequential)]
		public struct KERB_PURGE_TKT_CACHE_REQUEST
		{
			/// <summary>KERB_PROTOCOL_MESSAGE_TYPE value identifying the type of request being made. This member must be set to <c>KerbPurgeTicketCacheMessage</c>.</summary>
			public KERB_PROTOCOL_MESSAGE_TYPE MessageType;

			/// <summary>
			/// LUID structure containing the logon session identifier. This can be zero for the current user's logon session. If not zero,
			/// the caller must have the SeTcbPrivilege privilege set. If this fails, the Kerberos authentication package sets the
			/// ProtocolStatus parameter of LsaCallAuthenticationPackage to <c>STATUS_ACCESS_DENIED</c>.
			/// </summary>
			public LUID LogonId;

			/// <summary>UNICODE_STRING containing the name of the service whose tickets should be deleted from the cache.</summary>
			public LSA_UNICODE_STRING ServerName;

			/// <summary>UNICODE_STRING containing the name of the realm whose tickets should be deleted from the cache.</summary>
			public LSA_UNICODE_STRING RealmName;
		}

		/// <summary>
		/// <para>The <c>KERB_QUERY_TKT_CACHE_REQUEST</c> structure contains information used to query the ticket cache.</para>
		/// <para>It is used by LsaCallAuthenticationPackage.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/ntsecapi/ns-ntsecapi-kerb_query_tkt_cache_request typedef struct
		// _KERB_QUERY_TKT_CACHE_REQUEST { KERB_PROTOCOL_MESSAGE_TYPE MessageType; LUID LogonId; } KERB_QUERY_TKT_CACHE_REQUEST, *PKERB_QUERY_TKT_CACHE_REQUEST;
		[PInvokeData("ntsecapi.h", MSDNShortId = "3c8e63b3-9ac4-4228-87e1-6802c3d12d6c")]
		[StructLayout(LayoutKind.Sequential)]
		public struct KERB_QUERY_TKT_CACHE_REQUEST
		{
			/// <summary>
			/// <para>
			/// KERB_PROTOCOL_MESSAGE_TYPE value identifying the type of request being made. This member must be set to
			/// <c>KerbQueryTicketCacheMessage</c> or <c>KerbRetrieveTicketMessage</c>.
			/// </para>
			/// <para>
			/// If this member is set to <c>KerbQueryTicketCacheMessage</c>, the request is for information about all of the cached tickets
			/// for the specified user logon session. If it is set to <c>KerbRetrieveTicketMessage</c>, the request is for the ticket
			/// granting ticket from the ticket cache of the specified user logon session.
			/// </para>
			/// </summary>
			public KERB_PROTOCOL_MESSAGE_TYPE MessageType;

			/// <summary>
			/// LUID structure containing the logon session identifier. This can be zero for the current user's logon session. If not zero,
			/// the caller must have the SeTcbPrivilege privilege set. If this fails, the Kerberos authentication package sets the
			/// ProtocolStatus parameter of LsaCallAuthenticationPackage to STATUS_ACCESS_DENIED.
			/// </summary>
			public LUID LogonId;
		}

		/// <summary>
		/// <para>The <c>KERB_QUERY_TKT_CACHE_RESPONSE</c> structure contains the results of querying the ticket cache.</para>
		/// <para>It is used by LsaCallAuthenticationPackage.</para>
		/// </summary>
		/// <remarks>
		/// This buffer is allocated by the Kerberos authentication package and should be deleted by the application that called
		/// LsaCallAuthenticationPackage, using LsaFreeReturnBuffer.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ntsecapi/ns-ntsecapi-kerb_query_tkt_cache_response typedef struct
		// _KERB_QUERY_TKT_CACHE_RESPONSE { KERB_PROTOCOL_MESSAGE_TYPE MessageType; ULONG CountOfTickets; KERB_TICKET_CACHE_INFO
		// Tickets[ANYSIZE_ARRAY]; } KERB_QUERY_TKT_CACHE_RESPONSE, *PKERB_QUERY_TKT_CACHE_RESPONSE;
		[PInvokeData("ntsecapi.h", MSDNShortId = "2101c1de-f304-4d44-899f-f9f03cd50934")]
		[StructLayout(LayoutKind.Sequential)]
		[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<KERB_QUERY_TKT_CACHE_RESPONSE>), nameof(CountOfTickets))]
		public struct KERB_QUERY_TKT_CACHE_RESPONSE
		{
			/// <summary>KERB_PROTOCOL_MESSAGE_TYPE value identifying the type of request being made. This member must be set to <c>KerbQueryTicketCacheMessage</c>.</summary>
			public KERB_PROTOCOL_MESSAGE_TYPE MessageType;

			/// <summary>
			/// Number of tickets in <c>Tickets</c> array. This can be zero if no tickets are available for the specified logon session.
			/// </summary>
			public uint CountOfTickets;

			/// <summary>Array of length <c>CountOfTickets</c> of KERB_TICKET_CACHE_INFO structures.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public KERB_TICKET_CACHE_INFO[] Tickets;
		}

		/// <summary>
		/// <para>The <c>KERB_RETRIEVE_TKT_REQUEST</c> structure contains information used to retrieve a ticket.</para>
		/// <para>
		/// It is used by LsaCallAuthenticationPackage.The Kerberos ticket is defined in Internet RFC 4120. For more information, see http://www.ietf.org.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ns-ntsecapi-_kerb_retrieve_tkt_request typedef struct
		// _KERB_RETRIEVE_TKT_REQUEST { KERB_PROTOCOL_MESSAGE_TYPE MessageType; LUID LogonId; UNICODE_STRING TargetName; ULONG TicketFlags;
		// ULONG CacheOptions; LONG EncryptionType; SecHandle CredentialsHandle; } KERB_RETRIEVE_TKT_REQUEST, *PKERB_RETRIEVE_TKT_REQUEST;
		[PInvokeData("ntsecapi.h", MSDNShortId = "3b088c94-810b-44c7-887a-58e8dbd13603")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct KERB_RETRIEVE_TKT_REQUEST
		{
			/// <summary>KERB_PROTOCOL_MESSAGE_TYPE value indicating the type of request being made. This member must be set to <c>KerbRetrieveEncodedTicketMessage</c>.</summary>
			public KERB_PROTOCOL_MESSAGE_TYPE MessageType;

			/// <summary>
			/// LUID structure containing the logon session identifier. This can be zero for the current user's logon session. If not zero,
			/// the caller must have the SeTcbPrivilege privilege set. If this fails, the Kerberos authentication package sets the
			/// ProtocolStatus parameter of LsaCallAuthenticationPackage to STATUS_ACCESS_DENIED.
			/// </summary>
			public LUID LogonId;

			/// <summary>UNICODE_STRING containing the name of the target service.</summary>
			public LSA_UNICODE_STRING TargetName;

			/// <summary>
			/// <para>
			/// Contains flags specifying uses for the retrieved ticket. If <c>TicketFlags</c> is set to zero and if there is a matching
			/// ticket found in the cache, then that ticket will be returned, regardless of its flag values. If there is no match in the
			/// cache, a new ticket with the default flag values will be requested.
			/// </para>
			/// <para>If this member is not set to zero, the returned ticket will not be cached.</para>
			/// </summary>
			public uint TicketFlags;

			/// <summary>
			/// <para>
			/// Indicates options for searching the cache. Set this member to zero to indicate that the cache should be searched and if no
			/// ticket if found, a new ticket should be requested.
			/// </para>
			/// <para>If this member is not set to zero, the returned ticket will not be cached.</para>
			/// <para><c>CacheOptions</c> can contain the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>KERB_RETRIEVE_TICKET_DONT_USE_CACHE 1</term>
			/// <term>
			/// Always request a new ticket; do not search the cache. If a ticket is obtained, the Kerberos authentication package returns
			/// STATUS_SUCCESS in the ProtocolStatus parameter of the LsaCallAuthenticationPackage function.
			/// </term>
			/// </item>
			/// <item>
			/// <term>KERB_RETRIEVE_TICKET_USE_CREDHANDLE 4</term>
			/// <term>
			/// Use the CredentialsHandle member instead of LogonId to identify the logon session. The credential handle is used as the
			/// client credential for which the ticket is retrieved Note This option is not available for 32-bit Windows-based applications
			/// running on 64-bit Windows.
			/// </term>
			/// </item>
			/// <item>
			/// <term>KERB_RETRIEVE_TICKET_USE_CACHE_ONLY 2</term>
			/// <term>
			/// Return only a previously cached ticket. If such a ticket is not found, the Kerberos authentication package returns
			/// STATUS_OBJECT_NAME_NOT_FOUND in the ProtocolStatus parameter of the LsaCallAuthenticationPackage function.
			/// </term>
			/// </item>
			/// <item>
			/// <term>KERB_RETRIEVE_TICKET_AS_KERB_CRED 8</term>
			/// <term>
			/// Return the ticket as a Kerberos credential. The Kerberos ticket is defined in Internet RFC 4120 as KRB_CRED. For more
			/// information, see http://www.ietf.org.
			/// </term>
			/// </item>
			/// <item>
			/// <term>KERB_RETRIEVE_TICKET_WITH_SEC_CRED 10</term>
			/// <term>Not implemented.</term>
			/// </item>
			/// <item>
			/// <term>KERB_RETRIEVE_TICKET_CACHE_TICKET 20</term>
			/// <term>
			/// Return the ticket that is currently in the cache. If the ticket is not in the cache, it is requested and then cached. This
			/// flag should not be used with the KERB_RETRIEVE_TICKET_DONT_USE_CACHE flag. Windows XP with SP1 and earlier and Windows Server
			/// 2003: This option is not available.
			/// </term>
			/// </item>
			/// <item>
			/// <term>KERB_RETRIEVE_TICKET_MAX_LIFETIME 40</term>
			/// <term>
			/// Return a fresh ticket with maximum allowed time by the policy. The ticker is cached afterwards. Use of this flag implies that
			/// KERB_RETRIEVE_TICKET_USE_CACHE_ONLY is not set and KERB_RETRIEVE_TICKET_CACHE_TICKET is set. Windows Vista, Windows Server
			/// 2008, Windows XP with SP1 and earlier and Windows Server 2003: This option is not available.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public uint CacheOptions;

			/// <summary>
			/// <para>
			/// Specifies the type of encryption to use for the requested ticket. If this member is not set to zero, the returned ticket will
			/// not be cached.
			/// </para>
			/// <para>This member can have one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>KERB_ETYPE_DES_CBC_CRC</term>
			/// <term>Use DES encryption in cipher-block-chaining mode with a CRC-32 checksum.</term>
			/// </item>
			/// <item>
			/// <term>KERB_ETYPE_DES_CBC_MD4</term>
			/// <term>Use DES encryption in cipher-block-chaining mode with a MD4 checksum.</term>
			/// </item>
			/// <item>
			/// <term>KERB_ETYPE_DES_CBC_MD5</term>
			/// <term>Use DES encryption in cipher-block-chaining mode with a MD5 checksum.</term>
			/// </item>
			/// <item>
			/// <term>KERB_ETYPE_NULL</term>
			/// <term>Use no encryption.</term>
			/// </item>
			/// <item>
			/// <term>KERB_ETYPE_RC4_HMAC_NT</term>
			/// <term>Use the RC4 stream cipher with a hash-based Message Authentication Code (MAC), as used by Windows.</term>
			/// </item>
			/// <item>
			/// <term>KERB_ETYPE_RC4_MD4</term>
			/// <term>Use the RC4 stream cipher with the MD4 hash function.</term>
			/// </item>
			/// <item>
			/// <term>&gt;127</term>
			/// <term>Values greater than 127 are reserved for local values and may change without notice.</term>
			/// </item>
			/// </list>
			/// </summary>
			public KERB_ETYPE EncryptionType;

			/// <summary>An SSPI credentials handle used in place of a logon session identifier.</summary>
			public CredHandle CredentialsHandle;
		}

		/// <summary>
		/// <para>The <c>KERB_RETRIEVE_TKT_RESPONSE</c> structure contains the response from retrieving a ticket.</para>
		/// <para>It is used by LsaCallAuthenticationPackage.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ns-ntsecapi-_kerb_retrieve_tkt_response typedef struct
		// _KERB_RETRIEVE_TKT_RESPONSE { KERB_EXTERNAL_TICKET Ticket; } KERB_RETRIEVE_TKT_RESPONSE, *PKERB_RETRIEVE_TKT_RESPONSE;
		[PInvokeData("ntsecapi.h", MSDNShortId = "682d4076-dc65-4291-8a82-981f207ae432")]
		[StructLayout(LayoutKind.Sequential)]
		public struct KERB_RETRIEVE_TKT_RESPONSE
		{
			/// <summary>KERB_EXTERNAL_TICKET structure containing the requested ticket.</summary>
			public KERB_EXTERNAL_TICKET Ticket;
		}

		/// <summary>
		/// <para>
		/// The <c>KERB_TICKET_CACHE_INFO</c> structure contains information about a cached Kerberos ticket. The Kerberos ticket is defined
		/// in Internet RFC 4120. For more information, see http://www.ietf.org.
		/// </para>
		/// <para>
		/// It can be used both for retrieving tickets and querying the ticket cache. The KERB_QUERY_TKT_CACHE_RESPONSE structure uses this structure.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/ntsecapi/ns-ntsecapi-kerb_ticket_cache_info typedef struct
		// _KERB_TICKET_CACHE_INFO { UNICODE_STRING ServerName; UNICODE_STRING RealmName; LARGE_INTEGER StartTime; LARGE_INTEGER EndTime;
		// LARGE_INTEGER RenewTime; LONG EncryptionType; ULONG TicketFlags; } KERB_TICKET_CACHE_INFO, *PKERB_TICKET_CACHE_INFO;
		[PInvokeData("ntsecapi.h", MSDNShortId = "e9ac70f0-65dc-4c5a-b41f-7c4659680333")]
		[StructLayout(LayoutKind.Sequential)]
		public struct KERB_TICKET_CACHE_INFO
		{
			/// <summary>
			/// A UNICODE_STRING that contains the name of the server the ticket applies to. This name is combined with the <c>RealmName</c>
			/// value to create the full name <c>ServerName</c>@ <c>RealmName</c>.
			/// </summary>
			public LSA_UNICODE_STRING ServerName;

			/// <summary>A UNICODE_STRING that contains the name of the realm the ticket applies to.</summary>
			public LSA_UNICODE_STRING RealmName;

			/// <summary>
			/// A FILETIME structure that contains the time at which the ticket becomes valid. If the <c>starttime</c> member of the ticket
			/// is not set, this value defaults to the time when the ticket was initially authenticated, <c>authtime</c>. The
			/// <c>starttime</c> member of a ticket is optional.
			/// </summary>
			public FILETIME StartTime;

			/// <summary>A FILETIME structure that contains the time when the ticket expires.</summary>
			public FILETIME EndTime;

			/// <summary>
			/// If KERB_TICKET_FLAGS_renewable is set in <c>TicketFlags</c>, this member is a FILETIME structure that contains the time
			/// beyond which the ticket cannot be renewed.
			/// </summary>
			public FILETIME RenewTime;

			/// <summary>The type of encryption used in the ticket.</summary>
			public KERB_ETYPE EncryptionType;

			/// <summary>
			/// <para>The ticket flags, as defined in Internet RFC 4120. These flags can be one or more of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>KERB_TICKET_FLAGS_forwardable 0x40000000</term>
			/// <term>
			/// The ticket-granting server can issue a new ticket-granting ticket with a different network address based on the presented ticket.
			/// </term>
			/// </item>
			/// <item>
			/// <term>KERB_TICKET_FLAGS_forwarded 0x20000000</term>
			/// <term>
			/// The ticket has either been forwarded or was issued based on authentication that involved a forwarded ticket-granting ticket.
			/// </term>
			/// </item>
			/// <item>
			/// <term>KERB_TICKET_FLAGS_hw_authent 0x00100000</term>
			/// <term>
			/// The protocol employed for initial authentication required the use of hardware expected to be possessed solely by the named
			/// client. The hardware authentication method is selected by the KDC and the strength of the method is not indicated.
			/// </term>
			/// </item>
			/// <item>
			/// <term>KERB_TICKET_FLAGS_initial 0x00400000</term>
			/// <term>The ticket was issued by using the Authentication Service protocol instead of being based on a ticket-granting ticket.</term>
			/// </item>
			/// <item>
			/// <term>KERB_TICKET_FLAGS_invalid 0x01000000</term>
			/// <term>The ticket is not valid.</term>
			/// </item>
			/// <item>
			/// <term>KERB_TICKET_FLAGS_may_postdate 0x04000000</term>
			/// <term>Indicates to the ticket-granting server that a postdated ticket can be issued based on this ticket-granting ticket.</term>
			/// </item>
			/// <item>
			/// <term>KERB_TICKET_FLAGS_ok_as_delegate 0x00040000</term>
			/// <term>
			/// The target of the ticket is trusted by the directory service for delegation. Thus, clients may delegate their credentials to
			/// the server, which lets the server act as the client when talking to other services.
			/// </term>
			/// </item>
			/// <item>
			/// <term>KERB_TICKET_FLAGS_postdated 0x02000000</term>
			/// <term>
			/// The ticket has been postdated. The end-service can check the ticket's authtime member to see when the original
			/// authentication occurred.
			/// </term>
			/// </item>
			/// <item>
			/// <term>KERB_TICKET_FLAGS_pre_authent 0x00200000</term>
			/// <term>
			/// During initial authentication, the client was authenticated by the Key Distribution Center (KDC) before a ticket was issued.
			/// The strength of the preauthentication method is not indicated, but is acceptable to the KDC.
			/// </term>
			/// </item>
			/// <item>
			/// <term>KERB_TICKET_FLAGS_proxiable 0x10000000</term>
			/// <term>
			/// Indicates to the ticket-granting server that only nonticket-granting tickets can be issued based on this ticket but with a
			/// different network addresses.
			/// </term>
			/// </item>
			/// <item>
			/// <term>KERB_TICKET_FLAGS_proxy 0x08000000</term>
			/// <term>The ticket is a proxy.</term>
			/// </item>
			/// <item>
			/// <term>KERB_TICKET_FLAGS_renewable 0x00800000</term>
			/// <term>
			/// The ticket is renewable. If this flag is set, the time limit for renewing the ticket is set in RenewTime. A renewable ticket
			/// can be used to obtain a replacement ticket that expires at a later date.
			/// </term>
			/// </item>
			/// <item>
			/// <term>KERB_TICKET_FLAGS_reserved 0x80000000</term>
			/// <term>Reserved for future use. Do not set this flag.</term>
			/// </item>
			/// <item>
			/// <term>KERB_TICKET_FLAGS_reserved1 0x00000001</term>
			/// <term>Reserved.</term>
			/// </item>
			/// </list>
			/// </summary>
			public KERB_TICKET_FLAGS TicketFlags;
		}
		/// <summary>The <c>LSA_LAST_INTER_LOGON_INFO</c> structure contains information about a logon session.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ns-ntsecapi-_lsa_last_inter_logon_info typedef struct
		// _LSA_LAST_INTER_LOGON_INFO { LARGE_INTEGER LastSuccessfulLogon; LARGE_INTEGER LastFailedLogon; ULONG
		// FailedAttemptCountSinceLastSuccessfulLogon; } LSA_LAST_INTER_LOGON_INFO, *PLSA_LAST_INTER_LOGON_INFO;
		[PInvokeData("ntsecapi.h", MSDNShortId = "FB935FED-571F-4298-8F83-0F805408179D")]
		[StructLayout(LayoutKind.Sequential)]
		public struct LSA_LAST_INTER_LOGON_INFO
		{
			/// <summary>The time that the session owner most recently logged on successfully.</summary>
			public long LastSuccessfulLogon;

			/// <summary>The time of the most recent failed attempt to log on.</summary>
			public long LastFailedLogon;

			/// <summary>The number of failed attempts to log on since the last successful log on.</summary>
			public uint FailedAttemptCountSinceLastSuccessfulLogon;
		}

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

		/// <summary>
		/// <para>The <c>MSV1_0_INTERACTIVE_LOGON</c> structure contains information about an interactive logon.</para>
		/// <para>It is used by the LsaLogonUser function.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ns-ntsecapi-msv1_0_interactive_logon typedef struct
		// _MSV1_0_INTERACTIVE_LOGON { MSV1_0_LOGON_SUBMIT_TYPE MessageType; UNICODE_STRING LogonDomainName; UNICODE_STRING UserName;
		// UNICODE_STRING Password; } MSV1_0_INTERACTIVE_LOGON, *PMSV1_0_INTERACTIVE_LOGON;
		[PInvokeData("ntsecapi.h", MSDNShortId = "f9b9a966-54b9-4f89-98cc-d92e3f74571d")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MSV1_0_INTERACTIVE_LOGON
		{
			/// <summary>
			/// MSV1_0_LOGON_SUBMIT_TYPE value that specifies the type of logon being requested. This member must be set to <c>MsV1_0InteractiveLogon</c>.
			/// </summary>
			public MSV1_0_LOGON_SUBMIT_TYPE MessageType;

			/// <summary>
			/// <para>
			/// UNICODE_STRING that contains the name of the logon domain. The specified domain name must be a Windows domain or mixed domain
			/// that is trusted by this machine.
			/// </para>
			/// <para>
			/// The <c>Buffer</c> member of the UNICODE_STRING structure must point to memory that is contiguous to the
			/// <c>MSV1_0_INTERACTIVE_LOGON</c> structure.
			/// </para>
			/// </summary>
			public LSA_UNICODE_STRING LogonDomainName;

			/// <summary>
			/// <para>
			/// UNICODE_STRING that represents the user's account name. The name can be up to 255 bytes long. The name is treated as
			/// case-insensitive. The specified <c>UserName</c> must have an account in domain <c>LogonDomainName</c>.
			/// </para>
			/// <para>
			/// The <c>Buffer</c> member of the UNICODE_STRING structure must point to memory that is contiguous to the
			/// <c>MSV1_0_INTERACTIVE_LOGON</c> structure.
			/// </para>
			/// </summary>
			public LSA_UNICODE_STRING UserName;

			/// <summary>
			/// <para>
			/// UNICODE_STRING that contains the user's plaintext password. The password may be up to 255 bytes long and contain any Unicode
			/// value. When you have finished using the password, clear it from memory by calling the SecureZeroMemory function. For more
			/// information on protecting the password, see Handling Passwords.
			/// </para>
			/// <para>
			/// The <c>Buffer</c> member of the UNICODE_STRING structure must point to memory that is contiguous to the
			/// <c>MSV1_0_INTERACTIVE_LOGON</c> structure.
			/// </para>
			/// </summary>
			public LSA_UNICODE_STRING Password;
		}

		/// <summary>
		/// <para>The <c>SECURITY_LOGON_SESSION_DATA</c> structure contains information about a logon session.</para>
		/// <para>This structure is used by the LsaGetLogonSessionData function.</para>
		/// </summary>
		/// <remarks>
		/// This structure is allocated by the LSA. When the structure is no longer required, free it by using the LSAFreeReturnBuffer function.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ns-ntsecapi-_security_logon_session_data typedef struct
		// _SECURITY_LOGON_SESSION_DATA { ULONG Size; LUID LogonId; LSA_UNICODE_STRING UserName; LSA_UNICODE_STRING LogonDomain;
		// LSA_UNICODE_STRING AuthenticationPackage; ULONG LogonType; ULONG Session; PSID Sid; LARGE_INTEGER LogonTime; LSA_UNICODE_STRING
		// LogonServer; LSA_UNICODE_STRING DnsDomainName; LSA_UNICODE_STRING Upn; ULONG UserFlags; LSA_LAST_INTER_LOGON_INFO LastLogonInfo;
		// LSA_UNICODE_STRING LogonScript; LSA_UNICODE_STRING ProfilePath; LSA_UNICODE_STRING HomeDirectory; LSA_UNICODE_STRING
		// HomeDirectoryDrive; LARGE_INTEGER LogoffTime; LARGE_INTEGER KickOffTime; LARGE_INTEGER PasswordLastSet; LARGE_INTEGER
		// PasswordCanChange; LARGE_INTEGER PasswordMustChange; } SECURITY_LOGON_SESSION_DATA, *PSECURITY_LOGON_SESSION_DATA;
		[PInvokeData("ntsecapi.h", MSDNShortId = "284ddb9a-fd08-4f38-b1d0-242596c114a8")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SECURITY_LOGON_SESSION_DATA
		{
			/// <summary>The size of the structure, in bytes.</summary>
			public uint Size;

			/// <summary>A locally unique identifier (LUID) that identifies a logon session.</summary>
			public LUID LogonId;

			/// <summary>
			/// An LSA_UNICODE_STRING structure that contains the account name of the security principal that owns the logon session.
			/// </summary>
			public LSA_UNICODE_STRING UserName;

			/// <summary>
			/// An LSA_UNICODE_STRING structure that contains the name of the domain used to authenticate the owner of the logon session.
			/// </summary>
			public LSA_UNICODE_STRING LogonDomain;

			/// <summary>
			/// An LSA_UNICODE_STRING structure that contains the name of the authentication package used to authenticate the owner of the
			/// logon session.
			/// </summary>
			public LSA_UNICODE_STRING AuthenticationPackage;

			/// <summary>A SECURITY_LOGON_TYPE value that identifies the logon method.</summary>
			public SECURITY_LOGON_TYPE LogonType;

			/// <summary>A Terminal Services session identifier. This member may be zero.</summary>
			public uint Session;

			/// <summary>A pointer to the user's security identifier (SID).</summary>
			public PSID Sid;

			/// <summary>The time the session owner logged on.</summary>
			public long LogonTime;

			/// <summary>
			/// An LSA_UNICODE_STRING structure that contains the name of the server used to authenticate the owner of the logon session.
			/// </summary>
			public LSA_UNICODE_STRING LogonServer;

			/// <summary>An LSA_UNICODE_STRING structure that contains the DNS name for the owner of the logon session.</summary>
			public LSA_UNICODE_STRING DnsDomainName;

			/// <summary>An LSA_UNICODE_STRING structure that contains the user principal name (UPN) for the owner of the logon session.</summary>
			public LSA_UNICODE_STRING Upn;

			/// <summary>
			/// <para>The user flags for the logon session.</para>
			/// <para>
			/// <c>Windows Server 2003 R2, Windows XP with SP1 and earlier, Windows Server 2003 and Windows XP:</c> This member is not supported.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>LOGON_OPTIMIZED 0x4000</term>
			/// <term>The logon is an optimized logon session.</term>
			/// </item>
			/// <item>
			/// <term>LOGON_WINLOGON 0x8000</term>
			/// <term>The logon was created for Winlogon.</term>
			/// </item>
			/// <item>
			/// <term>LOGON_PKINIT 0x10000</term>
			/// <term>The Kerberos PKINIT extension was used to authenticate the user in this logon session.</term>
			/// </item>
			/// <item>
			/// <term>LOGON_NOT_OPTIMIZED 0x20000</term>
			/// <term>Optimized logon has been disabled for this account.</term>
			/// </item>
			/// </list>
			/// </summary>
			public LogonUserFlags UserFlags;

			/// <summary>
			/// <para>An LSA_LAST_INTER_LOGON_INFO structure that contains the information on the last logon session.</para>
			/// <para>
			/// <c>Windows Server 2003 R2, Windows XP with SP1 and earlier, Windows Server 2003 and Windows XP:</c> This member is not supported.
			/// </para>
			/// </summary>
			public LSA_LAST_INTER_LOGON_INFO LastLogonInfo;

			/// <summary>
			/// <para>An LSA_UNICODE_STRING structure that contains the script used for logging on.</para>
			/// <para>
			/// <c>Windows Server 2003 R2, Windows XP with SP1 and earlier, Windows Server 2003 and Windows XP:</c> This member is not supported.
			/// </para>
			/// </summary>
			public LSA_UNICODE_STRING LogonScript;

			/// <summary>
			/// <para>An LSA_UNICODE_STRING structure that contains the path to the user's profile.</para>
			/// <para>
			/// <c>Windows Server 2003 R2, Windows XP with SP1 and earlier, Windows Server 2003 and Windows XP:</c> This member is not supported.
			/// </para>
			/// </summary>
			public LSA_UNICODE_STRING ProfilePath;

			/// <summary>
			/// <para>An LSA_UNICODE_STRING structure that contains the home directory for the logon session.</para>
			/// <para>
			/// <c>Windows Server 2003 R2, Windows XP with SP1 and earlier, Windows Server 2003 and Windows XP:</c> This member is not supported.
			/// </para>
			/// </summary>
			public LSA_UNICODE_STRING HomeDirectory;

			/// <summary>
			/// <para>An LSA_UNICODE_STRING structure that contains the drive location of the home directory of the logon session.</para>
			/// <para>
			/// <c>Windows Server 2003 R2, Windows XP with SP1 and earlier, Windows Server 2003 and Windows XP:</c> This member is not supported.
			/// </para>
			/// </summary>
			public LSA_UNICODE_STRING HomeDirectoryDrive;

			/// <summary>
			/// <para>The time stamp of when the session user logged off.</para>
			/// <para>
			/// <c>Windows Server 2003 R2, Windows XP with SP1 and earlier, Windows Server 2003 and Windows XP:</c> This member is not supported.
			/// </para>
			/// </summary>
			public long LogoffTime;

			/// <summary>
			/// <para>The time that the logon session must end.</para>
			/// <para>
			/// <c>Windows Server 2003 R2, Windows XP with SP1 and earlier, Windows Server 2003 and Windows XP:</c> This member is not supported.
			/// </para>
			/// </summary>
			public long KickOffTime;

			/// <summary>
			/// <para>The time when the user last changed the password.</para>
			/// <para>
			/// <c>Windows Server 2003 R2, Windows XP with SP1 and earlier, Windows Server 2003 and Windows XP:</c> This member is not supported.
			/// </para>
			/// </summary>
			public long PasswordLastSet;

			/// <summary>
			/// <para>The password can be changed during the logon session.</para>
			/// <para>
			/// <c>Windows Server 2003 R2, Windows XP with SP1 and earlier, Windows Server 2003 and Windows XP:</c> This member is not supported.
			/// </para>
			/// </summary>
			public long PasswordCanChange;

			/// <summary>
			/// <para>The password must be changed during the logon session.</para>
			/// <para>
			/// <c>Windows Server 2003 R2, Windows XP with SP1 and earlier, Windows Server 2003 and Windows XP:</c> This member is not supported.
			/// </para>
			/// </summary>
			public long PasswordMustChange;
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