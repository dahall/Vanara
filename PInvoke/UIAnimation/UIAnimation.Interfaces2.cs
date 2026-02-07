using System.Runtime.Versioning;
using static Vanara.PInvoke.Dcomp;

namespace Vanara.PInvoke;

public static partial class UIAnimation
{
	/// <summary>
	/// Extends the IUIAnimationInterpolator interface that defines methods for creating a custom interpolator.
	/// <c>IUIAnimationInterpolator2</c> supports interpolation in a given dimension.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Client applications can use the transitions provided in the IUIAnimationTransitionLibrary orIUIAnimationTransitionLibrary2
	/// interfaces, or in a library provided by a third party; however, custom transitions can be created by implementing the
	/// IUIAnimationInterpolator or <c>IUIAnimationInterpolator2</c> interfaces.
	/// </para>
	/// <para>
	/// Before Windows Animation can use your custom interpolator, you must wrap it in an object that implements the IUIAnimationTransition
	/// interface (by calling IUIAnimationTransitionFactory::CreateTransition) or the IUIAnimationTransition2 interface (by calling
	/// IUIAnimationTransitionFactory2::CreateTransition) and passing in the custom interpolator. After the interpolator wrapper has been
	/// created, client applications interact with your interpolator using the <c>IUIAnimationTransition</c> or
	/// <c>IUIAnimationTransition2</c> interfaces.
	/// </para>
	/// <para>
	/// Custom interpolators can be reused across applications, but it is recommended that they be exposed using factory interfaces that
	/// return an IUIAnimationTransition interface or an IUIAnimationTransition2 interface.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nn-uianimation-iuianimationinterpolator2
	[PInvokeData("uianimation.h", MSDNShortId = "NN:uianimation.IUIAnimationInterpolator2")]
	[ComImport, Guid("EA76AFF8-EA22-4A23-A0EF-A6A966703518"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !NET5_0
	[SupportedOSPlatform("windows8.0")]
#endif
	public interface IUIAnimationInterpolator2
	{
		/// <summary>Gets the number of dimensions that require interpolation.</summary>
		/// <param name="dimension">The number of dimensions.</param>
		/// <returns>
		/// If this method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationinterpolator2-getdimension HRESULT
		// GetDimension( [out] UINT *dimension );
		[PreserveSig]
		HRESULT GetDimension(out uint dimension);

		/// <summary>Sets the initial value and velocity of the transition for the given dimension.</summary>
		/// <param name="initialValue">The initial value.</param>
		/// <param name="initialVelocity">The initial velocity.</param>
		/// <param name="cDimension">The dimension in which to set the initial value or velocity of the transition.</param>
		/// <returns>
		/// Returns <c>S_OK</c> if successful; otherwise an <c>HRESULT</c> error code. See Windows Animation Error Codes for a list of error codes.
		/// </returns>
		/// <remarks>
		/// Windows Animation always calls <c>SetInitialValueAndVelocity</c> before calling the other methods of IUIAnimationInterpolator2
		/// at different offsets. However, <c>SetInitialValueAndVelocity</c> can be called multiple times with different parameters.
		/// Interpolators can cache internal state to improve performance, but they must update this cached state each time
		/// <c>SetInitialValueAndVelocity</c> is called and ensure that the results of subsequent calls to these methods reflect the updated state.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationinterpolator2-setinitialvalueandvelocity
		// HRESULT SetInitialValueAndVelocity( [in] DOUBLE *initialValue, [in] DOUBLE *initialVelocity, [in] UINT cDimension );
		[PreserveSig]
		HRESULT SetInitialValueAndVelocity([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] double[] initialValue, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] double[] initialVelocity, uint cDimension);

		/// <summary>Sets the duration of the transition in the given dimension.</summary>
		/// <param name="duration">The duration of the transition.</param>
		/// <returns>
		/// Returns <c>S_OK</c> if successful; otherwise an <c>HRESULT</c> error code. See Windows Animation Error Codes for a list of error codes.
		/// </returns>
		/// <remarks>
		/// <para>
		/// Windows Animation calls this method only after calling the IUIAnimationInterpolator2::GetDependencies method, and only if that
		/// call returns <c>UI_ANIMATION_DEPENDENCY_DURATION</c> as one of its <c>durationDependencies</c> flags.
		/// </para>
		/// <para>
		/// Typically, an interpolator with a duration dependency has a duration parameter in the IUIAnimationTransitionFactory or
		/// IUIAnimationTransitionFactory2 creation method that is associated with that interpolator. The interpolator should store its
		/// duration when first initialized and overwrite the duration when <c>SetDuration</c> is called.
		/// </para>
		/// <para>
		/// Windows Animation always calls the IUIAnimationInterpolator2::SetInitialValueAndVelocity method to set the initial value and
		/// velocity before calling <c>SetDuration</c>, so a custom interpolator doesn't need to check whether the initial value and
		/// velocity have been set.
		/// </para>
		/// <para>
		/// Windows Animation can call SetInitialValueAndVelocity and <c>SetDuration</c> multiple times with different parameters.
		/// Interpolators can cache internal state to improve performance, but they must update this cached state each time
		/// <c>SetInitialValueAndVelocity</c> is called and ensure that the results of subsequent calls to <c>SetDuration</c> reflect the
		/// updated state.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationinterpolator2-setduration HRESULT
		// SetDuration( [in, out] UI_ANIMATION_SECONDS duration );
		[PreserveSig]
		HRESULT SetDuration(double duration);

		/// <summary>Gets the duration of a transition for the given dimension.</summary>
		/// <param name="duration">The duration of the transition.</param>
		/// <returns>
		/// If this method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </returns>
		/// <remarks>
		/// <para>
		/// Windows Animation always calls the IUIAnimationInterpolator2::SetInitialValueAndVelocity method to set the initial value and
		/// velocity before calling <c>GetDuration</c>, so a custom interpolator need not check whether the initial value and velocity have
		/// been set.
		/// </para>
		/// <para>
		/// Windows Animation can call SetInitialValueAndVelocity multiple times with different parameters. Interpolators can cache internal
		/// state to improve performance, but they must update this cached state each time <c>SetInitialValueAndVelocity</c> is called and
		/// ensure that the results of subsequent calls to <c>GetDuration</c> reflect the updated state.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationinterpolator2-getduration HRESULT
		// GetDuration( [out] UI_ANIMATION_SECONDS *duration );
		[PreserveSig]
		HRESULT GetDuration(out double duration);

		/// <summary>Gets the final value at the end of the transition for the given dimension.</summary>
		/// <param name="value">The final value.</param>
		/// <param name="cDimension">The dimension from which to retrieve the final value.</param>
		/// <returns>
		/// If this method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </returns>
		/// <remarks>
		/// <para>
		/// Windows Animation always calls the IUIAnimationInterpolator2::SetInitialValueAndVelocity method to set the initial value and
		/// velocity before calling <c>GetFinalValue</c>, so a custom interpolator need not check whether the initial value and velocity
		/// have been set.
		/// </para>
		/// <para>
		/// Windows Animation can call SetInitialValueAndVelocity multiple times with different parameters. Interpolators can cache internal
		/// state to improve performance, but they must update this cached state each time <c>SetInitialValueAndVelocity</c> is called and
		/// ensure that the results of subsequent calls to <c>GetFinalValue</c> reflect the updated state.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationinterpolator2-getfinalvalue HRESULT
		// GetFinalValue( [out] DOUBLE *value, [in] UINT cDimension );
		[PreserveSig]
		HRESULT GetFinalValue([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] double[] value, uint cDimension);

		/// <summary>Interpolates the value of an animation variable at the specified offset and for the given dimension.</summary>
		/// <param name="offset">
		/// <para>The offset from the start of the transition.</para>
		/// <para>
		/// This parameter is always greater than or equal to zero and less than the duration of the transition. This method is not called
		/// if the duration of the transition is zero.
		/// </para>
		/// </param>
		/// <param name="value">The interpolated value.</param>
		/// <param name="cDimension">The dimension in which to interpolate the value.</param>
		/// <returns>
		/// If this method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </returns>
		/// <remarks>
		/// <para>
		/// Windows Animation always calls the IUIAnimationInterpolator2::SetInitialValueAndVelocity method to set the initial value and
		/// velocity before calling <c>InterpolateValue</c>, so a custom interpolator need not check whether the initial value and velocity
		/// have been set.
		/// </para>
		/// <para>
		/// Windows Animation can call SetInitialValueAndVelocity multiple times with different parameters. Interpolators can cache internal
		/// state to improve performance, but they must update this cached state each time <c>SetInitialValueAndVelocity</c> is called and
		/// ensure that the results of subsequent calls to <c>InterpolateValue</c> reflect the updated state.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationinterpolator2-interpolatevalue HRESULT
		// InterpolateValue( [in] UI_ANIMATION_SECONDS offset, [out] DOUBLE *value, [in] UINT cDimension );
		[PreserveSig]
		HRESULT InterpolateValue(double offset, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] double[] value, uint cDimension);

		/// <summary>Interpolates the velocity, or rate of change, at the specified offset for the given dimension.</summary>
		/// <param name="offset">
		/// <para>The offset from the start of the transition.</para>
		/// <para>
		/// The offset is always greater than or equal to zero and less than or equal to the duration of the transition. This method is not
		/// called if the duration of the transition is zero.
		/// </para>
		/// </param>
		/// <param name="velocity">The interpolated velocity.</param>
		/// <param name="cDimension">The dimension in which to interpolate the velocity.</param>
		/// <returns>
		/// If this method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </returns>
		/// <remarks>
		/// <para>
		/// Windows Animation always calls the IUIAnimationInterpolator2::SetInitialValueAndVelocity method to set the initial value and
		/// velocity before calling <c>InterpolateVelocity</c>, so a custom interpolator need not check whether the initial value and
		/// velocity have been set.
		/// </para>
		/// <para>
		/// Windows Animation can call SetInitialValueAndVelocity multiple times with different parameters. Interpolators can cache internal
		/// state to improve performance, but they must update this cached state each time <c>SetInitialValueAndVelocity</c> is called and
		/// ensure that the results of subsequent calls to <c>InterpolateVelocity</c> reflect the updated state.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationinterpolator2-interpolatevelocity
		// HRESULT InterpolateVelocity( [in] UI_ANIMATION_SECONDS offset, [out] DOUBLE *velocity, [in] UINT cDimension );
		[PreserveSig]
		HRESULT InterpolateVelocity(double offset, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] double[] velocity, uint cDimension);

		/// <summary>Generates a primitive interpolation of the specified animation curve.</summary>
		/// <param name="interpolation">The object that defines the custom animation curve information.</param>
		/// <param name="cDimension">The dimension in which to apply the new segment.</param>
		/// <returns>
		/// If this method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationinterpolator2-getprimitiveinterpolation
		// HRESULT GetPrimitiveInterpolation( [in] IUIAnimationPrimitiveInterpolation *interpolation, [in] UINT cDimension );
		[PreserveSig]
		HRESULT GetPrimitiveInterpolation(IUIAnimationPrimitiveInterpolation interpolation, uint cDimension);

		/// <summary>
		/// For the given dimension, <c>GetDependencies</c> retrieves the aspects of the interpolator that depend on the initial value or
		/// velocity that is passed to the IUIAnimationInterpolator2::SetInitialValueAndVelocity method or the duration that is passed to
		/// the IUIAnimationInterpolator2::SetDuration method.
		/// </summary>
		/// <param name="initialValueDependencies">Aspects of the interpolator that depend on the initial value passed to SetInitialValueAndVelocity.</param>
		/// <param name="initialVelocityDependencies">Aspects of the interpolator that depend on the initial velocity passed to SetInitialValueAndVelocity.</param>
		/// <param name="durationDependencies">Aspects of the interpolator that depend on the duration passed to SetDuration.</param>
		/// <returns>
		/// If this method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
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
		/// <para>For example, consider an interpolator that:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Accepts a final value as a parameter.</description>
		/// </item>
		/// <item>
		/// <description>Always comes to a gradual stop at that final value.</description>
		/// </item>
		/// <item>
		/// <description>Has a duration determined by the difference between the final value and the initial value.</description>
		/// </item>
		/// </list>
		/// <para>
		/// In this case the interpolator should return <c>UI_ANIMATION_DEPENDENCY_INTERMEDIATE_VALUES</c>| <c>UI_ANIMATION_DURATION</c> for
		/// the <c>initialValueDependencies</c> parameter. It should not return <c>UI_ANIMATION_DEPENDENCY_FINAL_VALUE</c>, because this
		/// value is set when the interpolator is created and is not affected by the initial value. Likewise, the interpolator should not
		/// return <c>UI_ANIMATION_DEPENDENCY_FINAL_VELOCITY</c>, because the slope of the curve is defined to always be zero when it
		/// reaches the final value.
		/// </para>
		/// <para>
		/// It is important that an interpolator return a correct set of flags. If a flag is not present for an output, Windows Animation
		/// assumes that the corresponding parameter does not affect that aspect of the interpolator's results. For example, if the custom
		/// interpolator does not include <c>UI_ANIMATION_DEPENDENCY_FINAL_VALUE</c> for <c>initialVelocityDependencies</c>, Windows
		/// Animation may call SetInitialValueAndVelocity with an arbitrary velocity parameter, and then call GetFinalValue to determine the
		/// final value. The interpolator's implementation of <c>GetFinalValue</c> must return the same result no matter which velocity
		/// parameter has been passed to <c>SetInitialValueAndVelocity</c>, because the interpolator has claimed that the transition's final
		/// value does not depend on the initial velocity.
		/// </para>
		/// <para>
		/// <c>Note</c>  If the flags returned for <c>durationDependencies</c> do not include <c>UI_ANIMATION_DEPENDENCY_DURATION</c>,
		/// SetDuration will never be called on the interpolator.
		/// </para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationinterpolator2-getdependencies HRESULT
		// GetDependencies( [out] UI_ANIMATION_DEPENDENCIES *initialValueDependencies, [out] UI_ANIMATION_DEPENDENCIES
		// *initialVelocityDependencies, [out] UI_ANIMATION_DEPENDENCIES *durationDependencies );
		[PreserveSig]
		HRESULT GetDependencies(out UI_ANIMATION_DEPENDENCIES initialValueDependencies, out UI_ANIMATION_DEPENDENCIES initialVelocityDependencies, out UI_ANIMATION_DEPENDENCIES durationDependencies);
	}

	/// <summary>Defines a method for handling storyboard loop iteration events.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nn-uianimation-iuianimationloopiterationchangehandler2
	[PInvokeData("uianimation.h", MSDNShortId = "NN:uianimation.IUIAnimationLoopIterationChangeHandler2")]
	[ComImport, Guid("2D3B15A4-4762-47AB-A030-B23221DF3AE0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !NET5_0
	[SupportedOSPlatform("windows8.0")]
#endif
	public interface IUIAnimationLoopIterationChangeHandler2
	{
		/// <summary>Handles loop iteration change events, which occur when a loop within a storyboard begins a new iteration.</summary>
		/// <param name="storyboard">The storyboard to which the loop belongs.</param>
		/// <param name="id">The loop ID.</param>
		/// <param name="newIterationCount">The iteration count for the latest IUIAnimationManager2::Update.</param>
		/// <param name="oldIterationCount">The iteration count for the previous IUIAnimationManager2::Update.</param>
		/// <returns>
		/// If this method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationloopiterationchangehandler2-onloopiterationchanged
		// HRESULT OnLoopIterationChanged( [in] IUIAnimationStoryboard2 *storyboard, [in] UINT_PTR id, [in] UINT32 newIterationCount, [in]
		// UINT32 oldIterationCount );
		[PreserveSig]
		HRESULT OnLoopIterationChanged(IUIAnimationStoryboard2 storyboard, nuint id, uint newIterationCount, uint oldIterationCount);
	}

	/// <summary>
	/// Defines an <c>animation manager</c>, which provides a central interface for creating and managing animations in multiple dimensions.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nn-uianimation-iuianimationmanager2
	[PInvokeData("uianimation.h", MSDNShortId = "NN:uianimation.IUIAnimationManager2")]
	[ComImport, Guid("D8B6F7D4-4109-4D3F-ACEE-879926968CB1"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(UIAnimationManager2))]
#if !NET5_0
	[SupportedOSPlatform("windows8.0")]
#endif
	public interface IUIAnimationManager2
	{
		/// <summary>Creates a new animation variable for each specified dimension.</summary>
		/// <param name="initialValue">A vector (of size <c>cDimension</c>) of initial values for the animation variable.</param>
		/// <param name="cDimension">
		/// The number of dimensions that require animated values. This parameter specifies the number of values listed in <c>initialValue</c>.
		/// </param>
		/// <returns>The new animation variable.</returns>
		/// <remarks>
		/// <para>
		/// The initial value of an animation variable is specified when the variable is created. After an animation variable is created,
		/// its value cannot be changed directly; it must be updated through the animation manager.
		/// </para>
		/// <para>
		/// An animation variable is typically created to represent each visual characteristic that is to be animated. For example, an
		/// application might create three animation variables for the X, Y, and Z coordinates of an object that can move freely within a
		/// three-dimensional space.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager2-createanimationvectorvariable
		// HRESULT CreateAnimationVectorVariable( [in] const DOUBLE *initialValue, [in] UINT cDimension, [out, retval] IUIAnimationVariable2
		// **variable );
		IUIAnimationVariable2 CreateAnimationVectorVariable([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] double[] initialValue, uint cDimension);

		/// <summary>Creates a new animation variable.</summary>
		/// <param name="initialValue">The initial value for the animation variable.</param>
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
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager2-createanimationvariable
		// HRESULT CreateAnimationVariable( [in] DOUBLE initialValue, [out, retval] IUIAnimationVariable2 **variable );
		IUIAnimationVariable2 CreateAnimationVariable(double initialValue);

		/// <summary>Creates and schedules a single-transition storyboard.</summary>
		/// <param name="variable">The animation variable.</param>
		/// <param name="transition">A transition to be applied to the animation variable.</param>
		/// <param name="timeNow">The current system time.</param>
		/// <remarks>
		/// This method schedules a new storyboard by creating the storyboard, applying the specified transition to the specified variable,
		/// and then scheduling the storyboard.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager2-scheduletransition HRESULT
		// ScheduleTransition( [in] IUIAnimationVariable2 *variable, [in] IUIAnimationTransition2 *transition, [in] UI_ANIMATION_SECONDS
		// timeNow );
		void ScheduleTransition(IUIAnimationVariable2 variable, IUIAnimationTransition2 transition, double timeNow);

		/// <summary>Creates a new storyboard.</summary>
		/// <returns>The new storyboard.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager2-createstoryboard HRESULT
		// CreateStoryboard( [out, retval] IUIAnimationStoryboard2 **storyboard );
		IUIAnimationStoryboard2 CreateStoryboard();

		/// <summary>Finishes all active storyboards within the specified time interval.</summary>
		/// <param name="completionDeadline">The maximum time interval during which all storyboards must be finished.</param>
		/// <remarks>
		/// <para>
		/// Calling the <c>FinishAllStoryboards</c> method ensures that all active storyboards finish within the specified completion
		/// deadline. If a storyboard is scheduled to play past the deadline, it is compressed.
		/// </para>
		/// <para>
		/// A storyboard is considered active if a call to the IUIAnimationStoryboard::GetStatus method returns
		/// UI_ANIMATION_STORYBOARD_PLAYING or UI_ANIMATION_STORYBOARD_SCHEDULED.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager2-finishallstoryboards HRESULT
		// FinishAllStoryboards( [in] UI_ANIMATION_SECONDS completionDeadline );
		void FinishAllStoryboards(double completionDeadline);

		/// <summary>Abandons all active storyboards.</summary>
		/// <remarks>
		/// <para>Calling this method is equivalent to calling the IUIAnimationStoryboard::Abandon method for each active storyboard.</para>
		/// <para>
		/// A storyboard is considered active if a call to the IUIAnimationStoryboard::GetStatus method returns
		/// UI_ANIMATION_STORYBOARD_PLAYING or UI_ANIMATION_STORYBOARD_SCHEDULED.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager2-abandonallstoryboards HRESULT AbandonAllStoryboards();
		void AbandonAllStoryboards();

		/// <summary>Updates the values of all animation variables.</summary>
		/// <param name="timeNow">The current system time. This parameter must be greater than or equal to 0.0.</param>
		/// <param name="updateResult">The result of the update. You can omit this parameter from calls to this method.</param>
		/// <remarks>
		/// Calling this method advances the animation manager to <c>timeNow</c>, changes the status of all storyboards as necessary, and
		/// updates any animation variables to appropriate interpolated values. If the animation manager is paused, no storyboards or
		/// variables are updated. If the animation mode is UI_ANIMATION_MODE_DISABLED, all scheduled storyboards finish playing
		/// immediately. If the values of any variables change during this call, the value of <c>updateResult</c> is
		/// UI_ANIMATION_UPDATE_VARIABLES_CHANGED; otherwise, it is UI_ANIMATION_UPDATE_NO_CHANGE.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager2-update HRESULT Update( [in]
		// UI_ANIMATION_SECONDS timeNow, [out, optional] UI_ANIMATION_UPDATE_RESULT *updateResult );
		void Update(double timeNow, out UI_ANIMATION_UPDATE_RESULT updateResult);

		/// <summary>Gets the animation variable with the specified tag.</summary>
		/// <param name="object">The object portion of the tag. This parameter can be NULL.</param>
		/// <param name="id">The identifier portion of the tag.</param>
		/// <returns>The animation variable that matches the specified tag, or <c>NULL</c> if no match is found.</returns>
		/// <remarks>
		/// <para>
		/// A tag is a pairing of an integer identifier ( <c>id</c>) with a COM object ( <c>object</c>). An application can use tags to
		/// identify animation variables and storyboards. NULL is a valid object component of a tag; therefore, the <c>object</c> parameter
		/// can be NULL.
		/// </para>
		/// <para>
		/// Tags are not necessarily unique; this method returns <c>UI_E_AMBIGUOUS_MATCH</c> if more than one animation variable exists with
		/// the specified tag.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager2-getvariablefromtag HRESULT
		// GetVariableFromTag( [in, optional] IUnknown *object, [in] UINT32 id, [out, retval] IUIAnimationVariable2 **variable );
		IUIAnimationVariable2? GetVariableFromTag([In, MarshalAs(UnmanagedType.IUnknown)] object? @object, uint id);

		/// <summary>Gets the storyboard with the specified tag.</summary>
		/// <param name="object">The object portion of the tag. This parameter can be NULL.</param>
		/// <param name="id">The identifier portion of the tag.</param>
		/// <returns>The storyboard that matches the specified tag, or <c>NULL</c> if no match is found.</returns>
		/// <remarks>
		/// <para>
		/// A tag is a pairing of an integer identifier ( <c>id</c>) with a COM object ( <c>object</c>). An application can use tags to
		/// identify animation variables and storyboards. NULL is a valid object component of a tag; therefore, the <c>object</c> parameter
		/// can be NULL.
		/// </para>
		/// <para>
		/// Tags are not necessarily unique; this method returns UI_E_AMBIGUOUS_MATCH if more than one storyboard exists with the specified tag.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager2-getstoryboardfromtag HRESULT
		// GetStoryboardFromTag( [in, optional] IUnknown *object, [in] UINT32 id, [out] IUIAnimationStoryboard2 **storyboard );
		IUIAnimationStoryboard2? GetStoryboardFromTag([In, MarshalAs(UnmanagedType.IUnknown)] object? @object, uint id);

		/// <summary>Retrieves an estimate of the time interval before the next animation event.</summary>
		/// <returns>The estimated time, in seconds.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager2-estimatenexteventtime HRESULT
		// EstimateNextEventTime( [out] UI_ANIMATION_SECONDS *seconds );
		double EstimateNextEventTime();

		/// <summary>Gets the status of the animation manager.</summary>
		/// <returns>The status of the animation manager.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager2-getstatus HRESULT GetStatus(
		// [out] UI_ANIMATION_MANAGER_STATUS *status );
		UI_ANIMATION_MANAGER_STATUS GetStatus();

		/// <summary>Sets the animation mode.</summary>
		/// <param name="mode">The animation mode.</param>
		/// <remarks>
		/// Use this method to enable or disable animation globally. While animation is disabled, all storyboards finish immediately when
		/// they are scheduled. The default mode is UI_ANIMATION_MODE_SYSTEM_DEFAULT, which lets Windows decide when to enable or disable
		/// animation in the application.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager2-setanimationmode HRESULT
		// SetAnimationMode( [in] UI_ANIMATION_MODE mode );
		void SetAnimationMode(UI_ANIMATION_MODE mode);

		/// <summary>Pauses all animations.</summary>
		/// <remarks>When an animation manager is paused, its status is set to UI_ANIMATION_MANAGER_IDLE.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager2-pause HRESULT Pause();
		void Pause();

		/// <summary>Resumes all animations.</summary>
		/// <remarks>
		/// When an animation manager is resumed, and at least one animation is currently scheduled or playing, its status is set to UI_ANIMATION_MANAGER_BUSY.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager2-resume HRESULT Resume();
		void Resume();

		/// <summary>Specifies a handler for animation manager status updates.</summary>
		/// <param name="handler">
		/// <para>The event handler to be called when the status of the animation manager changes.</para>
		/// <para>
		/// The specified object must implement the IUIAnimationManagerEventHandler interface or be <c>NULL</c>. See Remarks for more info.
		/// </para>
		/// </param>
		/// <param name="fRegisterForNextAnimationEvent">
		/// If <c>TRUE</c>, specifies that IUIAnimationManager2::EstimateNextEventTime will incorporate <c>handler</c> into its estimate of
		/// the time interval until the next animation event. No default value.
		/// </param>
		/// <remarks>
		/// Passing <c>NULL</c> for the <c>handler</c> parameter causes Windows Animation to release its reference to any handler object
		/// that you passed in earlier. This technique can be essential for breaking reference cycles without having to call the
		/// IUIAnimationManager2::Shutdown method.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager2-setmanagereventhandler
		// HRESULT SetManagerEventHandler( [in, optional] IUIAnimationManagerEventHandler2 *handler, [in] [MarshalAs(UnmanagedType.Bool)]
		// bool fRegisterForNextAnimationEvent );
		void SetManagerEventHandler(IUIAnimationManagerEventHandler2? handler, [MarshalAs(UnmanagedType.Bool)] bool fRegisterForNextAnimationEvent);

		/// <summary>Sets the priority comparison handler that determines whether a scheduled storyboard can be canceled.</summary>
		/// <param name="comparison">
		/// <para>The priority comparison handler for cancelation.</para>
		/// <para>
		/// The specified object must implement the IUIAnimationPriorityComparison2 interface or be <c>NULL</c>. See Remarks for more info.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Setting a priority comparison handler with this method enables the application to indicate when scheduling conflicts can be
		/// resolved by canceling storyboards.
		/// </para>
		/// <para>
		/// A scheduled storyboard can be canceled only if it hasn't started playing and the priority comparison object registered with this
		/// method returns <c>S_OK</c>. Canceled storyboards are completely removed from the schedule.
		/// </para>
		/// <para>
		/// Passing <c>NULL</c> for the <c>comparison</c> parameter causes Windows Animation to release its reference to any priority
		/// comparison handler object that you passed in earlier. This technique can be essential for breaking reference cycles without
		/// having to call the IUIAnimationManager2::Shutdown method.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager2-setcancelprioritycomparison
		// HRESULT SetCancelPriorityComparison( [in, optional] IUIAnimationPriorityComparison2 *comparison );
		void SetCancelPriorityComparison(IUIAnimationPriorityComparison2? comparison);

		/// <summary>Sets the priority comparison handler that determines whether a scheduled storyboard can be trimmed.</summary>
		/// <param name="comparison">
		/// <para>The priority comparison handler for trimming.</para>
		/// <para>The specified object must implement the IUIAnimationPriorityComparison interface or be <c>NULL</c>.</para>
		/// <para>See Remarks for more info.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Setting a priority comparison handler with this method enables the application to indicate when scheduling conflicts can be
		/// resolved by trimming the scheduled storyboard.
		/// </para>
		/// <para>
		/// A scheduled storyboard can be trimmed only if the priority comparison object registered with this method returns <c>S_OK</c>. If
		/// the new storyboard trims the scheduled storyboard, the scheduled storyboard can no longer affect a variable after the new
		/// storyboard begins to animate that variable.
		/// </para>
		/// <para>
		/// Passing <c>NULL</c> for the <c>comparison</c> parameter causes Windows Animation to release its reference to any handler object
		/// that you passed in earlier. This technique can be essential for breaking reference cycles without having to call the
		/// IUIAnimationManager2::Shutdown method.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager2-settrimprioritycomparison
		// HRESULT SetTrimPriorityComparison( [in, optional] IUIAnimationPriorityComparison2 *comparison );
		void SetTrimPriorityComparison(IUIAnimationPriorityComparison2? comparison);

		/// <summary>Sets the priority comparison handler that determines whether a scheduled storyboard can be compressed.</summary>
		/// <param name="comparison">
		/// <para>The priority comparison handler for compression.</para>
		/// <para>
		/// The specified object must implement the IUIAnimationPriorityComparison2 interface or be <c>NULL</c>. See Remarks for more info.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Setting a priority comparison handler with this method enables the application to indicate when scheduling conflicts can be
		/// resolved by compressing the scheduled storyboard and any other storyboards animating the same variables.
		/// </para>
		/// <para>
		/// A storyboard can be compressed only if the priority comparison object registered with this method returns <c>S_OK</c> for all
		/// the other scheduled storyboards that will be affected by compression. When the storyboards are compressed, time is temporarily
		/// accelerated for affected storyboards, so they play faster.
		/// </para>
		/// <para>
		/// Passing <c>NULL</c> for the <c>comparison</c> parameter causes Windows Animation to release its reference to any handler object
		/// that you passed in earlier. This technique can be essential for breaking reference cycles without having to call the
		/// IUIAnimationManager2::Shutdown method.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager2-setcompressprioritycomparison
		// HRESULT SetCompressPriorityComparison( [in, optional] IUIAnimationPriorityComparison2 *comparison );
		void SetCompressPriorityComparison(IUIAnimationPriorityComparison2? comparison);

		/// <summary>Sets the priority comparison handler that determines whether a scheduled storyboard can be concluded.</summary>
		/// <param name="comparison">
		/// The priority comparison handler for conclusion. The specified object must implement the IUIAnimationPriorityComparison2
		/// interface or be <c>NULL</c>. See Remarks for more info.
		/// </param>
		/// <remarks>
		/// <para>
		/// Setting a priority comparison handler with this method enables the application to indicate when scheduling conflicts can be
		/// resolved by concluding the scheduled storyboard.
		/// </para>
		/// <para>
		/// A scheduled storyboard can be concluded only if it contains a loop with a repetition count of UI_ANIMATION_REPEAT_INDEFINITELY
		/// and the priority comparison object registered with this method returns <c>S_OK</c>. If the storyboard is concluded, the current
		/// repetition of the loop completes, and the rest of the storyboard then plays.
		/// </para>
		/// <para>
		/// Passing <c>NULL</c> for the <c>comparison</c> parameter causes Windows Animation to release its reference to any handler object
		/// that you passed in earlier. This technique can be essential for breaking reference cycles without having to call the
		/// IUIAnimationManager2::Shutdown method.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager2-setconcludeprioritycomparison
		// HRESULT SetConcludePriorityComparison( [in, optional] IUIAnimationPriorityComparison2 *comparison );
		void SetConcludePriorityComparison(IUIAnimationPriorityComparison2? comparison);

		/// <summary>Sets the default acceptable animation delay. This is the length of time that may pass before storyboards begin.</summary>
		/// <param name="delay">
		/// The default delay. This parameter can be a positive value, or UI_ANIMATION_SECONDS_EVENTUALLY (-1) to indicate that any finite
		/// delay is acceptable.
		/// </param>
		/// <remarks>
		/// For Windows Animation to schedule a storyboard successfully, the storyboard must begin before the longest acceptable delay has
		/// elapsed. Windows Animation determines this delay in the following order: the delay value set by calling
		/// IUIAnimationStoryboard::SetLongestAcceptableDelay for this specific storyboard, the delay value set by calling this method, or
		/// 0.0 if neither method has been called.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager2-setdefaultlongestacceptabledelay
		// HRESULT SetDefaultLongestAcceptableDelay( [in] UI_ANIMATION_SECONDS delay );
		void SetDefaultLongestAcceptableDelay(double delay);

		/// <summary>Shuts down the animation manager and all its associated objects.</summary>
		/// <remarks>
		/// Calling this method directs the animation manager, and all the objects it created, to release all their pointers to other
		/// objects. After <c>IUIAnimationManager2::Shutdown</c> has been called, no other methods may be called on the animation manager or
		/// on any objects that it created. An application can call this method to clean up if there is any possibility that the application
		/// has introduced a reference cycle that includes some animation objects.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanager2-shutdown HRESULT Shutdown();
		void Shutdown();
	}

	/// <summary>Defines a method for handling updates to an animation manager.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nn-uianimation-iuianimationmanagereventhandler2
	[PInvokeData("uianimation.h", MSDNShortId = "NN:uianimation.IUIAnimationManagerEventHandler2")]
	[ComImport, Guid("F6E022BA-BFF3-42EC-9033-E073F33E83C3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !NET5_0
	[SupportedOSPlatform("windows8.0")]
#endif
	public interface IUIAnimationManagerEventHandler2
	{
		/// <summary>Handles status changes to an animation manager.</summary>
		/// <param name="newStatus">The new status of the animation manager.</param>
		/// <param name="previousStatus">The previous status of the animation manager.</param>
		/// <returns>
		/// If the method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </returns>
		/// <remarks>
		/// Calls made to other Windows Animation methods from <c>IUIAnimationManager2::OnManagerStatusChanged</c> fail and return <c>UI_E_ILLEGAL_REENTRANCY</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationmanagereventhandler2-onmanagerstatuschanged
		// HRESULT OnManagerStatusChanged( [in] UI_ANIMATION_MANAGER_STATUS newStatus, [in] UI_ANIMATION_MANAGER_STATUS previousStatus );
		[PreserveSig]
		HRESULT OnManagerStatusChanged(UI_ANIMATION_MANAGER_STATUS newStatus, UI_ANIMATION_MANAGER_STATUS previousStatus);
	}

	/// <summary>
	/// Defines a method that allows a custom interpolator to provide transition information, in the form of a cubic polynomial curve, to
	/// the animation manager.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nn-uianimation-iuianimationprimitiveinterpolation
	[PInvokeData("uianimation.h", MSDNShortId = "NN:uianimation.IUIAnimationPrimitiveInterpolation")]
	[ComImport, Guid("BAB20D63-4361-45DA-A24F-AB8508846B5B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !NET5_0
	[SupportedOSPlatform("windows8.0")]
#endif
	public interface IUIAnimationPrimitiveInterpolation
	{
		/// <summary>Adds a cubic polynomial segment that describes the shape of a transition curve to the animation function.</summary>
		/// <param name="dimension">The dimension in which to apply the new segment.</param>
		/// <param name="beginOffset">The begin offset for the segment, where 0 corresponds to the start of the transition.</param>
		/// <param name="constantCoefficient">The cubic polynomial constant coefficient.</param>
		/// <param name="linearCoefficient">The cubic polynomial linear coefficient.</param>
		/// <param name="quadraticCoefficient">The cubic polynomial quadratic coefficient.</param>
		/// <param name="cubicCoefficient">The cubic polynomial cubic coefficient.</param>
		/// <returns>
		/// If this method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </returns>
		/// <remarks>
		/// This method will fail with an error code of UI_E_INVALID_PRIMITIVE if the start time is either less than 0 or less than the
		/// start time of a previous segment.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationprimitiveinterpolation-addcubic
		// HRESULT AddCubic( [in] UINT dimension, [in] UI_ANIMATION_SECONDS beginOffset, [in] FLOAT constantCoefficient, [in] FLOAT
		// linearCoefficient, [in] FLOAT quadraticCoefficient, [in] FLOAT cubicCoefficient );
		[PreserveSig]
		HRESULT AddCubic(uint dimension, double beginOffset, float constantCoefficient, float linearCoefficient, float quadraticCoefficient, float cubicCoefficient);

		/// <summary>Adds a sinusoidal segment that describes the shape of a transition curve to the animation function.</summary>
		/// <param name="dimension">The dimension in which to apply the new segment.</param>
		/// <param name="beginOffset">The begin offset for the segment, where 0 corresponds to the start of the transition.</param>
		/// <param name="bias">The bias constant in the sinusoidal function.</param>
		/// <param name="amplitude">The amplitude constant in the sinusoidal function.</param>
		/// <param name="frequency">The frequency constant in the sinusoidal function.</param>
		/// <param name="phase">The phase constant in the sinusoidal function.</param>
		/// <returns>
		/// If this method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </returns>
		/// <remarks>
		/// <para>
		/// Defined by the function Y(t) = bias + amplitudesin(360frequency*t + phase), where 'sin' is the sin of an angle specified in
		/// degrees (for example, sin(n + 360) == sin(n) for any real number 'n').
		/// </para>
		/// <para>
		/// This method will fail with an error code of UI_E_INVALID_PRIMITIVE if the start time is either less than 0 or less than the
		/// start time of a previous segment.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationprimitiveinterpolation-addsinusoidal
		// HRESULT AddSinusoidal( [in] UINT dimension, [in] UI_ANIMATION_SECONDS beginOffset, [in] FLOAT bias, [in] FLOAT amplitude, [in]
		// FLOAT frequency, [in] FLOAT phase );
		[PreserveSig]
		HRESULT AddSinusoidal(uint dimension, double beginOffset, float bias, float amplitude, float frequency, float phase);
	}

	/// <summary>Defines a method that resolves scheduling conflicts through priority comparison.</summary>
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
	/// To determine which storyboard has priority, the animation manager can call the HasPriority method on one or more priority comparison
	/// handlers provided by the application.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nn-uianimation-iuianimationprioritycomparison2
	[PInvokeData("uianimation.h", MSDNShortId = "NN:uianimation.IUIAnimationPriorityComparison2")]
	[ComImport, Guid("5B6D7A37-4621-467C-8B05-70131DE62DDB"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !NET5_0
	[SupportedOSPlatform("windows8.0")]
#endif
	public interface IUIAnimationPriorityComparison2
	{
		/// <summary>Determines the relative priority between a scheduled storyboard and a new storyboard.</summary>
		/// <param name="scheduledStoryboard">The currently scheduled storyboard.</param>
		/// <param name="newStoryboard">The new storyboard that is interrupting the scheduled storyboard specified by <c>scheduledStoryboard</c>.</param>
		/// <param name="priorityEffect">The potential effect on <c>newStoryboard</c> if <c>scheduledStoryboard</c> has a higher priority.</param>
		/// <returns>
		/// <para>
		/// Returns the following if successful; otherwise an <c>HRESULT</c> error code. See Windows Animation Error Codes for a list of
		/// error codes.
		/// </para>
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
		/// To determine which storyboard has priority, the animation manager can call the <c>HasPriority</c> method on one or more priority
		/// comparison handlers provided by the application.
		/// </para>
		/// <para>
		/// Registering priority comparison objects is optional. By default, all storyboards can be trimmed, concluded, or compressed to
		/// prevent failure, but none can be canceled, and by default no storyboards will be canceled or trimmed to prevent a delay.
		/// </para>
		/// <para>
		/// By default, a call made in a callback method to any other animation method results in the call failing and returning
		/// <c>UI_E_ILLEGAL_REENTRANCY</c>. However, there are exceptions to this default. The following methods can be successfully called
		/// from HasPriority:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>IUIAnimationManager2::GetStoryboardFromTag</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationManager2::GetVariableFromTag</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationStoryboard::GetTag</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable2::GetTag</description>
		/// </item>
		/// </list>
		/// <para>Contention Management</para>
		/// <para>To resolve a scheduling conflict, the animation manager has the following options:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// Cancel the scheduled storyboard if it has not started playing and the priority comparison object that is registered with
		/// IUIAnimationManager2::SetCancelPriorityComparison returns <c>S_OK</c>. Canceled storyboards are completely removed from the schedule.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// Trim the scheduled storyboard if the priority comparison object that is registered with
		/// IUIAnimationManager2::SetTrimPriorityComparison returns <c>S_OK</c>. If the new storyboard trims the scheduled storyboard, the
		/// scheduled storyboard can no longer affect a variable when the new storyboard begins to animate that variable.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// Conclude the scheduled storyboard if the scheduled storyboard contains a loop with a repetition count of
		/// UI_ANIMATION_REPEAT_INDEFINITELY and the priority comparison object that is registered with
		/// IUIAnimationManager2::SetConcludePriorityComparison returns <c>S_OK</c>. If the storyboard is concluded, the current repetition
		/// of the loop completes, and the reminder of the storyboard then plays.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// Compress the scheduled storyboard, and any other storyboards animating the same variables, if the priority comparison object
		/// that is registered with IUIAnimationManager2::SetCompressPriorityComparison returns <c>S_OK</c> for all scheduled storyboards
		/// that might be affected by the compression. When the storyboards are compressed, time is temporarily accelerated for affected
		/// storyboards, so they play faster.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// If none of the preceding options is allowed by the priority comparison objects, the attempt to schedule the storyboard fails and
		/// Windows Animation returns UI_ANIMATION_SCHEDULING_INSUFFICIENT_PRIORITY to the calling application.
		/// </para>
		/// <para>
		/// Note that for the new storyboard to be successfully scheduled, it must begin before its longest acceptable delay has elapsed.
		/// This is determined by IUIAnimationStoryboard::SetLongestAcceptableDelay or
		/// IUIAnimationManager2::SetDefaultLongestAcceptableDelay (if neither is called, the default is 0.0 seconds). If the longest
		/// acceptable delay is <c>UI_ANIMATION_SECONDS_EVENTUALLY</c>, any finite delay will be sufficient.
		/// </para>
		/// <para>
		/// The <c>priorityEffect</c> parameter describes the possible effect on the new storyboard if <c>HasPriority</c> were to return
		/// <c>S_FALSE</c>. If <c>priorityEffect</c> is UI_ANIMATION_PRIORITY_EFFECT_FAILURE, it is possible that returning <c>S_FALSE</c>
		/// will result in a failure to schedule the new storyboard. (It is also possible that the animation manager will be allowed to
		/// resolve the conflict in a different way by another priority comparison object.) If <c>priorityEffect</c> is
		/// <c>UI_ANIMATION_PRIORITY_EFFECT_DELAY</c>, the only downside of returning <c>S_FALSE</c> is that the storyboard might begin
		/// later than it would have if <c>HasPriority</c> had returned <c>S_OK</c>.
		/// </para>
		/// <para>
		/// When UI_ANIMATION_PRIORITY_EFFECT_DELAY is passed to <c>HasPriority</c>, the animation manager has already determined that it
		/// can schedule the new storyboard to begin before its longest acceptable delay has elapsed, but it is in effect asking the
		/// application if the storyboard should begin even earlier. In some scenarios, it might be best to reduce the latency of an
		/// animation by returning <c>S_OK</c>. In others, it might be preferable to let scheduled animations complete whenever possible, in
		/// which case <c>HasPriority</c> should return <c>S_FALSE</c>. <c>UI_ANIMATION_PRIORITY_EFFECT_DELAY</c> is only passed to
		/// <c>HasPriority</c> when the animation manager is considering canceling or trimming a storyboard.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationprioritycomparison2-haspriority
		// HRESULT HasPriority( [in] IUIAnimationStoryboard2 *scheduledStoryboard, [in] IUIAnimationStoryboard2 *newStoryboard, [in]
		// UI_ANIMATION_PRIORITY_EFFECT priorityEffect );
		[PreserveSig]
		HRESULT HasPriority(IUIAnimationStoryboard2 scheduledStoryboard, IUIAnimationStoryboard2 newStoryboard, UI_ANIMATION_PRIORITY_EFFECT priorityEffect);
	}

	/// <summary>Defines a storyboard, which contains a group of transitions that are synchronized relative to one another.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nn-uianimation-iuianimationstoryboard2
	[PInvokeData("uianimation.h", MSDNShortId = "NN:uianimation.IUIAnimationStoryboard2")]
	[ComImport, Guid("AE289CD2-12D4-4945-9419-9E41BE034DF2"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IUIAnimationStoryboard2
	{
		/// <summary>Adds a transition to the storyboard.</summary>
		/// <param name="variable">The animation variable for which the transition is to be added.</param>
		/// <param name="transition">The transition to be added.</param>
		/// <remarks>
		/// The <c>AddTransition</c> method applies the specified transition to the specified variable in the storyboard. If this is the
		/// first transition applied to this variable in this storyboard, the transition begins at the start of the storyboard. Otherwise,
		/// the transition is appended to the transition that was most recently added to the variable.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboard2-addtransition HRESULT
		// AddTransition( [in] IUIAnimationVariable2 *variable, [in] IUIAnimationTransition2 *transition );
		void AddTransition(IUIAnimationVariable2 variable, IUIAnimationTransition2 transition);

		/// <summary>Adds a keyframe at the specified offset from an existing keyframe.</summary>
		/// <param name="existingKeyframe">
		/// The existing keyframe. To add a keyframe at an offset from the start of the storyboard, use the special keyframe UI_ANIMATION_KEYFRAME_STORYBOARD_START.
		/// </param>
		/// <param name="offset">The offset from the existing keyframe at which a new keyframe is to be added.</param>
		/// <param name="keyframe">The keyframe to be added.</param>
		/// <remarks>
		/// A keyframe represents a moment in time within a storyboard and can be used to specify the start and end times of transitions.
		/// Because keyframes can be added at the ends of transitions, their offsets from the start of the storyboard may not be known until
		/// the storyboard is playing.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboard2-addkeyframeatoffset
		// HRESULT AddKeyframeAtOffset( [in] UI_ANIMATION_KEYFRAME existingKeyframe, [in] UI_ANIMATION_SECONDS offset, [out]
		// UI_ANIMATION_KEYFRAME *keyframe );
		void AddKeyframeAtOffset(UI_ANIMATION_KEYFRAME existingKeyframe, double offset, out UI_ANIMATION_KEYFRAME keyframe);

		/// <summary>Adds a keyframe at the end of the specified transition.</summary>
		/// <param name="transition">The transition after which a keyframe is to be added.</param>
		/// <param name="keyframe">The keyframe to be added.</param>
		/// <remarks>
		/// A keyframe represents a moment in time within a storyboard and can be used to specify the start and end times of transitions.
		/// Because keyframes can be added at the ends of transitions, their offsets from the start of the storyboard may not be known until
		/// the storyboard is playing.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboard2-addkeyframeaftertransition
		// HRESULT AddKeyframeAfterTransition( [in] IUIAnimationTransition2 *transition, [out] UI_ANIMATION_KEYFRAME *keyframe );
		void AddKeyframeAfterTransition(IUIAnimationTransition2 transition, out UI_ANIMATION_KEYFRAME keyframe);

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
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboard2-addtransitionatkeyframe
		// HRESULT AddTransitionAtKeyframe( [in] IUIAnimationVariable2 *variable, [in] IUIAnimationTransition2 *transition, [in]
		// UI_ANIMATION_KEYFRAME startKeyframe );
		void AddTransitionAtKeyframe(IUIAnimationVariable2 variable, IUIAnimationTransition2 transition, UI_ANIMATION_KEYFRAME startKeyframe);

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
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboard2-addtransitionbetweenkeyframes
		// HRESULT AddTransitionBetweenKeyframes( [in] IUIAnimationVariable2 *variable, [in] IUIAnimationTransition2 *transition, [in]
		// UI_ANIMATION_KEYFRAME startKeyframe, [in] UI_ANIMATION_KEYFRAME endKeyframe );
		void AddTransitionBetweenKeyframes(IUIAnimationVariable2 variable, IUIAnimationTransition2 transition, UI_ANIMATION_KEYFRAME startKeyframe, UI_ANIMATION_KEYFRAME endKeyframe);

		/// <summary>Creates a loop between two keyframes.</summary>
		/// <param name="startKeyframe">The keyframe at which the loop is to begin.</param>
		/// <param name="endKeyframe">
		/// The keyframe at which the loop is to end. <c>endKeyframe</c> must not occur earlier in the storyboard than <c>startKeyframe</c>.
		/// </param>
		/// <param name="cRepetition">
		/// The number of times the loop is to be repeated; the last iteration of a loop can terminate fractionally between keyframes. A
		/// value of zero indicates that the specified portion of a storyboard will not be played. A value of
		/// UI_ANIMATION_REPEAT_INDEFINITELY (-1) indicates that the loop will repeat indefinitely until the storyboard is trimmed or concluded.
		/// </param>
		/// <param name="repeatMode">
		/// <para>The pattern for the loop iteration.</para>
		/// <para>
		/// A value of UI_ANIMATION_REPEAT_MODE_ALTERNATE (1) specifies that the start of the loop must alternate between keyframes
		/// (k1-&gt;k2, k2-&gt;k1, k1-&gt;k2, and so on).
		/// </para>
		/// <para>
		/// A value of UI_ANIMATION_REPEAT_MODE_NORMAL (0) specifies that the start of the loop must begin with the first keyframe
		/// (k1-&gt;k2, k1-&gt;k2, k1-&gt;k2, and so on).
		/// </para>
		/// <para>
		/// <c>Note</c>  If <c>repeatMode</c> has a value of UI_ANIMATION_REPEAT_MODE_ALTERNATE (1) and <c>cRepetition</c> has a value of
		/// UI_ANIMATION_REPEAT_INDEFINITELY (-1), the loop terminates on the end keyframe.
		/// </para>
		/// <para></para>
		/// </param>
		/// <param name="pIterationChangeHandler">The handler for each loop iteration event. The default value is 0.</param>
		/// <param name="id">The loop ID to pass to <c>pIterationChangeHandler</c>. The default value is 0.</param>
		/// <param name="fRegisterForNextAnimationEvent">
		/// If true, specifies that <c>pIterationChangeHandler</c> will be incorporated into the estimate of the time interval until the
		/// next animation event that is returned by the IUIAnimationManager2::EstimateNextEventTime method. The default value is 0, or false.
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
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboard2-repeatbetweenkeyframes
		// HRESULT RepeatBetweenKeyframes( [in] UI_ANIMATION_KEYFRAME startKeyframe, [in] UI_ANIMATION_KEYFRAME endKeyframe, [in] DOUBLE
		// cRepetition, [in] UI_ANIMATION_REPEAT_MODE repeatMode, [in] IUIAnimationLoopIterationChangeHandler2 *pIterationChangeHandler,
		// [in] UINT_PTR id, [in] [MarshalAs(UnmanagedType.Bool)] bool fRegisterForNextAnimationEvent );
		void RepeatBetweenKeyframes(UI_ANIMATION_KEYFRAME startKeyframe, UI_ANIMATION_KEYFRAME endKeyframe, double cRepetition, UI_ANIMATION_REPEAT_MODE repeatMode,
			IUIAnimationLoopIterationChangeHandler2 pIterationChangeHandler, nuint id, [MarshalAs(UnmanagedType.Bool)] bool fRegisterForNextAnimationEvent);

		/// <summary>Directs the storyboard to hold the specified animation variable at its final value until the storyboard ends.</summary>
		/// <param name="variable">The animation variable.</param>
		/// <remarks>
		/// When a storyboard is playing, it has exclusive access to any variables it animates unless the storyboard is trimmed by a
		/// higher-priority storyboard. Typically, this exclusive access is released when the last transition in the storyboard for that
		/// variable finishes playing. Applications can call this method to maintain exclusive access to the animation variable and hold the
		/// variable, at the final value of the last transition, until the end of the storyboard.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboard2-holdvariable HRESULT
		// HoldVariable( [in] IUIAnimationVariable2 *variable );
		void HoldVariable(IUIAnimationVariable2 variable);

		/// <summary>Sets the longest acceptable delay before the scheduled storyboard begins.</summary>
		/// <param name="delay">
		/// The longest acceptable delay. This parameter can be a positive value, or UI_ANIMATION_SECONDS_EVENTUALLY (-1) to indicate that
		/// any finite delay is acceptable.
		/// </param>
		/// <remarks>
		/// <para>
		/// For Windows Animation to schedule a storyboard successfully, the storyboard must begin before the longest acceptable delay has
		/// elapsed. Windows Animation determines this delay in the following order: the delay value set by calling this method, the delay
		/// value set by calling the IUIAnimationManager2::SetDefaultLongestAcceptableDelay method, or 0.0 if neither of these methods has
		/// been called.
		/// </para>
		/// <para>
		/// Use IUIAnimationStoryboard2::SetSkipDuration to start a storyboard animation at a specified offset instead of delaying the start
		/// of a storyboard.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboard2-setlongestacceptabledelay
		// HRESULT SetLongestAcceptableDelay( [in] UI_ANIMATION_SECONDS delay );
		void SetLongestAcceptableDelay(double delay);

		/// <summary>Specifies an offset from the beginning of a storyboard at which to start animating.</summary>
		/// <param name="secondsDuration">The offset, or amount of time, to skip at the beginning of the storyboard.</param>
		/// <remarks>
		/// <para>Calls to <c>SetSkipDuration</c> fail if the storyboard has been scheduled.</para>
		/// <para>
		/// <c>SetSkipDuration</c> does not delay the start of a scheduled storyboard. See
		/// IUIAnimationStoryboard2::SetLongestAcceptableDelay for more info on how to set a delay for a scheduled storyboard.
		/// </para>
		/// <para>This diagram shows a skip duration, or offset, for a storyboard.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboard2-setskipduration HRESULT
		// SetSkipDuration( [in] UI_ANIMATION_SECONDS secondsDuration );
		void SetSkipDuration(double secondsDuration);

		/// <summary>Directs the storyboard to schedule itself for play.</summary>
		/// <param name="timeNow">The current time.</param>
		/// <param name="schedulingResult">The result of the scheduling request. You can omit this parameter from calls to this method.</param>
		/// <remarks>
		/// <para>This method directs a storyboard to try to add itself to the schedule of playing storyboards, using these rules:</para>
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
		/// and the storyboard starts playing as soon as possible.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If the storyboard does not have priority, the attempt fails and the <c>schedulingResult</c> parameter is set to UI_ANIMATION_SCHEDULING_INSUFFICIENT_PRIORITY.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// If this method is called from a handler for OnStoryboardStatusChanged events, the <c>schedulingResult</c> parameter is set to
		/// <c>UI_ANIMATION_SCHEDULING_DEFERRED</c>. The only way to determine whether the storyboard is successfully scheduled is to set a
		/// storyboard event handler and check whether the storyboard's status ever becomes UI_ANIMATION_SCHEDULING_INSUFFICIENT_PRIORITY.
		/// </para>
		/// <para>
		/// It is possible to reuse a storyboard by calling <c>Schedule</c> again after its status has reached
		/// UI_ANIMATION_STORYBOARD_READY. An attempt to schedule a storyboard when it is in any state other than
		/// <c>UI_ANIMATION_STORYBOARD_BUILDING</c> or <c>UI_ANIMATION_STORYBOARD_READY</c> fails, and <c>schedulingResult</c> is set to UI_ANIMATION_SCHEDULING_ALREADY_SCHEDULED.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboard2-schedule HRESULT Schedule(
		// [in] UI_ANIMATION_SECONDS timeNow, [out, optional] UI_ANIMATION_SCHEDULING_RESULT *schedulingResult );
		void Schedule(double timeNow, out UI_ANIMATION_SCHEDULING_RESULT schedulingResult);

		/// <summary>
		/// Completes the current iteration of a keyframe loop that is in progress (where the loop is set to
		/// UI_ANIMATION_REPEAT_INDEFINITELY), terminates the loop, and continues with the storyboard.
		/// </summary>
		/// <remarks>
		/// <para>
		/// This method specifies that any subsequent keyframe loops that have a repetition count of UI_ANIMATION_REPEAT_INDEFINITELY (-1)
		/// will be skipped while the remainder of the storyboard is played.
		/// </para>
		/// <para>An iteration of a keyframe loop that is in progress will be completed before the remainder of the storyboard plays.</para>
		/// <para>
		/// If this method is called at the end of an alternating keyframe loop iteration, the loop is terminated with the loop value set to
		/// the ending loop value.
		/// </para>
		/// <para>
		/// If this method is called at the end of a non-alternating keyframe loop iteration, where "loop wrapping" results in the loop
		/// value being set to the starting value of the next iteration, the loop is executed once more in order for the loop value to be
		/// set to the ending loop value.
		/// </para>
		/// <para>
		/// For alternating keyframe loops, each iteration has a starting value that is equivalent to the ending value of the preceding
		/// loop. In this case, "loop wrapping" is not an issue.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboard2-conclude HRESULT Conclude();
		void Conclude();

		/// <summary>Finishes the storyboard within the specified time, compressing the storyboard if necessary.</summary>
		/// <param name="completionDeadline">The maximum amount of time that the storyboard can use to finish playing.</param>
		/// <remarks>This method has no effect on storyboard events. Events continue to be raised as expected while the storyboard plays.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboard2-finish HRESULT Finish(
		// UI_ANIMATION_SECONDS completionDeadline );
		void Finish(double completionDeadline);

		/// <summary>Terminates the storyboard, releases all related animation variables, and removes the storyboard from the schedule.</summary>
		/// <remarks>
		/// <para>This method can be called before or after the storyboard starts playing.</para>
		/// <para>This method does not trigger any storyboard events.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboard2-abandon HRESULT Abandon();
		void Abandon();

		/// <summary>Sets the tag for the storyboard.</summary>
		/// <param name="object">The object portion of the tag. This parameter can be NULL.</param>
		/// <param name="id">The identifier portion of the tag.</param>
		/// <remarks>
		/// A tag is a pairing of an integer identifier ( <c>id</c>) with a COM object ( <c>object</c>). It can be used by an application to
		/// identify a storyboard.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboard2-settag HRESULT SetTag(
		// [in, optional] IUnknown *object, [in] UINT32 id );
		void SetTag([MarshalAs(UnmanagedType.IUnknown)] object? @object, uint id);

		/// <summary>Gets the tag for a storyboard.</summary>
		/// <param name="obj">The object portion of the tag.</param>
		/// <param name="id">The identifier portion of the tag.</param>
		/// <returns>
		/// <para>
		/// If this method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>UI_E_VALUE_NOT_SET</c></description>
		/// <description>The storyboard tag was not set.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A tag is a pairing of an integer identifier ( <c>id</c>) with a COM object ( <c>object</c>); it can be used by an application to
		/// identify a storyboard.
		/// </para>
		/// <para>This method can return the identifier, the object, or both portions of the tag.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboard2-gettag HRESULT GetTag(
		// [out, optional] IUnknown **object, [out, optional] UINT32 *id );
		[PreserveSig]
		unsafe HRESULT GetTag([Out, Optional] IntPtr* obj, [Out, Optional] uint* id);

		/// <summary>Gets the status of the storyboard.</summary>
		/// <returns>The storyboard status.</returns>
		/// <remarks>
		/// Unless this method is called from a handler for OnStoryboardStatusChanged events, the only values it returns are
		/// UI_ANIMATION_STORYBOARD_BUILDING, <c>UI_ANIMATION_STORYBOARD_SCHEDULED</c>, <c>UI_ANIMATION_STORYBOARD_PLAYING</c>, and <c>UI_ANIMATION_STORYBOARD_READY</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboard2-getstatus HRESULT
		// GetStatus( [out, retval] UI_ANIMATION_STORYBOARD_STATUS *status );
		UI_ANIMATION_STORYBOARD_STATUS GetStatus();

		/// <summary>Gets the time that has elapsed since the storyboard started playing.</summary>
		/// <returns>The elapsed time.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboard2-getelapsedtime HRESULT
		// GetElapsedTime( [out] UI_ANIMATION_SECONDS *elapsedTime );
		double GetElapsedTime();

		/// <summary>Specifies a handler for storyboard events.</summary>
		/// <param name="handler">
		/// <para>The handler that Windows Animation should call whenever storyboard status and update events occur.</para>
		/// <para>
		/// The specified object must implement the IUIAnimationStoryboardEventHandler2 interface or be <c>NULL</c>. See Remarks for more info.
		/// </para>
		/// </param>
		/// <param name="fRegisterStatusChangeForNextAnimationEvent">
		/// If <c>TRUE</c>, registers the OnStoryboardStatusChanged event and includes those events in
		/// IUIAnimationManager2::EstimateNextEventTime, which estimates the time interval until the next animation event. No default value.
		/// </param>
		/// <param name="fRegisterUpdateForNextAnimationEvent">
		/// If <c>TRUE</c>, registers the OnStoryboardUpdated event and includes those events in
		/// IUIAnimationManager2::EstimateNextEventTime, which estimates the time interval until the next animation event. No default value.
		/// </param>
		/// <remarks>
		/// Passing <c>NULL</c> for the <c>handler</c> parameter causes Windows Animation to release its reference to any handler object
		/// that you passed in earlier. This technique can be essential for breaking reference cycles without having to call the
		/// IUIAnimationManager2::Shutdown method.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboard2-setstoryboardeventhandler
		// HRESULT SetStoryboardEventHandler( [in, optional] IUIAnimationStoryboardEventHandler2 *handler, [in] BOOL
		// fRegisterStatusChangeForNextAnimationEvent, [in] BOOL fRegisterUpdateForNextAnimationEvent );
		void SetStoryboardEventHandler(IUIAnimationStoryboardEventHandler2? handler, [MarshalAs(UnmanagedType.Bool)] bool fRegisterStatusChangeForNextAnimationEvent,
			[MarshalAs(UnmanagedType.Bool)] bool fRegisterUpdateForNextAnimationEvent);
	}

	/// <summary>Defines methods for handling storyboard events.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nn-uianimation-iuianimationstoryboardeventhandler2
	[PInvokeData("uianimation.h", MSDNShortId = "NN:uianimation.IUIAnimationStoryboardEventHandler2")]
	[ComImport, Guid("BAC5F55A-BA7C-414C-B599-FBF850F553C6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !NET5_0
	[SupportedOSPlatform("windows8.0")]
#endif
	public interface IUIAnimationStoryboardEventHandler2
	{
		/// <summary>Handles storyboard status change events.</summary>
		/// <param name="storyboard">The storyboard for which the status has changed.</param>
		/// <param name="newStatus">The new status.</param>
		/// <param name="previousStatus">The previous status.</param>
		/// <returns>
		/// If this method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
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
		/// <description>IUIAnimationManager2::CreateAnimationVariable</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationManager2::CreateStoryboard</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationManager2::GetStoryboardFromTag</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationManager2::GetVariableFromTag</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationStoryboard2::Abandon</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationStoryboard2::AddKeyframeAtOffset</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationStoryboard2::AddKeyframeAfterTransition</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationStoryboard2::AddTransition</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationStoryboard2::AddTransitionAtKeyframe</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationStoryboard2::AddTransitionBetweenKeyframes</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationStoryboard2::Conclude</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationStoryboard2::Finish</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationStoryboard2::GetTag</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationStoryboard2::HoldVariable</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationStoryboard2::RepeatBetweenKeyframes</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationStoryboard2::SetLongestAcceptableDelay</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationStoryboard2::SetStoryboardEventHandler</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationStoryboard2::SetTag</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationStoryboard2::Schedule</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationTransition2::GetDuration</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationTransition2::IsDurationKnown</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationTransition2::SetInitialValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationTransition2::SetInitialVelocity</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable2::GetCurrentStoryboard</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable2::GetFinalIntegerValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable2::GetFinalValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable2::GetIntegerValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable2::GetPreviousIntegerValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable2::GetPreviousValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable2::GetTag</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable2::GetValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable2::SetTag</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboardeventhandler2-onstoryboardstatuschanged
		// HRESULT OnStoryboardStatusChanged( [in] IUIAnimationStoryboard2 *storyboard, [in] UI_ANIMATION_STORYBOARD_STATUS newStatus, [in]
		// UI_ANIMATION_STORYBOARD_STATUS previousStatus );
		[PreserveSig]
		HRESULT OnStoryboardStatusChanged(IUIAnimationStoryboard2 storyboard, UI_ANIMATION_STORYBOARD_STATUS newStatus, UI_ANIMATION_STORYBOARD_STATUS previousStatus);

		/// <summary>Handles storyboard update events.</summary>
		/// <param name="storyboard">The storyboard that has been updated.</param>
		/// <returns>
		/// If this method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method is called when the value of at least one of the variables that a storyboard is animating has changed since the last
		/// call to the IUIAnimationManager2::Update method.
		/// </para>
		/// <para>
		/// By default, a call made in a callback method to any other animation method results in the call failing and returning
		/// <c>UI_E_ILLEGAL_REENTRANCY</c>. However, there are exceptions to this default. The following methods can be successfully called
		/// from <c>OnStoryboardUpdated</c>:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>IUIAnimationManager2::GetStoryboardFromTag</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationManager2::GetVariableFromTag</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationStoryboard2::GetTag</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable2::GetCurrentStoryboard</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable2::GetFinalIntegerValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable2::GetFinalValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable2::GetIntegerValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable2::GetPreviousIntegerValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable2::GetPreviousValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable2::GetTag</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable2::GetValue</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationstoryboardeventhandler2-onstoryboardupdated
		// HRESULT OnStoryboardUpdated( [in] IUIAnimationStoryboard2 *storyboard );
		[PreserveSig]
		HRESULT OnStoryboardUpdated(IUIAnimationStoryboard2 storyboard);
	}

	/// <summary>
	/// Extends the IUIAnimationTransition interface that defines a transition. An <c>IUIAnimationTransition2</c> transition determines how
	/// an animation variable changes over time in a given dimension.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nn-uianimation-iuianimationtransition2
	[PInvokeData("uianimation.h", MSDNShortId = "NN:uianimation.IUIAnimationTransition2")]
	[ComImport, Guid("62FF9123-A85A-4E9B-A218-435A93E268FD"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !NET5_0
	[SupportedOSPlatform("windows8.0")]
#endif
	public interface IUIAnimationTransition2
	{
		/// <summary>Gets the number of dimensions in which the animation variable has a transition specified.</summary>
		/// <returns>The number of dimensions.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransition2-getdimension HRESULT
		// GetDimension( [out] UINT *dimension );
		uint GetDimension();

		/// <summary>Sets the initial value of the transition.</summary>
		/// <param name="value">The initial value for the transition.</param>
		/// <remarks>Do not call this method after the transition has been added to a storyboard.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransition2-setinitialvalue HRESULT
		// SetInitialValue( [in] DOUBLE value );
		void SetInitialValue(double value);

		/// <summary>Sets the initial value of the transition for each specified dimension in the animation variable.</summary>
		/// <param name="value">A vector (of size <c>cDimension</c>) that contains the initial values for the transition.</param>
		/// <param name="cDimension">
		/// The number of dimensions that require transition values. This parameter specifies the number of values listed in <c>value</c>.
		/// </param>
		/// <remarks>The animation manager should not call this method after the transition has been added to a storyboard.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransition2-setinitialvectorvalue
		// HRESULT SetInitialVectorValue( [in] const DOUBLE *value, [in] UINT cDimension );
		void SetInitialVectorValue([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] double[] value, uint cDimension);

		/// <summary>Sets the initial velocity of the transition.</summary>
		/// <param name="velocity">The initial velocity for the transition.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransition2-setinitialvelocity HRESULT
		// SetInitialVelocity( [in] DOUBLE velocity );
		void SetInitialVelocity(double velocity);

		/// <summary>Sets the initial velocity of the transition for each specified dimension in the animation variable.</summary>
		/// <param name="velocity">A vector (of size <c>cDimension</c>) that contains the initial velocities for the transition.</param>
		/// <param name="cDimension">
		/// The number of dimensions that require transition velocities. This parameter specifies the number of values listed in <c>velocity</c>.
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransition2-setinitialvectorvelocity
		// HRESULT SetInitialVectorVelocity( [in] const DOUBLE *velocity, [in] UINT cDimension );
		void SetInitialVectorVelocity([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] double[] velocity, uint cDimension);

		/// <summary>Determines whether the duration of a transition is known.</summary>
		/// <returns>
		/// If this method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </returns>
		/// <remarks>This method should not be called when the storyboard to which the transition has been added is scheduled or playing.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransition2-isdurationknown HRESULT IsDurationKnown();
		[PreserveSig]
		HRESULT IsDurationKnown();

		/// <summary>Gets the duration of the transition.</summary>
		/// <returns>The duration of the transition, in seconds.</returns>
		/// <remarks>
		/// <para>An application should typically call the IsDurationKnown method before calling this method.</para>
		/// <para>This method should not be called when the storyboard to which the transition has been added is scheduled or playing.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransition2-getduration HRESULT
		// GetDuration( [out] UI_ANIMATION_SECONDS *duration );
		double GetDuration();
	}

	/// <summary>
	/// <para>Defines a method for creating transitions from custom interpolators.</para>
	/// <para><c>IUIAnimationTransitionFactory2</c> supports the creation of transitions in a specified dimension.</para>
	/// </summary>
	/// <remarks>
	/// When an application requires animation effects that are not available in the transition library, developers can implement custom
	/// transitions that the application can use. A custom transition is created by first implementing the interpolator function for the
	/// transition, and then by using a factory object to generate transitions from the interpolator. An interpolator must implement either
	/// the IUIAnimationInterpolator interface or the IUIAnimationInterpolator2 interface; an implementation of the transition factory
	/// object is provided by UIAnimationTransitionFactory or by UIAnimationTransitionFactory2.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nn-uianimation-iuianimationtransitionfactory2
	[PInvokeData("uianimation.h", MSDNShortId = "NN:uianimation.IUIAnimationTransitionFactory2")]
	[ComImport, Guid("937D4916-C1A6-42D5-88D8-30344D6EFE31"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(UIAnimationTransitionFactory2))]
#if !NET5_0
	[SupportedOSPlatform("windows8.0")]
#endif
	public interface IUIAnimationTransitionFactory2
	{
		/// <summary>Creates a transition from a custom interpolator for a given dimension.</summary>
		/// <param name="interpolator">
		/// <para>The interpolator from which a transition is to be created.</para>
		/// <para>The specified object must implement the IUIAnimationInterpolator2 interface.</para>
		/// </param>
		/// <returns>The new transition.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransitionfactory2-createtransition
		// HRESULT CreateTransition( [in, optional] IUIAnimationInterpolator2 *interpolator, [out] IUIAnimationTransition2 **transition );
		IUIAnimationTransition2 CreateTransition(IUIAnimationInterpolator2 interpolator);
	}

	/// <summary>Defines a library of standard transitions for a specified dimension.</summary>
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
	/// factory object to generate transitions from interpolators. An interpolator must implement the IUIAnimationInterpolator2 interface;
	/// an implementation of the transition factory object is provided by the UIAnimationTransitionFactory2 object.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nn-uianimation-iuianimationtransitionlibrary2
	[PInvokeData("uianimation.h", MSDNShortId = "NN:uianimation.IUIAnimationTransitionLibrary2")]
	[ComImport, Guid("03CFAE53-9580-4EE3-B363-2ECE51B4AF6A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(UIAnimationTransitionLibrary2))]
#if !NET5_0
	[SupportedOSPlatform("windows8.0")]
#endif
	public interface IUIAnimationTransitionLibrary2
	{
		/// <summary>Creates an instantaneous scalar transition.</summary>
		/// <param name="finalValue">The value of the animation variable at the end of the transition.</param>
		/// <returns>The new instantaneous transition.</returns>
		/// <remarks>
		/// <para>
		/// During an instantaneous transition, the value of the animation variable changes instantly from its current value to a specified
		/// final value. The duration of this transition is always zero.
		/// </para>
		/// <para>The following figure shows the change in value over time of an animation variable during an instantaneous transition.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransitionlibrary2-createinstantaneoustransition
		// HRESULT CreateInstantaneousTransition( [in] DOUBLE finalValue, [out] IUIAnimationTransition2 **transition );
		IUIAnimationTransition2 CreateInstantaneousTransition(double finalValue);

		/// <summary>Creates an instantaneous vector transition for each specified dimension.</summary>
		/// <param name="finalValue">
		/// A vector (of size <c>cDimension</c>) that contains the values of the animation variable at the end of the transition.
		/// </param>
		/// <param name="cDimension">
		/// The number of dimensions to apply the transition. This parameter specifies the number of values listed in <c>finalValue</c>.
		/// </param>
		/// <returns>The new instantaneous transition.</returns>
		/// <remarks>
		/// <para>
		/// During an instantaneous transition, the value of the animation variable changes instantly from its current value to a specified
		/// final value. The duration of this transition is always zero.
		/// </para>
		/// <para>The following figure shows the change in value over time of an animation variable during an instantaneous transition.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransitionlibrary2-createinstantaneousvectortransition
		// HRESULT CreateInstantaneousVectorTransition( [in] const DOUBLE *finalValue, [in] UINT cDimension, [out, retval]
		// IUIAnimationTransition2 **transition );
		IUIAnimationTransition2 CreateInstantaneousVectorTransition([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] double[] finalValue, uint cDimension);

		/// <summary>Creates a constant scalar transition.</summary>
		/// <param name="duration">The duration of the transition.</param>
		/// <returns>The new constant transition.</returns>
		/// <remarks>
		/// <para>
		/// During a constant transition, the value of an animation variable remains at the initial value over the duration of the transition.
		/// </para>
		/// <para>The following figure shows the change in value for an animation variable over time during a constant-duration transition.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransitionlibrary2-createconstanttransition
		// HRESULT CreateConstantTransition( [in] UI_ANIMATION_SECONDS duration, [out] IUIAnimationTransition2 **transition );
		IUIAnimationTransition2 CreateConstantTransition(double duration);

		/// <summary>Creates a discrete scalar transition.</summary>
		/// <param name="delay">The amount of time by which to delay the instantaneous switch to the final value.</param>
		/// <param name="finalValue">The value of the animation variable at the end of the transition.</param>
		/// <param name="hold">The amount of time by which to hold the variable at its final value.</param>
		/// <returns>The new discrete transition.</returns>
		/// <remarks>
		/// <para>
		/// During a discrete transition, the animation variable remains at the initial value for a specified delay time, then switches
		/// instantaneously to a specified final value and remains at that value for a given hold time.
		/// </para>
		/// <para>The following figure shows the change in value over time of an animation variable during a discrete transition.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransitionlibrary2-creatediscretetransition
		// HRESULT CreateDiscreteTransition( [in] UI_ANIMATION_SECONDS delay, [in] DOUBLE finalValue, [in] UI_ANIMATION_SECONDS hold, [out]
		// IUIAnimationTransition2 **transition );
		IUIAnimationTransition2 CreateDiscreteTransition(double delay, double finalValue, double hold);

		/// <summary>Creates a discrete vector transition for each specified dimension.</summary>
		/// <param name="delay">The amount of time by which to delay the instantaneous switch to the final value.</param>
		/// <param name="finalValue">
		/// A vector (of size <c>cDimension</c>) that contains the final values of the animation variable at the end of the transition.
		/// </param>
		/// <param name="cDimension">
		/// The number of dimensions to apply the transition. This parameter specifies the number of values listed in <c>finalValue</c>.
		/// </param>
		/// <param name="hold">The amount of time by which to hold the variable at its final value.</param>
		/// <returns>The new discrete transition.</returns>
		/// <remarks>
		/// <para>
		/// During a discrete transition, the animation variable remains at the initial value for a specified delay time, then switches
		/// instantaneously to a specified final value and remains at that value for a given hold time.
		/// </para>
		/// <para>The following figure shows the change in value over time of an animation variable during a discrete transition.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransitionlibrary2-creatediscretevectortransition
		// HRESULT CreateDiscreteVectorTransition( [in] UI_ANIMATION_SECONDS delay, [in] const DOUBLE *finalValue, [in] UINT cDimension,
		// [in] UI_ANIMATION_SECONDS hold, [out] IUIAnimationTransition2 **transition );
		IUIAnimationTransition2 CreateDiscreteVectorTransition(double delay, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] double[] finalValue, uint cDimension, double hold);

		/// <summary>Creates a linear scalar transition.</summary>
		/// <param name="duration">The duration of the transition.</param>
		/// <param name="finalValue">The value of the animation variable at the end of the transition.</param>
		/// <returns>The new linear transition.</returns>
		/// <remarks>
		/// <para>
		/// During a linear transition, the value of the animation variable transitions linearly from its initial value to a specified final value.
		/// </para>
		/// <para>The following figure shows the change in value over time of an animation variable during a linear transition.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransitionlibrary2-createlineartransition
		// HRESULT CreateLinearTransition( [in] UI_ANIMATION_SECONDS duration, [in] DOUBLE finalValue, [out] IUIAnimationTransition2
		// **transition );
		IUIAnimationTransition2 CreateLinearTransition(double duration, double finalValue);

		/// <summary>Creates a linear vector transition in the specified dimension.</summary>
		/// <param name="duration">The duration of the transition.</param>
		/// <param name="finalValue">
		/// A vector (of size <c>cDimension</c>) that contains the final values of the animation variable at the end of the transition.
		/// </param>
		/// <param name="cDimension">
		/// The number of dimensions to apply the transition. This parameter specifies the number of values listed in <c>finalValue</c>.
		/// </param>
		/// <returns>The new linear transition.</returns>
		/// <remarks>
		/// <para>
		/// During a linear transition, the value of the animation variable transitions linearly from its initial value to a specified final value.
		/// </para>
		/// <para>The following figure shows the change in value over time of an animation variable during a linear transition.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransitionlibrary2-createlinearvectortransition
		// HRESULT CreateLinearVectorTransition( [in] UI_ANIMATION_SECONDS duration, [in] const DOUBLE *finalValue, [in] UINT cDimension,
		// [out] IUIAnimationTransition2 **transition );
		IUIAnimationTransition2 CreateLinearVectorTransition(double duration, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] double[] finalValue, uint cDimension);

		/// <summary>Creates a linear-speed scalar transition.</summary>
		/// <param name="speed">The absolute value of the velocity in units/second.</param>
		/// <param name="finalValue">The value of the animation variable at the end of the transition.</param>
		/// <returns>The new linear-speed transition.</returns>
		/// <remarks>
		/// <para>
		/// During a linear-speed transition, the value of the animation variable changes at a specified rate. The duration of the
		/// transition is determined by the difference between the initial value and the specified final value.
		/// </para>
		/// <para>The following figure shows the change in value over time of an animation variable during a linear-speed transition.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransitionlibrary2-createlineartransitionfromspeed
		// HRESULT CreateLinearTransitionFromSpeed( [in] DOUBLE speed, [in] DOUBLE finalValue, [out] IUIAnimationTransition2 **transition );
		IUIAnimationTransition2 CreateLinearTransitionFromSpeed(double speed, double finalValue);

		/// <summary>Creates a linear-speed vector transition in the specified dimension.</summary>
		/// <param name="speed">The absolute value of the velocity in units/second.</param>
		/// <param name="finalValue">
		/// A vector (of size <c>cDimension</c>) that contains the final values of the animation variable at the end of the transition.
		/// </param>
		/// <param name="cDimension">
		/// The number of dimensions to apply the transition. This parameter specifies the number of values listed in <c>finalValue</c>.
		/// </param>
		/// <returns>The new linear-speed transition.</returns>
		/// <remarks>
		/// <para>
		/// During a linear-speed transition, the value of the animation variable changes at a specified rate. The duration of the
		/// transition is determined by the difference between the initial value and the specified final value.
		/// </para>
		/// <para>The following figure shows the change in value over time of an animation variable during a linear-speed transition.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransitionlibrary2-createlinearvectortransitionfromspeed
		// HRESULT CreateLinearVectorTransitionFromSpeed( [in] DOUBLE speed, [in] const DOUBLE *finalValue, [in] UINT cDimension, [out]
		// IUIAnimationTransition2 **transition );
		IUIAnimationTransition2 CreateLinearVectorTransitionFromSpeed(double speed, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] double[] finalValue, uint cDimension);

		/// <summary>Creates a sinusoidal scalar transition where amplitude is determined by initial velocity.</summary>
		/// <param name="duration">The duration of the transition.</param>
		/// <param name="period">The period of oscillation of the sinusoidal wave.</param>
		/// <returns>The new sinusoidal-velocity transition.</returns>
		/// <remarks>
		/// <para>
		/// The value of the animation variable oscillates around the initial value over the entire duration of a sinusoidal-range
		/// transition. The amplitude of the oscillation is determined by the velocity when the transition begins.
		/// </para>
		/// <para>The following figure shows the change in value over time of an animation variable during a sinusoidal-velocity transition.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransitionlibrary2-createsinusoidaltransitionfromvelocity
		// HRESULT CreateSinusoidalTransitionFromVelocity( [in] UI_ANIMATION_SECONDS duration, [in] UI_ANIMATION_SECONDS period, [out]
		// IUIAnimationTransition2 **transition );
		IUIAnimationTransition2 CreateSinusoidalTransitionFromVelocity(double duration, double period);

		/// <summary>Creates a sinusoidal-range scalar transition with a specified range of oscillation.</summary>
		/// <param name="duration">The duration of the transition.</param>
		/// <param name="minimumValue">The value of the animation variable at a trough of the sinusoidal wave.</param>
		/// <param name="maximumValue">The value of the animation variable at a peak of the sinusoidal wave.</param>
		/// <param name="period">The period of oscillation of the sinusoidal wave.</param>
		/// <param name="slope">The slope at the start of the transition.</param>
		/// <returns>The new sinusoidal-range transition.</returns>
		/// <remarks>
		/// <para>
		/// The value of the animation variable fluctuates between the specified minimum and maximum values over the entire duration of a
		/// sinusodial-range transition. The <c>slope</c> parameter is used to disambiguate between the two possible sine waves specified by
		/// the other parameters.
		/// </para>
		/// <para>
		/// The following figure shows the change in value over time of an animation variable during a sinusoidal-range transition. Passing
		/// in the UI_ANIMATION_SLOPE_INCREASING enumeration value yields a wave like the solid curve shown in the figure, whereas the
		/// <c>UI_ANIMATION_SLOPE_DECREASING</c> value yields a wave like the dashed curve.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransitionlibrary2-createsinusoidaltransitionfromrange
		// HRESULT CreateSinusoidalTransitionFromRange( [in] UI_ANIMATION_SECONDS duration, [in] DOUBLE minimumValue, [in] DOUBLE
		// maximumValue, [in] UI_ANIMATION_SECONDS period, [in] UI_ANIMATION_SLOPE slope, [out] IUIAnimationTransition2 **transition );
		IUIAnimationTransition2 CreateSinusoidalTransitionFromRange(double duration, double minimumValue, double maximumValue, double period, UI_ANIMATION_SLOPE slope);

		/// <summary>Creates an accelerate-decelerate scalar transition.</summary>
		/// <param name="duration">The duration of the transition.</param>
		/// <param name="finalValue">The value of the animation variable at the end of the transition.</param>
		/// <param name="accelerationRatio">The ratio of <c>duration</c> time spent accelerating (0 to 1).</param>
		/// <param name="decelerationRatio">The ratio of <c>duration</c> time spent decelerating (0 to 1).</param>
		/// <returns>The new accelerate-decelerate transition.</returns>
		/// <remarks>
		/// <para>
		/// During an accelerate-decelerate transition, the animation variable speeds up and then slows down over the duration of the
		/// transition, ending at a specified value. You can control how quickly the variable accelerates and decelerates independently, by
		/// specifying different acceleration and deceleration ratios.
		/// </para>
		/// <para>
		/// When the initial velocity is zero, the acceleration ratio is the fraction of the duration that the variable will spend
		/// accelerating; likewise for the deceleration ratio. If the value of initial velocity is nonzero, the value is the fraction of the
		/// time between the velocity reaching zero and the end of transition. The acceleration ratio and the deceleration ratio should sum
		/// to a maximum of 1.0.
		/// </para>
		/// <para>
		/// The following figures show the change in value for animation variables with different initial velocities during
		/// accelerate-decelerate transitions.
		/// </para>
		/// <para><c>Note</c>  d' in the figure on the right shows the time between the velocity reaching zero and the end of the transition.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransitionlibrary2-createacceleratedeceleratetransition
		// HRESULT CreateAccelerateDecelerateTransition( [in] UI_ANIMATION_SECONDS duration, [in] DOUBLE finalValue, [in] DOUBLE
		// accelerationRatio, [in] DOUBLE decelerationRatio, [out] IUIAnimationTransition2 **transition );
		IUIAnimationTransition2 CreateAccelerateDecelerateTransition(double duration, double finalValue, double accelerationRatio, double decelerationRatio);

		/// <summary>Creates a reversal scalar transition.</summary>
		/// <param name="duration">The duration of the transition.</param>
		/// <returns>The new reversal transition.</returns>
		/// <remarks>
		/// A reversal transition smoothly changes direction over the specified duration. The final value will be the same as the initial
		/// value and the final velocity will be the negative of the initial velocity. The following figure shows such a reversal transition.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransitionlibrary2-createreversaltransition
		// HRESULT CreateReversalTransition( [in] UI_ANIMATION_SECONDS duration, [out] IUIAnimationTransition2 **transition );
		IUIAnimationTransition2 CreateReversalTransition(double duration);

		/// <summary>Creates a cubic scalar transition.</summary>
		/// <param name="duration">The duration of the transition.</param>
		/// <param name="finalValue">The value of the animation variable at the end of the transition.</param>
		/// <param name="finalVelocity">The velocity of the variable at the end of the transition.</param>
		/// <returns>The new cubic transition.</returns>
		/// <remarks>
		/// <para>
		/// During a cubic transition, the value of the animation variable changes from its initial value to the <c>finalValue</c> over the
		/// <c>duration</c> of the transition, ending at the <c>finalVelocity</c>.
		/// </para>
		/// <para>The following figure shows the effect on an animation variable over time during a cubic transition.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransitionlibrary2-createcubictransition
		// HRESULT CreateCubicTransition( [in] UI_ANIMATION_SECONDS duration, [in] DOUBLE finalValue, [in] DOUBLE finalVelocity, [out]
		// IUIAnimationTransition2 **transition );
		IUIAnimationTransition2 CreateCubicTransition(double duration, double finalValue, double finalVelocity);

		/// <summary>Creates a cubic vector transition for each specified dimension.</summary>
		/// <param name="duration">The duration of the transition.</param>
		/// <param name="finalValue">
		/// A vector (of size <c>cDimension</c>) that contains the final values of the animation variable at the end of the transition.
		/// </param>
		/// <param name="finalVelocity">
		/// A vector (of size <c>cDimension</c>) that contains the final velocities (in units per second) of the animation variable at the
		/// end of the transition.
		/// </param>
		/// <param name="cDimension">
		/// The number of dimensions to apply the transition. This parameter specifies the number of values listed in <c>finalValue</c> and <c>finalVelocity</c>.
		/// </param>
		/// <returns>The new cubic transition.</returns>
		/// <remarks>
		/// <para>
		/// During a cubic transition, the value of the animation variable changes from its initial value to the <c>finalValue</c> over the
		/// <c>duration</c> of the transition, ending at the <c>finalVelocity</c>.
		/// </para>
		/// <para>The following figure shows the effect on an animation variable over time during a cubic transition.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransitionlibrary2-createcubicvectortransition
		// HRESULT CreateCubicVectorTransition( [in] UI_ANIMATION_SECONDS duration, [in] const DOUBLE *finalValue, [in] const DOUBLE
		// *finalVelocity, [in] UINT cDimension, [out] IUIAnimationTransition2 **transition );
		IUIAnimationTransition2 CreateCubicVectorTransition(double duration, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] double[] finalValue,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] double[] finalVelocity, uint cDimension);

		/// <summary>Creates a smooth-stop scalar transition.</summary>
		/// <param name="maximumDuration">The maximum duration of the transition.</param>
		/// <param name="finalValue">The value of the animation variable at the end of the transition.</param>
		/// <returns>The new smooth-stop transition.</returns>
		/// <remarks>
		/// <para>
		/// A smooth-stop transition slows down as it approaches the specified final value, and reaches the final value with a velocity of
		/// zero. The duration of the transition is determined by the initial velocity, the difference between the initial and final values,
		/// and the specified maximum duration. If there is no solution consisting of a single parabolic arc, this method creates a cubic transition.
		/// </para>
		/// <para>The following figure shows the change in value over time of an animation variable during a smooth-stop transition.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransitionlibrary2-createsmoothstoptransition
		// HRESULT CreateSmoothStopTransition( [in] UI_ANIMATION_SECONDS maximumDuration, [in] DOUBLE finalValue, [out]
		// IUIAnimationTransition2 **transition );
		IUIAnimationTransition2 CreateSmoothStopTransition(double maximumDuration, double finalValue);

		/// <summary>Creates a parabolic-acceleration scalar transition.</summary>
		/// <param name="finalValue">The value of the animation variable at the end of the transition.</param>
		/// <param name="finalVelocity">The velocity, in units/second, at the end of the transition.</param>
		/// <param name="acceleration">The acceleration, in units/second², during the transition.</param>
		/// <returns>The new parabolic-acceleration transition.</returns>
		/// <remarks>
		/// <para>
		/// During a parabolic-acceleration transition, the value of the animation variable changes from the initial value to the final
		/// value, ending at the specified velocity. You can control how quickly the variable reaches the final value by specifying the rate
		/// of acceleration.
		/// </para>
		/// <para>The following figure shows the change in value over time of an animation variable during a parabolic-acceleration transition.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransitionlibrary2-createparabolictransitionfromacceleration
		// HRESULT CreateParabolicTransitionFromAcceleration( [in] DOUBLE finalValue, [in] DOUBLE finalVelocity, [in] DOUBLE acceleration,
		// [out] IUIAnimationTransition2 **transition );
		IUIAnimationTransition2 CreateParabolicTransitionFromAcceleration(double finalValue, double finalVelocity, double acceleration);

		/// <summary>Creates a cubic Bézier linear scalar transition.</summary>
		/// <param name="duration">The duration of the transition.</param>
		/// <param name="finalValue">The value of the animation variable at the end of the transition.</param>
		/// <param name="x1">The x-coordinate of the first control point.</param>
		/// <param name="y1">The y-coordinate of the first control point.</param>
		/// <param name="x2">The x-coordinate of the second control point.</param>
		/// <param name="y2">The y-coordinate of the second control point.</param>
		/// <returns>The new cubic Bézier linear transition.</returns>
		/// <remarks>
		/// <para>
		/// During a cubic Bézier linear transition, the value of the animation variable changes from its initial value to the
		/// <c>finalValue</c> over the <c>duration</c> of the transition. The ordered pairs, (x1, y1) and (x2, y2), act as control points
		/// that provide directional information to transform the linear path of the transition into a smooth parametric curve.
		/// </para>
		/// <para>The following figure shows the change in value over time for an animation variable during a cubic Bézier linear transition.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransitionlibrary2-createcubicbezierlineartransition
		// HRESULT CreateCubicBezierLinearTransition( [in] UI_ANIMATION_SECONDS duration, [in] DOUBLE finalValue, [in] DOUBLE x1, [in]
		// DOUBLE y1, [in] DOUBLE x2, [in] DOUBLE y2, [out] IUIAnimationTransition2 **ppTransition );
		IUIAnimationTransition2 CreateCubicBezierLinearTransition(double duration, double finalValue, double x1, double y1, double x2, double y2);

		/// <summary>Creates a cubic Bézier linear vector transition for each specified dimension.</summary>
		/// <param name="duration">The duration of the transition.</param>
		/// <param name="finalValue">
		/// A vector (of size <c>cDimension</c>) that contains the final values of the animation variable at the end of the transition.
		/// </param>
		/// <param name="cDimension">
		/// The number of dimensions to apply the transition. This parameter specifies the number of values listed in <c>finalValue</c>.
		/// </param>
		/// <param name="x1">The x-coordinate of the first control point.</param>
		/// <param name="y1">The y-coordinate of the first control point.</param>
		/// <param name="x2">The x-coordinate of the second control point.</param>
		/// <param name="y2">The y-coordinate of the second control point.</param>
		/// <returns>The new cubic Bézier linear transition.</returns>
		/// <remarks>
		/// <para>
		/// During a cubic Bézier linear transition, the value of the animation variable changes from its initial value to the
		/// <c>finalValue</c> over the <c>duration</c> of the transition. The ordered pairs, (x1, y1) and (x2, y2), act as control points
		/// that provide directional information to transform the linear path of the transition into a smooth parametric curve.
		/// </para>
		/// <para>The following figure shows the change in value over time of an animation variable during a cubic Bézier linear transition.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationtransitionlibrary2-createcubicbezierlinearvectortransition
		// HRESULT CreateCubicBezierLinearVectorTransition( [in] UI_ANIMATION_SECONDS duration, [in] const DOUBLE *finalValue, [in] UINT
		// cDimension, [in] DOUBLE x1, [in] DOUBLE y1, [in] DOUBLE x2, [in] DOUBLE y2, [out] IUIAnimationTransition2 **ppTransition );
		IUIAnimationTransition2 CreateCubicBezierLinearVectorTransition(double duration, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] double[] finalValue, uint cDimension, double x1, double y1, double x2, double y2);
	}

	/// <summary>Defines an animation variable, which represents a visual element that can be animated in multiple dimensions.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nn-uianimation-iuianimationvariable2
	[PInvokeData("uianimation.h", MSDNShortId = "NN:uianimation.IUIAnimationVariable2")]
	[ComImport, Guid("4914B304-96AB-44D9-9E77-D5109B7E7466"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !NET5_0
	[SupportedOSPlatform("windows8.0")]
#endif
	public interface IUIAnimationVariable2
	{
		/// <summary>Gets the number of dimensions that the animation variable is to be animated in.</summary>
		/// <returns>The number of dimensions.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable2-getdimension HRESULT
		// GetDimension( [out] UINT *dimension );
		uint GetDimension();

		/// <summary>Gets the value of the animation variable.</summary>
		/// <returns>The value of the animation variable.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable2-getvalue HRESULT GetValue(
		// [out] DOUBLE *value );
		double GetValue();

		/// <summary>Gets the value of the animation variable in the specified dimension.</summary>
		/// <param name="value">The value of the animation variable.</param>
		/// <param name="cDimension">The dimension from which to get the value of the animation variable.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable2-getvectorvalue HRESULT
		// GetVectorValue( [out] DOUBLE *value, [in] UINT cDimension );
		void GetVectorValue([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] double[] value, uint cDimension);

		/// <summary>Gets the animation curve of the animation variable.</summary>
		/// <param name="animation">The object that generates a sequence of animation curve primitives.</param>
		/// <remarks>The application implements the IDCompositionAnimation object that is referenced by the <c>animation</c> parameter.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable2-getcurve HRESULT GetCurve(
		// [in] IDCompositionAnimation *animation );
		void GetCurve([In] IDCompositionAnimation animation);

		/// <summary>Gets the animation curve of the animation variable for the specified dimension.</summary>
		/// <param name="animation">The object that generates a sequence of animation curve primitives.</param>
		/// <param name="cDimension">The number of animation curves.</param>
		/// <remarks>The application implements the IDCompositionAnimation object that is referenced by the <c>animation</c> parameter.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable2-getvectorcurve HRESULT
		// GetVectorCurve( [in] IDCompositionAnimation **animation, [in] UINT cDimension );
		void GetVectorCurve([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] IDCompositionAnimation[] animation, uint cDimension);

		/// <summary>
		/// Gets the final value of the animation variable. This is the value after all currently scheduled animations have completed.
		/// </summary>
		/// <param name="finalValue">The final value of the animation variable.</param>
		/// <returns>
		/// If this method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable2-getfinalvalue HRESULT
		// GetFinalValue( [out] DOUBLE *finalValue );
		[PreserveSig]
		HRESULT GetFinalValue(out double finalValue);

		/// <summary>
		/// Gets the final value of the animation variable for the specified dimension. This is the value after all currently scheduled
		/// animations have completed.
		/// </summary>
		/// <param name="finalValue">The final value of the animation variable.</param>
		/// <param name="cDimension">The dimension from which to get the value of the animation variable.</param>
		/// <returns>
		/// If this method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable2-getfinalvectorvalue HRESULT
		// GetFinalVectorValue( [out] DOUBLE *finalValue, [in] UINT cDimension );
		[PreserveSig]
		HRESULT GetFinalVectorValue([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] double[] finalValue, uint cDimension);

		/// <summary>
		/// Gets the previous value of the animation variable. This is the value of the animation variable before the most recent update.
		/// </summary>
		/// <returns>The previous value of the animation variable.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable2-getpreviousvalue HRESULT
		// GetPreviousValue( [out] DOUBLE *previousValue );
		double GetPreviousValue();

		/// <summary>
		/// Gets the previous value of the animation variable for the specified dimension. This is the value of the animation variable
		/// before the most recent update.
		/// </summary>
		/// <param name="previousValue">The previous value of the animation variable.</param>
		/// <param name="cDimension">The dimension from which to get the value of the animation variable.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable2-getpreviousvectorvalue
		// HRESULT GetPreviousVectorValue( [out] DOUBLE *previousValue, [in] UINT cDimension );
		void GetPreviousVectorValue([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] double[] previousValue, uint cDimension);

		/// <summary>Gets the integer value of the animation variable.</summary>
		/// <returns>The value of the animation variable as an integer.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable2-getintegervalue HRESULT
		// GetIntegerValue( [out] INT32 *value );
		int GetIntegerValue();

		/// <summary>Gets the integer value of the animation variable for the specified dimension.</summary>
		/// <param name="value">The value of the animation variable as an integer.</param>
		/// <param name="cDimension">The dimension from which to get the value of the animation variable.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable2-getintegervectorvalue
		// HRESULT GetIntegerVectorValue( [out] INT32 *value, [in] UINT cDimension );
		void GetIntegerVectorValue([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] value, uint cDimension);

		/// <summary>
		/// Gets the final integer value of the animation variable. This is the value after all currently scheduled animations have completed.
		/// </summary>
		/// <param name="finalValue">The final value of the animation variable as an integer.</param>
		/// <returns>
		/// If this method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable2-getfinalintegervalue HRESULT
		// GetFinalIntegerValue( [out] INT32 *finalValue );
		[PreserveSig]
		HRESULT GetFinalIntegerValue(out int finalValue);

		/// <summary>
		/// Gets the final integer value of the animation variable for the specified dimension. This is the value after all currently
		/// scheduled animations have completed.
		/// </summary>
		/// <param name="finalValue">The final value of the animation variable as an integer.</param>
		/// <param name="cDimension">The dimension from which to get the value of the animation variable.</param>
		/// <returns>
		/// If this method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable2-getfinalintegervectorvalue
		// HRESULT GetFinalIntegerVectorValue( [out] INT32 *finalValue, [in] UINT cDimension );
		[PreserveSig]
		HRESULT GetFinalIntegerVectorValue([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] finalValue, uint cDimension);

		/// <summary>
		/// Gets the previous integer value of the animation variable in the specified dimension. This is the value of the animation
		/// variable before the most recent update.
		/// </summary>
		/// <returns>The previous value of the animation variable as an integer.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable2-getpreviousintegervalue
		// HRESULT GetPreviousIntegerValue( [out] INT32 *previousValue );
		int GetPreviousIntegerValue();

		/// <summary>
		/// Gets the previous integer value of the animation variable for the specified dimension. This is the value of the animation
		/// variable before the most recent update.
		/// </summary>
		/// <param name="previousValue">The previous value of the animation variable as an integer.</param>
		/// <param name="cDimension">The dimension from which to get the value of the animation variable.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable2-getpreviousintegervectorvalue
		// HRESULT GetPreviousIntegerVectorValue( [out] INT32 *previousValue, [in] UINT cDimension );
		void GetPreviousIntegerVectorValue([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] previousValue, uint cDimension);

		/// <summary>Gets the active storyboard for the animation variable.</summary>
		/// <returns>The active storyboard, or NULL if the animation variable is not being animated.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable2-getcurrentstoryboard HRESULT
		// GetCurrentStoryboard( [out] IUIAnimationStoryboard2 **storyboard );
		IUIAnimationStoryboard2? GetCurrentStoryboard();

		/// <summary>
		/// Sets the lower bound (floor) for the value of the animation variable. The value of the animation variable should not fall below
		/// the specified value.
		/// </summary>
		/// <param name="bound">The lower bound for the value of the animation variable.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable2-setlowerbound HRESULT
		// SetLowerBound( [in] DOUBLE bound );
		void SetLowerBound(double bound);

		/// <summary>
		/// Sets the lower bound (floor) value of each specified dimension for the animation variable. The value of each animation variable
		/// should not fall below its lower bound.
		/// </summary>
		/// <param name="bound">A vector (of size <c>cDimension</c>) that contains the lower bound values of each dimension.</param>
		/// <param name="cDimension">
		/// The number of dimensions that require lower bound values. This parameter specifies the number of values listed in <c>bound</c>.
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable2-setlowerboundvector HRESULT
		// SetLowerBoundVector( [in] const DOUBLE *bound, [in] UINT cDimension );
		void SetLowerBoundVector([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] double[] bound, uint cDimension);

		/// <summary>
		/// Sets the upper bound (ceiling) for the value of the animation variable. The value of the animation variable should not rise
		/// above the specified value.
		/// </summary>
		/// <param name="bound">The upper bound for the value of the animation variable.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable2-setupperbound HRESULT
		// SetUpperBound( [in] DOUBLE bound );
		void SetUpperBound(double bound);

		/// <summary>
		/// Sets the upper bound (ceiling) value of each specified dimension for the animation variable. The value of each animation
		/// variable should not rise above its upper bound.
		/// </summary>
		/// <param name="bound">A vector (of size <c>cDimension</c>) that contains the upper bound values of each dimension.</param>
		/// <param name="cDimension">
		/// The number of dimensions that require upper bound values. This parameter specifies the number of values listed in <c>bound</c>.
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable2-setupperboundvector HRESULT
		// SetUpperBoundVector( [in] const DOUBLE *bound, [in] UINT cDimension );
		void SetUpperBoundVector([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] double[] bound, uint cDimension);

		/// <summary>Sets the rounding mode of the animation variable.</summary>
		/// <param name="mode">The rounding mode.</param>
		/// <remarks>
		/// An animation variable's rounding mode determines how a floating-point value is converted to an integer. The default mode for
		/// each variable is <c>UI_ANIMATION_ROUNDING_NEAREST</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable2-setroundingmode HRESULT
		// SetRoundingMode( [in] UI_ANIMATION_ROUNDING_MODE mode );
		void SetRoundingMode(UI_ANIMATION_ROUNDING_MODE mode);

		/// <summary>Sets the tag of the animation variable.</summary>
		/// <param name="obj">The object portion of the tag. This parameter can be <c>NULL</c>.</param>
		/// <param name="id">The identifier portion of the tag.</param>
		/// <remarks>
		/// A tag is a pairing of an integer identifier ( <c>id</c>) with a COM object ( <c>object</c>), and it can be used by an
		/// application to identify an animation variable. Because <c>NULL</c> is a valid object component of a tag, the <c>object</c>
		/// parameter can be <c>NULL</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable2-settag HRESULT SetTag( [in,
		// optional] IUnknown *object, [in] UINT32 id );
		void SetTag([MarshalAs(UnmanagedType.IUnknown)] object? obj, uint id);

		/// <summary>Gets the tag of the animation variable.</summary>
		/// <param name="obj">The object portion of the tag.</param>
		/// <param name="id">The identifier portion of the tag.</param>
		/// <returns>
		/// If this method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </returns>
		/// <remarks>
		/// <para>
		/// A tag is a pairing of an integer identifier ( <c>id</c>) with a COM object ( <c>object</c>); it can be used by an application to
		/// identify an animation variable.
		/// </para>
		/// <para>
		/// The parameters are optional, so that the method can return both portions of the tag, or just the identifier or object portion.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable2-gettag HRESULT GetTag( [out,
		// optional] IUnknown **object, [out, optional] UINT32 *id );
		[PreserveSig]
		unsafe HRESULT GetTag([Out, Optional] IntPtr* obj, [Out, Optional] uint* id);

		/// <summary>Specifies a handler for changes to the value of the animation variable.</summary>
		/// <param name="handler">The handler for changes to the value of the animation variable. This parameter can be <c>NULL</c>.</param>
		/// <param name="fRegisterForNextAnimationEvent">
		/// If <c>TRUE</c>, specifies that the EstimateNextEventTime method will incorporate <c>handler</c> into its estimate of the time
		/// interval until the next animation event. No default value.
		/// </param>
		/// <remarks>
		/// Passing <c>NULL</c> for the <c>handler</c> parameter causes Windows Animation to release its reference to any handler object
		/// that you passed in earlier. This technique can be essential for breaking reference cycles without having to call the
		/// IUIAnimationManager2::Shutdown method.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable2-setvariablechangehandler
		// HRESULT SetVariableChangeHandler( [in, optional] IUIAnimationVariableChangeHandler2 *handler, [in] BOOL
		// fRegisterForNextAnimationEvent );
		void SetVariableChangeHandler(IUIAnimationVariableChangeHandler2? handler, [MarshalAs(UnmanagedType.Bool)] bool fRegisterForNextAnimationEvent);

		/// <summary>Specifies a handler for changes to the integer value of the animation variable.</summary>
		/// <param name="handler">
		/// A pointer to the handler for changes to the integer value of the animation variable. This parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="fRegisterForNextAnimationEvent">
		/// If <c>TRUE</c>, specifies that the EstimateNextEventTime method will incorporate <c>handler</c> into its estimate of the time
		/// interval until the next animation event. No default value.
		/// </param>
		/// <remarks>
		/// <para>
		/// Passing <c>NULL</c> for the <c>handler</c> parameter causes Windows Animation to release its reference to any handler object
		/// that you passed in earlier. This technique can be essential for breaking reference cycles without having to call the Shutdown method.
		/// </para>
		/// <para>
		/// IUIAnimationVariableIntegerChangeHandler2::OnIntegerValueChanged is called only if the rounded value has changed since the last update.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable2-setvariableintegerchangehandler
		// HRESULT SetVariableIntegerChangeHandler( [in, optional] IUIAnimationVariableIntegerChangeHandler2 *handler, [in] BOOL
		// fRegisterForNextAnimationEvent );
		void SetVariableIntegerChangeHandler(IUIAnimationVariableIntegerChangeHandler2? handler, [MarshalAs(UnmanagedType.Bool)] bool fRegisterForNextAnimationEvent);

		/// <summary>Specifies a handler for changes to the animation curve of the animation variable.</summary>
		/// <param name="handler">
		/// A pointer to the handler for changes to the animation curve of the animation variable. This parameter can be <c>NULL</c>.
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariable2-setvariablecurvechangehandler
		// HRESULT SetVariableCurveChangeHandler( [in, optional] IUIAnimationVariableCurveChangeHandler2 *handler );
		void SetVariableCurveChangeHandler(IUIAnimationVariableCurveChangeHandler2? handler);
	}

	/// <summary>
	/// Defines a method for handling animation variable update events. <c>IUIAnimationVariableChangeHandler2</c> handles events that occur
	/// in a specified dimension.
	/// </summary>
	/// <remarks>
	/// <para>The OnValueChanged method receives animation variable value updates as <c>DOUBLE</c> values.</para>
	/// <para>
	/// To receive value updates as <c>INT32</c> values, use the IUIAnimationVariableIntegerChangeHandler2::OnIntegerValueChanged method.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nn-uianimation-iuianimationvariablechangehandler2
	[PInvokeData("uianimation.h", MSDNShortId = "NN:uianimation.IUIAnimationVariableChangeHandler2")]
	[ComImport, Guid("63ACC8D2-6EAE-4BB0-B879-586DD8CFBE42"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !NET5_0
	[SupportedOSPlatform("windows8.0")]
#endif
	public interface IUIAnimationVariableChangeHandler2
	{
		/// <summary>Handles events that occur when the value of an animation variable changes in the specified dimension.</summary>
		/// <param name="storyboard">The storyboard that is animating the animation variable specified by the <c>variable</c> parameter.</param>
		/// <param name="variable">The animation variable that has been updated.</param>
		/// <param name="newValue">The new value of the animation variable.</param>
		/// <param name="previousValue">The previous value of the animation variable.</param>
		/// <param name="cDimension">The dimension in which the value of the animation variable changed.</param>
		/// <returns>
		/// If this method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method receives updates as <c>DOUBLE</c> values. To receive updates as <c>INT32</c> values, use the
		/// IUIAnimationVariableIntegerChangeHandler2::OnIntegerValueChanged method.
		/// </para>
		/// <para>
		/// By default, a call made in a callback method to any other animation method results in the call failing and returning
		/// <c>UI_E_ILLEGAL_REENTRANCY</c>. However, there are exceptions to this default. The following methods can be successfully called
		/// from <c>IUIAnimationVariableChangeHandler2::OnValueChanged</c>:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>IUIAnimationVariable2::GetValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable2::GetFinalValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable2::GetPreviousValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable2::GetIntegerValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable2::GetFinalIntegerValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable2::GetPreviousIntegerValue</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable2::GetCurrentStoryboard</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationVariable2::GetTag</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationManager2::GetVariableFromTag</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationManager2::GetStoryboardFromTag</description>
		/// </item>
		/// <item>
		/// <description>IUIAnimationStoryboard2::GetTag</description>
		/// </item>
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
		/// <description>IUIAnimationVariable::GetTag</description>
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
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariablechangehandler2-onvaluechanged
		// HRESULT OnValueChanged( [in] IUIAnimationStoryboard2 *storyboard, [in] IUIAnimationVariable2 *variable, [in] DOUBLE *newValue,
		// [in] DOUBLE *previousValue, [in] UINT cDimension );
		[PreserveSig]
		HRESULT OnValueChanged(IUIAnimationStoryboard2 storyboard, IUIAnimationVariable2 variable, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] double[] newValue, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] double[] previousValue, uint cDimension);
	}

	/// <summary>Defines a method for handling animation curve update events.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nn-uianimation-iuianimationvariablecurvechangehandler2
	[PInvokeData("uianimation.h", MSDNShortId = "NN:uianimation.IUIAnimationVariableCurveChangeHandler2")]
	[ComImport, Guid("72895E91-0145-4C21-9192-5AAB40EDDF80"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !NET5_0
	[SupportedOSPlatform("windows8.0")]
#endif
	public interface IUIAnimationVariableCurveChangeHandler2
	{
		/// <summary>Handles events that occur when the animation curve of an animation variable changes.</summary>
		/// <param name="variable">The animation variable for which the animation curve has been updated.</param>
		/// <returns>
		/// If this method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariablecurvechangehandler2-oncurvechanged
		// HRESULT OnCurveChanged( [in] IUIAnimationVariable2 *variable );
		[PreserveSig]
		HRESULT OnCurveChanged(IUIAnimationVariable2 variable);
	}

	/// <summary>
	/// Defines a method for handling animation variable update events. <c>IUIAnimationVariableIntegerChangeHandler2</c> handles events that
	/// occur in a specified dimension.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nn-uianimation-iuianimationvariableintegerchangehandler2
	[PInvokeData("uianimation.h", MSDNShortId = "NN:uianimation.IUIAnimationVariableIntegerChangeHandler2")]
	[ComImport, Guid("829B6CF1-4F3A-4412-AE09-B243EB4C6B58"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !NET5_0
	[SupportedOSPlatform("windows8.0")]
#endif
	public interface IUIAnimationVariableIntegerChangeHandler2
	{
		/// <summary>Handles events that occur when the integer value of an animation variable changes in the specified dimension.</summary>
		/// <param name="storyboard">The storyboard that is animating the animation variable specified by the <c>variable</c> parameter.</param>
		/// <param name="variable">The animation variable that has been updated.</param>
		/// <param name="newValue">
		/// <para>The new integer value of the animation variable.</para>
		/// <para><c>Note</c>  The rounding mode for an animation variable is specified using the SetRoundingMode method.</para>
		/// <para></para>
		/// </param>
		/// <param name="previousValue">
		/// <para>The previous integer value of the animation variable.</para>
		/// <para><c>Note</c>  The rounding mode for an animation variable is specified using the SetRoundingMode method.</para>
		/// <para></para>
		/// </param>
		/// <param name="cDimension">The dimension in which the integer value of the animation variable changed.</param>
		/// <returns>
		/// If this method succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See Windows Animation Error Codes
		/// for a list of error codes.
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method receives updates as <c>INT32</c> values. To receive updates as <c>DOUBLE</c> values, use the OnValueChanged method.
		/// </para>
		/// <para>
		/// <c>OnIntegerValueChanged</c> events might occur less frequently than OnValueChanged events because values such as 2.2, 2.3, and
		/// 2.4 would all be rounded to the same integer.
		/// </para>
		/// <para>
		/// By default, a call made in a callback method to any other animation method results in the call failing and returning
		/// <c>UI_E_ILLEGAL_REENTRANCY</c>. However, there are exceptions to this default. The following methods can be successfully called
		/// from <c>OnIntegerValueChanged</c>:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>GetValue</description>
		/// </item>
		/// <item>
		/// <description>GetFinalValue</description>
		/// </item>
		/// <item>
		/// <description>GetPreviousValue</description>
		/// </item>
		/// <item>
		/// <description>GetIntegerValue</description>
		/// </item>
		/// <item>
		/// <description>GetFinalIntegerValue</description>
		/// </item>
		/// <item>
		/// <description>GetPreviousIntegerValue</description>
		/// </item>
		/// <item>
		/// <description>GetCurrentStoryboard</description>
		/// </item>
		/// <item>
		/// <description>GetVariableFromTag</description>
		/// </item>
		/// <item>
		/// <description>GetStoryboardFromTag</description>
		/// </item>
		/// <item>
		/// <description>GetTag</description>
		/// </item>
		/// <item>
		/// <description>GetTag</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/uianimation/nf-uianimation-iuianimationvariableintegerchangehandler2-onintegervaluechanged
		// HRESULT OnIntegerValueChanged( [in] IUIAnimationStoryboard2 *storyboard, [in] IUIAnimationVariable2 *variable, [in] INT32
		// *newValue, [in] INT32 *previousValue, [in] UINT cDimension );
		[PreserveSig]
		HRESULT OnIntegerValueChanged(IUIAnimationStoryboard2 storyboard, IUIAnimationVariable2 variable, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] int[] newValue, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] int[] previousValue, uint cDimension);
	}

	/// <summary>Gets the tag for a storyboard.</summary>
	/// <param name="this">The <see cref="IUIAnimationStoryboard2"/> instance.</param>
	/// <param name="obj">The object portion of the tag.</param>
	/// <param name="id">The identifier portion of the tag.</param>
	/// <remarks>
	/// <para>
	/// A tag is a pairing of an integer identifier ( <c>id</c>) with a COM object ( <c>object</c>); it can be used by an application to
	/// identify a storyboard.
	/// </para>
	/// <para>The parameters are optional so that the method can return both portions of the tag, or just the identifier or object portion.</para>
	/// </remarks>
	[SupportedOSPlatform("windows8.0")]
	public static void GetTag(this IUIAnimationStoryboard2 @this, out object? obj, out uint? id)
	{ unsafe { GetTag(@this.GetTag, out obj, out id); } }

	/// <summary>Gets the tag for a storyboard.</summary>
	/// <param name="this">The <see cref="IUIAnimationStoryboard2"/> instance.</param>
	/// <param name="obj">The object portion of the tag.</param>
	/// <remarks>
	/// <para>
	/// A tag is a pairing of an integer identifier ( <c>id</c>) with a COM object ( <c>object</c>); it can be used by an application to
	/// identify a storyboard.
	/// </para>
	/// <para>The parameters are optional so that the method can return both portions of the tag, or just the identifier or object portion.</para>
	/// </remarks>
	[SupportedOSPlatform("windows8.0")]
	public static void GetTag(this IUIAnimationStoryboard2 @this, out object? obj)
	{ unsafe { GetTag(@this.GetTag, out obj); } }

	/// <summary>Gets the tag for a storyboard.</summary>
	/// <param name="this">The <see cref="IUIAnimationStoryboard2"/> instance.</param>
	/// <param name="id">The identifier portion of the tag.</param>
	/// <remarks>
	/// <para>
	/// A tag is a pairing of an integer identifier ( <c>id</c>) with a COM object ( <c>object</c>); it can be used by an application to
	/// identify a storyboard.
	/// </para>
	/// <para>The parameters are optional so that the method can return both portions of the tag, or just the identifier or object portion.</para>
	/// </remarks>
	[SupportedOSPlatform("windows8.0")]
	public static void GetTag(this IUIAnimationStoryboard2 @this, out uint? id)
	{ unsafe { GetTag(@this.GetTag, out id); } }

	/// <summary>Gets the tag for an animation variable.</summary>
	/// <param name="this">The <see cref="IUIAnimationVariable2"/> instance.</param>
	/// <param name="obj">The object portion of the tag.</param>
	/// <param name="id">The identifier portion of the tag.</param>
	/// <remarks>
	/// <para>
	/// A tag is a pairing of an integer identifier ( <c>id</c>) with a COM object ( <c>object</c>); it can be used by an application to
	/// identify an animation variable.
	/// </para>
	/// <para>The parameters are optional so that the method can return both portions of the tag, or just the identifier or object portion.</para>
	/// </remarks>
	[SupportedOSPlatform("windows8.0")]
	public static void GetTag(this IUIAnimationVariable2 @this, out object? obj, out uint? id)
	{ unsafe { GetTag(@this.GetTag, out obj, out id); } }

	/// <summary>Gets the tag for an animation variable.</summary>
	/// <param name="this">The <see cref="IUIAnimationVariable2"/> instance.</param>
	/// <param name="obj">The object portion of the tag.</param>
	/// <remarks>
	/// <para>
	/// A tag is a pairing of an integer identifier ( <c>id</c>) with a COM object ( <c>object</c>); it can be used by an application to
	/// identify an animation variable.
	/// </para>
	/// <para>The parameters are optional so that the method can return both portions of the tag, or just the identifier or object portion.</para>
	/// </remarks>
	[SupportedOSPlatform("windows8.0")]
	public static void GetTag(this IUIAnimationVariable2 @this, out object? obj)
	{ unsafe { GetTag(@this.GetTag, out obj); } }

	/// <summary>Gets the tag for an animation variable.</summary>
	/// <param name="this">The <see cref="IUIAnimationVariable2"/> instance.</param>
	/// <param name="id">The identifier portion of the tag.</param>
	/// <remarks>
	/// <para>
	/// A tag is a pairing of an integer identifier ( <c>id</c>) with a COM object ( <c>object</c>); it can be used by an application to
	/// identify an animation variable.
	/// </para>
	/// <para>The parameters are optional so that the method can return both portions of the tag, or just the identifier or object portion.</para>
	/// </remarks>
	[SupportedOSPlatform("windows8.0")]
	public static void GetTag(this IUIAnimationVariable2 @this, out uint? id)
	{ unsafe { GetTag(@this.GetTag, out id); } }

	/// <summary>CLSID_UIAnimationManager2</summary>
	[ComImport, Guid("D25D8842-8884-4A4A-B321-091314379BDD"), ClassInterface(ClassInterfaceType.None)]
	public class UIAnimationManager2
	{
	}

	/// <summary>CLSID_UIAnimationTransitionFactory2</summary>
	[ComImport, Guid("84302F97-7F7B-4040-B190-72AC9D18E420"), ClassInterface(ClassInterfaceType.None)]
	public class UIAnimationTransitionFactory2
	{
	}

	/// <summary>CLSID_UIAnimationTransitionLibrary2</summary>
	[ComImport, Guid("812F944A-C5C8-4CD9-B0A6-B3DA802F228D"), ClassInterface(ClassInterfaceType.None)]
	public class UIAnimationTransitionLibrary2
	{
	}
}