using System.Drawing;
using System.Windows.Forms;
using Vanara.Extensions.Reflection;

namespace Vanara.Extensions
{
	public static partial class ControlExtension
	{
		/// <summary>
		/// Builds the <see cref="TextFormatFlags"/> based on this control's values.
		/// </summary>
		/// <param name="ctrl">The control.</param>
		/// <param name="singleLine">if set to <c>true</c> text is in a single line.</param>
		/// <returns>A <see cref="TextFormatFlags"/> value for this control.</returns>
		public static TextFormatFlags BuildTextFormatFlags(this Control ctrl, bool singleLine = true)
		{
			var align = ctrl.GetPropertyValue("TextAlign", ContentAlignment.TopLeft);
			var ellip = ctrl.GetPropertyValue("AutoEllipsis", false);
			var mne = ctrl.GetPropertyValue("UseMnemonic", false);
			var kb = ctrl.GetPropertyValue("ShowKeyboardCues", false);
			return GraphicsExtension.BuildTextFormatFlags(align, singleLine, ellip, mne, ctrl.GetRightToLeftProperty(), kb);
		}
	}
}