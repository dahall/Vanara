![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.DirectoryServices NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.DirectoryServices?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

Wrapper classes around Win32 ADs methods and interfaces to provide simplified and object-oriented access to Active Directory and other directory service calls.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.DirectoryServices**

Classes | Interfaces
--- | ---
ADsBaseObject ADsCollection ADsComputer ADsComputerOperations ADsContainer ADsDomain ADsFileService ADsFileServiceOperations ADsFileShare ADsGroup ADsMembership ADsObject ADsPrintJob ADsPrintJobOperations ADsPrintQueue ADsPrintQueueOperations ADsPropertyCache ADsResource ADsSchemaClass ADsSchemaProperty ADsSchemaPropertySyntax ADsService ADsServiceOperations ADsSession ADsUser DirectoryObject DirectorySearch SearchResult SearchRow  | IADsContainerObject IADsObject                            
