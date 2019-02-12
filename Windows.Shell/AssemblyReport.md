## Assembly report for Vanara.Windows.Shell.dll
### Classes
Class | Description
---- | ----
ComClassFactory | An implementation of `IClassFactory` to be used in conjunction with `IComObject` derivatives.
CommandVerb | Encapsulates a shortcut menu verb in the registry.
CommandVerbDictionary | A dictionary of Command Verbs defined in the Windows Registry.
ComObject | Base class for all COM objects which handles calling AddRef and Release for the assembly, connection to IClassFactory, implements IObjectWithSite, using an internal message loop, and a mechanism to issue a non-blocking call to itself. Once implemented, you only need to implement your own interfaces. The IClassFactory implementation can get any derived interfaces through casting for calls to its QueryInterface method. If you want more control, override the QueryInterface method in this class.
ControlPanel | Provides a means to open Control Panel items and get their paths.
IconLocation | Wraps the icon location string used by some Shell classes.
IndirectString | Wraps the icon location string used by some Shell classes.
MessageEventArgs | Holds a copy of the MSG instance retrieved by GetMessage.
MessageLoop | <para> This class encapsulates the management of a message loop for an application. It supports queuing a callback to the application via the message loop to enable the app to return from a call and continue processing that call later. This behavior is needed when implementing a shell verb as verbs must not block the caller. </para> <note type="note">The ComObject derived class should call QueueNonBlockingCallback in its invoke function, for example IExecuteCommand::Execute() or IDropTarget::Drop() passing a method that will complete the initialization work.</note>
ProgId | Represents a programmatic identifier in the registry for an application.
PropertyBag | Encapsulates an `IPropertyBag` instance.
PropertyDescription | Enumerate and retrieve individual property description details. Wraps the `IPropertyDescription` shell interface
PropertyDescriptionList | Exposes methods that extract information from a collection of property descriptions presented as a list.
PropertyStore | Encapsulates the IPropertyStore object.
PropertyType | Exposes methods that extract data from enumeration information.
PropertyTypeList | Exposes methods that enumerate the possible values for a property.
RegBasedSettings | Base class for registry based settings.
RegistryBasedVirtualDictionary<T> | A virtual dictionary that is based on values in the Windows Registry.
ShellAssociation | Represents a Shell file association defined in the Windows Registry. Wraps `IQueryAssociations`.
ShellCommand | Wraps the functionality of IInitializeCommand. When deriving, handling the `InitializeCommand` event is optional.
ShellDropTarget | COM object that implements IDropTarget. Solves race problem on drop and simplifies interface calls. All IDropTarget methods call their equivalent On[MethodName] equivalents. To specialize their handling, simply override the On[MethodName] method or hook an event to the corresponding event.
ShellExecuteCommand | Wraps the functionality of IExecuteCommand. To implement, derive from this class and override the `OnExecute` method. All Shell items passed to the command are available through the `SelectedItems` property.
ShellFileInfo | Information and icons for any shell file.
ShellFileNewOpEventArgs | Arguments supplied to the `PostNewItem` event.
ShellFileOperations | Queued and static file operations using the Shell.
ShellFileOpEventArgs | Arguments supplied to events from `ShellFileOperations`. Depending on the event, some properties may not be set.
ShellFolder | A folder or container of `ShellItem` instances.
ShellImageList | Represents the System Image List holding images for all shell icons.
ShellItem | Encapsulates an item in the Windows Shell.
ShellItemArray | A folder or container of `ShellItem` instances.
ShellItemChangeEventArgs | Provides data for `ShellItemChangeWatcher` events.
ShellItemChangeWatcher | Listens to the shell item change notifications and raises events when a folder, or item in a folder, changes.
ShellItemPropertyStore | A property store for a `ShellItem`.
ShellItemPropertyUpdates | A dictionary of properties that can be used to set or update property values on Shell items via the `ShellFileOperations.QueueApplyPropertiesOperation(Vanara.Windows.Shell.ShellItem,Vanara.Windows.Shell.ShellItemPropertyUpdates)` method. This class wraps the `IPropertyChangeArray` COM interface.
ShellLibrary | Shell library encapsulation.
ShellLibraryFolders | Folders of a `ShellLibrary`.
ShellLink | Represents a Shell Shortcut (.lnk) file.
ShellRegistrar | Contains static methods used to register and unregister shell items in the Windows Registry.
TaskbarList | Methods that control the Windows taskbar. It allows you to dynamically add, remove, and activate items on the taskbar. This wraps all of the ITaskbarListX interfaces.
### Enumerations
Enum | Description | Values
---- | ---- | ----
ChangeFilters | Changes that might occur to a shell item or folder. | ItemRenamed, ItemCreated, ItemDeleted, FolderCreated, FolderDeleted, MediaInserted, MediaRemoved, DriveRemoved, DriveAdded, FolderShared, FolderUnshared, Attributes, FolderUpdated, ItemUpdated, ServerDisconnected, SystemImageUpdated, DriveAddedInteractive, FolderRenamed, AllDiskEvents, DriveFreeSpaceChanged, FileAssociationChanged, AllGlobalEvents, AllEvents
ExecutableType | Specifies the executable file type. | Nonexecutable, DOS, Win32Console, Windows
FolderItemFilter | A filter for the types of children to enumerate. | Folders, NonFolders, IncludeHidden, Printers, Shareable, Storage, FastItems, FlatList, IncludeSuperHidden
LibraryFolderFilter | Defines options for filtering folder items. | FileSystemOnly, StorageObjects, AllItems
LibraryViewTemplate | Defines the type of view assigned to a library folder. | Documents, General, Music, Pictures, Videos, Custom
LinkResolution | Flags determining how the links with missing targets are resolved. | None, NoUI, AnyMatch, Update, NoUpdate, NoSearch, NoTrack, NoLinkInfo, InvokeMSI, NoUIWithMsgPump, OfferDeleteWithoutFile, KnownFolder, MachineInLocalTarget, UpdateMachineAndSid, NoObjectID
OperationFlags | Flags that control the file operation. | MultiDestFiles, Silent, RenameOnCollision, NoConfirmation, WantMappingHandle, AllowUndo, FilesOnly, SimpleProgress, NoConfirmMkDir, NoErrorUI, NoCopySecurityAttribs, NoRecursion, NoConnectedElements, WantNukeWarning, NoSkipJunctions, PreferHardLink, ShowElevationPrompt, EarlyFailure, PreserveFileExtensions, KeepNewerFile, NoCopyHooks, NoMinimizeBox, MoveACLsAcrossVolumes, DontDisplaySourcePath, DontDisplayDestPath, RequireElevation, AddUndoRecord, CopyAsDownload, DontDisplayLocations
ShellIconType | The type of icon to be returned from `ShellFileInfo.GetIcon(Vanara.Windows.Shell.ShellIconType)`. | Large, Small, Open, ShellDefinedSize, LinkOverlay, Selected
ShellImageSize | Used to determine the size of the icon returned by `ShellImageList.GetSystemIcon(System.String,Vanara.Windows.Shell.ShellImageSize)`. | Large, Small, ExtraLarge, Jumbo
ShellItemAttribute | Attributes that can be retrieved on an item (file or folder) or set of items using `Attributes`. | CanCopy, CanMove, CanLink, Storage, CanRename, CanDelete, HasPropSheet, DropTarget, CapabilityMask, System, Encrypted, IsSlow, Ghosted, Link, Share, ReadOnly, Hidden, DisplayAttrMask, NonEnumerated, NewContent, CanMoniker, HasStorage, Stream, StorageAncestor, Validate, Removable, Compressed, Browsable, FileSysAncestor, Folder, FileSystem, StorageCapMask, HasSubfolder, ContentsMask, PKEYMask
ShellItemComparison | Used to determine how to compare two Shell items. ShellItem.Compare uses this enumerated type. | Display, Canonical, SecondaryFileSystemPath, AllFields
ShellItemDisplayString | Requests the form of an item's display name to retrieve through `ShellItem.GetDisplayName(Vanara.Windows.Shell.ShellItemDisplayString)`. | NormalDisplay, ParentRelativeParsing, DesktopAbsoluteParsing, ParentRelativeEditing, DesktopAbsoluteEditing, FileSysPath, Url, ParentRelativeForAddressBar, ParentRelative, ParentRelativeForUI
ShellItemGetImageOptions | Options for retrieving images from a `ShellItem`. | ResizeToFit, BiggerSizeOk, MemoryOnly, IconOnly, ThumbnailOnly, InCacheOnly, CropToSquare, WideThumbnails, IconBackground, ScaleUp
ShellItemToolTipOptions | Flags that direct the handling of the item from which you're retrieving the info tip text. | Default, Name, LinkNotTarget, LinkTarget, AllowDelay, SingleLine
TaskbarButtonProgressState | State of the progress shown on a taskbar button. | None, Indeterminate, Normal, Error, Paused
TransferFlags | Used by methods of the ITransferSource and ITransferDestination interfaces to control their file operations. | Normal, FailExist, RenameExist, OverwriteExist, AllowDecryption, NoSecurity, CopyCreationTime, CopyWriteTime, UseFullAccess, DeleteRecycleIfPossible, CopyHardLink, CopyLocalizedName, MoveAsCopyDelete, SuspendShellEvents
VerbMultiSelectModel |  | Unset, Player, Single, Document
VerbPosition |  | Unset, Top, Bottom
VerbSelectionModel |  | Item, BackgroundShortcutMenu
