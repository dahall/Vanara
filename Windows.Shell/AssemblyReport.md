## Assembly report for Vanara.Windows.Shell.dll
### Classes
Class | Description
---- | ----
IconLocation | Wraps the icon location string used by some Shell classes.
PropertyType | Exposes methods that extract data from enumeration information.
PropertyTypeList | Exposes methods that enumerate the possible values for a property.
ShellFileInfo | Information and icons for any shell file.
### Enumerations
Enum | Description | Values
---- | ---- | ----
ExecutableType | Specifies the executable file type. | Nonexecutable, DOS, Win32Console, Windows
FolderItemFilter | A filter for the types of children to enumerate. | Folders, NonFolders, IncludeHidden, Printers, Shareable, Storage, FastItems, FlatList, IncludeSuperHidden
LibraryFolderFilter | Defines options for filtering folder items. | FileSystemOnly, StorageObjects, AllItems
LibraryViewTemplate | Defines the type of view assigned to a library folder. | Documents, General, Music, Pictures, Videos, Custom
LinkResolution | Flags determining how the links with missing targets are resolved. | None, NoUI, AnyMatch, Update, NoUpdate, NoSearch, NoTrack, NoLinkInfo, InvokeMSI, NoUIWithMsgPump, OfferDeleteWithoutFile, KnownFolder, MachineInLocalTarget, UpdateMachineAndSid, NoObjectID
ShellIconType | The type of icon to be returned from `ShellFileInfo.GetIcon(Vanara.Windows.Shell.ShellIconType)`. | Large, Small, Open, ShellDefinedSize, LinkOverlay, Selected
ShellItemAttribute | Attributes that can be retrieved on an item (file or folder) or set of items using `Attributes`. | CanCopy, CanMove, CanLink, Storage, CanRename, CanDelete, HasPropSheet, DropTarget, CapabilityMask, System, Encrypted, IsSlow, Ghosted, Link, Share, ReadOnly, Hidden, DisplayAttrMask, NonEnumerated, NewContent, CanMoniker, HasStorage, Stream, StorageAncestor, Validate, Removable, Compressed, Browsable, FileSysAncestor, Folder, FileSystem, StorageCapMask, HasSubfolder, ContentsMask, PKEYMask
ShellItemComparison | Used to determine how to compare two Shell items. ShellItem.Compare uses this enumerated type. | Display, Canonical, SecondaryFileSystemPath, AllFields
ShellItemDisplayString | Requests the form of an item's display name to retrieve through `ShellItem.GetDisplayName(Vanara.Windows.Shell.ShellItemDisplayString)`. | NormalDisplay, ParentRelativeParsing, DesktopAbsoluteParsing, ParentRelativeEditing, DesktopAbsoluteEditing, FileSysPath, Url, ParentRelativeForAddressBar, ParentRelative, ParentRelativeForUI
ShellItemGetImageOptions | Options for retrieving images from a `ShellItem`. | ResizeToFit, BiggerSizeOk, MemoryOnly, IconOnly, ThumbnailOnly, InCacheOnly, CropToSquare, WideThumbnails, IconBackground, ScaleUp
ShellItemToolTipOptions | Flags that direct the handling of the item from which you're retrieving the info tip text. | Default, Name, LinkNotTarget, LinkTarget, AllowDelay, SingleLine
