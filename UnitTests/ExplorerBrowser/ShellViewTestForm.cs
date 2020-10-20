using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vanara.PInvoke
{
	public partial class ShellViewTestForm : Form
	{
		public ShellViewTestForm()
		{
			InitializeComponent();
		}

		private void shellView1_Navigating(object sender, Windows.Shell.NavigatingEventArgs e)
		{
			MessageBox.Show(e.PendingLocation.Name);
		}
	}
}
