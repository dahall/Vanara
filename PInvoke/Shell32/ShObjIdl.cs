using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.PropSys;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable InconsistentNaming
// ReSharper disable MemberHidesStaticFromOuterClass
// ReSharper disable UnusedMethodReturnValue.Global

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>Values that specify from which category the list of destinations should be retrieved.</summary>
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd378410")]
		public enum APPDOCLISTTYPE
		{
			/// <summary>The Recent category, which lists those items most recently accessed.</summary>
			RECENT,

			/// <summary>The Frequent category, which lists the items that have been accessed the greatest number of times.</summary>
			FREQUENT
		}

		/// <summary>One of the following values that indicate which known category to add to the list</summary>
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd378397")]
		public enum KNOWNDESTCATEGORY
		{
			/// <summary>Add the Frequent category.</summary>
			KDC_FREQUENT = 1,

			/// <summary>Add the Recent category.</summary>
			KDC_RECENT = 2
		}

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
			/// If a namespace extension returns this attribute, a Create Shortcut entry with a default handler is added to the shortcut menu that is displayed
			/// during drag-and-drop operations. The extension can also implement its own handler for the link verb in place of the default. If the extension
			/// does so, it is responsible for creating the shortcut.
			/// </para>
			/// <para>A Create Shortcut item is also added to the Windows Explorer File menu and to normal shortcut menus.</para>
			/// <para>
			/// If the item is selected, your application's IContextMenu::InvokeCommand method is invoked with the lpVerb member of the CMINVOKECOMMANDINFO
			/// structure set to link. Your application is responsible for creating the link.
			/// </para>
			/// </summary>
			SFGAO_CANLINK = 4,

			/// <summary>Not supported.</summary>
			SFGAO_CANMONIKER = 0x400000,

			/// <summary>The specified items can be moved.</summary>
			SFGAO_CANMOVE = 2,

			/// <summary>
			/// The specified items can be renamed. Note that this value is essentially a suggestion; not all namespace clients allow items to be renamed.
			/// However, those that do must have this attribute set.
			/// </summary>
			SFGAO_CANRENAME = 0x10,

			/// <summary>
			/// This flag is a mask for the capability attributes: SFGAO_CANCOPY, SFGAO_CANMOVE, SFGAO_CANLINK, SFGAO_CANRENAME, SFGAO_CANDELETE,
			/// SFGAO_HASPROPSHEET, and SFGAO_DROPTARGET. Callers normally do not use this value.
			/// </summary>
			SFGAO_CAPABILITYMASK = 0x177,

			/// <summary>The specified items are compressed.</summary>
			SFGAO_COMPRESSED = 0x4000000,

			/// <summary>This flag is a mask for content attributes, at present only SFGAO_HASSUBFOLDER. Callers normally do not use this value.</summary>
			SFGAO_CONTENTSMASK = 0x80000000,

			/// <summary>Do not use.</summary>
			SFGAO_DISPLAYATTRMASK = 0xfc000,

			/// <summary>The specified items are drop targets.</summary>
			SFGAO_DROPTARGET = 0x100,

			/// <summary>The specified items are encrypted and might require special presentation.</summary>
			SFGAO_ENCRYPTED = 0x2000,

			/// <summary>
			/// The specified folders are either file system folders or contain at least one descendant (child, grandchild, or later) that is a file system
			/// (SFGAO_FILESYSTEM) folder.
			/// </summary>
			SFGAO_FILESYSANCESTOR = 0x10000000,

			/// <summary>
			/// The specified folders or files are part of the file system (that is, they are files, directories, or root directories). The parsed names of the
			/// items can be assumed to be valid Win32 file system paths. These paths can be either UNC or drive-letter based.
			/// </summary>
			SFGAO_FILESYSTEM = 0x40000000,

			/// <summary>
			/// The specified items are folders. Some items can be flagged with both SFGAO_STREAM and SFGAO_FOLDER, such as a compressed file with a .zip file
			/// name extension. Some applications might include this flag when testing for items that are both files and containers.
			/// </summary>
			SFGAO_FOLDER = 0x20000000,

			/// <summary>The specified items are shown as dimmed and unavailable to the user.</summary>
			SFGAO_GHOSTED = 0x8000,

			/// <summary>The specified items have property sheets.</summary>
			SFGAO_HASPROPSHEET = 0x40,

			/// <summary>Not supported.</summary>
			SFGAO_HASSTORAGE = 0x400000,

			/// <summary>
			/// The specified folders have subfolders. The SFGAO_HASSUBFOLDER attribute is only advisory and might be returned by Shell folder implementations
			/// even if they do not contain subfolders. Note, however, that the converse—failing to return SFGAO_HASSUBFOLDER—definitively states that the folder
			/// objects do not have subfolders.
			/// <para>
			/// Returning SFGAO_HASSUBFOLDER is recommended whenever a significant amount of time is required to determine whether any subfolders exist. For
			/// example, the Shell always returns SFGAO_HASSUBFOLDER when a folder is located on a network drive.
			/// </para>
			/// </summary>
			SFGAO_HASSUBFOLDER = 0x80000000,

			/// <summary>The item is hidden and should not be displayed unless the Show hidden files and folders option is enabled in Folder Settings.</summary>
			SFGAO_HIDDEN = 0x80000,

			/// <summary>
			/// Accessing the item (through IStream or other storage interfaces) is expected to be a slow operation. Applications should avoid accessing items
			/// flagged with SFGAO_ISSLOW. <note>Opening a stream for an item is generally a slow operation at all times. SFGAO_ISSLOW indicates that it is
			/// expected to be especially slow, for example in the case of slow network connections or offline (FILE_ATTRIBUTE_OFFLINE) files. However, querying
			/// SFGAO_ISSLOW is itself a slow operation. Applications should query SFGAO_ISSLOW only on a background thread. An alternate method, such as
			/// retrieving the PKEY_FileAttributes property and testing for FILE_ATTRIBUTE_OFFLINE, could be used in place of a method call that involves SFGAO_ISSLOW.</note>
			/// </summary>
			SFGAO_ISSLOW = 0x4000,

			/// <summary>The specified items are shortcuts.</summary>
			SFGAO_LINK = 0x10000,

			/// <summary>The items contain new content, as defined by the particular application.</summary>
			SFGAO_NEWCONTENT = 0x200000,

			/// <summary>
			/// The items are nonenumerated items and should be hidden. They are not returned through an enumerator such as that created by the
			/// IShellFolder::EnumObjects method.
			/// </summary>
			SFGAO_NONENUMERATED = 0x100000,

			/// <summary>
			/// Mask used by the PKEY_SFGAOFlags property to determine attributes that are considered to cause slow calculations or lack context: SFGAO_ISSLOW,
			/// SFGAO_READONLY, SFGAO_HASSUBFOLDER, and SFGAO_VALIDATE. Callers normally do not use this value.
			/// </summary>
			SFGAO_PKEYSFGAOMASK = 0x81044000,

			/// <summary>
			/// The specified items are read-only. In the case of folders, this means that new items cannot be created in those folders. This should not be
			/// confused with the behavior specified by the FILE_ATTRIBUTE_READONLY flag retrieved by IColumnProvider::GetItemData in a SHCOLUMNDATA structure.
			/// FILE_ATTRIBUTE_READONLY has no meaning for Win32 file system folders.
			/// </summary>
			SFGAO_READONLY = 0x40000,

			/// <summary>The specified items are on removable media or are themselves removable devices.</summary>
			SFGAO_REMOVABLE = 0x2000000,

			/// <summary>The specified objects are shared.</summary>
			SFGAO_SHARE = 0x20000,

			/// <summary>
			/// The specified items can be bound to an IStorage object through IShellFolder::BindToObject. For more information about namespace manipulation
			/// capabilities, see IStorage.
			/// </summary>
			SFGAO_STORAGE = 8,

			/// <summary>Children of this item are accessible through IStream or IStorage. Those children are flagged with SFGAO_STORAGE or SFGAO_STREAM.</summary>
			SFGAO_STORAGEANCESTOR = 0x800000,

			/// <summary>
			/// This flag is a mask for the storage capability attributes: SFGAO_STORAGE, SFGAO_LINK, SFGAO_READONLY, SFGAO_STREAM, SFGAO_STORAGEANCESTOR,
			/// SFGAO_FILESYSANCESTOR, SFGAO_FOLDER, and SFGAO_FILESYSTEM. Callers normally do not use this value.
			/// </summary>
			SFGAO_STORAGECAPMASK = 0x70c50008,

			/// <summary>
			/// Indicates that the item has a stream associated with it. That stream can be accessed through a call to IShellFolder::BindToObject or
			/// IShellItem::BindToHandler with IID_IStream in the riid parameter.
			/// </summary>
			SFGAO_STREAM = 0x400000,

			/// <summary>Windows 7 and later. The specified items are system items.</summary>
			SFGAO_SYSTEM = 0x00001000,

			/// <summary>
			/// When specified as input, SFGAO_VALIDATE instructs the folder to validate that the items contained in a folder or Shell item array exist. If one
			/// or more of those items do not exist, IShellFolder::GetAttributesOf and IShellItemArray::GetAttributes return a failure code. This flag is never
			/// returned as an [out] value.
			/// <para>
			/// When used with the file system folder, SFGAO_VALIDATE instructs the folder to discard cached properties retrieved by clients of
			/// IShellFolder2::GetDetailsEx that might have accumulated for the specified items.
			/// </para>
			/// </summary>
			SFGAO_VALIDATE = 0x1000000
		}

		/// <summary>Determines the types of items included in an enumeration. These values are used with the IShellFolder::EnumObjects method.</summary>
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762539")]
		[Flags]
		public enum SHCONTF
		{
			/// <summary>Windows 7 and later. The calling application is checking for the existence of child items in the folder.</summary>
			SHCONTF_CHECKING_FOR_CHILDREN = 0x00010,

			/// <summary>Include items that are folders in the enumeration.</summary>
			SHCONTF_FOLDERS = 0x00020,

			/// <summary>Include items that are not folders in the enumeration.</summary>
			SHCONTF_NONFOLDERS = 0x00040,

			/// <summary>Include hidden items in the enumeration. This does not include hidden system items. (To include hidden system items, use SHCONTF_INCLUDESUPERHIDDEN.)</summary>
			SHCONTF_INCLUDEHIDDEN = 0x00080,

			/// <summary>
			/// No longer used; always assumed. IShellFolder::EnumObjects can return without validating the enumeration object. Validation can be postponed until
			/// the first call to IEnumIDList::Next. Use this flag when a user interface might be displayed prior to the first IEnumIDList::Next call. For a user
			/// interface to be presented, hwnd must be set to a valid window handle.
			/// </summary>
			SHCONTF_INIT_ON_FIRST_NEXT = 0x00100,

			/// <summary>The calling application is looking for printer objects.</summary>
			SHCONTF_NETPRINTERSRCH = 0x00200,

			/// <summary>The calling application is looking for resources that can be shared.</summary>
			SHCONTF_SHAREABLE = 0x00400,

			/// <summary>Include items with accessible storage and their ancestors, including hidden items.</summary>
			SHCONTF_STORAGE = 0x00800,

			/// <summary>Windows 7 and later. Child folders should provide a navigation enumeration.</summary>
			SHCONTF_NAVIGATION_ENUM = 0x01000,

			/// <summary>Windows Vista and later. The calling application is looking for resources that can be enumerated quickly.</summary>
			SHCONTF_FASTITEMS = 0x02000,

			/// <summary>Windows Vista and later. Enumerate items as a simple list even if the folder itself is not structured in that way.</summary>
			SHCONTF_FLATLIST = 0x04000,

			/// <summary>
			/// Windows Vista and later. The calling application is monitoring for change notifications. This means that the enumerator does not have to return
			/// all results. Items can be reported through change notifications.
			/// </summary>
			SHCONTF_ENABLE_ASYNC = 0x08000,

			/// <summary>
			/// Windows 7 and later. Include hidden system items in the enumeration. This value does not include hidden non-system items. (To include hidden
			/// non-system items, use SHCONTF_INCLUDEHIDDEN.)
			/// </summary>
			SHCONTF_INCLUDESUPERHIDDEN = 0x10000
		}

		/// <summary>
		/// Defines the values used with the IShellFolder::GetDisplayNameOf and IShellFolder::SetNameOf methods to specify the type of file or folder names used
		/// by those methods.
		/// </summary>
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762541")]
		[Flags]
		public enum SHGDNF
		{
			/// <summary>The name is displayed in an address bar combo box.</summary>
			SHGDN_FORADDRESSBAR = 0x4000,

			/// <summary>The name is used for in-place editing when the user renames the item.</summary>
			SHGDN_FOREDITING = 0x1000,

			/// <summary>
			/// The name is used for parsing. That is, it can be passed to IShellFolder::ParseDisplayName to recover the object's PIDL. The form this name takes
			/// depends on the particular object. When SHGDN_FORPARSING is used alone, the name is relative to the desktop. When combined with SHGDN_INFOLDER,
			/// the name is relative to the folder from which the request was made.
			/// </summary>
			SHGDN_FORPARSING = 0x8000,

			/// <summary>
			/// The name is relative to the folder from which the request was made. This is the name display to the user when used in the context of the folder.
			/// For example, it is used in the view and in the address bar path segment for the folder. This name should not include disambiguation
			/// information—for instance "username" instead of "username (on Machine)" for a particular user's folder. Use this flag in combinations with
			/// SHGDN_FORPARSING and SHGDN_FOREDITING.
			/// </summary>
			SHGDN_INFOLDER = 1,

			/// <summary>
			/// When not combined with another flag, return the parent-relative name that identifies the item, suitable for displaying to the user. This name
			/// often does not include extra information such as the file name extension and does not need to be unique. This name might include information that
			/// identifies the folder that contains the item. For instance, this flag could cause IShellFolder::GetDisplayNameOf to return the string "username
			/// (on Machine)" for a particular user's folder.
			/// </summary>
			SHGDN_NORMAL = 0
		}

		/// <summary>
		/// If the array contains a single item, this method provides the same results as GetAttributes. However, if the array contains multiple items, the
		/// attribute sets of all the items are combined into a single attribute set and returned in the value pointed to by psfgaoAttribs. This parameter takes
		/// one of the following values to define how that final attribute set is determined:
		/// </summary>
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb761096")]
		public enum SIATTRIBFLAGS
		{
			/// <summary>If there are multiple items in the array, use a bitwise AND to combine the attributes across items. For instance, if the array contains
			/// two items where one item can be moved (SFGAO_CANMOVE) and a second item cannot, the method returns (1 &amp; 0) or 0 for that attribute bit.</summary>
			SIATTRIBFLAGS_AND = 1,

			/// <summary>
			/// Retrieve the attributes directly from the Shell data source. To use this value, the Shell item array must have been initialized as an
			/// IShellFolder with its contents specified as an array of child PIDLs.
			/// </summary>
			SIATTRIBFLAGS_APPCOMPAT = 3,

			/// <summary>
			/// If there are multiple items in the array, use a bitwise OR to combine the attributes across items. For instance, if the array contains two items
			/// where one item can be moved (SFGAO_CANMOVE) and a second item cannot, the method returns (1 | 0) or 1 for that attribute bit.
			/// </summary>
			SIATTRIBFLAGS_OR = 2,

			/// <summary>
			/// Windows 7 and later. Examine all items in the array to compute the attributes. Note that this can result in poor performance over large arrays
			/// and therefore it should be used only when needed. Cases in which you pass this flag should be extremely rare. See Remarks for more details.
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
			/// This relates to the iOrder parameter of the IShellItem::Compare interface and indicates that the comparison is based on a canonical name.
			/// </summary>
			SICHINT_CANONICAL = 0x10000000,

			/// <summary>
			/// This relates to the iOrder parameter of the IShellItem::Compare interface and indicates that the comparison is based on the display in a folder view.
			/// </summary>
			SICHINT_DISPLAY = 0,

			/// <summary>Windows 7 and later. If the Shell items are not the same, test the file system paths.</summary>
			SICHINT_TEST_FILESYSPATH_IF_NOT_EQUAL = 0x20000000
		}

		/// <summary>Requests the form of an item's display name to retrieve through IShellItem::GetDisplayName and SHGetNameFromIDList.</summary>
		/// <remarks>
		/// Different forms of an item's name can be retrieved through the item's properties, including those listed here. Note that not all properties are
		/// present on all items, so only those appropriate to the item will appear.
		/// </remarks>
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762502")]
		public enum SIGDN : uint
		{
			/// <summary>Returns the editing name relative to the desktop. In UI this name is suitable for display to the user.</summary>
			SIGDN_DESKTOPABSOLUTEEDITING = 0x8004c000,

			/// <summary>Returns the parsing name relative to the desktop. This name is not suitable for use in UI.</summary>
			SIGDN_DESKTOPABSOLUTEPARSING = 0x80028000,

			/// <summary>
			/// Returns the item's file system path, if it has one. Only items that report SFGAO_FILESYSTEM have a file system path. When an item does not have a
			/// file system path, a call to IShellItem::GetDisplayName on that item will fail. In UI this name is suitable for display to the user in some cases,
			/// but note that it might not be specified for all items.
			/// </summary>
			SIGDN_FILESYSPATH = 0x80058000,

			/// <summary>Returns the display name relative to the parent folder. In UI this name is generally ideal for display to the user.</summary>
			SIGDN_NORMALDISPLAY = 0,

			/// <summary>Returns the path relative to the parent folder.</summary>
			SIGDN_PARENTRELATIVE = 0x80080001,

			/// <summary>Returns the editing name relative to the parent folder. In UI this name is suitable for display to the user.</summary>
			SIGDN_PARENTRELATIVEEDITING = 0x80031001,

			/// <summary>
			/// Returns the path relative to the parent folder in a friendly format as displayed in an address bar. This name is suitable for display to the user.
			/// </summary>
			SIGDN_PARENTRELATIVEFORADDRESSBAR = 0x8007c001,

			/// <summary>Introduced in Windows 8.</summary>
			SIGDN_PARENTRELATIVEFORUI = 0x80094001,

			/// <summary>Returns the parsing name relative to the parent folder. This name is not suitable for use in UI.</summary>
			SIGDN_PARENTRELATIVEPARSING = 0x80018001,

			/// <summary>
			/// Returns the item's URL, if it has one. Some items do not have a URL, and in those cases a call to IShellItem::GetDisplayName will fail. This name
			/// is suitable for display to the user in some cases, but note that it might not be specified for all items.
			/// </summary>
			SIGDN_URL = 0x80068000
		}

		/// <summary>Flags that specify the type of path information to retrieve. This parameter can be a combination of the following values.</summary>
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb774944")]
		[Flags]
		public enum SLGP
		{
			/// <summary>Retrieves the standard short (8.3 format) file name.</summary>
			SLGP_SHORTPATH = 1,

			/// <summary>Unsupported; do not use.</summary>
			SLGP_UNCPRIORITY = 2,

			/// <summary>
			/// Retrieves the raw path name. A raw path is something that might not exist and may include environment variables that need to be expanded.
			/// </summary>
			SLGP_RAWPATH = 4,

			/// <summary>
			/// Windows Vista and later. Retrieves the path, if possible, of the shortcut's target relative to the path set by a previous call to IShellLink::SetRelativePath.
			/// </summary>
			SLGP_RELATIVEPRIORITY = 8
		}

		/// <summary>Exposes methods that allow an application to remove one or all destinations from the Recent or Frequent categories in a Jump List.</summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, Guid("12337d35-94c6-48a0-bce7-6a9c69d4d600"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd378413")]
		public interface IApplicationDestinations
		{
			/// <summary>
			/// Specifies a unique AppUserModelID for the application from whose taskbar button's Jump List the methods of this interface will remove
			/// destinations. This method is optional.
			/// </summary>
			/// <param name="pszAppID">Pointer to the AppUserModelID of the process whose taskbar button representation receives the Jump List.</param>
			void SetAppID([MarshalAs(UnmanagedType.LPWStr)] string pszAppID);

			/// <summary>Removes a single destination from the Recent and Frequent categories in a Jump List.</summary>
			/// <param name="punk">A pointer to the IShellItem or IShellLink that represents the destination to remove.</param>
			void RemoveDestination([MarshalAs(UnmanagedType.IUnknown)] object punk);

			/// <summary>Clears all destination entries from the Recent and Frequent categories in an application's Jump List.</summary>
			void RemoveAllDestinations();
		}

		/// <summary>Allows an application to retrieve the most recent and frequent documents opened in that app, as reported via SHAddToRecentDocs</summary>
		/// <securitynote>Critical: Suppresses unmanaged code security.</securitynote>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("3c594f9f-9f30-47a1-979a-c9e83d3d0a06")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762502")]
		public interface IApplicationDocumentLists
		{
			/// <summary>
			/// Set the App User Model ID for the application retrieving this list. If an AppID is not provided via this method, the system will use a
			/// heuristically determined ID. This method must be called before GetList.
			/// </summary>
			/// <param name="pszAppID">App Id.</param>
			void SetAppID([MarshalAs(UnmanagedType.LPWStr)] string pszAppID);

			/// <summary>Retrieve an IEnumObjects or IObjectArray for IShellItems and/or IShellLinks. Items may appear in both the frequent and recent lists.</summary>
			/// <param name="listtype">Which of the known list types to retrieve</param>
			/// <param name="cItemsDesired">The number of items desired.</param>
			/// <param name="riid">The interface Id that the return value should be queried for.</param>
			/// <returns>A COM object based on the IID passed for the riid parameter.</returns>
			[return: MarshalAs(UnmanagedType.IUnknown)]
			object GetList(APPDOCLISTTYPE listtype, uint cItemsDesired, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);
		}

		/// <summary>
		/// Exposes a standard set of methods used to enumerate the pointers to item identifier lists (PIDLs) of the items in a Shell folder. When a folder's
		/// IShellFolder::EnumObjects method is called, it creates an enumeration object and passes a pointer to the object's IEnumIDList interface back to the
		/// calling application.
		/// </summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("000214F2-0000-0000-C000-000000000046")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb761982")]
		public interface IEnumIDList
		{
			/// <summary>
			/// Retrieves the specified number of item identifiers in the enumeration sequence and advances the current position by the number of items retrieved.
			/// </summary>
			/// <param name="celt">The number of elements in the array referenced by the rgelt parameter.</param>
			/// <param name="rgelt">
			/// The address of a pointer to an array of ITEMIDLIST pointers that receive the item identifiers. The implementation must allocate these item
			/// identifiers using CoTaskMemAlloc. The calling application is responsible for freeing the item identifiers using CoTaskMemFree.
			/// </param>
			/// <param name="pceltFetched">
			/// A pointer to a value that receives a count of the item identifiers actually returned in rgelt. The count can be smaller than the value specified
			/// in the celt parameter. This parameter can be NULL on entry only if celt = 1, because in that case the method can only retrieve one (S_OK) or zero
			/// (S_FALSE) items.
			/// </param>
			/// <returns>
			/// Returns S_OK if the method successfully retrieved the requested celt elements. This method only returns S_OK if the full count of requested items
			/// are successfully retrieved. S_FALSE indicates that more items were requested than remained in the enumeration.The value pointed to by the
			/// pceltFetched parameter specifies the actual number of items retrieved. Note that the value will be 0 if there are no more items to retrieve.
			/// </returns>
			[PreserveSig]
			HRESULT Next(uint celt, out IntPtr rgelt, out uint pceltFetched);

			/// <summary>Skips the specified number of elements in the enumeration sequence.</summary>
			/// <param name="celt">The number of item identifiers to skip.</param>
			void Skip(uint celt);

			/// <summary>Returns to the beginning of the enumeration sequence.</summary>
			void Reset();

			/// <summary>Creates a new item enumeration object with the same contents and state as the current one.</summary>
			/// <returns>
			/// The address of a pointer to the new enumeration object. The calling application must eventually free the new object by calling its Release member function.
			/// </returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			IEnumIDList Clone();
		}

		/// <summary>Exposes enumeration of IShellItem interfaces. This interface is typically obtained by calling the IEnumShellItems method.</summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("70629033-e363-4a28-a567-0db78006e6d7")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb761962")]
		public interface IEnumShellItems
		{
			/// <summary>Gets an array of one or more IShellItem interfaces from the enumeration.</summary>
			/// <param name="celt">The number of elements in the array referenced by the rgelt parameter.</param>
			/// <param name="rgelt">
			/// The address of an array of pointers to IShellItem interfaces that receive the enumerated item or items. The calling application is responsible
			/// for freeing the IShellItem interfaces by calling the IUnknown::Release method.
			/// </param>
			/// <param name="pceltFetched">
			/// A pointer to a value that receives the number of IShellItem interfaces successfully retrieved. The count can be smaller than the value specified
			/// in the celt parameter. This parameter can be NULL on entry only if celt is one, because in that case the method can only retrieve one item and
			/// return S_OK, or zero items and return S_FALSE.
			/// </param>
			/// <returns>
			/// Returns S_OK if the method successfully retrieved the requested celt elements. This method only returns S_OK if the full count of requested items
			/// are successfully retrieved. S_FALSE indicates that more items were requested than remained in the enumeration. The value pointed to by the
			/// pceltFetched parameter specifies the actual number of items retrieved. Note that the value will be 0 if there are no more items to retrieve.
			/// </returns>
			[PreserveSig]
			HRESULT Next(uint celt, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 2)] IShellItem[] rgelt, out uint pceltFetched);

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

		/// <summary>Exposes methods that enable clients to access items in a collection of objects that support IUnknown.</summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("92CA9DCD-5622-4bba-A805-5E9F541BD8C9")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd378311")]
		public interface IObjectArray
		{
			/// <summary>Provides a count of the objects in the collection.</summary>
			/// <returns>The number of objects in the collection.</returns>
			uint GetCount();

			/// <summary>Provides a pointer to a specified object's interface. The object and interface are specified by index and interface ID.</summary>
			/// <param name="uiIndex">The index of the object</param>
			/// <param name="riid">Reference to the desired interface ID.</param>
			/// <returns>Receives the interface pointer requested in riid.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			object GetAt([In] uint uiIndex, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);
		}

		/// <summary>Extends the IObjectArray interface by providing methods that enable clients to add and remove objects that support IUnknown in a collection.</summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("5632b1a4-e38a-400a-928a-d4cd63230295"), CoClass(typeof(CEnumerableObjectCollection))]
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd378307")]
		public interface IObjectCollection
		{
			/// <summary>Provides a count of the objects in the collection.</summary>
			/// <returns>The number of objects in the collection.</returns>
			uint GetCount();

			/// <summary>Provides a pointer to a specified object's interface. The object and interface are specified by index and interface ID.</summary>
			/// <param name="uiIndex">The index of the object</param>
			/// <param name="riid">Reference to the desired interface ID.</param>
			/// <returns>Receives the interface pointer requested in riid.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			object GetAt([In] uint uiIndex, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			/// <summary>Adds a single object to the collection.</summary>
			/// <param name="punk">Pointer to the IUnknown of the object to be added to the collection.</param>
			void AddObject([In, MarshalAs(UnmanagedType.Interface)] object punk);

			/// <summary>Adds the objects contained in an IObjectArray to the collection.</summary>
			/// <param name="poaSource">Pointer to the IObjectArray whose contents are to be added to the collection.</param>
			void AddFromArray(IObjectArray poaSource);

			/// <summary>Removes a single, specified object from the collection.</summary>
			/// <param name="uiIndex">A pointer to the index of the object within the collection.</param>
			void RemoveObjectAt(uint uiIndex);

			/// <summary>Removes all objects from the collection.</summary>
			void Clear();
		}

		/// <summary>
		/// Exposes methods that allow implementers of a custom IAssocHandler object to provide access to its explicit Application User Model ID
		/// (AppUserModelID). This information is used to determine whether a particular file type can be added to an application's Jump List.
		/// </summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("36db0196-9665-46d1-9ba7-d3709eecf9ed")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd378302")]
		public interface IObjectWithAppUserModelId
		{
			/// <summary>Sets the application identifier.</summary>
			/// <param name="pszAppID">The PSZ application identifier.</param>
			void SetAppID([MarshalAs(UnmanagedType.LPWStr)] string pszAppID);

			/// <summary>Retrieves a file type handler's explicit Application User Model ID (AppUserModelID), if one has been declared.</summary>
			/// <returns></returns>
			SafeCoTaskMemString GetAppID();
		}

		/// <summary>Exposes methods that provide access to the ProgID associated with an object.</summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("71e806fb-8dee-46fc-bf8c-7748a8a1ae13")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd378294")]
		public interface IObjectWithProgId
		{
			/// <summary>Sets the ProgID of an object.</summary>
			/// <param name="pszProgID">A pointer to a string that contains the new ProgID.</param>
			void SetProgID([MarshalAs(UnmanagedType.LPWStr)] string pszProgID);

			/// <summary>Retrieves the ProgID associated with an object.</summary>
			/// <returns>A pointer to a string that, when this method returns successfully, contains the ProgID.</returns>
			SafeCoTaskMemString GetProgID();
		}

		/// <summary>
		/// Exposes methods that the Shell uses to retrieve flags and info tip information for an item that resides in an IShellFolder implementation. Info tips
		/// are usually displayed inside a tooltip control.
		/// </summary>
		[ComImport, Guid("00021500-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb761359")]
		public interface IQueryInfo
		{
			/// <summary>Gets the information tip.</summary>
			/// <param name="dwFlags">
			/// Flags that direct the handling of the item from which you're retrieving the info tip text. This value is commonly zero (QITIPF_DEFAULT).
			/// </param>
			/// <param name="ppwszTip">The address of a Unicode string pointer that, when this method returns successfully, receives the tip string pointer. Applications that implement
			/// this method must allocate memory for ppwszTip by calling CoTaskMemAlloc. Calling applications must call CoTaskMemFree to free the memory when it
			/// is no longer needed.
			/// </param>>
			void GetInfoTip(QITIP dwFlags, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string ppwszTip);

			/// <summary>Gets the information flags for an item. This method is not currently used.</summary>
			/// <returns>A pointer to a value that receives the flags for the item. If no flags are to be returned, this value should be set to zero.</returns>
			uint GetInfoFlags();
		}

		/// <summary>Exposed by all Shell namespace folder objects, its methods are used to manage folders.</summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("000214E6-0000-0000-C000-000000000046")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb775075")]
		public interface IShellFolder
		{
			/// <summary>Translates the display name of a file object or a folder into an item identifier list.</summary>
			/// <param name="hwnd">
			/// A window handle. The client should provide a window handle if it displays a dialog or message box. Otherwise set hwnd to NULL
			/// </param>
			/// <param name="pbc">
			/// Optional. A pointer to a bind context used to pass parameters as inputs and outputs to the parsing function. These passed parameters are often
			/// specific to the data source and are documented by the data source owners. For example, the file system data source accepts the name being parsed
			/// (as a WIN32_FIND_DATA structure), using the STR_FILE_SYS_BIND_DATA bind context parameter. STR_PARSE_PREFER_FOLDER_BROWSING can be passed to
			/// indicate that URLs are parsed using the file system data source when possible. Construct a bind context object using CreateBindCtx and populate
			/// the values using IBindCtx::RegisterObjectParam. See Bind Context String Keys for a complete list of these. If no data is being passed to or
			/// received from the parsing function, this value can be NULL.
			/// </param>
			/// <param name="pszDisplayName">
			/// A null-terminated Unicode string with the display name. Because each Shell folder defines its own parsing syntax, the form this string can take
			/// may vary. The desktop folder, for instance, accepts paths such as "C:\My Docs\My File.txt". It also will accept references to items in the
			/// namespace that have a GUID associated with them using the "::{GUID}" syntax.
			/// </param>
			/// <param name="pchEaten">
			/// A pointer to a ULONG value that receives the number of characters of the display name that was parsed. If your application does not need this
			/// information, set pchEaten to NULL, and no value will be returned.
			/// </param>
			/// <param name="ppidl">
			/// When this method returns, contains a pointer to the PIDL for the object. The returned item identifier list specifies the item relative to the
			/// parsing folder. If the object associated with pszDisplayName is within the parsing folder, the returned item identifier list will contain only
			/// one SHITEMID structure. If the object is in a subfolder of the parsing folder, the returned item identifier list will contain multiple SHITEMID
			/// structures. If an error occurs, NULL is returned in this address.
			/// <para>When it is no longer needed, it is the responsibility of the caller to free this resource by calling CoTaskMemFree.</para>
			/// </param>
			/// <param name="pdwAttributes">
			/// The value used to query for file attributes. If not used, it should be set to NULL. To query for one or more attributes, initialize this
			/// parameter with the SFGAO flags that represent the attributes of interest. On return, those attributes that are true and were requested will be set.
			/// </param>
			void ParseDisplayName(IntPtr hwnd, [In, Optional] IBindCtx pbc, [MarshalAs(UnmanagedType.LPWStr)] string pszDisplayName, out uint pchEaten, out PIDL ppidl, [In, Out] ref SFGAO pdwAttributes);

			/// <summary>
			/// Enables a client to determine the contents of a folder by creating an item identifier enumeration object and returning its IEnumIDList interface.
			/// The methods supported by that interface can then be used to enumerate the folder's contents.
			/// </summary>
			/// <param name="hwnd">
			/// If user input is required to perform the enumeration, this window handle should be used by the enumeration object as the parent window to take
			/// user input. An example would be a dialog box to ask for a password or prompt the user to insert a CD or floppy disk. If hwndOwner is set to NULL,
			/// the enumerator should not post any messages, and if user input is required, it should silently fail.
			/// </param>
			/// <param name="grfFlags">
			/// Flags indicating which items to include in the enumeration. For a list of possible values, see the SHCONTF enumerated type.
			/// </param>
			/// <returns>
			/// The address that receives a pointer to the IEnumIDList interface of the enumeration object created by this method. If an error occurs or no
			/// suitable subobjects are found, ppenumIDList is set to NULL.
			/// </returns>
			IEnumIDList EnumObjects(IntPtr hwnd, SHCONTF grfFlags);

			/// <summary>
			/// Retrieves a handler, typically the Shell folder object that implements IShellFolder for a particular item. Optional parameters that control the
			/// construction of the handler are passed in the bind context.
			/// </summary>
			/// <param name="pidl">
			/// The address of an ITEMIDLIST structure (PIDL) that identifies the subfolder. This value can refer to an item at any level below the parent folder
			/// in the namespace hierarchy. The structure contains one or more SHITEMID structures, followed by a terminating NULL.
			/// </param>
			/// <param name="pbc">
			/// A pointer to an IBindCtx interface on a bind context object that can be used to pass parameters to the construction of the handler. If this
			/// parameter is not used, set it to NULL. Because support for this parameter is optional for folder object implementations, some folders may not
			/// support the use of bind contexts.
			/// <para>
			/// Information that can be provided in the bind context includes a BIND_OPTS structure that includes a grfMode member that indicates the access mode
			/// when binding to a stream handler. Other parameters can be set and discovered using IBindCtx::RegisterObjectParam and IBindCtx::GetObjectParam.
			/// </para>
			/// </param>
			/// <param name="riid">
			/// The identifier of the interface to return. This may be IID_IShellFolder, IID_IStream, or any other interface that identifies a particular handler.
			/// </param>
			/// <returns>
			/// When this method returns, contains the address of a pointer to the requested interface. If an error occurs, a NULL pointer is returned at this address.
			/// </returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			object BindToObject([In] PIDL pidl, [In, Optional] IBindCtx pbc, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			/// <summary>Requests a pointer to an object's storage interface.</summary>
			/// <param name="pidl">
			/// The address of an ITEMIDLIST structure that identifies the subfolder relative to its parent folder. The structure must contain exactly one
			/// SHITEMID structure followed by a terminating zero.
			/// </param>
			/// <param name="pbc">
			/// The optional address of an IBindCtx interface on a bind context object to be used during this operation. If this parameter is not used, set it to
			/// NULL. Because support for pbc is optional for folder object implementations, some folders may not support the use of bind contexts.
			/// </param>
			/// <param name="riid">
			/// The IID of the requested storage interface. To retrieve an IStream, IStorage, or IPropertySetStorage interface pointer, set riid to IID_IStream,
			/// IID_IStorage, or IID_IPropertySetStorage, respectively.
			/// </param>
			/// <returns>The address that receives the interface pointer specified by riid. If an error occurs, a NULL pointer is returned in this address.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			object BindToStorage([In] PIDL pidl, [In, Optional] IBindCtx pbc, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			/// <summary>Determines the relative order of two file objects or folders, given their item identifier lists.</summary>
			/// <param name="lParam">
			/// A value that specifies how the comparison should be performed.
			/// <para>
			/// The lower sixteen bits of lParam define the sorting rule. Most applications set the sorting rule to the default value of zero, indicating that
			/// the two items should be compared by name. The system does not define any other sorting rules. Some folder objects might allow calling
			/// applications to use the lower sixteen bits of lParam to specify folder-specific sorting rules. The rules and their associated lParam values are
			/// defined by the folder.
			/// </para>
			/// <para>
			/// When the system folder view object calls IShellFolder::CompareIDs, the lower sixteen bits of lParam are used to specify the column to be used for
			/// the comparison.
			/// </para>
			/// <para>The upper sixteen bits of lParam are used for flags that modify the sorting rule. The system currently defines these modifier flags.</para>
			/// <list>
			/// <item>
			/// <term>SHCIDS_ALLFIELDS</term>
			/// <description>
			/// Version 5.0. Compare all the information contained in the ITEMIDLIST structure, not just the display names. This flag is valid only for folder
			/// objects that support the IShellFolder2 interface. For instance, if the two items are files, the folder should compare their names, sizes, file
			/// times, attributes, and any other information in the structures. If this flag is set, the lower sixteen bits of lParam must be zero.
			/// </description>
			/// </item>
			/// <item>
			/// <term>SHCIDS_CANONICALONLY</term>
			/// <description>
			/// Version 5.0. When comparing by name, compare the system names but not the display names. When this flag is passed, the two items are compared by
			/// whatever criteria the Shell folder determines are most efficient, as long as it implements a consistent sort function. This flag is useful when
			/// comparing for equality or when the results of the sort are not displayed to the user. This flag cannot be combined with other flags.
			/// </description>
			/// </item>
			/// </list>
			/// </param>
			/// <param name="pidl1">
			/// A pointer to the first item's ITEMIDLIST structure. It will be relative to the folder. This ITEMIDLIST structure can contain more than one
			/// element; therefore, the entire structure must be compared, not just the first element.
			/// </param>
			/// <param name="pidl2">
			/// A pointer to the second item's ITEMIDLIST structure. It will be relative to the folder. This ITEMIDLIST structure can contain more than one
			/// element; therefore, the entire structure must be compared, not just the first element.
			/// </param>
			/// <returns>
			/// If this method is successful, the CODE field of the HRESULT contains one of the following values. For information regarding the extraction of the
			/// CODE field from the returned HRESULT, see Remarks. If this method is unsuccessful, it returns a COM error code.
			/// </returns>
			[PreserveSig]
			HRESULT CompareIDs(IntPtr lParam, [In] PIDL pidl1, [In] PIDL pidl2);

			/// <summary>Requests an object that can be used to obtain information from or interact with a folder object.</summary>
			/// <param name="hwndOwner">
			/// A handle to the owner window. If you have implemented a custom folder view object, your folder view window should be created as a child of hwndOwner.
			/// </param>
			/// <param name="riid">A reference to the IID of the interface to retrieve through ppv, typically IID_IShellView.</param>
			/// <returns>
			/// When this method returns successfully, contains the interface pointer requested in riid. This is typically IShellView. See the Remarks section
			/// for more details.
			/// </returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			object CreateViewObject(IntPtr hwndOwner, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			/// <summary>Gets the attributes of one or more file or folder objects contained in the object represented by IShellFolder.</summary>
			/// <param name="cidl">The number of items from which to retrieve attributes.</param>
			/// <param name="apidl">
			/// The address of an array of pointers to ITEMIDLIST structures, each of which uniquely identifies an item relative to the parent folder. Each
			/// ITEMIDLIST structure must contain exactly one SHITEMID structure followed by a terminating zero.
			/// </param>
			/// <param name="rgfInOut">
			/// Pointer to a single ULONG value that, on entry, contains the bitwise SFGAO attributes that the calling application is requesting. On exit, this
			/// value contains the requested attributes that are common to all of the specified items.
			/// </param>
			void GetAttributesOf(uint cidl, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] IntPtr[] apidl, ref SFGAO rgfInOut);

			/// <summary>Gets an object that can be used to carry out actions on the specified file objects or folders.</summary>
			/// <param name="hwndOwner">A handle to the owner window that the client should specify if it displays a dialog box or message box.</param>
			/// <param name="cidl">The number of file objects or subfolders specified in the apidl parameter.</param>
			/// <param name="apidl">
			/// The address of an array of pointers to ITEMIDLIST structures, each of which uniquely identifies a file object or subfolder relative to the parent
			/// folder. Each item identifier list must contain exactly one SHITEMID structure followed by a terminating zero.
			/// </param>
			/// <param name="riid">
			/// A reference to the IID of the interface to retrieve through ppv. This can be any valid interface identifier that can be created for an item. The
			/// most common identifiers used by the Shell are listed in the comments at the end of this reference.
			/// </param>
			/// <param name="rgfReserved">Reserved.</param>
			/// <returns>When this method returns successfully, contains the interface pointer requested in riid.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			object GetUIObjectOf(IntPtr hwndOwner, uint cidl, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] IntPtr[] apidl, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid, IntPtr rgfReserved = default(IntPtr));

			/// <summary>Retrieves the display name for the specified file object or subfolder.</summary>
			/// <param name="pidl">PIDL that uniquely identifies the file object or subfolder relative to the parent folder.</param>
			/// <param name="uFlags">Flags used to request the type of display name to return. For a list of possible values, see the SHGDNF enumerated type.</param>
			/// <returns>
			/// When this method returns, contains a pointer to a STRRET structure in which to return the display name. The type of name returned in this
			/// structure can be the requested type, but the Shell folder might return a different type.
			/// </returns>
			[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(STRRETMarshaler))]
			string GetDisplayNameOf([In] PIDL pidl, SHGDNF uFlags);

			/// <summary>Sets the display name of a file object or subfolder, changing the item identifier in the process.</summary>
			/// <param name="hwnd">A handle to the owner window of any dialog or message box that the client displays.</param>
			/// <param name="pidl">
			/// A pointer to an ITEMIDLIST structure that uniquely identifies the file object or subfolder relative to the parent folder. The structure must
			/// contain exactly one SHITEMID structure followed by a terminating zero.
			/// </param>
			/// <param name="pszName">A pointer to a null-terminated string that specifies the new display name.</param>
			/// <param name="uFlags">
			/// Flags that indicate the type of name specified by the pszName parameter. For a list of possible values and combinations of values, see SHGDNF.
			/// </param>
			/// <param name="ppidlOut">
			/// Optional. If specified, the address of a pointer to an ITEMIDLIST structure that receives the ITEMIDLIST of the renamed item. The caller requests
			/// this value by passing a non-null ppidlOut. Implementations of IShellFolder::SetNameOf must return a pointer to the new ITEMIDLIST in the ppidlOut parameter.
			/// </param>
			void SetNameOf(IntPtr hwnd, [In] PIDL pidl, [MarshalAs(UnmanagedType.LPWStr)] string pszName, SHGDNF uFlags, out PIDL ppidlOut);
		}

		/// <summary>
		/// Exposes methods that retrieve information about a Shell item. IShellItem and IShellItem2 are the preferred representations of items in any new code.
		/// </summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("43826d1e-e718-42ee-bc55-a1e261c37bfe")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb761144")]
		public interface IShellItem
		{
			/// <summary>Binds to a handler for an item as specified by the handler ID value (BHID).</summary>
			/// <param name="pbc">
			/// A pointer to an IBindCtx interface on a bind context object. Used to pass optional parameters to the handler. The contents of the bind context
			/// are handler-specific. For example, when binding to BHID_Stream, the STGM flags in the bind context indicate the mode of access desired (read or read/write).
			/// </param>
			/// <param name="bhid">Reference to a GUID that specifies which handler will be created.</param>
			/// <param name="riid">IID of the object type to retrieve.</param>
			/// <returns>When this method returns, contains a pointer of type riid that is returned by the handler specified by rbhid.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			object BindToHandler(IBindCtx pbc, [In, MarshalAs(UnmanagedType.LPStruct)] Guid bhid, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			/// <summary>Gets the parent of an IShellItem object.</summary>
			/// <returns>The address of a pointer to the parent of an IShellItem interface.</returns>
			IShellItem GetParent();

			/// <summary>Gets the display name of the IShellItem object.</summary>
			/// <param name="sigdnName">One of the SIGDN values that indicates how the name should look.</param>
			/// <returns>A value that, when this function returns successfully, receives the address of a pointer to the retrieved display name.</returns>
			SafeCoTaskMemString GetDisplayName(SIGDN sigdnName);

			/// <summary>Gets a requested set of attributes of the IShellItem object.</summary>
			/// <param name="sfgaoMask">
			/// Specifies the attributes to retrieve. One or more of the SFGAO values. Use a bitwise OR operator to determine the attributes to retrieve.
			/// </param>
			/// <returns>
			/// A pointer to a value that, when this method returns successfully, contains the requested attributes. One or more of the SFGAO values. Only those
			/// attributes specified by sfgaoMask are returned; other attribute values are undefined.
			/// </returns>
			SFGAO GetAttributes(SFGAO sfgaoMask);

			/// <summary>Compares two IShellItem objects.</summary>
			/// <param name="psi">A pointer to an IShellItem object to compare with the existing IShellItem object.</param>
			/// <param name="hint">
			/// One of the SICHINTF values that determines how to perform the comparison. See SICHINTF for the list of possible values for this parameter.
			/// </param>
			/// <returns>
			/// This parameter receives the result of the comparison. If the two items are the same this parameter equals zero; if they are different the
			/// parameter is nonzero.
			/// </returns>
			int Compare(IShellItem psi, SICHINTF hint);
		}

		/// <summary>
		/// Extends IShellItem with methods that retrieve various property values of the item. IShellItem and IShellItem2 are the preferred representations of
		/// items in any new code.
		/// </summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("7e9fb0d3-919f-4307-ab2e-9b1860310c93")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb761130")]
		public interface IShellItem2 : IShellItem
		{
			/// <summary>Binds to a handler for an item as specified by the handler ID value (BHID).</summary>
			/// <param name="pbc">
			/// A pointer to an IBindCtx interface on a bind context object. Used to pass optional parameters to the handler. The contents of the bind context
			/// are handler-specific. For example, when binding to BHID_Stream, the STGM flags in the bind context indicate the mode of access desired (read or read/write).
			/// </param>
			/// <param name="bhid">Reference to a GUID that specifies which handler will be created.</param>
			/// <param name="riid">IID of the object type to retrieve.</param>
			/// <returns>When this method returns, contains a pointer of type riid that is returned by the handler specified by rbhid.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			new object BindToHandler(IBindCtx pbc, [In, MarshalAs(UnmanagedType.LPStruct)] Guid bhid, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			/// <summary>Gets the parent of an IShellItem object.</summary>
			/// <returns>The address of a pointer to the parent of an IShellItem interface.</returns>
			new IShellItem GetParent();

			/// <summary>Gets the display name of the IShellItem object.</summary>
			/// <param name="sigdnName">One of the SIGDN values that indicates how the name should look.</param>
			/// <returns>A value that, when this function returns successfully, receives the address of a pointer to the retrieved display name.</returns>
			new SafeCoTaskMemString GetDisplayName(SIGDN sigdnName);

			/// <summary>Gets a requested set of attributes of the IShellItem object.</summary>
			/// <param name="sfgaoMask">
			/// Specifies the attributes to retrieve. One or more of the SFGAO values. Use a bitwise OR operator to determine the attributes to retrieve.
			/// </param>
			/// <returns>
			/// A pointer to a value that, when this method returns successfully, contains the requested attributes. One or more of the SFGAO values. Only those
			/// attributes specified by sfgaoMask are returned; other attribute values are undefined.
			/// </returns>
			new SFGAO GetAttributes(SFGAO sfgaoMask);

			/// <summary>Compares two IShellItem objects.</summary>
			/// <param name="psi">A pointer to an IShellItem object to compare with the existing IShellItem object.</param>
			/// <param name="hint">
			/// One of the SICHINTF values that determines how to perform the comparison. See SICHINTF for the list of possible values for this parameter.
			/// </param>
			/// <returns>
			/// This parameter receives the result of the comparison. If the two items are the same this parameter equals zero; if they are different the
			/// parameter is nonzero.
			/// </returns>
			new int Compare(IShellItem psi, SICHINTF hint);

			/// <summary>Gets a property store object for specified property store flags.</summary>
			/// <param name="flags">The GETPROPERTYSTOREFLAGS constants that modify the property store object.</param>
			/// <param name="riid">A reference to the IID of the object to be retrieved.</param>
			/// <returns>When this method returns, contains the address of an IPropertyStore interface pointer.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			IPropertyStore GetPropertyStore(GETPROPERTYSTOREFLAGS flags, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			/// <summary>
			/// Uses the specified ICreateObject instead of CoCreateInstance to create an instance of the property handler associated with the Shell item on
			/// which this method is called. Most calling applications do not need to call this method, and can call IShellItem2::GetPropertyStore instead.
			/// </summary>
			/// <param name="flags">The GETPROPERTYSTOREFLAGS constants that modify the property store object.</param>
			/// <param name="punkCreateObject">
			/// A pointer to a factory for low-rights creation of type ICreateObject.
			/// <para>
			/// The method CreateObject creates an instance of a COM object. The implementation of IShellItem2::GetPropertyStoreWithCreateObject uses
			/// CreateObject instead of CoCreateInstance to create the property handler, which is a Shell extension, for a given file type. The property handler
			/// provides many of the important properties in the property store that this method returns.
			/// </para>
			/// <para>
			/// This method is useful only if the ICreateObject object is created in a separate process (as a LOCALSERVER instead of an INPROCSERVER), and also
			/// if this other process has lower rights than the process calling IShellItem2::GetPropertyStoreWithCreateObject.
			/// </para>
			/// </param>
			/// <param name="riid">A reference to the IID of the object to be retrieved.</param>
			/// <returns>When this method returns, contains the address of the requested IPropertyStore interface pointer.</returns>
			// TODO: Create ICreateObject for second param
			[return: MarshalAs(UnmanagedType.Interface)]
			IPropertyStore GetPropertyStoreWithCreateObject(GETPROPERTYSTOREFLAGS flags, [MarshalAs(UnmanagedType.IUnknown)] object punkCreateObject,
				[In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			/// <summary>Gets property store object for specified property keys.</summary>
			/// <param name="rgKeys">
			/// A pointer to an array of PROPERTYKEY structures. Each structure contains a unique identifier for each property used in creating the property store.
			/// </param>
			/// <param name="cKeys">The number of PROPERTYKEY structures in the array pointed to by rgKeys.</param>
			/// <param name="flags">The GETPROPERTYSTOREFLAGS constants that modify the property store object.</param>
			/// <param name="riid">A reference to the IID of the object to be retrieved.</param>
			/// <returns></returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			IPropertyStore GetPropertyStoreForKeys([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] PROPERTYKEY[] rgKeys, uint cKeys, GETPROPERTYSTOREFLAGS flags, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			/// <summary>Gets a property description list object given a reference to a property key.</summary>
			/// <param name="keyType">A reference to a PROPERTYKEY structure.</param>
			/// <param name="riid">A reference to a desired IID.</param>
			/// <returns>Contains the address of an IPropertyDescriptionList interface pointer.</returns>
			IPropertyDescriptionList GetPropertyDescriptionList([In] ref PROPERTYKEY keyType, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			/// <summary>Ensures that any cached information in this item is updated.</summary>
			/// <param name="pbc">A pointer to an IBindCtx interface on a bind context object.</param>
			void Update(IBindCtx pbc);

			/// <summary>Gets a PROPVARIANT structure from a specified property key.</summary>
			/// <param name="key">A reference to a PROPERTYKEY structure.</param>
			/// <returns>Contains a pointer to a PROPVARIANT structure.</returns>
			PROPVARIANT GetProperty([In] ref PROPERTYKEY key);

			/// <summary>Gets the class identifier (CLSID) value of specified property key.</summary>
			/// <param name="key">A reference to a PROPERTYKEY structure.</param>
			/// <returns>A pointer to a CLSID value.</returns>
			Guid GetCLSID([In] ref PROPERTYKEY key);

			/// <summary>Gets the date and time value of a specified property key.</summary>
			/// <param name="key">A reference to a PROPERTYKEY structure.</param>
			/// <returns>A pointer to a date and time value.</returns>
			FILETIME GetFileTime([In] ref PROPERTYKEY key);

			/// <summary>Gets the Int32 value of specified property key.</summary>
			/// <param name="key">A reference to a PROPERTYKEY structure.</param>
			/// <returns>A pointer to an Int32 value.</returns>
			int GetInt32([In] ref PROPERTYKEY key);

			/// <summary>Gets the string value of a specified property key.</summary>
			/// <param name="key">A reference to a PROPERTYKEY structure.</param>
			/// <returns>A pointer to a Unicode string value.</returns>
			SafeCoTaskMemString GetString([In] ref PROPERTYKEY key);

			/// <summary>Gets the UInt32 value of specified property key.</summary>
			/// <param name="key">A reference to a PROPERTYKEY structure.</param>
			/// <returns>A pointer to an UInt32 value.</returns>
			uint GetUInt32([In] ref PROPERTYKEY key);

			/// <summary>Gets the UInt64 value of specified property key.</summary>
			/// <param name="key">A reference to a PROPERTYKEY structure.</param>
			/// <returns>A pointer to an UInt64 value.</returns>
			ulong GetUInt64([In] ref PROPERTYKEY key);

			/// <summary>Gets the boolean value of a specified property key.</summary>
			/// <param name="key">A reference to a PROPERTYKEY structure.</param>
			/// <returns>A pointer to a boolean value.</returns>
			[return: MarshalAs(UnmanagedType.Bool)]
			bool GetBool([In] ref PROPERTYKEY key);
		}

		/// <summary>Exposes methods that create and manipulate Shell item arrays.</summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("B63EA76D-1F85-456F-A19C-48159EFA858B")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb761106")]
		public interface IShellItemArray
		{
			/// <summary>Binds to an object by means of the specified handler.</summary>
			/// <param name="pbc">A pointer to an IBindCtx interface on a bind context object.</param>
			/// <param name="rbhid">One of the following values, defined in Shlguid.h, that determine the handler.
			/// <list>
			/// <item><term>BHID_SFUIObject</term><description>Restricts usage to GetUIObjectOf. Use this handler type only for a flat item array, where all items are in the same folder.</description></item>
			/// <item><term>BHID_DataObject</term><description>Introduced in Windows Vista: Gets an IDataObject object for use with an item or an array of items. Use this handler type only for flat data objects or item arrays created by SHCreateShellItemArrayFromDataObject.</description></item>
			/// <item><term>BHID_AssociationArray</term><description>Introduced in Windows Vista: Gets an IQueryAssociations object for use with an item or an array of items. This only retrieves the association array object for the first item in the IShellItemArray</description></item>
			/// </list></param>
			/// <param name="riid">The IID of the object type to retrieve.</param>
			/// <returns>When this /// methods returns, contains the object specified in riid that is returned by the handler specified by rbhid.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			object BindToHandler(IBindCtx pbc, [In, MarshalAs(UnmanagedType.LPStruct)] Guid rbhid, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			/// <summary>Gets a property store.</summary>
			/// <param name="flags">One of the GETPROPERTYSTOREFLAGS constants.</param>
			/// <param name="riid">The IID of the object type to retrieve.</param>
			/// <returns>When this method returns, contains interface pointer requested in riid. This is typically IPropertyStore or IPropertyStoreCapabilities.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			object GetPropertyStore(GETPROPERTYSTOREFLAGS flags, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			/// <summary>Gets a property description list for the items in the shell item array.</summary>
			/// <param name="keyType">A reference to the PROPERTYKEY structure specifying which property list to retrieve.</param>
			/// <param name="riid">The IID of the object type to retrieve.</param>
			/// <returns>When this method returns, contains the interface requested in riid. This will typically be IPropertyDescriptionList.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			object GetPropertyDescriptionList([In] ref PROPERTYKEY keyType, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			/// <summary>
			/// Gets the attributes of the set of items contained in an IShellItemArray. If the array contains more than one item, the attributes retrieved by
			/// this method are not the attributes of single items, but a logical combination of all of the requested attributes of all of the items.
			/// </summary>
			/// <param name="dwAttribFlags">
			/// If the array contains a single item, this method provides the same results as GetAttributes. However, if the array contains multiple items, the
			/// attribute sets of all the items are combined into a single attribute set and returned in the value pointed to by psfgaoAttribs. This parameter
			/// takes one of the following values to define how that final attribute set is determined:
			/// </param>
			/// <param name="sfgaoMask">A mask that specifies what particular attributes are being requested. A bitwise OR of one or more of the SFGAO values.</param>
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
			/// <returns>When this method returns, contains an IEnumShellItems pointer that enumerates the shell items that are in the array.</returns>
			IEnumShellItems EnumItems();
		}

		/// <summary>Retrieves the User Model AppID that has been explicitly set for the current process via SetCurrentProcessExplicitAppUserModelID</summary>
		/// <param name="AppID">The application identifier.</param>
		/// <returns></returns>
		[DllImport(Lib.Shell32, ExactSpelling = true)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd378419")]
		public static extern HRESULT GetCurrentProcessExplicitAppUserModelID([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string AppID);

		/// <summary>Clones an ITEMIDLIST structure.</summary>
		/// <param name="pidl">A pointer to the ITEMIDLIST structure to be cloned.</param>
		/// <returns>Returns a pointer to a copy of the ITEMIDLIST structure pointed to by pidl.</returns>
		[DllImport(Lib.Shell32, ExactSpelling = true, SetLastError = false)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb776433")]
		public static extern PIDL ILClone(IntPtr pidl);

		/// <summary>Clones the first SHITEMID structure in an ITEMIDLIST structure.</summary>
		/// <param name="pidl">A pointer to the ITEMIDLIST structure to be cloned.</param>
		/// <returns>
		/// A pointer to an ITEMIDLIST structure that contains the first SHITEMID structure from the ITEMIDLIST structure specified by pidl. Returns NULL on failure.
		/// </returns>
		[DllImport(Lib.Shell32, ExactSpelling = true, SetLastError = false)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb776435")]
		public static extern PIDL ILCloneFirst(IntPtr pidl);

		/// <summary>Combines two ITEMIDLIST structures.</summary>
		/// <param name="pidl1">A pointer to the first ITEMIDLIST structure.</param>
		/// <param name="pidl2">A pointer to the second ITEMIDLIST structure. This structure is appended to the structure pointed to by pidl1.</param>
		/// <returns>
		/// Returns an ITEMIDLIST containing the combined structures. If you set either pidl1 or pidl2 to NULL, the returned ITEMIDLIST structure is a clone of
		/// the non-NULL parameter. Returns NULL if pidl1 and pidl2 are both set to NULL.
		/// </returns>
		[DllImport(Lib.Shell32, ExactSpelling = true, SetLastError = false)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb776437")]
		public static extern PIDL ILCombine(IntPtr pidl1, IntPtr pidl2);

		/// <summary>Returns the ITEMIDLIST structure associated with a specified file path.</summary>
		/// <param name="pszPath">
		/// A pointer to a null-terminated Unicode string that contains the path. This string should be no more than MAX_PATH characters in length, including the
		/// terminating null character.
		/// </param>
		/// <returns>Returns a pointer to an ITEMIDLIST structure that corresponds to the path.</returns>
		[DllImport(Lib.Shell32, CharSet = CharSet.Auto, SetLastError = false)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd378420")]
		public static extern PIDL ILCreateFromPath(string pszPath);

		/// <summary>Returns a pointer to the last SHITEMID structure in an ITEMIDLIST structure.</summary>
		/// <param name="pidl">A pointer to an ITEMIDLIST structure.</param>
		/// <returns>A pointer to the last SHITEMID structure in pidl.</returns>
		[DllImport(Lib.Shell32, ExactSpelling = true, SetLastError = false)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb776440")]
		public static extern IntPtr ILFindLastID(IntPtr pidl);

		/// <summary>Frees an ITEMIDLIST structure allocated by the Shell.</summary>
		/// <param name="pidl">A pointer to the ITEMIDLIST structure to be freed. This parameter can be NULL.</param>
		[DllImport(Lib.Shell32, ExactSpelling = true, SetLastError = false)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb776441")]
		public static extern void ILFree(IntPtr pidl);

		/// <summary>Returns the size, in bytes, of an SHITEMID structure.</summary>
		/// <param name="pidl">A pointer to an SHITEMID structure.</param>
		/// <returns>The size of the SHITEMID structure specified by pidl, in bytes.</returns>
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762502")]
		public static int ILGetItemSize(IntPtr pidl) => pidl.Equals(IntPtr.Zero) ? 0 : Marshal.ReadInt16(pidl);

		/// <summary>Retrieves the next SHITEMID structure in an ITEMIDLIST structure.</summary>
		/// <param name="pidl">A pointer to a particular SHITEMID structure in a larger ITEMIDLIST structure.</param>
		/// <returns>
		/// Returns a pointer to the SHITEMID structure that follows the one specified by pidl. Returns NULL if pidl points to the last SHITEMID structure.
		/// </returns>
		[DllImport(Lib.Shell32, ExactSpelling = true, SetLastError = false)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb776442")]
		public static extern IntPtr ILGetNext(IntPtr pidl);

		/// <summary>Returns the size, in bytes, of an ITEMIDLIST structure.</summary>
		/// <param name="pidl">A pointer to an ITEMIDLIST structure.</param>
		/// <returns>The size of the ITEMIDLIST structure specified by pidl, in bytes.</returns>
		[DllImport(Lib.Shell32, ExactSpelling = true, SetLastError = false)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb776443")]
		public static extern uint ILGetSize(IntPtr pidl);

		/// <summary>Verifies whether a pointer to an item identifier list (PIDL) is a child PIDL, which is a PIDL with exactly one SHITEMID.</summary>
		/// <param name="pidl">A constant, unaligned, relative PIDL that is being checked.</param>
		/// <returns>Returns TRUE if the given PIDL is a child PIDL; otherwise, FALSE.</returns>
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb776446")]
		public static bool ILIsChild(IntPtr pidl) => ILIsEmpty(pidl) || ILIsEmpty(ILNext(pidl));

		/// <summary>Verifies whether an ITEMIDLIST structure is empty.</summary>
		/// <param name="pidl">A pointer to the ITEMIDLIST structure to be checked.</param>
		/// <returns>TRUE if the pidl parameter is NULL or the ITEMIDLIST structure pointed to by pidl is empty; otherwise FALSE.</returns>
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb776447")]
		public static bool ILIsEmpty(IntPtr pidl) => ILGetItemSize(pidl) == 0;

		/// <summary>Tests whether two ITEMIDLIST structures are equal in a binary comparison.</summary>
		/// <param name="pidl1">The first ITEMIDLIST structure.</param>
		/// <param name="pidl2">The second ITEMIDLIST structure.</param>
		/// <returns>Returns TRUE if the two structures are equal, FALSE otherwise.</returns>
		[DllImport(Lib.Shell32, ExactSpelling = true, SetLastError = false)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb776448")]
		public static extern bool ILIsEqual(IntPtr pidl1, IntPtr pidl2);

		/// <summary>Tests whether an ITEMIDLIST structure is the parent of another ITEMIDLIST structure.</summary>
		/// <param name="pidl1">A pointer to an ITEMIDLIST (PIDL) structure that specifies the parent. This must be an absolute PIDL.</param>
		/// <param name="pidl2">A pointer to an ITEMIDLIST (PIDL) structure that specifies the child. This must be an absolute PIDL.</param>
		/// <param name="fImmediate">A Boolean value that is set to TRUE to test for immediate parents of pidl2, or FALSE to test for any parents of pidl2.</param>
		/// <returns>
		/// Returns TRUE if pidl1 is a parent of pidl2. If fImmediate is set to TRUE, the function only returns TRUE if pidl1 is the immediate parent of pidl2.
		/// Otherwise, the function returns FALSE.
		/// </returns>
		[DllImport(Lib.Shell32, ExactSpelling = true, SetLastError = false)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb776449")]
		public static extern bool ILIsParent(IntPtr pidl1, IntPtr pidl2, [MarshalAs(UnmanagedType.Bool)] bool fImmediate);

		/// <summary>Retrieves the next SHITEMID structure in an ITEMIDLIST structure.</summary>
		/// <param name="pidl">A constant, unaligned, relative PIDL for which the next SHITEMID structure is being retrieved.</param>
		/// <returns>
		/// When this function returns, contains one of three results: If pidl is valid and not the last SHITEMID in the ITEMIDLIST, then it contains a pointer
		/// to the next ITEMIDLIST structure. If the last ITEMIDLIST structure is passed, it contains NULL, which signals the end of the PIDL. For other values
		/// of pidl, the return value is meaningless.
		/// </returns>
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb776454")]
		public static IntPtr ILNext(IntPtr pidl)
		{
			var size = ILGetItemSize(pidl);
			return size == 0 ? IntPtr.Zero : pidl.Offset(size);
		}

		/// <summary>Removes the last SHITEMID structure from an ITEMIDLIST structure.</summary>
		/// <param name="pidl">A pointer to the ITEMIDLIST structure to be shortened. When the function returns, this variable points to the shortened structure.</param>
		/// <returns>Returns TRUE if successful, FALSE otherwise.</returns>
		[DllImport(Lib.Shell32, ExactSpelling = true, SetLastError = false)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb776456")]
		public static extern bool ILRemoveLastID(IntPtr pidl);

		/// <summary>Returns the ITEMIDLIST structure associated with a specified file path.</summary>
		/// <param name="pszPath">
		/// A pointer to a null-terminated Unicode string that contains the path. This string should be no more than MAX_PATH characters in length, including the
		/// terminating null character.
		/// </param>
		/// <returns>Returns a pointer to an ITEMIDLIST structure that corresponds to the path.</returns>
		[DllImport(Lib.Shell32, EntryPoint = "ILCreateFromPathW", SetLastError = true)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd378420")]
		public static extern IntPtr IntILCreateFromPath([MarshalAs(UnmanagedType.LPWStr)] string pszPath);

		/// <summary>
		/// Specifies a unique application-defined Application User Model ID (AppUserModelID) that identifies the current process to the taskbar. This identifier
		/// allows an application to group its associated processes and windows under a single taskbar button.
		/// </summary>
		/// <param name="AppID">Pointer to the AppUserModelID to assign to the current process.</param>
		[DllImport(Lib.Shell32, ExactSpelling = true)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd378422")]
		public static extern HRESULT SetCurrentProcessExplicitAppUserModelID([MarshalAs(UnmanagedType.LPWStr)] string AppID);

		/// <summary>
		/// Creates and initializes a Shell item object from a pointer to an item identifier list (PIDL). The resulting shell item object supports the IShellItem interface.
		/// </summary>
		/// <param name="pidl">The source PIDL.</param>
		/// <param name="riid">A reference to the IID of the requested interface.</param>
		/// <param name="ppv">When this function returns, contains the interface pointer requested in riid. This will typically be IShellItem or IShellItem2.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.Shell32, ExactSpelling = true)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762133")]
		public static extern HRESULT SHCreateItemFromIDList(PIDL pidl, [MarshalAs(UnmanagedType.LPStruct)] Guid riid, [MarshalAs(UnmanagedType.Interface)] out object ppv);

		/// <summary>Creates and initializes a Shell item object from a parsing name.</summary>
		/// <param name="pszPath">A pointer to a display name.</param>
		/// <param name="pbc">Optional. A pointer to a bind context used to pass parameters as inputs and outputs to the parsing function. These passed parameters are often specific to the data source and are documented by the data source owners. For example, the file system data source accepts the name being parsed (as a WIN32_FIND_DATA structure), using the STR_FILE_SYS_BIND_DATA bind context parameter.
		/// <para>STR_PARSE_PREFER_FOLDER_BROWSING can be passed to indicate that URLs are parsed using the file system data source when possible.Construct a bind context object using CreateBindCtx and populate the values using IBindCtx::RegisterObjectParam. See Bind Context String Keys for a complete list of these.See the Parsing With Parameters Sample for an example of the use of this parameter.</para>
		/// <para>If no data is being passed to or received from the parsing function, this value can be NULL.</para></param>
		/// <param name="riid">A reference to the IID of the interface to retrieve through ppv, typically IID_IShellItem or IID_IShellItem2.</param>
		/// <param name="ppv">When this method returns successfully, contains the interface pointer requested in riid. This is typically IShellItem or IShellItem2.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.Shell32, ExactSpelling = true)]
		[PInvokeData("Shlobjidl.h", MSDNShortId = "bb762134")]
		public static extern HRESULT SHCreateItemFromParsingName(
			[In, MarshalAs(UnmanagedType.LPWStr)] string pszPath,
			[In, Optional] IBindCtx pbc,
			[In, MarshalAs(UnmanagedType.LPStruct)] Guid riid,
			[MarshalAs(UnmanagedType.Interface, IidParameterIndex = 2)] out object ppv);

		/// <summary>Creates and initializes a Shell item object from a relative parsing name.</summary>
		/// <param name="psiParent">A pointer to the parent Shell item.</param>
		/// <param name="pszName">A pointer to a null-terminated, Unicode string that specifies a display name that is relative to the psiParent.</param>
		/// <param name="pbc">A pointer to a bind context that controls the parsing operation. This parameter can be NULL.</param>
		/// <param name="riid">A reference to an interface ID.</param>
		/// <param name="ppv">When this function returns, contains the interface pointer requested in riid. This will usually be IShellItem or IShellItem2.</param>
		[DllImport(Lib.Shell32, CharSet = CharSet.Unicode, ExactSpelling = true)]
		[SecurityCritical, SuppressUnmanagedCodeSecurity]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762135")]
		public static extern HRESULT SHCreateItemFromRelativeName([In, MarshalAs(UnmanagedType.Interface)] IShellItem psiParent, [In, MarshalAs(UnmanagedType.LPWStr)] string pszName,
			[In, MarshalAs(UnmanagedType.Interface)] IBindCtx pbc, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid, [MarshalAs(UnmanagedType.Interface)] out object ppv);

		/// <summary>
		/// Creates a Shell item object for a single file that exists inside a known folder.
		/// </summary>
		/// <param name="kfid">A reference to the KNOWNFOLDERID, a GUID that identifies the folder that contains the item.</param>
		/// <param name="dwKFFlags">Flags that specify special options in the object retrieval. This value can be 0; otherwise, one or more of the KNOWN_FOLDER_FLAG values.</param>
		/// <param name="pszItem">A pointer to a null-terminated buffer that contains the file name of the new item as a Unicode string. This parameter can also be NULL. In this case, an IShellItem that represents the known folder itself is created.</param>
		/// <param name="riid">A reference to an interface ID.</param>
		/// <param name="ppv">When this function returns, contains the interface pointer requested in riid. This will usually be IShellItem or IShellItem2.</param>
		[DllImport(Lib.Shell32, CharSet = CharSet.Unicode, ExactSpelling = true)]
		[SecurityCritical, SuppressUnmanagedCodeSecurity]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762136")]
		public static extern HRESULT SHCreateItemInKnownFolder([In, MarshalAs(UnmanagedType.LPStruct)] Guid kfid, [In] KNOWN_FOLDER_FLAG dwKFFlags,
			[In, Optional, MarshalAs(UnmanagedType.LPWStr)] string pszItem, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid, [MarshalAs(UnmanagedType.Interface)] out object ppv);

		/// <summary>
		/// Create a Shell item, given a parent folder and a child item ID.
		/// </summary>
		/// <param name="pidlParent">The IDList of the parent folder of the item being created; the IDList of psfParent. This parameter can be NULL, if psfParent is specified.</param>
		/// <param name="psfParent">A pointer to IShellFolder interface that specifies the shell data source of the child item specified by the pidl.This parameter can be NULL, if pidlParent is specified.</param>
		/// <param name="pidl">A child item ID relative to its parent folder specified by psfParent or pidlParent.</param>
		/// <param name="riid">A reference to an interface ID.</param>
		/// <param name="ppvItem">When this function returns, contains the interface pointer requested in riid. This will usually be IShellItem or IShellItem2.</param>
		[DllImport(Lib.Shell32, CharSet = CharSet.Unicode, ExactSpelling = true)]
		[SecurityCritical, SuppressUnmanagedCodeSecurity]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762137")]
		public static extern HRESULT SHCreateItemWithParent([In] PIDL pidlParent, [In, MarshalAs(UnmanagedType.Interface)] IShellFolder psfParent,
			[In] PIDL pidl, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid, [MarshalAs(UnmanagedType.Interface)] out object ppvItem);

		// [DllImport(Lib.Shell32, CharSet = CharSet.Unicode, ExactSpelling = true)]
		// [SecurityCritical, SuppressUnmanagedCodeSecurity]
		// [PInvokeData("Shlobj.h", MSDNShortId = "bb762141")]
		// public static extern HRESULT SHCreateShellFolderView([In] ref SFV_CREATE pcsfv, [MarshalAs(UnmanagedType.Interface)] out object ppvItem);

		/// <summary>
		/// Creates a Shell item array object.
		/// </summary>
		/// <param name="pidlParent">The ID list of the parent folder of the items specified in ppidl. If psf is specified, this parameter can be NULL. If this pidlParent is not specified, it is computed from the psf parameter using IPersistFolder2.</param>
		/// <param name="psf">The Shell data source object that is the parent of the child items specified in ppidl. If pidlParent is specified, this parameter can be NULL.</param>
		/// <param name="cidl">The number of elements in the array specified by ppidl.</param>
		/// <param name="ppidl">The list of child item IDs for which the array is being created. This value can be NULL.</param>
		/// <param name="ppsiItemArray">When this function returns, contains the address of an <see cref="IShellItemArray"/> interface pointer.</param>
		[DllImport(Lib.Shell32, CharSet = CharSet.Unicode, ExactSpelling = true)]
		[SecurityCritical, SuppressUnmanagedCodeSecurity]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762144")]
		public static extern HRESULT SHCreateShellItemArray([In] PIDL pidlParent, [In, MarshalAs(UnmanagedType.Interface)] IShellFolder psf,
			uint cidl, [In] PIDL ppidl,  out IShellItemArray ppsiItemArray);

		/// <summary>
		/// Creates a Shell item array object from a list of ITEMIDLIST structures.
		/// </summary>
		/// <param name="cidl">The number of elements in the array.</param>
		/// <param name="rgpidl">A list of cidl constant pointers to ITEMIDLIST structures.</param>
		/// <param name="ppsiItemArray">When this function returns, contains an IShellItemArray interface pointer.</param>
		[DllImport(Lib.Shell32, CharSet = CharSet.Unicode, ExactSpelling = true)]
		[SecurityCritical, SuppressUnmanagedCodeSecurity]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762146")]
		public static extern HRESULT SHCreateShellItemArrayFromIDLists(uint cidl, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] IntPtr[] rgpidl, out IShellItemArray ppsiItemArray);

		/// <summary>
		/// Creates an array of one element from a single Shell item.
		/// </summary>
		/// <param name="psi">Pointer to IShellItem object that represents the item.</param>
		/// <param name="riid">A reference to the IID of the interface to retrieve through ppv, typically IID_IShellItemArray.</param>
		/// <param name="ppv">When this method returns, contains the interface pointer requested in riid. This is typically a pointer to an IShellItemArray.</param>
		[DllImport(Lib.Shell32, CharSet = CharSet.Unicode, ExactSpelling = true)]
		[SecurityCritical, SuppressUnmanagedCodeSecurity]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762147")]
		public static extern HRESULT SHCreateShellItemArrayFromShellItem([In, MarshalAs(UnmanagedType.Interface)] IShellItem psi, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid, out IShellItemArray ppv);

		/// <summary>Returns a property store for an item, given a path or parsing name.</summary>
		/// <param name="pszPath">A pointer to a null-terminated Unicode string that specifies the item path.</param>
		/// <param name="pbc">A pointer to a IBindCtx object, which provides access to a bind context. This value can be NULL.</param>
		/// <param name="flags">One or more values from the GETPROPERTYSTOREFLAGS constants. This parameter can also be NULL.</param>
		/// <param name="riid">A reference to the desired interface ID.</param>
		/// <param name="propertyStore">
		/// When this function returns, contains the interface pointer requested in riid. This is typically IPropertyStore or a related interface.
		/// </param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.Shell32, ExactSpelling = true)]
		[PInvokeData("Shlobjidl.h", MSDNShortId = "bb762197")]
		public static extern HRESULT SHGetPropertyStoreFromParsingName(
			[In, MarshalAs(UnmanagedType.LPWStr)] string pszPath,
			[In] IBindCtx pbc,
			GETPROPERTYSTOREFLAGS flags,
			[MarshalAs(UnmanagedType.LPStruct)] Guid riid,
			[Out] out IPropertyStore propertyStore);

		/// <summary>Clones an ITEMIDLIST structure.</summary>
		/// <param name="pidl">A pointer to the ITEMIDLIST structure to be cloned.</param>
		/// <returns>Returns a pointer to a copy of the ITEMIDLIST structure pointed to by pidl.</returns>
		[DllImport(Lib.Shell32, EntryPoint = "ILClone", SetLastError = false)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb776433")]
		internal static extern IntPtr IntILClone(IntPtr pidl);

		/// <summary>Combines two ITEMIDLIST structures.</summary>
		/// <param name="pidl1">A pointer to the first ITEMIDLIST structure.</param>
		/// <param name="pidl2">A pointer to the second ITEMIDLIST structure. This structure is appended to the structure pointed to by pidl1.</param>
		/// <returns>
		/// Returns an ITEMIDLIST containing the combined structures. If you set either pidl1 or pidl2 to NULL, the returned ITEMIDLIST structure is a clone of
		/// the non-NULL parameter. Returns NULL if pidl1 and pidl2 are both set to NULL.
		/// </returns>
		[DllImport(Lib.Shell32, EntryPoint = "ILCombine", SetLastError = false)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb776437")]
		internal static extern IntPtr IntILCombine(IntPtr pidl1, IntPtr pidl2);

		/// <summary>Class interface for IEnumerableObjectCollection.</summary>
		[ComImport, Guid("2d3468c1-36a7-43b6-ac24-d3f02fd9607a"), ClassInterface(ClassInterfaceType.None)]
		public class CEnumerableObjectCollection { }
	}
}