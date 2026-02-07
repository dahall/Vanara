![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.WcnApi NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.WcnApi?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml/badge.svg?branch=master)](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml)

PInvoke API (methods, structures and constants) imported from Windows Connect Now (WcnApi.dll).

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [MyGet build](https://www.myget.org/feed/Packages/vanara).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.WcnApi**

Enumerations | Structures | Interfaces
--- | --- | ---
WCN_FLAG WCN_PASSWORD_TYPE WCN_SESSION_STATUS WCN_ATTRIBUTE_TYPE WCN_VALUE_TYPE_ASSOCIATION_STATE WCN_VALUE_TYPE_AUTHENTICATION_TYPE WCN_VALUE_TYPE_BOOLEAN WCN_VALUE_TYPE_CONFIG_METHODS WCN_VALUE_TYPE_CONFIGURATION_ERROR WCN_VALUE_TYPE_CONNECTION_TYPE WCN_VALUE_TYPE_DEVICE_PASSWORD_ID WCN_VALUE_TYPE_DEVICE_TYPE_CATEGORY WCN_VALUE_TYPE_DEVICE_TYPE_SUBCATEGORY WCN_VALUE_TYPE_DEVICE_TYPE_SUBCATEGORY_OUI WCN_VALUE_TYPE_ENCRYPTION_TYPE WCN_VALUE_TYPE_MESSAGE_TYPE WCN_VALUE_TYPE_REQUEST_TYPE WCN_VALUE_TYPE_RESPONSE_TYPE WCN_VALUE_TYPE_RF_BANDS WCN_VALUE_TYPE_VERSION WCN_VALUE_TYPE_WI_FI_PROTECTED_SETUP_STATE  | WCN_VENDOR_EXTENSION_SPEC WCN_VALUE_TYPE_PRIMARY_DEVICE_TYPE                     | IWCNConnectNotify IWCNDevice                    
