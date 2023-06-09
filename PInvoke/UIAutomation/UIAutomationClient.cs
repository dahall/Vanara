namespace Vanara.PInvoke;

public static partial class UIAutomationClient
{
	/// <summary>Describes the named constants used to identify Microsoft UI Automation events.</summary>
	[PInvokeData("UIAutomationClient.h")]
	public enum EVENTID
	{
		/// <summary>
		/// Identifies the event that is raised when the active text position changes, indicated by a navigation event within or between
		/// read-only text elements (such as web browsers, PDF documents, or EPUB documents) using bookmarks (fragment identifiers that refer
		/// to a location within a resource).
		/// </summary>
		UIA_ActiveTextPositionChangedEventId = 20036,

		/// <summary>
		/// Identifies the event that is raised when asynchronous content is being loaded. This event is used mainly by providers to indicate
		/// that asynchronous content-loading events have occurred.
		/// </summary>
		UIA_AsyncContentLoadedEventId = 20006,

		/// <summary>Identifies the event that is raised when the focus has changed from one element to another.</summary>
		UIA_AutomationFocusChangedEventId = 20005,

		/// <summary>Identifies the event that is raised when the value of a property has changed.</summary>
		UIA_AutomationPropertyChangedEventId = 20004,

		/// <summary>Identifies the event that is raised when a provider calls the UiaRaiseChangesEvent function.</summary>
		UIA_ChangesEventId = 20034,

		/// <summary>
		/// Identifies the event that is raised when the user ends a drag operation before dropping an element on a drop target. This event
		/// is raised by the element being dragged. Supported starting with Windows 8.
		/// </summary>
		UIA_Drag_DragCancelEventId = 20027,

		/// <summary>
		/// Identifies the event that is raised when the user drops an element on a drop target. This event is raised by the element being
		/// dragged. Supported starting with Windows 8.
		/// </summary>
		UIA_Drag_DragCompleteEventId = 20028,

		/// <summary>
		/// Identifies the event that is raised when the user starts to drag an element. This event is raised by the element being dragged.
		/// Supported starting with Windows 8.
		/// </summary>
		UIA_Drag_DragStartEventId = 20026,

		/// <summary>
		/// Identifies the event that is raised when the user drags an element into a drop target's boundary. This event is raised by the
		/// drop target element. Supported starting with Windows 8.
		/// </summary>
		UIA_DropTarget_DragEnterEventId = 20029,

		/// <summary>
		/// Identifies the event that is raised when the user drags an element out of a drop target's boundary. This event is raised by the
		/// drop target element. Supported starting with Windows 8.
		/// </summary>
		UIA_DropTarget_DragLeaveEventId = 20030,

		/// <summary>
		/// Identifies the event that is raised when the user drops an element on a drop target. This event is raised by the drop target
		/// element. Supported starting with Windows 8.
		/// </summary>
		UIA_DropTarget_DroppedEventId = 20031,

		/// <summary>
		/// Identifies the event that is raised when a change is made to the root node of a UI Automation fragment that is hosted in another
		/// element. Supported starting with Windows 8.
		/// </summary>
		UIA_HostedFragmentRootsInvalidatedEventId = 20025,

		/// <summary>Identifies the event that is raised when the specified input was discarded or otherwise failed to reach any element.</summary>
		UIA_InputDiscardedEventId = 20022,

		/// <summary>
		/// Identifies the event that is raised when the specified input reached an element other than the element for which the
		/// StartListening method was called.
		/// </summary>
		UIA_InputReachedOtherElementEventId = 20021,

		/// <summary>
		/// Identifies the event that is raised when the specified mouse or keyboard input reaches the element for which the StartListening
		/// method was called.
		/// </summary>
		UIA_InputReachedTargetEventId = 20020,

		/// <summary>Identifies the event that is raised when a control is invoked or activated.</summary>
		UIA_Invoke_InvokedEventId = 20009,

		/// <summary>
		/// Identifies the event that is raised when the layout of child items within a control has changed. This event is also used for
		/// Auto-suggest accessibility.
		/// </summary>
		UIA_LayoutInvalidatedEventId = 20008,

		/// <summary>
		/// Identifies the event that is raised when the content of a live region has changed. Supported starting with Windows 8.
		/// </summary>
		UIA_LiveRegionChangedEventId = 20024,

		/// <summary>Identifies the event that is raised when a menu is closed.</summary>
		UIA_MenuClosedEventId = 20007,

		/// <summary>Identifies the event that is raised when a menu mode is ended.</summary>
		UIA_MenuModeEndEventId = 20019,

		/// <summary>Identifies the event that is raised when a menu mode is started.</summary>
		UIA_MenuModeStartEventId = 20018,

		/// <summary>Identifies the event that is raised when a menu is opened.</summary>
		UIA_MenuOpenedEventId = 20003,

		/// <summary>Identifies the event that is raised when a provider calls the UiaRaiseNotificationEvent method.</summary>
		UIA_NotificationEventId = 20035,

		/// <summary>Identifies the event that is raised when a selection in a container has changed significantly.</summary>
		UIA_Selection_InvalidatedEventId = 20013,

		/// <summary>Identifies the event raised when an item is added to a collection of selected items.</summary>
		UIA_SelectionItem_ElementAddedToSelectionEventId = 20010,

		/// <summary>Identifies the event raised when an item is removed from a collection of selected items.</summary>
		UIA_SelectionItem_ElementRemovedFromSelectionEventId = 20011,

		/// <summary>
		/// Identifies the event that is raised when a call to the Select, AddToSelection, or RemoveFromSelection method results in a single
		/// item being selected.
		/// </summary>
		UIA_SelectionItem_ElementSelectedEventId = 20012,

		/// <summary>Identifies the event that is raised when the UI Automation tree structure is changed.</summary>
		UIA_StructureChangedEventId = 20002,

		/// <summary>Identifies the event that is raised when a provider issues a system alert. Supported starting with Windows 8.</summary>
		UIA_SystemAlertEventId = 20023,

		/// <summary>Identifies the event that is raised whenever textual content is modified.</summary>
		UIA_Text_TextChangedEventId = 20015,

		/// <summary>Identifies the event that is raised when the text selection is modified.</summary>
		UIA_Text_TextSelectionChangedEventId = 20014,

		/// <summary>
		/// Identifies the event that is raised whenever a composition replacement is performed by a control. Supported starting with Windows 8.1.
		/// </summary>
		UIA_TextEdit_ConversionTargetChangedEventId = 20033,

		/// <summary>
		/// Identifies the event that is raised whenever text auto-correction is performed by a control. Supported starting with Windows 8.1.
		/// </summary>
		UIA_TextEdit_TextChangedEventId = 20032,

		/// <summary>Identifies the event that is raised when a tooltip is closed.</summary>
		UIA_ToolTipClosedEventId = 20001,

		/// <summary>Identifies the event that is raised when a tooltip is opened.</summary>
		UIA_ToolTipOpenedEventId = 20000,

		/// <summary>Identifies the event that is raised when a window is closed.</summary>
		UIA_Window_WindowClosedEventId = 20017,

		/// <summary>Identifies the event that is raised when a window is opened.</summary>
		UIA_Window_WindowOpenedEventId = 20016,
	}

	/// <summary>Describes the named constants, which are used to identify metadata types in a document.</summary>
	[PInvokeData("UIAutomationClient.h")]
	public enum METADATAID
	{
		/// <summary>
		/// Identifies metadata which indicates how a string should be interpreted and spoken by a screen reader or text-to-speech engine.
		/// </summary>
		UIA_SayAsInterpretAsMetadataId = 100000,
	}

	/// <summary>Describes the named constants that identify Microsoft UI Automation control patterns.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/winauto/uiauto-controlpattern-ids
	[PInvokeData("UIAutomationClient.h")]
	public enum PATTERNID
	{
		/// <summary>Identifies the Annotation control pattern. Supported starting with Windows 8.</summary>
		UIA_AnnotationPatternId = 10023,

		/// <summary>Identifies the CustomNavigation control pattern. Supported starting with Windows 10.</summary>
		UIA_CustomNavigationPatternId = 10033,

		/// <summary>Identifies the Dock control pattern.</summary>
		UIA_DockPatternId = 10011,

		/// <summary>Identifies the Drag control pattern. Supported starting with Windows 8.</summary>
		UIA_DragPatternId = 10030,

		/// <summary>Identifies the DropTarget control pattern. Supported starting with Windows 8.</summary>
		UIA_DropTargetPatternId = 10031,

		/// <summary>Identifies the ExpandCollapse control pattern.</summary>
		UIA_ExpandCollapsePatternId = 10005,

		/// <summary>Identifies the GridItem control pattern.</summary>
		UIA_GridItemPatternId = 10007,

		/// <summary>Identifies the Grid control pattern.</summary>
		UIA_GridPatternId = 10006,

		/// <summary>Identifies the Invoke control pattern.</summary>
		UIA_InvokePatternId = 10000,

		/// <summary>Identifies the ItemContainer control pattern.</summary>
		UIA_ItemContainerPatternId = 10019,

		/// <summary>Identifies the LegacyIAccessible control pattern.</summary>
		UIA_LegacyIAccessiblePatternId = 10018,

		/// <summary>Identifies the MultipleView control pattern.</summary>
		UIA_MultipleViewPatternId = 10008,

		/// <summary>Identifies the ObjectModel control pattern. Supported starting with Windows 8.</summary>
		UIA_ObjectModelPatternId = 10022,

		/// <summary>Identifies the RangeValue control pattern.</summary>
		UIA_RangeValuePatternId = 10003,

		/// <summary>Identifies the ScrollItem control pattern.</summary>
		UIA_ScrollItemPatternId = 10017,

		/// <summary>Identifies the Scroll control pattern.</summary>
		UIA_ScrollPatternId = 10004,

		/// <summary>Identifies the SelectionItem control pattern.</summary>
		UIA_SelectionItemPatternId = 10010,

		/// <summary>Identifies the Selection control pattern.</summary>
		UIA_SelectionPatternId = 10001,

		/// <summary>Identifies the Spreadsheet control pattern. Supported starting with Windows 8.</summary>
		UIA_SpreadsheetPatternId = 10026,

		/// <summary>Identifies the SpreadsheetItem control pattern. Supported starting with Windows 8.</summary>
		UIA_SpreadsheetItemPatternId = 10027,

		/// <summary>Identifies the Styles control pattern. Supported starting with Windows 8.</summary>
		UIA_StylesPatternId = 10025,

		/// <summary>Identifies the SynchronizedInput control pattern.</summary>
		UIA_SynchronizedInputPatternId = 10021,

		/// <summary>Identifies the TableItem control pattern.</summary>
		UIA_TableItemPatternId = 10013,

		/// <summary>Identifies the Table control pattern.</summary>
		UIA_TablePatternId = 10012,

		/// <summary>Identifies the TextChild control pattern. Supported starting with Windows 8.</summary>
		UIA_TextChildPatternId = 10029,

		/// <summary>Identifies the TextEdit control pattern. Supported starting with Windows 8.1.</summary>
		UIA_TextEditPatternId = 10032,

		/// <summary>Identifies the Text control pattern.</summary>
		UIA_TextPatternId = 10014,

		/// <summary>Identifies the second version of the Text control pattern. Supported starting with Windows 8.</summary>
		UIA_TextPattern2Id = 10024,

		/// <summary>Identifies the Toggle control pattern.</summary>
		UIA_TogglePatternId = 10015,

		/// <summary>Identifies the Transform control pattern.</summary>
		UIA_TransformPatternId = 10016,

		/// <summary>Identifies the second version of the Transform control pattern. Supported starting with Windows 8.</summary>
		UIA_TransformPattern2Id = 10028,

		/// <summary>Identifies the Value control pattern.</summary>
		UIA_ValuePatternId = 10002,

		/// <summary>Identifies the VirtualizedItem control pattern.</summary>
		UIA_VirtualizedItemPatternId = 10020,

		/// <summary>Identifies the Window control pattern.</summary>
		UIA_WindowPatternId = 10009,
	}

	/// <summary>Describes the named constants that identify the properties of Microsoft UI Automation elements.</summary>
	[PInvokeData("UIAutomationClient.h")]
	public enum PROPERTYID
	{
		/// <summary>
		/// Identifies the AcceleratorKey property, which is a string containing the accelerator key (also called shortcut key) combinations
		/// for the automation element.
		/// <para>
		/// Shortcut key combinations invoke an action. For example, CTRL+O is often used to invoke the Open file common dialog box. An
		/// automation element that has the AcceleratorKey property can implement the Invoke control pattern for the action that is
		/// equivalent to the shortcut command.
		/// </para>
		/// <para>Variant type: VT_BSTR</para>
		/// <para>Default value: empty string</para>
		/// </summary>
		UIA_AcceleratorKeyPropertyId = 30006,

		/// <summary>
		/// Identifies the AccessKey property, which is a string containing the access key character for the automation element.
		/// <para>
		/// An access key (sometimes called a mnemonic) is a character in the text of a menu, menu item, or label of a control such as a
		/// button, that activates the associated menu function. For example, to open the File menu, for which the access key is typically F,
		/// the user would press ALT+F.
		/// </para>
		/// <para>Variant type: VT_BSTR</para>
		/// <para>Default value: empty string</para>
		/// </summary>
		UIA_AccessKeyPropertyId = 30007,

		/// <summary>
		/// Identifies the AnnotationObjects property, which is a list of annotation objects in a document, such as comment, header, footer,
		/// and so on.
		/// <para>Variant type: VT_I4 | VT_ARRAY</para>
		/// <para>Default value: empty array</para>
		/// </summary>
		UIA_AnnotationObjectsPropertyId = 30156,

		/// <summary>
		/// Identifies the AnnotationTypes property, which is a list of the types of annotations in a document, such as comment, header,
		/// footer, and so on.
		/// <para>Variant type: VT_I4 | VT_ARRAY</para>
		/// <para>Default value: empty array</para>
		/// </summary>
		UIA_AnnotationTypesPropertyId = 30155,

		/// <summary>
		/// Identifies the AriaProperties property, which is a formatted string containing the Accessible Rich Internet Application (ARIA)
		/// property information for the automation element. For more information about mapping ARIA states and properties to UI Automation
		/// properties and functions, see UI Automation for W3C Accessible Rich Internet Applications Specification.
		/// <para>
		/// AriaProperties is a collection of Name/Value pairs with delimiters of = (equals) and ; (semicolon), for example,
		/// "checked=true;disabled=false". The \ (backslash) is used as an escape character when these delimiter characters or \ appear in
		/// the values. For security and other reasons, the provider implementation of this property can take steps to validate the original
		/// ARIA properties; however, it is not required.
		/// </para>
		/// <para>Variant type: VT_BSTR</para>
		/// <para>Default value: empty string</para>
		/// </summary>
		UIA_AriaPropertiesPropertyId = 30102,

		/// <summary>
		/// Identifies the AriaRole property, which is a string containing the Accessible Rich Internet Application (ARIA) role information
		/// for the automation element. For more information about mapping ARIA roles to UI Automation control types, see UI Automation for
		/// W3C Accessible Rich Internet Applications Specification.
		/// <para>[!Note]</para>
		/// <para>
		/// As an option, the user agent can also offer a localized description of the W3C ARIA role in the LocalizedControlType property.
		/// When the localized string is not specified, the system will provide the default LocalizedControlType string for the element.
		/// </para>
		/// <para>Variant type: VT_BSTR</para>
		/// <para>Default value: empty string</para>
		/// </summary>
		UIA_AriaRolePropertyId = 30101,

		/// <summary>
		/// Identifies the AutomationId property, which is a string containing the UI Automation identifier (ID) for the automation element.
		/// <para>
		/// When it is available, the AutomationId of an element must be the same in any instance of the application, regardless of the local
		/// language. The value should be unique among sibling elements, but not necessarily unique across the entire desktop. For example,
		/// multiple instances of an application, or multiple folder views in Microsoft Windows Explorer, can contain elements with the same
		/// AutomationId property, such as "SystemMenuBar".
		/// </para>
		/// <para>
		/// Although support for AutomationId is always recommended for better automated testing support, this property is not mandatory.
		/// Where it is supported, AutomationId is useful for creating a test automation script that runs regardless of the UI language.
		/// Clients should make no assumptions regarding the AutomationId values exposed by other applications. AutomationId is not
		/// guaranteed to be stable across different releases or builds of an application.
		/// </para>
		/// <para>Variant type: VT_BSTR</para>
		/// <para>Default value: empty string</para>
		/// </summary>
		UIA_AutomationIdPropertyId = 30011,

		/// <summary>
		/// Identifies the BoundingRectangle property, which specifies the coordinates of the rectangle that completely encloses the
		/// automation element. The rectangle is expressed in physical screen coordinates. It can contain points that are not clickable if
		/// the shape or clickable region of the UI item is irregular, or if the item is obscured by other UI elements.
		/// <para>Variant type: VT_R8 | VT_ARRAY</para>
		/// <para>Default value: [0,0,0,0]</para>
		/// <para>[!Note]</para>
		/// <para>This property is NULL if the item is not currently displaying a UI.</para>
		/// </summary>
		UIA_BoundingRectanglePropertyId = 30001,

		/// <summary>
		/// Identifies the CenterPoint property, which specifies the center X and Y point coordinates of the automation element. The
		/// coordinate space is what the provider logically considers a page.
		/// <para>Variant type: VT_R8 | VT_ARRAY</para>
		/// <para>Default value: VT_EMPTY</para>
		/// </summary>
		UIA_CenterPointPropertyId = 30165,

		/// <summary>
		/// Identifies the ClassName property, which is a string containing the class name for the automation element as assigned by the
		/// control developer.
		/// <para>
		/// The class name depends on the implementation of the UI Automation provider and therefore is not always in a standard format.
		/// However, if the class name is known, it can be used to verify that an application is working with the expected automation element.
		/// </para>
		/// <para>Variant type: VT_BSTR</para>
		/// <para>Default value: empty string</para>
		/// </summary>
		UIA_ClassNamePropertyId = 30012,

		/// <summary>
		/// Identifies the ClickablePoint property, which is a point on the automation element that can be clicked. An element cannot be
		/// clicked if it is completely or partially obscured by another window.
		/// <para>Variant type: VT_R8 | VT_ARRAY</para>
		/// <para>Default value: VT_EMPTY</para>
		/// </summary>
		UIA_ClickablePointPropertyId = 30014,

		/// <summary>
		/// Identifies the ControllerFor property, which is an array of automation elements that are manipulated by the automation element
		/// that supports this property.
		/// <para>
		/// ControllerFor is used when an automation element affects one or more segments of the application UI or the desktop; otherwise, it
		/// is hard to associate the impact of the control operation with UI elements.
		/// </para>
		/// <para>This identifier is commonly used for Auto-suggest accessibility.</para>
		/// <para>Variant type for providers: VT_UNKNOWN | VT_ARRAY</para>
		/// <para>Variant type for clients: VT_UNKNOWN (IUIAutomationElementArray )</para>
		/// <para>Default value: empty array</para>
		/// </summary>
		UIA_ControllerForPropertyId = 30104,

		/// <summary>
		/// Identifies the ControlType property, which is a class that identifies the type of the automation element. ControlType defines
		/// characteristics of the UI elements by well known UI control primitives such as button or check box.
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: UIA_CustomControlTypeId</para>
		/// <para>[!Note]</para>
		/// <para>Use the default value only if the automation element represents a completely new type of control.</para>
		/// </summary>
		UIA_ControlTypePropertyId = 30003,

		/// <summary>
		/// Identifies the Culture property, which contains a locale identifier for the automation element (for example, 0x0409 for "en-US"
		/// or English (United States)).
		/// <para>
		/// Each locale has a unique identifier, a 32-bit value that consists of a language identifier and a sort order identifier. The
		/// locale identifier is a standard international numeric abbreviation and has the components necessary to uniquely identify one of
		/// the installed operating system-defined locales. For more information, see Language Identifier Constants and Strings.
		/// </para>
		/// <para>This property may exist on a per-control basis, but typically is only available on an application level.</para>
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_CulturePropertyId = 30015,

		/// <summary>
		/// Identifies the DescribedBy property, which is an array of elements that provide more information about the automation element.
		/// <para>
		/// DescribedBy is used when an automation element is explained by another segment of the application UI. For example, the property
		/// can point to a text element of "2,529 items in 85 groups, 10 items selected" from a complex custom list object. Instead of using
		/// the object model for clients to digest similar information, the DescribedBy property can offer quick access to the UI element
		/// that may already offer useful end-user information that describes the UI element.
		/// </para>
		/// <para>Variant type for providers: VT_UNKNOWN | VT_ARRAY</para>
		/// <para>Variant type for clients: VT_UNKNOWN (IUIAutomationElementArray)</para>
		/// <para>Default value: empty array</para>
		/// </summary>
		UIA_DescribedByPropertyId = 30105,

		/// <summary>
		/// Identifies the FillColor property, which specifies the color used to fill the automation element. This attribute is specified as
		/// a COLORREF, a 32-bit value used to specify an RGB or RGBA color.
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_FillColorPropertyId = 30160,

		/// <summary>
		/// Identifies the FillType property, which specifies the pattern used to fill the automation element, such as none, color, gradient,
		/// picture, pattern, and so on.
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_FillTypePropertyId = 30162,

		/// <summary>
		/// Identifies the FlowsFrom property, which is an array of automation elements that suggests the reading order before the current
		/// automation element. Supported starting with Windows 8.
		/// <para>
		/// The FlowsFrom property specifies the reading order when automation elements are not exposed or structured in the same reading
		/// order as perceived by the user. While the FlowsFrom property can specify multiple preceding elements, it typically contains only
		/// the prior element in the reading order.
		/// </para>
		/// <para>Variant type for providers: VT_UNKNOWN | VT_ARRAY</para>
		/// <para>Variant type for clients: VT_UNKNOWN (IUIAutomationElementArray)</para>
		/// <para>Default value: empty array</para>
		/// </summary>
		UIA_FlowsFromPropertyId = 30148,

		/// <summary>
		/// Identifies the FlowsTo property, which is an array of automation elements that suggests the reading order after the current
		/// automation element.
		/// <para>
		/// The FlowsTo property specifies the reading order when automation elements are not exposed or structured in the same reading order
		/// as perceived by the user. While the FlowsTo property can specify multiple succeeding elements, it typically contains only the
		/// next element in the reading order.
		/// </para>
		/// <para>Variant type for providers: VT_UNKNOWN | VT_ARRAY</para>
		/// <para>Variant type for clients: VT_UNKNOWN (IUIAutomationElementArray)</para>
		/// <para>Default value: empty array</para>
		/// </summary>
		UIA_FlowsToPropertyId = 30106,

		/// <summary>
		/// Identifies the FrameworkId property, which is a string containing the name of the underlying UI framework that the automation
		/// element belongs to.
		/// <para>
		/// The FrameworkId enables client applications to process automation elements differently depending on the particular UI framework.
		/// Examples of property values include "Win32", "WinForm", and "DirectUI".
		/// </para>
		/// <para>Variant type: VT_BSTR</para>
		/// <para>Default value: empty string</para>
		/// </summary>
		UIA_FrameworkIdPropertyId = 30024,

		/// <summary>
		/// The FullDescription property exposes a localized string which can contain extended description text for an element.
		/// FullDescription can contain a more complete description of an element than may be appropriate for the element Name.
		/// <para>Variant type: VT_BSTR</para>
		/// <para>Default value: empty string</para>
		/// </summary>
		UIA_FullDescriptionPropertyId = 30159,

		/// <summary>
		/// Identifies the HasKeyboardFocus property, which is a Boolean value that indicates whether the automation element has keyboard focus.
		/// <para>Variant type: VT_BOOL</para>
		/// <para>Default value: FALSE</para>
		/// </summary>
		UIA_HasKeyboardFocusPropertyId = 30008,

		/// <summary>
		/// Identifies the HeadingLevel property, which indicates the heading level of a UI Automation element.
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: HeadingLevel_None</para>
		/// </summary>
		UIA_HeadingLevelPropertyId = 30173,

		/// <summary>
		/// Identifies the HelpText property, which is a help text string associated with the automation element.
		/// <para>
		/// The HelpText property can be supported with placeholder text appearing in edit or list controls. For example, "Type text here for
		/// search" is a good candidate the HelpText property for an edit control that places the text prior to the user's actual input.
		/// However, it is not adequate for the name property of the edit control.
		/// </para>
		/// <para>When HelpText is supported, the string must match the application UI language or the operating system default UI language.</para>
		/// <para>Variant type: VT_BSTR</para>
		/// <para>Default value: empty string</para>
		/// </summary>
		UIA_HelpTextPropertyId = 30013,

		/// <summary>
		/// Identifies the IsContentElement property, which is a Boolean value that specifies whether the element appears in the content view
		/// of the automation element tree. For more information, see UI Automation Tree Overview.
		/// <para>[!Note]</para>
		/// <para>
		/// For an element to appear in the content view, both the IsContentElement property and the IsControlElement property must be TRUE.
		/// </para>
		/// <para>Variant type: VT_BOOL</para>
		/// <para>Default value: TRUE</para>
		/// </summary>
		UIA_IsContentElementPropertyId = 30017,

		/// <summary>
		/// Identifies the IsControlElement property, which is a Boolean value that specifies whether the element appears in the control view
		/// of the automation element tree. For more information, see UI Automation Tree Overview.
		/// <para>Variant type: VT_BOOL</para>
		/// <para>Default value: TRUE</para>
		/// </summary>
		UIA_IsControlElementPropertyId = 30016,

		/// <summary>
		/// Identifies the IsDataValidForForm property, which is a Boolean value that indicates whether the entered or selected value is
		/// valid for the form rule associated with the automation element. For example, if the user entered "425-555-5555" for a zip code
		/// field that requires 5 or 9 digits, the IsDataValidForForm property can be set to FALSE to indicate that the data is not valid.
		/// <para>Variant type: VT_BOOL</para>
		/// <para>Default value: FALSE</para>
		/// </summary>
		UIA_IsDataValidForFormPropertyId = 30103,

		/// <summary>
		/// Identifies the IsDialog property, which is a Boolean value that indicates whether the automation element is a dialog window. For
		/// example, assistive technology such as screen readers typically speak the title of the dialog, the focused control in the dialog,
		/// and then the content of the dialog up to the focused control ("Do you want to save your changes before closing"). For standard
		/// windows, a screen reader typically speaks the window title followed by the focused control. The IsDialog property can be set to
		/// TRUE to indicate that the client application should treat the element as a dialog window.
		/// <para>Variant type: VT_BOOL</para>
		/// <para>Default value: FALSE</para>
		/// </summary>
		UIA_IsDialogPropertyId = 30174,

		/// <summary>
		/// Identifies the IsEnabled property, which is a Boolean value that indicates whether the UI item referenced by the automation
		/// element is enabled and can be interacted with.
		/// <para>
		/// When the enabled state of a control is FALSE, it is assumed that child controls are also not enabled. Clients should not expect
		/// property-changed events from child elements when the state of the parent control changes.
		/// </para>
		/// <para>Variant type: VT_BOOL</para>
		/// <para>Default value: FALSE</para>
		/// </summary>
		UIA_IsEnabledPropertyId = 30010,

		/// <summary>
		/// Identifies the IsKeyboardFocusable property, which is a Boolean value that indicates whether the automation element can accept
		/// keyboard focus.
		/// <para>Variant type: VT_BOOL</para>
		/// <para>Default value: FALSE</para>
		/// </summary>
		UIA_IsKeyboardFocusablePropertyId = 30009,

		/// <summary>
		/// Identifies the IsOffscreen property, which is a Boolean value that indicates whether the automation element is entirely scrolled
		/// out of view (for example, an item in a list box that is outside the viewport of the container object) or collapsed out of view
		/// (for example, an item in a tree view or menu, or in a minimized window). If the element has a clickable point that can cause it
		/// to receive the focus, the element is considered to be on-screen while a portion of the element is off-screen.
		/// <para>
		/// The value of the property is not affected by occlusion by other windows, or by whether the element is visible on a specific monitor.
		/// </para>
		/// <para>
		/// If the IsOffscreen property is TRUE, the UI element is scrolled off-screen or collapsed. The element is temporarily hidden, yet
		/// it remains in the end-user's perception and continues to be included in the UI model. The object can be brought back into view by
		/// scrolling, clicking a drop-down, and so on.
		/// </para>
		/// <para>
		/// Objects that the end-user does not perceive at all, or that are "programmatically hidden" (for example, a dialog box that has
		/// been dismissed, but the underlying object is still cached by the application) should not be in the automation element tree in the
		/// first place (instead of setting the state of IsOffscreen to TRUE).
		/// </para>
		/// <para>Variant type: VT_BOOL</para>
		/// <para>Default value: FALSE</para>
		/// </summary>
		UIA_IsOffscreenPropertyId = 30022,

		/// <summary>
		/// Identifies the IsPassword property, which is a Boolean value that indicates whether the automation element contains protected
		/// content or a password.
		/// <para>
		/// When the IsPassword property is TRUE and the element has the keyboard focus, a client application should disable keyboard echoing
		/// or keyboard input feedback that may expose the user's protected information. Attempting to access the Value property of the
		/// protected element (edit control) may cause an error to occur.
		/// </para>
		/// <para>Variant type: VT_BOOL</para>
		/// <para>Default value: FALSE</para>
		/// </summary>
		UIA_IsPasswordPropertyId = 30019,

		/// <summary>
		/// Identifies the IsPeripheral property, which is a Boolean value that indicates whether the automation element represents
		/// peripheral UI. Peripheral UI appears and supports user interaction, but does not take keyboard focus when it appears. Examples of
		/// peripheral UI includes popups, flyouts, context menus, or floating notifications. Supported starting with Windows 8.1.
		/// <para>
		/// When the IsPeripheral property is TRUE, a client application can't assume that focus was taken by the element even if it's
		/// currently keyboard-interactive.
		/// </para>
		/// <para>This property is relevant for these control types:</para>
		/// <para>UIA_GroupControlTypeId</para>
		/// <para>UIA_MenuControlTypeId</para>
		/// <para>UIA_PaneControlTypeId</para>
		/// <para>UIA_ToolBarControlTypeId</para>
		/// <para>UIA_ToolTipControlTypeId</para>
		/// <para>UIA_WindowControlTypeId</para>
		/// <para>UIA_CustomControlTypeId</para>
		/// <para>Variant type: VT_BOOL</para>
		/// <para>Default value: FALSE</para>
		/// </summary>
		UIA_IsPeripheralPropertyId = 30150,

		/// <summary>
		/// Identifies the IsRequiredForForm property, which is a Boolean value that indicates whether the automation element is required to
		/// be filled out on a form.
		/// <para>Variant type: VT_BOOL</para>
		/// <para>Default value: FALSE</para>
		/// </summary>
		UIA_IsRequiredForFormPropertyId = 30025,

		/// <summary>
		/// Identifies the ItemStatus property, which is a text string describing the status of an item of the automation element.
		/// <para>
		/// ItemStatus enables a client to ascertain whether an element is conveying status about an item as well as what the status is. For
		/// example, an item associated with a contact in a messaging application might be "Busy" or "Connected".
		/// </para>
		/// <para>When ItemStatus is supported, the string must match the application UI language or the operating system default UI language.</para>
		/// <para>Variant type: VT_BSTR</para>
		/// <para>Default value: empty string</para>
		/// </summary>
		UIA_ItemStatusPropertyId = 30026,

		/// <summary>
		/// Identifies the ItemType property, which is a text string describing the type of the automation element.
		/// <para>
		/// ItemType is used to obtain information about items in a list, tree view, or data grid. For example, an item in a file directory
		/// view might be a "Document File" or a "Folder".
		/// </para>
		/// <para>When ItemType is supported, the string must match the application UI language or the operating system default UI language.</para>
		/// <para>Variant type: VT_BSTR</para>
		/// <para>Default value: empty string</para>
		/// </summary>
		UIA_ItemTypePropertyId = 300021,

		/// <summary>
		/// Identifies the LabeledBy property, which is an automation element that contains the text label for this element.
		/// <para>This property can be used to retrieve, for example, the static text label for a combo box.</para>
		/// <para>Variant type: VT_UNKNOWN</para>
		/// <para>Default value: NULL</para>
		/// </summary>
		UIA_LabeledByPropertyId = 30018,

		/// <summary>
		/// Identifies the LandmarkType property, which is a Landmark Type Identifier associated with an element.
		/// <para>
		/// The LandmarkType property describes an element that represents a group of elements. For example, a search landmark could
		/// represent a set of related controls for searching.
		/// </para>
		/// <para>If UIA_CustomLandmarkTypeId is used then UIA_LocalizedLandmarkTypePropertyId is required to describe the custom landmark.</para>
		/// <para>Variant Type: VT_I4</para>
		/// <para>Default Value: 0</para>
		/// </summary>
		UIA_LandmarkTypePropertyId = 30157,

		/// <summary>
		/// Identifies the Level property, which is a 1-based integer associated with an automation element.
		/// <para>
		/// The Level property describes the location of an element inside a hierarchical or broken hierarchical structures. For example a
		/// bulleted/numbered list, headings, or other structured data items can have various parent/child relationships. Level describes
		/// where in the structure the item is located.
		/// </para>
		/// <para>It is recommended to use the CustomNavigation Control Pattern in tandem with Level.</para>
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_LevelPropertyId = 30154,

		/// <summary>
		/// Identifies the LiveSetting property, which is supported by an automation element that represents a live region. The LiveSetting
		/// property indicates the "politeness" level that a client should use to notify the user of changes to the live region. This
		/// property can be one of the values from the LiveSetting enumeration. Supported starting with Windows 8.
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_LiveSettingPropertyId = 30135,

		/// <summary>
		/// Identifies the LocalizedControlType property, which is a text string describing the type of control that the automation element
		/// represents. The string should contain only lowercase characters:
		/// <para>Correct: "button"</para>
		/// <para>Incorrect: "Button"</para>
		/// <para>
		/// When LocalizedControlType is not specified by the element provider, the default localized string is supplied by the framework,
		/// according to the control type of the element (for example, "button" for the Button control type). An automation element with the
		/// Custom control type must support a localized control type string that represents the role of the element (for example, "color
		/// picker" for a custom control that enables users to choose and specify colors).
		/// </para>
		/// <para>When a custom value is supplied, the string must match the application UI language or the operating system default UI language.</para>
		/// <para>Variant type: VT_BSTR</para>
		/// <para>Default value: empty string</para>
		/// </summary>
		UIA_LocalizedControlTypePropertyId = 30004,

		/// <summary>
		/// Identifies the LocalizedLandmarkType, which is a text string describing the type of landmark that the automation element represents.
		/// <para>
		/// This should be used in tandem with UIA_CustomLandmarkTypeId however, LocalizedLandmarkType should always take precedence over
		/// LandmarkType and be used to describe the landmark before LandmarkType.
		/// </para>
		/// <para>The string must match the application UI language or the operating system default UI language.</para>
		/// <para>Variant type: VT_BSTR</para>
		/// <para>Default value: empty string</para>
		/// </summary>
		UIA_LocalizedLandmarkTypePropertyId = 30158,

		/// <summary>
		/// Identifies the Name property, which is a string that holds the name of the automation element.
		/// <para>
		/// The Name property should be the same as the label text on screen. For example, Name should be "Browse" for a button element with
		/// the label "Browse". The Name property must not include the mnemonic character for the access keys (that is, "&amp;"), which is
		/// underlined in the UI text presentation. Also, the Name property should not be an extended or modified version of the on-screen
		/// label because the inconsistency between the name and the label can cause confusion among client applications and users.
		/// </para>
		/// <para>
		/// When the corresponding label text is not visible on screen, or when it is replaced by graphics, alternative text should be
		/// chosen. The alternative text should be concise, intuitive, and localized to the application UI language, or to the operating
		/// system default UI language. The alternative text should not be a detailed description of the visual details, but a concise
		/// description of the UI function or feature as if it were labeled by simple text. For example, the Windows Start menu button is
		/// named "Start" (button) instead of "Windows Logo on blue round sphere graphics" (button). For more information, see Creating Text
		/// Equivalents for Images.
		/// </para>
		/// <para>
		/// When a UI label uses text graphics (for example, using "&gt;&gt;" for a button that adds an item from left to right), the Name
		/// property should be overridden by an appropriate text alternative (for example, "Add"). However the practice of using text
		/// graphics as a UI label is discouraged due to both localization and accessibility concerns.
		/// </para>
		/// <para>
		/// The Name property must not include the control role or type information, such as "button" or "list"; otherwise, it will conflict
		/// with the text from the LocalizedControlType property when these two properties are appended (many existing assistive technologies
		/// do this).
		/// </para>
		/// <para>
		/// The Name property cannot be used as a unique identifier among siblings. However, as long as it is consistent with the UI
		/// presentation, the same Name value can be supported among peers. For test automation, the clients should consider using the
		/// AutomationId or RuntimeId property.
		/// </para>
		/// <para>
		/// Text controls do not always have to have the Name property be identical to the text that is displayed within the control, so long
		/// as the Text pattern is also supported.
		/// </para>
		/// <para>Variant type: VT_BSTR</para>
		/// <para>Default value: empty string</para>
		/// </summary>
		UIA_NamePropertyId = 30005,

		/// <summary>
		/// Identifies the NativeWindowHandle property, which is an integer that represents the handle (HWND) of the automation element
		/// window, if it exists; otherwise, this property is 0.
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_NativeWindowHandlePropertyId = 30020,

		/// <summary>
		/// Identifies the OptimizeForVisualContent property, which is a Boolean value that indicates whether the provider exposes only
		/// elements that are visible. A provider can use this property to optimize performance when working with very large pieces of
		/// content. For example, as the user pages through a large piece of content, the provider can destroy content elements that are no
		/// longer visible. When a content element is destroyed, the provider should return the UIA_E_ELEMENTNOTAVAILABLE error code.
		/// Supported starting with Windows 8.
		/// <para>Variant type: VT_BOOL</para>
		/// <para>Default value: FALSE</para>
		/// </summary>
		UIA_OptimizeForVisualContentPropertyId = 30111,

		/// <summary>
		/// Identifies the Orientation property, which indicates the orientation of the control represented by the automation element. The
		/// property is expressed as a value from the OrientationType enumerated type.
		/// <para>
		/// The Orientation property is supported by controls, such as scroll bars and sliders, that can have either a vertical or a
		/// horizontal orientation. Otherwise, it can always be OrientationType_None, which means that the control has no orientation.
		/// </para>
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: 0 (OrientationType_None)</para>
		/// </summary>
		UIA_OrientationPropertyId = 300023,

		/// <summary>
		/// Identifies the OutlineColor property, which specifies the color used for the outline of the automation element. This attribute is
		/// specified as a COLORREF, a 32-bit value used to specify an RGB or RGBA color.
		/// <para>Variant type: VT_I4 | VT_ARRAY</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_OutlineColorPropertyId = 30161,

		/// <summary>
		/// Identifies the OutlineThickness property, which specifies the width for the outline of the automation element.
		/// <para>Variant type: VT_R8 | VT_ARRAY</para>
		/// <para>Default value: VT_EMPTY</para>
		/// </summary>
		UIA_OutlineThicknessPropertyId = 30164,

		/// <summary>
		/// Identifies the PositionInSet property, which is a 1-based integer associated with an automation element. PositionInSet describes
		/// the ordinal location of the element within a set of elements which are considered to be siblings.
		/// <para>PositionInSet works in coordination with the SizeOfSet property to describe the ordinal location in the set.</para>
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_PositionInSetPropertyId = 30152,

		/// <summary>
		/// Identifies the ProcessId property, which is an integer representing the process identifier (ID) of the automation element.
		/// <para>
		/// The process identifier (ID) is assigned by the operating system. It can be seen in the PID column of the Processes tab in Task Manager.
		/// </para>
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_ProcessIdPropertyId = 30002,

		/// <summary>
		/// Identifies the ProviderDescription property, which is a formatted string containing the source information of the UI Automation
		/// provider for the automation element, including proxy information.
		/// <para>Variant type: VT_BSTR</para>
		/// <para>Default value: empty string</para>
		/// </summary>
		UIA_ProviderDescriptionPropertyId = 30107,

		/// <summary>
		/// Identifies the Rotation property, which specifies the angle of rotation in unspecified units.
		/// <para>Variant type: VT_R8</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_RotationPropertyId = 30166,

		/// <summary>
		/// Identifies the RuntimeId property, which is an array of integers representing the identifier for an automation element.
		/// <para>
		/// The identifier is unique on the desktop, but it is guaranteed to be unique only within the UI of the desktop on which it was
		/// generated. Identifiers can be reused over time.
		/// </para>
		/// <para>
		/// The format of RuntimeId can change. The returned identifier should be treated as an opaque value and used only for comparison;
		/// for example, to determine whether an automation element is in the cache.
		/// </para>
		/// <para>Variant type: VT_I4 | VT_ARRAY</para>
		/// <para>Default value: VT_EMPTY</para>
		/// </summary>
		UIA_RuntimeIdPropertyId = 30000,

		/// <summary>
		/// Identifies the Size property, which specifies the width and height of the automation element.
		/// <para>Variant type: VT_R8 | VT_ARRAY</para>
		/// <para>Default value: VT_EMPTY</para>
		/// </summary>
		UIA_SizePropertyId = 30167,

		/// <summary>
		/// Identifies the SizeOfSet property, which is a 1-based integer associated with an automation element. SizeOfSet describes the
		/// count of automation elements in a group or set that are considered to be siblings.
		/// <para>SizeOfSet works in coordination with the PositionInSet property to describe the count of items in the set.</para>
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_SizeOfSetPropertyId = 30153,

		/// <summary>
		/// Identifies the VisualEffects property, which is a bit field that specifies effects on the automation element, such as shadow,
		/// reflection, glow, soft edges, or bevel.
		/// <para>VisualEffects:</para>
		/// <para>VisualEffects_Shadow: 0x1</para>
		/// <para>VisualEffects_Reflection: 0x2</para>
		/// <para>VisualEffects_Glow: 0x4</para>
		/// <para>VisualEffects_SoftEdges: 0x8</para>
		/// <para>VisualEffects_Bevel: 0x10</para>
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_VisualEffectsPropertyId = 30163,

		/// <summary>
		/// Identifies the AnnotationTypeId property of the Annotation control pattern. Supported starting with Windows 8.
		/// <para>This property indicates the type of an annotation. For a list of possible values, see Annotation Type Identifiers.</para>
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_AnnotationAnnotationTypeIdPropertyId = 30113,

		/// <summary>
		/// Identifies the AnnotationTypeName property of the Annotation control pattern. Supported starting with Windows 8.
		/// <para>
		/// This property is a localized string that contains the name of an annotation type. The name can correspond to one of the
		/// annotation type identifiers (for example, Comment for AnnotationType_Comment), but it is not required to.
		/// </para>
		/// <para>Variant type: VT_BSTR</para>
		/// <para>Default value: empty string</para>
		/// </summary>
		UIA_AnnotationAnnotationTypeNamePropertyId = 30114,

		/// <summary>
		/// Identifies the Author property of the Annotation control pattern. Supported starting with Windows 8.
		/// <para>This property is a string that contains the name of the person who authored the annotation.</para>
		/// <para>Variant type: VT_BSTR</para>
		/// <para>Default value: empty string</para>
		/// </summary>
		UIA_AnnotationAuthorPropertyId = 30115,

		/// <summary>
		/// Identifies the DateTime property of the Annotation control pattern. Supported starting with Windows 8.
		/// <para>This property is a string that contains the date and time when the annotation was created.</para>
		/// <para>Variant type: VT_BSTR</para>
		/// <para>Default value: empty string</para>
		/// </summary>
		UIA_AnnotationDateTimePropertyId = 30116,

		/// <summary>
		/// Identifies the Target property of the Annotation control pattern. Supported starting with Windows 8.
		/// <para>This property is the IUIAutomationElement interface of the element that is being annotated.</para>
		/// <para>Variant type: VT_UNKNOWN</para>
		/// <para>Default value: NULL</para>
		/// </summary>
		UIA_AnnotationTargetPropertyId = 30117,

		/// <summary>
		/// Identifies the DockPosition property of the Dock control pattern.
		/// <para>
		/// This property indicates the dock position of the automation element within a docking container, and is expressed as a value from
		/// the DockPosition enumerated type.
		/// </para>
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: DockPosition_None</para>
		/// </summary>
		UIA_DockDockPositionPropertyId = 30069,

		/// <summary>
		/// Identifies the DropEffect property of the Drag control pattern. Supported starting with Windows 8.
		/// <para>This property indicates what happens when an element is dropped as part of a drag-drop operation.</para>
		/// <para>Variant type: VT_BSTR</para>
		/// <para>Default value: empty string</para>
		/// </summary>
		UIA_DragDropEffectPropertyId = 30139,

		/// <summary>
		/// Identifies the DropEffects property of the Drag control pattern. Supported starting with Windows 8.
		/// <para>
		/// This property is a collection of strings that enumerate the possible effects that can happen when an element is dropped as part
		/// of a drag-drop operation.
		/// </para>
		/// <para>Variant type: VT_BSTR | VT_ARRAY</para>
		/// <para>Default value: empty array</para>
		/// </summary>
		UIA_DragDropEffectsPropertyId = 30140,

		/// <summary>
		/// Identifies the IsGrabbed property of the Drag control pattern. Supported starting with Windows 8.
		/// <para>This property indicates whether an element is being dragged.</para>
		/// <para>Variant type: VT_BOOL</para>
		/// <para>Default value: FALSE</para>
		/// </summary>
		UIA_DragIsGrabbedPropertyId = 30138,

		/// <summary>
		/// Identifies the GrabbedItems property of the Drag control pattern. Supported starting with Windows 8.
		/// <para>This property is a collection of elements that are being dragged as part of a drag operation.</para>
		/// <para>Variant type: VT_UNKNOWN | VT_ARRAY</para>
		/// <para>Default value: empty array</para>
		/// </summary>
		UIA_DragGrabbedItemsPropertyId = 30144,

		/// <summary>
		/// Identifies the DropTargetEffect property of the DropTarget control pattern. Supported starting with Windows 8.
		/// <para>This property indicates the current drop effect for the element being dragged.</para>
		/// <para>Variant type: VT_BSTR</para>
		/// <para>Default value: empty string</para>
		/// </summary>
		UIA_DropTargetDropTargetEffectPropertyId = 30142,

		/// <summary>
		/// Identifies the DropTargetEffects property of the DropTarget control pattern. Supported starting with Windows 8.
		/// <para>This property indicates the possible drop effects that can happen when an element is dropped on a drop target.</para>
		/// <para>Variant type: VT_BSTR | VT_ARRAY</para>
		/// <para>Default value: empty array</para>
		/// </summary>
		UIA_DropTargetDropTargetEffectsPropertyId = 30143,

		/// <summary>
		/// Identifies the ExpandCollapseState property of the ExpandCollapse control pattern.
		/// <para>
		/// This property indicates the current state, expanded or collapsed, of the automation element, and is expressed as a value from the
		/// ExpandCollapseState enumerated type.
		/// </para>
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: ExpandCollapseState_LeafNode</para>
		/// </summary>
		UIA_ExpandCollapseExpandCollapseStatePropertyId = 30070,

		/// <summary>
		/// Identifies the ColumnCount property of the Grid control pattern.
		/// <para>This property indicates the total number of columns in the grid.</para>
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_GridColumnCountPropertyId = 30063,

		/// <summary>
		/// Identifies the Column property of the GridItem control pattern.
		/// <para>This property indicates the ordinal number of the column that contains the cell or item.</para>
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_GridItemColumnPropertyId = 30065,

		/// <summary>
		/// Identifies the ColumnSpan property of the GridItem control pattern.
		/// <para>This property indicates the number of columns spanned by the cell or item.</para>
		/// <para>Variant type:VT_I4</para>
		/// <para>Default value: 1</para>
		/// </summary>
		UIA_GridItemColumnSpanPropertyId = 30067,

		/// <summary>
		/// Identifies the ContainingGrid property of the GridItem control pattern.
		/// <para>
		/// This property is the IUIAutomationElement interface pointer of the automation element that contains the cell or item. The
		/// container element implements the Grid control pattern (IGridProvider).
		/// </para>
		/// <para>Variant type: VT_UNKNOWN</para>
		/// <para>Default value: NULL</para>
		/// </summary>
		UIA_GridItemContainingGridPropertyId = 30068,

		/// <summary>
		/// Identifies the Row property of the GridItem control pattern.
		/// <para>This property is the ordinal number of the row that contains the cell or item.</para>
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_GridItemRowPropertyId = 30064,

		/// <summary>
		/// Identifies the RowSpan property of the GridItem control pattern.
		/// <para>This property indicates the number of rows spanned by the cell or item.</para>
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: 1</para>
		/// </summary>
		UIA_GridItemRowSpanPropertyId = 30066,

		/// <summary>
		/// Identifies the RowCount property of the Grid control pattern.
		/// <para>This property indicates the total number of rows in the grid.</para>
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_GridRowCountPropertyId = 30062,

		/// <summary>
		/// Identifies the ChildId property of the LegacyIAccessible control pattern.
		/// <para>This property is the Microsoft Active Accessibility (MSAA) child identifier of the automation element.</para>
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_LegacyIAccessibleChildIdPropertyId = 30091,

		/// <summary>
		/// Identifies the DefaultAction property of the LegacyIAccessible control pattern.
		/// <para>This property is the MSAA default action (accDefaultAction) for the automation element.</para>
		/// <para>Variant type: VT_BSTR</para>
		/// <para>Default value: empty string</para>
		/// </summary>
		UIA_LegacyIAccessibleDefaultActionPropertyId = 30100,

		/// <summary>
		/// Identifies the Description property of the LegacyIAccessible control pattern.
		/// <para>This property is the MSAA description (accDescription) for the automation element.</para>
		/// <para>Variant type: VT_BSTR</para>
		/// <para>Default value: empty string</para>
		/// </summary>
		UIA_LegacyIAccessibleDescriptionPropertyId = 30094,

		/// <summary>
		/// Identifies the Help property of the LegacyIAccessible control pattern.
		/// <para>This property is the MSAA help string (accHelp) for the automation element.</para>
		/// <para>Variant type: VT_BSTR</para>
		/// <para>Default value: empty string</para>
		/// </summary>
		UIA_LegacyIAccessibleHelpPropertyId = 30097,

		/// <summary>
		/// Identifies the KeyboardShortcut property of the LegacyIAccessible control pattern.
		/// <para>This property is the MSAA keyboard shortcut string (accKeyboardShortcut) for the automation element.</para>
		/// <para>Variant type: VT_BSTR</para>
		/// <para>Default value: empty string</para>
		/// </summary>
		UIA_LegacyIAccessibleKeyboardShortcutPropertyId = 30098,

		/// <summary>
		/// Identifies the Name property of the LegacyIAccessible control pattern.
		/// <para>This property is the MSAA name string (accName) for the automation element.</para>
		/// <para>Variant type: VT_BSTR</para>
		/// <para>Default value: empty string</para>
		/// </summary>
		UIA_LegacyIAccessibleNamePropertyId = 30092,

		/// <summary>
		/// Identifies the Roleproperty of the LegacyIAccessible control pattern.
		/// <para>This property is the MSAA role identifier (accRole) for the automation element.</para>
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_LegacyIAccessibleRolePropertyId = 30095,

		/// <summary>
		/// Identifies the Selection property of the LegacyIAccessible control pattern.
		/// <para>This property is the MSAA list of selected items (accSelection) in the control represented by the automation element.</para>
		/// <para>Variant type: VT_UNKNOWN | VT_ARRAY</para>
		/// <para>Default value: empty array</para>
		/// </summary>
		UIA_LegacyIAccessibleSelectionPropertyId = 30099,

		/// <summary>
		/// Identifies the State property of the LegacyIAccessible control pattern.
		/// <para>This property is the MSAA state (accState) of the automation element.</para>
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_LegacyIAccessibleStatePropertyId = 30096,

		/// <summary>
		/// Identifies the Value property of the LegacyIAccessible control pattern.
		/// <para>This property is the MSAA value (accValue) of the automation element.</para>
		/// <para>Variant type: VT_BSTR</para>
		/// <para>Default value: empty string</para>
		/// </summary>
		UIA_LegacyIAccessibleValuePropertyId = 30093,

		/// <summary>
		/// Identifies the CurrentView property of the MultipleView control pattern.
		/// <para>This property indicates the current view state of the automation element.</para>
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_MultipleViewCurrentViewPropertyId = 30071,

		/// <summary>
		/// Identifies the SupportedViews property of the MultipleView control pattern.
		/// <para>This property is a list of identifiers for the view states supported by the automation element.</para>
		/// <para>Variant type: VT_I4 | VT_ARRAY</para>
		/// <para>Default value: empty array</para>
		/// </summary>
		UIA_MultipleViewSupportedViewsPropertyId = 30072,

		/// <summary>
		/// Identifies the IsReadOnly property of the RangeValue control pattern.
		/// <para>This property indicates whether the value of the automation element is read-only.</para>
		/// <para>Variant type: VT_BOOL</para>
		/// <para>Default value: TRUE</para>
		/// </summary>
		UIA_RangeValueIsReadOnlyPropertyId = 30048,

		/// <summary>
		/// Identifies the LargeChange property of the RangeValue control pattern.
		/// <para>
		/// This property is the large-change value, unique to the automation element, that is added to or subtracted from the Value property.
		/// </para>
		/// <para>Variant type: VT_R8</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_RangeValueLargeChangePropertyId = 30051,

		/// <summary>
		/// Identifies the Maximum property of the RangeValue control pattern.
		/// <para>This property is the maximum range value supported by the automation element.</para>
		/// <para>Variant type: VT_R8</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_RangeValueMaximumPropertyId = 30050,

		/// <summary>
		/// Identifies the Minimum property of the RangeValue control pattern.
		/// <para>This property is the minimum range value supported by the automation element.</para>
		/// <para>Variant type: VT_R8</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_RangeValueMinimumPropertyId = 30049,

		/// <summary>
		/// Identifies the SmallChange property of the RangeValue control pattern.
		/// <para>
		/// This property is the small-change value, unique to the automation element, that is added to or subtracted from the Value property.
		/// </para>
		/// <para>Variant type: VT_R8</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_RangeValueSmallChangePropertyId = 30052,

		/// <summary>
		/// Identifies the Value property of the RangeValue control pattern.
		/// <para>This property is the current value of the automation element.</para>
		/// <para>Variant type: VT_R8</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_RangeValueValuePropertyId = 30047,

		/// <summary>
		/// Identifies the HorizontallyScrollable property of the Scroll control pattern.
		/// <para>This property indicates whether the automation element can scroll horizontally.</para>
		/// <para>Variant type: VT_BOOL</para>
		/// <para>Default value: FALSE</para>
		/// </summary>
		UIA_ScrollHorizontallyScrollablePropertyId = 30057,

		/// <summary>
		/// Identifies the HorizontalScrollPercent property of the Scroll control pattern.
		/// <para>
		/// This property is the current horizontal scroll position expressed as a percentage of the total content area within the automation element.
		/// </para>
		/// <para>Variant type: VT_R8</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_ScrollHorizontalScrollPercentPropertyId = 30053,

		/// <summary>
		/// Identifies the HorizontalViewSize property of the Scroll control pattern.
		/// <para>
		/// This property is the horizontal size of the viewable region expressed as a percentage of the total content area within the element.
		/// </para>
		/// <para>Variant type: VT_R8</para>
		/// <para>Default value: 100</para>
		/// </summary>
		UIA_ScrollHorizontalViewSizePropertyId = 30054,

		/// <summary>
		/// Identifies the VerticallyScrollable property of the Scroll control pattern.
		/// <para>This property indicates whether the automation element can scroll vertically.</para>
		/// <para>Variant type: VT_BOOL</para>
		/// <para>Default value: FALSE</para>
		/// </summary>
		UIA_ScrollVerticallyScrollablePropertyId = 30058,

		/// <summary>
		/// Identifies the VerticalScrollPercent property of the Scroll control pattern.
		/// <para>
		/// This property is the current vertical scroll position expressed as a percentage of the total content area within the automation element.
		/// </para>
		/// <para>Variant type: VT_R8</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_ScrollVerticalScrollPercentPropertyId = 30055,

		/// <summary>
		/// Identifies the VerticalViewSize property of the Scroll control pattern.
		/// <para>
		/// This property is the vertical size of the viewable region expressed as a percentage of the total content area within the element.
		/// </para>
		/// <para>Variant type: VT_R8</para>
		/// <para>Default value: 100</para>
		/// </summary>
		UIA_ScrollVerticalViewSizePropertyId = 30056,

		/// <summary>
		/// Identifies the CanSelectMultiple property of the Selection control pattern.
		/// <para>This property indicates whether the automation element allows more than one child element to be selected concurrently.</para>
		/// <para>Variant type: VT_BOOL</para>
		/// <para>Default value: FALSE</para>
		/// </summary>
		UIA_SelectionCanSelectMultiplePropertyId = 30060,

		/// <summary>
		/// Identifies the IsSelectionRequired property of the Selection control pattern.
		/// <para>This property indicates whether the automation element requires at least one child item to be selected.</para>
		/// <para>Variant type: VT_BOOL</para>
		/// <para>Default value: FALSE</para>
		/// </summary>
		UIA_SelectionIsSelectionRequiredPropertyId = 30061,

		/// <summary>
		/// Identifies the Selection property of the Selection control pattern.
		/// <para>This property is a collection of the selected child elements, and is expressed as an IUIAutomationElementArray pointer.</para>
		/// <para>Variant type: VT_UNKNOWN | VT_ARRAY</para>
		/// <para>Default value: empty array</para>
		/// </summary>
		UIA_SelectionSelectionPropertyId = 30059,

		/// <summary>
		/// Identifies the IsSelected property of the SelectionItem control pattern.
		/// <para>This property indicates whether the automation element is selected.</para>
		/// <para>Variant type: VT_BOOL</para>
		/// <para>Default value: FALSE</para>
		/// </summary>
		UIA_SelectionItemIsSelectedPropertyId = 30079,

		/// <summary>
		/// Identifies the SelectionContainer property of the SelectionItem control pattern.
		/// <para>This property is the IUIAutomationElement interface pointer for the automation element that contains the current element.</para>
		/// <para>Variant type: VT_UNKNOWN</para>
		/// <para>Default value: NULL</para>
		/// </summary>
		UIA_SelectionItemSelectionContainerPropertyId = 30080,

		/// <summary>
		/// Identifies the Formula property of the SpreadsheetItem control pattern.
		/// <para>This property is a string that contains the formula for the spreadsheet cell. Supported starting with Windows 8.</para>
		/// <para>Variant type: VT_BSTR</para>
		/// <para>Default value: empty string</para>
		/// </summary>
		UIA_SpreadsheetItemFormulaPropertyId = 30129,

		/// <summary>
		/// Identifies the AnnotationObjects property of the SpreadsheetItem control pattern.
		/// <para>
		/// This property is a collection of UI Automation elements representing the annotations associated with the spreadsheet cell. The
		/// collection is expressed as an IUIAutomationElementArray interface. Supported starting with Windows 8.
		/// </para>
		/// <para>Variant type: VT_UNKNOWN | VT_ARRAY</para>
		/// <para>Default value: empty array</para>
		/// </summary>
		UIA_SpreadsheetItemAnnotationObjectsPropertyId = 30130,

		/// <summary>
		/// Identifies the AnnotationTypes property of the SpreadsheetItem control pattern. Supported starting with Windows 8.
		/// <para>
		/// This property is array of annotation type identifiers, one for each type of annotation associated with the spreadsheet cell. For
		/// a list of possible values, see Annotation Type Identifiers.
		/// </para>
		/// <para>Variant type: VT_I4 | VT_ARRAY</para>
		/// <para>Default value: empty array</para>
		/// </summary>
		UIA_SpreadsheetItemAnnotationTypesPropertyId = 30131,

		/// <summary>
		/// Identifies the ExtendedProperties property of the Styles control pattern.
		/// <para>
		/// This property contains a localized, formatted string that contains additional properties that are not included in the Styles
		/// control pattern, but that provide information about the document content that might be useful to the user. The format of the
		/// string is as follows: "prop1=value;prop2=value2". Supported starting with Windows 8.
		/// </para>
		/// <para>Variant type: VT_BSTR</para>
		/// <para>Default value: empty string</para>
		/// </summary>
		UIA_StylesExtendedPropertiesPropertyId = 30126,

		/// <summary>
		/// Identifies the FillColor property of the Styles control pattern.
		/// <para>
		/// This property specifies the color used to fill an element. This property is expressed as a COLORREF, a 32-bit value used to
		/// specify an RGB or RGBA color. Supported starting with Windows 8.
		/// </para>
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_StylesFillColorPropertyId = 30122,

		/// <summary>
		/// Identifies the FillPatternColor property of the Styles control pattern.
		/// <para>
		/// This property specifies the color of the pattern used to fill an element. This property is expressed as a COLORREF, a 32-bit
		/// value used to specify an RGB or RGBA color. Supported starting with Windows 8.
		/// </para>
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_StylesFillPatternColorPropertyId = 30125,

		/// <summary>
		/// Identifies the FillPatternStyle property of the Styles control pattern.
		/// <para>
		/// This property is a localized string that contains the style of the pattern used to fill an element, such as "Vertical Stripe".
		/// Supported starting with Windows 8.
		/// </para>
		/// <para>Variant type: VT_BSTR</para>
		/// <para>Default value: empty string</para>
		/// </summary>
		UIA_StylesFillPatternStylePropertyId = 30123,

		/// <summary>
		/// Identifies the Shape property of the Styles control pattern.
		/// <para>This property is a localized string that indicates the shape of the element. Supported starting with Windows 8.</para>
		/// <para>Variant type: VT_BSTR</para>
		/// <para>Default value: empty string</para>
		/// </summary>
		UIA_StylesShapePropertyId = 30124,

		/// <summary>
		/// Identifies the StyleId property of the Styles control pattern.
		/// <para>
		/// This property identifies the visual style of the element. For a list of possible values, see Style Identifiers. Supported
		/// starting with Windows 8.
		/// </para>
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_StylesStyleIdPropertyId = 30120,

		/// <summary>
		/// Identifies the StyleName property of the Styles control pattern.
		/// <para>This property is the name of the visual style of the element. Supported starting with Windows 8.</para>
		/// <para>Variant type: VT_BSTR</para>
		/// <para>Default value: empty string</para>
		/// </summary>
		UIA_StylesStyleNamePropertyId = 30121,

		/// <summary>
		/// Identifies the ColumnHeaders property of the Table control pattern.
		/// <para>
		/// This property is a collection of automation elements for all column headers in the table, and is expressed as an
		/// IUIAutomationElementArray interface pointer.
		/// </para>
		/// <para>Variant type: VT_UNKNOWN | VT_ARRAY</para>
		/// <para>Default value: empty array</para>
		/// </summary>
		UIA_TableColumnHeadersPropertyId = 30082,

		/// <summary>
		/// Identifies the ColumnHeaderItems property of the TableItem control pattern.
		/// <para>
		/// This property is a collection of automation elements for all column headers in the table item or cell, and is expressed as an
		/// IUIAutomationElementArray interface pointer.
		/// </para>
		/// <para>Variant type: VT_UNKNOWN | VT_ARRAY</para>
		/// <para>Default value: empty array</para>
		/// </summary>
		UIA_TableItemColumnHeaderItemsPropertyId = 30085,

		/// <summary>
		/// Identifies the RowHeaders property of the Table control pattern.
		/// <para>
		/// This property is a collection of automation elements for all row headers in the table, and is expressed as an
		/// IUIAutomationElementArray interface pointer.
		/// </para>
		/// <para>Variant type: VT_UNKNOWN | VT_ARRAY</para>
		/// <para>Default value: empty array</para>
		/// </summary>
		UIA_TableRowHeadersPropertyId = 30081,

		/// <summary>
		/// Identifies the RowOrColumnMajor property of the Table control pattern.
		/// <para>
		/// This property indicates the primary direction of traversal for the table, and is expressed as a value from the RowOrColumnMajor
		/// enumerated type.
		/// </para>
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: RowOrColumnMajor_Indeterminate</para>
		/// </summary>
		UIA_TableRowOrColumnMajorPropertyId = 30083,

		/// <summary>
		/// Identifies the RowHeaderItems property of the TableItem control pattern.
		/// <para>
		/// This property is a collection of automation elements for all row headers in the table item or cell, and is expressed as an
		/// IUIAutomationElementArray interface pointer.
		/// </para>
		/// <para>Variant type: VT_UNKNOWN | VT_ARRAY</para>
		/// <para>Default value: empty array</para>
		/// </summary>
		UIA_TableItemRowHeaderItemsPropertyId = 30084,

		/// <summary>
		/// Identifies the ToggleState property of the Toggle control pattern.
		/// <para>
		/// This property indicates the toggle state of the automation element, and is expressed as a value from the ToggleState enumerated type.
		/// </para>
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: ToggleState_Indeterminate</para>
		/// </summary>
		UIA_ToggleToggleStatePropertyId = 30086,

		/// <summary>
		/// Identifies the CanMove property of the Transform control pattern.
		/// <para>This property indicates whether the automation element can be moved.</para>
		/// <para>Variant type: VT_BOOL</para>
		/// <para>Default value: FALSE</para>
		/// </summary>
		UIA_TransformCanMovePropertyId = 30087,

		/// <summary>
		/// Identifies the CanResize property of the Transform control pattern.
		/// <para>This property indicates whether the automation element can be resized.</para>
		/// <para>Variant type: VT_BOOL</para>
		/// <para>Default value: FALSE</para>
		/// </summary>
		UIA_TransformCanResizePropertyId = 30088,

		/// <summary>
		/// Identifies the CanRotate property of the Transform control pattern.
		/// <para>This property indicates whether the automation element can be rotated.</para>
		/// <para>Variant type: VT_BOOL</para>
		/// <para>Default value: FALSE</para>
		/// </summary>
		UIA_TransformCanRotatePropertyId = 30089,

		/// <summary>
		/// Identifies the CanZoom property of the Transform control pattern.
		/// <para>This property indicates whether the control supports zooming of its viewport. Supported starting with Windows 8.</para>
		/// <para>Variant type: VT_BOOL</para>
		/// <para>Default value: FALSE</para>
		/// </summary>
		UIA_Transform2CanZoomPropertyId = 30133,

		/// <summary>
		/// Identifies the ZoomLevel property of the Transform control pattern. Supported starting with Windows 8.
		/// <para>This property indicates the current zooming level of the control's viewport.</para>
		/// <para>Variant type: VT_R8</para>
		/// <para>Default value: 1</para>
		/// </summary>
		UIA_Transform2ZoomLevelPropertyId = 30145,

		/// <summary>
		/// Identifies the ZoomMaximum property of the Transform control pattern. Supported starting with Windows 8.
		/// <para>This property indicates the maximum zooming level supported by the control's viewport.</para>
		/// <para>Variant type: VT_R8</para>
		/// <para>Default value: 1</para>
		/// </summary>
		UIA_Transform2ZoomMaximumPropertyId = 30147,

		/// <summary>
		/// Identifies the ZoomMinimum property of the Transform control pattern. Supported starting with Windows 8.
		/// <para>This property indicates the minimum zooming level supported by the control's viewport.</para>
		/// <para>Variant type: VT_R8</para>
		/// <para>Default value: 1</para>
		/// </summary>
		UIA_Transform2ZoomMinimumPropertyId = 30146,

		/// <summary>
		/// Identifies the IsReadOnly property of the Value control pattern.
		/// <para>This property indicates whether the value of the automation element is read-only.</para>
		/// <para>Variant type: VT_BOOL</para>
		/// <para>Default value: TRUE</para>
		/// </summary>
		UIA_ValueIsReadOnlyPropertyId = 30046,

		/// <summary>
		/// Identifies the Value property of the Value control pattern.
		/// <para>This property indicates the value of the automation element.</para>
		/// <para>Variant type: VT_BSTR</para>
		/// <para>Default value: empty string</para>
		/// </summary>
		UIA_ValueValuePropertyId = 30045,

		/// <summary>
		/// Identifies the CanMaximize property of the Window control pattern.
		/// <para>This property indicates whether the window can be maximized.</para>
		/// <para>Variant type: VT_BOOL</para>
		/// <para>Default value: FALSE</para>
		/// </summary>
		UIA_WindowCanMaximizePropertyId = 30073,

		/// <summary>
		/// Identifies the CanMinimize property of the Window control pattern.
		/// <para>This property indicates whether the window can be minimized.</para>
		/// <para>Variant type: VT_BOOL</para>
		/// <para>Default value: FALSE</para>
		/// </summary>
		UIA_WindowCanMinimizePropertyId = 30074,

		/// <summary>
		/// Identifies the IsModal property of the Window control pattern.
		/// <para>This property indicates whether the window is modal.</para>
		/// <para>Variant type: VT_BOOL</para>
		/// <para>Default value: FALSE</para>
		/// </summary>
		UIA_WindowIsModalPropertyId = 30077,

		/// <summary>
		/// Identifies the IsTopmost property of the Window control pattern.
		/// <para>This property indicates whether the window is the topmost element in the z-order.</para>
		/// <para>Variant type: VT_BOOL</para>
		/// <para>Default value: FALSE</para>
		/// </summary>
		UIA_WindowIsTopmostPropertyId = 30078,

		/// <summary>
		/// Identifies the WindowInteractionState property of the Window control pattern.
		/// <para>
		/// This property indicates the state of the window for the purposes of user interaction, and is expressed as a value from the
		/// WindowInteractionState enumerated type.
		/// </para>
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: WindowInteractionState_Running</para>
		/// </summary>
		UIA_WindowWindowInteractionStatePropertyId = 30076,

		/// <summary>
		/// Identifies the WindowVisualState property of the Window control pattern.
		/// <para>
		/// This property indicates the visual state of the window, and is expressed as a value from the WindowVisualState enumerated type.
		/// </para>
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: WindowVisualState_Normal</para>
		/// </summary>
		UIA_WindowWindowVisualStatePropertyId = 30075,

		/// <summary>
		/// Identifies the IsAnnotationPatternAvailable property, which indicates whether the Annotation control pattern is available for the
		/// automation element. If TRUE, a client can retrieve an IUIAutomationAnnotationPattern interface from the element. Supported
		/// starting with Windows 8.
		/// </summary>
		UIA_IsAnnotationPatternAvailablePropertyId = 30118,

		/// <summary>
		/// Identifies the IsCustomNavigationPatternAvailable property, which indicates whether the CustomNavigation control pattern is
		/// available for the automation element. If TRUE, a client can retrieve an IUIAutomationCustomNavigationPattern interface from the
		/// element. Supported starting with Windows 10.
		/// </summary>
		UIA_IsCustomNavigationPatternAvailablePropertyId = 30151,

		/// <summary>
		/// Identifies the IsDockPatternAvailable property, which indicates whether the Dock control pattern is available for the automation
		/// element. If TRUE, a client can retrieve an IUIAutomationDockPattern interface from the element.
		/// </summary>
		UIA_IsDockPatternAvailablePropertyId = 30027,

		/// <summary>
		/// Identifies the IsDragPatternAvailable property, which indicates whether the Drag control pattern is available for the automation
		/// element. If TRUE, a client can retrieve an IUIAutomationDragPattern interface from the element. Supported starting with Windows 8.
		/// </summary>
		UIA_IsDragPatternAvailablePropertyId = 30137,

		/// <summary>
		/// Identifies the IsDropTargetPatternAvailable property, which indicates whether the DropTarget control pattern is available for the
		/// automation element. If TRUE, a client can retrieve an IUIAutomationDropTargetPattern interface from the element. Supported
		/// starting with Windows 8.
		/// </summary>
		UIA_IsDropTargetPatternAvailablePropertyId = 30141,

		/// <summary>
		/// Identifies the IsExpandCollapsePatternAvailable property, which indicates whether the ExpandCollapse control pattern is available
		/// for the automation element. If TRUE, a client can retrieve an IUIAutomationExpandCollapsePattern interface from the element.
		/// </summary>
		UIA_IsExpandCollapsePatternAvailablePropertyId = 30028,

		/// <summary>
		/// Identifies the IsGridItemPatternAvailable property, which indicates whether the GridItem control pattern is available for the
		/// automation element. If TRUE, a client can retrieve an IUIAutomationGridItemPattern interface from the element.
		/// </summary>
		UIA_IsGridItemPatternAvailablePropertyId = 30029,

		/// <summary>
		/// Identifies the IsGridPatternAvailable property, which indicates whether the Grid control pattern is available for the automation
		/// element. If TRUE, a client can retrieve an IUIAutomationGridPattern interface from the element.
		/// </summary>
		UIA_IsGridPatternAvailablePropertyId = 30030,

		/// <summary>
		/// Identifies the IsInvokePatternAvailable property, which indicates whether the Invoke control pattern is available for the
		/// automation element. If TRUE, a client can retrieve an IUIAutomationInvokePattern interface from the element.
		/// </summary>
		UIA_IsInvokePatternAvailablePropertyId = 30031,

		/// <summary>
		/// Identifies the IsItemContainerPatternAvailable property, which indicates whether the ItemContainer control pattern is available
		/// for the automation element. If TRUE, a client can retrieve an IUIAutomationItemContainerPattern interface from the element.
		/// </summary>
		UIA_IsItemContainerPatternAvailablePropertyId = 30108,

		/// <summary>
		/// Identifies the IsLegacyIAccessiblePatternAvailable property, which indicates whether the LegacyIAccessible control pattern is
		/// available for the automation element. If TRUE, a client can retrieve an IUIAutomationLegacyIAccessiblePattern interface from the element.
		/// </summary>
		UIA_IsLegacyIAccessiblePatternAvailablePropertyId = 30090,

		/// <summary>
		/// Identifies the IsMultipleViewPatternAvailable property, which indicates whether the MultipleView control pattern is available for
		/// the automation element. If TRUE, a client can retrieve an IUIAutomationMultipleViewPattern interface from the element.
		/// </summary>
		UIA_IsMultipleViewPatternAvailablePropertyId = 30032,

		/// <summary>
		/// Identifies the IsObjectModelPatternAvailable property, which indicates whether the ObjectModel control pattern is available for
		/// the automation element. If TRUE, a client can retrieve an IUIAutomationObjectModelPattern interface from the element. Supported
		/// starting with Windows 8.
		/// </summary>
		UIA_IsObjectModelPatternAvailablePropertyId = 30112,

		/// <summary>
		/// Identifies the IsRangeValuePatternAvailable property, which indicates whether the RangeValue control pattern is available for the
		/// automation element. If TRUE, a client can retrieve an IUIAutomationRangeValuePattern interface from the element.
		/// </summary>
		UIA_IsRangeValuePatternAvailablePropertyId = 30033,

		/// <summary>
		/// Identifies the IsScrollItemPatternAvailable property, which indicates whether the ScrollItem control pattern is available for the
		/// automation element. If TRUE, a client can retrieve an IUIAutomationScrollItemPattern interface from the element.
		/// </summary>
		UIA_IsScrollItemPatternAvailablePropertyId = 30035,

		/// <summary>
		/// Identifies the IsScrollPatternAvailable property, which indicates whether the Scroll control pattern is available for the
		/// automation element. If TRUE, a client can retrieve an IUIAutomationScrollPattern interface from the element.
		/// </summary>
		UIA_IsScrollPatternAvailablePropertyId = 30034,

		/// <summary>
		/// Identifies the IsSelectionItemPatternAvailable property, which indicates whether the SelectionItem control pattern is available
		/// for the automation element. If TRUE, a client can retrieve an IUIAutomationSelectionItemPattern interface from the element.
		/// </summary>
		UIA_IsSelectionItemPatternAvailablePropertyId = 30036,

		/// <summary>
		/// Identifies the IsSelectionPatternAvailable property, which indicates whether the Selection control pattern is available for the
		/// automation element. If TRUE, a client can retrieve an IUIAutomationSelectionPattern interface from the element.
		/// </summary>
		UIA_IsSelectionPatternAvailablePropertyId = 30037,

		/// <summary>
		/// Identifies the IsSpreadsheetPatternAvailable property, which indicates whether the Spreadsheet control pattern is available for
		/// the automation element. If TRUE, a client can retrieve an IUIAutomationSpreadsheetPattern interface from the element. Supported
		/// starting with Windows 8.
		/// </summary>
		UIA_IsSpreadsheetPatternAvailablePropertyId = 30128,

		/// <summary>
		/// Identifies the IsSpreadsheetItemPatternAvailable property, which indicates whether the SpreadsheetItem control pattern is
		/// available for the automation element. If TRUE, a client can retrieve an IUIAutomationSpreadsheetItemPattern interface from the
		/// element. Supported starting with Windows 8.
		/// </summary>
		UIA_IsSpreadsheetItemPatternAvailablePropertyId = 30132,

		/// <summary>
		/// Identifies the IsStylesPatternAvailable property, which indicates whether the Styles control pattern is available for the
		/// automation element. If TRUE, a client can retrieve an IUIAutomationStylesPattern interface from the element. Supported starting
		/// with Windows 8.
		/// </summary>
		UIA_IsStylesPatternAvailablePropertyId = 30127,

		/// <summary>
		/// Identifies the IsSynchronizedInputPatternAvailable property, which indicates whether the SynchronizedInput control pattern is
		/// available for the automation element. If TRUE, a client can retrieve an IUIAutomationSynchronizedInputPattern interface from the element.
		/// </summary>
		UIA_IsSynchronizedInputPatternAvailablePropertyId = 30110,

		/// <summary>
		/// Identifies the IsTableItemPatternAvailable property, which indicates whether the TableItem control pattern is available for the
		/// automation element. If TRUE, a client can retrieve an IUIAutomationTableItemPattern interface from the element.
		/// </summary>
		UIA_IsTableItemPatternAvailablePropertyId = 30039,

		/// <summary>
		/// Identifies the IsTablePatternAvailable property, which indicates whether the Table control pattern is available for the
		/// automation element. If TRUE, a client can retrieve an IUIAutomationTablePattern interface from the element.
		/// </summary>
		UIA_IsTablePatternAvailablePropertyId = 30038,

		/// <summary>
		/// Identifies the IsTextChildPatternAvailable property, which indicates whether the TextChild control pattern is available for the
		/// automation element. If TRUE, a client can retrieve an IUIAutomationTextChildPattern interface from the element. Supported
		/// starting with Windows 8.
		/// </summary>
		UIA_IsTextChildPatternAvailablePropertyId = 30136,

		/// <summary>
		/// Identifies the IsTextEditPatternAvailable property, which indicates whether the TextEdit control pattern is available for the
		/// automation element. If TRUE, a client can retrieve an IUIAutomationTextEditPattern interface from the element. Supported starting
		/// with Windows 8.1.
		/// </summary>
		UIA_IsTextEditPatternAvailablePropertyId = 30149,

		/// <summary>
		/// Identifies the IsTextPatternAvailable property, which indicates whether the Text control pattern is available for the automation
		/// element. If TRUE, a client can retrieve an IUIAutomationTextPattern interface from the element.
		/// </summary>
		UIA_IsTextPatternAvailablePropertyId = 30040,

		/// <summary>
		/// Identifies the IsTextPattern2Available property, which indicates whether version two of the Text control pattern is available for
		/// the automation element. If TRUE, a client can retrieve an IUIAutomationTextPattern2 interface from the element. Supported
		/// starting with Windows 8.
		/// </summary>
		UIA_IsTextPattern2AvailablePropertyId = 30119,

		/// <summary>
		/// Identifies the IsTogglePatternAvailable property, which indicates whether the Toggle control pattern is available for the
		/// automation element. If TRUE, a client can retrieve an IUIAutomationTogglePattern interface from the element.
		/// </summary>
		UIA_IsTogglePatternAvailablePropertyId = 30041,

		/// <summary>
		/// Identifies the IsTransformPatternAvailable property, which indicates whether the Transform control pattern is available for the
		/// automation element. If TRUE, a client can retrieve an IUIAutomationTransformPattern interface from the element.
		/// </summary>
		UIA_IsTransformPatternAvailablePropertyId = 30042,

		/// <summary>
		/// Identifies the IsTransformPattern2Available property, which indicates whether version two of the Transform control pattern is
		/// available for the automation element. If TRUE, a client can retrieve an IUIAutomationTransformPattern2 interface from the
		/// element. Supported starting with Windows 8.
		/// </summary>
		UIA_IsTransformPattern2AvailablePropertyId = 30134,

		/// <summary>
		/// Identifies the IsValuePatternAvailable property, which indicates whether the Value control pattern is available for the
		/// automation element. If TRUE, a client can retrieve an IUIAutomationValuePattern interface from the element.
		/// </summary>
		UIA_IsValuePatternAvailablePropertyId = 30043,

		/// <summary>
		/// Identifies the IsVirtualizedItemPatternAvailable property, which indicates whether the VirtualizedItem control pattern is
		/// available for the automation element. If TRUE, a client can retrieve an IUIAutomationVirtualizedItemPattern interface from the element.
		/// </summary>
		UIA_IsVirtualizedItemPatternAvailablePropertyId = 30109,

		/// <summary>
		/// Identifies the IsWindowPatternAvailable property, which indicates whether the Window control pattern is available for the
		/// automation element. If TRUE, a client can retrieve an IUIAutomationWindowPattern interface from the element.
		/// </summary>
		UIA_IsWindowPatternAvailablePropertyId = 30044,
	}

	/// <summary>Describes the named constants used to identify text attributes of a Microsoft UI Automation text range.</summary>
	[PInvokeData("UIAutomationClient.h")]
	public enum TEXTATTRIBUTEID
	{
		/// <summary>
		/// Identifies the AfterParagraphSpacing text attribute, which specifies the size of spacing after the paragraph.
		/// <para>Variant type: VT_R8</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_AfterParagraphSpacingAttributeId = 40042,

		/// <summary>
		/// Identifies the AnimationStyle text attribute, which specifies the type of animation applied to the text. This attribute is
		/// specified as a value from the AnimationStyle enumerated type.
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: AnimationStyle_None</para>
		/// </summary>
		UIA_AnimationStyleAttributeId = 40000,

		/// <summary>
		/// Identifies the AnnotationObjects text attribute, which maintains an array of IUIAutomationElement2 interfaces, one for each
		/// element in the current text range that implements the Annotation control pattern. Each element might also implement other control
		/// patterns as needed to describe the annotation. For example, an annotation that is a comment would also support the Text control
		/// pattern. Supported starting with Windows 8.
		/// <para>Variant type: VT_UNKNOWN</para>
		/// <para>Default value: empty array</para>
		/// </summary>
		UIA_AnnotationObjectsAttributeId = 40032,

		/// <summary>
		/// Identifies the AnnotationTypes text attribute, which maintains a list of annotation type identifiers for a range of text. For a
		/// list of possible values, see Annotation Type Identifiers. Supported starting with Windows 8.
		/// <para>Variant type: VT_ARRAY</para>
		/// <para>VT_I4</para>
		/// <para>Default value: empty array</para>
		/// </summary>
		UIA_AnnotationTypesAttributeId = 40031,

		/// <summary>
		/// Identifies the BackgroundColor text attribute, which specifies the background color of the text. This attribute is specified as a
		/// COLORREF; a 32-bit value used to specify an RGB or RGBA color.
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_BackgroundColorAttributeId = 40001,

		/// <summary>
		/// Identifies the BeforeParagraphSpacing text attribute, which specifies the size of spacing before the paragraph.
		/// <para>Variant type: VT_R8</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_BeforeParagraphSpacingAttributeId = 40041,

		/// <summary>
		/// Identifies the BulletStyle text attribute, which specifies the style of bullets used in the text range. This attribute is
		/// specified as a value from the BulletStyle enumerated type.
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: BulletStyle_None</para>
		/// </summary>
		UIA_BulletStyleAttributeId = 40002,

		/// <summary>
		/// Identifies the CapStyle text attribute, which specifies the capitalization style for the text. This attribute is specified as a
		/// value from the CapStyle enumerated type.
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: CapStyle_None</para>
		/// </summary>
		UIA_CapStyleAttributeId = 40003,

		/// <summary>
		/// Identifies the CaretBidiMode text attribute, which indicates the direction of text flow in the text range. This attribute is
		/// specified as a value from the CaretBidiMode enumerated type. Supported starting with Windows 8.
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: CaretBidiMode_LTR</para>
		/// </summary>
		UIA_CaretBidiModeAttributeId = 40039,

		/// <summary>
		/// Identifies the CaretPosition text attribute, which indicates whether the caret is at the beginning or the end of a line of text
		/// in the text range. This attribute is specified as a value from the CaretPosition enumerated type. Supported starting with Windows 8.
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: CaretPosition_Unknown</para>
		/// </summary>
		UIA_CaretPositionAttributeId = 40038,

		/// <summary>
		/// Identifies the Culture text attribute, which specifies the locale of the text by locale identifier (LCID).
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: locale of the application UI</para>
		/// </summary>
		UIA_CultureAttributeId = 40004,

		/// <summary>
		/// Identifies the FontName text attribute, which specifies the name of the font. Examples: "Arial Black"; "Arial Narrow". The font
		/// name string is not localized.
		/// <para>Variant type: VT_BSTR</para>
		/// <para>Default value: empty string</para>
		/// </summary>
		UIA_FontNameAttributeId = 40005,

		/// <summary>
		/// Identifies the FontSize text attribute, which specifies the point size of the font.
		/// <para>Variant type: VT_R8</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_FontSizeAttributeId = 40006,

		/// <summary>
		/// Identifies the FontWeight text attribute, which specifies the relative stroke, thickness, or boldness of the font. The FontWeight
		/// attribute is modeled after the lfWeight member of the GDI LOGFONT structure, and related standards, and can be one of the
		/// following values:
		/// <para>0 = DontCare</para>
		/// <para>100 = Thin</para>
		/// <para>200 = ExtraLight or UltraLight</para>
		/// <para>300 = Light</para>
		/// <para>400 = Normal or Regular</para>
		/// <para>500 = Medium</para>
		/// <para>600 = SemiBold</para>
		/// <para>700 = Bold</para>
		/// <para>800 = ExtraBold or UltraBold</para>
		/// <para>900 = Heavy or Black</para>
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_FontWeightAttributeId = 40007,

		/// <summary>
		/// Identifies the ForegroundColor text attribute, which specifies the foreground color of the text. This attribute is specified as a
		/// COLORREF, a 32-bit value used to specify an RGB or RGBA color.
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_ForegroundColorAttributeId = 40008,

		/// <summary>
		/// Identifies the HorizontalTextAlignment text attribute, which specifies how the text is aligned horizontally. This attribute is
		/// specified as a value from the HorizontalTextAlignmentEnum enumerated type.
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: HorizontalTextAlignment_Left</para>
		/// </summary>
		UIA_HorizontalTextAlignmentAttributeId = 40009,

		/// <summary>
		/// Identifies the IndentationFirstLine text attribute, which specifies how far, in points, to indent the first line of a paragraph.
		/// <para>Variant type: VT_R8</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_IndentationFirstLineAttributeId = 40010,

		/// <summary>
		/// Identifies the IndentationLeading text attribute, which specifies the leading indentation, in points.
		/// <para>Variant type: VT_R8</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_IndentationLeadingAttributeId = 40011,

		/// <summary>
		/// Identifies the IndentationTrailing text attribute, which specifies the trailing indentation, in points.
		/// <para>Variant type: VT_R8</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_IndentationTrailingAttributeId = 40012,

		/// <summary>
		/// Identifies the IsActive text attribute, which indicates whether the control that contains the text range has the keyboard focus
		/// (TRUE) or not (FALSE). Supported starting with Windows 8.
		/// <para>Variant type: VT_BOOL</para>
		/// <para>Default value: FALSE</para>
		/// </summary>
		UIA_IsActiveAttributeId = 40036,

		/// <summary>
		/// Identifies the IsHidden text attribute, which indicates whether the text is hidden (TRUE) or visible (FALSE).
		/// <para>Variant type: VT_BOOL</para>
		/// <para>Default value: FALSE</para>
		/// </summary>
		UIA_IsHiddenAttributeId = 40013,

		/// <summary>
		/// Identifies the IsItalic text attribute, which indicates whether the text is italic (TRUE) or not (FALSE).
		/// <para>Variant type: VT_BOOL</para>
		/// <para>Default value: FALSE</para>
		/// </summary>
		UIA_IsItalicAttributeId = 40014,

		/// <summary>
		/// Identifies the IsReadOnly text attribute, which indicates whether the text is read-only (TRUE) or can be modified (FALSE).
		/// <para>Variant type: VT_BOOL</para>
		/// <para>Default value: FALSE</para>
		/// </summary>
		UIA_IsReadOnlyAttributeId = 40015,

		/// <summary>
		/// Identifies the IsSubscript text attribute, which indicates whether the text is subscript (TRUE) or not (FALSE).
		/// <para>Variant type: VT_BOOL</para>
		/// <para>Default value: FALSE</para>
		/// </summary>
		UIA_IsSubscriptAttributeId = 40016,

		/// <summary>
		/// Identifies the IsSuperscript text attribute, which indicates whether the text is subscript (TRUE) or not (FALSE).
		/// <para>Variant type: VT_BOOL</para>
		/// <para>Default value: FALSE</para>
		/// </summary>
		UIA_IsSuperscriptAttributeId = 40017,

		/// <summary>
		/// Identifies the LineSpacing text attribute, which specifies the spacing between lines of text.
		/// <para>Variant type: VT_BSTR</para>
		/// <para>Default value: "LineSpacingAttributeDefault"</para>
		/// </summary>
		UIA_LineSpacingAttributeId = 40040,

		/// <summary>
		/// Identifies the Link text attribute, which contains the IUIAutomationTextRange interface of the text range that is the target of
		/// an internal link in a document. Supported starting with Windows 8.
		/// <para>Variant type: VT_UNKNOWN</para>
		/// <para>Default value: NULL</para>
		/// </summary>
		UIA_LinkAttributeId = 40035,

		/// <summary>
		/// Identifies the MarginBottom text attribute, which specifies the size, in points, of the bottom margin applied to the page
		/// associated with the text range.
		/// <para>Variant type: VT_R8</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_MarginBottomAttributeId = 40018,

		/// <summary>
		/// Identifies the MarginLeading text attribute, which specifies the size, in points, of the leading margin applied to the page
		/// associated with the text range.
		/// <para>Variant type: VT_R8</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_MarginLeadingAttributeId = 40019,

		/// <summary>
		/// Identifies the MarginTop text attribute, which specifies the size, in points, of the top margin applied to the page associated
		/// with the text range.
		/// <para>Variant type: VT_R8</para>
		/// <para>Ddefault value: 0</para>
		/// </summary>
		UIA_MarginTopAttributeId = 40020,

		/// <summary>
		/// Identifies the MarginTrailing text attribute, which specifies the size, in points, of the trailing margin applied to the page
		/// associated with the text range.
		/// <para>Variant type: VT_R8</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_MarginTrailingAttributeId = 40021,

		/// <summary>
		/// Identifies the OutlineStyles text attribute, which specifies the outline style of the text. This attribute is specified as a
		/// value from the OutlineStyles enumerated type.
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: OutlineStyles_None</para>
		/// </summary>
		UIA_OutlineStylesAttributeId = 40022,

		/// <summary>
		/// Identifies the OverlineColor text attribute, which specifies the color of the overline text decoration. This attribute is
		/// specified as a COLORREF, a 32-bit value used to specify an RGB or RGBA color.
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_OverlineColorAttributeId = 40023,

		/// <summary>
		/// Identifies the OverlineStyle text attribute, which specifies the style of the overline text decoration. This attribute is
		/// specified as a value from the TextDecorationLineStyleEnum enumerated type.
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: TextDecorationLineStyle_None</para>
		/// </summary>
		UIA_OverlineStyleAttributeId = 40024,

		/// <summary>
		/// Identifies the SelectionActiveEnd text attribute, which indicates the location of the caret relative to a text range that
		/// represents the currently selected text. This attribute is specified as a value from the ActiveEnd enumeration. Supported starting
		/// with Windows 8.
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: ActiveEnd_None</para>
		/// </summary>
		UIA_SelectionActiveEndAttributeId = 40037,

		/// <summary>
		/// Identifies the StrikethroughColor text attribute, which specifies the color of the strikethrough text decoration. This attribute
		/// is specified as a COLORREF, a 32-bit value used to specify an RGB or RGBA color.
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_StrikethroughColorAttributeId = 40025,

		/// <summary>
		/// Identifies the StrikethroughStyle text attribute, which specifies the style of the strikethrough text decoration. This attribute
		/// is specified as a value from the TextDecorationLineStyleEnum enumerated type.
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: TextDecorationLineStyle_None</para>
		/// </summary>
		UIA_StrikethroughStyleAttributeId = 40026,

		/// <summary>
		/// Identifies the StyleId text attribute, which indicates the text styles in use for a text range. For a list of possible values,
		/// see Style Identifiers. Supported starting with Windows 8.
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_StyleIdAttributeId = 40034,

		/// <summary>
		/// Identifies the StyleName text attribute, which identifies the localized name of the text style in use for a text range. Supported
		/// starting with Windows 8.
		/// <para>Variant type: VT_BSTR</para>
		/// <para>Default value: empty string</para>
		/// </summary>
		UIA_StyleNameAttributeId = 40033,

		/// <summary>
		/// Identifies the Tabs text attribute, which is an array specifying the tab stops for the text range. Each array element specifies a
		/// distance, in points, from the leading margin.
		/// <para>Variant type: VT_ARRAY | VT_R8</para>
		/// <para>Default value: empty array</para>
		/// </summary>
		UIA_TabsAttributeId = 40027,

		/// <summary>
		/// Identifies the TextFlowDirections text attribute, which specifies the direction of text flow. This attribute is specified as a
		/// combination of values from the FlowDirections enumerated type.
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: FlowDirections_Default</para>
		/// </summary>
		UIA_TextFlowDirectionsAttributeId = 40028,

		/// <summary>
		/// Identifies the UnderlineColor text attribute, which specifies the color of the underline text decoration. This attribute is
		/// specified as a COLORREF, a 32-bit value used to specify an RGB or RGBA color.
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: 0</para>
		/// </summary>
		UIA_UnderlineColorAttributeId = 40029,

		/// <summary>
		/// Identifies the UnderlineStyle text attribute, which specifies the style of the underline text decoration. This attribute is
		/// specified as a value from the TextDecorationLineStyleEnum enumerated type.
		/// <para>Variant type: VT_I4</para>
		/// <para>Default value: TextDecorationLineStyle_None</para>
		/// </summary>
		UIA_UnderlineStyleAttributeId = 40030,
	}
}