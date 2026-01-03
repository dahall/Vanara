using System.Runtime.InteropServices.ComTypes;
using System.Security;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.PropSys;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>Attributes that can be retrieved on an item (file or folder) or set of items.</summary>
	[PInvokeData("Shobjidl.h", MSDNShortId = "bb762589")]
	[Flags]
	public enum SFGAO : uint
	{
		/// <summary>The specified items can be hosted inside a web browser or Windows Explorer frame.</summary>
		SFGAO_BROWSABLE = 0x8000000,

		/// <summary>The specified items can be copied.</summary>
		SFGAO_CANCOPY = 1,

		/// <summary>The specified items can be deleted.</summary>
		SFGAO_CANDELETE = 0x20,

		/// <summary>
		/// Shortcuts can be created for the specified items. This attribute has the same value as DROPEFFECT_LINK.
		/// <para>
		/// If a namespace extension returns this attribute, a Create Shortcut entry with a default handler is added to the shortcut menu
		/// that is displayed during drag-and-drop operations. The extension can also implement its own handler for the link verb in
		/// place of the default. If the extension does so, it is responsible for creating the shortcut.
		/// </para>
		/// <para>A Create Shortcut item is also added to the Windows Explorer File menu and to normal shortcut menus.</para>
		/// <para>
		/// If the item is selected, your application's IContextMenu::InvokeCommand method is invoked with the lpVerb member of the
		/// CMINVOKECOMMANDINFO structure set to link. Your application is responsible for creating the link.
		/// </para>
		/// </summary>
		SFGAO_CANLINK = 4,

		/// <summary>Not supported.</summary>
		SFGAO_CANMONIKER = 0x400000,

		/// <summary>The specified items can be moved.</summary>
		SFGAO_CANMOVE = 2,

		/// <summary>
		/// The specified items can be renamed. Note that this value is essentially a suggestion; not all namespace clients allow items
		/// to be renamed. However, those that do must have this attribute set.
		/// </summary>
		SFGAO_CANRENAME = 0x10,

		/// <summary>
		/// This flag is a mask for the capability attributes: SFGAO_CANCOPY, SFGAO_CANMOVE, SFGAO_CANLINK, SFGAO_CANRENAME,
		/// SFGAO_CANDELETE, SFGAO_HASPROPSHEET, and SFGAO_DROPTARGET. Callers normally do not use this value.
		/// </summary>
		SFGAO_CAPABILITYMASK = 0x177,

		/// <summary>The specified items are compressed.</summary>
		SFGAO_COMPRESSED = 0x4000000,

		/// <summary>
		/// This flag is a mask for content attributes, at present only SFGAO_HASSUBFOLDER. Callers normally do not use this value.
		/// </summary>
		SFGAO_CONTENTSMASK = 0x80000000,

		/// <summary>Do not use.</summary>
		SFGAO_DISPLAYATTRMASK = 0xfc000,

		/// <summary>The specified items are drop targets.</summary>
		SFGAO_DROPTARGET = 0x100,

		/// <summary>The specified items are encrypted and might require special presentation.</summary>
		SFGAO_ENCRYPTED = 0x2000,

		/// <summary>
		/// The specified folders are either file system folders or contain at least one descendant (child, grandchild, or later) that is
		/// a file system (SFGAO_FILESYSTEM) folder.
		/// </summary>
		SFGAO_FILESYSANCESTOR = 0x10000000,

		/// <summary>
		/// The specified folders or files are part of the file system (that is, they are files, directories, or root directories). The
		/// parsed names of the items can be assumed to be valid Win32 file system paths. These paths can be either UNC or drive-letter based.
		/// </summary>
		SFGAO_FILESYSTEM = 0x40000000,

		/// <summary>
		/// The specified items are folders. Some items can be flagged with both SFGAO_STREAM and SFGAO_FOLDER, such as a compressed file
		/// with a .zip file name extension. Some applications might include this flag when testing for items that are both files and containers.
		/// </summary>
		SFGAO_FOLDER = 0x20000000,

		/// <summary>The specified items are shown as dimmed and unavailable to the user.</summary>
		SFGAO_GHOSTED = 0x8000,

		/// <summary>The specified items have property sheets.</summary>
		SFGAO_HASPROPSHEET = 0x40,

		/// <summary>Not supported.</summary>
		SFGAO_HASSTORAGE = 0x400000,

		/// <summary>
		/// The specified folders have subfolders. The SFGAO_HASSUBFOLDER attribute is only advisory and might be returned by Shell
		/// folder implementations even if they do not contain subfolders. Note, however, that the converse—failing to return
		/// SFGAO_HASSUBFOLDER—definitively states that the folder objects do not have subfolders.
		/// <para>
		/// Returning SFGAO_HASSUBFOLDER is recommended whenever a significant amount of time is required to determine whether any
		/// subfolders exist. For example, the Shell always returns SFGAO_HASSUBFOLDER when a folder is located on a network drive.
		/// </para>
		/// </summary>
		SFGAO_HASSUBFOLDER = 0x80000000,

		/// <summary>
		/// The item is hidden and should not be displayed unless the Show hidden files and folders option is enabled in Folder Settings.
		/// </summary>
		SFGAO_HIDDEN = 0x80000,

		/// <summary>
		/// Accessing the item (through IStream or other storage interfaces) is expected to be a slow operation. Applications should
		/// avoid accessing items flagged with SFGAO_ISSLOW. <note>Opening a stream for an item is generally a slow operation at all
		/// times. SFGAO_ISSLOW indicates that it is expected to be especially slow, for example in the case of slow network connections
		/// or offline (FILE_ATTRIBUTE_OFFLINE) files. However, querying SFGAO_ISSLOW is itself a slow operation. Applications should
		/// query SFGAO_ISSLOW only on a background thread. An alternate method, such as retrieving the PKEY_FileAttributes property and
		/// testing for FILE_ATTRIBUTE_OFFLINE, could be used in place of a method call that involves SFGAO_ISSLOW.</note>
		/// </summary>
		SFGAO_ISSLOW = 0x4000,

		/// <summary>The specified items are shortcuts.</summary>
		SFGAO_LINK = 0x10000,

		/// <summary>The items contain new content, as defined by the particular application.</summary>
		SFGAO_NEWCONTENT = 0x200000,

		/// <summary>
		/// The items are nonenumerated items and should be hidden. They are not returned through an enumerator such as that created by
		/// the IShellFolder::EnumObjects method.
		/// </summary>
		SFGAO_NONENUMERATED = 0x100000,

		/// <summary>
		/// Mask used by the PKEY_SFGAOFlags property to determine attributes that are considered to cause slow calculations or lack
		/// context: SFGAO_ISSLOW, SFGAO_READONLY, SFGAO_HASSUBFOLDER, and SFGAO_VALIDATE. Callers normally do not use this value.
		/// </summary>
		SFGAO_PKEYSFGAOMASK = 0x81044000,

		/// <summary>
		/// The specified items are read-only. In the case of folders, this means that new items cannot be created in those folders. This
		/// should not be confused with the behavior specified by the FILE_ATTRIBUTE_READONLY flag retrieved by
		/// IColumnProvider::GetItemData in a SHCOLUMNDATA structure. FILE_ATTRIBUTE_READONLY has no meaning for Win32 file system folders.
		/// </summary>
		SFGAO_READONLY = 0x40000,

		/// <summary>The specified items are on removable media or are themselves removable devices.</summary>
		SFGAO_REMOVABLE = 0x2000000,

		/// <summary>The specified objects are shared.</summary>
		SFGAO_SHARE = 0x20000,

		/// <summary>
		/// The specified items can be bound to an IStorage object through IShellFolder::BindToObject. For more information about
		/// namespace manipulation capabilities, see IStorage.
		/// </summary>
		SFGAO_STORAGE = 8,

		/// <summary>
		/// Children of this item are accessible through IStream or IStorage. Those children are flagged with SFGAO_STORAGE or SFGAO_STREAM.
		/// </summary>
		SFGAO_STORAGEANCESTOR = 0x800000,

		/// <summary>
		/// This flag is a mask for the storage capability attributes: SFGAO_STORAGE, SFGAO_LINK, SFGAO_READONLY, SFGAO_STREAM,
		/// SFGAO_STORAGEANCESTOR, SFGAO_FILESYSANCESTOR, SFGAO_FOLDER, and SFGAO_FILESYSTEM. Callers normally do not use this value.
		/// </summary>
		SFGAO_STORAGECAPMASK = 0x70c50008,

		/// <summary>
		/// Indicates that the item has a stream associated with it. That stream can be accessed through a call to
		/// IShellFolder::BindToObject or IShellItem::BindToHandler with IID_IStream in the riid parameter.
		/// </summary>
		SFGAO_STREAM = 0x400000,

		/// <summary>Windows 7 and later. The specified items are system items.</summary>
		SFGAO_SYSTEM = 0x00001000,

		/// <summary>
		/// When specified as input, SFGAO_VALIDATE instructs the folder to validate that the items contained in a folder or Shell item
		/// array exist. If one or more of those items do not exist, IShellFolder::GetAttributesOf and IShellItemArray::GetAttributes
		/// return a failure code. This flag is never returned as an [out] value.
		/// <para>
		/// When used with the file system folder, SFGAO_VALIDATE instructs the folder to discard cached properties retrieved by clients
		/// of IShellFolder2::GetDetailsEx that might have accumulated for the specified items.
		/// </para>
		/// </summary>
		SFGAO_VALIDATE = 0x1000000
	}

	/// <summary>
	/// If the array contains a single item, this method provides the same results as GetAttributes. However, if the array contains
	/// multiple items, the attribute sets of all the items are combined into a single attribute set and returned in the value pointed to
	/// by psfgaoAttribs. This parameter takes one of the following values to define how that final attribute set is determined:
	/// </summary>
	[PInvokeData("Shobjidl.h", MSDNShortId = "bb761096")]
	public enum SIATTRIBFLAGS
	{
		/// <summary>
		/// If there are multiple items in the array, use a bitwise AND to combine the attributes across items. For instance, if the
		/// array contains two items where one item can be moved (SFGAO_CANMOVE) and a second item cannot, the method returns (1 &amp; 0)
		/// or 0 for that attribute bit.
		/// </summary>
		SIATTRIBFLAGS_AND = 1,

		/// <summary>
		/// Retrieve the attributes directly from the Shell data source. To use this value, the Shell item array must have been
		/// initialized as an IShellFolder with its contents specified as an array of child PIDLs.
		/// </summary>
		SIATTRIBFLAGS_APPCOMPAT = 3,

		/// <summary>
		/// If there are multiple items in the array, use a bitwise OR to combine the attributes across items. For instance, if the array
		/// contains two items where one item can be moved (SFGAO_CANMOVE) and a second item cannot, the method returns (1 | 0) or 1 for
		/// that attribute bit.
		/// </summary>
		SIATTRIBFLAGS_OR = 2,

		/// <summary>
		/// Windows 7 and later. Examine all items in the array to compute the attributes. Note that this can result in poor performance
		/// over large arrays and therefore it should be used only when needed. Cases in which you pass this flag should be extremely
		/// rare. See Remarks for more details.
		/// </summary>
		SIATTRIBFLAGS_ALLITEMS = 0x00004000,
	}

	/// <summary>Used to determine how to compare two Shell items. IShellItem::Compare uses this enumerated type.</summary>
	[PInvokeData("Shobjidl.h", MSDNShortId = "bb762543")]
	[Flags]
	public enum SICHINTF : uint
	{
		/// <summary>Exact comparison of two instances of a Shell item.</summary>
		SICHINT_ALLFIELDS = 0x80000000,

		/// <summary>
		/// This relates to the iOrder parameter of the IShellItem::Compare interface and indicates that the comparison is based on a
		/// canonical name.
		/// </summary>
		SICHINT_CANONICAL = 0x10000000,

		/// <summary>
		/// This relates to the iOrder parameter of the IShellItem::Compare interface and indicates that the comparison is based on the
		/// display in a folder view.
		/// </summary>
		SICHINT_DISPLAY = 0,

		/// <summary>Windows 7 and later. If the Shell items are not the same, test the file system paths.</summary>
		SICHINT_TEST_FILESYSPATH_IF_NOT_EQUAL = 0x20000000
	}

	/// <summary>Requests the form of an item's display name to retrieve through IShellItem::GetDisplayName and SHGetNameFromIDList.</summary>
	/// <remarks>
	/// Different forms of an item's name can be retrieved through the item's properties, including those listed here. Note that not all
	/// properties are present on all items, so only those appropriate to the item will appear.
	/// </remarks>
	[PInvokeData("Shobjidl.h", MSDNShortId = "bb762502")]
	public enum SIGDN : uint
	{
		/// <summary>Returns the editing name relative to the desktop. In UI this name is suitable for display to the user.</summary>
		SIGDN_DESKTOPABSOLUTEEDITING = 0x8004c000,

		/// <summary>Returns the parsing name relative to the desktop. This name is not suitable for use in UI.</summary>
		SIGDN_DESKTOPABSOLUTEPARSING = 0x80028000,

		/// <summary>
		/// Returns the item's file system path, if it has one. Only items that report SFGAO_FILESYSTEM have a file system path. When an
		/// item does not have a file system path, a call to IShellItem::GetDisplayName on that item will fail. In UI this name is
		/// suitable for display to the user in some cases, but note that it might not be specified for all items.
		/// </summary>
		SIGDN_FILESYSPATH = 0x80058000,

		/// <summary>
		/// Returns the display name relative to the parent folder. In UI this name is generally ideal for display to the user.
		/// </summary>
		SIGDN_NORMALDISPLAY = 0,

		/// <summary>Returns the path relative to the parent folder.</summary>
		SIGDN_PARENTRELATIVE = 0x80080001,

		/// <summary>Returns the editing name relative to the parent folder. In UI this name is suitable for display to the user.</summary>
		SIGDN_PARENTRELATIVEEDITING = 0x80031001,

		/// <summary>
		/// Returns the path relative to the parent folder in a friendly format as displayed in an address bar. This name is suitable for
		/// display to the user.
		/// </summary>
		SIGDN_PARENTRELATIVEFORADDRESSBAR = 0x8007c001,

		/// <summary>Introduced in Windows 8.</summary>
		SIGDN_PARENTRELATIVEFORUI = 0x80094001,

		/// <summary>Returns the parsing name relative to the parent folder. This name is not suitable for use in UI.</summary>
		SIGDN_PARENTRELATIVEPARSING = 0x80018001,

		/// <summary>
		/// Returns the item's URL, if it has one. Some items do not have a URL, and in those cases a call to IShellItem::GetDisplayName
		/// will fail. This name is suitable for display to the user in some cases, but note that it might not be specified for all items.
		/// </summary>
		SIGDN_URL = 0x80068000
	}

	/// <summary>Flags for <see cref="IShellItemImageFactory.GetImage"/>.</summary>
	[Flags]
	public enum SIIGBF
	{
		/// <summary>Shrink the bitmap as necessary to fit, preserving its aspect ratio.</summary>
		SIIGBF_RESIZETOFIT = 0x00000000,

		/// <summary>
		/// Passed by callers if they want to stretch the returned image themselves. For example, if the caller passes an icon size of
		/// 80x80, a 96x96 thumbnail could be returned. This action can be used as a performance optimization if the caller expects that
		/// they will need to stretch the image. Note that the Shell implementation of IShellItemImageFactory performs a GDI stretch
		/// blit. If the caller wants a higher quality image stretch than provided through that mechanism, they should pass this flag and
		/// perform the stretch themselves.
		/// </summary>
		SIIGBF_BIGGERSIZEOK = 0x00000001,

		/// <summary>
		/// Return the item only if it is already in memory. Do not access the disk even if the item is cached. Note that this only
		/// returns an already-cached icon and can fall back to a per-class icon if an item has a per-instance icon that has not been
		/// cached. Retrieving a thumbnail, even if it is cached, always requires the disk to be accessed, so GetImage should not be
		/// called from the UI thread without passing SIIGBF_MEMORYONLY.
		/// </summary>
		SIIGBF_MEMORYONLY = 0x00000002,

		/// <summary>Return only the icon, never the thumbnail.</summary>
		SIIGBF_ICONONLY = 0x00000004,

		/// <summary>
		/// Return only the thumbnail, never the icon. Note that not all items have thumbnails, so SIIGBF_THUMBNAILONLY will cause the
		/// method to fail in these cases.
		/// </summary>
		SIIGBF_THUMBNAILONLY = 0x00000008,

		/// <summary>
		/// Allows access to the disk, but only to retrieve a cached item. This returns a cached thumbnail if it is available. If no
		/// cached thumbnail is available, it returns a cached per-instance icon but does not extract a thumbnail or icon.
		/// </summary>
		SIIGBF_INCACHEONLY = 0x00000010,

		/// <summary>Introduced in Windows 8. If necessary, crop the bitmap to a square.</summary>
		SIIGBF_CROPTOSQUARE = 0x00000020,

		/// <summary>Introduced in Windows 8. Stretch and crop the bitmap to a 0.7 aspect ratio.</summary>
		SIIGBF_WIDETHUMBNAILS = 0x00000040,

		/// <summary>
		/// Introduced in Windows 8. If returning an icon, paint a background using the associated app's registered background color.
		/// </summary>
		SIIGBF_ICONBACKGROUND = 0x00000080,

		/// <summary>Introduced in Windows 8. If necessary, stretch the bitmap so that the height and width fit the given size.</summary>
		SIIGBF_SCALEUP = 0x00000100,
	}

	/// <summary>
	/// Exposes enumeration of IShellItem interfaces. This interface is typically obtained by calling the IEnumShellItems method.
	/// </summary>
	[SuppressUnmanagedCodeSecurity]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("70629033-e363-4a28-a567-0db78006e6d7")]
	[PInvokeData("Shobjidl.h", MSDNShortId = "bb761962")]
	public interface IEnumShellItems : Vanara.Collections.ICOMEnum<IShellItem>
	{
		/// <summary>Gets an array of one or more IShellItem interfaces from the enumeration.</summary>
		/// <param name="celt">The number of elements in the array referenced by the rgelt parameter.</param>
		/// <param name="rgelt">
		/// The address of an array of pointers to IShellItem interfaces that receive the enumerated item or items. The calling
		/// application is responsible for freeing the IShellItem interfaces by calling the IUnknown::Release method.
		/// </param>
		/// <param name="pceltFetched">
		/// A pointer to a value that receives the number of IShellItem interfaces successfully retrieved. The count can be smaller than
		/// the value specified in the celt parameter. This parameter can be NULL on entry only if celt is one, because in that case the
		/// method can only retrieve one item and return S_OK, or zero items and return S_FALSE.
		/// </param>
		/// <returns>
		/// Returns S_OK if the method successfully retrieved the requested celt elements. This method only returns S_OK if the full
		/// count of requested items are successfully retrieved. S_FALSE indicates that more items were requested than remained in the
		/// enumeration. The value pointed to by the pceltFetched parameter specifies the actual number of items retrieved. Note that the
		/// value will be 0 if there are no more items to retrieve.
		/// </returns>
		[PreserveSig]
		HRESULT Next(uint celt, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] IShellItem[] rgelt, out uint pceltFetched);

		/// <summary>Skips the specified number of elements in the enumeration sequence.</summary>
		/// <param name="celt">The number of IShellItem interfaces to skip.</param>
		void Skip(uint celt);

		/// <summary>Returns to the beginning of the enumeration sequence.</summary>
		void Reset();

		/// <summary>Gets a copy of the current enumeration.</summary>
		/// <returns>The address of a pointer that receives a copy of this enumeration.</returns>
		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumShellItems Clone();
	}

	/// <summary>When the <c>STR_PARSE_AND_CREATE_ITEM</c> binding context is specified, this interface gets or sets the stored Shell items that SHCreateItemFromParsingName creates from a parsing name.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-iparseandcreateitem
	[ComImport, Guid("67efed0e-e827-4408-b493-78f3982b685c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IParseAndCreateItem
	{
		/// <summary>Sets a Shell item that SHCreateItemFromParsingName created from a parsing name.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>Pointer to an IShellItem object.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iparseandcreateitem-setitem
		// HRESULT SetItem( IShellItem *psi );
		void SetItem(IShellItem psi);

		/// <summary>Gets a stored Shell item that SHCreateItemFromParsingName created from a parsing name.</summary>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>A reference to the IID of the interface to retrieve through ppv, typically IID_IShellItem.</para>
		/// </param>
		/// <param name="ppv">
		/// <para>Type: <c>void**</c></para>
		/// <para>When this method returns successfully, contains the interface pointer requested in riid. This is typically IShellItem.</para>
		/// </param>
		/// <remarks>
		/// We recommend that you use the <c>IID_PPV_ARGS</c> macro, defined in Objbase.h, to package the riid and ppv parameters. This
		/// macro provides the correct IID based on the interface pointed to by the value in ppv, which eliminates the possibility of a
		/// coding error in riid that could lead to unexpected results.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iparseandcreateitem-getitem
		// HRESULT GetItem( REFIID riid, void **ppv );
		void GetItem(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppv);
	}

	/// <summary>
	/// Exposes methods that retrieve information about a Shell item. IShellItem and IShellItem2 are the preferred representations of
	/// items in any new code.
	/// </summary>
	[SuppressUnmanagedCodeSecurity]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("43826d1e-e718-42ee-bc55-a1e261c37bfe")]
	[PInvokeData("Shobjidl.h", MSDNShortId = "bb761144")]
	public interface IShellItem
	{
		/// <summary>Binds to a handler for an item as specified by the handler ID value (BHID).</summary>
		/// <param name="pbc">
		/// <para>Type: <b><c>IBindCtx</c>*</b></para>
		/// <para>
		/// A pointer to an <c>IBindCtx</c> interface on a bind context object. Used to pass optional parameters to the handler. The contents
		/// of the bind context are handler-specific. For example, when binding to <b>BHID_Stream</b>, the <c>STGM</c> flags in the bind
		/// context indicate the mode of access desired (read or read/write).
		/// </para>
		/// </param>
		/// <param name="bhid">
		/// <para>Type: <b>REFGUID</b></para>
		/// <para>Reference to a GUID that specifies which handler will be created. One of the following values defined in Shlguid.h:</para>
		/// <para>BHID_SFObject</para>
		/// <para>Restricts usage to <c>BindToObject</c>.</para>
		/// <para>BHID_SFUIObject</para>
		/// <para>Restricts usage to <c>GetUIObjectOf</c>.</para>
		/// <para>BHID_SFViewObject</para>
		/// <para>Restricts usage to <c>CreateViewObject</c>.</para>
		/// <para>BHID_Storage</para>
		/// <para>Attempts to retrieve the storage RIID, but defaults to Shell implementation on failure.</para>
		/// <para>BHID_Stream</para>
		/// <para>Restricts usage to <c>IStream</c>.</para>
		/// <para>BHID_LinkTargetItem</para>
		/// <para>
		/// CLSID_ShellItem is initialized with the target of this item (can only be SFGAO_LINK). See <c>SFGAO</c> for a description of SFGAO_LINK.
		/// </para>
		/// <para>BHID_StorageEnum</para>
		/// <para>If the item is a folder, gets an <c>IEnumShellItems</c> object with which to enumerate the storage contents.</para>
		/// <para>BHID_Transfer</para>
		/// <para>
		/// <b>Introduced in Windows Vista</b>: If the item is a folder, gets an <c>ITransferSource</c> or <c>ITransferDestination</c> object.
		/// </para>
		/// <para>BHID_PropertyStore</para>
		/// <para><b>Introduced in Windows Vista</b>: Restricts usage to <c>IPropertyStore</c> or <c>IPropertyStoreFactory</c>.</para>
		/// <para>BHID_ThumbnailHandler</para>
		/// <para><b>Introduced in Windows Vista</b>: Restricts usage to <c>IExtractImage</c> or <c>IThumbnailProvider</c>.</para>
		/// <para>BHID_EnumItems</para>
		/// <para>
		/// <b>Introduced in Windows Vista</b>: If the item is a folder, gets an <c>IEnumShellItems</c> object that enumerates all items in
		/// the folder. This includes folders, nonfolders, and hidden items.
		/// </para>
		/// <para>BHID_DataObject</para>
		/// <para><b>Introduced in Windows Vista</b>: Gets an <c>IDataObject</c> object for use with an item or an array of items.</para>
		/// <para>BHID_AssociationArray</para>
		/// <para><b>Introduced in Windows Vista</b>: Gets an <c>IQueryAssociations</c> object for use with an item or an array of items.</para>
		/// <para>BHID_Filter</para>
		/// <para><b>Introduced in Windows Vista</b>: Restricts usage to <c>IFilter</c>.</para>
		/// <para>BHID_EnumAssocHandlers</para>
		/// <para>
		/// <b>Introduced in Windows 7</b>: Gets an <c>IEnumAssocHandlers</c> object used to enumerate the recommended association handlers
		/// for the given item.
		/// </para>
		/// <para>BHID_RandomAccessStream</para>
		/// <para><b>Introduced in Windows 8</b>: Gets an <c>IRandomAccessStream</c> object for the item.</para>
		/// <para>BHID_FilePlaceholder</para>
		/// <para><b>Introduced in Windows 8.1</b>: Gets an object used to provide placeholder file functionality.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>IID of the object type to retrieve.</para>
		/// </param>
		/// <param name="ppv">
		/// <para>Type: <b>void**</b></para>
		/// <para>When this method returns, contains a pointer of type <i>riid</i> that is returned by the handler specified by <i>rbhid</i>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellitem-bindtohandler
		// HRESULT BindToHandler( IBindCtx *pbc, REFGUID bhid, REFIID riid, void **ppv );
		[PreserveSig]
		HRESULT BindToHandler([In, Optional] IBindCtx? pbc, in Guid bhid, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppv);

		/// <summary>Gets the parent of an IShellItem object.</summary>
		/// <returns>The address of a pointer to the parent of an IShellItem interface.</returns>
		IShellItem GetParent();

		/// <summary>Gets the display name of the IShellItem object.</summary>
		/// <param name="sigdnName">One of the SIGDN values that indicates how the name should look.</param>
		/// <returns>
		/// A value that, when this function returns successfully, receives the address of a pointer to the retrieved display name.
		/// </returns>
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetDisplayName(SIGDN sigdnName);

		/// <summary>Gets a requested set of attributes of the IShellItem object.</summary>
		/// <param name="sfgaoMask">
		/// Specifies the attributes to retrieve. One or more of the SFGAO values. Use a bitwise OR operator to determine the attributes
		/// to retrieve.
		/// </param>
		/// <returns>
		/// A pointer to a value that, when this method returns successfully, contains the requested attributes. One or more of the SFGAO
		/// values. Only those attributes specified by sfgaoMask are returned; other attribute values are undefined.
		/// </returns>
		SFGAO GetAttributes(SFGAO sfgaoMask);

		/// <summary>Compares two IShellItem objects.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to an IShellItem object to compare with the existing <c>IShellItem</c> object.</para>
		/// </param>
		/// <param name="hint">
		/// <para>Type: <c>SICHINTF</c></para>
		/// <para>
		/// One of the SICHINTF values that determines how to perform the comparison. See <c>SICHINTF</c> for the list of possible values for
		/// this parameter.
		/// </para>
		/// </param>
		/// <param name="piOrder">
		/// <para>Type: <c>int*</c></para>
		/// <para>
		/// This parameter receives the result of the comparison. If the two items are the same this parameter equals zero; if they are
		/// different the parameter is nonzero.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if the items are the same, S_FALSE if they are different, or an error value otherwise.</para>
		/// </returns>
		/// <remarks>The data type used in the second parameter, SICHINTF, is defined as:</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellitem-compare
		// HRESULT Compare( IShellItem *psi, SICHINTF hint, int *piOrder );
		[PreserveSig]
		HRESULT Compare(IShellItem? psi, SICHINTF hint, out int piOrder);
	}

	/// <summary>
	/// Extends IShellItem with methods that retrieve various property values of the item. IShellItem and IShellItem2 are the preferred
	/// representations of items in any new code.
	/// </summary>
	[SuppressUnmanagedCodeSecurity]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("7e9fb0d3-919f-4307-ab2e-9b1860310c93")]
	[PInvokeData("Shobjidl.h", MSDNShortId = "bb761130")]
	public interface IShellItem2 : IShellItem
	{
		/// <summary>Binds to a handler for an item as specified by the handler ID value (BHID).</summary>
		/// <param name="pbc">
		/// <para>Type: <b><c>IBindCtx</c>*</b></para>
		/// <para>
		/// A pointer to an <c>IBindCtx</c> interface on a bind context object. Used to pass optional parameters to the handler. The contents
		/// of the bind context are handler-specific. For example, when binding to <b>BHID_Stream</b>, the <c>STGM</c> flags in the bind
		/// context indicate the mode of access desired (read or read/write).
		/// </para>
		/// </param>
		/// <param name="bhid">
		/// <para>Type: <b>REFGUID</b></para>
		/// <para>Reference to a GUID that specifies which handler will be created. One of the following values defined in Shlguid.h:</para>
		/// <para>BHID_SFObject</para>
		/// <para>Restricts usage to <c>BindToObject</c>.</para>
		/// <para>BHID_SFUIObject</para>
		/// <para>Restricts usage to <c>GetUIObjectOf</c>.</para>
		/// <para>BHID_SFViewObject</para>
		/// <para>Restricts usage to <c>CreateViewObject</c>.</para>
		/// <para>BHID_Storage</para>
		/// <para>Attempts to retrieve the storage RIID, but defaults to Shell implementation on failure.</para>
		/// <para>BHID_Stream</para>
		/// <para>Restricts usage to <c>IStream</c>.</para>
		/// <para>BHID_LinkTargetItem</para>
		/// <para>
		/// CLSID_ShellItem is initialized with the target of this item (can only be SFGAO_LINK). See <c>SFGAO</c> for a description of SFGAO_LINK.
		/// </para>
		/// <para>BHID_StorageEnum</para>
		/// <para>If the item is a folder, gets an <c>IEnumShellItems</c> object with which to enumerate the storage contents.</para>
		/// <para>BHID_Transfer</para>
		/// <para>
		/// <b>Introduced in Windows Vista</b>: If the item is a folder, gets an <c>ITransferSource</c> or <c>ITransferDestination</c> object.
		/// </para>
		/// <para>BHID_PropertyStore</para>
		/// <para><b>Introduced in Windows Vista</b>: Restricts usage to <c>IPropertyStore</c> or <c>IPropertyStoreFactory</c>.</para>
		/// <para>BHID_ThumbnailHandler</para>
		/// <para><b>Introduced in Windows Vista</b>: Restricts usage to <c>IExtractImage</c> or <c>IThumbnailProvider</c>.</para>
		/// <para>BHID_EnumItems</para>
		/// <para>
		/// <b>Introduced in Windows Vista</b>: If the item is a folder, gets an <c>IEnumShellItems</c> object that enumerates all items in
		/// the folder. This includes folders, nonfolders, and hidden items.
		/// </para>
		/// <para>BHID_DataObject</para>
		/// <para><b>Introduced in Windows Vista</b>: Gets an <c>IDataObject</c> object for use with an item or an array of items.</para>
		/// <para>BHID_AssociationArray</para>
		/// <para><b>Introduced in Windows Vista</b>: Gets an <c>IQueryAssociations</c> object for use with an item or an array of items.</para>
		/// <para>BHID_Filter</para>
		/// <para><b>Introduced in Windows Vista</b>: Restricts usage to <c>IFilter</c>.</para>
		/// <para>BHID_EnumAssocHandlers</para>
		/// <para>
		/// <b>Introduced in Windows 7</b>: Gets an <c>IEnumAssocHandlers</c> object used to enumerate the recommended association handlers
		/// for the given item.
		/// </para>
		/// <para>BHID_RandomAccessStream</para>
		/// <para><b>Introduced in Windows 8</b>: Gets an <c>IRandomAccessStream</c> object for the item.</para>
		/// <para>BHID_FilePlaceholder</para>
		/// <para><b>Introduced in Windows 8.1</b>: Gets an object used to provide placeholder file functionality.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>IID of the object type to retrieve.</para>
		/// </param>
		/// <param name="ppv">
		/// <para>Type: <b>void**</b></para>
		/// <para>When this method returns, contains a pointer of type <i>riid</i> that is returned by the handler specified by <i>rbhid</i>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellitem-bindtohandler
		// HRESULT BindToHandler( IBindCtx *pbc, REFGUID bhid, REFIID riid, void **ppv );
		[PreserveSig]
		new HRESULT BindToHandler([In, Optional] IBindCtx? pbc, in Guid bhid, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppv);

		/// <summary>Gets the parent of an IShellItem object.</summary>
		/// <returns>The address of a pointer to the parent of an IShellItem interface.</returns>
		new IShellItem GetParent();

		/// <summary>Gets the display name of the IShellItem object.</summary>
		/// <param name="sigdnName">One of the SIGDN values that indicates how the name should look.</param>
		/// <returns>
		/// A value that, when this function returns successfully, receives the address of a pointer to the retrieved display name.
		/// </returns>
		[return: MarshalAs(UnmanagedType.LPWStr)]
		new string GetDisplayName(SIGDN sigdnName);

		/// <summary>Gets a requested set of attributes of the IShellItem object.</summary>
		/// <param name="sfgaoMask">
		/// Specifies the attributes to retrieve. One or more of the SFGAO values. Use a bitwise OR operator to determine the attributes
		/// to retrieve.
		/// </param>
		/// <returns>
		/// A pointer to a value that, when this method returns successfully, contains the requested attributes. One or more of the SFGAO
		/// values. Only those attributes specified by sfgaoMask are returned; other attribute values are undefined.
		/// </returns>
		new SFGAO GetAttributes(SFGAO sfgaoMask);

		/// <summary>Compares two IShellItem objects.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to an IShellItem object to compare with the existing <c>IShellItem</c> object.</para>
		/// </param>
		/// <param name="hint">
		/// <para>Type: <c>SICHINTF</c></para>
		/// <para>
		/// One of the SICHINTF values that determines how to perform the comparison. See <c>SICHINTF</c> for the list of possible values for
		/// this parameter.
		/// </para>
		/// </param>
		/// <param name="piOrder">
		/// <para>Type: <c>int*</c></para>
		/// <para>
		/// This parameter receives the result of the comparison. If the two items are the same this parameter equals zero; if they are
		/// different the parameter is nonzero.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if the items are the same, S_FALSE if they are different, or an error value otherwise.</para>
		/// </returns>
		/// <remarks>The data type used in the second parameter, SICHINTF, is defined as:</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellitem-compare
		// HRESULT Compare( IShellItem *psi, SICHINTF hint, int *piOrder );
		[PreserveSig]
		new HRESULT Compare(IShellItem? psi, SICHINTF hint, out int piOrder);

		/// <summary>Gets a property store object for specified property store flags.</summary>
		/// <param name="flags">The GETPROPERTYSTOREFLAGS constants that modify the property store object.</param>
		/// <param name="riid">A reference to the IID of the object to be retrieved.</param>
		/// <returns>When this method returns, contains the address of an IPropertyStore interface pointer.</returns>
		[return: MarshalAs(UnmanagedType.Interface)]
		IPropertyStore GetPropertyStore(GETPROPERTYSTOREFLAGS flags, in Guid riid);

		/// <summary>
		/// Uses the specified ICreateObject instead of CoCreateInstance to create an instance of the property handler associated with
		/// the Shell item on which this method is called. Most calling applications do not need to call this method, and can call
		/// IShellItem2::GetPropertyStore instead.
		/// </summary>
		/// <param name="flags">The GETPROPERTYSTOREFLAGS constants that modify the property store object.</param>
		/// <param name="punkCreateObject">
		/// A pointer to a factory for low-rights creation of type ICreateObject.
		/// <para>
		/// The method CreateObject creates an instance of a COM object. The implementation of
		/// IShellItem2::GetPropertyStoreWithCreateObject uses CreateObject instead of CoCreateInstance to create the property handler,
		/// which is a Shell extension, for a given file type. The property handler provides many of the important properties in the
		/// property store that this method returns.
		/// </para>
		/// <para>
		/// This method is useful only if the ICreateObject object is created in a separate process (as a LOCALSERVER instead of an
		/// INPROCSERVER), and also if this other process has lower rights than the process calling IShellItem2::GetPropertyStoreWithCreateObject.
		/// </para>
		/// </param>
		/// <param name="riid">A reference to the IID of the object to be retrieved.</param>
		/// <returns>When this method returns, contains the address of the requested IPropertyStore interface pointer.</returns>
		// TODO: Create ICreateObject for second param
		[return: MarshalAs(UnmanagedType.Interface)]
		IPropertyStore GetPropertyStoreWithCreateObject(GETPROPERTYSTOREFLAGS flags, [MarshalAs(UnmanagedType.IUnknown)] object punkCreateObject,
			in Guid riid);

		/// <summary>Gets property store object for specified property keys.</summary>
		/// <param name="rgKeys">
		/// A pointer to an array of PROPERTYKEY structures. Each structure contains a unique identifier for each property used in
		/// creating the property store.
		/// </param>
		/// <param name="cKeys">The number of PROPERTYKEY structures in the array pointed to by rgKeys.</param>
		/// <param name="flags">The GETPROPERTYSTOREFLAGS constants that modify the property store object.</param>
		/// <param name="riid">A reference to the IID of the object to be retrieved.</param>
		/// <returns></returns>
		[return: MarshalAs(UnmanagedType.Interface)]
		IPropertyStore GetPropertyStoreForKeys([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] PROPERTYKEY[] rgKeys, uint cKeys, GETPROPERTYSTOREFLAGS flags, in Guid riid);

		/// <summary>Gets a property description list object given a reference to a property key.</summary>
		/// <param name="keyType">A reference to a PROPERTYKEY structure.</param>
		/// <param name="riid">A reference to a desired IID.</param>
		/// <returns>Contains the address of an IPropertyDescriptionList interface pointer.</returns>
		IPropertyDescriptionList GetPropertyDescriptionList(in PROPERTYKEY keyType, in Guid riid);

		/// <summary>Ensures that any cached information in this item is updated.</summary>
		/// <param name="pbc">A pointer to an IBindCtx interface on a bind context object.</param>
		void Update(IBindCtx pbc);

		/// <summary>Gets a PROPVARIANT structure from a specified property key.</summary>
		/// <param name="key">A reference to a PROPERTYKEY structure.</param>
		/// <returns>Contains a pointer to a PROPVARIANT structure.</returns>
		PROPVARIANT GetProperty(in PROPERTYKEY key);

		/// <summary>Gets the class identifier (CLSID) value of specified property key.</summary>
		/// <param name="key">A reference to a PROPERTYKEY structure.</param>
		/// <returns>A pointer to a CLSID value.</returns>
		Guid GetCLSID(in PROPERTYKEY key);

		/// <summary>Gets the date and time value of a specified property key.</summary>
		/// <param name="key">A reference to a PROPERTYKEY structure.</param>
		/// <returns>A pointer to a date and time value.</returns>
		FILETIME GetFileTime(in PROPERTYKEY key);

		/// <summary>Gets the Int32 value of specified property key.</summary>
		/// <param name="key">A reference to a PROPERTYKEY structure.</param>
		/// <returns>A pointer to an Int32 value.</returns>
		int GetInt32(in PROPERTYKEY key);

		/// <summary>Gets the string value of a specified property key.</summary>
		/// <param name="key">A reference to a PROPERTYKEY structure.</param>
		/// <returns>A pointer to a Unicode string value.</returns>
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetString(in PROPERTYKEY key);

		/// <summary>Gets the UInt32 value of specified property key.</summary>
		/// <param name="key">A reference to a PROPERTYKEY structure.</param>
		/// <returns>A pointer to an UInt32 value.</returns>
		uint GetUInt32(in PROPERTYKEY key);

		/// <summary>Gets the UInt64 value of specified property key.</summary>
		/// <param name="key">A reference to a PROPERTYKEY structure.</param>
		/// <returns>A pointer to an UInt64 value.</returns>
		ulong GetUInt64(in PROPERTYKEY key);

		/// <summary>Gets the boolean value of a specified property key.</summary>
		/// <param name="key">A reference to a PROPERTYKEY structure.</param>
		/// <returns>A pointer to a boolean value.</returns>
		[return: MarshalAs(UnmanagedType.Bool)]
		bool GetBool(in PROPERTYKEY key);
	}

	/// <summary>Exposes methods that create and manipulate Shell item arrays.</summary>
	[SuppressUnmanagedCodeSecurity]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("B63EA76D-1F85-456F-A19C-48159EFA858B")]
	[PInvokeData("Shobjidl.h", MSDNShortId = "bb761106")]
	public interface IShellItemArray
	{
		/// <summary>Binds to an object by means of the specified handler.</summary>
		/// <param name="pbc">A pointer to an IBindCtx interface on a bind context object.</param>
		/// <param name="rbhid">
		/// One of the following values, defined in Shlguid.h, that determine the handler.
		/// <list>
		/// <item>
		/// <term>BHID_SFUIObject</term>
		/// <description>
		/// Restricts usage to GetUIObjectOf. Use this handler type only for a flat item array, where all items are in the same folder.
		/// </description>
		/// </item>
		/// <item>
		/// <term>BHID_DataObject</term>
		/// <description>
		/// Introduced in Windows Vista: Gets an IDataObject object for use with an item or an array of items. Use this handler type only
		/// for flat data objects or item arrays created by SHCreateShellItemArrayFromDataObject.
		/// </description>
		/// </item>
		/// <item>
		/// <term>BHID_AssociationArray</term>
		/// <description>
		/// Introduced in Windows Vista: Gets an IQueryAssociations object for use with an item or an array of items. This only retrieves
		/// the association array object for the first item in the IShellItemArray
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="riid">The IID of the object type to retrieve.</param>
		/// <returns>
		/// When this /// methods returns, contains the object specified in riid that is returned by the handler specified by rbhid.
		/// </returns>
		[return: MarshalAs(UnmanagedType.Interface, IidParameterIndex = 2)]
		object BindToHandler(IBindCtx? pbc, in Guid rbhid, in Guid riid);

		/// <summary>Gets a property store.</summary>
		/// <param name="flags">One of the GETPROPERTYSTOREFLAGS constants.</param>
		/// <param name="riid">The IID of the object type to retrieve.</param>
		/// <returns>
		/// When this method returns, contains interface pointer requested in riid. This is typically IPropertyStore or IPropertyStoreCapabilities.
		/// </returns>
		[return: MarshalAs(UnmanagedType.Interface, IidParameterIndex = 1)]
		object GetPropertyStore(GETPROPERTYSTOREFLAGS flags, in Guid riid);

		/// <summary>Gets a property description list for the items in the shell item array.</summary>
		/// <param name="keyType">A reference to the PROPERTYKEY structure specifying which property list to retrieve.</param>
		/// <param name="riid">The IID of the object type to retrieve.</param>
		/// <returns>When this method returns, contains the interface requested in riid. This will typically be IPropertyDescriptionList.</returns>
		[return: MarshalAs(UnmanagedType.Interface, IidParameterIndex = 1)]
		object GetPropertyDescriptionList(in PROPERTYKEY keyType, in Guid riid);

		/// <summary>
		/// Gets the attributes of the set of items contained in an IShellItemArray. If the array contains more than one item, the
		/// attributes retrieved by this method are not the attributes of single items, but a logical combination of all of the requested
		/// attributes of all of the items.
		/// </summary>
		/// <param name="dwAttribFlags">
		/// If the array contains a single item, this method provides the same results as GetAttributes. However, if the array contains
		/// multiple items, the attribute sets of all the items are combined into a single attribute set and returned in the value
		/// pointed to by psfgaoAttribs. This parameter takes one of the following values to define how that final attribute set is determined:
		/// </param>
		/// <param name="sfgaoMask">
		/// A mask that specifies what particular attributes are being requested. A bitwise OR of one or more of the SFGAO values.
		/// </param>
		/// <returns>A bitmap that, when this method returns successfully, contains the values of the requested attributes.</returns>
		SFGAO GetAttributes(SIATTRIBFLAGS dwAttribFlags, SFGAO sfgaoMask);

		/// <summary>Gets the number of items in the given IShellItem array.</summary>
		/// <returns>When this method returns, contains the number of items in the IShellItemArray.</returns>
		uint GetCount();

		/// <summary>Gets the item at the given index in the IShellItemArray.</summary>
		/// <param name="dwIndex">The index of the IShellItem requested in the IShellItemArray</param>
		/// <returns>When this method returns, contains the requested IShellItem pointer.</returns>
		IShellItem GetItemAt(uint dwIndex);

		/// <summary>Gets an enumerator of the items in the array.</summary>
		/// <returns>
		/// When this method returns, contains an IEnumShellItems pointer that enumerates the shell items that are in the array.
		/// </returns>
		IEnumShellItems EnumItems();
	}

	/// <summary>
	/// <para>
	/// Exposes a method to return either icons or thumbnails for Shell items. If no thumbnail or icon is available for the requested
	/// item, a per-class icon may be provided from the Shell.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>A pointer to this interface is commonly obtained through one of the following functions:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>SHCreateItemFromIDList</term>
	/// </item>
	/// <item>
	/// <term>SHCreateItemFromParsingName</term>
	/// </item>
	/// <item>
	/// <term>SHCreateItemFromRelativeName</term>
	/// </item>
	/// <item>
	/// <term>SHCreateItemInKnownFolder</term>
	/// </item>
	/// <item>
	/// <term>SHCreateItemWithParent</term>
	/// </item>
	/// </list>
	/// <para>See the Using Image Factory sample for a full example of how to use this interface.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nn-shobjidl_core-ishellitemimagefactory
	[PInvokeData("shobjidl_core.h", MSDNShortId = "a6eea412-553a-4bdd-afc2-cc002c4500a4")]
	[ComImport, Guid("bcc18b79-ba16-442f-80c4-8a59c30c463b"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IShellItemImageFactory
	{
		/// <summary>
		/// Gets an HBITMAP that represents an IShellItem. The default behavior is to load a thumbnail. If there is no thumbnail for the
		/// current IShellItem, it retrieves an HBITMAP for the icon of the item. The thumbnail or icon is extracted if it is not
		/// currently cached.
		/// </summary>
		/// <param name="size">A structure that specifies the size of the image to be received.</param>
		/// <param name="flags">One or more of the SIIGBF flags.</param>
		/// <param name="phbm">
		/// Pointer to a value that, when this method returns successfully, receives the handle of the retrieved bitmap. It is the
		/// responsibility of the caller to free this retrieved resource through DeleteObject when it is no longer needed.
		/// </param>
		/// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[PreserveSig]
		HRESULT GetImage([In, MarshalAs(UnmanagedType.Struct)] SIZE size, [In] SIIGBF flags, out SafeHBITMAP phbm);
	}

	/// <summary>Binds to a handler for an item as specified by the handler ID value (BHID).</summary>
	/// <typeParam name = "T">
	/// <para>Type: <b>REFIID</b></para>
	/// <para>IID of the object type to retrieve.</para>
	/// </typeParam>
	/// <param name = "si">The <see cref = "IShellItem"/> interface instance value used for the extension method.</param>
	/// <param name = "pbc">
	/// <para>Type: <b><c>IBindCtx</c>*</b></para>
	/// <para> A pointer to an <c>IBindCtx</c> interface on a bind context object. Used to pass optional parameters to the handler. The contents of the bind context are handler-specific. For example, when binding to <b>BHID_Stream</b>, the <c>STGM</c> flags in the bind context indicate the mode of access desired (read or read/write).
	/// </para>
	/// </param>
	/// <param name = "bhid">
	/// <para>Type: <b>REFGUID</b></para>
	/// <para>Reference to a GUID that specifies which handler will be created. One of the following values defined in Shlguid.h:</para>
	/// <para>BHID_SFObject</para>
	/// <para>Restricts usage to <c>BindToObject</c>.</para>
	/// <para>BHID_SFUIObject</para>
	/// <para>Restricts usage to <c>GetUIObjectOf</c>.</para>
	/// <para>BHID_SFViewObject</para>
	/// <para>Restricts usage to <c>CreateViewObject</c>.</para>
	/// <para>BHID_Storage</para>
	/// <para>Attempts to retrieve the storage RIID, but defaults to Shell implementation on failure.</para>
	/// <para>BHID_Stream</para>
	/// <para>Restricts usage to <c>IStream</c>.</para>
	/// <para>BHID_LinkTargetItem</para>
	/// <para> CLSID_ShellItem is initialized with the target of this item (can only be SFGAO_LINK). See <c>SFGAO</c> for a description of SFGAO_LINK.
	/// </para>
	/// <para>BHID_StorageEnum</para>
	/// <para>If the item is a folder, gets an <c>IEnumShellItems</c> object with which to enumerate the storage contents.</para>
	/// <para>BHID_Transfer</para>
	/// <para>
	/// <b>Introduced in Windows Vista</b>: If the item is a folder, gets an <c>ITransferSource</c> or <c>ITransferDestination</c> object.
	/// </para>
	/// <para>BHID_PropertyStore</para>
	/// <para><b>Introduced in Windows Vista</b>: Restricts usage to <c>IPropertyStore</c> or <c>IPropertyStoreFactory</c>.</para>
	/// <para>BHID_ThumbnailHandler</para>
	/// <para><b>Introduced in Windows Vista</b>: Restricts usage to <c>IExtractImage</c> or <c>IThumbnailProvider</c>.</para>
	/// <para>BHID_EnumItems</para>
	/// <para>
	/// <b>Introduced in Windows Vista</b>: If the item is a folder, gets an <c>IEnumShellItems</c> object that enumerates all items in the folder. This includes folders, nonfolders, and hidden items.
	/// </para>
	/// <para>BHID_DataObject</para>
	/// <para><b>Introduced in Windows Vista</b>: Gets an <c>IDataObject</c> object for use with an item or an array of items.</para>
	/// <para>BHID_AssociationArray</para>
	/// <para><b>Introduced in Windows Vista</b>: Gets an <c>IQueryAssociations</c> object for use with an item or an array of items.</para>
	/// <para>BHID_Filter</para>
	/// <para><b>Introduced in Windows Vista</b>: Restricts usage to <c>IFilter</c>.</para>
	/// <para>BHID_EnumAssocHandlers</para>
	/// <para>
	/// <b>Introduced in Windows 7</b>: Gets an <c>IEnumAssocHandlers</c> object used to enumerate the recommended association handlers for the given item.
	/// </para>
	/// <para>BHID_RandomAccessStream</para>
	/// <para><b>Introduced in Windows 8</b>: Gets an <c>IRandomAccessStream</c> object for the item.</para>
	/// <para>BHID_FilePlaceholder</para>
	/// <para><b>Introduced in Windows 8.1</b>: Gets an object used to provide placeholder file functionality.</para>
	/// </param>
	/// <param name = "ppv">
	/// <para>Type: <b>void**</b></para>
	/// <para>When this method returns, contains a pointer of type <i>riid</i> that is returned by the handler specified by <i>rbhid</i>.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b>HRESULT</b></para>
	/// <para>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
	/// </returns>
	public static HRESULT BindToHandler<T>(this IShellItem si, [In, Optional] IBindCtx? pbc, BHID bhid, out T? ppv)
		where T : class
	{
		if (bhid == 0 && !CorrespondingTypeAttribute.CanGet<T, BHID>(out bhid)) throw new ArgumentException("The specified type does not have a corresponding BHID.", nameof(T));
		return si.BindToHandler<T>(pbc, bhid.Guid(), out ppv);
	}

	/// <summary>Extension method to simplify using the <see cref="IShellItem.BindToHandler"/> method.</summary>
	/// <typeparam name="T">Type of the interface to get.</typeparam>
	/// <param name="si">An <see cref="IShellItem"/> instance.</param>
	/// <param name="pbc">
	/// A pointer to an IBindCtx interface on a bind context object. Used to pass optional parameters to the handler. The contents of
	/// the bind context are handler-specific. For example, when binding to BHID_Stream, the STGM flags in the bind context indicate
	/// the mode of access desired (read or read/write).
	/// </param>
	/// <param name="bhid">Reference to a GUID that specifies which handler will be created.</param>
	/// <returns>Receives the interface pointer requested in <typeparamref name="T"/>.</returns>
	public static T BindToHandler<T>(this IShellItem si, [In] IBindCtx? pbc, in Guid bhid) where T : class
	{
		si.BindToHandler(pbc, bhid, out T? ppv).ThrowIfFailed();
		return ppv!;
	}

	/// <summary>Extension method to simplify using the <see cref="IShellItem.BindToHandler"/> method.</summary>
	/// <typeparam name="T">Type of the interface to get.</typeparam>
	/// <param name="si">An <see cref="IShellItem"/> instance.</param>
	/// <param name="pbc">
	/// A pointer to an IBindCtx interface on a bind context object. Used to pass optional parameters to the handler. The contents of
	/// the bind context are handler-specific. For example, when binding to BHID_Stream, the STGM flags in the bind context indicate
	/// the mode of access desired (read or read/write).
	/// </param>
	/// <param name="bhid">A BHID enumeration value that specifies which handler will be created.</param>
	/// <returns>Receives the interface pointer requested in <typeparamref name="T"/>.</returns>
	public static T BindToHandler<T>(this IShellItem si, [In] IBindCtx? pbc = null, BHID bhid = 0) where T : class => si.BindToHandler<T>(pbc, bhid.Guid());

	/// <summary>Extension method to simplify using the <see cref="IShellItemArray.BindToHandler"/> method.</summary>
	/// <typeparam name="T">Type of the interface to get.</typeparam>
	/// <param name="sia">An <see cref="IShellItemArray"/> instance.</param>
	/// <param name="pbc">
	/// A pointer to an IBindCtx interface on a bind context object. Used to pass optional parameters to the handler. The contents of
	/// the bind context are handler-specific. For example, when binding to BHID_Stream, the STGM flags in the bind context indicate
	/// the mode of access desired (read or read/write).
	/// </param>
	/// <param name="rbhid">Reference to a GUID that specifies which handler will be created.</param>
	/// <returns>Receives the interface pointer requested in <typeparamref name="T"/>.</returns>
	public static T BindToHandler<T>(this IShellItemArray sia, [In] IBindCtx? pbc, in Guid rbhid) where T : class => (T)sia.BindToHandler(pbc, rbhid, typeof(T).GUID);

	/// <summary>Extension method to simplify using the <see cref="IShellItemArray.BindToHandler"/> method.</summary>
	/// <typeparam name="T">Type of the interface to get.</typeparam>
	/// <param name="sia">An <see cref="IShellItemArray"/> instance.</param>
	/// <param name="pbc">
	/// A pointer to an IBindCtx interface on a bind context object. Used to pass optional parameters to the handler. The contents of
	/// the bind context are handler-specific. For example, when binding to BHID_Stream, the STGM flags in the bind context indicate
	/// the mode of access desired (read or read/write).
	/// </param>
	/// <param name="bhid">A BHID enumeration value that specifies which handler will be created.</param>
	/// <returns>Receives the interface pointer requested in <typeparamref name="T"/>.</returns>
	public static T BindToHandler<T>(this IShellItemArray sia, [In] IBindCtx? pbc, BHID bhid) where T : class => (T)sia.BindToHandler(pbc, bhid.Guid(), typeof(T).GUID);

	/// <summary>Extension method to simplify using the <see cref="IShellItemArray.GetPropertyStore"/> method.</summary>
	/// <typeparam name="T">Type of the interface to get.</typeparam>
	/// <param name="sia">An <see cref="IShellItemArray"/> instance.</param>
	/// <param name="flags">One of the GETPROPERTYSTOREFLAGS constants.</param>
	/// <returns>Receives the interface pointer requested in <typeparamref name="T"/>.</returns>
	public static T GetPropertyStore<T>(this IShellItemArray sia, GETPROPERTYSTOREFLAGS flags) where T : class => (T)sia.GetPropertyStore(flags, typeof(T).GUID);

	/// <summary>Extension method to simplify using the <see cref="IShellItemArray.GetPropertyDescriptionList"/> method.</summary>
	/// <typeparam name="T">Type of the interface to get.</typeparam>
	/// <param name="sia">An <see cref="IShellItemArray"/> instance.</param>
	/// <param name="keyType">A reference to the PROPERTYKEY structure specifying which property list to retrieve.</param>
	/// <returns>Receives the interface pointer requested in <typeparamref name="T"/>.</returns>
	public static T GetPropertyDescriptionList<T>(this IShellItemArray sia, in PROPERTYKEY keyType) where T : class => (T)sia.GetPropertyDescriptionList(keyType, typeof(T).GUID);
}