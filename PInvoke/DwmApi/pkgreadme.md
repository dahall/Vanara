![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.DwmApi NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.DwmApi?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows DwmApi.dll.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.DwmApi**

Functions | Enumerations | Structures
--- | --- | ---
DwmDefWindowProc DwmEnableBlurBehindWindow DwmEnableComposition DwmEnableMMCSS DwmExtendFrameIntoClientArea DwmFlush DwmGetColorizationColor DwmGetCompositionTimingInfo DwmGetTransportAttributes DwmGetUnmetTabRequirements DwmGetWindowAttribute DwmInvalidateIconicBitmaps DwmIsCompositionEnabled DwmpGetColorizationParameters DwmpSetColorizationParameters DwmQueryThumbnailSourceSize DwmRegisterThumbnail DwmRenderGesture DwmSetIconicLivePreviewBitmap DwmSetIconicThumbnail DwmSetWindowAttribute DwmShowContact DwmTetherContact DwmTransitionOwnedWindow DwmUnregisterThumbnail DwmUpdateThumbnailProperties  | DWM_BLURBEHIND_Mask DWM_CLOAKED DWM_SETICONICPREVIEW_Flags DWM_SHOWCONTACT DWM_TAB_WINDOW_REQUIREMENTS DWM_TNP DWMFLIP3DWINDOWPOLICY DWMNCRENDERINGPOLICY DWMTRANSITION_OWNEDWINDOW_TARGET DWM_WINDOW_CORNER_PREFERENCE DWMWINDOWATTRIBUTE GESTURE_TYPE                | DWM_BLURBEHIND DWM_COLORIZATION_PARAMS DWM_THUMBNAIL_PROPERTIES DWM_TIMING_INFO MARGINS UNSIGNED_RATIO                     
