## Assembly report for Vanara.Windows.Forms.dll
### Classes
Class | Description
---- | ----
AccessControlEditorDialog | Displays a property sheet that contains a basic security property page. This property page enables the user to view and edit the access rights allowed or denied by the ACEs in an object's DACL.
ActivationContext | 
AppSettingsFileListStorage | Storage in the local application settings.
AttributedComponentDesigner<T> | 
AttributedComponentDesignerEx<T> | 
AttributedControlDesigner<T> | 
AttributedControlDesignerEx<T> | 
AttributedDesignerActionList | 
AttributedParentControlDesigner<T> | 
AttributedParentControlDesignerEx<T> | 
AuthenticationBuffer | Safe container for an authentication buffer. Allows for creation using native <c>CredPackAuthenticationBuffer</c> method or assignment from an existing <c>IntPtr</c>. Can unpack to `String` or `SecureString` values.
BufferedPaint | 
BufferedPaintHandle | 
ButtonClickedEventArgs | Provides data for the `ButtonClicked` and the `RadioButtonClicked` events.
ButtonExtension | 
CollapsiblePanel | Control providing a panel that can be collapsed.
ComboBoxExtension | 
CommandLink | Represents a Windows Command Link control.
ComponentDesignerExtension | Methods to assist when using designer code.
ControlExtension | 
ControlImage | 
CredentialsDialog | Dialog box which prompts for user credentials using the Win32 CREDUI methods.
CursorExtension | 
CustomButton | 
CustomComboBox | <c>CustomComboBox</c> is an extension of `ComboBox` which provides drop-down customization.
CustomDrawBase | Abstract class for implementing a custom-drawn control that tracks mouse movement and has text and/or an image. It exposes all property changes.
DesignerActionMethodAttribute | 
DesignerActionPropertyAttribute | 
DesignerVerbAttribute | 
DesktopWindowManager | Main DWM class, provides glass sheet effect and blur behind.
DisabledItemComboBox | A version of `ComboBox` that allows for disabled items.
DrawPattern | 
EditorServiceContext | 
EnumComboBox | 
ExpandedEventArgs | Provides data for the `Expanded` event.
FlagCheckedListBox | 
FlagCheckedListBoxItem | 
FlagEnumUIEditor<T> | 
FolderBrowserDialog | Class to let the user browse for a folder.
FolderBrowserDialogInitializedEventArgs | Event arguments for when the `FolderBrowserDialog` has been initialized.
GenericProvider | Base implementation of `IAccessControlEditorDialogProvider`.
GetDuration<T> | 
GlassExtenderProvider | GlassExtenderProvider extends a `Form` and provides glass margins.
GraphicsExtension | 
GroupIconResIndexer | 
IconExtension | 
ImageListExtension | 
ImageResIndexer<T> | 
InputDialog | An input dialog that automatically creates controls to collect the values of the object supplied via the `Data` property.
InputDialogItemAttribute | Allows a developer to attribute a property or field with text that gets shown instead of the field or property name in an `InputDialog`.
InvalidFolderEventArgs | Event arguments for when an invalid folder is selected.
IPAddressBox | An Internet Protocol (IP) address control allows the user to enter an IP address in an easily understood format.
IPAddressFieldChangedEventArgs | Contains the arguments needed to handle the `FieldChanged` event.
LabelExtension | 
ListViewExtension | 
ListViewGroupingSet<T> | Takes a list of groups and matching predicates to be used by the ApplyGroupingSet extension method.
LiveThumbnail | Extracts all or a portion of a window and renders it as a thumbnail on another portion of the desktop.
MapPointExtension | 
MenuStripMRUManager | A class that manages a Most Recently Used file listing and interacts with a MenuStrip to display a menu list of the files. By default, the application settings are used to store the history. Optionally a constructor can be used to provide an alternate class to handle that work.
MRUManager | A class that manages a Most Recently Used file listing.
PaintAction<T> | 
PasswordValidatorEventArgs | Used by the `ValidatePassword` event.
PreventShutdownContext | Used to define a set of operations within which any shutdown request will be met with a reason why this application is blocking it.
ProgressDialog | Multi-level, auto-sizing, progress dialog supporting asyncronous tasks. The background activities are provided as asyncronous methods who have a `CancellationToken` and an <see cref="T:System.IProgress`1" /> instance passed as parameters. The method uses the `CancellationToken` instance to determine if the user has pressed the "Cancel" button and the <see cref="M:System.IProgress`1.Report(`0)" /> method to report progress.
ProgressEventArgs | Updates progress on a `ProgressDialog`.
RedirectedDesignerPropertyAttribute | 
RegistryFileListStorage | 
ResourceFile | 
ServiceProviderExtension | 
SmartBitmapLock | A self-disposing LockBits class for Bitmaps.
SplitButton | The SplitButton is a composite control with which the user can select from a drop-down list bound to the button.
SplitMenuEventArgs | Provides data for the clicking of split buttons and the opening of context menus.
StringResIndexer | 
Style | 
TaskDialog | A Task Dialog. This is like a MessageBox but with many more features. For Windows version prior to Vista, an emulated version of the system dialog is displayed.
TaskDialogButton | 
TaskDialogButtonBase | A custom button for the TaskDialog.
TaskDialogButtonCollection<T> | A collection of `TaskDialogButton` elements.
TaskDialogProgressBar | 
TaskDialogRadioButton | 
TextBoxExtension | Extension methods for `TextBox`.
ThemedImageDraw | A button that displays an image and no text.
ThemedLabel | A Label containing some text that will be drawn with glowing border on top of the Glass Sheet effect.
ThemedPanel | A panel that supports a glass overlay.
ThemedTableLayoutPanel | A table layout panel that supports a glass overlay.
TimerEventArgs | Provides data for the `Timer` event.
TrackBarEx | Extends the `TrackBar` class to provide full native-control functionality.
TranslateButtonStateDelegate | 
TreeViewExtension | Extension methods for `TreeView` controls.
TypedBehavior<T> | 
TypedDesignerActionList<T> | 
TypedGlyph<T> | 
VerificationClickedEventArgs | Provides data for the `VerificationClicked` event.
VistaButtonBase | Implements a CommandLink button that can be used in WinForms user interfaces.
VistaControlExtender | 
VisualStylesRendererExtension | 
VisualTheme | 
### Structures
Struct | Description
---- | ----
ImageListDrawColor | Draw color with options for `ImageListExtension.Draw(System.Windows.Forms.ImageList,System.Drawing.Graphics,System.Drawing.Rectangle,System.Int32,Vanara.Extensions.ImageListExtension.ImageListDrawColor,Vanara.Extensions.ImageListExtension.ImageListDrawColor,Vanara.PInvoke.ComCtl32.IMAGELISTDRAWFLAGS,System.Int32)` method.
TaskDialogResult | Results from running the `TaskDialog`.
### Enumerations
Enum | Description | Values
---- | ---- | ----
CloakingSource | Use with GetWindowAttr and WindowAttribute.Cloaked. If the window is cloaked, provides one of the following values explaining why. | App, Shell, Inherited
CollapsiblePanelBorderCondition |  | Always, OnlyExpanded, Never
CollapsiblePanelHeaderState |  | Normal, Hot, Pressed, ExpandedNormal, ExpandedHot, ExpandedPressed, Disabled, ExpandedDisabled
ControlState |  | Hot, Pressed, Disabled, Animating, MouseDown, InButtonUp, Defaulted, Focused
Corners | Used to define which corners of `Rectangle` are effected by an operation. | None, TopLeft, TopRight, BottomLeft, BottomRight, All
Flip3DWindowPolicy | Flags used by the SetWindowAttr method to specify the Flip3D window policy. | Default, ExcludeBelow, ExcludeAbove
FolderBrowserDialogOptions |  | Folders, FoldersAndFiles, Computers, Printers
KnownFolder | Standard folders registered with the system as Known Folders. A computer will have only folders appropriate to it installed. | AccountPictures, AddNewPrograms, AdminTools, ApplicationShortcuts, AppsFolder, AppUpdates, CameraRoll, CDBurning, ChangeRemovePrograms, CommonAdminTools, CommonOEMLinks, CommonPrograms, CommonStartMenu, CommonStartup, CommonTemplates, ComputerFolder, ConflictFolder, ConnectionsFolder, Contacts, ControlPanelFolder, Cookies, Desktop, DeviceMetadataStore, Documents, DocumentsLibrary, Downloads, Favorites, Fonts, Games, GameTasks, History, HomeGroup, HomeGroupCurrentUser, ImplicitAppShortcuts, InternetCache, InternetFolder, Libraries, Links, LocalAppData, LocalAppDataLow, LocalizedResourcesDir, Music, MusicLibrary, NetHood, NetworkFolder, OriginalImages, PhotoAlbums, PicturesLibrary, Pictures, Playlists, PrintersFolder, PrintHood, Profile, ProgramData, ProgramFiles, ProgramFilesX64, ProgramFilesX86, ProgramFilesCommon, ProgramFilesCommonX64, ProgramFilesCommonX86, Programs, Public, PublicDesktop, PublicDocuments, PublicDownloads, PublicGameTasks, PublicLibraries, PublicMusic, PublicPictures, PublicRingtones, PublicUserTiles, PublicVideos, QuickLaunch, Recent, RecordedTVLibrary, RecycleBinFolder, ResourceDir, Ringtones, RoamingAppData, RoamedTileImages, RoamingTiles, SampleMusic, SamplePictures, SamplePlaylists, SampleVideos, SavedGames, SavedPictures, SavedPicturesLibrary, SavedSearches, Screenshots, SEARCH_CSC, SearchHistory, SearchHome, SEARCH_MAPI, SearchTemplates, SendTo, SidebarDefaultParts, SidebarParts, SkyDrive, SkyDriveCameraRoll, SkyDriveDocuments, SkyDrivePictures, StartMenu, Startup, SyncManagerFolder, SyncResultsFolder, SyncSetupFolder, System, SystemX86, Templates, UserPinned, UserProfiles, UserProgramFiles, UserProgramFilesCommon, UsersFiles, UsersLibraries, Videos, VideosLibrary, Windows, Undefined
NonClientRenderingPolicy | Flags used by the SetWindowAttr method to specify the non-client area rendering policy. | UseWindowStyle, Disabled, Enabled
ProgressBarState | Progress bar state. | Normal, Error, Paused
RenderStyle |  | SystemTheme, Custom
SecurityPageType | Values that indicate the types of property pages in an access control editor property sheet. | BasicPermissions, AdvancedPermissions, Audit, Owner, EffectiveRights, TakeOwnership, Share
SizeMode | Sizing mode for the CustomComboBox drop-down area. | UseComboSize, UseControlSize, UseDropDownSize
TaskDialogButtonDisplay | Indicates how buttons are displayed on a `TaskDialog`. | StandardButton, CommandLink, CommandLinkNoIcon
TaskDialogCommonButtons | The TaskDialog common button flags used to specify the built in buttons to show in the TaskDialog. | None, Ok, Yes, No, Cancel, Retry, Close
TaskDialogIcon | The System icons the TaskDialog supports. | None, ShieldGray, SecuritySuccess, SecurityError, SecurityWarning, ShieldBlue, Shield, Information, Error, Warning
