![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.WinTrust NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.WinTrust?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml/badge.svg?branch=master)](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml)

PInvoke API (methods, structures and constants) imported from Windows WinTrust.dll.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [MyGet build](https://www.myget.org/feed/Packages/vanara).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.WinTrust**

Functions | Enumerations | Structures
--- | --- | ---
CryptCATAdminAcquireContext<br>CryptCATAdminAcquireContext2<br>CryptCATAdminAddCatalog<br>CryptCATAdminCalcHashFromFileHandle<br>CryptCATAdminCalcHashFromFileHandle2<br>CryptCATAdminEnumCatalogFromHash<br>CryptCATAdminReleaseCatalogContext<br>CryptCATAdminReleaseContext<br>CryptCATAdminRemoveCatalog<br>CryptCATAdminResolveCatalogPath<br>CryptCATCatalogInfoFromContext<br>CryptCATCDFClose<br>CryptCATCDFEnumCatAttributes<br>CryptCATCDFEnumMembersByCDFTagEx<br>CryptCATCDFOpen<br>CryptCATClose<br>CryptCATEnumerateAttr<br>CryptCATEnumerateCatAttr<br>CryptCATEnumerateMember<br>CryptCATGetAttrInfo<br>CryptCATGetMemberInfo<br>CryptCATHandleFromStore<br>CryptCATOpen<br>CryptCATPersistStore<br>CryptCATPutAttrInfo<br>CryptCATPutCatAttrInfo<br>CryptCATPutMemberInfo<br>CryptCATStoreFromHandle<br>IsCatalogFile<br>OpenPersonalTrustDBDialog<br>OpenPersonalTrustDBDialogEx<br>WintrustAddActionID<br>WintrustAddDefaultForUsage<br>WintrustGetDefaultForUsage<br>WintrustGetRegPolicyFlags<br>WintrustLoadFunctionPointers<br>WintrustRemoveActionID<br>WintrustSetDefaultIncludePEPageHashes<br>WintrustSetRegPolicyFlags<br>WinVerifyTrust<br>WinVerifyTrustEx<br>WTHelperCertCheckValidSignature<br>WTHelperCertFindIssuerCertificate<br>WTHelperCertIsSelfSigned<br>WTHelperGetFileHash<br>WTHelperGetProvCertFromChain<br>WTHelperGetProvPrivateDataFromChain<br>WTHelperGetProvSignerFromChain<br>WTHelperProvDataFromStateData<br> | CRYPTCAT_ATTR<br>CRYPTCAT_E<br>CRYPTCAT_OPEN<br>CRYPTCAT_VERSION<br>CCPI<br>CertConfidence<br>CPD<br>DWACTION<br>WIN_CERT_TYPE<br>WSS<br>WSS_SUPPORT<br>WT_TRUSTDBDIALOG<br>WTD_CHOICE<br>WTD_REVOKE<br>WTD_STATEACTION<br>WTD_TRUST<br>WTD_UI<br>WTD_UICONTEXT<br>WTPF<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br> | CATALOG_INFO<br>CRYPTCATATTRIBUTE<br>CRYPTCATCDF<br>CRYPTCATMEMBER<br>CRYPTCATSTORE<br>CONFIG_CI_PROV_INFO<br>CONFIG_CI_PROV_INFO_RESULT<br>DRIVER_VER_INFO<br>DRIVER_VER_MAJORMINOR<br>WTD_GENERIC_CHAIN_POLICY_CREATE_INFO<br>WTD_GENERIC_CHAIN_POLICY_DATA<br>WTD_GENERIC_CHAIN_POLICY_SIGNER_INFO<br>CRYPT_PROVIDER_CERT<br>CRYPT_PROVIDER_DATA<br>CRYPT_PROVIDER_DEFUSAGE<br>CRYPT_PROVIDER_FUNCTIONS<br>CRYPT_PROVIDER_PRIVDATA<br>CRYPT_PROVIDER_REGDEFUSAGE<br>CRYPT_PROVIDER_SGNR<br>CRYPT_PROVIDER_SIGSTATE<br>CRYPT_PROVUI_DATA<br>CRYPT_PROVUI_FUNCS<br>CRYPT_REGISTER_ACTIONID<br>CRYPT_TRUST_REG_ENTRY<br>SPC_INDIRECT_DATA_CONTENT<br>WIN_CERTIFICATE<br>WINTRUST_BLOB_INFO<br>WINTRUST_CATALOG_INFO<br>WINTRUST_CERT_INFO<br>WINTRUST_FILE_INFO<br>WINTRUST_SGNR_INFO<br>WINTRUST_SIGNATURE_SETTINGS<br>WINTRUST_DATA<br>HCATALOG<br>HCATINFO<br>HCATADMIN<br>HCRYPTMSG<br><br><br><br><br><br><br><br><br><br><br><br><br>
