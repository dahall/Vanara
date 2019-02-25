## Assembly report for Vanara.Security.dll
### Classes
Class | Description
---- | ----
AccessControlHelper | Helper methods for working with Access Control structures.
AccessExtension | Extension methods for native and .NET access control objects.
AccountPrivileges | Allows for the privileges of a user to be retrieved, enumerated and set.
AccountUtils | Helper methods for working with `WindowsIdentity` and user names.
ActiveDirectoryExtension | 
BadValueException | Exception raised when value(s) of a claim value type is invalid.
ClaimValue | Class to represent the type of claims values held, the value(s) and obtain native (unmanaged) pointers to the value as they are stored in the union members of AUTHZ_SECURITY_ATTRIBUTE_V1 structure's 'Values' field.
LogonRights | Allows for the privileges of a user to be retrieved, enumerated and set.
PinnedAcl | Enables access to managed `RawAcl` as unmanaged <see cref="T:byte[]" />.
PinnedSecurityDescriptor | Enables access to managed `ObjectSecurity` as unmanaged <see cref="T:byte[]" />.
PinnedSid | Enables access to managed `SecurityIdentifier` as unmanaged `PSID`.
PrivilegeAndAttributes | Class to hold associated `SystemPrivilege` and `PrivilegeAttributes` pairs.
PrivilegedCodeBlock | Elevate user privileges for a code block similar to a <c>lock</c> or <c>using</c> statement.
PrivilegeExtension | Extension methods for `SafeHTOKEN` for working with privileges.
SystemAccountInfo | Contains a corresponding result for each name provided to the `SystemSecurity.GetAccountInfo(System.Boolean,System.String[])` method.
SystemSecurity | Provides access to the local security authority on a given server.
UAC | Provides information about the state of User Access Control for the system.
WindowsImpersonatedIdentity | Impersonation of a user. Allows to execute code under another user context. Please note that the account that instantiates this class needs to have the 'Act as part of operating system' privilege set.
### Enumerations
Enum | Description | Values
---- | ---- | ----
AccountLogonRights | Account rights determine the type of logon that a user account can perform. An administrator assigns account rights to user and group accounts. Each user's account rights include those granted to the user and to the groups to which the user belongs. | InteractiveLogon, NetworkLogon, BatchLogon, ServiceLogon, DenyInteractiveLogon, DenyNetworkLogon, DenyBatchLogon, DenyServiceLogon, RemoteInteractiveLogon, DenyRemoteInteractiveLogon
DesiredAccess | Access rights for a local security policy. | ViewLocalInformation, ViewAuditInformation, GetPrivateInformation, TrustAdmin, CreateAccount, CreateSecret, SetDefaultQuotaLimits, SetAuditRequirements, AuditLogAdmin, ServerAdmin, LookupNames, AllAccess
SystemPrivilege | Privilege determining the type of system operations that can be performed. | InteractiveLogon, NetworkLogon, BatchLogon, ServiceLogon, DenyInteractiveLogon, DenyNetworkLogon, DenyBatchLogon, DenyServiceLogon, RemoteInteractiveLogon, DenyRemoteInteractiveLogon, AssignPrimaryToken, Audit, Backup, ChangeNotify, CreateGlobal, CreatePageFile, CreatePermanent, CreateSymbolicLink, CreateToken, Debug, DelegateSessionUserImpersonate, EnableDelegation, Impersonate, IncreaseBasePriority, IncreaseQuota, IncreaseWorkingSet, LoadDriver, LockMemory, MachineAccount, ManageVolume, ProfileSingleProcess, Relabel, RemoteShutdown, Restore, Security, Shutdown, SyncAgent, SystemEnvironment, SystemProfile, SystemTime, TakeOwnership, TrustedComputerBase, TimeZone, TrustedCredentialManagerAccess, Undock, UnsolicitedInput
