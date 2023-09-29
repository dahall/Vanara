namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>Indicates which button was clicked and the kind of click.</summary>
	[PInvokeData("shobjidl.h", MSDNShortId = "a595ffd0-edc6-4726-b7b2-ad1aed9e9701")]
	[Flags]
	public enum NSTCECLICKTYPE
	{
		/// <summary>The left button was clicked.</summary>
		NSTCECT_LBUTTON = 0x0001,

		/// <summary>The middle button was clicked.</summary>
		NSTCECT_MBUTTON = 0x0002,

		/// <summary>The right button was clicked.</summary>
		NSTCECT_RBUTTON = 0x0003,

		/// <summary>A button was clicked.</summary>
		NSTCECT_BUTTON = 0x0003,

		/// <summary>The click was a double click. If this value is present, it is added to one of the other values.</summary>
		NSTCECT_DBLCLICK = 0x0004,
	}

	/// <summary>The location on the IShellItem that was clicked.</summary>
	[PInvokeData("shobjidl.h", MSDNShortId = "a595ffd0-edc6-4726-b7b2-ad1aed9e9701")]
	[Flags]
	public enum NSTCEHITTEST
	{
		/// <summary>The click missed the IShellItem.</summary>
		NSTCEHT_NOWHERE = 0x0001,

		/// <summary>The click was on the icon of the IShellItem.</summary>
		NSTCEHT_ONITEMICON = 0x0002,

		/// <summary>The click was on the label text of the IShellItem.</summary>
		NSTCEHT_ONITEMLABEL = 0x0004,

		/// <summary>The click was on the indented space on the leftmost side of the IShellItem.</summary>
		NSTCEHT_ONITEMINDENT = 0x0008,

		/// <summary>The click was on the expando button of the IShellItem.</summary>
		NSTCEHT_ONITEMBUTTON = 0x0010,

		/// <summary>The click was on the rightmost side of the text of the IShellItem.</summary>
		NSTCEHT_ONITEMRIGHT = 0x0020,

		/// <summary>The click was on the state icon of the IShellItem.</summary>
		NSTCEHT_ONITEMSTATEICON = 0x0040,

		/// <summary>The click was on the item icon or the item label or the state icon of the IShellItem.</summary>
		NSTCEHT_ONITEM = 0x0046,

		/// <summary>The click was on the tab button of the IShellItem.</summary>
		NSTCEHT_ONITEMTABBUTTON = 0x1000,
	};

	/// <summary>
	/// Specifies the state of a tree item. These values are used by methods of the INameSpaceTreeControlFolderCapabilities interface.
	/// </summary>
	/// <remarks>The <c>NSTCFOLDERCAPABILITIES</c> type is defined in Shobjidl.h beginning in Windows 7.</remarks>
	// https://docs.microsoft.com/ja-jp/windows/win32/api/shobjidl_core/ne-shobjidl_core-nstcfoldercapabilities
	[PInvokeData("shobjidl_core.h", MSDNShortId = "a5282277-85f5-494e-b994-efbf1116b519")]
	[Flags]
	public enum NSTCFOLDERCAPABILITIES
	{
		/// <summary>The property does not exist. Filtering is not supported.</summary>
		NSTCFC_NONE = 0,

		/// <summary>Property exists. Supports filtering based on the value specified in System.IsPinnedToNameSpaceTree.</summary>
		NSTCFC_PINNEDITEMFILTERING = 1,

		/// <summary>Delays registration for change notifications until the tree is expanded in the navigation pane.</summary>
		NSTCFC_DELAY_REGISTER_NOTIFY = 2,
	}

	/// <summary>The type of the next item.</summary>
	[PInvokeData("shobjidl_core.h", MSDNShortId = "71ede595-14b6-4e59-854a-af75c02093f8")]
	public enum NSTCGNI
	{
		/// <summary>The next sibling of the given item.</summary>
		NSTCGNI_NEXT = 0,

		/// <summary>
		/// The next visible item in the tree that has any relationship to the given item. This includes a child (if there is one), the
		/// next sibling, or even one of the ancestor's siblings.
		/// </summary>
		NSTCGNI_NEXTVISIBLE = 1,

		/// <summary>The previous sibling item of the given item.</summary>
		NSTCGNI_PREV = 2,

		/// <summary>The previous visible item that is a sibling item, sibling descendent item or a parent item.</summary>
		NSTCGNI_PREVVISIBLE = 3,

		/// <summary>The parent item of the given item.</summary>
		NSTCGNI_PARENT = 4,

		/// <summary>The first child item of the given item.</summary>
		NSTCGNI_CHILD = 5,

		/// <summary>The absolute first visible item in the tree (not relative to the given item).</summary>
		NSTCGNI_FIRSTVISIBLE = 6,

		/// <summary>The absolute last visible item in the tree (not relative to the given item).</summary>
		NSTCGNI_LASTVISIBLE = 7,
	}

	/// <summary>Specifies the state of a tree item. These values are used by methods of the INameSpaceTreeControl interface.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/ne-shobjidl_core-_nstcitemstate typedef enum _NSTCITEMSTATE {
	// NSTCIS_NONE, NSTCIS_SELECTED, NSTCIS_EXPANDED, NSTCIS_BOLD, NSTCIS_DISABLED, NSTCIS_SELECTEDNOEXPAND } ;
	[PInvokeData("shobjidl_core.h", MSDNShortId = "1f3fd526-c044-41ff-9e05-c6d91d386b42")]
	[Flags]
	public enum NSTCITEMSTATE : uint
	{
		/// <summary>The item has default state; it is not selected, expanded, bolded or disabled.</summary>
		NSTCIS_NONE = 0x0000,

		/// <summary>The item is selected.</summary>
		NSTCIS_SELECTED = 0x0001,

		/// <summary>The item is expanded.</summary>
		NSTCIS_EXPANDED = 0x0002,

		/// <summary>The item is bold.</summary>
		NSTCIS_BOLD = 0x0004,

		/// <summary>The item is disabled.</summary>
		NSTCIS_DISABLED = 0x0008,

		/// <summary>Windows 7 and later. The item is selected, but not expanded.</summary>
		NSTCIS_SELECTEDNOEXPAND = 0x0010,
	}

	/// <summary>Specifies the style of the root that is being appended.</summary>
	[PInvokeData("shobjidl_core.h", MSDNShortId = "a280d183-9215-43c2-bba3-63c34ba33285")]
	[Flags]
	public enum NSTCROOTSTYLE : uint
	{
		/// <summary>The root is visible as well as the items. Mutually exclusive with NSTCRS_HIDDEN.</summary>
		NSTCRS_VISIBLE = 0x0000,

		/// <summary>The root is hidden so that the children only are visible. Mutually exclusive with NSTCRS_VISIBLE.</summary>
		NSTCRS_HIDDEN = 0x0001,

		/// <summary>The root is expanded upon initialization.</summary>
		NSTCRS_EXPANDED = 0x0002,
	}

	/// <summary>Describes the characteristics of a given namespace tree control.</summary>
	/// <remarks>
	/// <para>
	/// Three values have effect only in conjunction with NSTCS_CHECKBOXES: NSTCS_PARTIALCHECKBOXES, NSTCS_EXCLUSIONCHECKBOXES, and
	/// NSTCS_DIMMEDCHECKBOXES. The icons associated with these states are inserted into the state image list as follows:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Image Slot</term>
	/// <term>Image</term>
	/// <term>Associated Flags</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>Blank</term>
	/// <term>NSTCS_CHECKBOXES</term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>Unchecked</term>
	/// <term>NSTCS_CHECKBOXES</term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>Checked</term>
	/// <term>NSTCS_CHECKBOXES</term>
	/// </item>
	/// <item>
	/// <term>3</term>
	/// <term>Partial</term>
	/// <term>NSTCS_CHECKBOXES | NSTCS_PARTIALCHECKBOXES</term>
	/// </item>
	/// <item>
	/// <term>4</term>
	/// <term>Exclusion (red X)</term>
	/// <term>NSTCS_CHECKBOXES | NSTCS_EXCLUSIONCHECKBOXES</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/ne-shobjidl_core-_nstcstyle typedef enum _NSTCSTYLE {
	// NSTCS_HASEXPANDOS, NSTCS_HASLINES, NSTCS_SINGLECLICKEXPAND, NSTCS_FULLROWSELECT, NSTCS_SPRINGEXPAND, NSTCS_HORIZONTALSCROLL,
	// NSTCS_ROOTHASEXPANDO, NSTCS_SHOWSELECTIONALWAYS, NSTCS_NOINFOTIP, NSTCS_EVENHEIGHT, NSTCS_NOREPLACEOPEN, NSTCS_DISABLEDRAGDROP,
	// NSTCS_NOORDERSTREAM, NSTCS_RICHTOOLTIP, NSTCS_BORDER, NSTCS_NOEDITLABELS, NSTCS_TABSTOP, NSTCS_FAVORITESMODE, NSTCS_AUTOHSCROLL,
	// NSTCS_FADEINOUTEXPANDOS, NSTCS_EMPTYTEXT, NSTCS_CHECKBOXES, NSTCS_PARTIALCHECKBOXES, NSTCS_EXCLUSIONCHECKBOXES,
	// NSTCS_DIMMEDCHECKBOXES, NSTCS_NOINDENTCHECKS, NSTCS_ALLOWJUNCTIONS, NSTCS_SHOWTABSBUTTON, NSTCS_SHOWDELETEBUTTON,
	// NSTCS_SHOWREFRESHBUTTON } ;
	[PInvokeData("shobjidl_core.h", MSDNShortId = "879af1be-2eea-4ebd-b9ea-64b1db40682d")]
	[Flags]
	public enum NSTCSTYLE : uint
	{
		/// <summary>
		/// The control displays a triangle—known as an expando—on the leftmost edge of those items that have child items. Clicking on
		/// the expando expands the item to reveal the children of the item. Has no effect when combined with NSTCS_SHOWTABSBUTTON,
		/// NSTCS_SHOWDELETEBUTTON, or NSTCS_SHOWREFRESHBUTTON. Maps to the TVS_HASBUTTONS tree view control style.
		/// </summary>
		NSTCS_HASEXPANDOS = 0x00000001,

		/// <summary>
		/// The control draws lines to the left of the tree items that lead to their individual parent items. Has no effect when
		/// combined with NSTCS_SHOWTABSBUTTON, NSTCS_SHOWDELETEBUTTON, or NSTCS_SHOWREFRESHBUTTON. Maps to the TVS_HASLINES tree view
		/// control style.
		/// </summary>
		NSTCS_HASLINES = 0x00000002,

		/// <summary>
		/// An item expands to show its child items in response to a single mouse click. Maps to the TVS_SINGLEEXPAND tree view control style.
		/// </summary>
		NSTCS_SINGLECLICKEXPAND = 0x00000004,

		/// <summary>
		/// The selection of an item fills the row with inverse text to the end of the window area, regardless of the length of the
		/// text. When this option is not declared, only the area behind text is inverted. This value cannot be combined with
		/// NSTCS_HASLINES. Maps to the TVS_FULLROWSELECT tree view control style.
		/// </summary>
		NSTCS_FULLROWSELECT = 0x00000008,

		/// <summary>
		/// When one item is selected and expanded and you select a second item, the first selection automatically collapses. This is
		/// the opposite of the TVS_EX_NOSINGLECOLLAPSE tree view control style.
		/// </summary>
		NSTCS_SPRINGEXPAND = 0x00000010,

		/// <summary>
		/// The area of the window that contains the tree of namespace items has a horizontal scroll bar. Maps to the WS_HSCROLL Windows style.
		/// </summary>
		NSTCS_HORIZONTALSCROLL = 0x00000020,

		/// <summary>
		/// The root item is preceded by an expando that allows expansion of the root item. Maps to the TVS_LINESATROOT tree view
		/// control style.
		/// </summary>
		NSTCS_ROOTHASEXPANDO = 0x00000040,

		/// <summary>
		/// The node of an item is outlined when the control does not have the focus. Maps to the TVS_SHOWSELALWAYS tree view control style.
		/// </summary>
		NSTCS_SHOWSELECTIONALWAYS = 0x00000080,

		/// <summary>
		/// Do not display infotips when the mouse cursor is over an item. This is the opposite of the TVS_INFOTIP tree view control style.
		/// </summary>
		NSTCS_NOINFOTIP = 0x00000200,

		/// <summary>
		/// Sets the height of the items to an even height. By default, the height of items can be even or odd. This is the opposite of
		/// the TVS_NONEVENHEIGHT tree view control style.
		/// </summary>
		NSTCS_EVENHEIGHT = 0x00000400,

		/// <summary>Do not replace the Open command in the shortcut menu with a user-defined function.</summary>
		NSTCS_NOREPLACEOPEN = 0x00000800,

		/// <summary>
		/// Do not allow drag-and-drop operations within the control. Note that you can still drag an item from outside of the control
		/// and drop it onto the control. Maps to the TVS_DISABLEDRAGDROP tree view control style.
		/// </summary>
		NSTCS_DISABLEDRAGDROP = 0x00001000,

		/// <summary>
		/// Do not persist reordering changes. Used with NSTCS_FAVORITESMODE. If favorites mode is not specified, this flag has no effect.
		/// </summary>
		NSTCS_NOORDERSTREAM = 0x00002000,

		/// <summary>
		/// Use a rich tooltip. Rich tooltips display the item's icon in addition to the item's text. A standard tooltip displays only
		/// the item's text. The tree view displays tooltips only for items in the tree that are partially visible. Maps to the
		/// TVS_EX_RICHTOOLTIP tree view control style.NSTCS_RICHTOOLTIP has no effect unless it is combined with NSTCS_NOINFOTIP and/or
		/// NSTCS_FAVORITESMODE. If NSTCS_NOINFOTIP is not specified, the tree view displays an infotip instead of a tooltip. If
		/// NSTCS_FAVORITESMODE is not specified, the namespace tree control always sets the TVS_EX_RICHTOOLTIP style.
		/// </summary>
		NSTCS_RICHTOOLTIP = 0x00004000,

		/// <summary>Draw a thin border around the control. Corresponds to WS_BORDER.</summary>
		NSTCS_BORDER = 0x00008000,

		/// <summary>
		/// Do not allow creation of an in-place edit box, which would allow the user to rename the given item. This is the opposite of
		/// the TVS_EDITLABELS tree view control style.
		/// </summary>
		NSTCS_NOEDITLABELS = 0x00010000,

		/// <summary>If the control is hosted, you can tabstop into the control. Corresponds to WS_EX_CONTROLPARENT.</summary>
		NSTCS_TABSTOP = 0x00020000,

		/// <summary>The control has the appearance of the favorites band in Windows XP.</summary>
		NSTCS_FAVORITESMODE = 0x00080000,

		/// <summary>
		/// When you hover the mouse pointer over an item that extends past the end of the control window, the control automatically
		/// scrolls horizontally so that the item appears more fully in the window area. Maps to the TVS_EX_AUTOHSCROLL tree view
		/// control style.
		/// </summary>
		NSTCS_AUTOHSCROLL = 0x00100000,

		/// <summary>
		/// If the control does not have the focus and there are items that are preceded by expandos, then these expandos are visible
		/// only when the mouse pointer is near to the control. Maps to the TVS_EX_FADEINOUTEXPANDOS tree view control style.
		/// </summary>
		NSTCS_FADEINOUTEXPANDOS = 0x00200000,

		/// <summary>
		/// If an item has no children and is not expanded, then that item contains a line of text at the child level that says "empty".
		/// </summary>
		NSTCS_EMPTYTEXT = 0x00400000,

		/// <summary>
		/// Items have check boxes on their leftmost side. These check boxes can be of types partial, exclusion or dimmed, which
		/// correspond to the flags NSTCS_PARTIALCHECKBOXES, NSTCS_EXCLUSIONCHECKBOXES, and NSTCS_DIMMEDCHECKBOXES. Maps to the
		/// TVS_CHECKBOXES tree view control style.
		/// </summary>
		NSTCS_CHECKBOXES = 0x00800000,

		/// <summary>
		/// Adds a checkbox icon on the leftmost side of a given item with a square in the center, that indicates that the node is
		/// partially selected. Must be combined with NSTCS_CHECKBOXES. Maps to the TVS_EX_PARTIALCHECKBOXES tree view control style.
		/// </summary>
		NSTCS_PARTIALCHECKBOXES = 0x01000000,

		/// <summary>
		/// Adds a checkbox icon on the leftmost side of a given item that contains a red X, which indicates that the item is excluded
		/// from the current selection. Without this exclusion icon, selection of a parent item includes selection of its child items.
		/// Must be combined with NSTCS_CHECKBOXES. Maps to the TVS_EX_EXCLUSIONCHECKBOXES tree view control style.
		/// </summary>
		NSTCS_EXCLUSIONCHECKBOXES = 0x02000000,

		/// <summary>
		/// Adds a checkbox on the leftmost side of a given item that contains an icon of a dimmed check mark, that indicates that a
		/// node is selected because its parent is selected. Must be combined with NSTCS_CHECKBOXES. Maps to the TVS_EX_DIMMEDCHECKBOXES
		/// tree view control style.
		/// </summary>
		NSTCS_DIMMEDCHECKBOXES = 0x04000000,

		/// <summary>
		/// Check boxes are located at the far left edge of the window area instead of being indented. Maps to the TVS_EX_NOINDENTSTATE
		/// tree view control style.
		/// </summary>
		NSTCS_NOINDENTCHECKS = 0x08000000,

		/// <summary>
		/// Allow junctions. A junction point, or just junction, is a root of a namespace extension that is normally displayed by
		/// Windows Explorer as a folder in both tree and folder views. For Windows Explorer to display your extension's files and
		/// subfolders, you must specify where the root folder is located in the Shell namespace hierarchy. Junctions exist in the file
		/// system as files, but are not treated as files. An example is a compressed file with a .zip file name extension, which to the
		/// file system is just a file. However, if this file is treated as a junction, it can represent an entire namespace. This
		/// allows the namespace tree control to treat compressed files and similar junctions as folders rather than as files.
		/// </summary>
		NSTCS_ALLOWJUNCTIONS = 0x10000000,

		/// <summary>
		/// Displays an arrow on the right side of an item if the item is a folder. The action associated with the arrow is
		/// implementation specific. Cannot be combined with NSTCS_SHOWDELETEBUTTON or NSTCS_SHOWREFRESHBUTTON.
		/// </summary>
		NSTCS_SHOWTABSBUTTON = 0x20000000,

		/// <summary>
		/// Displays a red X on the right side of an item. The action associated with the X is implementation specific. Cannot be
		/// combined with NSTCS_SHOWTABSBUTTON or NSTCS_SHOWREFRESHBUTTON.
		/// </summary>
		NSTCS_SHOWDELETEBUTTON = 0x40000000,

		/// <summary>
		/// Displays a refresh button on the right side of an item. The action associated with the button is implementation specific.
		/// Cannot be combined with NSTCS_SHOWTABSBUTTON or NSTCS_SHOWDELETEBUTTON.
		/// </summary>
		NSTCS_SHOWREFRESHBUTTON = 0x80000000,
	}

	/// <summary>Used by methods of the INameSpaceTreeControl2 to specify extended display styles in a Shell namespace treeview.</summary>
	/// <remarks>
	/// The value NSTCS2_ALLMASK can be used to mask for the NSTCS2_INTERRUPTNOTIFICATIONS, NSTCS2_SHOWNULLSPACEMENU, and
	/// NSTCS2_DISPLAYPADDING values.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/ne-shobjidl-nstcstyle2 typedef enum NSTCSTYLE2 { NSTCS2_DEFAULT,
	// NSTCS2_INTERRUPTNOTIFICATIONS, NSTCS2_SHOWNULLSPACEMENU, NSTCS2_DISPLAYPADDING, NSTCS2_DISPLAYPINNEDONLY,
	// NTSCS2_NOSINGLETONAUTOEXPAND, NTSCS2_NEVERINSERTNONENUMERATED } ;
	[PInvokeData("shobjidl.h", MSDNShortId = "0bfa6900-71c0-44b7-8157-662bee58e6c9")]
	[Flags]
	public enum NSTCSTYLE2
	{
		/// <summary>Displays the tree nodes in default mode, which includes none of the following values.</summary>
		NSTCS2_DEFAULT = 0x00000000,

		/// <summary>Displays interrupt notifications.</summary>
		NSTCS2_INTERRUPTNOTIFICATIONS = 0x00000001,

		/// <summary>Displays the context menu in the padding space.</summary>
		NSTCS2_SHOWNULLSPACEMENU = 0x00000002,

		/// <summary>Inserts spacing (padding) between top-level nodes.</summary>
		NSTCS2_DISPLAYPADDING = 0x00000004,

		/// <summary>
		/// Filters items based on the System.IsPinnedToNameSpaceTree value when INameSpaceTreeControlFolderCapabilities is implemented.
		/// </summary>
		NSTCS2_DISPLAYPINNEDONLY = 0x00000008,

		/// <summary/>
		NTSCS2_NOSINGLETONAUTOEXPAND = 0x00000010,

		/// <summary>Do not insert nonenumerated (SFGAO_NONENUMERATED) items in the tree.</summary>
		NTSCS2_NEVERINSERTNONENUMERATED = 0x00000020,
	}

	/// <summary>Exposes methods that perform accessibility actions on a Shell item from a namespace tree control.</summary>
	/// <remarks>This interface is used only by INameSpaceTreeControl (CLSID_NameSpaceTreeControl).</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nn-shobjidl-inamespacetreeaccessible
	[PInvokeData("shobjidl.h", MSDNShortId = "b14dfe40-e21a-4208-835f-e0febef60783")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("71f312de-43ed-4190-8477-e9536b82350b"), CoClass(typeof(NameSpaceTreeControl))]
	public interface INameSpaceTreeAccessible
	{
		/// <summary>Gets the default accessibility action for a Shell item.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>Pointer to the IShellItem.</para>
		/// </param>
		/// <param name="pbstrDefaultAction">
		/// <para>Type: <c>BSTR*</c></para>
		/// <para>When this method returns, contains a BSTR that specifies the default, accessibility action.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if successful, or E_OUTOFMEMORY otherwise.</para>
		/// </returns>
		/// <remarks>This method is called when the default accessibililty action for a Shell item is retrieved.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-inamespacetreeaccessible-ongetdefaultaccessibilityaction
		// HRESULT OnGetDefaultAccessibilityAction( IShellItem *psi, BSTR *pbstrDefaultAction );
		[PreserveSig]
		HRESULT OnGetDefaultAccessibilityAction([In] IShellItem psi, [MarshalAs(UnmanagedType.BStr)] out string pbstrDefaultAction);

		/// <summary>Invokes the default accessibility action on a Shell item.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>Pointer to the IShellItem.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-inamespacetreeaccessible-ondodefaultaccessibilityaction
		// HRESULT OnDoDefaultAccessibilityAction( IShellItem *psi );
		[PreserveSig]
		HRESULT OnDoDefaultAccessibilityAction([In] IShellItem psi);

		/// <summary>Gets the accessibility role for a Shell item.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>Pointer to the IShellItem.</para>
		/// </param>
		/// <param name="pvarRole">
		/// <para>Type: <c>VARIANT*</c></para>
		/// <para>When this method returns, contains a VARIANT that specifies the role.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>This method is called when the accessibility role for a Shell item is retrieved.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-inamespacetreeaccessible-ongetaccessibilityrole
		// HRESULT OnGetAccessibilityRole( IShellItem *psi, VARIANT *pvarRole );
		[PreserveSig]
		HRESULT OnGetAccessibilityRole([In] IShellItem psi, out object pvarRole);
	}

	/// <summary>Exposes methods used to view and manipulate nodes in a tree of Shell items.</summary>
	/// <remarks>To implement this interface use class ID CLSID_NameSpaceTreeControl.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-inamespacetreecontrol
	[PInvokeData("shobjidl_core.h", MSDNShortId = "2072cb3c-e540-4708-bfe8-33fff3a190bd")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("028212A3-B627-47e9-8856-C14265554E4F"), CoClass(typeof(NameSpaceTreeControl))]
	public interface INameSpaceTreeControl
	{
		/// <summary>Initializes an INameSpaceTreeControl object.</summary>
		/// <param name="hwndParent">
		/// <para>Type: <c>HWND</c></para>
		/// <para>The handle of the parent window.</para>
		/// </param>
		/// <param name="prc">
		/// <para>Type: <c>RECT*</c></para>
		/// <para>A pointer to a RECT structure that describes the size and position of the control in the client window.</para>
		/// </param>
		/// <param name="nsctsFlags">
		/// <para>Type: <c>NSTCSTYLE</c></para>
		/// <para>The characteristics of the given namespace tree control. One or more of the following values from the NSTCSTYLE enumeration.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-initialize HRESULT
		// Initialize( HWND hwndParent, RECT *prc, NSTCSTYLE nsctsFlags );
		[PreserveSig]
		HRESULT Initialize(HWND hwndParent, in RECT prc, NSTCSTYLE nsctsFlags);

		/// <summary>Enables a client to register with the control.</summary>
		/// <param name="punk">
		/// <para>Type: <c>IUnknown*</c></para>
		/// <para>A pointer to the client IUnknown that registers with the control.</para>
		/// </param>
		/// <param name="pdwCookie">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>A pointer to the cookie that is passed back for registration.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>The pointer to the cookie that is passed back is used to unregister the control later with INameSpaceTreeControl::TreeUnadvise.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-treeadvise HRESULT
		// TreeAdvise( IUnknown *punk, DWORD *pdwCookie );
		[PreserveSig]
		HRESULT TreeAdvise([MarshalAs(UnmanagedType.IUnknown)] object punk, out uint pdwCookie);

		/// <summary>Enables a client to unregister with the control.</summary>
		/// <param name="dwCookie">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>A pointer to the cookie that is to be unregistered.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>The pointer to the cookie that is passed in is the one that was passed back in INameSpaceTreeControl::TreeAdvise.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-treeunadvise HRESULT
		// TreeUnadvise( DWORD dwCookie );
		[PreserveSig]
		HRESULT TreeUnadvise(uint dwCookie);

		/// <summary>Appends a Shell item to the list of roots in a tree.</summary>
		/// <param name="psiRoot">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>Pointer to the Shell item that is being appended.</para>
		/// </param>
		/// <param name="grfEnumFlags">
		/// <para>Type: <c>SHCONTF</c></para>
		/// <para>
		/// Enumerates the qualities of the root and all of its children. One or more of the values of type SHCONTF. These flags can be
		/// combined using a bitwise OR.
		/// </para>
		/// </param>
		/// <param name="grfRootStyle">
		/// <para>Type: <c>NSTCROOTSTYLE</c></para>
		/// <para>Specifies the style of the root that is being appended. One or more of the following values:</para>
		/// <para>NSTCRS_VISIBLE (0x0000)</para>
		/// <para>The root is visible as well as the items. Mutually exclusive with NSTCRS_HIDDEN.</para>
		/// <para>NSTCRS_HIDDEN (0x0001)</para>
		/// <para>The root is hidden so that the children only are visible. Mutually exclusive with NSTCRS_VISIBLE.</para>
		/// <para>NSTCRS_EXPANDED (0x0002)</para>
		/// <para>The root is expanded upon initialization.</para>
		/// </param>
		/// <param name="pif">
		/// <para>Type: <c>IShellItemFilter*</c></para>
		/// <para>
		/// Pointer to the IShellItemFilter that enables you to filter which items in the tree are displayed. If supplied, every item is
		/// customizable with a SHCONTF flag. This value can be <c>NULL</c> if no filter is required.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-appendroot HRESULT
		// AppendRoot( IShellItem *psiRoot, SHCONTF grfEnumFlags, NSTCROOTSTYLE grfRootStyle, IShellItemFilter *pif );
		[PreserveSig]
		HRESULT AppendRoot(IShellItem psiRoot, SHCONTF grfEnumFlags, NSTCROOTSTYLE grfRootStyle, [In, Optional] IShellItemFilter? pif);

		/// <summary>Inserts a Shell item on a root item in a tree.</summary>
		/// <param name="iIndex">
		/// <para>Type: <c>int</c></para>
		/// <para>The index at which to insert the root.</para>
		/// </param>
		/// <param name="psiRoot">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the Shell item that is being inserted.</para>
		/// </param>
		/// <param name="grfEnumFlags">
		/// <para>Type: <c>SHCONTF</c></para>
		/// <para>Enumerates the qualities of the root and all of its children. One of the values of type SHCONTF.</para>
		/// </param>
		/// <param name="grfRootStyle">
		/// <para>Type: <c>NSTCROOTSTYLE</c></para>
		/// <para>
		/// The style of the root that is being inserted. One or more of the following values (flags can be combined using a bitwise OR).
		/// </para>
		/// <para>NSTCRS_VISIBLE (0x0000)</para>
		/// <para>The root is visible as well as the items. Mutually exclusive with NSTCRS_HIDDEN.</para>
		/// <para>NSTCRS_HIDDEN (0x0001)</para>
		/// <para>The root is hidden so that only the children are visible. Mutually exclusive with NSTCRS_VISIBLE.</para>
		/// <para>NSTCRS_EXPANDED (0x0002)</para>
		/// <para>The root is expanded upon initialization.</para>
		/// </param>
		/// <param name="pif">
		/// <para>Type: <c>IShellItemFilter*</c></para>
		/// <para>
		/// A pointer to the IShellItemFilter that enables you to filter which items in the tree are displayed. If supplied, every item
		/// is customizable with a SHCONTF flag. This value can be <c>NULL</c> if no filter is required.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-insertroot HRESULT
		// InsertRoot( int iIndex, IShellItem *psiRoot, SHCONTF grfEnumFlags, NSTCROOTSTYLE grfRootStyle, IShellItemFilter *pif );
		[PreserveSig]
		HRESULT InsertRoot(int iIndex, IShellItem psiRoot, SHCONTF grfEnumFlags, NSTCROOTSTYLE grfRootStyle, [In, Optional] IShellItemFilter? pif);

		/// <summary>Removes a root and its children from a tree.</summary>
		/// <param name="psiRoot">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the root that is to be removed.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-removeroot HRESULT
		// RemoveRoot( IShellItem *psiRoot );
		[PreserveSig]
		HRESULT RemoveRoot(IShellItem psiRoot);

		/// <summary>Removes all roots and their children from a tree.</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-removeallroots
		// HRESULT RemoveAllRoots();
		[PreserveSig]
		HRESULT RemoveAllRoots();

		/// <summary>Gets an array of the root items.</summary>
		/// <param name="ppsiaRootItems">
		/// <para>Type: <c>IShellItemArray**</c></para>
		/// <para>A pointer to an array of root items.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-getrootitems HRESULT
		// GetRootItems( IShellItemArray **ppsiaRootItems );
		[PreserveSig]
		HRESULT GetRootItems(out IShellItemArray ppsiaRootItems);

		/// <summary>Sets state information for a Shell item.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the Shell item for which to set the state.</para>
		/// </param>
		/// <param name="nstcisMask">
		/// <para>Type: <c>NSTCITEMSTATE</c></para>
		/// <para>Specifies which information is being set, in the form of a bitmap. One or more of the NSTCITEMSTATE constants.</para>
		/// </param>
		/// <param name="nstcisFlags">
		/// <para>Type: <c>NSTCITEMSTATE</c></para>
		/// <para>A bitmap that contains the values to set for the flags specified in nstcisMask.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// The nstcisMask value specifies which bits in the value pointed to by pnstcisFlags are to be set. Other bits are ignored. As
		/// a simple example, if nstcisMask=NSTCIS_SELECTED, then the first bit in the nstcisFlags value determines whether that flag is
		/// set (1) or removed (0).
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-setitemstate HRESULT
		// SetItemState( IShellItem *psi, NSTCITEMSTATE nstcisMask, NSTCITEMSTATE nstcisFlags );
		[PreserveSig]
		HRESULT SetItemState(IShellItem psi, NSTCITEMSTATE nstcisMask, NSTCITEMSTATE nstcisFlags);

		/// <summary>Gets state information about a Shell item.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the Shell item from which to retrieve the state.</para>
		/// </param>
		/// <param name="nstcisMask">
		/// <para>Type: <c>NSTCITEMSTATE</c></para>
		/// <para>Specifies which information is being requested, in the form of a bitmap. One or more of the NSTCITEMSTATE constants.</para>
		/// </param>
		/// <param name="pnstcisFlags">
		/// <para>Type: <c>NSTCITEMSTATE*</c></para>
		/// <para>When this method returns, points to a bitmap that contains the values requested in nstcisMask.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// The nstcisMask value specifies which bits in the value pointed to by pnstcisFlags are requested. As a simple example, if
		/// nstcisMask=NSTCIS_SELECTED, then only the first bit in the value pointed to by pnstcisFlags is valid when this method
		/// returns. If the first bit in the value pointed to by pnstcisFlags is 1, then the NSTCIS_SELECTED flag is set. If the first
		/// bit in the value pointed to by pnstcisFlags is 0, then the NSTCIS_SELECTED flag is not set.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-getitemstate HRESULT
		// GetItemState( IShellItem *psi, NSTCITEMSTATE nstcisMask, NSTCITEMSTATE *pnstcisFlags );
		[PreserveSig]
		HRESULT GetItemState(IShellItem psi, NSTCITEMSTATE nstcisMask, out NSTCITEMSTATE pnstcisFlags);

		/// <summary>Gets an array of selected Shell items.</summary>
		/// <param name="psiaItems">
		/// <para>Type: <c>IShellItemArray**</c></para>
		/// <para>A pointer to an array of selected Shell items.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-getselecteditems
		// HRESULT GetSelectedItems( IShellItemArray **psiaItems );
		[PreserveSig]
		HRESULT GetSelectedItems(out IShellItemArray psiaItems);

		/// <summary>Gets the state of the checkbox associated with a given Shell item.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the Shell item for which checkbox state is being retrieved.</para>
		/// </param>
		/// <param name="piStateNumber">
		/// <para>Type: <c>int*</c></para>
		/// <para>A pointer to the state of the checkbox for the Shell item.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-getitemcustomstate
		// HRESULT GetItemCustomState( IShellItem *psi, int *piStateNumber );
		[PreserveSig]
		HRESULT GetItemCustomState(IShellItem psi, out int piStateNumber);

		/// <summary>Sets the state of the checkbox associated with the Shell item.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the Shell item for which checkbox state is being set.</para>
		/// </param>
		/// <param name="iStateNumber">
		/// <para>Type: <c>int</c></para>
		/// <para>The desired state of the checkbox for the Shell item.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-setitemcustomstate
		// HRESULT SetItemCustomState( IShellItem *psi, int iStateNumber );
		[PreserveSig]
		HRESULT SetItemCustomState(IShellItem psi, int iStateNumber);

		/// <summary>Ensures that the given item is visible.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the Shell item for which the visibility is being ensured.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-ensureitemvisible
		// HRESULT EnsureItemVisible( IShellItem *psi );
		[PreserveSig]
		HRESULT EnsureItemVisible(IShellItem psi);

		/// <summary>Sets the desktop theme for the current window only.</summary>
		/// <param name="pszTheme">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>The name of the desktop theme to which the current window is being set.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-settheme HRESULT
		// SetTheme( LPCWSTR pszTheme );
		[PreserveSig]
		HRESULT SetTheme([MarshalAs(UnmanagedType.LPWStr)] string? pszTheme);

		/// <summary>Retrieves the next item in the tree according to which method is requested.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>The Shell item for which the next item is being retrieved. This value can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="nstcgi">
		/// <para>Type: <c>NSTCGNI</c></para>
		/// <para>The type of the next item. This value can be one of the following flags:</para>
		/// <para>NSTCGNI_NEXT (0)</para>
		/// <para>The next sibling of the given item.</para>
		/// <para>NSTCGNI_NEXTVISIBLE (1)</para>
		/// <para>
		/// The next visible item in the tree that has any relationship to the given item. This includes a child (if there is one), the
		/// next sibling, or even one of the ancestor's siblings.
		/// </para>
		/// <para>NSTCGNI_PREV (2)</para>
		/// <para>The previous sibling item of the given item.</para>
		/// <para>NSTCGNI_PREVVISIBLE (3)</para>
		/// <para>The previous visible item that is a sibling item, sibling descendent item or a parent item.</para>
		/// <para>NSTCGNI_PARENT (4)</para>
		/// <para>The parent item of the given item.</para>
		/// <para>NSTCGNI_CHILD (5)</para>
		/// <para>The first child item of the given item.</para>
		/// <para>NSTCGNI_FIRSTVISIBLE (6)</para>
		/// <para>The absolute first visible item in the tree (not relative to the given item).</para>
		/// <para>NSTCGNI_LASTVISIBLE (7)</para>
		/// <para>The absolute last visible item in the tree (not relative to the given item).</para>
		/// </param>
		/// <param name="ppsiNext">
		/// <para>Type: <c>IShellItem**</c></para>
		/// <para>The address of a pointer to the IShellItem that fits the criteria for the next item that was requested.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// If there is no next item for the type selected, this function returns E_FAIL with <c>NULL</c> for the returned item, ppsiNext.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-getnextitem HRESULT
		// GetNextItem( IShellItem *psi, NSTCGNI nstcgi, IShellItem **ppsiNext );
		[PreserveSig]
		HRESULT GetNextItem([In] IShellItem? psi, NSTCGNI nstcgi, out IShellItem? ppsiNext);

		/// <summary>Retrieves the item that a given point is in, if any.</summary>
		/// <param name="ppt">
		/// <para>Type: <c>POINT*</c></para>
		/// <para>A pointer to the point to be tested.</para>
		/// </param>
		/// <param name="ppsiOut">
		/// <para>Type: <c>IShellItem**</c></para>
		/// <para>The address of a pointer to the item in which the point exists, or <c>NULL</c> if the point does not exist in an item.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>This function returns <c>S_FALSE</c> with a <c>NULL</c> item if the point does not exist in an item.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-hittest HRESULT
		// HitTest( POINT *ppt, IShellItem **ppsiOut );
		[PreserveSig]
		HRESULT HitTest(in POINT ppt, out IShellItem? ppsiOut);

		/// <summary>Gets the RECT structure that describes the size and position of a given item.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the item for which the RECT structure is being retrieved.</para>
		/// </param>
		/// <param name="prect">
		/// <para>Type: <c>RECT*</c></para>
		/// <para>A pointer to the RECT structure that describes the size and position of the item.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-getitemrect HRESULT
		// GetItemRect( IShellItem *psi, RECT *prect );
		[PreserveSig]
		HRESULT GetItemRect(IShellItem psi, out RECT prect);

		/// <summary>Collapses all of the items in the given tree.</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-collapseall HRESULT CollapseAll();
		[PreserveSig]
		HRESULT CollapseAll();
	}

	/// <summary>
	/// Extends the INameSpaceTreeControl interface by providing methods that get and set the display styles of treeview controls for
	/// use with Shell namespace items.
	/// </summary>
	/// <remarks>
	/// <para>This interface also provides the methods of the INameSpaceTreeControl interface, from which it inherits.</para>
	/// <para>Use class identifier (CLSID) CLSID_NameSpaceTreeControl to instantiate an instance of this interface.</para>
	/// <para>When to Implement</para>
	/// <para>An implementation of this interface is provided with Windows. Third parties should not implement their own versions.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nn-shobjidl-inamespacetreecontrol2
	[PInvokeData("shobjidl.h", MSDNShortId = "5f9514db-35fe-44c7-9324-d69022628913")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("7cc7aed8-290e-49bc-8945-c1401cc9306c"), CoClass(typeof(NameSpaceTreeControl))]
	public interface INameSpaceTreeControl2 : INameSpaceTreeControl
	{
		/// <summary>Initializes an INameSpaceTreeControl object.</summary>
		/// <param name="hwndParent">
		/// <para>Type: <c>HWND</c></para>
		/// <para>The handle of the parent window.</para>
		/// </param>
		/// <param name="prc">
		/// <para>Type: <c>RECT*</c></para>
		/// <para>A pointer to a RECT structure that describes the size and position of the control in the client window.</para>
		/// </param>
		/// <param name="nsctsFlags">
		/// <para>Type: <c>NSTCSTYLE</c></para>
		/// <para>The characteristics of the given namespace tree control. One or more of the following values from the NSTCSTYLE enumeration.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-initialize HRESULT
		// Initialize( HWND hwndParent, RECT *prc, NSTCSTYLE nsctsFlags );
		[PreserveSig]
		new HRESULT Initialize(HWND hwndParent, in RECT prc, NSTCSTYLE nsctsFlags);

		/// <summary>Enables a client to register with the control.</summary>
		/// <param name="punk">
		/// <para>Type: <c>IUnknown*</c></para>
		/// <para>A pointer to the client IUnknown that registers with the control.</para>
		/// </param>
		/// <param name="pdwCookie">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>A pointer to the cookie that is passed back for registration.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>The pointer to the cookie that is passed back is used to unregister the control later with INameSpaceTreeControl::TreeUnadvise.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-treeadvise HRESULT
		// TreeAdvise( IUnknown *punk, DWORD *pdwCookie );
		[PreserveSig]
		new HRESULT TreeAdvise([MarshalAs(UnmanagedType.IUnknown)] object punk, out uint pdwCookie);

		/// <summary>Enables a client to unregister with the control.</summary>
		/// <param name="dwCookie">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>A pointer to the cookie that is to be unregistered.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>The pointer to the cookie that is passed in is the one that was passed back in INameSpaceTreeControl::TreeAdvise.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-treeunadvise HRESULT
		// TreeUnadvise( DWORD dwCookie );
		[PreserveSig]
		new HRESULT TreeUnadvise(uint dwCookie);

		/// <summary>Appends a Shell item to the list of roots in a tree.</summary>
		/// <param name="psiRoot">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>Pointer to the Shell item that is being appended.</para>
		/// </param>
		/// <param name="grfEnumFlags">
		/// <para>Type: <c>SHCONTF</c></para>
		/// <para>
		/// Enumerates the qualities of the root and all of its children. One or more of the values of type SHCONTF. These flags can be
		/// combined using a bitwise OR.
		/// </para>
		/// </param>
		/// <param name="grfRootStyle">
		/// <para>Type: <c>NSTCROOTSTYLE</c></para>
		/// <para>Specifies the style of the root that is being appended. One or more of the following values:</para>
		/// <para>NSTCRS_VISIBLE (0x0000)</para>
		/// <para>The root is visible as well as the items. Mutually exclusive with NSTCRS_HIDDEN.</para>
		/// <para>NSTCRS_HIDDEN (0x0001)</para>
		/// <para>The root is hidden so that the children only are visible. Mutually exclusive with NSTCRS_VISIBLE.</para>
		/// <para>NSTCRS_EXPANDED (0x0002)</para>
		/// <para>The root is expanded upon initialization.</para>
		/// </param>
		/// <param name="pif">
		/// <para>Type: <c>IShellItemFilter*</c></para>
		/// <para>
		/// Pointer to the IShellItemFilter that enables you to filter which items in the tree are displayed. If supplied, every item is
		/// customizable with a SHCONTF flag. This value can be <c>NULL</c> if no filter is required.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-appendroot HRESULT
		// AppendRoot( IShellItem *psiRoot, SHCONTF grfEnumFlags, NSTCROOTSTYLE grfRootStyle, IShellItemFilter *pif );
		[PreserveSig]
		new HRESULT AppendRoot(IShellItem psiRoot, SHCONTF grfEnumFlags, NSTCROOTSTYLE grfRootStyle, [In] IShellItemFilter? pif);

		/// <summary>Inserts a Shell item on a root item in a tree.</summary>
		/// <param name="iIndex">
		/// <para>Type: <c>int</c></para>
		/// <para>The index at which to insert the root.</para>
		/// </param>
		/// <param name="psiRoot">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the Shell item that is being inserted.</para>
		/// </param>
		/// <param name="grfEnumFlags">
		/// <para>Type: <c>SHCONTF</c></para>
		/// <para>Enumerates the qualities of the root and all of its children. One of the values of type SHCONTF.</para>
		/// </param>
		/// <param name="grfRootStyle">
		/// <para>Type: <c>NSTCROOTSTYLE</c></para>
		/// <para>
		/// The style of the root that is being inserted. One or more of the following values (flags can be combined using a bitwise OR).
		/// </para>
		/// <para>NSTCRS_VISIBLE (0x0000)</para>
		/// <para>The root is visible as well as the items. Mutually exclusive with NSTCRS_HIDDEN.</para>
		/// <para>NSTCRS_HIDDEN (0x0001)</para>
		/// <para>The root is hidden so that only the children are visible. Mutually exclusive with NSTCRS_VISIBLE.</para>
		/// <para>NSTCRS_EXPANDED (0x0002)</para>
		/// <para>The root is expanded upon initialization.</para>
		/// </param>
		/// <param name="pif">
		/// <para>Type: <c>IShellItemFilter*</c></para>
		/// <para>
		/// A pointer to the IShellItemFilter that enables you to filter which items in the tree are displayed. If supplied, every item
		/// is customizable with a SHCONTF flag. This value can be <c>NULL</c> if no filter is required.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-insertroot HRESULT
		// InsertRoot( int iIndex, IShellItem *psiRoot, SHCONTF grfEnumFlags, NSTCROOTSTYLE grfRootStyle, IShellItemFilter *pif );
		[PreserveSig]
		new HRESULT InsertRoot(int iIndex, IShellItem psiRoot, SHCONTF grfEnumFlags, NSTCROOTSTYLE grfRootStyle, [In] IShellItemFilter? pif);

		/// <summary>Removes a root and its children from a tree.</summary>
		/// <param name="psiRoot">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the root that is to be removed.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-removeroot HRESULT
		// RemoveRoot( IShellItem *psiRoot );
		[PreserveSig]
		new HRESULT RemoveRoot(IShellItem psiRoot);

		/// <summary>Removes all roots and their children from a tree.</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-removeallroots
		// HRESULT RemoveAllRoots();
		[PreserveSig]
		new HRESULT RemoveAllRoots();

		/// <summary>Gets an array of the root items.</summary>
		/// <param name="ppsiaRootItems">
		/// <para>Type: <c>IShellItemArray**</c></para>
		/// <para>A pointer to an array of root items.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-getrootitems HRESULT
		// GetRootItems( IShellItemArray **ppsiaRootItems );
		[PreserveSig]
		new HRESULT GetRootItems(out IShellItemArray ppsiaRootItems);

		/// <summary>Sets state information for a Shell item.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the Shell item for which to set the state.</para>
		/// </param>
		/// <param name="nstcisMask">
		/// <para>Type: <c>NSTCITEMSTATE</c></para>
		/// <para>Specifies which information is being set, in the form of a bitmap. One or more of the NSTCITEMSTATE constants.</para>
		/// </param>
		/// <param name="nstcisFlags">
		/// <para>Type: <c>NSTCITEMSTATE</c></para>
		/// <para>A bitmap that contains the values to set for the flags specified in nstcisMask.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// The nstcisMask value specifies which bits in the value pointed to by pnstcisFlags are to be set. Other bits are ignored. As
		/// a simple example, if nstcisMask=NSTCIS_SELECTED, then the first bit in the nstcisFlags value determines whether that flag is
		/// set (1) or removed (0).
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-setitemstate HRESULT
		// SetItemState( IShellItem *psi, NSTCITEMSTATE nstcisMask, NSTCITEMSTATE nstcisFlags );
		[PreserveSig]
		new HRESULT SetItemState(IShellItem psi, NSTCITEMSTATE nstcisMask, NSTCITEMSTATE nstcisFlags);

		/// <summary>Gets state information about a Shell item.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the Shell item from which to retrieve the state.</para>
		/// </param>
		/// <param name="nstcisMask">
		/// <para>Type: <c>NSTCITEMSTATE</c></para>
		/// <para>Specifies which information is being requested, in the form of a bitmap. One or more of the NSTCITEMSTATE constants.</para>
		/// </param>
		/// <param name="pnstcisFlags">
		/// <para>Type: <c>NSTCITEMSTATE*</c></para>
		/// <para>When this method returns, points to a bitmap that contains the values requested in nstcisMask.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// The nstcisMask value specifies which bits in the value pointed to by pnstcisFlags are requested. As a simple example, if
		/// nstcisMask=NSTCIS_SELECTED, then only the first bit in the value pointed to by pnstcisFlags is valid when this method
		/// returns. If the first bit in the value pointed to by pnstcisFlags is 1, then the NSTCIS_SELECTED flag is set. If the first
		/// bit in the value pointed to by pnstcisFlags is 0, then the NSTCIS_SELECTED flag is not set.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-getitemstate HRESULT
		// GetItemState( IShellItem *psi, NSTCITEMSTATE nstcisMask, NSTCITEMSTATE *pnstcisFlags );
		[PreserveSig]
		new HRESULT GetItemState(IShellItem psi, NSTCITEMSTATE nstcisMask, out NSTCITEMSTATE pnstcisFlags);

		/// <summary>Gets an array of selected Shell items.</summary>
		/// <param name="psiaItems">
		/// <para>Type: <c>IShellItemArray**</c></para>
		/// <para>A pointer to an array of selected Shell items.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-getselecteditems
		// HRESULT GetSelectedItems( IShellItemArray **psiaItems );
		[PreserveSig]
		new HRESULT GetSelectedItems(out IShellItemArray psiaItems);

		/// <summary>Gets the state of the checkbox associated with a given Shell item.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the Shell item for which checkbox state is being retrieved.</para>
		/// </param>
		/// <param name="piStateNumber">
		/// <para>Type: <c>int*</c></para>
		/// <para>A pointer to the state of the checkbox for the Shell item.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-getitemcustomstate
		// HRESULT GetItemCustomState( IShellItem *psi, int *piStateNumber );
		[PreserveSig]
		new HRESULT GetItemCustomState(IShellItem psi, out int piStateNumber);

		/// <summary>Sets the state of the checkbox associated with the Shell item.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the Shell item for which checkbox state is being set.</para>
		/// </param>
		/// <param name="iStateNumber">
		/// <para>Type: <c>int</c></para>
		/// <para>The desired state of the checkbox for the Shell item.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-setitemcustomstate
		// HRESULT SetItemCustomState( IShellItem *psi, int iStateNumber );
		[PreserveSig]
		new HRESULT SetItemCustomState(IShellItem psi, int iStateNumber);

		/// <summary>Ensures that the given item is visible.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the Shell item for which the visibility is being ensured.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-ensureitemvisible
		// HRESULT EnsureItemVisible( IShellItem *psi );
		[PreserveSig]
		new HRESULT EnsureItemVisible(IShellItem psi);

		/// <summary>Sets the desktop theme for the current window only.</summary>
		/// <param name="pszTheme">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>The name of the desktop theme to which the current window is being set.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-settheme HRESULT
		// SetTheme( LPCWSTR pszTheme );
		[PreserveSig]
		new HRESULT SetTheme([MarshalAs(UnmanagedType.LPWStr)] string pszTheme);

		/// <summary>Retrieves the next item in the tree according to which method is requested.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>The Shell item for which the next item is being retrieved. This value can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="nstcgi">
		/// <para>Type: <c>NSTCGNI</c></para>
		/// <para>The type of the next item. This value can be one of the following flags:</para>
		/// <para>NSTCGNI_NEXT (0)</para>
		/// <para>The next sibling of the given item.</para>
		/// <para>NSTCGNI_NEXTVISIBLE (1)</para>
		/// <para>
		/// The next visible item in the tree that has any relationship to the given item. This includes a child (if there is one), the
		/// next sibling, or even one of the ancestor's siblings.
		/// </para>
		/// <para>NSTCGNI_PREV (2)</para>
		/// <para>The previous sibling item of the given item.</para>
		/// <para>NSTCGNI_PREVVISIBLE (3)</para>
		/// <para>The previous visible item that is a sibling item, sibling descendent item or a parent item.</para>
		/// <para>NSTCGNI_PARENT (4)</para>
		/// <para>The parent item of the given item.</para>
		/// <para>NSTCGNI_CHILD (5)</para>
		/// <para>The first child item of the given item.</para>
		/// <para>NSTCGNI_FIRSTVISIBLE (6)</para>
		/// <para>The absolute first visible item in the tree (not relative to the given item).</para>
		/// <para>NSTCGNI_LASTVISIBLE (7)</para>
		/// <para>The absolute last visible item in the tree (not relative to the given item).</para>
		/// </param>
		/// <param name="ppsiNext">
		/// <para>Type: <c>IShellItem**</c></para>
		/// <para>The address of a pointer to the IShellItem that fits the criteria for the next item that was requested.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// If there is no next item for the type selected, this function returns E_FAIL with <c>NULL</c> for the returned item, ppsiNext.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-getnextitem HRESULT
		// GetNextItem( IShellItem *psi, NSTCGNI nstcgi, IShellItem **ppsiNext );
		[PreserveSig]
		new HRESULT GetNextItem([In] IShellItem? psi, NSTCGNI nstcgi, out IShellItem? ppsiNext);

		/// <summary>Retrieves the item that a given point is in, if any.</summary>
		/// <param name="ppt">
		/// <para>Type: <c>POINT*</c></para>
		/// <para>A pointer to the point to be tested.</para>
		/// </param>
		/// <param name="ppsiOut">
		/// <para>Type: <c>IShellItem**</c></para>
		/// <para>The address of a pointer to the item in which the point exists, or <c>NULL</c> if the point does not exist in an item.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>This function returns <c>S_FALSE</c> with a <c>NULL</c> item if the point does not exist in an item.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-hittest HRESULT
		// HitTest( POINT *ppt, IShellItem **ppsiOut );
		[PreserveSig]
		new HRESULT HitTest(in POINT ppt, out IShellItem? ppsiOut);

		/// <summary>Gets the RECT structure that describes the size and position of a given item.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the item for which the RECT structure is being retrieved.</para>
		/// </param>
		/// <param name="prect">
		/// <para>Type: <c>RECT*</c></para>
		/// <para>A pointer to the RECT structure that describes the size and position of the item.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-getitemrect HRESULT
		// GetItemRect( IShellItem *psi, RECT *prect );
		[PreserveSig]
		new HRESULT GetItemRect(IShellItem psi, out RECT prect);

		/// <summary>Collapses all of the items in the given tree.</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrol-collapseall HRESULT CollapseAll();
		[PreserveSig]
		new HRESULT CollapseAll();

		/// <summary>Sets the display styles for the namespace object's treeview controls.</summary>
		/// <param name="nstcsMask">
		/// <para>Type: <c>NSTCSTYLE</c></para>
		/// <para>One or more of the NSTCSTYLE constants that specify the styles for which the method should set new values.</para>
		/// </param>
		/// <param name="nstcsStyle">
		/// <para>Type: <c>NSTCSTYLE</c></para>
		/// <para>
		/// A bitmap that contains the new values for the styles specified in nstcsMask. If the bit that represents the individual
		/// NSTCSTYLE value is 0, that style is not used. If the value is 1, the style is applied to the treeview. Styles in positions
		/// not specified in nstcsMask are left at their current setting regardless of their bit's value in this bitmap.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-inamespacetreecontrol2-setcontrolstyle HRESULT
		// SetControlStyle( NSTCSTYLE nstcsMask, NSTCSTYLE nstcsStyle );
		[PreserveSig]
		HRESULT SetControlStyle(NSTCSTYLE nstcsMask, NSTCSTYLE nstcsStyle);

		/// <summary>Gets the display styles set for the namespace object's treeview controls.</summary>
		/// <param name="nstcsMask">
		/// <para>Type: <c>NSTCSTYLE</c></para>
		/// <para>One or more of the NSTCSTYLE constants that specify the values for which the method should retrieve the current settings.</para>
		/// </param>
		/// <param name="pnstcsStyle">
		/// <para>Type: <c>NSTCSTYLE*</c></para>
		/// <para>
		/// Pointer to a value that, when this method returns successfully, receives the values requested in nstcsMask. If the bit that
		/// represents the individual NSTCSTYLE value is 0, that value is not set. If the value is 1, it is the current setting. Bit
		/// values in positions not specifically requested in nstcsMask do not necessarily reflect the current settings and should not
		/// be used.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-inamespacetreecontrol2-getcontrolstyle HRESULT
		// GetControlStyle( NSTCSTYLE nstcsMask, NSTCSTYLE *pnstcsStyle );
		[PreserveSig]
		HRESULT GetControlStyle(NSTCSTYLE nstcsMask, out NSTCSTYLE pnstcsStyle);

		/// <summary>Sets the extended display styles for the namespace object's treeview controls.</summary>
		/// <param name="nstcsMask">
		/// <para>Type: <c>NSTCSTYLE2</c></para>
		/// <para>One or more of the NSTCSTYLE2 constants that specify the styles for which the method should set new values.</para>
		/// </param>
		/// <param name="nstcsStyle">
		/// <para>Type: <c>NSTCSTYLE2</c></para>
		/// <para>
		/// A bitmap that contains the new values for the styles specified in nstcsMask. If the bit that represents the individual
		/// NSTCSTYLE2 value is 0, that style is not used. If the value is 1, the style is applied to the treeview. Styles in positions
		/// not specified in nstcsMask are left at their current setting regardless of their bit's value in this bitmap.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-inamespacetreecontrol2-setcontrolstyle2 HRESULT
		// SetControlStyle2( NSTCSTYLE2 nstcsMask, NSTCSTYLE2 nstcsStyle );
		[PreserveSig]
		HRESULT SetControlStyle2(NSTCSTYLE2 nstcsMask, NSTCSTYLE2 nstcsStyle);

		/// <summary>Gets the extended display styles set for the namespace object's treeview controls.</summary>
		/// <param name="nstcsMask">
		/// <para>Type: <c>NSTCSTYLE2</c></para>
		/// <para>One or more of the NSTCSTYLE2 constants that specify the values for which the method should retrieve the current settings.</para>
		/// </param>
		/// <param name="pnstcsStyle">
		/// <para>Type: <c>NSTCSTYLE2*</c></para>
		/// <para>
		/// Pointer to a value that, when this method returns successfully, receives the values requested in nstcsMask. If the bit that
		/// represents the individual NSTCSTYLE2 value is 0, that value is not set. If the value is 1, it is the current setting. Bit
		/// values in positions not specifically requested in nstcsMask do not necessarily reflect the current settings and should not
		/// be used.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-inamespacetreecontrol2-getcontrolstyle2 HRESULT
		// GetControlStyle2( NSTCSTYLE2 nstcsMask, NSTCSTYLE2 *pnstcsStyle );
		[PreserveSig]
		HRESULT GetControlStyle2(NSTCSTYLE2 nstcsMask, out NSTCSTYLE2 pnstcsStyle);
	}

	/// <summary>
	/// Exposes handler methods for drag-and-drop. Used by the namespace tree control to notify the client of any drag-and-drop
	/// operation happening within the control. Provides a way for a client to intercept a drop operation and perform its own action, or
	/// to return the desired drop effect.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nn-shobjidl-inamespacetreecontroldrophandler
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("F9C665D6-C2F2-4c19-BF33-8322D7352F51")]
	public interface INameSpaceTreeControlDropHandler
	{
		/// <summary>Called on drag enter to set drag effect, as specified.</summary>
		/// <param name="psiOver">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to an IShellItem interface representing the item underneath the mouse cursor. Optional.</para>
		/// </param>
		/// <param name="psiaData">
		/// <para>Type: <c>IShellItemArray*</c></para>
		/// <para>A pointer to an IShellItem array containing the items being dragged.</para>
		/// </param>
		/// <param name="fOutsideSource">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Specifies whether drag started outside target area.</para>
		/// </param>
		/// <param name="grfKeyState">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The current state of keyboard modifier keys.</para>
		/// </param>
		/// <param name="pdwEffect">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>On success, contains a pointer to the drag effect value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>Failing this method blocks the drag operation in the namespace tree control (NSTC).</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-inamespacetreecontroldrophandler-ondragenter HRESULT
		// OnDragEnter( IShellItem *psiOver, IShellItemArray *psiaData, BOOL fOutsideSource, DWORD grfKeyState, DWORD *pdwEffect );
		[PreserveSig]
		HRESULT OnDragEnter([In, Optional] IShellItem? psiOver, [In] IShellItemArray psiaData, [MarshalAs(UnmanagedType.Bool)] bool fOutsideSource, uint grfKeyState, ref uint pdwEffect);

		/// <summary>Called on drag over to set drag effect, as specified.</summary>
		/// <param name="psiOver">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to an IShellItem interface representing the item underneath the mouse cursor. Optional.</para>
		/// </param>
		/// <param name="psiaData">
		/// <para>Type: <c>IShellItemArray*</c></para>
		/// <para>A pointer to an IShellItem array containing the items being dragged.</para>
		/// </param>
		/// <param name="grfKeyState">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The current state of keyboard modifier keys.</para>
		/// </param>
		/// <param name="pdwEffect">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>On success, contains a pointer to the drag effect value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>Failing this method blocks the drag operation in the namespace tree control (NSTC).</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-inamespacetreecontroldrophandler-ondragover HRESULT
		// OnDragOver( IShellItem *psiOver, IShellItemArray *psiaData, DWORD grfKeyState, DWORD *pdwEffect );
		[PreserveSig]
		HRESULT OnDragOver([In, Optional] IShellItem? psiOver, [In] IShellItemArray psiaData, uint grfKeyState, ref uint pdwEffect);

		/// <summary>Called when the item is being dragged within the same level (within the same parent folder) in the tree.</summary>
		/// <param name="psiOver">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to an IShellItem interface representing the item underneath the mouse cursor. Optional.</para>
		/// </param>
		/// <param name="psiaData">
		/// <para>Type: <c>IShellItemArray*</c></para>
		/// <para>A pointer to an IShellItem array containing the items being dragged.</para>
		/// </param>
		/// <param name="iNewPosition">
		/// <para>Type: <c>int</c></para>
		/// <para>The index if the item being dragged is between items; otherwise, NSTCDHPOS_ONTOP (-1).</para>
		/// </param>
		/// <param name="iOldPosition">
		/// <para>Type: <c>int</c></para>
		/// <para>The old position.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>Failing this method prevents the item rearrangment.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-inamespacetreecontroldrophandler-ondragposition
		// HRESULT OnDragPosition( IShellItem *psiOver, IShellItemArray *psiaData, int iNewPosition, int iOldPosition );
		[PreserveSig]
		HRESULT OnDragPosition([In, Optional] IShellItem? psiOver, [In] IShellItemArray psiaData, int iNewPosition, int iOldPosition);

		/// <summary>Called on drop to set drop effect, as specified.</summary>
		/// <param name="psiOver">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to an IShellItem interface representing the item underneath the mouse cursor. Optional.</para>
		/// </param>
		/// <param name="psiaData">
		/// <para>Type: <c>IShellItemArray*</c></para>
		/// <para>A pointer to an IShellItem array representing a data object.</para>
		/// </param>
		/// <param name="iPosition">
		/// <para>Type: <c>int</c></para>
		/// <para>Specifies drop position.</para>
		/// </param>
		/// <param name="grfKeyState">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The current state of keyboard modifier keys.</para>
		/// </param>
		/// <param name="pdwEffect">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>A pointer to the drop effect value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <c>Note</c> To overwrite the default drop behavior, a client should fail this method; success proceeds with the default drop operation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-inamespacetreecontroldrophandler-ondrop HRESULT
		// OnDrop( IShellItem *psiOver, IShellItemArray *psiaData, int iPosition, DWORD grfKeyState, DWORD *pdwEffect );
		[PreserveSig]
		HRESULT OnDrop([In, Optional] IShellItem? psiOver, [In] IShellItemArray psiaData, int iPosition, uint grfKeyState, ref uint pdwEffect);

		/// <summary>Called when the item is being dropped within the same level (within the same parent folder) in the tree.</summary>
		/// <param name="psiOver">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to an IShellItem interface representing the item underneath the mouse cursor. Optional.</para>
		/// </param>
		/// <param name="psiaData">
		/// <para>Type: <c>IShellItemArray*</c></para>
		/// <para>A pointer to an IShellItem array representing a data object.</para>
		/// </param>
		/// <param name="iNewPosition">
		/// <para>Type: <c>int</c></para>
		/// <para>The index if the item being dropped is between items; otherwise, NSTCDHPOS_ONTOP (-1).</para>
		/// </param>
		/// <param name="iOldPosition">
		/// <para>Type: <c>int</c></para>
		/// <para>Specifies old position.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>Failing this method prevents the item rearrangment from happening.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-inamespacetreecontroldrophandler-ondropposition
		// HRESULT OnDropPosition( IShellItem *psiOver, IShellItemArray *psiaData, int iNewPosition, int iOldPosition );
		[PreserveSig]
		HRESULT OnDropPosition([In, Optional] IShellItem? psiOver, [In] IShellItemArray psiaData, int iNewPosition, int iOldPosition);

		/// <summary>Called on drag leave for a specified item.</summary>
		/// <param name="psiOver">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to an IShellItem interface representing the item underneath the mouse cursor. Optional.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-inamespacetreecontroldrophandler-ondragleave HRESULT
		// OnDragLeave( IShellItem *psiOver );
		[PreserveSig]
		HRESULT OnDragLeave([In, Optional] IShellItem? psiOver);
	}

	/// <summary>Exposes methods for handling INameSpaceTreeControl events.</summary>
	/// <remarks>
	/// This interface is implemented by a client of namespace control (CLSID_NameSpaceTreeControl) to be advised of namespace control
	/// events so that the client may process these events and if not, allow the namespace control to process them.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nn-shobjidl-inamespacetreecontrolevents
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("93D77985-B3D8-4484-8318-672CDDA002CE")]
	public interface INameSpaceTreeControlEvents
	{
		/// <summary>Called when the user clicks a button on the mouse.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>The IShellItem that was clicked.</para>
		/// </param>
		/// <param name="nstceHitTest">
		/// <para>Type: <c>NSTCEHITTEST</c></para>
		/// <para>The location on the IShellItem that was clicked. One of the following values:</para>
		/// <para>NSTCEHT_NOWHERE (0x0001)</para>
		/// <para>The click missed the IShellItem.</para>
		/// <para>NSTCEHT_ONITEMICON (0x0002)</para>
		/// <para>The click was on the icon of the IShellItem.</para>
		/// <para>NSTCEHT_ONITEMLABEL (0x0004)</para>
		/// <para>The click was on the label text of the IShellItem.</para>
		/// <para>NSTCEHT_ONITEMINDENT (0x0008)</para>
		/// <para>The click was on the indented space on the leftmost side of the IShellItem.</para>
		/// <para>NSTCEHT_ONITEMBUTTON (0x0010)</para>
		/// <para>The click was on the expando button of the IShellItem.</para>
		/// <para>NSTCEHT_ONITEMRIGHT (0x0020)</para>
		/// <para>The click was on the rightmost side of the text of the IShellItem.</para>
		/// <para>NSTCEHT_ONITEMSTATEICON (0x0040)</para>
		/// <para>The click was on the state icon of the IShellItem.</para>
		/// <para>NSTCEHT_ONITEM (0x0046)</para>
		/// <para>The click was on the item icon or the item label or the state icon of the IShellItem.</para>
		/// <para>NSTCEHT_ONITEMTABBUTTON (0x1000)</para>
		/// <para>The click was on the tab button of the IShellItem.</para>
		/// </param>
		/// <param name="nstceClickType">
		/// <para>Type: <c>NSTCSTYLE</c></para>
		/// <para>Indicates which button was clicked and the kind of click. One of the following values:</para>
		/// <para>NSTCECT_LBUTTON (0x0001)</para>
		/// <para>The left button was clicked.</para>
		/// <para>NSTCECT_MBUTTON (0x0002)</para>
		/// <para>The middle button was clicked.</para>
		/// <para>NSTCECT_RBUTTON (0x0003)</para>
		/// <para>The right button was clicked.</para>
		/// <para>NSTCECT_BUTTON (0x0003)</para>
		/// <para>A button was clicked.</para>
		/// <para>NSTCECT_DBLCLICK (0x0004)</para>
		/// <para>The click was a double click. If this value is present, it is added to one of the other values.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// If this method fails, the event is processed by both INameSpaceTreeControl and TreeView. If it returns S_OK, then only
		/// <c>INameSpaceTreeControl</c> will process the event.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-inamespacetreecontrolevents-onitemclick HRESULT
		// OnItemClick( IShellItem *psi, NSTCEHITTEST nstceHitTest, NSTCECLICKTYPE nstceClickType );
		[PreserveSig]
		HRESULT OnItemClick([In] IShellItem psi, NSTCEHITTEST nstceHitTest, NSTCECLICKTYPE nstceClickType);

		/// <summary>Not implemented.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>Not used.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns E_NOTIMPL.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-inamespacetreecontrolevents-onpropertyitemcommit
		// HRESULT OnPropertyItemCommit( IShellItem *psi );
		[PreserveSig]
		HRESULT OnPropertyItemCommit([In] IShellItem psi);

		/// <summary>Called before the state of an item changes.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the Shell item for which the state is going to change.</para>
		/// </param>
		/// <param name="nstcisMask">
		/// <para>Type: <c>NSTCITEMSTATE</c></para>
		/// <para>
		/// One or more values from the NSTCITEMSTATE enumeration that indicate which pieces of information the calling application
		/// wants to set.
		/// </para>
		/// </param>
		/// <param name="nstcisState">
		/// <para>Type: <c>NSTCITEMSTATE</c></para>
		/// <para>One or more values from the NSTCITEMSTATE enumeration that indicate the values that are to be set.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-inamespacetreecontrolevents-onitemstatechanging
		// HRESULT OnItemStateChanging( IShellItem *psi, NSTCITEMSTATE nstcisMask, NSTCITEMSTATE nstcisState );
		[PreserveSig]
		HRESULT OnItemStateChanging([In] IShellItem psi, NSTCITEMSTATE nstcisMask, NSTCITEMSTATE nstcisState);

		/// <summary>Not implemented.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the shell item for which the state has changed.</para>
		/// </param>
		/// <param name="nstcisMask">
		/// <para>Type: <c>NSTCITEMSTATE</c></para>
		/// <para>
		/// One or more values from the NSTCITEMSTATE enumeration that indicates what pieces of information the caller wants to set.
		/// </para>
		/// </param>
		/// <param name="nstcisState">
		/// <para>Type: <c>NSTCITEMSTATE</c></para>
		/// <para>One or more values from the NSTCITEMSTATE enumeration that indicates the values that are to be set.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-inamespacetreecontrolevents-onitemstatechanged
		// HRESULT OnItemStateChanged( IShellItem *psi, NSTCITEMSTATE nstcisMask, NSTCITEMSTATE nstcisState );
		[PreserveSig]
		HRESULT OnItemStateChanged([In] IShellItem psi, NSTCITEMSTATE nstcisMask, NSTCITEMSTATE nstcisState);

		/// <summary>Called when the selection changes.</summary>
		/// <param name="psiaSelection">
		/// <para>Type: <c>IShellItemArray*</c></para>
		/// <para>An array of IShellItem objects that contains the new selection.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-inamespacetreecontrolevents-onselectionchanged
		// HRESULT OnSelectionChanged( IShellItemArray *psiaSelection );
		[PreserveSig]
		HRESULT OnSelectionChanged([In] IShellItemArray psiaSelection);

		/// <summary>Called when the user presses a key on the keyboard.</summary>
		/// <param name="uMsg">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The message value.</para>
		/// </param>
		/// <param name="wParam">
		/// <para>Type: <c>WPARAM</c></para>
		/// <para>Specifies the WParam parameters of the message.</para>
		/// </param>
		/// <param name="lParam">
		/// <para>Type: <c>LPARAM</c></para>
		/// <para>Specifies the LParam parameters of the message.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// This method receives its message directly from WndProc. When this returns S_OK, the message was not consumed and the
		/// namespace tree control is allowed to process the message. Otherwise this message was handled, with no further action required.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-inamespacetreecontrolevents-onkeyboardinput HRESULT
		// OnKeyboardInput( UINT uMsg, WPARAM wParam, LPARAM lParam );
		[PreserveSig]
		HRESULT OnKeyboardInput(uint uMsg, IntPtr wParam, IntPtr lParam);

		/// <summary>Called before an IShellItem is expanded.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the IShellItem that is to be expanded.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-inamespacetreecontrolevents-onbeforeexpand HRESULT
		// OnBeforeExpand( IShellItem *psi );
		[PreserveSig]
		HRESULT OnBeforeExpand([In] IShellItem psi);

		/// <summary>Called after an IShellItem is expanded.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the IShellItem that was expanded.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-inamespacetreecontrolevents-onafterexpand HRESULT
		// OnAfterExpand( IShellItem *psi );
		[PreserveSig]
		HRESULT OnAfterExpand([In] IShellItem psi);

		/// <summary>Called before the IShellItem goes into edit mode.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>Pointer to the IShellItem for which the text is to be edited.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>If this method fails, the transition to edit mode is not canceled.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-inamespacetreecontrolevents-onbeginlabeledit HRESULT
		// OnBeginLabelEdit( IShellItem *psi );
		[PreserveSig]
		HRESULT OnBeginLabelEdit([In] IShellItem psi);

		/// <summary>Called after the IShellItem leaves edit mode.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the IShellItem for which the text was edited.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-inamespacetreecontrolevents-onendlabeledit HRESULT
		// OnEndLabelEdit( IShellItem *psi );
		[PreserveSig]
		HRESULT OnEndLabelEdit([In] IShellItem psi);

		/// <summary>Enables you to provide a tooltip.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>Pointer to the IShellItem that contains the tooltip.</para>
		/// </param>
		/// <param name="pszTip">
		/// <para>Type: <c>LPWSTR</c></para>
		/// <para>When this method returns, contains the text of the tooltip.</para>
		/// </param>
		/// <param name="cchTip">
		/// <para>Type: <c>int</c></para>
		/// <para>The size of the tooltip in characters.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// If this method returns S_OK, the client provides its own tooltip. Otherwise the INameSpaceTreeControl will extract one.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-inamespacetreecontrolevents-ongettooltip HRESULT
		// OnGetToolTip( IShellItem *psi, LPWSTR pszTip, int cchTip );
		[PreserveSig]
		HRESULT OnGetToolTip([In] IShellItem psi, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszTip, int cchTip);

		/// <summary>Called before an IShellItem and all of its children are deleted.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the IShellItem that is to be deleted.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>If this method fails, the given IShellItem and its children are still deleted.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-inamespacetreecontrolevents-onbeforeitemdelete
		// HRESULT OnBeforeItemDelete( IShellItem *psi );
		[PreserveSig]
		HRESULT OnBeforeItemDelete([In] IShellItem psi);

		/// <summary>Called after an IShellItem has been added.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the IShellItem that was added.</para>
		/// </param>
		/// <param name="fIsRoot">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Specifies whether the IShellItem that was added is a root.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-inamespacetreecontrolevents-onitemadded HRESULT
		// OnItemAdded( IShellItem *psi, BOOL fIsRoot );
		[PreserveSig]
		HRESULT OnItemAdded([In] IShellItem psi, [MarshalAs(UnmanagedType.Bool)] bool fIsRoot);

		/// <summary>Called after an IShellItem has been deleted.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the IShellItem that was deleted.</para>
		/// </param>
		/// <param name="fIsRoot">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Specifies whether the IShellItem that was deleted is a root.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-inamespacetreecontrolevents-onitemdeleted HRESULT
		// OnItemDeleted( IShellItem *psi, BOOL fIsRoot );
		[PreserveSig]
		HRESULT OnItemDeleted([In] IShellItem psi, [MarshalAs(UnmanagedType.Bool)] bool fIsRoot);

		/// <summary>Called before a context menu is displayed; allows client to add additional menu entries.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the IShellItem from which the context menu is generated. This value can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>Reference to the IID of the context menu.</para>
		/// </param>
		/// <param name="ppv">
		/// <para>Type: <c>void**</c></para>
		/// <para>When this methods returns, contains the address of a pointer to the interface specified by riid.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-inamespacetreecontrolevents-onbeforecontextmenu
		// HRESULT OnBeforeContextMenu( IShellItem *psi, REFIID riid, void **ppv );
		[PreserveSig]
		HRESULT OnBeforeContextMenu([In, Optional] IShellItem? psi, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppv);

		/// <summary>Called after a context menu is displayed.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>
		/// A pointer to the IShellItem from which the context menu is generated. This value can be <c>NULL</c> only if the
		/// NSTCS2_SHOWNULLSPACEMENU flag is set.
		/// </para>
		/// </param>
		/// <param name="pcmIn">
		/// <para>Type: <c>IContextMenu*</c></para>
		/// <para>A pointer to the context menu.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>Reference to the IID of the context menu.</para>
		/// </param>
		/// <param name="ppv">
		/// <para>Type: <c>void**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the interface specified in riid.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// This method allows client to completely replace the context menu. This method will allow the client to use the context menu
		/// returned by ppv and not necessarily the one specified in pcmIn.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-inamespacetreecontrolevents-onaftercontextmenu
		// HRESULT OnAfterContextMenu( IShellItem *psi, IContextMenu *pcmIn, REFIID riid, void **ppv );
		[PreserveSig]
		HRESULT OnAfterContextMenu([In, Optional] IShellItem? psi, [In] IContextMenu pcmIn, [In] in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppv);

		/// <summary>Called before the state icon of the given IShellItem is changed.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>Pointer to the IShellItem in which the state image is changing.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// If this method returns S_OK, the client has processed the event and no further action is required of the namespace control.
		/// Otherwise the event will need to be processed, in this case the default action is to go to the next image in the list.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-inamespacetreecontrolevents-onbeforestateimagechange
		// HRESULT OnBeforeStateImageChange( IShellItem *psi );
		[PreserveSig]
		HRESULT OnBeforeStateImageChange([In] IShellItem psi);

		/// <summary>Undocumented.</summary>
		/// <param name="psi">Undocumented.</param>
		/// <param name="piDefaultIcon">Undocumented.</param>
		/// <param name="piOpenIcon">Undocumented.</param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		[PreserveSig]
		HRESULT OnGetDefaultIconIndex([In] IShellItem psi, out int piDefaultIcon, out int piOpenIcon);
	}

	/// <summary>Exposes a single method that retrieves the status of a folder's System.IsPinnedToNameSpaceTree filtering support.</summary>
	/// <remarks>
	/// <para>
	/// The namespace tree control checks all the nodes it enumerates to see if they support filtering. This is done by retrieving the
	/// System.IsPinnedToNameSpaceTree property for the shell folders that support this interface. Nodes that do not support this
	/// interface do not have filtering support and are shown by default.
	/// </para>
	/// <para>Use this interface to retrieve the filtering support status of a shell folder.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-inamespacetreecontrolfoldercapabilities
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("e9701183-e6b3-4ff2-8568-813615fec7be")]
	public interface INameSpaceTreeControlFolderCapabilities
	{
		/// <summary>
		/// Gets a folder's capability to be filtered through the System.IsPinnedToNameSpaceTree property key value and change
		/// notification registration status.
		/// </summary>
		/// <param name="nfcMask">
		/// <para>Type: <c>NSTCFOLDERCAPABILITIES</c></para>
		/// <para>The capabilities for which this method should retrieve values. Specify one or both of the following:</para>
		/// <para>NSTCFC_PINNEDITEMFILTERING (0x00000001)</para>
		/// <para>
		/// 0x00000001. The System.IsPinnedToNameSpaceTree property exists on this folder and filtering based on that property value is supported.
		/// </para>
		/// <para>NSTCFC_DELAY_REGISTER_NOTIFY (0x00000002)</para>
		/// <para>0x00000002. Registration for change notifications is delayed until the folder is expanded in the navigation pane.</para>
		/// </param>
		/// <param name="pnfcValue">
		/// <para>Type: <c>NSTCFOLDERCAPABILITIES*</c></para>
		/// <para>
		/// Pointer to a value that, when this method returns successfully, receives the capabilities requested in nfcMask. Except in
		/// the case of NSTCFC_NONE, bit values in positions not specifically requested in nfcMask do not necessarily reflect the
		/// capabilities and should not be used.
		/// </para>
		/// <para>NSTCFC_NONE (0x00000000)</para>
		/// <para>0x00000000. The System.IsPinnedToNameSpaceTree property does not exist on this folder. Filtering is not supported.</para>
		/// <para>NSTCFC_PINNEDITEMFILTERING (0x00000001)</para>
		/// <para>
		/// 0x00000001. The System.IsPinnedToNameSpaceTree property exists on this folder and filtering based on that property value is supported.
		/// </para>
		/// <para>NSTCFC_DELAY_REGISTER_NOTIFY (0x00000002)</para>
		/// <para>0x00000002. Registration for change notifications is delayed until the folder is expanded in the navigation pane.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inamespacetreecontrolfoldercapabilities-getfoldercapabilities
		// HRESULT GetFolderCapabilities( NSTCFOLDERCAPABILITIES nfcMask, NSTCFOLDERCAPABILITIES *pnfcValue );
		[PreserveSig]
		HRESULT GetFolderCapabilities(NSTCFOLDERCAPABILITIES nfcMask, out NSTCFOLDERCAPABILITIES pnfcValue);
	}

	/// <summary>Exposes methods that enable the user to draw a custom namespace tree control and its items.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nn-shobjidl-inamespacetreecontrolcustomdraw
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("2D3BA758-33EE-42d5-BB7B-5F3431D86C78")]
	internal interface INameSpaceTreeControlCustomDraw
	{
		/// <summary>Called before the namespace tree control is drawn.</summary>
		/// <param name="hdc">
		/// <para>Type: <c>HDC</c></para>
		/// <para>A handle to the control's device context. Use this HDC to perform any GDI functions.</para>
		/// </param>
		/// <param name="prc">
		/// <para>Type: <c>RECT*</c></para>
		/// <para>A pointer to the RECT structure that describes the bounding rectangle of the area being drawn.</para>
		/// </param>
		/// <param name="plres">
		/// <para>Type: <c>LRESULT*</c></para>
		/// <para>
		/// When this method returns, contains a pointer to an <c>LRESULT</c>, which contains one or more of the values from the CDRF
		/// Constants enumeration.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-inamespacetreecontrolcustomdraw-prepaint HRESULT
		// PrePaint( HDC hdc, RECT *prc, LRESULT *plres );
		[PreserveSig]
		HRESULT PrePaint([In] HDC hdc, in RECT prc, out IntPtr plres);

		/// <summary>Called after the namespace tree control is drawn.</summary>
		/// <param name="hdc">
		/// <para>Type: <c>HDC</c></para>
		/// <para>A handle to the control's device context. Use this HDC to perform any GDI functions.</para>
		/// </param>
		/// <param name="prc">
		/// <para>Type: <c>RECT*</c></para>
		/// <para>A pointer to the RECT structure that describes the bounding rectangle of the area being drawn.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-inamespacetreecontrolcustomdraw-postpaint HRESULT
		// PostPaint( HDC hdc, RECT *prc );
		[PreserveSig]
		HRESULT PostPaint([In] HDC hdc, in RECT prc);

		/// <summary>Called before an item in the namespace tree control is drawn.</summary>
		/// <param name="hdc">
		/// <para>Type: <c>HDC</c></para>
		/// <para>A handle to the control's device context. Use this HDC to perform any GDI functions.</para>
		/// </param>
		/// <param name="prc">
		/// <para>Type: <c>RECT*</c></para>
		/// <para>A pointer to the RECT structure that describes the bounding rectangle of the area being drawn.</para>
		/// </param>
		/// <param name="pnstccdItem">
		/// <para>Type: <c>NSTCCUSTOMDRAW*</c></para>
		/// <para>A pointer to the NSTCCUSTOMDRAW structure that determines the details of the drawing.</para>
		/// </param>
		/// <param name="pclrText">
		/// <para>Type: <c>COLORREF*</c></para>
		/// <para>
		/// On entry, a pointer to a COLORREF structure that declares the default color of the text. When this method returns, contains
		/// a pointer to a <c>COLORREF</c> structure that declares the color that should be used in its place, if any. This allows the
		/// client to provide their own color if they do not want to use the default.
		/// </para>
		/// </param>
		/// <param name="pclrTextBk">
		/// <para>Type: <c>COLORREF*</c></para>
		/// <para>
		/// On entry, a pointer to a COLORREF structure that declares the default color of the background. When this method returns,
		/// contains a pointer to a <c>COLORREF</c> structure that declares the color that should be used in its place, if any. This
		/// allows the client to provide their own color if they do not want to use the default.
		/// </para>
		/// </param>
		/// <param name="plres">
		/// <para>Type: <c>LRESULT*</c></para>
		/// <para>
		/// When this method returns, contains a pointer to an <c>LRESULT</c>, which points to one or more of the values from the CDRF
		/// Constants enumeration.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-inamespacetreecontrolcustomdraw-itemprepaint HRESULT
		// ItemPrePaint( HDC hdc, RECT *prc, NSTCCUSTOMDRAW *pnstccdItem, COLORREF *pclrText, COLORREF *pclrTextBk, LRESULT *plres );
		[PreserveSig]
		HRESULT ItemPrePaint([In] HDC hdc, in RECT prc, in NSTCCUSTOMDRAW pnstccdItem, ref COLORREF pclrText, ref COLORREF pclrTextBk, out IntPtr plres);

		/// <summary>Called after an item in the namespace tree control is drawn.</summary>
		/// <param name="hdc">
		/// <para>Type: <c>HDC</c></para>
		/// <para>A handle to the control's device context. Use this HDC to perform any GDI functions.</para>
		/// </param>
		/// <param name="prc">
		/// <para>Type: <c>RECT*</c></para>
		/// <para>A pointer to the RECT structure that describes the bounding rectangle of the area being drawn.</para>
		/// </param>
		/// <param name="pnstccdItem">
		/// <para>Type: <c>NSTCCUSTOMDRAW*</c></para>
		/// <para>A pointer to the NSTCCUSTOMDRAW struct that determines the details of the drawing.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-inamespacetreecontrolcustomdraw-itempostpaint HRESULT
		// ItemPostPaint( HDC hdc, RECT *prc, NSTCCUSTOMDRAW *pnstccdItem );
		[PreserveSig]
		HRESULT ItemPostPaint([In] HDC hdc, in RECT prc, in NSTCCUSTOMDRAW pnstccdItem);
	}

	/// <summary>Custom draw structure used by INameSpaceTreeControlCustomDraw methods.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/ns-shobjidl-nstccustomdraw typedef struct NSTCCUSTOMDRAW { IShellItem
	// *psi; UINT uItemState; NSTCITEMSTATE nstcis; LPCWSTR pszText; int iImage; HIMAGELIST himl; int iLevel; int iIndent; } NSTCCUSTOMDRAW;
	[PInvokeData("shobjidl.h", MSDNShortId = "95747075-4882-4c29-8653-941ac04db54b")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct NSTCCUSTOMDRAW
	{
		/// <summary>
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to a Shell item.</para>
		/// </summary>
		public IShellItem psi;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The current item state. See NMCUSTOMDRAW for more detail.</para>
		/// </summary>
		public uint uItemState;

		/// <summary>
		/// <para>Type: <c>NSTCITEMSTATE</c></para>
		/// <para>The state of a tree item. See NSTCITEMSTATE.</para>
		/// </summary>
		public NSTCITEMSTATE nstcis;

		/// <summary>
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a null-terminated Unicode string that contains the item text, if the structure specifies item attributes.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string pszText;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>The index in the tree-view control's image list.</para>
		/// </summary>
		public int iImage;

		/// <summary>
		/// <para>Type: <c>HIMAGELIST</c></para>
		/// <para>A handle to an image list.</para>
		/// </summary>
		public HIMAGELIST himl;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>The zero-based level of the item being drawn.</para>
		/// </summary>
		public int iLevel;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>A tree-level indent.</para>
		/// </summary>
		public int iIndent;
	}

	/// <summary>CLSID_NameSpaceTreeControl</summary>
	[ComImport, Guid("AE054212-3535-4430-83ED-D501AA6680E6"), ClassInterface(ClassInterfaceType.None)]
	public class NameSpaceTreeControl { }
}