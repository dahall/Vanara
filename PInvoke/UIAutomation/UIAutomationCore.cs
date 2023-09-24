using Accessibility;
using static Vanara.PInvoke.Oleacc;

namespace Vanara.PInvoke;

/// <summary>Items from the UIAutomationCore.dll.</summary>
public static partial class UIAutomationCore
{
	/// <summary>Contains values that specify the location of a docking window represented by the Dock <c>control pattern</c>.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/ne-uiautomationcore-dockposition typedef enum DockPosition {
	// DockPosition_Top = 0, DockPosition_Left = 1, DockPosition_Bottom = 2, DockPosition_Right = 3, DockPosition_Fill = 4, DockPosition_None
	// = 5 } ;
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NE:uiautomationcore.DockPosition")]
	public enum DockPosition
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The window is docked at the top.</para>
		/// </summary>
		DockPosition_Top = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The window is docked at the left.</para>
		/// </summary>
		DockPosition_Left,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>The window is docked at the bottom.</para>
		/// </summary>
		DockPosition_Bottom,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>The window is docked at the right.</para>
		/// </summary>
		DockPosition_Right,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>The window is docked on all four sides.</para>
		/// </summary>
		DockPosition_Fill,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>The window is not docked.</para>
		/// </summary>
		DockPosition_None,
	}

	/// <summary>Contains values that specify the state of a UI element that can be expanded and collapsed.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/ne-uiautomationcore-expandcollapsestate typedef enum
	// ExpandCollapseState { ExpandCollapseState_Collapsed = 0, ExpandCollapseState_Expanded = 1, ExpandCollapseState_PartiallyExpanded = 2,
	// ExpandCollapseState_LeafNode = 3 } ;
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NE:uiautomationcore.ExpandCollapseState")]
	public enum ExpandCollapseState
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>No children are visible.</para>
		/// </summary>
		ExpandCollapseState_Collapsed = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>All children are visible.</para>
		/// </summary>
		ExpandCollapseState_Expanded,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Some, but not all, children are visible.</para>
		/// </summary>
		ExpandCollapseState_PartiallyExpanded,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>The element does not expand or collapse.</para>
		/// </summary>
		ExpandCollapseState_LeafNode,
	}

	/// <summary>Contains values used to specify the direction of navigation within the Microsoft UI Automation tree.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/ne-uiautomationcore-navigatedirection typedef enum
	// NavigateDirection { NavigateDirection_Parent = 0, NavigateDirection_NextSibling = 1, NavigateDirection_PreviousSibling = 2,
	// NavigateDirection_FirstChild = 3, NavigateDirection_LastChild = 4 } ;
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NE:uiautomationcore.NavigateDirection")]
	public enum NavigateDirection
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The navigation direction is to the parent.</para>
		/// </summary>
		NavigateDirection_Parent = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The navigation direction is to the next sibling.</para>
		/// </summary>
		NavigateDirection_NextSibling,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>The navigation direction is to the previous sibling.</para>
		/// </summary>
		NavigateDirection_PreviousSibling,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>The navigation direction is to the first child.</para>
		/// </summary>
		NavigateDirection_FirstChild,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>The navigation direction is to the last child.</para>
		/// </summary>
		NavigateDirection_LastChild,
	}

	/// <summary>
	/// Contains values that specify the type of UI Automation provider. The IRawElementProviderSimple::ProviderOptions property uses this enumeration.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/ne-uiautomationcore-provideroptions typedef enum ProviderOptions
	// { ProviderOptions_ClientSideProvider = 0x1, ProviderOptions_ServerSideProvider = 0x2, ProviderOptions_NonClientAreaProvider = 0x4,
	// ProviderOptions_OverrideProvider = 0x8, ProviderOptions_ProviderOwnsSetFocus = 0x10, ProviderOptions_UseComThreading = 0x20,
	// ProviderOptions_RefuseNonClientSupport = 0x40, ProviderOptions_HasNativeIAccessible = 0x80, ProviderOptions_UseClientCoordinates =
	// 0x100 } ;
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NE:uiautomationcore.ProviderOptions")]
	[Flags]
	public enum ProviderOptions
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>The provider is a client-side (proxy) provider.</para>
		/// </summary>
		ProviderOptions_ClientSideProvider = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>The provider is a server-side provider.</para>
		/// </summary>
		ProviderOptions_ServerSideProvider = 2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>The provider is a non-client-area provider.</para>
		/// </summary>
		ProviderOptions_NonClientAreaProvider = 4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8</para>
		/// <para>The provider overrides another provider.</para>
		/// </summary>
		ProviderOptions_OverrideProvider = 8,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10</para>
		/// <para>
		/// The provider handles its own focus, and does not want UI Automation to set focus to the nearest window on its behalf. This option
		/// is typically used by providers for windows that appear to take focus without actually receiving Win32 focus, such as menus and drop-downs.
		/// </para>
		/// </summary>
		ProviderOptions_ProviderOwnsSetFocus = 16,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x20</para>
		/// <para>
		/// The provider has explicit support for COM threading models, so that calls by UI Automation on COM-based providers are received on
		/// the appropriate thread. This means that STA-based provider implementations will be called back on their own STA thread, and
		/// therefore do not need extra synchronization to safely access resources that belong to that STA. MTA-based provider
		/// implementations will be called back on some other thread in the MTA, and will require appropriate synchronization to be added, as
		/// is usual for MTA code.
		/// </para>
		/// </summary>
		ProviderOptions_UseComThreading = 32,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x40</para>
		/// <para>
		/// The provider handles its own non-client area and does not want UI Automation to provide default accessibility support for
		/// controls in the non-client area, such as minimize/maximize buttons and menu bars.
		/// </para>
		/// </summary>
		ProviderOptions_RefuseNonClientSupport = 64,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x80</para>
		/// <para>The provider implements the</para>
		/// <para>IAccessible</para>
		/// <para>interface.</para>
		/// </summary>
		ProviderOptions_HasNativeIAccessible = 128,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x100</para>
		/// <para>The provider works in client coordinates instead of screen coordinates.</para>
		/// </summary>
		ProviderOptions_UseClientCoordinates = 256,
	}

	/// <summary>Contains values that specify whether data in a table should be read primarily by row or by column.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/ne-uiautomationcore-roworcolumnmajor typedef enum
	// RowOrColumnMajor { RowOrColumnMajor_RowMajor = 0, RowOrColumnMajor_ColumnMajor = 1, RowOrColumnMajor_Indeterminate = 2 } ;
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NE:uiautomationcore.RowOrColumnMajor")]
	public enum RowOrColumnMajor
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Data in the table should be read row by row.</para>
		/// </summary>
		RowOrColumnMajor_RowMajor,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Data in the table should be read column by column.</para>
		/// </summary>
		RowOrColumnMajor_ColumnMajor,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>The best way to present the data is indeterminate.</para>
		/// </summary>
		RowOrColumnMajor_Indeterminate,
	}

	/// <summary>Contains values that specify the direction and distance to scroll.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/ne-uiautomationcore-scrollamount typedef enum ScrollAmount {
	// ScrollAmount_LargeDecrement = 0, ScrollAmount_SmallDecrement = 1, ScrollAmount_NoAmount = 2, ScrollAmount_LargeIncrement = 3,
	// ScrollAmount_SmallIncrement = 4 } ;
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NE:uiautomationcore.ScrollAmount")]
	public enum ScrollAmount
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>
		/// Scrolling is done in large decrements, equivalent to pressing the PAGE UP key or clicking on a blank part of a scroll bar. If one
		/// page up is not a relevant amount for the control and no scroll bar exists, the value represents an amount equal to the current
		/// visible window.
		/// </para>
		/// </summary>
		ScrollAmount_LargeDecrement,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Scrolling is done in small decrements, equivalent to pressing an arrow key or clicking the arrow button on a scroll bar.</para>
		/// </summary>
		ScrollAmount_SmallDecrement,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>No scrolling is done.</para>
		/// </summary>
		ScrollAmount_NoAmount,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>
		/// Scrolling is done in large increments, equivalent to pressing the PAGE DOWN or PAGE UP key or clicking on a blank part of a
		/// scroll bar.
		/// </para>
		/// <para>
		/// If one page is not a relevant amount for the control and no scroll bar exists, the value represents an amount equal to the
		/// current visible window.
		/// </para>
		/// </summary>
		ScrollAmount_LargeIncrement,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Scrolling is done in small increments, equivalent to pressing an arrow key or clicking the arrow</para>
		/// <para>button on a scroll bar.</para>
		/// </summary>
		ScrollAmount_SmallIncrement,
	}

	/// <summary>Contains values that specify the type of change in the Microsoft UI Automation tree structure.</summary>
	/// <remarks>
	/// <para>
	/// Because the implementation of structure-change events depends on the underlying UI framework, UI Automation defines no strict rule
	/// governing when a provider must switch from sending individual ChildAdded or ChildRemoved events to the bulk equivalent. However, the
	/// switch typically occurs when two to five child elements are added or removed at once. The bulk events help to prevent clients from
	/// being flooded by individual ChildAdded and ChildRemoved events.
	/// </para>
	/// <para>
	/// Except for ChildAdded, structure-change events are always associated with the container element that holds the children. The
	/// ChildAdded event is associated with the element that was just added.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/ne-uiautomationcore-structurechangetype typedef enum
	// StructureChangeType { StructureChangeType_ChildAdded = 0, StructureChangeType_ChildRemoved, StructureChangeType_ChildrenInvalidated,
	// StructureChangeType_ChildrenBulkAdded, StructureChangeType_ChildrenBulkRemoved, StructureChangeType_ChildrenReordered } ;
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NE:uiautomationcore.StructureChangeType")]
	public enum StructureChangeType
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>A child element was added to the UI Automation element tree.</para>
		/// </summary>
		StructureChangeType_ChildAdded,

		/// <summary>A child element was removed from the UI Automation element tree.</summary>
		StructureChangeType_ChildRemoved,

		/// <summary>
		/// Child elements were invalidated in the UI Automation element tree. This might mean that one or more child elements were added or
		/// removed, or a combination of both. This value can also indicate that one subtree in the UI was substituted for another. For
		/// example, the entire contents of a dialog box changed at once, or the view of a list changed because an Explorer-type application
		/// navigated to another location. The exact meaning depends on the UI Automation provider implementation.
		/// </summary>
		StructureChangeType_ChildrenInvalidated,

		/// <summary>Child elements were added in bulk to the UI Automation element tree.</summary>
		StructureChangeType_ChildrenBulkAdded,

		/// <summary>Child elements were removed in bulk from the UI Automation element tree.</summary>
		StructureChangeType_ChildrenBulkRemoved,

		/// <summary>
		/// The order of child elements has changed in the UI Automation element tree. Child elements may or may not have been added or removed.
		/// </summary>
		StructureChangeType_ChildrenReordered,
	}

	/// <summary>Contains values that specify the supported text selection attribute.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/ne-uiautomationcore-supportedtextselection typedef enum
	// SupportedTextSelection { SupportedTextSelection_None = 0, SupportedTextSelection_Single = 1, SupportedTextSelection_Multiple = 2 } ;
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NE:uiautomationcore.SupportedTextSelection")]
	public enum SupportedTextSelection
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Does not support text selections.</para>
		/// </summary>
		SupportedTextSelection_None,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Supports a single, continuous text selection.</para>
		/// </summary>
		SupportedTextSelection_Single,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Supports multiple, disjoint text selections.</para>
		/// </summary>
		SupportedTextSelection_Multiple,
	}

	/// <summary>Contains values that specify the type of synchronized input.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/ne-uiautomationcore-synchronizedinputtype typedef enum
	// SynchronizedInputType { SynchronizedInputType_KeyUp = 0x1, SynchronizedInputType_KeyDown = 0x2, SynchronizedInputType_LeftMouseUp =
	// 0x4, SynchronizedInputType_LeftMouseDown = 0x8, SynchronizedInputType_RightMouseUp = 0x10, SynchronizedInputType_RightMouseDown = 0x20
	// } ;
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NE:uiautomationcore.SynchronizedInputType")]
	[Flags]
	public enum SynchronizedInputType
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>A key has been released.</para>
		/// </summary>
		SynchronizedInputType_KeyUp = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>A key has been pressed.</para>
		/// </summary>
		SynchronizedInputType_KeyDown = 2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>The left mouse button has been released.</para>
		/// </summary>
		SynchronizedInputType_LeftMouseUp = 4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8</para>
		/// <para>The left mouse button has been pressed.</para>
		/// </summary>
		SynchronizedInputType_LeftMouseDown = 8,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10</para>
		/// <para>The right mouse button has been released.</para>
		/// </summary>
		SynchronizedInputType_RightMouseUp = 16,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x20</para>
		/// <para>The right mouse button has been pressed.</para>
		/// </summary>
		SynchronizedInputType_RightMouseDown = 32,
	}

	/// <summary>Contains values that specify the endpoints of a text range.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/ne-uiautomationcore-textpatternrangeendpoint typedef enum
	// TextPatternRangeEndpoint { TextPatternRangeEndpoint_Start = 0, TextPatternRangeEndpoint_End = 1 } ;
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NE:uiautomationcore.TextPatternRangeEndpoint")]
	public enum TextPatternRangeEndpoint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The starting endpoint of the range.</para>
		/// </summary>
		TextPatternRangeEndpoint_Start,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The ending endpoint of the range.</para>
		/// </summary>
		TextPatternRangeEndpoint_End,
	}

	/// <summary>Contains values that specify units of text for the purposes of navigation.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/ne-uiautomationcore-textunit typedef enum TextUnit {
	// TextUnit_Character = 0, TextUnit_Format = 1, TextUnit_Word = 2, TextUnit_Line = 3, TextUnit_Paragraph = 4, TextUnit_Page = 5,
	// TextUnit_Document = 6 } ;
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NE:uiautomationcore.TextUnit")]
	public enum TextUnit
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Character.</para>
		/// </summary>
		TextUnit_Character,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Format.</para>
		/// </summary>
		TextUnit_Format,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Word.</para>
		/// </summary>
		TextUnit_Word,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Line.</para>
		/// </summary>
		TextUnit_Line,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Paragraph.</para>
		/// </summary>
		TextUnit_Paragraph,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>Page.</para>
		/// </summary>
		TextUnit_Page,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>Document.</para>
		/// </summary>
		TextUnit_Document,
	}

	/// <summary>
	/// Contains values that specify the toggle state of a Microsoft UI Automation element that implements the Toggle <c>control pattern</c>.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/ne-uiautomationcore-togglestate typedef enum ToggleState {
	// ToggleState_Off = 0, ToggleState_On = 1, ToggleState_Indeterminate = 2 } ;
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NE:uiautomationcore.ToggleState")]
	public enum ToggleState
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The UI Automation element is not selected, checked, marked or otherwise activated.</para>
		/// </summary>
		ToggleState_Off,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The UI Automation element is selected, checked, marked or otherwise activated.</para>
		/// </summary>
		ToggleState_On,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>The UI Automation element is in an indeterminate state.</para>
		/// <para>The Indeterminate property can be used to indicate whether the user has acted</para>
		/// <para>on a control. For example, a check box can appear checked and dimmed, indicating an indeterminate state.</para>
		/// <para>Creating an indeterminate state is different from disabling the control.</para>
		/// <para>Consequently, a check box in the indeterminate state can still receive the focus.</para>
		/// <para>When the user clicks an indeterminate control the ToggleState cycles to its next value.</para>
		/// </summary>
		ToggleState_Indeterminate,
	}

	/// <summary>Contains values used to indicate Microsoft UI Automation data types.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/ne-uiautomationcore-uiautomationtype typedef enum
	// UIAutomationType { UIAutomationType_Int = 0x1, UIAutomationType_Bool = 0x2, UIAutomationType_String = 0x3, UIAutomationType_Double =
	// 0x4, UIAutomationType_Point = 0x5, UIAutomationType_Rect = 0x6, UIAutomationType_Element = 0x7, UIAutomationType_Array = 0x10000,
	// UIAutomationType_Out = 0x20000, UIAutomationType_IntArray, UIAutomationType_BoolArray, UIAutomationType_StringArray,
	// UIAutomationType_DoubleArray, UIAutomationType_PointArray, UIAutomationType_RectArray, UIAutomationType_ElementArray,
	// UIAutomationType_OutInt, UIAutomationType_OutBool, UIAutomationType_OutString, UIAutomationType_OutDouble, UIAutomationType_OutPoint,
	// UIAutomationType_OutRect, UIAutomationType_OutElement, UIAutomationType_OutIntArray, UIAutomationType_OutBoolArray,
	// UIAutomationType_OutStringArray, UIAutomationType_OutDoubleArray, UIAutomationType_OutPointArray, UIAutomationType_OutRectArray,
	// UIAutomationType_OutElementArray } ;
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NE:uiautomationcore.UIAutomationType")]
	public enum UIAutomationType
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>An integer.</para>
		/// </summary>
		UIAutomationType_Int = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>An Boolean value.</para>
		/// </summary>
		UIAutomationType_Bool,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x3</para>
		/// <para>A null-terminated character string.</para>
		/// </summary>
		UIAutomationType_String,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>A double-precision floating-point number.</para>
		/// </summary>
		UIAutomationType_Double,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x5</para>
		/// <para>A</para>
		/// <para>POINT</para>
		/// <para>structure containing the x- and y-coordinates of a point.</para>
		/// </summary>
		UIAutomationType_Point,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x6</para>
		/// <para>A</para>
		/// <para>RECT</para>
		/// <para>
		/// structure containing the coordinates of the upper-left and lower-right corners of a rectangle. This type is not supported for a
		/// custom UI Automation property.
		/// </para>
		/// </summary>
		UIAutomationType_Rect,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x7</para>
		/// <para>The address of the</para>
		/// <para>IUIAutomationElement</para>
		/// <para>interface of a UI Automation element.</para>
		/// </summary>
		UIAutomationType_Element,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10000</para>
		/// <para>An array of an unspecified type.</para>
		/// </summary>
		UIAutomationType_Array = 65536,

		/// <summary>An array of integers. This type is not supported for a custom UI Automation property.</summary>
		UIAutomationType_IntArray,

		/// <summary>An array of Boolean values. This type is not supported for a custom UI Automation property.</summary>
		UIAutomationType_BoolArray,

		/// <summary>An array of null-terminated character strings. This type is not supported for a custom UI Automation property.</summary>
		UIAutomationType_StringArray,

		/// <summary>An array of double-precision floating-point numbers. This type is not supported for a custom UI Automation property.</summary>
		UIAutomationType_DoubleArray,

		/// <summary>
		/// <para>An array of</para>
		/// <para>POINT</para>
		/// <para>
		/// structures, each containing the x- and y-coordinates of a point. This type is not supported for a custom UI Automation property.
		/// </para>
		/// </summary>
		UIAutomationType_PointArray,

		/// <summary>
		/// <para>An array of</para>
		/// <para>RECT</para>
		/// <para>
		/// structures, each containing the coordinates of the upper-left and lower-right corners of a rectangle. This type is not supported
		/// for a custom UI Automation property.
		/// </para>
		/// </summary>
		UIAutomationType_RectArray,

		/// <summary>
		/// <para>An array of pointers to</para>
		/// <para>IUIAutomationElement</para>
		/// <para>interfaces, each for a UI Automation element.</para>
		/// </summary>
		UIAutomationType_ElementArray,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x20000</para>
		/// <para>The address of a variable that receives a value retrieved by a function.</para>
		/// </summary>
		UIAutomationType_Out = 0x20000,

		/// <summary>The address of a variable that receives an integer value.</summary>
		UIAutomationType_OutInt,

		/// <summary>The address of a variable that receives a Boolean value.</summary>
		UIAutomationType_OutBool,

		/// <summary>The address of a variable that receives a null-terminated character string.</summary>
		UIAutomationType_OutString,

		/// <summary>The address of a variable that receives a double-precision floating-point number.</summary>
		UIAutomationType_OutDouble,

		/// <summary>
		/// <para>The address of a variable that receives a</para>
		/// <para>POINT</para>
		/// <para>structure.</para>
		/// </summary>
		UIAutomationType_OutPoint,

		/// <summary>
		/// <para>The address of a variable that receives a</para>
		/// <para>RECT</para>
		/// <para>structure.</para>
		/// </summary>
		UIAutomationType_OutRect,

		/// <summary>
		/// <para>The address of a variable that receives a pointer to the</para>
		/// <para>IUIAutomationElement</para>
		/// <para>interface of a UI Automation element.</para>
		/// </summary>
		UIAutomationType_OutElement,

		/// <summary>The address of a variable that receives an array of integer values.</summary>
		UIAutomationType_OutIntArray = 196609,

		/// <summary>The address of a variable that receives an array of Boolean values.</summary>
		UIAutomationType_OutBoolArray,

		/// <summary>The address of a variable that receives an array of null-terminated character strings.</summary>
		UIAutomationType_OutStringArray,

		/// <summary>The address of a variable that receives an array of double-precision floating-point numbers.</summary>
		UIAutomationType_OutDoubleArray,

		/// <summary>
		/// <para>The address of a variable that receives an array of</para>
		/// <para>POINT</para>
		/// <para>structures.</para>
		/// </summary>
		UIAutomationType_OutPointArray,

		/// <summary>
		/// <para>The address of a variable that receives an array of</para>
		/// <para>RECT</para>
		/// <para>structures.</para>
		/// </summary>
		UIAutomationType_OutRectArray,

		/// <summary>
		/// <para>The address of a variable that receives an array of pointers to the</para>
		/// <para>IUIAutomationElement</para>
		/// <para>interfaces of UI Automation elements.</para>
		/// </summary>
		UIAutomationType_OutElementArray,
	}

	/// <summary>Contains values that specify the current state of the window for purposes of user interaction.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/ne-uiautomationcore-windowinteractionstate typedef enum
	// WindowInteractionState { WindowInteractionState_Running = 0, WindowInteractionState_Closing = 1,
	// WindowInteractionState_ReadyForUserInteraction = 2, WindowInteractionState_BlockedByModalWindow = 3,
	// WindowInteractionState_NotResponding = 4 } ;
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NE:uiautomationcore.WindowInteractionState")]
	public enum WindowInteractionState
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The window is running. This does not guarantee that the window is ready for user interaction or is responding.</para>
		/// </summary>
		WindowInteractionState_Running,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The window is closing.</para>
		/// </summary>
		WindowInteractionState_Closing,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>The window is ready for user interaction.</para>
		/// </summary>
		WindowInteractionState_ReadyForUserInteraction,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>The window is blocked by a modal window.</para>
		/// </summary>
		WindowInteractionState_BlockedByModalWindow,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>The window is not responding.</para>
		/// </summary>
		WindowInteractionState_NotResponding,
	}

	/// <summary>Contains values that specify the visual state of a window.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/ne-uiautomationcore-windowvisualstate typedef enum
	// WindowVisualState { WindowVisualState_Normal = 0, WindowVisualState_Maximized = 1, WindowVisualState_Minimized = 2 } ;
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NE:uiautomationcore.WindowVisualState")]
	public enum WindowVisualState
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The window is normal (restored).</para>
		/// </summary>
		WindowVisualState_Normal,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The window is maximized.</para>
		/// </summary>
		WindowVisualState_Maximized,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>The window is minimized.</para>
		/// </summary>
		WindowVisualState_Minimized,
	}

	/// <summary>
	/// Contains possible values for the IUIAutomationTransformPattern2::ZoomByUnit method, which zooms the viewport of a control by the
	/// specified unit.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/ne-uiautomationcore-zoomunit typedef enum ZoomUnit {
	// ZoomUnit_NoAmount = 0, ZoomUnit_LargeDecrement = 1, ZoomUnit_SmallDecrement = 2, ZoomUnit_LargeIncrement = 3, ZoomUnit_SmallIncrement
	// = 4 } ;
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NE:uiautomationcore.ZoomUnit")]
	public enum ZoomUnit
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>No increase or decrease in zoom.</para>
		/// </summary>
		ZoomUnit_NoAmount,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Decrease zoom by a large decrement.</para>
		/// </summary>
		ZoomUnit_LargeDecrement,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Decrease zoom by a small decrement.</para>
		/// </summary>
		ZoomUnit_SmallDecrement,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Increase zoom by a large increment.</para>
		/// </summary>
		ZoomUnit_LargeIncrement,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Increase zoom by a small increment.</para>
		/// </summary>
		ZoomUnit_SmallIncrement,
	}

	/// <summary>
	/// <para>
	/// Controls that do not have a Microsoft UI Automation provider, but that implement <c>IAccessible</c>, can easily be upgraded to
	/// provide some UI Automation functionality by implementing the <c>IAccessibleEx</c> interface. This interface enables the control to
	/// expose UI Automation properties and control patterns, without the need for a full implementation of UI Automation provider interfaces
	/// such as <c>IRawElementProviderFragment</c>. To use <c>IAccessibleEx</c>, <c>IRawElementProviderFragment</c>, and all other UI
	/// Automation interfaces, include the UIAutomation.h header file in your source code.
	/// </para>
	/// <para>
	/// For example, consider a custom control that has a range value. The Microsoft Active Accessibility server for the control defines the
	/// control's role and is able to return its current value. However, because Microsoft Active Accessibility does not define minimum and
	/// maximum properties, the server lacks the means to return the minimum and maximum values of the control. A UI Automation client is
	/// able to retrieve the control's role, current value, and other Microsoft Active Accessibility properties, because the UI Automation
	/// core can obtain these through <c>IAccessible</c>. However, without access to an <c>IRangeValueProvider</c> interface on the object,
	/// UI Automation is also unable to retrieve the maximum and minimum values.
	/// </para>
	/// <para>
	/// The control developer could supply a complete UI Automation provider for the control, but this would mean duplicating much of the
	/// existing functionality of the <c>IAccessible</c> implementation: for example, navigation and common properties. Instead, the
	/// developer can continue to rely on <c>IAccessible</c> to supply this functionality, while adding support for control-specific
	/// properties through <c>IRangeValueProvider</c>.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/winauto/iaccessibleex
	[PInvokeData("")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("f8b80ada-2c44-48d0-89be-5ff23c9cd875")]
	public interface IAccessibleEx
	{
		/// <summary>Retrieves an IAccessibleEx interface representing the specified child of this element.</summary>
		/// <param name="idChild">
		/// <para>Type: <c>long</c></para>
		/// <para>The identifier of the child element.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IAccessibleEx**</c></para>
		/// <para>Receives a pointer to the IAccessibleEx interface.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>pRetVal</c> returns <c>NULL</c> if this implementation does not use child IDs, or cannot provide an IAccessibleEx interface
		/// for the specified child, or itself represents a child element.
		/// </para>
		/// <para><c>idChild</c> must represent an actual MSAA child element, not an object that has its own IAccessible interface.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iaccessibleex-getobjectforchild HRESULT
		// GetObjectForChild( [in] long idChild, [out] IAccessibleEx **pRetVal );
		IAccessibleEx GetObjectForChild(int idChild);

		/// <summary>Retrieves the IAccessible interface and child ID for this item.</summary>
		/// <param name="ppAcc">
		/// <para>Type: <c>IAccessible**</c></para>
		/// <para>Receives a pointer to the IAccessible interface for this object, or the parent object if this is a child element.</para>
		/// </param>
		/// <param name="pidChild">
		/// <para>Type: <c>long*</c></para>
		/// <para>Receives the child ID, or CHILDID_SELF if this is not a child element.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iaccessibleex-getiaccessiblepair HRESULT
		// GetIAccessiblePair( [out] IAccessible **ppAcc, [out] long *pidChild );
		void GetIAccessiblePair(out IAccessible ppAcc, out int pidChild);

		/// <summary>Retrieves the runtime identifier of this element.</summary>
		/// <returns>
		/// <para>Type: <c>SAFEARRAY**</c></para>
		/// <para>Receives a pointer to the runtime identifier.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The runtime identifier is a provider-defined array of integers, the first item of which must be <c>UiaAppendRuntimeId</c>. The
		/// runtime identifier must be unique within the parent window.
		/// </para>
		/// <para>
		/// The MSAA-to-UIA Proxy uses the runtime identifier (together with the window handle) to determine if two interface instances refer
		/// to the same underlying element. If <c>IAccessibleEx::GetRuntimeId</c> is not implemented, the proxy performs field-by-field
		/// comparisons on the two IAccessible objects to determine if they are equivalent, which is less efficient.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iaccessibleex-getruntimeid HRESULT
		// GetRuntimeId( [out] SAFEARRAY **pRetVal );
		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)]
		int[] GetRuntimeId();

		/// <summary>Retrieves the IAccessibleEx interface of an element returned as a property value.</summary>
		/// <param name="pIn">
		/// <para>Type: <c>IRawElementProviderSimple*</c></para>
		/// <para>Pointer to the IRawElementProviderSimple interface that was retrieved as a property.</para>
		/// </param>
		/// <param name="ppRetValOut">
		/// <para>Type: <c>IAccessibleEx**</c></para>
		/// <para>Receives a pointer to the IAccessibleEx interface of the element.</para>
		/// </param>
		/// <remarks>
		/// This method is implemented by the bridge between Microsoft UI Automation and Microsoft Active Accessibility. Most other
		/// implementations should return E_NOTIMPL after setting <c>ppRetValOut</c> to <c>NULL</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iaccessibleex-convertreturnedelement
		// HRESULT ConvertReturnedElement( [in] IRawElementProviderSimple *pIn, [out] IAccessibleEx **ppRetValOut );
		void ConvertReturnedElement(IRawElementProviderSimple pIn, out IAccessibleEx ppRetValOut);
	}

	/// <summary>
	/// A Microsoft Active Accessibility object implements this interface when the object is the root of an accessibility tree that includes
	/// windowless Microsoft ActiveX controls that implement Microsoft UI Automation. Because Microsoft Active Accessibility and UI
	/// Automation use different interfaces, this interface enables a client to discover the list of hosted windowless ActiveX controls that
	/// support UI Automation in case the client needs to treat them differently.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-iaccessiblehostingelementproviders
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.IAccessibleHostingElementProviders")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("33ac331b-943e-4020-b295-db37784974a3")]
	public interface IAccessibleHostingElementProviders
	{
		/// <summary>
		/// Retrieves the Microsoft Active Accessibility providers of all windowless Microsoft ActiveX controls that have a Microsoft UI
		/// Automation provider implementation, and are hosted in a Microsoft Active Accessibility object that implements the
		/// IAccessibleHostingElementProviders interface.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>SAFEARRAY**</c></para>
		/// <para>Receives the IRawElementProviderFragmentRoot interface pointers.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The container of windowless ActiveX controls implements this method on the same object that implements the IAccessible interface.
		/// When called, this method queries each of the contained windowless ActiveX controls for an IRawElementProviderFragmentRoot
		/// pointer, and then adds the pointer to the safe array.
		/// </para>
		/// <para>This method should not include any providers that do not implement <c>IRawElementProviderFragmentRoot</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iaccessiblehostingelementproviders-getembeddedfragmentroots
		// HRESULT GetEmbeddedFragmentRoots( [out, retval] SAFEARRAY **pRetVal );
		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UNKNOWN)]
		IRawElementProviderFragmentRoot[] GetEmbeddedFragmentRoots();

		/// <summary>
		/// Retrieves the object ID associated with a contained windowless Microsoft ActiveX control that implements Microsoft UI Automation.
		/// </summary>
		/// <param name="pProvider">
		/// <para>Type: <c>IRawElementProviderSimple*</c></para>
		/// <para>The provider for the windowless ActiveX control.</para>
		/// </param>
		/// <param name="pidObject">
		/// <para>Type: <c>long*</c></para>
		/// <para>The object ID of the contained windowless ActiveX control.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iaccessiblehostingelementproviders-getobjectidforprovider
		// HRESULT GetObjectIdForProvider( [in, optional] IRawElementProviderSimple *pProvider, [out] long *pidObject );
		void GetObjectIdForProvider(IRawElementProviderSimple pProvider, out int pidObject);
	}

	/// <summary>Exposes the properties of an annotation in a document.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-iannotationprovider
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.IAnnotationProvider")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("f95c7e80-bd63-4601-9782-445ebff011fc")]
	public interface IAnnotationProvider
	{
		/// <summary>
		/// <para>The annotation type identifier of this annotation.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iannotationprovider-get_annotationtypeid
		// HRESULT get_AnnotationTypeId( int *retVal );
		int AnnotationTypeId { get; }

		/// <summary>
		/// <para>The name of this annotation type.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// The name of the annotation type can correspond to one of the annotation type identifiers (for example, âCommentâ for
		/// AnnotationType_Comment), but it is not required to.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iannotationprovider-get_annotationtypename
		// HRESULT get_AnnotationTypeName( BSTR *retVal );
		string AnnotationTypeName { [return: MarshalAs(UnmanagedType.BStr)] get; }

		/// <summary>
		/// <para>The name of the annotation author.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iannotationprovider-get_author HRESULT
		// get_Author( BSTR *retVal );
		string Author { [return: MarshalAs(UnmanagedType.BStr)] get; }

		/// <summary>
		/// <para>The date and time when this annotation was created.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iannotationprovider-get_datetime HRESULT
		// get_DateTime( BSTR *retVal );
		string DateTime { [return: MarshalAs(UnmanagedType.BStr)] get; }

		/// <summary>
		/// <para>The UI Automation element that is being annotated.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iannotationprovider-get_target HRESULT
		// get_Target( IRawElementProviderSimple **retVal );
		IRawElementProviderSimple Target { [return: MarshalAs(UnmanagedType.IUnknown)] get; }
	}

	/// <summary>Undocumented</summary>
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("2062a28a-8c07-4b94-8e12-7037c622aeb8")]
	public interface ICustomNavigationProvider
	{
		/// <summary>Navigates the specified direction.</summary>
		/// <param name="direction">The direction.</param>
		/// <returns></returns>
		IRawElementProviderSimple Navigate(NavigateDirection direction);
	}

	/// <summary>Provides access to an element in a docking container.</summary>
	/// <remarks>
	/// <para>
	/// <c>IDockProvider</c> does not expose any properties of the docking container or any properties of controls that might be docked
	/// adjacent to the current control in the docking container.
	/// </para>
	/// <para>
	/// Controls are docked relative to each other based on their current z-order; the higher their z-order placement, the farther they are
	/// placed from the specified edge of the docking container.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-idockprovider
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.IDockProvider")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("159bc72c-4ad3-485e-9637-d7052edf0146")]
	public interface IDockProvider
	{
		/// <summary>Sets the docking position of this element.</summary>
		/// <param name="dockPosition">
		/// <para>Type: <c>DockPosition</c></para>
		/// <para>The new docking position.</para>
		/// </param>
		/// <remarks>
		/// A docking container is a control that allows the arrangement of child elements, both horizontally and vertically, relative to the
		/// boundaries of the docking container and other elements within the container.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-idockprovider-setdockposition HRESULT
		// SetDockPosition( [in] DockPosition dockPosition );
		void SetDockPosition(DockPosition dockPosition);

		/// <summary>
		/// <para>Indicates the current docking position of this element.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// A docking container is a control that allows the arrangement of child elements, both horizontally and vertically, relative to the
		/// boundaries of the docking container and other elements in the container.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example shows how to return the DockPosition property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-idockprovider-get_dockposition HRESULT
		// get_DockPosition( DockPosition *pRetVal );
		DockPosition DockPosition { get; }
	}

	/// <summary>
	/// Enables a Microsoft UI Automation element to describe itself as an element that can be dragged as part of a drag-and-drop operation.
	/// </summary>
	/// <remarks>
	/// A provider can implement <c>IDragProvider</c> only on the element being dragged, or it can use an intermediary drag object that
	/// implements <c>IDragProvider</c>, in addition to the <c>IDragProvider</c> implementation on the individual element. The intermediary
	/// is responsible for firing all events, which enables the provider to support dragging multiple elements at once, and to describe the
	/// multi-element drag operation with a single set of drag properties and events.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-idragprovider
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.IDragProvider")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("6aa7bbbb-7ff9-497d-904f-d20b897929d8")]
	public interface IDragProvider
	{
		/// <summary>Retrieves the collection of elements that are being dragged as part of a drag operation.</summary>
		/// <returns>
		/// An array of VT_UNKNOWN pointers to the IRawElementProviderSimple interfaces of the elements that are being dragged. This
		/// parameter is <c>NULL</c> if only a single item is being dragged.
		/// </returns>
		/// <remarks>
		/// If the user is dragging multiple items, the items are represented by a single master element with an associated set of grabbed
		/// elements. The master element raises the appropriate events, to avoid having a large set of duplicate events. The client can call
		/// <c>GetGrabbedItems</c> to retrieve the full list of grabbed items. The provider should allocate a SAFEARRAY of appropriate length
		/// and add the Component Object Model (COM) pointers of the elements that are part of the drag operation.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-idragprovider-getgrabbeditems HRESULT
		// GetGrabbedItems( [out, retval, optional] SAFEARRAY **pRetVal );
		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UNKNOWN)]
		IRawElementProviderSimple[] GetGrabbedItems();

		/// <summary>
		/// <para>Indicates whether the element has been grabbed as part of a drag-and-drop operation.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// If this property changes, the provider must notify clients by calling UiaRaiseAutomationPropertyChangedEvent and specifying a
		/// property identifier of UIA_DragIsGrabbedPropertyId or UIA_DragDropEffectPropertyId.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-idragprovider-get_isgrabbed HRESULT
		// get_IsGrabbed( BOOL *pRetVal );
		bool IsGrabbed { get; }

		/// <summary>
		/// <para>Retrieves a localized string that indicates what happens when this element is dropped as part of a drag-drop operation.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// In the source-only style of UI Automation drag-and-drop, no elements implement the DropTarget pattern. To find out what effect
		/// dropping the dragged element will have, a client can query the <c>DropEffect</c> property of the dragged element. This property
		/// can be a short string such as "move", or a longer one, such as "insert into Main group". The string is always localized.
		/// </para>
		/// <para>
		/// If this property changes, the provider must notify clients by calling UiaRaiseAutomationPropertyChangedEvent and specifying a
		/// property identifier of UIA_DragIsGrabbedPropertyId or UIA_DragDropEffectPropertyId.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-idragprovider-get_dropeffect HRESULT
		// get_DropEffect( BSTR *pRetVal );
		string DropEffect { [return: MarshalAs(UnmanagedType.BStr)] get; }

		/// <summary>
		/// <para>
		/// Retrieves an array of localized strings that enumerate the full set of effects that can happen when this element is dropped as
		/// part of a drag-and-drop operation.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// Some drag operations support a set of different drop effects. For example, a drag operation initiated through a right-click might
		/// display a menu of options when the element is dropped. In the source-only style of Microsoft UI Automation drag-and-drop, no
		/// elements implement the DropTarget pattern. To find out what effect dropping the dragged element will have, a client can query the
		/// DropEffect property of the dragged element. This property can be a short string such as "move", or a longer one, such as "insert
		/// into Main group". The strings are always localized.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-idragprovider-get_dropeffects HRESULT
		// get_DropEffects( SAFEARRAY **pRetVal );
		string[] DropEffects { [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)] get; }
	}

	/// <summary>
	/// Enables a Microsoft UI Automation element to describe itself as an element that can receive a drop of a dragged element as part of a
	/// UI Automation drag-and-drop operation.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-idroptargetprovider
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.IDropTargetProvider")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("bae82bfd-358a-481c-85a0-d8b4d90a5d61")]
	public interface IDropTargetProvider
	{
		/// <summary>
		/// <para>
		/// Retrieves a localized string that describes the effect that happens when the user drops the grabbed element on this drop target.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// This property describes the default effect that happens when the user drops a grabbed element on a target, such as moving or
		/// copying the element. This property can be a short string such as "move", or a longer one such as "insert into Main group". The
		/// string is always localized.
		/// </para>
		/// <para>If this property changes, the provider must notify clients by firing a UIA_AutomationPropertyChangedEventId event.</para>
		/// <para>Examples</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-idroptargetprovider-get_droptargeteffect
		// HRESULT get_DropTargetEffect( BSTR *pRetVal );
		string DropTargetEffect { [return: MarshalAs(UnmanagedType.BStr)] get; }

		/// <summary>
		/// <para>
		/// Retrieves an array of localized strings that enumerate the full set of effects that can happen when the user drops a grabbed
		/// element on this drop target as part of a drag-and-drop operation.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// Some drag operations support a set of different drop effects. For example, a drag operation that is initiated with a right-click
		/// might display a menu of options for the action that occurs when the element is dropped. To find out the set of effects that can
		/// happen when the grabbed element is dropped, a client can query the DropEffects property of the dragged element. This property can
		/// contain short strings such as "move", or longer ones such as "insert into Main group". The strings are always localized.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-idroptargetprovider-get_droptargeteffects
		// HRESULT get_DropTargetEffects( SAFEARRAY **pRetVal );
		string[] DropTargetEffects { [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)] get; }
	}

	/// <summary>Provides access to a control that visually expands to display content, and collapses to hide content.</summary>
	/// <remarks>Implemented on a Microsoft UI Automation provider that must support the ExpandCollapse control pattern.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-iexpandcollapseprovider
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.IExpandCollapseProvider")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("d847d3a5-cab0-4a98-8c32-ecb45c59ad24")]
	public interface IExpandCollapseProvider
	{
		/// <summary>Displays all child nodes, controls, or content of the control.</summary>
		/// <remarks>This is a blocking method that returns after the control has been expanded.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iexpandcollapseprovider-expand HRESULT Expand();
		void Expand();

		/// <summary>Hides all child nodes, controls, or content of this element.</summary>
		/// <remarks>This is a blocking method that returns after the element has been collapsed.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iexpandcollapseprovider-collapse HRESULT Collapse();
		void Collapse();

		/// <summary>
		/// <para>Indicates the state, expanded or collapsed, of the control.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iexpandcollapseprovider-get_expandcollapsestate
		// HRESULT get_ExpandCollapseState( ExpandCollapseState *pRetVal );
		ExpandCollapseState ExpandCollapseState { get; }
	}

	/// <summary>Provides access to individual child controls of containers that implement IGridProvider.</summary>
	/// <remarks>
	/// <para>Implemented on a UI Automation provider that must support the GridItem <c>control pattern</c>.</para>
	/// <para>
	/// Controls that implement <c>IGridItemProvider</c> can typically be traversed (that is, a UI Automation client can move to adjacent
	/// controls) by using the keyboard.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-igriditemprovider
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.IGridItemProvider")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("d02541f1-fb81-4d64-ae32-f520f8a6dbd1")]
	public interface IGridItemProvider
	{
		/// <summary>
		/// <para>Specifies the ordinal number of the row that contains this cell or item.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-igriditemprovider-get_row HRESULT
		// get_Row( int *pRetVal );
		int Row { get; }

		/// <summary>
		/// <para>Specifies the ordinal number of the column that contains this cell or item.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-igriditemprovider-get_column HRESULT
		// get_Column( int *pRetVal );
		int Column { get; }

		/// <summary>
		/// <para>Specifies the number of rows spanned by this cell or item.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-igriditemprovider-get_rowspan HRESULT
		// get_RowSpan( int *pRetVal );
		int RowSpan { get; }

		/// <summary>
		/// <para>Specifies the number of columns spanned by this cell or item.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-igriditemprovider-get_columnspan HRESULT
		// get_ColumnSpan( int *pRetVal );
		int ColumnSpan { get; }

		/// <summary>
		/// <para>Specifies the UI Automation provider that implements IGridProvider and represents the container of this cell or item.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-igriditemprovider-get_containinggrid
		// HRESULT get_ContainingGrid( IRawElementProviderSimple **pRetVal );
		IRawElementProviderSimple ContainingGrid { [return: MarshalAs(UnmanagedType.IUnknown)] get; }
	}

	/// <summary>
	/// Provides access to controls that act as containers for a collection of child elements organized in a two-dimensional logical
	/// coordinate system that can be traversed (that is, a Microsoft UI Automation client can move to adjacent controls) by using the
	/// keyboard. The children of this element must implement IGridItemProvider.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>IGridProvider</c> interface exposes methods and properties to support UI Automation client access to controls that act as
	/// containers for a collection of child elements. The children of this element must implement IGridItemProvider and be organized in a
	/// two-dimensional logical coordinate system that can be traversed (that is, a UI Automation client can move to adjacent controls) by
	/// using the keyboard.
	/// </para>
	/// <para>Implemented on a UI Automation provider that must support the Grid control pattern.</para>
	/// <para><c>IGridProvider</c> does not enable active manipulation of a grid; ITransformProvider must be implemented for this.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-igridprovider
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.IGridProvider")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("b17d6187-0907-464b-a168-0ef17a1572b1")]
	public interface IGridProvider
	{
		/// <summary>Retrieves the Microsoft UI Automation provider for the specified cell.</summary>
		/// <param name="row">
		/// <para>Type: <c>int</c></para>
		/// <para>The ordinal number of the row of interest.</para>
		/// </param>
		/// <param name="column">
		/// <para>Type: <c>int</c></para>
		/// <para>The ordinal number of the column of interest.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IRawElementProviderSimple**</c></para>
		/// <para>
		/// Receives a pointer to a UI Automation provider for the specified cell or a null reference (Nothing in Microsoft Visual BasicÂ
		/// .NET) if the cell is empty.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>Grid coordinates are zero-based with the upper left (or upper right cell depending on locale) having coordinates (0,0).</para>
		/// <para>
		/// If a cell is empty a UI Automation provider must still be returned in order to support the ContainingGrid property for that cell.
		/// This is possible when the layout of child elements in the grid is similar to a ragged array.
		/// </para>
		/// <para>
		/// Hidden rows and columns, depending on the provider implementation, may be loaded in the UI Automation tree and will therefore be
		/// reflected in the IGridProvider::RowCount and IGridProvider::ColumnCount properties. If the hidden rows and columns have not yet
		/// been loaded they should not be counted.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-igridprovider-getitem HRESULT GetItem(
		// [in] int row, [in] int column, [out, retval] IRawElementProviderSimple **pRetVal );
		IRawElementProviderSimple GetItem(int row, int column);

		/// <summary>
		/// <para>Specifies the total number of rows in the grid.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// Hidden rows and columns, depending on the provider implementation, may be loaded in the logical tree and will therefore be
		/// reflected in the <c>IGridProvider::RowCount</c> and IGridProvider::ColumnCount properties. If the hidden rows and columns have
		/// not yet been loaded they will not be counted.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-igridprovider-get_rowcount HRESULT
		// get_RowCount( int *pRetVal );
		int RowCount { get; }

		/// <summary>
		/// <para>Specifies the total number of columns in the grid.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// Hidden rows and columns, depending on the provider implementation, may be loaded in the logical tree and will therefore be
		/// reflected in the IGridProvider::RowCount and <c>IGridProvider::ColumnCount</c> properties. If the hidden rows and columns have
		/// not yet been loaded they will not be counted.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-igridprovider-get_columncount HRESULT
		// get_ColumnCount( int *pRetVal );
		int ColumnCount { get; }
	}

	/// <summary>Provides access to controls that initiate or perform a single, unambiguous action and do not maintain state when activated.</summary>
	/// <remarks>
	/// <para>Implemented on a Microsoft UI Automation provider that must support the Invoke control pattern.</para>
	/// <para>
	/// Controls implement <c>IInvokeProvider</c> if the same behavior is not exposed through another control pattern provider. For example,
	/// if the Invoke method of a control performs the same action as the IExpandCollapseProvider::Expand or Collapse method, the control
	/// should not also implement <c>IInvokeProvider</c>.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-iinvokeprovider
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.IInvokeProvider")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("54fcb24b-e18e-47a2-b4d3-eccbe77599a2")]
	public interface IInvokeProvider
	{
		/// <summary>Sends a request to activate a control and initiate its single, unambiguous action.</summary>
		/// <remarks>
		/// <para><c>IInvokeProvider::Invoke</c> is an asynchronous call and must return immediately without blocking.</para>
		/// <para>
		/// <c>Note</c> Â Â This is particularly critical for controls that, directly or indirectly, launch a modal dialog when invoked. Any
		/// Microsoft UI Automation client that instigated the event will remain blocked until the modal dialog is closed.
		/// </para>
		/// <para>Â</para>
		/// <para><c>IInvokeProvider::Invoke</c> raises the Invoked event after the control has completed its associated action, if possible.</para>
		/// <para>The event should be raised before servicing the Invoke request in the following scenarios:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>It is not possible or practical to wait until the action is complete.</description>
		/// </item>
		/// <item>
		/// <description>The action requires user interaction.</description>
		/// </item>
		/// <item>
		/// <description>The action is time-consuming and will cause the calling client to block for a significant length of time.</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iinvokeprovider-invoke HRESULT Invoke();
		void Invoke();
	}

	/// <summary>Provides access to controls that act as containers of other controls, such as a virtual list-view.</summary>
	/// <remarks>
	/// The ItemContainer control pattern allows a container object to efficiently lookup an item by a specified automation element property,
	/// such as Name, AutomationId, or IsSelected state. While this control pattern is introduced with a view to being used by virtualized
	/// containers, it can be implemented by any container that provides name lookup, independently of whether that container uses virtualization.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-iitemcontainerprovider
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.IItemContainerProvider")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("e747770b-39ce-4382-ab30-d8fb3f336f24")]
	public interface IItemContainerProvider
	{
		/// <summary>Retrieves an element within a containing element, based on a specified property value.</summary>
		/// <param name="pStartAfter">
		/// <para>Type: <c>IRawElementProviderSimple*</c></para>
		/// <para>The UI Automation provider of the element after which the search begins, or <c>NULL</c> to search all elements.</para>
		/// </param>
		/// <param name="propertyId">
		/// <para>Type: <c>PROPERTYID</c></para>
		/// <para>The property identifier. For a list of property IDs, see Property Identifiers.</para>
		/// </param>
		/// <param name="value">
		/// <para>Type: <c>VARIANT</c></para>
		/// <para>The value of the property.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IRawElementProviderSimple**</c></para>
		/// <para>Receives a pointer to the UI Automation provider of the element.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// For virtual lists, the element returned may be a placeholder. IVirtualizedItemProvider::Realize can then be used to make the item
		/// fully available.
		/// </para>
		/// <para>
		/// The method returns E_INVALIDARG if searching by the specified property is not supported. Most containers should support
		/// UIA_NamePropertyId and, if appropriate, UIA_AutomationIdPropertyId and UIA_SelectionItemIsSelectedPropertyId.
		/// </para>
		/// <para>
		/// If <c>propertyId</c> is 0, all items are a match. This value can be used with <c>pStartAfter</c> equalling <c>NULL</c> to get the
		/// first item, and then to get successive items. In this case, <c>value</c> should be VT_EMPTY.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iitemcontainerprovider-finditembyproperty
		// HRESULT FindItemByProperty( [in] IRawElementProviderSimple *pStartAfter, [in] PROPERTYID propertyId, [in] VARIANT value, [out]
		// IRawElementProviderSimple **pFound );
		IRawElementProviderSimple FindItemByProperty(IRawElementProviderSimple pStartAfter, UIAutomationClient.PROPERTYID propertyId, object value);
	}

	/// <summary>
	/// Enables Microsoft UI Automation clients to access the underlying IAccessible implementation of Microsoft Active Accessibility elements.
	/// </summary>
	/// <remarks>
	/// This interface is implemented by the Microsoft Active Accessibility to UI Automation Proxy to expose native MSAA properties and
	/// methods to UI Automation clients that need them for legacy reasons. The proxy automatically supplies this interface for applications
	/// or controls that implement Microsoft Active Accessibility natively. This interface is not intended to be implemented by UI Automation
	/// applications or controls.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-ilegacyiaccessibleprovider
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.ILegacyIAccessibleProvider")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("e44c3566-915d-4070-99c6-047bff5a08f5")]
	public interface ILegacyIAccessibleProvider
	{
		/// <summary>Selects the element.</summary>
		/// <param name="flagsSelect">
		/// <para>Type: <c>long</c></para>
		/// <para>
		/// Specifies which selection or focus operations are to be performed. This parameter must have a combination of the values described
		/// in SELFLAG Constants.
		/// </para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-ilegacyiaccessibleprovider-select HRESULT
		// Select( [in] long flagsSelect );
		void Select(SELFLAG flagsSelect);

		/// <summary>Performs the default action on the control.</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-ilegacyiaccessibleprovider-dodefaultaction
		// HRESULT DoDefaultAction();
		void DoDefaultAction();

		/// <summary>Sets the string value of the control.</summary>
		/// <param name="szValue">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A localized string that contains the value.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-ilegacyiaccessibleprovider-setvalue
		// HRESULT SetValue( [in] LPCWSTR szValue );
		void SetValue(string szValue);

		/// <summary>
		/// Retrieves an accessible object that corresponds to a UI Automation element that supports the LegacyIAccessible control pattern.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>IAccessible**</c></para>
		/// <para>Receives a pointer to the accessible object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-ilegacyiaccessibleprovider-getiaccessible
		// HRESULT GetIAccessible( [out] IAccessible **ppAccessible );
		IAccessible GetIAccessible();

		/// <summary>Retrieves the selected item or items in the control.</summary>
		/// <returns>
		/// <para>Type: <c>SAFEARRAY**</c></para>
		/// <para>Receives a pointer to a SAFEARRAY containing the selected items.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-ilegacyiaccessibleprovider-getselection
		// HRESULT GetSelection( [out] SAFEARRAY **pvarSelectedChildren );
		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UNKNOWN)]
		IRawElementProviderSimple[] GetSelection();

		/// <summary>
		/// <para>Specifies the child identifier of this element.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-ilegacyiaccessibleprovider-get_childid
		// HRESULT get_ChildId( int *pRetVal );
		int ChildId { get; }

		/// <summary>
		/// <para>Specifies the name of this element.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-ilegacyiaccessibleprovider-get_name
		// HRESULT get_Name( BSTR *pszName );
		string Name { [return: MarshalAs(UnmanagedType.BStr)] get; }

		/// <summary>
		/// <para>Specifies the value of this element.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-ilegacyiaccessibleprovider-get_value
		// HRESULT get_Value( BSTR *pszValue );
		string Value { [return: MarshalAs(UnmanagedType.BStr)] get; }

		/// <summary>
		/// <para>Contains the description of this element.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-ilegacyiaccessibleprovider-get_description
		// HRESULT get_Description( BSTR *pszDescription );
		string Description { [return: MarshalAs(UnmanagedType.BStr)] get; }

		/// <summary>
		/// <para>Specifies the role identifier of this element.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-ilegacyiaccessibleprovider-get_role
		// HRESULT get_Role( DWORD *pdwRole );
		uint Role { get; }

		/// <summary>
		/// <para>Specifies the state of this element.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-ilegacyiaccessibleprovider-get_state
		// HRESULT get_State( DWORD *pdwState );
		uint State { get; }

		/// <summary>
		/// <para>Specifies a string that contains help information for this element.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-ilegacyiaccessibleprovider-get_help
		// HRESULT get_Help( BSTR *pszHelp );
		string Help { [return: MarshalAs(UnmanagedType.BStr)] get; }

		/// <summary>
		/// <para>Specifies the keyboard shortcut for this element.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-ilegacyiaccessibleprovider-get_keyboardshortcut
		// HRESULT get_KeyboardShortcut( BSTR *pszKeyboardShortcut );
		string KeyboardShortcut { [return: MarshalAs(UnmanagedType.BStr)] get; }

		/// <summary>
		/// <para>Contains a description of the default action for this element.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-ilegacyiaccessibleprovider-get_defaultaction
		// HRESULT get_DefaultAction( BSTR *pszDefaultAction );
		string DefaultAction { [return: MarshalAs(UnmanagedType.BStr)] get; }
	}

	/// <summary>
	/// Provides access to controls that provide, and are able to switch between, multiple representations of the same set of information or
	/// child controls.
	/// </summary>
	/// <remarks>Implemented on a Microsoft UI Automation provider that must support the MultipleView control pattern.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-imultipleviewprovider
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.IMultipleViewProvider")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("6278cab1-b556-4a1a-b4e0-418acc523201")]
	public interface IMultipleViewProvider
	{
		/// <summary>Retrieves the name of a control-specific view.</summary>
		/// <param name="viewId">
		/// <para>Type: <c>int</c></para>
		/// <para>A view identifier.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BSTR*</c></para>
		/// <para>Receives a localized name for the view. This parameter is passed uninitialized.</para>
		/// </returns>
		/// <remarks>
		/// <para>View identifiers can be retrieved by using IMultipleViewProvider::GetSupportedViews.</para>
		/// <para>The collection of view identifiers must be identical for all instances of a control.</para>
		/// <para>View names must be suitable for use in text-to-speech, Braille, and other accessible applications.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-imultipleviewprovider-getviewname HRESULT
		// GetViewName( [in] int viewId, [out, retval] BSTR *pRetVal );
		[return: MarshalAs(UnmanagedType.BStr)]
		string GetViewName(int viewId);

		/// <summary>Sets the current control-specific view.</summary>
		/// <param name="viewId">
		/// <para>Type: <c>int</c></para>
		/// <para>A view identifier.</para>
		/// </param>
		/// <remarks>
		/// <para>View identifiers can be retrieved by using IMultipleViewProvider::GetSupportedViews.</para>
		/// <para>The collection of view identifiers must be identical for all instances of a control.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-imultipleviewprovider-setcurrentview
		// HRESULT SetCurrentView( [in] int viewId );
		void SetCurrentView(int viewId);

		/// <summary>Retrieves a collection of control-specific view identifiers.</summary>
		/// <returns>
		/// <para>Type: <c>SAFEARRAY**</c></para>
		/// <para>
		/// Receives a collection of control-specific integer values that identify the views available for a UI Automation element. This
		/// parameter is passed uninitialized.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>An empty array is returned by UIAutoCore.dll if the provider does not supply any view identifiers.</para>
		/// <para>The collection of view identifiers must be identical for all instances of a control.</para>
		/// <para>View identifier values can be passed to IMultipleViewProvider::GetViewName.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-imultipleviewprovider-getsupportedviews
		// HRESULT GetSupportedViews( [out, retval] SAFEARRAY **pRetVal );
		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)]
		int[] GetSupportedViews();

		/// <summary>
		/// <para>Identifies the current view that the control is using to display information or child controls.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>The collection of view identifiers must be identical for all instances of a control.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-imultipleviewprovider-get_currentview
		// HRESULT get_CurrentView( int *pRetVal );
		int CurrentView { get; }
	}

	/// <summary>
	/// Provides access to the underlying object model implemented by a control or application. Assistive technology applications can use the
	/// object model to directly access the content of the control or application.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-iobjectmodelprovider
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.IObjectModelProvider")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("3ad86ebd-f5ef-483d-bb18-b1042a475d64")]
	public interface IObjectModelProvider
	{
		/// <summary>Retrieves an interface used to access the underlying object model of the provider.</summary>
		/// <returns>
		/// <para>Type: <c>IUnknown**</c></para>
		/// <para>Receives an interface for accessing the underlying object model.</para>
		/// </returns>
		/// <remarks>Client applications can use the object model to directly access the content of the control or application.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iobjectmodelprovider-getunderlyingobjectmodel
		// HRESULT GetUnderlyingObjectModel( [out, retval] IUnknown **ppUnknown );
		[return: MarshalAs(UnmanagedType.IUnknown)]
		object GetUnderlyingObjectModel();
	}

	/// <summary>
	/// Exposes a method that is implemented by proxy providers to handle WinEvents. To implement Microsoft UI Automation event handling, a
	/// proxy provider may need to handle WinEvents that are raised by the proxied UI. UI Automation will use the
	/// <c>IProxyProviderWinEventHandler</c> interface to notify the provider that a WinEvent has been raised for the provider window.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-iproxyproviderwineventhandler
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.IProxyProviderWinEventHandler")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("89592ad4-f4e0-43d5-a3b6-bad7e111b435")]
	public interface IProxyProviderWinEventHandler
	{
		/// <summary>Handles a WinEvent.</summary>
		/// <param name="idWinEvent">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The identifier of the incoming WinEvent. For a list of WinEvent IDs, see <c>User32.EventConstants</c>.</para>
		/// </param>
		/// <param name="hwnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>The handle of the window for which the WinEvent was fired. This should also be the window for which the proxy was created.</para>
		/// </param>
		/// <param name="idObject">
		/// <para>Type: <c>LONG</c></para>
		/// <para>
		/// The object identifier (OBJID_*) of the accessible object associated with the event. For a list of object identifiers, see Object Identifiers.
		/// </para>
		/// </param>
		/// <param name="idChild">
		/// <para>Type: <c>LONG</c></para>
		/// <para>The child identifier of the element associated with the event, or <c>CHILDID_SELF</c> if the element is not a child.</para>
		/// </param>
		/// <param name="pSink">
		/// <para>Type: <c>IProxyProviderWinEventSink*</c></para>
		/// <para>
		/// A pointer to the IProxyProviderWinEventSink interface provided by the UI Automation core. Any event that the proxy needs to raise
		/// in response to the WinEvent being handled should be added to the sink.
		/// </para>
		/// </param>
		/// <remarks>
		/// The provider should review the event data. If the provider needs to raise a UI Automation event in response, the data for that
		/// event should be added to the <c>pSink</c> event sink.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iproxyproviderwineventhandler-respondtowinevent
		// HRESULT RespondToWinEvent( [in] DWORD idWinEvent, [in] HWND hwnd, [in] LONG idObject, [in] LONG idChild, [in]
		// IProxyProviderWinEventSink *pSink );
		void RespondToWinEvent(uint idWinEvent, HWND hwnd, int idObject, int idChild, IProxyProviderWinEventSink pSink);
	}

	/// <summary>Exposes methods used by proxy providers to raise events.</summary>
	/// <remarks>
	/// The <c>IProxyProviderWinEventSink</c> interface is provided by UIAutomationCore.dll when the framework calls the
	/// IProxyProviderWinEventHandler::RespondToWinEvent method. The framework stores the events added to the
	/// <c>IProxyProviderWinEventSink</c> object. When <c>IProxyProviderWinEventHandler::RespondToWinEvent</c> returns, the framework passes
	/// the events back to the client side, where the UI Automation events are actually fired.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-iproxyproviderwineventsink
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.IProxyProviderWinEventSink")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("4fd82b78-a43e-46ac-9803-0a6969c7c183")]
	public interface IProxyProviderWinEventSink
	{
		/// <summary>Raises a property-changed event.</summary>
		/// <param name="pProvider">
		/// <para>Type: <c>IRawElementProviderSimple*</c></para>
		/// <para>A pointer to the provider for the element that will raise the event.</para>
		/// </param>
		/// <param name="id">
		/// <para>Type: <c>PROPERTYID</c></para>
		/// <para>The identifier of the property that is to be changed. For a list of property IDs, see Property Identifiers.</para>
		/// </param>
		/// <param name="newValue">
		/// <para>Type: <c>VARIANT</c></para>
		/// <para>The new value for the changed property.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iproxyproviderwineventsink-addautomationpropertychangedevent
		// HRESULT AddAutomationPropertyChangedEvent( [in] IRawElementProviderSimple *pProvider, [in] PROPERTYID id, [in] VARIANT newValue );
		void AddAutomationPropertyChangedEvent(IRawElementProviderSimple pProvider, int id, [In] object newValue);

		/// <summary>Raises a Microsoft UI Automation event.</summary>
		/// <param name="pProvider">
		/// <para>Type: <c>IRawElementProviderSimple*</c></para>
		/// <para>A pointer to the provider for the element that will raise the event.</para>
		/// </param>
		/// <param name="id">
		/// <para>Type: <c>EVENTID</c></para>
		/// <para>The identifier of the event that will be raised. For a list of event identifiers, see Event Identifiers</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iproxyproviderwineventsink-addautomationevent
		// HRESULT AddAutomationEvent( [in] IRawElementProviderSimple *pProvider, [in] EVENTID id );
		void AddAutomationEvent(IRawElementProviderSimple pProvider, int id);

		/// <summary>Raises an event to notify clients that the structure of the UI Automation tree has changed.</summary>
		/// <param name="pProvider">
		/// <para>Type: <c>IRawElementProviderSimple*</c></para>
		/// <para>A pointer to the provider of the element that is raising the event.</para>
		/// </param>
		/// <param name="structureChangeType"/>
		/// <param name="runtimeId">
		/// <para>Type: <c>SAFEARRAY*</c></para>
		/// <para>
		/// A pointer to the runtime identifiers of the elements that are affected. These IDs enable applications to identify elements that
		/// have been removed and are no longer represented by IUIAutomationElement interfaces.
		/// </para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iproxyproviderwineventsink-addstructurechangedevent
		// HRESULT AddStructureChangedEvent( [in] IRawElementProviderSimple *pProvider, StructureChangeType structureChangeType, [in]
		// SAFEARRAY *runtimeId );
		void AddStructureChangedEvent(IRawElementProviderSimple pProvider, StructureChangeType structureChangeType, [In, MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)] int[] runtimeId);
	}

	/// <summary>Provides access to controls that can be set to a value within a range.</summary>
	/// <remarks>Implemented on a Microsoft UI Automation provider that must support the RangeValue control pattern.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-irangevalueprovider
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.IRangeValueProvider")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("36dc7aef-33e6-4691-afe1-2be7274b3d33")]
	public interface IRangeValueProvider
	{
		/// <summary>Sets the value of the control.</summary>
		/// <param name="val">
		/// <para>Type: <c>double</c></para>
		/// <para>The value to set.</para>
		/// </param>
		/// <remarks>The actual value set depends on the control implementation. The control may round the requested value up or down.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-irangevalueprovider-setvalue HRESULT
		// SetValue( [in] double val );
		void SetValue(double val);

		/// <summary>
		/// <para>Specifies the value of the control.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-irangevalueprovider-get_value HRESULT
		// get_Value( double *pRetVal );
		double Value { get; }

		/// <summary>
		/// <para>Indicates whether the value of a control is read-only.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-irangevalueprovider-get_isreadonly
		// HRESULT get_IsReadOnly( BOOL *pRetVal );
		bool IsReadOnly { get; }

		/// <summary>
		/// <para>Specifies the maximum range value supported by the control.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>This value should be greater than Minimum.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-irangevalueprovider-get_maximum HRESULT
		// get_Maximum( double *pRetVal );
		double Maximum { get; }

		/// <summary>
		/// <para>Specifies the minimum range value supported by the control.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>This value should be less than Maximum.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-irangevalueprovider-get_minimum HRESULT
		// get_Minimum( double *pRetVal );
		double Minimum { get; }

		/// <summary>
		/// <para>
		/// Specifies the value that is added to or subtracted from the IRangeValueProvider::Value property when a large change is made, such
		/// as when the PAGE DOWN key is pressed.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// The LargeChange property can support Not a Number (NaN) value. When returning a NaN value, the provider should return a quiet
		/// (non-signaling) NaN to avoid raising an exception if floating-point exceptions are turned on. The following example shows how to
		/// create a quiet NaN:
		/// </para>
		/// <para>Alternatively, you can use the following function from the standard C++ libraries:</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-irangevalueprovider-get_largechange
		// HRESULT get_LargeChange( double *pRetVal );
		double LargeChange { get; }

		/// <summary>
		/// <para>
		/// Specifies the value that is added to or subtracted from the IRangeValueProvider::Value property when a small change is made, such
		/// as when an arrow key is pressed.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// The SmallChange property can support Not a Number (NaN) value. When returning a NaN value, the provider should return a quiet
		/// (non-signaling) NaN to avoid raising an exception if floating-point exceptions are turned on. The following example shows how to
		/// create a quiet NaN:
		/// </para>
		/// <para>Alternatively, you can use the following function from the standard C++ libraries:</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-irangevalueprovider-get_smallchange
		// HRESULT get_SmallChange( double *pRetVal );
		double SmallChange { get; }
	}

	/// <summary>
	/// Exposes methods that are called to notify the root element of a fragment when a Microsoft UI Automation client application begins or
	/// ends listening for events on that fragment.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Implementation of this interface is optional. It can be used to improve performance by raising events only when they are being
	/// listened for.
	/// </para>
	/// <para>
	/// Similar to implementing reference counting in Component Object Model (COM) programming, it is important for UI Automation providers
	/// to treat the AdviseEventAdded and AdviseEventRemoved methods like the AddRef and Release methods of the IUnknown interface. As long
	/// as <c>AdviseEventAdded</c> has been called more times than <c>AdviseEventRemoved</c> for a specific event or property, the provider
	/// should continue to raise corresponding events, because some clients are still listening. Alternatively, UI Automation providers can
	/// use the UiaClientsAreListening function to determine if at least one client is listening and, if so, raise all appropriate events.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-irawelementprovideradviseevents
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.IRawElementProviderAdviseEvents")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("a407b27b-0f6d-4427-9292-473c7bf93258")]
	public interface IRawElementProviderAdviseEvents
	{
		/// <summary>
		/// Notifies the Microsoft UI Automation provider when a UI Automation client begins listening for a specific event, including a
		/// property-changed event.
		/// </summary>
		/// <param name="eventId">
		/// <para>Type: <c>EVENTID</c></para>
		/// <para>The identifier of the event being added. For a list of event IDs, see Event Identifiers.</para>
		/// </param>
		/// <param name="propertyIDs">
		/// <para>Type: <c>SAFEARRAY*</c></para>
		/// <para>
		/// A pointer to the identifiers of properties being added, or <c>NULL</c> if the event listener being added is not listening for
		/// property events.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>This method enables the provider to reduce overhead by raising only events that are being listened for.</para>
		/// <para>
		/// It is important for UI Automation providers to treat the <c>IRawElementProviderAdviseEvents::AdviseEventAdded</c> like the AddRef
		/// method of the IUnknown interface. As long as <c>AdviseEventAdded</c> has been called more times than AdviseEventRemoved for a
		/// specific event or property, the provider should continue to raise corresponding events, because some clients are still listening.
		/// Alternatively, UI Automation providers can use the UiaClientsAreListening function to determine if at least one client is
		/// listening and, if so, raise all appropriate events.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-irawelementprovideradviseevents-adviseeventadded
		// HRESULT AdviseEventAdded( [in] EVENTID eventId, [in] SAFEARRAY *propertyIDs );
		void AdviseEventAdded(int eventId, [In, MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)] int[] propertyIDs);

		/// <summary>
		/// Notifies the Microsoft UI Automation provider when a UI Automation client stops listening for a specific event, including a
		/// property-changed event.
		/// </summary>
		/// <param name="eventId">
		/// <para>Type: <c>EVENTID</c></para>
		/// <para>The identifier of the event being removed. For a list of event IDs, see Event Identifiers.</para>
		/// </param>
		/// <param name="propertyIDs">
		/// <para>Type: <c>SAFEARRAY*</c></para>
		/// <para>
		/// A pointer to the identifiers of the properties being removed, or <c>NULL</c> if the event listener being removed is not listening
		/// for property events.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>This method enables the provider to reduce overhead by raising only events that are being listened for.</para>
		/// <para>
		/// It is important for UI Automation providers to treat the <c>IRawElementProviderAdviseEvents::AdviseEventRemoved</c> like the
		/// Release method of the IUnknown interface. As long as AdviseEventAdded has been called more times than <c>AdviseEventRemoved</c>
		/// for a specific event or property, the provider should continue to raise corresponding events, because some clients are still
		/// listening. Alternatively, UI Automation providers can use the UiaClientsAreListening function to determine if at least one client
		/// is listening and, if so, raise all appropriate events.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-irawelementprovideradviseevents-adviseeventremoved
		// HRESULT AdviseEventRemoved( [in] EVENTID eventId, [in] SAFEARRAY *propertyIDs );
		void AdviseEventRemoved(int eventId, [In, MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)] int[] propertyIDs);
	}

	/// <summary>
	/// Exposes methods and properties on UI elements that are part of a structure more than one level deep, such as a list box or list item.
	/// Implemented by Microsoft UI Automation provider.
	/// </summary>
	/// <remarks>The root node of the fragment must also support the IRawElementProviderFragmentRoot interface.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-irawelementproviderfragment
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.IRawElementProviderFragment")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("f7063da8-8359-439c-9297-bbc5299a7d87")]
	public interface IRawElementProviderFragment
	{
		/// <summary>Retrieves the Microsoft UI Automation element in a specified direction within the UI Automation tree.</summary>
		/// <param name="direction"/>
		/// <returns>
		/// <para>Type: <c>IRawElementProviderFragment**</c></para>
		/// <para>
		/// Receives a pointer to the provider of the UI Automation element in the specified direction, or <c>NULL</c> if there is no element
		/// in that direction. This parameter is passed uninitialized.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>The UI Automation server's implementations of this method define the structure of the UI Automation tree.</para>
		/// <para>
		/// Navigation must be supported upward to the parent, downward to the first and last child, and laterally to the next and previous
		/// siblings, as applicable.
		/// </para>
		/// <para>
		/// Each child node has only one parent and must be placed in the chain of siblings reached from the parent by
		/// <c>NavigateDirection_FirstChild</c> and <c>NavigateDirection_LastChild</c>.
		/// </para>
		/// <para>
		/// Relationships among siblings must be identical in both directions: if A is B's previous sibling (
		/// <c>NavigateDirection_PreviousSibling</c>), then B is A's next sibling ( <c>NavigateDirection_NextSibling</c>). A first child (
		/// <c>NavigateDirection_FirstChild</c>) has no previous sibling, and a last child ( <c>NavigateDirection_LastChild</c>) has no next sibling.
		/// </para>
		/// <para>
		/// Fragment roots do not enable navigation to a parent or siblings; navigation among fragment roots is handled by the default window
		/// providers. Elements in fragments must navigate only to other elements within that fragment.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example shows an implementation for a list item provider. The member variables for the parent, previous sibling,
		/// and next sibling providers were initialized when the list was created.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-irawelementproviderfragment-navigate
		// HRESULT Navigate( NavigateDirection direction, [out, retval] IRawElementProviderFragment **pRetVal );
		[return: MarshalAs(UnmanagedType.Interface)]
		IRawElementProviderFragment Navigate(NavigateDirection direction);

		/// <summary>Retrieves the runtime identifier of an element.</summary>
		/// <returns>
		/// <para>Type: <c>SAFEARRAY**</c></para>
		/// <para>Receives a pointer to the runtime identifier. This parameter is passed uninitialized.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Implementations should return <c>NULL</c> for a top-level element that is hosted in a window. Other elements should return an
		/// array that contains <c>UiaAppendRuntimeId</c> (defined in Uiautomationcoreapi.h), followed by a value that is unique within an
		/// instance of the fragment.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following implementation for a list item returns a runtime identifier made up of the <c>UiaAppendRuntimeId</c> constant and
		/// the index of the item within the list.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-irawelementproviderfragment-getruntimeid
		// HRESULT GetRuntimeId( [out, retval] SAFEARRAY **pRetVal );
		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)]
		int[] GetRuntimeId();

		/// <summary>
		/// <para>Specifies the bounding rectangle of this element.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <para>The bounding rectangle is defined by the location of the top left corner on the screen, and the dimensions.</para>
		/// <para>
		/// No clipping is required if the element is partly obscured or partly off-screen. The IsOffscreen property should be set to
		/// indicate whether the rectangle is actually visible.
		/// </para>
		/// <para>Not all points within the bounding rectangle are necessarily clickable.</para>
		/// <para>Examples</para>
		/// <para>
		/// The following example implementation by a list item provider calculates the bounding rectangle for the item based on its height
		/// and position within the containing list box.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-irawelementproviderfragment-get_boundingrectangle
		// HRESULT get_BoundingRectangle( UiaRect *pRetVal );
		UiaRect get_BoundingRectangle();

		/// <summary>
		/// Retrieves an array of root fragments that are embedded in the Microsoft UI Automation tree rooted at the current element.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>SAFEARRAY**</c></para>
		/// <para>Receives an array of pointers to the root fragments, or <c>NULL</c> (see Remarks). This parameter is passed uninitialized.</para>
		/// </returns>
		/// <remarks>
		/// This method returns an array of fragments only if the current element is hosting another automation framework. Most providers
		/// return <c>NULL</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-irawelementproviderfragment-getembeddedfragmentroots
		// HRESULT GetEmbeddedFragmentRoots( [out, retval] SAFEARRAY **pRetVal );
		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UNKNOWN)]
		IRawElementProviderFragmentRoot[] GetEmbeddedFragmentRoots();

		/// <summary>Sets the focus to this element.</summary>
		/// <remarks>
		/// The Microsoft UI Automation framework will ensure that the part of the interface that hosts this fragment is already focused
		/// before calling this method. Your implementation should update only its internal focus state; for example, by repainting a list
		/// item to show that it has the focus. If you prefer that UI Automation not focus the parent window, set
		/// ProviderOptions_ProviderOwnsSetFocus in IRawElementProviderSimple::ProviderOptions for the fragment root.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-irawelementproviderfragment-setfocus
		// HRESULT SetFocus();
		void SetFocus();

		/// <summary>
		/// <para>Specifies the root node of the fragment.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>A provider for a fragment root should return a pointer to its own implementation of IRawElementProviderFragmentRoot.</para>
		/// <para>Examples</para>
		/// <para>The following example implementation for a list item provider returns the provider for the parent list box.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-irawelementproviderfragment-get_fragmentroot
		// HRESULT get_FragmentRoot( IRawElementProviderFragmentRoot **pRetVal );
		IRawElementProviderFragmentRoot FragmentRoot { get; }
	}

	/// <summary>Exposes methods and properties on the root element in a fragment.</summary>
	/// <remarks>
	/// This interface is implemented by a root element within a framework; for example, a list box within a window. Other elements in the
	/// same fragment, such as list items, implement the IRawElementProviderFragment interface.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-irawelementproviderfragmentroot
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.IRawElementProviderFragmentRoot")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("620ce2a5-ab8f-40a9-86cb-de3c75599b58")]
	public interface IRawElementProviderFragmentRoot
	{
		/// <summary>Retrieves the provider of the element that is at the specified point in this fragment.</summary>
		/// <param name="x">
		/// <para>Type: <c>double</c></para>
		/// <para>The horizontal screen coordinate.</para>
		/// </param>
		/// <param name="y">
		/// <para>Type: <c>double</c></para>
		/// <para>The vertical screen coordinate.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IRawElementProviderFragment**</c></para>
		/// <para>Receives a pointer to the provider of the element at (x, y), or <c>NULL</c> if none exists. This parameter is passed uninitialized.</para>
		/// </returns>
		/// <remarks>
		/// <para>The returned provider should correspond to the element that would receive mouse input at the specified point.</para>
		/// <para>
		/// If the point is on this element but not on any child element, either <c>NULL</c> or the provider of the fragment root is
		/// returned. If the point is on an element in another framework that is hosted by this fragment, the method returns the element that
		/// hosts that fragment (as indicated by IRawElementProviderFragment::GetEmbeddedFragmentRoots).
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example shows an implementation for a list box hosted in an <c>HWND</c> whose handle is <c>m_controlHwnd</c>.
		/// IndexFromY retrieves the index of the list item at the cursor position, and GetItemByIndex retrieves the UI Automation provider
		/// for that item.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-irawelementproviderfragmentroot-elementproviderfrompoint
		// HRESULT ElementProviderFromPoint( [in] double x, [in] double y, [out, retval] IRawElementProviderFragment **pRetVal );
		IRawElementProviderFragment ElementProviderFromPoint(double x, double y);

		/// <summary>Retrieves the element in this fragment that has the input focus.</summary>
		/// <returns>
		/// <para>Type: <c>IRawElementProviderFragment**</c></para>
		/// <para>
		/// Receives a pointer to the IRawElementProviderFragment interface of the element in this fragment that has the input focus, if any;
		/// otherwise <c>NULL</c>. This parameter is passed uninitialized.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-irawelementproviderfragmentroot-getfocus
		// HRESULT GetFocus( [out, retval] IRawElementProviderFragment **pRetVal );
		IRawElementProviderFragment GetFocus();
	}

	/// <summary>
	/// This interface is implemented by a Microsoft UI Automation provider when the provider is the root of an accessibility tree that
	/// includes windowless controls that support Microsoft Active Accessibility. Because UI Automation and Microsoft Active Accessibility
	/// use different interfaces, this interface enables a client to discover the list of hosted Microsoft Active Accessibility controls in
	/// case it needs to treat them differently.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-irawelementproviderhostingaccessibles
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.IRawElementProviderHostingAccessibles")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("24be0b07-d37d-487a-98cf-a13ed465e9b3")]
	public interface IRawElementProviderHostingAccessibles
	{
		/// <summary>
		/// Retrieves the IAccessible interface pointers of the windowless Microsoft ActiveX controls that are hosted by this provider.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>SAFEARRAY**</c></para>
		/// <para>Receives the IAccessible pointers of the hosted windowless ActiveX controls.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An ActiveX control container with an existing IRawElementProviderFragmentRoot interface implements this method on the same object
		/// that implements <c>IRawElementProviderFragmentRoot</c>. When called, this method should query each contained windowless control
		/// for an IAccessible pointer and then add the pointer to the safe array.
		/// </para>
		/// <para>This method should ignore providers that do not implement IAccessible.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-irawelementproviderhostingaccessibles-getembeddedaccessibles
		// HRESULT GetEmbeddedAccessibles( [out, retval] SAFEARRAY **pRetVal );
		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UNKNOWN)]
		IAccessible[] GetEmbeddedAccessibles();
	}

	/// <summary>Exposes a method that enables repositioning of window-based elements within the fragment's UI Automation tree.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-irawelementproviderhwndoverride
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.IRawElementProviderHwndOverride")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("1d5df27c-8947-4425-b8d9-79787bb460b8")]
	public interface IRawElementProviderHwndOverride
	{
		/// <summary>Gets a UI Automation provider for the specified element.</summary>
		/// <param name="hwnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>The window handle of the element.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IRawElementProviderSimple**</c></para>
		/// <para>
		/// Receives a pointer to the new provider for the specified window, or <c>NULL</c> if the provider is not being overridden. This
		/// parameter is passed uninitialized.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method is implemented by fragment roots that contain window-based child elements. By default, controls hosted in windows are
		/// served by default providers in addition to any custom providers. The default providers treat all windows within a parent window
		/// as siblings. If you want to restructure the UI Automation tree so that one window-based control is seen as a child of another,
		/// you must override the default provider by implementing this method on the fragment root. The returned provider can supply
		/// additional properties or override properties of the specified component.
		/// </para>
		/// <para>
		/// The returned provider must be part of the fragment tree. It can supply additional properties or override properties of the
		/// specified component.
		/// </para>
		/// <para>
		/// If the returned provider implements IRawElementProviderFragment, the provider should be part of the fragment's tree and be
		/// reachable by navigating from the fragment's root.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-irawelementproviderhwndoverride-getoverrideproviderforhwnd
		// HRESULT GetOverrideProviderForHwnd( [in] HWND hwnd, [out, retval] IRawElementProviderSimple **pRetVal );
		IRawElementProviderSimple GetOverrideProviderForHwnd(HWND hwnd);
	}

	/// <summary>Defines methods and properties that expose simple UI elements.</summary>
	/// <remarks>
	/// <para>This interface can be implemented on:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>UI Automation provider for simple UI elements, such as buttons.</description>
	/// </item>
	/// <item>
	/// <description>Providers that add or override properties or control patterns on a UI element that already has a provider.</description>
	/// </item>
	/// </list>
	/// <para>Providers for complex elements must also implement IRawElementProviderFragment and, if they are root elements, IRawElementProviderFragmentRoot.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-irawelementprovidersimple
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.IRawElementProviderSimple")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("d6dd68d1-86fd-4332-8666-9abedea2d24c")]
	public interface IRawElementProviderSimple
	{
		/// <summary>Retrieves a pointer to an object that provides support for a control pattern on a Microsoft UI Automation element.</summary>
		/// <param name="patternId">
		/// <para>Type: <c>PATTERNID</c></para>
		/// <para>The identifier of the control pattern. For a list of control pattern IDs, see Control Pattern Identifiers.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IUnknown**</c></para>
		/// <para>
		/// Receives a pointer to the object that supports the control pattern, or <c>NULL</c> if the control pattern is not supported. This
		/// parameter is passed uninitialized.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-irawelementprovidersimple-getpatternprovider
		// HRESULT GetPatternProvider( [in] PATTERNID patternId, [out, retval] IUnknown **pRetVal );
		[return: MarshalAs(UnmanagedType.IUnknown)]
		object? GetPatternProvider(UIAutomationClient.PATTERNID patternId);

		/// <summary>Retrieves the value of a property supported by the Microsoft UI Automation provider.</summary>
		/// <param name="propertyId">
		/// <para>Type: <c>PROPERTYID</c></para>
		/// <para>The property identifier. For a list of property IDs, see Property Identifiers.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>VARIANT*</c></para>
		/// <para>
		/// Receives the property value, or <c>VT_EMPTY</c> if the property is not supported by this provider. This parameter is passed
		/// uninitialized. See Remarks.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If a provider is explicitly hiding the property value (that is, the provider does not supply the property, and the request is not
		/// to be passed through to other providers), it should return a pointer obtained by using the UiaGetReservedNotSupportedValue
		/// function. For example:
		/// </para>
		/// <para>
		/// UI Automation properties of the <c>double</c> type support Not a Number (NaN) values. When returning a NaN value, the provider
		/// should return a quiet (non-signaling) NaN to avoid raising an exception if floating-point exceptions are turned on. The following
		/// example shows how to create a quiet NaN:
		/// </para>
		/// <para>Alternatively, you can use the following function from the standard C++ libraries:</para>
		/// <para>Examples</para>
		/// <para>
		/// The following example returns various property values. The <c>UiaIds</c> structure contains property identifiers; to see how it
		/// is initialized, see UiaLookupId.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-irawelementprovidersimple-getpropertyvalue
		// HRESULT GetPropertyValue( [in] PROPERTYID propertyId, [out, retval] VARIANT *pRetVal );
		object GetPropertyValue(UIAutomationClient.PROPERTYID propertyId);

		/// <summary>
		/// <para>
		/// Specifies the type of Microsoft UI Automation provider; for example, whether it is a client-side (proxy) or server-side provider.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>The method must return either ProviderOptions_ServerSideProvider or ProviderOptions_ClientSideProvider.</para>
		/// <para>
		/// UI Automation handles the various types of providers differently. For example, events from a server-side provider are broadcast
		/// to all listening clients, but events from client-side (proxy) providers remain in the client.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example implements this method for a server-side UI Automation provider.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-irawelementprovidersimple-get_provideroptions
		// HRESULT get_ProviderOptions( ProviderOptions *pRetVal );
		ProviderOptions ProviderOptions { get; }

		/// <summary>
		/// <para>Specifies the host provider for this element.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// This property is generally the Microsoft UI Automation provider for the window of a custom control. UI Automation uses this
		/// provider in combination with the custom provider. For example, the runtime identifier of the element is usually obtained from the
		/// host provider.
		/// </para>
		/// <para>
		/// A host provider must be returned in the following cases: when the element is a fragment root, when the element is a simple
		/// element (such as a push button), and when the provider is a repositioning placeholder (for more information, see Provider
		/// Repositioning). In other cases, the property should be <c>NULL</c>.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example returns the host provider for the window that hosts the control served by this provider.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-irawelementprovidersimple-get_hostrawelementprovider
		// HRESULT get_HostRawElementProvider( IRawElementProviderSimple **pRetVal );
		IRawElementProviderSimple HostRawElementProvider { get; }
	}

	/// <summary>Extends the IRawElementProviderSimple interface to enable programmatically invoking context menus.</summary>
	/// <remarks>
	/// <para>This interface can be implemented on:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Providers that add or override properties or control patterns on a UI element that already has a provider.</description>
	/// </item>
	/// </list>
	/// <para>
	/// If no context menu is available directly on the element on which ShowContextMenu was invoked, the provider should attempt to invoke a
	/// context menu on the UI Automation parent of the current item.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-irawelementprovidersimple2
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.IRawElementProviderSimple2")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("a0a839a9-8da1-4a82-806a-8e0d44e79f56")]
	public interface IRawElementProviderSimple2 : IRawElementProviderSimple
	{
		/// <summary>Retrieves a pointer to an object that provides support for a control pattern on a Microsoft UI Automation element.</summary>
		/// <param name="patternId">
		/// <para>Type: <c>PATTERNID</c></para>
		/// <para>The identifier of the control pattern. For a list of control pattern IDs, see Control Pattern Identifiers.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IUnknown**</c></para>
		/// <para>
		/// Receives a pointer to the object that supports the control pattern, or <c>NULL</c> if the control pattern is not supported. This
		/// parameter is passed uninitialized.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-irawelementprovidersimple-getpatternprovider
		// HRESULT GetPatternProvider( [in] PATTERNID patternId, [out, retval] IUnknown **pRetVal );
		[return: MarshalAs(UnmanagedType.IUnknown)]
		new object GetPatternProvider(UIAutomationClient.PATTERNID patternId);

		/// <summary>Retrieves the value of a property supported by the Microsoft UI Automation provider.</summary>
		/// <param name="propertyId">
		/// <para>Type: <c>PROPERTYID</c></para>
		/// <para>The property identifier. For a list of property IDs, see Property Identifiers.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>VARIANT*</c></para>
		/// <para>
		/// Receives the property value, or <c>VT_EMPTY</c> if the property is not supported by this provider. This parameter is passed
		/// uninitialized. See Remarks.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If a provider is explicitly hiding the property value (that is, the provider does not supply the property, and the request is not
		/// to be passed through to other providers), it should return a pointer obtained by using the UiaGetReservedNotSupportedValue
		/// function. For example:
		/// </para>
		/// <para>
		/// UI Automation properties of the <c>double</c> type support Not a Number (NaN) values. When returning a NaN value, the provider
		/// should return a quiet (non-signaling) NaN to avoid raising an exception if floating-point exceptions are turned on. The following
		/// example shows how to create a quiet NaN:
		/// </para>
		/// <para>Alternatively, you can use the following function from the standard C++ libraries:</para>
		/// <para>Examples</para>
		/// <para>
		/// The following example returns various property values. The <c>UiaIds</c> structure contains property identifiers; to see how it
		/// is initialized, see UiaLookupId.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-irawelementprovidersimple-getpropertyvalue
		// HRESULT GetPropertyValue( [in] PROPERTYID propertyId, [out, retval] VARIANT *pRetVal );
		new object GetPropertyValue(UIAutomationClient.PROPERTYID propertyId);

		/// <summary>
		/// <para>
		/// Specifies the type of Microsoft UI Automation provider; for example, whether it is a client-side (proxy) or server-side provider.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>The method must return either ProviderOptions_ServerSideProvider or ProviderOptions_ClientSideProvider.</para>
		/// <para>
		/// UI Automation handles the various types of providers differently. For example, events from a server-side provider are broadcast
		/// to all listening clients, but events from client-side (proxy) providers remain in the client.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example implements this method for a server-side UI Automation provider.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-irawelementprovidersimple-get_provideroptions
		// HRESULT get_ProviderOptions( ProviderOptions *pRetVal );
		new ProviderOptions ProviderOptions { get; }

		/// <summary>
		/// <para>Specifies the host provider for this element.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// This property is generally the Microsoft UI Automation provider for the window of a custom control. UI Automation uses this
		/// provider in combination with the custom provider. For example, the runtime identifier of the element is usually obtained from the
		/// host provider.
		/// </para>
		/// <para>
		/// A host provider must be returned in the following cases: when the element is a fragment root, when the element is a simple
		/// element (such as a push button), and when the provider is a repositioning placeholder (for more information, see Provider
		/// Repositioning). In other cases, the property should be <c>NULL</c>.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example returns the host provider for the window that hosts the control served by this provider.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-irawelementprovidersimple-get_hostrawelementprovider
		// HRESULT get_HostRawElementProvider( IRawElementProviderSimple **pRetVal );
		new IRawElementProviderSimple HostRawElementProvider { get; }

		/// <summary>Programmatically invokes a context menu on the target element.</summary>
		/// <remarks>
		/// <para>This method returns an error code if the context menu could not be invoked.</para>
		/// <para>
		/// If no context menu is available directly on the element on which <c>ShowContextMenu</c> was invoked, the provider should attempt
		/// to invoke a context menu on the UI Automation parent of the current item.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-irawelementprovidersimple2-showcontextmenu
		// HRESULT ShowContextMenu();
		void ShowContextMenu();
	}

	/// <summary>
	/// Extends the IRawElementProviderSimple2 interface to enable retrieving metadata about how accessible technology should say the
	/// preferred content type.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Screen reading accessibility tools like Narrator use a speech synthesizer to read what an app is showing. Speech synthesizers usually
	/// read the provided content well based on the content description.
	/// </para>
	/// <para>
	/// However, the speech synthesizer could use some help describing the preferred content type. The SayAs command provides accurate
	/// content reading from a Microsoft UI Automation provider to a UI Automation client (such as a screen reader) through UI Automation
	/// core APIs.
	/// </para>
	/// <para>Examples:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// Given the date 10/4, is the format Month/Day or Day/Month? If a screen reader does not know, you could hear October 4th or 10th April.
	/// </description>
	/// </item>
	/// <item>
	/// <description>Given the string "10-100", is this "Ten to one hundred" or "Ten minus 100"?
	/// <para>The ability to mark the "10" as a number and the "-100" as a number helps active technology (AT) read it better.</para>
	/// </description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-irawelementprovidersimple3
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.IRawElementProviderSimple3")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("fcf5d820-d7ec-4613-bdf6-42a84ce7daaf")]
	public interface IRawElementProviderSimple3 : IRawElementProviderSimple2
	{
		/// <summary>Retrieves a pointer to an object that provides support for a control pattern on a Microsoft UI Automation element.</summary>
		/// <param name="patternId">
		/// <para>Type: <c>PATTERNID</c></para>
		/// <para>The identifier of the control pattern. For a list of control pattern IDs, see Control Pattern Identifiers.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IUnknown**</c></para>
		/// <para>
		/// Receives a pointer to the object that supports the control pattern, or <c>NULL</c> if the control pattern is not supported. This
		/// parameter is passed uninitialized.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-irawelementprovidersimple-getpatternprovider
		// HRESULT GetPatternProvider( [in] PATTERNID patternId, [out, retval] IUnknown **pRetVal );
		[return: MarshalAs(UnmanagedType.IUnknown)]
		new object GetPatternProvider(UIAutomationClient.PATTERNID patternId);

		/// <summary>Retrieves the value of a property supported by the Microsoft UI Automation provider.</summary>
		/// <param name="propertyId">
		/// <para>Type: <c>PROPERTYID</c></para>
		/// <para>The property identifier. For a list of property IDs, see Property Identifiers.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>VARIANT*</c></para>
		/// <para>
		/// Receives the property value, or <c>VT_EMPTY</c> if the property is not supported by this provider. This parameter is passed
		/// uninitialized. See Remarks.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If a provider is explicitly hiding the property value (that is, the provider does not supply the property, and the request is not
		/// to be passed through to other providers), it should return a pointer obtained by using the UiaGetReservedNotSupportedValue
		/// function. For example:
		/// </para>
		/// <para>
		/// UI Automation properties of the <c>double</c> type support Not a Number (NaN) values. When returning a NaN value, the provider
		/// should return a quiet (non-signaling) NaN to avoid raising an exception if floating-point exceptions are turned on. The following
		/// example shows how to create a quiet NaN:
		/// </para>
		/// <para>Alternatively, you can use the following function from the standard C++ libraries:</para>
		/// <para>Examples</para>
		/// <para>
		/// The following example returns various property values. The <c>UiaIds</c> structure contains property identifiers; to see how it
		/// is initialized, see UiaLookupId.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-irawelementprovidersimple-getpropertyvalue
		// HRESULT GetPropertyValue( [in] PROPERTYID propertyId, [out, retval] VARIANT *pRetVal );
		new object GetPropertyValue(UIAutomationClient.PROPERTYID propertyId);

		/// <summary>
		/// <para>
		/// Specifies the type of Microsoft UI Automation provider; for example, whether it is a client-side (proxy) or server-side provider.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>The method must return either ProviderOptions_ServerSideProvider or ProviderOptions_ClientSideProvider.</para>
		/// <para>
		/// UI Automation handles the various types of providers differently. For example, events from a server-side provider are broadcast
		/// to all listening clients, but events from client-side (proxy) providers remain in the client.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example implements this method for a server-side UI Automation provider.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-irawelementprovidersimple-get_provideroptions
		// HRESULT get_ProviderOptions( ProviderOptions *pRetVal );
		new ProviderOptions ProviderOptions { get; }

		/// <summary>
		/// <para>Specifies the host provider for this element.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// This property is generally the Microsoft UI Automation provider for the window of a custom control. UI Automation uses this
		/// provider in combination with the custom provider. For example, the runtime identifier of the element is usually obtained from the
		/// host provider.
		/// </para>
		/// <para>
		/// A host provider must be returned in the following cases: when the element is a fragment root, when the element is a simple
		/// element (such as a push button), and when the provider is a repositioning placeholder (for more information, see Provider
		/// Repositioning). In other cases, the property should be <c>NULL</c>.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example returns the host provider for the window that hosts the control served by this provider.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-irawelementprovidersimple-get_hostrawelementprovider
		// HRESULT get_HostRawElementProvider( IRawElementProviderSimple **pRetVal );
		new IRawElementProviderSimple HostRawElementProvider { get; }

		/// <summary>Programmatically invokes a context menu on the target element.</summary>
		/// <remarks>
		/// <para>This method returns an error code if the context menu could not be invoked.</para>
		/// <para>
		/// If no context menu is available directly on the element on which <c>ShowContextMenu</c> was invoked, the provider should attempt
		/// to invoke a context menu on the UI Automation parent of the current item.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-irawelementprovidersimple2-showcontextmenu
		// HRESULT ShowContextMenu();
		new void ShowContextMenu();

		/// <summary>
		/// Gets metadata from the UI Automation element that indicates how the information should be interpreted. For example, should the
		/// string "1/4" be interpreted as a fraction or a date?
		/// </summary>
		/// <param name="targetId">The ID of the property to retrieve.</param>
		/// <param name="metadataId">Specifies the type of metadata to retrieve.</param>
		/// <returns>The metadata.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-irawelementprovidersimple3-getmetadatavalue
		// HRESULT GetMetadataValue( [in] int targetId, [in] METADATAID metadataId, [out, retval] VARIANT *returnVal );
		object GetMetadataValue(int targetId, UIAutomationClient.METADATAID metadataId);
	}

	/// <summary>
	/// A Microsoft ActiveX control site implements this interface to enable a Microsoft UI Automation-enabled ActiveX control to express its
	/// accessibility. This interface enables the control container to provide an IRawElementProviderFragment pointer for the parent or
	/// siblings of the windowless ActiveX control, and to provide a runtime ID that is unique to the control site.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-irawelementproviderwindowlesssite
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.IRawElementProviderWindowlessSite")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0a2a93cc-bfad-42ac-9b2e-0991fb0d3ea0")]
	public interface IRawElementProviderWindowlessSite
	{
		/// <summary>
		/// Retrieves a fragment pointer for a fragment that is adjacent to the windowless Microsoft ActiveX control owned by this control site.
		/// </summary>
		/// <param name="direction"/>
		/// <returns>
		/// <para>Type: <c>IRawElementProviderFragment**</c></para>
		/// <para>Receives the adjacent fragment.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To return the parent of the fragment, an object that implements the IRawElementProviderFragment interface must be able to
		/// implement the Navigate method. Implementing <c>Navigate</c> is difficult for a windowless ActiveX control because the control
		/// might be unable to determine its location in the accessible tree of the parent object. The <c>GetAdjacentFragment</c> method
		/// enables the windowless ActiveX control to query its site for the adjacent fragment, and then return that fragment to the client
		/// that called <c>Navigate</c>.
		/// </para>
		/// <para>A provider typically calls this method as part of handling the IRawElementProviderFragment::Navigate method.</para>
		/// <para>Examples</para>
		/// <para>The following C++ code example shows how to implement the <c>GetAdjacentFragment</c> method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-irawelementproviderwindowlesssite-getadjacentfragment
		// HRESULT GetAdjacentFragment( NavigateDirection direction, [out, retval] IRawElementProviderFragment **ppParent );
		IRawElementProviderFragment GetAdjacentFragment(NavigateDirection direction);

		/// <summary>Retrieves a Microsoft UI Automation runtime ID that is unique to the windowless Microsoft ActiveX control site.</summary>
		/// <returns>
		/// <para>Type: <c>SAFEARRAY**</c></para>
		/// <para>Receives the runtime ID.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A UI Automation fragment must implement the IRawElementProviderFragment::GetRuntimeId method to return a unique ID for the
		/// fragment. This is difficult for a windowless ActiveX control, which must be able to identify itself as unique among other
		/// windowless controls in the ActiveX control container. To resolve this issue, the windowless site should implement the
		/// <c>GetRuntimeIdPrefix</c> method by forming a SAFEARRAY that contains the constant <c>UiaAppendRuntimeId</c>, followed by an
		/// integer value that is unique to this windowless site.
		/// </para>
		/// <para>
		/// The fragment can then append an integer value that is unique relative to all other fragments in the windowless ActiveX control,
		/// and return it to the client.
		/// </para>
		/// <para>
		/// For example, the site might return a SAFEARRAY with the following contents: . This might represent the third ActiveX control in
		/// the container. The fragment provider's GetRuntimeId method could then form a SAFEARRAY with the following contents: . This might
		/// represent the fifth fragment within the ActiveX container. The whole SAFEARRAY would be a unique ID relative to the whole ActiveX
		/// control container.
		/// </para>
		/// <para>A provider typically calls this method as part of handling the GetRuntimeId method.</para>
		/// <para>Examples</para>
		/// <para>The following C++ code example shows how to implement the <c>GetRuntimeIdPrefix</c> method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-irawelementproviderwindowlesssite-getruntimeidprefix
		// HRESULT GetRuntimeIdPrefix( [out, retval] SAFEARRAY **pRetVal );
		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)]
		int[] GetRuntimeIdPrefix();
	}

	/// <summary>Provides access to individual child controls of containers that implement IScrollProvider.</summary>
	/// <remarks>Implemented on a Microsoft UI Automation provider that must support the ScrollItem control pattern.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-iscrollitemprovider
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.IScrollItemProvider")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("2360c714-4bf1-4b26-ba65-9b21316127eb")]
	public interface IScrollItemProvider
	{
		/// <summary>
		/// Scrolls the content area of a container object in order to display the control within the visible region (viewport) of the container.
		/// </summary>
		/// <remarks>This method will not guarantee the position of the control within the visible region (viewport) of the container.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iscrollitemprovider-scrollintoview
		// HRESULT ScrollIntoView();
		void ScrollIntoView();
	}

	/// <summary>
	/// Provides access to controls that act as scrollable containers for a collection of child objects. The children of this control must
	/// implement IScrollItemProvider.
	/// </summary>
	/// <remarks>Implemented on a Microsoft UI Automation provider that must support the Scroll control pattern.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-iscrollprovider
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.IScrollProvider")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("b38b8077-1fc3-42a5-8cae-d40c2215055a")]
	public interface IScrollProvider
	{
		/// <summary>Scrolls the visible region of the content area horizontally and vertically.</summary>
		/// <param name="horizontalAmount"/>
		/// <param name="verticalAmount"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iscrollprovider-scroll HRESULT Scroll(
		// ScrollAmount horizontalAmount, ScrollAmount verticalAmount );
		void Scroll(ScrollAmount horizontalAmount, ScrollAmount verticalAmount);

		/// <summary>Sets the horizontal and vertical scroll position as a percentage of the total content area within the control.</summary>
		/// <param name="horizontalPercent">
		/// <para>Type: <c>double</c></para>
		/// <para>
		/// The horizontal position as a percentage of the content area's total range, or <c>UIA_ScrollPatternNoScroll</c> if there is no
		/// horizontal scrolling.
		/// </para>
		/// </param>
		/// <param name="verticalPercent">
		/// <para>Type: <c>double</c></para>
		/// <para>
		/// The vertical position as a percentage of the content area's total range, or <c>UIA_ScrollPatternNoScroll</c> if there is no
		/// vertical scrolling.
		/// </para>
		/// </param>
		/// <remarks>This method is only useful when the content area of the control is larger than the visible region.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iscrollprovider-setscrollpercent HRESULT
		// SetScrollPercent( [in] double horizontalPercent, [in] double verticalPercent );
		void SetScrollPercent(double horizontalPercent, double verticalPercent);

		/// <summary>
		/// <para>Specifies the horizontal scroll position.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// The horizontal scroll position can be reported as <c>UIA_ScrollPatternNoScroll</c> if no valid position is available; for
		/// example, if the window does not have a horizontal scroll bar.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iscrollprovider-get_horizontalscrollpercent
		// HRESULT get_HorizontalScrollPercent( double *pRetVal );
		double HorizontalScrollPercent { get; }

		/// <summary>
		/// <para>Specifies the vertical scroll position.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// The vertical scroll position can be reported as <c>UIA_ScrollPatternNoScroll</c> if no valid position is available; for example,
		/// if the window does not have a vertical scroll bar.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iscrollprovider-get_verticalscrollpercent
		// HRESULT get_VerticalScrollPercent( double *pRetVal );
		double VerticalScrollPercent { get; }

		/// <summary>
		/// <para>Specifies the horizontal size of the viewable region.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iscrollprovider-get_horizontalviewsize
		// HRESULT get_HorizontalViewSize( double *pRetVal );
		double HorizontalViewSize { get; }

		/// <summary>
		/// <para>Specifies the vertical size of the viewable region.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iscrollprovider-get_verticalviewsize
		// HRESULT get_VerticalViewSize( double *pRetVal );
		double VerticalViewSize { get; }

		/// <summary>
		/// <para>Indicates whether the control can scroll horizontally.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// This property can be dynamic. For example, the content area of the control might not be larger than the current viewable area,
		/// meaning <c>IScrollProvider::HorizontallyScrollable</c> is <c>FALSE</c>. However, either resizing the control or adding child
		/// items may increase the bounds of the content area beyond the viewable area, meaning
		/// <c>IScrollProvider::HorizontallyScrollable</c> is <c>TRUE</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iscrollprovider-get_horizontallyscrollable
		// HRESULT get_HorizontallyScrollable( BOOL *pRetVal );
		bool HorizontallyScrollable { get; }

		/// <summary>
		/// <para>Indicates whether the control can scroll vertically.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// This property can be dynamic. For example, the content area of the control might not be larger than the viewable area, meaning
		/// <c>IScrollProvider::VerticallyScrollable</c> is <c>FALSE</c>. However, resizing the control or adding child items may increase
		/// the bounds of the content area beyond the viewable area, meaning that <c>IScrollProvider::VerticallyScrollable</c> is <c>TRUE</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iscrollprovider-get_verticallyscrollable
		// HRESULT get_VerticallyScrollable( BOOL *pRetVal );
		bool VerticallyScrollable { get; }
	}

	/// <summary>Provides access to individual, selectable child controls of containers that implement ISelectionProvider.</summary>
	/// <remarks>Implemented on a Microsoft UI Automation provider that must support the SelectionItem control pattern.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-iselectionitemprovider
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.ISelectionItemProvider")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("2acad808-b2d4-452d-a407-91ff1ad167b2")]
	public interface ISelectionItemProvider
	{
		/// <summary>Deselects any selected items and then selects the current element.</summary>
		/// <remarks>
		/// If the current element isnât selected, this method deselects any selected items and then selects the current element. If the
		/// current element is already selected, this method does nothing.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iselectionitemprovider-select HRESULT Select();
		void Select();

		/// <summary>Adds the current element to the collection of selected items.</summary>
		/// <remarks>
		/// <para>
		/// If the result of a call to <c>ISelectionItemProvider::AddToSelection</c> is that a single item is selected, then send an
		/// UIA_SelectionItem_ElementSelectedEventId event for that element; otherwise send an
		/// UIA_SelectionItem_ElementAddedToSelectionEventId or UIA_SelectionItem_ElementRemovedFromSelectionEventId event as appropriate.
		/// </para>
		/// <para>
		/// <c>Note</c> Â Â This rule does not depend on whether the container allows single or multiple selection, or on what method was
		/// used to change the selection. Only the result matters.
		/// </para>
		/// <para>Â</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iselectionitemprovider-addtoselection
		// HRESULT AddToSelection();
		void AddToSelection();

		/// <summary>Removes the current element from the collection of selected items.</summary>
		/// <remarks>
		/// <para>Send an UIA_SelectionItem_ElementRemovedFromSelectionEventId event as appropriate.</para>
		/// <para>
		/// <c>Note</c> Â Â This rule does not depend on whether the container allows single or multiple selection, or on what method was
		/// used to change the selection. Only the result matters.
		/// </para>
		/// <para>Â</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iselectionitemprovider-removefromselection
		// HRESULT RemoveFromSelection();
		void RemoveFromSelection();

		/// <summary>
		/// <para>Indicates whether an item is selected.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iselectionitemprovider-get_isselected
		// HRESULT get_IsSelected( BOOL *pRetVal );
		bool IsSelected { get; }

		/// <summary>
		/// <para>Specifies the provider that implements ISelectionProvider and acts as the container for the calling object.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iselectionitemprovider-get_selectioncontainer
		// HRESULT get_SelectionContainer( IRawElementProviderSimple **pRetVal );
		IRawElementProviderSimple SelectionContainer { get; }
	}

	/// <summary>
	/// Provides access to controls that act as containers for a collection of individual, selectable child items. The children of this
	/// control must implement ISelectionItemProvider.
	/// </summary>
	/// <remarks>
	/// <para>This interface is implemented by a UI Automation provider.</para>
	/// <para>Providers should raise an event of type UIA_Selection_InvalidatedEventId when a selection in a container has changed significantly.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-iselectionprovider
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.ISelectionProvider")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("fb8b03af-3bdf-48d4-bd36-1a65793be168")]
	public interface ISelectionProvider
	{
		/// <summary>Retrieves a Microsoft UI Automation provider for each child element that is selected.</summary>
		/// <returns>
		/// <para>Type: <c>SAFEARRAY**</c></para>
		/// <para>
		/// Receives a pointer to a SAFEARRAY that contains an array of pointers to the IRawElementProviderSimple interfaces of the selected
		/// elements. This parameter is passed uninitialized.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iselectionprovider-getselection HRESULT
		// GetSelection( [out, retval] SAFEARRAY **pRetVal );
		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UNKNOWN)]
		IRawElementProviderSimple[] GetSelection();

		/// <summary>
		/// <para>Indicates whether the Microsoft UI Automation provider allows more than one child element to be selected concurrently.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// This property may be dynamic. For example, in rare cases a control might allow multiple items to be selected on initialization
		/// but subsequently allow only single selections to be made.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iselectionprovider-get_canselectmultiple
		// HRESULT get_CanSelectMultiple( BOOL *pRetVal );
		bool CanSelectMultiple { get; }

		/// <summary>
		/// <para>Indicates whether the Microsoft UI Automation provider requires at least one child element to be selected.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// This property can be dynamic. For example, the initial state of a control might not have any items selected by default, meaning
		/// that <c>ISelectionProvider::IsSelectionRequired</c> is <c>FALSE</c>. However, after an item is selected the control must always
		/// have at least one item selected.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iselectionprovider-get_isselectionrequired
		// HRESULT get_IsSelectionRequired( BOOL *pRetVal );
		bool IsSelectionRequired { get; }
	}

	/// <summary>Extends the ISelectionItemProvider interface to provide information about selected items.</summary>
	/// <remarks>
	/// <para>This interface is implemented by a Microsoft UI Automation provider.</para>
	/// <para>Providers should raise an event of type UIA_Selection_InvalidatedEventId when a selection in a container has changed significantly.</para>
	/// <para>
	/// When selecting from a list or 2D grid there are primary pieces of information that ATs would like to better read to their end users.
	/// Using Excel as a primary example, there are 4 main pieces of information necessary for the AT to provide a good experience:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description>The first cell in the selection</description>
	/// </item>
	/// <item>
	/// <description>The last cell in the selection</description>
	/// </item>
	/// <item>
	/// <description>The current item as you select</description>
	/// </item>
	/// <item>
	/// <description>The total count</description>
	/// </item>
	/// </list>
	/// <para>The above image illustrates the end state of a 2D selection:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>The user started in cell F5 (note this is where focus input stays because if you type that is where data lands)</description>
	/// </item>
	/// <item>
	/// <description>The user selects down the column to cell F7</description>
	/// </item>
	/// <item>
	/// <description>The user then selects left to cell D7</description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-iselectionprovider2
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.ISelectionProvider2")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("14f68475-ee1c-44f6-a869-d239381f0fe7")]
	public interface ISelectionProvider2 : ISelectionProvider
	{
		/// <summary>Retrieves a Microsoft UI Automation provider for each child element that is selected.</summary>
		/// <returns>
		/// <para>Type: <c>SAFEARRAY**</c></para>
		/// <para>
		/// Receives a pointer to a SAFEARRAY that contains an array of pointers to the IRawElementProviderSimple interfaces of the selected
		/// elements. This parameter is passed uninitialized.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iselectionprovider-getselection HRESULT
		// GetSelection( [out, retval] SAFEARRAY **pRetVal );
		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UNKNOWN)]
		new IRawElementProviderSimple[] GetSelection();

		/// <summary>
		/// <para>Indicates whether the Microsoft UI Automation provider allows more than one child element to be selected concurrently.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// This property may be dynamic. For example, in rare cases a control might allow multiple items to be selected on initialization
		/// but subsequently allow only single selections to be made.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iselectionprovider-get_canselectmultiple
		// HRESULT get_CanSelectMultiple( BOOL *pRetVal );
		new bool CanSelectMultiple { get; }

		/// <summary>
		/// <para>Indicates whether the Microsoft UI Automation provider requires at least one child element to be selected.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// This property can be dynamic. For example, the initial state of a control might not have any items selected by default, meaning
		/// that <c>ISelectionProvider::IsSelectionRequired</c> is <c>FALSE</c>. However, after an item is selected the control must always
		/// have at least one item selected.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iselectionprovider-get_isselectionrequired
		// HRESULT get_IsSelectionRequired( BOOL *pRetVal );
		new bool IsSelectionRequired { get; }

		/// <summary>
		/// <para>Gets the first item in a group of selected items.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iselectionprovider2-get_firstselecteditem
		// HRESULT get_FirstSelectedItem( IRawElementProviderSimple **retVal );
		IRawElementProviderSimple FirstSelectedItem { get; }

		/// <summary>
		/// <para>Gets the last item in a group of selected items.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iselectionprovider2-get_lastselecteditem
		// HRESULT get_LastSelectedItem( IRawElementProviderSimple **retVal );
		IRawElementProviderSimple LastSelectedItem { get; }

		/// <summary>
		/// <para>Gets the currently selected item.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iselectionprovider2-get_currentselecteditem
		// HRESULT get_CurrentSelectedItem( IRawElementProviderSimple **retVal );
		IRawElementProviderSimple CurrentSelectedItem { get; }

		/// <summary>
		/// <para>Gets the number of selected items.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iselectionprovider2-get_itemcount HRESULT
		// get_ItemCount( int *retVal );
		int ItemCount { get; }
	}

	/// <summary>Provides access to information about an item (cell) in a spreadsheet.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-ispreadsheetitemprovider
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.ISpreadsheetItemProvider")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("eaed4660-7b3d-4879-a2e6-365ce603f3d0")]
	public interface ISpreadsheetItemProvider
	{
		/// <summary>Retrieves an array of objects that represent the annotations associated with this spreadsheet cell.</summary>
		/// <returns>
		/// <para>Type: <c>SAFEARRAY**</c></para>
		/// <para>
		/// Receives an array of IRawElementProviderSimple interfaces that represent the annotations associated with the spreadsheet cell.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-ispreadsheetitemprovider-getannotationobjects
		// HRESULT GetAnnotationObjects( [out, retval] SAFEARRAY **pRetVal );
		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UNKNOWN)]
		IRawElementProviderSimple[] GetAnnotationObjects();

		/// <summary>
		/// Retrieves an array of annotation type identifiers indicating the types of annotations that are associated with this spreadsheet cell.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>SAFEARRAY**</c></para>
		/// <para>
		/// Receives an array of annotation type identifiers, one for each type of annotation associated with the spreadsheet cell. For a
		/// list of possible values, see Annotation Type Identifiers.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-ispreadsheetitemprovider-getannotationtypes
		// HRESULT GetAnnotationTypes( [out, retval] SAFEARRAY **pRetVal );
		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)]
		int[] GetAnnotationTypes();

		/// <summary>
		/// <para>Specifies the formula for this spreadsheet cell.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-ispreadsheetitemprovider-get_formula
		// HRESULT get_Formula( BSTR *pRetVal );
		string Formula { [return: MarshalAs(UnmanagedType.BStr)] get; }
	}

	/// <summary>Provides access to items (cells) in a spreadsheet.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-ispreadsheetprovider
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.ISpreadsheetProvider")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("6f6b5d35-5525-4f80-b758-85473832ffc7")]
	public interface ISpreadsheetProvider
	{
		/// <summary>Exposes a UI Automation element that represents the spreadsheet cell that has the specified name.</summary>
		/// <param name="name">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>The name of the target cell.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IRawElementProviderSimple**</c></para>
		/// <para>Receives the element that represents the target cell.</para>
		/// </returns>
		/// <remarks>A spreadsheet cell typically has a name such as âc5â or âa15â. A name can also apply to a range of cells.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-ispreadsheetprovider-getitembyname
		// HRESULT GetItemByName( [in] LPCWSTR name, [out, retval] IRawElementProviderSimple **pRetVal );
		IRawElementProviderSimple GetItemByName(string name);
	}

	/// <summary>Provides access to the visual styles associated with the content of a document.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-istylesprovider
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.IStylesProvider")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("19b6b649-f5d7-4a6d-bdcb-129252be588a")]
	public interface IStylesProvider
	{
		/// <summary>
		/// <para>Identifies the visual style of an element in a document.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// A provider should use this property to expose style identifiers that are useful to client applications. For example, a provider
		/// might expose the StyleId_Title identifier for an element that represents the title of a presentation. A screen reader could then
		/// retrieve the <c>StyleId</c> property, discover that the element is a presentation title, and read the title to the user.
		/// </para>
		/// <para>List Styles</para>
		/// <para>IDs for list styles are supported starting with WindowsÂ 8.1.</para>
		/// <para>
		/// These styles should be applied at a paragraph level; all text that is part of a list item should have one of these styles applied
		/// to it.
		/// </para>
		/// <para>
		/// When bullet styles are mixed within a list, the <c>BulletedList</c> style should be applied to the whole range, and the
		/// BulletStyle attribute value (property identified by <c>UIA_BulletStyleAttributeId</c>) should be mixed according to breakdown of
		/// different bullet types within the range.
		/// </para>
		/// <para>
		/// When nested lists contain bullets also (perhaps of a different type than the main list), the <c>BulletedList</c> style would
		/// again be applied to the whole range, and the <c>BulletStyle</c> attribute value is whatever the nested bullet style is (for the
		/// range covering the nested list).
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-istylesprovider-get_styleid HRESULT
		// get_StyleId( int *retVal );
		int StyleId { get; }

		/// <summary>
		/// <para>Specifies the name of the visual style of an element in a document.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>The style name typically indicates the role of the element in the document, such as "Heading 1."</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-istylesprovider-get_stylename HRESULT
		// get_StyleName( BSTR *retVal );
		string StyleName { [return: MarshalAs(UnmanagedType.BStr)] get; }

		/// <summary>
		/// <para>Specifies the fill color of an element in a document.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-istylesprovider-get_fillcolor HRESULT
		// get_FillColor( int *retVal );
		int FillColor { get; }

		/// <summary>
		/// <para>Specifies the fill pattern style of an element in a document.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-istylesprovider-get_fillpatternstyle
		// HRESULT get_FillPatternStyle( BSTR *retVal );
		string FillPatternStyle { [return: MarshalAs(UnmanagedType.BStr)] get; }

		/// <summary>
		/// <para>Specifies the shape of an element in a document.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-istylesprovider-get_shape HRESULT
		// get_Shape( BSTR *retVal );
		string Shape { [return: MarshalAs(UnmanagedType.BStr)] get; }

		/// <summary>
		/// <para>Specifies the color of the pattern used to fill an element in a document.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-istylesprovider-get_fillpatterncolor
		// HRESULT get_FillPatternColor( int *retVal );
		int FillPatternColor { get; }

		/// <summary>
		/// <para>
		/// Contains additional properties that are not included in this control pattern, but that provide information about the document
		/// content that might be useful to the user.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>The extended properties must be localized because they are intended to be consumed by the user.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-istylesprovider-get_extendedproperties
		// HRESULT get_ExtendedProperties( BSTR *retVal );
		string ExtendedProperties { [return: MarshalAs(UnmanagedType.BStr)] get; }
	}

	/// <summary>Enables Microsoft UI Automation client applications to direct the mouse or keyboard input to a specific UI element.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-isynchronizedinputprovider
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.ISynchronizedInputProvider")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("29db1a06-02ce-4cf7-9b42-565d4fab20ee")]
	public interface ISynchronizedInputProvider
	{
		/// <summary>Starts listening for input of the specified type.</summary>
		/// <param name="inputType">
		/// <para>Type: <c>SynchronizedInputType</c></para>
		/// <para>The type of input that is requested to be synchronized.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// When it finds matching input, the provider checks if the target UI Automation element matches the current element. If they match,
		/// the provider raises the UIA_InputReachedTargetEventId event; otherwise, it raises the UIA_InputReachedOtherElementEventId or
		/// UIA_InputDiscardedEventId event. The UI Automation provider must discard the input if it is for an element other than this one.
		/// </para>
		/// <para>This is a one-shot method; after receiving input, the provider stops listening and continues normally.</para>
		/// <para>This method returns E_INVALIDOPERATION if the provider is already listening for input.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-isynchronizedinputprovider-startlistening
		// HRESULT StartListening( [in] SynchronizedInputType inputType );
		void StartListening(SynchronizedInputType inputType);

		/// <summary>Cancels listening for input.</summary>
		/// <remarks>If the provider is currently listening for input, it should revert to normal operation.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-isynchronizedinputprovider-cancel HRESULT Cancel();
		void Cancel();
	}

	/// <summary>Provides access to child controls of containers that implement ITableProvider.</summary>
	/// <remarks>
	/// <para>
	/// This control pattern is analogous to IGridItemProvider with the distinction that any control implementing <c>ITableItemProvider</c>
	/// must expose the relationship between the individual cell and its row and column information.
	/// </para>
	/// <para>Access to individual cell functionality is provided by the concurrent implementation of IGridItemProvider.</para>
	/// <para>Implemented on a UI Automation provider that must support the TableItem control pattern.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-itableitemprovider
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.ITableItemProvider")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("b9734fa6-771f-4d78-9c90-2517999349cd")]
	public interface ITableItemProvider
	{
		/// <summary>
		/// Retrieves a collection of Microsoft UI Automation provider representing all the row headers associated with a table item or cell.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>SAFEARRAY**</c></para>
		/// <para>
		/// Receives a pointer to a SAFEARRAY that contains an array of pointers to the IRawElementProviderSimple interfaces of the row
		/// headers. This parameter is passed uninitialized.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itableitemprovider-getrowheaderitems
		// HRESULT GetRowHeaderItems( [out, retval] SAFEARRAY **pRetVal );
		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UNKNOWN)]
		IRawElementProviderSimple[] GetRowHeaderItems();

		/// <summary>
		/// Retrieves a collection of Microsoft UI Automation provider representing all the column headers associated with a table item or cell.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>SAFEARRAY**</c></para>
		/// <para>
		/// Receives a pointer to a SAFEARRAY that contains an array of pointers to the IRawElementProviderSimple interfaces of the column
		/// headers. This parameter is passed uninitialized.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itableitemprovider-getcolumnheaderitems
		// HRESULT GetColumnHeaderItems( [out, retval] SAFEARRAY **pRetVal );
		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UNKNOWN)]
		IRawElementProviderSimple[] GetColumnHeaderItems();
	}

	/// <summary>
	/// Provides access to controls that act as containers for a collection of child elements. The children of this element must implement
	/// ITableItemProvider and be organized in a two-dimensional logical coordinate system that can be traversed by using the keyboard.
	/// </summary>
	/// <remarks>
	/// <para>
	/// This control pattern is analogous to IGridProvider with the distinction that any control that implements <c>ITableProvider</c> must
	/// also expose a column and/or row header relationship for each child element.
	/// </para>
	/// <para>
	/// Controls that implement <c>ITableProvider</c> are also required to implement IGridProvider so as to expose the inherent grid
	/// functionality of a table control.
	/// </para>
	/// <para>Implemented on a UI Automation provider that must support the Table control pattern and Grid control pattern.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-itableprovider
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.ITableProvider")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("9c860395-97b3-490a-b52a-858cc22af166")]
	public interface ITableProvider
	{
		/// <summary>Gets a collection of Microsoft UI Automation providers that represents all the row headers in a table.</summary>
		/// <returns>
		/// <para>Type: <c>SAFEARRAY**</c></para>
		/// <para>
		/// Receives a pointer to a SAFEARRAY that contains an array of pointers to the IRawElementProviderSimple interfaces of the row
		/// headers. This parameter is passed uninitialized.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itableprovider-getrowheaders HRESULT
		// GetRowHeaders( [out, retval] SAFEARRAY **pRetVal );
		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UNKNOWN)]
		IRawElementProviderSimple[] GetRowHeaders();

		/// <summary>Gets a collection of Microsoft UI Automation providers that represents all the column headers in a table.</summary>
		/// <returns>
		/// <para>Type: <c>SAFEARRAY**</c></para>
		/// <para>
		/// Receives a pointer to a SAFEARRAY that contains an array of pointers to the IRawElementProviderSimple interfaces of the column
		/// headers. This parameter is passed uninitialized.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itableprovider-getcolumnheaders HRESULT
		// GetColumnHeaders( [out, retval] SAFEARRAY **pRetVal );
		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UNKNOWN)]
		IRawElementProviderSimple[] GetColumnHeaders();

		/// <summary>
		/// <para>Specifies the primary direction of traversal for the table.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itableprovider-get_roworcolumnmajor
		// HRESULT get_RowOrColumnMajor( RowOrColumnMajor *pRetVal );
		RowOrColumnMajor RowOrColumnMajor { get; }
	}

	/// <summary>
	/// Provides access to a text-based control (or an object embedded in text) that is a child or descendant of another text-based control.
	/// </summary>
	/// <remarks>
	/// <para>
	/// An element that implements the TextChild control pattern must be a child, or descendent, of an element that supports the Text control pattern.
	/// </para>
	/// <para>It is not required that this element also implement the Text control pattern.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-itextchildprovider
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.ITextChildProvider")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("4c2de2b9-c88f-4f88-a111-f1d336b7d1a9")]
	public interface ITextChildProvider
	{
		/// <summary>
		/// <para>Retrieves this element's nearest ancestor provider that supports the Text control pattern.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextchildprovider-get_textcontainer
		// HRESULT get_TextContainer( IRawElementProviderSimple **pRetVal );
		IRawElementProviderSimple TextContainer { get; }

		/// <summary>
		/// <para>Retrieves a text range that encloses this child element.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextchildprovider-get_textrange HRESULT
		// get_TextRange( ITextRangeProvider **pRetVal );
		ITextRangeProvider TextRange { get; }
	}

	/// <summary>Extends the ITextProvider interface to enable Microsoft UI Automation providers to expose programmatic text-edit actions.</summary>
	/// <remarks>
	/// Call the UiaRaiseTextEditTextChangedEvent function to raise the UI Automation events that notify clients of changes. Use values of
	/// TextEditChangeType to describe the change. Follow the guidance given in TextEdit Control Pattern that describes when to raise the
	/// events and what payload the events should pass to UI Automation.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-itexteditprovider
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.ITextEditProvider")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("ea3605b4-3a05-400e-b5f9-4e91b40f6176")]
	public interface ITextEditProvider : ITextProvider
	{
		/// <summary>Retrieves a collection of text ranges that represents the currently selected text in a text-based control.</summary>
		/// <returns>
		/// <para>Type: <c>SAFEARRAY**</c></para>
		/// <para>
		/// Receives the address of an array of pointers to the ITextRangeProvider interfaces of the text ranges, one for each selected span
		/// of text. This parameter is passed uninitialized.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// For UI Automation providers that support text selection, the provider should implement this method and also return a
		/// ITextProvider::SupportedTextSelection value.
		/// </para>
		/// <para>If the control contains only a single span of selected text, the <c>pRetVal</c> array should contain a single text range.</para>
		/// <para>
		/// If the control contains a text insertion point but no text is selected, the <c>pRetVal</c> array should contain a degenerate
		/// (empty) text range at the position of the text insertion point.
		/// </para>
		/// <para>
		/// If the control contains no selected text, or if the control does not contain a text insertion point, set <c>pRetVal</c> to <c>NULL</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextprovider-getselection HRESULT
		// GetSelection( [out, retval] SAFEARRAY **pRetVal );
		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UNKNOWN)]
		new ITextRangeProvider[] GetSelection();

		/// <summary>
		/// Retrieves an array of disjoint text ranges from a text-based control where each text range represents a contiguous span of
		/// visible text.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>SAFEARRAY**</c></para>
		/// <para>
		/// Receives the address of an array of pointers to the ITextRangeProvider interfaces of the visible text ranges or an empty array. A
		/// <c>NULL</c> reference is never returned. This parameter is passed uninitialized.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the visible text consists of one contiguous span of text, the <c>pRetVal</c> array should contain a single text range that
		/// represents all of the visible text.
		/// </para>
		/// <para>
		/// If the visible text consists of multiple, disjoint spans of text, the <c>pRetVal</c> array should contain one text range for each
		/// visible span, beginning with the first visible span, and ending with the last visible span. Disjoint spans of visible text can
		/// occur when the content of a text-based control is partially obscured by an overlapping window or other object, or when a
		/// text-based control with multiple pages or columns has content that is partially scrolled out of view.
		/// </para>
		/// <para>
		/// <c>ITextProvider::GetVisibleRanges</c> should return a degenerate (empty) text range if no text is visible, if all text is
		/// scrolled out of view, or if the text-based control contains no text.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextprovider-getvisibleranges HRESULT
		// GetVisibleRanges( [out, retval] SAFEARRAY **pRetVal );
		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UNKNOWN)]
		new ITextRangeProvider[] GetVisibleRanges();

		/// <summary>
		/// Retrieves a text range that encloses the specified child element (for example, an image, hyperlink, or other embedded object).
		/// </summary>
		/// <param name="childElement">The UI Automation provider of the specified child element.</param>
		/// <returns>
		/// <para>The text range that encloses the child element.</para>
		/// <para>This range completely encloses the content of the child element such that:</para>
		/// <list type="number">
		/// <item>
		/// ITextRangeProvider::GetEnclosingElement returns the child element itself, or the innermost descendant of the child element that
		/// shares the same text range as the child element
		/// </item>
		/// <item>ITextRangeProvider::GetChildren returns children of the element from (1) that are completely enclosed within the range</item>
		/// <item>Both endpoints of the range are at the boundaries of the child element</item>
		/// </list>
		/// <para>This parameter is passed uninitialized.</para>
		/// </returns>
		new ITextRangeProvider RangeFromChild(IRawElementProviderSimple childElement);

		/// <summary>Returns the degenerate (empty) text range nearest to the specified screen coordinates.</summary>
		/// <param name="point">
		/// <para>Type: <c>UiaPoint</c></para>
		/// <para>The location in screen coordinates.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ITextRangeProvider**</c></para>
		/// <para>Receives a pointer to the degenerate (empty) text range nearest the specified location. This parameter is passed uninitialized.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A text range that encloses a child object is returned if the screen coordinates are within the coordinates of an image,
		/// hyperlink, or other embedded object.
		/// </para>
		/// <para>
		/// Because hidden text is not ignored by <c>ITextProvider::RangeFromPoint</c>, a degenerate range from the visible text closest to
		/// the given point is returned.
		/// </para>
		/// <para>The property never returns <c>NULL</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextprovider-rangefrompoint HRESULT
		// RangeFromPoint( [in] UiaPoint point, [out, retval] ITextRangeProvider **pRetVal );
		new ITextRangeProvider RangeFromPoint(UiaPoint point);

		/// <summary>
		/// <para>Retrieves a text range that encloses the main text of a document.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>Some auxiliary text such as headers, footnotes, or annotations may not be included.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextprovider-get_documentrange HRESULT
		// get_DocumentRange( ITextRangeProvider **pRetVal );
		new ITextRangeProvider DocumentRange { get; }

		/// <summary>
		/// <para>Retrieves a value that specifies the type of text selection that is supported by the control.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>[out]</para>
		/// <para>Type: <c>SupportedTextSelection*</c></para>
		/// <para>When this function returns, contains a pointer to the SupportedTextSelection object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextprovider-get_supportedtextselection
		// HRESULT get_SupportedTextSelection (SupportedTextSelection *pRetVal);
		new SupportedTextSelection SupportedTextSelection { get; }

		/// <summary>Returns the active composition.</summary>
		/// <returns>
		/// <para>Type: <c>ITextRangeProvider**</c></para>
		/// <para>Pointer to the range of the current conversion (none if there is no conversion).</para>
		/// </returns>
		/// <remarks>
		/// Follow the guidance given in TextEdit Control Pattern that describes how to implement this method and how to raise the related
		/// notification events.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itexteditprovider-getactivecomposition
		// HRESULT GetActiveComposition( [out, retval] ITextRangeProvider **pRetVal );
		ITextRangeProvider GetActiveComposition();

		/// <summary>Returns the current conversion target range.</summary>
		/// <returns>
		/// <para>Type: <c>ITextRangeProvider**</c></para>
		/// <para>Pointer to the conversion target range (none if there is no conversion).</para>
		/// </returns>
		/// <remarks>
		/// Follow the guidance given in TextEdit Control Pattern that describes how to implement this method and how to raise the related
		/// notification events.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itexteditprovider-getconversiontarget
		// HRESULT GetConversionTarget( [out, retval] ITextRangeProvider **pRetVal );
		ITextRangeProvider GetConversionTarget();
	}

	/// <summary>Provides access to controls that contain text.</summary>
	/// <remarks>Implemented on a Microsoft UI Automation provider that must support the Text control pattern.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-itextprovider
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.ITextProvider")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("3589c92c-63f3-4367-99bb-ada653b77cf2")]
	public interface ITextProvider
	{
		/// <summary>Retrieves a collection of text ranges that represents the currently selected text in a text-based control.</summary>
		/// <returns>
		/// <para>Type: <c>SAFEARRAY**</c></para>
		/// <para>
		/// Receives the address of an array of pointers to the ITextRangeProvider interfaces of the text ranges, one for each selected span
		/// of text. This parameter is passed uninitialized.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// For UI Automation providers that support text selection, the provider should implement this method and also return a
		/// ITextProvider::SupportedTextSelection value.
		/// </para>
		/// <para>If the control contains only a single span of selected text, the <c>pRetVal</c> array should contain a single text range.</para>
		/// <para>
		/// If the control contains a text insertion point but no text is selected, the <c>pRetVal</c> array should contain a degenerate
		/// (empty) text range at the position of the text insertion point.
		/// </para>
		/// <para>
		/// If the control contains no selected text, or if the control does not contain a text insertion point, set <c>pRetVal</c> to <c>NULL</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextprovider-getselection HRESULT
		// GetSelection( [out, retval] SAFEARRAY **pRetVal );
		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UNKNOWN)]
		ITextRangeProvider[] GetSelection();

		/// <summary>
		/// Retrieves an array of disjoint text ranges from a text-based control where each text range represents a contiguous span of
		/// visible text.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>SAFEARRAY**</c></para>
		/// <para>
		/// Receives the address of an array of pointers to the ITextRangeProvider interfaces of the visible text ranges or an empty array. A
		/// <c>NULL</c> reference is never returned. This parameter is passed uninitialized.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the visible text consists of one contiguous span of text, the <c>pRetVal</c> array should contain a single text range that
		/// represents all of the visible text.
		/// </para>
		/// <para>
		/// If the visible text consists of multiple, disjoint spans of text, the <c>pRetVal</c> array should contain one text range for each
		/// visible span, beginning with the first visible span, and ending with the last visible span. Disjoint spans of visible text can
		/// occur when the content of a text-based control is partially obscured by an overlapping window or other object, or when a
		/// text-based control with multiple pages or columns has content that is partially scrolled out of view.
		/// </para>
		/// <para>
		/// <c>ITextProvider::GetVisibleRanges</c> should return a degenerate (empty) text range if no text is visible, if all text is
		/// scrolled out of view, or if the text-based control contains no text.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextprovider-getvisibleranges HRESULT
		// GetVisibleRanges( [out, retval] SAFEARRAY **pRetVal );
		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UNKNOWN)]
		ITextRangeProvider[] GetVisibleRanges();

		/// <summary>
		/// Retrieves a text range that encloses the specified child element (for example, an image, hyperlink, or other embedded object).
		/// </summary>
		/// <param name="childElement">The UI Automation provider of the specified child element.</param>
		/// <returns>
		/// <para>The text range that encloses the child element.</para>
		/// <para>This range completely encloses the content of the child element such that:</para>
		/// <list type="number">
		/// <item>
		/// ITextRangeProvider::GetEnclosingElement returns the child element itself, or the innermost descendant of the child element that
		/// shares the same text range as the child element
		/// </item>
		/// <item>ITextRangeProvider::GetChildren returns children of the element from (1) that are completely enclosed within the range</item>
		/// <item>Both endpoints of the range are at the boundaries of the child element</item>
		/// </list>
		/// <para>This parameter is passed uninitialized.</para>
		/// </returns>
		ITextRangeProvider RangeFromChild(IRawElementProviderSimple childElement);

		/// <summary>Returns the degenerate (empty) text range nearest to the specified screen coordinates.</summary>
		/// <param name="point">
		/// <para>Type: <c>UiaPoint</c></para>
		/// <para>The location in screen coordinates.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ITextRangeProvider**</c></para>
		/// <para>Receives a pointer to the degenerate (empty) text range nearest the specified location. This parameter is passed uninitialized.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A text range that encloses a child object is returned if the screen coordinates are within the coordinates of an image,
		/// hyperlink, or other embedded object.
		/// </para>
		/// <para>
		/// Because hidden text is not ignored by <c>ITextProvider::RangeFromPoint</c>, a degenerate range from the visible text closest to
		/// the given point is returned.
		/// </para>
		/// <para>The property never returns <c>NULL</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextprovider-rangefrompoint HRESULT
		// RangeFromPoint( [in] UiaPoint point, [out, retval] ITextRangeProvider **pRetVal );
		ITextRangeProvider RangeFromPoint(UiaPoint point);

		/// <summary>
		/// <para>Retrieves a text range that encloses the main text of a document.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>Some auxiliary text such as headers, footnotes, or annotations may not be included.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextprovider-get_documentrange HRESULT
		// get_DocumentRange( ITextRangeProvider **pRetVal );
		ITextRangeProvider DocumentRange { get; }

		/// <summary>
		/// <para>Retrieves a value that specifies the type of text selection that is supported by the control.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>[out]</para>
		/// <para>Type: <c>SupportedTextSelection*</c></para>
		/// <para>When this function returns, contains a pointer to the SupportedTextSelection object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextprovider-get_supportedtextselection
		// HRESULT get_SupportedTextSelection (SupportedTextSelection *pRetVal);
		SupportedTextSelection SupportedTextSelection { get; }
	}

	/// <summary>
	/// Extends the ITextProvider interface to enable Microsoft UI Automation providers to expose textual content that is the target of an
	/// annotation, and information about a caret that belongs to the provider.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-itextprovider2
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.ITextProvider2")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0dc5e6ed-3e16-4bf1-8f9a-a979878bc195")]
	public interface ITextProvider2 : ITextProvider
	{
		/// <summary>Retrieves a collection of text ranges that represents the currently selected text in a text-based control.</summary>
		/// <returns>
		/// <para>Type: <c>SAFEARRAY**</c></para>
		/// <para>
		/// Receives the address of an array of pointers to the ITextRangeProvider interfaces of the text ranges, one for each selected span
		/// of text. This parameter is passed uninitialized.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// For UI Automation providers that support text selection, the provider should implement this method and also return a
		/// ITextProvider::SupportedTextSelection value.
		/// </para>
		/// <para>If the control contains only a single span of selected text, the <c>pRetVal</c> array should contain a single text range.</para>
		/// <para>
		/// If the control contains a text insertion point but no text is selected, the <c>pRetVal</c> array should contain a degenerate
		/// (empty) text range at the position of the text insertion point.
		/// </para>
		/// <para>
		/// If the control contains no selected text, or if the control does not contain a text insertion point, set <c>pRetVal</c> to <c>NULL</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextprovider-getselection HRESULT
		// GetSelection( [out, retval] SAFEARRAY **pRetVal );
		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UNKNOWN)]
		new ITextRangeProvider[] GetSelection();

		/// <summary>
		/// Retrieves an array of disjoint text ranges from a text-based control where each text range represents a contiguous span of
		/// visible text.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>SAFEARRAY**</c></para>
		/// <para>
		/// Receives the address of an array of pointers to the ITextRangeProvider interfaces of the visible text ranges or an empty array. A
		/// <c>NULL</c> reference is never returned. This parameter is passed uninitialized.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the visible text consists of one contiguous span of text, the <c>pRetVal</c> array should contain a single text range that
		/// represents all of the visible text.
		/// </para>
		/// <para>
		/// If the visible text consists of multiple, disjoint spans of text, the <c>pRetVal</c> array should contain one text range for each
		/// visible span, beginning with the first visible span, and ending with the last visible span. Disjoint spans of visible text can
		/// occur when the content of a text-based control is partially obscured by an overlapping window or other object, or when a
		/// text-based control with multiple pages or columns has content that is partially scrolled out of view.
		/// </para>
		/// <para>
		/// <c>ITextProvider::GetVisibleRanges</c> should return a degenerate (empty) text range if no text is visible, if all text is
		/// scrolled out of view, or if the text-based control contains no text.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextprovider-getvisibleranges HRESULT
		// GetVisibleRanges( [out, retval] SAFEARRAY **pRetVal );
		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UNKNOWN)]
		new ITextRangeProvider[] GetVisibleRanges();

		/// <summary>
		/// Retrieves a text range that encloses the specified child element (for example, an image, hyperlink, or other embedded object).
		/// </summary>
		/// <param name="childElement">The UI Automation provider of the specified child element.</param>
		/// <returns>
		/// <para>The text range that encloses the child element.</para>
		/// <para>This range completely encloses the content of the child element such that:</para>
		/// <list type="number">
		/// <item>
		/// ITextRangeProvider::GetEnclosingElement returns the child element itself, or the innermost descendant of the child element that
		/// shares the same text range as the child element
		/// </item>
		/// <item>ITextRangeProvider::GetChildren returns children of the element from (1) that are completely enclosed within the range</item>
		/// <item>Both endpoints of the range are at the boundaries of the child element</item>
		/// </list>
		/// <para>This parameter is passed uninitialized.</para>
		/// </returns>
		new ITextRangeProvider RangeFromChild(IRawElementProviderSimple childElement);

		/// <summary>Returns the degenerate (empty) text range nearest to the specified screen coordinates.</summary>
		/// <param name="point">
		/// <para>Type: <c>UiaPoint</c></para>
		/// <para>The location in screen coordinates.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ITextRangeProvider**</c></para>
		/// <para>Receives a pointer to the degenerate (empty) text range nearest the specified location. This parameter is passed uninitialized.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A text range that encloses a child object is returned if the screen coordinates are within the coordinates of an image,
		/// hyperlink, or other embedded object.
		/// </para>
		/// <para>
		/// Because hidden text is not ignored by <c>ITextProvider::RangeFromPoint</c>, a degenerate range from the visible text closest to
		/// the given point is returned.
		/// </para>
		/// <para>The property never returns <c>NULL</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextprovider-rangefrompoint HRESULT
		// RangeFromPoint( [in] UiaPoint point, [out, retval] ITextRangeProvider **pRetVal );
		new ITextRangeProvider RangeFromPoint(UiaPoint point);

		/// <summary>
		/// <para>Retrieves a text range that encloses the main text of a document.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>Some auxiliary text such as headers, footnotes, or annotations may not be included.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextprovider-get_documentrange HRESULT
		// get_DocumentRange( ITextRangeProvider **pRetVal );
		new ITextRangeProvider DocumentRange { get; }

		/// <summary>
		/// <para>Retrieves a value that specifies the type of text selection that is supported by the control.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>[out]</para>
		/// <para>Type: <c>SupportedTextSelection*</c></para>
		/// <para>When this function returns, contains a pointer to the SupportedTextSelection object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextprovider-get_supportedtextselection
		// HRESULT get_SupportedTextSelection (SupportedTextSelection *pRetVal);
		new SupportedTextSelection SupportedTextSelection { get; }

		/// <summary>
		/// Exposes a text range that contains the text that is the target of the annotation associated with the specified annotation element.
		/// </summary>
		/// <param name="annotationElement">
		/// <para>Type: <c>IRawElementProviderSimple*</c></para>
		/// <para>
		/// The provider for an element that implements the IAnnotationProvider interface. The annotation element is a sibling of the element
		/// that implements the ITextProvider2 interface for the document.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ITextRangeProvider**</c></para>
		/// <para>Receives a text range that contains the annotation target text.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextprovider2-rangefromannotation
		// HRESULT RangeFromAnnotation( [in] IRawElementProviderSimple *annotationElement, [out, retval] ITextRangeProvider **pRetVal );
		ITextRangeProvider RangeFromAnnotation(IRawElementProviderSimple annotationElement);

		/// <summary>Provides a zero-length text range at the location of the caret that belongs to the text-based control.</summary>
		/// <param name="isActive">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para><c>TRUE</c> if the text-based control that contains the caret has keyboard focus, otherwise <c>FALSE</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ITextRangeProvider**</c></para>
		/// <para>A text range that represents the current location of the caret that belongs to the text-based control.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the <c>isActive</c> parameter is <c>FALSE</c>, the caret that belongs to the text-based control might not be at the same
		/// location as the system caret.
		/// </para>
		/// <para>
		/// This method retrieves a text range that a client can use to find the bounding rectangle of the caret that belongs to the
		/// text-based control, or to find the text near the caret.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextprovider2-getcaretrange HRESULT
		// GetCaretRange( [out] BOOL *isActive, [out, retval] ITextRangeProvider **pRetVal );
		ITextRangeProvider GetCaretRange(out bool isActive);
	}

	/// <summary>Provides access to a span of continuous text in a text container that implements ITextProvider or ITextProvider2.</summary>
	/// <remarks>A range can represent an insertion point, a portion of text, or all of the text in a container.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-itextrangeprovider
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.ITextRangeProvider")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("5347ad7b-c355-46f8-aff5-909033582f63")]
	public interface ITextRangeProvider
	{
		/// <summary>
		/// Returns a new ITextRangeProvider identical to the original <c>ITextRangeProvider</c> and inheriting all properties of the original.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>ITextRangeProvider**</c></para>
		/// <para>Receives a pointer to the copy of the text range. A null reference is never returned. This parameter is passed uninitialized.</para>
		/// </returns>
		/// <remarks>The new range can be manipulated independently from the original.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextrangeprovider-clone HRESULT Clone(
		// [out, retval] ITextRangeProvider **pRetVal );
		ITextRangeProvider Clone();

		/// <summary>Retrieves a value that specifies whether this text range has the same endpoints as another text range.</summary>
		/// <param name="range">
		/// <para>Type: <c>ITextRangeProvider*</c></para>
		/// <para>The text range to compare with this one.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>Receives <c>TRUE</c> if the text ranges have the same endpoints, or <c>FALSE</c> if they do not.</para>
		/// </returns>
		/// <remarks>
		/// This method compares the endpoints of the two text ranges, not the text in the ranges. The ranges are identical if they share the
		/// same endpoints. If two text ranges have different endpoints, they are not identical even if the text in both ranges is exactly
		/// the same.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextrangeprovider-compare HRESULT
		// Compare( [in] ITextRangeProvider *range, [out, retval] BOOL *pRetVal );
		bool Compare(ITextRangeProvider range);

		/// <summary>Returns a value that specifies whether two text ranges have identical endpoints.</summary>
		/// <param name="endpoint"/>
		/// <param name="targetRange">
		/// <para>Type: <c>ITextRangeProvider*</c></para>
		/// <para>The text range to be compared.</para>
		/// </param>
		/// <param name="targetEndpoint"/>
		/// <returns>
		/// <para>Type: <c>int*</c></para>
		/// <para>Receives a value that indicates whether the two text ranges have identical endpoints. This parameter is passed uninitialized.</para>
		/// </returns>
		/// <remarks>
		/// <para>Returns a negative value if the caller's endpoint occurs earlier in the text than the target endpoint.</para>
		/// <para>Returns zero if the caller's endpoint is at the same location as the target endpoint.</para>
		/// <para>Returns a positive value if the caller's endpoint occurs later in the text than the target endpoint.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextrangeprovider-compareendpoints
		// HRESULT CompareEndpoints( TextPatternRangeEndpoint endpoint, [in] ITextRangeProvider *targetRange, TextPatternRangeEndpoint
		// targetEndpoint, [out, retval] int *pRetVal );
		int CompareEndpoints(TextPatternRangeEndpoint endpoint, ITextRangeProvider targetRange, TextPatternRangeEndpoint targetEndpoint);

		/// <summary>
		/// Normalizes the text range by the specified text unit. The range is expanded if it is smaller than the specified unit, or
		/// shortened if it is longer than the specified unit.
		/// </summary>
		/// <param name="unit">
		/// <para>Type: <c>TextUnit</c></para>
		/// <para>The type of text units, such as character, word, paragraph, and so on.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Client applications such as screen readers use this method to retrieve the full word, sentence, or paragraph that exists at the
		/// insertion point or caret position.
		/// </para>
		/// <para>
		/// Despite its name, the <c>ITextRangeProvider::ExpandToEnclosingUnit</c> method does not necessarily expand a text range. Instead,
		/// it "normalizes" a text range by moving the endpoints so that the range encompasses the specified text unit. The range is expanded
		/// if it is smaller than the specified unit, or shortened if it is longer than the specified unit. If the range is already an exact
		/// quantity of the specified units, it remains unchanged. It is critical that the <c>ExpandToEnclosingUnit</c> method always
		/// normalizes text ranges in a consistent manner; otherwise, other aspects of text range manipulation by text unit would be
		/// unpredictable. The following diagram shows how <c>ExpandToEnclosingUnit</c> normalizes a text range by moving the endpoints of
		/// the range.
		/// </para>
		/// <para>
		/// <c>ExpandToEnclosingUnit</c> defaults to the next largest text unit supported if the specified text unit is not supported by the
		/// control. The order, from smallest unit to largest, is as follows:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>Character</c></description>
		/// </item>
		/// <item>
		/// <description><c>Format</c></description>
		/// </item>
		/// <item>
		/// <description><c>Word</c></description>
		/// </item>
		/// <item>
		/// <description><c>Line</c></description>
		/// </item>
		/// <item>
		/// <description><c>Paragraph</c></description>
		/// </item>
		/// <item>
		/// <description><c>Page</c></description>
		/// </item>
		/// <item>
		/// <description><c>Document</c></description>
		/// </item>
		/// </list>
		/// <para><c>ExpandToEnclosingUnit</c> respects both visible and hidden text.</para>
		/// <para>Range behavior when <c>unit</c> is</para>
		/// <para>
		/// as a <c>unit</c> value positions the boundary of a text range to expand or move the range based on shared text attributes
		/// (format) of the text within the range. However, using the format text unit should not move or expand a text range across the
		/// boundary of an embedded object, such as an image or hyperlink. For more info, see UI Automation Text Units or Text and TextRange
		/// Control Patterns.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextrangeprovider-expandtoenclosingunit
		// HRESULT ExpandToEnclosingUnit( [in] TextUnit unit );
		void ExpandToEnclosingUnit(TextUnit unit);

		/// <summary>Returns a text range subset that has the specified text attribute value.</summary>
		/// <param name="attributeId">
		/// <para>Type: <c>TEXTATTRIBUTEID</c></para>
		/// <para>The identifier of the text attribute. For a list of text attribute IDs, see Text Attribute Identifiers.</para>
		/// </param>
		/// <param name="val">
		/// <para>Type: <c>VARIANT</c></para>
		/// <para>The attribute value to search for. This value must match the type specified for the attribute.</para>
		/// </param>
		/// <param name="backward">
		/// <para>Type: <c>BOOL</c></para>
		/// <para><c>TRUE</c> if the last occurring text range should be returned instead of the first; otherwise <c>FALSE</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ITextRangeProvider**</c></para>
		/// <para>Receives a pointer to the text range having a matching attribute and attribute value; otherwise <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// The <c>FindAttribute</c> method retrieves matching text regardless of whether the text is hidden or visible. Clients can use
		/// UIA_IsHiddenAttributeId to check text visibility.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextrangeprovider-findattribute HRESULT
		// FindAttribute( [in] TEXTATTRIBUTEID attributeId, [in] VARIANT val, [in] BOOL backward, [out, retval] ITextRangeProvider **pRetVal );
		ITextRangeProvider FindAttribute(UIAutomationClient.TEXTATTRIBUTEID attributeId, object val, bool backward);

		/// <summary>Returns a text range subset that contains the specified text.</summary>
		/// <param name="text">
		/// <para>Type: <c>BSTR</c></para>
		/// <para>The text string to search for.</para>
		/// </param>
		/// <param name="backward">
		/// <para>Type: <c>BOOL</c></para>
		/// <para><c>TRUE</c> if the last occurring text range should be returned instead of the first; otherwise <c>FALSE</c>.</para>
		/// </param>
		/// <param name="ignoreCase">
		/// <para>Type: <c>BOOL</c></para>
		/// <para><c>TRUE</c> if case should be ignored; otherwise <c>FALSE</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ITextRangeProvider**</c></para>
		/// <para>Receives a pointer to the text range matching the specified text; otherwise <c>NULL</c>. This parameter is passed uninitialized.</para>
		/// </returns>
		/// <remarks>There is no differentiation between hidden and visible text.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextrangeprovider-findtext HRESULT
		// FindText( [in] BSTR text, [in] BOOL backward, [in] BOOL ignoreCase, [out, retval] ITextRangeProvider **pRetVal );
		ITextRangeProvider FindText([In, MarshalAs(UnmanagedType.BStr)] string text, bool backward, bool ignoreCase);

		/// <summary>Retrieves the value of the specified text attribute across the text range.</summary>
		/// <param name="attributeId">
		/// <para>Type: <c>TEXTATTRIBUTEID</c></para>
		/// <para>The identifier of the text attribute. For a list of text attribute IDs, see Text Attribute Identifiers.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>VARIANT*</c></para>
		/// <para>Receives one of the following.</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// The address of an object representing the value of the specified attribute. The data type of the value varies depending on the
		/// specified attribute. For example, if <c>attributeId</c> is UIA_FontNameAttributeId, <c>GetAttributeValue</c> returns a string
		/// that represents the font name of the text range, but if <c>attributeId</c> is UIA_IsItalicAttributeId, <c>GetAttributeValue</c>
		/// returns a boolean.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// The address of the value retrieved by the UiaGetReservedMixedAttributeValue function, if the value of the specified attribute
		/// varies over the text range.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// The address of the value retrieved by the UiaGetReservedNotSupportedValue function, if the specified attribute is not supported
		/// by the provider or the control.
		/// </description>
		/// </item>
		/// </list>
		/// <para>This parameter is passed uninitialized.</para>
		/// </returns>
		/// <remarks>
		/// The <c>GetAttributeValue</c> method should retrieve the attribute value regardless of whether the text is hidden or visible.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextrangeprovider-getattributevalue
		// HRESULT GetAttributeValue( [in] TEXTATTRIBUTEID attributeId, [out, retval] VARIANT *pRetVal );
		object GetAttributeValue(UIAutomationClient.TEXTATTRIBUTEID attributeId);

		/// <summary>Retrieves a collection of bounding rectangles for each fully or partially visible line of text in a text range.</summary>
		/// <returns>
		/// <para>Type: <c>SAFEARRAY**</c></para>
		/// <para>Receives a pointer to one of the following.</para>
		/// <list type="bullet">
		/// <item>
		/// <description>An array of bounding rectangles for each full or partial line of text in a text range.</description>
		/// </item>
		/// <item>
		/// <description>An empty array for a degenerate range.</description>
		/// </item>
		/// <item>
		/// <description>
		/// An empty array for a text range that has screen coordinates placing it completely off-screen, scrolled out of view, or obscured
		/// by an overlapping window.
		/// </description>
		/// </item>
		/// </list>
		/// <para>This parameter is passed uninitialized.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextrangeprovider-getboundingrectangles
		// HRESULT GetBoundingRectangles( [out, retval] SAFEARRAY **pRetVal );
		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R8)]
		double[] GetBoundingRectangles();

		/// <summary>Returns the innermost element that encloses the specified text range.</summary>
		/// <returns>
		/// <para>The UI Automation provider of the innermost element that encloses the specified ITextRangeProvider.</para>
		/// <para><note type="note">The enclosing element can span more than just the specified ITextRangeProvider.</note></para>
		/// <para>If no enclosing element is found, the ITextProvider parent of the ITextRangeProvider is returned.</para>
		/// <para>This parameter is passed uninitialized.</para>
		/// </returns>
		IRawElementProviderSimple GetEnclosingElement();

		/// <summary>Retrieves the plain text of the range.</summary>
		/// <param name="maxLength">
		/// <para>Type: <c>int</c></para>
		/// <para>The maximum length of the string to return. Use -1 if no limit is required.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BSTR*</c></para>
		/// <para>
		/// Receives the plain text of the text range, possibly truncated at the specified maximum length. This parameter is passed uninitialized.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para><c>ITextRangeProvider::GetText</c> retrieves both hidden and visible text.</para>
		/// <para>
		/// If <c>maxLength</c> is greater than the length of the text span of the caller, the string returned will be the plain text of the
		/// text range.
		/// </para>
		/// <para>
		/// <c>ITextRangeProvider::GetText</c> will not be affected by the order of endpoints in the text flow; it will always return the
		/// text between the start and end endpoints of the text range in the logical text flow order.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextrangeprovider-gettext HRESULT
		// GetText( [in] int maxLength, [out, retval] BSTR *pRetVal );
		[return: MarshalAs(UnmanagedType.BStr)]
		string GetText(int maxLength);

		/// <summary>Moves the text range forward or backward by the specified number of text units.</summary>
		/// <param name="unit"/>
		/// <param name="count">
		/// <para>Type: <c>int</c></para>
		/// <para>The number of text units to move. A positive value moves the text range forward.</para>
		/// <para>A negative value moves the text range backward. Zero has no effect.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>int*</c></para>
		/// <para>
		/// The number of text units actually moved. This can be less than the number requested if either of the new text range endpoints is
		/// greater than or less than the endpoints retrieved by the ITextProvider::DocumentRange method. This value can be negative if
		/// navigation is happening in the backward direction.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>ITextRangeProvider::Move</c> should only move the text range to span a different part of the text, it should not alter the
		/// text in any way.
		/// </para>
		/// <para>
		/// For a non-degenerate (non-empty) text range, <c>ITextRangeProvider::Move</c> should normalize and move the text range by
		/// performing the following steps.
		/// </para>
		/// <list type="number">
		/// <item>
		/// <description>Collapse the text range to a degenerate (empty) range at the starting endpoint.</description>
		/// </item>
		/// <item>
		/// <description>
		/// If necessary, move the resulting text range backward in the document to the beginning of the requested unit boundary.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Move the text range forward or backward in the document by the requested number of text unit boundaries.</description>
		/// </item>
		/// <item>
		/// <description>
		/// Expand the text range from the degenerate state by moving the ending endpoint forward by one requested text unit boundary.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// If any of the preceding steps fail, the text range should be left unchanged. If the text range cannot be moved as far as the
		/// requested number of text units, but can be moved by a smaller number of text units, the text range should be moved by the smaller
		/// number of text units and <c>pRetVal</c> should be set to the number of text units moved successfully.
		/// </para>
		/// <para>
		/// For a degenerate text range, <c>ITextRangeProvider::Move</c> should simply move the text insertion point by the specified number
		/// of text units.
		/// </para>
		/// <para>When moving a text range, the provider should ignore the boundaries of any embedded objects in the text.</para>
		/// <para><c>ITextRangeProvider::Move</c> should respect both hidden and visible text.</para>
		/// <para>
		/// If a text-based control does not support the text unit specified by the <c>unit</c> parameter, the provider should substitute the
		/// next larger supported text unit.
		/// </para>
		/// <para>The size of the text units, from smallest unit to largest, is as follows.</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Character</description>
		/// </item>
		/// <item>
		/// <description>Format</description>
		/// </item>
		/// <item>
		/// <description>Word</description>
		/// </item>
		/// <item>
		/// <description>Line</description>
		/// </item>
		/// <item>
		/// <description>Paragraph</description>
		/// </item>
		/// <item>
		/// <description>Page</description>
		/// </item>
		/// <item>
		/// <description>Document</description>
		/// </item>
		/// </list>
		/// <para>Range behavior when <c>unit</c> is</para>
		/// <para>
		/// as a <c>unit</c> value positions the boundary of a text range to expand or move the range based on shared text attributes
		/// (format) of the text within the range. However, using the format text unit should not move or expand a text range across the
		/// boundary of an embedded object, such as an image or hyperlink. For more info, see UI Automation Text Units or Text and TextRange
		/// Control Patterns.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextrangeprovider-move HRESULT Move(
		// TextUnit unit, [in] int count, [out, retval] int *pRetVal );
		int Move(TextUnit unit, int count);

		/// <summary>Moves one endpoint of the text range the specified number of TextUnit units within the document range.</summary>
		/// <param name="endpoint"/>
		/// <param name="unit"/>
		/// <param name="count">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The number of units to move. A positive value moves the endpoint forward. A negative value moves backward. A value of 0 has no effect.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>int*</c></para>
		/// <para>
		/// Receives the number of units actually moved, which can be less than the number requested if moving the endpoint runs into the
		/// beginning or end of the document.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The endpoint is moved forward or backward, as specified, to the next available unit boundary. If the original <c>endpoint</c> was
		/// at the boundary of the specified text unit, the <c>endpoint</c> is moved to the next available text unit boundary, as shown in
		/// the following illustration.
		/// </para>
		/// <para>
		/// If the endpoint being moved crosses the other <c>endpoint</c> of the same text range, the other <c>endpoint</c> is also moved,
		/// resulting in a degenerate range and ensuring the correct ordering of the <c>endpoint</c> (that is, that the start is always less
		/// than or equal to the end).
		/// </para>
		/// <para>
		/// <c>ITextRangeProvider::MoveEndpointByUnit</c> deprecates up to the next supported text unit if the given text unit is not
		/// supported by the control.
		/// </para>
		/// <para>The order, from smallest unit to largest, is listed here.</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>Character</c></description>
		/// </item>
		/// <item>
		/// <description><c>Format</c></description>
		/// </item>
		/// <item>
		/// <description><c>Word</c></description>
		/// </item>
		/// <item>
		/// <description><c>Line</c></description>
		/// </item>
		/// <item>
		/// <description><c>Paragraph</c></description>
		/// </item>
		/// <item>
		/// <description><c>Page</c></description>
		/// </item>
		/// <item>
		/// <description><c>Document</c></description>
		/// </item>
		/// </list>
		/// <para>Range behavior when <c>unit</c> is</para>
		/// <para>
		/// as a <c>unit</c> value positions the boundary of a text range to expand or move the range based on shared text attributes
		/// (format) of the text within the range. However, using the format text unit should not move or expand a text range across the
		/// boundary of an embedded object, such as an image or hyperlink. For more info, see UI Automation Text Units or Text and TextRange
		/// Control Patterns.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextrangeprovider-moveendpointbyunit
		// HRESULT MoveEndpointByUnit( TextPatternRangeEndpoint endpoint, TextUnit unit, [in] int count, [out, retval] int *pRetVal );
		int MoveEndpointByUnit(TextPatternRangeEndpoint endpoint, TextUnit unit, int count);

		/// <summary>Moves one endpoint of the current text range to the specified endpoint of a second text range.</summary>
		/// <param name="endpoint"/>
		/// <param name="targetRange">
		/// <para>Type: <c>ITextRangeProvider*</c></para>
		/// <para>A second text range from the same text provider as the current text range.</para>
		/// </param>
		/// <param name="targetEndpoint"/>
		/// <remarks>
		/// If the endpoint being moved crosses the other endpoint of the same text range, that other endpoint is moved also, resulting in a
		/// degenerate (empty) range and ensuring the correct ordering of the endpoints (that is, the start is always less than or equal to
		/// the end).
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextrangeprovider-moveendpointbyrange
		// HRESULT MoveEndpointByRange( TextPatternRangeEndpoint endpoint, [in] ITextRangeProvider *targetRange, TextPatternRangeEndpoint
		// targetEndpoint );
		void MoveEndpointByRange(TextPatternRangeEndpoint endpoint, ITextRangeProvider targetRange, TextPatternRangeEndpoint targetEndpoint);

		/// <summary>Selects the span of text that corresponds to this text range, and removes any previous selection.</summary>
		/// <remarks>Providing a degenerate text range will move the text insertion point.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextrangeprovider-select HRESULT Select();
		void Select();

		/// <summary>
		/// Adds the text range to the collection of selected text ranges in a control that supports multiple, disjoint spans of selected text.
		/// </summary>
		/// <remarks>
		/// <para>The text insertion point moves to the area of the new selection.</para>
		/// <para>
		/// If this method is called on a degenerate text range, the text insertion point moves to the location of the text range but no text
		/// is selected.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextrangeprovider-addtoselection HRESULT AddToSelection();
		void AddToSelection();

		/// <summary>
		/// Removes the text range from the collection of selected text ranges in a control that supports multiple, disjoint spans of
		/// selected text.
		/// </summary>
		/// <remarks>
		/// <para>The text insertion point moves to the area of the removed selection.</para>
		/// <para>
		/// If this method is called on a degenerate text range, the text insertion point moves to the location of the text range but no text
		/// is selected.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextrangeprovider-removefromselection
		// HRESULT RemoveFromSelection();
		void RemoveFromSelection();

		/// <summary>Causes the text control to scroll vertically until the text range is visible in the viewport.</summary>
		/// <param name="alignToTop">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// TRUE if the text control should be scrolled so the text range is flush with the top of the viewport; FALSE if it should be flush
		/// with the bottom of the viewport.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para><c>ITextRangeProvider::ScrollIntoView</c> respects both hidden and visible text.</para>
		/// <para>If the text range is hidden, the text control will scroll only if the hidden text has an anchor in the viewport.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextrangeprovider-scrollintoview HRESULT
		// ScrollIntoView( [in] BOOL alignToTop );
		void ScrollIntoView(bool alignToTop);

		/// <summary>
		/// Retrieves a collection of all elements that are both contained (either partially or completely) within the specified text range,
		/// and are child elements of the enclosing element for the specified text range.
		/// </summary>
		/// <returns>
		/// <para>
		/// An array of pointers to the IRawElementProviderSimple interfaces for all child elements that are enclosed by the text range
		/// (sorted by the Start endpoint of their ranges).
		/// </para>
		/// <para>If the text range does not include any child elements, an empty collection is returned.</para>
		/// <para>This parameter is passed uninitialized.</para>
		/// </returns>
		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UNKNOWN)]
		IRawElementProviderSimple[] GetChildren();
	}

	/// <summary>Extends the ITextRangeProvider interface to enable Microsoft UI Automation providers to invoke context menus.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-itextrangeprovider2
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.ITextRangeProvider2")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("9bbce42c-1921-4f18-89ca-dba1910a0386")]
	public interface ITextRangeProvider2 : ITextRangeProvider
	{
		/// <summary>
		/// Returns a new ITextRangeProvider identical to the original <c>ITextRangeProvider</c> and inheriting all properties of the original.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>ITextRangeProvider**</c></para>
		/// <para>Receives a pointer to the copy of the text range. A null reference is never returned. This parameter is passed uninitialized.</para>
		/// </returns>
		/// <remarks>The new range can be manipulated independently from the original.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextrangeprovider-clone HRESULT Clone(
		// [out, retval] ITextRangeProvider **pRetVal );
		new ITextRangeProvider Clone();

		/// <summary>Retrieves a value that specifies whether this text range has the same endpoints as another text range.</summary>
		/// <param name="range">
		/// <para>Type: <c>ITextRangeProvider*</c></para>
		/// <para>The text range to compare with this one.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>Receives <c>TRUE</c> if the text ranges have the same endpoints, or <c>FALSE</c> if they do not.</para>
		/// </returns>
		/// <remarks>
		/// This method compares the endpoints of the two text ranges, not the text in the ranges. The ranges are identical if they share the
		/// same endpoints. If two text ranges have different endpoints, they are not identical even if the text in both ranges is exactly
		/// the same.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextrangeprovider-compare HRESULT
		// Compare( [in] ITextRangeProvider *range, [out, retval] BOOL *pRetVal );
		new bool Compare(ITextRangeProvider range);

		/// <summary>Returns a value that specifies whether two text ranges have identical endpoints.</summary>
		/// <param name="endpoint"/>
		/// <param name="targetRange">
		/// <para>Type: <c>ITextRangeProvider*</c></para>
		/// <para>The text range to be compared.</para>
		/// </param>
		/// <param name="targetEndpoint"/>
		/// <returns>
		/// <para>Type: <c>int*</c></para>
		/// <para>Receives a value that indicates whether the two text ranges have identical endpoints. This parameter is passed uninitialized.</para>
		/// </returns>
		/// <remarks>
		/// <para>Returns a negative value if the caller's endpoint occurs earlier in the text than the target endpoint.</para>
		/// <para>Returns zero if the caller's endpoint is at the same location as the target endpoint.</para>
		/// <para>Returns a positive value if the caller's endpoint occurs later in the text than the target endpoint.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextrangeprovider-compareendpoints
		// HRESULT CompareEndpoints( TextPatternRangeEndpoint endpoint, [in] ITextRangeProvider *targetRange, TextPatternRangeEndpoint
		// targetEndpoint, [out, retval] int *pRetVal );
		new int CompareEndpoints(TextPatternRangeEndpoint endpoint, ITextRangeProvider targetRange, TextPatternRangeEndpoint targetEndpoint);

		/// <summary>
		/// Normalizes the text range by the specified text unit. The range is expanded if it is smaller than the specified unit, or
		/// shortened if it is longer than the specified unit.
		/// </summary>
		/// <param name="unit">
		/// <para>Type: <c>TextUnit</c></para>
		/// <para>The type of text units, such as character, word, paragraph, and so on.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Client applications such as screen readers use this method to retrieve the full word, sentence, or paragraph that exists at the
		/// insertion point or caret position.
		/// </para>
		/// <para>
		/// Despite its name, the <c>ITextRangeProvider::ExpandToEnclosingUnit</c> method does not necessarily expand a text range. Instead,
		/// it "normalizes" a text range by moving the endpoints so that the range encompasses the specified text unit. The range is expanded
		/// if it is smaller than the specified unit, or shortened if it is longer than the specified unit. If the range is already an exact
		/// quantity of the specified units, it remains unchanged. It is critical that the <c>ExpandToEnclosingUnit</c> method always
		/// normalizes text ranges in a consistent manner; otherwise, other aspects of text range manipulation by text unit would be
		/// unpredictable. The following diagram shows how <c>ExpandToEnclosingUnit</c> normalizes a text range by moving the endpoints of
		/// the range.
		/// </para>
		/// <para>
		/// <c>ExpandToEnclosingUnit</c> defaults to the next largest text unit supported if the specified text unit is not supported by the
		/// control. The order, from smallest unit to largest, is as follows:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>Character</c></description>
		/// </item>
		/// <item>
		/// <description><c>Format</c></description>
		/// </item>
		/// <item>
		/// <description><c>Word</c></description>
		/// </item>
		/// <item>
		/// <description><c>Line</c></description>
		/// </item>
		/// <item>
		/// <description><c>Paragraph</c></description>
		/// </item>
		/// <item>
		/// <description><c>Page</c></description>
		/// </item>
		/// <item>
		/// <description><c>Document</c></description>
		/// </item>
		/// </list>
		/// <para><c>ExpandToEnclosingUnit</c> respects both visible and hidden text.</para>
		/// <para>Range behavior when <c>unit</c> is</para>
		/// <para>
		/// as a <c>unit</c> value positions the boundary of a text range to expand or move the range based on shared text attributes
		/// (format) of the text within the range. However, using the format text unit should not move or expand a text range across the
		/// boundary of an embedded object, such as an image or hyperlink. For more info, see UI Automation Text Units or Text and TextRange
		/// Control Patterns.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextrangeprovider-expandtoenclosingunit
		// HRESULT ExpandToEnclosingUnit( [in] TextUnit unit );
		new void ExpandToEnclosingUnit(TextUnit unit);

		/// <summary>Returns a text range subset that has the specified text attribute value.</summary>
		/// <param name="attributeId">
		/// <para>Type: <c>TEXTATTRIBUTEID</c></para>
		/// <para>The identifier of the text attribute. For a list of text attribute IDs, see Text Attribute Identifiers.</para>
		/// </param>
		/// <param name="val">
		/// <para>Type: <c>VARIANT</c></para>
		/// <para>The attribute value to search for. This value must match the type specified for the attribute.</para>
		/// </param>
		/// <param name="backward">
		/// <para>Type: <c>BOOL</c></para>
		/// <para><c>TRUE</c> if the last occurring text range should be returned instead of the first; otherwise <c>FALSE</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ITextRangeProvider**</c></para>
		/// <para>Receives a pointer to the text range having a matching attribute and attribute value; otherwise <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// The <c>FindAttribute</c> method retrieves matching text regardless of whether the text is hidden or visible. Clients can use
		/// UIA_IsHiddenAttributeId to check text visibility.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextrangeprovider-findattribute HRESULT
		// FindAttribute( [in] TEXTATTRIBUTEID attributeId, [in] VARIANT val, [in] BOOL backward, [out, retval] ITextRangeProvider **pRetVal );
		new ITextRangeProvider FindAttribute(UIAutomationClient.TEXTATTRIBUTEID attributeId, object val, bool backward);

		/// <summary>Returns a text range subset that contains the specified text.</summary>
		/// <param name="text">
		/// <para>Type: <c>BSTR</c></para>
		/// <para>The text string to search for.</para>
		/// </param>
		/// <param name="backward">
		/// <para>Type: <c>BOOL</c></para>
		/// <para><c>TRUE</c> if the last occurring text range should be returned instead of the first; otherwise <c>FALSE</c>.</para>
		/// </param>
		/// <param name="ignoreCase">
		/// <para>Type: <c>BOOL</c></para>
		/// <para><c>TRUE</c> if case should be ignored; otherwise <c>FALSE</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ITextRangeProvider**</c></para>
		/// <para>Receives a pointer to the text range matching the specified text; otherwise <c>NULL</c>. This parameter is passed uninitialized.</para>
		/// </returns>
		/// <remarks>There is no differentiation between hidden and visible text.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextrangeprovider-findtext HRESULT
		// FindText( [in] BSTR text, [in] BOOL backward, [in] BOOL ignoreCase, [out, retval] ITextRangeProvider **pRetVal );
		new ITextRangeProvider FindText([In, MarshalAs(UnmanagedType.BStr)] string text, bool backward, bool ignoreCase);

		/// <summary>Retrieves the value of the specified text attribute across the text range.</summary>
		/// <param name="attributeId">
		/// <para>Type: <c>TEXTATTRIBUTEID</c></para>
		/// <para>The identifier of the text attribute. For a list of text attribute IDs, see Text Attribute Identifiers.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>VARIANT*</c></para>
		/// <para>Receives one of the following.</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// The address of an object representing the value of the specified attribute. The data type of the value varies depending on the
		/// specified attribute. For example, if <c>attributeId</c> is UIA_FontNameAttributeId, <c>GetAttributeValue</c> returns a string
		/// that represents the font name of the text range, but if <c>attributeId</c> is UIA_IsItalicAttributeId, <c>GetAttributeValue</c>
		/// returns a boolean.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// The address of the value retrieved by the UiaGetReservedMixedAttributeValue function, if the value of the specified attribute
		/// varies over the text range.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// The address of the value retrieved by the UiaGetReservedNotSupportedValue function, if the specified attribute is not supported
		/// by the provider or the control.
		/// </description>
		/// </item>
		/// </list>
		/// <para>This parameter is passed uninitialized.</para>
		/// </returns>
		/// <remarks>
		/// The <c>GetAttributeValue</c> method should retrieve the attribute value regardless of whether the text is hidden or visible.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextrangeprovider-getattributevalue
		// HRESULT GetAttributeValue( [in] TEXTATTRIBUTEID attributeId, [out, retval] VARIANT *pRetVal );
		new object GetAttributeValue(UIAutomationClient.TEXTATTRIBUTEID attributeId);

		/// <summary>Retrieves a collection of bounding rectangles for each fully or partially visible line of text in a text range.</summary>
		/// <returns>
		/// <para>Type: <c>SAFEARRAY**</c></para>
		/// <para>Receives a pointer to one of the following.</para>
		/// <list type="bullet">
		/// <item>
		/// <description>An array of bounding rectangles for each full or partial line of text in a text range.</description>
		/// </item>
		/// <item>
		/// <description>An empty array for a degenerate range.</description>
		/// </item>
		/// <item>
		/// <description>
		/// An empty array for a text range that has screen coordinates placing it completely off-screen, scrolled out of view, or obscured
		/// by an overlapping window.
		/// </description>
		/// </item>
		/// </list>
		/// <para>This parameter is passed uninitialized.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextrangeprovider-getboundingrectangles
		// HRESULT GetBoundingRectangles( [out, retval] SAFEARRAY **pRetVal );
		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R8)]
		new double[] GetBoundingRectangles();

		/// <summary>Returns the innermost element that encloses the specified text range.</summary>
		/// <returns>
		/// <para>The UI Automation provider of the innermost element that encloses the specified ITextRangeProvider.</para>
		/// <para><note type="note">The enclosing element can span more than just the specified ITextRangeProvider.</note></para>
		/// <para>If no enclosing element is found, the ITextProvider parent of the ITextRangeProvider is returned.</para>
		/// <para>This parameter is passed uninitialized.</para>
		/// </returns>
		new IRawElementProviderSimple GetEnclosingElement();

		/// <summary>Retrieves the plain text of the range.</summary>
		/// <param name="maxLength">
		/// <para>Type: <c>int</c></para>
		/// <para>The maximum length of the string to return. Use -1 if no limit is required.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BSTR*</c></para>
		/// <para>
		/// Receives the plain text of the text range, possibly truncated at the specified maximum length. This parameter is passed uninitialized.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para><c>ITextRangeProvider::GetText</c> retrieves both hidden and visible text.</para>
		/// <para>
		/// If <c>maxLength</c> is greater than the length of the text span of the caller, the string returned will be the plain text of the
		/// text range.
		/// </para>
		/// <para>
		/// <c>ITextRangeProvider::GetText</c> will not be affected by the order of endpoints in the text flow; it will always return the
		/// text between the start and end endpoints of the text range in the logical text flow order.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextrangeprovider-gettext HRESULT
		// GetText( [in] int maxLength, [out, retval] BSTR *pRetVal );
		[return: MarshalAs(UnmanagedType.BStr)]
		new string GetText(int maxLength);

		/// <summary>Moves the text range forward or backward by the specified number of text units.</summary>
		/// <param name="unit"/>
		/// <param name="count">
		/// <para>Type: <c>int</c></para>
		/// <para>The number of text units to move. A positive value moves the text range forward.</para>
		/// <para>A negative value moves the text range backward. Zero has no effect.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>int*</c></para>
		/// <para>
		/// The number of text units actually moved. This can be less than the number requested if either of the new text range endpoints is
		/// greater than or less than the endpoints retrieved by the ITextProvider::DocumentRange method. This value can be negative if
		/// navigation is happening in the backward direction.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>ITextRangeProvider::Move</c> should only move the text range to span a different part of the text, it should not alter the
		/// text in any way.
		/// </para>
		/// <para>
		/// For a non-degenerate (non-empty) text range, <c>ITextRangeProvider::Move</c> should normalize and move the text range by
		/// performing the following steps.
		/// </para>
		/// <list type="number">
		/// <item>
		/// <description>Collapse the text range to a degenerate (empty) range at the starting endpoint.</description>
		/// </item>
		/// <item>
		/// <description>
		/// If necessary, move the resulting text range backward in the document to the beginning of the requested unit boundary.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Move the text range forward or backward in the document by the requested number of text unit boundaries.</description>
		/// </item>
		/// <item>
		/// <description>
		/// Expand the text range from the degenerate state by moving the ending endpoint forward by one requested text unit boundary.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// If any of the preceding steps fail, the text range should be left unchanged. If the text range cannot be moved as far as the
		/// requested number of text units, but can be moved by a smaller number of text units, the text range should be moved by the smaller
		/// number of text units and <c>pRetVal</c> should be set to the number of text units moved successfully.
		/// </para>
		/// <para>
		/// For a degenerate text range, <c>ITextRangeProvider::Move</c> should simply move the text insertion point by the specified number
		/// of text units.
		/// </para>
		/// <para>When moving a text range, the provider should ignore the boundaries of any embedded objects in the text.</para>
		/// <para><c>ITextRangeProvider::Move</c> should respect both hidden and visible text.</para>
		/// <para>
		/// If a text-based control does not support the text unit specified by the <c>unit</c> parameter, the provider should substitute the
		/// next larger supported text unit.
		/// </para>
		/// <para>The size of the text units, from smallest unit to largest, is as follows.</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Character</description>
		/// </item>
		/// <item>
		/// <description>Format</description>
		/// </item>
		/// <item>
		/// <description>Word</description>
		/// </item>
		/// <item>
		/// <description>Line</description>
		/// </item>
		/// <item>
		/// <description>Paragraph</description>
		/// </item>
		/// <item>
		/// <description>Page</description>
		/// </item>
		/// <item>
		/// <description>Document</description>
		/// </item>
		/// </list>
		/// <para>Range behavior when <c>unit</c> is</para>
		/// <para>
		/// as a <c>unit</c> value positions the boundary of a text range to expand or move the range based on shared text attributes
		/// (format) of the text within the range. However, using the format text unit should not move or expand a text range across the
		/// boundary of an embedded object, such as an image or hyperlink. For more info, see UI Automation Text Units or Text and TextRange
		/// Control Patterns.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextrangeprovider-move HRESULT Move(
		// TextUnit unit, [in] int count, [out, retval] int *pRetVal );
		new int Move(TextUnit unit, int count);

		/// <summary>Moves one endpoint of the text range the specified number of TextUnit units within the document range.</summary>
		/// <param name="endpoint"/>
		/// <param name="unit"/>
		/// <param name="count">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The number of units to move. A positive value moves the endpoint forward. A negative value moves backward. A value of 0 has no effect.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>int*</c></para>
		/// <para>
		/// Receives the number of units actually moved, which can be less than the number requested if moving the endpoint runs into the
		/// beginning or end of the document.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The endpoint is moved forward or backward, as specified, to the next available unit boundary. If the original <c>endpoint</c> was
		/// at the boundary of the specified text unit, the <c>endpoint</c> is moved to the next available text unit boundary, as shown in
		/// the following illustration.
		/// </para>
		/// <para>
		/// If the endpoint being moved crosses the other <c>endpoint</c> of the same text range, the other <c>endpoint</c> is also moved,
		/// resulting in a degenerate range and ensuring the correct ordering of the <c>endpoint</c> (that is, that the start is always less
		/// than or equal to the end).
		/// </para>
		/// <para>
		/// <c>ITextRangeProvider::MoveEndpointByUnit</c> deprecates up to the next supported text unit if the given text unit is not
		/// supported by the control.
		/// </para>
		/// <para>The order, from smallest unit to largest, is listed here.</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>Character</c></description>
		/// </item>
		/// <item>
		/// <description><c>Format</c></description>
		/// </item>
		/// <item>
		/// <description><c>Word</c></description>
		/// </item>
		/// <item>
		/// <description><c>Line</c></description>
		/// </item>
		/// <item>
		/// <description><c>Paragraph</c></description>
		/// </item>
		/// <item>
		/// <description><c>Page</c></description>
		/// </item>
		/// <item>
		/// <description><c>Document</c></description>
		/// </item>
		/// </list>
		/// <para>Range behavior when <c>unit</c> is</para>
		/// <para>
		/// as a <c>unit</c> value positions the boundary of a text range to expand or move the range based on shared text attributes
		/// (format) of the text within the range. However, using the format text unit should not move or expand a text range across the
		/// boundary of an embedded object, such as an image or hyperlink. For more info, see UI Automation Text Units or Text and TextRange
		/// Control Patterns.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextrangeprovider-moveendpointbyunit
		// HRESULT MoveEndpointByUnit( TextPatternRangeEndpoint endpoint, TextUnit unit, [in] int count, [out, retval] int *pRetVal );
		new int MoveEndpointByUnit(TextPatternRangeEndpoint endpoint, TextUnit unit, int count);

		/// <summary>Moves one endpoint of the current text range to the specified endpoint of a second text range.</summary>
		/// <param name="endpoint"/>
		/// <param name="targetRange">
		/// <para>Type: <c>ITextRangeProvider*</c></para>
		/// <para>A second text range from the same text provider as the current text range.</para>
		/// </param>
		/// <param name="targetEndpoint"/>
		/// <remarks>
		/// If the endpoint being moved crosses the other endpoint of the same text range, that other endpoint is moved also, resulting in a
		/// degenerate (empty) range and ensuring the correct ordering of the endpoints (that is, the start is always less than or equal to
		/// the end).
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextrangeprovider-moveendpointbyrange
		// HRESULT MoveEndpointByRange( TextPatternRangeEndpoint endpoint, [in] ITextRangeProvider *targetRange, TextPatternRangeEndpoint
		// targetEndpoint );
		new void MoveEndpointByRange(TextPatternRangeEndpoint endpoint, ITextRangeProvider targetRange, TextPatternRangeEndpoint targetEndpoint);

		/// <summary>Selects the span of text that corresponds to this text range, and removes any previous selection.</summary>
		/// <remarks>Providing a degenerate text range will move the text insertion point.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextrangeprovider-select HRESULT Select();
		new void Select();

		/// <summary>
		/// Adds the text range to the collection of selected text ranges in a control that supports multiple, disjoint spans of selected text.
		/// </summary>
		/// <remarks>
		/// <para>The text insertion point moves to the area of the new selection.</para>
		/// <para>
		/// If this method is called on a degenerate text range, the text insertion point moves to the location of the text range but no text
		/// is selected.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextrangeprovider-addtoselection HRESULT AddToSelection();
		new void AddToSelection();

		/// <summary>
		/// Removes the text range from the collection of selected text ranges in a control that supports multiple, disjoint spans of
		/// selected text.
		/// </summary>
		/// <remarks>
		/// <para>The text insertion point moves to the area of the removed selection.</para>
		/// <para>
		/// If this method is called on a degenerate text range, the text insertion point moves to the location of the text range but no text
		/// is selected.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextrangeprovider-removefromselection
		// HRESULT RemoveFromSelection();
		new void RemoveFromSelection();

		/// <summary>Causes the text control to scroll vertically until the text range is visible in the viewport.</summary>
		/// <param name="alignToTop">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// TRUE if the text control should be scrolled so the text range is flush with the top of the viewport; FALSE if it should be flush
		/// with the bottom of the viewport.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para><c>ITextRangeProvider::ScrollIntoView</c> respects both hidden and visible text.</para>
		/// <para>If the text range is hidden, the text control will scroll only if the hidden text has an anchor in the viewport.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextrangeprovider-scrollintoview HRESULT
		// ScrollIntoView( [in] BOOL alignToTop );
		new void ScrollIntoView(bool alignToTop);

		/// <summary>
		/// Retrieves a collection of all elements that are both contained (either partially or completely) within the specified text range,
		/// and are child elements of the enclosing element for the specified text range.
		/// </summary>
		/// <returns>
		/// <para>
		/// An array of pointers to the IRawElementProviderSimple interfaces for all child elements that are enclosed by the text range
		/// (sorted by the Start endpoint of their ranges).
		/// </para>
		/// <para>If the text range does not include any child elements, an empty collection is returned.</para>
		/// <para>This parameter is passed uninitialized.</para>
		/// </returns>
		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UNKNOWN)]
		new IRawElementProviderSimple[] GetChildren();

		/// <summary>Programmatically invokes a context menu on the target element.</summary>
		/// <remarks>
		/// <para>This method should return an error code if the context menu could not be invoked.</para>
		/// <para>
		/// <c>ShowContextMenu</c> should always show the context menu at the beginning end point of the range. This should be equivalent to
		/// what would happen if the user pressed the context menu key or SHIFT + F10 with the insertion point at the beginning of the range.
		/// </para>
		/// <para>
		/// If showing the context menu would typically result in the insertion point moving to a given location, then it should do so for
		/// programmatically invoking <c>ShowContextMenu</c> for Microsoft UI Automation support also.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itextrangeprovider2-showcontextmenu
		// HRESULT ShowContextMenu();
		void ShowContextMenu();
	}

	/// <summary>Provides access to controls that can cycle through a set of states and maintain a state after it is set.</summary>
	/// <remarks>Implemented on a Microsoft UI Automation provider that must support the Toggle control pattern.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-itoggleprovider
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.IToggleProvider")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("56d00bd0-c4f4-433c-a836-1a52a57e0892")]
	public interface IToggleProvider
	{
		/// <summary>Cycles through the toggle states of a control.</summary>
		/// <remarks>
		/// A control must cycle through its ToggleState in this order: <c>ToggleState_On</c>, <c>ToggleState_Off</c> and, if supported, <c>ToggleState_Indeterminate</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itoggleprovider-toggle HRESULT Toggle();
		void Toggle();

		/// <summary>
		/// <para>Specifies the toggle state of the control.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// A control must cycle through its ToggleState in this order: <c>ToggleState_On</c>, <c>ToggleState_Off</c> and, if supported, <c>ToggleState_Indeterminate</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itoggleprovider-get_togglestate HRESULT
		// get_ToggleState( ToggleState *pRetVal );
		ToggleState ToggleState { get; }
	}

	/// <summary>Provides access to controls that can be moved, resized, and/or rotated within a two-dimensional space.</summary>
	/// <remarks>
	/// <para>Implemented on a Microsoft UI Automation provider that must support the Transform control pattern.</para>
	/// <para>
	/// Support for this control pattern is not limited to objects on the desktop. This control pattern must also be implemented by the
	/// children of a container object as long as the children can be moved, resized, or rotated freely within the boundaries of the container.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-itransformprovider
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.ITransformProvider")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("6829ddc4-4f91-4ffa-b86f-bd3e2987cb4c")]
	public interface ITransformProvider
	{
		/// <summary>Moves the control.</summary>
		/// <param name="x">
		/// <para>Type: <c>double</c></para>
		/// <para>The absolute screen coordinates of the left side of the control.</para>
		/// </param>
		/// <param name="y">
		/// <para>Type: <c>double</c></para>
		/// <para>The absolute screen coordinates of the top of the control.</para>
		/// </param>
		/// <remarks>
		/// An object cannot be moved, resized or rotated such that its resulting screen location would be completely outside the coordinates
		/// of its container and inaccessible to keyboard or mouse. For example, when a top-level window is moved completely off-screen or a
		/// child object is moved outside the boundaries of the container's viewport. In these cases the object is placed as close to the
		/// requested screen coordinates as possible with the top or left coordinates overridden to be within the container boundaries.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itransformprovider-move HRESULT Move(
		// [in] double x, [in] double y );
		void Move(double x, double y);

		/// <summary>Resizes the control.</summary>
		/// <param name="width">
		/// <para>Type: <c>double</c></para>
		/// <para>The new width of the window in pixels.</para>
		/// </param>
		/// <param name="height">
		/// <para>Type: <c>double</c></para>
		/// <para>The new height of the window in pixels.</para>
		/// </param>
		/// <remarks>
		/// <para>When called on a control supporting split panes, this method might have the side effect of resizing other contiguous panes.</para>
		/// <para>
		/// An object cannot be moved, resized, or rotated such that its resulting screen location would be completely outside the
		/// coordinates of its container and inaccessible to keyboard or mouse. For example, a top-level window moved completely off-screen
		/// or a child object moved outside the boundaries of the container's viewport. In these cases the object is placed as close to the
		/// requested screen coordinates as possible with the top or left coordinates overridden to be within the container boundaries.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itransformprovider-resize HRESULT Resize(
		// [in] double width, [in] double height );
		void Resize(double width, double height);

		/// <summary>Rotates the control.</summary>
		/// <param name="degrees">
		/// <para>Type: <c>double</c></para>
		/// <para>The number of degrees to rotate the control. A positive number rotates clockwise; a negative number rotates counterclockwise.</para>
		/// </param>
		/// <remarks>
		/// An object cannot be moved, resized, or rotated such that its resulting screen location would be completely outside the
		/// coordinates of its container and inaccessible to keyboard or mouse. For example, a top-level window moved completely off-screen
		/// or a child object moved outside the boundaries of the container's viewport. In these cases the object is placed as close to the
		/// requested screen coordinates as possible with the top or left coordinates overridden to be within the container boundaries.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itransformprovider-rotate HRESULT Rotate(
		// [in] double degrees );
		void Rotate(double degrees);

		/// <summary>
		/// <para>Indicates whether the control can be moved.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itransformprovider-get_canmove HRESULT
		// get_CanMove( BOOL *pRetVal );
		bool CanMove { get; }

		/// <summary>
		/// <para>Indicates whether the control can be resized.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itransformprovider-get_canresize HRESULT
		// get_CanResize( BOOL *pRetVal );
		bool CanResize { get; }

		/// <summary>
		/// <para>Indicates whether the control can be rotated.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itransformprovider-get_canrotate HRESULT
		// get_CanRotate( BOOL *pRetVal );
		bool CanRotate { get; }
	}

	/// <summary>
	/// Extends the ITransformProvider interface to enable Microsoft UI Automation providers to expose properties to support the viewport
	/// zooming functionality of a control.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-itransformprovider2
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.ITransformProvider2")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("4758742f-7ac2-460c-bc48-09fc09308a93")]
	public interface ITransformProvider2 : ITransformProvider
	{
		/// <summary>Moves the control.</summary>
		/// <param name="x">
		/// <para>Type: <c>double</c></para>
		/// <para>The absolute screen coordinates of the left side of the control.</para>
		/// </param>
		/// <param name="y">
		/// <para>Type: <c>double</c></para>
		/// <para>The absolute screen coordinates of the top of the control.</para>
		/// </param>
		/// <remarks>
		/// An object cannot be moved, resized or rotated such that its resulting screen location would be completely outside the coordinates
		/// of its container and inaccessible to keyboard or mouse. For example, when a top-level window is moved completely off-screen or a
		/// child object is moved outside the boundaries of the container's viewport. In these cases the object is placed as close to the
		/// requested screen coordinates as possible with the top or left coordinates overridden to be within the container boundaries.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itransformprovider-move HRESULT Move(
		// [in] double x, [in] double y );
		new void Move(double x, double y);

		/// <summary>Resizes the control.</summary>
		/// <param name="width">
		/// <para>Type: <c>double</c></para>
		/// <para>The new width of the window in pixels.</para>
		/// </param>
		/// <param name="height">
		/// <para>Type: <c>double</c></para>
		/// <para>The new height of the window in pixels.</para>
		/// </param>
		/// <remarks>
		/// <para>When called on a control supporting split panes, this method might have the side effect of resizing other contiguous panes.</para>
		/// <para>
		/// An object cannot be moved, resized, or rotated such that its resulting screen location would be completely outside the
		/// coordinates of its container and inaccessible to keyboard or mouse. For example, a top-level window moved completely off-screen
		/// or a child object moved outside the boundaries of the container's viewport. In these cases the object is placed as close to the
		/// requested screen coordinates as possible with the top or left coordinates overridden to be within the container boundaries.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itransformprovider-resize HRESULT Resize(
		// [in] double width, [in] double height );
		new void Resize(double width, double height);

		/// <summary>Rotates the control.</summary>
		/// <param name="degrees">
		/// <para>Type: <c>double</c></para>
		/// <para>The number of degrees to rotate the control. A positive number rotates clockwise; a negative number rotates counterclockwise.</para>
		/// </param>
		/// <remarks>
		/// An object cannot be moved, resized, or rotated such that its resulting screen location would be completely outside the
		/// coordinates of its container and inaccessible to keyboard or mouse. For example, a top-level window moved completely off-screen
		/// or a child object moved outside the boundaries of the container's viewport. In these cases the object is placed as close to the
		/// requested screen coordinates as possible with the top or left coordinates overridden to be within the container boundaries.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itransformprovider-rotate HRESULT Rotate(
		// [in] double degrees );
		new void Rotate(double degrees);

		/// <summary>
		/// <para>Indicates whether the control can be moved.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itransformprovider-get_canmove HRESULT
		// get_CanMove( BOOL *pRetVal );
		new bool CanMove { get; }

		/// <summary>
		/// <para>Indicates whether the control can be resized.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itransformprovider-get_canresize HRESULT
		// get_CanResize( BOOL *pRetVal );
		new bool CanResize { get; }

		/// <summary>
		/// <para>Indicates whether the control can be rotated.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itransformprovider-get_canrotate HRESULT
		// get_CanRotate( BOOL *pRetVal );
		new bool CanRotate { get; }

		/// <summary>Zooms the viewport of the control.</summary>
		/// <param name="zoom">
		/// <para>Type: <c>double</c></para>
		/// <para>
		/// The amount to zoom the viewport, specified as a percentage. The provider should zoom the viewport to the nearest supported value.
		/// </para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itransformprovider2-zoom HRESULT Zoom(
		// [in] double zoom );
		void Zoom(double zoom);

		/// <summary>
		/// <para>Indicates whether the control supports zooming of its viewport.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itransformprovider2-get_canzoom HRESULT
		// get_CanZoom( BOOL *pRetVal );
		bool CanZoom { get; }

		/// <summary>
		/// <para>Retrieves the current zoom level of the element.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itransformprovider2-get_zoomlevel HRESULT
		// get_ZoomLevel( double *pRetVal );
		double ZoomLevel { get; }

		/// <summary>
		/// <para>Retrieves the minimum zoom level of the element.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itransformprovider2-get_zoomminimum
		// HRESULT get_ZoomMinimum( double *pRetVal );
		double ZoomMinimum { get; }

		/// <summary>
		/// <para>Retrieves the maximum zoom level of the element.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itransformprovider2-get_zoommaximum
		// HRESULT get_ZoomMaximum( double *pRetVal );
		double ZoomMaximum { get; }

		/// <summary>Zooms the viewport of the control by the specified logical unit.</summary>
		/// <param name="zoomUnit">The logical unit by which to increase or decrease the zoom of the viewport.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-itransformprovider2-zoombyunit HRESULT
		// ZoomByUnit( ZoomUnit zoomUnit );
		void ZoomByUnit(ZoomUnit zoomUnit);
	}

	/// <summary>
	/// Returns a client API wrapper object and to unmarshal property and method requests to an actual provider instance. The PatternHandler
	/// object is stateless, so this can be implemented by a singleton.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-iuiautomationpatternhandler
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.IUIAutomationPatternHandler")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("d97022f3-a947-465e-8b2a-ac4315fa54e8")]
	public interface IUIAutomationPatternHandler
	{
		/// <summary>Creates an object that enables a client application to interact with a custom <c>control pattern</c>.</summary>
		/// <param name="pPatternInstance">
		/// <para>Type: <c>IUIAutomationPatternInstance*</c></para>
		/// <para>A pointer to the instance of the control pattern that will be used by the wrapper.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IUnknown**</c></para>
		/// <para>Receives a pointer to the wrapper object.</para>
		/// </returns>
		/// <remarks>
		/// The wrapper object exposes methods and properties of the <c>control pattern</c>. The implementation of the wrapper class passes
		/// these calls to Microsoft UI Automation by calling CallMethod and GetProperty.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iuiautomationpatternhandler-createclientwrapper
		// HRESULT CreateClientWrapper( [in] IUIAutomationPatternInstance *pPatternInstance, [out, retval] IUnknown **pClientWrapper );
		[return: MarshalAs(UnmanagedType.IUnknown)]
		object CreateClientWrapper(IUIAutomationPatternInstance pPatternInstance);

		/// <summary>Dispatches a method or property getter to a custom <c>control pattern</c> provider.</summary>
		/// <param name="pTarget">
		/// <para>Type: <c>IUnknown*</c></para>
		/// <para>A pointer to the object that implements the control pattern provider.</para>
		/// </param>
		/// <param name="index">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index of the method or property getter.</para>
		/// </param>
		/// <param name="pParams">
		/// <para>Type: <c>UIAutomationParameter*</c></para>
		/// <para>A pointer to an array of structures that contain information about the parameters to be passed.</para>
		/// </param>
		/// <param name="cParams">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The count of parameters in <c>pParams</c>.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iuiautomationpatternhandler-dispatch
		// HRESULT Dispatch( [in] IUnknown *pTarget, [in] UINT index, [in] const UIAutomationParameter *pParams, [in] UINT cParams );
		void Dispatch([In, MarshalAs(UnmanagedType.IUnknown)] object pTarget, uint index, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] UIAutomationParameter[] pParams, uint cParams);
	}

	/// <summary>
	/// Represents a control pattern object. The client API wrapper uses this interface to implement all property and method calls in terms
	/// of the GetProperty and CallMethod methods.
	/// </summary>
	/// <remarks>
	/// This interface is implemented by Microsoft UI Automation and returned by methods such as GetCurrentPattern. The interface is passed
	/// to CreateClientWrapper, where it is used to call the appropriate methods and property getters.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-iuiautomationpatterninstance
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.IUIAutomationPatternInstance")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("c03a7fe4-9431-409f-bed8-ae7c2299bc8d")]
	public interface IUIAutomationPatternInstance
	{
		/// <summary>
		/// The client wrapper object implements the <c>IUIAutomation::get_Current</c><c>X</c> and
		/// <c>IUIAutomationElement::get_Cached</c><c>X</c> methods by calling this function, specifying the property by index.
		/// </summary>
		/// <param name="index">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index of the property.</para>
		/// </param>
		/// <param name="cached">
		/// <para>Type: <c>BOOL</c></para>
		/// <para><c>TRUE</c> if the property should be retrieved from the cache, otherwise <c>FALSE</c>.</para>
		/// </param>
		/// <param name="type"/>
		/// <param name="pPtr">
		/// <para>Type: <c>void*</c></para>
		/// <para>Receives the value of the property.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iuiautomationpatterninstance-getproperty
		// HRESULT GetProperty( [in] UINT index, [in] BOOL cached, UIAutomationType type, [out, retval] void *pPtr );
		void GetProperty(uint index, bool cached, UIAutomationType type, [Out] IntPtr pPtr);

		/// <summary>Client wrapper implements methods by calling this CallMethod function, specifying the parameters as an array of pointers.</summary>
		/// <param name="index">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index of the method.</para>
		/// </param>
		/// <param name="pParams">
		/// <para>Type: <c>UIAutomationParameter*</c></para>
		/// <para>A pointer to an array of structures describing the parameters.</para>
		/// </param>
		/// <param name="cParams">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The count of parameters in <c>pParams</c>.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iuiautomationpatterninstance-callmethod
		// HRESULT CallMethod( [in] UINT index, [in] const UIAutomationParameter *pParams, [in] UINT cParams );
		void CallMethod(uint index, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] UIAutomationParameter[] pParams, uint cParams);
	}

	/// <summary>Exposes methods for registering new control patterns, properties, and events.</summary>
	/// <remarks>
	/// The <c>IUIAutomationRegistrar</c> interface is exposed by the CUIAutomationRegistrar object. To obtain an instance of this object,
	/// call the CoCreateInstance function with a class ID of <c>CLSID_CUIAutomationRegistrar</c>.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-iuiautomationregistrar
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.IUIAutomationRegistrar")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("8609c4ec-4a1a-4d88-a357-5a66e060e1cf"), CoClass(typeof(CUIAutomationRegistrar))]
	public interface IUIAutomationRegistrar
	{
		/// <summary>Registers a third-party property.</summary>
		/// <param name="property">
		/// <para>Type: <c>UIAutomationPropertyInfo*</c></para>
		/// <para>A pointer to a structure that contains information about the property to register.</para>
		/// </param>
		/// <param name="propertyId">
		/// <para>Type: <c>PropertyID*</c></para>
		/// <para>Receives the property ID of the newly registered property.</para>
		/// </param>
		/// <remarks>
		/// The property ID can be used in various property methods, including GetCurrentPropertyValue, and CreatePropertyCondition. The same
		/// value can be used as a WinEvent value for property change events in IAccessibleEx implementations.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iuiautomationregistrar-registerproperty
		// HRESULT RegisterProperty( [in] const UIAutomationPropertyInfo *property, [out] PROPERTYID *propertyId );
		void RegisterProperty(in UIAutomationPropertyInfo property, out UIAutomationClient.PROPERTYID propertyId);

		/// <summary>Registers a third-party Microsoft UI Automation event.</summary>
		/// <param name="_event">
		/// <para>Type: <c>UIAutomationEventInfo</c>*</para>
		/// <para>A pointer to a structure that contains information about the event to register.</para>
		/// </param>
		/// <param name="eventId">
		/// <para>Type: <c>EVENTID</c>*</para>
		/// <para>Receives the event identifier. For a list of event IDs, see Event Identifiers.</para>
		/// </param>
		/// <remarks>The event ID can be used in various event methods, and as a WinEvent value for events in IAccessibleEx implementations.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iuiautomationregistrar-registerevent
		// HRESULT RegisterEvent( [in] const UIAutomationEventInfo *event, [out] EVENTID *eventId );
		void RegisterEvent(in UIAutomationEventInfo _event, out UIAutomationClient.EVENTID eventId);

		/// <summary>Registers a third-party control pattern.</summary>
		/// <param name="pattern">
		/// <para>Type: <c>UIAutomationPatternInfo*</c></para>
		/// <para>A pointer to a structure that contains information about the control pattern to register.</para>
		/// </param>
		/// <param name="pPatternId">
		/// <para>Type: <c>PATTERNID*</c></para>
		/// <para>Receives the pattern identifier.</para>
		/// </param>
		/// <param name="pPatternAvailablePropertyId">
		/// <para>Type: <c>PROPERTYID*</c></para>
		/// <para>
		/// Receives the property identifier for the pattern. This value can be used with UI Automation client methods to determine whether
		/// the element supports the new pattern. This is equivalent to values such as UIA_IsInvokePatternAvailablePropertyId.
		/// </para>
		/// </param>
		/// <param name="propertyIdCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of properties supported by the control pattern.</para>
		/// </param>
		/// <param name="pPropertyIds">
		/// <para>Type: <c>PROPERTYID*</c></para>
		/// <para>Receives an array of identifiers for properties supported by the pattern.</para>
		/// </param>
		/// <param name="eventIdCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of events supported by the control pattern.</para>
		/// </param>
		/// <param name="pEventIds">
		/// <para>Type: <c>EVENTID*</c></para>
		/// <para>Receives an array of identifiers for events that are raised by the pattern.</para>
		/// </param>
		/// <remarks>The pattern, property, and event IDs retrieved by this method can be used in IAccessibleEx implementations.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iuiautomationregistrar-registerpattern
		// HRESULT RegisterPattern( [in] const UIAutomationPatternInfo *pattern, [out] PATTERNID *pPatternId, [out] PROPERTYID
		// *pPatternAvailablePropertyId, [in] UINT propertyIdCount, [out] PROPERTYID *pPropertyIds, [in] UINT eventIdCount, [out] EVENTID
		// *pEventIds );
		void RegisterPattern(in UIAutomationPatternInfo pattern, out UIAutomationClient.PATTERNID pPatternId,
			out UIAutomationClient.PROPERTYID pPatternAvailablePropertyId, uint propertyIdCount,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] UIAutomationClient.PROPERTYID[] pPropertyIds, uint eventIdCount,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] UIAutomationClient.EVENTID[] pEventIds);
	}

	/// <summary>
	/// Provides access to controls that have an intrinsic value that does not span a range, and that can be represented as a string.
	/// </summary>
	/// <remarks>
	/// <para>The value of the control may or may not be editable depending on the control and its settings.</para>
	/// <para>Implemented on a Microsoft UI Automation provider that must support the Value control pattern.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-ivalueprovider
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.IValueProvider")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("c7935180-6fb3-4201-b174-7df73adbf64a")]
	public interface IValueProvider
	{
		/// <summary>Sets the value of control.</summary>
		/// <param name="val">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>The value to set. The provider is responsible for converting the value to the appropriate data type.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Single-line edit controls support programmatic access to their contents by implementing IValueProvider. However, multi-line edit
		/// controls do not implement <c>IValueProvider</c>; instead they provide access to their content by implementing ITextProvider.
		/// </para>
		/// <para>
		/// Controls such as ListItem and TreeItem must implement IValueProvider if the value of any of the items is editable, regardless of
		/// the current edit mode of the control. The parent control must also implement <c>IValueProvider</c> if the child items are editable.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-ivalueprovider-setvalue HRESULT SetValue(
		// [in] LPCWSTR val );
		void SetValue(string val);

		/// <summary>
		/// <para>The value of the control.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// Single-line edit controls support programmatic access to their contents by implementing IValueProvider (in addition to
		/// ITextProvider). However, multi-line edit controls do not implement <c>IValueProvider</c>.
		/// </para>
		/// <para>
		/// To retrieve the textual contents of multi-line edit controls, the controls must implement ITextProvider. However,
		/// <c>ITextProvider</c> does not support setting the value of a control.
		/// </para>
		/// <para>
		/// IValueProvider does not support the retrieval of formatting information or substring values. Implement ITextProvider in these scenarios.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-ivalueprovider-get_value HRESULT
		// get_Value( BSTR *pRetVal );
		string Value { [return: MarshalAs(UnmanagedType.BStr)] get; }

		/// <summary>
		/// <para>Indicates whether the value of a control is read-only.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// A control should have its IsEnabled property (UIA_IsEnabledPropertyId) set to <c>TRUE</c> and its
		/// <c>IValueProvider::IsReadOnly</c> property set to <c>FALSE</c> before allowing a call to IValueProvider::SetValue.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-ivalueprovider-get_isreadonly HRESULT
		// get_IsReadOnly( BOOL *pRetVal );
		bool IsReadOnly { get; }
	}

	/// <summary>
	/// Provides access to virtualized items, which are items that are represented by placeholder automation elements in the Microsoft UI
	/// Automation tree.
	/// </summary>
	/// <remarks>
	/// A virtualized item is typically an item in a virtual list; that is, a list that does not manage its own data. When an application
	/// retrieves an IUIAutomationElement for a virtualized item by using FindItemByProperty, UI Automation calls the provider's
	/// implementation of FindItemByProperty, where the provider may return a placeholder element that also implements
	/// <c>IVirtualizedItemProvider</c>. On a call to Realize, the provider's implementation of Realize returns a full UI Automation element
	/// reference and may also scroll the item into view.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-ivirtualizeditemprovider
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.IVirtualizedItemProvider")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("cb98b665-2d35-4fac-ad35-f3c60d0c0b8b")]
	public interface IVirtualizedItemProvider
	{
		/// <summary>Makes the virtual item fully accessible as a UI Automation element.</summary>
		/// <remarks>
		/// When an item is obtained from a virtual list, it is only a placeholder. Use this method to convert it to a full reference to UI
		/// Automation element.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-ivirtualizeditemprovider-realize HRESULT Realize();
		void Realize();
	}

	/// <summary>Provides access to the fundamental window-based functionality of a control.</summary>
	/// <remarks>Implemented on a Microsoft UI Automation provider that must support the Window Control Pattern control pattern.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nn-uiautomationcore-iwindowprovider
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NN:uiautomationcore.IWindowProvider")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("987df77b-db06-4d77-8f8a-86a9c3bb90b9")]
	public interface IWindowProvider
	{
		/// <summary>Changes the visual state of the window. For example, minimizes or maximizes it.</summary>
		/// <param name="state">
		/// <para>Type: <c>WindowVisualState</c></para>
		/// <para>The state of the window.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iwindowprovider-setvisualstate HRESULT
		// SetVisualState( [in] WindowVisualState state );
		void SetVisualState(WindowVisualState state);

		/// <summary>Attempts to close the window.</summary>
		/// <remarks>
		/// <para><c>IWindowProvider::Close</c> must return immediately without blocking.</para>
		/// <para>
		/// <c>IWindowProvider::Close</c> raises the UIA_Window_WindowClosedEventId event. If possible, the event should be raised after the
		/// control has completed its associated action.
		/// </para>
		/// <para>When called on a split pane control, this method will close the pane and remove the associated split.</para>
		/// <para>This method may also close all other panes depending on implementation.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iwindowprovider-close HRESULT Close();
		void Close();

		/// <summary>
		/// Causes the calling code to block for the specified time or until the associated process enters an idle state, whichever completes first.
		/// </summary>
		/// <param name="milliseconds">
		/// <para>Type: <c>int</c></para>
		/// <para>The amount of time, in milliseconds, to wait for the associated process to become idle. The maximum is Int32.MaxValue.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>
		/// Receives <c>TRUE</c> if the window has entered the idle state; <c>FALSE</c> if the time-out occurred. This parameter is passed uninitialized.
		/// </para>
		/// </returns>
		/// <remarks>
		/// This method is typically used in conjunction with the handling of a UIA_Window_WindowOpenedEventId. The implementation is
		/// dependent on the underlying application framework; therefore this method might return some time after the window is ready for
		/// user input. The calling code should not rely on this method to ascertain exactly when the window has become idle. Use the value
		/// of <c>pRetVal</c> to determine if the window is ready for input or if the method timed out.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iwindowprovider-waitforinputidle HRESULT
		// WaitForInputIdle( [in] int milliseconds, [out, retval] BOOL *pRetVal );
		bool WaitForInputIdle(int milliseconds);

		/// <summary>
		/// <para>Indicates whether the window can be maximized.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iwindowprovider-get_canmaximize HRESULT
		// get_CanMaximize( BOOL *pRetVal );
		bool CanMaximize { get; }

		/// <summary>
		/// <para>Indicates whether the window can be minimized.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iwindowprovider-get_canminimize HRESULT
		// get_CanMinimize( BOOL *pRetVal );
		bool CanMinimize { get; }

		/// <summary>
		/// <para>Indicates whether the window is modal.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iwindowprovider-get_ismodal HRESULT
		// get_IsModal( BOOL *pRetVal );
		bool IsModal { get; }

		/// <summary>
		/// <para>Specifies the visual state of the window; that is, whether the window is normal (restored), minimized, or maximized.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iwindowprovider-get_windowvisualstate
		// HRESULT get_WindowVisualState( WindowVisualState *pRetVal );
		WindowVisualState WindowVisualState { get; }

		/// <summary>
		/// <para>Specifies the current state of the window for the purposes of user interaction.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iwindowprovider-get_windowinteractionstate
		// HRESULT get_WindowInteractionState( WindowInteractionState *pRetVal );
		WindowInteractionState WindowInteractionState { get; }

		/// <summary>
		/// <para>Indicates whether the window is the topmost element in the z-order.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/nf-uiautomationcore-iwindowprovider-get_istopmost HRESULT
		// get_IsTopmost( BOOL *pRetVal );
		bool IsTopmost { get; }
	}

	/// <summary>Contains the coordinates of a point.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/ns-uiautomationcore-uiapoint struct UiaPoint { double x; double
	// y; };
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NS:uiautomationcore.UiaPoint")]
	[StructLayout(LayoutKind.Sequential)]
	public struct UiaPoint
	{
		/// <summary>
		/// <para>Type: <c>double</c></para>
		/// <para>The horizontal screen coordinate.</para>
		/// </summary>
		public double x;

		/// <summary>
		/// <para>Type: <c>double</c></para>
		/// <para>The vertical screen coordinate.</para>
		/// </summary>
		public double y;
	}

	/// <summary>Contains the position and size of a rectangle, in screen coordinates.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/ns-uiautomationcore-uiarect struct UiaRect { double left; double
	// top; double width; double height; };
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NS:uiautomationcore.UiaRect")]
	[StructLayout(LayoutKind.Sequential)]
	public struct UiaRect
	{
		/// <summary>
		/// <para>Type: <c>double</c></para>
		/// <para>Position of the left side.</para>
		/// </summary>
		public double left;

		/// <summary>
		/// <para>Type: <c>double</c></para>
		/// <para>Position of the top side.</para>
		/// </summary>
		public double top;

		/// <summary>
		/// <para>Type: <c>double</c></para>
		/// <para>Width.</para>
		/// </summary>
		public double width;

		/// <summary>
		/// <para>Type: <c>double</c></para>
		/// <para>Height.</para>
		/// </summary>
		public double height;
	}

	/// <summary>Contains information about a custom event.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/ns-uiautomationcore-uiautomationeventinfo struct
	// UIAutomationEventInfo { GUID guid; LPCWSTR pProgrammaticName; };
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NS:uiautomationcore.UIAutomationEventInfo")]
	[StructLayout(LayoutKind.Sequential)]
	public struct UIAutomationEventInfo
	{
		/// <summary>
		/// <para>Type: <c>GUID</c></para>
		/// <para>The event identifier.</para>
		/// </summary>
		public Guid guid;

		/// <summary>
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>The programmatic name of the event (a non-localizable string).</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pProgrammaticName;
	}

	/// <summary>Contains information about a method that is supported by a custom control pattern.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/ns-uiautomationcore-uiautomationmethodinfo struct
	// UIAutomationMethodInfo { LPCWSTR pProgrammaticName; BOOL doSetFocus; UINT cInParameters; UINT cOutParameters; UIAutomationType
	// *pParameterTypes; LPCWSTR *pParameterNames; };
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NS:uiautomationcore.UIAutomationMethodInfo")]
	[StructLayout(LayoutKind.Sequential)]
	public struct UIAutomationMethodInfo
	{
		/// <summary>
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>The name of the method (a non-localizable string).</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pProgrammaticName;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para><c>TRUE</c> if UI Automation should set the focus on the object before calling the method; otherwise <c>FALSE</c>.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool doSetFocus;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The count of [in] parameters, which are always first in the <c>pParameterTypes</c> array.</para>
		/// </summary>
		public uint cInParameters;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The count of [out] parameters, which always follow the [in] parameters in the <c>pParameterTypes</c> array.</para>
		/// </summary>
		public uint cOutParameters;

		/// <summary>
		/// <para>Type: <c>UIAutomationType*</c></para>
		/// <para>
		/// A pointer to an array of values indicating the data types of the parameters of the method. The data types of the In parameters
		/// should be first, followed by those of the Out parameters.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.IUnknown)]
		public UIAutomationType pParameterTypes;

		/// <summary>
		/// <para>Type: <c>LPCWSTR*</c></para>
		/// <para>A pointer to an array containing the parameter names (non-localizable strings).</para>
		/// </summary>
		public IntPtr pParameterNames;
	}

	/// <summary>Contains information about a parameter of a custom control pattern.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/ns-uiautomationcore-uiautomationparameter struct
	// UIAutomationParameter { UIAutomationType type; void *pData; };
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NS:uiautomationcore.UIAutomationParameter")]
	[StructLayout(LayoutKind.Sequential)]
	public struct UIAutomationParameter
	{
		/// <summary>
		/// <para>Type: <c>UIAutomationType</c></para>
		/// <para>A value indicating the type of the parameter.</para>
		/// </summary>
		public UIAutomationType type;

		/// <summary>
		/// <para>Type: <c>void*</c></para>
		/// <para>A pointer to the parameter data.</para>
		/// </summary>
		public IntPtr pData;
	}

	/// <summary>Contains information about a custom control pattern.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/ns-uiautomationcore-uiautomationpatterninfo struct
	// UIAutomationPatternInfo { GUID guid; LPCWSTR pProgrammaticName; GUID providerInterfaceId; GUID clientInterfaceId; UINT cProperties;
	// struct UIAutomationPropertyInfo *pProperties; UINT cMethods; struct UIAutomationMethodInfo *pMethods; UINT cEvents; struct
	// UIAutomationEventInfo *pEvents; IUIAutomationPatternHandler *pPatternHandler; };
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NS:uiautomationcore.UIAutomationPatternInfo")]
	[StructLayout(LayoutKind.Sequential)]
	public struct UIAutomationPatternInfo
	{
		/// <summary>
		/// <para>Type: <c>GUID</c></para>
		/// <para>The unique identifier of the control pattern.</para>
		/// </summary>
		public Guid guid;

		/// <summary>
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>The name of the control pattern (a non-localizable string).</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pProgrammaticName;

		/// <summary>
		/// <para>Type: <c>GUID</c></para>
		/// <para>The unique identifier of the provider interface for the control pattern.</para>
		/// </summary>
		public Guid providerInterfaceId;

		/// <summary>
		/// <para>Type: <c>GUID</c></para>
		/// <para>The unique identifier of the client interface for the control pattern.</para>
		/// </summary>
		public Guid clientInterfaceId;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The count of elements in <c>pProperties</c>.</para>
		/// </summary>
		public uint cProperties;

		/// <summary>
		/// <para>Type: <c>UIAutomationPropertyInfo*</c></para>
		/// <para>A pointer to an array of structures describing properties available on the control pattern.</para>
		/// </summary>
		public IntPtr pProperties;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The count of elements in <c>pMethods</c>.</para>
		/// </summary>
		public uint cMethods;

		/// <summary>
		/// <para>Type: <c>UIAutomationMethodInfo*</c></para>
		/// <para>A pointer to an array of structures describing methods available on the control pattern.</para>
		/// </summary>
		public IntPtr pMethods;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The count of elements in <c>pEvents</c>.</para>
		/// </summary>
		public uint cEvents;

		/// <summary>
		/// <para>Type: <c>UIAutomationEventInfo*</c></para>
		/// <para>A pointer to an array of structures describing events available on the control pattern.</para>
		/// </summary>
		public IntPtr pEvents;

		/// <summary>
		/// <para>Type: <c>IUIAutomationPatternHandler*</c></para>
		/// <para>A pointer to the object that makes the control pattern available to clients.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.IUnknown)]
		public IUIAutomationPatternHandler pPatternHandler;
	}

	/// <summary>Contains information about a custom property.</summary>
	/// <remarks>
	/// <para>
	/// A custom property must have one of the following data types specified by the UIAutomationType enumeration. No other data types are
	/// supported for custom properties. For more information, see Custom Properties, Events, and Control Patterns.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description>UIAutomationType_Bool</description>
	/// </item>
	/// <item>
	/// <description>UIAutomationType_Double</description>
	/// </item>
	/// <item>
	/// <description>UIAutomationType_Element</description>
	/// </item>
	/// <item>
	/// <description>UIAutomationType_Int</description>
	/// </item>
	/// <item>
	/// <description>UIAutomationType_Point</description>
	/// </item>
	/// <item>
	/// <description>UIAutomationType_String</description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uiautomationcore/ns-uiautomationcore-uiautomationpropertyinfo struct
	// UIAutomationPropertyInfo { GUID guid; LPCWSTR pProgrammaticName; UIAutomationType type; };
	[PInvokeData("uiautomationcore.h", MSDNShortId = "NS:uiautomationcore.UIAutomationPropertyInfo")]
	[StructLayout(LayoutKind.Sequential)]
	public struct UIAutomationPropertyInfo
	{
		/// <summary>
		/// <para>Type: <c>GUID</c></para>
		/// <para>The unique identifier of the property.</para>
		/// </summary>
		public Guid guid;

		/// <summary>
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>The programmatic name of the property (a non-localizable string).</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pProgrammaticName;

		/// <summary>
		/// <para>Type: <c>UIAutomationType</c></para>
		/// <para>A value from the UIAutomationType enumerated type indicating the data type of the property value.</para>
		/// </summary>
		public UIAutomationType type;
	}

	/// <summary>Implements the <c>IUIAutomationRegistrar</c> interface.</summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ff384837(v=vs.85)
	[ComImport, ClassInterface(ClassInterfaceType.None), Guid("8609c4ec-4a1a-4d88-a357-5a66e060e1cf")]
	public class CUIAutomationRegistrar
	{
	}
}