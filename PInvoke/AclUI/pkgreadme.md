﻿![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.AclUI NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.AclUI?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows AclUI.dll.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.AclUI**

Functions | Enumerations | Structures | Interfaces
--- | --- | --- | ---
CreateSecurityPage EditSecurity EditSecurityAdvanced      | PropertySheetCallbackMessage SECURITY_OBJECT_ID SI_OBJECT_INFO_Flags SI_PAGE_ACTIVATED SI_PAGE_TYPE    | EFFPERM_RESULT_LIST SECURITY_OBJECT SI_OBJECT_INFO SID_INFO SI_ACCESS SI_INHERIT_TYPE   | IEffectivePermission IEffectivePermission2 ISecurityInformation ISecurityInformation2 ISecurityInformation3 ISecurityInformation4 ISecurityObjectTypeInfo 
