![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.WscApi NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.WscApi?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml/badge.svg?branch=master)](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml)

PInvoke API (methods, structures and constants) imported from Windows Security Center (WscApi.dll).

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [MyGet build](https://www.myget.org/feed/Packages/vanara).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.WscApi**

Functions | Enumerations | Interfaces
--- | --- | ---
WscGetSecurityProviderHealth<br>WscRegisterForChanges<br>WscUnRegisterChanges<br><br><br><br> | SECURITY_PRODUCT_TYPE<br>WSC_SECURITY_PRODUCT_STATE<br>WSC_SECURITY_PRODUCT_SUBSTATUS<br>WSC_SECURITY_SIGNATURE_STATUS<br>WSC_SECURITY_PROVIDER<br>WSC_SECURITY_PROVIDER_HEALTH<br> | IWSCDefaultProduct<br>IWscProduct<br>IWscProduct2<br>IWscProduct3<br>IWscProductList<br><br>
