![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.UserEnv NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.UserEnv?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml/badge.svg?branch=master)](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml)

PInvoke API (methods, structures and constants) imported from UserEnv.dll.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [MyGet build](https://www.myget.org/feed/Packages/vanara).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.UserEnv**

Functions | Enumerations | Structures
--- | --- | ---
CreateAppContainerProfile CreateEnvironmentBlock CreateProfile DeleteAppContainerProfile DeleteProfile DeriveAppContainerSidFromAppContainerName DestroyEnvironmentBlock EnterCriticalPolicySection ExpandEnvironmentStringsForUserA ExpandEnvironmentStringsForUserW FreeGPOList GetAllUsersProfileDirectory GetAppContainerFolderPath GetAppContainerRegistryLocation GetAppliedGPOList GetDefaultUserProfileDirectory GetGPOListA GetGPOListW GetProfilesDirectory GetProfileType GetUserProfileDirectoryA GetUserProfileDirectoryW LeaveCriticalPolicySection LoadUserProfile RefreshPolicy RefreshPolicyEx RegisterGPNotification UnloadUserProfile UnregisterGPNotification  | GPO_LINK GPO_LIST_FLAG ProfileInfoFlags ProfileType RefreshPolicyOption                          | GROUP_POLICY_OBJECT PROFILEINFO                            
