using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Vanara.Extensions;
using Vanara.Extensions.Reflection;

namespace Vanara.Configuration
{
	using Microsoft.Win32;
	using System.Configuration;
	using System.Diagnostics;
	using System.IO;
	using System.Reflection;
	using System.Runtime.InteropServices;

	/// <summary>A class that manages a Most Recently Used file listing.</summary>
	[DefaultEvent(nameof(RecentFileMenuItemClick))]
	public class MRUManager : Component
	{
		/// <summary>This value should contain the appropriate image for the clear list menu item in derived classes.</summary>
		protected object clearListMenuItemImage;

		private const string defClearListMenuItemText = "Clear List";
		private const int defMaxHistoryCount = 10;
		private MenuPlacement clearListMenuItemPlacement;
		private string clearListMenuItemText = defClearListMenuItemText;
		private string[] exts;
		private IFileListStorage storage;

		/// <summary>Initializes a new instance of the <see cref="MRUManager"/> class.</summary>
		public MRUManager() { }

		/// <summary>Initializes a new instance of the <see cref="MRUManager"/> class.</summary>
		/// <param name="fileListStorage">The file list storage.</param>
		/// <param name="menuBuilder">The menu builder.</param>
		public MRUManager(IFileListStorage fileListStorage, IMenuBuilder menuBuilder)
		{
			StorageHandler = fileListStorage;
			MenuBuilderHandler = menuBuilder;
		}

		/// <summary>Occurs when the clear recent files menu item is clicked.</summary>
		[Category("Behavior"), Description("Occurs when the clear recent files menu item is clicked.")]
		public event Action<StringCollection> ClearListMenuItemClick;

		/// <summary>Occurs when [get menu image for file].</summary>
		[Category("Behavior"), Description("Occurs when a file menu item is about to be drawn and is requesting an image.")]
		public event Func<string, object> GetMenuImageForFile;

		/// <summary>Occurs when one of the automatically added recent file menu items is clicked.</summary>
		[Category("Behavior"), Description("Occurs when one of the automatically added recent file menu items is clicked.")]
		public event Action<string> RecentFileMenuItemClick;

		/// <summary>The placement of a menu item in a list.</summary>
		public enum MenuPlacement
		{
			/// <summary>The bottom of the list, after all items.</summary>
			Bottom,

			/// <summary>The top of the list, before all items.</summary>
			Top
		}

		/// <summary>Defines a class that implements storage for an MRU file list.</summary>
		public interface IFileListStorage
		{
			/// <summary>Gets or sets the files declared in this storage instance.</summary>
			/// <value>The file listing. Each file should declare its full path.</value>
			IEnumerable<string> Files { get; set; }

			/// <summary>Adds a new file to the list.</summary>
			/// <param name="fileNameWithFullPath">The file name with full path.</param>
			void AddRecentFile(string fileNameWithFullPath);

			/// <summary>Initializes this instance and sets up any local settings required for execution.</summary>
			void Initialize();

			/// <summary>Removes the file from the list.</summary>
			/// <param name="fileNameWithFullPath">The file name with full path.</param>
			void RemoveRecentFile(string fileNameWithFullPath);
		}

		/// <summary>Defines a class that implements a menu handler for an MRU file list.</summary>
		public interface IMenuBuilder
		{
			/// <summary>Clears the menu items of all files.</summary>
			void ClearRecentFiles();

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
			void RebuildMenus(IEnumerable<string> files, Action<string> fileMenuItemClick, string clearListMenuItemText = null, Action clearListMenuItemClick = null, object clearListMenuItemImage = null, bool clearListMenuItemOnTop = false, Func<string, object> menuImageCallback = null);
		}

		/// <summary>Gets or sets the clear list menu item placement relative to the MRU items.</summary>
		/// <value>The clear list menu item placement.</value>
		[Category("Appearance"), DefaultValue(typeof(MenuPlacement), "Bottom"), Description("The clear list menu item text."), Localizable(true)]
		public MenuPlacement ClearListMenuItemPlacement
		{
			get => clearListMenuItemPlacement;
			set { clearListMenuItemPlacement = value; RefreshRecentFilesMenu(); }
		}

		/// <summary>Gets or sets the clear list menu item text.</summary>
		/// <value>The clear list menu item text. Set this value to <c>null</c> to hide this menu item.</value>
		[Category("Appearance"), DefaultValue(defClearListMenuItemText), Description("The clear list menu item text."), Localizable(true)]
		public string ClearListMenuItemText
		{
			get => clearListMenuItemText;
			set { clearListMenuItemText = value; RefreshRecentFilesMenu(); }
		}

		/// <summary>Gets or sets the vertical bar ('|') separated list of extensions without periods that are supported.</summary>
		/// <value>The file extensions.</value>
		[DefaultValue(null), Category("Behavior"), Description("Required. Vertical bar ('|') separated list of extensions without periods that are supported.")]
		public string FileExtensions
		{
			get => exts == null ? string.Empty : string.Join("|", exts);
			set { exts = value?.ToLower().Replace(".", "").Split('|', ';', ',', ' '); RefreshRecentFilesMenu(); }
		}

		/// <summary>Gets the list of most recently used files.</summary>
		/// <value>The files in reverse chronological order.</value>
		[Browsable(false)]
		public IEnumerable<string> Files
		{
			get
			{
				// Pre-load with values from local settings
				var recentFiles = StorageHandler != null ? new List<string>(StorageHandler.Files) : new List<string>();

				// Augment with values from Recently Used Files system folder
				if (exts != null && exts.Length > 0)
				{
					try
					{
						var type = Type.GetTypeFromProgID("Wscript.Shell");
						if (type != null)
						{
							var script = Activator.CreateInstance(type);
							foreach (var file in Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Recent), "*.lnk").Where(s => exts.Contains(Path.GetExtension(s.Substring(0, s.Length - 4)).Trim('.').ToLower())))
							{
								var sc = script.InvokeMethod<object>("CreateShortcut", file);
								var targetPath = sc.GetPropertyValue<string>("TargetPath");
								if (targetPath != null)
									recentFiles.Add(targetPath);
							}
						}
					}
					catch (Exception ex)
					{
						Debug.WriteLine(ex.ToString());
					}
				}

				// Sort files by last write time
				var res = recentFiles.Distinct().Where(s => !string.IsNullOrEmpty(s) && File.Exists(s)).OrderByDescending(File.GetLastWriteTimeUtc).Take(MaxHistoryCount).ToList();

				// Update settings with updated list
				if (StorageHandler != null) StorageHandler.Files = res;

				return res;
			}
		}

		/// <summary>Gets or sets the maximum number of files to maintain in the history.</summary>
		/// <value>The maximum number of files to maintain in the history.</value>
		[DefaultValue(defMaxHistoryCount), Category("Behavior"), Description("The maximum number of files to maintain in the history.")]
		public int MaxHistoryCount { get; set; } = defMaxHistoryCount;

		/// <summary>Gets or sets the menu builder handler.</summary>
		/// <value>The menu builder handler.</value>
		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public IMenuBuilder MenuBuilderHandler { get; set; }

		/// <summary>Gets or sets the storage handler.</summary>
		/// <value>The storage handler.</value>
		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public IFileListStorage StorageHandler
		{
			get => storage;
			set { storage = value; if (LicenseManager.UsageMode != LicenseUsageMode.Designtime) storage?.Initialize(); }
		}

		/// <summary>Adds the recent file.</summary>
		/// <param name="fileNameWithFullPath">The file name with full path.</param>
		public void AddRecentFile(string fileNameWithFullPath)
		{
			if (string.IsNullOrEmpty(fileNameWithFullPath) || !File.Exists(fileNameWithFullPath))
				throw new FileNotFoundException("Unable to add a file that doesn't exist.", fileNameWithFullPath);

			try
			{
				SHAddToRecentDocs(2, fileNameWithFullPath);
				StorageHandler?.AddRecentFile(fileNameWithFullPath);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.ToString());
			}

			RefreshRecentFilesMenu();
		}

		/// <summary>Removes the recent file.</summary>
		/// <param name="fileNameWithFullPath">The file name with full path.</param>
		public void RemoveRecentFile(string fileNameWithFullPath)
		{
			try
			{
				StorageHandler?.RemoveRecentFile(fileNameWithFullPath);
				File.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Recent), Path.GetFileName(fileNameWithFullPath) + ".lnk"));
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}

			RefreshRecentFilesMenu();
		}

		/// <summary>Refreshes the recent files menu.</summary>
		protected void RefreshRecentFilesMenu()
		{
			if (!DesignMode)
				MenuBuilderHandler?.RebuildMenus(Files, OnRecentFileMenuItemClick, ClearListMenuItemText, OnClearListMenuItemClick, clearListMenuItemImage, clearListMenuItemPlacement == MenuPlacement.Top, GetMenuImageForFile);
		}

		[DllImport("shell32.dll", CharSet = CharSet.Ansi)]
		private static extern void SHAddToRecentDocs(int flag, string path);

		private void OnClearListMenuItemClick()
		{
			var fileArray = new StringCollection();
			fileArray.AddRange(Files.ToArray());
			try
			{
				if (StorageHandler != null)
				{
					foreach (var s in StorageHandler.Files)
						try { File.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Recent), Path.GetFileName(s) + ".lnk")); } catch { }
					StorageHandler.Files = null;
				}
				MenuBuilderHandler?.ClearRecentFiles();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			ClearListMenuItemClick?.Invoke(fileArray);
		}

		private void OnRecentFileMenuItemClick(string file)
		{
			RecentFileMenuItemClick?.Invoke(file);
		}

		/// <summary>Storage in the local application settings.</summary>
		public class AppSettingsFileListStorage : IFileListStorage
		{
			private const string propName = "__MRUList__";
			private ApplicationSettingsBase settings;

			/// <summary>Initializes a new instance of the <see cref="AppSettingsFileListStorage"/> class.</summary>
			/// <param name="settings">
			/// The settings object to use. If <see langword="null"/>, the component will search all loaded assemblies for an instance.
			/// </param>
			public AppSettingsFileListStorage(ApplicationSettingsBase settings = null)
			{
				if (settings != null) Settings = settings;
			}

			/// <summary>Gets or sets the files.</summary>
			/// <value>The files.</value>
			public IEnumerable<string> Files
			{
				get => new List<string>(SettingsValue.Cast<string>());
				set
				{
					var col = new StringCollection();
					if (value != null)
						col.AddRange(value.ToArray());
					SettingsValue = col;
				}
			}

			private ApplicationSettingsBase Settings
			{
				get => settings;
				set { settings = value; AddMRUPropToSettings(); }
			}

			private StringCollection SettingsValue
			{
				get => settings != null ? settings[propName] as StringCollection : new StringCollection();
				set { if (settings != null) settings[propName] = value; }
			}

			/// <summary>Adds the recent file.</summary>
			/// <param name="fileNameWithFullPath">The file name with full path.</param>
			public void AddRecentFile(string fileNameWithFullPath)
			{
				var col = new StringCollection { fileNameWithFullPath };
				col.AddRange(SettingsValue.Cast<string>().ToArray());
				SettingsValue = col;
			}

			/// <summary>Initializes this instance.</summary>
			public void Initialize()
			{
				TryLoadAppSettings();
			}

			/// <summary>Removes the recent file.</summary>
			/// <param name="fileNameWithFullPath">The file name with full path.</param>
			public void RemoveRecentFile(string fileNameWithFullPath)
			{
				var col = SettingsValue;
				col.Remove(fileNameWithFullPath);
				SettingsValue = col;
			}

			private void AddMRUPropToSettings()
			{
				if (Settings?.Properties[propName] != null) return;

				object defValue = new StringCollection();
				var d = new SettingsAttributeDictionary
				{
					{ typeof(UserScopedSettingAttribute), new UserScopedSettingAttribute() }
				};
				Settings?.Properties.Add(new SettingsProperty(propName, typeof(StringCollection),
					Settings.Providers["LocalFileSettingsProvider"], false, defValue,
					SettingsSerializeAs.Xml, d, false, false));
				Settings?.Reload();
				var conf = SettingsValue;
				if (conf != null) return;
				SettingsValue = new StringCollection();
				Settings?.Save();
			}

			private void TryLoadAppSettings()
			{
				if (Settings != null) return;
				var appSettingsType = AppDomain.CurrentDomain.GetAllTypes().FirstOrDefault(t => t.IsSubclassOf(typeof(ApplicationSettingsBase)));
				if (appSettingsType != null)
				{
					var defProp = appSettingsType.GetProperty("Default");
					if (defProp != null)
						Settings = (ApplicationSettingsBase)defProp.GetValue(null, null);
					else
						Settings = (ApplicationSettingsBase)SettingsBase.Synchronized((ApplicationSettingsBase)Activator.CreateInstance(appSettingsType));
				}
				else
					throw new ApplicationException("Assembly hosting MRUManager must already have a settings instance derived from ApplicationSettingsBase.");
			}
		}

		/// <summary></summary>
		public class RegistryFileListStorage : IFileListStorage
		{
			/// <summary>Gets or sets the files.</summary>
			/// <value>The files.</value>
			public IEnumerable<string> Files
			{
				get => GetFiles(GetKey());
				set => SetFiles(GetKey(), value);
			}

			/// <summary>Gets or sets the name of the sub key.</summary>
			/// <value>The name of the sub key.</value>
			public string SubKeyName { get; set; }

			/// <summary>Adds the recent file.</summary>
			/// <param name="fileNameWithFullPath">The file name with full path.</param>
			public void AddRecentFile(string fileNameWithFullPath)
			{
				try
				{
					using var rK = GetKey();
					var l = new List<string>(GetFiles(rK));
					l.Insert(0, fileNameWithFullPath);
					SetFiles(rK, l.Distinct());
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
				}
			}

			/// <summary>Initializes this instance.</summary>
			public void Initialize()
			{
				if (SubKeyName == null)
				{
					var company = GetAssemblyAttribute<AssemblyCompanyAttribute>()?.Company;
					var product = GetAssemblyAttribute<AssemblyProductAttribute>()?.Product;
					string s;
					if (company != null && product != null)
						s = $"{company}\\{product}";
					else if (company != null)
						s = company;
					else if (product != null)
						s = product;
					else
						s = Assembly.GetExecutingAssembly().GetName().Name;
					SubKeyName = $"Software\\{s}\\MRU";
				}
			}

			/// <summary>Removes the recent file.</summary>
			/// <param name="fileNameWithFullPath">The file name with full path.</param>
			public void RemoveRecentFile(string fileNameWithFullPath)
			{
				try
				{
					using var rK = GetKey();
					var l = new List<string>(GetFiles(rK));
					l.RemoveAll(s => string.Equals(s, fileNameWithFullPath, StringComparison.InvariantCultureIgnoreCase));
					SetFiles(rK, l.Distinct());
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
				}
			}

			private static T GetAssemblyAttribute<T>() => (T)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(T), true).FirstOrDefault();

			private IEnumerable<string> GetFiles(SafeRegKey rK)
			{
				for (var i = 0; ; i++)
				{
					if (!(rK.Key.GetValue(i.ToString(), null) is string s))
						break;
					yield return s;
				}
			}

			private SafeRegKey GetKey() => new SafeRegKey(Registry.CurrentUser, SubKeyName, RegistryKeyPermissionCheck.ReadWriteSubTree);

			private void SetFiles(SafeRegKey rK, IEnumerable<string> value)
			{
				var i = 0;
				while (true)
				{
					try { rK.Key.DeleteValue(i++.ToString(), true); }
					catch { break; }
				}
				i = 0;
				foreach (var s in value)
					rK.Key.SetValue(i++.ToString(), s);
			}

			private class SafeRegKey : IDisposable
			{
				public readonly RegistryKey Key;

				public SafeRegKey(RegistryKey root, string subKeyName, RegistryKeyPermissionCheck opt)
				{
					Key = root.CreateSubKey(subKeyName, opt);
				}

				public static implicit operator RegistryKey(SafeRegKey k) => k.Key;

				public void Dispose()
				{
					Key.Close();
				}
			}
		}
	}
}

namespace Vanara.Windows.Forms
{
	using System.Drawing;
	using System.Text;
	using System.Windows.Forms;
	using Vanara.Configuration;
	using Vanara.PInvoke;

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
			Action<StringCollection> onClearRecentFilesClick = null, IFileListStorage storageHandler = null)
			: base(storageHandler ?? new AppSettingsFileListStorage(), new MenuStripMenuBuilder())
		{
			FileExtensions = extensions;
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
		public Image ClearListMenuItemImage
		{
			get => clearListMenuItemImage as Image;
			set
			{
				if (!(value is Image))
					throw new ArgumentException("Must be of type Image.");
				clearListMenuItemImage = value;
				RefreshRecentFilesMenu();
			}
		}

		/// <summary>Gets or sets the recent file menu item.</summary>
		/// <value>The recent file menu item.</value>
		[DefaultValue(null), Category("Behavior"), Description("The recent file menu item.")]
		public ToolStripMenuItem RecentFileMenuItem
		{
			get => ((MenuStripMenuBuilder)MenuBuilderHandler).RecentFileMenuItem;
			set { ((MenuStripMenuBuilder)MenuBuilderHandler).RecentFileMenuItem = value; RefreshRecentFilesMenu(); }
		}

		/// <summary>Builds a menu within a MenuStrip.</summary>
		private class MenuStripMenuBuilder : IMenuBuilder
		{
			private Action<string> fileMenuItemClickAction;

			/// <summary>Gets or sets the recent file menu item.</summary>
			/// <value>The recent file menu item.</value>
			public ToolStripMenuItem RecentFileMenuItem { get; set; }

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
			public void RebuildMenus(IEnumerable<string> files, Action<string> fileMenuItemClick, string clearListMenuItemText = null, Action clearListMenuItemClick = null, object clearListMenuItemImage = null, bool clearListMenuItemOnTop = false, Func<string, object> menuImageCallback = null)
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
					RecentFileMenuItem.DropDownItems.Add(new ToolStripMenuItem(CompactPath(RecentFileMenuItem.GetCurrentParent().CreateGraphics(), f, RecentFileMenuItem.Font, RecentFileMenuItem.Width), menuImageCallback?.Invoke(f) as Image, OnFileMenuItemClick) { Tag = f });
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

			private void OnFileMenuItemClick(object sender, EventArgs e)
			{
				if (sender is ToolStripMenuItem item)
					fileMenuItemClickAction(item.Tag.ToString());
			}
		}
	}
}

//namespace Vanara.Windows.Controls
//{
//	using Vanara.Configuration;
//	using System.Windows.Controls;

// ///
// <summary>
// /// A class that manages a Most Recently Used file listing and interacts with a MenuStrip to display a menu list of the files. By
// default, the application /// settings are used to store the history. Optionally a constructor can be used to provide an alternate class
// to handle that work. ///
// </summary>
// [DefaultProperty("RecentFileMenuItem")] public class MenuMRUManager : MRUManager { ///
// <summary>Initializes a new instance of the <see cref="MenuMRUManager"/> class.</summary>
// public MenuMRUManager() : base(new AppSettingsFileListStorage(), new MenuBuilder()) { }

// /// <summary>Initializes a new instance of the <see cref="MenuMRUManager"/> class.</summary> /// <param name="extensions">The extensions
// of files to find in system MRU list.</param> /// <param name="parentMenuItem">The parent "Recent Files" menu item.</param> /// <param
// name="onRecentFileClick">Action to run when The on recent file click.</param> /// <param name="onClearRecentFilesClick">Optional. The on
// clear recent files click.</param> /// <param name="storageHandler">Optional. The storage handler.</param> public MenuMRUManager(string
// extensions, MenuItem parentMenuItem, Action<string> onRecentFileClick, Action<StringCollection> onClearRecentFilesClick = null,
// IFileListStorage storageHandler = null) : base(storageHandler ?? new AppSettingsFileListStorage(), new MenuBuilder()) { FileExtensions =
// extensions; ((MenuBuilder)MenuBuilderHandler).RecentFileMenuItem = parentMenuItem; if (onRecentFileClick != null) RecentFileMenuItemClick
// += onRecentFileClick; if (onClearRecentFilesClick != null) ClearListMenuItemClick += onClearRecentFilesClick;

// RefreshRecentFilesMenu(); }

// ///
// <summary>Gets or sets the recent file menu item.</summary>
// ///
// <value>The recent file menu item.</value>
// [DefaultValue(null), Category("Behavior"), Description("The recent file menu item.")] public MenuItem RecentFileMenuItem { get =&gt;
// ((MenuBuilder)MenuBuilderHandler).RecentFileMenuItem; set { ((MenuBuilder)MenuBuilderHandler).RecentFileMenuItem = value;
// RefreshRecentFilesMenu(); } }

// /// <summary>Builds a menu within a MenuStrip.</summary> private class MenuBuilder : IMenuBuilder { private Action<string> fileMenuItemClickAction;

// ///
// <summary>Gets or sets the recent file menu item.</summary>
// ///
// <value>The recent file menu item.</value>
// public MenuItem RecentFileMenuItem { get; set; }

// ///
// <summary>Clears the recent files.</summary>
// public void ClearRecentFiles() { if (RecentFileMenuItem == null) return; RecentFileMenuItem.Items.Clear(); RecentFileMenuItem.IsEnabled =
// false; }

// /// <summary>Rebuilds the menus.</summary> /// <param name="files">The file listing.</param> /// <param name="fileMenuItemClick">The
// handler for when one of the automatically added recent file menu items is clicked..</param> /// <param name="clearListMenuItemText">The
// clear list menu item text. A <c>null</c> value indicates that this menu item should not be shown.</param> /// <param
// name="clearListMenuItemClick">The handler for when the clear recent files menu item is clicked.</param> /// <param
// name="clearListMenuItemImage">The clear list menu item image. A <c>null</c> value indicates that this menu item's image should not be
// shown.</param> /// <param name="clearListMenuItemOnTop">if set to <see langword="true" />, the clear list menu item precedes the
// files.</param> /// <param name="menuImageCallback">The menu image callback delegate.</param> public void RebuildMenus(IEnumerable<string>
// files, Action<string> fileMenuItemClick, string clearListMenuItemText = null, Action clearListMenuItemClick = null, object
// clearListMenuItemImage = null, bool clearListMenuItemOnTop = false, Func<string, object> menuImageCallback = null) { if
// (RecentFileMenuItem == null) return;

// RecentFileMenuItem.Items.Clear();

// fileMenuItemClickAction = fileMenuItemClick; foreach (var f in files) AddMenuItem(f, OnFileMenuItemClick);

// if (RecentFileMenuItem.Items.Count == 0) { RecentFileMenuItem.IsEnabled = false; return; }

// if (!string.IsNullOrEmpty(clearListMenuItemText)) { RecentFileMenuItem.Items.Add(new Separator()); AddMenuItem(clearListMenuItemText, (o,
// e) => clearListMenuItemClick()); } RecentFileMenuItem.IsEnabled = true; }

// private void AddMenuItem(string f, System.Windows.RoutedEventHandler handler) { var m = new MenuItem() { Header = f, Tag = f }; m.Click
// += handler; RecentFileMenuItem.Items.Add(m); }

//			private void OnFileMenuItemClick(object sender, RoutedEventArgs e)
//			{
//				if (sender is MenuItem item)
//					fileMenuItemClickAction(item.Tag.ToString());
//			}
//		}
//	}
//}