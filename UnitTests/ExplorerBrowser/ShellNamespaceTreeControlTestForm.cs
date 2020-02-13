using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vanara.Windows.Shell;

namespace ExplorerBrowser
{
	public partial class ShellNamespaceTreeControlTestForm : Form
	{
		public ShellNamespaceTreeControlTestForm()
		{
			InitializeComponent();
		}

		private void ShellNamespaceTreeControlTestForm_Load(object sender, EventArgs e)
		{
			shellNamespaceTreeControl1.RootItems.Add(ShellFolder.Desktop, true, true);
			propertyGrid1.SelectedObject = shellNamespaceTreeControl1;
		}

		private void shellNamespaceTreeControl1_SelectionChanged(object sender, EventArgs e)
		{
			log.AppendText("Selected item: " + shellNamespaceTreeControl1.SelectedItem?.Name ?? "[null]" + Environment.NewLine);
		}

		private void shellNamespaceTreeControl1_AfterExpand(object sender, Vanara.Windows.Forms.ShellNamespaceTreeControlEventArgs e)
		{
			log.AppendText($"After expand: {e.Item.Name}, {e.Action}" + Environment.NewLine);
		}

		private void shellNamespaceTreeControl1_AfterLabelEdit(object sender, Vanara.Windows.Forms.ShellNamespaceTreeControlItemLabelEditEventArgs e)
		{
			log.AppendText($"After label edit: {e.Item.Name}, {e.Label}" + Environment.NewLine);
		}

		private void shellNamespaceTreeControl1_BeforeExpand(object sender, Vanara.Windows.Forms.ShellNamespaceTreeControlEventArgs e)
		{
			log.AppendText($"Before expand: {e.Item.Name}, {e.Action}" + Environment.NewLine);
		}

		private void shellNamespaceTreeControl1_BeforeItemDelete(object sender, Vanara.Windows.Forms.ShellNamespaceTreeControlEventArgs e)
		{
			log.AppendText($"Before delete: {e.Item.Name}, {e.Action}" + Environment.NewLine);
		}

		private void shellNamespaceTreeControl1_BeforeLabelEdit(object sender, Vanara.Windows.Forms.ShellNamespaceTreeControlItemLabelEditEventArgs e)
		{
			log.AppendText($"Before label edit: {e.Item.Name}, {e.Label}" + Environment.NewLine);
		}

		private void shellNamespaceTreeControl1_ItemMouseClick(object sender, Vanara.Windows.Forms.ShellNamespaceTreeControlItemMouseClickEventArgs e)
		{
			log.AppendText($"Mouse click: {e.Item.Name}, {e.HitLocation}, {e.Button}" + Environment.NewLine);
		}

		private void shellNamespaceTreeControl1_ItemMouseDoubleClick(object sender, Vanara.Windows.Forms.ShellNamespaceTreeControlItemMouseClickEventArgs e)
		{
			log.AppendText($"Mouse double-click: {e.Item.Name}, {e.HitLocation}, {e.Button}" + Environment.NewLine);
		}
	}
}
