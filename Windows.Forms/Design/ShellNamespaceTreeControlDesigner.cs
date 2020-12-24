using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Vanara.Windows.Forms.Design
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	internal class ShellNamespaceTreeControlDesigner : AttributedControlDesigner<ShellNamespaceTreeControl>, IToolboxUser
	{
		public ShellNamespaceTreeControlDesigner() { }

		public override SelectionRules SelectionRules => SelectionRules.Visible | SelectionRules.AllSizeable | SelectionRules.Moveable;

		protected override IEnumerable<string> EventsToRemove => new[] { nameof(ShellNamespaceTreeControl.BackColorChanged),
			nameof(ShellNamespaceTreeControl.BackgroundImageChanged), nameof(ShellNamespaceTreeControl.BackgroundImageLayoutChanged),
			nameof(ShellNamespaceTreeControl.CausesValidationChanged), nameof(ShellNamespaceTreeControl.ContextMenuStripChanged),
			nameof(ShellNamespaceTreeControl.CursorChanged), nameof(ShellNamespaceTreeControl.FontChanged), nameof(ShellNamespaceTreeControl.ForeColorChanged),
			nameof(ShellNamespaceTreeControl.PaddingChanged), nameof(ShellNamespaceTreeControl.RightToLeftChanged), nameof(ShellNamespaceTreeControl.TextChanged) };

		protected override IEnumerable<string> PropertiesToRemove => new[] { nameof(ShellNamespaceTreeControl.BackColor),
			nameof(ShellNamespaceTreeControl.BackgroundImage), nameof(ShellNamespaceTreeControl.BackgroundImageLayout),
			nameof(ShellNamespaceTreeControl.CausesValidation), nameof(ShellNamespaceTreeControl.ContextMenuStrip),
			nameof(ShellNamespaceTreeControl.Cursor), nameof(ShellNamespaceTreeControl.Font), nameof(ShellNamespaceTreeControl.ForeColor),
			nameof(ShellNamespaceTreeControl.Padding), nameof(ShellNamespaceTreeControl.RightToLeft), nameof(ShellNamespaceTreeControl.Text),
			nameof(ShellNamespaceTreeControl.UseWaitCursor) };

		public override void Initialize(IComponent component)
		{
			base.Initialize(component);
			AutoResizeHandles = true;
		}

		bool IToolboxUser.GetToolSupported(ToolboxItem tool) => true;

		void IToolboxUser.ToolPicked(ToolboxItem tool) { }
	}
}