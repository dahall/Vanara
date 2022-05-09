![Vanara](https://github.com/dahall/Vanara/raw/master/docs/icons/VanaraHeading.png)
### Vanara.PInvoke.CredUI NuGet Package
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.CredUI?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows CredUI.dll.

### What is Vanara?

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### Issues?

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### Included in Vanara.PInvoke.CredUI

Functions | Enumerations | Structures
--- | --- | ---
CredPackAuthenticationBuffer<br>CredUICmdLinePromptForCredentials<br>CredUIConfirmCredentials<br>CredUIParseUserName<br>CredUIPromptForCredentials<br>CredUIPromptForWindowsCredentials<br>CredUIReadSSOCred<br>CredUIStoreSSOCred<br>CredUnPackAuthenticationBuffer<br>SspiGetCredUIContext<br>SspiIsPromptingNeeded<br>SspiPromptForCredentials<br>SspiUnmarshalCredUIContext<br>SspiUpdateCredentials<br> | SSPIPFC<br>CredentialsDialogOptions<br>CredPackFlags<br>WindowsCredentialsDialogOptions<br><br><br><br><br><br><br><br><br><br><br> | PSEC_WINNT_CREDUI_CONTEXT<br>PSEC_WINNT_CREDUI_CONTEXT_VECTOR<br>CREDUI_INFO<br><br><br><br><br><br><br><br><br><br><br><br>
