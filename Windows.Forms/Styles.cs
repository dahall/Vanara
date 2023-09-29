using System.Drawing;
using System.Windows.Forms;

namespace Vanara.Windows.Forms;

/// <summary>Style used to render the theme.</summary>
public enum RenderStyle
{
	/// <summary>The system theme</summary>
	SystemTheme,

	/// <summary>A custom theme.</summary>
	Custom
}

/// <summary>An interface for controls that provide drawing styles.</summary>
/// <typeparam name="TCtrl">The type of the control.</typeparam>
/// <typeparam name="TEnum">The type of the enum.</typeparam>
public interface IDrawingStyle<in TCtrl, in TEnum> where TEnum : struct, IConvertible where TCtrl : Control
{
	/// <summary>Draws the specified control.</summary>
	/// <param name="ctrl">The control.</param>
	/// <param name="state">The state.</param>
	/// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
	void Draw(TCtrl ctrl, TEnum state, PaintEventArgs e);

	/// <summary>Measures the specified control.</summary>
	/// <param name="ctrl">The control.</param>
	/// <param name="state">The state.</param>
	/// <param name="g">The g.</param>
	/// <returns></returns>
	Size Measure(TCtrl ctrl, TEnum state, Graphics? g = null);
}