![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.ActiveDS NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.ActiveDS?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows Active Directory Service Interfaces.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.ActiveDS**

Functions | Enumerations | Structures | Interfaces
--- | --- | --- | ---
ADsBuildEnumerator ADsBuildVarArrayInt ADsBuildVarArrayStr ADsEncodeBinaryData ADsEnumerateNext ADsFreeEnumerator ADsGetLastError ADsGetObject ADsOpenObject ADsSetLastError AllocADsMem AllocADsStr BinarySDToSecurityDescriptor FreeADsMem FreeADsStr ReallocADsMem ReallocADsStr SecurityDescriptorToBinarySD                                             | ADS_ACEFLAG ADS_ACETYPE ADS_ATTR ADS_AUTHENTICATION ADS_CHASE_REFERRALS ADS_DEREF ADS_DISPLAY ADS_ESCAPE_MODE ADS_EXT ADS_FLAGTYPE ADS_FORMAT ADS_GROUP_TYPE ADS_JOB_STATUS ADS_NAME_INITTYPE ADS_NAME_TYPE ADS_OPTION ADS_PASSWORD_ENCODING ADS_PATHTYPE ADS_PREFERENCES ADS_PRINT_QUEUE_STATUS ADS_PROPERTY_OPERATION ADS_RIGHTS ADS_SCOPE ADS_SD_CONTROL ADS_SD_FORMAT ADS_SD_REVISION ADS_SEARCHPREF ADS_SECURITY_INFO ADS_SERVICE_ERR ADS_SERVICE_START ADS_SERVICE_STATUS ADS_SERVICE_TYPE ADS_SETTYPE ADS_STATUS ADS_SYSTEMFLAG ADS_USER_FLAG ADSI_DIALECT ADSTYPE PASSWORD_ATTR                        | ADS_SEARCH_HANDLE ADS_ATTR_DEF ADS_ATTR_INFO ADS_BACKLINK ADS_CASEIGNORE_LIST ADS_CLASS_DEF ADS_DN_WITH_BINARY ADS_DN_WITH_STRING ADS_EMAIL ADS_FAXNUMBER ADS_HOLD ADS_NETADDRESS ADS_NT_SECURITY_DESCRIPTOR ADS_OBJECT_INFO ADS_OCTET_LIST ADS_OCTET_STRING ADS_PATH ADS_POSTALADDRESS ADS_PROV_SPECIFIC ADS_REPLICAPOINTER ADS_SEARCH_COLUMN ADS_SEARCHPREF_INFO ADS_SORTKEY ADS_TIMESTAMP ADS_TYPEDNAME ADSVALUE ADS_VLV                                    | IADs IADsAccessControlEntry IADsAccessControlList IADsAcl IADsADSystemInfo IADsBackLink IADsCaseIgnoreList IADsClass IADsCollection IADsComputer IADsComputerOperations IADsContainer IADsDeleteOps IADsDNWithBinary IADsDNWithString IADsDomain IADsEmail IADsExtension IADsFaxNumber IADsFileService IADsFileServiceOperations IADsFileShare IADsGroup IADsHold IADsLargeInteger IADsLocality IADsMembers IADsNamespaces IADsNameTranslate IADsNetAddress IADsO IADsObjectOptions IADsOctetList IADsOpenDSObject IADsOU IADsPath IADsPathname IADsPostalAddress IADsPrintJob IADsPrintJobOperations IADsPrintQueue IADsPrintQueueOperations IADsProperty IADsPropertyEntry IADsPropertyList IADsPropertyValue IADsPropertyValue2 IADsReplicaPointer IADsResource IADsSecurityDescriptor IADsSecurityUtility IADsService IADsServiceOperations IADsSession IADsSyntax IADsTimestamp IADsTypedName IADsUser IADsWinNTSystemInfo IDirectoryObject IDirectorySearch 
