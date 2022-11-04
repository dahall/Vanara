using System;

namespace Vanara.PInvoke;

/// <summary>Items from the DirectManipulation.dll.</summary>
public static partial class DirectManipulation
{
	/// <term>Specifies a psuedo-pointer ID for emulating a touch contact through keyboard input.</term>
	public const uint DIRECTMANIPULATION_KEYBOARDFOCUS = 0xFFFFFFFE;

	/// <term>Specifies the minimum permitted zoom boundary of 10%.</term>
	public const float DIRECTMANIPULATION_MINIMUM_ZOOM = 0.1f;

	/// <term>Specifies a psuedo-pointer ID for emulating a touch contact through mouse input.</term>
	public const uint DIRECTMANIPULATION_MOUSEFOCUS = 0xfffffffd;

	/// <summary>Autoscroll Behavior. Enables content to automatically scroll as it approaches the boundary of a given axis.</summary>
	public static readonly Guid CLSID_AutoScrollBehavior = new(0x26126a51, 0x3c70, 0x4c9a, 0xae, 0xc2, 0x94, 0x88, 0x49, 0xee, 0xb0, 0x93);

	/// <summary>Contact deferral behavior. The amount of time (in millliseconds) to wait before calling SetContact.</summary>
	public static readonly Guid CLSID_DeferContactService = new(0xd7b67cf4, 0x84bb, 0x434e, 0x86, 0xae, 0x65, 0x92, 0xbb, 0xc9, 0xab, 0xd9);

	/// <summary>Drag & Drop Behavior. Enables items to be selected and dragged.</summary>
	public static readonly Guid CLSID_DragDropConfigurationBehavior = new(0x09b01b3e, 0xba6c, 0x454d, 0x82, 0xe8, 0x95, 0xe3, 0x52, 0x32, 0x9f, 0x23);

	/// <summary>Horizontal Panning Indicator. A visual element that shows your current position in content that extends off-screen horizontally.</summary>
	public static readonly Guid CLSID_HorizontalIndicatorContent = new(0xe7d18cf5, 0x3ec7, 0x44d5, 0xa7, 0x6b, 0x37, 0x70, 0xf3, 0xcf, 0x90, 0x3d);

	/// <summary>Vertical Panning Indicator. A visual element that shows your current position in content that extends off-screen vertically.</summary>
	public static readonly Guid CLSID_VerticalIndicatorContent = new(0xa10b5f17, 0xafe0, 0x4aa2, 0x91, 0xe9, 0x3e, 0x70, 0x1, 0xd2, 0xe6, 0xb4);

	/// <summary>Virtual Viewport. A virtual viewport can be used to respect fixed position elements for viewports with zoom configured.</summary>
	public static readonly Guid CLSID_VirtualViewportContent = new(0x3206a19a, 0x86f0, 0x4cb4, 0xa7, 0xf3, 0x16, 0xe3, 0xb7, 0xe2, 0xd8, 0x52);

	private const string Lib_DirectManipulation = "DirectManipulation.dll";

	/// <summary>Determines the type and direction of automatic scrolling animation to apply.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/ne-directmanipulation-directmanipulation_autoscroll_configuration
	// typedef enum DIRECTMANIPULATION_AUTOSCROLL_CONFIGURATION { DIRECTMANIPULATION_AUTOSCROLL_CONFIGURATION_STOP = 0,
	// DIRECTMANIPULATION_AUTOSCROLL_CONFIGURATION_FORWARD = 1, DIRECTMANIPULATION_AUTOSCROLL_CONFIGURATION_REVERSE = 2 } ;
	[PInvokeData("directmanipulation.h", MSDNShortId = "NE:directmanipulation.DIRECTMANIPULATION_AUTOSCROLL_CONFIGURATION")]
	public enum DIRECTMANIPULATION_AUTOSCROLL_CONFIGURATION
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>If content is scrolling, slowly stop along the direction of the motion.</para>
		/// </summary>
		DIRECTMANIPULATION_AUTOSCROLL_CONFIGURATION_STOP,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Scroll towards the positive boundary of the content.</para>
		/// </summary>
		DIRECTMANIPULATION_AUTOSCROLL_CONFIGURATION_FORWARD,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Scroll towards the origin of the content.</para>
		/// </summary>
		DIRECTMANIPULATION_AUTOSCROLL_CONFIGURATION_REVERSE,
	}

	/// <summary>Defines the interaction configuration states available in Direct Manipulation.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/ne-directmanipulation-directmanipulation_configuration typedef
	// enum DIRECTMANIPULATION_CONFIGURATION { DIRECTMANIPULATION_CONFIGURATION_NONE = 0, DIRECTMANIPULATION_CONFIGURATION_INTERACTION = 0x1,
	// DIRECTMANIPULATION_CONFIGURATION_TRANSLATION_X = 0x2, DIRECTMANIPULATION_CONFIGURATION_TRANSLATION_Y = 0x4,
	// DIRECTMANIPULATION_CONFIGURATION_SCALING = 0x10, DIRECTMANIPULATION_CONFIGURATION_TRANSLATION_INERTIA = 0x20,
	// DIRECTMANIPULATION_CONFIGURATION_SCALING_INERTIA = 0x80, DIRECTMANIPULATION_CONFIGURATION_RAILS_X = 0x100,
	// DIRECTMANIPULATION_CONFIGURATION_RAILS_Y = 0x200 } ;
	[PInvokeData("directmanipulation.h", MSDNShortId = "NE:directmanipulation.DIRECTMANIPULATION_CONFIGURATION")]
	[Flags]
	public enum DIRECTMANIPULATION_CONFIGURATION
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>No interaction is defined.</para>
		/// </summary>
		DIRECTMANIPULATION_CONFIGURATION_NONE = 0x0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>An interaction is defined. To enable interactions, this value must be included.</para>
		/// <para>Required when setting a configuration other than</para>
		/// <para>DIRECTMANIPULATION_CONFIGURATION_NONE</para>
		/// <para>.</para>
		/// </summary>
		DIRECTMANIPULATION_CONFIGURATION_INTERACTION = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>Translation in the horizontal axis.</para>
		/// </summary>
		DIRECTMANIPULATION_CONFIGURATION_TRANSLATION_X = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>Translation in the vertical axis.</para>
		/// </summary>
		DIRECTMANIPULATION_CONFIGURATION_TRANSLATION_Y = 0x4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10</para>
		/// <para>Zoom.</para>
		/// </summary>
		DIRECTMANIPULATION_CONFIGURATION_SCALING = 0x10,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x20</para>
		/// <para>Inertia for translation as defined by</para>
		/// <para>DIRECTMANIPULATION_CONFIGURATION_TRANSLATION_X</para>
		/// <para>and</para>
		/// <para>DIRECTMANIPULATION_CONFIGURATION_TRANSLATION_Y</para>
		/// <para>.</para>
		/// </summary>
		DIRECTMANIPULATION_CONFIGURATION_TRANSLATION_INERTIA = 0x20,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x80</para>
		/// <para>Inertia for zoom as defined by</para>
		/// <para>DIRECTMANIPULATION_CONFIGURATION _SCALING</para>
		/// <para>.</para>
		/// </summary>
		DIRECTMANIPULATION_CONFIGURATION_SCALING_INERTIA = 0x80,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x100</para>
		/// <para>Rails on the horizontal axis.</para>
		/// </summary>
		DIRECTMANIPULATION_CONFIGURATION_RAILS_X = 0x100,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x200</para>
		/// <para>Rails on the vertical axis.</para>
		/// </summary>
		DIRECTMANIPULATION_CONFIGURATION_RAILS_Y = 0x200,
	}

	/// <summary>Defines behaviors for the drag-drop interaction.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/ne-directmanipulation-directmanipulation_drag_drop_configuration
	// typedef enum DIRECTMANIPULATION_DRAG_DROP_CONFIGURATION { DIRECTMANIPULATION_DRAG_DROP_CONFIGURATION_VERTICAL = 0x1,
	// DIRECTMANIPULATION_DRAG_DROP_CONFIGURATION_HORIZONTAL = 0x2, DIRECTMANIPULATION_DRAG_DROP_CONFIGURATION_SELECT_ONLY = 0x10,
	// DIRECTMANIPULATION_DRAG_DROP_CONFIGURATION_SELECT_DRAG = 0x20, DIRECTMANIPULATION_DRAG_DROP_CONFIGURATION_HOLD_DRAG = 0x40 } ;
	[PInvokeData("directmanipulation.h", MSDNShortId = "NE:directmanipulation.DIRECTMANIPULATION_DRAG_DROP_CONFIGURATION")]
	[Flags]
	public enum DIRECTMANIPULATION_DRAG_DROP_CONFIGURATION
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>Specifies that vertical movement is applicable to the chosen gesture.</para>
		/// </summary>
		DIRECTMANIPULATION_DRAG_DROP_CONFIGURATION_VERTICAL = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>Specifies that horizontal movement is applicable to the chosen gesture.</para>
		/// </summary>
		DIRECTMANIPULATION_DRAG_DROP_CONFIGURATION_HORIZONTAL = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10</para>
		/// <para>Specifies that the gesture is to be cross-slide only.</para>
		/// </summary>
		DIRECTMANIPULATION_DRAG_DROP_CONFIGURATION_SELECT_ONLY = 0x10,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x20</para>
		/// <para>Specifies that the gesture is a drag initiated by cross-slide.</para>
		/// </summary>
		DIRECTMANIPULATION_DRAG_DROP_CONFIGURATION_SELECT_DRAG = 0x20,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x40</para>
		/// <para>Specifies that the gesture a drag initiated by press-and-hold.</para>
		/// </summary>
		DIRECTMANIPULATION_DRAG_DROP_CONFIGURATION_HOLD_DRAG = 0x40,
	}

	/// <summary>Defines the drag-and-drop interaction states for the viewport.</summary>
	/// <remarks>
	/// <para>
	/// For each interaction, the status always starts at <c>DIRECTMANIPULATION_DRAG_DROP_READY</c> and ends at either
	/// <c>DIRECTMANIPULATION_DRAG_DROP_CANCELLED</c> or <c>DIRECTMANIPULATION_DRAG_DROP_COMMITTED</c>. There are no explicit callbacks for
	/// the transition from CANCELLED/COMMITTED to READY.
	/// </para>
	/// <para>The meaning of the CANCELLED and COMMITTED values depend on the previous status.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// For <c>DIRECTMANIPULATION_DRAG_DROP_PRESELECT</c>, they mean the same thing: the content goes back to the original location and no
	/// other actions should be taken.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// FOR <c>DIRECTMANIPULATION_DRAG_DROP_SELECTING</c>, COMMITTED means apply the selection change; CANCELLED means avoid the selection change.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// For <c>DIRECTMANIPULATION_DRAG_DROP_DRAGGING</c>, COMMITTED means perform the drop action; CANCELLED means cancel the drop action.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/ne-directmanipulation-directmanipulation_drag_drop_status
	// typedef enum DIRECTMANIPULATION_DRAG_DROP_STATUS { DIRECTMANIPULATION_DRAG_DROP_READY = 0, DIRECTMANIPULATION_DRAG_DROP_PRESELECT = 1,
	// DIRECTMANIPULATION_DRAG_DROP_SELECTING = 2, DIRECTMANIPULATION_DRAG_DROP_DRAGGING = 3, DIRECTMANIPULATION_DRAG_DROP_CANCELLED = 4,
	// DIRECTMANIPULATION_DRAG_DROP_COMMITTED = 5 } ;
	[PInvokeData("directmanipulation.h", MSDNShortId = "NE:directmanipulation.DIRECTMANIPULATION_DRAG_DROP_STATUS")]
	public enum DIRECTMANIPULATION_DRAG_DROP_STATUS
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The viewport is at rest and ready for input.</para>
		/// </summary>
		DIRECTMANIPULATION_DRAG_DROP_READY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The viewport is updating its content and the content is not selected.</para>
		/// </summary>
		DIRECTMANIPULATION_DRAG_DROP_PRESELECT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>The viewport is updating its content and the content is selected.</para>
		/// </summary>
		DIRECTMANIPULATION_DRAG_DROP_SELECTING,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>The viewport is updating its content and the content is being dragged.</para>
		/// </summary>
		DIRECTMANIPULATION_DRAG_DROP_DRAGGING,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>The viewport has concluded the interaction and requests a revert.</para>
		/// </summary>
		DIRECTMANIPULATION_DRAG_DROP_CANCELLED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>The viewport has concluded the interaction and requests a commit.</para>
		/// </summary>
		DIRECTMANIPULATION_DRAG_DROP_COMMITTED,
	}

	/// <summary>Defines the gestures that can be passed to SetManualGesture.</summary>
	/// <remarks>
	/// <para>By default, Direct Manipulation always reassigns tap and press-and-hold gestures to the application.</para>
	/// <para>Use <c>DIRECTMANIPULATION_GESTURE_PINCH_ZOOM</c> to zoom instead of scale.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/ne-directmanipulation-directmanipulation_gesture_configuration
	// typedef enum DIRECTMANIPULATION_GESTURE_CONFIGURATION { DIRECTMANIPULATION_GESTURE_NONE = 0, DIRECTMANIPULATION_GESTURE_DEFAULT = 0, DIRECTMANIPULATION_GESTURE_CROSS_SLIDE_VERTICAL = 0x8, DIRECTMANIPULATION_GESTURE_CROSS_SLIDE_HORIZONTAL = 0x10, DIRECTMANIPULATION_GESTURE_PINCH_ZOOM = 0x20 } ;
	[PInvokeData("directmanipulation.h", MSDNShortId = "NE:directmanipulation.DIRECTMANIPULATION_GESTURE_CONFIGURATION")]
	public enum DIRECTMANIPULATION_GESTURE_CONFIGURATION
	{
		/// <summary>
		///   <para>Value:</para>
		///   <para>0</para>
		///   <para>No gestures are defined.</para>
		/// </summary>
		DIRECTMANIPULATION_GESTURE_NONE = 0x0,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0</para>
		///   <para>Only default gestures are supported. This is the default value.</para>
		/// </summary>
		DIRECTMANIPULATION_GESTURE_DEFAULT = 0x0,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x8</para>
		///   <para>Vertical slide and swipe gestures are supported through the cross-slide interaction. For more information, see</para>
		///   <para>Guidelines for cross-slide</para>
		///   <para>.</para>
		/// </summary>
		DIRECTMANIPULATION_GESTURE_CROSS_SLIDE_VERTICAL = 0x8,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x10</para>
		///   <para>Horizontal slide and swipe gestures are supported through the cross-slide interaction. For more information, see</para>
		///   <para>Guidelines for cross-slide</para>
		///   <para>.</para>
		/// </summary>
		DIRECTMANIPULATION_GESTURE_CROSS_SLIDE_HORIZONTAL = 0x10,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x20</para>
		///   <para>Pinch and stretch gestures for zooming.</para>
		/// </summary>
		DIRECTMANIPULATION_GESTURE_PINCH_ZOOM = 0x20,
	}

	/// <summary>Defines how hit testing is handled by Direct Manipulation when using a dedicated hit-test thread registered through RegisterHitTestTarget.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/ne-directmanipulation-directmanipulation_hittest_type typedef
	// enum DIRECTMANIPULATION_HITTEST_TYPE { DIRECTMANIPULATION_HITTEST_TYPE_ASYNCHRONOUS = 0, DIRECTMANIPULATION_HITTEST_TYPE_SYNCHRONOUS =
	// 0x1, DIRECTMANIPULATION_HITTEST_TYPE_AUTO_SYNCHRONOUS = 0x2 } ;
	[PInvokeData("directmanipulation.h", MSDNShortId = "NE:directmanipulation.DIRECTMANIPULATION_HITTEST_TYPE")]
	public enum DIRECTMANIPULATION_HITTEST_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The hit-test thread receives</para>
		/// <para>WM_POINTERDOWN</para>
		/// <para>messages and specifies whether to call</para>
		/// <para>SetContact</para>
		/// <para>. If</para>
		/// <para>SetContact</para>
		/// <para>is not called, the contact will not be associated with a viewport.</para>
		/// </summary>
		DIRECTMANIPULATION_HITTEST_TYPE_ASYNCHRONOUS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>The UI thread always receives</para>
		/// <para>WM_POINTERDOWN</para>
		/// <para>messages after the hit-test thread. A call to</para>
		/// <para>SetContact</para>
		/// <para>is not required.</para>
		/// </summary>
		DIRECTMANIPULATION_HITTEST_TYPE_SYNCHRONOUS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>The UI thread receives</para>
		/// <para>WM_POINTERDOWN</para>
		/// <para>messages only when</para>
		/// <para>SetContact</para>
		/// <para>isn't called by the hit-test thread.</para>
		/// </summary>
		DIRECTMANIPULATION_HITTEST_TYPE_AUTO_SYNCHRONOUS,
	}

	/// <summary>Defines the horizontal alignment options for content within a viewport.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/ne-directmanipulation-directmanipulation_horizontalalignment
	// typedef enum DIRECTMANIPULATION_HORIZONTALALIGNMENT { DIRECTMANIPULATION_HORIZONTALALIGNMENT_NONE = 0,
	// DIRECTMANIPULATION_HORIZONTALALIGNMENT_LEFT = 0x1, DIRECTMANIPULATION_HORIZONTALALIGNMENT_CENTER = 0x2,
	// DIRECTMANIPULATION_HORIZONTALALIGNMENT_RIGHT = 0x4, DIRECTMANIPULATION_HORIZONTALALIGNMENT_UNLOCKCENTER = 0x8 } ;
	[PInvokeData("directmanipulation.h", MSDNShortId = "NE:directmanipulation.DIRECTMANIPULATION_HORIZONTALALIGNMENT")]
	[Flags]
	public enum DIRECTMANIPULATION_HORIZONTALALIGNMENT
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>No alignment. The object can be positioned anywhere within the viewport.</para>
		/// </summary>
		DIRECTMANIPULATION_HORIZONTALALIGNMENT_NONE = 0x0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>Align object along the left side of the viewport.</para>
		/// </summary>
		DIRECTMANIPULATION_HORIZONTALALIGNMENT_LEFT = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>Align object to the center of the viewport.</para>
		/// </summary>
		DIRECTMANIPULATION_HORIZONTALALIGNMENT_CENTER = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>Align object along the right side of the viewport.</para>
		/// </summary>
		DIRECTMANIPULATION_HORIZONTALALIGNMENT_RIGHT = 0x4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8</para>
		/// <para>Content zooms around the center point of the contacts, instead of being locked with the horizontal alignment.</para>
		/// </summary>
		DIRECTMANIPULATION_HORIZONTALALIGNMENT_UNLOCKCENTER = 0x8,
	}

	/// <summary>
	/// Defines the threading behavior for SetInputMode or SetUpdateMode. The exact meaning of each constant depends on the method called.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/ne-directmanipulation-directmanipulation_input_mode typedef
	// enum DIRECTMANIPULATION_INPUT_MODE { DIRECTMANIPULATION_INPUT_MODE_AUTOMATIC = 0, DIRECTMANIPULATION_INPUT_MODE_MANUAL = 1 } ;
	[PInvokeData("directmanipulation.h", MSDNShortId = "NE:directmanipulation.DIRECTMANIPULATION_INPUT_MODE")]
	public enum DIRECTMANIPULATION_INPUT_MODE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Input is automatically passed to the viewport in an independent thread.</para>
		/// </summary>
		DIRECTMANIPULATION_INPUT_MODE_AUTOMATIC,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Input is manually passed by the app on its thread via the</para>
		/// <para>ProcessInput</para>
		/// <para>method.</para>
		/// </summary>
		DIRECTMANIPULATION_INPUT_MODE_MANUAL,
	}

	/// <summary>Defines gestures recognized by Direct Manipulation.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/ne-directmanipulation-directmanipulation_interaction_type
	// typedef enum DIRECTMANIPULATION_INTERACTION_TYPE { DIRECTMANIPULATION_INTERACTION_BEGIN = 0,
	// DIRECTMANIPULATION_INTERACTION_TYPE_MANIPULATION = 1, DIRECTMANIPULATION_INTERACTION_TYPE_GESTURE_TAP = 2,
	// DIRECTMANIPULATION_INTERACTION_TYPE_GESTURE_HOLD = 3, DIRECTMANIPULATION_INTERACTION_TYPE_GESTURE_CROSS_SLIDE = 4,
	// DIRECTMANIPULATION_INTERACTION_TYPE_GESTURE_PINCH_ZOOM = 5, DIRECTMANIPULATION_INTERACTION_END = 100 } ;
	[PInvokeData("directmanipulation.h", MSDNShortId = "NE:directmanipulation.DIRECTMANIPULATION_INTERACTION_TYPE")]
	public enum DIRECTMANIPULATION_INTERACTION_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Marks the beginning of an interaction.</para>
		/// </summary>
		DIRECTMANIPULATION_INTERACTION_BEGIN,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>A compound gesture that supports translation, rotation and scaling.</para>
		/// </summary>
		DIRECTMANIPULATION_INTERACTION_TYPE_MANIPULATION,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>A tap gesture.</para>
		/// </summary>
		DIRECTMANIPULATION_INTERACTION_TYPE_GESTURE_TAP,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>A hold gesture.</para>
		/// </summary>
		DIRECTMANIPULATION_INTERACTION_TYPE_GESTURE_HOLD,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Select or move through slide or swipe gestures.</para>
		/// </summary>
		DIRECTMANIPULATION_INTERACTION_TYPE_GESTURE_CROSS_SLIDE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>A zoom gesture.</para>
		/// </summary>
		DIRECTMANIPULATION_INTERACTION_TYPE_GESTURE_PINCH_ZOOM,

		/// <summary>
		/// <para>Value:</para>
		/// <para>100</para>
		/// <para>Marks the end of an interaction.</para>
		/// </summary>
		DIRECTMANIPULATION_INTERACTION_END,
	}

	/// <summary>Defines the Direct Manipulation motion type.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/ne-directmanipulation-directmanipulation_motion_types typedef
	// enum DIRECTMANIPULATION_MOTION_TYPES { DIRECTMANIPULATION_MOTION_NONE = 0, DIRECTMANIPULATION_MOTION_TRANSLATEX = 0x1,
	// DIRECTMANIPULATION_MOTION_TRANSLATEY = 0x2, DIRECTMANIPULATION_MOTION_ZOOM = 0x4, DIRECTMANIPULATION_MOTION_CENTERX = 0x10,
	// DIRECTMANIPULATION_MOTION_CENTERY = 0x20, DIRECTMANIPULATION_MOTION_ALL } ;
	[PInvokeData("directmanipulation.h", MSDNShortId = "NE:directmanipulation.DIRECTMANIPULATION_MOTION_TYPES")]
	[Flags]
	public enum DIRECTMANIPULATION_MOTION_TYPES
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>None.</para>
		/// </summary>
		DIRECTMANIPULATION_MOTION_NONE = 0x0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>Translation in the horizontal axis.</para>
		/// </summary>
		DIRECTMANIPULATION_MOTION_TRANSLATEX = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>Translation in the vertical axis.</para>
		/// </summary>
		DIRECTMANIPULATION_MOTION_TRANSLATEY = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>Zoom.</para>
		/// </summary>
		DIRECTMANIPULATION_MOTION_ZOOM = 0x4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10</para>
		/// <para>The horizontal center of the manipulation.</para>
		/// </summary>
		DIRECTMANIPULATION_MOTION_CENTERX = 0x10,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x20</para>
		/// <para>The vertical center of the manipulation.</para>
		/// </summary>
		DIRECTMANIPULATION_MOTION_CENTERY = 0x20,

		/// <summary>All manipulation motion.</summary>
		DIRECTMANIPULATION_MOTION_ALL = DIRECTMANIPULATION_MOTION_TRANSLATEX | DIRECTMANIPULATION_MOTION_TRANSLATEY | DIRECTMANIPULATION_MOTION_ZOOM | DIRECTMANIPULATION_MOTION_CENTERX | DIRECTMANIPULATION_MOTION_CENTERY,
	}

	/// <summary>Defines the coordinate system for a collection of snap points.</summary>
	/// <remarks>
	/// If <c>DIRECTMANIPULATION_COORDINATE_ORIGIN</c> and <c>DIRECTMANIPULATION_COORDINATE_MIRRORED</c> are both specified, the snap points
	/// are interpreted as specified from the bottom and right boundaries of the content (the size of the content - the size of the
	/// viewport). This is intended for RTL reading scenarios where content is normally specified and rendered from right-to-left or bottom-to-top.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/ne-directmanipulation-directmanipulation_snappoint_coordinate
	// typedef enum DIRECTMANIPULATION_SNAPPOINT_COORDINATE { DIRECTMANIPULATION_COORDINATE_BOUNDARY = 0,
	// DIRECTMANIPULATION_COORDINATE_ORIGIN = 0x1, DIRECTMANIPULATION_COORDINATE_MIRRORED = 0x10 } ;
	[PInvokeData("directmanipulation.h", MSDNShortId = "NE:directmanipulation.DIRECTMANIPULATION_SNAPPOINT_COORDINATE")]
	[Flags]
	public enum DIRECTMANIPULATION_SNAPPOINT_COORDINATE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Default.</para>
		/// <para>Snap points are specified relative to the top and left boundaries of the content unless</para>
		/// <para>DIRECTMANIPULATION_COORDINATE_MIRRORED</para>
		/// <para>
		/// is also specified, in which case they are relative to the bottom and right boundaries of the content. For zoom, the boundary is 1.0f.
		/// </para>
		/// </summary>
		DIRECTMANIPULATION_COORDINATE_BOUNDARY = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>Snap points are specified relative to the origin of the viewport.</para>
		/// </summary>
		DIRECTMANIPULATION_COORDINATE_ORIGIN = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10</para>
		/// <para>
		/// Snap points are interpreted as specified in the negative direction of the origin. The origin is shifted to the bottom and right
		/// of the viewport or content. Cannot be set for zoom.
		/// </para>
		/// </summary>
		DIRECTMANIPULATION_COORDINATE_MIRRORED = 0x10,
	}

	/// <summary>Modifies how the final inertia end position is calculated.</summary>
	/// <remarks>
	/// For <c>DIRECTMANIPULATION_SNAPPOINT_MANDATORY</c> or <c>DIRECTMANIPULATION_SNAPPOINT_OPTIONAL</c> snap points, the snap points are
	/// chosen based on the natural ending position of inertia as calculated by the touch interaction engine. For
	/// <c>DIRECTMANIPULATION_SNAPPOINT_MANDATORY_SINGLE</c> or <c>DIRECTMANIPULATION_SNAPPOINT_OPTIONAL_SINGLE</c> snap points, the selected
	/// snap point depends on where inertia started.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/ne-directmanipulation-directmanipulation_snappoint_type typedef
	// enum DIRECTMANIPULATION_SNAPPOINT_TYPE { DIRECTMANIPULATION_SNAPPOINT_MANDATORY = 0, DIRECTMANIPULATION_SNAPPOINT_OPTIONAL = 1,
	// DIRECTMANIPULATION_SNAPPOINT_MANDATORY_SINGLE = 2, DIRECTMANIPULATION_SNAPPOINT_OPTIONAL_SINGLE = 3 } ;
	[PInvokeData("directmanipulation.h", MSDNShortId = "NE:directmanipulation.DIRECTMANIPULATION_SNAPPOINT_TYPE")]
	public enum DIRECTMANIPULATION_SNAPPOINT_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Content always stops at the snap point closest to where inertia would naturally stop along the direction of inertia.</para>
		/// </summary>
		DIRECTMANIPULATION_SNAPPOINT_MANDATORY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>
		/// Content stops at a snap point closest to where inertia would naturally stop along the direction of inertia, depending on how
		/// close the snap point is.
		/// </para>
		/// </summary>
		DIRECTMANIPULATION_SNAPPOINT_OPTIONAL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Content always stops at the snap point closest to the release point along the direction of inertia.</para>
		/// </summary>
		DIRECTMANIPULATION_SNAPPOINT_MANDATORY_SINGLE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Content stops at the next snap point, if the motion starts far from it.</para>
		/// </summary>
		DIRECTMANIPULATION_SNAPPOINT_OPTIONAL_SINGLE,
	}

	/// <summary>Defines the possible states of Direct Manipulation. The viewport can process input in any state unless otherwise noted.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/ne-directmanipulation-directmanipulation_status typedef enum
	// DIRECTMANIPULATION_STATUS { DIRECTMANIPULATION_BUILDING = 0, DIRECTMANIPULATION_ENABLED = 1, DIRECTMANIPULATION_DISABLED = 2,
	// DIRECTMANIPULATION_RUNNING = 3, DIRECTMANIPULATION_INERTIA = 4, DIRECTMANIPULATION_READY = 5, DIRECTMANIPULATION_SUSPENDED = 6 } ;
	[PInvokeData("directmanipulation.h", MSDNShortId = "NE:directmanipulation.DIRECTMANIPULATION_STATUS")]
	public enum DIRECTMANIPULATION_STATUS
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The viewport is being initialized and is not yet able to process input.</para>
		/// </summary>
		DIRECTMANIPULATION_BUILDING,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The viewport was successfully enabled.</para>
		/// </summary>
		DIRECTMANIPULATION_ENABLED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>The viewport is disabled and cannot process input or callbacks. The viewport can be enabled by calling</para>
		/// <para>Enable</para>
		/// <para>.</para>
		/// </summary>
		DIRECTMANIPULATION_DISABLED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>The viewport is currently processing input and updating content.</para>
		/// </summary>
		DIRECTMANIPULATION_RUNNING,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>The viewport is moving content due to inertia.</para>
		/// </summary>
		DIRECTMANIPULATION_INERTIA,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>The viewport has completed the previous interaction.</para>
		/// </summary>
		DIRECTMANIPULATION_READY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>The transient state of the viewport when input has been promoted to an ancestor in the</para>
		/// <para>SetContact</para>
		/// <para>chain.</para>
		/// </summary>
		DIRECTMANIPULATION_SUSPENDED,
	}

	/// <summary>Defines the vertical alignment settings for content within the viewport.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/ne-directmanipulation-directmanipulation_verticalalignment
	// typedef enum DIRECTMANIPULATION_VERTICALALIGNMENT { DIRECTMANIPULATION_VERTICALALIGNMENT_NONE = 0,
	// DIRECTMANIPULATION_VERTICALALIGNMENT_TOP = 0x1, DIRECTMANIPULATION_VERTICALALIGNMENT_CENTER = 0x2,
	// DIRECTMANIPULATION_VERTICALALIGNMENT_BOTTOM = 0x4, DIRECTMANIPULATION_VERTICALALIGNMENT_UNLOCKCENTER = 0x8 } ;
	[PInvokeData("directmanipulation.h", MSDNShortId = "NE:directmanipulation.DIRECTMANIPULATION_VERTICALALIGNMENT")]
	[Flags]
	public enum DIRECTMANIPULATION_VERTICALALIGNMENT
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>No alignment. The object can be positioned anywhere within the viewport.</para>
		/// </summary>
		DIRECTMANIPULATION_VERTICALALIGNMENT_NONE = 0x0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>Align object along the top of the viewport.</para>
		/// </summary>
		DIRECTMANIPULATION_VERTICALALIGNMENT_TOP = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>Align object to the center of the viewport.</para>
		/// </summary>
		DIRECTMANIPULATION_VERTICALALIGNMENT_CENTER = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>Align object along the bottom of the viewport.</para>
		/// </summary>
		DIRECTMANIPULATION_VERTICALALIGNMENT_BOTTOM = 0x4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8</para>
		/// <para>Content zooms around the center point of the contacts, instead of being locked with the vertical alignment.</para>
		/// </summary>
		DIRECTMANIPULATION_VERTICALALIGNMENT_UNLOCKCENTER = 0x8,
	}

	/// <summary>Defines the input behavior options for the viewport.</summary>
	/// <remarks>
	/// <c>DIRECTMANIPULATION_VIEWPORT_OPTIONS</c> is used in the SetViewportOptions method. These flags can be combined to set the input
	/// behavior for a viewport.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/ne-directmanipulation-directmanipulation_viewport_options
	// typedef enum DIRECTMANIPULATION_VIEWPORT_OPTIONS { DIRECTMANIPULATION_VIEWPORT_OPTIONS_DEFAULT = 0,
	// DIRECTMANIPULATION_VIEWPORT_OPTIONS_AUTODISABLE = 0x1, DIRECTMANIPULATION_VIEWPORT_OPTIONS_MANUALUPDATE = 0x2,
	// DIRECTMANIPULATION_VIEWPORT_OPTIONS_INPUT = 0x4, DIRECTMANIPULATION_VIEWPORT_OPTIONS_EXPLICITHITTEST = 0x8,
	// DIRECTMANIPULATION_VIEWPORT_OPTIONS_DISABLEPIXELSNAPPING = 0x10 } ;
	[PInvokeData("directmanipulation.h", MSDNShortId = "NE:directmanipulation.DIRECTMANIPULATION_VIEWPORT_OPTIONS")]
	[Flags]
	public enum DIRECTMANIPULATION_VIEWPORT_OPTIONS
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>No special behaviors. This is the default value used to set or revert to default behavior.</para>
		/// </summary>
		DIRECTMANIPULATION_VIEWPORT_OPTIONS_DEFAULT = 0x0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>At the end of an interaction, the viewport transitions to</para>
		/// <para>DIRECTMANIPULATION_READY</para>
		/// <para>and then immediately to</para>
		/// <para>DIRECTMANIPULATION_DISABLED</para>
		/// <para>. The viewport must be explicitly enabled through the</para>
		/// <para>Enable</para>
		/// <para>method before the next interaction can be processed.</para>
		/// </summary>
		DIRECTMANIPULATION_VIEWPORT_OPTIONS_AUTODISABLE = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>Update</para>
		/// <para>must be called to redraw the content within the viewport. The content is not updated automatically during an input event.</para>
		/// </summary>
		DIRECTMANIPULATION_VIEWPORT_OPTIONS_MANUALUPDATE = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>All input from a contact associated with the viewport is passed to the UI thread for processing.</para>
		/// </summary>
		DIRECTMANIPULATION_VIEWPORT_OPTIONS_INPUT = 0x4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8</para>
		/// <para>If set, all</para>
		/// <para>WM_POINTERDOWN</para>
		/// <para>messages are passed to the application for hit testing. Otherwise,</para>
		/// <para>Direct Manipulation</para>
		/// <para>
		/// will process the messages for hit testing against the existing list of running viewports, and the application will not see the input.
		/// </para>
		/// <para>Applies only when viewport state is</para>
		/// <para>DIRECTMANIPULATION_RUNNING</para>
		/// <para>or</para>
		/// <para>DIRECTMANIPULATION_INERTIA</para>
		/// <para>.</para>
		/// </summary>
		DIRECTMANIPULATION_VIEWPORT_OPTIONS_EXPLICITHITTEST = 0x8,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10</para>
		/// <para>Specifies that pixel snapping during a manipulation is disabled.</para>
		/// <para>
		/// Anti-aliasing can create irregular edge rendering. Artifacts, commonly seen as blurry, or semi-transparent, edges can occur when
		/// the location of an edge falls in the middle of a device pixel rather than between device pixels.
		/// </para>
		/// </summary>
		DIRECTMANIPULATION_VIEWPORT_OPTIONS_DISABLEPIXELSNAPPING = 0x10,
	}
}