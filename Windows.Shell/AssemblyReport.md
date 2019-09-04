## Assembly report for Vanara.Windows.Shell.dll
### Enumerations
Enum | Header | Description | Values
---- | ---- | ---- | ----
Vanara.Windows.Shell.ChangeFilters | | Changes that might occur to a shell item or folder. | ItemRenamed, ItemCreated, ItemDeleted, FolderCreated, FolderDeleted, MediaInserted, MediaRemoved, DriveRemoved, DriveAdded, FolderShared, FolderUnshared, Attributes, FolderUpdated, ItemUpdated, ServerDisconnected, SystemImageUpdated, DriveAddedInteractive, FolderRenamed, AllDiskEvents, DriveFreeSpaceChanged, FileAssociationChanged, AllGlobalEvents, AllEvents
Vanara.Windows.Shell.ExecutableType | | Specifies the executable file type. | Nonexecutable, DOS, Win32Console, Windows
Vanara.Windows.Shell.FolderItemFilter | | A filter for the types of children to enumerate. | Folders, NonFolders, IncludeHidden, Printers, Shareable, Storage, FastItems, FlatList, IncludeSuperHidden
Vanara.Windows.Shell.LibraryFolderFilter | | Defines options for filtering folder items. | FileSystemOnly, StorageObjects, AllItems
Vanara.Windows.Shell.LibraryViewTemplate | | Defines the type of view assigned to a library folder. | Documents, General, Music, Pictures, Videos, Custom
Vanara.Windows.Shell.LinkResolution | | Flags determining how the links with missing targets are resolved. | None, NoUI, AnyMatch, Update, NoUpdate, NoSearch, NoTrack, NoLinkInfo, InvokeMSI, NoUIWithMsgPump, OfferDeleteWithoutFile, KnownFolder, MachineInLocalTarget, UpdateMachineAndSid, NoObjectID
Vanara.Windows.Shell.ShellFileOperations.OperationFlags | | Flags that control the file operation. | MultiDestFiles, Silent, RenameOnCollision, NoConfirmation, WantMappingHandle, AllowUndo, FilesOnly, SimpleProgress, NoConfirmMkDir, NoErrorUI, NoCopySecurityAttribs, NoRecursion, NoConnectedElements, WantNukeWarning, NoSkipJunctions, PreferHardLink, ShowElevationPrompt, EarlyFailure, PreserveFileExtensions, KeepNewerFile, NoCopyHooks, NoMinimizeBox, MoveACLsAcrossVolumes, DontDisplaySourcePath, DontDisplayDestPath, RequireElevation, AddUndoRecord, CopyAsDownload, DontDisplayLocations
Vanara.Windows.Shell.ShellIconType | | The type of icon to be returned from `Vanara.Windows.Shell.ShellFileInfo.GetIcon(Vanara.Windows.Shell.ShellIconType)`. | Large, Small, Open, ShellDefinedSize, LinkOverlay, Selected
Vanara.Windows.Shell.ShellImageSize | | Used to determine the size of the icon returned by `Vanara.Windows.Shell.ShellImageList.GetSystemIcon(System.String,Vanara.Windows.Shell.ShellImageSize)`. | Large, Small, ExtraLarge, Jumbo
Vanara.Windows.Shell.ShellItemAttribute | | Attributes that can be retrieved on an item (file or folder) or set of items using `Vanara.Windows.Shell.ShellItem.Attributes`. | CanCopy, CanMove, CanLink, Storage, CanRename, CanDelete, HasPropSheet, DropTarget, CapabilityMask, System, Encrypted, IsSlow, Ghosted, Link, Share, ReadOnly, Hidden, DisplayAttrMask, NonEnumerated, NewContent, CanMoniker, HasStorage, Stream, StorageAncestor, Validate, Removable, Compressed, Browsable, FileSysAncestor, Folder, FileSystem, StorageCapMask, HasSubfolder, ContentsMask, PKEYMask
Vanara.Windows.Shell.ShellItemComparison | | Used to determine how to compare two Shell items. ShellItem.Compare uses this enumerated type. | Display, Canonical, SecondaryFileSystemPath, AllFields
Vanara.Windows.Shell.ShellItemDisplayString | | Requests the form of an item's display name to retrieve through `Vanara.Windows.Shell.ShellItem.GetDisplayName(Vanara.Windows.Shell.ShellItemDisplayString)`. | NormalDisplay, ParentRelativeParsing, DesktopAbsoluteParsing, ParentRelativeEditing, DesktopAbsoluteEditing, FileSysPath, Url, ParentRelativeForAddressBar, ParentRelative, ParentRelativeForUI
Vanara.Windows.Shell.ShellItemGetImageOptions | | Options for retrieving images from a `Vanara.Windows.Shell.ShellItem`. | ResizeToFit, BiggerSizeOk, MemoryOnly, IconOnly, ThumbnailOnly, InCacheOnly, CropToSquare, WideThumbnails, IconBackground, ScaleUp
Vanara.Windows.Shell.ShellItemToolTipOptions | | Flags that direct the handling of the item from which you're retrieving the info tip text. | Default, Name, LinkNotTarget, LinkTarget, AllowDelay, SingleLine
Vanara.Windows.Shell.TaskbarButtonProgressState | | State of the progress shown on a taskbar button. | None, Indeterminate, Normal, Error, Paused
Vanara.Windows.Shell.ShellFileOperations.TransferFlags | | Used by methods of the ITransferSource and ITransferDestination interfaces to control their file operations. | Normal, FailExist, RenameExist, OverwriteExist, AllowDecryption, NoSecurity, CopyCreationTime, CopyWriteTime, UseFullAccess, DeleteRecycleIfPossible, CopyHardLink, CopyLocalizedName, MoveAsCopyDelete, SuspendShellEvents
Vanara.Windows.Shell.VerbMultiSelectModel | |  | Unset, Player, Single, Document
Vanara.Windows.Shell.VerbPosition | |  | Unset, Top, Bottom
Vanara.Windows.Shell.VerbSelectionModel | |  | Item, BackgroundShortcutMenu
### Interfaces
Interface | Header | Description
---- | ---- | ----
Vanara.Windows.Shell.IComObject | | Exposed methods from `Vanara.Windows.Shell.ComObject`.
### Classes
Class | Header | Description
---- | ---- | ----
Vanara.Windows.Shell.ComClassFactory | | An implementation of `Vanara.PInvoke.Ole32.IClassFactory` to be used in conjunction with `Vanara.Windows.Shell.IComObject` derivatives.
Vanara.Windows.Shell.CommandVerb | | Encapsulates a shortcut menu verb in the registry.
Vanara.Windows.Shell.CommandVerbDictionary | | A dictionary of Command Verbs defined in the Windows Registry.
Vanara.Windows.Shell.ComObject | | Base class for all COM objects which handles calling AddRef and Release for the assembly, connection to IClassFactory, implements IObjectWithSite, using an internal message loop, and a mechanism to issue a non-blocking call to itself. Once implemented, you only need to implement your own interfaces. The IClassFactory implementation can get any derived interfaces through casting for calls to its QueryInterface method. If you want more control, override the QueryInterface method in this class.
Vanara.Windows.Shell.ControlPanel | | Provides a means to open Control Panel items and get their paths.
Vanara.Windows.Shell.IconLocation | | Wraps the icon location string used by some Shell classes.
Vanara.Windows.Shell.IndirectResource | | Wraps a resource reference used by some Shell classes.
Vanara.Windows.Shell.IndirectString | | Wraps a string resource reference used by some Shell classes.
Vanara.PInvoke.MessageLoop.MessageEventArgs | | Holds a copy of the MSG instance retrieved by GetMessage.
Vanara.PInvoke.MessageLoop | | <para> This class encapsulates the management of a message loop for an application. It supports queuing a callback to the application via the message loop to enable the app to return from a call and continue processing that call later. This behavior is needed when implementing a shell verb as verbs must not block the caller. </para> <note type="note">The ComObject derived class should call QueueNonBlockingCallback in its invoke function, for example IExecuteCommand::Execute() or IDropTarget::Drop() passing a method that will complete the initialization work.</note>
Vanara.Windows.Shell.ProgId | | Represents a programmatic identifier in the registry for an application.
Vanara.Windows.Shell.PropertyBag | | Encapsulates an `Vanara.PInvoke.Ole32.IPropertyBag` instance.
Vanara.Windows.Shell.PropertyDescription | | Enumerate and retrieve individual property description details. Wraps the `Vanara.PInvoke.PropSys.IPropertyDescription` shell interface
Vanara.Windows.Shell.PropertyDescriptionList | | Exposes methods that extract information from a collection of property descriptions presented as a list.
Vanara.Windows.Shell.PropertyStore | | Encapsulates the IPropertyStore object.
Vanara.Windows.Shell.PropertyType | | Exposes methods that extract data from enumeration information.
Vanara.Windows.Shell.PropertyTypeList | | Exposes methods that enumerate the possible values for a property.
Vanara.Windows.Shell.RegBasedSettings | | Base class for registry based settings.
Vanara.Windows.Shell.RegistryBasedVirtualDictionary<T> | | A virtual dictionary that is based on values in the Windows Registry.
Vanara.Windows.Shell.ShellAssociation | | Represents a Shell file association defined in the Windows Registry. Wraps `Vanara.PInvoke.ShlwApi.IQueryAssociations`.
Vanara.Windows.Shell.ShellFileInfo | | Information and icons for any shell file.
Vanara.Windows.Shell.ShellFileOperations.ShellFileNewOpEventArgs | | Arguments supplied to the `Vanara.Windows.Shell.ShellFileOperations.PostNewItem` event.
Vanara.Windows.Shell.ShellFileOperations | | Queued and static file operations using the Shell.
Vanara.Windows.Shell.ShellFileOperations.ShellFileOpEventArgs | | Arguments supplied to events from `Vanara.Windows.Shell.ShellFileOperations`. Depending on the event, some properties may not be set.
Vanara.Windows.Shell.ShellFolder | | A folder or container of `Vanara.Windows.Shell.ShellItem` instances.
Vanara.Windows.Shell.ShellImageList | | Represents the System Image List holding images for all shell icons.
Vanara.Windows.Shell.ShellItem | | Encapsulates an item in the Windows Shell.
Vanara.Windows.Shell.ShellItemArray | | A folder or container of `Vanara.Windows.Shell.ShellItem` instances.
Vanara.Windows.Shell.ShellItemChangeWatcher.ShellItemChangeEventArgs | | Provides data for `Vanara.Windows.Shell.ShellItemChangeWatcher` events.
Vanara.Windows.Shell.ShellItemChangeWatcher | | Listens to the shell item change notifications and raises events when a folder, or item in a folder, changes.
Vanara.Windows.Shell.ShellItemPropertyStore | | A property store for a `Vanara.Windows.Shell.ShellItem`.
Vanara.Windows.Shell.ShellItemPropertyUpdates | | A dictionary of properties that can be used to set or update property values on Shell items via the `Vanara.Windows.Shell.ShellFileOperations.QueueApplyPropertiesOperation(Vanara.Windows.Shell.ShellItem,Vanara.Windows.Shell.ShellItemPropertyUpdates)` method. This class wraps the `Vanara.Windows.Shell.ShellItemPropertyUpdates.IPropertyChangeArray` COM interface.
Vanara.Windows.Shell.ShellLibrary | | Shell library encapsulation.
Vanara.Windows.Shell.ShellLibrary.ShellLibraryFolders | | Folders of a `Vanara.Windows.Shell.ShellLibrary`.
Vanara.Windows.Shell.ShellLink | | Represents a Shell Shortcut (.lnk) file.
Vanara.Windows.Shell.ShellRegistrar | | Contains static methods used to register and unregister shell items in the Windows Registry.
Vanara.Windows.Shell.TaskbarList | | Methods that control the Windows taskbar. It allows you to dynamically add, remove, and activate items on the taskbar. This wraps all of the ITaskbarListX interfaces.
