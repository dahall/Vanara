## Assembly report for Vanara.Windows.Forms.dll
### Classes
Class | Description
---- | ----
ActivationContext | 
AppSettingsFileListStorage | Storage in the local application settings.
AspChildControlTypeAttribute | 
AspDataFieldAttribute | 
AspDataFieldsAttribute | 
AspMethodPropertyAttribute | 
AspMvcActionAttribute | ASP.NET MVC attribute. If applied to a parameter, indicates that the parameter is an MVC action. If applied to a method, the MVC action name is calculated implicitly from the context. Use this attribute for custom wrappers similar to <c>System.Web.Mvc.Html.ChildActionExtensions.RenderAction(HtmlHelper, String)</c>.
AspMvcActionSelectorAttribute | ASP.NET MVC attribute. When applied to a parameter of an attribute, indicates that this parameter is an MVC action name.
AspMvcAreaAttribute | ASP.NET MVC attribute. Indicates that a parameter is an MVC area. Use this attribute for custom wrappers similar to <c>System.Web.Mvc.Html.ChildActionExtensions.RenderAction(HtmlHelper, String)</c>.
AspMvcAreaMasterLocationFormatAttribute | 
AspMvcAreaPartialViewLocationFormatAttribute | 
AspMvcAreaViewLocationFormatAttribute | 
AspMvcControllerAttribute | ASP.NET MVC attribute. If applied to a parameter, indicates that the parameter is an MVC controller. If applied to a method, the MVC controller name is calculated implicitly from the context. Use this attribute for custom wrappers similar to <c>System.Web.Mvc.Html.ChildActionExtensions.RenderAction(HtmlHelper, String, String)</c>.
AspMvcDisplayTemplateAttribute | ASP.NET MVC attribute. Indicates that a parameter is an MVC display template. Use this attribute for custom wrappers similar to <c>System.Web.Mvc.Html.DisplayExtensions.DisplayForModel(HtmlHelper, String)</c>.
AspMvcEditorTemplateAttribute | ASP.NET MVC attribute. Indicates that a parameter is an MVC editor template. Use this attribute for custom wrappers similar to <c>System.Web.Mvc.Html.EditorExtensions.EditorForModel(HtmlHelper, String)</c>.
AspMvcMasterAttribute | ASP.NET MVC attribute. Indicates that a parameter is an MVC Master. Use this attribute for custom wrappers similar to <c>System.Web.Mvc.Controller.View(String, String)</c>.
AspMvcMasterLocationFormatAttribute | 
AspMvcModelTypeAttribute | ASP.NET MVC attribute. Indicates that a parameter is an MVC model type. Use this attribute for custom wrappers similar to <c>System.Web.Mvc.Controller.View(String, Object)</c>.
AspMvcPartialViewAttribute | ASP.NET MVC attribute. If applied to a parameter, indicates that the parameter is an MVC partial view. If applied to a method, the MVC partial view name is calculated implicitly from the context. Use this attribute for custom wrappers similar to <c>System.Web.Mvc.Html.RenderPartialExtensions.RenderPartial(HtmlHelper, String)</c>.
AspMvcPartialViewLocationFormatAttribute | 
AspMvcSuppressViewErrorAttribute | ASP.NET MVC attribute. Allows disabling inspections for MVC views within a class or a method.
AspMvcTemplateAttribute | ASP.NET MVC attribute. Indicates that a parameter is an MVC template. Use this attribute for custom wrappers similar to <c>System.ComponentModel.DataAnnotations.UIHintAttribute(System.String)</c>.
AspMvcViewAttribute | ASP.NET MVC attribute. If applied to a parameter, indicates that the parameter is an MVC view component. If applied to a method, the MVC view name is calculated implicitly from the context. Use this attribute for custom wrappers similar to <c>System.Web.Mvc.Controller.View(Object)</c>.
AspMvcViewComponentAttribute | ASP.NET MVC attribute. If applied to a parameter, indicates that the parameter is an MVC view component name.
AspMvcViewComponentViewAttribute | ASP.NET MVC attribute. If applied to a parameter, indicates that the parameter is an MVC view component view. If applied to a method, the MVC view component view name is default.
AspMvcViewLocationFormatAttribute | 
AspRequiredAttributeAttribute | 
AspTypePropertyAttribute | 
AssertionConditionAttribute | Indicates the condition parameter of the assertion method. The method itself should be marked by `AssertionMethodAttribute` attribute. The mandatory argument of the attribute is the assertion type.
AssertionMethodAttribute | Indicates that the marked method is assertion method, i.e. it halts control flow if one of the conditions is satisfied. To set the condition, mark one of the parameters with `AssertionConditionAttribute` attribute.
AuthenticationBuffer | Safe container for an authentication buffer. Allows for creation using native <c>CredPackAuthenticationBuffer</c> method or assignment from an existing <c>IntPtr</c>. Can unpack to `String` or `SecureString` values.
BaseTypeRequiredAttribute | When applied to a target attribute, specifies a requirement for any type marked with the target attribute to implement or inherit specific type or types.
BufferedPaintHandle | 
ButtonClickedEventArgs | 
CanBeNullAttribute | Indicates that the value of the marked element could be <c>null</c> sometimes, so the check for <c>null</c> is necessary before its usage.
CannotApplyEqualityOperatorAttribute | Indicates that the value of the marked type (or its derivatives) cannot be compared using '==' or '!=' operators and <c>Equals()</c> should be used instead. However, using '==' or '!=' for comparison with <c>null</c> is always permitted.
CollapsiblePanel | Control providing a panel that can be collapsed.
CollectionAccessAttribute | Indicates how method, constructor invocation or property access over collection type affects content of the collection.
CommandLink | Represents a Windows Command Link control.
ContractAnnotationAttribute | Describes dependency between method input and output.
ControlImage | 
CredentialsDialog | Dialog box which prompts for user credentials using the Win32 CREDUI methods.
DesignerActionMethodAttribute | 
DesignerActionPropertyAttribute | 
DesignerVerbAttribute | 
DisabledItemComboBox | A version of `ComboBox` that allows for disabled items.
DrawPattern | 
EditorServiceContext | 
EnumComboBox | 
ExpandedEventArgs | 
FlagCheckedListBox | 
FlagCheckedListBoxItem | 
FlagEnumUIEditor`1 | 
FolderBrowserDialog | Class to let the user browse for a folder.
FolderBrowserDialogInitializedEventArgs | Event arguments for when the `FolderBrowserDialog` has been initialized.
GetDuration`1 | 
GlassExtenderProvider | GlassExtenderProvider extends a `Form` and provides glass margins.
GroupIconResIndexer | 
HtmlAttributeValueAttribute | 
HtmlElementAttributesAttribute | 
ImageResIndexer`1 | 
ImplicitNotNullAttribute | Implicitly apply [NotNull]/[ItemNotNull] annotation to all the of type members and parameters in particular scope where this annotation is used (type declaration or whole assembly).
InputDialog | An input dialog that automatically creates controls to collect the values of the object supplied via the `Data` property.
InputDialogItemAttribute | Allows a developer to attribute a property or field with text that gets shown instead of the field or property name in an `InputDialog`.
InstantHandleAttribute | Tells code analysis engine if the parameter is completely handled when the invoked method is on stack. If the parameter is a delegate, indicates that delegate is executed while the method is executed. If the parameter is an enumerable, indicates that it is enumerated while the method is executed.
InvalidFolderEventArgs | Event arguments for when an invalid folder is selected.
InvokerParameterNameAttribute | Indicates that the function argument should be string literal and match one of the parameters of the caller function. For example, ReSharper annotates the parameter of `ArgumentNullException`.
IPAddressBox | An Internet Protocol (IP) address control allows the user to enter an IP address in an easily understood format.
IPAddressFieldChangedEventArgs | Contains the arguments needed to handle the `FieldChanged` event.
ItemCanBeNullAttribute | Can be appplied to symbols of types derived from IEnumerable as well as to symbols of Task and Lazy classes to indicate that the value of a collection item, of the Task.Result property or of the Lazy.Value property can be null.
ItemNotNullAttribute | Can be appplied to symbols of types derived from IEnumerable as well as to symbols of Task and Lazy classes to indicate that the value of a collection item, of the Task.Result property or of the Lazy.Value property can never be null.
LinqTunnelAttribute | Indicates that method is pure LINQ method, with postponed enumeration (like Enumerable.Select, .Where). This annotation allows inference of [InstantHandle] annotation for parameters of delegate type by analyzing LINQ method chains.
ListViewGroupingSet`1 | Takes a list of groups and matching predicates to be used by the ApplyGroupingSet extension method.
LocalizationRequiredAttribute | Indicates that marked element should be localized or not.
MacroAttribute | Allows specifying a macro for a parameter of a <see cref="T:Vanara.Windows.Forms.Annotations.SourceTemplateAttribute">source template</see>.
MeansImplicitUseAttribute | Should be used on attributes and causes ReSharper to not mark symbols marked with such attributes as unused (as well as by other usage inspections)
MenuStripMRUManager | A class that manages a Most Recently Used file listing and interacts with a MenuStrip to display a menu list of the files. By default, the application settings are used to store the history. Optionally a constructor can be used to provide an alternate class to handle that work.
MRUManager | A class that manages a Most Recently Used file listing.
MustUseReturnValueAttribute | Indicates that the return value of method invocation must be used.
NoEnumerationAttribute | Indicates that IEnumerable, passed as parameter, is not enumerated.
NoReorder | Prevents the Member Reordering feature from tossing members of the marked class.
NotifyPropertyChangedInvocatorAttribute | Indicates that the method is contained in a type that implements <c>System.ComponentModel.INotifyPropertyChanged</c> interface and this method is used to notify that some property value changed.
NotNullAttribute | Indicates that the value of the marked element could never be <c>null</c>.
PaintAction`2 | 
PasswordValidatorEventArgs | Used by the `ValidatePassword` event.
PathReferenceAttribute | Indicates that a parameter is a path to a file or a folder within a web project. Path can be relative or absolute, starting from web root (~).
PreventShutdownContext | Used to define a set of operations within which any shutdown request will be met with a reason why this application is blocking it.
ProgressDialog | Multi-level, auto-sizing, progress dialog supporting asyncronous tasks. The background activities are provided as asyncronous methods who have a `CancellationToken` and an <see cref="T:System.IProgress`1" /> instance passed as parameters. The method uses the `CancellationToken` instance to determine if the user has pressed the "Cancel" button and the <see cref="M:System.IProgress`1.Report(`0)" /> method to report progress.
ProgressEventArgs | Updates progress on a `ProgressDialog`.
ProvidesContextAttribute | Indicates the type member or parameter of some type, that should be used instead of all other ways to get the value that type. This annotation is useful when you have some "context" value evaluated and stored somewhere, meaning that all other ways to get this value must be consolidated with existing one.
PublicAPIAttribute | This attribute is intended to mark publicly available API which should not be removed and so is treated as used.
PureAttribute | Indicates that a method does not make any observable state changes. The same as <c>System.Diagnostics.Contracts.PureAttribute</c>.
RazorDirectiveAttribute | 
RazorHelperCommonAttribute | 
RazorImportNamespaceAttribute | 
RazorInjectionAttribute | 
RazorLayoutAttribute | 
RazorSectionAttribute | Razor attribute. Indicates that a parameter or a method is a Razor section. Use this attribute for custom wrappers similar to <c>System.Web.WebPages.WebPageBase.RenderSection(String)</c>.
RazorWriteLiteralMethodAttribute | 
RazorWriteMethodAttribute | 
RazorWriteMethodParameterAttribute | 
RedirectedDesignerPropertyAttribute | 
RegexPatternAttribute | Indicates that parameter is regular expression pattern.
RegistryFileListStorage | 
ResourceFile | 
SmartBitmapLock | A self-disposing LockBits class for Bitmaps.
SourceTemplateAttribute | An extension method marked with this attribute is processed by ReSharper code completion as a 'Source Template'. When extension method is completed over some expression, it's source code is automatically expanded like a template at call site.
SplitMenuEventArgs | 
StringFormatMethodAttribute | Indicates that the marked method builds string by format pattern and (optional) arguments. Parameter, which contains format string, should be given in constructor. The format string should be in `String.Format(System.IFormatProvider,System.String,System.Object[])`-like form.
StringResIndexer | 
Style | 
TaskDialogProgressBar | 
TerminatesProgramAttribute | Indicates that the marked method unconditionally terminates control flow execution. For example, it could unconditionally throw exception.
ThemedLabel | A Label containing some text that will be drawn with glowing border on top of the Glass Sheet effect.
ThemedPanel | A panel that supports a glass overlay.
ThemedTableLayoutPanel | A table layout panel that supports a glass overlay.
TimerEventArgs | 
TrackBarEx | Extends the `TrackBar` class to provide full native-control functionality.
TranslateButtonStateDelegate | 
UsedImplicitlyAttribute | Indicates that the marked symbol is used implicitly (e.g. via reflection, in external library), so this symbol will not be marked as unused (as well as by other usage inspections).
ValueProviderAttribute | For a parameter that is expected to be one of the limited set of values. Specify fields of which type should be used as values for this parameter.
VerificationClickedEventArgs | 
VistaControlExtender | 
VisualTheme | 
XamlItemBindingOfItemsControlAttribute | XAML attribute. Indicates the property of some <c>BindingBase</c>-derived type, that is used to bind some item of <c>ItemsControl</c>-derived type. This annotation will enable the <c>DataContext</c> type resolve for XAML bindings for such properties.
XamlItemsControlAttribute | XAML attribute. Indicates the type that has <c>ItemsSource</c> property and should be treated as <c>ItemsControl</c>-derived type, to enable inner items <c>DataContext</c> type resolve.
### Structures
Struct | Description
---- | ----
ImageListDrawColor | Draw color with options for `ImageListExtension.Draw(System.Windows.Forms.ImageList,System.Drawing.Graphics,System.Drawing.Rectangle,System.Int32,Vanara.Extensions.ImageListExtension.ImageListDrawColor,Vanara.Extensions.ImageListExtension.ImageListDrawColor,Vanara.PInvoke.ComCtl32.IMAGELISTDRAWFLAGS,System.Int32)` method.
TaskDialogResult | 
### Enumerations
Enum | Description | Values
---- | ---- | ----
AssertionConditionType | Specifies assertion type. If the assertion method argument satisfies the condition, then the execution continues. Otherwise, execution is assumed to be halted. | IS_TRUE, IS_FALSE, IS_NULL, IS_NOT_NULL
CloakingSource | Use with GetWindowAttr and WindowAttribute.Cloaked. If the window is cloaked, provides one of the following values explaining why. | App, Shell, Inherited
CollapsiblePanelBorderCondition |  | Always, OnlyExpanded, Never
CollapsiblePanelHeaderState |  | Normal, Hot, Pressed, ExpandedNormal, ExpandedHot, ExpandedPressed, Disabled, ExpandedDisabled
CollectionAccessType |  | None, Read, ModifyExistingContent, UpdatedContent
ControlState |  | Hot, Pressed, Disabled, Animating, MouseDown, InButtonUp, Defaulted, Focused
Corners | Used to define which corners of `Rectangle` are effected by an operation. | None, TopLeft, TopRight, BottomLeft, BottomRight, All
Flip3DWindowPolicy | Flags used by the SetWindowAttr method to specify the Flip3D window policy. | Default, ExcludeBelow, ExcludeAbove
FolderBrowserDialogOptions |  | Folders, FoldersAndFiles, Computers, Printers
ImplicitUseKindFlags |  | Access, Assign, InstantiatedWithFixedConstructorSignature, Default, InstantiatedNoFixedConstructorSignature
ImplicitUseTargetFlags | Specify what is considered used implicitly when marked with `MeansImplicitUseAttribute` or `UsedImplicitlyAttribute`. | Default, Itself, Members, WithMembers
KnownFolders | Standard folders registered with the system as Known Folders. A computer will have only folders appropriate to it installed. | AccountPictures, AddNewPrograms, AdminTools, ApplicationShortcuts, AppsFolder, AppUpdates, CameraRoll, CDBurning, ChangeRemovePrograms, CommonAdminTools, CommonOEMLinks, CommonPrograms, CommonStartMenu, CommonStartup, CommonTemplates, ComputerFolder, ConflictFolder, ConnectionsFolder, Contacts, ControlPanelFolder, Cookies, Desktop, DeviceMetadataStore, Documents, DocumentsLibrary, Downloads, Favorites, Fonts, Games, GameTasks, History, HomeGroup, HomeGroupCurrentUser, ImplicitAppShortcuts, InternetCache, InternetFolder, Libraries, Links, LocalAppData, LocalAppDataLow, LocalizedResourcesDir, Music, MusicLibrary, NetHood, NetworkFolder, OriginalImages, PhotoAlbums, PicturesLibrary, Pictures, Playlists, PrintersFolder, PrintHood, Profile, ProgramData, ProgramFiles, ProgramFilesX64, ProgramFilesX86, ProgramFilesCommon, ProgramFilesCommonX64, ProgramFilesCommonX86, Programs, Public, PublicDesktop, PublicDocuments, PublicDownloads, PublicGameTasks, PublicLibraries, PublicMusic, PublicPictures, PublicRingtones, PublicUserTiles, PublicVideos, QuickLaunch, Recent, RecordedTVLibrary, RecycleBinFolder, ResourceDir, Ringtones, RoamingAppData, RoamedTileImages, RoamingTiles, SampleMusic, SamplePictures, SamplePlaylists, SampleVideos, SavedGames, SavedPictures, SavedPicturesLibrary, SavedSearches, Screenshots, OfflineFiles, SearchHistory, SearchHome, MicrosoftOfficeOutlook, SearchTemplates, SendTo, SidebarDefaultParts, SidebarParts, SkyDrive, SkyDriveCameraRoll, SkyDriveDocuments, SkyDrivePictures, StartMenu, Startup, SyncManagerFolder, SyncResultsFolder, SyncSetupFolder, System, SystemX86, Templates, UserPinned, UserProfiles, UserProgramFiles, UserProgramFilesCommon, UsersFiles, UsersLibraries, Videos, VideosLibrary, Windows, Undefined
NonClientRenderingPolicy | Flags used by the SetWindowAttr method to specify the non-client area rendering policy. | UseWindowStyle, Disabled, Enabled
ProgressBarState | Progress bar state. | Normal, Error, Paused
RenderStyle |  | SystemTheme, Custom
SecurityPageType | Values that indicate the types of property pages in an access control editor property sheet. | BasicPermissions, AdvancedPermissions, Audit, Owner, EffectiveRights, TakeOwnership, Share
SizeMode | Sizing mode for the CustomComboBox drop-down area. | UseComboSize, UseControlSize, UseDropDownSize
TaskDialogButtonDisplay | Indicates how buttons are displayed on a `TaskDialog`. | StandardButton, CommandLink, CommandLinkNoIcon
TaskDialogCommonButtons | The TaskDialog common button flags used to specify the built in buttons to show in the TaskDialog. | None, Ok, Yes, No, Cancel, Retry, Close
TaskDialogIcon | The System icons the TaskDialog supports. | None, ShieldGray, SecuritySuccess, SecurityError, SecurityWarning, ShieldBlue, Shield, Information, Error, Warning
