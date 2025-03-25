![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.Dcomp NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.Dcomp?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows Dcomp.dll (DirectComposition).

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.Dcomp**

Functions | Enumerations | Structures | Interfaces
--- | --- | --- | ---
CreatePresentationFactory DCompositionAttachMouseDragToHwnd DCompositionAttachMouseWheelToHwnd DCompositionBoostCompositorClock DCompositionCreateDevice DCompositionCreateDevice2 DCompositionCreateDevice3 DCompositionCreateSurfaceHandle DCompositionGetFrameId DCompositionGetStatistics DCompositionGetTargetStatistics DCompositionWaitForCompositorClock DllGetActivationFactory DwmEnableMMCSS DwmFlush DwmpEnableDDASupport                                 | COMPOSITION_FRAME_ID_TYPE COMPOSITIONOBJECT_ACCESS DCOMPOSITION_BACKFACE_VISIBILITY DCOMPOSITION_BITMAP_INTERPOLATION_MODE DCOMPOSITION_BORDER_MODE DCOMPOSITION_COMPOSITE_MODE DCOMPOSITION_DEPTH_MODE DCOMPOSITION_OPACITY_MODE                                         | DCompositionInkTrailPoint COMPOSITION_FRAME_STATS COMPOSITION_STATS COMPOSITION_TARGET_ID COMPOSITION_TARGET_STATS DCOMPOSITION_FRAME_STATISTICS                                           | IDCompositionDevice IDCompositionTarget IDCompositionVisual IDCompositionEffect IDCompositionTransform3D IDCompositionTransform IDCompositionTranslateTransform IDCompositionScaleTransform IDCompositionRotateTransform IDCompositionSkewTransform IDCompositionMatrixTransform IDCompositionEffectGroup IDCompositionTranslateTransform3D IDCompositionScaleTransform3D IDCompositionRotateTransform3D IDCompositionMatrixTransform3D IDCompositionClip IDCompositionRectangleClip IDCompositionSurface IDCompositionVirtualSurface IDCompositionDevice2 IDCompositionDesktopDevice IDCompositionDeviceDebug IDCompositionSurfaceFactory IDCompositionVisual2 IDCompositionVisualDebug IDCompositionVisual3 IDCompositionDevice3 IDCompositionFilterEffect IDCompositionGaussianBlurEffect IDCompositionBrightnessEffect IDCompositionColorMatrixEffect IDCompositionShadowEffect IDCompositionHueRotationEffect IDCompositionSaturationEffect IDCompositionTurbulenceEffect IDCompositionLinearTransferEffect IDCompositionTableTransferEffect IDCompositionCompositeEffect IDCompositionBlendEffect IDCompositionArithmeticCompositeEffect IDCompositionAffineTransform2DEffect IDCompositionDelegatedInkTrail IDCompositionInkTrailDevice IDCompositionTexture IDCompositionDevice4 IDCompositionAnimation 
