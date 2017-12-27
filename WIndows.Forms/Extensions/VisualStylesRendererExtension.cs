using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Vanara.PInvoke;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.UxTheme;

namespace Vanara.Extensions
{
	public static partial class VisualStylesRendererExtension
	{
		public static Padding GetMargins2(this VisualStyleRenderer rnd, IDeviceContext dc = null, MarginProperty prop = MarginProperty.ContentMargins)
		{
			using (var hdc = new SafeDCHandle(dc))
			{
				GetThemeMargins(rnd.GetSafeHandle(), hdc, rnd.Part, rnd.State, (int)prop, null, out MARGINS m);
				return new Padding(m.cxLeftWidth, m.cyTopHeight, m.cxRightWidth, m.cyBottomHeight);
			}
		}

		public static uint GetTransitionDuration(this VisualStyleRenderer rnd, int toState, int fromState = 0)
		{
			GetThemeTransitionDuration(rnd.GetSafeHandle(), rnd.Part, fromState == 0 ? rnd.State : fromState, toState, (int)IntegerListProperty.TransitionDuration, out var dwDuration);
			return dwDuration;
		}

		public static int[,] GetTransitionMatrix(this VisualStyleRenderer rnd)
		{
			var res = GetThemeIntList(rnd.GetSafeHandle(), rnd.Part, rnd.State, (int)IntegerListProperty.TransitionDuration);
			if (res == null || res.Length == 0) return null;
			var dim = res[0];
			var ret = new int[dim, dim];
			for (var i = 0; i < dim; i++)
				for (var j = 0; j < dim; j++)
					ret[i, j] = res[i*dim + j + 1];
			return ret;
		}

		public static bool IsPartDefined(this VisualStyleRenderer rnd, int part, int state) => IsThemePartDefined(rnd.GetSafeHandle(), part, state);

		/// <summary>
		/// Sets the state of the <see cref="VisualStyleRenderer"/>.
		/// </summary>
		/// <param name="rnd">The <see cref="VisualStyleRenderer"/> instance.</param>
		/// <param name="state">The state.</param>
		public static void SetState(this VisualStyleRenderer rnd, int state) { rnd.SetParameters(rnd.Class, rnd.Part, state); }

		/// <summary>
		/// Sets the window theme.
		/// </summary>
		/// <param name="win">The window on which to apply the theme.</param>
		/// <param name="subAppName">Name of the sub application. This is the theme name (e.g. "Explorer").</param>
		/// <param name="subIdList">The sub identifier list. This can be left <c>null</c>.</param>
		public static void SetWindowTheme(this IWin32Window win, string subAppName, string[] subIdList = null)
		{
			var idl = subIdList == null ? null : string.Join(";", subIdList);
			try { UxTheme.SetWindowTheme(new HandleRef(win, win.Handle), subAppName, idl); } catch { }
		}

		/// <summary>
		/// Sets attributes to control how visual styles are applied to a specified window.
		/// </summary>
		/// <param name="window">The window.</param>
		/// <param name="attr">The attributes to apply or disable.</param>
		/// <param name="enable">if set to <c>true</c> enable the attribute, otherwise disable it.</param>
		public static void SetWindowThemeAttribute(this IWin32Window window, WTNCA attr, bool enable = true)
		{
			try { UxTheme.SetWindowThemeNonClientAttributes(new HandleRef(window, window.Handle), attr, enable); }
			catch (EntryPointNotFoundException) { }
		}

		private static SafeThemeHandle GetSafeHandle(this VisualStyleRenderer rnd) => new SafeThemeHandle(rnd.Handle, false);
	}
}