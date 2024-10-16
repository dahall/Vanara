using UI_ANIMATION_SECONDS = double;

namespace Vanara.PInvoke;

/// <summary>Items from the UIAnimation.dll.</summary>
public static partial class UIAnimation
{
	internal unsafe delegate HRESULT GetTagDelegate([Out, Optional] IntPtr* obj, [Out, Optional] uint* id);

	/// <summary>Defines methods for creating a custom interpolator.</summary>
	/// <remarks>
	/// <para>
	/// Client applications can use the transitions provided in IUIAnimationTransitionLibrary or in a library provided by a third party;
	/// however, if you need custom behavior, you can create your own transitions by implementing the <c>IUIAnimationInterpolator</c> interface.
	/// </para>
	/// <para>
	/// Before Windows Animation can use your custom interpolator, you must wrap it in an object that implements IUIAnimationTransition by
	/// calling the IUIAnimationTransitionFactory::CreateTransition method and passing in the custom interpolator. After the interpolator is
	/// wrapped, client applications interact with your interpolator using the <c>IUIAnimationTransition</c> interface.
	/// </para>
	/// <para>
	/// Custom interpolators can be reused across applications, but it is recommended that they be exposed using factory interfaces that
	/// return IUIAnimationTransition interfaces.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Custom Interpolator Sample.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nn-uianimation-iuianimationinterpolator
	[PInvokeData("uianimation.h", MSDNShortId = "NN:uianimation.IUIAnimationInterpolator")]
	[ComImport, Guid("7815CBBA-DDF7-478C-A46C-7B6C738B7978"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IUIAnimationInterpolator
	{
		/// <summary>Sets the initial value and velocity at the start of the transition.</summary>
		/// <param name="initialValue">The initial value.</param>
		/// <param name="initialVelocity">The initial velocity.</param>
		/// <returns>
		/// <para>If the method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// <para>See Windows Animation Error Codes for a list of error codes.</para>
		/// </returns>
		/// <remarks>
		/// Windows Animation always calls <c>SetInitialValueAndVelocity</c> before calling the other methods of IUIAnimationInterpolator at
		/// different offsets. However, it can be called multiple times with different parameters. Interpolators can cache internal state to
		/// improve performance, but they must update this cached state each time <c>SetInitialValueAndVelocity</c> is called and ensure
		/// that the results of subsequent calls to these methods reflect the updated state.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationinterpolator-setinitialvalueandvelocity
		// HRESULT SetInitialValueAndVelocity( [in] DOUBLE initialValue, [in] DOUBLE initialVelocity );
		[PreserveSig]
		HRESULT SetInitialValueAndVelocity(double initialValue, double initialVelocity);

		/// <summary>Sets the duration of the transition.</summary>
		/// <param name="duration">The duration of the transition.</param>
		/// <returns>
		/// If the method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </returns>
		/// <remarks>
		/// <para>
		/// Windows Animation calls this method only after calling the GetDependencies method, and only if that call returns
		/// <c>UI_ANIMATION_DEPENDENCY_DURATION</c> as one of its <c>durationDependencies</c> flags.
		/// </para>
		/// <para>
		/// Typically, an interpolator with a duration dependency will have a duration parameter in its associated creation method of
		/// IUIAnimationTransitionFactory. The interpolator should store its duration when first initialized and overwrite it when
		/// <c>SetDuration</c> is called.
		/// </para>
		/// <para>
		/// Windows Animation always calls the SetInitialValueAndVelocity method to set the initial value and velocity before calling
		/// <c>SetDuration</c>, so a custom interpolator need not check whether the initial value and velocity have been set.
		/// </para>
		/// <para>
		/// Windows Animation can call SetInitialValueAndVelocity and <c>SetDuration</c> multiple times with different parameters.
		/// Interpolators can cache internal state to improve performance, but they must update this cached state each time
		/// <c>SetInitialValueAndVelocity</c> is called and ensure that the results of subsequent calls to <c>SetDuration</c> reflect the
		/// updated state.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationinterpolator-setduration HRESULT
		// SetDuration( [in] UI_ANIMATION_SECONDS duration );
		[PreserveSig]
		HRESULT SetDuration(double duration);

		/// <summary>Gets the duration of a transition.</summary>
		/// <param name="duration">The duration of the transition.</param>
		/// <returns>
		/// If the method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </returns>
		/// <remarks>
		/// <para>
		/// Windows Animation always calls the SetInitialValueAndVelocity method to set the initial value and velocity before calling
		/// <c>GetDuration</c>, so a custom interpolator need not check whether the initial value and velocity have been set.
		/// </para>
		/// <para>
		/// Windows Animation can call SetInitialValueAndVelocity multiple times with different parameters. Interpolators can cache internal
		/// state to improve performance, but they must update this cached state each time <c>SetInitialValueAndVelocity</c> is called and
		/// ensure that the results of subsequent calls to <c>GetDuration</c> reflect the updated state.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationinterpolator-getduration HRESULT
		// GetDuration( [out] UI_ANIMATION_SECONDS *duration );
		[PreserveSig]
		HRESULT GetDuration(out double duration);

		/// <summary>Gets the final value at the end of the transition.</summary>
		/// <param name="value">The final value.</param>
		/// <returns>
		/// If the method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </returns>
		/// <remarks>
		/// <para>
		/// Windows Animation always calls the SetInitialValueAndVelocity method to set the initial value and velocity before calling
		/// <c>GetFinalValue</c>, so a custom interpolator need not check whether the initial value and velocity have been set.
		/// </para>
		/// <para>
		/// Windows Animation can call SetInitialValueAndVelocity multiple times with different parameters. Interpolators can cache internal
		/// state to improve performance, but they must update this cached state each time <c>SetInitialValueAndVelocity</c> is called and
		/// ensure that the results of subsequent calls to <c>GetFinalValue</c> reflect the updated state.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationinterpolator-getfinalvalue HRESULT
		// GetFinalValue( [out] DOUBLE *value );
		[PreserveSig]
		HRESULT GetFinalValue(out double value);

		/// <summary>Interpolates the value of an animation variable at the specified offset.</summary>
		/// <param name="offset">
		/// <para>The offset from the start of the transition.</para>
		/// <para>
		/// This parameter is always greater than or equal to zero and less than the duration of the transition. This method is not called
		/// if the duration of the transition is zero.
		/// </para>
		/// </param>
		/// <param name="value">The interpolated value.</param>
		/// <returns>
		/// If the method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </returns>
		/// <remarks>
		/// <para>
		/// Windows Animation always calls the SetInitialValueAndVelocity method to set the initial value and velocity before calling
		/// <c>InterpolateValue</c>, so a custom interpolator need not check whether the initial value and velocity have been set.
		/// </para>
		/// <para>
		/// Windows Animation can call SetInitialValueAndVelocity multiple times with different parameters. Interpolators can cache internal
		/// state to improve performance, but they must update this cached state each time <c>SetInitialValueAndVelocity</c> is called and
		/// ensure that the results of subsequent calls to <c>InterpolateValue</c> reflect the updated state.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationinterpolator-interpolatevalue HRESULT
		// InterpolateValue( [in] UI_ANIMATION_SECONDS offset, [out] DOUBLE *value );
		[PreserveSig]
		HRESULT InterpolateValue(double offset, out double value);

		/// <summary>Interpolates the velocity, or rate of change, at the specified offset.</summary>
		/// <param name="offset">
		/// <para>The offset from the start of the transition.</para>
		/// <para>
		/// The offset is always greater than or equal to zero and less than or equal to the duration of the transition. This method is not
		/// called if the duration of the transition is zero.
		/// </para>
		/// </param>
		/// <param name="velocity">The interpolated velocity.</param>
		/// <returns>
		/// If the method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </returns>
		/// <remarks>
		/// <para>
		/// Windows Animation always calls the SetInitialValueAndVelocity method to set the initial value and velocity before calling
		/// <c>InterpolateVelocity</c>, so a custom interpolator need not check whether the initial value and velocity have been set.
		/// </para>
		/// <para>
		/// Windows Animation can call SetInitialValueAndVelocity multiple times with different parameters. Interpolators can cache internal
		/// state to improve performance, but they must update this cached state each time <c>SetInitialValueAndVelocity</c> is called and
		/// ensure that the results of subsequent calls to <c>InterpolateVelocity</c> reflect the updated state.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationinterpolator-interpolatevelocity
		// HRESULT InterpolateVelocity( [in] UI_ANIMATION_SECONDS offset, [out] DOUBLE *velocity );
		[PreserveSig]
		HRESULT InterpolateVelocity(double offset, out double velocity);

		/// <summary>
		/// Gets the aspects of the interpolator that depend on the initial value or velocity passed to SetInitialValueAndVelocity, or that
		/// depend on the duration passed to SetDuration.
		/// </summary>
		/// <param name="initialValueDependencies">Aspects of the interpolator that depend on the initial value passed to SetInitialValueAndVelocity.</param>
		/// <param name="initialVelocityDependencies">Aspects of the interpolator that depend on the initial velocity passed to SetInitialValueAndVelocity.</param>
		/// <param name="durationDependencies">Aspects of the interpolator that depend on the duration passed to SetDuration.</param>
		/// <returns>
		/// If the method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method is called to identify which aspects of the custom interpolator are affected by certain inputs: value, velocity, and
		/// duration. For each of these inputs, the interpolator returns either of the following:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>The bitwise-OR of any members of UI_ANIMATION_DEPENDENCIES that apply.</description>
		/// </item>
		/// <item>
		/// <description><c>UI_ANIMATION_DEPENDENCY_NONE</c> if nothing depends on the input.</description>
		/// </item>
		/// </list>
		/// <para>
		/// For example, consider an interpolator (1) that accepts a final value as a parameter, (2) that always comes to a gradual stop at
		/// that final value, and (3) whose duration is determined by the difference between the final and initial values. The interpolator
		/// should return <c>UI_ANIMATION_DEPENDENCY_INTERMEDIATE_VALUES</c>| <c>UI_ANIMATION_DURATION</c> for
		/// <c>initialValueDependencies</c>. It should not return <c>UI_ANIMATION_DEPENDENCY_FINAL_VALUE</c> because this is set when the
		/// interpolator is created and is not affected by the initial value. Likewise it should not return
		/// <c>UI_ANIMATION_DEPENDENCY_FINAL_VELOCITY</c> because the slope of the curve is defined to always be zero when it reaches the
		/// final value.
		/// </para>
		/// <para>
		/// It is important that an interpolator return correct set of flags. If a flag is not present for an output, Windows Animation
		/// assumes that the corresponding parameter does not affect that aspect of the interpolator's results. For example, if the custom
		/// interpolator does not include <c>UI_ANIMATION_DEPENDENCY_FINAL_VALUE</c> for <c>initialVelocityDependencies</c>, Windows
		/// Animation may call SetInitialValueAndVelocity with an arbitrary velocity parameter, then call GetFinalValue to determine the
		/// final value. The interpolator's implementation of <c>GetFinalValue</c> must return the same result no matter what velocity
		/// parameter has been passed to <c>SetInitialValueAndVelocity</c> because the interpolator has claimed that the transition's final
		/// value does not depend on the initial velocity.
		/// </para>
		/// <para>
		/// <c>Note</c>  If the flags returned for <c>durationDependencies</c> do not include <c>UI_ANIMATION_DEPENDENCY_DURATION</c>,
		/// SetDuration will never be called on the interpolator.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationinterpolator-getdependencies HRESULT
		// GetDependencies( [out] UI_ANIMATION_DEPENDENCIES *initialValueDependencies, [out] UI_ANIMATION_DEPENDENCIES
		// *initialVelocityDependencies, [out] UI_ANIMATION_DEPENDENCIES *durationDependencies );
		[PreserveSig]
		HRESULT GetDependencies(out UI_ANIMATION_DEPENDENCIES initialValueDependencies, out UI_ANIMATION_DEPENDENCIES initialVelocityDependencies, out UI_ANIMATION_DEPENDENCIES durationDependencies);
	}

	/// <summary>Defines the animation manager, which provides a central interface for creating and managing animations.</summary>
	/// <remarks>
	/// <para><c>IUIAnimationManager</c> defines a central control object for animations.</para>
	/// <para>
	/// A single instance of <c>IUIAnimationManager</c> is typically used to compose, schedule, and manage all animations for a client application.
	/// </para>
	/// <para>IUIAnimationVariable, IUIAnimationTransition, and IUIAnimationStoryboard are the primary components for building animations.</para>
	/// <para>Use <c>IUIAnimationManager</c> to create and manage these components.</para>
	/// <para>Examples</para>
	/// <para>For an example that creates the animation manager object, see Create the Main Animation Objects.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nn-uianimation-iuianimationmanager
	[PInvokeData("uianimation.h", MSDNShortId = "NN:uianimation.IUIAnimationManager")]
	[ComImport, Guid("9169896C-AC8D-4e7d-94E5-67FA4DC2F2E8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(UIAnimationManager))]
	public interface IUIAnimationManager
	{
		/// <summary>Creates a new animation variable.</summary>
		/// <param name="initialValue">The initial value for the new animation variable.</param>
		/// <returns>The new animation variable.</returns>
		/// <remarks>
		/// <para>
		/// The initial value of an animation variable is specified when the variable is created. After an animation variable is created,
		/// its value cannot be changed directly; it must be updated through the animation manager.
		/// </para>
		/// <para>
		/// An animation variable is typically created to represent each visual characteristic that is to be animated. For example, an
		/// application might create two animation variables for the X and Y coordinates of an object that can move freely within a window.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Create Animation Variables.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager-createanimationvariable
		// HRESULT CreateAnimationVariable( [in] DOUBLE initialValue, [out] IUIAnimationVariable **variable );
		IUIAnimationVariable CreateAnimationVariable([In] double initialValue);

		/// <summary>Creates and schedules a single-transition storyboard.</summary>
		/// <param name="variable">The animation variable.</param>
		/// <param name="transition">A transition to be applied to the animation variable.</param>
		/// <param name="timeNow">The current system time.</param>
		/// <remarks>
		/// <para>
		/// This method schedules a new storyboard by creating the storyboard, applying the specified transition to the specified variable,
		/// and then scheduling the storyboard.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example creates a storyboard for a specified transition and animation variable.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager-scheduletransition HRESULT
		// ScheduleTransition( [in] IUIAnimationVariable *variable, [in] IUIAnimationTransition *transition, [in] UI_ANIMATION_SECONDS
		// timeNow );
		void ScheduleTransition([In] IUIAnimationVariable variable, [In] IUIAnimationTransition transition, [In] UI_ANIMATION_SECONDS timeNow);

		/// <summary>Creates a new storyboard.</summary>
		/// <returns>The new storyboard.</returns>
		/// <remarks>
		/// <para>
		/// Storyboards can specify complex coordinated updates to many animation variables. These updates happen in sequence or in
		/// parallel, and they are guaranteed to remain synchronized within the storyboard. A storyboard is created, populated with
		/// transitions on animation variables, and then scheduled.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Create a Storyboard and Add Transitions.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager-createstoryboard HRESULT
		// CreateStoryboard( [out] IUIAnimationStoryboard **storyboard );
		IUIAnimationStoryboard CreateStoryboard();

		/// <summary>Finishes all active storyboards within the specified time interval.</summary>
		/// <param name="completionDeadline">The maximum time interval during which all storyboards must be finished.</param>
		/// <remarks>
		/// <para>
		/// Calling <c>FinishAllStoryboards</c> ensures that all active storyboards finish within the specified completion deadline. If a
		/// storyboard is scheduled to play past the deadline, it is compressed.
		/// </para>
		/// <para>A storyboard is considered active if its status is <c>UI_ANIMATION_STORYBOARD_PLAYING</c> or <c>UI_ANIMATION_STORYBOARD_SCHEDULED</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager-finishallstoryboards HRESULT
		// FinishAllStoryboards( [in] UI_ANIMATION_SECONDS completionDeadline );
		void FinishAllStoryboards([In] UI_ANIMATION_SECONDS completionDeadline);

		/// <summary>Abandons all active storyboards.</summary>
		/// <remarks>
		/// <para>Calling this method is equivalent to calling the IUIAnimationStoryboard::Abandon method for each active storyboard.</para>
		/// <para>A storyboard is considered active if its status is <c>UI_ANIMATION_STORYBOARD_PLAYING</c> or <c>UI_ANIMATION_STORYBOARD_SCHEDULED</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager-abandonallstoryboards HRESULT AbandonAllStoryboards();
		void AbandonAllStoryboards();

		/// <summary>Updates the values of all animation variables.</summary>
		/// <param name="timeNow">The current system time. This parameter must be greater than or equal to 0.0.</param>
		/// <returns>The result of the update. This parameter can be omitted from calls to this method.</returns>
		/// <remarks>
		/// <para>
		/// Calling this method advances the animation manager to <c>timeNow</c>, changing statuses of storyboards as necessary and updating
		/// any animation variables to appropriate interpolated values. If the animation manager is paused, no storyboards or variables are
		/// updated. If the animation mode is <c>UI_ANIMATION_MODE_DISABLED</c>, all scheduled storyboards finish playing immediately. If
		/// the values of any variables change during this call, the value of <c>updateResult</c> is
		/// <c>UI_ANIMATION_UPDATE_VARIABLES_CHANGED</c>; otherwise, it is <c>UI_ANIMATION_UPDATE_NO_CHANGE</c>.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example updates the animation manager with the current time. For additional examples, see Update the Animation
		/// Manager and Draw Frames.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager-update HRESULT Update( [in]
		// UI_ANIMATION_SECONDS timeNow, [out, optional] UI_ANIMATION_UPDATE_RESULT *updateResult );
		UI_ANIMATION_UPDATE_RESULT Update([In] UI_ANIMATION_SECONDS timeNow);

		/// <summary>Gets the animation variable with the specified tag.</summary>
		/// <param name="object">The object portion of the tag. This parameter can be <c>NULL</c>.</param>
		/// <param name="id">The identifier portion of the tag.</param>
		/// <returns>The animation variable that matches the specified tag, or <c>NULL</c> if no match is found.</returns>
		/// <remarks>
		/// <para>
		/// A tag is a pairing of an integer identifier ( <c>id</c>) with a COM object ( <c>object</c>). An application can use tags to
		/// identify animation variables and storyboards. <c>NULL</c> is a valid object component of a tag; therefore, the <c>object</c>
		/// parameter can be <c>NULL</c>.
		/// </para>
		/// <para>
		/// Tags are not necessarily unique; this method returns <c>UI_E_AMBIGUOUS_MATCH</c> if more than one animation variable exists with
		/// the specified tag.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager-getvariablefromtag HRESULT
		// GetVariableFromTag( [in, optional] IUnknown *object, [in] UINT32 id, [out] IUIAnimationVariable **variable );
		IUIAnimationVariable? GetVariableFromTag([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? @object, uint id);

		/// <summary>Gets the storyboard with the specified tag.</summary>
		/// <param name="object">The object portion of the tag. This parameter can be <c>NULL</c>.</param>
		/// <param name="id">The identifier portion of the tag.</param>
		/// <returns>The storyboard that matches the specified tag, or <c>NULL</c> if no match is found.</returns>
		/// <remarks>
		/// <para>
		/// A tag is a pairing of an integer identifier ( <c>id</c>) with a COM object ( <c>object</c>). An application can use tags to
		/// identify animation variables and storyboards. <c>NULL</c> is a valid object component of a tag; therefore, the <c>object</c>
		/// parameter can be <c>NULL</c>.
		/// </para>
		/// <para>
		/// Tags are not necessarily unique; this method returns UI_E_AMBIGUOUS_MATCH if more than one storyboard exists with the specified tag.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager-getstoryboardfromtag HRESULT
		// GetStoryboardFromTag( [in, optional] IUnknown *object, [in] UINT32 id, [out] IUIAnimationStoryboard **storyboard );
		IUIAnimationStoryboard? GetStoryboardFromTag([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? @object, uint id);

		/// <summary>Gets the status of the animation manager.</summary>
		/// <returns>The status.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager-getstatus HRESULT GetStatus(
		// [out] UI_ANIMATION_MANAGER_STATUS *status );
		UI_ANIMATION_MANAGER_STATUS GetStatus();

		/// <summary>Sets the animation mode.</summary>
		/// <param name="mode">The animation mode.</param>
		/// <remarks>
		/// This method is used to enable or disable animation globally. While animation is disabled, all storyboards finish immediately
		/// when they are scheduled. The default mode is <c>UI_ANIMATION_MODE_SYSTEM_DEFAULT</c>, which lets Windows decide when to enable
		/// or disable animation in the application.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager-setanimationmode HRESULT
		// SetAnimationMode( [in] UI_ANIMATION_MODE mode );
		void SetAnimationMode([In] UI_ANIMATION_MODE mode);

		/// <summary>Pauses all animations.</summary>
		/// <remarks>When an animation manager is paused, its status is set to <c>UI_ANIMATION_MANAGER_IDLE</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager-pause HRESULT Pause();
		void Pause();

		/// <summary>Resumes all animations.</summary>
		/// <remarks>
		/// When an animation manager is resumed, and at least one animation is currently scheduled or playing, its status is set to <c>UI_ANIMATION_MANAGER_BUSY</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager-resume HRESULT Resume();
		void Resume();

		/// <summary>Specifies a handler for animation manager status updates.</summary>
		/// <param name="handler">
		/// <para>The event handler to be called when the status of the animation manager changes.</para>
		/// <para>The specified object must implement the IUIAnimationManagerEventHandler interface or be <c>NULL</c>.</para>
		/// <para>See Remarks section for more information.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Passing <c>NULL</c> for the <c>handler</c> parameter causes Windows Animation to release its reference to any handler object
		/// that you passed in earlier. This technique can be essential for breaking reference cycles without having to call the
		/// IUIAnimationManager::Shutdown method.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Update the Animation Manager and Draw Frames.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager-setmanagereventhandler HRESULT
		// SetManagerEventHandler( [in, optional] IUIAnimationManagerEventHandler *handler );
		void SetManagerEventHandler([In, Optional] IUIAnimationManagerEventHandler? handler);

		/// <summary>Sets the priority comparison handler to be called to determine whether a scheduled storyboard can be canceled.</summary>
		/// <param name="comparison">
		/// <para>The priority comparison handler for cancelation.</para>
		/// <para>The specified object must implement the IUIAnimationPriorityComparison interface or be <c>NULL</c>.</para>
		/// <para>See Remarks.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Setting a priority comparison handler with this method enables the application to indicate when scheduling conflicts can be
		/// resolved by canceling storyboards.
		/// </para>
		/// <para>
		/// A scheduled storyboard can be canceled only if it has not started playing and the priority comparison object registered with
		/// this method returns <c>S_OK</c>. Canceled storyboards are completely removed from the schedule.
		/// </para>
		/// <para>
		/// Passing <c>NULL</c> for the <c>comparison</c> parameter causes Windows Animation to release its reference to any priority
		/// comparison handler object you passed in earlier. This technique can be essential for breaking reference cycles without having to
		/// call the IUIAnimationManager::Shutdown method.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager-setcancelprioritycomparison
		// HRESULT SetCancelPriorityComparison( [in, optional] IUIAnimationPriorityComparison *comparison );
		void SetCancelPriorityComparison([In, Optional] IUIAnimationPriorityComparison? comparison);

		/// <summary>Sets the priority comparison handler to be called to determine whether a scheduled storyboard can be trimmed.</summary>
		/// <param name="comparison">
		/// <para>The priority comparison handler for trimming.</para>
		/// <para>The specified object must implement the IUIAnimationPriorityComparison interface or be <c>NULL</c>.</para>
		/// <para>See Remarks.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Setting a priority comparison handler with this method enables the application to indicate when scheduling conflicts can be
		/// resolved by trimming the scheduled storyboard.
		/// </para>
		/// <para>
		/// A scheduled storyboard can be trimmed only if the priority comparison object registered with this method returns <c>S_OK</c>. If
		/// the new storyboard trims the scheduled storyboard, the scheduled storyboard can no longer affect a variable once the new
		/// storyboard begins to animate that variable.
		/// </para>
		/// <para>
		/// Passing <c>NULL</c> for the <c>comparison</c> parameter causes Windows Animation to release its reference to any handler object
		/// you passed in earlier. This technique can be essential for breaking reference cycles without having to call the
		/// IUIAnimationManager::Shutdown method.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager-settrimprioritycomparison
		// HRESULT SetTrimPriorityComparison( [in, optional] IUIAnimationPriorityComparison *comparison );
		void SetTrimPriorityComparison([In, Optional] IUIAnimationPriorityComparison? comparison);

		/// <summary>Sets the priority comparison handler to be called to determine whether a scheduled storyboard can be compressed.</summary>
		/// <param name="comparison">
		/// <para>The priority comparison handler for compression.</para>
		/// <para>The specified object must implement the IUIAnimationPriorityComparison interface or be <c>NULL</c>. See Remarks.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Setting a priority comparison handler with this method enables the application to indicate when the scheduling conflicts can be
		/// resolved by compressing the scheduled storyboard and any other storyboards animating the same variables.
		/// </para>
		/// <para>
		/// A storyboard can be compressed only if the priority comparison object registered with this method returns <c>S_OK</c> for all
		/// the other scheduled storyboards that will be affected by compression. When the storyboards are compressed, time is temporarily
		/// accelerated for affected storyboards, so they play faster.
		/// </para>
		/// <para>
		/// Passing <c>NULL</c> for the <c>comparison</c> parameter causes Windows Animation to release its reference to any handler object
		/// you passed in earlier. This technique can be essential for breaking reference cycles without having to call the
		/// IUIAnimationManager::Shutdown method.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager-setcompressprioritycomparison
		// HRESULT SetCompressPriorityComparison( [in, optional] IUIAnimationPriorityComparison *comparison );
		void SetCompressPriorityComparison([In, Optional] IUIAnimationPriorityComparison? comparison);

		/// <summary>Sets the priority comparison handler to be called to determine whether a scheduled storyboard can be concluded.</summary>
		/// <param name="comparison">
		/// The priority comparison handler for conclusion. The specified object must implement the IUIAnimationPriorityComparison interface
		/// or be <c>NULL</c>. See Remarks.
		/// </param>
		/// <remarks>
		/// <para>
		/// Setting a priority comparison handler with this method enables the application to indicate when scheduling conflicts can be
		/// resolved by concluding the scheduled storyboard.
		/// </para>
		/// <para>
		/// A scheduled storyboard can be concluded only if it contains a loop with a repetition count of UI_ANIMATION_REPEAT_INDEFINITELY
		/// and the priority comparison object registered with this method returns <c>S_OK</c>. If the storyboard is concluded, the current
		/// repetition of the loop completes, and the reminder of the storyboard then plays.
		/// </para>
		/// <para>
		/// Passing <c>NULL</c> for the <c>comparison</c> parameter causes Windows Animation to release its reference to any handler object
		/// you passed in earlier. This technique can be essential for breaking reference cycles without having to call the
		/// IUIAnimationManager::Shutdown method.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager-setconcludeprioritycomparison
		// HRESULT SetConcludePriorityComparison( [in, optional] IUIAnimationPriorityComparison *comparison );
		void SetConcludePriorityComparison([In, Optional] IUIAnimationPriorityComparison? comparison);

		/// <summary>Sets the default acceptable animation delay. This is the length of time that may pass before storyboards begin.</summary>
		/// <param name="delay">
		/// The default delay. This parameter can be a positive value, or <c>UI_ANIMATION_SECONDS_EVENTUALLY</c> (-1) to indicate that any
		/// finite delay is acceptable.
		/// </param>
		/// <remarks>
		/// For a storyboard to be successfully scheduled, it must begin before the longest acceptable delay has elapsed. This delay is
		/// determined in the following order: the delay value set by calling IUIAnimationStoryboard::SetLongestAcceptableDelay for this
		/// specific storyboard, the delay value set by calling this method, or 0.0 if neither method has been called.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager-setdefaultlongestacceptabledelay
		// HRESULT SetDefaultLongestAcceptableDelay( [in] UI_ANIMATION_SECONDS delay );
		void SetDefaultLongestAcceptableDelay([In] UI_ANIMATION_SECONDS delay);

		/// <summary>Shuts down the animation manager and all its associated objects.</summary>
		/// <remarks>
		/// Calling this method directs the animation manager, and all the objects it created, to release all their pointers to other
		/// objects. After <c>IUIAnimationManager::Shutdown</c> has been called, no other methods may be called on the animation manager or
		/// any objects that it created. An application can call this method to clean up if there is any possibility that the application
		/// has introduced a reference cycle that includes some animation objects.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager-shutdown HRESULT Shutdown();
		void Shutdown();
	}

	/// <summary>Defines a method for handling status updates to an animation manager.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nn-uianimation-iuianimationmanagereventhandler
	[PInvokeData("uianimation.h", MSDNShortId = "NN:uianimation.IUIAnimationManagerEventHandler")]
	[ComImport, Guid("783321ED-78A3-4366-B574-6AF607A64788"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IUIAnimationManagerEventHandler
	{
		/// <summary>Handles status changes to an animation manager.</summary>
		/// <param name="newStatus">The new status.</param>
		/// <param name="previousStatus">The previous status.</param>
		/// <returns>
		/// If the method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </returns>
		/// <remarks>A call made in this callback method to any other animation method results in the call failing and returning <c>UI_E_ILLEGAL_REENTRANCY</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanagereventhandler-onmanagerstatuschanged
		// HRESULT OnManagerStatusChanged( [in] UI_ANIMATION_MANAGER_STATUS newStatus, [in] UI_ANIMATION_MANAGER_STATUS previousStatus );
		[PreserveSig]
		HRESULT OnManagerStatusChanged(UI_ANIMATION_MANAGER_STATUS newStatus, UI_ANIMATION_MANAGER_STATUS previousStatus);
	}

	/// <summary>Defines a method for priority comparison that the animation manager uses to resolve scheduling conflicts.</summary>
	/// <remarks>
	/// <para>
	/// A single animation variable can be included in multiple storyboards, but multiple storyboards cannot animate the same variable at
	/// the same time.
	/// </para>
	/// <para>
	/// If a newly scheduled storyboard attempts to animate one or more variables that are currently scheduled for animation by different
	/// storyboards, a scheduling conflict occurs.
	/// </para>
	/// <para>
	/// To determine which storyboard has priority, the animation manager can call HasPriority on one or more priority comparison handlers
	/// provided by the application.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nn-uianimation-iuianimationprioritycomparison
	[PInvokeData("uianimation.h", MSDNShortId = "NN:uianimation.IUIAnimationPriorityComparison")]
	[ComImport, Guid("83FA9B74-5F86-4618-BC6A-A2FAC19B3F44"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IUIAnimationPriorityComparison
	{
		/// <summary>Determines whether a new storyboard has priority over a scheduled storyboard.</summary>
		/// <param name="scheduledStoryboard">The currently scheduled storyboard.</param>
		/// <param name="newStoryboard">The new storyboard that is interrupting the scheduled storyboard specified in <c>scheduledStoryboard</c>.</param>
		/// <param name="priorityEffect">The potential effect on <c>newStoryboard</c> if <c>scheduledStoryboard</c> has a higher priority.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>S_OK</c></description>
		/// <description><c>newStoryboard</c> has priority.</description>
		/// </item>
		/// <item>
		/// <description><c>S_FALSE</c></description>
		/// <description><c>scheduledStoryboard</c> has priority.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A single animation variable can be included in multiple storyboards, but multiple storyboards cannot animate the same variable
		/// at the same time.
		/// </para>
		/// <para>
		/// If a new storyboard attempts to animate one or more variables that are currently scheduled for animation by a different
		/// storyboard, a scheduling conflict occurs.
		/// </para>
		/// <para>
		/// To determine which storyboard has priority, the animation manager can call <c>HasPriority</c> on one or more priority comparison
		/// handlers provided by the application.
		/// </para>
		/// <para>
		/// Registering priority comparison objects is optional. By default, all storyboards can be trimmed, concluded or compressed to
		/// prevent failure, but none can be canceled, and by default no storyboards will be canceled or trimmed to prevent a delay.
		/// </para>
		/// <para>
		/// By default, a call made in a callback method to any other animation method results in the call failing and returning
		/// <c>UI_E_ILLEGAL_REENTRANCY</c>. However, there are exceptions to this default. The following methods can be successfully called
		/// from <c>HasPriority</c>:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>IUIAnimationManager::GetStoryboardFromTag</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationManager::GetVariableFromTag</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationStoryboard::GetTag</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable::GetTag</description>
		/// </item>
		/// </list>
		/// <para>Contention Management</para>
		/// <para>To resolve a scheduling conflict, the animation manager has the following options:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// Cancel the scheduled storyboard if it has not started playing and the priority comparison object registered with
		/// IUIAnimationManager::SetCancelPriorityComparison returns <c>S_OK</c>. Canceled storyboards are completely removed from the schedule.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// Trim the scheduled storyboard if the priority comparison object registered with IUIAnimationManager::SetTrimPriorityComparison
		/// returns <c>S_OK</c>. If the new storyboard trims the scheduled storyboard, the scheduled storyboard can no longer affect a
		/// variable when the new storyboard begins to animate that variable.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// Conclude the scheduled storyboard if the scheduled storyboard contains a loop with a repetition count of
		/// UI_ANIMATION_REPEAT_INDEFINITELY and the priority comparison object registered with
		/// IUIAnimationManager::SetConcludePriorityComparison returns <c>S_OK</c>. If the storyboard is concluded, the current repetition
		/// of the loop completes, and the reminder of the storyboard then plays.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// Compress the scheduled storyboard, and any other storyboards animating the same variables, if the priority comparison object
		/// registered with IUIAnimationManager::SetCompressPriorityComparison returns <c>S_OK</c> for all scheduled storyboards that might
		/// be affected by the compression. When the storyboards are compressed, time is temporarily accelerated for affected storyboards,
		/// so they play faster.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// If none of the above options is allowed by the priority comparison objects, the attempt to schedule the storyboard fails and
		/// Windows Animation returns UI_ANIMATION_SCHEDULING_INSUFFICIENT_PRIORITY to the calling application.
		/// </para>
		/// <para>
		/// Note that for the new storyboard to be successfully scheduled, it must begin before its longest acceptable delay has elapsed.
		/// This is determined by IUIAnimationStoryboard::SetLongestAcceptableDelay or IUIAnimationManager::SetDefaultLongestAcceptableDelay
		/// (if neither is called, the default is 0.0 seconds). If the longest acceptable delay is <c>UI_ANIMATION_SECONDS_EVENTUALLY</c>,
		/// any finite delay will be sufficient.
		/// </para>
		/// <para>
		/// The <c>priorityEffect</c> parameter describes the possible effect on the new storyboard if <c>HasPriority</c> were to return
		/// S_FALSE. If <c>priorityEffect</c> is UI_ANIMATION_PRIORITY_EFFECT_FAILURE, it is possible that returning S_FALSE will result in
		/// a failure to schedule the new storyboard (it is also possible that the animation manager will be allowed to resolve the conflict
		/// in a different way by another priority comparison object). If <c>priorityEffect</c> is
		/// <c>UI_ANIMATION_PRIORITY_EFFECT_DELAY</c>, the only downside of returning S_FALSE is that the storyboard might begin later than
		/// it would have had <c>HasPriority</c> returned S_OK.
		/// </para>
		/// <para>
		/// When UI_ANIMATION_PRIORITY_EFFECT_DELAY is passed to <c>HasPriority</c>, the animation manager has already determined that it
		/// can schedule the new storyboard such that it will begin before its longest acceptable delay has elapsed, but it is in effect
		/// asking the application if the storyboard should begin even earlier. In some scenarios, it might be best to reduce the latency of
		/// an animation by returning S_OK. In others, it might be preferable to let scheduled animations complete whenever possible, in
		/// which case S_FALSE should be returned. <c>UI_ANIMATION_PRIORITY_EFFECT_DELAY</c> is only passed to <c>HasPriority</c> when the
		/// animation manager is considering canceling or trimming a storyboard.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationprioritycomparison-haspriority HRESULT
		// HasPriority( [in] IUIAnimationStoryboard *scheduledStoryboard, [in] IUIAnimationStoryboard *newStoryboard, [in]
		// UI_ANIMATION_PRIORITY_EFFECT priorityEffect );
		[PreserveSig]
		HRESULT HasPriority(IUIAnimationStoryboard scheduledStoryboard, IUIAnimationStoryboard newStoryboard, UI_ANIMATION_PRIORITY_EFFECT priorityEffect);
	}

	/// <summary>Defines a storyboard, which contains a group of transitions that are synchronized relative to one another.</summary>
	/// <remarks><c>IUIAnimationStoryboard</c> is a primary component for building animations, along with IUIAnimationVariable and IUIAnimationTransition.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nn-uianimation-iuianimationstoryboard
	[PInvokeData("uianimation.h", MSDNShortId = "NN:uianimation.IUIAnimationStoryboard")]
	[ComImport, Guid("A8FF128F-9BF9-4AF1-9E67-E5E410DEFB84"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IUIAnimationStoryboard
	{
		/// <summary>Adds a transition to the storyboard.</summary>
		/// <param name="variable">The animation variable for which the transition is to be added.</param>
		/// <param name="transition">The transition to be added.</param>
		/// <remarks>
		/// <para>
		/// The <c>AddTransition</c> method applies the specified transition to the specified variable in the storyboard. If this is the
		/// first transition applied to this variable in this storyboard, the transition begins at the start of the storyboard. Otherwise,
		/// the transition is appended to the transition that was most recently added to the variable.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Create a Storyboard and Add Transitions.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboard-addtransition HRESULT
		// AddTransition( [in] IUIAnimationVariable *variable, [in] IUIAnimationTransition *transition );
		void AddTransition(IUIAnimationVariable variable, IUIAnimationTransition transition);

		/// <summary>Adds a keyframe at the specified offset from an existing keyframe.</summary>
		/// <param name="existingKeyframe">
		/// The existing keyframe. To add a keyframe at an offset from the start of the storyboard, use the special keyframe UI_ANIMATION_KEYFRAME_STORYBOARD_START.
		/// </param>
		/// <param name="offset">The offset from the existing keyframe at which a new keyframe is to be added.</param>
		/// <param name="keyframe">The keyframe to be added.</param>
		/// <remarks>
		/// <para>
		/// A keyframe represents a moment in time within a storyboard and can be used to specify the start and end times of transitions.
		/// Because keyframes can be added at the ends of transitions, their offsets from the start of the storyboard may not be known until
		/// the storyboard is playing.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code adds a keyframe at a fixed offset of 0.3 seconds from the keyframe at the start of the storyboard.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboard-addkeyframeatoffset HRESULT
		// AddKeyframeAtOffset( [in] UI_ANIMATION_KEYFRAME existingKeyframe, [in] UI_ANIMATION_SECONDS offset, [out] UI_ANIMATION_KEYFRAME
		// *keyframe );
		void AddKeyframeAtOffset(UI_ANIMATION_KEYFRAME existingKeyframe, double offset, out UI_ANIMATION_KEYFRAME keyframe);

		/// <summary>Adds a keyframe at the end of the specified transition.</summary>
		/// <param name="transition">The transition after which a keyframe is to be added.</param>
		/// <param name="keyframe">The keyframe to be added.</param>
		/// <remarks>
		/// A keyframe represents a moment in time within a storyboard and can be used to specify the start and end times of transitions.
		/// Because keyframes can be added at the ends of transitions, their offsets from the start of the storyboard may not be known until
		/// the storyboard is playing.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboard-addkeyframeaftertransition
		// HRESULT AddKeyframeAfterTransition( [in] IUIAnimationTransition *transition, [out] UI_ANIMATION_KEYFRAME *keyframe );
		void AddKeyframeAfterTransition(IUIAnimationTransition transition, out UI_ANIMATION_KEYFRAME keyframe);

		/// <summary>Adds a transition that starts at the specified keyframe.</summary>
		/// <param name="variable">The animation variable for which a transition is to be added.</param>
		/// <param name="transition">The transition to be added.</param>
		/// <param name="startKeyframe">The keyframe that specifies the beginning of the new transition.</param>
		/// <remarks>
		/// <para>
		/// Transitions must be added in the order in which they will be played. A transition may begin playing before the preceding
		/// transition in the storyboard has finished, in which case the initial value and velocity seen by the new transition is determined
		/// by the state of the preceding one. A transition should not begin before the start of the preceding transition.
		/// </para>
		/// <para>
		/// A keyframe represents a moment in time within a storyboard and can be used to specify the start and end times of transitions.
		/// Because keyframes can be added at the ends of transitions, their offsets from the start of the storyboard may not be known until
		/// the storyboard is playing.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboard-addtransitionatkeyframe
		// HRESULT AddTransitionAtKeyframe( [in] IUIAnimationVariable *variable, [in] IUIAnimationTransition *transition, [in]
		// UI_ANIMATION_KEYFRAME startKeyframe );
		void AddTransitionAtKeyframe(IUIAnimationVariable variable, IUIAnimationTransition transition, UI_ANIMATION_KEYFRAME startKeyframe);

		/// <summary>Adds a transition between two keyframes.</summary>
		/// <param name="variable">The animation variable for which the transition is to be added.</param>
		/// <param name="transition">The transition to be added.</param>
		/// <param name="startKeyframe">A keyframe that specifies the beginning of the new transition.</param>
		/// <param name="endKeyframe">
		/// A keyframe that specifies the end of the new transition. It must not be possible for <c>endKeyframe</c> to appear earlier in the
		/// storyboard than <c>startKeyframe</c>.
		/// </param>
		/// <remarks>
		/// <para>
		/// This method applies the specified transition to the specified variable in the storyboard, with the transition starting and
		/// ending at the specified keyframes. If the transition was created with a duration parameter specified, that duration is
		/// overwritten with the duration of time between the start and end keyframes. Otherwise, Windows Animation speeds up or slows down
		/// the transition as necessary.
		/// </para>
		/// <para>
		/// A keyframe represents a moment in time within a storyboard and can be used to specify the start and end times of transitions.
		/// Because keyframes can be added at the ends of transitions, their offsets from the start of the storyboard may not be known until
		/// the storyboard is playing.
		/// </para>
		/// <para>
		/// Transitions must be added in the order in which they will be played. A transition may begin playing before the preceding
		/// transition in the storyboard has finished, in which case the initial value and velocity seen by the new transition will be
		/// determined by the state of the preceding one. It must not be possible for a transition to begin before the start of the
		/// preceding transition.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboard-addtransitionbetweenkeyframes
		// HRESULT AddTransitionBetweenKeyframes( [in] IUIAnimationVariable *variable, [in] IUIAnimationTransition *transition, [in]
		// UI_ANIMATION_KEYFRAME startKeyframe, [in] UI_ANIMATION_KEYFRAME endKeyframe );
		void AddTransitionBetweenKeyframes(IUIAnimationVariable variable, IUIAnimationTransition transition, UI_ANIMATION_KEYFRAME startKeyframe, UI_ANIMATION_KEYFRAME endKeyframe);

		/// <summary>Creates a loop between two specified keyframes.</summary>
		/// <param name="startKeyframe">The keyframe at which the loop is to begin.</param>
		/// <param name="endKeyframe">
		/// The keyframe at which the loop is to end. It must not be possible for <c>endKeyframe</c> to occur earlier in the storyboard than <c>startKeyframe</c>.
		/// </param>
		/// <param name="repetitionCount">
		/// The number of times the loop is to be repeated; this parameter must be 0 or a positive number. Use
		/// UI_ANIMATION_REPEAT_INDEFINITELY (-1) to repeat the loop indefinitely until the storyboard is trimmed or concluded.
		/// </param>
		/// <remarks>
		/// <para>
		/// This method directs a storyboard to play the interval between the given keyframes repeatedly before playing the remainder of the
		/// storyboard. If a finite repetition count is specified, the loop always plays that number of times. If
		/// UI_ANIMATION_REPEAT_INDEFINITELY (-1) is specified, the loop repeats until the storyboard is concluded, in which case the
		/// current iteration of the loop completes and the remainder of the storyboard plays. A storyboard that loops indefinitely also
		/// ends if it is truncated.
		/// </para>
		/// <para>Nested and overlapping loops are not supported.</para>
		/// <para>
		/// A keyframe represents a moment in time within a storyboard and can be used to specify the start or end times of transitions.
		/// Because keyframes can be added at the ends of transitions, their offsets from the start of the storyboard may not be known until
		/// the storyboard is playing.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboard-repeatbetweenkeyframes
		// HRESULT RepeatBetweenKeyframes( [in] UI_ANIMATION_KEYFRAME startKeyframe, [in] UI_ANIMATION_KEYFRAME endKeyframe, [in] INT32
		// repetitionCount );
		void RepeatBetweenKeyframes(UI_ANIMATION_KEYFRAME startKeyframe, UI_ANIMATION_KEYFRAME endKeyframe, int repetitionCount);

		/// <summary>Directs the storyboard to hold the specified animation variable at its final value until the storyboard ends.</summary>
		/// <param name="variable">The animation variable.</param>
		/// <remarks>
		/// When a storyboard is playing, it has exclusive access to any variables it animates unless the storyboard is trimmed by a higher
		/// priority storyboard. Typically, this exclusive access is released when the last transition in the storyboard for that variable
		/// finishes playing. Applications can call this method to maintain exclusive access to the animation variable and hold the
		/// variable, at the final value of the last transition, until the end of the storyboard.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboard-holdvariable HRESULT
		// HoldVariable( [in] IUIAnimationVariable *variable );
		void HoldVariable(IUIAnimationVariable variable);

		/// <summary>Sets the longest acceptable delay before the scheduled storyboard begins.</summary>
		/// <param name="delay">
		/// The longest acceptable delay. This parameter can be a positive value, or <c>UI_ANIMATION_SECONDS_EVENTUALLY</c> (-1) to indicate
		/// that any finite delay is acceptable.
		/// </param>
		/// <remarks>
		/// For a storyboard to be successfully scheduled, it must begin before the longest acceptable delay has elapsed. This delay is
		/// determined in the following order: the delay value set by calling this method, the delay value set by calling the
		/// IUIAnimationManager::SetDefaultLongestAcceptableDelay method, or 0.0 if neither of these methods has been called.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboard-setlongestacceptabledelay
		// HRESULT SetLongestAcceptableDelay( [in] UI_ANIMATION_SECONDS delay );
		void SetLongestAcceptableDelay(double delay);

		/// <summary>Directs the storyboard to schedule itself for play.</summary>
		/// <param name="timeNow">The current time.</param>
		/// <param name="schedulingResult">The result of the scheduling request. This parameter can be omitted from calls to this method.</param>
		/// <remarks>
		/// <para>This method directs a storyboard to attempt to add itself to the schedule of playing storyboards. The rules are as follows:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// If there are no playing storyboards animating any of the same animation variables, the attempt succeeds and the storyboard
		/// starts playing immediately.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If the storyboard has priority to cancel, trim, conclude, or compress conflicting storyboards, the attempt to schedule succeeds
		/// and the storyboard begins playing as soon as possible.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If the storyboard does not have priority, the attempt fails and the <c>schedulingResult</c> parameter is set to <c>UI_ANIMATION_SCHEDULING_INSUFFICIENT_PRIORITY</c>.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// If this method is called from a handler for OnStoryboardStatusChanged events, the <c>schedulingResult</c> parameter is set to
		/// <c>UI_ANIMATION_SCHEDULING_DEFERRED</c>. The only way to determine whether the storyboard is successfully scheduled is to set a
		/// storyboard event handler and check whether the storyboard's status ever becomes <c>UI_ANIMATION_STORYBOARD_INSUFFICIENT_PRIORITY</c>.
		/// </para>
		/// <para>
		/// It is possible reuse a storyboard by calling <c>Schedule</c> again after its status has reached
		/// <c>UI_ANIMATION_STORYBOARD_READY</c>. An attempt to schedule a storyboard when it is in any state other than
		/// <c>UI_ANIMATION_STORYBOARD_BUILDING</c> or <c>UI_ANIMATION_STORYBOARD_READY</c> fails, and <c>schedulingResult</c> is set to <c>UI_ANIMATION_SCHEDULING_ALREADY_SCHEDULED</c>.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example gets the current time and schedules the storyboard. For an additional example, see Schedule a Storyboard.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboard-schedule HRESULT Schedule(
		// [in] UI_ANIMATION_SECONDS timeNow, [out, optional] UI_ANIMATION_SCHEDULING_RESULT *schedulingResult );
		void Schedule(double timeNow, [Optional] out UI_ANIMATION_SCHEDULING_RESULT schedulingResult);

		/// <summary>
		/// Completes the current iteration of a keyframe loop that is in progress (where the loop is set to
		/// <c>UI_ANIMATION_REPEAT_INDEFINITELY</c>), terminates the loop, and continues with the storyboard.
		/// </summary>
		/// <remarks>
		/// <para>
		/// This method specifies that any subsequent keyframe loops that have a repetition count of UI_ANIMATION_REPEAT_INDEFINITELY (-1)
		/// will be skipped while the remainder of the storyboard is played.
		/// </para>
		/// <para>An iteration of a keyframe loop that is in progress will be completed before the remainder of the storyboard plays.</para>
		/// <para>
		/// If this method is called at the end of a keyframe loop iteration, the loop is terminated and the loop value is set to the
		/// starting loop value.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboard-conclude HRESULT Conclude();
		void Conclude();

		/// <summary>Finishes the storyboard within the specified time, compressing the storyboard if necessary.</summary>
		/// <param name="completionDeadline">The maximum amount of time that the storyboard can use to finish playing.</param>
		/// <remarks>This method has no effect on storyboard events. Events continue to be raised as expected while the storyboard plays.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboard-finish HRESULT Finish( [in]
		// UI_ANIMATION_SECONDS completionDeadline );
		void Finish(double completionDeadline);

		/// <summary>Terminates the storyboard, releases all related animation variables, and removes the storyboard from the schedule.</summary>
		/// <remarks>
		/// <para>This method can be called before or after the storyboard starts playing.</para>
		/// <para>This method does not trigger any storyboard events.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboard-abandon HRESULT Abandon();
		void Abandon();

		/// <summary>Sets the tag for the storyboard.</summary>
		/// <param name="object">The object portion of the tag. This parameter can be <c>NULL</c>.</param>
		/// <param name="id">The identifier portion of the tag.</param>
		/// <remarks>
		/// A tag is a pairing of an integer identifier ( <c>id</c>) with a COM object ( <c>object</c>); it can be used by an application to
		/// identify a storyboard.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboard-settag HRESULT SetTag( [in,
		// optional] IUnknown *object, [in] UINT32 id );
		void SetTag([In, MarshalAs(UnmanagedType.IUnknown)] object? @object, uint id);

		/// <summary>Gets the tag for a storyboard.</summary>
		/// <param name="obj">The object portion of the tag.</param>
		/// <param name="id">The identifier portion of the tag.</param>
		/// <returns>
		/// <para>
		/// If the method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>UI_E_VALUE_NOT_SET</c></description>
		/// <description>The storyboard's tag was not set.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A tag is a pairing of an integer identifier ( <c>id</c>) with a COM object ( <c>object</c>); it can be used by an application to
		/// identify a storyboard.
		/// </para>
		/// <para>The parameters are optional so that the method can return both portions of the tag, or just the identifier or object portion.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboard-gettag HRESULT GetTag(
		// [out, optional] IUnknown **object, [out, optional] UINT32 *id );
		unsafe HRESULT GetTag([Out, Optional] IntPtr* obj, [Out, Optional] uint* id);

		/// <summary>Gets the status of the storyboard.</summary>
		/// <returns>The storyboard status.</returns>
		/// <remarks>
		/// Unless this method is called from a handler for OnStoryboardStatusChanged events, the only values it returns are
		/// <c>UI_ANIMATION_STORYBOARD_BUILDING</c>, <c>UI_ANIMATION_STORYBOARD_SCHEDULED</c>, <c>UI_ANIMATION_STORYBOARD_PLAYING</c>, and <c>UI_ANIMATION_STORYBOARD_READY</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboard-getstatus HRESULT
		// GetStatus( [out] UI_ANIMATION_STORYBOARD_STATUS *status );
		UI_ANIMATION_STORYBOARD_STATUS GetStatus();

		/// <summary>Gets the time that has elapsed since the storyboard started playing.</summary>
		/// <returns>The elapsed time.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboard-getelapsedtime HRESULT
		// GetElapsedTime( [out] UI_ANIMATION_SECONDS *elapsedTime );
		double GetElapsedTime();

		/// <summary>Specifies a handler for storyboard events.</summary>
		/// <param name="handler">
		/// <para>The handler to be called whenever storyboard status and update events occur.</para>
		/// <para>The specified object must implement the IUIAnimationStoryboardEventHandler interface or be <c>NULL</c>. See Remarks.</para>
		/// </param>
		/// <remarks>
		/// Passing <c>NULL</c> for the <c>handler</c> parameter causes Windows Animation to release its reference to any handler object you
		/// passed in earlier. This technique can be essential for breaking reference cycles without having to call the
		/// IUIAnimationManager::Shutdown method.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboard-setstoryboardeventhandler
		// HRESULT SetStoryboardEventHandler( [in, optional] IUIAnimationStoryboardEventHandler *handler );
		void SetStoryboardEventHandler(IUIAnimationStoryboardEventHandler? handler);
	}

	/// <summary>Directs the storyboard to schedule itself for play.</summary>
	/// <param name="this">The <see cref="IUIAnimationStoryboard"/> instance.</param>
	/// <param name="timeNow">The current time.</param>
	/// <remarks>
	/// <para>This method directs a storyboard to attempt to add itself to the schedule of playing storyboards. The rules are as follows:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// If there are no playing storyboards animating any of the same animation variables, the attempt succeeds and the storyboard starts
	/// playing immediately.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// If the storyboard has priority to cancel, trim, conclude, or compress conflicting storyboards, the attempt to schedule succeeds and
	/// the storyboard begins playing as soon as possible.
	/// </description>
	/// </item>
	/// <item>
	/// <description>If the storyboard does not have priority, the attempt fails.</description>
	/// </item>
	/// </list>
	/// </remarks>
	public static void Schedule(this IUIAnimationStoryboard @this, double timeNow) => @this.Schedule(timeNow, out _);

	/// <summary>Defines methods for handling status and update events for a storyboard.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nn-uianimation-iuianimationstoryboardeventhandler
	[PInvokeData("uianimation.h", MSDNShortId = "NN:uianimation.IUIAnimationStoryboardEventHandler")]
	[ComImport, Guid("3D5C9008-EC7C-4364-9F8A-9AF3C58CBAE6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IUIAnimationStoryboardEventHandler
	{
		/// <summary>Handles events that occur when a storyboard's status changes.</summary>
		/// <param name="storyboard">The storyboard whose status has changed.</param>
		/// <param name="newStatus">The new status.</param>
		/// <param name="previousStatus">The previous status.</param>
		/// <returns>
		/// If the method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </returns>
		/// <remarks>
		/// <para>
		/// By default, a call made in a callback method to any other animation method results in the call failing and returning
		/// <c>UI_E_ILLEGAL_REENTRANCY</c>. However, there are exceptions to this default. The following methods can be successfully called
		/// from <c>OnStoryboardStatusChanged</c>:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>IUIAnimationManager::CreateAnimationVariable</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationManager::CreateStoryboard</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationManager::GetStoryboardFromTag</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationManager::GetVariableFromTag</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationStoryboard::Abandon</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationStoryboard::AddKeyframeAtOffset</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationStoryboard::AddKeyframeAfterTransition</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationStoryboard::AddTransition</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationStoryboard::AddTransitionAtKeyframe</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationStoryboard::AddTransitionBetweenKeyframes</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationStoryboard::Conclude</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationStoryboard::Finish</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationStoryboard::GetTag</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationStoryboard::HoldVariable</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationStoryboard::RepeatBetweenKeyframes</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationStoryboard::SetLongestAcceptableDelay</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationStoryboard::SetStoryboardEventHandler</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationStoryboard::SetTag</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationStoryboard::Schedule</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationTransition::GetDuration</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationTransition::IsDurationKnown</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationTransition::SetInitialValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationTransition::SetInitialVelocity</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable::GetCurrentStoryboard</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable::GetFinalIntegerValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable::GetFinalValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable::GetIntegerValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable::GetPreviousIntegerValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable::GetPreviousValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable::GetTag</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable::GetValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable::SetTag</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboardeventhandler-onstoryboardstatuschanged
		// HRESULT OnStoryboardStatusChanged( [in] IUIAnimationStoryboard *storyboard, [in] UI_ANIMATION_STORYBOARD_STATUS newStatus, [in]
		// UI_ANIMATION_STORYBOARD_STATUS previousStatus );
		[PreserveSig]
		HRESULT OnStoryboardStatusChanged(IUIAnimationStoryboard storyboard, UI_ANIMATION_STORYBOARD_STATUS newStatus, UI_ANIMATION_STORYBOARD_STATUS previousStatus);

		/// <summary>Handles events that occur when a storyboard is updated.</summary>
		/// <param name="storyboard">The storyboard that has been updated.</param>
		/// <returns>
		/// If the method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method is called when the value of at least one of the variables that a storyboard is animating has changed since the last
		/// call to the IUIAnimationManager::Update method.
		/// </para>
		/// <para>
		/// By default, a call made in a callback method to any other animation method results in the call failing and returning
		/// <c>UI_E_ILLEGAL_REENTRANCY</c>. However, there are exceptions to this default. The following methods can be successfully called
		/// from <c>OnStoryboardUpdated</c>:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>IUIAnimationManager::GetStoryboardFromTag</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationManager::GetVariableFromTag</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationStoryboard::GetTag</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable::GetCurrentStoryboard</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable::GetFinalIntegerValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable::GetFinalValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable::GetIntegerValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable::GetPreviousIntegerValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable::GetPreviousValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable::GetTag</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable::GetValue</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboardeventhandler-onstoryboardupdated
		// HRESULT OnStoryboardUpdated( [in] IUIAnimationStoryboard *storyboard );
		[PreserveSig]
		HRESULT OnStoryboardUpdated(IUIAnimationStoryboard storyboard);
	}

	/// <summary>Defines an animation timer, which provides services for managing animation timing.</summary>
	/// <remarks>
	/// <para>
	/// A timer helps to manage animation rendering by automatically indicating the passage of a small unit of time, called a tick. In turn,
	/// ticks can trigger animation rendering or other animation events. Each animation timer provides timing for a single animation manager.
	/// </para>
	/// <para>
	/// The timing system is designed to provide the necessary timing services needed to support animations and does not require
	/// applications to play an explicit role in generating the ticks. The animation timer can be set up to automatically update the
	/// animation manager for each tick without application-side handling.
	/// </para>
	/// <para>
	/// An application may not need to use a timer with Windows Animation, depending on the graphics platform it is using. For example, an
	/// application drawing with Direct2D or Direct3D can synchronize to monitor's refresh rate, yielding very smooth animation. However,
	/// such applications may still find the <c>IUIAnimationTimer</c> interface useful for its GetTime method, which returns an accurate
	/// system time in UI_ANIMATION_SECONDS, the units used throughout the Windows Animation API.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example that creates the animation timer object, see Create the Main Animation Objects.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nn-uianimation-iuianimationtimer
	[PInvokeData("uianimation.h", MSDNShortId = "NN:uianimation.IUIAnimationTimer")]
	[ComImport, Guid("6B0EFAD1-A053-41D6-9085-33A689144665"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(UIAnimationTimer))]
	public interface IUIAnimationTimer
	{
		/// <summary>Specifies a timer update handler.</summary>
		/// <param name="updateHandler">
		/// A timer update handler, or <c>NULL</c> (see Remarks). The specified object must implement the IUIAnimationTimerUpdateHandler interface.
		/// </param>
		/// <param name="idleBehavior">A member of UI_ANIMATION_IDLE_BEHAVIOR that specifies the behavior of the timer when it is idle.</param>
		/// <remarks>
		/// <para>
		/// The timer update handler receives time updates (ticks) from the timer. The timer indicates an update by calling the
		/// IUIAnimationTimerUpdateHandler::OnUpdate method on the specified handler.
		/// </para>
		/// <para>
		/// Passing <c>NULL</c> for the <c>updateHandler</c> parameter causes Windows Animation to release its reference to any handler
		/// object you passed in earlier. This technique can be essential for breaking reference cycles without having to call the
		/// IUIAnimationManager::Shutdown method.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Update the Animation Manager.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtimer-settimerupdatehandler HRESULT
		// SetTimerUpdateHandler( [in, optional] IUIAnimationTimerUpdateHandler *updateHandler, [in] UI_ANIMATION_IDLE_BEHAVIOR idleBehavior );
		void SetTimerUpdateHandler(IUIAnimationTimerUpdateHandler updateHandler, UI_ANIMATION_IDLE_BEHAVIOR idleBehavior);

		/// <summary>Specifies a timer event handler.</summary>
		/// <param name="handler">
		/// A timer event handler. The specified object must implement the IUIAnimationTimerEventHandler interface or be <c>NULL</c>. See Remarks.
		/// </param>
		/// <remarks>
		/// <para>
		/// Timing events include the OnPreUpdate, OnPostUpdate, and OnRenderingTooSlow methods of the IUIAnimationTimerEventHandler interface.
		/// </para>
		/// <para>
		/// Passing <c>NULL</c> for the <c>handler</c> parameter causes Windows Animation to release its reference to any handler object you
		/// passed in earlier. This technique can be essential for breaking reference cycles without having to call the
		/// IUIAnimationManager::Shutdown method.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Update the Animation Manager and Draw Frames.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtimer-settimereventhandler HRESULT
		// SetTimerEventHandler( [in, optional] IUIAnimationTimerEventHandler *handler );
		void SetTimerEventHandler(IUIAnimationTimerEventHandler? handler);

		/// <summary>Enables the animation timer.</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtimer-enable HRESULT Enable();
		void Enable();

		/// <summary>Disables the animation timer.</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtimer-disable HRESULT Disable();
		void Disable();

		/// <summary>Determines whether the timer is currently enabled.</summary>
		/// <returns>
		/// Returns S_OK if the animation timer is enabled, S_FALSE if the animation timer is disabled, or an <c>HRESULT</c> error code. See
		/// Windows Animation Error Codes for a list of error codes.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtimer-isenabled HRESULT IsEnabled();
		[PreserveSig]
		HRESULT IsEnabled();

		/// <summary>Gets the current time.</summary>
		/// <returns>The current time, in UI_ANIMATION_SECONDS.</returns>
		/// <remarks>
		/// <para>
		/// This method can be used in both the application-driven and timer-driven configurations to retrieve the system time in
		/// UI_ANIMATION_SECONDS, the units used throughout the Windows Animation API.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Update the Animation Manager and Draw Frames.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtimer-gettime HRESULT GetTime( [out]
		// UI_ANIMATION_SECONDS *seconds );
		double GetTime();

		/// <summary>Sets the frame rate below which the timer notifies the application that rendering is too slow.</summary>
		/// <param name="framesPerSecond">The minimum desirable frame rate, in frames per second.</param>
		/// <remarks>
		/// If the rendering frame rate for an animation falls below the specified frame rate, an
		/// IUIAnimationTimerEventHandler::OnRenderingTooSlow event is raised.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtimer-setframeratethreshold HRESULT
		// SetFrameRateThreshold( [in] UINT32 framesPerSecond );
		void SetFrameRateThreshold(uint framesPerSecond);
	}

	/// <summary>Defines a method for handling events related to changes in timer client status.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nn-uianimation-iuianimationtimerclienteventhandler
	[PInvokeData("uianimation.h", MSDNShortId = "NN:uianimation.IUIAnimationTimerClientEventHandler")]
	[ComImport, Guid("BEDB4DB6-94FA-4BFB-A47F-EF2D9E408C25"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IUIAnimationTimerClientEventHandler
	{
		/// <summary>Handles events that occur when the status of the timer's client changes.</summary>
		/// <param name="newStatus">The new status of the timer's client.</param>
		/// <param name="previousStatus">The previous status of the timer's client.</param>
		/// <returns>
		/// If the method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtimerclienteventhandler-ontimerclientstatuschanged
		// HRESULT OnTimerClientStatusChanged( [in] UI_ANIMATION_TIMER_CLIENT_STATUS newStatus, [in] UI_ANIMATION_TIMER_CLIENT_STATUS
		// previousStatus );
		[PreserveSig]
		HRESULT OnTimerClientStatusChanged(UI_ANIMATION_TIMER_CLIENT_STATUS newStatus, UI_ANIMATION_TIMER_CLIENT_STATUS previousStatus);
	}

	/// <summary>Defines methods for handling timing events.</summary>
	/// <remarks>
	/// <para>Use SetTimerEventHandler to specify the timing events handler for an instance of IUIAnimationTimer.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Read the Animation Variable Values and Draw Frames.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nn-uianimation-iuianimationtimereventhandler
	[PInvokeData("uianimation.h", MSDNShortId = "NN:uianimation.IUIAnimationTimerEventHandler")]
	[ComImport, Guid("274A7DEA-D771-4095-ABBD-8DF7ABD23CE3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IUIAnimationTimerEventHandler
	{
		/// <summary>Handles events that occur before an animation update begins.</summary>
		/// <returns>
		/// If the method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See UIAnimation Error Codes for a
		/// list of error codes.
		/// </returns>
		/// <remarks>
		/// <para>For each tick, a timer calls the following sequence of methods:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>IUIAnimationTimerEventHandler::OnPreUpdate</c></description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationTimerUpdateHandler::OnUpdate</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationTimerEventHandler::OnPostUpdate</description>
		/// </item>
		/// </list>
		/// <para>
		/// <c>OnPreUpdate</c> and OnPostUpdate are called on the IUIAnimationTimerEventHandler registered with the
		/// IUIAnimationTimer::SetTimerEventHandler method. OnUpdate is called on the IUIAnimationTimerUpdateHandler registered with the
		/// IUIAnimationTimer::SetTimerUpdateHandler method.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtimereventhandler-onpreupdate HRESULT OnPreUpdate();
		[PreserveSig]
		HRESULT OnPreUpdate();

		/// <summary>Handles events that occur after an animation update is finished.</summary>
		/// <returns>
		/// If the method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See UIAnimation Error Codes for a
		/// list of error codes.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The UIAnimationTimer object calls this method only when calls to IUIAnimationTimerUpdateHandler::OnUpdate return a result of <c>UI_ANIMATION_UPDATE_VARIABLES_CHANGED</c>.
		/// </para>
		/// <para>For each tick, a timer calls the following sequence of methods:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>IUIAnimationTimerEventHandler::OnPreUpdate</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationTimerUpdateHandler::OnUpdate</description>
		/// </item>
		/// <item>
		/// <description><c>IUIAnimationTimerEventHandler::OnPostUpdate</c></description>
		/// </item>
		/// </list>
		/// <para>
		/// OnPreUpdate and <c>OnPostUpdate</c> are called on the IUIAnimationTimerEventHandler registered with
		/// IUIAnimationTimer::SetTimerEventHandler. OnUpdate is called on the IUIAnimationTimerUpdateHandler registered with IUIAnimationTimer::SetTimerUpdateHandler.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtimereventhandler-onpostupdate HRESULT OnPostUpdate();
		[PreserveSig]
		HRESULT OnPostUpdate();

		/// <summary>Handles events that occur when the rendering frame rate for an animation falls below a minimum desirable frame rate.</summary>
		/// <param name="framesPerSecond">The current frame rate, in frames per second.</param>
		/// <returns>
		/// If the method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See UIAnimation Error Codes for a
		/// list of error codes.
		/// </returns>
		/// <remarks>The minimum desirable frame rate is specified using the IUIAnimationTimer::SetFrameRateThreshold method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtimereventhandler-onrenderingtooslow
		// HRESULT OnRenderingTooSlow( [in] UINT32 framesPerSecond );
		[PreserveSig]
		HRESULT OnRenderingTooSlow(uint framesPerSecond);
	}

	/// <summary>Defines methods for handling timing update events.</summary>
	/// <remarks>
	/// The UIAnimationManager object implements this interface, so a client application can query the <c>UIAnimationManager</c> object for
	/// this interface and then pass the interface to IUIAnimationTimer::SetTimerUpdateHandler. It is not necessary to disconnect the
	/// <c>UIAnimationManager</c> and UIAnimationTimer objects; releasing them both is sufficient to clean up.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nn-uianimation-iuianimationtimerupdatehandler
	[PInvokeData("uianimation.h", MSDNShortId = "NN:uianimation.IUIAnimationTimerUpdateHandler")]
	[ComImport, Guid("195509B7-5D5E-4E3E-B278-EE3759B367AD"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IUIAnimationTimerUpdateHandler
	{
		/// <summary>Handles update events from the timer.</summary>
		/// <param name="timeNow">The current timer time, in seconds.</param>
		/// <param name="result">
		/// Receives a member of the UI_ANIMATION_UPDATE_RESULT enumeration, indicating whether any animation variables changed as a result
		/// of the update.
		/// </param>
		/// <returns>
		/// If the method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </returns>
		/// <remarks>
		/// This method is used by the UIAnimationTimer object to update the state of the UIAnimationManager object. The
		/// <c>UIAnimationTimer</c> object calls UIAnimationTimerEventHandler::OnPostUpdate only when calls to this method return a result
		/// of <c>UI_ANIMATION_UPDATE_VARIABLES_CHANGED</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtimerupdatehandler-onupdate HRESULT
		// OnUpdate( [in] UI_ANIMATION_SECONDS timeNow, [out] UI_ANIMATION_UPDATE_RESULT *result );
		[PreserveSig]
		HRESULT OnUpdate(double timeNow, out UI_ANIMATION_UPDATE_RESULT result);

		/// <summary>Specifies a handler for timer client status change events.</summary>
		/// <param name="handler">A handler for timer client events. The specified object must implement IUIAnimationTimerUpdateHandler.</param>
		/// <returns>
		/// If the method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </returns>
		/// <remarks>If the update handler is already connected to the timer, this method returns <c>UI_E_TIMER_CLIENT_ALREADY_CONNECTED.</c></remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtimerupdatehandler-settimerclienteventhandler
		// HRESULT SetTimerClientEventHandler( [in] IUIAnimationTimerClientEventHandler *handler );
		[PreserveSig]
		HRESULT SetTimerClientEventHandler(IUIAnimationTimerClientEventHandler handler);

		/// <summary>Clears the handler for timer client status change events.</summary>
		/// <returns>
		/// If the method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtimerupdatehandler-cleartimerclienteventhandler
		// HRESULT ClearTimerClientEventHandler();
		[PreserveSig]
		HRESULT ClearTimerClientEventHandler();
	}

	/// <summary>Defines a transition, which determines how an animation variable changes over time.</summary>
	/// <remarks>
	/// <para>
	/// <c>IUIAnimationTransition</c> is one of the primary interfaces used to add animation to an application, along with the
	/// IUIAnimationVariable and IUIAnimationStoryboard interfaces.
	/// </para>
	/// <para>UIAnimationTransitionLibrary implements a library of standard transitions.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nn-uianimation-iuianimationtransition
	[PInvokeData("uianimation.h", MSDNShortId = "NN:uianimation.IUIAnimationTransition")]
	[ComImport, Guid("DC6CE252-F731-41CF-B610-614B6CA049AD"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IUIAnimationTransition
	{
		/// <summary>Sets the initial value for the transition.</summary>
		/// <param name="value">The initial value for the transition.</param>
		/// <remarks>This method should not be called after the transition has been added to a storyboard.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransition-setinitialvalue HRESULT
		// SetInitialValue( [in] DOUBLE value );
		void SetInitialValue(double value);

		/// <summary>Sets the initial velocity for the transition.</summary>
		/// <param name="velocity">The initial velocity for the transition.</param>
		/// <remarks>This method should not be called after the transition has been added to a storyboard.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransition-setinitialvelocity HRESULT
		// SetInitialVelocity( [in] DOUBLE velocity );
		void SetInitialVelocity(double velocity);

		/// <summary>Determines whether a transition's duration is currently known.</summary>
		/// <returns>
		/// <para>
		/// Returns S_OK if the duration is known, S_FALSE if the duration is not known, or an <c>HRESULT</c> error code. See Windows
		/// Animation Error Codes for a list of error codes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>UI_E_STORYBOARD_ACTIVE</c></description>
		/// <description>The storyboard for this transition is currently in schedule.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>This method should not be called when the storyboard to which the transition has been added is scheduled or playing.</para>
		/// <para>Examples</para>
		/// <para>For an example, see IUIAnimationTransition::GetDuration.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransition-isdurationknown HRESULT IsDurationKnown();
		[PreserveSig]
		HRESULT IsDurationKnown();

		/// <summary>Gets the duration of the transition.</summary>
		/// <returns>The duration of the transition, in seconds.</returns>
		/// <remarks>
		/// <para>
		/// An application should typically call the IUIAnimationTransition::IsDurationKnown method before calling this method. This method
		/// should not be called when the storyboard to which the transition has been added is scheduled or playing.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following shows how to get the duration of a transition.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransition-getduration HRESULT
		// GetDuration( [out] UI_ANIMATION_SECONDS *duration );
		double GetDuration();
	}

	/// <summary>Defines a method for creating transitions from custom interpolators.</summary>
	/// <remarks>
	/// When an application requires animation effects that are not available in the transition library, developers can implement custom
	/// transitions that it can use. A custom transition is created by first implementing the interpolator function for the transition, and
	/// then by using a factory object to generate transitions from the interpolator. An interpolator must implement the
	/// IUIAnimationInterpolator interface; an implementation of the transition factory object is provided by UIAnimationTransitionFactory.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nn-uianimation-iuianimationtransitionfactory
	[PInvokeData("uianimation.h", MSDNShortId = "NN:uianimation.IUIAnimationTransitionFactory")]
	[ComImport, Guid("FCD91E03-3E3B-45AD-BBB1-6DFC8153743D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(UIAnimationTransitionFactory))]
	public interface IUIAnimationTransitionFactory
	{
		/// <summary>Creates a transition from a custom interpolator.</summary>
		/// <param name="interpolator">
		/// <para>The interpolator from which a transition is to be created.</para>
		/// <para>The specified object must implement the IUIAnimationInterpolator interface.</para>
		/// </param>
		/// <returns>The new transition.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransitionfactory-createtransition
		// HRESULT CreateTransition( [in] IUIAnimationInterpolator *interpolator, [out] IUIAnimationTransition **transition );
		IUIAnimationTransition CreateTransition(IUIAnimationInterpolator interpolator);
	}

	/// <summary>Defines a library of standard transitions.</summary>
	/// <remarks>
	/// <para>
	/// Windows Animation includes a library of common transitions that developers can apply to variables through a storyboard. The
	/// parameters for specifying a transition depend on the type of transition. For some transitions, the duration of the transition is an
	/// explicit parameter; for others, the duration is determined by other parameters, such as speed or acceleration when the transition
	/// begins. A transition's initial value or velocity can be overridden if a discontinuous jump is desired, and duration can be queried
	/// after the transition is added to a storyboard.
	/// </para>
	/// <para>
	/// If an application requires an effect that cannot be specified using the transition library, developers can implement custom
	/// transitions. A custom transition is created by first implementing the interpolator function for the transition, and then by using a
	/// factory object to generate transitions from interpolators. An interpolator must implement the IUIAnimationInterpolator interface; an
	/// implementation of the transition factory object is provided by UIAnimationTransitionFactory.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example that creates the transition library object, see Create the Main Animation Objects.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nn-uianimation-iuianimationtransitionlibrary
	[PInvokeData("uianimation.h", MSDNShortId = "NN:uianimation.IUIAnimationTransitionLibrary")]
	[ComImport, Guid("CA5A14B1-D24F-48B8-8FE4-C78169BA954E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(UIAnimationTransitionLibrary))]
	public interface IUIAnimationTransitionLibrary
	{
		/// <summary>Creates an instantaneous transition.</summary>
		/// <param name="finalValue">The value of the animation variable at the end of the transition.</param>
		/// <returns>The new instantaneous transition.</returns>
		/// <remarks>
		/// <para>
		/// During an instantaneous transition, the value of the animation variable changes instantly from its current value to a specified
		/// final value. The duration of this transition is always zero.
		/// </para>
		/// <para>The figure below shows the effect on an animation variable over time during an instantaneous transition.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransitionlibrary-createinstantaneoustransition
		// HRESULT CreateInstantaneousTransition( [in] DOUBLE finalValue, [out] IUIAnimationTransition **transition );
		IUIAnimationTransition CreateInstantaneousTransition(double finalValue);

		/// <summary>Creates a constant transition.</summary>
		/// <param name="duration">The duration of the transition.</param>
		/// <returns>The new constant transition.</returns>
		/// <remarks>
		/// <para>
		/// During a constant transition, the value of an animation variable remains at the initial value over the duration of the transition.
		/// </para>
		/// <para>The figure below shows the effect on an animation variable over time during a constant-duration transition.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransitionlibrary-createconstanttransition
		// HRESULT CreateConstantTransition( [in] UI_ANIMATION_SECONDS duration, [out] IUIAnimationTransition **transition );
		IUIAnimationTransition CreateConstantTransition(double duration);

		/// <summary>Creates a discrete transition.</summary>
		/// <param name="delay">The amount of time by which to delay the instantaneous switch to the final value.</param>
		/// <param name="finalValue">The value of the animation variable at the end of the transition.</param>
		/// <param name="hold">The amount of time by which to hold the variable at its final value.</param>
		/// <returns>The new discrete transition.</returns>
		/// <remarks>
		/// <para>
		/// During a discrete transition, the animation variable remains at the initial value for a specified delay time, then switches
		/// instantaneously to a specified final value and remains at that value for a given hold time.
		/// </para>
		/// <para>The figure below shows the effect on an animation variable over time during a discrete transition.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransitionlibrary-creatediscretetransition
		// HRESULT CreateDiscreteTransition( [in] UI_ANIMATION_SECONDS delay, [in] DOUBLE finalValue, [in] UI_ANIMATION_SECONDS hold, [out]
		// IUIAnimationTransition **transition );
		IUIAnimationTransition CreateDiscreteTransition(double delay, double finalValue, double hold);

		/// <summary>Creates a linear transition.</summary>
		/// <param name="duration">The duration of the transition.</param>
		/// <param name="finalValue">The value of the animation variable at the end of the transition.</param>
		/// <returns>The new linear transition.</returns>
		/// <remarks>
		/// <para>
		/// During a linear transition, the value of the animation variable transitions linearly from its initial value to a specified final value.
		/// </para>
		/// <para>The figure below shows the effect on an animation variable over time during a linear transition.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransitionlibrary-createlineartransition
		// HRESULT CreateLinearTransition( [in] UI_ANIMATION_SECONDS duration, [in] DOUBLE finalValue, [out] IUIAnimationTransition
		// **transition );
		IUIAnimationTransition CreateLinearTransition(double duration, double finalValue);

		/// <summary>Creates a linear-speed transition.</summary>
		/// <param name="speed">The absolute value of the velocity.</param>
		/// <param name="finalValue">The value of the animation variable at the end of the transition.</param>
		/// <returns>The new linear-speed transition.</returns>
		/// <remarks>
		/// <para>
		/// During a linear-speed transition, the value of the animation variable changes at a specified rate. The duration of the
		/// transition is determined by the difference between the initial value and the specified final value.
		/// </para>
		/// <para>The figure below shows the effect on an animation variable over time during a linear-speed transition.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransitionlibrary-createlineartransitionfromspeed
		// HRESULT CreateLinearTransitionFromSpeed( [in] DOUBLE speed, [in] DOUBLE finalValue, [out] IUIAnimationTransition **transition );
		IUIAnimationTransition CreateLinearTransitionFromSpeed(double speed, double finalValue);

		/// <summary>Creates a sinusoidal-velocity transition, with an amplitude determined by the initial velocity.</summary>
		/// <param name="duration">The duration of the transition.</param>
		/// <param name="period">The period of oscillation of the sinusoidal wave in seconds.</param>
		/// <returns>The new sinusoidal-velocity transition.</returns>
		/// <remarks>
		/// <para>
		/// The value of the animation variable oscillates around the initial value over the entire duration of a sinusoidal-range
		/// transition. The amplitude of the oscillation is determined by the velocity when the transition begins.
		/// </para>
		/// <para>The figure below shows the effect on an animation variable over time during a sinusoidal-velocity transition.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransitionlibrary-createsinusoidaltransitionfromvelocity
		// HRESULT CreateSinusoidalTransitionFromVelocity( [in] UI_ANIMATION_SECONDS duration, [in] UI_ANIMATION_SECONDS period, [out]
		// IUIAnimationTransition **transition );
		IUIAnimationTransition CreateSinusoidalTransitionFromVelocity(double duration, double period);

		/// <summary>Creates a sinusoidal-range transition, with a specified range of oscillation.</summary>
		/// <param name="duration">The duration of the transition.</param>
		/// <param name="minimumValue">The value of the animation variable at a trough of the sinusoidal wave.</param>
		/// <param name="maximumValue">The value of the animation variable at a peak of the sinusoidal wave.</param>
		/// <param name="period">The period of oscillation of the sinusoidal wave, in seconds.</param>
		/// <param name="slope">The slope at the start of the transition.</param>
		/// <returns>The new sinusoidal-range transition.</returns>
		/// <remarks>
		/// <para>
		/// The value of the animation variable fluctuates between the specified minimum and maximum values over the entire duration of a
		/// sinusodial-range transition. The <c>slope</c> parameter is used to disambiguate between the two possible sine waves specified by
		/// the other parameters.
		/// </para>
		/// <para>
		/// The figure below shows the effect on an animation variable over time during a sinusoidal-range transition. Passing in the
		/// <c>UI_ANIMATION_SLOPE_INCREASING</c> enumeration value yields a wave like the solid curve shown in the figure, whereas the
		/// <c>UI_ANIMATION_SLOPE_DECREASING</c> value yields a wave like the dashed curve.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransitionlibrary-createsinusoidaltransitionfromrange
		// HRESULT CreateSinusoidalTransitionFromRange( [in] UI_ANIMATION_SECONDS duration, [in] DOUBLE minimumValue, [in] DOUBLE
		// maximumValue, [in] UI_ANIMATION_SECONDS period, [in] UI_ANIMATION_SLOPE slope, [out] IUIAnimationTransition **transition );
		IUIAnimationTransition CreateSinusoidalTransitionFromRange(double duration, double minimumValue, double maximumValue, double period, UI_ANIMATION_SLOPE slope);

		/// <summary>Creates an accelerate-decelerate transition.</summary>
		/// <param name="duration">The duration of the transition.</param>
		/// <param name="finalValue">The value of the animation variable at the end of the transition.</param>
		/// <param name="accelerationRatio">The ratio of the time spent accelerating to the duration.</param>
		/// <param name="decelerationRatio">The ratio of the time spent decelerating to the duration.</param>
		/// <returns>The new accelerate-decelerate transition.</returns>
		/// <remarks>
		/// <para>
		/// During an accelerate-decelerate transition, the animation variable speeds up and then slows down over the duration of the
		/// transition, ending at a specified value. You can control how quickly the variable accelerates and decelerates independently, by
		/// specifying different acceleration and deceleration ratios.
		/// </para>
		/// <para>
		/// When the initial velocity is zero, the acceleration ratio is the fraction of the duration that the variable will spend
		/// accelerating; likewise with the deceleration ratio. If the initial velocity is nonzero, it is the fraction of the time between
		/// the velocity reaching zero and the end of transition. The acceleration ratio and the deceleration ratio should sum to a maximum
		/// of 1.0.
		/// </para>
		/// <para>
		/// The figures below show the effect on animation variables with different initial velocities during accelerate-decelerate transitions.
		/// </para>
		/// <para>
		/// <c>Note</c>  d' in the above figure on the right shows the time between the velocity reaching zero and the end of the transition.
		/// </para>
		/// <para></para>
		/// <para>Examples</para>
		/// <para>For an example, see Create a Storyboard and Add Transitions.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransitionlibrary-createacceleratedeceleratetransition
		// HRESULT CreateAccelerateDecelerateTransition( [in] UI_ANIMATION_SECONDS duration, [in] DOUBLE finalValue, [in] DOUBLE
		// accelerationRatio, [in] DOUBLE decelerationRatio, [out] IUIAnimationTransition **transition );
		IUIAnimationTransition CreateAccelerateDecelerateTransition(double duration, double finalValue, double accelerationRatio, double decelerationRatio);

		/// <summary>Creates a reversal transition.</summary>
		/// <param name="duration">The duration of the transition.</param>
		/// <returns>The new reversal transition.</returns>
		/// <remarks>
		/// A reversal transition smoothly changes direction over the specified duration. The final value will be the same as the initial
		/// value and the final velocity will be the negative of the initial velocity. The figure below shows such a reversal transition.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransitionlibrary-createreversaltransition
		// HRESULT CreateReversalTransition( [in] UI_ANIMATION_SECONDS duration, [out] IUIAnimationTransition **transition );
		IUIAnimationTransition CreateReversalTransition(double duration);

		/// <summary>Creates a cubic transition.</summary>
		/// <param name="duration">The duration of the transition.</param>
		/// <param name="finalValue">The value of the animation variable at the end of the transition.</param>
		/// <param name="finalVelocity">The velocity of the variable at the end of the transition.</param>
		/// <returns>The new cubic transition.</returns>
		/// <remarks>
		/// <para>
		/// During a cubic transition, the value of the animation variable changes from its initial value to a specified final value over
		/// the duration of the transition, ending at a specified velocity.
		/// </para>
		/// <para>The figure below shows the effect on an animation variable over time during a cubic transition.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransitionlibrary-createcubictransition
		// HRESULT CreateCubicTransition( [in] UI_ANIMATION_SECONDS duration, [in] DOUBLE finalValue, [in] DOUBLE finalVelocity, [out]
		// IUIAnimationTransition **transition );
		IUIAnimationTransition CreateCubicTransition(double duration, double finalValue, double finalVelocity);

		/// <summary>Creates a smooth-stop transition.</summary>
		/// <param name="maximumDuration">The maximum duration of the transition.</param>
		/// <param name="finalValue">The value of the animation variable at the end of the transition.</param>
		/// <returns>The new smooth-stop transition.</returns>
		/// <remarks>
		/// <para>
		/// A smooth-stop transition slows down as it approaches the specified final value, and reaches it with a velocity of zero. The
		/// duration of the transition is determined by the initial velocity, the difference between the initial and final values, and the
		/// specified maximum duration. If there is no solution consisting of a single parabolic arc, this method creates a cubic transition.
		/// </para>
		/// <para>The figure below shows the effect on an animation variable over time during a smooth-stop transition.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransitionlibrary-createsmoothstoptransition
		// HRESULT CreateSmoothStopTransition( [in] UI_ANIMATION_SECONDS maximumDuration, [in] DOUBLE finalValue, [out]
		// IUIAnimationTransition **transition );
		IUIAnimationTransition CreateSmoothStopTransition(double maximumDuration, double finalValue);

		/// <summary>Creates a parabolic-acceleration transition.</summary>
		/// <param name="finalValue">The value of the animation variable at the end of the transition.</param>
		/// <param name="finalVelocity">The velocity at the end of the transition.</param>
		/// <param name="acceleration">The acceleration during the transition.</param>
		/// <returns>The new parabolic-acceleration transition.</returns>
		/// <remarks>
		/// <para>
		/// During a parabolic-acceleration transition, the value of the animation variable changes from the initial value to the final
		/// value ending at the specified velocity. You can control how quickly the variable reaches the final value by specifying the rate
		/// of acceleration.
		/// </para>
		/// <para>The figure below shows the effect on an animation variable over time during a parabolic-acceleration transition.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransitionlibrary-createparabolictransitionfromacceleration
		// HRESULT CreateParabolicTransitionFromAcceleration( [in] DOUBLE finalValue, [in] DOUBLE finalVelocity, [in] DOUBLE acceleration,
		// [out] IUIAnimationTransition **transition );
		IUIAnimationTransition CreateParabolicTransitionFromAcceleration(double finalValue, double finalVelocity, double acceleration);
	}

	/// <summary>Defines an animation variable, which represents a visual element that can be animated.</summary>
	/// <remarks>
	/// Along with IUIAnimationTransition and IUIAnimationStoryboard, <c>IUIAnimationVariable</c> is a primary component for building
	/// animations. To create and manage animation variables, use IUIAnimationManager.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nn-uianimation-iuianimationvariable
	[PInvokeData("uianimation.h", MSDNShortId = "NN:uianimation.IUIAnimationVariable")]
	[ComImport, Guid("8CEEB155-2849-4CE5-9448-91FF70E1E4D9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IUIAnimationVariable
	{
		/// <summary>Gets the current value of the animation variable.</summary>
		/// <returns>The current value of the animation variable.</returns>
		/// <remarks>
		/// <para>
		/// The results can be affected by the lower and upper bounds determined by IUIAnimationVariable::SetLowerBound and
		/// IUIAnimationVariable::SetUpperBound, respectively.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Read the Animation Variable Values.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable-getvalue HRESULT GetValue(
		// [out] DOUBLE *value );
		double GetValue();

		/// <summary>
		/// Gets the final value of the animation variable. This is the value after all currently scheduled animations have completed.
		/// </summary>
		/// <param name="finalValue">The final value of the animation variable.</param>
		/// <returns>
		/// <para>
		/// If the method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>UI_E_VALUE_NOT_DETERMINED</c></description>
		/// <description>The final value of the animation variable cannot be determined at this time.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The result can be affected by the lower and upper bounds determined by IUIAnimationVariable::SetLowerBound and
		/// IUIAnimationVariable::SetUpperBound, respectively.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable-getfinalvalue HRESULT
		// GetFinalValue( [out] DOUBLE *finalValue );
		[PreserveSig]
		HRESULT GetFinalValue(out double finalValue);

		/// <summary>
		/// Gets the previous value of the animation variable. This is the value of the animation variable before the most recent update.
		/// </summary>
		/// <returns>The previous value of the animation variable.</returns>
		/// <remarks>
		/// The results can be affected by the lower and upper bounds determined by IUIAnimationVariable::SetLowerBound and
		/// IUIAnimationVariable::SetUpperBound, respectively.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable-getpreviousvalue HRESULT
		// GetPreviousValue( [out] DOUBLE *previousValue );
		double GetPreviousValue();

		/// <summary>Gets the current value of the animation variable as an integer.</summary>
		/// <returns>The current value of the animation variable, converted to an <c>INT32</c> value.</returns>
		/// <remarks>
		/// <para>To specify the rounding mode to be used when converting the value, use the IUIAnimationVariable::SetRoundingMode method.</para>
		/// <para>
		/// The result can also be affected by the lower and upper bounds determined by IUIAnimationVariable::SetLowerBound and
		/// IUIAnimationVariable::SetUpperBound, respectively.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Read the Animation Variable Values.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable-getintegervalue HRESULT
		// GetIntegerValue( [out] INT32 *value );
		int GetIntegerValue();

		/// <summary>
		/// Gets the final value of the animation variable as an integer. This is the value after all currently scheduled animations have completed.
		/// </summary>
		/// <param name="finalValue">The final value of the animation variable, converted to an <c>INT32</c> value.</param>
		/// <returns>
		/// <para>
		/// If the method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>UI_E_VALUE_NOT_DETERMINED</c></description>
		/// <description>The final value of the animation variable cannot be determined at this time.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>To specify the rounding mode to be used when converting the value, use the IUIAnimationVariable::SetRoundingMode method.</para>
		/// <para>
		/// The result can also be affected by the lower and upper bounds determined by IUIAnimationVariable::SetLowerBound and
		/// IUIAnimationVariable::SetUpperBound, respectively.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable-getfinalintegervalue HRESULT
		// GetFinalIntegerValue( [out] INT32 *finalValue );
		[PreserveSig]
		HRESULT GetFinalIntegerValue(out int finalValue);

		/// <summary>
		/// Gets the previous value of the animation variable as an integer. This is the value of the animation variable before the most
		/// recent update.
		/// </summary>
		/// <returns>The previous value of the animation variable, converted to an <c>INT32</c> value.</returns>
		/// <remarks>
		/// <para>To specify the rounding mode to be used when converting the value, use the IUIAnimationVariable::SetRoundingMode method.</para>
		/// <para>
		/// The result can also be affected by the lower and upper bounds determined by IUIAnimationVariable::SetLowerBound and
		/// IUIAnimationVariable::SetUpperBound, respectively.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable-getpreviousintegervalue
		// HRESULT GetPreviousIntegerValue( [out] INT32 *previousValue );
		int GetPreviousIntegerValue();

		/// <summary>Gets the storyboard that is currently animating the animation variable.</summary>
		/// <returns>The current storyboard, or <c>NULL</c> if no storyboard is currently animating the animation variable.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable-getcurrentstoryboard HRESULT
		// GetCurrentStoryboard( [out] IUIAnimationStoryboard **storyboard );
		IUIAnimationStoryboard? GetCurrentStoryboard();

		/// <summary>
		/// Sets the lower bound (floor) for the animation variable. The value of the animation variable should not fall below the specified value.
		/// </summary>
		/// <param name="bound">The lower bound for the animation variable.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable-setlowerbound HRESULT
		// SetLowerBound( [in] DOUBLE bound );
		void SetLowerBound(double bound);

		/// <summary>
		/// Sets an upper bound (ceiling) for the animation variable. The value of the animation variable should not rise above the
		/// specified value.
		/// </summary>
		/// <param name="bound">The upper bound for the animation variable.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable-setupperbound HRESULT
		// SetUpperBound( [in] DOUBLE bound );
		void SetUpperBound(double bound);

		/// <summary>Specifies the rounding mode for the animation variable.</summary>
		/// <param name="mode">The rounding mode for the animation variable.</param>
		/// <remarks>
		/// <para>
		/// An animation variable's rounding mode determines how a floating-point value is converted to an integer. The default mode for
		/// each variable is <c>UI_ANIMATION_ROUNDING_NEAREST</c>.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Create Animation Variables.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable-setroundingmode HRESULT
		// SetRoundingMode( [in] UI_ANIMATION_ROUNDING_MODE mode );
		void SetRoundingMode(UI_ANIMATION_ROUNDING_MODE mode);

		/// <summary>Sets the tag for an animation variable.</summary>
		/// <param name="object">The object portion of the tag. This parameter can be <c>NULL</c>.</param>
		/// <param name="id">The identifier portion of the tag.</param>
		/// <remarks>
		/// A tag is a pairing of an integer identifier ( <c>id</c>) with a COM object ( <c>object</c>); it can be used by an application to
		/// identify an animation variable. Because <c>NULL</c> is a valid object component of a tag, the <c>object</c> parameter can be <c>NULL</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable-settag HRESULT SetTag( [in,
		// optional] IUnknown *object, [in] UINT32 id );
		void SetTag([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? @object, uint id);

		/// <summary>Gets the tag for an animation variable.</summary>
		/// <param name="obj">The object portion of the tag.</param>
		/// <param name="id">The identifier portion of the tag.</param>
		/// <returns>
		/// <para>
		/// If the method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>UI_E_VALUE_NOT_SET</c></description>
		/// <description>The animation variable's tag was not set.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A tag is a pairing of an integer identifier ( <c>id</c>) with a COM object ( <c>object</c>); it can be used by an application to
		/// identify an animation variable.
		/// </para>
		/// <para>The parameters are optional so that the method can return both portions of the tag, or just the identifier or object portion.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable-gettag HRESULT GetTag( [out,
		// optional] IUnknown **object, [out, optional] UINT32 *id );
		[PreserveSig]
		unsafe HRESULT GetTag([Out, Optional] IntPtr* obj, [Out, Optional] uint* id);

		/// <summary>Specifies a variable change handler. This handler is notified of changes to the value of the animation variable.</summary>
		/// <param name="handler">
		/// <para>A variable change handler.</para>
		/// <para>The specified object must implement the IUIAnimationVariableChangeHandler interface or be <c>NULL</c>.</para>
		/// <para>See Remarks.</para>
		/// </param>
		/// <remarks>
		/// Passing <c>NULL</c> for the <c>handler</c> parameter causes Windows Animation to release its reference to any handler object you
		/// passed in earlier. This technique can be essential for breaking reference cycles without having to call the
		/// IUIAnimationManager::Shutdown method.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable-setvariablechangehandler
		// HRESULT SetVariableChangeHandler( [in, optional] IUIAnimationVariableChangeHandler *handler );
		void SetVariableChangeHandler(IUIAnimationVariableChangeHandler? handler);

		/// <summary>
		/// Specifies an integer variable change handler. This handler is notified of changes to the integer value of the animation variable.
		/// </summary>
		/// <param name="handler">
		/// <para>An integer variable change handler.</para>
		/// <para>The specified object must implement the IUIAnimationVariableIntegerChangeHandler interface or be NULL.</para>
		/// <para>See Remarks.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Passing NULL for the <c>handler</c> parameter causes Windows Animation to release its reference to any handler object you passed
		/// in earlier. This technique can be essential for breaking reference cycles without having to call the
		/// IUIAnimationManager::Shutdown method.
		/// </para>
		/// <para>
		/// IUIAnimationVariableIntegerChangeHandler::OnIntegerValueChanged is called only if the rounded value has changed since the last update.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable-setvariableintegerchangehandler
		// HRESULT SetVariableIntegerChangeHandler( [in, optional] IUIAnimationVariableIntegerChangeHandler *handler );
		void SetVariableIntegerChangeHandler(IUIAnimationVariableIntegerChangeHandler? handler);
	}

	/// <summary>Defines a method for handling events related to animation variable updates.</summary>
	/// <remarks>
	/// <para>OnValueChanged receives animation variable value updates as <c>DOUBLE</c> values.</para>
	/// <para>To receive value updates as <c>INT32</c> values, use IUIAnimationVariableIntegerChangeHandler::OnIntegerValueChanged.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nn-uianimation-iuianimationvariablechangehandler
	[PInvokeData("uianimation.h", MSDNShortId = "NN:uianimation.IUIAnimationVariableChangeHandler")]
	[ComImport, Guid("6358B7BA-87D2-42D5-BF71-82E919DD5862"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IUIAnimationVariableChangeHandler
	{
		/// <summary>
		/// <para>Handles events that occur when the value of an animation variable changes.</para>
		/// <para>
		/// This method receives updates as <c>DOUBLE</c> values. To receive updates as <c>INT32</c> values, use the
		/// IUIAnimationVariableIntegerChangeHandler::OnIntegerValueChanged method.
		/// </para>
		/// </summary>
		/// <param name="storyboard">The storyboard that is animating the animation variable specified by the <c>variable</c> parameter.</param>
		/// <param name="variable">The animation variable that has been updated.</param>
		/// <param name="newValue">The new value of the animation variable.</param>
		/// <param name="previousValue">The previous value of the animation variable.</param>
		/// <returns>
		/// If the method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </returns>
		/// <remarks>
		/// <para>
		/// By default, a call made in a callback method to any other animation method results in the call failing and returning
		/// <c>UI_E_ILLEGAL_REENTRANCY</c>. However, there are exceptions to this default. The following methods can be successfully called
		/// from <c>OnValueChanged</c>:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>IUIAnimationVariable::GetValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable::GetFinalValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable::GetPreviousValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable::GetIntegerValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable::GetFinalIntegerValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable::GetPreviousIntegerValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable::GetCurrentStoryboard</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationManager::GetVariableFromTag</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationManager::GetStoryboardFromTag</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationStoryboard::GetTag</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable::GetTag</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariablechangehandler-onvaluechanged
		// HRESULT OnValueChanged( [in] IUIAnimationStoryboard *storyboard, [in] IUIAnimationVariable *variable, [in] DOUBLE newValue, [in]
		// DOUBLE previousValue );
		[PreserveSig]
		HRESULT OnValueChanged(IUIAnimationStoryboard storyboard, IUIAnimationVariable variable, double newValue, double previousValue);
	}

	/// <summary>Defines a method for handling animation variable update events.</summary>
	/// <remarks>
	/// <para>OnIntegerValueChanged receives animation variable value updates as <c>INT32</c> values.</para>
	/// <para>To receive value updates as <c>DOUBLE</c> values, use the IUIAnimationVariableChangeHandler::OnValueChanged method.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nn-uianimation-iuianimationvariableintegerchangehandler
	[PInvokeData("uianimation.h", MSDNShortId = "NN:uianimation.IUIAnimationVariableIntegerChangeHandler")]
	[ComImport, Guid("BB3E1550-356E-44B0-99DA-85AC6017865E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IUIAnimationVariableIntegerChangeHandler
	{
		/// <summary>
		/// <para>Handles events that occur when the value of an animation variable changes.</para>
		/// <para>
		/// This method receives updates as <c>INT32</c> values. To receive updates as <c>DOUBLE</c> values, use the
		/// IUIAnimationVariableChangeHandler::OnValueChanged method.
		/// </para>
		/// </summary>
		/// <param name="storyboard">The storyboard that is animating the animation variable specified by the <c>variable</c> parameter.</param>
		/// <param name="variable">The animation variable that has been updated.</param>
		/// <param name="newValue">The new value of the animation variable, rounded according to the variable's rounding mode.</param>
		/// <param name="previousValue">The previous value of the animation variable, rounded according to the variable's rounding mode.</param>
		/// <returns>
		/// If the method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </returns>
		/// <remarks>
		/// <para>The rounding mode for an animation variable is specified using the IUIAnimationVariable::SetRoundingMode method.</para>
		/// <para>
		/// <c>OnIntegerValueChanged</c> events might occur less frequently than OnValueChanged events because values such as 2.2, 2.3, 2.4
		/// would all be rounded to the same integer.
		/// </para>
		/// <para>
		/// By default, a call made in a callback method to any other animation method results in the call failing and returning
		/// <c>UI_E_ILLEGAL_REENTRANCY</c>. However, there are exceptions to this default. The following methods can be successfully called
		/// from <c>OnIntegerValueChanged</c>:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>IUIAnimationVariable::GetCurrentStoryboard</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable::GetFinalIntegerValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable::GetFinalValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable::GetIntegerValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable::GetPreviousIntegerValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable::GetPreviousValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable::GetValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationManager::GetStoryboardFromTag</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationManager::GetVariableFromTag</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationStoryboard::GetTag</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable::GetTag</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariableintegerchangehandler-onintegervaluechanged
		// HRESULT OnIntegerValueChanged( [in] IUIAnimationStoryboard *storyboard, [in] IUIAnimationVariable *variable, [in] INT32 newValue,
		// [in] INT32 previousValue );
		[PreserveSig]
		HRESULT OnIntegerValueChanged(IUIAnimationStoryboard storyboard, IUIAnimationVariable variable, int newValue, int previousValue);
	}

	/// <summary>Gets the tag for a storyboard.</summary>
	/// <param name="this">The <see cref="IUIAnimationStoryboard"/> instance.</param>
	/// <param name="obj">The object portion of the tag.</param>
	/// <param name="id">The identifier portion of the tag.</param>
	/// <remarks>
	/// <para>
	/// A tag is a pairing of an integer identifier ( <c>id</c>) with a COM object ( <c>object</c>); it can be used by an application to
	/// identify a storyboard.
	/// </para>
	/// <para>The parameters are optional so that the method can return both portions of the tag, or just the identifier or object portion.</para>
	/// </remarks>
	public static void GetTag(this IUIAnimationStoryboard @this, out object? obj, out uint? id)
	{ unsafe { GetTag(@this.GetTag, out obj, out id); } }

	/// <summary>Gets the tag for a storyboard.</summary>
	/// <param name="this">The <see cref="IUIAnimationStoryboard"/> instance.</param>
	/// <param name="obj">The object portion of the tag.</param>
	/// <remarks>
	/// <para>
	/// A tag is a pairing of an integer identifier ( <c>id</c>) with a COM object ( <c>object</c>); it can be used by an application to
	/// identify a storyboard.
	/// </para>
	/// <para>The parameters are optional so that the method can return both portions of the tag, or just the identifier or object portion.</para>
	/// </remarks>
	public static void GetTag(this IUIAnimationStoryboard @this, out object? obj)
	{ unsafe { GetTag(@this.GetTag, out obj); } }

	/// <summary>Gets the tag for a storyboard.</summary>
	/// <param name="this">The <see cref="IUIAnimationStoryboard"/> instance.</param>
	/// <param name="id">The identifier portion of the tag.</param>
	/// <remarks>
	/// <para>
	/// A tag is a pairing of an integer identifier ( <c>id</c>) with a COM object ( <c>object</c>); it can be used by an application to
	/// identify a storyboard.
	/// </para>
	/// <para>The parameters are optional so that the method can return both portions of the tag, or just the identifier or object portion.</para>
	/// </remarks>
	public static void GetTag(this IUIAnimationStoryboard @this, out uint? id)
	{ unsafe { GetTag(@this.GetTag, out id); } }

	/// <summary>Gets the tag for an animation variable.</summary>
	/// <param name="this">The <see cref="IUIAnimationVariable"/> instance.</param>
	/// <param name="obj">The object portion of the tag.</param>
	/// <param name="id">The identifier portion of the tag.</param>
	/// <remarks>
	/// <para>
	/// A tag is a pairing of an integer identifier ( <c>id</c>) with a COM object ( <c>object</c>); it can be used by an application to
	/// identify an animation variable.
	/// </para>
	/// <para>The parameters are optional so that the method can return both portions of the tag, or just the identifier or object portion.</para>
	/// </remarks>
	public static void GetTag(this IUIAnimationVariable @this, out object? obj, out uint? id)
	{ unsafe { GetTag(@this.GetTag, out obj, out id); } }

	/// <summary>Gets the tag for an animation variable.</summary>
	/// <param name="this">The <see cref="IUIAnimationVariable"/> instance.</param>
	/// <param name="obj">The object portion of the tag.</param>
	/// <remarks>
	/// <para>
	/// A tag is a pairing of an integer identifier ( <c>id</c>) with a COM object ( <c>object</c>); it can be used by an application to
	/// identify an animation variable.
	/// </para>
	/// <para>The parameters are optional so that the method can return both portions of the tag, or just the identifier or object portion.</para>
	/// </remarks>
	public static void GetTag(this IUIAnimationVariable @this, out object? obj)
	{ unsafe { GetTag(@this.GetTag, out obj); } }

	/// <summary>Gets the tag for an animation variable.</summary>
	/// <param name="this">The <see cref="IUIAnimationVariable"/> instance.</param>
	/// <param name="id">The identifier portion of the tag.</param>
	/// <remarks>
	/// <para>
	/// A tag is a pairing of an integer identifier ( <c>id</c>) with a COM object ( <c>object</c>); it can be used by an application to
	/// identify an animation variable.
	/// </para>
	/// <para>The parameters are optional so that the method can return both portions of the tag, or just the identifier or object portion.</para>
	/// </remarks>
	public static void GetTag(this IUIAnimationVariable @this, out uint? id)
	{ unsafe { GetTag(@this.GetTag, out id); } }

	internal static void GetTag(GetTagDelegate gt, out object? obj, out uint? id)
	{
		unsafe
		{
			IntPtr pObj = IntPtr.Zero;
			uint _id = 0;
			HRESULT hr = gt(&pObj, &_id);
			obj = hr == HRESULT.UI_E_VALUE_NOT_SET || pObj == IntPtr.Zero ? null : Marshal.GetObjectForIUnknown(pObj);
			id = hr == HRESULT.UI_E_VALUE_NOT_SET ? null : _id;
		}
	}

	internal static void GetTag(GetTagDelegate gt, out object? obj)
	{
		unsafe
		{
			IntPtr pObj = IntPtr.Zero;
			HRESULT hr = gt(&pObj, null);
			obj = hr == HRESULT.UI_E_VALUE_NOT_SET || pObj == IntPtr.Zero ? null : Marshal.GetObjectForIUnknown(pObj);
		}
	}

	internal static void GetTag(GetTagDelegate gt, out uint? id)
	{
		unsafe
		{
			uint _id = 0;
			HRESULT hr = gt(null, &_id);
			id = hr == HRESULT.UI_E_VALUE_NOT_SET ? null : _id;
		}
	}

	/// <summary>CLSID_UIAnimationManager</summary>
	[ComImport, Guid("4C1FC63A-695C-47E8-A339-1A194BE3D0B8"), ClassInterface(ClassInterfaceType.None)]
	public class UIAnimationManager { }

	/// <summary>CLSID_UIAnimationTimer</summary>
	[ComImport, Guid("BFCD4A0C-06B6-4384-B768-0DAA792C380E"), ClassInterface(ClassInterfaceType.None)]
	public class UIAnimationTimer { }

	/// <summary>CLSID_UIAnimationTransitionFactory</summary>
	[ComImport, Guid("8A9B1CDD-FCD7-419C-8B44-42FD17DB1887"), ClassInterface(ClassInterfaceType.None)]
	public class UIAnimationTransitionFactory { }

	/// <summary>CLSID_UIAnimationTransitionLibrary</summary>
	[ComImport, Guid("1D6322AD-AA85-4EF5-A828-86D71067D145"), ClassInterface(ClassInterfaceType.None)]
	public class UIAnimationTransitionLibrary { }
}