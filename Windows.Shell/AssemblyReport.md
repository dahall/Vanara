## Assembly report for Vanara.Windows.Shell.dll
### Classes
Class | Description
---- | ----
ControlPanel | Provides a means to open Control Panel items and get their paths.
IconLocation | Wraps the icon location string used by some Shell classes.
PropertyDescription | 
PropertyDescriptionList | Exposes methods that extract information from a collection of property descriptions presented as a list.
PropertyStore | Encapsulates the IPropertyStore object.
PropertyType | Exposes methods that extract data from enumeration information.
PropertyTypeList | Exposes methods that enumerate the possible values for a property.
ShellFileInfo | Information and icons for any shell file.
ShellFileNewOpEventArgs | Arguments supplied to the `PostNewItem` event.
ShellFileOperations | Queued and static file operations using the Shell.
ShellFileOpEventArgs | Arguments supplied to events from `ShellFileOperations`. Depending on the event, some properties may not be set.
ShellFolder | A folder or container of `ShellItem` instances.
ShellImageList | 
ShellItem | Encapsulates an item in the Windows Shell.
ShellItemArray | A folder or container of `ShellItem` instances.
ShellItemPropertyStore | A property store for a `ShellItem`.
ShellItemPropertyUpdates | A dictionary of properties that can be used to set or update property values on Shell items via the `ShellFileOperations.QueueApplyPropertiesOperation(Vanara.Windows.Shell.ShellItem,Vanara.Windows.Shell.ShellItemPropertyUpdates)` method. This class wraps the `IPropertyChangeArray` COM interface.
ShellLibrary | Shell library encapsulation.
ShellLibraryFolders | Folders of a `ShellLibrary`.
ShellLink | Represents a Shell Shortcut (.lnk) file.
TaskbarList | 
### Enumerations
Enum | Description | Values
---- | ---- | ----
ExecutableType | Specifies the executable file type. | Nonexecutable, DOS, Win32Console, Windows
FolderItemFilter | A filter for the types of children to enumerate. | Folders, NonFolders, IncludeHidden, Printers, Shareable, Storage, FastItems, FlatList, IncludeSuperHidden
LibraryFolderFilter | Defines options for filtering folder items. | FileSystemOnly, StorageObjects, AllItems
LibraryViewTemplate | Defines the type of view assigned to a library folder. | Documents, General, Music, Pictures, Videos, Custom
LinkResolution | Flags determining how the links with missing targets are resolved. | None, NoUI, AnyMatch, Update, NoUpdate, NoSearch, NoTrack, NoLinkInfo, InvokeMSI, NoUIWithMsgPump, OfferDeleteWithoutFile, KnownFolder, MachineInLocalTarget, UpdateMachineAndSid, NoObjectID
OperationFlags | Flags that control the file operation. | MultiDestFiles, Silent, RenameOnCollision, NoConfirmation, WantMappingHandle, AllowUndo, FilesOnly, SimpleProgress, NoConfirmMkDir, NoErrorUI, NoCopySecurityAttribs, NoRecursion, NoConnectedElements, WantNukeWarning, NoSkipJunctions, PreferHardLink, ShowElevationPrompt, EarlyFailure, PreserveFileExtensions, KeepNewerFile, NoCopyHooks, NoMinimizeBox, MoveACLsAcrossVolumes, DontDisplaySourcePath, DontDisplayDestPath, RequireElevation, AddUndoRecord, CopyAsDownload, DontDisplayLocations
ShellIconType | The type of icon to be returned from `ShellFileInfo.GetIcon(Vanara.Windows.Shell.ShellIconType)`. | Large, Small, Open, ShellDefinedSize, LinkOverlay, Selected
ShellItemAttribute | Attributes that can be retrieved on an item (file or folder) or set of items using `Attributes`. | CanCopy, CanMove, CanLink, Storage, CanRename, CanDelete, HasPropSheet, DropTarget, CapabilityMask, System, Encrypted, IsSlow, Ghosted, Link, Share, ReadOnly, Hidden, DisplayAttrMask, NonEnumerated, NewContent, CanMoniker, HasStorage, Stream, StorageAncestor, Validate, Removable, Compressed, Browsable, FileSysAncestor, Folder, FileSystem, StorageCapMask, HasSubfolder, ContentsMask, PKEYMask
ShellItemComparison | Used to determine how to compare two Shell items. ShellItem.Compare uses this enumerated type. | Display, Canonical, SecondaryFileSystemPath, AllFields
ShellItemDisplayString | Requests the form of an item's display name to retrieve through `ShellItem.GetDisplayName(Vanara.Windows.Shell.ShellItemDisplayString)`. | NormalDisplay, ParentRelativeParsing, DesktopAbsoluteParsing, ParentRelativeEditing, DesktopAbsoluteEditing, FileSysPath, Url, ParentRelativeForAddressBar, ParentRelative, ParentRelativeForUI
ShellItemGetImageOptions | Options for retrieving images from a `ShellItem`. | ResizeToFit, BiggerSizeOk, MemoryOnly, IconOnly, ThumbnailOnly, InCacheOnly, CropToSquare, WideThumbnails, IconBackground, ScaleUp
ShellItemToolTipOptions | Flags that direct the handling of the item from which you're retrieving the info tip text. | Default, Name, LinkNotTarget, LinkTarget, AllowDelay, SingleLine
TransferFlags | Used by methods of the ITransferSource and ITransferDestination interfaces to control their file operations. | Normal, FailExist, RenameExist, OverwriteExist, AllowDecryption, NoSecurity, CopyCreationTime, CopyWriteTime, UseFullAccess, DeleteRecycleIfPossible, CopyHardLink, CopyLocalizedName, MoveAsCopyDelete, SuspendShellEvents
