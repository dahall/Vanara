## Assembly report for Vanara.Windows.Forms.dll
### Enumerations
Enum | Header | Description | Values
---- | ---- | ---- | ----
Vanara.Windows.Forms.VisualTheme.BitmapProperty | | Properties accessible via `Vanara.Windows.Forms.VisualTheme.GetBitmap(System.Int32,System.Int32,Vanara.Windows.Forms.VisualTheme.BitmapProperty)`. | BackgroundImage, GlyphImage, Handle
Vanara.Windows.Forms.VisualTheme.BoolProperty | | Properties accessible via `Vanara.Windows.Forms.VisualTheme.GetBool(System.Int32,System.Int32,Vanara.Windows.Forms.VisualTheme.BoolProperty)`. | FlatMenus, Transparent, AutoSize, BorderOnly, Composited, BackgroundFill, GlyphTransparent, GlyphOnly, AlwaysShowSizingBar, MirrorImage, UniformSizing, IntegralSizing, SourceGrow, SourceShrink, DrawBorders, NoEtchedEffect, TextApplyOverlay, TextGlow, TextItalic, CompositedOpaque, LocalizedMirrorImage, UserPicture, ScaledBackground
Vanara.Windows.Forms.DesktopWindowManager.CloakingSource | | Use with GetWindowAttr and WindowAttribute.Cloaked. If the window is cloaked, provides one of the following values explaining why. | App, Shell, Inherited
Vanara.Windows.Forms.CollapsiblePanelBorderCondition | |  | Always, OnlyExpanded, Never
Vanara.Windows.Forms.CollapsiblePanelHeaderState | |  | Normal, Hot, Pressed, ExpandedNormal, ExpandedHot, ExpandedPressed, Disabled, ExpandedDisabled
Vanara.Windows.Forms.VisualTheme.ColorProperty | | Properties accessible via `Vanara.Windows.Forms.VisualTheme.GetColor(System.Int32,System.Int32,Vanara.Windows.Forms.VisualTheme.ColorProperty)`. | ScrollBar, Background, ActiveCaption, InactiveCaption, Menu, Window, WindowFrame, MenuText, WindowText, CaptionText, ActiveBorder, InactiveBorder, AppWorkspace, Highlight, HighlightText, ButtonFace, ButtonShadow, GrayText, ButtonText, InactiveCaptionText, ButtonHighlight, DarkShadow3D, Light3D, InfoText, InfoBackground, ButtonAlternateFace, HotTracking, GradientActiveCaption, GradientInactiveCaption, MenuHilight, MenuBar, FromColor1, FromColor2, FromColor3, FromColor4, FromColor5, BorderColor, FillColor, TextColor, EdgeLightColor, EdgeHighlightColor, EdgeShadowColor, EdgeDarkShadowColor, EdgeFillColor, TransparentColor, GradientColor1, GradientColor2, GradientColor3, GradientColor4, GradientColor5, ShadowColor, GlowColor, TextBorderColor, TextShadowColor, GlyphTextColor, GlyphTransparentColor, FillColorHint, BorderColorHint, AccentColorHint, TextColorHint, Heading1TextColor, Heading2TextColor, BodyTextColor, BlendColor
Vanara.Windows.Forms.ControlState | |  | Hot, Pressed, Disabled, Animating, MouseDown, InButtonUp, Defaulted, Focused
Vanara.Extensions.Corners | | Used to define which corners of `System.Drawing.Rectangle` are effected by an operation. | None, TopLeft, TopRight, BottomLeft, BottomRight, All
Vanara.Windows.Forms.VisualTheme.EnumProperty | | Properties accessible via <c>GetEnumValue</c>. | BackgroundType, BorderType, FillType, SizingType, HAlign, ContentAlignment, VAlign, OffsetType, IconEffect, TextShadowType, ImageLayout, GlyphType, ImageSelectType, GlyphFontSizingType, TrueSizeScalingType
Vanara.Windows.Forms.VisualTheme.FilenameProperty | | Properties accessible via `Vanara.Windows.Forms.VisualTheme.GetFilename(System.Int32,System.Int32,Vanara.Windows.Forms.VisualTheme.FilenameProperty)`. | ImageFile, ImageFile1, ImageFile2, ImageFile3, ImageFile4, ImageFile5, GlyphImageFile
Vanara.Windows.Forms.DesktopWindowManager.Flip3DWindowPolicy | | Flags used by the SetWindowAttr method to specify the Flip3D window policy. | Default, ExcludeBelow, ExcludeAbove
Vanara.Windows.Forms.FolderBrowserDialogOptions | |  | Folders, FoldersAndFiles, Computers, Printers
Vanara.Windows.Forms.VisualTheme.FontProperty | | Properties accessible via `Vanara.Windows.Forms.VisualTheme.GetFont(System.Drawing.IDeviceContext,System.Int32,System.Int32,Vanara.Windows.Forms.VisualTheme.FontProperty)`. | Caption, SmallCaption, Menu, Status, MessageBox, IconTitle, Heading1, Heading2, Body, Glyph
Vanara.Extensions.IconSize | | Used to determine the size of the icon returned by various shell methods. | Large, Small, ExtraLarge, Jumbo
Vanara.Windows.Forms.VisualTheme.IntProperty | | Properties accessible via `Vanara.Windows.Forms.VisualTheme.GetInt(System.Int32,System.Int32,Vanara.Windows.Forms.VisualTheme.IntProperty)`. | CharSet, MinimumColorDepth, FromHue1, FromHue2, FromHue3, FromHue4, FromHue5, ToHue1, ToHue2, ToHue3, ToHue4, ToHue5, ToColor1, ToColor2, ToColor3, ToColor4, ToColor5, TextGlowSize, FramesPerSecond, PixelsPerFrame, AnimationDelay, GlowIntensity, Opacity, ColorizationColor, ColorizationOpacity, AnimationDuration
Vanara.Windows.Forms.KnownFolder | | Standard folders registered with the system as Known Folders. A computer will have only folders appropriate to it installed. | AccountPictures, AddNewPrograms, AdminTools, ApplicationShortcuts, AppsFolder, AppUpdates, CameraRoll, CDBurning, ChangeRemovePrograms, CommonAdminTools, CommonOEMLinks, CommonPrograms, CommonStartMenu, CommonStartup, CommonTemplates, ComputerFolder, ConflictFolder, ConnectionsFolder, Contacts, ControlPanelFolder, Cookies, Desktop, DeviceMetadataStore, Documents, DocumentsLibrary, Downloads, Favorites, Fonts, Games, GameTasks, History, HomeGroup, HomeGroupCurrentUser, ImplicitAppShortcuts, InternetCache, InternetFolder, Libraries, Links, LocalAppData, LocalAppDataLow, LocalizedResourcesDir, Music, MusicLibrary, NetHood, NetworkFolder, OriginalImages, PhotoAlbums, PicturesLibrary, Pictures, Playlists, PrintersFolder, PrintHood, Profile, ProgramData, ProgramFiles, ProgramFilesX64, ProgramFilesX86, ProgramFilesCommon, ProgramFilesCommonX64, ProgramFilesCommonX86, Programs, Public, PublicDesktop, PublicDocuments, PublicDownloads, PublicGameTasks, PublicLibraries, PublicMusic, PublicPictures, PublicRingtones, PublicUserTiles, PublicVideos, QuickLaunch, Recent, RecordedTVLibrary, RecycleBinFolder, ResourceDir, Ringtones, RoamingAppData, RoamedTileImages, RoamingTiles, SampleMusic, SamplePictures, SamplePlaylists, SampleVideos, SavedGames, SavedPictures, SavedPicturesLibrary, SavedSearches, Screenshots, SEARCH_CSC, SearchHistory, SearchHome, SEARCH_MAPI, SearchTemplates, SendTo, SidebarDefaultParts, SidebarParts, SkyDrive, SkyDriveCameraRoll, SkyDriveDocuments, SkyDrivePictures, StartMenu, Startup, SyncManagerFolder, SyncResultsFolder, SyncSetupFolder, System, SystemX86, Templates, UserPinned, UserProfiles, UserProgramFiles, UserProgramFilesCommon, UsersFiles, UsersLibraries, Videos, VideosLibrary, Windows, Undefined
Vanara.Windows.Forms.VisualTheme.MarginsProperty | | Properties accessible via `Vanara.Windows.Forms.VisualTheme.GetMargins(System.Drawing.IDeviceContext,System.Int32,System.Int32,Vanara.Windows.Forms.VisualTheme.MarginsProperty)`. | Sizing, Content, Caption
Vanara.Windows.Forms.VisualTheme.MetricProperty | | Properties accessible via `Vanara.Windows.Forms.VisualTheme.GetMetric(System.Drawing.IDeviceContext,System.Int32,System.Int32,Vanara.Windows.Forms.VisualTheme.MetricProperty)`. | ImageCount, AlphaLevel, BorderSize, RoundCornerWidth, RoundCornerHeight, GradientRatio1, GradientRatio2, GradientRatio3, GradientRatio4, GradientRatio5, ProgressChunkSize, ProgressSpaceSize, Saturation, TextBorderSize, AlphaThreshold, Width, Height, GlyphIndex, TrueSizeStretchMark, MinDpi1, MinDpi2, MinDpi3, MinDpi4, MinDpi5
Vanara.Windows.Forms.DesktopWindowManager.NonClientRenderingPolicy | | Flags used by the SetWindowAttr method to specify the non-client area rendering policy. | UseWindowStyle, Disabled, Enabled
Vanara.Windows.Forms.VisualTheme.PartSize | | Identifies the type of size value to retrieve for a visual style part. | Minimum, BestFit, Default
Vanara.Windows.Forms.VisualTheme.PositionProperty | | Properties accessible via `Vanara.Windows.Forms.VisualTheme.GetPosition(System.Int32,System.Int32,Vanara.Windows.Forms.VisualTheme.PositionProperty)`. | Offset, TextShadowOffset, MinSize, MinSize1, MinSize2, MinSize3, MinSize4, MinSize5, NormalSize
Vanara.Windows.Forms.ProgressBarState | | Progress bar state. | Normal, Error, Paused
Vanara.Windows.Forms.VisualTheme.PropertyOrigin | | Returned by <c>GetPropertyOrigin</c> to specify where a property was found. | State, Part, Class, Global, NotFound
Vanara.Windows.Forms.VisualTheme.RectangleProperty | | Properties accessible via `Vanara.Windows.Forms.VisualTheme.GetRect(System.Int32,System.Int32,Vanara.Windows.Forms.VisualTheme.RectangleProperty)`. | DefaultPane, CustomSplit, AnimationButton, Atlas
Vanara.Windows.Forms.RenderStyle | |  | SystemTheme, Custom
Vanara.Windows.Forms.SecurityPageType | | Values that indicate the types of property pages in an access control editor property sheet. | BasicPermissions, AdvancedPermissions, Audit, Owner, EffectiveRights, TakeOwnership, Share
Vanara.Windows.Forms.ShellProgressDialogStyle | | Display style for a `Vanara.Windows.Forms.ShellProgressDialog`. | Normal, Marquee, Hidden
Vanara.Windows.Forms.CustomComboBox.SizeMode | | Sizing mode for the CustomComboBox drop-down area. | UseComboSize, UseControlSize, UseDropDownSize
Vanara.Windows.Forms.VisualTheme.StringProperty | | Properties accessible via `Vanara.Windows.Forms.VisualTheme.GetString(System.Int32,System.Int32,Vanara.Windows.Forms.VisualTheme.StringProperty)`. | ColorSchemes, Sizes, Name, DisplayName, Tooltip, Company, Author, Copyright, Url, Version, Description, CssName, XmlName, LastUpdated, Alias, Text, ClassicValue, AtlasInputImage
Vanara.Windows.Forms.TaskDialogButtonDisplay | | Indicates how buttons are displayed on a `Vanara.Windows.Forms.TaskDialog`. | StandardButton, CommandLink, CommandLinkNoIcon
Vanara.Windows.Forms.TaskDialogCommonButtons | | The TaskDialog common button flags used to specify the built in buttons to show in the TaskDialog. | None, Ok, Yes, No, Cancel, Retry, Close
Vanara.Windows.Forms.TaskDialogIcon | | The System icons the TaskDialog supports. | None, ShieldGray, SecuritySuccess, SecurityError, SecurityWarning, ShieldBlue, Shield, Information, Error, Warning
### Structures
Struct | Header | Description
---- | ---- | ----
Vanara.Windows.Forms.TaskDialog.TaskDialogResult | | Results from running the `Vanara.Windows.Forms.TaskDialog`.
### Interfaces
Interface | Header | Description
---- | ---- | ----
Vanara.Security.AccessControl.IAccessControlEditorDialogProvider | | An interface for defining an information provider for object types supplied to the `Vanara.Windows.Forms.AccessControlEditorDialog`.
Vanara.Windows.Forms.Design.IActionGetItem | | 
Vanara.Windows.Forms.IDrawingStyle<T> | | 
Vanara.Windows.Forms.IEnableable | | Interface that exposes an <c>Enabled</c> property for an item supplied to `Vanara.Windows.Forms.DisabledItemComboBox`.
Vanara.Configuration.MRUManager.IFileListStorage | | Defines a class that implements storage for an MRU file list.
Vanara.Configuration.MRUManager.IMenuBuilder | | Defines a class that implements a menu handler for an MRU file list.
### Classes
Class | Header | Description
---- | ---- | ----
Vanara.Windows.Forms.AccessControlEditorDialog | | Displays a property sheet that contains a basic security property page. This property page enables the user to view and edit the access rights allowed or denied by the ACEs in an object's DACL.
Vanara.Windows.Forms.ActivationContext | | Provides an activation context for a manifest file or PE image. On disposal, the context is deactivated.
Vanara.Configuration.MRUManager.AppSettingsFileListStorage | | Storage in the local application settings.
Vanara.Windows.Forms.Design.AttributedComponentDesigner<T> | | 
Vanara.Windows.Forms.Design.AttributedComponentDesignerEx<T> | | 
Vanara.Windows.Forms.Design.AttributedControlDesigner<T> | | 
Vanara.Windows.Forms.Design.AttributedControlDesignerEx<T> | | 
Vanara.Windows.Forms.Design.AttributedDesignerActionList | | 
Vanara.Windows.Forms.Design.AttributedParentControlDesigner<T> | | 
Vanara.Windows.Forms.Design.AttributedParentControlDesignerEx<T> | | 
Vanara.Security.AuthenticationBuffer | | Safe container for an authentication buffer. Allows for creation using native <c>CredPackAuthenticationBuffer</c> method or assignment from an existing <c>IntPtr</c>. Can unpack to `System.String` or `System.Security.SecureString` values.
Vanara.Drawing.BufferedAnimationPainter | | Use to paint a buffered animation.
Vanara.Drawing.BufferedPaint | | Buffered painting helper class.
Vanara.Drawing.BufferedPainter | | Use to perform buffered painting.
Vanara.Windows.Forms.TaskDialog.ButtonClickedEventArgs | | Provides data for the `Vanara.Windows.Forms.TaskDialog.ButtonClicked` and the `Vanara.Windows.Forms.TaskDialog.RadioButtonClicked` events.
Vanara.Extensions.ButtonExtension | | 
Vanara.Windows.Forms.CollapsiblePanel | | Control providing a panel that can be collapsed.
Vanara.Extensions.ComboBoxExtension | | 
Vanara.Windows.Forms.CommandLink | | Represents a Windows Command Link control.
Vanara.Windows.Forms.Design.ComponentDesignerExtension | | Methods to assist when using designer code.
Vanara.Extensions.ControlExtension | | Control extension methods.
Vanara.Windows.Forms.ControlImage | | 
Vanara.Windows.Forms.CredentialsDialog | | Dialog box which prompts for user credentials using the Win32 CREDUI methods.
Vanara.Extensions.CursorExtension | | 
Vanara.Windows.Forms.CustomButton | | 
Vanara.Windows.Forms.CustomComboBox | | <c>CustomComboBox</c> is an extension of `System.Windows.Forms.ComboBox` which provides drop-down customization.
Vanara.Windows.Forms.CustomDrawBase | | Abstract class for implementing a custom-drawn control that tracks mouse movement and has text and/or an image. It exposes all property changes.
Vanara.Windows.Forms.Design.DesignerActionMethodAttribute | | 
Vanara.Windows.Forms.Design.DesignerActionPropertyAttribute | | 
Vanara.Windows.Forms.Design.DesignerVerbAttribute | | 
Vanara.Windows.Forms.DesktopWindowManager | | Main DWM class, provides glass sheet effect and blur behind.
Vanara.Windows.Forms.DisabledItemComboBox | | A version of `System.Windows.Forms.ComboBox` that allows for disabled items.
Vanara.Windows.Forms.CustomButton.DrawPattern | | 
Vanara.Windows.Forms.Design.EditorServiceContext | | 
Vanara.Windows.Forms.EnumComboBox | | 
Vanara.Windows.Forms.TaskDialog.ExpandedEventArgs | | Provides data for the `Vanara.Windows.Forms.TaskDialog.ExpandedEventArgs.Expanded` event.
Vanara.Windows.Forms.Design.FlagEnumUIEditor<T>.FlagCheckedListBox | | 
Vanara.Windows.Forms.Design.FlagEnumUIEditor<T>.FlagCheckedListBox.FlagCheckedListBoxItem | | 
Vanara.Windows.Forms.Design.FlagEnumUIEditor<T> | | A `System.Drawing.Design.UITypeEditor` for editing flag enums.
Vanara.Windows.Forms.FolderBrowserDialog | | Class to let the user browse for a folder.
Vanara.Windows.Forms.FolderBrowserDialogInitializedEventArgs | | Event arguments for when the `Vanara.Windows.Forms.FolderBrowserDialog` has been initialized.
Vanara.Security.AccessControl.GenericProvider | | Base implementation of `Vanara.Security.AccessControl.IAccessControlEditorDialogProvider`.
Vanara.Drawing.BufferedPaint.GetDuration<T> | | A method delegate that retrieves a duration, in milliseconds, to use as the time over which buffered painting occurs.
Vanara.Windows.Forms.GlassExtenderProvider | | GlassExtenderProvider extends a `System.Windows.Forms.Form` and provides glass margins.
Vanara.Extensions.GraphicsExtension | | Extensions to <c>Graphics</c> related classes.
Vanara.Resources.ResourceFile.GroupIconResIndexer | | 
Vanara.Extensions.IconExtension | | 
Vanara.Extensions.ImageListExtension | | Extension methods for `System.Windows.Forms.ImageList`.
Vanara.Resources.ResourceFile.ImageResIndexer<T> | | 
Vanara.Windows.Forms.InputDialog | | An input dialog that automatically creates controls to collect the values of the object supplied via the `Vanara.Windows.Forms.InputDialog.Data` property.
Vanara.Windows.Forms.InputDialogItemAttribute | | Allows a developer to attribute a property or field with text that gets shown instead of the field or property name in an `Vanara.Windows.Forms.InputDialog`.
Vanara.Windows.Forms.InvalidFolderEventArgs | | Event arguments for when an invalid folder is selected.
Vanara.Windows.Forms.IPAddressBox | | An Internet Protocol (IP) address control allows the user to enter an IP address in an easily understood format.
Vanara.Windows.Forms.IPAddressFieldChangedEventArgs | | Contains the arguments needed to handle the `Vanara.Windows.Forms.IPAddressBox.FieldChanged` event.
Vanara.Extensions.LabelExtension | | 
Vanara.Extensions.ListViewExtension | | 
Vanara.Extensions.ListViewGroupingSet<T> | | Takes a list of groups and matching predicates to be used by the ApplyGroupingSet extension method.
Vanara.Windows.Forms.LiveThumbnail | | Extracts all or a portion of a window and renders it as a thumbnail on another portion of the desktop.
Vanara.Extensions.MapPointExtension | | 
Vanara.Windows.Forms.MenuStripMRUManager | | A class that manages a Most Recently Used file listing and interacts with a MenuStrip to display a menu list of the files. By default, the application settings are used to store the history. Optionally a constructor can be used to provide an alternate class to handle that work.
Vanara.Configuration.MRUManager | | A class that manages a Most Recently Used file listing.
Vanara.Windows.Forms.NetworkConnectionDialog | | A dialog box that allows the user to browse and connect to network resources.
Vanara.Windows.Forms.NetworkDisconnectDialog | | A dialog box that allows the user to browse and connect to network resources.
Vanara.Drawing.BufferedPaint.PaintAction<T> | | A method delegate to paint a stateful image.
Vanara.Windows.Forms.CredentialsDialog.PasswordValidatorEventArgs | | Used by the `Vanara.Windows.Forms.CredentialsDialog.ValidatePassword` event.
Vanara.Windows.Forms.Forms.PreventShutdownContext | | Used to define a set of operations within which any shutdown request will be met with a reason why this application is blocking it.
Vanara.Windows.Forms.ProgressDialog | | Multi-level, auto-sizing, progress dialog supporting asyncronous tasks. The background activities are provided as asyncronous methods who have a `System.Threading.CancellationToken` and an `System.IProgress`1` instance passed as parameters. The method uses the `System.Threading.CancellationToken` instance to determine if the user has pressed the "Cancel" button and the `System.IProgress`1.Report(`0)` method to report progress.
Vanara.Windows.Forms.ProgressEventArgs | | Updates progress on a `Vanara.Windows.Forms.ProgressDialog`.
Vanara.Windows.Forms.Design.RedirectedDesignerPropertyAttribute | | 
Vanara.Configuration.MRUManager.RegistryFileListStorage | | 
Vanara.Resources.ResourceFile | | 
Vanara.Windows.Forms.Design.ServiceProviderExtension | | 
Vanara.Windows.Forms.ShellProgressDialog | | Wrapper for IProgressDialog which displays a system progress dialog. This object is a generic way to show a user how an operation is progressing. It is typically used when deleting, uploading, copying, moving, or downloading large numbers of files. The dialog is shown on a separate thread and will not block operations in the current thread.
Vanara.Extensions.GraphicsExtension.SmartBitmapLock | | A self-disposing LockBits class for Bitmaps.
Vanara.Windows.Forms.SplitButton | | The SplitButton is a composite control with which the user can select from a drop-down list bound to the button.
Vanara.Windows.Forms.SplitButton.SplitMenuEventArgs | | Provides data for the clicking of split buttons and the opening of context menus.
Vanara.Resources.ResourceFile.StringResIndexer | | 
Vanara.Windows.Forms.CollapsiblePanel.Style | | 
Vanara.Windows.Forms.TaskDialog | | A Task Dialog. This is like a MessageBox but with many more features. For Windows version prior to Vista, an emulated version of the system dialog is displayed.
Vanara.Windows.Forms.TaskDialogButton | | 
Vanara.Windows.Forms.TaskDialog.TaskDialogButtonBase | | A custom button for the TaskDialog.
Vanara.Windows.Forms.TaskDialog.TaskDialogButtonCollection<T> | | A collection of `Vanara.Windows.Forms.TaskDialogButton` elements.
Vanara.Windows.Forms.TaskDialog.TaskDialogProgressBar | | 
Vanara.Windows.Forms.TaskDialogRadioButton | | 
Vanara.Extensions.TextBoxExtension | | Extension methods for `System.Windows.Forms.TextBox`.
Vanara.Windows.Forms.ThemedImageDraw | | A button that displays an image and no text.
Vanara.Windows.Forms.ThemedLabel | | A Label containing some text that will be drawn with glowing border on top of the Glass Sheet effect.
Vanara.Windows.Forms.ThemedPanel | | A panel that supports a glass overlay and is drawn using a visual style.
Vanara.Windows.Forms.ThemedTableLayoutPanel | | A table layout panel that supports a glass overlay.
Vanara.Windows.Forms.TaskDialog.TimerEventArgs | | Provides data for the `Vanara.Windows.Forms.TaskDialog.Timer` event.
Vanara.Windows.Forms.TrackBarEx | | Extends the `System.Windows.Forms.TrackBar` class to provide full native-control functionality.
Vanara.Extensions.TreeViewExtension | | Extension methods for `System.Windows.Forms.TreeView` controls.
Vanara.Windows.Forms.Design.TypedBehavior<T> | | 
Vanara.Windows.Forms.Design.TypedDesignerActionList<T> | | 
Vanara.Windows.Forms.Design.TypedGlyph<T> | | 
Vanara.Windows.Forms.TaskDialog.VerificationClickedEventArgs | | Provides data for the `Vanara.Windows.Forms.TaskDialog.VerificationClicked` event.
Vanara.Windows.Forms.VistaButtonBase | | Implements a CommandLink button that can be used in WinForms user interfaces.
Vanara.Windows.Forms.VistaControlExtender | | 
Vanara.Extensions.VisualStylesRendererExtension | | Extension methods for `System.Windows.Forms.VisualStyles.VisualStyleRenderer` for glass effects and extended method functionality. Also provides GetFont2 and GetMargins2 methods that corrects base library's non-functioning methods.
Vanara.Windows.Forms.VisualTheme | | A wrapper around the UxTheme methods.
