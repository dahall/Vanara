![Vanara](https://github.com/dahall/Vanara/raw/master/docs/icons/VanaraHeading.png)
### Vanara.PInvoke.UserEnv NuGet Package
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.UserEnv?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from UserEnv.dll.

### What is Vanara?

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### Issues?

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### Included in Vanara.PInvoke.UserEnv

Functions | Enumerations | Structures
--- | --- | ---
CreateAppContainerProfile<br>CreateEnvironmentBlock<br>CreateProfile<br>DeleteAppContainerProfile<br>DeleteProfile<br>DeriveAppContainerSidFromAppContainerName<br>DestroyEnvironmentBlock<br>EnterCriticalPolicySection<br>ExpandEnvironmentStringsForUserA<br>ExpandEnvironmentStringsForUserW<br>FreeGPOList<br>GetAllUsersProfileDirectory<br>GetAppContainerFolderPath<br>GetAppContainerRegistryLocation<br>GetAppliedGPOList<br>GetDefaultUserProfileDirectory<br>GetGPOListA<br>GetGPOListW<br>GetProfilesDirectory<br>GetProfileType<br>GetUserProfileDirectoryA<br>GetUserProfileDirectoryW<br>LeaveCriticalPolicySection<br>LoadUserProfile<br>RefreshPolicy<br>RefreshPolicyEx<br>RegisterGPNotification<br>UnloadUserProfile<br>UnregisterGPNotification<br> | GPO_LINK<br>GPO_LIST_FLAG<br>ProfileInfoFlags<br>ProfileType<br>RefreshPolicyOption<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br> | GROUP_POLICY_OBJECT<br>PROFILEINFO<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>
