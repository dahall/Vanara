using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Vanara.PInvoke;
using static Vanara.PInvoke.UxTheme;

namespace Vanara.Extensions;

public static partial class VisualStylesRendererExtension
{
	/// <summary>Retrieves the value of a <c>MARGINS</c> property.</summary>
	/// <param name="rnd">The visual style to query.</param>
	/// <param name="dc">A device context for any font selection. This value can be <see langword="null"/>.</param>
	/// <param name="prop">The property to retrieve.</param>
	/// <returns>The margins defined for the property.</returns>
	public static Padding GetMargins2(this VisualStyleRenderer rnd, IDeviceContext dc = null, MarginProperty prop = MarginProperty.ContentMargins)
	{
		using (var hdc = new SafeTempHDC(dc))
		{
			GetThemeMargins(rnd.GetSafeHandle(), hdc, rnd.Part, rnd.State, (int)prop, null, out MARGINS m);
			return new Padding(m.cxLeftWidth, m.cyTopHeight, m.cxRightWidth, m.cyBottomHeight);
		}
	}

	/// <summary>Gets the duration of the specified transition.</summary>
	/// <param name="rnd">The visual style to query.</param>
	/// <param name="toState">State ID of the part after the transition.</param>
	/// <param name="fromState">State ID of the part before the transition.</param>
	/// <returns>The transition duration, in milliseconds.</returns>
	public static uint GetTransitionDuration(this VisualStyleRenderer rnd, int toState, int fromState = 0)
	{
		GetThemeTransitionDuration(rnd.GetSafeHandle(), rnd.Part, fromState == 0 ? rnd.State : fromState, toState, (int)ThemeProperty.TMT_TRANSITIONDURATIONS, out var dwDuration);
		return dwDuration;
	}

	/// <summary>Gets the transition matrix for a visual style.</summary>
	/// <param name="rnd">The visual style to query.</param>
	/// <returns>A two dimensional array that represents the transition durations, in milliseconds, between any two parts.</returns>
	public static int[,] GetTransitionMatrix(this VisualStyleRenderer rnd)
	{
		var res = GetThemeIntList(rnd.GetSafeHandle(), rnd.Part, rnd.State, (int)ThemeProperty.TMT_TRANSITIONDURATIONS);
		if (res == null || res.Length == 0) return null;
		var dim = res[0];
		var ret = new int[dim, dim];
		for (var i = 0; i < dim; i++)
			for (var j = 0; j < dim; j++)
				ret[i, j] = res[i*dim + j + 1];
		return ret;
	}

	/// <summary>Determines whether a different part is defined for this visual theme.</summary>
	/// <param name="rnd">The visual style to query.</param>
	/// <param name="part">The part ID to consider.</param>
	/// <returns><c>true</c> if the part is defined; otherwise, <c>false</c>.</returns>
	public static bool IsPartDefined(this VisualStyleRenderer rnd, int part) => IsThemePartDefined(rnd.GetSafeHandle(), part, 0);

	/// <summary>Prevents the application of visual styling for this specific window or control.</summary>
	/// <param name="window">The window or control.</param>
	public static void PreventVisualStyling(this IWin32Window window) => SetWindowTheme(window, " ", new[] { " " });

	/// <summary>
	/// Sets the state of the <see cref="VisualStyleRenderer"/>.
	/// </summary>
	/// <param name="rnd">The <see cref="VisualStyleRenderer"/> instance.</param>
	/// <param name="state">The state.</param>
	public static void SetState(this VisualStyleRenderer rnd, int state) { rnd.SetParameters(rnd.Class, rnd.Part, state); }

	/// <summary>Sets the window theme.</summary>
	/// <param name="window">The window on which to apply the theme.</param>
	/// <param name="subAppName">Name of the sub application. This is the theme name (e.g. "Explorer").</param>
	/// <param name="subIdList">The sub identifier list. This can be left <c>null</c>.</param>
	public static void SetWindowTheme(this IWin32Window window, string subAppName, string[] subIdList = null)
	{
		var idl = subIdList == null ? null : string.Join(";", subIdList);
		try { UxTheme.SetWindowTheme(window.Handle, subAppName, idl); } catch { }
	}

	/// <summary>Sets attributes to control how visual styles are applied to a specified window.</summary>
	/// <param name="window">The window.</param>
	/// <param name="attr">The attributes to apply or disable.</param>
	/// <param name="enable">if set to <c>true</c> enable the attribute, otherwise disable it.</param>
	public static void SetWindowThemeAttribute(this IWin32Window window, WTNCA attr, bool enable = true)
	{
		try { SetWindowThemeNonClientAttributes(window.Handle, attr, enable); }
		catch (EntryPointNotFoundException) { }
	}

	private static SafeHTHEME GetSafeHandle(this VisualStyleRenderer rnd) => new(rnd.Handle, false);
}