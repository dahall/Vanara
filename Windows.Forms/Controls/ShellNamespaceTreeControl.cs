using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Vanara.Extensions;
using Vanara.PInvoke;
using Vanara.Windows.Shell;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.Shell32;
using static Vanara.PInvoke.User32;
using IMessageFilter = System.Windows.Forms.IMessageFilter;

namespace Vanara.Windows.Forms
{
	/// <summary>The location on the IShellItem that was clicked.</summary>
	public enum ItemHitLocation
	{
		/// <summary>The click missed the IShellItem.</summary>
		NoWhere = NSTCEHITTEST.NSTCEHT_NOWHERE,

		/// <summary>The click was on the icon of the IShellItem.</summary>
		OnIcon = NSTCEHITTEST.NSTCEHT_ONITEMICON,

		/// <summary>The click was on the label text of the IShellItem.</summary>
		OnLabel = NSTCEHITTEST.NSTCEHT_ONITEMLABEL,

		/// <summary>The click was on the indented space on the leftmost side of the IShellItem.</summary>
		OnIndent = NSTCEHITTEST.NSTCEHT_ONITEMINDENT,

		/// <summary>The click was on the expando button of the IShellItem.</summary>
		OnButton = NSTCEHITTEST.NSTCEHT_ONITEMBUTTON,

		/// <summary>The click was on the rightmost side of the text of the IShellItem.</summary>
		OnRight = NSTCEHITTEST.NSTCEHT_ONITEMRIGHT,

		/// <summary>The click was on the state icon of the IShellItem.</summary>
		OnStateIcon = NSTCEHITTEST.NSTCEHT_ONITEMSTATEICON,

		/// <summary>The click was on the item icon or the item label or the state icon of the IShellItem.</summary>
		OnItem = NSTCEHITTEST.NSTCEHT_ONITEM,

		/// <summary>The click was on the tab button of the IShellItem.</summary>
		OnTabButton = NSTCEHITTEST.NSTCEHT_ONITEMTABBUTTON,
	}

	/// <summary>Actions on a <see cref="ShellNamespaceTreeControl"/> exposed through <see cref="ShellNamespaceTreeControlEventArgs"/>.</summary>
	public enum ShellNamespaceTreeControlAction
	{
		/// <summary>Unknown action.</summary>
		Unknown,

		/// <summary>A keystroke caused the action.</summary>
		ByKeyboard,

		/// <summary>A mouse click caused the action.</summary>
		ByMouse,

		/// <summary>An item has been added.</summary>
		AfterAdd,

		/// <summary>An item has been deleted.</summary>
		AfterDelete,

		/// <summary>An item is about to be deleted.</summary>
		BeforeDelete,

		/// <summary>An item is being collapsed.</summary>
		Collapse,

		/// <summary>An item is being expanded.</summary>
		Expand
	}

	/// <summary>Determines the image displayed to the right of an item in <see cref="ShellNamespaceTreeControl"/>.</summary>
	public enum ShellTreeItemButton
	{
		/// <summary>No button is displayed to the right of an item.</summary>
		None,

		/// <summary>
		/// Displays an arrow on the right side of an item if the item is a folder. The action associated with the arrow is implementation specific.
		/// </summary>
		Arrow,

		/// <summary>Displays a red X on the right side of an item. The action associated with the X is implementation specific.</summary>
		Delete,

		/// <summary>
		/// Displays a refresh button on the right side of an item. The action associated with the button is implementation specific.
		/// </summary>
		Refresh
	}

	/// <summary>The style of check box to display.</summary>
	public enum ShellTreeItemCheckBoxStyle
	{
		/// <summary>Display no check box. This is the default.</summary>
		None,

		/// <summary>Adds a standard, two-state, checkbox icon on the leftmost side of a given item.</summary>
		Normal,

		/// <summary>
		/// Adds a checkbox icon on the leftmost side of a given item with a square in the center, that indicates that the node is partially selected.
		/// </summary>
		Partial,

		/// <summary>
		/// Adds a checkbox icon on the leftmost side of a given item that contains a red X, which indicates that the item is excluded from
		/// the current selection. Without this exclusion icon, selection of a parent item includes selection of its child items.
		/// </summary>
		Exclusion,

		/// <summary>
		/// Adds a checkbox on the leftmost side of a given item that contains an icon of a dimmed check mark, that indicates that a node is
		/// selected because its parent is selected.
		/// </summary>
		Dimmed
	}

	/// <summary>Specifies the state of a tree item.</summary>
	[Flags]
	public enum ShellTreeItemState : uint
	{
		/// <summary>The item has default state; it is not selected, expanded, bolded or disabled.</summary>
		None = NSTCITEMSTATE.NSTCIS_NONE,

		/// <summary>The item is selected.</summary>
		Selected = NSTCITEMSTATE.NSTCIS_SELECTED,

		/// <summary>The item is expanded.</summary>
		Expanded = NSTCITEMSTATE.NSTCIS_EXPANDED,

		/// <summary>The item is bold.</summary>
		Bold = NSTCITEMSTATE.NSTCIS_BOLD,

		/// <summary>The item is disabled.</summary>
		Disabled = NSTCITEMSTATE.NSTCIS_DISABLED,

		/// <summary>Windows 7 and later. The item is selected, but not expanded.</summary>
		SelectedNotExpanded = NSTCITEMSTATE.NSTCIS_SELECTEDNOEXPAND,
	}

	/// <summary>A control used to view and manipulate nodes in a tree of Shell items.</summary>
	[Designer(typeof(Design.ShellNamespaceTreeControlDesigner)), DefaultProperty(nameof(ShowPlusMinus)), DefaultEvent(nameof(AfterSelect))]
	[ToolboxItem(true), ToolboxBitmap(typeof(ShellNamespaceTreeControl), "ShellNamespaceTreeControl.bmp")]
	[Description("A Shell object that displays a tree of shell items.")]
	[ComVisible(true), Guid("0639efb8-7701-472e-863d-d6fbc543d736")]
	public class ShellNamespaceTreeControl : Control, Shell32.IServiceProvider, INameSpaceTreeControlEvents, INameSpaceTreeControlDropHandler, IMessageFilter //, INameSpaceTreeAccessible
	{
		internal INameSpaceTreeControl pCtrl;

		private const NSTCSTYLE defaultStyle = NSTCSTYLE.NSTCS_HASEXPANDOS | NSTCSTYLE.NSTCS_ROOTHASEXPANDO | NSTCSTYLE.NSTCS_FADEINOUTEXPANDOS |
			NSTCSTYLE.NSTCS_NOINFOTIP | NSTCSTYLE.NSTCS_ALLOWJUNCTIONS | NSTCSTYLE.NSTCS_SHOWSELECTIONALWAYS | NSTCSTYLE.NSTCS_FULLROWSELECT |
			NSTCSTYLE.NSTCS_TABSTOP;

		private const NSTCSTYLE2 defaultStyle2 = NSTCSTYLE2.NTSCS2_NOSINGLETONAUTOEXPAND | NSTCSTYLE2.NSTCS2_INTERRUPTNOTIFICATIONS |
			NSTCSTYLE2.NSTCS2_DISPLAYPINNEDONLY | NSTCSTYLE2.NTSCS2_NEVERINSERTNONENUMERATED;

		private const NSTCITEMSTATE NSTCITEMSTATE_ALL = NSTCITEMSTATE.NSTCIS_SELECTED | NSTCITEMSTATE.NSTCIS_EXPANDED | NSTCITEMSTATE.NSTCIS_BOLD | NSTCITEMSTATE.NSTCIS_DISABLED | NSTCITEMSTATE.NSTCIS_SELECTEDNOEXPAND;

		private const NSTCSTYLE NSTCSTYLE_ALL = NSTCSTYLE.NSTCS_HASEXPANDOS | NSTCSTYLE.NSTCS_HASLINES | NSTCSTYLE.NSTCS_SINGLECLICKEXPAND |
			NSTCSTYLE.NSTCS_FULLROWSELECT | NSTCSTYLE.NSTCS_SPRINGEXPAND | NSTCSTYLE.NSTCS_HORIZONTALSCROLL | NSTCSTYLE.NSTCS_ROOTHASEXPANDO |
			NSTCSTYLE.NSTCS_SHOWSELECTIONALWAYS | NSTCSTYLE.NSTCS_NOINFOTIP | NSTCSTYLE.NSTCS_EVENHEIGHT | NSTCSTYLE.NSTCS_NOREPLACEOPEN |
			NSTCSTYLE.NSTCS_DISABLEDRAGDROP | NSTCSTYLE.NSTCS_NOORDERSTREAM | NSTCSTYLE.NSTCS_RICHTOOLTIP | NSTCSTYLE.NSTCS_BORDER |
			NSTCSTYLE.NSTCS_NOEDITLABELS | NSTCSTYLE.NSTCS_TABSTOP | NSTCSTYLE.NSTCS_FAVORITESMODE | NSTCSTYLE.NSTCS_AUTOHSCROLL |
			NSTCSTYLE.NSTCS_FADEINOUTEXPANDOS | NSTCSTYLE.NSTCS_EMPTYTEXT | NSTCSTYLE.NSTCS_CHECKBOXES | NSTCSTYLE.NSTCS_PARTIALCHECKBOXES |
			NSTCSTYLE.NSTCS_EXCLUSIONCHECKBOXES | NSTCSTYLE.NSTCS_DIMMEDCHECKBOXES | NSTCSTYLE.NSTCS_NOINDENTCHECKS |
			NSTCSTYLE.NSTCS_ALLOWJUNCTIONS | NSTCSTYLE.NSTCS_SHOWTABSBUTTON | NSTCSTYLE.NSTCS_SHOWDELETEBUTTON | NSTCSTYLE.NSTCS_SHOWREFRESHBUTTON;

		private const NSTCSTYLE2 NSTCSTYLE2_ALL = NSTCSTYLE2.NSTCS2_INTERRUPTNOTIFICATIONS | NSTCSTYLE2.NSTCS2_SHOWNULLSPACEMENU |
			NSTCSTYLE2.NSTCS2_DISPLAYPADDING | NSTCSTYLE2.NSTCS2_DISPLAYPINNEDONLY | NSTCSTYLE2.NTSCS2_NOSINGLETONAUTOEXPAND |
			NSTCSTYLE2.NTSCS2_NEVERINSERTNONENUMERATED;

		private uint adviseCookie = uint.MaxValue;
		private BorderStyle borderStyle = BorderStyle.None;
		private HWND hWndNsTreeCtrl, hWndTreeView;
		private bool oleUninit = false;
		private INameSpaceTreeControl2 pCtrl2;
		private EnumFlagIndexer<NSTCSTYLE> style = defaultStyle;
		private EnumFlagIndexer<NSTCSTYLE2> style2 = defaultStyle2;
		private string theme = null;

		/// <summary>Initializes a new instance of the <see cref="ShellNamespaceTreeControl"/> class.</summary>
		public ShellNamespaceTreeControl()
		{
			RootItems = new ShellNamespaceTreeRootList(this);
			BackColor = SystemColors.Window;
			oleUninit = Ole32.OleInitialize().Succeeded;
		}

		/// <summary>Called after an item is expanded.</summary>
		[Category("Behavior"), Description("Occurs when an item has been expanded.")]
		public event EventHandler<ShellNamespaceTreeControlEventArgs> AfterExpand;

		/// <summary>Called after an item has been added.</summary>
		[Category("Behavior"), Description("Occurs when an item has been added.")]
		public event EventHandler<ShellNamespaceTreeControlEventArgs> AfterItemAdd;

		/// <summary>Called after an item and all of its children are deleted.</summary>
		[Category("Behavior"), Description("Occurs when an item has been deleted.")]
		public event EventHandler<ShellNamespaceTreeControlEventArgs> AfterItemDelete;

		/// <summary>Called after the item leaves edit mode.</summary>
		[Category("Behavior"), Description("Occurs when the text of an item has been edited by the user.")]
		public event EventHandler<ShellNamespaceTreeControlItemLabelEditEventArgs> AfterLabelEdit;

		/// <summary>Occurs when the selection changes.</summary>
		[Category("Behavior"), Description("Occurs when an item has been selected.")]
		public event EventHandler AfterSelect;

		/// <summary>Called before an item is expanded.</summary>
		[Category("Behavior"), Description("Occurs when an item it about to be expanded.")]
		public event EventHandler<ShellNamespaceTreeControlCancelEventArgs> BeforeExpand;

		/// <summary>Called before an item and all of its children are deleted.</summary>
		[Category("Behavior"), Description("Occurs when an item is about to be deleted.")]
		public event EventHandler<ShellNamespaceTreeControlCancelEventArgs> BeforeItemDelete;

		/// <summary>Called before the item goes into edit mode.</summary>
		[Category("Behavior"), Description("Occurs when the text of an item is about to be edited by the user.")]
		public event EventHandler<ShellNamespaceTreeControlItemLabelEditEventArgs> BeforeLabelEdit;

		/// <summary>Called when the user clicks a button on the mouse.</summary>
		[Category("Behavior"), Description("Occurs when an item is clicked by the user.")]
		public event EventHandler<ShellNamespaceTreeControlItemMouseClickEventArgs> ItemMouseClick;

		/// <summary>Called when the user double-clicks a button on the mouse.</summary>
		[Category("Behavior"), Description("Occurs when an item is double-clicked with the mouse.")]
		public event EventHandler<ShellNamespaceTreeControlItemMouseClickEventArgs> ItemMouseDoubleClick;

		/// <summary>Indicates whether to insert spacing (padding) between top-level nodes.</summary>
		[DefaultValue(false), Category("Appearance"), Description("Indicates whether to insert spacing (padding) between top-level nodes.")]
		public bool AddTopLevelNodePadding
		{
			get => HasTreeStyle(NSTCSTYLE2.NSTCS2_DISPLAYPADDING);
			set => SetTreeStyle(NSTCSTYLE2.NSTCS2_DISPLAYPADDING, value);
		}

		/// <summary>
		/// Indicates whether to allow junctions. A junction point, or just junction, is a root of a namespace extension that is normally
		/// displayed by Windows Explorer as a folder in both tree and folder views. For Windows Explorer to display your extension's files
		/// and subfolders, you must specify where the root folder is located in the Shell namespace hierarchy. Junctions exist in the file
		/// system as files, but are not treated as files. An example is a compressed file with a .zip file name extension, which to the
		/// file system is just a file. However, if this file is treated as a junction, it can represent an entire namespace. This allows
		/// the namespace tree control to treat compressed files and similar junctions as folders rather than as files.
		/// </summary>
		[DefaultValue(true), Category("Behavior"), Description("Indicates whether to allow junctions.")]
		public bool AllowJunctions
		{
			get => HasTreeStyle(NSTCSTYLE.NSTCS_ALLOWJUNCTIONS);
			set => SetTreeStyle(NSTCSTYLE.NSTCS_ALLOWJUNCTIONS, value);
		}

		/// <summary>Gets or sets the border style.</summary>
		/// <value>The border style.</value>
		[DefaultValue(BorderStyle.None), Category("Appearance"), Description("The border style of the control.")]
		public BorderStyle BorderStyle
		{
			get => borderStyle;
			set { if (borderStyle != value) { borderStyle = value; /*InitializeControl();*/ } }
		}

		/// <summary>
		/// Indicates whether to display check boxes on the leftmost side of the items. These check boxes can be of types partial, exclusion
		/// or dimmed.
		/// </summary>
		[DefaultValue(ShellTreeItemCheckBoxStyle.None), Category("Appearance"), Description("Indicates the type of check boxes to display besides nodes.")]
		public ShellTreeItemCheckBoxStyle CheckBoxStyle
		{
			get => style switch
			{
				var s when s[NSTCSTYLE.NSTCS_PARTIALCHECKBOXES] => ShellTreeItemCheckBoxStyle.Partial,
				var s when s[NSTCSTYLE.NSTCS_EXCLUSIONCHECKBOXES] => ShellTreeItemCheckBoxStyle.Exclusion,
				var s when s[NSTCSTYLE.NSTCS_DIMMEDCHECKBOXES] => ShellTreeItemCheckBoxStyle.Dimmed,
				var s when s[NSTCSTYLE.NSTCS_CHECKBOXES] => ShellTreeItemCheckBoxStyle.Normal,
				_ => ShellTreeItemCheckBoxStyle.None
			};

			set
			{
				var lstyle = ((NSTCSTYLE)style).SetFlags(NSTCSTYLE.NSTCS_CHECKBOXES | NSTCSTYLE.NSTCS_PARTIALCHECKBOXES | NSTCSTYLE.NSTCS_EXCLUSIONCHECKBOXES | NSTCSTYLE.NSTCS_DIMMEDCHECKBOXES, false) |
					value switch
					{
						ShellTreeItemCheckBoxStyle.Normal => NSTCSTYLE.NSTCS_CHECKBOXES,
						ShellTreeItemCheckBoxStyle.Partial => NSTCSTYLE.NSTCS_CHECKBOXES | NSTCSTYLE.NSTCS_PARTIALCHECKBOXES,
						ShellTreeItemCheckBoxStyle.Exclusion => NSTCSTYLE.NSTCS_CHECKBOXES | NSTCSTYLE.NSTCS_EXCLUSIONCHECKBOXES,
						ShellTreeItemCheckBoxStyle.Dimmed => NSTCSTYLE.NSTCS_CHECKBOXES | NSTCSTYLE.NSTCS_DIMMEDCHECKBOXES,
						_ => 0
					};
				if (style != lstyle)
				{
					style = lstyle;
					UpdateStyle();
				}
			}
		}

		/// <summary>
		/// Indicates whether to allow drag-and-drop operations within the control. Note that you can still drag an item from outside of the
		/// control and drop it onto the control.
		/// </summary>
		[DefaultValue(false), Category("Behavior"), Description("Indicates whether to allow drag-and-drop operations within the control.")]
		public bool DisableDragDrop
		{
			get => HasTreeStyle(NSTCSTYLE.NSTCS_DISABLEDRAGDROP);
			set => SetTreeStyle(NSTCSTYLE.NSTCS_DISABLEDRAGDROP, value);
		}

		/// <summary>
		/// Indicates whether to filter items based on the System.IsPinnedToNameSpaceTree value when INameSpaceTreeControlFolderCapabilities
		/// is implemented.
		/// </summary>
		[DefaultValue(true), Category("Behavior"), Description("Indicates whether to filter items based on their pinned value.")]
		public bool DisplayPinnedItemsOnly
		{
			get => HasTreeStyle(NSTCSTYLE2.NSTCS2_DISPLAYPINNEDONLY);
			set => SetTreeStyle(NSTCSTYLE2.NSTCS2_DISPLAYPINNEDONLY, value);
		}

		/// <summary>
		/// Indicates whether to set the height of the items to an even height. By default, the height of items can be even or odd.
		/// </summary>
		[DefaultValue(false), Category("Appearance"), Description("Indicates whether to set the height of the items to an even height.")]
		public bool ForceEvenHeight
		{
			get => HasTreeStyle(NSTCSTYLE.NSTCS_EVENHEIGHT);
			set => SetTreeStyle(NSTCSTYLE.NSTCS_EVENHEIGHT, value);
		}

		/// <summary>
		/// Indicates whether the selection of an item fills the row with inverse text to the end of the window area, regardless of the
		/// length of the text. When this option is not declared, only the area behind text is inverted.
		/// </summary>
		[DefaultValue(true), Category("Appearance"), Description("Indicates whether the highlight spans the width of the control.")]
		public bool FullRowSelect
		{
			get => HasTreeStyle(NSTCSTYLE.NSTCS_FULLROWSELECT);
			set => SetTreeStyle(NSTCSTYLE.NSTCS_FULLROWSELECT, value);
		}

		/// <summary>Indicates whether the node of an item is not outlined when the control does not have the focus.</summary>
		[DefaultValue(false), Category("Appearance"), Description("Removes highlight from the selected item when control does not have the focus.")]
		public bool HideSelection
		{
			get => !HasTreeStyle(NSTCSTYLE.NSTCS_SHOWSELECTIONALWAYS);
			set => SetTreeStyle(NSTCSTYLE.NSTCS_SHOWSELECTIONALWAYS, !value);
		}

		/// <summary>
		/// If the control does not have the focus and there are items that are preceded by expandos, then these expandos are visible only
		/// when the mouse pointer is near to the control.
		/// </summary>
		[DefaultValue(true), Category("Appearance"), Description("Expandos are only visible when mouse hovers near the control.")]
		public bool HotExpandos
		{
			get => HasTreeStyle(NSTCSTYLE.NSTCS_FADEINOUTEXPANDOS);
			set => SetTreeStyle(NSTCSTYLE.NSTCS_FADEINOUTEXPANDOS, value);
		}

		/// <summary>Indicates whether to allow creation of an in-place edit box, which would allow the user to rename the given item.</summary>
		[DefaultValue(true), Category("Behavior"), Description("Indicates whether the user can edit the label text of items.")]
		public bool LabelEdit
		{
			get => !HasTreeStyle(NSTCSTYLE.NSTCS_NOEDITLABELS);
			set => SetTreeStyle(NSTCSTYLE.NSTCS_NOEDITLABELS, !value);
		}

		/// <summary>Indicates whether check boxes are located at the far left edge of the window area instead of being indented.</summary>
		[DefaultValue(false), Category("Appearance"), Description("Removes indent before item check boxes.")]
		public bool NoIndentCheckBoxes
		{
			get => HasTreeStyle(NSTCSTYLE.NSTCS_NOINDENTCHECKS);
			set => SetTreeStyle(value ? NSTCSTYLE.NSTCS_NOINDENTCHECKS | NSTCSTYLE.NSTCS_CHECKBOXES : NSTCSTYLE.NSTCS_NOINDENTCHECKS, value);
		}

		/// <summary>Gets the root items.</summary>
		/// <value>The root items.</value>
		[Browsable(false)]
		public ShellNamespaceTreeRootList RootItems { get; }

		/// <summary>Gets the currently selected item, or <see langword="null"/> if nothing is selected.</summary>
		/// <value>The selected item, or <see langword="null"/> if nothing is selected.</value>
		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ShellItem SelectedItem
		{
			get
			{
				if (pCtrl != null && pCtrl.GetSelectedItems(out var items).Succeeded)
				{
					try { return ShellItem.Open(items.GetItemAt(0)); }
					finally { Marshal.ReleaseComObject(items); }
				}
				return null;
			}
			set
			{
				var state = GetItemState(value);
				SetItemState(value, (ShellTreeItemState)NSTCITEMSTATE_ALL, state | ShellTreeItemState.Selected);
			}
		}

		/// <summary>
		/// Indicates which button to display on the right side of an item. The action associated with the button is implementation specific.
		/// </summary>
		[DefaultValue(ShellTreeItemButton.None), Category("Appearance"), Description("Indicates which button to display on the right side of an item.")]
		public ShellTreeItemButton ShowFolderButton
		{
			get => style switch
			{
				var s when s[NSTCSTYLE.NSTCS_SHOWTABSBUTTON] => ShellTreeItemButton.Arrow,
				var s when s[NSTCSTYLE.NSTCS_SHOWDELETEBUTTON] => ShellTreeItemButton.Delete,
				var s when s[NSTCSTYLE.NSTCS_SHOWREFRESHBUTTON] => ShellTreeItemButton.Refresh,
				_ => ShellTreeItemButton.None
			};

			set
			{
				var lstyle = ((NSTCSTYLE)style).SetFlags(NSTCSTYLE.NSTCS_SHOWTABSBUTTON | NSTCSTYLE.NSTCS_SHOWDELETEBUTTON | NSTCSTYLE.NSTCS_SHOWREFRESHBUTTON, false) |
					value switch
					{
						ShellTreeItemButton.Arrow => NSTCSTYLE.NSTCS_SHOWTABSBUTTON,
						ShellTreeItemButton.Delete => NSTCSTYLE.NSTCS_SHOWDELETEBUTTON,
						ShellTreeItemButton.Refresh => NSTCSTYLE.NSTCS_SHOWREFRESHBUTTON,
						_ => 0
					};
				if (style != lstyle)
				{
					style = lstyle;
					UpdateStyle();
				}
			}
		}

		/// <summary>Indicates whether to display infotips when the mouse cursor is over an item.</summary>
		[DefaultValue(false), Category("Behavior"), Description("Indicates whether ToolTips will be displayed on the items.")]
		public bool ShowItemToolTips
		{
			get => !HasTreeStyle(NSTCSTYLE.NSTCS_NOINFOTIP);
			set
			{
				SetTreeStyle(NSTCSTYLE.NSTCS_NOINFOTIP, !value);
				if (value)
					SetTreeStyle(NSTCSTYLE.NSTCS_RICHTOOLTIP, false);
			}
		}

		/// <summary>Indicates whether the control draws lines to the left of the tree items that lead to their individual parent items.</summary>
		[DefaultValue(false), Category("Appearance"), Description("Indicates whether lines are displayed between sibling items and between parent and child items.")]
		public bool ShowLines
		{
			get => HasTreeStyle(NSTCSTYLE.NSTCS_HASLINES);
			set => SetTreeStyle(NSTCSTYLE.NSTCS_HASLINES, value);
		}

		/// <summary>
		/// If <see langword="true"/>, the control displays an indicator on the leftmost edge of those items that have child items. Clicking
		/// on the indicator expands the item to reveal the children of the item.
		/// </summary>
		[DefaultValue(true), Category("Appearance"), Description("Indicates if plus/minus buttons will be shown next to parent nodes.")]
		public bool ShowPlusMinus
		{
			get => HasTreeStyle(NSTCSTYLE.NSTCS_HASEXPANDOS);
			set => SetTreeStyle(NSTCSTYLE.NSTCS_HASEXPANDOS, value);
		}

		/// <summary>Indicates whether the root item is preceded by an expando that allows expansion of the root item.</summary>
		[DefaultValue(true), Category("Appearance"), Description("Indicates whether lines are display between root items.")]
		public bool ShowRootLines
		{
			get => HasTreeStyle(NSTCSTYLE.NSTCS_ROOTHASEXPANDO);
			set => SetTreeStyle(NSTCSTYLE.NSTCS_ROOTHASEXPANDO, value);
		}

		/// <summary>Indicates whether an item expands to show its child items in response to a single mouse click.</summary>
		[DefaultValue(false), Category("Behavior"), Description("Indicates whether an item expands to show its child items in response to a single mouse click.")]
		public bool SingleClickExpand
		{
			get => HasTreeStyle(NSTCSTYLE.NSTCS_SINGLECLICKEXPAND);
			set => SetTreeStyle(NSTCSTYLE.NSTCS_SINGLECLICKEXPAND, value);
		}

		/// <summary>
		/// Indicates whether when one item is selected and expanded and you select a second item, the first selection automatically collapses.
		/// </summary>
		[DefaultValue(false), Category("Behavior"), Description("Indicates whether when one item is selected and expanded and you select a second item, the first selection automatically collapses.")]
		public bool SpringExpand
		{
			get => HasTreeStyle(NSTCSTYLE.NSTCS_SPRINGEXPAND);
			set => SetTreeStyle(NSTCSTYLE.NSTCS_SPRINGEXPAND, value);
		}

		/// <summary>If the control is hosted, you can tabstop into the control.</summary>
		[DefaultValue(true), Category("Behavior"), Description("Indicates whether the user can use the TAB key to gain access to the control.")]
		public new bool TabStop
		{
			get => HasTreeStyle(NSTCSTYLE.NSTCS_TABSTOP);
			set
			{
				if (SetTreeStyle(NSTCSTYLE.NSTCS_TABSTOP, value))
					OnTabStopChanged(EventArgs.Empty);
			}
		}

		/// <summary>Gets or sets the desktop theme for the current control.</summary>
		/// <value>The name of the desktop theme to which the current window is being set.</value>
		[DefaultValue(null), Category("Appearance"), Description("Gets or sets the desktop theme for the current control.")]
		public string Theme { get => theme; set { theme = value; pCtrl?.SetTheme(value); } }

		// TODO: Figure how to do this best
		//[DefaultValue(false)]
		//public bool Scrollable
		//{
		//	get => HasTreeStyle(NSTCSTYLE.NSTCS_HORIZONTALSCROLL);
		//	set => SetTreeStyle(NSTCSTYLE.NSTCS_HORIZONTALSCROLL, value);
		//}
		//[DefaultValue(false)]
		//public bool NoReplaceOpen
		//{
		//	get => HasTreeStyle(NSTCSTYLE.NSTCS_NOREPLACEOPEN);
		//	set => SetTreeStyle(NSTCSTYLE.NSTCS_NOREPLACEOPEN, value);
		//}
		// TODO: Figure how to do this best
		//[DefaultValue(false)]
		//public bool AutoHScroll
		//{
		//	get => HasTreeStyle(NSTCSTYLE.NSTCS_AUTOHSCROLL);
		//	set => SetTreeStyle(NSTCSTYLE.NSTCS_AUTOHSCROLL, value);
		//}

		/// <summary>
		/// Indicates whether to use a rich tooltip. Rich tooltips display the item's icon in addition to the item's text. A standard
		/// tooltip displays only the item's text. The tree view displays tooltips only for items in the tree that are partially visible.
		/// </summary>
		[DefaultValue(false), Category("Behavior"), Description("Indicates whether to use a rich tooltip.")]
		public bool UseRichToolTips
		{
			get => HasTreeStyle(NSTCSTYLE.NSTCS_RICHTOOLTIP);
			set => SetTreeStyle(value ? NSTCSTYLE.NSTCS_RICHTOOLTIP | NSTCSTYLE.NSTCS_NOINFOTIP : NSTCSTYLE.NSTCS_RICHTOOLTIP, value);
		}

		/// <summary>
		/// Gets the required creation parameters when the control handle is created.
		/// </summary>
		protected override CreateParams CreateParams
		{
			get
			{
				var cp = base.CreateParams;
				if (!this.IsDesignMode())
				{
					cp.Style &= ~(int)WindowStyles.WS_VISIBLE;
				}
				return cp;
			}
		}

		/// <summary>Collapses all of the items in the tree.</summary>
		public void CollapseAll() => pCtrl.CollapseAll();

		/// <summary>Ensures that the given item is visible.</summary>
		/// <param name="item">The Shell item for which the visibility is being ensured.</param>
		public void EnsureVisible(ShellItem item) => pCtrl.EnsureItemVisible(item.IShellItem);

		/// <summary>Gets state information about a Shell item.</summary>
		/// <param name="item">A pointer to the Shell item from which to retrieve the state.</param>
		/// <returns>The state of the specified item.</returns>
		public ShellTreeItemState GetItemState(ShellItem item) => pCtrl.GetItemState(item?.IShellItem, NSTCITEMSTATE_ALL, out var state).Succeeded ? (ShellTreeItemState)state : 0;

		/// <summary>Retrieves the item that a given point is in, if any.</summary>
		/// <param name="pt">The point to be tested.</param>
		/// <returns>The item in which the point exists, or <see langword="null"/> if the point does not exist in an item.</returns>
		public ShellItem HitTest(Point pt)
		{
			pCtrl.HitTest(pt, out var psi);
			return psi is null ? null : ShellItem.Open(psi);
		}

		/// <summary>Sets state information for a Shell item.</summary>
		/// <param name="item">
		/// <para>The Shell item for which to set the state.</para>
		/// </param>
		/// <param name="stateMask">
		/// <para>Specifies which information is being set, in the form of a bitmap.</para>
		/// </param>
		/// <param name="state">
		/// <para>A bitmap that contains the values to set for the flags specified in <paramref name="stateMask"/>.</para>
		/// </param>
		/// <remarks>
		/// The <paramref name="stateMask"/> value specifies which bits in the value pointed to by <paramref name="state"/> are to be set.
		/// Other bits are ignored. As a simple example, if <paramref name="stateMask"/>=Selected, then the first bit in the <paramref
		/// name="state"/> value determines whether that flag is set (1) or removed (0).
		/// </remarks>
		public void SetItemState(ShellItem item, ShellTreeItemState stateMask, ShellTreeItemState state) => pCtrl.SetItemState(item?.IShellItem, (NSTCITEMSTATE)stateMask, (NSTCITEMSTATE)state);

		bool IMessageFilter.PreFilterMessage(ref Message m)
		{
			if (m.Msg == (int)WindowMessage.WM_KEYDOWN || m.Msg == (int)WindowMessage.WM_KEYUP)
				Debug.WriteLine($"PreFileter msg: {(WindowMessage)m.Msg}, {(Keys)unchecked((int)(long)m.WParam)}");
			return (pCtrl as ExplorerBrowser.IInputObject_WinForms)?.TranslateAcceleratorIO(m) == HRESULT.S_OK;
		}

		HRESULT INameSpaceTreeControlEvents.OnAfterContextMenu(IShellItem psi, IContextMenu pcmIn, in Guid riid, out object ppv)
		{
			if (riid == typeof(IContextMenu).GUID)
			{
				// TODO: Figure out how to host ContextMenuStrip
				//if (ContextMenuStrip != null)
				//{
				//	var ictxmenu = new IContextMenu();
				//	ppv = ContextMenuStrip.; /* get IContextMenu from ContextMenuStrip */
				//	return HRESULT.S_OK;
				//}
				ppv = pcmIn;
			}
			else
			{
				ppv = default;
			}
			return HRESULT.E_NOTIMPL;
		}

		HRESULT INameSpaceTreeControlEvents.OnAfterExpand(IShellItem psi)
		{
			AfterExpand?.Invoke(this, new ShellNamespaceTreeControlEventArgs(psi, ShellNamespaceTreeControlAction.Expand));
			return HRESULT.S_OK;
		}

		HRESULT INameSpaceTreeControlEvents.OnBeforeContextMenu(IShellItem psi, in Guid riid, out object ppv)
		{
			if (riid == typeof(IContextMenu).GUID)
			{
				ppv = default; // TODO: replace with result from event
				return HRESULT.E_NOTIMPL; // Change if menu provided by event
			}
			else
			{
				ppv = default;
				return HRESULT.E_NOTIMPL;
			}
		}

		HRESULT INameSpaceTreeControlEvents.OnBeforeExpand(IShellItem psi)
		{
			var args = new ShellNamespaceTreeControlCancelEventArgs(psi, false, ShellNamespaceTreeControlAction.Expand);
			try { BeforeExpand?.Invoke(this, args); } catch (Exception ex) { return HRESULT.FromException(ex); }
			return args.Cancel ? HRESULT.S_FALSE : HRESULT.S_OK;
		}

		HRESULT INameSpaceTreeControlEvents.OnBeforeItemDelete(IShellItem psi)
		{
			var args = new ShellNamespaceTreeControlCancelEventArgs(psi, false, ShellNamespaceTreeControlAction.BeforeDelete);
			BeforeItemDelete?.Invoke(this, args);
			return args.Cancel ? HRESULT.S_FALSE : HRESULT.S_OK;
		}

		HRESULT INameSpaceTreeControlEvents.OnBeforeStateImageChange(IShellItem psi) => HRESULT.S_OK;

		HRESULT INameSpaceTreeControlEvents.OnBeginLabelEdit(IShellItem psi)
		{
			BeforeLabelEdit?.Invoke(this, new ShellNamespaceTreeControlItemLabelEditEventArgs(psi));
			return HRESULT.S_OK;
		}

		HRESULT INameSpaceTreeControlDropHandler.OnDragEnter(IShellItem psiOver, IShellItemArray psiaData, bool fOutsideSource, uint grfKeyState, ref uint pdwEffect)
		{
			var ido = new DataObject();
			ido.SetFileDropList(GetStringCollection(psiaData));
			var dragEvent = new DragEventArgs(ido, (int)grfKeyState, MousePosition.X, MousePosition.Y, DragDropEffects.All, (DragDropEffects)pdwEffect);
			base.OnDragEnter(dragEvent);
			pdwEffect = (uint)dragEvent.Effect;
			return HRESULT.S_OK;
		}

		HRESULT INameSpaceTreeControlDropHandler.OnDragLeave(IShellItem psiOver)
		{
			base.OnDragLeave(EventArgs.Empty);
			return HRESULT.S_OK;
		}

		HRESULT INameSpaceTreeControlDropHandler.OnDragOver(IShellItem psiOver, IShellItemArray psiaData, uint grfKeyState, ref uint pdwEffect)
		{
			var ido = new DataObject();
			ido.SetFileDropList(GetStringCollection(psiaData));
			var dragEvent = new DragEventArgs(ido, (int)grfKeyState, MousePosition.X, MousePosition.Y, DragDropEffects.All, (DragDropEffects)pdwEffect);
			base.OnDragOver(dragEvent);
			pdwEffect = (uint)dragEvent.Effect;
			return HRESULT.S_OK;
		}

		HRESULT INameSpaceTreeControlDropHandler.OnDragPosition(IShellItem psiOver, IShellItemArray psiaData, int iNewPosition, int iOldPosition) => HRESULT.E_FAIL;

		HRESULT INameSpaceTreeControlDropHandler.OnDrop(IShellItem psiOver, IShellItemArray psiaData, int iPosition, uint grfKeyState, ref uint pdwEffect)
		{
			var ido = new DataObject();
			ido.SetFileDropList(GetStringCollection(psiaData));
			var dragEvent = new DragEventArgs(ido, (int)grfKeyState, MousePosition.X, MousePosition.Y, DragDropEffects.All, (DragDropEffects)pdwEffect);
			base.OnDragDrop(dragEvent);
			pdwEffect = (uint)dragEvent.Effect;
			return HRESULT.S_OK;
		}

		HRESULT INameSpaceTreeControlDropHandler.OnDropPosition(IShellItem psiOver, IShellItemArray psiaData, int iNewPosition, int iOldPosition) => HRESULT.E_FAIL;

		HRESULT INameSpaceTreeControlEvents.OnEndLabelEdit(IShellItem psi)
		{
			AfterLabelEdit?.Invoke(this, new ShellNamespaceTreeControlItemLabelEditEventArgs(psi));
			return HRESULT.S_OK;
		}

		HRESULT INameSpaceTreeControlEvents.OnGetDefaultIconIndex(IShellItem psi, out int piDefaultIcon, out int piOpenIcon)
		{
			piDefaultIcon = piOpenIcon = default;
			return HRESULT.E_NOTIMPL;
		}

		HRESULT INameSpaceTreeControlEvents.OnGetToolTip(IShellItem psi, StringBuilder pszTip, int cchTip) => HRESULT.E_NOTIMPL;

		HRESULT INameSpaceTreeControlEvents.OnItemAdded(IShellItem psi, bool fIsRoot)
		{
			AfterItemAdd?.Invoke(this, new ShellNamespaceTreeControlEventArgs(psi, ShellNamespaceTreeControlAction.AfterAdd));
			return HRESULT.E_NOTIMPL;
			//return HRESULT.S_OK;
		}

		HRESULT INameSpaceTreeControlEvents.OnItemClick(IShellItem psi, NSTCEHITTEST nstceHitTest, NSTCECLICKTYPE nstceClickType)
		{
			var mb = MouseButtons.None;
			switch (nstceClickType)
			{
				case NSTCECLICKTYPE.NSTCECT_LBUTTON:
					mb = MouseButtons.Left;
					break;

				case NSTCECLICKTYPE.NSTCECT_MBUTTON:
					mb = MouseButtons.Middle;
					break;

				case NSTCECLICKTYPE.NSTCECT_RBUTTON:
					mb = MouseButtons.Right;
					break;
			}
			var args = new ShellNamespaceTreeControlItemMouseClickEventArgs(psi, mb, nstceHitTest);
			if (nstceClickType > NSTCECLICKTYPE.NSTCECT_BUTTON)
				ItemMouseDoubleClick?.Invoke(this, args);
			else
				ItemMouseClick?.Invoke(this, args);
			return args.Handled ? HRESULT.S_OK : HRESULT.S_FALSE;
		}

		HRESULT INameSpaceTreeControlEvents.OnItemDeleted(IShellItem psi, bool fIsRoot)
		{
			AfterItemDelete?.Invoke(this, new ShellNamespaceTreeControlEventArgs(psi, ShellNamespaceTreeControlAction.AfterDelete));
			return HRESULT.E_NOTIMPL;
			//return HRESULT.S_OK;
		}

		HRESULT INameSpaceTreeControlEvents.OnItemStateChanged(IShellItem psi, NSTCITEMSTATE nstcisMask, NSTCITEMSTATE nstcisState) => HRESULT.S_OK;

		HRESULT INameSpaceTreeControlEvents.OnItemStateChanging(IShellItem psi, NSTCITEMSTATE nstcisMask, NSTCITEMSTATE nstcisState) => HRESULT.S_OK;

		HRESULT INameSpaceTreeControlEvents.OnKeyboardInput(uint uMsg, IntPtr wParam, IntPtr lParam)
		{
			System.Diagnostics.Debug.WriteLine($"Kbd msg: {(WindowMessage)uMsg}, {(Keys)unchecked((int)(long)wParam)}");
			//var args = new KeyEventArgs((Keys)unchecked((int)(long)wParam) | ModifierKeys);
			var hSel = SendMessage(hWndTreeView, ComCtl32.TreeViewMessage.TVM_GETNEXTITEM, ComCtl32.TreeViewActionFlag.TVGN_CARET);
			if (hSel != default && uMsg == (uint)WindowMessage.WM_KEYUP)
			{
				switch ((Keys)unchecked((int)(long)wParam))
				{
					case Keys.Down:
						//Move(IsExpanded(hSel) ? ComCtl32.TreeViewActionFlag.TVGN_CHILD : ComCtl32.TreeViewActionFlag.TVGN_NEXT);
						Move(ComCtl32.TreeViewActionFlag.TVGN_NEXTVISIBLE);
						break;
					case Keys.Up:
						//var hPrev = SendMessage(hWndTreeView, ComCtl32.TreeViewMessage.TVM_GETNEXTITEM, ComCtl32.TreeViewActionFlag.TVGN_PREVIOUS, hSel);
						//if (hPrev != default)
						//{
						//	if (IsExpanded(hPrev))
						//		Move(ComCtl32.TreeViewActionFlag.TVGN_PREVIOUSVISIBLE);
						//	else
						//		SelItem(hPrev);
						//}
						Move(ComCtl32.TreeViewActionFlag.TVGN_PREVIOUSVISIBLE);
						break;
					case Keys.Right:
						if (IsExpanded(hSel))
							Move(ComCtl32.TreeViewActionFlag.TVGN_CHILD);
						else
							SendMessage(hWndTreeView, ComCtl32.TreeViewMessage.TVM_EXPAND, ComCtl32.TreeViewExpandFlags.TVE_EXPAND, hSel);
						break;
					case Keys.Left:
						if (IsExpanded(hSel))
							SendMessage(hWndTreeView, ComCtl32.TreeViewMessage.TVM_EXPAND, ComCtl32.TreeViewExpandFlags.TVE_COLLAPSE, hSel);
						else
							Move(ComCtl32.TreeViewActionFlag.TVGN_PARENT);
						break;
					case Keys.Home:
						Move(ComCtl32.TreeViewActionFlag.TVGN_ROOT);
						break;
					case Keys.End:
						Move(ComCtl32.TreeViewActionFlag.TVGN_LASTVISIBLE);
						break;
					case Keys.Enter:
						break;
					case Keys.Space:
						break;
				}
			}
			//if (uMsg == (uint)WindowMessage.WM_KEYUP)
			//	OnKeyUp(args);
			//return args.Handled ? HRESULT.S_FALSE : HRESULT.S_OK;
			return HRESULT.S_FALSE;

			bool IsExpanded(IntPtr item) => SendMessage(hWndTreeView, (uint)ComCtl32.TreeViewMessage.TVM_GETITEMSTATE, item, (IntPtr)(int)ComCtl32.TreeViewItemStates.TVIS_EXPANDED) == (IntPtr)(int)ComCtl32.TreeViewItemStates.TVIS_EXPANDED;

			void Move(ComCtl32.TreeViewActionFlag dir)
			{
				SelItem(SendMessage(hWndTreeView, ComCtl32.TreeViewMessage.TVM_GETNEXTITEM, dir, hSel));
			}

			void SelItem(IntPtr hNext)
			{
				if (hNext != default)
					SendMessage(hWndTreeView, ComCtl32.TreeViewMessage.TVM_SELECTITEM, ComCtl32.TreeViewActionFlag.TVGN_CARET, hNext);
			}
		}

		HRESULT INameSpaceTreeControlEvents.OnPropertyItemCommit(IShellItem psi) => HRESULT.S_FALSE;

		HRESULT INameSpaceTreeControlEvents.OnSelectionChanged(IShellItemArray psiaSelection)
		{
			OnAfterSelect();
			return HRESULT.S_OK;
		}

		HRESULT Shell32.IServiceProvider.QueryService(in Guid guidService, in Guid riid, out IntPtr ppvObject)
		{
			if (riid == typeof(INameSpaceTreeControlDropHandler).GUID)
			{
				ppvObject = Marshal.GetComInterfaceForObject(this, typeof(INameSpaceTreeControlDropHandler)); ;
				return HRESULT.S_OK;
			}
			else if (riid == typeof(INameSpaceTreeControlEvents).GUID)
			{
				ppvObject = Marshal.GetComInterfaceForObject(this, typeof(INameSpaceTreeControlEvents)); ;
				return HRESULT.S_OK;
			}
			ppvObject = default;
			return HRESULT.E_NOINTERFACE;
		}

		/// <summary>Releases unmanaged and - optionally - managed resources.</summary>
		/// <param name="disposing">
		/// <see langword="true"/> to release both managed and unmanaged resources; <see langword="false"/> to release only unmanaged resources.
		/// </param>
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (oleUninit) Ole32.OleUninitialize();
		}

		/// <summary>Raises the <see cref="AfterSelect"/> event.</summary>
		protected virtual void OnAfterSelect() => AfterSelect?.Invoke(this, EventArgs.Empty);

		/// <summary>Raises the <see cref="M:System.Windows.Forms.Control.CreateControl"/> method.</summary>
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			if (this.IsDesignMode()) return;

			// Grab interfaces
			pCtrl = new INameSpaceTreeControl();
			pCtrl2 = pCtrl as INameSpaceTreeControl2;

			// Initialize and capture child window handles
			var rect = BorderStyle == BorderStyle.None ? Bounds : Rectangle.Inflate(Bounds, -1, -1);
			pCtrl.Initialize(Parent.Handle, rect, style).ThrowIfFailed();
			var sb = new StringBuilder(512);
			var srect = (RECT)RectangleToScreen(rect);
			hWndNsTreeCtrl = User32.EnumChildWindows(Parent.Handle).First(h => IsClass(h, "NamespaceTreeControl"));
			hWndTreeView = hWndNsTreeCtrl.EnumChildWindows().First(h => IsClass(h, "SysTreeView32"));

			// Remove default roots and update style
			pCtrl.RemoveAllRoots();
			UpdateStyle();

			// Setup event handler and sink
			pCtrl.TreeAdvise(this, out adviseCookie).ThrowIfFailed();
			SetSite(this);
			Application.AddMessageFilter(this);

			bool IsClass(HWND hWnd, string className) =>
				GetClassName(hWnd, sb, sb.Capacity) > 0 && sb.ToString() == className && GetWindowRect(hWnd, out var r) && r == srect;
		}

		/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.GotFocus"/> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			if (!hWndTreeView.IsNull)
				SetFocus(hWndTreeView);
		}

		/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.KeyDown"/> event.</summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs"/> that contains the event data.</param>
		protected override void OnKeyDown(KeyEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine($"Base KeyDown: {e.KeyCode}");
			base.OnKeyDown(e);
		}

		/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.KeyUp"/> event.</summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs"/> that contains the event data.</param>
		protected override void OnKeyUp(KeyEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine($"Base KeyUp: {e.KeyCode}");
			base.OnKeyUp(e);
		}

		/// <summary>Raises the <see cref="E:HandleDestroyed"/> event.</summary>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected override void OnHandleDestroyed(EventArgs e)
		{
			if (pCtrl != null)
			{
				if (adviseCookie > 0)
					pCtrl.TreeUnadvise(adviseCookie);
				SetSite(null);
				pCtrl = null;
			}
			pCtrl2 = null;

			base.OnHandleDestroyed(e);
		}

		/// <summary>Raises the <see cref="E:Paint"/> event.</summary>
		/// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			if (borderStyle != BorderStyle.None)
				ControlPaint.DrawBorder3D(e.Graphics, Bounds, Border3DStyle.Flat);
		}

		/// <summary>Raises the <see cref="E:SizeChanged"/> event.</summary>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			SetWindowPos(hWndNsTreeCtrl, HWND.NULL, Left, Top, Width, Height, SetWindowPosFlags.SWP_NOACTIVATE | SetWindowPosFlags.SWP_NOOWNERZORDER | SetWindowPosFlags.SWP_NOZORDER);
		}

		/// <summary>Enables a container to pass an object a pointer to the interface for its site.</summary>
		/// <param name="sp">
		/// A pointer to the <c>IServiceProvider</c> interface pointer of the site managing this object. If <see langword="null"/>, the
		/// object should call Release on any existing site at which point the object no longer knows its site.
		/// </param>
		protected virtual void SetSite(Shell32.IServiceProvider sp) => (pCtrl as IObjectWithSite)?.SetSite(sp);

		private static System.Collections.Specialized.StringCollection GetStringCollection(IShellItemArray psiaData)
		{
			using var shiArray = new ShellItemArray(psiaData);
			var fileList = new System.Collections.Specialized.StringCollection();
			fileList.AddRange(shiArray.Select(shi => shi.ParsingName).ToArray());
			return fileList;
		}

		private IEnumerable<IShellItem> EnumChildren(IShellItem psi)
		{
			if (psi is null) yield break;
			foreach (var i in GetChildren(psi))
			{
				yield return i;
				GetChildren(i);
			}

			IEnumerable<IShellItem> GetChildren(IShellItem shi)
			{
				var hr = pCtrl.GetNextItem(shi, NSTCGNI.NSTCGNI_CHILD, out var nxt);
				while (hr.Succeeded)
				{
					yield return nxt;
					hr = pCtrl.GetNextItem(nxt, NSTCGNI.NSTCGNI_NEXT, out nxt);
				}
			}
		}

		private IEnumerable<IShellItem> EnumVisibleItems()
		{
			var hr = pCtrl.GetNextItem(null, NSTCGNI.NSTCGNI_FIRSTVISIBLE, out var psi);
			while (hr.Succeeded)
			{
				yield return psi;
				hr = pCtrl.GetNextItem(psi, NSTCGNI.NSTCGNI_NEXTVISIBLE, out psi);
			}
		}

		private bool HasTreeStyle(NSTCSTYLE style) => this.style[style];

		private bool HasTreeStyle(NSTCSTYLE2 style) => style2[style];

		private bool SetTreeStyle(NSTCSTYLE style, bool value)
		{
			if (HasTreeStyle(style) == value) return false;
			this.style[style] = value;
			UpdateStyle();
			return true;
		}

		private void SetTreeStyle(NSTCSTYLE2 style, bool value)
		{
			if (HasTreeStyle(style) == value) return;
			style2[style] = value;
			UpdateStyle();
		}

		private void UpdateStyle()
		{
			if (!IsHandleCreated) return;

			// Set styles
			pCtrl2?.SetControlStyle(NSTCSTYLE_ALL, style);
			pCtrl2?.SetControlStyle2(NSTCSTYLE2_ALL, style2);

			// Get the current root items and states of visible items
			var states = EnumVisibleItems().Select(i => (i, GetState(i))).Where(t => t.Item2 != NSTCITEMSTATE.NSTCIS_NONE).ToList();

			// Reset the list (required to refresh)
			RootItems.SyncWithParent();

			// Add back all roots and their states
			foreach (var (i, state, num, childOnly) in RootItems.Select(i => (i, GetState(i.IShellItem), pCtrl.GetItemCustomState(i.IShellItem, out var num).Succeeded ? num : 0, RootItems.onlyShowChildren[i])))
			{
				//RootItems.Add(i, childOnly, state.IsFlagSet(NSTCITEMSTATE.NSTCIS_EXPANDED));
				if (state != NSTCITEMSTATE.NSTCIS_NONE)
					pCtrl.SetItemState(i.IShellItem, NSTCITEMSTATE_ALL, state);
				if (num != 0)
					pCtrl.SetItemCustomState(i.IShellItem, num);
			}

			// Add back all states for visible items
			foreach (var (i, state) in states)
				pCtrl.SetItemState(i, NSTCITEMSTATE_ALL, state);

			NSTCITEMSTATE GetState(IShellItem shi) => pCtrl.GetItemState(shi, NSTCITEMSTATE_ALL, out var state).Succeeded ? state : 0;
		}

		//HRESULT INameSpaceTreeAccessible.OnGetDefaultAccessibilityAction(IShellItem psi, out string pbstrDefaultAction) => throw new NotImplementedException();
		//HRESULT INameSpaceTreeAccessible.OnDoDefaultAccessibilityAction(IShellItem psi) => throw new NotImplementedException();
		//HRESULT INameSpaceTreeAccessible.OnGetAccessibilityRole(IShellItem psi, out object pvarRole) => throw new NotImplementedException();
	}

	/// <summary>Provides data for the BeforeExpand, and BeforeSelect events of a <see cref="ShellNamespaceTreeControl"/> control.</summary>
	/// <seealso cref="CancelEventArgs"/>
	public class ShellNamespaceTreeControlCancelEventArgs : CancelEventArgs
	{
		/// <summary>Initializes a new instance of the <see cref="ShellNamespaceTreeControlEventArgs"/> class.</summary>
		/// <param name="shellItem">The shell item instance.</param>
		/// <param name="cancel"><see langword="true"/> to cancel the event; otherwise, <see langword="false"/>.</param>
		/// <param name="action">The action performed.</param>
		public ShellNamespaceTreeControlCancelEventArgs(ShellItem shellItem, bool cancel, ShellNamespaceTreeControlAction action) : base(cancel)
		{
			Item = shellItem;
			Action = action;
		}

		internal ShellNamespaceTreeControlCancelEventArgs(IShellItem psi, bool cancel, ShellNamespaceTreeControlAction action) :
			this(psi is null ? null : ShellItem.Open(psi), cancel, action)
		{
		}

		/// <summary>The action associated with this event.</summary>
		public ShellNamespaceTreeControlAction Action { get; }

		/// <summary>The shell item associated with this event.</summary>
		public ShellItem Item { get; }
	}

	/// <summary>Event arguments for actions against <see cref="ShellNamespaceTreeControl"/>.</summary>
	/// <seealso cref="EventArgs"/>
	public class ShellNamespaceTreeControlEventArgs : EventArgs
	{
		/// <summary>Initializes a new instance of the <see cref="ShellNamespaceTreeControlEventArgs"/> class.</summary>
		/// <param name="shellItem">The shell item instance.</param>
		/// <param name="action">The action performed.</param>
		public ShellNamespaceTreeControlEventArgs(ShellItem shellItem, ShellNamespaceTreeControlAction action)
		{
			Item = shellItem;
			Action = action;
		}

		internal ShellNamespaceTreeControlEventArgs(IShellItem psi, ShellNamespaceTreeControlAction action)
		{
			Item = psi is null ? null : ShellItem.Open(psi);
			Action = action;
		}

		/// <summary>The action associated with this event.</summary>
		public ShellNamespaceTreeControlAction Action { get; }

		/// <summary>The shell item associated with this event.</summary>
		public ShellItem Item { get; }
	}

	/// <summary>Arguments for item label edit events in a <see cref="ShellNamespaceTreeControl"/>.</summary>
	/// <seealso cref="EventArgs"/>
	public class ShellNamespaceTreeControlItemLabelEditEventArgs : EventArgs
	{
		/// <summary>Initializes a new instance of the <see cref="ShellNamespaceTreeControlItemLabelEditEventArgs"/> class.</summary>
		/// <param name="shellItem">The shell item.</param>
		public ShellNamespaceTreeControlItemLabelEditEventArgs(ShellItem shellItem) => Item = shellItem;

		internal ShellNamespaceTreeControlItemLabelEditEventArgs(IShellItem psi) => Item = psi is null ? null : ShellItem.Open(psi);

		/// <summary>On return, set to <see langword="true"/> to cancel the edit.</summary>
		public bool CancelEdit { get; set; }

		/// <summary>The shell item associated with this event.</summary>
		public ShellItem Item { get; }

		/// <summary>The label associated with the selected item.</summary>
		public string Label => Item?.Name;
	}

	/// <summary>Arguments for mouse click events in a <see cref="ShellNamespaceTreeControl"/>.</summary>
	public class ShellNamespaceTreeControlItemMouseClickEventArgs : HandledMouseEventArgs
	{
		internal ShellNamespaceTreeControlItemMouseClickEventArgs(IShellItem item, MouseButtons button, NSTCEHITTEST ht)
			: base(button, 1, 0, 0, 0)
		{
			Item = ShellItem.Open(item);
			HitLocation = (ItemHitLocation)ht;
		}

		/// <summary>The location of the item that has been clicked.</summary>
		public ItemHitLocation HitLocation { get; }

		/// <summary>The shell item associated with this event.</summary>
		public ShellItem Item { get; }
	}

	/// <summary>Encapsulates the list of root items in a <see cref="ShellNamespaceTreeControl"/>.</summary>
	public class ShellNamespaceTreeRootList : IList<ShellItem>
	{
		internal Dictionary<ShellItem, bool> onlyShowChildren = new Dictionary<ShellItem, bool>();

		internal ShellNamespaceTreeRootList(ShellNamespaceTreeControl parent) => Parent = parent;

		/// <summary>Gets the number of elements contained in the <see cref="ICollection{ShellItem}"/>.</summary>
		public int Count => onlyShowChildren.Count;

		/// <summary>Gets a value indicating whether this instance is read only.</summary>
		/// <value><see langword="true"/> if this instance is read only; otherwise, <see langword="false"/>.</value>
		bool ICollection<ShellItem>.IsReadOnly => false;

		private ShellNamespaceTreeControl Parent { get; }

		/// <summary>Gets or sets the <see cref="ShellItem"/> at the specified index.</summary>
		/// <value>The <see cref="ShellItem"/>.</value>
		/// <param name="index">The index.</param>
		/// <returns>A <see cref="ShellItem"/> instance.</returns>
		public ShellItem this[int index]
		{
			get => GetItemArray()[index];
			set
			{
				if (index == Count)
					Add(value, false, false);
				else
				{
					((IList<ShellItem>)this).RemoveAt(index);
					Insert(index, value, false, false);
				}
			}
		}

		/// <summary>Appends a Shell item to the list of roots in a tree.</summary>
		/// <param name="item">The Shell item to append.</param>
		/// <param name="showChildrenOnly">The root is hidden so that the children only are visible. Mutually exclusive with NSTCRS_VISIBLE.</param>
		/// <param name="expanded">The root is expanded upon initialization.</param>
		public void Add(ShellItem item, bool showChildrenOnly, bool expanded)
		{
			Parent.pCtrl.AppendRoot(item.IShellItem, item.IsFolder ? SHCONTF.SHCONTF_FOLDERS : SHCONTF.SHCONTF_NONFOLDERS,
				(expanded ? NSTCROOTSTYLE.NSTCRS_EXPANDED : 0) | (showChildrenOnly ? NSTCROOTSTYLE.NSTCRS_HIDDEN : NSTCROOTSTYLE.NSTCRS_VISIBLE));
			onlyShowChildren[item] = showChildrenOnly;
		}

		/// <summary>Removes all items from this list.</summary>
		public void Clear()
		{
			Parent.pCtrl.RemoveAllRoots();
			onlyShowChildren.Clear();
		}

		/// <summary>
		/// Copies the elements of the <see cref="ICollection{ShellItem}"/> to an <see cref="T:System.Array"/>, starting at a particular
		/// <see cref="Array"/> index.
		/// </summary>
		/// <param name="array">
		/// The one-dimensional <see cref="Array"/> that is the destination of the elements copied from <see
		/// cref="ICollection{ShellItem}"/>. The <see cref="Array"/> must have zero-based indexing.
		/// </param>
		/// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
		public void CopyTo(ShellItem[] array, int arrayIndex) => onlyShowChildren.Keys.CopyTo(array, arrayIndex);

		/// <summary>Returns an enumerator that iterates through the collection.</summary>
		/// <returns>A <see cref="IEnumerator{ShellItem}"/> that can be used to iterate through the collection.</returns>
		public IEnumerator<ShellItem> GetEnumerator() => onlyShowChildren.Keys.GetEnumerator();

		/// <summary>Searches for the specified object and returns the zero-based index of the first occurrence within the entire list.</summary>
		/// <param name="item">The object to locate in the list. The value can be <see langword="null"/> for reference types.</param>
		/// <returns>The zero-based index of the first occurrence of item within the entire list, if found; otherwise, -1.</returns>
		public int IndexOf(ShellItem item) => onlyShowChildren.Keys.ToList().FindIndex(i => i.Equals(item));

		/// <summary>Inserts a Shell item to the list of roots in a tree.</summary>
		/// <param name="index">The index at which to insert the root.</param>
		/// <param name="item">The Shell item to append.</param>
		/// <param name="showChildrenOnly">The root is hidden so that the children only are visible. Mutually exclusive with NSTCRS_VISIBLE.</param>
		/// <param name="expanded">The root is expanded upon initialization.</param>
		public void Insert(int index, ShellItem item, bool showChildrenOnly, bool expanded)
		{
			Parent.pCtrl.InsertRoot(index, item.IShellItem, item.IsFolder ? SHCONTF.SHCONTF_FOLDERS : SHCONTF.SHCONTF_NONFOLDERS,
				(expanded ? NSTCROOTSTYLE.NSTCRS_EXPANDED : 0) | (showChildrenOnly ? NSTCROOTSTYLE.NSTCRS_HIDDEN : NSTCROOTSTYLE.NSTCRS_VISIBLE));
			onlyShowChildren[item] = showChildrenOnly;
		}

		/// <summary>Removes the first occurrence of a specific object from the list.</summary>
		/// <param name="item">The object to remove from the list. The value can be <see langword="null"/> for reference types.</param>
		/// <returns>
		/// <see langword="true"/> if item is successfully removed; otherwise, <see langword="false"/>. This method also returns <see
		/// langword="false"/> if item was not found in the list.
		/// </returns>
		public bool Remove(ShellItem item)
		{
			onlyShowChildren.Remove(item);
			return Parent.pCtrl.RemoveRoot(item.IShellItem).Succeeded;
		}

		internal void SyncWithParent()
		{
			if (Parent.pCtrl is null) return;
			Parent.pCtrl.RemoveAllRoots();
			foreach (var kv in onlyShowChildren)
			{
				Parent.pCtrl.AppendRoot(kv.Key.IShellItem, kv.Key.IsFolder ? SHCONTF.SHCONTF_FOLDERS : SHCONTF.SHCONTF_NONFOLDERS,
					kv.Value ? NSTCROOTSTYLE.NSTCRS_HIDDEN : NSTCROOTSTYLE.NSTCRS_VISIBLE);
			}
		}

		/// <summary>Adds an object to the end of the list.</summary>
		/// <param name="item">The object to be added to the end of the list. The value can be <see langword="null"/> for reference types.</param>
		void ICollection<ShellItem>.Add(ShellItem item) => Add(item, false, false);

		/// <summary>Determines whether an element is in the list.</summary>
		/// <param name="item">The object to locate in the list. The value can be <see langword="null"/> for reference types.</param>
		/// <returns><see langword="true"/> if item is found in the list; otherwise, <see langword="false"/>.</returns>
		bool ICollection<ShellItem>.Contains(ShellItem item) => onlyShowChildren.ContainsKey(item);

		/// <summary>Returns an enumerator that iterates through the list.</summary>
		/// <returns>An <see cref="IEnumerator"/> for the list.</returns>
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		/// <summary>Inserts an element into the lsit at the specified index.</summary>
		/// <param name="index">The zero-based index at which item should be inserted.</param>
		/// <param name="item">The object to insert. The value can be null for reference types.</param>
		void IList<ShellItem>.Insert(int index, ShellItem item) => Insert(index, item, false, false);

		/// <summary>Removes the element at the specified index of the list.</summary>
		/// <param name="index">The zero-based index of the element to remove.</param>
		void IList<ShellItem>.RemoveAt(int index)
		{
			Remove(this[index]);
		}

		internal ShellItemArray GetItemArray() => Parent.pCtrl.GetRootItems(out var pItems).Succeeded ? new ShellItemArray(pItems) : new ShellItemArray();
	}
}