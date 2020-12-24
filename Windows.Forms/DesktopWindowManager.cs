using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Security;
using System.Windows.Forms;
using Vanara.InteropServices;
using Vanara.PInvoke;
using static Vanara.PInvoke.DwmApi;

namespace Vanara.Windows.Forms
{
	/// <summary>Main DWM class, provides glass sheet effect and blur behind.</summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
	[SecuritySafeCritical]
	public static partial class DesktopWindowManager
	{
		internal static readonly ThumbnailMgr thumbnailMgr = new ThumbnailMgr();
		private static readonly object _lock = new object();
		private static readonly object colorizationColorChangedKey = new object();
		private static readonly object compositionChangedKey = new object();
		private static readonly object[] keys = { compositionChangedKey, nonClientRenderingChangedKey, colorizationColorChangedKey/*, WindowMaximizedChangedKey*/ };
		private static readonly object nonClientRenderingChangedKey = new object();
		private static EventHandlerList eventHandlerList;
		private static MessageWindow msgWin;

		/// <summary>Occurs when the colorization color has changed.</summary>
		public static event EventHandler ColorizationColorChanged
		{
			add { AddEventHandler(colorizationColorChangedKey, value); }
			remove { RemoveEventHandler(colorizationColorChangedKey, value); }
		}

		/// <summary>Occurs when the desktop window composition has been enabled or disabled.</summary>
		public static event EventHandler CompositionChanged
		{
			add { AddEventHandler(compositionChangedKey, value); }
			remove { RemoveEventHandler(compositionChangedKey, value); }
		}

		/// <summary>Occurs when the non-client area rendering policy has changed.</summary>
		public static event EventHandler NonClientRenderingChanged
		{
			add { AddEventHandler(nonClientRenderingChangedKey, value); }
			remove { RemoveEventHandler(nonClientRenderingChangedKey, value); }
		}

		/// <summary>
		/// Use with GetWindowAttr and WindowAttribute.Cloaked. If the window is cloaked, provides one of the following values explaining why.
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1714:FlagsEnumsShouldHavePluralNames")]
		[Flags]
		public enum CloakingSource
		{
			/// <summary>The window was cloaked by its owner application.</summary>
			App = 0x01,

			/// <summary>The window was cloaked by the Shell.</summary>
			Shell = 0x02,

			/// <summary>The cloak value was inherited from its owner window.</summary>
			Inherited = 0x04
		}

		/// <summary>Flags used by the SetWindowAttr method to specify the Flip3D window policy.</summary>
		public enum Flip3DWindowPolicy
		{
			/// <summary>
			/// Use the window's style and visibility settings to determine whether to hide or include the window in Flip3D rendering.
			/// </summary>
			Default,

			/// <summary>Exclude the window from Flip3D and display it below the Flip3D rendering.</summary>
			ExcludeBelow,

			/// <summary>Exclude the window from Flip3D and display it above the Flip3D rendering.</summary>
			ExcludeAbove
		}

		/// <summary>Flags used by the SetWindowAttr method to specify the non-client area rendering policy.</summary>
		public enum NonClientRenderingPolicy
		{
			/// <summary>The non-client rendering area is rendered based on the window style.</summary>
			UseWindowStyle,

			/// <summary>The non-client area rendering is disabled; the window style is ignored.</summary>
			Disabled,

			/// <summary>The non-client area rendering is enabled; the window style is ignored.</summary>
			Enabled
		}

		/// <summary>
		/// Gets or sets the current color used for Desktop Window Manager (DWM) glass composition. This value is based on the current color
		/// scheme and can be modified by the user.
		/// </summary>
		/// <value>The color of the glass composition.</value>
		public static Color CompositionColor
		{
			get
			{
				if (!CompositionSupported)
					return Color.Transparent;
				var value = (int)Microsoft.Win32.Registry.CurrentUser.GetValue(@"Software\Microsoft\Windows\DWM\ColorizationColor", 0);
				return Color.FromArgb(value);
			}
			set
			{
				if (!CompositionSupported)
					return;
				DwmpGetColorizationParameters(out var p).ThrowIfFailed();
				p.clrColor = value;
				DwmpSetColorizationParameters(p, 1).ThrowIfFailed();
				Microsoft.Win32.Registry.CurrentUser.SetValue(@"Software\Microsoft\Windows\DWM\ColorizationColor", value.ToArgb(), Microsoft.Win32.RegistryValueKind.DWord);
			}
		}

		/// <summary>Gets or sets a value indicating whether composition (Windows Aero) is enabled.</summary>
		/// <value><c>true</c> if composition is enabled; otherwise, <c>false</c>.</value>
		public static bool CompositionEnabled
		{
			get => IsCompositionEnabled();
			set { if (CompositionSupported) EnableComposition(value); }
		}

		/// <summary>Gets or sets a value indicating whether composition (Windows Aero) is supported.</summary>
		/// <value><c>true</c> if composition is supported; otherwise, <c>false</c>.</value>
		public static bool CompositionSupported => Environment.OSVersion.Version.Major >= 6;

		/// <summary>
		/// Gets a value notifying the Desktop Window Manager (DWM) to opt in to or out of Multimedia Class Schedule Service (MMCSS)
		/// scheduling while the calling process is alive.
		/// </summary>
		/// <value>
		/// <c>true</c> to instruct DWM to participate in MMCSS scheduling; otherwise, <c>false</c> to opt out or end participation in MMCSS scheduling.
		/// </value>
		public static bool MultimediaClassScheduleServiceEnabled { set => DwmEnableMMCSS(value).ThrowIfFailed(); }

		/// <summary>Gets or sets a value that indicates whether the <see cref="CompositionColor"/> is transparent.</summary>
		/// <value><c>true</c> if transparent; otherwise, <c>false</c>.</value>
		public static bool TransparencyEnabled
		{
			get
			{
				if (!CompositionSupported)
					return false;
				var value = (int)Microsoft.Win32.Registry.CurrentUser.GetValue(@"Software\Microsoft\Windows\DWM\ColorizationOpaqueBlend", 1);
				return value == 0;
			}
			set
			{
				if (!CompositionSupported)
					return;
				DwmpGetColorizationParameters(out var p).ThrowIfFailed();
				p.fOpaque = value;
				DwmpSetColorizationParameters(p, 1).ThrowIfFailed();
				Microsoft.Win32.Registry.CurrentUser.SetValue(@"Software\Microsoft\Windows\DWM\ColorizationOpaqueBlend", p.fOpaque, Microsoft.Win32.RegistryValueKind.DWord);
			}
		}

		/*/// <summary>
		/// Occurs when a Desktop Window Manager (DWM) composed window is maximized. </summary>
		public static event EventHandler WindowMaximizedChanged
		{
			add { AddEventHandler(WindowMaximizedChangedKey, value); }
			remove { RemoveEventHandler(WindowMaximizedChangedKey, value); }
		}*/

		/// <summary>Enables content rendered in the non-client area to be visible on the frame drawn by DWM.</summary>
		/// <param name="form">The form.</param>
		/// <param name="allowNCPaint">
		/// Set to <c>true</c> to enable content rendered in the non-client area to be visible on the frame; otherwise, <c>false</c>.
		/// </param>
		public static void AllowNonClientPainting(this Form form, bool allowNCPaint) => SetWindowAttribute(form, DWMWINDOWATTRIBUTE.DWMWA_ALLOW_NCPAINT, allowNCPaint);

		/// <summary>Cloaks the window such that it is not visible to the user. The window is still composed by DWM.</summary>
		/// <param name="form">The form.</param>
		/// <param name="cloak">If set to <c>true</c>, cloak.</param>
		public static void Cloak(this Form form, bool cloak) => SetWindowAttribute(form, DWMWINDOWATTRIBUTE.DWMWA_CLOAK, cloak);

		/// <summary>Enables or forcibly disables DWM transitions.</summary>
		/// <param name="form">The form.</param>
		/// <param name="forceDisabled"><c>true</c> to disable transitions.</param>
		public static void DisableTransitions(this Form form, bool forceDisabled) => SetWindowAttribute(form, DWMWINDOWATTRIBUTE.DWMWA_TRANSITIONS_FORCEDISABLED, forceDisabled);

		/// <summary>
		/// Do not show peek preview for the window. The peek view shows a full-sized preview of the window when the mouse hovers over the
		/// window's thumbnail in the taskbar.
		/// </summary>
		/// <param name="form">The form.</param>
		/// <param name="disallowPeek">
		/// if set to <c>true</c>, hovering the mouse pointer over the window's thumbnail dismisses peek (in case another window in the group
		/// has a peek preview showing).
		/// </param>
		public static void DisallowPeekPreview(this Form form, bool disallowPeek) => SetWindowAttribute(form, DWMWINDOWATTRIBUTE.DWMWA_DISALLOW_PEEK, disallowPeek);

		/// <summary>Enable the Aero "Blur Behind" effect on the whole client area. Background must be black.</summary>
		/// <param name="window">The window.</param>
		/// <param name="enabled"><c>true</c> to enable blur behind for this window, <c>false</c> to disable it.</param>
		public static void EnableBlurBehind(this IWin32Window window, bool enabled) => EnableBlurBehind(window, null, null, enabled, false);

		/// <summary>Enable the Aero "Blur Behind" effect on a specific region of a drawing area. Background must be black.</summary>
		/// <param name="window">The window.</param>
		/// <param name="graphics">The graphics area on which the region resides.</param>
		/// <param name="region">The region within the client area to apply the blur behind.</param>
		/// <param name="enabled"><c>true</c> to enable blur behind for this region, <c>false</c> to disable it.</param>
		/// <param name="transitionOnMaximized">
		/// <c>true</c> if the window's colorization should transition to match the maximized windows; otherwise, <c>false</c>.
		/// </param>
		public static void EnableBlurBehind(this IWin32Window window, Graphics graphics, Region region, bool enabled, bool transitionOnMaximized)
		{
			if (window == null)
				throw new ArgumentNullException(nameof(window));
			var bb = new DWM_BLURBEHIND(enabled);
			if (graphics != null && region != null)
				bb.SetRegion(graphics, region);
			if (transitionOnMaximized)
				bb.TransitionOnMaximized = true;
			DwmEnableBlurBehindWindow(window.Handle, bb);
		}

		/// <summary>Enables or disables Desktop Window Manager (DWM) composition.</summary>
		/// <param name="value"><c>true</c> to enable DWM composition; <c>false</c> to disable composition.</param>
		public static void EnableComposition(bool value) => DwmEnableComposition(value);

		/// <summary>Excludes the specified child control from the glass effect.</summary>
		/// <param name="parent">The parent control.</param>
		/// <param name="control">The control to exclude.</param>
		/// <exception cref="ArgumentNullException">Occurs if control is null.</exception>
		/// <exception cref="ArgumentException">Occurs if control is not a child control.</exception>
		public static void ExcludeChildFromGlass(this Control parent, Control control)
		{
			if (parent == null)
				throw new ArgumentNullException(nameof(parent));
			if (control == null)
				throw new ArgumentNullException(nameof(control));
			if (!parent.Contains(control))
				throw new ArgumentException("Control must be a child control.");

			if (IsCompositionEnabled())
			{
				var clientScreen = parent.RectangleToScreen(parent.ClientRectangle);
				var controlScreen = control.RectangleToScreen(control.ClientRectangle);

				var margins = new MARGINS(controlScreen.Left - clientScreen.Left, controlScreen.Top - clientScreen.Top,
					clientScreen.Right - controlScreen.Right, clientScreen.Bottom - controlScreen.Bottom);

				// Extend the Frame into client area
				DwmExtendFrameIntoClientArea(parent.Handle, margins);
			}
		}

		/// <summary>Extends the window frame beyond the client area.</summary>
		/// <param name="window">The window.</param>
		/// <param name="padding">The padding to use as the area into which the frame is extended.</param>
		public static void ExtendFrameIntoClientArea(this IWin32Window window, Padding padding)
		{
			if (window == null)
				throw new ArgumentNullException(nameof(window));
			var m = new MARGINS(padding.Left, padding.Right, padding.Top, padding.Bottom);
			DwmExtendFrameIntoClientArea(window.Handle, m);
		}

		/// <summary>
		/// Issues a flush call that blocks the caller until the next present, when all of the Microsoft DirectX surface updates that are
		/// currently outstanding have been made. This compensates for very complex scenes or calling processes with very low priority.
		/// </summary>
		public static void Flush() => DwmFlush().ThrowIfFailed();

		/// <summary>
		/// Forces the window to display an iconic thumbnail or peek representation (a static bitmap), even if a live or snapshot
		/// representation of the window is available. This value normally is set during a window's creation and not changed throughout the
		/// window's lifetime. Some scenarios, however, might require the value to change over time.
		/// </summary>
		/// <param name="form">The form.</param>
		/// <param name="iconRep"><c>true</c> to require a iconic thumbnail or peek representation; otherwise, <c>false</c>.</param>
		public static void ForceIconicRepresentation(this Form form, bool iconRep) => SetWindowAttribute(form, DWMWINDOWATTRIBUTE.DWMWA_FORCE_ICONIC_REPRESENTATION, iconRep);

		/// <summary>
		/// Freeze the window's thumbnail image with its current visuals. Do no further live updates on the thumbnail image to match the
		/// window's contents.
		/// </summary>
		/// <param name="form">The form.</param>
		/// <param name="freeze">if set to <c>true</c> freeze thumbnail.</param>
		public static void FreezeLiveThumbnail(this Form form, bool freeze) => SetWindowAttribute(form, DWMWINDOWATTRIBUTE.DWMWA_FREEZE_REPRESENTATION, freeze);

		/// <summary>Retrieves the bounds of the caption button area in the window-relative space.</summary>
		/// <param name="form">The form.</param>
		/// <returns>The bounds.</returns>
		public static Rectangle GetCaptionButtonBounds(this Form form) => GetWindowAttribute<RECT>(form, DWMWINDOWATTRIBUTE.DWMWA_CAPTION_BUTTON_BOUNDS);

		/// <summary>If the window is cloaked, provides a value explaining why.</summary>
		/// <param name="form">The form.</param>
		/// <returns>The reason the window is cloaked.</returns>
		public static CloakingSource GetCloakingSource(this Form form) => (CloakingSource)GetWindowAttribute<DWM_CLOAKED>(form, DWMWINDOWATTRIBUTE.DWMWA_CLOAKED);

		/// <summary>Retrieves the extended frame bounds rectangle in screen space.</summary>
		/// <param name="form">The form.</param>
		/// <returns>The bounds.</returns>
		public static Rectangle GetExtendedFrameBounds(this Form form) => GetWindowAttribute<RECT>(form, DWMWINDOWATTRIBUTE.DWMWA_EXTENDED_FRAME_BOUNDS);

		/// <summary>Gets the live client thumbnail.</summary>
		/// <param name="window">The window.</param>
		/// <returns></returns>
		public static LiveThumbnail GetLiveClientThumbnail(this IWin32Window window) => new LiveThumbnail(window);

		/// <summary>
		/// The window will provide a bitmap for use by DWM as an iconic thumbnail or peek representation (a static bitmap) for the window.
		/// DWMWA_HAS_ICONIC_BITMAP can be specified with DWMWA_FORCE_ICONIC_REPRESENTATION. DWMWA_HAS_ICONIC_BITMAP normally is set during a
		/// window's creation and not changed throughout the window's lifetime. Some scenarios, however, might require the value to change
		/// over time.
		/// </summary>
		/// <param name="form">The form.</param>
		/// <param name="hasIcon">if set to <c>true</c> inform DWM that the window will provide an iconic thumbnail or peek representation.</param>
		public static void HasIconicBitmap(this Form form, bool hasIcon) => SetWindowAttribute(form, DWMWINDOWATTRIBUTE.DWMWA_HAS_ICONIC_BITMAP, hasIcon);

		/// <summary>
		/// Called by an application to indicate that all previously provided iconic bitmaps from a window, both thumbnails and peek
		/// representations, should be refreshed.
		/// </summary>
		/// <param name="window">
		/// The window or tab whose bitmaps are being invalidated through this call. This window must belong to the calling process.
		/// </param>
		public static void InvalidateIconicBitmaps(this IWin32Window window) => DwmInvalidateIconicBitmaps(window.Handle).ThrowIfFailed();

		/// <summary>Discovers whether non-client rendering is enabled.</summary>
		/// <param name="form">The form.</param>
		/// <returns><c>true</c> if non client rendering is enabled; otherwise, <c>false</c>.</returns>
		public static bool IsNonClientRenderingEnabled(this Form form) => GetWindowAttribute<bool>(form, DWMWINDOWATTRIBUTE.DWMWA_NCRENDERING_ENABLED);

		/// <summary>Specifies whether non-client content is right-to-left (RTL) mirrored.</summary>
		/// <param name="form">The form.</param>
		/// <param name="rtl">if set to <c>true</c> the non-client content is right-to-left (RTL) mirrored.</param>
		public static void NonClientRightToLeft(this Form form, bool rtl) => SetWindowAttribute(form, DWMWINDOWATTRIBUTE.DWMWA_NONCLIENT_RTL_LAYOUT, rtl);

		/// <summary>Prevents a window from fading to a glass sheet when peek is invoked.</summary>
		/// <param name="form">The form.</param>
		/// <param name="prevent">if set to <c>true</c> prevent the window from fading during another window's peek.</param>
		public static void PreventFadingOnPeekPreview(this Form form, bool prevent) => SetWindowAttribute(form, DWMWINDOWATTRIBUTE.DWMWA_EXCLUDED_FROM_PEEK, prevent);

		/// <summary>Sets how Flip3D treats the window.</summary>
		/// <param name="form">The form.</param>
		/// <param name="policy">The policy.</param>
		public static void SetFlip3DPolicy(this Form form, Flip3DWindowPolicy policy) => SetWindowAttribute(form, DWMWINDOWATTRIBUTE.DWMWA_FLIP3D_POLICY, (DWMFLIP3DWINDOWPOLICY)policy);

		/// <summary>Sets the non-client rendering policy.</summary>
		/// <param name="form">The form.</param>
		/// <param name="policy">The policy.</param>
		public static void SetNonClientRenderingPolicy(this Form form, NonClientRenderingPolicy policy) => SetWindowAttribute(form, DWMWINDOWATTRIBUTE.DWMWA_NCRENDERING_POLICY, (DWMNCRENDERINGPOLICY)policy);

		private static void AddEventHandler(object id, EventHandler value)
		{
			lock (_lock)
			{
				if (msgWin == null)
					msgWin = new MessageWindow();
				if (eventHandlerList == null)
					eventHandlerList = new EventHandlerList();
				eventHandlerList.AddHandler(id, value);
			}
		}

		/// <summary>Gets the specified window attribute from the Desktop Window Manager (DWM).</summary>
		/// <typeparam name="T">Return type. Must match the attribute.</typeparam>
		/// <param name="window">The window.</param>
		/// <param name="attribute">The attribute.</param>
		/// <returns>Value of the windows attribute.</returns>
		private static T GetWindowAttribute<T>(this IWin32Window window, DWMWINDOWATTRIBUTE attribute) where T : struct
		{
			if (window == null)
				throw new ArgumentNullException(nameof(window));
			using (var ptr = SafeCoTaskMemHandle.CreateFromStructure<T>())
			{
				DwmGetWindowAttribute(window.Handle, attribute, (IntPtr)ptr, ptr.Size);
				return ptr.ToStructure<T>();
			}
		}

		/// <summary>Indicates whether Desktop Window Manager (DWM) composition is enabled.</summary>
		/// <returns><c>true</c> if is composition enabled; otherwise, <c>false</c>.</returns>
		private static bool IsCompositionEnabled()
		{
			if (!CompositionSupported || !System.IO.File.Exists(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), @"dwmapi.dll")))
				return false;
			DwmIsCompositionEnabled(out var res);
			return res;
		}

		private static void RemoveEventHandler(object id, EventHandler value)
		{
			lock (_lock)
			{
				eventHandlerList?.RemoveHandler(id, value);
			}
		}

		/// <summary>Sets the specified window attribute through the Desktop Window Manager (DWM).</summary>
		/// <param name="window">The window.</param>
		/// <param name="attribute">The attribute.</param>
		/// <param name="value">The value.</param>
		private static void SetWindowAttribute<T>(this IWin32Window window, DWMWINDOWATTRIBUTE attribute, T value) where T : struct
		{
			if (window == null)
				throw new ArgumentNullException(nameof(window));
			using (var ptr = SafeCoTaskMemHandle.CreateFromStructure(value))
				DwmSetWindowAttribute(window.Handle, attribute, (IntPtr)ptr, ptr.Size);
		}

		internal class ThumbnailMgr : IDisposable
		{
			private Dictionary<IntPtr, HTHUMBNAIL> thumbnails = new Dictionary<IntPtr, HTHUMBNAIL>();

			public ThumbnailMgr()
			{
			}

			public void Dispose()
			{
				foreach (var hThumb in thumbnails.Values)
					DwmUnregisterThumbnail(hThumb);
				thumbnails = null;
			}

			public HTHUMBNAIL Register(IWin32Window win)
			{
				if (thumbnails.TryGetValue(win.Handle, out var hThumbnail))
				{
					DwmUnregisterThumbnail(hThumbnail);
					thumbnails.Remove(win.Handle);
				}
				DwmRegisterThumbnail(win.Handle, User32.FindWindow("Progman", null), out var hThumb).ThrowIfFailed();
				thumbnails.Add(win.Handle, hThumb);
				return hThumb;
			}

			public void Unregister(HTHUMBNAIL hThumbnail)
			{
				foreach (var kv in thumbnails)
				{
					if (kv.Value == hThumbnail)
					{
						DwmUnregisterThumbnail(hThumbnail);
						thumbnails.Remove(kv.Key);
						break;
					}
				}
			}
		}

		[SecuritySafeCritical]
		private class MessageWindow : NativeWindow, IDisposable
		{
			[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
			public MessageWindow()
			{
				var cp = new CreateParams { Style = 0, ExStyle = 0, ClassStyle = 0, Parent = IntPtr.Zero, Caption = GetType().Name };
				CreateHandle(cp);
			}

			public void Dispose() => DestroyHandle();

			[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
			protected override void WndProc(ref Message m)
			{
				// ReSharper disable InconsistentNaming
				const int WM_DWMCOLORIZATIONCOLORCHANGED = 0x0320;
				const int WM_DWMCOMPOSITIONCHANGED = 0x031E;
				//const int WM_DWMNCRENDERINGCHANGED = 0x031F;
				//const int WM_DWMWINDOWMAXIMIZEDCHANGE = 0x0321;
				// ReSharper restore InconsistentNaming

				if (m.Msg >= WM_DWMCOMPOSITIONCHANGED && m.Msg <= WM_DWMCOLORIZATIONCOLORCHANGED)
					ExecuteEvents(m.Msg - WM_DWMCOMPOSITIONCHANGED);

				base.WndProc(ref m);
			}

			private static void ExecuteEvents(int idx)
			{
				if (eventHandlerList == null) return;
				lock (_lock)
				{
					try { ((EventHandler)eventHandlerList[keys[idx]]).Invoke(null, EventArgs.Empty); }
					catch { };
				}
			}
		}
	}
}