![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.UIAutomation NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.UIAutomation?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml/badge.svg?branch=master)](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml)

PInvoke API (methods, structures and constants) imported from Windows UIAutomationCore.dll.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [MyGet build](https://www.myget.org/feed/Packages/vanara).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.UIAutomation**

Enumerations | Structures | Interfaces
--- | --- | ---
EVENTID METADATAID PATTERNID PROPERTYID TEXTATTRIBUTEID DockPosition ExpandCollapseState NavigateDirection ProviderOptions RowOrColumnMajor ScrollAmount StructureChangeType SupportedTextSelection SynchronizedInputType TextPatternRangeEndpoint TextUnit ToggleState UIAutomationType WindowInteractionState WindowVisualState ZoomUnit                                  | UiaPoint UiaRect UIAutomationEventInfo UIAutomationMethodInfo UIAutomationParameter UIAutomationPatternInfo UIAutomationPropertyInfo                                                | IAccessibleEx IAccessibleHostingElementProviders IAnnotationProvider ICustomNavigationProvider IDockProvider IDragProvider IDropTargetProvider IExpandCollapseProvider IGridItemProvider IGridProvider IInvokeProvider IItemContainerProvider ILegacyIAccessibleProvider IMultipleViewProvider IObjectModelProvider IProxyProviderWinEventHandler IProxyProviderWinEventSink IRangeValueProvider IRawElementProviderAdviseEvents IRawElementProviderFragment IRawElementProviderFragmentRoot IRawElementProviderHostingAccessibles IRawElementProviderHwndOverride IRawElementProviderSimple IRawElementProviderSimple2 IRawElementProviderSimple3 IRawElementProviderWindowlessSite IScrollItemProvider IScrollProvider ISelectionItemProvider ISelectionProvider ISelectionProvider2 ISpreadsheetItemProvider ISpreadsheetProvider IStylesProvider ISynchronizedInputProvider ITableItemProvider ITableProvider ITextChildProvider ITextEditProvider ITextProvider ITextProvider2 ITextRangeProvider ITextRangeProvider2 IToggleProvider ITransformProvider ITransformProvider2 IUIAutomationPatternHandler IUIAutomationPatternInstance IUIAutomationRegistrar IValueProvider IVirtualizedItemProvider IWindowProvider 
