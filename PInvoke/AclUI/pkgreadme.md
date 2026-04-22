![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.AclUI NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.AclUI?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml/badge.svg?branch=master)](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml)

PInvoke API (methods, structures and constants) imported from Windows AclUI.dll.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [MyGet build](https://www.myget.org/feed/Packages/vanara).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.AclUI**

Functions | Enumerations | Structures | Interfaces
--- | --- | --- | ---
CreateSecurityPage<br>EditSecurity<br>EditSecurityAdvanced<br><br><br><br><br> | PropertySheetCallbackMessage<br>SECURITY_OBJECT_ID<br>SI_OBJECT_INFO_Flags<br>SI_PAGE_ACTIVATED<br>SI_PAGE_TYPE<br><br><br> | EFFPERM_RESULT_LIST<br>SECURITY_OBJECT<br>SI_OBJECT_INFO<br>SID_INFO<br>SID_INFO_LIST<br>SI_ACCESS<br>SI_INHERIT_TYPE<br> | IEffectivePermission<br>IEffectivePermission2<br>ISecurityInformation<br>ISecurityInformation2<br>ISecurityInformation3<br>ISecurityInformation4<br>ISecurityObjectTypeInfo<br>
