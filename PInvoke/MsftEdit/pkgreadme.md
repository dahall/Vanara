![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.MsftEdit NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.MsftEdit?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows MsftEdit.dll for the Rich Edit control.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.MsftEdit**

Functions | Enumerations | Structures | Interfaces
--- | --- | --- | ---
CreateTextServices GetMathAlphanumeric GetMathAlphanumericCode MathBuildDown MathBuildUp MathTranslate REExtendedRegisterClass ShutdownTextServices                                                | AURL BOE BOM CFE CFM CFU CTFMODEBIAS ECN ECO ECOOP ELLIPSIS ENM EPR GCMF GT GTL ICM ICT IMF IMF_SMODE KHYPH OLEOP PFA PFE PFM PFN PFNS PUNC RichEditMessage RichEditNotification RichEditStyle RTO SCF SEL SES SES_EX SF ST TEXTMODE TO UNDONAMEID WBF RECO REO REO_GETOBJ CN TXES TXTBACKSTYLE TXTBIT TXTNATURALSIZE TXTVIEW MANCODE OBJECTTYPE tomConstants  | BIDIOPTIONS CHARFORMAT CHARFORMAT2 CHARRANGE CLIPBOARDFORMAT COMPCOLOR EDITSTREAM ENCORRECTTEXT ENDCOMPOSITIONNOTIFY ENDROPFILES ENLINK ENLOWFIRTF ENOLEOPFAILED ENPROTECTED ENSAVECLIPBOARD FINDTEXT FINDTEXTEX FORMATRANGE GETCONTEXTMENUEX GETTEXTEX GETTEXTLENGTHEX HYPHENATEINFO HYPHRESULT IMECOMPTEXT MSGFILTER OBJECTPOSITIONS PARAFORMAT PARAFORMAT2 PUNCTUATION REPASTESPECIAL REQRESIZE RICHEDIT_IMAGE_PARAMETERS SELCHANGE SETTEXTEX TABLECELLPARMS TABLEROWPARMS TEXTRANGE REOBJECT CHANGENOTIFY                 | IRichEditOle IRichEditOleCallback IRicheditUiaOverrides IRicheditWindowlessAccessibility ITextDisplays ITextDocument ITextDocument2 ITextFont ITextFont2 ITextPara ITextPara2 ITextRange ITextRange2 ITextRow ITextSelection ITextSelection2 ITextStory ITextStoryRanges ITextStoryRanges2 ITextStrings                                   
