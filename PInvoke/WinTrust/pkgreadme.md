![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.WinTrust NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.WinTrust?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows WinTrust.dll.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.WinTrust**

Functions | Enumerations | Structures
--- | --- | ---
CryptCATAdminAcquireContext CryptCATAdminAcquireContext2 CryptCATAdminAddCatalog CryptCATAdminCalcHashFromFileHandle CryptCATAdminCalcHashFromFileHandle2 CryptCATAdminEnumCatalogFromHash CryptCATAdminReleaseCatalogContext CryptCATAdminReleaseContext CryptCATAdminRemoveCatalog CryptCATAdminResolveCatalogPath CryptCATCatalogInfoFromContext CryptCATCDFClose CryptCATCDFEnumCatAttributes CryptCATCDFOpen CryptCATClose CryptCATEnumerateAttr CryptCATEnumerateCatAttr CryptCATEnumerateMember CryptCATGetAttrInfo CryptCATGetMemberInfo CryptCATHandleFromStore CryptCATOpen CryptCATPersistStore CryptCATPutAttrInfo CryptCATPutCatAttrInfo CryptCATPutMemberInfo CryptCATStoreFromHandle CryptSIPAddProvider CryptSIPCreateIndirectData CryptSIPGetCaps CryptSIPGetSignedDataMsg CryptSIPLoad CryptSIPPutSignedDataMsg CryptSIPRemoveProvider CryptSIPRemoveSignedDataMsg CryptSIPRetrieveSubjectGuid CryptSIPRetrieveSubjectGuidForCatalogFile CryptSIPVerifyIndirectData IsCatalogFile OpenPersonalTrustDBDialog OpenPersonalTrustDBDialogEx WintrustAddActionID WintrustAddDefaultForUsage WintrustGetDefaultForUsage WintrustGetRegPolicyFlags WintrustLoadFunctionPointers WintrustRemoveActionID WintrustSetDefaultIncludePEPageHashes WintrustSetRegPolicyFlags WinVerifyTrust WinVerifyTrustEx WTHelperCertCheckValidSignature WTHelperCertFindIssuerCertificate WTHelperCertIsSelfSigned WTHelperGetFileHash WTHelperGetProvCertFromChain WTHelperGetProvPrivateDataFromChain WTHelperGetProvSignerFromChain WTHelperProvDataFromStateData  | CRYPTCAT_ATTR CRYPTCAT_E CRYPTCAT_OPEN CRYPTCAT_VERSION CertConfidence DWACTION WIN_CERT_TYPE WT_TRUSTDBDIALOG WTD_CHOICE WTD_REVOKE WTD_STATEACTION WTD_TRUST WTD_UI WTD_UICONTEXT WTPF                                              | CATALOG_INFO CRYPTCATATTRIBUTE CRYPTCATCDF CRYPTCATMEMBER CRYPTCATSTORE HCATALOG HCATINFO MS_ADDINFO_BLOB MS_ADDINFO_CATALOGMEMBER MS_ADDINFO_FLAT SIP_ADD_NEWPROVIDER SIP_CAP_SET_V2 SIP_CAP_SET_V3 SIP_DISPATCH_INFO SIP_INDIRECT_DATA SIP_SUBJECTINFO CRYPT_PROVIDER_CERT CRYPT_PROVIDER_DATA CRYPT_PROVIDER_DEFUSAGE CRYPT_PROVIDER_FUNCTIONS CRYPT_PROVIDER_PRIVDATA CRYPT_PROVIDER_REGDEFUSAGE CRYPT_PROVIDER_SGNR CRYPT_PROVIDER_SIGSTATE CRYPT_PROVUI_DATA CRYPT_PROVUI_FUNCS CRYPT_REGISTER_ACTIONID CRYPT_TRUST_REG_ENTRY HCATADMIN HCRYPTMSG SPC_INDIRECT_DATA_CONTENT WIN_CERTIFICATE WINTRUST_BLOB_INFO WINTRUST_CATALOG_INFO WINTRUST_CERT_INFO WINTRUST_FILE_INFO WINTRUST_SGNR_INFO WINTRUST_SIGNATURE_SETTINGS WINTRUST_DATA                     
