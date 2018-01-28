using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;

// ReSharper disable InconsistentNaming

namespace Vanara.PInvoke
{
	public static partial class DwmApi
	{
		/// <summary>Flags used by the DWM_BLURBEHIND structure to indicate which of its members contain valid information.</summary>
		[Flags]
		[PInvokeData("dwmapi.h")]
		public enum DWM_BLURBEHIND_Mask
		{
			/// <summary>A value for the fEnable member has been specified.</summary>
			DWM_BB_ENABLE = 0X00000001,

			/// <summary>A value for the hRgnBlur member has been specified.</summary>
			DWM_BB_BLURREGION = 0X00000002,

			/// <summary>A value for the fTransitionOnMaximized member has been specified.</summary>
			DWM_BB_TRANSITIONONMAXIMIZED = 0x00000004
		}

		/// <summary>Flags used by the DwmSetWindowAttribute function to specify the cloaking reason</summary>
		[Flags]
		[PInvokeData("dwmapi.h")]
		public enum DWM_CLOAKED
		{
			/// <summary>The window was cloaked by its owner application.</summary>
			DWM_CLOAKED_APP = 0x0000001,

			/// <summary>The window was cloaked by the Shell.</summary>
			DWM_CLOAKED_SHELL = 0x0000002,

			/// <summary>The cloak value was inherited from its owner window.</summary>
			DWM_CLOAKED_INHERITED = 0x0000004,
		}

		/// <summary>The display options for the live preview.</summary>
		[Flags]
		[PInvokeData("dwmapi.h")]
		public enum DWM_SETICONICPREVIEW_Flags
		{
			/// <summary>No frame is displayed around the provided thumbnail.</summary>
			DWM_SIT_NONE = 0x00000000,

			/// <summary>Displays a frame around the provided bitmap.</summary>
			DWM_SIT_DISPLAYFRAME = 0x00000001,
		}

		/// <summary>Visualizations that DWM should show for a contact.</summary>
		[Flags]
		[PInvokeData("dwmapi.h")]
		public enum DWM_SHOWCONTACT : uint
		{
			/// <summary>No visual feedback should be shown in reponse to the contact.</summary>
			DWMSC_NONE = 0x00000000,

			/// <summary>Show the "contact down" animation, such as would be used in a button press.</summary>
			DWMSC_DOWN = 0x00000001,

			/// <summary>Show the "contact up" animation, such as would be used in a button release.</summary>
			DWMSC_UP = 0x00000002,

			/// <summary>Show the "contact drag" animation when the UI element that was selected by the touch or pen is dragged.</summary>
			DWMSC_DRAG = 0x00000004,

			/// <summary>Show a visual while the contact is held down, such as holding down a button.</summary>
			DWMSC_HOLD = 0x00000008,

			/// <summary>Show the pen barrel visual when the pen barrel button is pressed.</summary>
			DWMSC_PENBARREL = 0x00000010,

			/// <summary>Show any of the animations if called for.</summary>
			DWMSC_ALL = 0xFFFFFFFF
		}

		/// <summary>Flags used by the DWM_THUMBNAIL_PROPERTIES structure to indicate which of its members contain valid information.</summary>
		[Flags]
		[PInvokeData("dwmapi.h")]
		public enum DWM_TNP : uint
		{
			/// <summary>A value for the rcDestination member has been specified.</summary>
			DWM_TNP_RECTDESTINATION = 0x00000001,

			/// <summary>A value for the rcSource member has been specified.</summary>
			DWM_TNP_RECTSOURCE = 0x00000002,

			/// <summary>A value for the opacity member has been specified.</summary>
			DWM_TNP_OPACITY = 0x00000004,

			/// <summary>A value for the fVisible member has been specified.</summary>
			DWM_TNP_VISIBLE = 0x00000008,

			/// <summary>A value for the fSourceClientAreaOnly member has been specified.</summary>
			DWM_TNP_SOURCECLIENTAREAONLY = 0x00000010,
		}

		/// <summary>Flags used by the DwmSetWindowAttribute function to specify the Flip3D window policy.</summary>
		[PInvokeData("dwmapi.h")]
		public enum DWMFLIP3DWINDOWPOLICY
		{
			/// <summary>Use the window's style and visibility settings to determine whether to hide or include the window in Flip3D rendering.</summary>
			DWMFLIP3D_DEFAULT,

			/// <summary>Exclude the window from Flip3D and display it below the Flip3D rendering.</summary>
			DWMFLIP3D_EXCLUDEBELOW,

			/// <summary>Exclude the window from Flip3D and display it above the Flip3D rendering.</summary>
			DWMFLIP3D_EXCLUDEABOVE,

			/// <summary>The maximum recognized DWMFLIP3DWINDOWPOLICY value, used for validation purposes.</summary>
			DWMFLIP3D_LAST
		}

		/// <summary>Flags used by the DwmSetWindowAttribute function to specify the non-client area rendering policy.</summary>
		[PInvokeData("dwmapi.h")]
		public enum DWMNCRENDERINGPOLICY
		{
			/// <summary>The non-client rendering area is rendered based on the window style.</summary>
			DWMNCRP_USEWINDOWSTYLE,

			/// <summary>The non-client area rendering is disabled; the window style is ignored.</summary>
			DWMNCRP_DISABLED,

			/// <summary>The non-client area rendering is enabled; the window style is ignored.</summary>
			DWMNCRP_ENABLED,

			/// <summary>The maximum recognized DWMNCRENDERINGPOLICY value, used for validation purposes.</summary>
			DWMNCRP_LAST
		}

		/// <summary>Identifies the target.</summary>
		[PInvokeData("dwmapi.h")]
		public enum DWMTRANSITION_OWNEDWINDOW_TARGET
		{
			/// <summary>Indicates no animation.</summary>
			DWMTRANSITION_OWNEDWINDOW_NULL = -1,

			/// <summary>Indicates that the window is repositioned.</summary>
			DWMTRANSITION_OWNEDWINDOW_REPOSITION = 0,
		}

		/// <summary>Flags used by the DwmGetWindowAttribute and DwmSetWindowAttribute functions to specify window attributes for non-client rendering.</summary>
		[PInvokeData("dwmapi.h")]
		public enum DWMWINDOWATTRIBUTE
		{
			/// <summary>
			/// Use with DwmGetWindowAttribute. Discovers whether non-client rendering is enabled. The retrieved value is of type BOOL. TRUE if non-client
			/// rendering is enabled; otherwise, FALSE.
			/// </summary>
			[CorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			DWMWA_NCRENDERING_ENABLED = 1,

			/// <summary>
			/// Use with DwmSetWindowAttribute. Sets the non-client rendering policy. The pvAttribute parameter points to a value from the DWMNCRENDERINGPOLICY enumeration.
			/// </summary>
			[CorrespondingType(typeof(DWMNCRENDERINGPOLICY), CorrepsondingAction.Set)]
			DWMWA_NCRENDERING_POLICY,

			/// <summary>
			/// Use with DwmSetWindowAttribute. Enables or forcibly disables DWM transitions. The pvAttribute parameter points to a value of TRUE to disable
			/// transitions or FALSE to enable transitions.
			/// </summary>
			[CorrespondingType(typeof(bool), CorrepsondingAction.Set)]
			DWMWA_TRANSITIONS_FORCEDISABLED,

			/// <summary>
			/// Use with DwmSetWindowAttribute. Enables content rendered in the non-client area to be visible on the frame drawn by DWM. The pvAttribute
			/// parameter points to a value of TRUE to enable content rendered in the non-client area to be visible on the frame; otherwise, it points to FALSE.
			/// </summary>
			[CorrespondingType(typeof(bool), CorrepsondingAction.Set)]
			DWMWA_ALLOW_NCPAINT,

			/// <summary>
			/// Use with DwmGetWindowAttribute. Retrieves the bounds of the caption button area in the window-relative space. The retrieved value is of type RECT.
			/// </summary>
			[CorrespondingType(typeof(RECT), CorrepsondingAction.Get)]
			DWMWA_CAPTION_BUTTON_BOUNDS,

			/// <summary>
			/// Use with DwmSetWindowAttribute. Specifies whether non-client content is right-to-left (RTL) mirrored. The pvAttribute parameter points to a value
			/// of TRUE if the non-client content is right-to-left (RTL) mirrored; otherwise, it points to FALSE.
			/// </summary>
			[CorrespondingType(typeof(bool), CorrepsondingAction.Set)]
			DWMWA_NONCLIENT_RTL_LAYOUT,

			/// <summary>
			/// Use with DwmSetWindowAttribute. Forces the window to display an iconic thumbnail or peek representation (a static bitmap), even if a live or
			/// snapshot representation of the window is available. This value normally is set during a window's creation and not changed throughout the window's
			/// lifetime. Some scenarios, however, might require the value to change over time. The pvAttribute parameter points to a value of TRUE to require a
			/// iconic thumbnail or peek representation; otherwise, it points to FALSE.
			/// </summary>
			[CorrespondingType(typeof(bool), CorrepsondingAction.Set)]
			DWMWA_FORCE_ICONIC_REPRESENTATION,

			/// <summary>
			/// Use with DwmSetWindowAttribute. Sets how Flip3D treats the window. The pvAttribute parameter points to a value from the DWMFLIP3DWINDOWPOLICY enumeration.
			/// </summary>
			[CorrespondingType(typeof(DWMFLIP3DWINDOWPOLICY), CorrepsondingAction.Set)]
			DWMWA_FLIP3D_POLICY,

			/// <summary>Use with DwmGetWindowAttribute. Retrieves the extended frame bounds rectangle in screen space. The retrieved value is of type RECT.</summary>
			[CorrespondingType(typeof(RECT), CorrepsondingAction.Get)]
			DWMWA_EXTENDED_FRAME_BOUNDS,

			/// <summary>
			/// Use with DwmSetWindowAttribute. The window will provide a bitmap for use by DWM as an iconic thumbnail or peek representation (a static bitmap)
			/// for the window. DWMWA_HAS_ICONIC_BITMAP can be specified with DWMWA_FORCE_ICONIC_REPRESENTATION. DWMWA_HAS_ICONIC_BITMAP normally is set during a
			/// window's creation and not changed throughout the window's lifetime. Some scenarios, however, might require the value to change over time. The
			/// pvAttribute parameter points to a value of TRUE to inform DWM that the window will provide an iconic thumbnail or peek representation; otherwise,
			/// it points to FALSE.
			/// <para><c>Windows Vista and earlier:</c> This value is not supported.</para>
			/// </summary>
			[CorrespondingType(typeof(bool), CorrepsondingAction.Set)]
			DWMWA_HAS_ICONIC_BITMAP,

			/// <summary>
			/// Use with DwmSetWindowAttribute. Do not show peek preview for the window. The peek view shows a full-sized preview of the window when the mouse
			/// hovers over the window's thumbnail in the taskbar. If this attribute is set, hovering the mouse pointer over the window's thumbnail dismisses
			/// peek (in case another window in the group has a peek preview showing). The pvAttribute parameter points to a value of TRUE to prevent peek
			/// functionality or FALSE to allow it.
			/// <para><c>Windows Vista and earlier:</c> This value is not supported.</para>
			/// </summary>
			[CorrespondingType(typeof(bool), CorrepsondingAction.Set)]
			DWMWA_DISALLOW_PEEK,

			/// <summary>
			/// Use with DwmSetWindowAttribute. Prevents a window from fading to a glass sheet when peek is invoked. The pvAttribute parameter points to a value
			/// of TRUE to prevent the window from fading during another window's peek or FALSE for normal behavior.
			/// <para><c>Windows Vista and earlier:</c> This value is not supported.</para>
			/// </summary>
			[CorrespondingType(typeof(bool), CorrepsondingAction.Set)]
			DWMWA_EXCLUDED_FROM_PEEK,

			/// <summary>
			/// Use with DwmSetWindowAttribute. Cloaks the window such that it is not visible to the user. The window is still composed by DWM.
			/// <para>
			/// <c>Using with DirectComposition:</c> Use the DWMWA_CLOAK flag to cloak the layered child window when animating a representation of the window's
			/// content via a DirectComposition visual which has been associated with the layered child window. For more details on this usage case, see How to
			/// How to animate the bitmap of a layered child window.
			/// </para>
			/// <para><c>Windows 7 and earlier:</c> This value is not supported.</para>
			/// </summary>
			[CorrespondingType(typeof(bool), CorrepsondingAction.Set)]
			DWMWA_CLOAK,

			/// <summary>
			/// Use with DwmGetWindowAttribute. If the window is cloaked, provides one of the following values explaining why:
			/// <list type="table">
			/// <listheader>
			/// <term>Name (Value)</term>
			/// <definition>Meaning</definition>
			/// </listheader>
			/// <item>
			/// <term>DWM_CLOAKED_APP 0x0000001</term>
			/// <definition>The window was cloaked by its owner application.</definition>
			/// </item>
			/// <item>
			/// <term>DWM_CLOAKED_SHELL 0x0000002</term>
			/// <definition>The window was cloaked by the Shell.</definition>
			/// </item>
			/// <item>
			/// <term>DWM_CLOAKED_INHERITED 0x0000004</term>
			/// <definition>The cloak value was inherited from its owner window.</definition>
			/// </item>
			/// </list>
			/// <para><c>Windows 7 and earlier:</c> This value is not supported.</para>
			/// </summary>
			[CorrespondingType(typeof(DWM_CLOAKED), CorrepsondingAction.Get)]
			DWMWA_CLOAKED,

			/// <summary>
			/// Use with DwmSetWindowAttribute. Freeze the window's thumbnail image with its current visuals. Do no further live updates on the thumbnail image
			/// to match the window's contents.
			/// <para><c>Windows 7 and earlier:</c> This value is not supported.</para>
			/// </summary>
			[CorrespondingType(typeof(bool), CorrepsondingAction.Set)]
			DWMWA_FREEZE_REPRESENTATION,
		}

		/// <summary>Identifies the gesture type specified in DwmRenderGesture.</summary>
		[PInvokeData("dwmapi.h")]
		public enum GESTURE_TYPE
		{
			/// <summary>A pen tap.</summary>
			GT_PEN_TAP = 0,

			/// <summary>A pen double tap.</summary>
			GT_PEN_DOUBLETAP = 1,

			/// <summary>A pen right tap.</summary>
			GT_PEN_RIGHTTAP = 2,

			/// <summary>A pen press and hold.</summary>
			GT_PEN_PRESSANDHOLD = 3,

			/// <summary>An abort of the pen press and hold.</summary>
			GT_PEN_PRESSANDHOLDABORT = 4,

			/// <summary>A touch tap.</summary>
			GT_TOUCH_TAP = 5,

			/// <summary>A touch double tap.</summary>
			GT_TOUCH_DOUBLETAP = 6,

			/// <summary>A touch right tap.</summary>
			GT_TOUCH_RIGHTTAP = 7,

			/// <summary>A touch press and hold.</summary>
			GT_TOUCH_PRESSANDHOLD = 8,

			/// <summary>An abort of the touch press and hold.</summary>
			GT_TOUCH_PRESSANDHOLDABORT = 9,

			/// <summary>A touch press and tap.</summary>
			GT_TOUCH_PRESSANDTAP = 10
		}

		/// <summary>Default window procedure for Desktop Window Manager (DWM) hit testing within the non-client area.</summary>
		/// <param name="hwnd">A handle to the window procedure that received the message.</param>
		/// <param name="msg">The message.</param>
		/// <param name="wParam">Specifies additional message information. The content of this parameter depends on the value of the msg parameter.</param>
		/// <param name="lParam">Specifies additional message information. The content of this parameter depends on the value of the msg parameter.</param>
		/// <param name="plResult">A pointer to an LRESULT value that, when this method returns successfully,receives the result of the hit test.</param>
		/// <returns>TRUE if DwmDefWindowProc handled the message; otherwise, FALSE.</returns>
		[DllImport(Lib.DwmApi, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("dwmapi.h")]
		public static extern bool DwmDefWindowProc(IntPtr hwnd, uint msg, IntPtr wParam, IntPtr lParam, out IntPtr plResult);

		/// <summary>Enables the blur effect on a specified window.</summary>
		/// <param name="hWnd">The handle to the window on which the blur behind data is applied.</param>
		/// <param name="pDwmBlurbehind">A pointer to a DWM_BLURBEHIND structure that provides blur behind data.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.DwmApi, ExactSpelling = true)]
		[System.Security.SecurityCritical]
		[PInvokeData("dwmapi.h")]
		public static extern HRESULT DwmEnableBlurBehindWindow(IntPtr hWnd, ref DWM_BLURBEHIND pDwmBlurbehind);

		/// <summary>
		/// Enables or disables Desktop Window Manager (DWM) composition. <note>This function is deprecated as of Windows 8. DWM can no longer be
		/// programmatically disabled.</note>
		/// </summary>
		/// <param name="uCompositionAction">
		/// DWM_EC_ENABLECOMPOSITION to enable DWM composition; DWM_EC_DISABLECOMPOSITION to disable composition. <note>As of Windows 8, calling this function
		/// with DWM_EC_DISABLECOMPOSITION has no effect. However, the function will still return a success code.</note>
		/// </param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.DwmApi, ExactSpelling = true)]
		[System.Security.SecurityCritical]
		[PInvokeData("dwmapi.h")]
		public static extern HRESULT DwmEnableComposition(int uCompositionAction);

		/// <summary>
		/// Notifies the Desktop Window Manager (DWM) to opt in to or out of Multimedia Class Schedule Service (MMCSS) scheduling while the calling process is alive.
		/// </summary>
		/// <param name="fEnableMMCSS">TRUE to instruct DWM to participate in MMCSS scheduling; FALSE to opt out or end participation in MMCSS scheduling.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.DwmApi, ExactSpelling = true)]
		[PInvokeData("dwmapi.h")]
		public static extern HRESULT DwmEnableMMCSS([MarshalAs(UnmanagedType.Bool)] bool fEnableMMCSS);

		/// <summary>Extends the window frame into the client area.</summary>
		/// <param name="hWnd">The handle to the window in which the frame will be extended into the client area.</param>
		/// <param name="pMarInset">A pointer to a MARGINS structure that describes the margins to use when extending the frame into the client area.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.DwmApi, ExactSpelling = true)]
		[System.Security.SecurityCritical]
		[PInvokeData("dwmapi.h")]
		public static extern HRESULT DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

		/// <summary>
		/// Issues a flush call that blocks the caller until the next present, when all of the Microsoft DirectX surface updates that are currently outstanding
		/// have been made. This compensates for very complex scenes or calling processes with very low priority.
		/// </summary>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.DwmApi, ExactSpelling = true)]
		[PInvokeData("dwmapi.h")]
		public static extern HRESULT DwmFlush();

		/// <summary>
		/// Retrieves the current color used for Desktop Window Manager (DWM) glass composition. This value is based on the current color scheme and can be
		/// modified by the user. Applications can listen for color changes by handling the WM_DWMCOLORIZATIONCOLORCHANGED notification.
		/// </summary>
		/// <param name="pcrColorization">
		/// A pointer to a value that, when this function returns successfully, receives the current color used for glass composition. The color format of the
		/// value is 0xAARRGGBB.
		/// </param>
		/// <param name="pfOpaqueBlend">
		/// A pointer to a value that, when this function returns successfully, indicates whether the color is an opaque blend. TRUE if the color is an opaque
		/// blend; otherwise, FALSE.
		/// </param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.DwmApi, ExactSpelling = true)]
		[PInvokeData("dwmapi.h")]
		public static extern HRESULT DwmGetColorizationColor(out uint pcrColorization, [MarshalAs(UnmanagedType.Bool)] out bool pfOpaqueBlend);

		/// <summary>Gets the colorization parameters.</summary>
		/// <param name="parameters">The parameters.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.DwmApi, EntryPoint = "#127")]
		[System.Security.SecurityCritical]
		[PInvokeData("dwmapi.h")]
		public static extern HRESULT DwmpGetColorizationParameters(out DWM_COLORIZATION_PARAMS parameters);

		/// <summary>Retrieves the current composition timing information for a specified window.</summary>
		/// <param name="hwnd">
		/// The handle to the window for which the composition timing information should be retrieved. Starting with Windows 8.1, this parameter must be set to
		/// NULL. If this parameter is not set to NULL, DwmGetCompositionTimingInfo returns E_INVALIDARG.
		/// </param>
		/// <param name="dwAttribute">
		/// A pointer to a DWM_TIMING_INFO structure that, when this function returns successfully, receives the current composition timing information for the
		/// window. The cbSize member of this structure must be set before this function is called.
		/// </param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.DwmApi, ExactSpelling = true)]
		[PInvokeData("dwmapi.h")]
		public static extern HRESULT DwmGetCompositionTimingInfo(IntPtr hwnd, ref DWM_TIMING_INFO dwAttribute);

		/// <summary>Retrieves transport attributes.</summary>
		/// <param name="pfIsRemoting">
		/// A pointer to a BOOL value that indicates whether the transport supports remoting. TRUE if the transport supports remoting; otherwise, FALSE.
		/// </param>
		/// <param name="pfIsConnected">
		/// A pointer to a BOOL value that indicates whether the transport is connected. TRUE if the transport is connected; otherwise, FALSE.
		/// </param>
		/// <param name="pDwGeneration">A pointer to a DWORD that receives a generation value for the transport.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.DwmApi, ExactSpelling = true)]
		[PInvokeData("dwmapi.h")]
		public static extern HRESULT DwmGetTransportAttributes([MarshalAs(UnmanagedType.Bool)] out bool pfIsRemoting, [MarshalAs(UnmanagedType.Bool)] out bool pfIsConnected, out uint pDwGeneration);

		/// <summary>Retrieves the current value of a specified attribute applied to a window.</summary>
		/// <param name="hwnd">The handle to the window from which the attribute data is retrieved.</param>
		/// <param name="dwAttribute">The attribute to retrieve, specified as a DWMWINDOWATTRIBUTE value.</param>
		/// <param name="pvAttribute">
		/// A pointer to a value that, when this function returns successfully, receives the current value of the attribute. The type of the retrieved value
		/// depends on the value of the dwAttribute parameter.
		/// </param>
		/// <param name="cbAttribute">The size of the DWMWINDOWATTRIBUTE value being retrieved. The size is dependent on the type of the pvAttribute parameter.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.DwmApi, ExactSpelling = true)]
		[System.Security.SecurityCritical]
		[PInvokeData("dwmapi.h")]
		public static extern HRESULT DwmGetWindowAttribute(IntPtr hwnd, DWMWINDOWATTRIBUTE dwAttribute, IntPtr pvAttribute, int cbAttribute);

		/// <summary>Retrieves the current value of a specified attribute applied to a window.</summary>
		/// <param name="hwnd">The handle to the window from which the attribute data is retrieved.</param>
		/// <param name="dwAttribute">The attribute to retrieve, specified as a DWMWINDOWATTRIBUTE value.</param>
		/// <param name="pvAttribute">
		/// A value that, when this function returns successfully, receives the current value of the attribute. The type of the retrieved value depends on the
		/// value of the dwAttribute parameter.
		/// </param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[PInvokeData("dwmapi.h")]
		public static HRESULT DwmGetWindowAttribute<T>(IntPtr hwnd, DWMWINDOWATTRIBUTE dwAttribute, out T pvAttribute)
		{
			if (!CorrespondingTypeAttribute.CanGet(dwAttribute, typeof(T))) throw new ArgumentException();
			var type = typeof(T);
			var isBool = type == typeof(bool);
			type = isBool ? typeof(uint) : (type.IsEnum ? Enum.GetUnderlyingType(type) : type);
			var m = new SafeCoTaskMemHandle(Marshal.SizeOf(type));
			var hr = DwmGetWindowAttribute(hwnd, dwAttribute, (IntPtr)m, m.Size);
			pvAttribute = isBool ? (T)Convert.ChangeType(m.ToStructure<uint>(), typeof(bool)) : (T)Marshal.PtrToStructure((IntPtr)m, type);
			return hr;
		}

		/// <summary>
		/// Called by an application to indicate that all previously provided iconic bitmaps from a window, both thumbnails and peek representations, should be refreshed.
		/// </summary>
		/// <param name="hwnd">
		/// A handle to the window or tab whose bitmaps are being invalidated through this call. This window must belong to the calling process.
		/// </param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		/// <remarks>
		/// Calling this function causes the Desktop Window Manager (DWM) to invalidate its current bitmaps for the window and request new bitmaps from the
		/// window when they are next needed. DwmInvalidateIconicBitmaps should not be called frequently. Doing so can lead to poor performance as new bitmaps
		/// are created and retrieved.
		/// </remarks>
		[DllImport(Lib.DwmApi, ExactSpelling = true)]
		[PInvokeData("dwmapi.h")]
		public static extern HRESULT DwmInvalidateIconicBitmaps(IntPtr hwnd);

		/// <summary>
		/// Obtains a value that indicates whether Desktop Window Manager (DWM) composition is enabled. Applications on machines running Windows 7 or earlier can
		/// listen for composition state changes by handling the WM_DWMCOMPOSITIONCHANGED notification.
		/// </summary>
		/// <param name="pfEnabled">
		/// A pointer to a value that, when this function returns successfully, receives TRUE if DWM composition is enabled; otherwise, FALSE. <note>As of
		/// Windows 8, DWM composition is always enabled. If an app declares Windows 8 compatibility in their manifest, this function will receive a value of
		/// TRUE through pfEnabled. If no such manifest entry is found, Windows 8 compatibility is not assumed and this function receives a value of FALSE
		/// through pfEnabled. This is done so that older programs that interpret a value of TRUE to imply that high contrast mode is off can continue to make
		/// the correct decisions about rendering their images. (Note that this is a bad practice—you should use the SystemParametersInfo function with the
		/// SPI_GETHIGHCONTRAST flag to determine the state of high contrast mode.)</note>
		/// </param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.DwmApi, ExactSpelling = true)]
		[System.Security.SecurityCritical]
		[PInvokeData("dwmapi.h")]
		public static extern HRESULT DwmIsCompositionEnabled([MarshalAs(UnmanagedType.Bool)] out bool pfEnabled);

		/// <summary>Retrieves the source size of the Desktop Window Manager (DWM) thumbnail.</summary>
		/// <param name="hThumbnail">A handle to the thumbnail to retrieve the source window size from.</param>
		/// <param name="pSize">A pointer to a SIZE structure that, when this function returns successfully, receives the size of the source thumbnail.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.DwmApi, ExactSpelling = true)]
		[PInvokeData("dwmapi.h")]
		public static extern HRESULT DwmQueryThumbnailSourceSize(IntPtr hThumbnail, ref SIZE pSize);

		/// <summary>Creates a Desktop Window Manager (DWM) thumbnail relationship between the destination and source windows.</summary>
		/// <param name="hwndDestination">
		/// The handle to the window that will use the DWM thumbnail. Setting the destination window handle to anything other than a top-level window type will
		/// result in a return value of E_INVALIDARG.
		/// </param>
		/// <param name="hwndSource">
		/// The handle to the window to use as the thumbnail source. Setting the source window handle to anything other than a top-level window type will result
		/// in a return value of E_INVALIDARG.
		/// </param>
		/// <param name="phThumbnailId">A pointer to a handle that, when this function returns successfully, represents the registration of the DWM thumbnail.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.DwmApi, ExactSpelling = true)]
		[PInvokeData("dwmapi.h")]
		public static extern HRESULT DwmRegisterThumbnail(IntPtr hwndDestination, IntPtr hwndSource, out IntPtr phThumbnailId);

		/// <summary>
		/// Notifies Desktop Window Manager (DWM) that a touch contact has been recognized as a gesture, and that DWM should draw feedback for that gesture.
		/// </summary>
		/// <param name="gt">The type of gesture, specified as one of the GESTURE_TYPE values.</param>
		/// <param name="cContacts">The number of contact points.</param>
		/// <param name="pdwPointerID">The pointer ID.</param>
		/// <param name="pPoints">The points.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.DwmApi, ExactSpelling = true)]
		[PInvokeData("dwmapi.h")]
		public static extern HRESULT DwmRenderGesture(GESTURE_TYPE gt, uint cContacts, ref uint pdwPointerID, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] System.Drawing.Point[] pPoints);

		/// <summary>Sets the colorization parameters.</summary>
		/// <param name="parameters">The parameters.</param>
		/// <param name="unk">Always set to 1.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.DwmApi, EntryPoint = "#131")]
		[System.Security.SecurityCritical]
		[PInvokeData("dwmapi.h")]
		public static extern HRESULT DwmpSetColorizationParameters(ref DWM_COLORIZATION_PARAMS parameters, uint unk);

		/// <summary>
		/// Sets a static, iconic bitmap to display a live preview (also known as a Peek preview) of a window or tab. The taskbar can use this bitmap to show a
		/// full-sized preview of a window or tab.
		/// </summary>
		/// <param name="hwnd">A handle to the window. This window must belong to the calling process.</param>
		/// <param name="hbmp">A handle to the bitmap to represent the window that hwnd specifies.</param>
		/// <param name="pptClient">
		/// The offset of a tab window's client region (the content area inside the client window frame) from the host window's frame. This offset enables the
		/// tab window's contents to be drawn correctly in a live preview when it is drawn without its frame.
		/// </param>
		/// <param name="dwSITFlags">The display options for the live preview.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.DwmApi, ExactSpelling = true)]
		[PInvokeData("dwmapi.h")]
		public static extern HRESULT DwmSetIconicLivePreviewBitmap(IntPtr hwnd, IntPtr hbmp, ref System.Drawing.Point pptClient, DWM_SETICONICPREVIEW_Flags dwSITFlags);

		/// <summary>
		/// Sets a static, iconic bitmap to display a live preview (also known as a Peek preview) of a window or tab. The taskbar can use this bitmap to show a
		/// full-sized preview of a window or tab.
		/// </summary>
		/// <param name="hwnd">A handle to the window. This window must belong to the calling process.</param>
		/// <param name="hbmp">A handle to the bitmap to represent the window that hwnd specifies.</param>
		/// <param name="pptClient">
		/// The offset of a tab window's client region (the content area inside the client window frame) from the host window's frame. This offset enables the
		/// tab window's contents to be drawn correctly in a live preview when it is drawn without its frame.
		/// </param>
		/// <param name="dwSITFlags">The display options for the live preview.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.DwmApi, ExactSpelling = true)]
		[PInvokeData("dwmapi.h")]
		public static extern HRESULT DwmSetIconicLivePreviewBitmap(IntPtr hwnd, IntPtr hbmp, IntPtr pptClient, DWM_SETICONICPREVIEW_Flags dwSITFlags);

		/// <summary>
		/// Sets a static, iconic bitmap on a window or tab to use as a thumbnail representation. The taskbar can use this bitmap as a thumbnail switch target
		/// for the window or tab.
		/// </summary>
		/// <param name="hwnd">A handle to the window. This window must belong to the calling process.</param>
		/// <param name="hbmp">A handle to the bitmap to represent the window that hwnd specifies.</param>
		/// <param name="dwSITFlags">The display options for the live preview.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.DwmApi, ExactSpelling = true)]
		[PInvokeData("dwmapi.h")]
		public static extern HRESULT DwmSetIconicThumbnail(IntPtr hwnd, IntPtr hbmp, DWM_SETICONICPREVIEW_Flags dwSITFlags);

		/// <summary>Sets the value of non-client rendering attributes for a window.</summary>
		/// <param name="hwnd">The handle to the window that will receive the attributes.</param>
		/// <param name="dwAttribute">
		/// A single DWMWINDOWATTRIBUTE flag to apply to the window. This parameter specifies the attribute and the pvAttribute parameter points to the value of
		/// that attribute.
		/// </param>
		/// <param name="pvAttribute">
		/// A pointer to the value of the attribute specified in the dwAttribute parameter. Different DWMWINDOWATTRIBUTE flags require different value types.
		/// </param>
		/// <param name="cbAttribute">The size, in bytes, of the value type pointed to by the pvAttribute parameter.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.DwmApi, ExactSpelling = true)]
		[System.Security.SecurityCritical]
		[PInvokeData("dwmapi.h")]
		public static extern HRESULT DwmSetWindowAttribute(IntPtr hwnd, DWMWINDOWATTRIBUTE dwAttribute, [In] IntPtr pvAttribute, int cbAttribute);

		/// <summary>Sets the value of non-client rendering attributes for a window.</summary>
		/// <param name="hwnd">The handle to the window that will receive the attributes.</param>
		/// <param name="dwAttribute">
		/// A single DWMWINDOWATTRIBUTE flag to apply to the window. This parameter specifies the attribute and the pvAttribute parameter points to the value of
		/// that attribute.
		/// </param>
		/// <param name="pvAttribute">
		/// The value of the attribute specified in the dwAttribute parameter. Different DWMWINDOWATTRIBUTE flags require different value types.
		/// </param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[PInvokeData("dwmapi.h")]
		public static HRESULT DwmSetWindowAttribute<T>(IntPtr hwnd, DWMWINDOWATTRIBUTE dwAttribute, [In] T pvAttribute)
		{
			if (pvAttribute == null || !CorrespondingTypeAttribute.CanSet(dwAttribute, typeof(T))) throw new ArgumentException();
			var attr = pvAttribute is bool ? Convert.ToUInt32(pvAttribute) : (pvAttribute.GetType().IsEnum ? Convert.ChangeType(pvAttribute, Enum.GetUnderlyingType(pvAttribute.GetType())) : pvAttribute);
			using (var p = new PinnedObject(attr))
				return DwmSetWindowAttribute(hwnd, dwAttribute, p, Marshal.SizeOf(attr));
		}

		/// <summary>Called by an app or framework to specify the visual feedback type to draw in response to a particular touch or pen contact.</summary>
		/// <param name="dwPointerID">The pointer ID of the contact. Each touch or pen contact is given a unique ID when it is detected.</param>
		/// <param name="eShowContact">One or more of the DWM_SHOWCONTACT visualizations that DWM should show for this contact.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.DwmApi, ExactSpelling = true)]
		[PInvokeData("dwmapi.h")]
		public static extern void DwmShowContact(uint dwPointerID, DWM_SHOWCONTACT eShowContact);

		/// <summary>Enables the graphical feedback of touch and drag interactions to the user.</summary>
		/// <param name="dwPointerID">The pointer ID.</param>
		/// <param name="fEnable">Indicates whether the contact is enabled.</param>
		/// <param name="ptTether">The tether.</param>
		[DllImport(Lib.DwmApi, ExactSpelling = true)]
		[PInvokeData("dwmapi.h")]
		public static extern void DwmTetherContact(uint dwPointerID, [MarshalAs(UnmanagedType.Bool)] bool fEnable, System.Drawing.Point ptTether);

		/// <summary>Coordinates the animations of tool windows with the Desktop Window Manager (DWM).</summary>
		/// <param name="hwnd">Handle to the window.</param>
		/// <param name="target">The target.</param>
		[DllImport(Lib.DwmApi, ExactSpelling = true)]
		[PInvokeData("dwmapi.h")]
		public static extern void DwmTransitionOwnedWindow(IntPtr hwnd, DWMTRANSITION_OWNEDWINDOW_TARGET target);

		/// <summary>Removes a Desktop Window Manager (DWM) thumbnail relationship created by the DwmRegisterThumbnail function.</summary>
		/// <param name="hThumbnailId">
		/// The handle to the thumbnail relationship to be removed. Null or non-existent handles will result in a return value of E_INVALIDARG.
		/// </param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.DwmApi, ExactSpelling = true)]
		[PInvokeData("dwmapi.h")]
		public static extern HRESULT DwmUnregisterThumbnail(IntPtr hThumbnailId);

		/// <summary>Updates the properties for a Desktop Window Manager (DWM) thumbnail.</summary>
		/// <param name="hThumbnailId">
		/// The handle to the DWM thumbnail to be updated. Null or invalid thumbnails, as well as thumbnails owned by other processes will result in a return
		/// value of E_INVALIDARG.
		/// </param>
		/// <param name="ptnProperties">A pointer to a DWM_THUMBNAIL_PROPERTIES structure that contains the new thumbnail properties.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.DwmApi, ExactSpelling = true)]
		[PInvokeData("dwmapi.h")]
		public static extern HRESULT DwmUpdateThumbnailProperties(IntPtr hThumbnailId, ref DWM_THUMBNAIL_PROPERTIES ptnProperties);

		/// <summary>Specifies Desktop Window Manager (DWM) blur-behind properties. Used by the DwmEnableBlurBehindWindow function.</summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("dwmapi.h")]
		public struct DWM_BLURBEHIND
		{
			/// <summary>A bitwise combination of DWM Blur Behind constant values that indicates which of the members of this structure have been set.</summary>
			public DWM_BLURBEHIND_Mask dwFlags;

			/// <summary>TRUE to register the window handle to DWM blur behind; FALSE to unregister the window handle from DWM blur behind.</summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fEnable;

			/// <summary>
			/// The region within the client area where the blur behind will be applied. A NULL value will apply the blur behind the entire client area.
			/// </summary>
			public IntPtr hRgnBlur;

			/// <summary>TRUE if the window's colorization should transition to match the maximized windows; otherwise, FALSE.</summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fTransitionOnMaximized;

			/// <summary>Initializes a new instance of the <see cref="DWM_BLURBEHIND"/> struct.</summary>
			/// <param name="enabled">if set to <c>true</c> enabled.</param>
			public DWM_BLURBEHIND(bool enabled)
			{
				fEnable = enabled;
				hRgnBlur = IntPtr.Zero;
				fTransitionOnMaximized = false;
				dwFlags = DWM_BLURBEHIND_Mask.DWM_BB_ENABLE;
			}

			/// <summary>Gets the region.</summary>
			/// <value>The region.</value>
			public System.Drawing.Region Region => System.Drawing.Region.FromHrgn(hRgnBlur);

			/// <summary>Gets or sets a value indicating whether the window's colorization should transition to match the maximized windows.</summary>
			/// <value><c>true</c> if the window's colorization should transition to match the maximized windows; otherwise, <c>false</c>.</value>
			public bool TransitionOnMaximized
			{
				get => fTransitionOnMaximized;
				set
				{
					fTransitionOnMaximized = value;
					dwFlags |= DWM_BLURBEHIND_Mask.DWM_BB_TRANSITIONONMAXIMIZED;
				}
			}

			/// <summary>Sets the region.</summary>
			/// <param name="graphics">The graphics.</param>
			/// <param name="region">The region.</param>
			public void SetRegion(System.Drawing.Graphics graphics, System.Drawing.Region region)
			{
				hRgnBlur = region.GetHrgn(graphics);
				dwFlags |= DWM_BLURBEHIND_Mask.DWM_BB_BLURREGION;
			}
		}

		/// <summary>Structure to get colorization information using the <see cref="PVanara.PInvokeDwmGetColorizationParameters"/> function.</summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("dwmapi.h")]
		public struct DWM_COLORIZATION_PARAMS
		{
			/// <summary>The ARGB accent color.</summary>
			public uint clrColor;

			/// <summary>The ARGB after glow color.</summary>
			public uint clrAfterGlow;

			/// <summary>Determines how much the glass streaks are visible in window borders.</summary>
			public uint nIntensity;

			/// <summary>Determines how bright the glass is (0 removes all color from borders).</summary>
			public uint clrAfterGlowBalance;

			/// <summary>Determines how bright the blur is.</summary>
			public uint clrBlurBalance;

			/// <summary>Determines how much the glass reflection is visible.</summary>
			public uint clrGlassReflectionIntensity;

			/// <summary>Determines if borders are opaque ( <c>true</c>) or transparent ( <c>false</c>).</summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fOpaque;
		}

		/// <summary>Specifies Desktop Window Manager (DWM) thumbnail properties. Used by the DwmUpdateThumbnailProperties function.</summary>
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct DWM_THUMBNAIL_PROPERTIES
		{
			/// <summary>A bitwise combination of DWM thumbnail constant values that indicates which members of this structure are set.</summary>
			public DWM_TNP dwFlags;

			/// <summary>The area in the destination window where the thumbnail will be rendered.</summary>
			public RECT rcDestination;

			/// <summary>The region of the source window to use as the thumbnail. By default, the entire window is used as the thumbnail.</summary>
			public RECT rcSource;

			/// <summary>The opacity with which to render the thumbnail. 0 is fully transparent while 255 is fully opaque. The default value is 255.</summary>
			public byte opacity;

			/// <summary>TRUE to make the thumbnail visible; otherwise, FALSE. The default is FALSE.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool fVisible;

			/// <summary>TRUE to use only the thumbnail source's client area; otherwise, FALSE. The default is FALSE.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool fSourceClientAreaOnly;
		}

		/// <summary>Specifies Desktop Window Manager (DWM) composition timing information. Used by the DwmGetCompositionTimingInfo function.</summary>
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		[PInvokeData("dwmapi.h")]
		public struct DWM_TIMING_INFO
		{
			/// <summary>The size of this DWM_TIMING_INFO structure.</summary>
			public int cbSize;

			/// <summary>The monitor refresh rate.</summary>
			public UNSIGNED_RATIO rateRefresh;

			/// <summary>The monitor refresh period.</summary>
			public ulong qpcRefreshPeriod;

			/// <summary>The composition rate.</summary>
			public UNSIGNED_RATIO rateCompose;

			/// <summary>The query performance counter value before the vertical blank.</summary>
			public ulong qpcVBlank;

			/// <summary>The DWM refresh counter.</summary>
			public ulong cRefresh;

			/// <summary>The DirectX refresh counter.</summary>
			public uint cDXRefresh;

			/// <summary>The query performance counter value for a frame composition.</summary>
			public ulong qpcCompose;

			/// <summary>The frame number that was composed at qpcCompose.</summary>
			public ulong cFrame;

			/// <summary>The DirectX present number used to identify rendering frames.</summary>
			public uint cDXPresent;

			/// <summary>The refresh count of the frame that was composed at qpcCompose.</summary>
			public ulong cRefreshFrame;

			/// <summary>The DWM frame number that was last submitted.</summary>
			public ulong cFrameSubmitted;

			/// <summary>The DirectX present number that was last submitted.</summary>
			public uint cDXPresentSubmitted;

			/// <summary>The DWM frame number that was last confirmed as presented.</summary>
			public ulong cFrameConfirmed;

			/// <summary>The DirectX present number that was last confirmed as presented.</summary>
			public uint cDXPresentConfirmed;

			/// <summary>The target refresh count of the last frame confirmed as completed by the GPU.</summary>
			public ulong cRefreshConfirmed;

			/// <summary>The DirectX refresh count when the frame was confirmed as presented.</summary>
			public uint cDXRefreshConfirmed;

			/// <summary>The number of frames the DWM presented late.</summary>
			public ulong cFramesLate;

			/// <summary>The number of composition frames that have been issued but have not been confirmed as completed.</summary>
			public uint cFramesOutstanding;

			/// <summary>The last frame displayed.</summary>
			public ulong cFrameDisplayed;

			/// <summary>The QPC time of the composition pass when the frame was displayed.</summary>
			public ulong qpcFrameDisplayed;

			/// <summary>The vertical refresh count when the frame should have become visible.</summary>
			public ulong cRefreshFrameDisplayed;

			/// <summary>The ID of the last frame marked as completed.</summary>
			public ulong cFrameComplete;

			/// <summary>The QPC time when the last frame was marked as completed.</summary>
			public ulong qpcFrameComplete;

			/// <summary>The ID of the last frame marked as pending.</summary>
			public ulong cFramePending;

			/// <summary>The QPC time when the last frame was marked as pending.</summary>
			public ulong qpcFramePending;

			/// <summary>The number of unique frames displayed. This value is valid only after a second call to the DwmGetCompositionTimingInfo function.</summary>
			public ulong cFramesDisplayed;

			/// <summary>The number of new completed frames that have been received.</summary>
			public ulong cFramesComplete;

			/// <summary>The number of new frames submitted to DirectX but not yet completed.</summary>
			public ulong cFramesPending;

			/// <summary>The number of frames available but not displayed, used, or dropped. This value is valid only after a second call to DwmGetCompositionTimingInfo.</summary>
			public ulong cFramesAvailable;

			/// <summary>
			/// The number of rendered frames that were never displayed because composition occurred too late. This value is valid only after a second call to DwmGetCompositionTimingInfo.
			/// </summary>
			public ulong cFramesDropped;

			/// <summary>The number of times an old frame was composed when a new frame should have been used but was not available.</summary>
			public ulong cFramesMissed;

			/// <summary>The frame count at which the next frame is scheduled to be displayed.</summary>
			public ulong cRefreshNextDisplayed;

			/// <summary>The frame count at which the next DirectX present is scheduled to be displayed.</summary>
			public ulong cRefreshNextPresented;

			/// <summary>The total number of refreshes that have been displayed for the application since the DwmSetPresentParameters function was last called.</summary>
			public ulong cRefreshesDisplayed;

			/// <summary>The total number of refreshes that have been presented by the application since DwmSetPresentParameters was last called.</summary>
			public ulong cRefreshesPresented;

			/// <summary>The refresh number when content for this window started to be displayed.</summary>
			public ulong cRefreshStarted;

			/// <summary>The total number of pixels DirectX redirected to the DWM.</summary>
			public ulong cPixelsReceived;

			/// <summary>The number of pixels drawn.</summary>
			public ulong cPixelsDrawn;

			/// <summary>The number of empty buffers in the flip chain.</summary>
			public ulong cBuffersEmpty;
		}

		/// <summary>Returned by the GetThemeMargins function to define the margins of windows that have visual styles applied.</summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("dwmapi.h")]
		public struct MARGINS
		{
			/// <summary>Width of the left border that retains its size.</summary>
			public int cxLeftWidth;

			/// <summary>Width of the right border that retains its size.</summary>
			public int cxRightWidth;

			/// <summary>Height of the top border that retains its size.</summary>
			public int cyTopHeight;

			/// <summary>Height of the bottom border that retains its size.</summary>
			public int cyBottomHeight;

			/// <summary>Retrieves a <see cref="MARGINS"/> instance with all values set to 0.</summary>
			public static readonly MARGINS Empty = new MARGINS(0);

			/// <summary>Retrieves a <see cref="MARGINS"/> instance with all values set to -1.</summary>
			public static readonly MARGINS Infinite = new MARGINS(-1);

			/// <summary>Initializes a new instance of the <see cref="MARGINS"/> struct.</summary>
			/// <param name="left">The left border value.</param>
			/// <param name="right">The right border value.</param>
			/// <param name="top">The top border value.</param>
			/// <param name="bottom">The bottom border value.</param>
			public MARGINS(int left, int right, int top, int bottom)
			{
				cxLeftWidth = left;
				cxRightWidth = right;
				cyTopHeight = top;
				cyBottomHeight = bottom;
			}

			/// <summary>Initializes a new instance of the <see cref="MARGINS"/> struct.</summary>
			/// <param name="allMargins">Value to assign to all margins.</param>
			public MARGINS(int allMargins)
			{
				cxLeftWidth = cxRightWidth = cyTopHeight = cyBottomHeight = allMargins;
			}

			/// <summary>Gets or sets the left border value.</summary>
			/// <value>The left border.</value>
			public int Left { get => cxLeftWidth; set => cxLeftWidth = value; }

			/// <summary>Gets or sets the right border value.</summary>
			/// <value>The right border.</value>
			public int Right { get => cxRightWidth; set => cxRightWidth = value; }

			/// <summary>Gets or sets the top border value.</summary>
			/// <value>The top border.</value>
			public int Top { get => cyTopHeight; set => cyTopHeight = value; }

			/// <summary>Gets or sets the bottom border value.</summary>
			/// <value>The bottom border.</value>
			public int Bottom { get => cyBottomHeight; set => cyBottomHeight = value; }

			/// <summary>Determines if two <see cref="MARGINS"/> values are not equal.</summary>
			/// <param name="m1">The first margin.</param>
			/// <param name="m2">The second margin.</param>
			/// <returns><c>true</c> if the values are unequal; <c>false</c> otherwise.</returns>
			public static bool operator !=(MARGINS m1, MARGINS m2) => !m1.Equals(m2);

			/// <summary>Determines if two <see cref="MARGINS"/> values are equal.</summary>
			/// <param name="m1">The first margin.</param>
			/// <param name="m2">The second margin.</param>
			/// <returns><c>true</c> if the values are equal; <c>false</c> otherwise.</returns>
			public static bool operator ==(MARGINS m1, MARGINS m2) => m1.Equals(m2);

			/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
			/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
			/// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
			public override bool Equals(object obj) => obj is MARGINS m2
				? cxLeftWidth == m2.cxLeftWidth && cxRightWidth == m2.cxRightWidth && cyTopHeight == m2.cyTopHeight &&
				  cyBottomHeight == m2.cyBottomHeight
				: base.Equals(obj);

			/// <summary>Returns a hash code for this instance.</summary>
			/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
			public override int GetHashCode()
			{
				int RotateLeft(int value, int nBits)
				{
					nBits = nBits % 0x20;
					return (value << nBits) | (value >> (0x20 - nBits));
				}
				return cxLeftWidth ^ RotateLeft(cyTopHeight, 8) ^ RotateLeft(cxRightWidth, 0x10) ^ RotateLeft(cyBottomHeight, 0x18);
			}

			/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
			/// <returns>A <see cref="string"/> that represents this instance.</returns>
			public override string ToString() => $"{{Left={cxLeftWidth},Right={cxRightWidth},Top={cyTopHeight},Bottom={cyBottomHeight}}}";
		}

		/// <summary>
		/// Defines a data type used by the Desktop Window Manager (DWM) APIs. It represents a generic ratio and is used for different purposes and units even
		/// within a single API.
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("dwmapi.h")]
		public struct UNSIGNED_RATIO
		{
			/// <summary>The ratio numerator.</summary>
			public uint uiNumerator;

			/// <summary>The ratio denominator.</summary>
			public uint uiDenominator;
		}
	}
}