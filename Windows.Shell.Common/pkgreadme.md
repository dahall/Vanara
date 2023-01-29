![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.Windows.Shell.Common NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.Windows.Shell.Common?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

Common classes for Windows Shell items derived from the Vanara PInvoke libraries. Includes shell items, files, icons, links, and taskbar lists.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.Windows.Shell.Common**

Classes | Enumerations | Interfaces
--- | --- | ---
AddExtenderEventArgs AppRegistration AppSettingsFileListStorage BindContext ComClassFactory CommandVerb CommandVerbDictionary ComObject ComObjWrapper ControlPanel DragEventArgs ExtenderProviderBase FileInUseHandler FileTypeAssociation IconLocation JumpList JumpListDestination JumpListItem JumpListSeparator JumpListTask MemoryPropertyStore MenuItemInfo MessageEventArgs MessageLoop MRUManager NativeClipboard ProgId PropertyBag PropertyDescription PropertyDescriptionList PropertyStore PropertyType PropertyTypeList ReadOnlyPropertyStore RecycleBin RegBasedDictionary RegBasedSettings RegistryFileListStorage SearchCondition ShellAssociation ShellAssociationHandler ShellCommand ShellContextMenu ShellDataTable ShellDropTarget ShellExecuteCommand ShellFileInfo ShellFileNewOpEventArgs ShellFileOperationDialog ShellFileOperations ShellFileOpEventArgs ShellFolder ShellFolderCategorizer ShellFolderCategory ShellImageList ShellItem ShellItemArray ShellItemChangeEventArgs ShellItemChangeWatcher ShellItemImages ShellItemPropertyStore ShellItemPropertyUpdates ShellLibrary ShellLibraryFolders ShellLink ShellNavigationHistory ShellRegistrar ShellSearch ShellSearchViewSettings StockIcon Taskbar TaskbarList TrayIcon Utils WallpaperManager WallpaperMonitor WallpaperSlideshow  | ChangeFilters DialogStatus ExecutableType FileUsageType FolderItemFilter LibraryFolderFilter LibraryViewTemplate LinkResolution MenuPlacement OperationFlags OperationMode OperationType ShellIconType ShellImageSize ShellItemAttribute ShellItemComparison ShellItemDisplayString ShellItemGetImageOptions ShellItemToolTipOptions TaskbarButtonProgressState TransferFlags VerbMultiSelectModel VerbPosition VerbSelectionModel WallpaperFit                                                      | IComObject IFileListStorage IJumpListItem IMenuBuilder                                                                          
