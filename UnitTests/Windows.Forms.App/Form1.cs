using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Vanara.PInvoke;
using Vanara.Windows.Shell;

namespace Windows.Forms.App;

public partial class Form1 : Form
{
	private const string appId = "Windows.Forms.App";
	private const bool systemWide = false;
	private static readonly string[] extensions = new[] { ".dmy" };
	private object currentDlg;
	private List<string> tempFiles = new List<string>();

	public Form1()
	{
		InitializeComponent();
		FillComboWithDialogs(dlgCombo);
		shellItemChangeWatcher1.Item = new ShellFolder(Shell32.KNOWNFOLDERID.FOLDERID_RecycleBinFolder);
		shellItemChangeWatcher1.EnableRaisingEvents = true;
	}

	private void ShellItemChangeWatcher1_Changed(object sender, Vanara.Windows.Shell.ShellItemChangeWatcher.ShellItemChangeEventArgs e)
	{
		foreach (var i in e.ChangedItems)
			logDisplay.AppendText($"{e.ChangeType}={i.Name}{Environment.NewLine}");
	}

	protected override void OnHandleDestroyed(EventArgs e)
	{
		shellItemChangeWatcher1.EnableRaisingEvents = false;
		base.OnHandleDestroyed(e);
	}

	private static void FillComboWithDialogs(ComboBox cb) => cb.Items.AddRange(Assembly.GetAssembly(typeof(Vanara.Windows.Forms.AccessControlEditorDialog)).GetTypes().Where(t => t.IsPublic && !t.IsNested && typeof(CommonDialog).IsAssignableFrom(t) || typeof(Form).IsAssignableFrom(t)).ToArray());

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

	private void Form1_FormClosing(object sender, FormClosingEventArgs e)
	{
		// Remove temp files
		foreach (var n in tempFiles)
			File.Delete(n);

		// Unregister app
		try { ProgId.Unregister(appId, true, systemWide); } catch { }
	}

	private void Form1_Load(object sender, EventArgs e)
	{
		// Register app
		using (var progId = ProgId.Register(appId, Text, systemWide))
		{
			progId.Verbs.Add("open", "Open", $"{Application.ExecutablePath} %1", true);
			foreach (var ext in extensions)
				progId.FileTypeAssociations.Add(ext);
		}

		// Create temp files
		var tempCount = 4;
		for (var i = 0; i < tempCount; i++)
		{
			var nfn = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"____File{i:D4}{extensions[0]}");
			File.WriteAllText(nfn, "dummy");
			tempFiles.Add(nfn);
		}
	}
}