// Heavily leverages the work done by Microsoft on the control by the same name in WindowsVistaApiPack. Work was done to improve the
// designer experience, remove nested properties, add missing capabilities, simplify COM calls, align names to those in other mainstream
// controls, and use the Vanara libraries.

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Vanara.Extensions;
using Vanara.InteropServices;
using Vanara.PInvoke;
using Vanara.Windows.Shell;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.Shell32;
using static Vanara.PInvoke.ShlwApi;
using static Vanara.PInvoke.User32;
using IMessageFilter = System.Windows.Forms.IMessageFilter;
using IServiceProvider = Vanara.PInvoke.Shell32.IServiceProvider;

namespace Vanara.Windows.Forms
{
    /// <summary>
    /// Indicates the content options of the explorer browser. Typically use one, or a bitwise combination of these flags to specify how
    /// content should appear in the explorer browser control
    /// </summary>
    [Flags]
    public enum ExplorerBrowserContentSectionOptions : uint
    {
        /// <summary>No options.</summary>
        None = FOLDERFLAGS.FWF_NONE,

        /// <summary>The view should be left-aligned.</summary>
        AlignLeft = FOLDERFLAGS.FWF_ALIGNLEFT,

        /// <summary>Automatically arrange the elements in the view.</summary>
        AutoArrange = FOLDERFLAGS.FWF_AUTOARRANGE,

        /// <summary>Turns on check mode for the view</summary>
        CheckSelect = FOLDERFLAGS.FWF_CHECKSELECT,

        /// <summary>When the view is set to "Tile" the layout of a single item should be extended to the width of the view.</summary>
        ExtendedTiles = FOLDERFLAGS.FWF_EXTENDEDTILES,

        /// <summary>When an item is selected, the item and all its sub-items are highlighted.</summary>
        FullRowSelect = FOLDERFLAGS.FWF_FULLROWSELECT,

        /// <summary>The view should not display file names</summary>
        HideFileNames = FOLDERFLAGS.FWF_HIDEFILENAMES,

        /// <summary>The view should not save view state in the browser.</summary>
        NoBrowserViewState = FOLDERFLAGS.FWF_NOBROWSERVIEWSTATE,

        /// <summary>Do not display a column header in the view in any view mode.</summary>
        NoColumnHeader = FOLDERFLAGS.FWF_NOCOLUMNHEADER,

        /// <summary>Only show the column header in details view mode.</summary>
        NoHeaderInAllViews = FOLDERFLAGS.FWF_NOHEADERINALLVIEWS,

        /// <summary>The view should not display icons.</summary>
        NoIcons = FOLDERFLAGS.FWF_NOICONS,

        /// <summary>Do not show subfolders.</summary>
        NoSubfolders = FOLDERFLAGS.FWF_NOSUBFOLDERS,

        /// <summary>Navigate with a single click</summary>
        SingleClickActivate = FOLDERFLAGS.FWF_SINGLECLICKACTIVATE,

        /// <summary>Do not allow more than a single item to be selected.</summary>
        SingleSelection = FOLDERFLAGS.FWF_SINGLESEL,

        /// <summary>
        /// Make the folder behave like the desktop. This value applies only to the desktop and is not used for typical Shell folders.
        /// </summary>
        Desktop = FOLDERFLAGS.FWF_DESKTOP,

        /// <summary>Draw transparently. This is used only for the desktop.</summary>
        Transparent = FOLDERFLAGS.FWF_TRANSPARENT,

        /// <summary>Do not add scroll bars. This is used only for the desktop.</summary>
        NoScrollBars = FOLDERFLAGS.FWF_NOSCROLL,

        /// <summary>The view should not be shown as a web view.</summary>
        NoWebView = FOLDERFLAGS.FWF_NOWEBVIEW,

        /// <summary>
        /// Windows Vista and later. Do not re-enumerate the view (or drop the current contents of the view) when the view is refreshed.
        /// </summary>
        NoEnumOnRefresh = FOLDERFLAGS.FWF_NOENUMREFRESH,

        /// <summary>Windows Vista and later. Do not allow grouping in the view</summary>
        NoGrouping = FOLDERFLAGS.FWF_NOGROUPING,

        /// <summary>Windows Vista and later. Do not display filters in the view.</summary>
        NoFilters = FOLDERFLAGS.FWF_NOFILTERS,

        /// <summary>Windows Vista and later. Items can be selected using check-boxes.</summary>
        AutoCheckSelect = FOLDERFLAGS.FWF_AUTOCHECKSELECT,

        /// <summary>Windows Vista and later. The view should list the number of items displayed in each group. To be used with IFolderView2::SetGroupSubsetCount.</summary>
        SubsetGroup = FOLDERFLAGS.FWF_SUBSETGROUPS,

        /// <summary>Windows Vista and later. Use the search folder for stacking and searching.</summary>
        UseSearchFolder = FOLDERFLAGS.FWF_USESEARCHFOLDER,

        /// <summary>
        /// Windows Vista and later. Ensure right-to-left reading layout in a right-to-left system. Without this flag, the view displays
        /// strings from left-to-right both on systems set to left-to-right and right-to-left reading layout, which ensures that file names
        /// display correctly.
        /// </summary>
        AllowRtlReading = FOLDERFLAGS.FWF_ALLOWRTLREADING,
    }

    /// <summary>These flags are used with <see cref="ExplorerBrowser.LoadCustomItems"/>.</summary>
    [Flags]
    public enum ExplorerBrowserLoadFlags
    {
        /// <summary>No flags.</summary>
        None = EXPLORER_BROWSER_FILL_FLAGS.EBF_NONE,

        /// <summary>
        /// Causes <see cref="ExplorerBrowser.LoadCustomItems"/> to first populate the results folder with the contents of the parent
        /// folders of the items in the data object, and then select only the items that are in the data object.
        /// </summary>
        SelectFromDataObject = EXPLORER_BROWSER_FILL_FLAGS.EBF_SELECTFROMDATAOBJECT,

        /// <summary>
        /// Do not allow dropping on the folder. In other words, do not register a drop target for the view. Applications can then register
        /// their own drop targets.
        /// </summary>
        NoDropTarget = EXPLORER_BROWSER_FILL_FLAGS.EBF_NODROPTARGET,
    }

    /// <summary>
    /// Specifies the options that control subsequent navigation. Typically use one, or a bitwise combination of these flags to specify how
    /// the explorer browser navigates.
    /// </summary>
    [Flags]
    public enum ExplorerBrowserNavigateOptions
    {
        /// <summary>No options.</summary>
        None = EXPLORER_BROWSER_OPTIONS.EBO_NONE,

        /// <summary>Always navigate, even if you are attempting to navigate to the current folder.</summary>
        AlwaysNavigate = EXPLORER_BROWSER_OPTIONS.EBO_ALWAYSNAVIGATE,

        /// <summary>Do not navigate further than the initial navigation.</summary>
        NavigateOnce = EXPLORER_BROWSER_OPTIONS.EBO_NAVIGATEONCE,

        /// <summary>
        /// Use the following standard panes: Commands Module pane, Navigation pane, Details pane, and Preview pane. An implementer of
        /// IExplorerPaneVisibility can modify the components of the Commands Module that are shown. For more information see,
        /// IExplorerPaneVisibility::GetPaneState. If EBO_SHOWFRAMES is not set, Explorer browser uses a single view object.
        /// </summary>
        ShowFrames = EXPLORER_BROWSER_OPTIONS.EBO_SHOWFRAMES,

        /// <summary>Do not update the travel log.</summary>
        NoTravelLog = EXPLORER_BROWSER_OPTIONS.EBO_NOTRAVELLOG,

        /// <summary>Do not use a wrapper window. This flag is used with legacy clients that need the browser parented directly on themselves.</summary>
        NoWrapperWindow = EXPLORER_BROWSER_OPTIONS.EBO_NOWRAPPERWINDOW,

        /// <summary>Show WebView for SharePoint sites.</summary>
        HtmlSharePointView = EXPLORER_BROWSER_OPTIONS.EBO_HTMLSHAREPOINTVIEW,

        /// <summary>Introduced in Windows Vista. Do not draw a border around the browser window.</summary>
        NoBorder = EXPLORER_BROWSER_OPTIONS.EBO_NOBORDER,

        /// <summary>Introduced in Windows Vista. Do not persist the view state.</summary>
        NoPersistViewState = EXPLORER_BROWSER_OPTIONS.EBO_NOPERSISTVIEWSTATE,
    }

    /// <summary>Flags specifying the folder to be browsed.</summary>
    [Flags]
    public enum ExplorerBrowserNavigationItemCategory : uint
    {
        /// <summary>An absolute PIDL, relative to the desktop.</summary>
        Absolute = SBSP.SBSP_ABSOLUTE,

        /// <summary>Windows Vista and later. Navigate without the default behavior of setting focus into the new view.</summary>
        ActivateNoFocus = SBSP.SBSP_ACTIVATE_NOFOCUS,

        /// <summary>Enable auto-navigation.</summary>
        AllowAutoNavigate = SBSP.SBSP_ALLOW_AUTONAVIGATE,

        /// <summary>
        /// Microsoft Internet Explorer 6 Service Pack 2 (SP2) and later. The navigation was possibly initiated by a web page with scripting
        /// code already present on the local system.
        /// </summary>
        CallerUntrusted = SBSP.SBSP_CALLERUNTRUSTED,

        /// <summary>
        /// Windows 7 and later. Do not add a new entry to the travel log. When the user enters a search term in the search box and
        /// subsequently refines the query, the browser navigates forward but does not add an additional travel log entry.
        /// </summary>
        CreateNoHistory = SBSP.SBSP_CREATENOHISTORY,

        /// <summary>
        /// Use default behavior, which respects the view option (the user setting to create new windows or to browse in place). In most
        /// cases, calling applications should use this flag.
        /// </summary>
        Default = SBSP.SBSP_DEFBROWSER,

        /// <summary>Use the current window.</summary>
        UseCurrentWindow = SBSP.SBSP_DEFMODE,

        /// <summary>
        /// Specifies a folder tree for the new browse window. If the current browser does not match the SBSP.SBSP_EXPLOREMODE of the browse
        /// object call, a new window is opened.
        /// </summary>
        ExploreMode = SBSP.SBSP_EXPLOREMODE,

        /// <summary>
        /// Windows Internet Explorer 7 and later. If allowed by current registry settings, give the browser a destination to navigate to.
        /// </summary>
        FeedNavigation = SBSP.SBSP_FEEDNAVIGATION,

        /// <summary>Windows Vista and later. Navigate without clearing the search entry field.</summary>
        KeepSearchText = SBSP.SBSP_KEEPWORDWHEELTEXT,

        /// <summary>Navigate back, ignore the PIDL.</summary>
        NavigateBack = SBSP.SBSP_NAVIGATEBACK,

        /// <summary>Navigate forward, ignore the PIDL.</summary>
        NavigateForward = SBSP.SBSP_NAVIGATEFORWARD,

        /// <summary>Creates another window for the specified folder.</summary>
        NewWindow = SBSP.SBSP_NEWBROWSER,

        /// <summary>Suppress selection in the history pane.</summary>
        NoHistorySelect = SBSP.SBSP_NOAUTOSELECT,

        /// <summary>Do not transfer the browsing history to the new window.</summary>
        NoTransferHistory = SBSP.SBSP_NOTRANSFERHIST,

        /// <summary>
        /// Specifies no folder tree for the new browse window. If the current browser does not match the SBSP.SBSP_OPENMODE of the browse
        /// object call, a new window is opened.
        /// </summary>
        NoFolderTree = SBSP.SBSP_OPENMODE,

        /// <summary>Browse the parent folder, ignore the PIDL.</summary>
        ParentFolder = SBSP.SBSP_PARENT,

        /// <summary>Windows 7 and later. Do not make the navigation complete sound for each keystroke in the search box.</summary>
        PlayNoSound = SBSP.SBSP_PLAYNOSOUND,

        /// <summary>Enables redirection to another URL.</summary>
        Redirect = SBSP.SBSP_REDIRECT,

        /// <summary>A relative PIDL, relative to the current folder.</summary>
        Relative = SBSP.SBSP_RELATIVE,

        /// <summary>Browse to another folder with the same Windows Explorer window.</summary>
        SameWindow = SBSP.SBSP_SAMEBROWSER,

        /// <summary>Microsoft Internet Explorer 6 Service Pack 2 (SP2) and later. The navigate should allow ActiveX prompts.</summary>
        TrustedForActiveX = SBSP.SBSP_TRUSTEDFORACTIVEX,

        /// <summary>
        /// Microsoft Internet Explorer 6 Service Pack 2 (SP2) and later. The new window is the result of a user initiated action. Trust the
        /// new window if it immediately attempts to download content.
        /// </summary>
        TrustFirstDownload = SBSP.SBSP_TRUSTFIRSTDOWNLOAD,

        /// <summary>
        /// Microsoft Internet Explorer 6 Service Pack 2 (SP2) and later. The window is navigating to an untrusted, non-HTML file. If the
        /// user attempts to download the file, do not allow the download.
        /// </summary>
        UntrustedForDownload = SBSP.SBSP_UNTRUSTEDFORDOWNLOAD,

        /// <summary>Write no history of this navigation in the history Shell folder.</summary>
        WriteNoHistory = SBSP.SBSP_WRITENOHISTORY
    }

    /// <summary>Indicates the viewing mode of the explorer browser</summary>
    public enum ExplorerBrowserViewMode
    {
        /// <summary>Choose the best view mode for the folder</summary>
        Auto = FOLDERVIEWMODE.FVM_AUTO,

        /// <summary>(New for Windows7)</summary>
        Content = FOLDERVIEWMODE.FVM_CONTENT,

        /// <summary>Object names and other selected information, such as the size or date last updated, are shown.</summary>
        Details = FOLDERVIEWMODE.FVM_DETAILS,

        /// <summary>The view should display medium-size icons.</summary>
        Icon = FOLDERVIEWMODE.FVM_ICON,

        /// <summary>Object names are displayed in a list view.</summary>
        List = FOLDERVIEWMODE.FVM_LIST,

        /// <summary>The view should display small icons.</summary>
        SmallIcon = FOLDERVIEWMODE.FVM_SMALLICON,

        /// <summary>The view should display thumbnail icons.</summary>
        Thumbnail = FOLDERVIEWMODE.FVM_THUMBNAIL,

        /// <summary>The view should display icons in a filmstrip format.</summary>
        ThumbStrip = FOLDERVIEWMODE.FVM_THUMBSTRIP,

        /// <summary>The view should display large icons.</summary>
        Tile = FOLDERVIEWMODE.FVM_TILE
    }

    /// <summary>Indicates the visibility state of an ExplorerBrowser pane.</summary>
    public enum PaneVisibilityState
    {
        /// <summary>Allow the explorer browser to determine if this pane is displayed.</summary>
        Default = EXPLORERPANESTATE.EPS_DONTCARE,

        /// <summary>Hide the pane</summary>
        Hide = EXPLORERPANESTATE.EPS_DEFAULT_OFF | EXPLORERPANESTATE.EPS_FORCE,

        /// <summary>Show the pane</summary>
        Show = EXPLORERPANESTATE.EPS_DEFAULT_ON | EXPLORERPANESTATE.EPS_FORCE
    }

    /// <summary>
    /// <c>ExplorerBrowser</c> is a browser object that can be either navigated or that can host a view of a data object. As a full-featured
    /// browser object, it also supports an automatic travel log.
    /// </summary>
    /// <seealso cref="Control"/>
    /// <seealso cref="IServiceProvider"/>
    /// <seealso cref="IExplorerPaneVisibility"/>
    /// <seealso cref="IExplorerBrowserEvents"/>
    /// <seealso cref="ICommDlgBrowser3"/>
    /// <seealso cref="IMessageFilter"/>
    [Designer(typeof(Design.ExplorerBrowserDesigner)), DefaultProperty(nameof(Name)), DefaultEvent(nameof(SelectionChanged))]
    [ToolboxItem(true), ToolboxBitmap(typeof(ExplorerBrowser), "ExplorerBrowser.bmp")]
    [Description("A Shell browser object that can be either navigated or that can host a view of a data object.")]
    [ComVisible(true), Guid("01103386-B66B-4AFB-AF50-78AED6E562DA")]
    public class ExplorerBrowser : Control, ICommDlgBrowser3, IExplorerBrowserEvents, IExplorerPaneVisibility, IMessageFilter, IServiceProvider
    {
        internal uint eventsCookie;
        internal IExplorerBrowser explorerBrowserControl;
        internal FOLDERSETTINGS folderSettings = new FOLDERSETTINGS(FOLDERVIEWMODE.FVM_AUTO, defaultFolderFlags);

        private const FOLDERFLAGS defaultFolderFlags = FOLDERFLAGS.FWF_USESEARCHFOLDER | FOLDERFLAGS.FWF_NOWEBVIEW;
        private const int defaultThumbnailSize = 32;
        private const int HRESULT_CANCELLED = unchecked((int)0x800704C7);
        private const int HRESULT_RESOURCE_IN_USE = unchecked((int)0x800700AA);

        private static readonly string defaultPropBagName = typeof(ExplorerBrowser).FullName;
        private static readonly Guid IID_ICommDlgBrowser = typeof(ICommDlgBrowser).GUID;

        private readonly IContainer components = null;
        private (ShellItem item, ExplorerBrowserNavigationItemCategory category) antecreationNavigationTarget;
        private EXPLORER_BROWSER_OPTIONS options = EXPLORER_BROWSER_OPTIONS.EBO_SHOWFRAMES;
        private string propertyBagName = defaultPropBagName;
        private int thumbnailSize = defaultThumbnailSize;
        private ViewEvents viewEvents;

        /// <summary>Initializes a new instance of the <see cref="ExplorerBrowser"/> class.</summary>
        public ExplorerBrowser()
        {
            components = new Container();
            //AutoScaleMode = AutoScaleMode.Font;

            History = new NavigationLog(this);
            Items = new ShellItemCollection(this, SVGIO.SVGIO_ALLVIEW);
            SelectedItems = new ShellItemCollection(this, SVGIO.SVGIO_SELECTION);
        }

        /// <summary>Fires when the Items collection changes.</summary>
        [Category("Action"), Description("Items changed.")]
        public event EventHandler ItemsChanged;

        /// <summary>Fires when the ExplorerBorwser view has finished enumerating files.</summary>
        [Category("Behavior"), Description("View is done enumerating files.")]
        public event EventHandler ItemsEnumerated;

        /// <summary>
        /// Fires when a navigation has been 'completed': no Navigating listener has canceled, and the ExplorerBorwser has created a new
        /// view. The view will be populated with new items asynchronously, and ItemsChanged will be fired to reflect this some time later.
        /// </summary>
        [Category("Action"), Description("Navigation complete.")]
        public event EventHandler<NavigatedEventArgs> Navigated;

        /// <summary>Fires when a navigation has been initiated, but is not yet complete.</summary>
        [Category("Action"), Description("Navigation initiated, but not complete.")]
        public event EventHandler<NavigatingEventArgs> Navigating;

        /// <summary>
        /// Fires when either a Navigating listener cancels the navigation, or if the operating system determines that navigation is not possible.
        /// </summary>
        [Category("Action"), Description("Navigation failed.")]
        public event EventHandler<NavigationFailedEventArgs> NavigationFailed;

        /// <summary>Fires when the item selected in the view has changed (i.e., a rename ). This is not the same as SelectionChanged.</summary>
        [Category("Action"), Description("Selected item has changed.")]
        public event EventHandler SelectedItemModified;

        /// <summary>Fires when the SelectedItems collection changes.</summary>
        [Category("Behavior"), Description("Selection changed.")]
        public event EventHandler SelectionChanged;

        // *** The implementation in Shell32 uses MSG which has proven to be slow. This passes the Message structure directly. ***
        [ComImport, Guid("68284fAA-6A48-11D0-8c78-00C04fd918b4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IInputObject_WinForms
        {
            [PreserveSig]
            HRESULT UIActivateIO([In, MarshalAs(UnmanagedType.Bool)] bool fActivate, in Message pMsg);

            [PreserveSig]
            HRESULT HasFocusIO();

            [PreserveSig]
            HRESULT TranslateAcceleratorIO(in Message pMsg);
        }

        /// <summary>The view should be left-aligned.</summary>
        [Browsable(false), DefaultValue(false), Category("Appearance"), Description("The view should be left-aligned.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool AlignLeft
        {
            get => IsContentFlagSet(ExplorerBrowserContentSectionOptions.AlignLeft);
            set => SetContentFlag(ExplorerBrowserContentSectionOptions.AlignLeft, value);
        }

        /// <summary>
        /// Ensure right-to-left reading layout in a right-to-left system. Without this flag, the view displays strings from left-to-right
        /// both on systems set to left-to-right and right-to-left reading layout, which ensures that file names display correctly.
        /// </summary>
        [Browsable(false), DefaultValue(false), Category("Appearance"), Description("Ensure right-to-left reading layout in a right-to-left system.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool AllowRtlReading
        {
            get => IsContentFlagSet(ExplorerBrowserContentSectionOptions.AllowRtlReading);
            set => SetContentFlag(ExplorerBrowserContentSectionOptions.AllowRtlReading, value);
        }

        /// <summary>Always navigate, even if you are attempting to navigate to the current folder.</summary>
        [DefaultValue(false), Category("Behavior"), Description("Always navigate, even if you are attempting to navigate to the current folder.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool AlwaysNavigate
        {
            get => IsNavFlagSet(ExplorerBrowserNavigateOptions.AlwaysNavigate);
            set => SetNavFlag(ExplorerBrowserNavigateOptions.AlwaysNavigate, value);
        }

        /// <summary>Automatically arrange the elements in the view.</summary>
        [DefaultValue(false), Category("Behavior"), Description("Automatically arrange the elements in the view.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool AutoArrange
        {
            get => IsContentFlagSet(ExplorerBrowserContentSectionOptions.AutoArrange);
            set => SetContentFlag(ExplorerBrowserContentSectionOptions.AutoArrange, value);
        }

        /// <summary>Items can be selected using check-boxes.</summary>
        [DefaultValue(false), Category("Behavior"), Description("Items can be selected using check-boxes.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool AutoCheckSelect
        {
            get => IsContentFlagSet(ExplorerBrowserContentSectionOptions.AutoCheckSelect);
            set => SetContentFlag(ExplorerBrowserContentSectionOptions.AutoCheckSelect, value);
        }

        /// <summary>Turns on check mode for the view</summary>
        [DefaultValue(false), Category("Behavior"), Description("Turns on check mode for the view")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool CheckSelect
        {
            get => IsContentFlagSet(ExplorerBrowserContentSectionOptions.CheckSelect);
            set => SetContentFlag(ExplorerBrowserContentSectionOptions.CheckSelect, value);
        }

        /// <summary>The binary representation of the ExplorerBrowser content flags</summary>
        [Browsable(false), DefaultValue(0), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ExplorerBrowserContentSectionOptions ContentFlags
        {
            get => (ExplorerBrowserContentSectionOptions)folderSettings.fFlags;
            set
            {
                folderSettings.fFlags = (FOLDERFLAGS)value | defaultFolderFlags;
                explorerBrowserControl?.SetFolderSettings(folderSettings);
            }
        }

        /// <summary>Make the folder behave like the desktop. This applies only to the desktop and is not used for typical Shell folders.</summary>
        [Browsable(false), DefaultValue(false), Category("Appearance"), Description("Make the folder behave like the desktop.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Desktop
        {
            get => IsContentFlagSet(ExplorerBrowserContentSectionOptions.Desktop);
            set => SetContentFlag(ExplorerBrowserContentSectionOptions.Desktop, value);
        }

        /// <summary>When the view is in "tile view mode" the layout of a single item should be extended to the width of the view.</summary>
        [DefaultValue(false), Category("Appearance"), Description("The layout of a single item should be extended to the width of the view.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ExtendedTiles
        {
            get => IsContentFlagSet(ExplorerBrowserContentSectionOptions.ExtendedTiles);
            set => SetContentFlag(ExplorerBrowserContentSectionOptions.ExtendedTiles, value);
        }

        /// <summary>When an item is selected, the item and all its sub-items are highlighted.</summary>
        [DefaultValue(false), Category("Behavior"), Description("When an item is selected, the item and all its sub-items are highlighted.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool FullRowSelect
        {
            get => IsContentFlagSet(ExplorerBrowserContentSectionOptions.FullRowSelect);
            set => SetContentFlag(ExplorerBrowserContentSectionOptions.FullRowSelect, value);
        }

        /// <summary>The view should not display file names</summary>
        [DefaultValue(false), Category("Appearance"), Description("The view should not display file names")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HideFileNames
        {
            get => IsContentFlagSet(ExplorerBrowserContentSectionOptions.HideFileNames);
            set => SetContentFlag(ExplorerBrowserContentSectionOptions.HideFileNames, value);
        }

        /// <summary>Contains the navigation history of the ExplorerBrowser</summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public NavigationLog History { get; }

        /// <summary>The set of ShellItems in the Explorer Browser</summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IReadOnlyList<ShellItem> Items { get; }

        /// <summary>Do not navigate further than the initial navigation.</summary>
        [DefaultValue(false), Category("Behavior"), Description("Do not navigate further than the initial navigation.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool NavigateOnce
        {
            get => IsNavFlagSet(ExplorerBrowserNavigateOptions.NavigateOnce);
            set => SetNavFlag(ExplorerBrowserNavigateOptions.NavigateOnce, value);
        }

        /// <summary>The binary flags that are passed to the explorer browser control's GetOptions/SetOptions methods</summary>
        [Browsable(false), DefaultValue(0), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ExplorerBrowserNavigateOptions NavigationFlags
        {
            get
            {
                explorerBrowserControl?.GetOptions(out options);
                return (ExplorerBrowserNavigateOptions)options;
            }
            // Always forcing SHOWFRAMES because we handle IExplorerPaneVisibility
            set => explorerBrowserControl?.SetOptions(options = (EXPLORER_BROWSER_OPTIONS)value | EXPLORER_BROWSER_OPTIONS.EBO_SHOWFRAMES);
        }

        /// <summary>The view should not save view state in the browser.</summary>
        [DefaultValue(false), Category("Behavior"), Description("The view should not save view state in the browser.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool NoBrowserViewState
        {
            get => IsContentFlagSet(ExplorerBrowserContentSectionOptions.NoBrowserViewState);
            set => SetContentFlag(ExplorerBrowserContentSectionOptions.NoBrowserViewState, value);
        }

        /// <summary>Do not display a column header in the view in any view mode.</summary>
        [DefaultValue(false), Category("Appearance"), Description("Do not display a column header in the view in any view mode.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool NoColumnHeader
        {
            get => IsContentFlagSet(ExplorerBrowserContentSectionOptions.NoColumnHeader);
            set => SetContentFlag(ExplorerBrowserContentSectionOptions.NoColumnHeader, value);
        }

        /// <summary>Do not re-enumerate the view (or drop the current contents of the view) when the view is refreshed.</summary>
        [DefaultValue(false), Category("Behavior"), Description("Do not re-enumerate the view (or drop the current contents of the view) when the view is refreshed.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool NoEnumOnRefresh
        {
            get => IsContentFlagSet(ExplorerBrowserContentSectionOptions.NoEnumOnRefresh);
            set => SetContentFlag(ExplorerBrowserContentSectionOptions.NoEnumOnRefresh, value);
        }

        /// <summary>Do not display filters in the view.</summary>
        [DefaultValue(false), Category("Appearance"), Description("Do not display filters in the view.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool NoFilters
        {
            get => IsContentFlagSet(ExplorerBrowserContentSectionOptions.NoFilters);
            set => SetContentFlag(ExplorerBrowserContentSectionOptions.NoFilters, value);
        }

        /// <summary>Do not allow grouping in the view.</summary>
        [DefaultValue(false), Category("Appearance"), Description("Do not allow grouping in the view.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool NoGrouping
        {
            get => IsContentFlagSet(ExplorerBrowserContentSectionOptions.NoGrouping);
            set => SetContentFlag(ExplorerBrowserContentSectionOptions.NoGrouping, value);
        }

        /// <summary>Only show the column header in details view mode.</summary>
        [DefaultValue(false), Category("Appearance"), Description("Only show the column header in details view mode.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool NoHeaderInAllViews
        {
            get => IsContentFlagSet(ExplorerBrowserContentSectionOptions.NoHeaderInAllViews);
            set => SetContentFlag(ExplorerBrowserContentSectionOptions.NoHeaderInAllViews, value);
        }

        /// <summary>The view should not display icons.</summary>
        [DefaultValue(false), Category("Appearance"), Description("The view should not display icons.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool NoIcons
        {
            get => IsContentFlagSet(ExplorerBrowserContentSectionOptions.NoIcons);
            set => SetContentFlag(ExplorerBrowserContentSectionOptions.NoIcons, value);
        }

        /// <summary>Introduced in Windows Vista. Do not persist the view state.</summary>
        [DefaultValue(false), Category("Behavior"), Description("Do not persist the view state.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool NoPersistViewState
        {
            get => IsNavFlagSet(ExplorerBrowserNavigateOptions.NoPersistViewState);
            set => SetNavFlag(ExplorerBrowserNavigateOptions.NoPersistViewState, value);
        }

        /// <summary>Do not add scroll bars. This is used only for the desktop.</summary>
        [Browsable(false), DefaultValue(false), Category("Appearance"), Description("Do not add scroll bars.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool NoScrollBars
        {
            get => IsContentFlagSet(ExplorerBrowserContentSectionOptions.NoScrollBars);
            set => SetContentFlag(ExplorerBrowserContentSectionOptions.NoScrollBars, value);
        }

        /// <summary>Do not show subfolders.</summary>
        [DefaultValue(false), Category("Appearance"), Description("Do not show subfolders.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool NoSubfolders
        {
            get => IsContentFlagSet(ExplorerBrowserContentSectionOptions.NoSubfolders);
            set => SetContentFlag(ExplorerBrowserContentSectionOptions.NoSubfolders, value);
        }

        /// <summary>Do not update the travel log.</summary>
        [DefaultValue(false), Category("Behavior"), Description("Do not update the travel log.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool NoTravelLog
        {
            get => IsNavFlagSet(ExplorerBrowserNavigateOptions.NoTravelLog);
            set => SetNavFlag(ExplorerBrowserNavigateOptions.NoTravelLog, value);
        }

        /// <summary>Do not use a wrapper window. This flag is used with legacy clients that need the browser parented directly on themselves.</summary>
        [Browsable(false), DefaultValue(false), Category("Behavior"), Description("Do not use a wrapper window.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool NoWrapperWindow
        {
            get => IsNavFlagSet(ExplorerBrowserNavigateOptions.NoWrapperWindow);
            set => SetNavFlag(ExplorerBrowserNavigateOptions.NoWrapperWindow, value);
        }

        /// <summary>Controls the visibility of the various ExplorerBrowser panes on subsequent navigation</summary>
        [Category("Appearance"), Description("Set visibility of child panes.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ExplorerBrowserPaneVisibility PaneVisibility { get; } = new ExplorerBrowserPaneVisibility();

        /// <summary>The name of the property bag used to persist changes to the ExplorerBrowser's view state.</summary>
        [Browsable(false), Category("Data"), Description("Name of the property bag used to persist changes to the ExplorerBrowser's view state")]
        public string PropertyBagName
        {
            get => propertyBagName;
            set { propertyBagName = value; explorerBrowserControl?.SetPropertyBag(propertyBagName); }
        }

        /// <summary>The set of selected ShellItems in the Explorer Browser</summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IReadOnlyList<ShellItem> SelectedItems { get; }

        /// <summary>Navigate with a single click.</summary>
        [DefaultValue(false), Category("Behavior"), Description("Navigate with a single click.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool SingleClickActivate
        {
            get => IsContentFlagSet(ExplorerBrowserContentSectionOptions.SingleClickActivate);
            set => SetContentFlag(ExplorerBrowserContentSectionOptions.SingleClickActivate, value);
        }

        /// <summary>Do not allow more than a single item to be selected.</summary>
        [DefaultValue(false), Category("Behavior"), Description("Do not allow more than a single item to be selected.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool SingleSelection
        {
            get => IsContentFlagSet(ExplorerBrowserContentSectionOptions.SingleSelection);
            set => SetContentFlag(ExplorerBrowserContentSectionOptions.SingleSelection, value);
        }

        /// <summary>The view should list the number of items displayed in each group.</summary>
        [DefaultValue(false), Category("Appearance"), Description("The view should list the number of items displayed in each group.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool SubsetGroup
        {
            get => IsContentFlagSet(ExplorerBrowserContentSectionOptions.SubsetGroup);
            set => SetContentFlag(ExplorerBrowserContentSectionOptions.SubsetGroup, value);
        }

        /// <summary>The size of the thumbnails in pixels.</summary>
        [Category("Appearance"), DefaultValue(defaultThumbnailSize), Description("The size of the thumbnails in pixels.")]
        public int ThumbnailSize
        {
            get
            {
                using var fv2 = ComReleaserFactory.Create(GetFolderView2());
                fv2.Item?.GetViewModeAndIconSize(out _, out thumbnailSize);
                return thumbnailSize;
            }
            set
            {
                using var fv2 = ComReleaserFactory.Create(GetFolderView2());
                if (fv2.Item is null) return;
                fv2.Item.GetViewModeAndIconSize(out var fvm, out _);
                fv2.Item.SetViewModeAndIconSize(fvm, thumbnailSize = value);
            }
        }

        /// <summary>Draw transparently. This is used only for the desktop.</summary>
        [Browsable(false), DefaultValue(false), Category("Appearance"), Description("Draw transparently.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Transparent
        {
            get => IsContentFlagSet(ExplorerBrowserContentSectionOptions.Transparent);
            set => SetContentFlag(ExplorerBrowserContentSectionOptions.Transparent, value);
        }

        /// <summary>Show WebView for SharePoint sites.</summary>
        [Browsable(false), DefaultValue(false), Category("Behavior"), Description("Show WebView for SharePoint sites.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool UseHtmlSharePointView
        {
            get => IsNavFlagSet(ExplorerBrowserNavigateOptions.HtmlSharePointView);
            set => SetNavFlag(ExplorerBrowserNavigateOptions.HtmlSharePointView, value);
        }

        /// <summary>The viewing mode of the Explorer Browser</summary>
        [DefaultValue(typeof(ExplorerBrowserViewMode), "Auto"), Category("Appearance"), Description("The viewing mode of the Explorer Browser.")]
        public ExplorerBrowserViewMode ViewMode
        {
            get => (ExplorerBrowserViewMode)folderSettings.ViewMode;
            set
            {
                folderSettings.ViewMode = (FOLDERVIEWMODE)value;
                explorerBrowserControl?.SetFolderSettings(folderSettings);
            }
        }

        /// <inheritdoc/>
        protected override Size DefaultSize => new Size(200, 150);

        /// <summary>Removes all items from the results folder.</summary>
        public void ClearCustomItems() => explorerBrowserControl?.RemoveAll();

        /// <summary>
        /// Exposes the underlying interfaces for the control. Using this interface directly to call methods will result in unexpected
        /// results with the control and can cause instability.
        /// </summary>
        /// <returns>The <see cref="IExplorerBrowser"/> instance used by this control.</returns>
        public IExplorerBrowser DangerousGetInterface() => explorerBrowserControl;

        /// <summary>Creates a custom folder and fills it with items.</summary>
        /// <param name="obj">
        /// An interface pointer on the source object that will fill the control. This can be an <see cref="IDataObject"/> or any object
        /// that can be used with <see cref="INamespaceWalk"/>.
        /// </param>
        /// <param name="flags">One of the <see cref="ExplorerBrowserLoadFlags"/> values.</param>
        public void LoadCustomItems(object obj, ExplorerBrowserLoadFlags flags = ExplorerBrowserLoadFlags.None) => explorerBrowserControl?.FillFromObject(obj, (EXPLORER_BROWSER_FILL_FLAGS)flags);

        /// <summary>
        /// Clears the Explorer Browser of existing content, fills it with content from the specified container, and adds a new point to the
        /// Travel Log.
        /// </summary>
        /// <param name="shellItem">The shell container to navigate to.</param>
        /// <param name="category">The category of the <paramref name="shellItem"/>.</param>
        public void Navigate(ShellItem shellItem, ExplorerBrowserNavigationItemCategory category = ExplorerBrowserNavigationItemCategory.Default)
        {
            if (explorerBrowserControl is null)
            {
                antecreationNavigationTarget = (shellItem, category);
            }
            else
            {
                var hr = explorerBrowserControl.BrowseToObject(shellItem?.IShellItem, (SBSP)category);
                if (hr == HRESULT_RESOURCE_IN_USE || hr == HRESULT_CANCELLED)
                    OnNavigationFailed(new NavigationFailedEventArgs { FailedLocation = shellItem });
                else if (hr.Failed)
                    throw new ArgumentException("Unable to browse to this shell item.", nameof(shellItem), hr.GetException());
            }
        }

        /// <summary>
        /// Navigates to the last item in the navigation history list. This does not change the set of locations in the navigation log.
        /// </summary>
        public bool NavigateBack() { if (History.CanNavigateBackward) { Navigate(null, ExplorerBrowserNavigationItemCategory.NavigateBack); return true; } return false; }

        /// <summary>
        /// Navigates to the next item in the navigation history list. This does not change the set of locations in the navigation log.
        /// </summary>
        /// <returns>True if the navigation succeeded, false if it failed for any reason.</returns>
        public bool NavigateForward() { if (History.CanNavigateForward) { Navigate(null, ExplorerBrowserNavigationItemCategory.NavigateForward); return true; } return false; }

        /// <summary>
        /// Navigate within the navigation log in a specific direciton. This does not change the set of locations in the navigation log.
        /// </summary>
        /// <param name="direction">The direction to navigate within the navigation logs collection.</param>
        /// <returns>True if the navigation succeeded, false if it failed for any reason.</returns>
        public bool NavigateFromHistory(NavigationLogDirection direction) => History.NavigateLog(direction);

        /// <summary>Navigate within the navigation log. This does not change the set of locations in the navigation log.</summary>
        /// <param name="historyIndex">An index into the navigation logs Locations collection.</param>
        /// <returns>True if the navigation succeeded, false if it failed for any reason.</returns>
        public bool NavigateToHistoryIndex(int historyIndex) => History.NavigateLog(historyIndex);

        /// <summary>Selects all items in the current view.</summary>
        public void SelectAll()
        {
            using var fv2 = ComReleaserFactory.Create(GetFolderView2());
            if (fv2.Item is null) return;
            for (var i = 0; i < fv2.Item.ItemCount(SVGIO.SVGIO_ALLVIEW); i++)
                fv2.Item.SelectItem(i, SVSIF.SVSI_SELECT);
        }

        /// <summary>Unselects all items in the current view.</summary>
        public void UnselectAll()
        {
            using var fv2 = ComReleaserFactory.Create(GetFolderView2());
            fv2.Item?.SelectItem(-1, SVSIF.SVSI_DESELECTOTHERS);
        }

        HRESULT ICommDlgBrowser3.GetCurrentFilter(StringBuilder pszFileSpec, int cchFileSpec) => HRESULT.S_OK;

        HRESULT ICommDlgBrowser3.GetDefaultMenuText(IShellView ppshv, StringBuilder pszText, int cchMax) => HRESULT.S_FALSE;

        HRESULT IExplorerPaneVisibility.GetPaneState(in Guid ep, out EXPLORERPANESTATE peps)
        {
            peps = ep switch
            {
                var a when a.Equals(IExplorerPaneVisibilityConstants.EP_AdvQueryPane) => (EXPLORERPANESTATE)PaneVisibility.AdvancedQuery,

                var a when a.Equals(IExplorerPaneVisibilityConstants.EP_Commands) => (EXPLORERPANESTATE)PaneVisibility.Commands,

                var a when a.Equals(IExplorerPaneVisibilityConstants.EP_Commands_Organize) => (EXPLORERPANESTATE)PaneVisibility.CommandsOrganize,

                var a when a.Equals(IExplorerPaneVisibilityConstants.EP_Commands_View) => (EXPLORERPANESTATE)PaneVisibility.CommandsView,

                var a when a.Equals(IExplorerPaneVisibilityConstants.EP_DetailsPane) => (EXPLORERPANESTATE)PaneVisibility.Details,

                var a when a.Equals(IExplorerPaneVisibilityConstants.EP_NavPane) => (EXPLORERPANESTATE)PaneVisibility.Navigation,

                var a when a.Equals(IExplorerPaneVisibilityConstants.EP_PreviewPane) => (EXPLORERPANESTATE)PaneVisibility.Preview,

                var a when a.Equals(IExplorerPaneVisibilityConstants.EP_QueryPane) => (EXPLORERPANESTATE)PaneVisibility.Query,

                var a when a.Equals(IExplorerPaneVisibilityConstants.EP_Ribbon) => (EXPLORERPANESTATE)PaneVisibility.Ribbon,

                var a when a.Equals(IExplorerPaneVisibilityConstants.EP_StatusBar) => (EXPLORERPANESTATE)PaneVisibility.StatusBar,

                _ => EXPLORERPANESTATE.EPS_DONTCARE,
            };
            return HRESULT.S_OK;
        }

        HRESULT ICommDlgBrowser3.GetViewFlags(out CDB2GVF pdwFlags)
        {
            pdwFlags = CDB2GVF.CDB2GVF_SHOWALLFILES;
            return HRESULT.S_OK;
        }

        HRESULT ICommDlgBrowser3.IncludeObject(IShellView ppshv, IntPtr pidl)
        {
            OnItemsChanged();
            return HRESULT.S_OK;
        }

        HRESULT ICommDlgBrowser3.Notify(IShellView ppshv, CDB2N dwNotifyType) => HRESULT.S_OK;

        HRESULT ICommDlgBrowser3.OnColumnClicked(IShellView ppshv, int iColumn) => HRESULT.S_OK;

        HRESULT ICommDlgBrowser3.OnDefaultCommand(IShellView ppshv) => HRESULT.S_FALSE;

        HRESULT IExplorerBrowserEvents.OnNavigationComplete(IntPtr pidlFolder)
        {
            folderSettings.ViewMode = GetCurrentViewMode();
            OnNavigated(new NavigatedEventArgs { NewLocation = new ShellItem(pidlFolder) });
            return HRESULT.S_OK;
        }

        HRESULT IExplorerBrowserEvents.OnNavigationFailed(IntPtr pidlFolder)
        {
            OnNavigationFailed(new NavigationFailedEventArgs { FailedLocation = new ShellItem(pidlFolder) });
            return HRESULT.S_OK;
        }

        HRESULT IExplorerBrowserEvents.OnNavigationPending(IntPtr pidlFolder)
        {
            OnNavigating(new NavigatingEventArgs { PendingLocation = new ShellItem(pidlFolder) }, out var cancelled);
            return cancelled ? (HRESULT)HRESULT_CANCELLED : HRESULT.S_OK;
        }

        HRESULT ICommDlgBrowser3.OnPreViewCreated(IShellView ppshv) => HRESULT.S_OK;

        HRESULT ICommDlgBrowser3.OnStateChange(IShellView ppshv, CDBOSC uChange)
        {
            if (uChange == CDBOSC.CDBOSC_SELCHANGE)
                OnSelectionChanged();
            return HRESULT.S_OK;
        }

        HRESULT IExplorerBrowserEvents.OnViewCreated(IShellView psv)
        {
            viewEvents?.ConnectToView(psv);
            return HRESULT.S_OK;
        }

        bool IMessageFilter.PreFilterMessage(ref Message m)
        {
            if (explorerBrowserControl is null) return false;
            return ((IInputObject_WinForms)explorerBrowserControl).TranslateAcceleratorIO(m) == HRESULT.S_OK;
        }

        HRESULT IServiceProvider.QueryService(in Guid guidService, in Guid riid, out IntPtr ppvObject)
        {
            if (guidService.Equals(typeof(IExplorerPaneVisibility).GUID))
            {
                ppvObject = Marshal.GetComInterfaceForObject(this, typeof(IExplorerPaneVisibility));
                return HRESULT.S_OK;
            }
            else if (guidService.Equals(IID_ICommDlgBrowser) && (riid.Equals(IID_ICommDlgBrowser) || riid.Equals(typeof(ICommDlgBrowser3).GUID)))
            {
                ppvObject = Marshal.GetComInterfaceForObject(this, typeof(ICommDlgBrowser3));
                return HRESULT.S_OK;
            }
            ppvObject = default;
            return HRESULT.E_NOINTERFACE;
        }

        /// <summary>Gets the IFolderView2 interface from the explorer browser.</summary>
        /// <returns>An <see cref="IFolderView2"/> instance.</returns>
        internal IFolderView2 GetFolderView2() { try { return explorerBrowserControl?.GetCurrentView<IFolderView2>(); } catch { return null; } }

        /// <summary>Gets the items in the ExplorerBrowser as an IShellItemArray</summary>
        /// <returns>An <see cref="IShellItemArray"/> instance or <see langword="null"/> if not available.</returns>
        internal IShellItemArray GetItemsArray(SVGIO opt)
        {
            try
            {
                using var fv2 = ComReleaserFactory.Create(GetFolderView2());
                return fv2.Item?.Items<IShellItemArray>(opt);
            }
            catch { return null; }
        }

        /// <summary>Raises the <see cref="ItemsChanged"/> event.</summary>
        protected internal virtual void OnItemsChanged() => ItemsChanged?.Invoke(this, EventArgs.Empty);

        /// <summary>Raises the <see cref="ItemsEnumerated"/> event.</summary>
        protected internal virtual void OnItemsEnumerated() => ItemsEnumerated?.Invoke(this, EventArgs.Empty);

        /// <summary>Raises the <see cref="Navigated"/> event.</summary>
        protected internal virtual void OnNavigated(NavigatedEventArgs ncevent)
        {
            if (ncevent?.NewLocation is null) return;
            Navigated?.Invoke(this, ncevent);
        }

        /// <summary>Raises the <see cref="Navigating"/> event.</summary>
        protected internal virtual void OnNavigating(NavigatingEventArgs npevent, out bool cancelled)
        {
            cancelled = false;
            if (Navigating is null || npevent?.PendingLocation is null) return;
            foreach (var del in Navigating.GetInvocationList())
            {
                del.DynamicInvoke(new object[] { this, npevent });
                if (npevent.Cancel)
                    cancelled = true;
            }
        }

        /// <summary>Raises the <see cref="NavigationFailed"/> event.</summary>
        protected internal virtual void OnNavigationFailed(NavigationFailedEventArgs nfevent)
        {
            if (nfevent?.FailedLocation is null) return;
            NavigationFailed?.Invoke(this, nfevent);
        }

        /// <summary>Raises the <see cref="SelectedItemModified"/> event.</summary>
        protected internal virtual void OnSelectedItemModified() => SelectedItemModified?.Invoke(this, EventArgs.Empty);

        /// <summary>Raises the <see cref="SelectionChanged"/> event.</summary>
        protected internal virtual void OnSelectionChanged() => SelectionChanged?.Invoke(this, EventArgs.Empty);

        /// <summary>Clean up any resources being used.</summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
                viewEvents?.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>Raises the <see cref="Control.CreateControl"/> method.</summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            if (!DesignMode)
            {
                explorerBrowserControl = new IExplorerBrowser();

                // hooks up IExplorerPaneVisibility and ICommDlgBrowser event notifications
                SetSite(this);

                // hooks up IExplorerBrowserEvents event notification
                explorerBrowserControl.Advise(this, out eventsCookie);

                // sets up ExplorerBrowser view connection point events
                viewEvents = new ViewEvents(this);

                explorerBrowserControl.Initialize(Handle, ClientRectangle, folderSettings);

                // Force an initial show frames so that IExplorerPaneVisibility works the first time it is set. This also enables the
                // control panel to be browsed to. If it is not set, then navigating to the control panel succeeds, but no items are visible
                // in the view.
                explorerBrowserControl.SetOptions(options);

                explorerBrowserControl.SetPropertyBag(propertyBagName);

                // ExplorerBrowserOptions.NoBorder does not work, so we do it manually...
                RemoveWindowBorder();

                if (antecreationNavigationTarget.item != null)
                {
                    BeginInvoke(new MethodInvoker(delegate
                    {
                        Navigate(antecreationNavigationTarget.item, antecreationNavigationTarget.category);
                        antecreationNavigationTarget = default;
                    }));
                }
            }

            Application.AddMessageFilter(this);
        }

        /// <summary>Cleans up the explorer browser events+object when the window is being taken down.</summary>
        /// <param name="e">An EventArgs that contains event data.</param>
        protected override void OnHandleDestroyed(EventArgs e)
        {
            if (explorerBrowserControl != null)
            {
                // unhook events
                viewEvents?.DisconnectFromView();
                explorerBrowserControl.Unadvise(eventsCookie);
                SetSite(null);

                // destroy the explorer browser control
                explorerBrowserControl.Destroy();

                // release com reference to it
                explorerBrowserControl = null;
            }

            base.OnHandleDestroyed(e);
        }

        /// <summary>Raises the <see cref="E:Paint"/> event.</summary>
        /// <param name="pe">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            if (DesignMode && pe != null)
            {
                var cr = ClientRectangle;
                pe.Graphics.FillRectangle(SystemBrushes.Window, cr);
                if (VisualStyleRenderer.IsSupported)
                {
                    var btn = new VisualStyleRenderer(VisualStyleElement.ScrollBar.ArrowButton.UpDisabled);
                    var sz = btn.GetPartSize(pe.Graphics, ThemeSizeType.True);
                    var rsb = new Rectangle(cr.X + cr.Width - sz.Width, cr.Y, sz.Width, cr.Height);
                    new VisualStyleRenderer(VisualStyleElement.ScrollBar.LowerTrackVertical.Disabled).DrawBackground(pe.Graphics, rsb);
                    rsb.Height = sz.Height;
                    btn.DrawBackground(pe.Graphics, rsb);
                    rsb.Offset(0, cr.Height - sz.Height);
                    new VisualStyleRenderer(VisualStyleElement.ScrollBar.ArrowButton.DownDisabled).DrawBackground(pe.Graphics, rsb);
                }
                else
                {
                    var sz = new Size(SystemInformation.VerticalScrollBarWidth, SystemInformation.VerticalScrollBarArrowHeight);
                    var rsb = new Rectangle(cr.X + cr.Width - sz.Width, cr.Y, sz.Width, cr.Height);
                    pe.Graphics.FillRectangle(SystemBrushes.ControlLightLight, rsb);
                    rsb.Height = sz.Height;
                    ControlPaint.DrawScrollButton(pe.Graphics, rsb, ScrollButton.Up, ButtonState.Inactive);
                    rsb.Offset(0, cr.Height - sz.Height);
                    ControlPaint.DrawScrollButton(pe.Graphics, rsb, ScrollButton.Down, ButtonState.Inactive);
                }
                ControlPaint.DrawBorder(pe.Graphics, cr, SystemColors.WindowFrame, ButtonBorderStyle.Solid);

                using var font = new Font("Segoe UI", 9);
                using var sf = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Near };
                pe.Graphics.DrawString(nameof(Windows.Forms.ExplorerBrowser), font, SystemBrushes.GrayText, Rectangle.Inflate(cr, -3, -3), sf);
            }

            base.OnPaint(pe);
        }

        /// <summary>Sizes the native control to match the WinForms control wrapper.</summary>
        /// <param name="e">Contains information about the size changed event.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            explorerBrowserControl?.SetRect(default, ClientRectangle);
            base.OnSizeChanged(e);
        }

        /// <summary>Enables a container to pass an object a pointer to the interface for its site.</summary>
        /// <param name="sp">
        /// A pointer to the <c>IServiceProvider</c> interface pointer of the site managing this object. If <see langword="null"/>, the
        /// object should call Release on any existing site at which point the object no longer knows its site.
        /// </param>
        protected virtual void SetSite(IServiceProvider sp) => (explorerBrowserControl as IObjectWithSite)?.SetSite(sp);

        private FOLDERVIEWMODE GetCurrentViewMode()
        {
            using var fv2 = ComReleaserFactory.Create(GetFolderView2());
            return fv2.Item?.GetCurrentViewMode() ?? 0;
        }

        private bool IsContentFlagSet(ExplorerBrowserContentSectionOptions flag) => folderSettings.fFlags.IsFlagSet((FOLDERFLAGS)flag);

        private bool IsNavFlagSet(ExplorerBrowserNavigateOptions flag) => NavigationFlags.IsFlagSet(flag);

        /// <summary>Find the native control handle, remove its border style, then ask for a redraw.</summary>
        private void RemoveWindowBorder()
        {
            // There is an option (EBO_NOBORDER) to avoid showing a border on the native ExplorerBrowser control so we wouldn't have to
            // remove it afterwards, but:
            // 1. It's not implemented by the Windows API Code Pack
            // 2. The flag doesn't seem to work anyway (tested on 7 and 8.1) For reference: EXPLORER_BROWSER_OPTIONS https://msdn.microsoft.com/en-us/library/windows/desktop/bb762501(v=vs.85).aspx
            var hwnd = FindWindowEx(Handle, default, "ExplorerBrowserControl", default);
            var explorerBrowserStyle = (WindowStyles)GetWindowLongAuto(hwnd, WindowLongFlags.GWL_STYLE).ToInt32();
            SetWindowLong(hwnd, WindowLongFlags.GWL_STYLE, (int)explorerBrowserStyle.ClearFlags(WindowStyles.WS_CAPTION | WindowStyles.WS_BORDER));
            SetWindowPos(hwnd, default, 0, 0, 0, 0, SetWindowPosFlags.SWP_FRAMECHANGED | SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOSIZE);
        }

        private void SetContentFlag(ExplorerBrowserContentSectionOptions flag, bool value)
        {
            folderSettings.fFlags = folderSettings.fFlags.SetFlags((FOLDERFLAGS)flag, value);
            explorerBrowserControl?.SetFolderSettings(folderSettings);
        }

        private void SetNavFlag(ExplorerBrowserNavigateOptions flag, bool value) => NavigationFlags = NavigationFlags.SetFlags(flag, value);

        private bool ShouldSerializePropertyBagName() => propertyBagName != defaultPropBagName;

        /// <summary>Controls the visibility of the various ExplorerBrowser panes on subsequent navigation</summary>
        [TypeConverter(typeof(BetterExpandableObjectConverter)), Serializable]
        public class ExplorerBrowserPaneVisibility
        {
            internal ExplorerBrowserPaneVisibility()
            {
            }

            /// <summary>Additional fields and options to aid in a search.</summary>
            [DefaultValue(PaneVisibilityState.Default), Category("Appearance"), Description("Additional fields and options to aid in a search.")]
            public PaneVisibilityState AdvancedQuery { get; set; } = PaneVisibilityState.Default;

            /// <summary>Commands module along the top of the Windows Explorer window.</summary>
            [DefaultValue(PaneVisibilityState.Default), Category("Appearance"), Description("Commands module along the top of the Windows Explorer window.")]
            public PaneVisibilityState Commands { get; set; } = PaneVisibilityState.Default;

            /// <summary>Organize menu within the commands module.</summary>
            [DefaultValue(PaneVisibilityState.Default), Category("Appearance"), Description("Organize menu within the commands module.")]
            public PaneVisibilityState CommandsOrganize { get; set; } = PaneVisibilityState.Default;

            /// <summary>View menu within the commands module.</summary>
            [DefaultValue(PaneVisibilityState.Default), Category("Appearance"), Description("View menu within the commands module.")]
            public PaneVisibilityState CommandsView { get; set; } = PaneVisibilityState.Default;

            /// <summary>Pane showing metadata along the bottom of the Windows Explorer window.</summary>
            [DefaultValue(PaneVisibilityState.Default), Category("Appearance"), Description("Pane showing metadata along the bottom of the Windows Explorer window.")]
            public PaneVisibilityState Details { get; set; } = PaneVisibilityState.Default;

            /// <summary>The pane on the left side of the Windows Explorer window that hosts the folders tree and Favorites.</summary>
            [DefaultValue(PaneVisibilityState.Default), Category("Appearance"), Description("The pane on the left side of the Windows Explorer window that hosts the folders tree and Favorites.")]
            public PaneVisibilityState Navigation { get; set; } = PaneVisibilityState.Default;

            /// <summary>Pane on the right of the Windows Explorer window that shows a large reading preview of the file.</summary>
            [DefaultValue(PaneVisibilityState.Default), Category("Appearance"), Description("Pane on the right of the Windows Explorer window that shows a large reading preview of the file.")]
            public PaneVisibilityState Preview { get; set; } = PaneVisibilityState.Default;

            /// <summary>Quick filter buttons to aid in a search.</summary>
            [DefaultValue(PaneVisibilityState.Default), Category("Appearance"), Description("Quick filter buttons to aid in a search.")]
            public PaneVisibilityState Query { get; set; } = PaneVisibilityState.Default;

            /// <summary>
            /// Introduced in Windows 8: The ribbon, which is the control that replaced menus and toolbars at the top of many Microsoft applications.
            /// </summary>
            [DefaultValue(PaneVisibilityState.Default), Category("Appearance"), Description("The ribbon, which is the control that replaced menus and toolbars at the top of many Microsoft applications.")]
            public PaneVisibilityState Ribbon { get; set; } = PaneVisibilityState.Default;

            /// <summary>Introduced in Windows 8: A status bar that indicates the progress of some process, such as copying or downloading.</summary>
            [DefaultValue(PaneVisibilityState.Default), Category("Appearance"), Description("A status bar that indicates the progress of some process, such as copying or downloading.")]
            public PaneVisibilityState StatusBar { get; set; } = PaneVisibilityState.Default;
        }

        /// <summary>Event argument for The Navigated event</summary>
        public class NavigatedEventArgs : EventArgs
        {
            /// <summary>The new location of the explorer browser</summary>
            public ShellItem NewLocation { get; set; }
        }

        /// <summary>Event argument for The Navigating event</summary>
        public class NavigatingEventArgs : EventArgs
        {
            /// <summary>Set to 'True' to cancel the navigation.</summary>
            public bool Cancel { get; set; }

            /// <summary>The location being navigated to</summary>
            public ShellItem PendingLocation { get; set; }
        }

        /// <summary>Event argument for the NavigatinoFailed event</summary>
        public class NavigationFailedEventArgs : EventArgs
        {
            /// <summary>The location the browser would have navigated to.</summary>
            public ShellItem FailedLocation { get; set; }
        }

        /// <summary>The navigation log is a history of the locations visited by the explorer browser.</summary>
        public class NavigationLog
        {
            private readonly ExplorerBrowser parent = null;

            /// <summary>The pending navigation log action. null if the user is not navigating via the navigation log.</summary>
            private PendingNavigation pendingNavigation;

            internal NavigationLog(ExplorerBrowser parent)
            {
                // Hook navigation events from the parent to distinguish between navigation log induced navigation, and other navigations.
                this.parent = parent ?? throw new ArgumentNullException(nameof(parent));
                this.parent.Navigated += OnNavigated;
                this.parent.NavigationFailed += OnNavigationFailed;
            }

            /// <summary>Fires when the navigation log changes or the current navigation position changes</summary>
            public event EventHandler<NavigationLogEventArgs> NavigationLogChanged;

            /// <summary>Indicates the presence of locations in the log that can be reached by calling Navigate(Backward)</summary>
            public bool CanNavigateBackward => CurrentLocationIndex > 0;

            /// <summary>Indicates the presence of locations in the log that can be reached by calling Navigate(Forward)</summary>
            public bool CanNavigateForward => CurrentLocationIndex < Locations.Count - 1;

            /// <summary>Gets the shell object in the Locations collection pointed to by CurrentLocationIndex.</summary>
            public ShellItem CurrentLocation => CurrentLocationIndex < 0 ? null : Locations[CurrentLocationIndex];

            /// <summary>
            /// An index into the Locations collection. The ShellItem pointed to by this index is the current location of the ExplorerBrowser.
            /// </summary>
            public int CurrentLocationIndex { get; set; } = -1;

            /// <summary>The navigation log</summary>
            public List<ShellItem> Locations { get; } = new List<ShellItem>();

            /// <summary>Clears the contents of the navigation log.</summary>
            public void Clear()
            {
                if (Locations.Count == 0) return;

                var oldCanNavigateBackward = CanNavigateBackward;
                var oldCanNavigateForward = CanNavigateForward;

                Locations.Clear();
                CurrentLocationIndex = -1;

                var args = new NavigationLogEventArgs
                {
                    LocationsChanged = true,
                    CanNavigateBackwardChanged = oldCanNavigateBackward != CanNavigateBackward,
                    CanNavigateForwardChanged = oldCanNavigateForward != CanNavigateForward
                };
                NavigationLogChanged?.Invoke(this, args);
            }

            internal bool NavigateLog(NavigationLogDirection direction)
            {
                // determine proper index to navigate to
                int locationIndex;
                switch (direction)
                {
                    case NavigationLogDirection.Backward when CanNavigateBackward:
                        locationIndex = CurrentLocationIndex - 1;
                        break;

                    case NavigationLogDirection.Forward when CanNavigateForward:
                        locationIndex = CurrentLocationIndex + 1;
                        break;

                    default:
                        return false;
                }

                // initiate traversal request
                var location = Locations[locationIndex];
                pendingNavigation = new PendingNavigation(location, locationIndex);
                parent.Navigate(location);
                return true;
            }

            internal bool NavigateLog(int index)
            {
                // can't go anywhere
                if (index >= Locations.Count || index < 0) return false;

                // no need to re navigate to the same location
                if (index == CurrentLocationIndex) return false;

                // initiate traversal request
                var location = Locations[index];
                pendingNavigation = new PendingNavigation(location, index);
                parent.Navigate(location);
                return true;
            }

            private void OnNavigated(object sender, NavigatedEventArgs args)
            {
                var eventArgs = new NavigationLogEventArgs();
                var oldCanNavigateBackward = CanNavigateBackward;
                var oldCanNavigateForward = CanNavigateForward;

                if (pendingNavigation != null)
                {
                    // navigation log traversal in progress

                    // determine if new location is the same as the traversal request
                    var shellItemsEqual = pendingNavigation.Location.IShellItem.Compare(args.NewLocation.IShellItem, SICHINTF.SICHINT_ALLFIELDS) == 0;
                    if (!shellItemsEqual)
                    {
                        // new location is different than traversal request, behave is if it never happened! remove history following
                        // currentLocationIndex, append new item
                        if (CurrentLocationIndex < Locations.Count - 1)
                        {
                            Locations.RemoveRange(CurrentLocationIndex + 1, Locations.Count - (CurrentLocationIndex + 1));
                        }
                        Locations.Add(args.NewLocation);
                        CurrentLocationIndex = Locations.Count - 1;
                        eventArgs.LocationsChanged = true;
                    }
                    else
                    {
                        // log traversal successful, update index
                        CurrentLocationIndex = pendingNavigation.Index;
                        eventArgs.LocationsChanged = false;
                    }
                    pendingNavigation = null;
                }
                else
                {
                    // remove history following currentLocationIndex, append new item
                    if (CurrentLocationIndex < Locations.Count - 1)
                    {
                        Locations.RemoveRange(CurrentLocationIndex + 1, Locations.Count - (CurrentLocationIndex + 1));
                    }
                    Locations.Add(args.NewLocation);
                    CurrentLocationIndex = Locations.Count - 1;
                    eventArgs.LocationsChanged = true;
                }

                // update event args
                eventArgs.CanNavigateBackwardChanged = oldCanNavigateBackward != CanNavigateBackward;
                eventArgs.CanNavigateForwardChanged = oldCanNavigateForward != CanNavigateForward;

                NavigationLogChanged?.Invoke(this, eventArgs);
            }

            private void OnNavigationFailed(object sender, NavigationFailedEventArgs args) => pendingNavigation = null;

            /// <summary>A navigation traversal request</summary>
            private class PendingNavigation
            {
                internal PendingNavigation(ShellItem location, int index)
                {
                    Location = location;
                    Index = index;
                }

                internal int Index { get; set; }

                internal ShellItem Location { get; set; }
            }
        }

        /// <summary>The event argument for NavigationLogChangedEvent</summary>
        public class NavigationLogEventArgs : EventArgs
        {
            /// <summary>Indicates CanNavigateBackward has changed</summary>
            public bool CanNavigateBackwardChanged { get; set; }

            /// <summary>Indicates CanNavigateForward has changed</summary>
            public bool CanNavigateForwardChanged { get; set; }

            /// <summary>Indicates the Locations collection has changed</summary>
            public bool LocationsChanged { get; set; }
        }

        /// <summary>Represents a collection of <see cref="ShellItem"/> attached to an <see cref="ExplorerBrowser"/>.</summary>
        private class ShellItemCollection : IReadOnlyList<ShellItem>
        {
            private readonly ExplorerBrowser eb;
            private readonly SVGIO option;

            internal ShellItemCollection(ExplorerBrowser eb, SVGIO opt)
            {
                this.eb = eb;
                option = opt;
            }

            /// <summary>Gets the number of elements in the collection.</summary>
            /// <value>Returns a <see cref="int"/> value.</value>
            public int Count
            {
                get
                {
                    using var fv2 = ComReleaserFactory.Create(eb?.GetFolderView2());
                    return fv2.Item?.ItemCount(option) ?? 0;
                }
            }

            private IShellItemArray Array => eb.GetItemsArray(option);

            private IEnumerable<IShellItem> Items
            {
                get
                {
                    var array = Array;
                    if (array is null)
                        yield break;
                    try
                    {
                        for (uint i = 0; i < array.GetCount(); i++)
                            yield return array.GetItemAt(i);
                    }
                    finally
                    {
                        Marshal.ReleaseComObject(array);
                    }
                }
            }

            /// <summary>Gets the <see cref="ShellItem"/> at the specified index.</summary>
            /// <value>The <see cref="ShellItem"/>.</value>
            /// <param name="index">The zero-based index of the element to get.</param>
            public ShellItem this[int index]
            {
                get
                {
                    var array = Array;
                    try
                    {
                        return array is null ? null : ShellItem.Open(array.GetItemAt((uint)index));
                    }
                    catch
                    {
                        return null;
                    }
                    finally
                    {
                        if (array != null)
                            Marshal.ReleaseComObject(array);
                    }
                }
            }

            /// <summary>Returns an enumerator that iterates through the collection.</summary>
            /// <returns>An enumerator that can be used to iterate through the collection.</returns>
            public IEnumerator<ShellItem> GetEnumerator() => Items.Select(ShellItem.Open).GetEnumerator();

            /// <summary>Returns an enumerator that iterates through the collection.</summary>
            /// <returns>An enumerator that can be used to iterate through the collection.</returns>
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        /// <summary>This provides a connection point container compatible dispatch interface for hooking into the ExplorerBrowser view.</summary>
        [ComVisible(true)]
#pragma warning disable CS0618 // Type or member is obsolete
        [ClassInterface(ClassInterfaceType.AutoDual)]
#pragma warning restore CS0618 // Type or member is obsolete
        private class ViewEvents : IDisposable
        {
            private static readonly Guid IID_DShellFolderViewEvents = typeof(DShellFolderViewEvents).GUID;
            private static readonly Guid IID_IDispatch = typeof(OleAut32.IDispatch).GUID;

            private readonly ExplorerBrowser parent;
            private uint viewConnectionPointCookie;
            private object viewDispatch;

            internal ViewEvents(ExplorerBrowser parent) => this.parent = parent;

            // Prevent default construction
            private ViewEvents() { }

            /// <summary>Finalizes ViewEvents</summary>
            ~ViewEvents()
            {
                Dispose(false);
            }

            /// <summary>Disconnects and disposes object.</summary>
            public void Dispose()
            {
                Dispose(true);
                System.GC.SuppressFinalize(this);
            }

            /// <summary>The contents of the view have changed</summary>
            [DispId(DISPID.DISPID_CONTENTSCHANGED)]
            public void ViewContentsChanged() => parent.OnItemsChanged();

            /// <summary>The enumeration of files in the view is complete</summary>
            [DispId(DISPID.DISPID_FILELISTENUMDONE)]
            public void ViewFileListEnumDone() => parent.OnItemsEnumerated();

            /// <summary>The selected item in the view has changed (not the same as the selection has changed)</summary>
            [DispId(DISPID.DISPID_SELECTEDITEMCHANGED)]
            public void ViewSelectedItemModified() => parent.OnSelectedItemModified();

            /// <summary>The view selection has changed</summary>
            [DispId(DISPID.DISPID_SELECTIONCHANGED)]
            public void ViewSelectionChanged() => parent.OnSelectionChanged();

            internal void ConnectToView(IShellView psv)
            {
                DisconnectFromView();
                viewDispatch = psv.GetItemObject(SVGIO.SVGIO_BACKGROUND, IID_IDispatch);
                if (ConnectToConnectionPoint(this, IID_DShellFolderViewEvents, true, viewDispatch, ref viewConnectionPointCookie).Failed)
                {
                    viewDispatch = null;
                }
            }

            internal void DisconnectFromView()
            {
                if (viewDispatch is null) return;
                ConnectToConnectionPoint(null, IID_DShellFolderViewEvents, false, viewDispatch, ref viewConnectionPointCookie);
                viewDispatch = null;
                viewConnectionPointCookie = 0;
            }

            // These need to be public to be accessible via AutoDual reflection
            /// <summary>Disconnects and disposes object.</summary>
            /// <param name="disposed"></param>
            protected virtual void Dispose(bool disposed)
            {
                if (disposed)
                {
                    DisconnectFromView();
                }
            }
        }
    }
}