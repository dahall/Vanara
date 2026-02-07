namespace Vanara.PInvoke;

/// <summary>Items from the Dcomp.dll.</summary>
public static partial class Dcomp
{
	/// <summary>
	/// Represents a function for animating one or more properties of one or more Microsoft DirectComposition objects. Any object property
	/// that takes a scalar value can be animated.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcompanimation/nn-dcompanimation-idcompositionanimation
	[PInvokeData("dcompanimation.h", MSDNShortId = "NN:dcompanimation.IDCompositionAnimation")]
	[ComImport, Guid("CBFD91D9-51B2-45e4-B3DE-D19CCFB863C5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionAnimation
	{
		/// <summary>Resets the animation function so that it contains no segments.</summary>
		/// <remarks>
		/// This method returns the animation function to a clean state, as when the animation was first constructed. After this method is
		/// called, the next segment to be added becomes the first segment of the animation function. Because it is the first segment, it can
		/// have any non-negative beginning offset.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcompanimation/nf-dcompanimation-idcompositionanimation-reset HRESULT Reset();
		void Reset();

		/// <summary>Sets the absolute time at which the animation function starts.</summary>
		/// <param name="beginTime">
		/// <para>Type: <b><c>LARGE_INTEGER</c></b></para>
		/// <para>The starting time for this animation.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// By default, an animation function starts when the first frame of the animation takes effect. For example, if an application
		/// creates a simple animation function with a single primitive at offset zero, associates the animation with some property, and then
		/// calls the <c>IDCompositionDevice::Commit</c> method, the first frame that includes the commit samples the animation at offset
		/// zero for the first primitive.
		/// </para>
		/// <para>
		/// This implies that the actual default start time of all animations varies depending on the time between when the application
		/// creates the animation and calls <b>Commit</b>, to the time it takes the composition engine to pick up the committed changes. The
		/// application can use the <b>SetAbsoluteBeginTime</b> method to exercise finer control over the starting time of an animation.
		/// </para>
		/// <para>
		/// This method does not control when animations take effect; it only affects how animations are sampled after they start. If the
		/// application specifies the exact time of the next frame as the absolute begin time, the result is the same as not calling this
		/// method at all. If the specified begin time is different from the time of the next frame, the result is one of following:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// If the specified time is later than the next frame time, the animation start is delayed until the specified begin time.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If the specified time is earlier than the next frame time, the beginning of the animation is dropped and sampling starts into the
		/// animation function.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcompanimation/nf-dcompanimation-idcompositionanimation-setabsolutebegintime
		// HRESULT SetAbsoluteBeginTime( [in] LARGE_INTEGER beginTime );
		void SetAbsoluteBeginTime(long beginTime);

		/// <summary>Adds a cubic polynomial segment to the animation function.</summary>
		/// <param name="beginOffset">
		/// <para>Type: <b>double</b></para>
		/// <para>The offset, in seconds, from the beginning of the animation function to the point when this segment should take effect.</para>
		/// </param>
		/// <param name="constantCoefficient">
		/// <para>Type: <b>float</b></para>
		/// <para>The constant coefficient of the polynomial.</para>
		/// </param>
		/// <param name="linearCoefficient">
		/// <para>Type: <b>float</b></para>
		/// <para>The linear coefficient of the polynomial.</para>
		/// </param>
		/// <param name="quadraticCoefficient">
		/// <para>Type: <b>float</b></para>
		/// <para>The quadratic coefficient of the polynomial.</para>
		/// </param>
		/// <param name="cubicCoefficient">
		/// <para>Type: <b>float</b></para>
		/// <para>The cubic coefficient of the polynomial.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// A cubic segment transitions time along a cubic polynomial. For a given time input (t), the output value is given by the following equation.
		/// </para>
		/// <para><i>x</i>( <i>t</i>) = <i>at</i>³ + <i>bt</i>² + <i>ct</i> + <i>d</i></para>
		/// <para>This method fails if any of the parameters are NaN, positive infinity, or negative infinity.</para>
		/// <para>
		/// Because animation segments must be added in increasing order, this method fails if the <i>beginOffset</i> parameter is less than
		/// or equal to the <i>beginOffset</i> parameter of the previous segment, if any.
		/// </para>
		/// <para>
		/// This animation segment remains in effect until the begin time of the next segment in the animation function. If the animation
		/// function contains no more segments, this segment remains in effect indefinitely.
		/// </para>
		/// <para>
		/// If all coefficients except <i>constantCoefficient</i> are zero, the value of this segment remains constant over time, and the
		/// animation does not cause a recomposition for the duration of the segment.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example creates an animation function with two cubic polynomial segments.</para>
		/// <para>
		/// <c>HRESULT DoAnimatedRotation(IDCompositionDevice *pDevice, IDCompositionRotateTransform *pRotateTransform, IDCompositionVisual
		/// *pVisual, float animationTime) { HRESULT hr = S_OK; IDCompositionAnimation *pAnimation = nullptr; // Create an animation object.
		/// hr = pDevice-&gt;CreateAnimation(&amp;pAnimation); if (SUCCEEDED(hr)) { // Create the animation function by adding cubic
		/// polynomial segments. // For a given time input (t), the output value is // a*t^3 + b* t^2 + c*t + d. // // The following segment
		/// will rotate the visual clockwise. pAnimation-&gt;AddCubic( 0.0, // Begin offset 0.0, // Constant coefficient - d (360.0f * 1.0f)
		/// / animationTime, // Linear coefficient - c 0.0, // Quadratic coefficient - b 0.0); // Cubic coefficient - a // The following
		/// segment will rotate the visual counterclockwise. pAnimation-&gt;AddCubic( animationTime, 0.0, -(360.0f * 1.0f) / animationTime,
		/// 0.0, 0.0); // Set the end of the animation. pAnimation-&gt;End( 2 * animationTime, // End offset 0.0); // End value // Apply the
		/// animation to the Angle property of the // rotate transform. hr = pRotateTransform-&gt;SetAngle(pAnimation); } if (SUCCEEDED(hr))
		/// { // Apply the rotate transform object to a visual. hr = pVisual-&gt;SetTransform(pRotateTransform); } if (SUCCEEDED(hr)) { //
		/// Commit the changes to the composition. hr = pDevice-&gt;Commit(); } SafeRelease(&amp;pAnimation); return hr; }</c>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcompanimation/nf-dcompanimation-idcompositionanimation-addcubic HRESULT
		// AddCubic( [in] double beginOffset, [in] float constantCoefficient, [in] float linearCoefficient, [in] float quadraticCoefficient,
		// [in] float cubicCoefficient );
		void AddCubic(double beginOffset, float constantCoefficient, float linearCoefficient, float quadraticCoefficient, float cubicCoefficient);

		/// <summary>Adds a sinusoidal segment to the animation function.</summary>
		/// <param name="beginOffset">
		/// <para>Type: <b>double</b></para>
		/// <para>The offset, in seconds, from the beginning of the animation function to the point when this segment should take effect.</para>
		/// </param>
		/// <param name="bias">
		/// <para>Type: <b>float</b></para>
		/// <para>A constant that is added to the sinusoidal.</para>
		/// </param>
		/// <param name="amplitude">
		/// <para>Type: <b>float</b></para>
		/// <para>A scale factor that is applied to the sinusoidal.</para>
		/// </param>
		/// <param name="frequency">
		/// <para>Type: <b>float</b></para>
		/// <para>A scale factor that is applied to the time offset, in Hertz.</para>
		/// </param>
		/// <param name="phase">
		/// <para>Type: <b>float</b></para>
		/// <para>A constant that is added to the time offset, in degrees.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// This method fails if any of the parameters are NaN, positive infinity, or negative infinity, or if the <i>beginOffset</i>
		/// parameter is negative.
		/// </para>
		/// <para>
		/// Because animation segments must be added in increasing order, this method fails if the <i>beginOffset</i> parameter is less than
		/// or equal to the <i>beginOffset</i> parameter of the previous segment, if any.
		/// </para>
		/// <para>
		/// This animation segment remains in effect until the begin time of the next segment in the animation function. If the animation
		/// function contains no more segments, this segment remains in effect indefinitely.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcompanimation/nf-dcompanimation-idcompositionanimation-addsinusoidal HRESULT
		// AddSinusoidal( double beginOffset, float bias, float amplitude, float frequency, float phase );
		void AddSinusoidal(double beginOffset, float bias, float amplitude, float frequency, float phase);

		/// <summary>Adds a repeat segment that causes the specified portion of an animation function to be repeated.</summary>
		/// <param name="beginOffset">
		/// <para>Type: <b>double</b></para>
		/// <para>The offset, in seconds, from the beginning of the animation to the point at which the repeat should begin.</para>
		/// </param>
		/// <param name="durationToRepeat">
		/// <para>Type: <b>double</b></para>
		/// <para>
		/// The duration, in seconds, of a portion of the animation immediately preceding the begin time that is specified by
		/// <i>beginOffset</i>. This is the portion that will be repeated.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>This method fails if any of the parameters are NaN, positive infinity, or negative infinity.</para>
		/// <para>
		/// Because animation segments must be added in increasing order, this method fails if the <i>beginOffset</i> parameter is less than
		/// or equal to the <i>beginOffset</i> parameter of the previous segment. This method also fails if this is the first segment to be
		/// added to the animation function.
		/// </para>
		/// <para>
		/// This animation segment remains in effect until the begin time of the next segment. If the animation function contains no more
		/// segments, this segment remains in effect indefinitely.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example creates an animation function that includes a repeat segment, and applies the animation to the x and y axes
		/// of a scale transform.
		/// </para>
		/// <para>
		/// <c>HRESULT MyCreateAnimatedScaleTransform(IDCompositionDevice *pDevice, IDCompositionVisual *pVisual) { HRESULT hr = S_OK;
		/// IDCompositionAnimation *pAnimation = nullptr; IDCompositionScaleTransform *pScaleTransform = nullptr; // Validate the pointers.
		/// if (pDevice == nullptr || pVisual == nullptr) return E_INVALIDARG; // Create an animation object. hr =
		/// pDevice-&gt;CreateAnimation(&amp;pAnimation); if (SUCCEEDED(hr)) { // Add segments to the animation function.
		/// pAnimation-&gt;AddCubic(0, 1, -0.5, 0, 0); pAnimation-&gt;AddRepeat(3.0, 3.0); pAnimation-&gt;End(10, .5); // Create a scale
		/// transform object. hr = pDevice-&gt;CreateScaleTransform(&amp;pScaleTransform); } if (SUCCEEDED(hr)) { // Apply the animation to
		/// the x and y axes of the scale transform. pScaleTransform-&gt;SetScaleX(pAnimation); pScaleTransform-&gt;SetScaleY(pAnimation); //
		/// Apply the scale transform to the visual. hr = pVisual-&gt;SetTransform(pScaleTransform); } if (SUCCEEDED(hr)) { // Commit the
		/// composition for rendering. hr = pDevice-&gt;Commit(); } // Clean up. SafeRelease(&amp;pAnimation);
		/// SafeRelease(&amp;pScaleTransform); return hr; }</c>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcompanimation/nf-dcompanimation-idcompositionanimation-addrepeat HRESULT
		// AddRepeat( [in] double beginOffset, [in] double durationToRepeat );
		void AddRepeat(double beginOffset, double durationToRepeat);

		/// <summary>Adds an end segment that marks the end of an animation function.</summary>
		/// <param name="endOffset">
		/// <para>Type: <b>double</b></para>
		/// <para>The offset, in seconds, from the beginning of the animation function to the point when the function ends.</para>
		/// </param>
		/// <param name="endValue">
		/// <para>Type: <b>float</b></para>
		/// <para>The final value of the animation.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// If the function succeeds, it returns S_OK. Otherwise, it returns an <b>HRESULT</b> error code. See <c>DirectComposition Error
		/// Codes</c> for a list of error codes.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When the specified offset is reached, the property or properties affected by this animation are set to the specified final value,
		/// and then the animation stops. If no end segment is added, the final segment of the animation function runs indefinitely. Calling
		/// this method is semantically identical to making the last segment of the animation function a cubic polynomial where the cubic,
		/// quadratic, and linear coefficients are all zeros, and the constant coefficient is the desired final value.
		/// </para>
		/// <para>
		/// Because animation segments must be added in increasing order, this method fails if the <i>endOffset</i> parameter is less than or
		/// equal to the <i>beginOffset</i> parameter of the previous segment. This method also fails if this is the first segment to be
		/// added to the animation function.
		/// </para>
		/// <para>
		/// After this method is called, all methods on this animation object fail except the <c>IDCompositionAnimation::Reset</c> method.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcompanimation/nf-dcompanimation-idcompositionanimation-end HRESULT End( [in]
		// double endOffset, [in] float endValue );
		void End(double endOffset, float endValue);
	}
}