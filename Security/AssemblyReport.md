## Assembly report for Vanara.Security.dll
### Classes
Class | Description
---- | ----
AccountPrivileges | Allows for the privileges of a user to be retrieved, enumerated and set.
BadValueException | Exception raised when value(s) of a claim value type is invalid.
LogonRights | Allows for the privileges of a user to be retrieved, enumerated and set.
PrivilegedCodeBlock | Elevate user privileges for a code block similar to a <c>lock</c> or <c>using</c> statement.
SystemSecurity | Provides access to the local security authority on a given server.
WindowsImpersonatedIdentity | Impersonation of a user. Allows to execute code under another user context. Please note that the account that instantiates this class needs to have the 'Act as part of operating system' privilege set.
### Enumerations
Enum | Description | Values
---- | ---- | ----
AccountLogonRights | Account rights determine the type of logon that a user account can perform. An administrator assigns account rights to user and group accounts. Each user's account rights include those granted to the user and to the groups to which the user belongs. | InteractiveLogon, NetworkLogon, BatchLogon, ServiceLogon, DenyInteractiveLogon, DenyNetworkLogon, DenyBatchLogon, DenyServiceLogon, RemoteInteractiveLogon, DenyRemoteInteractiveLogon
DesiredAccess | Access rights for a local security policy. | ViewLocalInformation, ViewAuditInformation, GetPrivateInformation, TrustAdmin, CreateAccount, CreateSecret, SetDefaultQuotaLimits, SetAuditRequirements, AuditLogAdmin, ServerAdmin, LookupNames, AllAccess
SystemPrivilege | Privilege determining the type of system operations that can be performed. | InteractiveLogon, NetworkLogon, BatchLogon, ServiceLogon, DenyInteractiveLogon, DenyNetworkLogon, DenyBatchLogon, DenyServiceLogon, RemoteInteractiveLogon, DenyRemoteInteractiveLogon, AssignPrimaryToken, Audit, Backup, ChangeNotify, CreateGlobal, CreatePageFile, CreatePermanent, CreateSymbolicLink, CreateToken, Debug, DelegateSessionUserImpersonate, EnableDelegation, Impersonate, IncreaseBasePriority, IncreaseQuota, IncreaseWorkingSet, LoadDriver, LockMemory, MachineAccount, ManageVolume, ProfileSingleProcess, Relabel, RemoteShutdown, Restore, Security, Shutdown, SyncAgent, SystemEnvironment, SystemProfile, SystemTime, TakeOwnership, TrustedComputerBase, TimeZone, TrustedCredentialManagerAccess, Undock, UnsolicitedInput
