using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Vanara.PInvoke;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.Shell32;
using Vanara.InteropServices;
using static Vanara.PInvoke.PropSys;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using Vanara.Extensions;
using System.ComponentModel;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable MemberCanBeProtected.Global
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
		PKEYMask = 0x81044000
	}

	/// <summary>Used to determine how to compare two Shell items. ShellItem.Compare uses this enumerated type.</summary>
	[Flags]
	public enum ShellItemComparison : uint
	{
		/// <summary>Exact comparison of two instances of a Shell item.</summary>
		AllFields = 0x80000000,

		/// <summary>Indicates that the comparison is based on a canonical name.</summary>
		Canonical = 0x10000000,

		/// <summary>Indicates that the comparison is based on the display in a folder view.</summary>
		Display = 0,

		/// <summary>Windows 7 and later. If the Shell items are not the same, test the file system paths.</summary>
		SecondaryFileSystemPath = 0x20000000
	}

	/// <summary>Requests the form of an item's display name to retrieve through <see cref="ShellItem.GetDisplayName(ShellItemDisplayString)"/>.</summary>
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
		ParentRelativeForUI = 0x80094001
	}

	/// <summary>Options for retrieving images from a <see cref="ShellItem"/>.</summary>
	[Flags]
	public enum ShellItemGetImageOptions
	{
		/// <summary>Shrink the bitmap as necessary to fit, preserving its aspect ratio.</summary>
		ResizeToFit = 0x00000000,
		/// <summary>
		/// Passed by callers if they want to stretch the returned image themselves. For example, if the caller passes an icon size of 80x80, a 96x96
		/// thumbnail could be returned. This action can be used as a performance optimization if the caller expects that they will need to stretch the image.
		/// </summary>
		BiggerSizeOk = 0x00000001,
		/// <summary>
		/// Return the item only if it is already in memory. Do not access the disk even if the item is cached. Note that this only returns an already-cached
		/// icon and can fall back to a per-class icon if an item has a per-instance icon that has not been cached. Retrieving a thumbnail, even if it is
		/// cached, always requires the disk to be accessed, so GetImage should not be called from the UI thread without passing MemoryOnly.
		/// </summary>
		MemoryOnly = 0x00000002,
		/// <summary>Return only the icon, never the thumbnail.</summary>
		IconOnly = 0x00000004,
		/// <summary>
		/// Return only the thumbnail, never the icon. Note that not all items have thumbnails, so ThumbnailOnly will cause the method to fail in these cases.
		/// </summary>
		ThumbnailOnly = 0x00000008,
		/// <summary>
		/// Allows access to the disk, but only to retrieve a cached item. This returns a cached thumbnail if it is available. If no cached thumbnail is
		/// available, it returns a cached per-instance icon but does not extract a thumbnail or icon.
		/// </summary>
		InCacheOnly = 0x00000010,
		/// <summary>Introduced in Windows 8. If necessary, crop the bitmap to a square.</summary>
		CropToSquare = 0x00000020,
		/// <summary>Introduced in Windows 8. Stretch and crop the bitmap to a 0.7 aspect ratio.</summary>
		WideThumbnails = 0x00000040,
		/// <summary>Introduced in Windows 8. If returning an icon, paint a background using the associated app's registered background color.</summary>
		IconBackground = 0x00000080,
		/// <summary>Introduced in Windows 8. If necessary, stretch the bitmap so that the height and width fit the given size.</summary>
		ScaleUp = 0x00000100,
	}

	/// <summary>Flags that direct the handling of the item from which you're retrieving the info tip text.</summary>
	[Flags]
	public enum ShellItemToolTipOptions
	{
		/// <summary>No special handling.</summary>
		Default = 0x00000000,

		/// <summary>Provide the name of the item in ppwszTip rather than the info tip text.</summary>
		Name = 0x00000001,

		/// <summary>If the item is a shortcut, retrieve the info tip text of the shortcut rather than its target.</summary>
		LinkNotTarget = 0x00000002,

		/// <summary>If the item is a shortcut, retrieve the info tip text of the shortcut's target.</summary>
		LinkTarget = 0x00000004,

		/// <summary>Search the entire namespace for the information. This value can result in a delayed response time.</summary>
		AllowDelay = 0x00000008,

		/// <summary><c>Windows Vista and later.</c> Put the info tip on a single line.</summary>
		SingleLine = 0x00000010,
	}

	// TODO: object GetPropertyStoreForKeys(IntPtr rgKeys, uint cKeys, GPS flags, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);
	// TODO: object GetPropertyStoreWithCreateObject(GPS flags, object punkCreateObject, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);
	/// <summary>Encapsulates an item in the Windows Shell.</summary>
	/// <seealso cref="System.IComparable{ShellItem}"/>
	/// <seealso cref="System.IDisposable"/>
	/// <seealso cref="System.IEquatable{IShellItem}"/>
	/// <seealso cref="System.IEquatable{ShellItem}"/>
	public class ShellItem : IComparable<ShellItem>, IDisposable, IEquatable<IShellItem>, IEquatable<ShellItem>, INotifyPropertyChanged
	{
		internal static readonly bool IsMin7 = Environment.OSVersion.Version >= new Version(6, 1);
		internal static readonly bool IsMinVista = Environment.OSVersion.Version.Major >= 6;
		internal static IBindCtx iBindCtx;
		internal IShellItem iShellItem;
		internal IShellItem2 iShellItem2;
		private static Dictionary<Type, BHID> bhidLookup;
		private IQueryInfo qi;
		private ShellItemPropertyStore props;
		private PropertyDescriptionList propDescList;

		/// <summary>Initializes a new instance of the <see cref="ShellItem"/> class.</summary>
		/// <param name="path">The file system path of the item.</param>
		public ShellItem(string path)
		{
			Init(ShellUtil.GetShellItemForPath(path));
		}

		/// <summary>Initializes a new instance of the <see cref="ShellItem"/> class.</summary>
		/// <param name="idList">The ID list.</param>
		public ShellItem(PIDL idList)
		{
			if (idList == null || idList.IsInvalid) throw new ArgumentNullException(nameof(idList));
			if (IsMinVista)
			{
				SHCreateItemFromIDList(idList, typeof(IShellItem).GUID, out var obj).ThrowIfFailed();
				Init((IShellItem)obj);
			}
			else
			{
				Init(new ShellItemImpl(idList, false));
			}
		}

		/// <summary>Initializes a new instance of the <see cref="ShellItem"/> class.</summary>
		/// <param name="si">An existing IShellItem instance.</param>
		protected ShellItem(IShellItem si) { Init(si); }

		/// <summary>Initializes a new instance of the <see cref="ShellItem"/> class.</summary>
		/// <param name="knownFolder">A known folder reference.</param>
		protected ShellItem(KNOWNFOLDERID knownFolder)
		{
			if (IsMin7)
			{
				SHGetKnownFolderItem(knownFolder.Guid(), KNOWN_FOLDER_FLAG.KF_FLAG_DEFAULT, SafeTokenHandle.Null, typeof(IShellItem).GUID, out var ppv).ThrowIfFailed();
				Init((IShellItem)ppv);
			}
			else
			{
				var csidl = knownFolder.SpecialFolder();
				if (csidl == null) throw new ArgumentOutOfRangeException(nameof(knownFolder), @"Cannot translate this known folder to a value understood by systems prior to Windows 7.");
				var path = new StringBuilder(MAX_PATH);
				SHGetFolderPath(IntPtr.Zero, (int)csidl.Value, SafeTokenHandle.Null, SHGFP.SHGFP_TYPE_CURRENT, path).ThrowIfFailed();
				Init(ShellUtil.GetShellItemForPath(path.ToString()));
			}
		}

		/// <summary>Initializes a new instance of the <see cref="ShellItem"/> class.</summary>
		protected ShellItem() { }

		/// <summary>Occurs when a property value changes.</summary>
		public event PropertyChangedEventHandler PropertyChanged
		{
			add { ((INotifyPropertyChanged)Properties).PropertyChanged += value; }
			remove { ((INotifyPropertyChanged)Properties).PropertyChanged -= value; }
		}

		/// <summary>Gets the attributes for the Shell item.</summary>
		/// <value>The attributes of the Shell item.</value>
		public ShellItemAttribute Attributes => (ShellItemAttribute)iShellItem.GetAttributes((SFGAO)0xFFFFFFFF);

		/// <summary>Gets the <see cref="ShellFileInfo"/> corresponding to this instance.</summary>
		public ShellFileInfo FileInfo => IsFileSystem ? new ShellFileInfo(PIDL) : throw new InvalidOperationException("Not file system objects do not have associated ShellFileInfo objects");

		/// <summary>Gets the file system path if this item is part of the file system.</summary>
		/// <value>The file system path.</value>
		public string FileSystemPath => GetDisplayName(SIGDN.SIGDN_FILESYSPATH);

		/// <summary>Gets a value indicating whether this instance is part of the file system.</summary>
		/// <value><c>true</c> if this instance is part of the file system; otherwise, <c>false</c>.</value>
		public bool IsFileSystem => iShellItem.GetAttributes(SFGAO.SFGAO_FILESYSTEM) != 0;

		/// <summary>Gets a value indicating whether this instance is folder.</summary>
		/// <value><c>true</c> if this instance is folder; otherwise, <c>false</c>.</value>
		public bool IsFolder => iShellItem.GetAttributes(SFGAO.SFGAO_FOLDER) != 0;

		/// <summary>Gets the IShellItem instance of the current ShellItem.</summary>
		/// <param name="i">A ShellItem instance.</param>
		public IShellItem IShellItem => iShellItem;

		/// <summary>Gets a value indicating whether this instance is link.</summary>
		/// <value><c>true</c> if this instance is link; otherwise, <c>false</c>.</value>
		public bool IsLink => iShellItem.GetAttributes(SFGAO.SFGAO_LINK) != 0;

		/// <summary>Gets the name relative to the parent for the item.</summary>
		public virtual string Name
		{
			get => GetDisplayName(SIGDN.SIGDN_NORMALDISPLAY);
			protected set { }
		}

		/// <summary>Gets the parent for the current item.</summary>
		/// <value>The parent item. If this is the desktop, this property will return <c>null</c>.</value>
		public ShellFolder Parent
		{
			get
			{
				try { return new ShellFolder(iShellItem.GetParent()); } catch { }
				return null;
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
				SHGetIDListFromObject(iShellItem, out var pidl).ThrowIfFailed();
				return pidl;
			}
		}

		/// <summary>Gets the property store for the item.</summary>
		/// <value>The dictionary of properties.</value>
		public ShellItemPropertyStore Properties => props ?? (props = new ShellItemPropertyStore(this));

		/// <summary>Gets a property description list object containing descriptions of all properties.</summary>
		/// <returns>A complete <see cref="PropertyDescriptionList"/> instance.</returns>
		public PropertyDescriptionList PropertyDescriptions => propDescList ?? (propDescList = GetPropertyDescriptionList(PROPERTYKEY.System.PropList.FullDetails));

		/// <summary>Gets the normal tool tip text associated with this item.</summary>
		/// <value>The tool tip text.</value>
		public string ToolTipText => GetToolTip();

		/// <summary>Gets the system bind context.</summary>
		/// <value>The bind context.</value>
		protected static IBindCtx BindContext
		{
			get
			{
				if (iBindCtx == null)
					CreateBindCtx(0, out iBindCtx);
				return iBindCtx;
			}
		}

		/// <summary>Implements the operator !=.</summary>
		/// <param name="left">The left operand.</param>
		/// <param name="right">The right operand.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(ShellItem left, ShellItem right) => !(left == right);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="left">The left operand.</param>
		/// <param name="right">The right operand.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(ShellItem left, ShellItem right) => Equals(left?.iShellItem, right?.iShellItem);

		/// <summary>
		/// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes,
		/// follows, or occurs in the same position in the sort order as the other object.
		/// </summary>
		/// <param name="other">An object to compare with this instance.</param>
		/// <param name="hint">Optional hint value that determines how to perform the comparison. The default compares all fields.</param>
		/// <returns>
		/// A value that indicates the relative order of the objects being compared. If the two items are the same this parameter equals zero; if they are
		/// different the parameter is nonzero.
		/// </returns>
		public int CompareTo(ShellItem other, ShellItemComparison hint = ShellItemComparison.SecondaryFileSystemPath) => iShellItem.Compare(other?.iShellItem, (SICHINTF)hint);

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		public virtual void Dispose()
		{
			if (props != null) { props?.Dispose(); props = null; }
			if (propDescList != null) { propDescList?.Dispose(); propDescList = null; }
			if (qi != null) { Marshal.ReleaseComObject(qi); qi = null; }
			if (iShellItem2 != null) { Marshal.ReleaseComObject(iShellItem2); iShellItem2 = null; }
			if (iShellItem != null) { Marshal.ReleaseComObject(iShellItem); iShellItem = null; }
		}

		/// <summary>Determines whether the specified <see cref="System.Object"/>, is equal to this instance.</summary>
		/// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj) => Equals(iShellItem, obj as IShellItem);

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public bool Equals(IShellItem other) => Equals(iShellItem, other);

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public bool Equals(ShellItem other) => Equals(iShellItem, other?.iShellItem);

		/// <summary>Gets a formatted display name for this item.</summary>
		/// <param name="option">The formatting options.</param>
		/// <returns>A string with the formatted display name if successful; otherwise <c>null</c>.</returns>
		public string GetDisplayName(ShellItemDisplayString option) => GetDisplayName((SIGDN)option);

		/// <summary>Gets a handler interface.</summary>
		/// <typeparam name="TInterface">The interface of the handler to return.</typeparam>
		/// <param name="handler">The bind handler to retrieve.</param>
		/// <returns>The requested interface.</returns>
		public TInterface GetHandler<TInterface>(BHID handler = 0) where TInterface : class
		{
			if (handler == 0)
				handler = GetBHIDForInterface<TInterface>();
			if (handler == 0)
				throw new ArgumentOutOfRangeException(nameof(handler));
			return iShellItem.BindToHandler(BindContext, handler.Guid(), typeof(TInterface).GUID) as TInterface;
		}

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => GetDisplayName(SIGDN.SIGDN_DESKTOPABSOLUTEPARSING).GetHashCode();

		/// <summary>
		/// Gets an image that represents this item. The default behavior is to load a thumbnail. If there is no thumbnail for the current item, it retrieves the
		/// icon of the item. The thumbnail or icon is extracted if it is not currently cached.
		/// </summary>
		/// <param name="size">A structure that specifies the size of the image to be received.</param>
		/// <param name="flags">One or more of the option flags.</param>
		/// <returns>The resulting image.</returns>
		/// <exception cref="PlatformNotSupportedException"></exception>
		public Image GetImage(Size size, ShellItemGetImageOptions flags)
		{
			if (!IsMinVista) throw new PlatformNotSupportedException();
			var fctry = iShellItem as IShellItemImageFactory;
			if (fctry != null)
			{
				var hres = fctry.GetImage(size, (SIIGBF)flags, out var hbitmap);
				if (hres == 0x8004B200 && flags.IsFlagSet(ShellItemGetImageOptions.ThumbnailOnly))
					throw new InvalidOperationException("Thumbnails are not supported by this item.");
				hres.ThrowIfFailed();
				//Marshal.ReleaseComObject(fctry);
				return GetTransparentBitmap((IntPtr)hbitmap);
			}
			if (!flags.IsFlagSet(ShellItemGetImageOptions.IconOnly))
				return GetThumbnail(size.Width);
			throw new InvalidOperationException("Unable to retrieve an image for this item.");
		}

		/// <summary>Gets a property description list object given a reference to a property key.</summary>
		/// <param name="keyType">A reference to a PROPERTYKEY structure. The values in <see cref="PROPERTYKEY.System.PropList"/> are all valid. <see cref="PROPERTYKEY.System.PropList.FullDetails"/> will return all properties.</param>
		/// <returns>A <see cref="PropertyDescriptionList"/> instance for the supplied key.</returns>
		public PropertyDescriptionList GetPropertyDescriptionList(PROPERTYKEY keyType)
		{
			ThrowIfNoShellItem2();
			return new PropertyDescriptionList(iShellItem2.GetPropertyDescriptionList(ref keyType, typeof(IPropertyDescriptionList).GUID));
		}

		/// <summary>Gets the formatted tool tip text associated with this item.</summary>
		/// <param name="options">The option flags.</param>
		/// <returns>The tool tip text formatted as per <paramref name="options"/>.</returns>
		public string GetToolTip(ShellItemToolTipOptions options = ShellItemToolTipOptions.Default)
		{
			if (qi == null)
				try
				{
					qi = (Parent ?? ShellFolder.Desktop).GetChildrenUIObjects<IQueryInfo>(null, this);
				}
				catch { }
			if (qi == null) return "";
			qi.GetInfoTip((QITIP)options, out var ret);
			return ret ?? "";
		}

		/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
		/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
		public override string ToString() => Name;

		/// <summary>Ensures that all cached information for this item is updated.</summary>
		public void Update()
		{
			props?.Commit();
			ThrowIfNoShellItem2();
			iShellItem2.Update(BindContext);
		}

		/// <summary>Open a new Windows Explorer window with this item selected.</summary>
		public void ViewInExplorer()
		{
			SHOpenFolderAndSelectItems(Parent.PIDL, 1, new IntPtr[] { PIDL }, OFASI.OFASI_NONE);
		}

		/// <summary>
		/// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
		/// </summary>
		/// <param name="other">An object to compare with this instance.</param>
		/// <returns>A value that indicates the relative order of the objects being compared. If the two items are the same this parameter equals zero; if they are different the parameter is nonzero.</returns>
		int IComparable<ShellItem>.CompareTo(ShellItem other) => CompareTo(other);

		/// <summary>Gets the BHID for the supplied <typeparamref name="TInterface"/>.</summary>
		/// <typeparam name="TInterface">The type of the interface to lookup.</typeparam>
		/// <returns>The related BHID if found, 0 if not.</returns>
		internal static BHID GetBHIDForInterface<TInterface>()
		{
			if (bhidLookup == null)
				bhidLookup = new Dictionary<Type, BHID>
				{
					//{ typeof(??), BHID.BHID_SFObject },
					{ typeof(IShellLinkW), BHID.BHID_SFUIObject },
					//{ typeof(Others??), BHID.BHID_SFUIObject },
					//{ typeof(??), BHID.BHID_SFViewObject },
					{ typeof(IStorage), BHID.BHID_Storage },
					{ typeof(IStream), BHID.BHID_Stream },
					//{ typeof(IShellItem??), BHID.BHID_LinkTargetItem },
					//{ typeof(IEnumShellItems), BHID.BHID_StorageEnum }, // Can't have multiple keys
					// TODO: { typeof(ITransferSource), BHID.BHID_Transfer },
					// TODO: { typeof(ITransferDestination), BHID.BHID_Transfer },
					{ typeof(IPropertyStore), BHID.BHID_PropertyStore },
					// TODO: { typeof(IPropertyStoreFactory), BHID.BHID_PropertyStore },
					{ typeof(IExtractImage), BHID.BHID_ThumbnailHandler },
					{ typeof(IThumbnailProvider), BHID.BHID_ThumbnailHandler },
					{ typeof(IEnumShellItems), BHID.BHID_EnumItems },
					{ typeof(IDataObject), BHID.BHID_DataObject },
					// TODO: { typeof(IQueryAssociations), BHID.BHID_AssociationArray },
					// TODO: { typeof(IFilter), BHID.BHID_Filter },
					// TODO: { typeof(IEnumAssocHandlers), BHID.BHID_EnumAssocHandlers },
					// TODO: { typeof(IRandomAccessStream), BHID.BHID_RandomAccessStream },
					//{ typeof(??), BHID.BHID_FilePlaceholder },
				};
			return bhidLookup.TryGetValue(typeof(TInterface), out var value) ? value : 0;
		}

		/// <summary>Creates the most specialized derivative of ShellItem from an IShellItem object.</summary>
		/// <param name="iItem">The IShellItem object.</param>
		/// <returns>A ShellItem derivative for the supplied IShellItem.</returns>
		internal static ShellItem Open(IShellItem iItem)
		{
			if (iItem.GetAttributes(SFGAO.SFGAO_LINK) != 0)
				return new ShellLink(iItem);

			// If not a folder, get the ShellItem
			if (iItem.GetAttributes(SFGAO.SFGAO_FOLDER) == 0)
				return new ShellItem(iItem);

			// Try to get specialized folder type from property
			var pk = PROPERTYKEY.System.ItemType;
			string itemType = null;
			try { itemType = (iItem as IShellItem2)?.GetString(ref pk)?.ToString().ToLowerInvariant(); } catch { }
			switch (itemType)
			{
				case ".library-ms":
					return new ShellLibrary(iItem);
				case ".searchconnector-ms":
				// TODO: Return a search connector
				case ".search-ms":
				// TODO: Return a saved search connection
				default:
					return new ShellFolder(iItem);
			}
		}

		/// <summary>Throws an exception if no IShellItem2 instance can be retrieved.</summary>
		internal void ThrowIfNoShellItem2()
		{
			if (iShellItem2 == null)
				throw new InvalidOperationException("Unable to get access to this detail.");
		}

		/// <summary>Enumerates all the children of the current item. Not valid before Vista.</summary>
		/// <returns>An enumeration of the child objects.</returns>
		protected virtual IEnumerable<ShellItem> EnumerateChildren()
		{
			if (!IsMinVista) yield break;
			IEnumShellItems ie = null;
			try
			{
				ie = GetHandler<IEnumShellItems>(BHID.BHID_EnumItems);
			}
			catch (Exception e) { Debug.WriteLine($"Unable to enum children: {e.Message}"); }
			if (ie != null)
			{
				var a = new IShellItem[1];
				while (ie.Next(1, a, out var f).Succeeded && f == 1)
				{
					ShellItem i = null;
					try { i = Open(a[0]); } catch (Exception e) { Debug.WriteLine($"Unable to open child: {e.Message}"); }
					if (i != null) yield return i;
				}
				Marshal.ReleaseComObject(ie);
			}
		}

		/// <summary>Gets the display name.</summary>
		/// <param name="dn">The display name option.</param>
		/// <returns>The display name.</returns>
		protected virtual string GetDisplayName(SIGDN dn)
		{
			try { return iShellItem?.GetDisplayName(dn); } catch { }
			return null;
		}

		/// <summary>Initializes this instance with the specified IShellItem.</summary>
		/// <param name="si">The IShellItem object.</param>
		/// <exception cref="ArgumentNullException">si</exception>
		protected void Init(IShellItem si)
		{
			iShellItem = si ?? throw new ArgumentNullException(nameof(si));
			iShellItem2 = si as IShellItem2;
		}

		private static bool Equals(IShellItem left, IShellItem right)
		{
			if (ReferenceEquals(left, right)) return true;
			if (left is null || right is null) return false;
			return left.Compare(right, SICHINTF.SICHINT_TEST_FILESYSPATH_IF_NOT_EQUAL) == 0;
		}

		private static Bitmap GetTransparentBitmap(IntPtr hbitmap)
		{
			var dibsection = GetObject<DIBSECTION>(hbitmap);
			var bitmap = new Bitmap(dibsection.dsBm.bmWidth, dibsection.dsBm.bmHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			using (var mstr = new MarshalingStream(dibsection.dsBm.bmBits, (long)dibsection.dsBm.bmBits))
			{
				for (int x = 0; x < dibsection.dsBmih.biWidth; x++)
					for (int y = 0; y < dibsection.dsBmih.biHeight; y++)
					{
						var rgbquad = mstr.Read<RGBQUAD>();
						if (rgbquad.rgbReserved != 0)
							bitmap.SetPixel(x, y, rgbquad.Color);
					}
			}
			return bitmap;
		}

		/// <summary>Gets the thumbnail image for the item using the specified characteristics.</summary>
		/// <param name="width">The width, in pixels, of the Bitmap.</param>
		/// <returns>The resulting Bitmap, on success, or <c>null</c> on failure.</returns>
		private Image GetThumbnail(int width = 32)
		{
			IThumbnailProvider provider = null;
			try
			{
				provider = GetHandler<IThumbnailProvider>(BHID.BHID_ThumbnailHandler);
				if (provider == null) return null;
				provider.GetThumbnail((uint)width, out var hbmp, out var alpha);
				return Image.FromHbitmap(hbmp);
			}
			catch
			{
				return null;
			}
			finally
			{
				if (provider != null) Marshal.ReleaseComObject(provider);
			}
		}

		protected class ShellItemImpl : IDisposable, IShellItem
		{
			public ShellItemImpl(PIDL pidl, bool owner)
			{
				PIDL = owner ? pidl : new PIDL(pidl);
			}

			private PIDL PIDL { get; set; }

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

			public SafeCoTaskMemString GetDisplayName(SIGDN sigdnName)
			{
				if (sigdnName == SIGDN.SIGDN_FILESYSPATH)
				{
					var result = new StringBuilder(512);
					if (!SHGetPathFromIDList(PIDL, result))
						throw new ArgumentException();
					return new SafeCoTaskMemString(result.ToString(), CharSet.Unicode, false);
				}

				var parentFolder = InternalGetParent().GetIShellFolder();
				var child = PIDL.LastId;
				return new SafeCoTaskMemString(parentFolder.GetDisplayNameOf(child, (SHGDNF)((int)sigdnName & 0xffff)), CharSet.Unicode, false);
			}

			public IShellItem GetParent()
			{
				var pidlCopy = new PIDL(PIDL);
				if (!pidlCopy.RemoveLastId())
					Marshal.ThrowExceptionForHR((int)new HRESULT(HRESULT.MK_E_NOOBJECT));
				return new ShellItemImpl(pidlCopy, true);
			}

			private IShellFolder GetIShellFolder()
			{
				SHGetFolderLocation(IntPtr.Zero, 0, SafeTokenHandle.Null, 0, out var dtPidl);
				if (ShellFolder.Desktop.PIDL.Equals(dtPidl))
					return ShellFolder.Desktop.iShellFolder;
				return (IShellFolder)ShellFolder.Desktop.iShellFolder.BindToObject(PIDL, null, typeof(IShellFolder).GUID);
			}

			private ShellItemImpl InternalGetParent()
			{
				var pidlCopy = new PIDL(PIDL);
				return pidlCopy.RemoveLastId() ? new ShellItemImpl(pidlCopy, true) : this;
			}
		}
	}
}