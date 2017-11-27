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

		/// <summary>Flags used by the DwmGetWindowAttribute and DwmSetWindowAttribute functions to specify window attributes for non-client rendering.</summary>
		[PInvokeData("dwmapi.h")]
		public enum DWMWINDOWATTRIBUTE
		{
			/// <summary>Use with DwmGetWindowAttribute. Discovers whether non-client rendering is enabled. The retrieved value is of type BOOL. TRUE if non-client rendering is enabled; otherwise, FALSE.</summary>
			DWMWA_NCRENDERING_ENABLED = 1,
			/// <summary>Use with DwmSetWindowAttribute. Sets the non-client rendering policy. The pvAttribute parameter points to a value from the DWMNCRENDERINGPOLICY enumeration.</summary>
			DWMWA_NCRENDERING_POLICY,
			/// <summary>Use with DwmSetWindowAttribute. Enables or forcibly disables DWM transitions. The pvAttribute parameter points to a value of TRUE to disable transitions or FALSE to enable transitions.</summary>
			DWMWA_TRANSITIONS_FORCEDISABLED,
			/// <summary>Use with DwmSetWindowAttribute. Enables content rendered in the non-client area to be visible on the frame drawn by DWM. The pvAttribute parameter points to a value of TRUE to enable content rendered in the non-client area to be visible on the frame; otherwise, it points to FALSE.</summary>
			DWMWA_ALLOW_NCPAINT,
			/// <summary>Use with DwmGetWindowAttribute. Retrieves the bounds of the caption button area in the window-relative space. The retrieved value is of type RECT.</summary>
			DWMWA_CAPTION_BUTTON_BOUNDS,
			/// <summary>Use with DwmSetWindowAttribute. Specifies whether non-client content is right-to-left (RTL) mirrored. The pvAttribute parameter points to a value of TRUE if the non-client content is right-to-left (RTL) mirrored; otherwise, it points to FALSE.</summary>
			DWMWA_NONCLIENT_RTL_LAYOUT,
			/// <summary>Use with DwmSetWindowAttribute. Forces the window to display an iconic thumbnail or peek representation (a static bitmap), even if a live or snapshot representation of the window is available. This value normally is set during a window's creation and not changed throughout the window's lifetime. Some scenarios, however, might require the value to change over time. The pvAttribute parameter points to a value of TRUE to require a iconic thumbnail or peek representation; otherwise, it points to FALSE.</summary>
			DWMWA_FORCE_ICONIC_REPRESENTATION,
			/// <summary>Use with DwmSetWindowAttribute. Sets how Flip3D treats the window. The pvAttribute parameter points to a value from the DWMFLIP3DWINDOWPOLICY enumeration.</summary>
			DWMWA_FLIP3D_POLICY,
			/// <summary>Use with DwmGetWindowAttribute. Retrieves the extended frame bounds rectangle in screen space. The retrieved value is of type RECT.</summary>
			DWMWA_EXTENDED_FRAME_BOUNDS,
			/// <summary>Use with DwmSetWindowAttribute. The window will provide a bitmap for use by DWM as an iconic thumbnail or peek representation (a static bitmap) for the window. DWMWA_HAS_ICONIC_BITMAP can be specified with DWMWA_FORCE_ICONIC_REPRESENTATION. DWMWA_HAS_ICONIC_BITMAP normally is set during a window's creation and not changed throughout the window's lifetime. Some scenarios, however, might require the value to change over time. The pvAttribute parameter points to a value of TRUE to inform DWM that the window will provide an iconic thumbnail or peek representation; otherwise, it points to FALSE.
			/// <para><c>Windows Vista and earlier:</c> This value is not supported.</para></summary>
			DWMWA_HAS_ICONIC_BITMAP,
			/// <summary>Use with DwmSetWindowAttribute. Do not show peek preview for the window. The peek view shows a full-sized preview of the window when the mouse hovers over the window's thumbnail in the taskbar. If this attribute is set, hovering the mouse pointer over the window's thumbnail dismisses peek (in case another window in the group has a peek preview showing). The pvAttribute parameter points to a value of TRUE to prevent peek functionality or FALSE to allow it.
			/// <para><c>Windows Vista and earlier:</c> This value is not supported.</para></summary>
			DWMWA_DISALLOW_PEEK,
			/// <summary>Use with DwmSetWindowAttribute. Prevents a window from fading to a glass sheet when peek is invoked. The pvAttribute parameter points to a value of TRUE to prevent the window from fading during another window's peek or FALSE for normal behavior.
			/// <para><c>Windows Vista and earlier:</c> This value is not supported.</para></summary>
			DWMWA_EXCLUDED_FROM_PEEK,
			/// <summary>Use with DwmGetWindowAttribute. Cloaks the window such that it is not visible to the user. The window is still composed by DWM.
			/// <para><c>Using with DirectComposition:</c> Use the DWMWA_CLOAK flag to cloak the layered child window when animating a representation of the window's content via a DirectComposition visual which has been associated with the layered child window. For more details on this usage case, see How to How to animate the bitmap of a layered child window.</para>
			/// <para><c>Windows 7 and earlier:</c> This value is not supported.</para></summary>
			DWMWA_CLOAK,
			/// <summary>Use with DwmGetWindowAttribute. If the window is cloaked, provides one of the following values explaining why:
			/// <list type="table">
			/// <listheader><term>Name (Value)</term><definition>Meaning</definition></listheader>
			/// <item><term>DWM_CLOAKED_APP 0x0000001</term><definition>The window was cloaked by its owner application.</definition></item>
			/// <item><term>DWM_CLOAKED_SHELL 0x0000002</term><definition>The window was cloaked by the Shell.</definition></item>
			/// <item><term>DWM_CLOAKED_INHERITED 0x0000004</term><definition>The cloak value was inherited from its owner window.</definition></item>
			/// </list>
			/// <para><c>Windows 7 and earlier:</c> This value is not supported.</para></summary>
			DWMWA_CLOAKED,
			/// <summary>Use with DwmSetWindowAttribute. Freeze the window's thumbnail image with its current visuals. Do no further live updates on the thumbnail image to match the window's contents.
			/// <para><c>Windows 7 and earlier:</c> This value is not supported.</para></summary>
			DWMWA_FREEZE_REPRESENTATION,
		}

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

		/// <summary>Extends the window frame into the client area.</summary>
		/// <param name="hWnd">The handle to the window in which the frame will be extended into the client area.</param>
		/// <param name="pMarInset">A pointer to a MARGINS structure that describes the margins to use when extending the frame into the client area.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.DwmApi, ExactSpelling = true)]
		[System.Security.SecurityCritical]
		[PInvokeData("dwmapi.h")]
		public static extern HRESULT DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

		//[DllImport(Lib.DwmApi, ExactSpelling = true)]
		//public static extern HRESULT DwmGetColorizationColor(out uint ColorizationColor, [MarshalAs(UnmanagedType.Bool)]out bool ColorizationOpaqueBlend);

		/// <summary>Gets the colorization parameters.</summary>
		/// <param name="parameters">The parameters.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.DwmApi, EntryPoint = "#127")]
		[System.Security.SecurityCritical]
		[PInvokeData("dwmapi.h")]
		public static extern HRESULT DwmGetColorizationParameters(ref DWM_COLORIZATION_PARAMS parameters);

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
		/// A value that, when this function returns successfully, receives the current value of the attribute. The type of the retrieved value
		/// depends on the value of the dwAttribute parameter.
		/// </param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[PInvokeData("dwmapi.h")]
		public static HRESULT DwmGetWindowAttribute<T>(IntPtr hwnd, DWMWINDOWATTRIBUTE dwAttribute, out T pvAttribute)
		{
			var isBool = typeof(T) == typeof(bool);
			if (!(typeof(T) == typeof(RECT) || isBool || typeof(T) == typeof(int) || typeof(T).IsEnum)) throw new ArgumentException();
			var m = new SafeCoTaskMemHandle(Marshal.SizeOf(isBool ? typeof(uint) : typeof(T)));
			var hr = DwmGetWindowAttribute(hwnd, dwAttribute, (IntPtr)m, m.Size);
			pvAttribute = isBool ? (T) Convert.ChangeType(m.ToStructure<uint>(), typeof(bool)) : m.ToStructure<T>();
			return hr;
		}

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

		/// <summary>Sets the colorization parameters.</summary>
		/// <param name="parameters">The parameters.</param>
		/// <param name="unk">Always set to 1.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.DwmApi, EntryPoint = "#131")]
		[System.Security.SecurityCritical]
		[PInvokeData("dwmapi.h")]
		public static extern HRESULT DwmSetColorizationParameters(ref DWM_COLORIZATION_PARAMS parameters, uint unk);

		/// <summary>Sets the value of non-client rendering attributes for a window.</summary>
		/// <param name="hwnd">The handle to the window that will receive the attributes.</param>
		/// <param name="dwAttribute">A single DWMWINDOWATTRIBUTE flag to apply to the window. This parameter specifies the attribute and the pvAttribute parameter points to the value of that attribute.</param>
		/// <param name="pvAttribute">A pointer to the value of the attribute specified in the dwAttribute parameter. Different DWMWINDOWATTRIBUTE flags require different value types.</param>
		/// <param name="cbAttribute">The size, in bytes, of the value type pointed to by the pvAttribute parameter.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.DwmApi, ExactSpelling = true)]
		[System.Security.SecurityCritical]
		[PInvokeData("dwmapi.h")]
		public static extern HRESULT DwmSetWindowAttribute(IntPtr hwnd, DWMWINDOWATTRIBUTE dwAttribute, [In] IntPtr pvAttribute, int cbAttribute);

		/// <summary>Sets the value of non-client rendering attributes for a window.</summary>
		/// <param name="hwnd">The handle to the window that will receive the attributes.</param>
		/// <param name="dwAttribute">A single DWMWINDOWATTRIBUTE flag to apply to the window. This parameter specifies the attribute and the pvAttribute parameter points to the value of that attribute.</param>
		/// <param name="pvAttribute">The value of the attribute specified in the dwAttribute parameter. Different DWMWINDOWATTRIBUTE flags require different value types.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[PInvokeData("dwmapi.h")]
		public static HRESULT DwmSetWindowAttribute<T>(IntPtr hwnd, DWMWINDOWATTRIBUTE dwAttribute, [In] T pvAttribute)
		{
			if (pvAttribute == null || !(pvAttribute is bool || pvAttribute is int || typeof(T).IsEnum)) throw new ArgumentException();
			var attr = pvAttribute is bool ? (object)Convert.ToUInt32(pvAttribute) : pvAttribute;
			using (var p = new PinnedObject(attr))
				return DwmSetWindowAttribute(hwnd, dwAttribute, p, Marshal.SizeOf(attr));
		}

		/// <summary>Specifies Desktop Window Manager (DWM) blur-behind properties. Used by the DwmEnableBlurBehindWindow function.</summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("dwmapi.h")]
		public struct DWM_BLURBEHIND
		{
			/// <summary>
			/// A bitwise combination of DWM Blur Behind constant values that indicates which of the members of this structure have been set.
			/// </summary>
			public DWM_BLURBEHIND_Mask dwFlags;
			/// <summary>
			/// TRUE to register the window handle to DWM blur behind; FALSE to unregister the window handle from DWM blur behind.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fEnable;
			/// <summary>
			/// The region within the client area where the blur behind will be applied. A NULL value will apply the blur behind the entire client area.
			/// </summary>
			public IntPtr hRgnBlur;
			/// <summary>
			/// TRUE if the window's colorization should transition to match the maximized windows; otherwise, FALSE.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fTransitionOnMaximized;

			/// <summary>
			/// Initializes a new instance of the <see cref="DWM_BLURBEHIND"/> struct.
			/// </summary>
			/// <param name="enabled">if set to <c>true</c> enabled.</param>
			public DWM_BLURBEHIND(bool enabled)
			{
				fEnable = enabled;
				hRgnBlur = IntPtr.Zero;
				fTransitionOnMaximized = false;
				dwFlags = DWM_BLURBEHIND_Mask.DWM_BB_ENABLE;
			}

			/// <summary>
			/// Gets the region.
			/// </summary>
			/// <value>
			/// The region.
			/// </value>
			public System.Drawing.Region Region => System.Drawing.Region.FromHrgn(hRgnBlur);

			/// <summary>
			/// Gets or sets a value indicating whether the window's colorization should transition to match the maximized windows.
			/// </summary>
			/// <value>
			///   <c>true</c> if the window's colorization should transition to match the maximized windows; otherwise, <c>false</c>.
			/// </value>
			public bool TransitionOnMaximized
			{
				get => fTransitionOnMaximized;
				set
				{
					fTransitionOnMaximized = value;
					dwFlags |= DWM_BLURBEHIND_Mask.DWM_BB_TRANSITIONONMAXIMIZED;
				}
			}

			/// <summary>
			/// Sets the region.
			/// </summary>
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
	}
}