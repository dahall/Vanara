![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.Imm32 NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.Imm32?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows Imm32.dll.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.Imm32**

Functions | Enumerations | Structures | Interfaces
--- | --- | --- | ---
ImmAssociateContext ImmAssociateContextEx ImmConfigureIME ImmCreateContext ImmDestroyContext ImmDisableIME ImmDisableLegacyIME ImmDisableTextFrameService ImmEnumInputContext ImmEnumRegisterWord ImmEscape ImmGetCandidateList ImmGetCandidateListCount ImmGetCandidateWindow ImmGetCompositionFont ImmGetCompositionString ImmGetCompositionWindow ImmGetContext ImmGetConversionList ImmGetConversionStatus ImmGetDefaultIMEWnd ImmGetDescription ImmGetGuideLine ImmGetIMEFileName ImmGetImeMenuItems ImmGetOpenStatus ImmGetProperty ImmGetRegisterWordStyle ImmGetStatusWindowPos ImmGetVirtualKey ImmInstallIME ImmIsIME ImmIsUIMessage ImmNotifyIME ImmRegisterWord ImmReleaseContext ImmSetCandidateWindow ImmSetCompositionFont ImmSetCompositionString ImmSetCompositionWindow ImmSetConversionStatus ImmSetHotKey ImmSetOpenStatus ImmSetStatusWindowPos ImmSimulateHotKey ImmUnregisterWord     | CHARINFO FEID IMEFAREASTINFO_TYPE IMEPADREQ IMEPN INFOMASK IPACFG IPACID IPAWS ATTR CFS CPS GCL GCS GGL GL_ID GL_LEVEL IACE IGIMIF IGIMII IGP IME_CAND IME_CMODE IME_CONFIG IME_ESC IME_HOTKEY IME_PROP IME_REGWORD_STYLE IME_SMODE IMEVER IMFS IMFT ISC NI SCS SCS_CAP SELECT_CAP UI_CAP FELANG_CLMN FELANG_CMODE FELANG_REQ IFED_POS IFED_REG IFED_SELECT IFED_TYPE IMEFMT IMEREG IMEREL IMEUCT  | APPLETIDLIST IMEAPPLETCFG IMEAPPLETUI IMECHARINFO IMECOMPOSITIONSTRINGINFO IMEFAREASTINFO IMEITEM IMEITEMCANDIDATE IMESTRINGCANDIDATE IMESTRINGCANDIDATEINFO IMESTRINGINFO CANDIDATELIST CANDIDATELIST_MGD COMPOSITIONFORM HIMC IMEMENUITEMINFO REGISTERWORD STYLEBUF CANDIDATEFORM IMECHARPOSITION RECONVERTSTRING IMEDLG IMEDP IMESHF IMEWRD MORRSLT POSTBL                        | IImePad IImePadApplet IImeSpecifyApplets IFECommon IFEDictionary IFELanguage IImePlugInDictDictionaryList                                           
