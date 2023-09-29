using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;

namespace Vanara.Windows.Forms.Design;

[EditorBrowsable(EditorBrowsableState.Never)]
internal class CommandLinkDesigner : AttributedControlDesigner<CommandLink>, IToolboxUser
{
	public CommandLinkDesigner() { }

	public override SelectionRules SelectionRules => SelectionRules.Visible | SelectionRules.AllSizeable | SelectionRules.Moveable;

	protected override IEnumerable<string> PropertiesToRemove { get; } = new string[] { "AllowDrop", "AutoEllipsis", "BackColor",
		"BackgroundImage", "BackgroundImageLayout", "ContextMenuStrip", "Cursor", "FlatStyle", "FlatAppearance", "Font",
		"ForeColor", "ImageAlign", "ImageIndex", "ImageKey", "ImageList", "Padding", "TextAlign", "TextImageRelation",
		"UseCompatibleTextRendering", "UseVisualStyleBackColor", "UseWaitCursor" };

	public override void Initialize(IComponent component)
	{
		base.Initialize(component);
		AutoResizeHandles = true;
	}

	bool IToolboxUser.GetToolSupported(ToolboxItem tool) => true;

	void IToolboxUser.ToolPicked(ToolboxItem tool) { }
}