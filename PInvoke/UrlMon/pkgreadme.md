![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.UrlMon NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.UrlMon?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml/badge.svg?branch=master)](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml)

PInvoke API (methods, structures and constants imported from UrlMon.dll.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [MyGet build](https://www.myget.org/feed/Packages/vanara).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.UrlMon**

Functions | Enumerations | Structures | Interfaces
--- | --- | --- | ---
AsyncInstallDistributionUnit CoGetClassObjectFromURL CoInternetCombineIUri CoInternetCombineUrl CoInternetCombineUrlEx CoInternetCompareUrl CoInternetGetSession CoInternetParseIUri CoInternetParseUrl CoInternetQueryInfo CompareSecurityIds CompatFlagsFromClsid CopyBindInfo CopyStgMedium CreateAsyncBindCtx CreateAsyncBindCtxEx CreateFormatEnumerator CreateIUriBuilder CreateUri CreateUriFromMultiByteString CreateUriWithFragment CreateURLMoniker CreateURLMonikerEx CreateURLMonikerEx2 FaultInIEFeature FindMediaType FindMediaTypeClass FindMimeFromData GetClassFileOrMime GetComponentIDFromCLSSPEC IEInstallScope IsAsyncMoniker IsValidURL MkParseDisplayNameEx ObtainUserAgentString RegisterBindStatusCallback RegisterFormatEnumerator RegisterMediaTypeClass RegisterMediaTypes ReleaseBindInfo RevokeBindStatusCallback RevokeFormatEnumerator URLDownloadToCacheFile URLDownloadToFile UrlMkGetSessionOption UrlMkSetSessionOption URLOpenBlockingStream URLOpenPullStream URLOpenStream  | BINDF BINDSTATUS BSCF COMPAT FIEF_FLAG FMFD MUTZ PARSEACTION PUAF QUERYOPTION SZM_FLAGS Uri_CREATE Uri_DISPLAY Uri_ENCODING Uri_HAS Uri_HOST_TYPE Uri_PROPERTY URL_MK URL_SCHEME URLPOLICY AUTHENTICATEF                              | BINDINFO AUTHENTICATEINFO                                                 | IAuthenticate IAuthenticateEx IBindHost IBinding IBindStatusCallback IInternetSecurityManager IInternetSecurityMgrSite IInternetSession IPersistMoniker IUri IUriBuilder                                       
