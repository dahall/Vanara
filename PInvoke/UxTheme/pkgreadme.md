![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.UxTheme NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.UxTheme?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows UxTheme.dll.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.UxTheme**

Functions | Enumerations | Structures
--- | --- | ---
BeginBufferedAnimation BeginBufferedPaint BeginPanningFeedback BufferedPaintClear BufferedPaintInit BufferedPaintRenderAnimation BufferedPaintSetAlpha BufferedPaintStopAllAnimations BufferedPaintUnInit CloseThemeData DrawThemeBackground DrawThemeBackgroundEx DrawThemeEdge DrawThemeIcon DrawThemeParentBackground DrawThemeParentBackgroundEx DrawThemeText DrawThemeTextEx EnableThemeDialogTexture EnableTheming EndBufferedAnimation EndBufferedPaint EndPanningFeedback GetBufferedPaintBits GetBufferedPaintDC GetBufferedPaintTargetDC GetBufferedPaintTargetRect GetCurrentThemeName GetThemeAnimationProperty GetThemeAnimationTransform GetThemeAppProperties GetThemeBackgroundContentRect GetThemeBackgroundExtent GetThemeBackgroundRegion GetThemeBitmap GetThemeBool GetThemeColor GetThemeDocumentationProperty GetThemeEnumValue GetThemeFilename GetThemeFont GetThemeInt GetThemeIntList GetThemeMargins GetThemeMetric GetThemePartSize GetThemePosition GetThemePropertyOrigin GetThemeRect GetThemeStream GetThemeString GetThemeSysBool GetThemeSysColor GetThemeSysColorBrush GetThemeSysFont GetThemeSysInt GetThemeSysSize GetThemeSysString GetThemeTextExtent GetThemeTextMetrics GetThemeTimingFunction GetThemeTransitionDuration GetWindowTheme HitTestThemeBackground IsAppThemed IsCompositionActive IsThemeActive IsThemeBackgroundPartiallyTransparent IsThemeDialogTextureEnabled IsThemePartDefined OpenThemeData OpenThemeDataEx OpenThemeDataForDpi SetThemeAppProperties SetWindowTheme SetWindowThemeAttribute UpdatePanningFeedback  | DrawThemeBackgroundFlags DrawThemeParentBackgroundFlags DrawThemeTextOptionsMasks GBF HitTestOptions OpenThemeDataOptions PROPERTYORIGIN TA_PROPERTY TA_PROPERTY_FLAG TA_TIMINGFUNCTION_TYPE TA_TRANSFORM_FLAG TA_TRANSFORM_TYPE TextShadowType ThemeAppProperties ThemeDialogTextureFlags THEMESIZE WINDOWTHEMEATTRIBUTETYPE WTNCA BP_ANIMATIONSTYLE BP_BUFFERFORMAT BufferedPaintParamsFlags BGTYPE BORDERTYPE CONTENTALIGNMENT FILLTYPE GLYPHFONTSIZINGTYPE GLYPHTYPE HALIGN ICONEFFECT IMAGELAYOUT IMAGESELECTTYPE OFFSETTYPE SIZINGTYPE TEXTSHADOWTYPE ThemeProperty TRUESIZESCALINGTYPE VALIGN                                          | DTTOPTS INTLIST MARGINS TA_TIMINGFUNCTION TA_TRANSFORM WTA_OPTIONS DTBGOPTS BP_ANIMATIONPARAMS HANIMATIONBUFFER HPAINTBUFFER BP_PAINTPARAMS                                                                   
