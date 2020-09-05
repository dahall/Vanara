using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Vanara.Windows.Forms
{
	[Designer(typeof(Design.EmbeddedContainerDesigner))]
	internal class EmbeddedContainer : ContainerControl
	{
		public EmbeddedContainer()
		{
			base.AutoScroll = false;
			base.Dock = DockStyle.Fill;
		}
	}

	namespace Design
	{
		[global::System.Security.Permissions.PermissionSet(global::System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		internal class EmbeddedContainerDesigner : AttributedControlDesigner<EmbeddedContainer>
		{
			public EmbeddedContainerDesigner() { }

			protected override IEnumerable<string> PropertiesToRemove { get; } = new string[]
			{
				"AutoScroll", "AutoScrollOffset", "AutoSize", "BackColor",
				"BackgroundImage", "BackgroundImageLayout", "ContextMenuStrip", "Cursor", "Dock", "Enabled", "Font",
				"ForeColor", /*"Location",*/ "MaximumSize", "MinimumSize", "Padding", /*"Size",*/ "TabStop",
				"UseWaitCursor"
			};
		}
	}
}

