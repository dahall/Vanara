using System;
using System.Drawing;
using System.Windows.Forms;

namespace Vanara.Windows.Forms
{
	public enum RenderStyle
	{
		SystemTheme,
		Custom
	}

	public interface IDrawingStyle<in TCtrl, in TEnum> where TEnum : struct, IConvertible where TCtrl : Control
	{
		void Draw(TCtrl ctrl, TEnum state, PaintEventArgs e);
		Size Measure(TCtrl ctrl, TEnum state, Graphics g = null);
	}
}
