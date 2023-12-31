using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Vanara.Configuration;

namespace Vanara.Windows.Forms;

/// <summary>
/// A class that manages a Most Recently Used file listing and interacts with a MenuStrip to display a menu list of the files. By
/// default, the application settings are used to store the history. Optionally a constructor can be used to provide an alternate class
/// to handle that work.
/// </summary>
[DefaultProperty("RecentFileMenuItem")]
public class MenuStripMRUManager : MRUManager
{
	/// <summary>Initializes a new instance of the <see cref="MenuStripMRUManager"/> class.</summary>
	public MenuStripMRUManager() : base(new AppSettingsFileListStorage(), new MenuStripMenuBuilder())
	{
	}

	/// <summary>Initializes a new instance of the <see cref="MRUManager"/> class.</summary>
	/// <param name="extensions">The extensions of files to find in system MRU list.</param>
	/// <param name="parentMenuItem">The parent "Recent Files" menu item.</param>
	/// <param name="onRecentFileClick">Action to run when The on recent file click.</param>
	/// <param name="onClearRecentFilesClick">Optional. The on clear recent files click.</param>
	/// <param name="storageHandler">Optional. The storage handler.</param>
	public MenuStripMRUManager(string extensions, ToolStripMenuItem parentMenuItem, Action<string> onRecentFileClick,
		Action<StringCollection>? onClearRecentFilesClick = null, IFileListStorage? storageHandler = null)
		: base(storageHandler ?? new AppSettingsFileListStorage(), new MenuStripMenuBuilder())
	{
		FileExtensions = extensions;
		if (MenuBuilderHandler is not null)
			((MenuStripMenuBuilder)MenuBuilderHandler).RecentFileMenuItem = parentMenuItem;
		if (onRecentFileClick != null)
			RecentFileMenuItemClick += onRecentFileClick;
		if (onClearRecentFilesClick != null)
			ClearListMenuItemClick += onClearRecentFilesClick;

		RefreshRecentFilesMenu();
	}

	/// <summary>Gets or sets the clear list menu item image.</summary>
	/// <value>The clear list menu item image.</value>
	[Category("Appearance"), DefaultValue(null), Description("The clear list menu item icon."), Localizable(true)]
	public Image? ClearListMenuItemImage
	{
		get => clearListMenuItemImage as Image;
		set
		{
			clearListMenuItemImage = value ?? throw new ArgumentException("Must be of type Image.");
			RefreshRecentFilesMenu();
		}
	}

	/// <summary>Gets or sets the recent file menu item.</summary>
	/// <value>The recent file menu item.</value>
	[DefaultValue(null), Category("Behavior"), Description("The recent file menu item.")]
	public ToolStripMenuItem? RecentFileMenuItem
	{
		get => ((MenuStripMenuBuilder?)MenuBuilderHandler)?.RecentFileMenuItem;
		set
		{
			if (MenuBuilderHandler is not null)
				((MenuStripMenuBuilder)MenuBuilderHandler).RecentFileMenuItem = value;
			RefreshRecentFilesMenu();
		}
	}

	/// <summary>Builds a menu within a MenuStrip.</summary>
	private class MenuStripMenuBuilder : IMenuBuilder
	{
		private Action<string>? fileMenuItemClickAction;

		/// <summary>Gets or sets the recent file menu item.</summary>
		/// <value>The recent file menu item.</value>
		public ToolStripMenuItem? RecentFileMenuItem { get; set; }

		/// <summary>Clears the recent files.</summary>
		public void ClearRecentFiles()
		{
			if (RecentFileMenuItem == null) return;
			RecentFileMenuItem.DropDownItems.Clear();
			RecentFileMenuItem.Enabled = false;
		}

		/// <summary>Rebuilds the menus.</summary>
		/// <param name="files">The file listing.</param>
		/// <param name="fileMenuItemClick">The handler for when one of the automatically added recent file menu items is clicked..</param>
		/// <param name="clearListMenuItemText">
		/// The clear list menu item text. A <c>null</c> value indicates that this menu item should not be shown.
		/// </param>
		/// <param name="clearListMenuItemClick">The handler for when the clear recent files menu item is clicked.</param>
		/// <param name="clearListMenuItemImage">
		/// The clear list menu item image. A <c>null</c> value indicates that this menu item's image should not be shown.
		/// </param>
		/// <param name="clearListMenuItemOnTop">if set to <see langword="true"/>, the clear list menu item precedes the files.</param>
		/// <param name="menuImageCallback">The menu image callback delegate.</param>
		public void RebuildMenus(IEnumerable<string> files, Action<string> fileMenuItemClick, string? clearListMenuItemText = null, Action? clearListMenuItemClick = null, object? clearListMenuItemImage = null, bool clearListMenuItemOnTop = false, Func<string, object>? menuImageCallback = null)
		{
			if (RecentFileMenuItem == null) return;

			RecentFileMenuItem.DropDownItems.Clear();

			if (files is null || !files.Any())
			{
				RecentFileMenuItem.Enabled = false;
				return;
			}

			if (clearListMenuItemOnTop && !string.IsNullOrEmpty(clearListMenuItemText))
			{
				RecentFileMenuItem.DropDownItems.Add(clearListMenuItemText, clearListMenuItemImage as Image, (o, e) => clearListMenuItemClick?.Invoke());
				RecentFileMenuItem.DropDownItems.Add("-");
			}

			fileMenuItemClickAction = fileMenuItemClick;
			foreach (var f in files)
			{
				RecentFileMenuItem.DropDownItems.Add(new ToolStripMenuItem(CompactPath(RecentFileMenuItem.GetCurrentParent()!.CreateGraphics(), f, RecentFileMenuItem.Font, RecentFileMenuItem.Width), menuImageCallback?.Invoke(f) as Image, OnFileMenuItemClick) { Tag = f });
			}

			if (!clearListMenuItemOnTop && !string.IsNullOrEmpty(clearListMenuItemText))
			{
				RecentFileMenuItem.DropDownItems.Add("-");
				RecentFileMenuItem.DropDownItems.Add(clearListMenuItemText, clearListMenuItemImage as Image, (o, e) => clearListMenuItemClick?.Invoke());
			}
			RecentFileMenuItem.Enabled = true;
		}

		/// <summary>Compacts the path.</summary>
		/// <param name="g">The Graphics instance to use.</param>
		/// <param name="stringToCompact">The string to compact.</param>
		/// <param name="font">The font.</param>
		/// <param name="maxWidthInPts">The maximum width in PTS.</param>
		/// <returns>The compacted string.</returns>
		private static string CompactPath(Graphics g, string stringToCompact, Font font, int maxWidthInPts)
		{
			var sb = new StringBuilder(stringToCompact);
			g.MeasureText(sb, font, new Size(maxWidthInPts, 0), TextFormatFlags.PathEllipsis | TextFormatFlags.ModifyString);
			return sb.ToString(); // string.Concat(stringToCompact.TakeWhile(c => c != '\0'));
		}

		private void OnFileMenuItemClick(object? sender, EventArgs e)
		{
			if (sender is ToolStripMenuItem item)
				fileMenuItemClickAction?.Invoke(item.Tag?.ToString()!);
		}
	}
}