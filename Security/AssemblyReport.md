## Assembly report for Vanara.Security.dll
### Enumerations
Enum | Header | Description | Values
---- | ---- | ---- | ----
Vanara.Security.AccessControl.SystemSecurity.AccountLogonRights | | Account rights determine the type of logon that a user account can perform. An administrator assigns account rights to user and group accounts. Each user's account rights include those granted to the user and to the groups to which the user belongs. | InteractiveLogon, NetworkLogon, BatchLogon, ServiceLogon, DenyInteractiveLogon, DenyNetworkLogon, DenyBatchLogon, DenyServiceLogon, RemoteInteractiveLogon, DenyRemoteInteractiveLogon
Vanara.Security.AccessControl.SystemSecurity.DesiredAccess | | Access rights for a local security policy. | ViewLocalInformation, ViewAuditInformation, GetPrivateInformation, TrustAdmin, CreateAccount, CreateSecret, SetDefaultQuotaLimits, SetAuditRequirements, AuditLogAdmin, ServerAdmin, LookupNames, AllAccess
Vanara.Security.AccessControl.SystemPrivilege | | Privilege determining the type of system operations that can be performed. | InteractiveLogon, NetworkLogon, BatchLogon, ServiceLogon, DenyInteractiveLogon, DenyNetworkLogon, DenyBatchLogon, DenyServiceLogon, RemoteInteractiveLogon, DenyRemoteInteractiveLogon, AssignPrimaryToken, Audit, Backup, ChangeNotify, CreateGlobal, CreatePageFile, CreatePermanent, CreateSymbolicLink, CreateToken, Debug, DelegateSessionUserImpersonate, EnableDelegation, Impersonate, IncreaseBasePriority, IncreaseQuota, IncreaseWorkingSet, LoadDriver, LockMemory, MachineAccount, ManageVolume, ProfileSingleProcess, Relabel, RemoteShutdown, Restore, Security, Shutdown, SyncAgent, SystemEnvironment, SystemProfile, SystemTime, TakeOwnership, TrustedComputerBase, TimeZone, TrustedCredentialManagerAccess, Undock, UnsolicitedInput
### Classes
Class | Header | Description
---- | ---- | ----
Vanara.Security.AccessControl.AccessControlHelper | | Helper methods for working with Access Control structures.
Vanara.Extensions.AccessExtension | | Extension methods for native and .NET access control objects.
Vanara.Security.AccessControl.SystemSecurity.AccountPrivileges | | Allows for the privileges of a user to be retrieved, enumerated and set.
Vanara.Security.AccountUtils | | Helper methods for working with `System.Security.Principal.WindowsIdentity` and user names.
Vanara.Extensions.ActiveDirectoryExtension | | 
Microsoft.Samples.DynamicAccessControl.BadValueException | | Exception raised when value(s) of a claim value type is invalid.
Microsoft.Samples.DynamicAccessControl.ClaimValue | | Class to represent the type of claims values held, the value(s) and obtain native (unmanaged) pointers to the value as they are stored in the union members of AUTHZ_SECURITY_ATTRIBUTE_V1 structure's 'Values' field.
Vanara.Security.AccessControl.SystemSecurity.LogonRights | | Allows for the privileges of a user to be retrieved, enumerated and set.
Vanara.Security.AccessControl.PinnedAcl | | Enables access to managed `System.Security.AccessControl.RawAcl` as unmanaged `byte[]`.
Vanara.Security.AccessControl.PinnedSecurityDescriptor | | Enables access to managed `System.Security.AccessControl.ObjectSecurity` as unmanaged `byte[]`.
Vanara.Security.AccessControl.PinnedSid | | Enables access to managed `System.Security.Principal.SecurityIdentifier` as unmanaged `Vanara.Security.AccessControl.PinnedSid.PSID`.
Vanara.Security.AccessControl.PrivilegeAndAttributes | | Class to hold associated `Vanara.Security.AccessControl.SystemPrivilege` and `Vanara.PInvoke.AdvApi32.PrivilegeAttributes` pairs.
Vanara.Security.AccessControl.PrivilegedCodeBlock | | Elevate user privileges for a code block similar to a <c>lock</c> or <c>using</c> statement.
Vanara.Security.AccessControl.PrivilegeExtension | | Extension methods for `Vanara.PInvoke.AdvApi32.SafeHTOKEN` for working with privileges.
Vanara.Security.AccessControl.SystemSecurity.SystemAccountInfo | | Contains a corresponding result for each name provided to the `Vanara.Security.AccessControl.SystemSecurity.GetAccountInfo(System.Boolean,System.String[])` method.
Vanara.Security.AccessControl.SystemSecurity | | Provides access to the local security authority on a given server.
Vanara.Security.UAC | | Provides information about the state of User Access Control for the system.
Vanara.Security.Principal.WindowsImpersonatedIdentity | | Impersonation of a user. Allows to execute code under another user context. Please note that the account that instantiates this class needs to have the 'Act as part of operating system' privilege set.
Vanara.Security.Principal.WindowsLoggedInIdentity | | Impersonation of a user. Allows to execute code under another user context. Please note that the account that instantiates this class needs to have the 'Act as part of operating system' privilege set.
