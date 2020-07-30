using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Magnification API functions and structures.</summary>
	/// <remarks>
	/// The Magnification API enables applications to magnify the entire screen or portions of the screen, and to apply color effects
	/// </remarks>
	public static partial class Magnification
	{
		/// <summary>The magnifier class window name.</summary>
		public const string WC_MAGNIFIER = "Magnifier";

		private const string Lib_Magnification = "magnification.dll";

		/// <summary>
		/// <para>
		/// <code>hwnd</code>
		/// </para>
		/// <para>Type: <c>HWND</c></para>
		/// <para>The magnification window.</para>
		/// <para>
		/// <code>srcdata</code>
		/// </para>
		/// <para>
		/// <code>srcheader</code>
		/// </para>
		/// <para>Type: <c>MAGIMAGEHEADER</c></para>
		/// <para>The description of the input format.</para>
		/// <para>
		/// <code>destdata</code>
		/// </para>
		/// <para>
		/// <code>destheader</code>
		/// </para>
		/// <para>Type: <c>MAGIMAGEHEADER</c></para>
		/// <para>The description of the output format.</para>
		/// <para>
		/// <code>unclipped</code>
		/// </para>
		/// <para>Type: <c>RECT</c></para>
		/// <para>The coordinates of the scaled version of the source bitmap.</para>
		/// <para>
		/// <code>clipped</code>
		/// </para>
		/// <para>Type: <c>RECT</c></para>
		/// <para>The coordinates of the window to which the scaled bitmap is clipped.</para>
		/// <para>
		/// <code>dirty</code>
		/// </para>
		/// <para>Type: <c>HRGN</c></para>
		/// <para>The region that needs to be refreshed.</para>
		/// </summary>
		/// <param name="hwnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>The magnification window.</para>
		/// </param>
		/// <param name="srcdata"/>
		/// <param name="srcheader">
		/// <para>Type: <c>MAGIMAGEHEADER</c></para>
		/// <para>The description of the input format.</para>
		/// </param>
		/// <param name="destdata"/>
		/// <param name="destheader">
		/// <para>Type: <c>MAGIMAGEHEADER</c></para>
		/// <para>The description of the output format.</para>
		/// </param>
		/// <param name="unclipped">
		/// <para>Type: <c>RECT</c></para>
		/// <para>The coordinates of the scaled version of the source bitmap.</para>
		/// </param>
		/// <param name="clipped">
		/// <para>Type: <c>RECT</c></para>
		/// <para>The coordinates of the window to which the scaled bitmap is clipped.</para>
		/// </param>
		/// <param name="dirty">
		/// <para>Type: <c>HRGN</c></para>
		/// <para>The region that needs to be refreshed.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/magnification/nc-magnification-magimagescalingcallback MagImageScalingCallback
		// Magimagescalingcallback; BOOL Magimagescalingcallback( HWND hwnd, void *srcdata, MAGIMAGEHEADER srcheader, void *destdata,
		// MAGIMAGEHEADER destheader, RECT unclipped, RECT clipped, HRGN dirty ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("magnification.h", MSDNShortId = "NC:magnification.MagImageScalingCallback")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool MagImageScalingCallback(HWND hwnd, IntPtr srcdata, MAGIMAGEHEADER srcheader, IntPtr destdata, MAGIMAGEHEADER destheader, RECT unclipped, RECT clipped, HRGN dirty);

		/// <summary>
		/// This topic describes the styles used with the magnifier control. To create a magnifier control, use the <c>CreateWindowEx</c>
		/// function and specify the WC_MAGNIFIER window class, along with a combination of the following magnifier styles.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/winauto/magapi/magapi-magnifier-styles
		[PInvokeData("magnification.h")]
		public enum MagnifierStyles
		{
			/// <term>Displays the magnified system cursor along with the magnified screen content.</term>
			MS_SHOWMAGNIFIEDCURSOR = 0x0001,

			/// <term>
			/// Clips the area of the magnifier window that surrounds the system cursor. This style enables the user to see screen content
			/// that is behind the magnifier window.
			/// </term>
			MS_CLIPAROUNDCURSOR = 0x0002,

			/// <term>Displays the magnified screen content using inverted colors.</term>
			MS_INVERTCOLORS = 0x0004,
		}

		/// <summary>The magnification filter mode.</summary>
		[PInvokeData("magnification.h", MSDNShortId = "NF:magnification.MagSetWindowFilterList")]
		public enum MW_FILTERMODE
		{
			/// <summary>Exclude the windows from magnification.</summary>
			MW_FILTERMODE_EXCLUDE = 0,

			/// <summary>Magnify the windows.</summary>
			MW_FILTERMODE_INCLUDE = 1
		}

		/// <summary>Gets the color transformation matrix for a magnifier control.</summary>
		/// <param name="hwnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>The magnification window.</para>
		/// </param>
		/// <param name="pEffect">
		/// <para>Type: <c>PMAGCOLOREFFECT</c></para>
		/// <para>The color transformation matrix, or <c>NULL</c> if no color effect has been set.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </returns>
		/// <remarks>
		/// <para>The magnifier control uses the color transformation matrix to apply a color effect to the entire magnifier window.</para>
		/// <para>This function requires Windows Display Driver Model (WDDM)-capable video cards.</para>
		/// <para>Examples</para>
		/// <para>The following example retrieves the color transformation matrix.</para>
		/// <para>
		/// <code>// Description: // Retrieves the color transformation matrix from a magnifier control. // Parameters: // hwndMag - handle of the magnifier control. // BOOL GetMagnifierColorTransform(HWND hwndMag) { MAGCOLOREFFECT effect; BOOL ret = MagGetColorEffect(hwndMag, &amp;effect); // // Do something with the color data. // return ret; }</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/magnification/nf-magnification-maggetcoloreffect BOOL MagGetColorEffect( HWND
		// hwnd, PMAGCOLOREFFECT pEffect );
		[DllImport(Lib_Magnification, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("magnification.h", MSDNShortId = "NF:magnification.MagGetColorEffect")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool MagGetColorEffect(HWND hwnd, out MAGCOLOREFFECT pEffect);

		/// <summary>Retrieves the color transformation matrix associated with the full-screen magnifier.</summary>
		/// <param name="pEffect">
		/// <para>Type: <c>PMAGCOLOREFFECT</c></para>
		/// <para>The color transformation matrix, or the identity matrix if no color effect has been set.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns TRUE if successful, or FALSE otherwise.</para>
		/// </returns>
		/// <remarks>
		/// <para>The full-screen magnifier uses the color transformation matrix to apply a color effect to the entire screen.</para>
		/// <para>Examples</para>
		/// <para>The following example retrieves the color transformation matrix associated with the full-screen magnifier.</para>
		/// <para>
		/// <code> // Get the current color effect. MAGCOLOREFFECT magEffect; if (!MagGetFullscreenColorEffect(&amp;magEffect)) return E_FAIL;</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/magnification/nf-magnification-maggetfullscreencoloreffect BOOL
		// MagGetFullscreenColorEffect( PMAGCOLOREFFECT pEffect );
		[DllImport(Lib_Magnification, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("magnification.h", MSDNShortId = "NF:magnification.MagGetFullscreenColorEffect")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool MagGetFullscreenColorEffect(out MAGCOLOREFFECT pEffect);

		/// <summary>Retrieves the magnification settings for the full-screen magnifier.</summary>
		/// <param name="pMagLevel">
		/// <para>Type: <c>float*</c></para>
		/// <para>
		/// The current magnification factor for the full-screen magnifier. A value of 1.0 indicates that the screen content is not being
		/// magnified. A value above 1.0 indicates the scale factor for magnification. A value less than 1.0 is not valid.
		/// </para>
		/// </param>
		/// <param name="pxOffset">
		/// <para>Type: <c>int*</c></para>
		/// <para>
		/// The x-coordinate offset for the upper-left corner of the unmagnified view. The offset is relative to the upper-left corner of
		/// the primary monitor, in unmagnified coordinates.
		/// </para>
		/// </param>
		/// <param name="pyOffset">
		/// <para>Type: <c>int*</c></para>
		/// <para>
		/// The y-coordinate offset for the upper-left corner of the unmagnified view. The offset is relative to the upper-left corner of
		/// the primary monitor, in unmagnified coordinates.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns TRUE if successful, or FALSE otherwise.</para>
		/// </returns>
		/// <remarks>
		/// <para>The offsets are not affected by the current dots per inch (dpi) setting.</para>
		/// <para>Examples</para>
		/// <para>The following code snippet retrieves the magnification value and offsets for the full-screen magnifier.</para>
		/// <para>
		/// <code> // Get the current magnification level and offset. float magLevel; int xOffset, yOffset; if (!MagGetFullscreenTransform(&amp;magLevel, &amp;xOffset, &amp;yOffset)) { return E_FAIL; } // // Do something with the magnification settings. //</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/magnification/nf-magnification-maggetfullscreentransform BOOL
		// MagGetFullscreenTransform( float *pMagLevel, int *pxOffset, int *pyOffset );
		[DllImport(Lib_Magnification, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("magnification.h", MSDNShortId = "NF:magnification.MagGetFullscreenTransform")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool MagGetFullscreenTransform(out float pMagLevel, out int pxOffset, out int pyOffset);

		/// <summary>Retrieves the registered callback function that implements a custom transform for image scaling.</summary>
		/// <param name="hwnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>The magnification window.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>MagImageScalingCallback</c></para>
		/// <para>Returns the registered MagImageScalingCallback callback function, or <c>NULL</c> if no callback is registered.</para>
		/// </returns>
		/// <remarks>
		/// <para>This function returns <c>NULL</c> if Windows Display Driver Model (WDDM) is not supported.</para>
		/// <para>This function works only when Desktop Window Manager (DWM) is off.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/magnification/nf-magnification-maggetimagescalingcallback
		// MagImageScalingCallback MagGetImageScalingCallback( HWND hwnd );
		[DllImport(Lib_Magnification, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("magnification.h", MSDNShortId = "NF:magnification.MagGetImageScalingCallback")]
		public static extern MagImageScalingCallback MagGetImageScalingCallback(HWND hwnd);

		/// <summary>
		/// Retrieves the current input transformation for pen and touch input, represented as a source rectangle and a destination rectangle.
		/// </summary>
		/// <param name="pfEnabled">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>TRUE if input translation is enabled, or FALSE if not.</para>
		/// </param>
		/// <param name="pRectSource">
		/// <para>Type: <c>LPRECT</c></para>
		/// <para>The source rectangle, in unmagnified screen coordinates, that defines the area of the screen that is magnified.</para>
		/// </param>
		/// <param name="pRectDest">
		/// <para>Type: <c>LPRECT</c></para>
		/// <para>
		/// The destination rectangle, in screen coordinates, that defines the area of the screen where the magnified screen content is
		/// displayed. Pen and touch input in this rectangle is mapped to the source rectangle.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns TRUE if successful, or FALSE otherwise.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The input transformation maps the coordinate space of the magnified screen content to the actual (unmagnified) screen coordinate
		/// space. This enables the system to pass touch and pen input that is entered in magnified screen content, to the correct UI
		/// element on the screen. For example, without input transformation, input is passed to the element located at the unmagnified
		/// screen coordinates, not to the item that appears in the magnified screen content.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example retrieves the current input translation settings.</para>
		/// <para>
		/// <code>// Description: // Retrieves the current input transform. // BOOL GetInputTranform() { BOOL fInputTransformEnabled; RECT rcSource; RECT rcTarget; BOOL fResult = MagGetInputTransform(&amp;fInputTransformEnabled, &amp;rcSource, &amp;rcTarget); if (fResult) { // // Do something with the input transform data. // } return fResult; }</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/magnification/nf-magnification-maggetinputtransform BOOL MagGetInputTransform(
		// BOOL *pfEnabled, LPRECT pRectSource, LPRECT pRectDest );
		[DllImport(Lib_Magnification, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("magnification.h", MSDNShortId = "NF:magnification.MagGetInputTransform")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool MagGetInputTransform([MarshalAs(UnmanagedType.Bool)] out bool pfEnabled, out RECT pRectSource, out RECT pRectDest);

		/// <summary>Retrieves the list of windows that are magnified or excluded from magnification.</summary>
		/// <param name="hwnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>The magnification window.</para>
		/// </param>
		/// <param name="pdwFilterMode">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>The filter mode, as set by MagSetWindowFilterList.</para>
		/// </param>
		/// <param name="count">
		/// <para>Type: <c>int</c></para>
		/// <para>The number of windows to retrieve, or 0 to retrieve a count of windows in the filter list.</para>
		/// </param>
		/// <param name="pHWND">
		/// <para>Type: <c>HWND*</c></para>
		/// <para>The list of window handles.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>int</c></para>
		/// <para>Returns the count of window handles in the filter list, or -1 if the hwnd parameter is not valid.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// First call the method with a count of 0 to retrieve the count of windows in the filter list. Use the retrieved count to allocate
		/// sufficient memory for the retrieved list of window handles.
		/// </para>
		/// <para>This function requires Windows Display Driver Model (WDDM)-capable video cards.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/magnification/nf-magnification-maggetwindowfilterlist int
		// MagGetWindowFilterList( HWND hwnd, DWORD *pdwFilterMode, int count, HWND *pHWND );
		[DllImport(Lib_Magnification, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("magnification.h", MSDNShortId = "NF:magnification.MagGetWindowFilterList")]
		public static extern int MagGetWindowFilterList(HWND hwnd, out MW_FILTERMODE pdwFilterMode, int count, [Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 2)] HWND[] pHWND);

		/// <summary>Gets the rectangle of the area that is being magnified.</summary>
		/// <param name="hwnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>The magnification window.</para>
		/// </param>
		/// <param name="pRect">
		/// <para>Type: <c>RECT*</c></para>
		/// <para>The rectangle that is being magnified, in desktop coordinates.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/magnification/nf-magnification-maggetwindowsource BOOL MagGetWindowSource(
		// HWND hwnd, RECT *pRect );
		[DllImport(Lib_Magnification, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("magnification.h", MSDNShortId = "NF:magnification.MagGetWindowSource")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool MagGetWindowSource(HWND hwnd, out RECT pRect);

		/// <summary>Retrieves the transformation matrix associated with a magnifier control.</summary>
		/// <param name="hwnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>The magnification window.</para>
		/// </param>
		/// <param name="pTransform">
		/// <para>Type: <c>PMAGTRANSFORM</c></para>
		/// <para>The transformation matrix.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </returns>
		/// <remarks>
		/// The transformation matrix specifies the magnification factor that the magnifier control applies to the contents of the source rectangle.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/magnification/nf-magnification-maggetwindowtransform BOOL
		// MagGetWindowTransform( HWND hwnd, PMAGTRANSFORM pTransform );
		[DllImport(Lib_Magnification, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("magnification.h", MSDNShortId = "NF:magnification.MagGetWindowTransform")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool MagGetWindowTransform(HWND hwnd, out MAGTRANSFORM pTransform);

		/// <summary>Creates and initializes the magnifier run-time objects.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if initialization was successful; otherwise <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/magnification/nf-magnification-maginitialize BOOL MagInitialize();
		[DllImport(Lib_Magnification, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("magnification.h", MSDNShortId = "NF:magnification.MagInitialize")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool MagInitialize();

		/// <summary>Sets the color transformation matrix for a magnifier control.</summary>
		/// <param name="hwnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>The magnification window.</para>
		/// </param>
		/// <param name="pEffect">
		/// <para>Type: <c>PMAGCOLOREFFECT</c></para>
		/// <para>The color transformation matrix, or <c>NULL</c> to remove the current color effect, if any.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The magnifier control uses the color transformation matrix to apply a color effect to the entire magnifier window. If the
		/// function is called multiple times, the most recent color transform is used.
		/// </para>
		/// <para>This function requires Windows Display Driver Model (WDDM)-capable video cards.</para>
		/// <para>Examples</para>
		/// <para>The following example sets a color transformation matrix that converts the colors displayed in the magnifier to grayscale.</para>
		/// <para>
		/// <code>// Description: // Converts the colors displayed in the magnifier window to grayscale, or // returns the colors to normal. // Parameters: // hwndMag - Handle of the magnifier control. // fInvert - TRUE to convert to grayscale, or FALSE for normal colors. // BOOL ConvertToGrayscale(HWND hwndMag, BOOL fConvert) { // Convert the screen colors in the magnifier window. if (fConvert) { MAGCOLOREFFECT magEffectGrayscale = {{ // MagEffectGrayscale { 0.3f, 0.3f, 0.3f, 0.0f, 0.0f }, { 0.6f, 0.6f, 0.6f, 0.0f, 0.0f }, { 0.1f, 0.1f, 0.1f, 0.0f, 0.0f }, { 0.0f, 0.0f, 0.0f, 1.0f, 0.0f }, { 0.0f, 0.0f, 0.0f, 0.0f, 1.0f } }}; return MagSetColorEffect(hwndMag, &amp;magEffectGrayscale); } // Return the colors to normal. else { return MagSetColorEffect(hwndMag, NULL); } }</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/magnification/nf-magnification-magsetcoloreffect BOOL MagSetColorEffect( HWND
		// hwnd, PMAGCOLOREFFECT pEffect );
		[DllImport(Lib_Magnification, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("magnification.h", MSDNShortId = "NF:magnification.MagSetColorEffect")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool MagSetColorEffect(HWND hwnd, in MAGCOLOREFFECT pEffect);

		/// <summary>Changes the color transformation matrix associated with the full-screen magnifier.</summary>
		/// <param name="pEffect">
		/// <para>Type: <c>PMAGCOLOREFFECT</c></para>
		/// <para>The new color transformation matrix. This parameter must not be NULL.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns TRUE if successful, or FALSE otherwise.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The full-screen magnifier uses the color transformation matrix to apply a color effect to the entire desktop. If the function is
		/// called multiple times, the most recent color transform is used.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example defines two color transformation matrices for use with <c>MagSetFullscreenColorEffect</c>. The
		/// <code>g_MagEffectGrayscale</code>
		/// matrix converts the screen colors to grayscale. The
		/// <code>g_MagEffectIdentity</code>
		/// matrix is the identity matrix, which restores the original screen colors.
		/// </para>
		/// <para>
		/// <code>// Initialize color transformation matrices used to apply grayscale and to // restore the original screen color. MAGCOLOREFFECT g_MagEffectGrayscale = {0.3f, 0.3f, 0.3f, 0.0f, 0.0f, 0.6f, 0.6f, 0.6f, 0.0f, 0.0f, 0.1f, 0.1f, 0.1f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f}; MAGCOLOREFFECT g_MagEffectIdentity = {1.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f}; BOOL SetColorGrayscale(__in BOOL fGrayscaleOn) { // Apply the color matrix required to either apply grayscale to the screen // colors or to show the regular colors. PMAGCOLOREFFECT pEffect = (fGrayscaleOn ? &amp;g_MagEffectGrayscale : &amp;g_MagEffectIdentity); return MagSetFullscreenColorEffect(pEffect); }</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/magnification/nf-magnification-magsetfullscreencoloreffect BOOL
		// MagSetFullscreenColorEffect( PMAGCOLOREFFECT pEffect );
		[DllImport(Lib_Magnification, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("magnification.h", MSDNShortId = "NF:magnification.MagSetFullscreenColorEffect")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool MagSetFullscreenColorEffect(in MAGCOLOREFFECT pEffect);

		/// <summary>Changes the magnification settings for the full-screen magnifier.</summary>
		/// <param name="magLevel">
		/// <para>Type: <c>float</c></para>
		/// <para>
		/// The new magnification factor for the full-screen magnifier. The minimum value of this parameter is 1.0, and the maximum value is
		/// 4096.0. If this value is 1.0, the screen content is not magnified and no offsets are applied.
		/// </para>
		/// </param>
		/// <param name="xOffset">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The new x-coordinate offset, in pixels, for the upper-left corner of the magnified view. The offset is relative to the
		/// upper-left corner of the primary monitor, in unmagnified coordinates. The minimum value of the parameter is -262144, and the
		/// maximum value is 262144.
		/// </para>
		/// </param>
		/// <param name="yOffset">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The new y-coordinate offset, in pixels, for the upper-left corner of the magnified view. The offset is relative to the
		/// upper-left corner of the primary monitor, in unmagnified coordinates. The minimum value of the parameter is -262144, and the
		/// maximum value is 262144.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns TRUE if successful. Otherwise, FALSE.</para>
		/// </returns>
		/// <remarks>
		/// <para>The offsets are not affected by the current dots per inch (dpi) settings.</para>
		/// <para>
		/// The magnification factor is applied to the current mouse cursor visuals, including cursor visuals affected by the mouse-related
		/// settings in the Ease of Access control panel.
		/// </para>
		/// <para>
		/// In a multiple monitor environment, to position the upper-left corner of the magnified view to the left of the primary monitor,
		/// the offsets must be adjusted by the upper-left corner of the virtual screen and the magnification factor being applied. (The
		/// virtual screen is the bounding rectangle of all display monitors.) For an example that shows how to position the upper-left
		/// corner of the magnified view to the left of the primary monitor, see Examples.
		/// </para>
		/// <para>
		/// Beginning with Windows 10 Creators Update (version 1703), you must use the MagSetInputTransform function for input to route to
		/// the magnified element.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/magnification/nf-magnification-magsetfullscreentransform BOOL
		// MagSetFullscreenTransform( float magLevel, int xOffset, int yOffset );
		[DllImport(Lib_Magnification, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("magnification.h", MSDNShortId = "NF:magnification.MagSetFullscreenTransform")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool MagSetFullscreenTransform(float magLevel, int xOffset, int yOffset);

		/// <summary>Sets the callback function for external image filtering and scaling.</summary>
		/// <param name="hwnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>The handle of the magnification window.</para>
		/// </param>
		/// <param name="callback">
		/// <para>Type: <c>MagImageScalingCallback</c></para>
		/// <para>The callback function, or <c>NULL</c> to remove a callback that was previously set.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </returns>
		/// <remarks>
		/// <para>This function requires Windows Display Driver Model (WDDM)-capable video cards.</para>
		/// <para>This function works only when Desktop Window Manager (DWM) is off.</para>
		/// <para>
		/// This callback mechanism enables custom image filtering and scaling mechanisms. Filtering might include bilinear, trilinear,
		/// bicubic, and flat. The mechanism also enables edge detection and enhancement.
		/// </para>
		/// <para>
		/// The only transform that can be performed within the callback is scaling. Rotations and skews that may compose the arbitrary
		/// transform passed to the MagSetWindowTransform function are performed after the callback function returns.
		/// </para>
		/// <para>
		/// The specified function is called by the magnification engine for all rasterized Windows Graphics Device Interface (GDI) bitmaps
		/// before they are composited.
		/// </para>
		/// <para>After the callback function returns, the bitmap in video memory can have one of the following size states:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// Unscaled. The returned bitmap is the same size as the bitmap passed by the caller. The magnification engine does the scaling by
		/// the transform specified in the MagSetWindowTransform function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Scaled. The returned bitmap is scaled by the transform specified in MagSetWindowTransform.</term>
		/// </item>
		/// </list>
		/// <para>If no callback is registered, the magnification engine scales bitmaps by the transform specified in MagSetWindowTransform.</para>
		/// <para>
		/// Windows Presentation Foundation (WPF) bitmaps can be scaled automatically using flat, bilinear, bicubic filtering and
		/// consequently do not use this callback mechanism.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/magnification/nf-magnification-magsetimagescalingcallback BOOL
		// MagSetImageScalingCallback( HWND hwnd, MagImageScalingCallback callback );
		[DllImport(Lib_Magnification, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("magnification.h", MSDNShortId = "NF:magnification.MagSetImageScalingCallback")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool MagSetImageScalingCallback(HWND hwnd, MagImageScalingCallback callback);

		/// <summary>
		/// Sets the current active input transformation for pen and touch input, represented as a source rectangle and a destination rectangle.
		/// </summary>
		/// <param name="fEnabled">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>TRUE to enable input transformation, or FALSE to disable it.</para>
		/// </param>
		/// <param name="pRectSource">
		/// <para>Type: <c>const LPRECT</c></para>
		/// <para>
		/// The new source rectangle, in unmagnified screen coordinates, that defines the area of the screen to magnify. This parameter is
		/// ignored if bEnabled is FALSE.
		/// </para>
		/// </param>
		/// <param name="pRectDest">
		/// <para>Type: <c>const LPRECT</c></para>
		/// <para>
		/// The new destination rectangle, in unmagnified screen coordinates, that defines the area of the screen where the magnified screen
		/// content is displayed. Pen and touch input in this rectangle is mapped to the source rectangle. This parameter is ignored if
		/// bEnabled is FALSE.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns TRUE if successful, or FALSE otherwise.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The input transformation maps the coordinate space of the magnified screen content to the actual (unmagnified) screen coordinate
		/// space. This enables the system to pass pen and touch input that is entered in magnified screen content, to the correct UI
		/// element on the screen. For example, without input transformation, input is passed to the element located at the unmagnified
		/// screen coordinates, not to the item that appears in the magnified screen content.
		/// </para>
		/// <para>
		/// This function requires the calling process to have UIAccess privileges. If the caller does not have UIAccess privileges, the
		/// call to <c>MagSetInputTransform</c> fails, and the GetLastError function returns ERROR_ACCESS_DENIED. For more information, see
		/// UI Automation Security Considerations and /MANIFESTUAC (Embeds UAC information in manifest).
		/// </para>
		/// <para>
		/// Beginning with Windows 10 Creators Update (version 1703), you must use the MagSetInputTransform function for mouse input to
		/// route to the magnified element (in addition to pen and touch input).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/magnification/nf-magnification-magsetinputtransform BOOL MagSetInputTransform(
		// BOOL fEnabled, const LPRECT pRectSource, const LPRECT pRectDest );
		[DllImport(Lib_Magnification, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("magnification.h", MSDNShortId = "NF:magnification.MagSetInputTransform")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool MagSetInputTransform([MarshalAs(UnmanagedType.Bool)] bool fEnabled, [Optional] in RECT pRectSource, [Optional] in RECT pRectDest);

		/// <summary>Sets the list of windows to be magnified or the list of windows to be excluded from magnification.</summary>
		/// <param name="hwnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>The handle of the magnification window.</para>
		/// </param>
		/// <param name="dwFilterMode">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The magnification filter mode. It can be one of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MW_FILTERMODE_INCLUDE</term>
		/// <term>Magnify the windows.</term>
		/// </item>
		/// <item>
		/// <term>MW_FILTERMODE_EXCLUDE</term>
		/// <term>Exclude the windows from magnification.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="count">
		/// <para>Type: <c>int</c></para>
		/// <para>The number of window handles in the list.</para>
		/// </param>
		/// <param name="pHWND">
		/// <para>Type: <c>HWND*</c></para>
		/// <para>The list of window handles.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </returns>
		/// <remarks>
		/// <para>This function requires Windows Display Driver Model (WDDM)-capable video cards.</para>
		/// <para>
		/// Only one window list is used. You can specify either MW_FILTERMODE_INCLUDE or MW_FILTERMODE_EXCLUDE, depending on whether it is
		/// more convenient to list included windows or excluded windows.
		/// </para>
		/// <para>The magnification window itself is automatically excluded.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/magnification/nf-magnification-magsetwindowfilterlist BOOL
		// MagSetWindowFilterList( HWND hwnd, DWORD dwFilterMode, int count, HWND *pHWND );
		[DllImport(Lib_Magnification, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("magnification.h", MSDNShortId = "NF:magnification.MagSetWindowFilterList")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool MagSetWindowFilterList(HWND hwnd, MW_FILTERMODE dwFilterMode, int count, [In, MarshalAs(UnmanagedType.LPArray, SizeConst = 2)] HWND[] pHWND);

		/// <summary>Sets the source rectangle for the magnification window.</summary>
		/// <param name="hwnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>The magnification window.</para>
		/// </param>
		/// <param name="rect">
		/// <para>Type: <c>RECT</c></para>
		/// <para>The rectangle to be magnified, in desktop coordinates.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/magnification/nf-magnification-magsetwindowsource BOOL MagSetWindowSource(
		// HWND hwnd, RECT rect );
		[DllImport(Lib_Magnification, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("magnification.h", MSDNShortId = "NF:magnification.MagSetWindowSource")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool MagSetWindowSource(HWND hwnd, RECT rect);

		/// <summary>Sets the transformation matrix for a magnifier control.</summary>
		/// <param name="hwnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>The magnification window.</para>
		/// </param>
		/// <param name="pTransform">
		/// <para>Type: <c>PMAGTRANSFORM</c></para>
		/// <para>A transformation matrix.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The transformation matrix specifies the magnification factor that the magnifier control applies to the contents of the source rectangle.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example shows how to set the magnification factor for a magnifier control.</para>
		/// <para>
		/// <code>// Description: // Sets the magnification factor for a magnifier control. // Parameters: // hwndMag - Handle of the magnifier control. // magFactor - New magnification factor. // BOOL SetMagnificationFactor(HWND hwndMag, float magFactor) { MAGTRANSFORM matrix; memset(&amp;matrix, 0, sizeof(matrix)); matrix.v[0][0] = magFactor; matrix.v[1][1] = magFactor; matrix.v[2][2] = 1.0f; return MagSetWindowTransform(hwndMag, &amp;matrix); }</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/magnification/nf-magnification-magsetwindowtransform BOOL
		// MagSetWindowTransform( HWND hwnd, PMAGTRANSFORM pTransform );
		[DllImport(Lib_Magnification, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("magnification.h", MSDNShortId = "NF:magnification.MagSetWindowTransform")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool MagSetWindowTransform(HWND hwnd, in MAGTRANSFORM pTransform);

		/// <summary>Shows or hides the system cursor.</summary>
		/// <param name="fShowCursor">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>TRUE to show the system cursor, or FALSE to hide it.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns TRUE if successful, or FALSE otherwise.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function does not associate a reference count with the visibility state of the system cursor. Instead, the specified
		/// visibility state takes effect immediately, regardless of any previous calls to <c>MagShowSystemCursor</c>.
		/// </para>
		/// <para>The system cursor is always magnified when it is shown while the full-screen magnifier is active.</para>
		/// <para>
		/// When used with a magnifier control, calls to <c>MagShowSystemCursor</c> have no effect on the magnified system cursor. The
		/// visibility of the magnified system cursor depends on whether the magnifier control has the MS_SHOWMAGNIFIEDCURSOR style. If it
		/// has this style, the magnifier control displays the magnified system cursor, along with the magnified screen content, whenever
		/// the system cursor enters the source rectangle.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example uses the <c>MagShowSystemCursor</c> function to set the visibility state of the system cursor.</para>
		/// <para>
		/// <code>// Description: // Show or hide the system cursor. // // Parameters: // fShow - TRUE to show the system cursor, FALSE to hide it. // BOOL ShowSystemCursor(BOOL fShow) { BOOL fResult = MagShowSystemCursor(fShow); return fResult; }</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/magnification/nf-magnification-magshowsystemcursor BOOL MagShowSystemCursor(
		// BOOL fShowCursor );
		[DllImport(Lib_Magnification, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("magnification.h", MSDNShortId = "NF:magnification.MagShowSystemCursor")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool MagShowSystemCursor([MarshalAs(UnmanagedType.Bool)] bool fShowCursor);

		/// <summary>Destroys the magnifier run-time objects.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/magnification/nf-magnification-maguninitialize BOOL MagUninitialize();
		[DllImport(Lib_Magnification, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("magnification.h", MSDNShortId = "NF:magnification.MagUninitialize")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool MagUninitialize();

		/// <summary>
		/// Describes a color transformation matrix that a magnifier control uses to apply a color effect to magnified screen content.
		/// </summary>
		/// <remarks>
		/// The values in the matrix are for red, blue, green, alpha, and color translation. For more information, see Using a Color Matrix
		/// to Transform a Single Color in the Windows GDI+ documentation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/magnification/ns-magnification-magcoloreffect typedef struct tagMAGCOLOREFFECT
		// { float transform[5][5]; } MAGCOLOREFFECT, *PMAGCOLOREFFECT;
		[PInvokeData("magnification.h", MSDNShortId = "NS:magnification.tagMAGCOLOREFFECT")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MAGCOLOREFFECT
		{
			private const int dimLen = 5;

			private float transform00;
			private float transform01;
			private float transform02;
			private float transform03;
			private float transform04;
			private float transform10;
			private float transform11;
			private float transform12;
			private float transform13;
			private float transform14;
			private float transform20;
			private float transform21;
			private float transform22;
			private float transform23;
			private float transform24;
			private float transform30;
			private float transform31;
			private float transform32;
			private float transform33;
			private float transform34;
			private float transform40;
			private float transform41;
			private float transform42;
			private float transform43;
			private float transform44;

			/// <summary>Initializes a new instance of the <see cref="MAGCOLOREFFECT"/> struct with initial values.</summary>
			/// <param name="values">The values.</param>
			public MAGCOLOREFFECT(float[,] values) : this() => transform = values;

			/// <summary>
			/// <para>Type: <c>float[5,5]</c></para>
			/// <para>The transformation matrix.</para>
			/// </summary>
			public float this[int x, int y]
			{
				get
				{
					if (x < 0 || x >= dimLen || y < 0 || y >= dimLen)
						throw new ArgumentOutOfRangeException();
					unsafe
					{
						fixed (float* f = &transform00)
						{
							return f[x * dimLen + y];
						}
					}
				}
				set
				{
					if (x < 0 || x >= dimLen || y < 0 || y >= dimLen)
						throw new ArgumentOutOfRangeException();
					unsafe
					{
						fixed (float* f = &transform00)
						{
							f[x * dimLen + y] = value;
						}
					}
				}
			}

			/// <summary>
			/// <para>Type: <c>float[5,5]</c></para>
			/// <para>The transformation matrix.</para>
			/// </summary>
			public float[,] transform
			{
				get => new float[,] { { transform00, transform01, transform02, transform03, transform04 },
					{ transform10, transform11, transform12, transform13, transform14 },
					{ transform20, transform21, transform22, transform23, transform24 },
					{ transform30, transform31, transform32, transform33, transform34 },
					{ transform40, transform41, transform42, transform43, transform44 } };
				set
				{
					if (value is null) throw new ArgumentNullException();
					if (value.Rank != 2 && value.GetLength(0) != dimLen && value.GetLength(1) != dimLen)
						throw new ArgumentOutOfRangeException();
					unsafe
					{
						fixed (float* f = &transform00)
						{
							for (int x = 0; x < dimLen; x++)
								for (int y = 0; y < dimLen; y++)
									f[x * dimLen + y] = value[x, y];
						}
					}
				}
			}

			/// <summary>Gets a value indicating whether this <see cref="MAGCOLOREFFECT"/> is empty (all values are zero).</summary>
			/// <value>This property is <see langword="true"/> if this <see cref="MAGCOLOREFFECT"/> is empty; otherwise, <see langword="false"/>.</value>
			public bool IsEmpty
			{
				get
				{
					unsafe
					{
						fixed (float* f = &transform00)
						{
							for (int x = 0; x < dimLen; x++)
								for (int y = 0; y < dimLen; y++)
									if (f[x * dimLen + y] != 0f)
										return false;
							return true;
						}
					}
				}
			}

			/// <summary>Gets a value indicating whether this <see cref="MAGTRANSFORM"/> is the identity matrix.</summary>
			/// <value>This property is <see langword="true"/> if this <see cref="MAGTRANSFORM"/> is identity; otherwise, <see langword="false"/>.</value>
			public bool IsIdentity
			{
				get
				{
					unsafe
					{
						fixed (float* f = &transform00)
						{
							for (int x = 0; x < dimLen; x++)
								for (int y = 0; y < dimLen; y++)
									if (f[x * dimLen + y] != (x == y ? 1f : 0f))
										return false;
							return true;
						}
					}
				}
			}

			/// <summary>Determines whether the specified <see cref="System.Object"/>, is equal to this instance.</summary>
			/// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
			/// <returns>
			/// <see langword="true"/> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <see langword="false"/>.
			/// </returns>
			public override bool Equals(object obj) => obj is MAGCOLOREFFECT m && Equals(m);

			/// <summary>Determines whether the specified <see cref="MAGCOLOREFFECT"/>, is equal to this instance.</summary>
			/// <param name="effect">The <see cref="MAGCOLOREFFECT"/> to compare with this instance.</param>
			/// <returns>
			/// <see langword="true"/> if the specified <see cref="MAGCOLOREFFECT"/> is equal to this instance; otherwise, <see langword="false"/>.
			/// </returns>
			public bool Equals(MAGCOLOREFFECT effect)
			{
				unsafe
				{
					fixed (float* f1 = &transform00)
					{
						float* f2 = &effect.transform00;
						for (int x = 0; x < dimLen; x++)
							for (int y = 0; y < dimLen; y++)
								if (f1[x * dimLen + y] != f2[x * dimLen + y])
									return false;
						return true;
					}
				}
			}

			/// <summary>Returns a hash code for this instance.</summary>
			/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
			public override int GetHashCode() => transform.GetHashCode();

			/// <summary>Implements the operator ==.</summary>
			/// <param name="lhs">The left-hand side argument.</param>
			/// <param name="rhs">The right-hand side argument.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(MAGCOLOREFFECT lhs, MAGCOLOREFFECT rhs) => lhs.Equals(rhs);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="lhs">The left-hand side argument.</param>
			/// <param name="rhs">The right-hand side argument.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(MAGCOLOREFFECT lhs, MAGCOLOREFFECT rhs) => !(lhs == rhs);

			/// <summary>An Identity Matrix for MAGCOLOREFFECT.</summary>
			public static readonly MAGCOLOREFFECT Identity = new MAGCOLOREFFECT { transform00 = 1, transform11 = 1, transform22 = 1, transform33 = 1, transform44 = 1 };
		}

		/// <summary>
		/// <para>
		/// <code>width</code>
		/// </para>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The width of the image.</para>
		/// <para>
		/// <code>height</code>
		/// </para>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The height of the image.</para>
		/// <para>
		/// <code>format</code>
		/// </para>
		/// <para>Type: <c>WICPixelFormatGUID</c></para>
		/// <para>
		/// A WICPixelFormatGUID (declared in wincodec.h) that specifies the pixel format of the image. For a list of available pixel
		/// formats, see the Native Pixel Formats topic.
		/// </para>
		/// <para>
		/// <code>stride</code>
		/// </para>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The stride, or number of bytes in a row of the image.</para>
		/// <para>
		/// <code>offset</code>
		/// </para>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The offset of the start of the image data from the beginning of the file.</para>
		/// <para>
		/// <code>cbSize</code>
		/// </para>
		/// <para>Type: <c>SIZE_T</c></para>
		/// <para>The size of the data.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/magnification/ns-magnification-magimageheader typedef struct tagMAGIMAGEHEADER
		// { UINT width; UINT height; WICPixelFormatGUID format; UINT stride; UINT offset; SIZE_T cbSize; } MAGIMAGEHEADER, *PMAGIMAGEHEADER;
		[PInvokeData("magnification.h", MSDNShortId = "NS:magnification.tagMAGIMAGEHEADER")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MAGIMAGEHEADER
		{
			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>The width of the image.</para>
			/// </summary>
			public uint width;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>The height of the image.</para>
			/// </summary>
			public uint height;

			/// <summary>
			/// <para>Type: <c>WICPixelFormatGUID</c></para>
			/// <para>
			/// A WICPixelFormatGUID (declared in wincodec.h) that specifies the pixel format of the image. For a list of available pixel
			/// formats, see the Native Pixel Formats topic.
			/// </para>
			/// </summary>
			public Guid format;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>The stride, or number of bytes in a row of the image.</para>
			/// </summary>
			public uint stride;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>The offset of the start of the image data from the beginning of the file.</para>
			/// </summary>
			public uint offset;

			/// <summary>
			/// <para>Type: <c>SIZE_T</c></para>
			/// <para>The size of the data.</para>
			/// </summary>
			public SizeT cbSize;
		}

		/// <summary>Describes a transformation matrix that a magnifier control uses to magnify screen content.</summary>
		/// <remarks>
		/// <para>The transformation matrix is</para>
		/// <para>(n, 0.0, 0.0)</para>
		/// <para>(0.0, n, 0.0)</para>
		/// <para>(0.0, 0.0, 1.0)</para>
		/// <para>where n is the magnification factor.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/magnification/ns-magnification-magtransform typedef struct tagMAGTRANSFORM {
		// float v[3][3]; } MAGTRANSFORM, *PMAGTRANSFORM;
		[PInvokeData("magnification.h", MSDNShortId = "NS:magnification.tagMAGTRANSFORM")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MAGTRANSFORM : IEquatable<MAGTRANSFORM>
		{
			private const int dimLen = 3;

			private float transform00;
			private float transform01;
			private float transform02;
			private float transform10;
			private float transform11;
			private float transform12;
			private float transform20;
			private float transform21;
			private float transform22;

			/// <summary>Initializes a new instance of the <see cref="MAGTRANSFORM"/> struct with initial values.</summary>
			/// <param name="values">The values.</param>
			public MAGTRANSFORM(float[,] values) : this() => transform = values;

			/// <summary>
			/// Initializes a new instance of the <see cref="MAGTRANSFORM"/> struct with the magnification value set into the transformation matrix.
			/// </summary>
			/// <param name="magnification">The magnification value.</param>
			public MAGTRANSFORM(float magnification) : this() { transform00 = transform11 = magnification; transform22 = 1f; }

			/// <summary>
			/// <para>Type: <c>float[3,3]</c></para>
			/// <para>The transformation matrix.</para>
			/// </summary>
			public float this[int x, int y]
			{
				get
				{
					if (x < 0 || x >= dimLen || y < 0 || y >= dimLen)
						throw new ArgumentOutOfRangeException();
					unsafe
					{
						fixed (float* f = &transform00)
						{
							return f[x * dimLen + y];
						}
					}
				}
				set
				{
					if (x < 0 || x >= dimLen || y < 0 || y >= dimLen)
						throw new ArgumentOutOfRangeException();
					unsafe
					{
						fixed (float* f = &transform00)
						{
							f[x * dimLen + y] = value;
						}
					}
				}
			}

			/// <summary>
			/// <para>Type: <c>float[3,3]</c></para>
			/// <para>The transformation matrix.</para>
			/// </summary>
			public float[,] transform
			{
				get => new float[,] { { transform00, transform01, transform02 },
					{ transform10, transform11, transform12 },
					{ transform20, transform21, transform22 } };
				set
				{
					if (value is null) throw new ArgumentNullException();
					if (value.Rank != 2 && value.GetLength(0) != dimLen && value.GetLength(1) != dimLen)
						throw new ArgumentOutOfRangeException();
					unsafe
					{
						fixed (float* f = &transform00)
						{
							for (int x = 0; x < dimLen; x++)
								for (int y = 0; y < dimLen; y++)
									f[x * dimLen + y] = value[x, y];
						}
					}
				}
			}

			/// <summary>Gets a value indicating whether this <see cref="MAGTRANSFORM"/> is empty (all values are zero).</summary>
			/// <value>This property is <see langword="true"/> if this <see cref="MAGTRANSFORM"/> is empty; otherwise, <see langword="false"/>.</value>
			public bool IsEmpty
			{
				get
				{
					unsafe
					{
						fixed (float* f = &transform00)
						{
							for (int x = 0; x < dimLen; x++)
								for (int y = 0; y < dimLen; y++)
									if (f[x * dimLen + y] != 0f)
										return false;
							return true;
						}
					}
				}
			}

			/// <summary>Gets a value indicating whether this <see cref="MAGTRANSFORM"/> is the identity matrix.</summary>
			/// <value>This property is <see langword="true"/> if this <see cref="MAGTRANSFORM"/> is identity; otherwise, <see langword="false"/>.</value>
			public bool IsIdentity
			{
				get
				{
					unsafe
					{
						fixed (float* f = &transform00)
						{
							for (int x = 0; x < dimLen; x++)
								for (int y = 0; y < dimLen; y++)
									if (f[x * dimLen + y] != (x == y ? 1f : 0f))
										return false;
							return true;
						}
					}
				}
			}

			/// <summary>Determines whether the specified <see cref="System.Object"/>, is equal to this instance.</summary>
			/// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
			/// <returns>
			/// <see langword="true"/> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <see langword="false"/>.
			/// </returns>
			public override bool Equals(object obj) => obj is MAGTRANSFORM m && Equals(m);

			/// <summary>Determines whether the specified <see cref="MAGTRANSFORM"/>, is equal to this instance.</summary>
			/// <param name="effect">The <see cref="MAGTRANSFORM"/> to compare with this instance.</param>
			/// <returns>
			/// <see langword="true"/> if the specified <see cref="MAGTRANSFORM"/> is equal to this instance; otherwise, <see langword="false"/>.
			/// </returns>
			public bool Equals(MAGTRANSFORM effect)
			{
				unsafe
				{
					fixed (float* f1 = &transform00)
					{
						float* f2 = &effect.transform00;
						for (int x = 0; x < dimLen; x++)
							for (int y = 0; y < dimLen; y++)
								if (f1[x * dimLen + y] != f2[x * dimLen + y])
									return false;
						return true;
					}
				}
			}

			/// <summary>Returns a hash code for this instance.</summary>
			/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
			public override int GetHashCode() => transform.GetHashCode();

			/// <summary>Implements the operator ==.</summary>
			/// <param name="lhs">The left-hand side argument.</param>
			/// <param name="rhs">The right-hand side argument.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(MAGTRANSFORM lhs, MAGTRANSFORM rhs) => lhs.Equals(rhs);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="lhs">The left-hand side argument.</param>
			/// <param name="rhs">The right-hand side argument.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(MAGTRANSFORM lhs, MAGTRANSFORM rhs) => !(lhs == rhs);

			/// <summary>An Identity Matrix for MAGTRANSFORM.</summary>
			public static readonly MAGTRANSFORM Identity = new MAGTRANSFORM { transform00 = 1, transform11 = 1, transform22 = 1 };
		}
	}
}