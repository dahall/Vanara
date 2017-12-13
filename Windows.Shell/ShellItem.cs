using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Vanara.PInvoke;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.ComCtl32;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.Macros;
using static Vanara.PInvoke.PropSys;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.Shell32;
using static Vanara.PInvoke.User32_Gdi;

// ReSharper disable InconsistentNaming

namespace Vanara.Windows.Shell
{
	/// <summary>Attributes that can be retrieved on an item (file or folder) or set of items using <see cref="ShellItem.Attributes"/>.</summary>
	[Flags]
	public enum ShellItemAttribute : uint
	{
		/// <summary>The specified items can be copied.</summary>
		CanCopy = 0x00000001,

		/// <summary>The specified items can be moved.</summary>
		CanMove = 0x00000002,

		/// <summary>
		/// Shortcuts can be created for the specified items. If a namespace extension returns this attribute, a Create
		/// Shortcut entry with a default handler is added to the shortcut menu that is displayed during drag-and-drop
		/// operations. The extension can also implement its own handler for the link verb in place of the default. If
		/// the extension does so, it is responsible for creating the shortcut. A Create Shortcut item is also added to
		/// the Windows Explorer File menu and to normal shortcut menus. If the item is selected, your application's
		/// IContextMenu::InvokeCommand method is invoked with the lpVerb member of the CMINVOKECOMMANDINFO structure set
		/// to link. Your application is responsible for creating the link.
		/// </summary>
		CanLink = 0x00000004,

		/// <summary>
		/// The specified items can be bound to an IStorage object throughIShellFolder::BindToObject. For more
		/// information about namespace manipulation capabilities, see IStorage.
		/// </summary>
		Storage = 0x00000008,

		/// <summary>
		/// The specified items can be renamed. Note that this value is essentially a suggestion; not all namespace
		/// clients allow items to be renamed. However, those that do must have this attribute set.
		/// </summary>
		CanRename = 0x00000010,

		/// <summary>The specified items can be deleted.</summary>
		CanDelete = 0x00000020,

		/// <summary>The specified items have property sheets.</summary>
		HasPropSheet = 0x00000040,

		/// <summary>The specified items are drop targets.</summary>
		DropTarget = 0x00000100,

		/// <summary>
		/// This flag is a mask for the capability attributes: CANCOPY, CANMOVE, CANLINK, CANRENAME, CANDELETE,
		/// HASPROPSHEET, and DROPTARGET. Callers normally do not use this value.
		/// </summary>
		CapabilityMask = 0x00000177,

		/// <summary>Windows 7 and later. The specified items are system items.</summary>
		System = 0x00001000,

		/// <summary>The specified items are encrypted and might require special presentation.</summary>
		Encrypted = 0x00002000,

		/// <summary>
		/// Accessing the item (through IStream or other storage interfaces) is expected to be a slow operation.
		/// Applications should avoid accessing items flagged with ISSLOW. Note: Opening a stream for an item is
		/// generally a slow operation at all times. ISSLOW indicates that it is expected to be especially slow, for
		/// example in the case of slow network connections or offline (FILE_ATTRIBUTE_OFFLINE) files. However, querying
		/// ISSLOW is itself a slow operation. Applications should query ISSLOW only on a background thread. An alternate
		/// method, such as retrieving the PKEY_FileAttributes property and testing for FILE_ATTRIBUTE_OFFLINE, could be
		/// used in place of a method call that involves ISSLOW.
		/// </summary>
		IsSlow = 0x00004000,

		/// <summary>The specified items are shown as dimmed and unavailable to the user.</summary>
		Ghosted = 0x00008000,

		/// <summary>The specified items are shortcuts.</summary>
		Link = 0x00010000,

		/// <summary>The specified objects are shared.</summary>
		Share = 0x00020000,

		/// <summary>
		/// The specified items are read-only. In the case of folders, this means that new items cannot be created in
		/// those folders. This should not be confused with the behavior specified by the FILE_ATTRIBUTE_READONLY flag
		/// retrieved by IColumnProvider::GetItemData in a SHCOLUMNDATAstructure. FILE_ATTRIBUTE_READONLY has no meaning
		/// for Win32 file system folders.
		/// </summary>
		ReadOnly = 0x00040000,

		/// <summary>
		/// The item is hidden and should not be displayed unless the Show hidden files and folders option is enabled in
		/// Folder Settings.
		/// </summary>
		Hidden = 0x00080000,

		/// <summary>Do not use.</summary>
		DisplayAttrMask = 0x000FC000,

		/// <summary>
		/// The items are nonenumerated items and should be hidden. They are not returned through an enumerator such as
		/// that created by theIShellFolder::EnumObjects method.
		/// </summary>
		NonEnumerated = 0x00100000,

		/// <summary>The items contain new content, as defined by the particular application.</summary>
		NewContent = 0x00200000,

		/// <summary>Not supported.</summary>
		CanMoniker = 0x00400000,

		/// <summary>Not supported.</summary>
		HasStorage = 0x00400000,

		/// <summary>
		/// Indicates that the item has a stream associated with it. That stream can be accessed through a call to
		/// IShellFolder::BindToObject orIShellItem::BindToHandler with IID_IStream in the riid parameter.
		/// </summary>
		Stream = 0x00400000,

		/// <summary>
		/// Children of this item are accessible through IStream or IStorage. Those children are flagged with STORAGE or STREAM.
		/// </summary>
		StorageAncestor = 0x00800000,

		/// <summary>
		/// When specified as input, VALIDATE instructs the folder to validate that the items contained in a folder or
		/// Shell item array exist. If one or more of those items do not exist, IShellFolder::GetAttributesOf and
		/// IShellItemArray::GetAttributes return a failure code. This flag is never returned as an [out] value. When
		/// used with the file system folder, VALIDATE instructs the folder to discard cached properties retrieved by
		/// clients of IShellFolder2::GetDetailsEx that might have accumulated for the specified items.
		/// </summary>
		Validate = 0x01000000,

		/// <summary>The specified items are on removable media or are themselves removable devices.</summary>
		Removable = 0x02000000,

		/// <summary>The specified items are compressed.</summary>
		Compressed = 0x04000000,

		/// <summary>The specified items can be hosted inside a web browser or Windows Explorer frame.</summary>
		Browsable = 0x08000000,

		/// <summary>
		/// The specified folders are either file system folders or contain at least one descendant (child, grandchild,
		/// or later) that is a file system (FILESYSTEM) folder.
		/// </summary>
		FileSysAncestor = 0x10000000,

		/// <summary>
		/// The specified items are folders. Some items can be flagged with both STREAM and FOLDER, such as a compressed
		/// file with a .zip file name extension. Some applications might include this flag when testing for items that
		/// are both files and containers.
		/// </summary>
		Folder = 0x20000000,

		/// <summary>
		/// The specified folders or files are part of the file system (that is, they are files, directories, or root
		/// directories). The parsed names of the items can be assumed to be valid Win32 file system paths. These paths
		/// can be either UNC or drive-letter based.
		/// </summary>
		FileSystem = 0x40000000,

		/// <summary>
		/// This flag is a mask for the storage capability attributes: STORAGE, LINK, READONLY, STREAM, STORAGEANCESTOR,
		/// FILESYSANCESTOR, FOLDER, and FILESYSTEM. Callers normally do not use this value.
		/// </summary>
		StorageCapMask = 0x70C50008,

		/// <summary>
		/// The specified folders have subfolders. The HASSUBFOLDER attribute is only advisory and might be returned by
		/// Shell folder implementations even if they do not contain subfolders. Note, however, that the converse—failing
		/// to return HASSUBFOLDER—definitively states that the folder objects do not have subfolders. Returning
		/// HASSUBFOLDER is recommended whenever a significant amount of time is required to determine whether any
		/// subfolders exist. For example, the Shell always returns HASSUBFOLDER when a folder is located on a network drive.
		/// </summary>
		HasSubfolder = 0x80000000,

		/// <summary>
		/// This flag is a mask for content attributes, at present only HASSUBFOLDER. Callers normally do not use this value.
		/// </summary>
		ContentsMask = 0x80000000,

		/// <summary>
		/// Mask used by the PKEY_SFGAOFlags property to determine attributes that are considered to cause slow
		/// calculations or lack context: ISSLOW, READONLY, HASSUBFOLDER, and VALIDATE. Callers normally do not use this value.
		/// </summary>
		PKEYMask = 0x81044000,
	}

	/// <summary>Requests the form of an item's display name to retrieve through <see cref="ShellItem.GetDisplayName"/>.</summary>
	public enum ShellItemDisplayString : uint
	{
		/// <summary>
		/// Returns the display name relative to the parent folder. In UI this name is generally ideal for display to the user.
		/// </summary>
		NormalDisplay = 0x00000000,

		/// <summary>
		/// Returns the parsing name relative to the parent folder. This name is not suitable for use in UI.
		/// </summary>
		ParentRelativeParsing = 0x80018001,

		/// <summary>Returns the parsing name relative to the desktop. This name is not suitable for use in UI.</summary>
		DesktopAbsoluteParsing = 0x80028000,

		/// <summary>
		/// Returns the editing name relative to the parent folder. In UI this name is suitable for display to the user.
		/// </summary>
		ParentRelativeEditing = 0x80031001,

		/// <summary>
		/// Returns the editing name relative to the desktop. In UI this name is suitable for display to the user.
		/// </summary>
		DesktopAbsoluteEditing = 0x8004c000,

		/// <summary>
		/// Returns the item's file system path, if it has one. Only items that report SFGAO_FILESYSTEM have a file
		/// system path. When an item does not have a file system path, a call to IShellItem::GetDisplayName on that item
		/// will fail. In UI this name is suitable for display to the user in some cases, but note that it might not be
		/// specified for all items.
		/// </summary>
		FileSysPath = 0x80058000,

		/// <summary>
		/// Returns the item's URL, if it has one. Some items do not have a URL, and in those cases a call to
		/// IShellItem::GetDisplayName will fail. This name is suitable for display to the user in some cases, but note
		/// that it might not be specified for all items.
		/// </summary>
		Url = 0x80068000,

		/// <summary>
		/// Returns the path relative to the parent folder in a friendly format as displayed in an address bar. This name
		/// is suitable for display to the user.
		/// </summary>
		ParentRelativeForAddressBar = 0x8007c001,

		/// <summary>Returns the path relative to the parent folder.</summary>
		ParentRelative = 0x80080001,

		/// <summary>Introduced in Windows 8.</summary>
		ParentRelativeForUI = 0x80094001,
	}

	/// <summary>Encapsulates an item in the Windows Shell.</summary>
	/// <seealso cref="System.IComparable{ShellItem}"/>
	/// <seealso cref="System.IDisposable"/>
	/// <seealso cref="System.IEquatable{IShellItem}"/>
	/// <seealso cref="System.IEquatable{ShellItem}"/>
	public class ShellItem : IComparable<ShellItem>, IDisposable, IEquatable<IShellItem>, IEquatable<ShellItem>
	{
		internal static readonly bool IsMin7 = Environment.OSVersion.Version >= new Version(6, 1);
		internal static readonly bool IsMinVista = Environment.OSVersion.Version.Major >= 6;

		private static ShellItem desktop;
		private IPropertyStore iprops;
		private IShellItem iShellItem;
		private IShellItem2 iShellItem2;
		private ShellItem parent;
		private PIDL pidl;
		private PropertyStore values;
		private bool writable, slowProps;

		/// <summary>Initializes a new instance of the <see cref="ShellItem"/> class.</summary>
		/// <param name="path">The file system path of the item.</param>
		public ShellItem(string path) : this(new Uri(path)) { }

		/// <summary>Initializes a new instance of the <see cref="ShellItem"/> class.</summary>
		/// <param name="uri">The URI of the item.</param>
		public ShellItem(Uri uri)
		{
			Init(uri);
		}

		/// <summary>Initializes a new instance of the <see cref="ShellItem"/> class.</summary>
		/// <param name="knownFolder">A known folder.</param>
		public ShellItem(KNOWNFOLDERID knownFolder)
		{
			Init(knownFolder);
		}

		/// <summary>Initializes a new instance of the <see cref="ShellItem"/> class.</summary>
		/// <param name="idList">The ID list.</param>
		public ShellItem(PIDL idList)
		{
			Init(idList);
		}

		/// <summary>Initializes a new instance of the <see cref="ShellItem"/> class.</summary>
		/// <param name="parent">The parent Shell item.</param>
		/// <param name="name">The name of the child item.</param>
		public ShellItem(ShellItem parent, string name)
		{
			if (parent == null) throw new ArgumentNullException(nameof(parent));
			if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
			if (!parent.IsFolder) throw new ArgumentException("Parent argument must be a folder.");

			if (parent.IsFileSystem)
				Init(ShellUtil.GetShellItemForPath(Path.Combine(parent.FileSystemPath, name)));
			else
			{
				SFGAO attr = 0;
				parent.GetIShellFolder().ParseDisplayName(IntPtr.Zero, null, name, out uint eaten, out PIDL tempPidl, ref attr);
				Init(tempPidl);
			}
		}

		/// <summary>Initializes a new instance of the <see cref="ShellItem"/> class.</summary>
		/// <param name="parent">The parent Shell item.</param>
		/// <param name="pidl">The ID List of the child.</param>
		public ShellItem(ShellItem parent, PIDL pidl)
		{
			if (parent == null) throw new ArgumentNullException(nameof(parent));
			if (pidl == null || pidl.IsInvalid) throw new ArgumentNullException(nameof(pidl));
			if (!parent.IsFolder) throw new ArgumentException("Parent argument must be a folder.");

			object ppv;
			if (IsMinVista)
				SHCreateItemWithParent(PIDL.Null, parent.GetIShellFolder(), pidl, typeof(IShellItem).GUID, out ppv);
			else
			{
				var idList = PIDL.Combine(parent.PIDL, pidl);
				ppv = new ShellItemImpl(idList, false);
			}
			Init((IShellItem)ppv);
		}

		private ShellItem() { }

		private ShellItem(IShellItem si) { Init(si); }

		/// <summary>Gets the attributes for the Shell item.</summary>
		/// <value>The attributes of the Shell item.</value>
		public ShellItemAttribute Attributes => (ShellItemAttribute)iShellItem.GetAttributes((SFGAO)0xFFFFFFFF);

		/// <summary>Gets a reference to the primary Desktop.</summary>
		/// <value>The desktop instance.</value>
		public static ShellItem Desktop => desktop ?? (desktop = new ShellItem(KNOWNFOLDERID.FOLDERID_Desktop));

		/// <summary>Gets the display name for the shell item.</summary>
		/// <value>The display name of the item.</value>
		public string DisplayName => GetDisplayName(SIGDN.SIGDN_NORMALDISPLAY);

		/// <summary>Gets the executable type of the file.</summary>
		public ExecutableType ExecutableType
		{
			get
			{
				if (IsFileSystem)
				{
					var shfi = new SHFILEINFO();
					var ret = SHGetFileInfo(FileSystemPath, 0, ref shfi, SHFILEINFO.Size, SHGFI.SHGFI_EXETYPE);
					if (ret != IntPtr.Zero)
					{
						var loWord = LOWORD(ret);
						if (HIWORD(ret) == 0x0000)
						{
							if (loWord == 0x5A4D)
								return ExecutableType.DOS;
							if (loWord == 0x4550)
								return ExecutableType.Win32Console;
						}
						else if (loWord == 0x454E || loWord == 0x4550 || loWord == 0x454C)
							return ExecutableType.Windows;
					}
				}
				return ExecutableType.Nonexecutable;
			}
		}

		/// <summary>Gets the file system path if this item is part of the file system.</summary>
		/// <value>The file system path.</value>
		public string FileSystemPath => GetDisplayName(SIGDN.SIGDN_FILESYSPATH);

		/// <summary>Gets the name of the file that contains the icon representing this shell item with the resource ID appended.</summary>
		/// <value>The icon file path and resource ID, or <c>null</c> if no icon is defined.</value>
		public string IconFilePath
		{
			get
			{
				var shfi = new SHFILEINFO();
				var ret = SHGetFileInfo(PIDL, 0, ref shfi, SHFILEINFO.Size, SHGFI.SHGFI_ICONLOCATION | SHGFI.SHGFI_PIDL);
				if (ret == IntPtr.Zero)
				{
					ret = SHGetFileInfo(PIDL, 0, ref shfi, SHFILEINFO.Size, SHGFI.SHGFI_ICONLOCATION | SHGFI.SHGFI_ICON | SHGFI.SHGFI_PIDL);
					if (ret != IntPtr.Zero) DestroyIcon(shfi.hIcon);
				}
				var id = shfi.iIcon == 0 ? "" : $",{shfi.iIcon}";
				return ret != IntPtr.Zero ? shfi.szDisplayName + id : null;
			}
		}

		/// <summary>Gets the index of the icon overlay.</summary>
		/// <value>The index of the icon overlay, or -1 if no overlay is set.</value>
		public int IconOverlayIndex
		{
			get
			{
				var shfi = new SHFILEINFO();
				var ret = SHGetFileInfo(PIDL, 0, ref shfi, SHFILEINFO.Size, SHGFI.SHGFI_ICON | SHGFI.SHGFI_USEFILEATTRIBUTES | SHGFI.SHGFI_OVERLAYINDEX | SHGFI.SHGFI_LINKOVERLAY | SHGFI.SHGFI_PIDL);
				if (ret == IntPtr.Zero) return -1;
				DestroyIcon(shfi.hIcon);
				return (shfi.iIcon >> 24) - 1;
			}
		}

		/// <summary>Gets or sets a value indicating whether to include slow properties.</summary>
		/// <value><c>true</c> if including slow properties; otherwise, <c>false</c>.</value>
		[DefaultValue(false)]
		public bool IncludeSlowProperties
		{
			get => !slowProps; set
			{
				if (value != slowProps)
				{
					slowProps = value;
					GetPropertyStore();
				}
			}
		}

		/// <summary>Gets a value indicating whether this instance is part of the file system.</summary>
		/// <value><c>true</c> if this instance is part of the file system; otherwise, <c>false</c>.</value>
		public bool IsFileSystem => iShellItem.GetAttributes(SFGAO.SFGAO_FILESYSTEM) != 0;

		/// <summary>Gets a value indicating whether this instance is folder.</summary>
		/// <value><c>true</c> if this instance is folder; otherwise, <c>false</c>.</value>
		public bool IsFolder => iShellItem.GetAttributes(SFGAO.SFGAO_FOLDER) != 0;

		/// <summary>Gets a value indicating whether this instance is link.</summary>
		/// <value><c>true</c> if this instance is link; otherwise, <c>false</c>.</value>
		public bool IsLink => iShellItem.GetAttributes(SFGAO.SFGAO_LINK) != 0;

		/// <summary>Gets the large icon for the file.</summary>
		public Icon LargeIcon => GetIcon();

		/// <summary>Gets the parent for the current item.</summary>
		/// <value>The parent item. If this is the desktop, this property will return <c>null</c>.</value>
		public ShellItem Parent
		{
			get
			{
				if (parent == null)
					try { parent = new ShellItem(iShellItem.GetParent()); } catch { }
				return parent;
			}
		}

		/// <summary>Gets a string that can be used to parse an absolute value from the Desktop.</summary>
		/// <value>A parsable name for the item.</value>
		public string ParsingName => GetDisplayName(SIGDN.SIGDN_DESKTOPABSOLUTEPARSING);

		/// <summary>Gets the item's ID list.</summary>
		/// <value>The ID list for the item.</value>
		public PIDL PIDL
		{
			get
			{
				if (pidl == null)
					SHGetIDListFromObject(iShellItem, out pidl);
				return pidl;
			}
		}

		/// <summary>Gets the property store for the item.</summary>
		/// <value>The dictionary of properties.</value>
		public PropertyStore Properties => values ?? (values = new PropertyStore(this));

		[DefaultValue(false)]
		public bool ReadWriteProperties
		{
			get => !writable; set
			{
				if (value != writable)
				{
					writable = value;
					GetPropertyStore();
				}
			}
		}

		/// <summary>Gets the small icon for the file.</summary>
		public Icon SmallIcon => GetIcon(ShellIconType.Small);

		/// <summary>Gets the icon for this shell item from the system.</summary>
		/// <value>The system icon on success; <c>null</c> on failure.</value>
		public Icon SystemIcon
		{
			get
			{
				var shfi = new SHFILEINFO();
				var hImageList = SHGetFileInfo(PIDL, 0, ref shfi, SHFILEINFO.Size, SHGFI.SHGFI_SYSICONINDEX | SHGFI.SHGFI_PIDL);
				if (hImageList == IntPtr.Zero) return null;
				var hIcon = ImageList_GetIcon(hImageList, shfi.iIcon, IMAGELISTDRAWFLAGS.ILD_NORMAL);
				return GetClonedIcon(hIcon);
			}
		}

		/// <summary>Gets the normal tool tip text associated with this item.</summary>
		/// <value>The tool tip text.</value>
		public string ToolTipText => GetToolTip();

		/// <summary>Gets the type name for the file.</summary>
		public string TypeName
		{
			get
			{
				var shfi = new SHFILEINFO();
				var ret = SHGetFileInfo(PIDL, 0, ref shfi, SHFILEINFO.Size, SHGFI.SHGFI_ICON | SHGFI.SHGFI_USEFILEATTRIBUTES | SHGFI.SHGFI_TYPENAME | SHGFI.SHGFI_PIDL);
				return ret == IntPtr.Zero ? null : shfi.szTypeName;
			}
		}

		/// <summary>Gets the <see cref="ShellItem"/> with the specified child name.</summary>
		/// <value>The <see cref="ShellItem"/> instance matching <paramref name="childName"/>.</value>
		/// <param name="childName">Name of the child item.</param>
		/// <returns>The <see cref="ShellItem"/> instance matching <paramref name="childName"/>, if it exists.</returns>
		public ShellItem this[string childName] => new ShellItem(this, childName);

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			if (iprops != null)
				Marshal.ReleaseComObject(iprops);
			if (iShellItem != null)
				Marshal.ReleaseComObject(iShellItem);
			if (iShellItem2 != null)
				Marshal.ReleaseComObject(iShellItem2);
		}

		/// <summary>Enumerates all children of this item. If this item is not a folder/container, this method will return an empty enumeration.</summary>
		/// <param name="filter">A filter for the types of children to enumerate.</param>
		/// <returns>An enumerated list of children matching the filter.</returns>
		public IEnumerable<ShellItem> EnumerateChildren(SHCONTF filter = SHCONTF.SHCONTF_FOLDERS | SHCONTF.SHCONTF_INCLUDEHIDDEN | SHCONTF.SHCONTF_NONFOLDERS)
		{
			if (!IsFolder) yield break;
			var folder = GetIShellFolder();
			var enumId = GetIEnumIDList(folder, filter);
			if (enumId == null) yield break;

			HRESULT result;
			while ((result = enumId.Next(1, out IntPtr cpidl, out uint count)) == HRESULT.S_OK)
			{
				yield return new ShellItem(this, new PIDL(cpidl));
			}
			if (result != HRESULT.S_FALSE)
				Marshal.ThrowExceptionForHR((int)result);
		}

		/// <summary>Determines whether the specified <see cref="System.Object"/>, is equal to this instance.</summary>
		/// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
		{
			var item = obj as ShellItem;
			if (item != null)
				return Equals(item);
			var psi = obj as IShellItem;
			return psi != null ? Equals(psi) : base.Equals(obj);
		}

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public bool Equals(IShellItem other)
		{
			return iShellItem.Compare(other, SICHINTF.SICHINT_ALLFIELDS) == 0;
		}

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public bool Equals(ShellItem other)
		{
			return ((IComparable<ShellItem>)this).CompareTo(other) == 0;
		}

		// ReSharper disable once InconsistentNaming
		/// <summary>Gets the CLSID of a supplied property key.</summary>
		/// <param name="key">The property key.</param>
		/// <returns>The CLSID related to the property key.</returns>
		public Guid GetCLSID(Guid key)
		{
			ThrowIfNoShellItem2();
			var shipk = new PROPERTYKEY(key, 2);
			return iShellItem2.GetCLSID(ref shipk);
		}

		/// <summary>Gets a formatted display name for this item.</summary>
		/// <param name="option">The formatting options.</param>
		/// <returns>A string with the formatted display name if successful; otherwise <c>null</c>.</returns>
		public string GetDisplayName(ShellItemDisplayString option) => GetDisplayName((SIGDN)option);

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => GetDisplayName(SIGDN.SIGDN_DESKTOPABSOLUTEEDITING).GetHashCode();

		/// <summary>
		/// Gets the icon defined by the set of flags provided.
		/// </summary>
		/// <param name="iconType">Flags to specify type of the icon.</param>
		/// <returns><see cref="Icon"/> if successful; <c>null</c> otherwise.</returns>
		public Icon GetIcon(ShellIconType iconType = ShellIconType.Large)
		{
			const SHGFI baseFlags = SHGFI.SHGFI_ICON | SHGFI.SHGFI_PIDL;
			var shfi = new SHFILEINFO();
			var ret = SHGetFileInfo(PIDL, 0, ref shfi, SHFILEINFO.Size, baseFlags | SHGFI.SHGFI_USEFILEATTRIBUTES | (SHGFI)iconType);
			if (ret == IntPtr.Zero)
				ret = SHGetFileInfo(PIDL, 0, ref shfi, SHFILEINFO.Size, baseFlags | (SHGFI)iconType);
			return ret == IntPtr.Zero ? null : GetClonedIcon(shfi.hIcon);
		}

		/// <summary>Gets the <see cref="IShellFolder"/> interface associated with this item.</summary>
		/// <returns>An <see cref="IShellFolder"/> interface associated with this item.</returns>
		public IShellFolder GetIShellFolder()
		{
			try
			{
				return (IShellFolder)iShellItem.BindToHandler(null, BHID_SFObject, typeof(IShellFolder).GUID);
			}
			catch { }
			return null;
		}

		/// <summary>Gets the property specified by <paramref name="key"/>.</summary>
		/// <typeparam name="T">Property type</typeparam>
		/// <param name="key">The property key.</param>
		/// <param name="defValue">The default value.</param>
		/// <returns>The value of the property or <paramref name="defValue"/> if not found.</returns>
		public T GetProperty<T>(PROPERTYKEY key, T defValue = default(T))
		{
			try
			{
				return (T)Properties[key];
			}
			catch { }
			return defValue;
		}

		/// <summary>Gets the formatted tool tip text associated with this item.</summary>
		/// <param name="flags">The format flags.</param>
		/// <returns>The tool tip text formatted as per <paramref name="flags"/>.</returns>
		public string GetToolTip(QITIP flags = QITIP.QITIPF_DEFAULT)
		{
			try
			{
				var relPidl = PIDL.LastId;
				var qi = (IQueryInfo)(Parent ?? Desktop).GetIShellFolder().GetUIObjectOf(IntPtr.Zero, 1, new[] { (IntPtr)relPidl }, typeof(IQueryInfo).GUID, IntPtr.Zero);
				return qi.GetInfoTip(flags);
			}
			catch (Exception)
			{
				return string.Empty;
			}
		}
		int IComparable<ShellItem>.CompareTo(ShellItem other) => iShellItem.Compare(other.iShellItem, SICHINTF.SICHINT_ALLFIELDS);

		/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
		/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
		public override string ToString() => DisplayName;

		// object GetPropertyDescriptionList(IntPtr keyType, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid); object GetPropertyStoreForKeys(IntPtr
		// rgKeys, uint cKeys, GPS flags, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid); object GetPropertyStoreWithCreateObject(GPS flags, object
		// punkCreateObject, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid); void Update(IBindCtx pbc); object BindToHandler(IBindCtx pbc, [In] ref
		// Guid bhid, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

		internal IPropertyStore GetPropertyStore()
		{
			if (iprops == null)
			{
				ThrowIfNoShellItem2();
				var gps = writable ? GETPROPERTYSTOREFLAGS.GPS_READWRITE : GETPROPERTYSTOREFLAGS.GPS_DEFAULT;
				if (slowProps)
					gps |= GETPROPERTYSTOREFLAGS.GPS_OPENSLOWITEM;
				if (iprops != null)
					Marshal.ReleaseComObject(iprops);
				try
				{
					iprops = iShellItem2.GetPropertyStore(gps, typeof(IPropertyStore).GUID) as IPropertyStore;
				}
				catch { }
			}
			return iprops;
		}

		/// <summary>Gets an <see cref="Icon"/> from an icon handle.</summary>
		/// <param name="hIcon">The icon handle.</param>
		/// <returns>An <see cref="Icon"/> instance.</returns>
		protected static Icon GetClonedIcon(IntPtr hIcon)
		{
			if (hIcon == IntPtr.Zero) return null;
			var icon = (Icon)Icon.FromHandle(hIcon).Clone();
			DestroyIcon(hIcon);
			return icon;
		}

		private static IEnumIDList GetIEnumIDList(IShellFolder folder, SHCONTF flags)
		{
			try
			{
				return folder.EnumObjects(IntPtr.Zero, flags);
			}
			catch { }
			return null;
		}

		private string GetDisplayName(SIGDN dn)
		{
			try { return iShellItem?.GetDisplayName(dn); } catch { }
			return null;
		}

		private void Init(PIDL idList)
		{
			if (IsMinVista)
			{
				object obj;
				SHCreateItemFromIDList(idList, typeof(IShellItem).GUID, out obj);
				Init((IShellItem)obj);
			}
			else
			{
				Init(new ShellItemImpl(idList, false));
			}
		}

		private void Init(KNOWNFOLDERID knownFolder)
		{
			if (IsMin7)
			{
				object ppv;
				SHGetKnownFolderItem(knownFolder.Guid(), KNOWN_FOLDER_FLAG.KF_FLAG_DEFAULT, SafeTokenHandle.Null, typeof(IShellItem).GUID, out ppv);
				Init((IShellItem)ppv);
			}
			else
			{
				var csidl = knownFolder.SpecialFolder();
				if (csidl == null) throw new ArgumentOutOfRangeException(nameof(knownFolder), @"Cannot translate this known folder to a value understood by systems prior to Windows 7.");
				var path = new StringBuilder(MAX_PATH);
				SHGetFolderPath(IntPtr.Zero, (int)csidl.Value, SafeTokenHandle.Null, SHGFP.SHGFP_TYPE_CURRENT, path);
				Init(new Uri(path.ToString()));
			}
		}

		private void Init(IShellItem si)
		{
			iShellItem = si;
			iShellItem2 = (IShellItem2)si;
		}

		private void Init(Uri uri)
		{
			if (uri.Scheme == "file")
			{
				Init(ShellUtil.GetShellItemForPath(uri.LocalPath));
			}
			else if (uri.Scheme == "shell")
			{
				var path = uri.GetComponents(UriComponents.Path, UriFormat.Unescaped);
				var knownFolder = path;
				var restOfPath = string.Empty;
				var separatorIndex = path.IndexOf('/');
				if (separatorIndex != -1)
				{
					knownFolder = path.Substring(0, separatorIndex);
					restOfPath = path.Substring(separatorIndex + 1);
				}
				if (restOfPath != string.Empty)
					Init(this[restOfPath.Replace('/', '\\')].iShellItem);
				else
					Init(ShellUtil.GetKnownFolderFromPath(knownFolder));
			}
			else
			{
				throw new InvalidOperationException("Invalid scheme.");
			}
		}

		private void ThrowIfNoShellItem2()
		{
			if (iShellItem2 == null)
				throw new InvalidOperationException("Unable to get access to this detail.");
		}

		private class ShellItemImpl : IDisposable, IShellItem
		{
			public ShellItemImpl(PIDL pidl, bool owner)
			{
				PIDL = owner ? pidl : new PIDL(pidl);
			}

			public PIDL PIDL { get; private set; }

			[return: MarshalAs(UnmanagedType.Interface)]
			public object BindToHandler(IBindCtx pbc, [In, MarshalAs(UnmanagedType.LPStruct)] Guid bhid, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid)
			{
				if (riid == typeof(IShellFolder).GUID)
					return Marshal.GetIUnknownForObject(GetIShellFolder());
				throw new InvalidCastException();
			}

			public int Compare(IShellItem psi, SICHINTF hint)
			{
				var other = (ShellItemImpl)psi;
				var p1 = InternalGetParent();
				var p2 = other.InternalGetParent();
				if (p1.PIDL.Equals(p2.PIDL))
					return p1.GetIShellFolder().CompareIDs((IntPtr)(int)hint, PIDL.LastId, other.PIDL.LastId).Code;
				return 1;
			}

			public void Dispose()
			{
				PIDL = null;
			}

			public SFGAO GetAttributes(SFGAO sfgaoMask)
			{
				var parentFolder = InternalGetParent().GetIShellFolder();
				var result = sfgaoMask;
				parentFolder.GetAttributesOf(1, new[] { (IntPtr)PIDL.LastId }, ref result);
				return result & sfgaoMask;
			}

			public string GetDisplayName(SIGDN sigdnName)
			{
				if (sigdnName == SIGDN.SIGDN_FILESYSPATH)
				{
					var result = new StringBuilder(512);
					if (!SHGetPathFromIDList(PIDL, result))
						throw new ArgumentException();
					return result.ToString();
				}

				var parentFolder = InternalGetParent().GetIShellFolder();
				var child = PIDL.LastId;
				return parentFolder.GetDisplayNameOf(child, (SHGDNF)((int)sigdnName & 0xffff));
			}

			public IShellItem GetParent()
			{
				var pidlCopy = new PIDL(PIDL);
				if (!pidlCopy.RemoveLastId())
					Marshal.ThrowExceptionForHR((int)new HRESULT(HRESULT.MK_E_NOOBJECT));
				return new ShellItemImpl(pidlCopy, true);
			}

			internal IShellFolder GetIShellFolder()
			{
				PIDL dtPidl;
				SHGetFolderLocation(IntPtr.Zero, 0, SafeTokenHandle.Null, 0, out dtPidl);
				if (Desktop.PIDL.Equals(dtPidl))
					return Desktop.GetIShellFolder();
				return (IShellFolder)Desktop.GetIShellFolder().BindToObject(PIDL, null, typeof(IShellFolder).GUID);
			}

			internal ShellItemImpl InternalGetParent()
			{
				var pidlCopy = new PIDL(PIDL);
				return pidlCopy.RemoveLastId() ? new ShellItemImpl(pidlCopy, true) : this;
			}
		}
	}
}