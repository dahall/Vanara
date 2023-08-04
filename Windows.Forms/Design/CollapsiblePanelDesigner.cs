using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Vanara.Windows.Forms.Design;

[EditorBrowsable(EditorBrowsableState.Never)]
internal class CollapsiblePanelDesigner : AttributedParentControlDesignerEx<CollapsiblePanel>, IToolboxUser
{
	private static readonly string[] propsToRemove = new string[] { "AutoScrollOffset", "AutoSize", "BackColor",
		"BackgroundImage", "BackgroundImageLayout", "ContextMenuStrip", "Cursor", "Enabled", "Font",
		"ForeColor", /*"Location",*/ "MaximumSize", "MinimumSize", "Padding", /*"Size",*/ "TabStop",
		"UseWaitCursor" };

	public CollapsiblePanelDesigner()
	{
	}

	public Control ControlContainer => Control.contentPanel;

	public ParentControlDesigner ControlContainerDesigner => DesignerHost?.GetDesigner(ControlContainer) as ParentControlDesigner;

	public override SelectionRules SelectionRules => (SelectionRules.Visible | SelectionRules.AllSizeable | SelectionRules.Moveable);

	protected IDesignerHost DesignerHost => GetService<IDesignerHost>();

	protected override bool EnableDragRect => true;

	protected override IEnumerable<string> PropertiesToRemove => propsToRemove;

	public override bool CanBeParentedTo(IDesigner parentDesigner) => parentDesigner?.Component is Control;

	public override bool CanParent(Control control) => true;

	public override void Initialize(IComponent component)
	{
		base.Initialize(component);
		AutoResizeHandles = true;
		if (Control != null)
			EnableDesignMode(Control.Content, "Content");
		//base.Glyphs.Add(new WizardPageContainerDesignerGlyph(this));
	}

	public override void InitializeNewComponent(IDictionary defaultValues)
	{
		base.InitializeNewComponent(defaultValues);
		Control.Text = "Header text";
	}

	bool IToolboxUser.GetToolSupported(ToolboxItem tool) => true;

	void IToolboxUser.ToolPicked(ToolboxItem tool) { }

	internal void RefreshDesigner() { GetService<DesignerActionUIService>()?.Refresh(Control); }

	private void SelectComponent(Component p)
	{
		if (SelectionService != null)
		{
			SelectionService.SetSelectedComponents(new object[] { Control }, SelectionTypes.Primary);
			if (p?.Site != null)
				SelectionService.SetSelectedComponents(new object[] { p });
			RefreshDesigner();
		}
	}

	internal class ActionList : TypedDesignerActionList<CollapsiblePanelDesigner, CollapsiblePanel>
	{
		public ActionList(CollapsiblePanelDesigner d, CollapsiblePanel c) : base(d, c)
		{
		}
	}
}
