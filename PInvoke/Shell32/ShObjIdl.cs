using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security;
using Vanara.Extensions;
using Vanara.InteropServices;
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
		/// <summary>The bind interruptable</summary>
		public const uint BIND_INTERRUPTABLE = 0xFFFFFFFF;
		/// <summary>Introduced in Windows XP SP2. Specify this bind context to permit clients of the data source to override the hidden drive letter policy and enable access to the view objects for data sources on the drives that are blocked.
		/// <para>Used with IShellFolder::BindToObject or IShellItem::BindToHandler.</para>
		/// <para>The system supports administrator-controlled policies that hide specified drive letters to block users from accessing those drives through Windows Explorer.When this policy is active, the result is that view objects and other handlers created with the IShellFolder::CreateViewObject method will fail when called on drives that are blocked by policy.</para></summary>
		public const string STR_AVOID_DRIVE_RESTRICTION_POLICY = "Avoid Drive Restriction Policy";
		/// <summary>Introduced in Windows Vista. Specify this bind context to cause the IShellFolder::BindToObject method to use the object specified by the pbc parameter to create the target object; in this case, the object specified by the punk parameter in the IBindCtx::RegisterObjectParam call must implement the ICreateObject interface.
		/// <para>Used with IShellFolder::BindToObject or IShellItem::BindToHandler.</para></summary>
		public const string STR_BIND_DELEGATE_CREATE_OBJECT = "Delegate Object Creation";
		/// <summary>Introduced in Windows 7. Passed to IShellFolder::ParseDisplayName along with STR_FILE_SYS_BIND_DATA. This forces simple parsing while also probing for Desktop.ini files along the path from which to get a localized name string. This avoids probing for folders along the path, which, in a case of a folder that represents a server or a share, could take extensive time and resources. Desktop.ini files are cached in some locations, so it will be at least as efficient as probing for folders attributes and then probing for the Desktop.ini if that folder should turn ou tot be read-only.</summary>
		public const string STR_BIND_FOLDERS_READ_ONLY = "Folders As Read Only";
		/// <summary>Introduced in Windows 7. Passed to IShellFolder::ParseDisplayName with an FOLDER_ENUM_MODE value to control the enumeration mode of the parsed item. The FOLDER_ENUM_MODE value is passed in the bind context through an object that implements IObjectWithFolderEnumMode.
		/// <para>Items with different enumeration modes compare canonically(SHCIDS_CANONICALONLY) different because they enumerate different sets of items.</para>
		/// <para>If an item doesn't support the enumeration mode (because it isn't a folder or it doesn't provide the enumeration mode) then it is created in the default enumeration mode.</para></summary>
		public const string STR_BIND_FOLDER_ENUM_MODE = "Folder Enum Mode";
		/// <summary>Introduced in Windows XP SP2. Specify this bind context to force a folder shortcut to resolve the link that points to its target.
		/// <para>A folder shortcut is a folder item that points to another folder item in the same namespace, using a link(shortcut) to hold the IDList of the target.The link is resolved to track the target in case it is moved or renamed.For example, the Windows XP My Network Places folder and the Windows Vista Computer folder can contain folder shortcuts created with the Add Network Location wizard.To improve performance, the IShellFolder::BindToObject method does not resolve links to network folder by default.</para>
		/// <para>Used with IShellFolder::BindToObject or IShellItem::BindToHandler.</para></summary>
		public const string STR_BIND_FORCE_FOLDER_SHORTCUT_RESOLVE = "Force Folder Shortcut Resolve";
		/// <summary>Introduced in Windows XP. Specify this bind context to prevent a call to the IShellFolder::ParseDisplayName method on the Desktop folder from treating relative paths as relative to the desktop; in such a case, parsing fails when this bind context is specified.</summary>
		public const string STR_DONT_PARSE_RELATIVE = "Don't Parse Relative";
		/// <summary>Introduced in Windows Vista. Specify this bind context to instruct an IShellItem not to resolve the link target obtained when using the BHID_LinkTargetItem GUID in IShellItem::BindToHandler.</summary>
		public const string STR_DONT_RESOLVE_LINK = "Don't Resolve Link";
		/// <summary>Introduced in Windows 8. Specifies a SHCONTF value to be passed to IShellFolder::EnumObjects when you call IShellItem::BindToHandler with BHID_EnumItems.</summary>
		public const string STR_ENUM_ITEMS_FLAGS = "SHCONTF";
		/// <summary>Introduced in Windows XP. Specify this bind context to provide file metadata to the IShellFolder::ParseDisplayName method, which is used instead of attempting to retrieve the actual file metadata. The associated object must implement IFileSystemBindData and can optionally also implement IFileSystemBindData2. By default, the IShellFolder::ParseDisplayName method verifies that the file exists and uses the file's actual metadata to populate the ID list.</summary>
		public const string STR_FILE_SYS_BIND_DATA = "File System Bind Data";
		/// <summary>Introduced in Windows 8.1. Specify this bind context to indicate that the data provided in the STR_FILE_SYS_FIND_DATA bind context should be used to create an ItemID list in the Windows 7 format.</summary>
		public const string STR_FILE_SYS_BIND_DATA_WIN7_FORMAT = "Win7FileSystemIdList";
		/// <summary>Introduced in Windows 7. Specify this bind context when the handler is being retrieved on the same thread as the UI. Any memory-intensive activities such as those that involve disk or network access should be avoided.</summary>
		public const string STR_GET_ASYNC_HANDLER = "GetAsyncHandler";
		/// <summary>Introduced in Windows Vista. Specify this bind context when requesting an IPropertySetStorage or IPropertyStore handler. This value is used with IShellFolder::BindToObject. See the GPS_BESTEFFORT flag for more information.</summary>
		public const string STR_GPS_BESTEFFORT = "GPS_BESTEFFORT";
		/// <summary>Introduced in Windows Vista. Specify this bind context when requesting an IPropertySetStorage or IPropertyStore handler. This value is used with IShellFolder::BindToObject. See the GPS_DELAYCREATION flag for more information.</summary>
		public const string STR_GPS_DELAYCREATION = "GPS_DELAYCREATION";
		/// <summary>Introduced in Windows Vista. Specify this bind context when requesting an IPropertySetStorage or IPropertyStore handler. This value is used with IShellFolder::BindToObject. See the GPS_FASTPROPERTIESONLY flag for more information.</summary>
		public const string STR_GPS_FASTPROPERTIESONLY = "GPS_FASTPROPERTIESONLY";
		/// <summary>Introduced in Windows Vista. Specify this bind context when requesting an IPropertySetStorage or IPropertyStore handler. This value is used with IShellFolder::BindToObject. See the GPS_HANDLERPROPERTIESONLY flag for more information.</summary>
		public const string STR_GPS_HANDLERPROPERTIESONLY = "GPS_HANDLERPROPERTIESONLY";
		/// <summary>Introduced in Windows 7. Specify this bind context when requesting an IPropertySetStorage or IPropertyStore handler. This value is used with IShellFolder::BindToObject. See the GPS_NO_OPLOCK flag for more information.</summary>
		public const string STR_GPS_NO_OPLOCK = "GPS_NO_OPLOCK";
		/// <summary>Introduced in Windows Vista. Specify this bind context when requesting an IPropertySetStorage or IPropertyStore handler. This value is used with IShellFolder::BindToObject. See the GPS_OPENSLOWITEM flag for more information.</summary>
		public const string STR_GPS_OPENSLOWITEM = "GPS_OPENSLOWITEM";
		/// <summary>Windows Vista only. Specify this bind context to cause a call to the IShellFolder::BindToObject method that requests the IFilter interface for a file system object to return a text filter if no other filter is available. This value is not defined as of Windows 7.</summary>
		public const string STR_IFILTER_FORCE_TEXT_FILTER_FALLBACK = "Always bind persistent handlers";
		/// <summary>Windows Vista only. Specify this bind context to cause a call to the IShellFolder::BindToObject method that requests the IFilter interface for a file system object to not return a fallback filter if no registered filter could be found.</summary>
		public const string STR_IFILTER_LOAD_DEFINED_FILTER = "Only bind registered persistent handlers";
		/// <summary>Introduced in Windows Vista. Specify this bind context to enable loading of the history from a stream for an internal navigation when the IPersistHistory::LoadHistory method is called. An internal navigation is a navigation within the same view.</summary>
		public const string STR_INTERNAL_NAVIGATE = "Internal Navigation";
		/// <summary>Introduced in Windows 7. Specify this bind context with STR_PARSE_PREFER_FOLDER_BROWSING when the client wants the Internet Shell folder handlers to generate an IDList for any valid URL if a DAV-type folder cannot be created for that URL. The URL is not verified to exist; only its syntax is checked and that it has a registered protocol handler.</summary>
		public const string STR_INTERNETFOLDER_PARSE_ONLY_URLMON_BINDABLE = "Validate URL";
		/// <summary>Introduced in Windows 7. Specify this bind context to instruct implementations of IShellFolder::ParseDisplayName and IPersistFolder3::InitializeEx to cache memory-intensive helper objects that can exist across instantiations of Shell items instead of recreating these objects each time that a Shell item is created. The associated object is another bind context object, initially empty. This should result in a separate bind context object, which is accessed through IBindCtx::GetObjectParam or IBindCtx::Register.ObjectParam.
		/// <para>A caller must opt into this behavior by providing this bind context parameter when calling SHCreateItemFromParsingName. By doing so, you optimize the behavior of binding to multiple parsing names in succession.The lifetime of the bind context object should span multiple instances of Shell items and their individual bind contexts.</para></summary>
		public const string STR_ITEM_CACHE_CONTEXT = "ItemCacheContext";
		/// <summary>Introduced in Windows Vista. Specify this bind context to allow invalid file name characters to appear in file names. By default, a call to the IShellFolder::ParseDisplayName method rejects characters that are illegal in file names. This bind context is meaningful only in conjunction with the STR_FILE_SYS_FIND_DATA bind context.</summary>
		public const string STR_NO_VALIDATE_FILENAME_CHARS = "NoValidateFilenameChars";
		/// <summary>Introduced in Windows Vista. Specify this bind context to enable a call to the IShellFolder::ParseDisplayName method on the Desktop folder to parse URLs. If this bind context is specified, it overrides STR_PARSE_PREFER_WEB_BROWSING.</summary>
		public const string STR_PARSE_ALLOW_INTERNET_SHELL_FOLDERS = "Allow binding to Internet shell folder handlers and negate STR_PARSE_PREFER_WEB_BROWSING";
		/// <summary>Introduced in Windows 7. Specify this bind context to instruct a data source's implementation of IShellFolder::ParseDisplayName to optimize the behavior of SHCreateItemFromParsingName.
		/// <para>Normally, SHCreateItemFromParsingName performs two binding operations on the name to be parsed: one through and one to IShellFolder::ParseDisplayName and one to create the Shell item.When the STR_PARSE_AND_CREATE_ITEM bind context is supported, the second bind is avoided by creating the Shell item during the IShellFolder::ParseDisplayName bind and storing the Shell item through IParseAndCreateItem::SetItem.SHCreateItemFromParsingName then uses the stored Shell item rather than creating one.</para>
		/// <para>This parameter applies to the last element of the name that is parsed. For instance, in the name "C:\Folder1\File.txt, the data applies to File.txt.</para></summary>
		public const string STR_PARSE_AND_CREATE_ITEM = "ParseAndCreateItem";
		/// <summary>Windows Vista only. Specify that, when parsing a URL, this bind context should not require the URL to exist before generating an IDList for it. Specify this bind context along with STR_PARSE_PREFER_FOLDER_BROWSING when the client desires that the Internet Shell folder handlers generate an IDList for the URL if a DAV folder cannot be created for the given URL.</summary>
		public const string STR_PARSE_DONT_REQUIRE_VALIDATED_URLS = "Do not require validated URLs";
		/// <summary>Introduced in Windows 7. The IShellFolder::ParseDisplayName method sets this property to tell the caller that the returned IDList was bound to the ProgID specified with STR_PARSE_WITH_EXPLICIT_PROGID or the application specified with STR_PARSE_WITH_EXPLICIT_ASSOCAPP. When STR_PARSE_EXPLICIT_ASSOCIATION_SUCCESSFUL is absent, the ProgID or application was not bound into the IDList.</summary>
		public const string STR_PARSE_EXPLICIT_ASSOCIATION_SUCCESSFUL = "ExplicitAssociationSuccessful";
		/// <summary>Introduced in Windows Vista. Specify this bind context to pass the original item that is being re-parsed when that item is stored as a IShellItem object that also implements the IParentAndItem interface. Before Windows 7 this value was not defined in a header file. It could be defined by the caller or passed as its string value of L"ParseOriginalItem". As of Windows 7, the value is defined in Shlobj.h. Note that this is a different header than the other STR constants.</summary>
		public const string STR_PARSE_PARTIAL_IDLIST = "ParseOriginalItem";
		/// <summary>Introduced in Windows XP. Specify this bind context to enable a call to the IShellFolder::ParseDisplayName method on the Desktop folder to parse URLs as if they were folders. Use this bind context to bind to a WebDAV server.</summary>
		public const string STR_PARSE_PREFER_FOLDER_BROWSING = "Parse Prefer Folder Browsing";
		/// <summary>Introduced in Windows Vista. Specify this bind context to prevent a call to the IShellFolder::ParseDisplayName method on the Desktop folder form parsing URLs. This bind context can be overridden by STR_PARSE_ALLOW_INTERNET_SHELL_FOLDERS.</summary>
		public const string STR_PARSE_PREFER_WEB_BROWSING = "Do not bind to Internet shell folder handlers";
		/// <summary>Introduced in Windows Vista. Specify this bind context to override the default property store used by the IShellFolder::ParseDisplayName method, and use the property store specified as the bind parameter instead. Applies to delegate folders.</summary>
		public const string STR_PARSE_PROPERTYSTORE = "DelegateNamedProperties";
		/// <summary>Introduced in Windows XP SP2. Specify this bind context to enable a call to the IShellFolder::ParseDisplayName method on the Desktop folder to use the "shell:" prefix notation to access files.</summary>
		public const string STR_PARSE_SHELL_PROTOCOL_TO_FILE_OBJECTS = "Parse Shell Protocol To File Objects";
		/// <summary>Introduced in Windows Vista. Specify this bind context to cause a call to the IShellFolder::ParseDisplayName method to display the network diagnostics dialog if the parsing of a network path fails.</summary>
		public const string STR_PARSE_SHOW_NET_DIAGNOSTICS_UI = "Show network diagnostics UI";
		/// <summary>Introduced in Windows Vista. Specify this bind context to cause a call to the IShellFolder::ParseDisplayName method to skip checking the network shares cache and contact the network server directly. Information about network shares is cached to improve performance, and IShellFolder::ParseDisplayName checks this cache by default.</summary>
		public const string STR_PARSE_SKIP_NET_CACHE = "Skip Net Resource Cache";
		/// <summary>Introduced in Windows XP. Specify this bind context to pass parsed properties to the IShellFolder::ParseDisplayName method for a delegate namespace. The namespace can use the passed properties instead of attempting to parse the name itself.</summary>
		public const string STR_PARSE_TRANSLATE_ALIASES = "Parse Translate Aliases";
		/// <summary>Windows Vista only. A parsing bind context that is used to pass a set of properties and the item's name when calling IShellFolder::ParseDisplayName. The object in the bind context implements IPropertyStore and is retrieved by calling IBindCtx::GetObjectParam.
		/// <para>DBFolder is a Shell data source that represents items in search results and query-based views.DBFolder retrieves these items by querying the Windows Search system.Items in the search results are identified through a protocol scheme, for example "file:" or "mapi:". DBFolder provides the behavior for these items by delegating to Shell data sources that are created for these protocols. See Developing Protocol Handler Add-ins for more information.</para>
		/// <para>When DBFolder delegates its parsing operation to the Shell data sources that support Windows Search protocols, this bind context provides access to values that were returned in the query result for that item. This includes the following:</para>
		/// <list type="bullet">
		/// <item><description>System.ItemType (PKEY_ItemType)</description></item>
		/// <item><description>System.ParsingPath (PKEY_ParsingPath)</description></item>
		/// <item><description>System.ItemPathDisplay (PKEY_ItemPathDisplay)</description></item>
		/// <item><description>System.ItemNameDisplay (PKEY_ItemNameDisplay)</description></item>
		/// </list>
		/// <para>This bind context can also be used to parse a DBFolder item if a client has a set of properties that define the item.In this case an empty name should be passed to IShellFolder::ParseDisplayName.</para>
		/// <para>Before Windows 7, this value was not defined in a header file.It could be defined by the caller or passed as its string value: L"ParseWithProperties". As of Windows 7, the value is defined in Shlobj.h.Note that this is a different header than where the other STR constants are defined.</para></summary>
		public const string STR_PARSE_WITH_PROPERTIES = "ParseWithProperties";
		/// <summary>Introduced in Windows 7. Specify this property to cause a call to the IShellFolder::ParseDisplayName method to return an IDList bound to the file type association handler for the application.</summary>
		public const string STR_PARSE_WITH_EXPLICIT_ASSOCAPP = "ExplicitAssociationApp";
		/// <summary>Introduced in Windows 7. Specify this property to cause a call to the IShellFolder::ParseDisplayName method to return an IDList bound to the file association handler of the provided ProgID.</summary>
		public const string STR_PARSE_WITH_EXPLICIT_PROGID = "ExplicitProgid";
		/// <summary>Introduced in Windows 8. Specify this bind context to indicate that the bind context parameter is a property bag (IPropertyBag) used to pass VARIANT values in the bind context. See the Remarks section for further details.</summary>
		public const string STR_PROPERTYBAG_PARAM = "SHBindCtxPropertyBag";
		/// <summary>Introduced in Windows XP. Specify this bind context to cause calls to the IShellFolder::ParseDisplayName or IShellFolder::BindToObject methods to ignore a particular Shell namespace extension when parsing or binding. The CLSID of the namespace to ignore is provided by the IPersist::GetClassID method of the bind parameter.</summary>
		public const string STR_SKIP_BINDING_CLSID = "Skip Binding CLSID";
		/// <summary>Not used.</summary>
		public const string STR_TRACK_CLSID = "Track the CLSID";

		/// <summary>The string referrer identifier</summary>
		public const string STR_REFERRER_IDENTIFIER = "Referrer Identifier";
		/// <summary>The string tab reuse identifier</summary>
		public const string STR_TAB_REUSE_IDENTIFIER = "Tab Reuse Identifier";

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

		/// <summary>
		/// Used with the IFolderView::Items, IFolderView::ItemCount, and IShellView::GetItemObject methods to restrict or control the items in their collections.
		/// </summary>
		public enum SVGIO : uint
		{
			/// <summary>Refers to the background of the view. It is used with IID_IContextMenu to get a shortcut menu for the view background and with IID_IDispatch to get a dispatch interface that represents the ShellFolderView object for the view.</summary>
			SVGIO_BACKGROUND = 0,
			/// <summary>Refers to the currently selected items. Used with IID_IDataObject to retrieve a data object that represents the selected items.</summary>
			SVGIO_SELECTION = 0x1,
			/// <summary>Used in the same way as SVGIO_SELECTION but refers to all items in the view.</summary>
			SVGIO_ALLVIEW = 0x2,
			/// <summary>Used in the same way as SVGIO_SELECTION but refers to checked items in views where checked mode is supported. For more details on checked mode, see FOLDERFLAGS.</summary>
			SVGIO_CHECKED = 0x3,
			/// <summary>Masks all bits but those corresponding to the _SVGIO flags.</summary>
			SVGIO_TYPE_MASK = 0xf,
			/// <summary>Returns the items in the order they appear in the view. If this flag is not set, the selected item will be listed first.</summary>
			SVGIO_FLAG_VIEWORDER = 0x80000000,
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

		/// <summary>Exposes methods that store file system information for optimizing calls to IShellFolder::ParseDisplayName.</summary>
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("01E18D10-4D8B-11d2-855D-006008059367")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb775671")]
		public interface IFileSystemBindData
		{
			/// <summary>Stores file system information in a WIN32_FIND_DATA structure. This information is used by IShellFolder::ParseDisplayName.</summary>
			/// <param name="pfd">A pointer to the WIN32_FIND_DATA structure that specifies the data you want to store.</param>
			void SetFindData([In] ref WIN32_FIND_DATA pfd);
			/// <summary>Gets the file system information stored in the WIN32_FIND_DATA structure.</summary>
			/// <param name="pfd">A pointer to the WIN32_FIND_DATA structure that receives the data.</param>
			void GetFindData(out WIN32_FIND_DATA pfd);
		}

		/// <summary>
		/// Extends IFileSystemBindData, which stores file system information for optimizing calls to IShellFolder::ParseDisplayName. This interface adds the
		/// ability set or get file ID or junction class identifier (CLSID).
		/// </summary>
		/// <seealso cref="Vanara.PInvoke.Shell32.IFileSystemBindData"/>
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("3acf075f-71db-4afa-81f0-3fc4fdf2a5b8")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb775660")]
		public interface IFileSystemBindData2 : IFileSystemBindData
		{
			/// <summary>Stores file system information in a WIN32_FIND_DATA structure. This information is used by IShellFolder::ParseDisplayName.</summary>
			/// <param name="pfd">A pointer to the WIN32_FIND_DATA structure that specifies the data you want to store.</param>
			new void SetFindData([In] ref WIN32_FIND_DATA pfd);
			/// <summary>Gets the file system information stored in the WIN32_FIND_DATA structure.</summary>
			/// <param name="pfd">A pointer to the WIN32_FIND_DATA structure that receives the data.</param>
			new void GetFindData(out WIN32_FIND_DATA pfd);
			/// <summary>Sets the unique file identifier for the current file.</summary>
			/// <param name="liFileID">A unique file identifier for the current file. liFileID is a value that is a concatenation of the values nFileIndexHigh and nFileIndexlow, noted in structure _by_handle_file_information.</param>
			void SetFileID(long liFileID);
			/// <summary>Gets the unique file identifier for the current file.</summary>
			/// <returns>When this method returns successfully, receives a pointer to the unique file identifier for the current file. pliFileID is a pointer to a value that is a concatenation of the values nFileIndexHigh and nFileIndexlow, noted in structure _by_handle_file_information.</returns>
			long GetFileID();
			/// <summary>Sets the class identifier (CLSID) of the object that implements IShellFolder, if the current item is a junction point.</summary>
			/// <param name="clsid">The CLSID for the object that implements IShellFolder with a junction point as its current item.</param>
			void SetJunctionCLSID([In, MarshalAs(UnmanagedType.LPStruct)] Guid clsid);
			/// <summary>Gets the class identifier (CLSID) of the object that implements IShellFolder for the item, if the item is a junction point.</summary>
			/// <returns>When this method returns successfully, receives a pointer to the CLSID of the object that implements IShellFolder for the current item, if the item is a junction point.</returns>
			[return: MarshalAs(UnmanagedType.LPStruct)]
			Guid GetJunctionCLSID();
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