![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.Security NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.Security?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

Classes for security related items derived from the Vanara PInvoke libraries. Includes extension methods for Active Directory and access control classes, methods for working with accounts, UAC, privileges, system access, impersonation and SIDs, and a full LSA wrapper.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.Security**

Classes | Enumerations
--- | ---
AccessControlHelper AccessExtension AccountPrivileges AccountUtils ActiveDirectoryExtension BadValueException CentralAccessPolicy CentralAccessPolicyEntry ClaimValue LogonRights PinnedAcl PinnedSecurityDescriptor PinnedSid PrivilegeAndAttributes PrivilegedCodeBlock PrivilegeExtension SystemAccountInfo SystemSecurity UAC WindowsImpersonatedIdentity WindowsLoggedInIdentity  | AccountLogonRights DesiredAccess SystemPrivilege                   
