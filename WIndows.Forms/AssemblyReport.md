## Assembly report for Vanara.Windows.Forms.dll
### Classes
Class | Description
---- | ----
AccessControlEditorDialog | Displays a property sheet that contains a basic security property page. This property page enables the user to view and edit the access rights allowed or denied by the ACEs in an object's DACL.
ActivationContext | Provides an activation context for a manifest file or PE image. On disposal, the context is deactivated.
AppSettingsFileListStorage | Storage in the local application settings.
AttributedComponentDesigner<T> | 
AttributedComponentDesignerEx<T> | 
AttributedControlDesigner<T> | 
AttributedControlDesignerEx<T> | 
AttributedDesignerActionList | 
AttributedParentControlDesigner<T> | 
AttributedParentControlDesignerEx<T> | 
AuthenticationBuffer | Safe container for an authentication buffer. Allows for creation using native <c>CredPackAuthenticationBuffer</c> method or assignment from an existing <c>IntPtr</c>. Can unpack to `String` or `SecureString` values.
BufferedAnimationPainter | Use to paint a buffered animation.
BufferedPaint | Buffered painting helper class.
BufferedPainter | Use to perform buffered painting.
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
GetDuration<T> | A method delegate that retrieves a duration, in milliseconds, to use as the time over which buffered painting occurs.
GlassExtenderProvider | GlassExtenderProvider extends a `Form` and provides glass margins.
GraphicsExtension | Extensions to <c>Graphics</c> related classes.
GroupIconResIndexer | 
IconExtension | 
ImageListExtension | Extension methods for `ImageList`.
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
NetworkConnectionDialog | A dialog box that allows the user to browse and connect to network resources.
NetworkDisconnectDialog | A dialog box that allows the user to browse and connect to network resources.
PaintAction<T> | A method delegate to paint a stateful image.
PasswordValidatorEventArgs | Used by the `ValidatePassword` event.
PreventShutdownContext | Used to define a set of operations within which any shutdown request will be met with a reason why this application is blocking it.
ProgressDialog | Multi-level, auto-sizing, progress dialog supporting asyncronous tasks. The background activities are provided as asyncronous methods who have a `CancellationToken` and an <see cref="T:System.IProgress`1" /> instance passed as parameters. The method uses the `CancellationToken` instance to determine if the user has pressed the "Cancel" button and the <see cref="M:System.IProgress`1.Report(`0)" /> method to report progress.
ProgressEventArgs | Updates progress on a `ProgressDialog`.
RedirectedDesignerPropertyAttribute | 
RegistryFileListStorage | 
ResourceFile | 
ServiceProviderExtension | 
ShellProgressDialog | Wrapper for IProgressDialog which displays a system progress dialog. This object is a generic way to show a user how an operation is progressing. It is typically used when deleting, uploading, copying, moving, or downloading large numbers of files. The dialog is shown on a separate thread and will not block operations in the current thread.
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
ThemedPanel | A panel that supports a glass overlay and is drawn using a visual style.
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
VisualStylesRendererExtension | Extension methods for `VisualStyleRenderer` for glass effects and extended method functionality. Also provides GetFont2 and GetMargins2 methods that corrects base library's non-functioning methods.
VisualTheme | A wrapper around the UxTheme methods.
### Structures
Struct | Description
---- | ----
TaskDialogResult | Results from running the `TaskDialog`.
### Enumerations
Enum | Description | Values
---- | ---- | ----
BitmapProperty | Properties accessible via `VisualTheme.GetBitmap(System.Int32,System.Int32,Vanara.Windows.Forms.VisualTheme.BitmapProperty)`. | BackgroundImage, GlyphImage, Handle
BoolProperty | Properties accessible via `VisualTheme.GetBool(System.Int32,System.Int32,Vanara.Windows.Forms.VisualTheme.BoolProperty)`. | FlatMenus, Transparent, AutoSize, BorderOnly, Composited, BackgroundFill, GlyphTransparent, GlyphOnly, AlwaysShowSizingBar, MirrorImage, UniformSizing, IntegralSizing, SourceGrow, SourceShrink, DrawBorders, NoEtchedEffect, TextApplyOverlay, TextGlow, TextItalic, CompositedOpaque, LocalizedMirrorImage, UserPicture, ScaledBackground
CloakingSource | Use with GetWindowAttr and WindowAttribute.Cloaked. If the window is cloaked, provides one of the following values explaining why. | App, Shell, Inherited
CollapsiblePanelBorderCondition |  | Always, OnlyExpanded, Never
CollapsiblePanelHeaderState |  | Normal, Hot, Pressed, ExpandedNormal, ExpandedHot, ExpandedPressed, Disabled, ExpandedDisabled
ColorProperty | Properties accessible via `VisualTheme.GetColor(System.Int32,System.Int32,Vanara.Windows.Forms.VisualTheme.ColorProperty)`. | ScrollBar, Background, ActiveCaption, InactiveCaption, Menu, Window, WindowFrame, MenuText, WindowText, CaptionText, ActiveBorder, InactiveBorder, AppWorkspace, Highlight, HighlightText, ButtonFace, ButtonShadow, GrayText, ButtonText, InactiveCaptionText, ButtonHighlight, DarkShadow3D, Light3D, InfoText, InfoBackground, ButtonAlternateFace, HotTracking, GradientActiveCaption, GradientInactiveCaption, MenuHilight, MenuBar, FromColor1, FromColor2, FromColor3, FromColor4, FromColor5, BorderColor, FillColor, TextColor, EdgeLightColor, EdgeHighlightColor, EdgeShadowColor, EdgeDarkShadowColor, EdgeFillColor, TransparentColor, GradientColor1, GradientColor2, GradientColor3, GradientColor4, GradientColor5, ShadowColor, GlowColor, TextBorderColor, TextShadowColor, GlyphTextColor, GlyphTransparentColor, FillColorHint, BorderColorHint, AccentColorHint, TextColorHint, Heading1TextColor, Heading2TextColor, BodyTextColor, BlendColor
ControlState |  | Hot, Pressed, Disabled, Animating, MouseDown, InButtonUp, Defaulted, Focused
Corners | Used to define which corners of `Rectangle` are effected by an operation. | None, TopLeft, TopRight, BottomLeft, BottomRight, All
EnumProperty | Properties accessible via <c>GetEnumValue</c>. | BackgroundType, BorderType, FillType, SizingType, HAlign, ContentAlignment, VAlign, OffsetType, IconEffect, TextShadowType, ImageLayout, GlyphType, ImageSelectType, GlyphFontSizingType, TrueSizeScalingType
FilenameProperty | Properties accessible via `VisualTheme.GetFilename(System.Int32,System.Int32,Vanara.Windows.Forms.VisualTheme.FilenameProperty)`. | ImageFile, ImageFile1, ImageFile2, ImageFile3, ImageFile4, ImageFile5, GlyphImageFile
Flip3DWindowPolicy | Flags used by the SetWindowAttr method to specify the Flip3D window policy. | Default, ExcludeBelow, ExcludeAbove
FolderBrowserDialogOptions |  | Folders, FoldersAndFiles, Computers, Printers
FontProperty | Properties accessible via `VisualTheme.GetFont(System.Drawing.IDeviceContext,System.Int32,System.Int32,Vanara.Windows.Forms.VisualTheme.FontProperty)`. | Caption, SmallCaption, Menu, Status, MessageBox, IconTitle, Heading1, Heading2, Body, Glyph
IconSize | Used to determine the size of the icon returned by <see cref="!:ShellImageList.GetSystemIcon" />. | Large, Small, ExtraLarge, Jumbo
IntProperty | Properties accessible via `VisualTheme.GetInt(System.Int32,System.Int32,Vanara.Windows.Forms.VisualTheme.IntProperty)`. | CharSet, MinimumColorDepth, FromHue1, FromHue2, FromHue3, FromHue4, FromHue5, ToHue1, ToHue2, ToHue3, ToHue4, ToHue5, ToColor1, ToColor2, ToColor3, ToColor4, ToColor5, TextGlowSize, FramesPerSecond, PixelsPerFrame, AnimationDelay, GlowIntensity, Opacity, ColorizationColor, ColorizationOpacity, AnimationDuration
KnownFolder | Standard folders registered with the system as Known Folders. A computer will have only folders appropriate to it installed. | AccountPictures, AddNewPrograms, AdminTools, ApplicationShortcuts, AppsFolder, AppUpdates, CameraRoll, CDBurning, ChangeRemovePrograms, CommonAdminTools, CommonOEMLinks, CommonPrograms, CommonStartMenu, CommonStartup, CommonTemplates, ComputerFolder, ConflictFolder, ConnectionsFolder, Contacts, ControlPanelFolder, Cookies, Desktop, DeviceMetadataStore, Documents, DocumentsLibrary, Downloads, Favorites, Fonts, Games, GameTasks, History, HomeGroup, HomeGroupCurrentUser, ImplicitAppShortcuts, InternetCache, InternetFolder, Libraries, Links, LocalAppData, LocalAppDataLow, LocalizedResourcesDir, Music, MusicLibrary, NetHood, NetworkFolder, OriginalImages, PhotoAlbums, PicturesLibrary, Pictures, Playlists, PrintersFolder, PrintHood, Profile, ProgramData, ProgramFiles, ProgramFilesX64, ProgramFilesX86, ProgramFilesCommon, ProgramFilesCommonX64, ProgramFilesCommonX86, Programs, Public, PublicDesktop, PublicDocuments, PublicDownloads, PublicGameTasks, PublicLibraries, PublicMusic, PublicPictures, PublicRingtones, PublicUserTiles, PublicVideos, QuickLaunch, Recent, RecordedTVLibrary, RecycleBinFolder, ResourceDir, Ringtones, RoamingAppData, RoamedTileImages, RoamingTiles, SampleMusic, SamplePictures, SamplePlaylists, SampleVideos, SavedGames, SavedPictures, SavedPicturesLibrary, SavedSearches, Screenshots, SEARCH_CSC, SearchHistory, SearchHome, SEARCH_MAPI, SearchTemplates, SendTo, SidebarDefaultParts, SidebarParts, SkyDrive, SkyDriveCameraRoll, SkyDriveDocuments, SkyDrivePictures, StartMenu, Startup, SyncManagerFolder, SyncResultsFolder, SyncSetupFolder, System, SystemX86, Templates, UserPinned, UserProfiles, UserProgramFiles, UserProgramFilesCommon, UsersFiles, UsersLibraries, Videos, VideosLibrary, Windows, Undefined
MarginsProperty | Properties accessible via `VisualTheme.GetMargins(System.Drawing.IDeviceContext,System.Int32,System.Int32,Vanara.Windows.Forms.VisualTheme.MarginsProperty)`. | Sizing, Content, Caption
MetricProperty | Properties accessible via `VisualTheme.GetMetric(System.Drawing.IDeviceContext,System.Int32,System.Int32,Vanara.Windows.Forms.VisualTheme.MetricProperty)`. | ImageCount, AlphaLevel, BorderSize, RoundCornerWidth, RoundCornerHeight, GradientRatio1, GradientRatio2, GradientRatio3, GradientRatio4, GradientRatio5, ProgressChunkSize, ProgressSpaceSize, Saturation, TextBorderSize, AlphaThreshold, Width, Height, GlyphIndex, TrueSizeStretchMark, MinDpi1, MinDpi2, MinDpi3, MinDpi4, MinDpi5
NonClientRenderingPolicy | Flags used by the SetWindowAttr method to specify the non-client area rendering policy. | UseWindowStyle, Disabled, Enabled
PartSize | Identifies the type of size value to retrieve for a visual style part. | Minimum, BestFit, Default
PositionProperty | Properties accessible via `VisualTheme.GetPosition(System.Int32,System.Int32,Vanara.Windows.Forms.VisualTheme.PositionProperty)`. | Offset, TextShadowOffset, MinSize, MinSize1, MinSize2, MinSize3, MinSize4, MinSize5, NormalSize
ProgressBarState | Progress bar state. | Normal, Error, Paused
PropertyOrigin | Returned by <c>GetPropertyOrigin</c> to specify where a property was found. | State, Part, Class, Global, NotFound
RectangleProperty | Properties accessible via `VisualTheme.GetRect(System.Int32,System.Int32,Vanara.Windows.Forms.VisualTheme.RectangleProperty)`. | DefaultPane, CustomSplit, AnimationButton, Atlas
RenderStyle |  | SystemTheme, Custom
SecurityPageType | Values that indicate the types of property pages in an access control editor property sheet. | BasicPermissions, AdvancedPermissions, Audit, Owner, EffectiveRights, TakeOwnership, Share
ShellProgressDialogStyle | Display style for a `ShellProgressDialog`. | Normal, Marquee, Hidden
SizeMode | Sizing mode for the CustomComboBox drop-down area. | UseComboSize, UseControlSize, UseDropDownSize
StringProperty | Properties accessible via `VisualTheme.GetString(System.Int32,System.Int32,Vanara.Windows.Forms.VisualTheme.StringProperty)`. | ColorSchemes, Sizes, Name, DisplayName, Tooltip, Company, Author, Copyright, Url, Version, Description, CssName, XmlName, LastUpdated, Alias, Text, ClassicValue, AtlasInputImage
TaskDialogButtonDisplay | Indicates how buttons are displayed on a `TaskDialog`. | StandardButton, CommandLink, CommandLinkNoIcon
TaskDialogCommonButtons | The TaskDialog common button flags used to specify the built in buttons to show in the TaskDialog. | None, Ok, Yes, No, Cancel, Retry, Close
TaskDialogIcon | The System icons the TaskDialog supports. | None, ShieldGray, SecuritySuccess, SecurityError, SecurityWarning, ShieldBlue, Shield, Information, Error, Warning
