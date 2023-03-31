using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;

namespace Vanara.Windows.Forms.Design;

[EditorBrowsable(EditorBrowsableState.Never)]
internal class ExplorerBrowserDesigner : AttributedControlDesigner<ExplorerBrowser>, IToolboxUser
{
	public ExplorerBrowserDesigner() { }

	public override SelectionRules SelectionRules => SelectionRules.Visible | SelectionRules.AllSizeable | SelectionRules.Moveable;

	protected override IEnumerable<string> PropertiesToRemove { get; } = new string[] { "AutoEllipsis", "BackColor",
		"BackgroundImage", "BackgroundImageLayout", "CausesValidation", "ContextMenuStrip", "Cursor", "Font",
		"ForeColor", "IMEMode", "Padding", "Text" };

	public override void Initialize(IComponent component)
	{
		base.Initialize(component);
		AutoResizeHandles = true;
	}

	bool IToolboxUser.GetToolSupported(ToolboxItem tool) => true;

	void IToolboxUser.ToolPicked(ToolboxItem tool) { }
}