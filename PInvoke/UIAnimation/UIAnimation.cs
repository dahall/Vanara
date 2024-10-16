// The units of time used for all animations
// using UI_ANIMATION_SECONDS = double;

namespace Vanara.PInvoke;

/// <summary>Items from the UIAnimation.dll.</summary>
public static partial class UIAnimation
{
	/// <summary>Special value to indicate that any predetermined time in the future will be acceptable</summary>
	public const double UI_ANIMATION_SECONDS_EVENTUALLY = -1.0;

	private const string Lib_UIAnimation = "UIAnimation.dll";

	/// <summary>Defines which aspects of an interpolator depend on a given input.</summary>
	/// <remarks>Multiple <c>UI_ANIMATION_DEPENDENCIES</c> values can be combined using a bitwise-OR operation.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/ne-uianimation-ui_animation_dependencies
	// typedef enum __MIDL___MIDL_itf_UIAnimation_0000_0010_0001 { UI_ANIMATION_DEPENDENCY_NONE = 0, UI_ANIMATION_DEPENDENCY_INTERMEDIATE_VALUES = 0x1, UI_ANIMATION_DEPENDENCY_FINAL_VALUE = 0x2, UI_ANIMATION_DEPENDENCY_FINAL_VELOCITY = 0x4, UI_ANIMATION_DEPENDENCY_DURATION = 0x8 } UI_ANIMATION_DEPENDENCIES;
	[PInvokeData("uianimation.h", MSDNShortId = "NE:uianimation.__MIDL___MIDL_itf_UIAnimation_0000_0010_0001")]
	[Flags]
	public enum UI_ANIMATION_DEPENDENCIES
	{
		/// <summary>
		///   <para>Value:</para>
		///   <para>0</para>
		///   <para>No aspect depends on the input.</para>
		/// </summary>
		UI_ANIMATION_DEPENDENCY_NONE = 0,

		/// <summary>
		///   <para>Value:</para>
		///   <para>0x1</para>
		///   <para>The intermediate values depend on the input.</para>
		/// </summary>
		UI_ANIMATION_DEPENDENCY_INTERMEDIATE_VALUES = 0x1,

		/// <summary>
		///   <para>Value:</para>
		///   <para>0x2</para>
		///   <para>The final value depends on the input.</para>
		/// </summary>
		UI_ANIMATION_DEPENDENCY_FINAL_VALUE = 0x2,

		/// <summary>
		///   <para>Value:</para>
		///   <para>0x4</para>
		///   <para>The final velocity depends on the input.</para>
		/// </summary>
		UI_ANIMATION_DEPENDENCY_FINAL_VELOCITY = 0x4,

		/// <summary>
		///   <para>Value:</para>
		///   <para>0x8</para>
		///   <para>The duration depends on the input.</para>
		/// </summary>
		UI_ANIMATION_DEPENDENCY_DURATION = 0x8,
	}

	/// <summary>Defines the behavior of a timer when the animation manager is idle.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/ne-uianimation-ui_animation_idle_behavior
	// typedef enum __MIDL___MIDL_itf_UIAnimation_0000_0012_0001 { UI_ANIMATION_IDLE_BEHAVIOR_CONTINUE = 0, UI_ANIMATION_IDLE_BEHAVIOR_DISABLE = 1 } UI_ANIMATION_IDLE_BEHAVIOR;
	[PInvokeData("uianimation.h", MSDNShortId = "NE:uianimation.__MIDL___MIDL_itf_UIAnimation_0000_0012_0001")]
	public enum UI_ANIMATION_IDLE_BEHAVIOR
	{
		/// <summary>
		///   <para>Value:</para>
		///   <para>0</para>
		///   <para>The timer continues to generate timer events (is enabled) when the animation manager is idle.</para>
		/// </summary>
		UI_ANIMATION_IDLE_BEHAVIOR_CONTINUE,

		/// <summary>
		///   <para>Value:</para>
		///   <para>1</para>
		///   <para>The timer is suspended (disabled) when the animation manager is idle.</para>
		/// </summary>
		UI_ANIMATION_IDLE_BEHAVIOR_DISABLE,
	}

	/// <summary>Defines the activity status of an animation manager.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/ne-uianimation-ui_animation_manager_status
	// typedef enum __MIDL___MIDL_itf_UIAnimation_0000_0000_0002 { UI_ANIMATION_MANAGER_IDLE = 0, UI_ANIMATION_MANAGER_BUSY = 1 } UI_ANIMATION_MANAGER_STATUS;
	[PInvokeData("uianimation.h", MSDNShortId = "NE:uianimation.__MIDL___MIDL_itf_UIAnimation_0000_0000_0002")]
	public enum UI_ANIMATION_MANAGER_STATUS
	{
		/// <summary>
		///   <para>Value:</para>
		///   <para>0</para>
		///   <para>The animation manager is idle; no animations are currently playing.</para>
		/// </summary>
		UI_ANIMATION_MANAGER_IDLE,

		/// <summary>
		///   <para>Value:</para>
		///   <para>1</para>
		///   <para>The animation manager is busy; at least one animation is currently playing or scheduled.</para>
		/// </summary>
		UI_ANIMATION_MANAGER_BUSY,
	}

	/// <summary>Defines animation modes.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/UIAnimation/ne-uianimation-ui_animation_mode
	// typedef enum __MIDL___MIDL_itf_UIAnimation_0000_0000_0003 { UI_ANIMATION_MODE_DISABLED = 0, UI_ANIMATION_MODE_SYSTEM_DEFAULT = 1, UI_ANIMATION_MODE_ENABLED = 2 } UI_ANIMATION_MODE;
	[PInvokeData("uianimation.h", MSDNShortId = "NE:uianimation.__MIDL___MIDL_itf_UIAnimation_0000_0000_0003")]
	public enum UI_ANIMATION_MODE
	{
		/// <summary>
		///   <para>Value:</para>
		///   <para>0</para>
		///   <para>Animation is disabled.</para>
		/// </summary>
		UI_ANIMATION_MODE_DISABLED,

		/// <summary>
		///   <para>Value:</para>
		///   <para>1</para>
		///   <para>The animation mode is managed by the system.</para>
		/// </summary>
		UI_ANIMATION_MODE_SYSTEM_DEFAULT,

		/// <summary>
		///   <para>Value:</para>
		///   <para>2</para>
		///   <para>Animation is enabled.</para>
		/// </summary>
		UI_ANIMATION_MODE_ENABLED,
	}

	/// <summary>Defines potential effects on a storyboard if a priority comparison returns false.</summary>
	/// <remarks>
	/// <para>This enumeration is used as the <c>priorityEffect</c> parameter of IUIAnimationPriorityComparison::HasPriority, informing the client of the potential effect on the storyboard to be scheduled when the return value is false (S_FALSE). UI_ANIMATION_PRIORITY_EFFECT_FAILURE means that the attempt to schedule the storyboard might fail if the return value is false. UI_ANIMATION_PRIORITY_EFFECT_DELAY means that the attempt to schedule the storyboard will succeed, but if the return value is false, the storyboard could play later than it would otherwise.</para>
	/// <para>This enumeration can help an application decide how aggressive to be about reducing latency in the UI. For example, if the application returns true when the effect is UI_ANIMATION_PRIORITY_EFFECT_DELAY, then other animations might get canceled or compressed even though doing so was not strictly necessary to play a new animation within the application-specified longest acceptable delay.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/ne-uianimation-ui_animation_priority_effect
	// typedef enum __MIDL___MIDL_itf_UIAnimation_0000_0008_0001 { UI_ANIMATION_PRIORITY_EFFECT_FAILURE = 0, UI_ANIMATION_PRIORITY_EFFECT_DELAY = 1 } UI_ANIMATION_PRIORITY_EFFECT;
	[PInvokeData("uianimation.h", MSDNShortId = "NE:uianimation.__MIDL___MIDL_itf_UIAnimation_0000_0008_0001")]
	public enum UI_ANIMATION_PRIORITY_EFFECT
	{
		/// <summary>
		///   <para>Value:</para>
		///   <para>0</para>
		///   <para>This storyboard might not be successfully scheduled.</para>
		/// </summary>
		UI_ANIMATION_PRIORITY_EFFECT_FAILURE,

		/// <summary>
		///   <para>Value:</para>
		///   <para>1</para>
		///   <para>The storyboard will be scheduled, but might start playing later.</para>
		/// </summary>
		UI_ANIMATION_PRIORITY_EFFECT_DELAY,
	}

	/// <summary>Defines the pattern for a loop iteration.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/ne-uianimation-ui_animation_repeat_mode
	// typedef enum __MIDL___MIDL_itf_UIAnimation_0000_0000_0004 { UI_ANIMATION_REPEAT_MODE_NORMAL = 0, UI_ANIMATION_REPEAT_MODE_ALTERNATE = 1 } UI_ANIMATION_REPEAT_MODE;
	[PInvokeData("uianimation.h", MSDNShortId = "NE:uianimation.__MIDL___MIDL_itf_UIAnimation_0000_0000_0004")]
	public enum UI_ANIMATION_REPEAT_MODE
	{
		/// <summary>
		///   <para>Value:</para>
		///   <para>0</para>
		///   <para>The start of a loop begins with the first value (v1-&gt;v2, v1-&gt;v2, v1-&gt;v2, and so on).</para>
		/// </summary>
		UI_ANIMATION_REPEAT_MODE_NORMAL,

		/// <summary>
		///   <para>Value:</para>
		///   <para>1</para>
		///   <para>The start of a loop alternates between values (v1-&gt;v2, v2-&gt;v1, v1-&gt;v2, and so on).</para>
		/// </summary>
		UI_ANIMATION_REPEAT_MODE_ALTERNATE,
	}

	/// <summary>Defines the rounding modes to be used when the value of an animation variable is converted from a floating-point type to an integer type.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/ne-uianimation-ui_animation_rounding_mode
	// typedef enum __MIDL___MIDL_itf_UIAnimation_0000_0001_0001 { UI_ANIMATION_ROUNDING_NEAREST = 0, UI_ANIMATION_ROUNDING_FLOOR = 1, UI_ANIMATION_ROUNDING_CEILING = 2 } UI_ANIMATION_ROUNDING_MODE;
	[PInvokeData("uianimation.h", MSDNShortId = "NE:uianimation.__MIDL___MIDL_itf_UIAnimation_0000_0001_0001")]
	public enum UI_ANIMATION_ROUNDING_MODE
	{
		/// <summary>
		///   <para>Value:</para>
		///   <para>0</para>
		///   <para>Round to the nearest integer.</para>
		/// </summary>
		UI_ANIMATION_ROUNDING_NEAREST,

		/// <summary>
		///   <para>Value:</para>
		///   <para>1</para>
		///   <para>Round down.</para>
		/// </summary>
		UI_ANIMATION_ROUNDING_FLOOR,

		/// <summary>
		///   <para>Value:</para>
		///   <para>2</para>
		///   <para>Round up.</para>
		/// </summary>
		UI_ANIMATION_ROUNDING_CEILING,
	}

	/// <summary>Defines results for storyboard scheduling.</summary>
	/// <remarks>IUIAnimationStoryboard::Schedule returns UI_ANIMATION_SCHEDULING_DEFERRED only if the application attempts to schedule a storyboard during a callback to IUIAnimationStoryboardEventHandler::OnStoryboardStatusChanged.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/ne-uianimation-ui_animation_scheduling_result
	// typedef enum __MIDL___MIDL_itf_UIAnimation_0000_0002_0002 { UI_ANIMATION_SCHEDULING_UNEXPECTED_FAILURE = 0, UI_ANIMATION_SCHEDULING_INSUFFICIENT_PRIORITY = 1, UI_ANIMATION_SCHEDULING_ALREADY_SCHEDULED = 2, UI_ANIMATION_SCHEDULING_SUCCEEDED = 3, UI_ANIMATION_SCHEDULING_DEFERRED = 4 } UI_ANIMATION_SCHEDULING_RESULT;
	[PInvokeData("uianimation.h", MSDNShortId = "NE:uianimation.__MIDL___MIDL_itf_UIAnimation_0000_0002_0002")]
	public enum UI_ANIMATION_SCHEDULING_RESULT
	{
		/// <summary>
		///   <para>Value:</para>
		///   <para>0</para>
		///   <para>Scheduling failed for an unexpected reason.</para>
		/// </summary>
		UI_ANIMATION_SCHEDULING_UNEXPECTED_FAILURE,

		/// <summary>
		///   <para>Value:</para>
		///   <para>1</para>
		///   <para>Scheduling failed because</para>
		///   <para>a scheduling conflict occurred and the currently scheduled storyboard has higher priority.</para>
		///   <para>For more information, see</para>
		///   <para>IUIAnimationPriorityComparison::HasPriority</para>
		///   <para>.</para>
		/// </summary>
		UI_ANIMATION_SCHEDULING_INSUFFICIENT_PRIORITY,

		/// <summary>
		///   <para>Value:</para>
		///   <para>2</para>
		///   <para>Scheduling failed because</para>
		///   <para>the storyboard is already scheduled.</para>
		/// </summary>
		UI_ANIMATION_SCHEDULING_ALREADY_SCHEDULED,

		/// <summary>
		///   <para>Value:</para>
		///   <para>3</para>
		///   <para>Scheduling succeeded.</para>
		/// </summary>
		UI_ANIMATION_SCHEDULING_SUCCEEDED,

		/// <summary>
		///   <para>Value:</para>
		///   <para>4</para>
		///   <para>Scheduling is deferred and will be attempted when the current callback completes.</para>
		/// </summary>
		UI_ANIMATION_SCHEDULING_DEFERRED,
	}

	/// <summary>Defines animation slope characteristics.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/ne-uianimation-ui_animation_slope
	// typedef enum __MIDL___MIDL_itf_UIAnimation_0000_0009_0001 { UI_ANIMATION_SLOPE_INCREASING = 0, UI_ANIMATION_SLOPE_DECREASING = 1 } UI_ANIMATION_SLOPE;
	[PInvokeData("uianimation.h", MSDNShortId = "NE:uianimation.__MIDL___MIDL_itf_UIAnimation_0000_0009_0001")]
	public enum UI_ANIMATION_SLOPE
	{
		/// <summary>
		///   <para>Value:</para>
		///   <para>0</para>
		///   <para>An increasing slope.</para>
		/// </summary>
		UI_ANIMATION_SLOPE_INCREASING,

		/// <summary>
		///   <para>Value:</para>
		///   <para>1</para>
		///   <para>A decreasing slope.</para>
		/// </summary>
		UI_ANIMATION_SLOPE_DECREASING,
	}

	/// <summary>Defines the status for a storyboard.</summary>
	/// <remarks>
	/// <para>Unless IUIAnimationStoryboard::GetStatus is called from a handler for OnStoryboardStatusChanged events, it returns only the following status values:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>UI_ANIMATION_STORYBOARD_BUILDING</description>
	/// </item>
	/// <item>
	/// <description>UI_ANIMATION_STORYBOARD_SCHEDULED</description>
	/// </item>
	/// <item>
	/// <description>UI_ANIMATION_STORYBOARD_PLAYING</description>
	/// </item>
	/// <item>
	/// <description>UI_ANIMATION_STORYBOARD_READY</description>
	/// </item>
	/// </list>
	/// <para>All status values can be passed to IUIAnimationStoryboardEventHandler::OnStoryboardStatusChanged.</para>
	/// <para>The following diagram illustrates the transitions between these states.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/ne-uianimation-ui_animation_storyboard_status
	// typedef enum __MIDL___MIDL_itf_UIAnimation_0000_0002_0001 { UI_ANIMATION_STORYBOARD_BUILDING = 0, UI_ANIMATION_STORYBOARD_SCHEDULED = 1, UI_ANIMATION_STORYBOARD_CANCELLED = 2, UI_ANIMATION_STORYBOARD_PLAYING = 3, UI_ANIMATION_STORYBOARD_TRUNCATED = 4, UI_ANIMATION_STORYBOARD_FINISHED = 5, UI_ANIMATION_STORYBOARD_READY = 6, UI_ANIMATION_STORYBOARD_INSUFFICIENT_PRIORITY = 7 } UI_ANIMATION_STORYBOARD_STATUS;
	[PInvokeData("uianimation.h", MSDNShortId = "NE:uianimation.__MIDL___MIDL_itf_UIAnimation_0000_0002_0001")]
	public enum UI_ANIMATION_STORYBOARD_STATUS
	{
		/// <summary>
		///   <para>Value:</para>
		///   <para>0</para>
		///   <para>The storyboard has never been scheduled.</para>
		/// </summary>
		UI_ANIMATION_STORYBOARD_BUILDING,

		/// <summary>
		///   <para>Value:</para>
		///   <para>1</para>
		///   <para>The storyboard is scheduled to play.</para>
		/// </summary>
		UI_ANIMATION_STORYBOARD_SCHEDULED,

		/// <summary>
		///   <para>Value:</para>
		///   <para>2</para>
		///   <para>The storyboard was canceled.</para>
		/// </summary>
		UI_ANIMATION_STORYBOARD_CANCELLED,

		/// <summary>
		///   <para>Value:</para>
		///   <para>3</para>
		///   <para>The storyboard is currently playing.</para>
		/// </summary>
		UI_ANIMATION_STORYBOARD_PLAYING,

		/// <summary>
		///   <para>Value:</para>
		///   <para>4</para>
		///   <para>The storyboard was truncated.</para>
		/// </summary>
		UI_ANIMATION_STORYBOARD_TRUNCATED,

		/// <summary>
		///   <para>Value:</para>
		///   <para>5</para>
		///   <para>The storyboard has finished playing.</para>
		/// </summary>
		UI_ANIMATION_STORYBOARD_FINISHED,

		/// <summary>
		///   <para>Value:</para>
		///   <para>6</para>
		///   <para>The storyboard is built and ready for scheduling.</para>
		/// </summary>
		UI_ANIMATION_STORYBOARD_READY,

		/// <summary>
		///   <para>Value:</para>
		///   <para>7</para>
		///   <para>Scheduling the storyboard failed because a scheduling conflict occurred and the currently scheduled storyboard has higher priority.</para>
		/// </summary>
		UI_ANIMATION_STORYBOARD_INSUFFICIENT_PRIORITY,
	}

	/// <summary>Defines activity status for a timer's client.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/ne-uianimation-ui_animation_timer_client_status
	// typedef enum __MIDL___MIDL_itf_UIAnimation_0000_0014_0001 { UI_ANIMATION_TIMER_CLIENT_IDLE = 0, UI_ANIMATION_TIMER_CLIENT_BUSY = 1 } UI_ANIMATION_TIMER_CLIENT_STATUS;
	[PInvokeData("uianimation.h", MSDNShortId = "NE:uianimation.__MIDL___MIDL_itf_UIAnimation_0000_0014_0001")]
	public enum UI_ANIMATION_TIMER_CLIENT_STATUS
	{
		/// <summary>
		///   <para>Value:</para>
		///   <para>0</para>
		///   <para>The client is idle.</para>
		/// </summary>
		UI_ANIMATION_TIMER_CLIENT_IDLE,

		/// <summary>
		///   <para>Value:</para>
		///   <para>1</para>
		///   <para>The client is busy.</para>
		/// </summary>
		UI_ANIMATION_TIMER_CLIENT_BUSY,
	}

	/// <summary>Defines results for animation updates.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/ne-uianimation-ui_animation_update_result
	// typedef enum __MIDL___MIDL_itf_UIAnimation_0000_0000_0001 { UI_ANIMATION_UPDATE_NO_CHANGE = 0, UI_ANIMATION_UPDATE_VARIABLES_CHANGED = 1 } UI_ANIMATION_UPDATE_RESULT;
	[PInvokeData("uianimation.h", MSDNShortId = "NE:uianimation.__MIDL___MIDL_itf_UIAnimation_0000_0000_0001")]
	public enum UI_ANIMATION_UPDATE_RESULT
	{
		/// <summary>
		///   <para>Value:</para>
		///   <para>0</para>
		///   <para>No animation variables have changed.</para>
		/// </summary>
		UI_ANIMATION_UPDATE_NO_CHANGE,

		/// <summary>
		///   <para>Value:</para>
		///   <para>1</para>
		///   <para>One or more animation variables has changed.</para>
		/// </summary>
		UI_ANIMATION_UPDATE_VARIABLES_CHANGED,
	}

	/// <summary>Defines a keyframe, which represents a time offset within a storyboard.</summary>
	/// <remarks>
	/// <para>This structure should be treated as a handle. It is returned as an output parameter by some methods and should be used only as a parameter passed back to other methods as an input parameter.</para>
	/// <para>UI_ANIMATION_KEYFRAME_STORYBOARD_START represents the implicit keyframe at the start of every storyboard.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/ns-uianimation-__midl___midl_itf_uianimation_0000_0002_0003
	// typedef struct __MIDL___MIDL_itf_UIAnimation_0000_0002_0003 { int _; } *UI_ANIMATION_KEYFRAME;
	[PInvokeData("uianimation.h", MSDNShortId = "NS:uianimation.__MIDL___MIDL_itf_UIAnimation_0000_0002_0003")]
	[StructLayout(LayoutKind.Sequential)]
	public struct UI_ANIMATION_KEYFRAME
	{
		/// <summary />
		private readonly int handle;
	}
}