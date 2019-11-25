using System;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Windows.Forms.App
{
	public partial class Form1 : Form
	{
		private object currentDlg;

		public Form1()
		{
			InitializeComponent();
			FillComboWithDialogs(dlgCombo);
		}

		private static void FillComboWithDialogs(ComboBox cb) => cb.Items.AddRange(Assembly.GetAssembly(typeof(Vanara.Windows.Forms.AccessControlEditorDialog)).GetTypes().Where(t => !t.IsNested && typeof(CommonDialog).IsAssignableFrom(t) || typeof(Form).IsAssignableFrom(t)).ToArray());

		private void button1_Click(object sender, EventArgs e)
		{
			if (currentDlg is null) return;
			try
			{
				if (currentDlg is CommonDialog c)
					c.ShowDialog();
				else if (currentDlg is Form f)
					f.ShowDialog();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), null, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void dlgCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			currentDlg = dlgCombo.SelectedItem is null ? null : Activator.CreateInstance((Type)dlgCombo.SelectedItem);
			propertyGrid1.SelectedObject = currentDlg;
		}
	}
}