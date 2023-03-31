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

namespace Microsoft.WindowsAPICodePack.Samples;

    public partial class SimpleForm : Form
    {
        public SimpleForm()
        {
            InitializeComponent();
        }

        private void SimpleForm_Load(object sender, EventArgs e)
        {
            //explorerBrowser1.Navigate(ShellFolder.Desktop);
        }
    }
