//Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Vanara.PInvoke;
using Vanara.Windows.Forms;
using Vanara.Windows.Shell;

namespace Microsoft.WindowsAPICodePack.Samples;

public partial class ExplorerBrowserTestForm : Form
{
	private readonly AutoResetEvent itemsChanged = new AutoResetEvent(false);
	private readonly AutoResetEvent selectionChanged = new AutoResetEvent(false);
	private readonly System.Windows.Forms.Timer uiDecoupleTimer = new System.Windows.Forms.Timer();

	public ExplorerBrowserTestForm()
	{
		InitializeComponent();

		// initialize known folder combo box
		knownFolderCombo.Sorted = true;
		knownFolderCombo.Items.AddRange(KFItem.All);

		// initial property grids
		propertyGrid.SelectedObject = explorerBrowser;

		// setup ExplorerBrowser navigation events
		explorerBrowser.Navigating += new EventHandler<Vanara.Windows.Forms.ExplorerBrowser.NavigatingEventArgs>(explorerBrowser_Navigating);
		explorerBrowser.NavigationFailed += new EventHandler<Vanara.Windows.Forms.ExplorerBrowser.NavigationFailedEventArgs>(explorerBrowser_NavigationFailed);
		explorerBrowser.Navigated += new EventHandler<Vanara.Windows.Forms.ExplorerBrowser.NavigatedEventArgs>(explorerBrowser_Navigated);
		explorerBrowser.ItemsChanged += new EventHandler(explorerBrowser_ItemsChanged);
		explorerBrowser.SelectionChanged += new EventHandler(explorerBrowser_SelectionChanged);
		explorerBrowser.ItemsEnumerated += new EventHandler(explorerBrowser_ItemsEnumerated);
		explorerBrowser.Navigate(ShellFolder.Desktop);

		// set up Navigation log event and button state
		explorerBrowser.History.NavigationLogChanged += new EventHandler<Vanara.Windows.Forms.ExplorerBrowser.NavigationLogEventArgs>(NavigationLog_NavigationLogChanged);
		backButton.Enabled = false;
		forwardButton.Enabled = false;

		uiDecoupleTimer.Tick += new EventHandler(uiDecoupleTimer_Tick);
		uiDecoupleTimer.Interval = 100;
		uiDecoupleTimer.Start();
	}

	private void DebugEnterFunc([System.Runtime.CompilerServices.CallerMemberName] string func = "") => System.Diagnostics.Debug.WriteLine($"Entering {func}...");

	private void backButton_Click(object sender, EventArgs e) =>
		// Move backwards through navigation log
		explorerBrowser.NavigateFromHistory(NavigationLogDirection.Backward);

	private void clearHistoryButton_Click(object sender, EventArgs e) =>
		// clear navigation log
		explorerBrowser.History.Clear();

	private void explorerBrowser_ItemsChanged(object sender, EventArgs e)
	{
		DebugEnterFunc();
		itemsChanged.Set();
	}

	private void explorerBrowser_ItemsEnumerated(object sender, EventArgs e)
	{
		DebugEnterFunc();
		// This event is BeginInvoked to decouple the ExplorerBrowser UI from this UI
		BeginInvoke(new MethodInvoker(delegate ()
		{
			eventHistoryTextBox.Text =
				eventHistoryTextBox.Text +
				"View enumeration complete.\n";
		}));

		selectionChanged.Set();
		itemsChanged.Set();
	}

	private void explorerBrowser_Navigated(object sender, Vanara.Windows.Forms.ExplorerBrowser.NavigatedEventArgs args)
	{
		DebugEnterFunc();
		// This event is BeginInvoked to decouple the ExplorerBrowser UI from this UI
		BeginInvoke(new MethodInvoker(delegate ()
		{
			// update event history text box
			var location = (args.NewLocation == null) ? "(unknown)" : args.NewLocation.Name;
			eventHistoryTextBox.Text =
				eventHistoryTextBox.Text +
				"Navigation completed. New Location = " + location + "\n";
		}));
	}

	private void explorerBrowser_Navigating(object sender, Vanara.Windows.Forms.ExplorerBrowser.NavigatingEventArgs args)
	{
		DebugEnterFunc();
		// fail navigation if check selected (this must be synchronous)
		args.Cancel = failNavigationCheckBox.Checked;

		// This portion is BeginInvoked to decouple the ExplorerBrowser UI from this UI
		BeginInvoke(new MethodInvoker(delegate ()
		{
			// update event history text box
			var message = "";
			var location = (args.PendingLocation == null) ? "(unknown)" : args.PendingLocation.Name;
			if (args.Cancel)
			{
				message = "Navigation Failing. Pending Location = " + location;
			}
			else
			{
				message = "Navigation Pending. Pending Location = " + location;
			}
			eventHistoryTextBox.Text =
				eventHistoryTextBox.Text + message + "\n";
		}));
	}

	private void explorerBrowser_NavigationFailed(object sender, Vanara.Windows.Forms.ExplorerBrowser.NavigationFailedEventArgs args)
	{
		DebugEnterFunc();
		// This event is BeginInvoked to decouple the ExplorerBrowser UI from this UI
		BeginInvoke(new MethodInvoker(delegate ()
		{
			// update event history text box
			var location = (args.FailedLocation == null) ? "(unknown)" : args.FailedLocation.Name;
			eventHistoryTextBox.Text =
				eventHistoryTextBox.Text +
				"Navigation failed. Failed Location = " + location + "\n";

			if (explorerBrowser.History.CurrentLocationIndex == -1)
				navigationHistoryCombo.Text = "";
			else
				navigationHistoryCombo.SelectedIndex = explorerBrowser.History.CurrentLocationIndex;
		}));
	}

	private void explorerBrowser_SelectionChanged(object sender, EventArgs e)
	{
		DebugEnterFunc();
		selectionChanged.Set();
	}

	private void filePathEdit_TextChanged(object sender, EventArgs e) => filePathNavigate.Enabled = (filePathEdit.Text.Length > 0);

	private void filePathNavigate_Click(object sender, EventArgs e)
	{
		DebugEnterFunc();
		try
		{
			// Navigates to a specified file (must be a container file to work, i.e., ZIP, CAB)
			explorerBrowser.Navigate(new ShellFolder(filePathEdit.Text));
		}
		catch (COMException)
		{
			MessageBox.Show("Navigation not possible.");
		}
	}

	private void forwardButton_Click(object sender, EventArgs e)
	{
		DebugEnterFunc();
		explorerBrowser.NavigateFromHistory(NavigationLogDirection.Forward);
	}

	private void knownFolderCombo_SelectedIndexChanged(object sender, EventArgs e) => knownFolderNavigate.Enabled = (knownFolderCombo.Text.Length > 0);

	private void knownFolderNavigate_Click(object sender, EventArgs e)
	{
		try
		{
			// Navigate to a known folder
			explorerBrowser.Navigate(ShellItem.Open(((KFItem)knownFolderCombo.SelectedItem).ShellItem));
		}
		catch (COMException)
		{
			MessageBox.Show("Navigation not possible.");
		}
	}

	private void navigateButton_Click(object sender, EventArgs e)
	{
		DebugEnterFunc();
		try
		{
			// navigate to specific folder
			explorerBrowser.Navigate(new ShellFolder(pathEdit.Text));
		}
		catch (COMException)
		{
			MessageBox.Show("Navigation not possible.");
		}
	}

	private void navigationHistoryCombo_SelectedIndexChanged(object sender, EventArgs e) =>
		// navigating to specific index in navigation log
		explorerBrowser.NavigateToHistoryIndex(navigationHistoryCombo.SelectedIndex);

	private void NavigationLog_NavigationLogChanged(object sender, Vanara.Windows.Forms.ExplorerBrowser.NavigationLogEventArgs args)
	{
		DebugEnterFunc();
		// This event is BeginInvoked to decouple the ExplorerBrowser UI from this UI
		BeginInvoke(new MethodInvoker(delegate ()
		{
			// calculate button states
			if (args.CanNavigateBackwardChanged)
			{
				backButton.Enabled = explorerBrowser.History.CanNavigateBackward;
			}
			if (args.CanNavigateForwardChanged)
			{
				forwardButton.Enabled = explorerBrowser.History.CanNavigateForward;
			}

			// update history combo box
			if (args.LocationsChanged)
			{
				navigationHistoryCombo.Items.Clear();
				foreach (var shobj in explorerBrowser.History.Locations)
				{
					navigationHistoryCombo.Items.Add(shobj.Name);
				}
			}
			if (explorerBrowser.History.CurrentLocationIndex == -1)
				navigationHistoryCombo.Text = "";
			else
				navigationHistoryCombo.SelectedIndex = explorerBrowser.History.CurrentLocationIndex;
		}));
	}

	private void pathEdit_TextChanged(object sender, EventArgs e) => navigateButton.Enabled = (pathEdit.Text.Length > 0);

	private void uiDecoupleTimer_Tick(object sender, EventArgs e)
	{
		DebugEnterFunc();
		try
		{
			if (selectionChanged.WaitOne(1))
			{
				var itemsText = new StringBuilder();

				foreach (var item in explorerBrowser.SelectedItems)
				{
					if (item != null)
						itemsText.AppendLine("\tItem = " + item.Name);
				}

				selectedItemsTextBox.Text = itemsText.ToString();
				itemsTabControl.TabPages[1].Text = "Selected Items (Count=" + explorerBrowser.SelectedItems.Count.ToString() + ")";
			}

			if (itemsChanged.WaitOne(1))
			{
				// update items text box
				var itemsText = new StringBuilder();

				foreach (var item in explorerBrowser.Items)
				{
					if (item != null)
						itemsText.AppendLine("\tItem = " + item.Name);
				}

				itemsTextBox.Text = itemsText.ToString();
				itemsTabControl.TabPages[0].Text = "Items (Count=" + explorerBrowser.Items.Count.ToString() + ")";
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
		}
	}

	private class KFItem
	{
		private static readonly Shell32.IKnownFolderManager kfm = new Shell32.IKnownFolderManager();

		public KFItem(Guid id)
		{
			Id = id; Text = kfm.GetFolder(id).Name();
		}

		public static KFItem[] All => kfm.GetFolderIds().Select(g => new KFItem(g)).ToArray();

		public Guid Id { get; set; }

		public Shell32.IShellItem ShellItem => kfm.GetFolder(Id).GetShellItem<Shell32.IShellItem>();
		public string Text { get; set; }

		public override string ToString() => Text;
	}
}