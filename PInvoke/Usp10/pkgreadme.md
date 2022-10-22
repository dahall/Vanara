![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.Usp10 NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.Usp10?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows Usp10.dll.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.Usp10**

Functions | Enumerations | Structures
--- | --- | ---
ScriptApplyDigitSubstitution ScriptApplyLogicalWidth ScriptBreak ScriptCacheGetHeight ScriptCPtoX ScriptFreeCache ScriptGetCMap ScriptGetFontAlternateGlyphs ScriptGetFontFeatureTags ScriptGetFontLanguageTags ScriptGetFontProperties ScriptGetFontScriptTags ScriptGetGlyphABCWidth ScriptGetLogicalWidths ScriptGetProperties ScriptIsComplex ScriptItemize ScriptItemizeOpenType ScriptJustify ScriptLayout ScriptPlace ScriptPlaceOpenType ScriptPositionSingleGlyph ScriptRecordDigitSubstitution ScriptShape ScriptShapeOpenType ScriptString_pcOutChars ScriptString_pLogAttr ScriptString_pSize ScriptStringAnalyse ScriptStringCPtoX ScriptStringFree ScriptStringGetLogicalWidths ScriptStringGetOrder ScriptStringOut ScriptStringValidate ScriptStringXtoCP ScriptSubstituteSingleGlyph ScriptTextOut ScriptXtoCP  | SCRIPT_DIGITSUB SCRIPT_JUSTIFY SGCM SIC SSA                                     | GOFFSET OPENTYPE_FEATURE_RECORD OPENTYPE_TAG SCRIPT_ANALYSIS SCRIPT_CHARPROP SCRIPT_CONTROL SCRIPT_DIGITSUBSTITUTE SCRIPT_FONTPROPERTIES SCRIPT_GLYPHPROP SCRIPT_ITEM SCRIPT_LOGATTR SCRIPT_PROPERTIES SCRIPT_STATE SCRIPT_TABDEF SCRIPT_VISATTR TEXTRANGE_PROPERTIES SafeSCRIPT_CACHE                        
