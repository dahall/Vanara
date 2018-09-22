using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Vanara.Extensions;
using Vanara.PInvoke;
using static Vanara.PInvoke.Shell32;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global

namespace Vanara.Windows.Shell
{
	/// <summary>Defines options for filtering folder items.</summary>
	public enum LibraryFolderFilter
	{
		/// <summary>Return only file system items.</summary>
		FileSystemOnly = LIBRARYFOLDERFILTER.LFF_FORCEFILESYSTEM,
		/// <summary>Return items that can be bound to an IStorage object.</summary>
		StorageObjects = LIBRARYFOLDERFILTER.LFF_STORAGEITEMS,
		/// <summary>Return all items.</summary>
		AllItems = LIBRARYFOLDERFILTER.LFF_ALLITEMS
	}

	/// <summary>Defines the type of view assigned to a library folder.</summary>
	public enum LibraryViewTemplate
	{
		/// <summary>Introduced in Windows 8.1. The folder does not fall under one of the other categories.</summary>
		General = FOLDERTYPEID.FOLDERTYPEID_StorageProviderGeneric,
		/// <summary>Introduced in Windows 8.1. The folder contains document files. These can be of mixed format—.doc, .txt, and others.</summary>
		Documents = FOLDERTYPEID.FOLDERTYPEID_StorageProviderDocuments,
		/// <summary>Introduced in Windows 8.1. The folder contains image files, such as .jpg, .tif, or .png files.</summary>
		Pictures = FOLDERTYPEID.FOLDERTYPEID_StorageProviderPictures,
		/// <summary>Introduced in Windows 8.1. The folder contains audio files, such as .mp3 and .wma files.</summary>
		Music = FOLDERTYPEID.FOLDERTYPEID_StorageProviderMusic,
		/// <summary>Introduced in Windows 8.1. The folder contains video files. These can be of mixed format—.wmv, .mov, and others.</summary>
		Videos = FOLDERTYPEID.FOLDERTYPEID_StorageProviderVideos,
		/// <summary>A custom template defined in the registry. Use <see cref="ShellLibrary.ViewTemplateId"/> for the identifier.</summary>
		Custom = -1,
	}

	/// <summary>Shell library encapsulation.</summary>
	/// <seealso cref="System.IDisposable"/>
	public class ShellLibrary : ShellFolder
	{
		//private const string ext = ".library-ms";
		internal IShellLibrary lib;
		private ShellLibraryFolders folders;
		private string name;

		/// <summary>Initializes a new instance of the <see cref="ShellLibrary"/> class.</summary>
		/// <param name="knownFolderId">The known folder identifier.</param>
		/// <param name="readOnly">if set to <c>true</c> [read only].</param>
		public ShellLibrary(KNOWNFOLDERID knownFolderId, bool readOnly = false)
		{
			lib = new IShellLibrary();
			lib.LoadLibraryFromKnownFolder(knownFolderId.Guid(), readOnly ? STGM.STGM_READ : STGM.STGM_READWRITE);
			Init(knownFolderId.GetIShellItem());
		}

		/// <summary>Initializes a new instance of the <see cref="ShellLibrary"/> class.</summary>
		/// <param name="libraryName">Name of the library.</param>
		/// <param name="kf">The kf.</param>
		/// <param name="overwrite">if set to <c>true</c> [overwrite].</param>
		public ShellLibrary(string libraryName, KNOWNFOLDERID kf = KNOWNFOLDERID.FOLDERID_Libraries, bool overwrite = false)
		{
			lib = new IShellLibrary();
			name = libraryName;
			lib.SaveInKnownFolder(kf.Guid(), libraryName, overwrite ? LIBRARYSAVEFLAGS.LSF_OVERRIDEEXISTING : LIBRARYSAVEFLAGS.LSF_FAILIFTHERE);
		}

		/// <summary>Initializes a new instance of the <see cref="ShellLibrary"/> class.</summary>
		/// <param name="libraryName">Name of the library.</param>
		/// <param name="parent">The parent.</param>
		/// <param name="overwrite">if set to <c>true</c> [overwrite].</param>
		public ShellLibrary(string libraryName, ShellFolder parent, bool overwrite = false)
		{
			lib = new IShellLibrary();
			name = libraryName;
			lib.Save(parent.iShellItem, libraryName, overwrite ? LIBRARYSAVEFLAGS.LSF_OVERRIDEEXISTING : LIBRARYSAVEFLAGS.LSF_FAILIFTHERE);
		}

		/// <summary>Initializes a new instance of the <see cref="ShellLibrary"/> class.</summary>
		/// <param name="iItem">The i item.</param>
		/// <param name="readOnly">if set to <c>true</c> [read only].</param>
		internal ShellLibrary(IShellItem iItem, bool readOnly = false) : base(iItem)
		{
			lib = new IShellLibrary();
			lib.LoadLibraryFromItem(iItem, readOnly ? STGM.STGM_READ : STGM.STGM_READWRITE);
		}
		/// <summary>Gets or sets the default target folder the library uses for save operations.</summary>
		/// <value>The default save folder.</value>
		public ShellItem DefaultSaveFolder
		{
			get => Open(lib.GetDefaultSaveFolder(DEFAULTSAVEFOLDERTYPE.DSFT_DETECT, typeof(IShellItem).GUID));
			set => lib.SetDefaultSaveFolder(DEFAULTSAVEFOLDERTYPE.DSFT_DETECT, value.iShellItem);
		}

		/// <summary>Gets the set of child folders that are contained in the library.</summary>
		/// <value>A <see cref="ShellItemArray"/> containing the child folders.</value>
		public ShellLibraryFolders Folders => folders ?? (folders = GetFilteredFolders());

		/// <summary>Gets or sets a string that describes the location of the default icon. The string must be formatted as <c>ModuleFileName,ResourceIndex or ModuleFileName,-ResourceID</c>.</summary>
		/// <value>The default icon location.</value>
		public IconLocation IconLocation
		{
			get { IconLocation.TryParse(lib.GetIcon(), out var l); return l; }
			set => lib.SetIcon(value.StringValue);
		}

		/// <summary>Gets the name relative to the parent for the item.</summary>
		public override string Name { get => name; protected set => name = value; }

		/// <summary>Gets or sets a value indicating whether to pin the library to the navigation pane.</summary>
		/// <value><c>true</c> if pinned to the navigation pane; otherwise, <c>false</c>.</value>
		public bool PinnedToNavigationPane
		{
			get => lib.GetOptions().IsFlagSet(LIBRARYOPTIONFLAGS.LOF_PINNEDTONAVPANE);
			set => lib.SetOptions(LIBRARYOPTIONFLAGS.LOF_PINNEDTONAVPANE, value ? LIBRARYOPTIONFLAGS.LOF_PINNEDTONAVPANE : 0);
		}

		/// <summary>Gets or sets the library's View Template.</summary>
		/// <value>The View Template.</value>
		public LibraryViewTemplate ViewTemplate
		{
			get => (LibraryViewTemplate) ShlGuidExt.Lookup<FOLDERTYPEID>(ViewTemplateId);
			set { if (value != LibraryViewTemplate.Custom) ViewTemplateId = ((FOLDERTYPEID) value).Guid(); }
		}

		/// <summary>Gets or sets the library's View Template identifier.</summary>
		/// <value>The View Template identifier.</value>
		public Guid ViewTemplateId
		{
			get => lib.GetFolderType();
			set => lib.SetFolderType(value);
		}

		/// <summary>Commits library updates.</summary>
		public void Commit() => lib.Commit();

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		public override void Dispose()
		{
			if (lib != null)
			{
				Marshal.ReleaseComObject(lib);
				lib = null;
			}

			base.Dispose();
		}

		/// <summary>Gets the set of child folders that are contained in the library.</summary>
		/// <param name="filter">A value that determines the folders to get.</param>
		/// <returns>A <see cref="ShellItemArray"/> containing the child folders.</returns>
		public ShellLibraryFolders GetFilteredFolders(LibraryFolderFilter filter = LibraryFolderFilter.AllItems) =>
			new ShellLibraryFolders(lib, lib.GetFolders((LIBRARYFOLDERFILTER)filter, typeof(IShellItemArray).GUID));

		/// <summary>Resolves the target location of a library folder, even if the folder has been moved or renamed.</summary>
		/// <param name="item">A ShellItem object that represents the library folder to locate.</param>
		/// <param name="timeout">The maximum time the method will attempt to locate the folder before returning. If the folder could not be located before the specified time elapses, an error is returned.</param>
		/// <returns>The resulting target location.</returns>
		public ShellItem ResolveFolder(ShellItem item, TimeSpan timeout) => Open(lib.ResolveFolder(item.iShellItem, Convert.ToUInt32(timeout.TotalMilliseconds), typeof(IShellItem).GUID));

		/// <summary>Shows the library management dialog box, which enables users to manage the library folders and default save location.</summary>
		/// <param name="parentWindow">The handle for the window that owns the library management dialog box. The value of this parameter can be NULL.</param>
		/// <param name="title">The title for the library management dialog. To display the generic title string, set the value of this parameter to NULL.</param>
		/// <param name="instruction">The help string to display below the title string in the library management dialog box. To display the generic help string, set the value of this parameter to NULL.</param>
		/// <param name="allowUnindexableLocations">if set to <c>true</c> do not display a warning dialog to the user in collisions that concern network locations that cannot be indexed.</param>
		public void ShowLibraryManagementDialog(IWin32Window parentWindow = null, string title = null, string instruction = null, bool allowUnindexableLocations = false)
		{
			SHShowManageLibraryUI(iShellItem, parentWindow?.Handle ?? IntPtr.Zero, title, instruction,
				allowUnindexableLocations ? LIBRARYMANAGEDIALOGOPTIONS.LMD_ALLOWUNINDEXABLENETWORKLOCATIONS : LIBRARYMANAGEDIALOGOPTIONS.LMD_DEFAULT).ThrowIfFailed();
		}

		/// <summary>Folders of a <see cref="ShellLibrary"/>.</summary>
		/// <seealso cref="Vanara.Windows.Shell.ShellItemArray"/>
		/// <seealso cref="System.Collections.Generic.ICollection{ShellItem}"/>
		public class ShellLibraryFolders : ShellItemArray, ICollection<ShellItem>
		{
			private IShellLibrary lib;

			/// <summary>Initializes a new instance of the <see cref="ShellLibraryFolders"/> class.</summary>
			/// <param name="lib">The library.</param>
			/// <param name="shellItemArray">The shell item array.</param>
			internal ShellLibraryFolders(IShellLibrary lib, IShellItemArray shellItemArray) : base(shellItemArray)
			{
				this.lib = lib;
			}

			/// <summary>Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.</summary>
			bool ICollection<ShellItem>.IsReadOnly => false;

			/// <summary>Adds the specified location.</summary>
			/// <param name="location">The location.</param>
			/// <exception cref="ArgumentNullException">location</exception>
			public void Add(ShellItem location)
			{
				if (location == null) throw new ArgumentNullException(nameof(location));
				lib.AddFolder(location.iShellItem);
			}

			/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
			public override void Dispose()
			{
				if (lib != null)
				{
					Marshal.ReleaseComObject(lib);
					lib = null;
				}
				base.Dispose();
			}

			/// <summary>Removes the specified location.</summary>
			/// <param name="location">The location.</param>
			/// <returns><c>true</c> on success.</returns>
			/// <exception cref="ArgumentNullException">location</exception>
			public bool Remove(ShellItem location)
			{
				if (location == null) throw new ArgumentNullException(nameof(location));
				try
				{
					lib.RemoveFolder(location.iShellItem);
					return true;
				}
				catch
				{
					return false;
				}
			}

			/// <summary>Removes all items from the <see cref="ICollection{ShellItem}"/>.</summary>
			/// <exception cref="NotImplementedException"></exception>
			void ICollection<ShellItem>.Clear() => throw new NotImplementedException();
		}
	}
}
