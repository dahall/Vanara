using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.PropSys;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>The bind interruptible</summary>
		public const uint BIND_INTERRUPTABLE = 0xFFFFFFFF;

		/// <summary>
		/// Introduced in Windows XP SP2. Specify this bind context to permit clients of the data source to override the hidden drive letter
		/// policy and enable access to the view objects for data sources on the drives that are blocked.
		/// <para>Used with IShellFolder::BindToObject or IShellItem::BindToHandler.</para>
		/// <para>
		/// The system supports administrator-controlled policies that hide specified drive letters to block users from accessing those
		/// drives through Windows Explorer.When this policy is active, the result is that view objects and other handlers created with the
		/// IShellFolder::CreateViewObject method will fail when called on drives that are blocked by policy.
		/// </para>
		/// </summary>
		public const string STR_AVOID_DRIVE_RESTRICTION_POLICY = "Avoid Drive Restriction Policy";

		/// <summary>
		/// Introduced in Windows Vista. Specify this bind context to cause the IShellFolder::BindToObject method to use the object
		/// specified by the pbc parameter to create the target object; in this case, the object specified by the punk parameter in the
		/// IBindCtx::RegisterObjectParam call must implement the ICreateObject interface.
		/// <para>Used with IShellFolder::BindToObject or IShellItem::BindToHandler.</para>
		/// </summary>
		public const string STR_BIND_DELEGATE_CREATE_OBJECT = "Delegate Object Creation";

		/// <summary>
		/// Introduced in Windows 7. Passed to IShellFolder::ParseDisplayName with an FOLDER_ENUM_MODE value to control the enumeration mode
		/// of the parsed item. The FOLDER_ENUM_MODE value is passed in the bind context through an object that implements IObjectWithFolderEnumMode.
		/// <para>
		/// Items with different enumeration modes compare canonically(SHCIDS_CANONICALONLY) different because they enumerate different sets
		/// of items.
		/// </para>
		/// <para>
		/// If an item doesn't support the enumeration mode (because it isn't a folder or it doesn't provide the enumeration mode) then it
		/// is created in the default enumeration mode.
		/// </para>
		/// </summary>
		public const string STR_BIND_FOLDER_ENUM_MODE = "Folder Enum Mode";

		/// <summary>
		/// Introduced in Windows 7. Passed to IShellFolder::ParseDisplayName along with STR_FILE_SYS_BIND_DATA. This forces simple parsing
		/// while also probing for Desktop.ini files along the path from which to get a localized name string. This avoids probing for
		/// folders along the path, which, in a case of a folder that represents a server or a share, could take extensive time and
		/// resources. Desktop.ini files are cached in some locations, so it will be at least as efficient as probing for folders attributes
		/// and then probing for the Desktop.ini if that folder should turn ou tot be read-only.
		/// </summary>
		public const string STR_BIND_FOLDERS_READ_ONLY = "Folders As Read Only";

		/// <summary>
		/// Introduced in Windows XP SP2. Specify this bind context to force a folder shortcut to resolve the link that points to its target.
		/// <para>
		/// A folder shortcut is a folder item that points to another folder item in the same namespace, using a link(shortcut) to hold the
		/// IDList of the target.The link is resolved to track the target in case it is moved or renamed.For example, the Windows XP My
		/// Network Places folder and the Windows Vista Computer folder can contain folder shortcuts created with the Add Network Location
		/// wizard.To improve performance, the IShellFolder::BindToObject method does not resolve links to network folder by default.
		/// </para>
		/// <para>Used with IShellFolder::BindToObject or IShellItem::BindToHandler.</para>
		/// </summary>
		public const string STR_BIND_FORCE_FOLDER_SHORTCUT_RESOLVE = "Force Folder Shortcut Resolve";

		/// <summary>
		/// Introduced in Windows XP. Specify this bind context to prevent a call to the IShellFolder::ParseDisplayName method on the
		/// Desktop folder from treating relative paths as relative to the desktop; in such a case, parsing fails when this bind context is specified.
		/// </summary>
		public const string STR_DONT_PARSE_RELATIVE = "Don't Parse Relative";

		/// <summary>
		/// Introduced in Windows Vista. Specify this bind context to instruct an IShellItem not to resolve the link target obtained when
		/// using the BHID_LinkTargetItem GUID in IShellItem::BindToHandler.
		/// </summary>
		public const string STR_DONT_RESOLVE_LINK = "Don't Resolve Link";

		/// <summary>
		/// Introduced in Windows 8. Specifies a SHCONTF value to be passed to IShellFolder::EnumObjects when you call
		/// IShellItem::BindToHandler with BHID_EnumItems.
		/// </summary>
		public const string STR_ENUM_ITEMS_FLAGS = "SHCONTF";

		/// <summary>
		/// Introduced in Windows XP. Specify this bind context to provide file metadata to the IShellFolder::ParseDisplayName method, which
		/// is used instead of attempting to retrieve the actual file metadata. The associated object must implement IFileSystemBindData and
		/// can optionally also implement IFileSystemBindData2. By default, the IShellFolder::ParseDisplayName method verifies that the file
		/// exists and uses the file's actual metadata to populate the ID list.
		/// </summary>
		public const string STR_FILE_SYS_BIND_DATA = "File System Bind Data";

		/// <summary>
		/// Introduced in Windows 8.1. Specify this bind context to indicate that the data provided in the STR_FILE_SYS_FIND_DATA bind
		/// context should be used to create an ItemID list in the Windows 7 format.
		/// </summary>
		public const string STR_FILE_SYS_BIND_DATA_WIN7_FORMAT = "Win7FileSystemIdList";

		/// <summary>
		/// Introduced in Windows 7. Specify this bind context when the handler is being retrieved on the same thread as the UI. Any
		/// memory-intensive activities such as those that involve disk or network access should be avoided.
		/// </summary>
		public const string STR_GET_ASYNC_HANDLER = "GetAsyncHandler";

		/// <summary>
		/// Introduced in Windows Vista. Specify this bind context when requesting an IPropertySetStorage or IPropertyStore handler. This
		/// value is used with IShellFolder::BindToObject. See the GPS_BESTEFFORT flag for more information.
		/// </summary>
		public const string STR_GPS_BESTEFFORT = "GPS_BESTEFFORT";

		/// <summary>
		/// Introduced in Windows Vista. Specify this bind context when requesting an IPropertySetStorage or IPropertyStore handler. This
		/// value is used with IShellFolder::BindToObject. See the GPS_DELAYCREATION flag for more information.
		/// </summary>
		public const string STR_GPS_DELAYCREATION = "GPS_DELAYCREATION";

		/// <summary>
		/// Introduced in Windows Vista. Specify this bind context when requesting an IPropertySetStorage or IPropertyStore handler. This
		/// value is used with IShellFolder::BindToObject. See the GPS_FASTPROPERTIESONLY flag for more information.
		/// </summary>
		public const string STR_GPS_FASTPROPERTIESONLY = "GPS_FASTPROPERTIESONLY";

		/// <summary>
		/// Introduced in Windows Vista. Specify this bind context when requesting an IPropertySetStorage or IPropertyStore handler. This
		/// value is used with IShellFolder::BindToObject. See the GPS_HANDLERPROPERTIESONLY flag for more information.
		/// </summary>
		public const string STR_GPS_HANDLERPROPERTIESONLY = "GPS_HANDLERPROPERTIESONLY";

		/// <summary>
		/// Introduced in Windows 7. Specify this bind context when requesting an IPropertySetStorage or IPropertyStore handler. This value
		/// is used with IShellFolder::BindToObject. See the GPS_NO_OPLOCK flag for more information.
		/// </summary>
		public const string STR_GPS_NO_OPLOCK = "GPS_NO_OPLOCK";

		/// <summary>
		/// Introduced in Windows Vista. Specify this bind context when requesting an IPropertySetStorage or IPropertyStore handler. This
		/// value is used with IShellFolder::BindToObject. See the GPS_OPENSLOWITEM flag for more information.
		/// </summary>
		public const string STR_GPS_OPENSLOWITEM = "GPS_OPENSLOWITEM";

		/// <summary>
		/// Windows Vista only. Specify this bind context to cause a call to the IShellFolder::BindToObject method that requests the IFilter
		/// interface for a file system object to return a text filter if no other filter is available. This value is not defined as of
		/// Windows 7.
		/// </summary>
		public const string STR_IFILTER_FORCE_TEXT_FILTER_FALLBACK = "Always bind persistent handlers";

		/// <summary>
		/// Windows Vista only. Specify this bind context to cause a call to the IShellFolder::BindToObject method that requests the IFilter
		/// interface for a file system object to not return a fallback filter if no registered filter could be found.
		/// </summary>
		public const string STR_IFILTER_LOAD_DEFINED_FILTER = "Only bind registered persistent handlers";

		/// <summary>
		/// Introduced in Windows Vista. Specify this bind context to enable loading of the history from a stream for an internal navigation
		/// when the IPersistHistory::LoadHistory method is called. An internal navigation is a navigation within the same view.
		/// </summary>
		public const string STR_INTERNAL_NAVIGATE = "Internal Navigation";

		/// <summary>
		/// Introduced in Windows 7. Specify this bind context with STR_PARSE_PREFER_FOLDER_BROWSING when the client wants the Internet
		/// Shell folder handlers to generate an IDList for any valid URL if a DAV-type folder cannot be created for that URL. The URL is
		/// not verified to exist; only its syntax is checked and that it has a registered protocol handler.
		/// </summary>
		public const string STR_INTERNETFOLDER_PARSE_ONLY_URLMON_BINDABLE = "Validate URL";

		/// <summary>
		/// Introduced in Windows 7. Specify this bind context to instruct implementations of IShellFolder::ParseDisplayName and
		/// IPersistFolder3::InitializeEx to cache memory-intensive helper objects that can exist across instantiations of Shell items
		/// instead of recreating these objects each time that a Shell item is created. The associated object is another bind context
		/// object, initially empty. This should result in a separate bind context object, which is accessed through
		/// IBindCtx::GetObjectParam or IBindCtx::Register.ObjectParam.
		/// <para>
		/// A caller must opt into this behavior by providing this bind context parameter when calling SHCreateItemFromParsingName. By doing
		/// so, you optimize the behavior of binding to multiple parsing names in succession.The lifetime of the bind context object should
		/// span multiple instances of Shell items and their individual bind contexts.
		/// </para>
		/// </summary>
		public const string STR_ITEM_CACHE_CONTEXT = "ItemCacheContext";

		/// <summary>
		/// Introduced in Windows Vista. Specify this bind context to allow invalid file name characters to appear in file names. By
		/// default, a call to the IShellFolder::ParseDisplayName method rejects characters that are illegal in file names. This bind
		/// context is meaningful only in conjunction with the STR_FILE_SYS_FIND_DATA bind context.
		/// </summary>
		public const string STR_NO_VALIDATE_FILENAME_CHARS = "NoValidateFilenameChars";

		/// <summary>
		/// Introduced in Windows Vista. Specify this bind context to enable a call to the IShellFolder::ParseDisplayName method on the
		/// Desktop folder to parse URLs. If this bind context is specified, it overrides STR_PARSE_PREFER_WEB_BROWSING.
		/// </summary>
		public const string STR_PARSE_ALLOW_INTERNET_SHELL_FOLDERS = "Allow binding to Internet shell folder handlers and negate STR_PARSE_PREFER_WEB_BROWSING";

		/// <summary>
		/// Introduced in Windows 7. Specify this bind context to instruct a data source's implementation of IShellFolder::ParseDisplayName
		/// to optimize the behavior of SHCreateItemFromParsingName.
		/// <para>
		/// Normally, SHCreateItemFromParsingName performs two binding operations on the name to be parsed: one through and one to
		/// IShellFolder::ParseDisplayName and one to create the Shell item.When the STR_PARSE_AND_CREATE_ITEM bind context is supported,
		/// the second bind is avoided by creating the Shell item during the IShellFolder::ParseDisplayName bind and storing the Shell item
		/// through IParseAndCreateItem::SetItem.SHCreateItemFromParsingName then uses the stored Shell item rather than creating one.
		/// </para>
		/// <para>
		/// This parameter applies to the last element of the name that is parsed. For instance, in the name "C:\Folder1\File.txt, the data
		/// applies to File.txt.
		/// </para>
		/// </summary>
		public const string STR_PARSE_AND_CREATE_ITEM = "ParseAndCreateItem";

		/// <summary>
		/// Windows Vista only. Specify that, when parsing a URL, this bind context should not require the URL to exist before generating an
		/// IDList for it. Specify this bind context along with STR_PARSE_PREFER_FOLDER_BROWSING when the client desires that the Internet
		/// Shell folder handlers generate an IDList for the URL if a DAV folder cannot be created for the given URL.
		/// </summary>
		public const string STR_PARSE_DONT_REQUIRE_VALIDATED_URLS = "Do not require validated URLs";

		/// <summary>
		/// Introduced in Windows 7. The IShellFolder::ParseDisplayName method sets this property to tell the caller that the returned
		/// IDList was bound to the ProgID specified with STR_PARSE_WITH_EXPLICIT_PROGID or the application specified with
		/// STR_PARSE_WITH_EXPLICIT_ASSOCAPP. When STR_PARSE_EXPLICIT_ASSOCIATION_SUCCESSFUL is absent, the ProgID or application was not
		/// bound into the IDList.
		/// </summary>
		public const string STR_PARSE_EXPLICIT_ASSOCIATION_SUCCESSFUL = "ExplicitAssociationSuccessful";

		/// <summary>
		/// Introduced in Windows Vista. Specify this bind context to pass the original item that is being re-parsed when that item is
		/// stored as a IShellItem object that also implements the IParentAndItem interface. Before Windows 7 this value was not defined in
		/// a header file. It could be defined by the caller or passed as its string value of L"ParseOriginalItem". As of Windows 7, the
		/// value is defined in Shlobj.h. Note that this is a different header than the other STR constants.
		/// </summary>
		public const string STR_PARSE_PARTIAL_IDLIST = "ParseOriginalItem";

		/// <summary>
		/// Introduced in Windows XP. Specify this bind context to enable a call to the IShellFolder::ParseDisplayName method on the Desktop
		/// folder to parse URLs as if they were folders. Use this bind context to bind to a WebDAV server.
		/// </summary>
		public const string STR_PARSE_PREFER_FOLDER_BROWSING = "Parse Prefer Folder Browsing";

		/// <summary>
		/// Introduced in Windows Vista. Specify this bind context to prevent a call to the IShellFolder::ParseDisplayName method on the
		/// Desktop folder form parsing URLs. This bind context can be overridden by STR_PARSE_ALLOW_INTERNET_SHELL_FOLDERS.
		/// </summary>
		public const string STR_PARSE_PREFER_WEB_BROWSING = "Do not bind to Internet shell folder handlers";

		/// <summary>
		/// Introduced in Windows Vista. Specify this bind context to override the default property store used by the
		/// IShellFolder::ParseDisplayName method, and use the property store specified as the bind parameter instead. Applies to delegate folders.
		/// </summary>
		public const string STR_PARSE_PROPERTYSTORE = "DelegateNamedProperties";

		/// <summary>
		/// Introduced in Windows XP SP2. Specify this bind context to enable a call to the IShellFolder::ParseDisplayName method on the
		/// Desktop folder to use the "shell:" prefix notation to access files.
		/// </summary>
		public const string STR_PARSE_SHELL_PROTOCOL_TO_FILE_OBJECTS = "Parse Shell Protocol To File Objects";

		/// <summary>
		/// Introduced in Windows Vista. Specify this bind context to cause a call to the IShellFolder::ParseDisplayName method to display
		/// the network diagnostics dialog if the parsing of a network path fails.
		/// </summary>
		public const string STR_PARSE_SHOW_NET_DIAGNOSTICS_UI = "Show network diagnostics UI";

		/// <summary>
		/// Introduced in Windows Vista. Specify this bind context to cause a call to the IShellFolder::ParseDisplayName method to skip
		/// checking the network shares cache and contact the network server directly. Information about network shares is cached to improve
		/// performance, and IShellFolder::ParseDisplayName checks this cache by default.
		/// </summary>
		public const string STR_PARSE_SKIP_NET_CACHE = "Skip Net Resource Cache";

		/// <summary>
		/// Introduced in Windows XP. Specify this bind context to pass parsed properties to the IShellFolder::ParseDisplayName method for a
		/// delegate namespace. The namespace can use the passed properties instead of attempting to parse the name itself.
		/// </summary>
		public const string STR_PARSE_TRANSLATE_ALIASES = "Parse Translate Aliases";

		/// <summary>
		/// Introduced in Windows 7. Specify this property to cause a call to the IShellFolder::ParseDisplayName method to return an IDList
		/// bound to the file type association handler for the application.
		/// </summary>
		public const string STR_PARSE_WITH_EXPLICIT_ASSOCAPP = "ExplicitAssociationApp";

		/// <summary>
		/// Introduced in Windows 7. Specify this property to cause a call to the IShellFolder::ParseDisplayName method to return an IDList
		/// bound to the file association handler of the provided ProgID.
		/// </summary>
		public const string STR_PARSE_WITH_EXPLICIT_PROGID = "ExplicitProgid";

		/// <summary>
		/// Windows Vista only. A parsing bind context that is used to pass a set of properties and the item's name when calling
		/// IShellFolder::ParseDisplayName. The object in the bind context implements IPropertyStore and is retrieved by calling IBindCtx::GetObjectParam.
		/// <para>
		/// DBFolder is a Shell data source that represents items in search results and query-based views.DBFolder retrieves these items by
		/// querying the Windows Search system.Items in the search results are identified through a protocol scheme, for example "file:" or
		/// "mapi:". DBFolder provides the behavior for these items by delegating to Shell data sources that are created for these
		/// protocols. See Developing Protocol Handler Add-ins for more information.
		/// </para>
		/// <para>
		/// When DBFolder delegates its parsing operation to the Shell data sources that support Windows Search protocols, this bind context
		/// provides access to values that were returned in the query result for that item. This includes the following:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>System.ItemType (PKEY_ItemType)</description>
		/// </item>
		/// <item>
		/// <description>System.ParsingPath (PKEY_ParsingPath)</description>
		/// </item>
		/// <item>
		/// <description>System.ItemPathDisplay (PKEY_ItemPathDisplay)</description>
		/// </item>
		/// <item>
		/// <description>System.ItemNameDisplay (PKEY_ItemNameDisplay)</description>
		/// </item>
		/// </list>
		/// <para>
		/// This bind context can also be used to parse a DBFolder item if a client has a set of properties that define the item.In this
		/// case an empty name should be passed to IShellFolder::ParseDisplayName.
		/// </para>
		/// <para>
		/// Before Windows 7, this value was not defined in a header file.It could be defined by the caller or passed as its string value:
		/// L"ParseWithProperties". As of Windows 7, the value is defined in Shlobj.h.Note that this is a different header than where the
		/// other STR constants are defined.
		/// </para>
		/// </summary>
		public const string STR_PARSE_WITH_PROPERTIES = "ParseWithProperties";

		/// <summary>
		/// Introduced in Windows 8. Specify this bind context to indicate that the bind context parameter is a property bag (IPropertyBag)
		/// used to pass VARIANT values in the bind context. See the Remarks section for further details.
		/// </summary>
		public const string STR_PROPERTYBAG_PARAM = "SHBindCtxPropertyBag";

		/// <summary>The string referrer identifier</summary>
		public const string STR_REFERRER_IDENTIFIER = "Referrer Identifier";

		/// <summary>
		/// Introduced in Windows XP. Specify this bind context to cause calls to the IShellFolder::ParseDisplayName or
		/// IShellFolder::BindToObject methods to ignore a particular Shell namespace extension when parsing or binding. The CLSID of the
		/// namespace to ignore is provided by the IPersist::GetClassID method of the bind parameter.
		/// </summary>
		public const string STR_SKIP_BINDING_CLSID = "Skip Binding CLSID";

		/// <summary>The string tab reuse identifier</summary>
		public const string STR_TAB_REUSE_IDENTIFIER = "Tab Reuse Identifier";

		/// <summary>Not used.</summary>
		public const string STR_TRACK_CLSID = "Track the CLSID";

		private delegate HRESULT IidFunc(in Guid riid, out object ppv);

		/// <summary>Values that specify from which category the list of destinations should be retrieved.</summary>
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd378410")]
		public enum APPDOCLISTTYPE
		{
			/// <summary>The Recent category, which lists those items most recently accessed.</summary>
			RECENT,

			/// <summary>The Frequent category, which lists the items that have been accessed the greatest number of times.</summary>
			FREQUENT
		}

		/// <summary>The type of media in a given drive.</summary>
		[PInvokeData("shobjidl.h", MSDNShortId = "ebc826a2-d7ea-413a-836b-c7e51f13692a")]
		[Flags]
		public enum ARCONTENT
		{
			/// <summary>Use the Autorun.inf file. This is the traditional AutoRun behavior.</summary>
			ARCONTENT_AUTORUNINF = 0x00000002,

			/// <summary>AutoRun audio CDs.</summary>
			ARCONTENT_AUDIOCD = 0x00000004,

			/// <summary>AutoRun DVDs.</summary>
			ARCONTENT_DVDMOVIE = 0x00000008,

			/// <summary>AutoPlay blank CD-Rs and CD-RWs.</summary>
			ARCONTENT_BLANKCD = 0x00000010,

			/// <summary>AutoPlay blank DVD-Rs and DVD-RAMs.</summary>
			ARCONTENT_BLANKDVD = 0x00000020,

			/// <summary>AutoRun if the media is formatted and the content does not fall under a type covered by one of the other flags.</summary>
			ARCONTENT_UNKNOWNCONTENT = 0x00000040,

			/// <summary>AutoPlay if the content consists of file types defined as pictures, such as .bmp and .jpg files.</summary>
			ARCONTENT_AUTOPLAYPIX = 0x00000080,

			/// <summary>AutoPlay if the content consists of file types defined as music, such as MP3 files.</summary>
			ARCONTENT_AUTOPLAYMUSIC = 0x00000100,

			/// <summary>AutoPlay if the content consists of file types defined as video files.</summary>
			ARCONTENT_AUTOPLAYVIDEO = 0x00000200,

			/// <summary>Introduced in Windows Vista. AutoPlay video CDs (VCDs).</summary>
			ARCONTENT_VCD = 0x00000400,

			/// <summary>Introduced in Windows Vista. AutoPlay Super Video CD (SVCD) media.</summary>
			ARCONTENT_SVCD = 0x00000800,

			/// <summary>Introduced in Windows Vista. AutoPlay DVD-Audio media.</summary>
			ARCONTENT_DVDAUDIO = 0x00001000,

			/// <summary>
			/// AutoPlay blank recordable high definition DVD media in the Blu-ray Disc™ format (BD-R or BD-RW). Note: Prior to Windows 7,
			/// this value was defined to specify non-recordable media in the HD DVD format.
			/// </summary>
			ARCONTENT_BLANKBD = 0x00002000,

			/// <summary>Introduced in Windows Vista. AutoPlay high definition DVD media in the Blu-ray Disc™ format.</summary>
			ARCONTENT_BLURAY = 0x00004000,

			/// <summary>Introduced in Windows 8.</summary>
			ARCONTENT_CAMERASTORAGE = 0x00008000,

			/// <summary>Introduced in Windows 8.</summary>
			ARCONTENT_CUSTOMEVENT = 0x00010000,

			/// <summary>Introduced in Windows Vista. AutoPlay empty but formatted media.</summary>
			ARCONTENT_NONE = 0x00000000,

			/// <summary>
			/// Introduced in Windows Vista. A mask that denotes valid ARCONTENT flag values for media types. This mask does not include
			/// ARCONTENT_PHASE values.
			/// </summary>
			ARCONTENT_MASK = 0x0001FFFE,

			/// <summary>
			/// Introduced in Windows Vista. AutoPlay is searching the media. The phase of the search (presniff, sniffing, or final) is unknown.
			/// </summary>
			ARCONTENT_PHASE_UNKNOWN = 0x00000000,

			/// <summary>
			/// Introduced in Windows Vista. The contents of the media are known before the media is searched, due to the media type; for
			/// instance, audio CDs and DVD movies.
			/// </summary>
			ARCONTENT_PHASE_PRESNIFF = 0x10000000,

			/// <summary>
			/// Introduced in Windows Vista. AutoPlay is currently searching the media. Any results reported during this phase should be
			/// considered a partial list as more content types might still be found.
			/// </summary>
			ARCONTENT_PHASE_SNIFFING = 0x20000000,

			/// <summary>Introduced in Windows Vista. AutoPlay has finished searching the media. Results reported are final.</summary>
			ARCONTENT_PHASE_FINAL = 0x40000000,

			/// <summary>Introduced in Windows Vista. A mask that denotes valid ARCONTENT_PHASE values.</summary>
			ARCONTENT_PHASE_MASK = 0x70000000,
		}

		/// <summary>Specifies the enumeration handler filter applied to the full list of handlers in SHAssocEnumHandlers.</summary>
		[PInvokeData("shobjidl_core.h", MSDNShortId = "83db466b-e00c-4015-879f-c5c222f45b8c")]
		public enum ASSOC_FILTER
		{
			/// <summary>Return all handlers.</summary>
			ASSOC_FILTER_NONE = 0x0,

			/// <summary>
			/// Return only recommended handlers. A handler sets its recommended status in the registry when it is installed. An initial
			/// status of non-recommended can later be promoted to recommended as a result of user action.
			/// </summary>
			ASSOC_FILTER_RECOMMENDED = 0x1,
		}

		/// <summary>
		/// <para>
		/// Specifies the source of the default association for a file name extension. Used by methods of the
		/// IApplicationAssociationRegistration interface.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/ne-shobjidl_core-associationlevel typedef enum
		// ASSOCIATIONLEVEL { AL_MACHINE , AL_EFFECTIVE , AL_USER } ;
		[PInvokeData("shobjidl_core.h", MSDNShortId = "846ce9f4-092a-420d-be73-0951efc4368f")]
		public enum ASSOCIATIONLEVEL
		{
			/// <summary>The machine-level default application association.</summary>
			AL_MACHINE,

			/// <summary>The effective default for the current user. This value should be used by most applications.</summary>
			AL_EFFECTIVE,

			/// <summary>
			/// The per-user default application association. If this value is used and no per-user default is declared, the calling method
			/// fails with a value of .
			/// </summary>
			AL_USER,
		}

		/// <summary>
		/// Specifies the type of association for an application. Used by methods of the IApplicationAssociationRegistration interface.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/ne-shobjidl_core-associationtype
		[PInvokeData("shobjidl_core.h")]
		public enum ASSOCIATIONTYPE
		{
			/// <summary>Indicates a file name extension, such as .htm or .mp3.</summary>
			AT_FILEEXTENSION,

			/// <summary>Indicates a protocol, such as http or mailto.</summary>
			AT_URLPROTOCOL,

			/// <summary>
			/// Indicates the owner of the startmenu client for a mail or Internet hyperlink. As of Windows 7, this value is used only for
			/// the MAPI sendmail client.
			/// </summary>
			AT_STARTMENUCLIENT,

			/// <summary>Indicates the MIME type, such as audio/mp3.</summary>
			AT_MIMETYPE,
		}

		/// <summary>
		/// <para>Values used by the SHGetItemFromDataObject function to specify options concerning the processing of the source object.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/ne-shobjidl_core-dataobj_get_item_flags typedef enum
		// DATAOBJ_GET_ITEM_FLAGS { DOGIF_DEFAULT , DOGIF_TRAVERSE_LINK , DOGIF_NO_HDROP , DOGIF_NO_URL , DOGIF_ONLY_IF_ONE } ;
		[PInvokeData("shobjidl_core.h", MSDNShortId = "7a5ee490-cf30-452a-ade2-22d875ce0358")]
		[Flags]
		public enum DATAOBJ_GET_ITEM_FLAGS
		{
			/// <summary>No special options.</summary>
			DOGIF_DEFAULT = 0x0000,

			/// <summary>If the source object is a link, base the IShellItem on the link's target rather than the link file itself.</summary>
			DOGIF_TRAVERSE_LINK = 0x0001,

			/// <summary>
			/// If the source data object does not contain data in the CFSTR_SHELLIDLIST format, which identifies the object through an
			/// IDList, do not revert to the CF_HDROP format, which uses a file path, as an alternative in the transfer.
			/// </summary>
			DOGIF_NO_HDROP = 0x0002,

			/// <summary>
			/// If the source data object does not contain data in the CFSTR_SHELLIDLIST format, which identifies the object through an
			/// IDList, do not revert to the CFSTR_INETURL clipboard format, which uses a URL, as an alternative in the transfer.
			/// </summary>
			DOGIF_NO_URL = 0x0004,

			/// <summary>If the source object is an array of items, use it only if the array contains just one item.</summary>
			DOGIF_ONLY_IF_ONE = 0x0008,
		}

		/// <summary>Constants used by IFileIsInUse::GetUsage to indicate how a file in use is being used.</summary>
		/// <remarks>
		/// The interpretation of "playing" or "editing" is left to the application's implementation of IFileIsInUse. Generally, "playing"
		/// would refer to a media file while "editing" can refer to any file being altered in an application. However, the application
		/// itself best knows how to map these terms to its actions.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/ne-shobjidl_core-file_usage_type typedef enum FILE_USAGE_TYPE
		// { FUT_PLAYING, FUT_EDITING, FUT_GENERIC } ;
		[PInvokeData("shobjidl_core.h", MSDNShortId = "32b0e148-499a-401d-837c-8cea74cf9cac")]
		public enum FILE_USAGE_TYPE
		{
			/// <summary>The file is being played by the process that has it open.</summary>
			FUT_PLAYING,

			/// <summary>The file is being edited by the process that has it open.</summary>
			FUT_EDITING,

			/// <summary>
			/// The file is open in the process for an unspecified action or an action that does not readily fit into the other two categories.
			/// </summary>
			FUT_GENERIC,
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

		/// <summary>The capability flags used by <see cref="IFileIsInUse.GetCapabilities(out OF_CAP)"/>.</summary>
		[PInvokeData("shobjidl_core.h")]
		[Flags]
		public enum OF_CAP
		{
			/// <summary>The UI can switch to the top-level window of the application that is using the file.</summary>
			OF_CAP_CANSWITCHTO = 0x0001,

			/// <summary>The file can be closed.</summary>
			OF_CAP_CANCLOSE = 0x0002
		}

		/// <summary>
		/// Specifies the states that a placeholder file can have. Retrieve this value through the System.FilePlaceholderStatus
		/// (PKEY_FilePlaceholderStatus) property.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/ne-shobjidl_core-placeholder_states typedef enum
		// PLACEHOLDER_STATES { PS_NONE, PS_MARKED_FOR_OFFLINE_AVAILABILITY, PS_FULL_PRIMARY_STREAM_AVAILABLE, PS_CREATE_FILE_ACCESSIBLE,
		// PS_CLOUDFILE_PLACEHOLDER, PS_DEFAULT, PS_ALL } ;
		[PInvokeData("shobjidl_core.h", MSDNShortId = "BF4E0A9F-CD78-4D29-AD0C-7DF14AE88447")]
		[Flags]
		public enum PLACEHOLDER_STATES
		{
			/// <summary>None of the other states apply at this time.</summary>
			PS_NONE = 0,

			/// <summary>May already be or eventually will be available offline.</summary>
			PS_MARKED_FOR_OFFLINE_AVAILABILITY = 0x1,

			/// <summary>The primary stream has been made fully available.</summary>
			PS_FULL_PRIMARY_STREAM_AVAILABLE = 0x2,

			/// <summary>
			/// The file is accessible through a call to the CreateFile function, without requesting the opening of reparse points.
			/// </summary>
			PS_CREATE_FILE_ACCESSIBLE = 0x4,

			/// <summary/>
			PS_CLOUDFILE_PLACEHOLDER = 0x8,

			/// <summary/>
			PS_DEFAULT = PS_MARKED_FOR_OFFLINE_AVAILABILITY | PS_FULL_PRIMARY_STREAM_AVAILABLE | PS_CREATE_FILE_ACCESSIBLE,

			/// <summary>A bitmask value for all valid PLACEHOLDER_STATES flags.</summary>
			PS_ALL = PS_MARKED_FOR_OFFLINE_AVAILABILITY | PS_FULL_PRIMARY_STREAM_AVAILABLE | PS_CREATE_FILE_ACCESSIBLE | PS_CLOUDFILE_PLACEHOLDER,
		}

		/// <summary>
		/// Flags that specify the type of path information to retrieve. This parameter can be a combination of the following values.
		/// </summary>
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb774944")]
		[Flags]
		public enum SLGP
		{
			/// <summary>Retrieves the standard short (8.3 format) file name.</summary>
			SLGP_SHORTPATH = 1,

			/// <summary>Unsupported; do not use.</summary>
			SLGP_UNCPRIORITY = 2,

			/// <summary>
			/// Retrieves the raw path name. A raw path is something that might not exist and may include environment variables that need to
			/// be expanded.
			/// </summary>
			SLGP_RAWPATH = 4,

			/// <summary>
			/// Windows Vista and later. Retrieves the path, if possible, of the shortcut's target relative to the path set by a previous
			/// call to IShellLink::SetRelativePath.
			/// </summary>
			SLGP_RELATIVEPRIORITY = 8
		}

		/// <summary>
		/// Used with the IFolderView::Items, IFolderView::ItemCount, and IShellView::GetItemObject methods to restrict or control the items
		/// in their collections.
		/// </summary>
		public enum SVGIO : uint
		{
			/// <summary>
			/// Refers to the background of the view. It is used with IID_IContextMenu to get a shortcut menu for the view background and
			/// with IID_IDispatch to get a dispatch interface that represents the ShellFolderView object for the view.
			/// </summary>
			SVGIO_BACKGROUND = 0,

			/// <summary>
			/// Refers to the currently selected items. Used with IID_IDataObject to retrieve a data object that represents the selected items.
			/// </summary>
			SVGIO_SELECTION = 0x1,

			/// <summary>Used in the same way as SVGIO_SELECTION but refers to all items in the view.</summary>
			SVGIO_ALLVIEW = 0x2,

			/// <summary>
			/// Used in the same way as SVGIO_SELECTION but refers to checked items in views where checked mode is supported. For more
			/// details on checked mode, see FOLDERFLAGS.
			/// </summary>
			SVGIO_CHECKED = 0x3,

			/// <summary>Masks all bits but those corresponding to the _SVGIO flags.</summary>
			SVGIO_TYPE_MASK = 0xf,

			/// <summary>
			/// Returns the items in the order they appear in the view. If this flag is not set, the selected item will be listed first.
			/// </summary>
			SVGIO_FLAG_VIEWORDER = 0x80000000,
		}

		/// <summary>Specifies possible status values used in the System.SyncTransferStatus property.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/ne-shobjidl_core-sync_transfer_status typedef enum
		// SYNC_TRANSFER_STATUS { STS_NONE, STS_NEEDSUPLOAD, STS_NEEDSDOWNLOAD, STS_TRANSFERRING, STS_PAUSED, STS_HASERROR,
		// STS_FETCHING_METADATA, STS_USER_REQUESTED_REFRESH, STS_HASWARNING, STS_EXCLUDED, STS_INCOMPLETE, STS_PLACEHOLDER_IFEMPTY } ;
		[PInvokeData("shobjidl_core.h", MSDNShortId = "B772BF05-0E82-48E6-9A0B-A3C53FBC5F60")]
		[Flags]
		public enum SYNC_TRANSFER_STATUS : uint
		{
			/// <summary>There is no current sync activity.</summary>
			STS_NONE = 0,

			/// <summary>The file is pending upload.</summary>
			STS_NEEDSUPLOAD = 0x1,

			/// <summary>The file is pending download.</summary>
			STS_NEEDSDOWNLOAD = 0x2,

			/// <summary>The file is currently being uploaded or downloaded.</summary>
			STS_TRANSFERRING = 0x4,

			/// <summary>The current transfer is paused.</summary>
			STS_PAUSED = 0x8,

			/// <summary>An error was encountered during the last sync operation.</summary>
			STS_HASERROR = 0x10,

			/// <summary>The sync engine is retrieving metadata from the cloud.</summary>
			STS_FETCHING_METADATA = 0x20,

			/// <summary/>
			STS_USER_REQUESTED_REFRESH = 0x40,

			/// <summary/>
			STS_HASWARNING = 0x80,

			/// <summary/>
			STS_EXCLUDED = 0x100,

			/// <summary/>
			STS_INCOMPLETE = 0x200,

			/// <summary/>
			STS_PLACEHOLDER_IFEMPTY = 0x400
		}

		/// <summary>
		/// <para>
		/// Exposes methods that query and set default applications for specific file Association Type, and protocols at a specific
		/// Association Level.
		/// </para>
		/// <para><c>Note</c> As of Windows 8, the only functionality of this interface that is supported is QueryCurrentDefault.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Because <c>IApplicationAssociationRegistration</c> is only supported for Windows Vista and Windows 7, applications that support
		/// earlier operating systems must use their preexisting code in relation to defaults when running under those operating systems.
		/// Those applications should include a check for the operating system version to account for this.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nn-shobjidl_core-iapplicationassociationregistration
		[PInvokeData("shobjidl_core.h", MSDNShortId = "015a3be4-2e74-4a2b-8c02-54dcbf0ecacd")]
		[ComImport, Guid("4e530b0a-e611-4c77-a3ac-9031d022281b"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(ApplicationAssociationRegistration))]
		public interface IApplicationAssociationRegistration
		{
			/// <summary>
			/// Determines the default application for a given association type. This is the default application launched by ShellExecute
			/// for that type. Not intended for use in Windows 8.
			/// </summary>
			/// <param name="pszQuery">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>
			/// A pointer to a null-terminated, Unicode string that contains the file name extension or protocol, such as .mp3 or http.
			/// </para>
			/// </param>
			/// <param name="atQueryType">
			/// <para>Type: <c>ASSOCIATIONTYPE</c></para>
			/// <para>One of the ASSOCIATIONTYPE enumeration values that specifies the type of association, such as extension or MIME type.</para>
			/// </param>
			/// <param name="alQueryLevel">
			/// <para>Type: <c>ASSOCIATIONLEVEL</c></para>
			/// <para>
			/// One of the ASSOCIATIONLEVEL enumeration values that specifies the level of association, such as per-user or machine. This is
			/// typically AL_EFFECTIVE.
			/// </para>
			/// </param>
			/// <param name="ppszAssociation">
			/// <para>Type: <c>LPWSTR*</c></para>
			/// <para>When this method returns, contains the address of a pointer to the ProgID that identifies the current default association.</para>
			/// <para><c>Note</c> It is the responsibility of the calling application to release the string through CoTaskMemFree.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// The string produced is typically a ProgID matching one of the ProgIDs associated with a registered application, but there
			/// are a few exceptions: If the string returned is a machine default protocol, it is a legacy string indicating a command line
			/// to a .exe handler instead of a ProgID. Similarly, if returning a machine default MIME type, it returns a legacy class
			/// identifier (CLSID) string instead of a ProgID.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iapplicationassociationregistration-querycurrentdefault
			// HRESULT QueryCurrentDefault( LPCWSTR pszQuery, ASSOCIATIONTYPE atQueryType, ASSOCIATIONLEVEL alQueryLevel, LPWSTR
			// *ppszAssociation );
			void QueryCurrentDefault([MarshalAs(UnmanagedType.LPWStr)] string pszQuery, ASSOCIATIONTYPE atQueryType, ASSOCIATIONLEVEL alQueryLevel, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string ppszAssociation);

			/// <summary>
			/// Determines whether an application owns the registered default association for a given application level and type. Not
			/// intended for use in Windows 8.
			/// </summary>
			/// <param name="pszQuery">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>
			/// A pointer to a <c>null</c>-terminated Unicode string that contains the file name extension or protocol of the application,
			/// such as .mp3 or http.
			/// </para>
			/// </param>
			/// <param name="atQueryType">
			/// <para>Type: <c>ASSOCIATIONTYPE</c></para>
			/// <para>
			/// One of the ASSOCIATIONTYPE enumeration values that specifies the type of the application named in pszQuery, such as file
			/// name extension or MIME type.
			/// </para>
			/// </param>
			/// <param name="alQueryLevel">
			/// <para>Type: <c>ASSOCIATIONLEVEL</c></para>
			/// <para>
			/// One of the ASSOCIATIONLEVEL enumeration values that specifies the level of association, such as per-user or machine. This is
			/// typically AL_EFFECTIVE.
			/// </para>
			/// </param>
			/// <param name="pszAppRegistryName">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>A pointer to a <c>null</c>-terminated Unicode string that specifies the registered name of the application.</para>
			/// </param>
			/// <param name="pfDefault">
			/// <para>Type: <c>BOOL*</c></para>
			/// <para>When this method returns, contains <c>TRUE</c> if the application is the default; or <c>FALSE</c> otherwise.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iapplicationassociationregistration-queryappisdefault
			// HRESULT QueryAppIsDefault( LPCWSTR pszQuery, ASSOCIATIONTYPE atQueryType, ASSOCIATIONLEVEL alQueryLevel, LPCWSTR
			// pszAppRegistryName, BOOL *pfDefault );
			void QueryAppIsDefault([MarshalAs(UnmanagedType.LPWStr)] string pszQuery, ASSOCIATIONTYPE atQueryType, ASSOCIATIONLEVEL alQueryLevel, [MarshalAs(UnmanagedType.LPWStr)] string pszAppRegistryName, [MarshalAs(UnmanagedType.Bool)] out bool pfDefault);

			/// <summary>
			/// Determines whether an application owns all of the registered default associations for a given application level. Not
			/// intended for use in Windows 8.
			/// </summary>
			/// <param name="alQueryLevel">
			/// <para>Type: <c>ASSOCIATIONLEVEL</c></para>
			/// <para>
			/// One of the ASSOCIATIONLEVEL enumeration values that specifies the level of association, such as per-user or machine. This is
			/// typically AL_EFFECTIVE.
			/// </para>
			/// </param>
			/// <param name="pszAppRegistryName">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>A pointer to a <c>null</c>-terminated Unicode string that specifies the registered name of the application.</para>
			/// </param>
			/// <param name="pfDefault">
			/// <para>Type: <c>BOOL*</c></para>
			/// <para>
			/// When this method returns, contains <c>TRUE</c> if the application is the default for all association types at the specified
			/// ASSOCIATIONLEVEL; or <c>FALSE</c> otherwise.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iapplicationassociationregistration-queryappisdefaultall
			// HRESULT QueryAppIsDefaultAll( ASSOCIATIONLEVEL alQueryLevel, LPCWSTR pszAppRegistryName, BOOL *pfDefault );
			void QueryAppIsDefaultAll(ASSOCIATIONLEVEL alQueryLevel, [MarshalAs(UnmanagedType.LPWStr)] string pszAppRegistryName, [MarshalAs(UnmanagedType.Bool)] out bool pfDefault);

			/// <summary>
			/// Sets an application as the default for a given extension or protocol, provided that the application's publisher matches the
			/// current default's. For more information, see Default Programs. Not intended for use in Windows 8.
			/// </summary>
			/// <param name="pszAppRegistryName"/>
			/// <param name="pszSet"/>
			/// <param name="atSetType">
			/// <para>Type: <c>ASSOCIATIONTYPE</c></para>
			/// <para>
			/// One of the ASSOCIATIONTYPE enumeration values that specifies the type of the application named in extOrUriScheme, such as
			/// file name extension or MIME type.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>
			/// If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code. In particular, if the
			/// application's publisher doesn't match the default's, this method returns <c>E_ACCESSDENIED</c>.
			/// </para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iapplicationassociationregistration-setappasdefault
			// HRESULT SetAppAsDefault( LPCWSTR pszAppRegistryName, LPCWSTR pszSet, ASSOCIATIONTYPE atSetType );
			void SetAppAsDefault([MarshalAs(UnmanagedType.LPWStr)] string pszAppRegistryName, [MarshalAs(UnmanagedType.LPWStr)] string pszSet, ASSOCIATIONTYPE atSetType);

			/// <summary>
			/// Sets an application as the default for all of the registered associations of any type for that application. Not intended for
			/// use in Windows 8.
			/// </summary>
			/// <param name="pszAppRegistryName">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>A pointer to a null-terminated Unicode string that specifies the registered name of the application.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iapplicationassociationregistration-setappasdefaultall
			// HRESULT SetAppAsDefaultAll( LPCWSTR pszAppRegistryName );
			void SetAppAsDefaultAll([MarshalAs(UnmanagedType.LPWStr)] string pszAppRegistryName);

			/// <summary>
			/// Removes all per-user associations for the current user. This results in a reversion to machine defaults, if they exist. Not
			/// intended for use in Windows 8.
			/// </summary>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iapplicationassociationregistration-clearuserassociations
			// HRESULT ClearUserAssociations();
			void ClearUserAssociations();
		}

		/// <summary>
		/// Exposes methods that allow an application to remove one or all destinations from the Recent or Frequent categories in a Jump List.
		/// </summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, Guid("12337d35-94c6-48a0-bce7-6a9c69d4d600"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(ApplicationDestinations))]
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd378413")]
		public interface IApplicationDestinations
		{
			/// <summary>
			/// Specifies a unique AppUserModelID for the application from whose taskbar button's Jump List the methods of this interface
			/// will remove destinations. This method is optional.
			/// </summary>
			/// <param name="pszAppID">
			/// Pointer to the AppUserModelID of the process whose taskbar button representation receives the Jump List.
			/// </param>
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
			/// Set the App User Model ID for the application retrieving this list. If an AppID is not provided via this method, the system
			/// will use a heuristically determined ID. This method must be called before GetList.
			/// </summary>
			/// <param name="pszAppID">App Id.</param>
			void SetAppID([MarshalAs(UnmanagedType.LPWStr)] string pszAppID);

			/// <summary>
			/// Retrieve an IEnumObjects or IObjectArray for IShellItems and/or IShellLinks. Items may appear in both the frequent and
			/// recent lists.
			/// </summary>
			/// <param name="listtype">Which of the known list types to retrieve</param>
			/// <param name="cItemsDesired">The number of items desired.</param>
			/// <param name="riid">The interface Id that the return value should be queried for.</param>
			/// <returns>A COM object based on the IID passed for the riid parameter.</returns>
			[return: MarshalAs(UnmanagedType.IUnknown)]
			object GetList(APPDOCLISTTYPE listtype, uint cItemsDesired, in Guid riid);
		}

		/// <summary>Exposes methods to set default icons associated with an object.</summary>
		[ComImport, Guid("41ded17d-d6b3-4261-997d-88c60e4b1d58"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[PInvokeData("Shobjidl.h")]
		public interface IDefaultExtractIconInit
		{
			/// <summary>Sets GIL_XXX flags. See GetIconLocation</summary>
			/// <param name="uFlags">Specifies return flags to get icon location.</param>
			void SetFlags(GetIconLocationFlags uFlags);

			/// <summary>Sets the registry key from which to load the "DefaultIcon" value.</summary>
			/// <param name="hkey">A handle to the registry key.</param>
			void SetKey(HKEY hkey);

			/// <summary>Sets the normal icon.</summary>
			/// <param name="pszFile">
			/// A pointer to a buffer that contains the full icon path, including the file name and extension, as a Unicode string. This
			/// pointer can be NULL.
			/// </param>
			/// <param name="iIcon">A Shell icon ID.</param>
			void SetNormalIcon([In, Optional, MarshalAs(UnmanagedType.LPWStr)] string pszFile, int iIcon);

			/// <summary>Sets the icon that allows containers to specify an "open" look.</summary>
			/// <param name="pszFile">
			/// A pointer to a buffer that contains the full icon path, including the file name and extension, as a Unicode string. This
			/// pointer can be NULL.
			/// </param>
			/// <param name="iIcon">Shell icon ID.</param>
			void SetOpenIcon([In, Optional, MarshalAs(UnmanagedType.LPWStr)] string pszFile, int iIcon);

			/// <summary>Sets the icon for a shortcut to the object.</summary>
			/// <param name="pszFile">
			/// A pointer to a buffer that contains the full icon path, including the file name and extension, as a Unicode string. This
			/// pointer can be NULL.
			/// </param>
			/// <param name="iIcon">Shell icon ID.</param>
			void SetShortcutIcon([In, Optional, MarshalAs(UnmanagedType.LPWStr)] string pszFile, int iIcon);

			/// <summary>Sets the default icon.</summary>
			/// <param name="pszFile">
			/// A pointer to a buffer that contains the full icon path, including the file name and extension, as a Unicode string. This
			/// pointer can be NULL.
			/// </param>
			/// <param name="iIcon">The Shell icon ID.</param>
			void SetDefaultIcon([In, Optional, MarshalAs(UnmanagedType.LPWStr)] string pszFile, int iIcon);
		}

		/// <summary>Exposes a method that allows enumeration of a collection of handlers associated with particular file name extensions.</summary>
		[ComImport, Guid("973810ae-9599-4b88-9e4d-6ee98c9552da"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[PInvokeData("shobjidl_core.h", MSDNShortId = "9e173cb3-bd73-437c-8853-c13c8b6f216f")]
		public interface IEnumAssocHandlers
		{
			/// <summary>Retrieves a specified number of elements.</summary>
			/// <param name="celt">The number of elements to retrieve.</param>
			/// <param name="rgelt">
			/// When this method returns, contains the address of an array of IAssocHandler pointers. Each IAssocHandler represents a single handler.
			/// </param>
			/// <param name="pceltFetched">When this method returns, contains a pointer to the number of elements retrieved.</param>
			/// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
			[PreserveSig]
			HRESULT Next(uint celt, out IntPtr rgelt, out uint pceltFetched);
		}

		/// <summary>
		/// Exposes a standard set of methods used to enumerate the pointers to item identifier lists (PIDLs) of the items in a Shell
		/// folder. When a folder's IShellFolder::EnumObjects method is called, it creates an enumeration object and passes a pointer to the
		/// object's IEnumIDList interface back to the calling application.
		/// </summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("000214F2-0000-0000-C000-000000000046")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb761982")]
		public interface IEnumIDList
		{
			/// <summary>
			/// Retrieves the specified number of item identifiers in the enumeration sequence and advances the current position by the
			/// number of items retrieved.
			/// </summary>
			/// <param name="celt">The number of elements in the array referenced by the rgelt parameter.</param>
			/// <param name="rgelt">
			/// The address of a pointer to an array of ITEMIDLIST pointers that receive the item identifiers. The implementation must
			/// allocate these item identifiers using CoTaskMemAlloc. The calling application is responsible for freeing the item
			/// identifiers using CoTaskMemFree.
			/// </param>
			/// <param name="pceltFetched">
			/// A pointer to a value that receives a count of the item identifiers actually returned in rgelt. The count can be smaller than
			/// the value specified in the celt parameter. This parameter can be NULL on entry only if celt = 1, because in that case the
			/// method can only retrieve one (S_OK) or zero (S_FALSE) items.
			/// </param>
			/// <returns>
			/// Returns S_OK if the method successfully retrieved the requested celt elements. This method only returns S_OK if the full
			/// count of requested items are successfully retrieved. S_FALSE indicates that more items were requested than remained in the
			/// enumeration.The value pointed to by the pceltFetched parameter specifies the actual number of items retrieved. Note that the
			/// value will be 0 if there are no more items to retrieve.
			/// </returns>
			[PreserveSig]
			HRESULT Next(uint celt, [In, Out, MarshalAs(UnmanagedType.LPArray)] IntPtr[] rgelt, out uint pceltFetched);

			/// <summary>Skips the specified number of elements in the enumeration sequence.</summary>
			/// <param name="celt">The number of item identifiers to skip.</param>
			void Skip(uint celt);

			/// <summary>Returns to the beginning of the enumeration sequence.</summary>
			void Reset();

			/// <summary>Creates a new item enumeration object with the same contents and state as the current one.</summary>
			/// <returns>
			/// The address of a pointer to the new enumeration object. The calling application must eventually free the new object by
			/// calling its Release member function.
			/// </returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			IEnumIDList Clone();
		}

		/// <summary>
		/// Exposes methods that can be called to get information on or close a file that is in use by another application. When an
		/// application attempts to access a file and finds that file already in use, it can use the methods of this interface to gather
		/// information to present to the user in a dialog box.
		/// </summary>
		/// <remarks>
		/// <para>
		/// In versions of Windows before Windows Vista, when a user attempted to access a file that was open in another application, the
		/// user would simply receive a dialog box with a message stating that the file was already open. The message instructed that the
		/// user close the other application, but did not identify it. Other than that suggestion, the dialog box provided no user action to
		/// address the situation. This interface provides methods that can lead to a more informative dialog box from which the user can
		/// take direct action.
		/// </para>
		/// <para>The Running Object Table</para>
		/// <para>
		/// When an application opens a file, that application registers the file by inserting the instantiated <c>IFileIsInUse</c> object
		/// into the running object table (ROT). The ROT is a globally accessible lookup table that keeps track of currently running
		/// objects. These objects can be identified by a moniker. When a client attempts to bind a moniker to an object, the moniker checks
		/// the ROT to determine whether the object is already running. This allows the moniker to bind to the current instance rather than
		/// loading a new instance.
		/// </para>
		/// <para>Perform these steps to add a file to the ROT:</para>
		/// <list type="number">
		/// <item>
		/// <term>Call the GetRunningObjectTable function to retrieve an instance of IRunningObjectTable.</term>
		/// </item>
		/// <item>
		/// <term>Create an <c>IFileIsInUse</c> object for the file that is currently in use.</term>
		/// </item>
		/// <item>
		/// <term>Create an IMoniker object for the file that is currently in use.</term>
		/// </item>
		/// <item>
		/// <term>Insert the <c>IFileIsInUse</c> and IMoniker objects into the ROT by calling IRunningObjectTable::Register.</term>
		/// </item>
		/// </list>
		/// <para>
		/// In the call to Register, specify the <c>ROTFLAGS_ALLOWANYCLIENT</c> flag. This allows the ROT entry to work across security
		/// boundaries. Use of this flag requires the calling application to have an explicit Application User Model ID (AppUserModelID)
		/// (System.AppUserModel.ID). An explicit AppUserModelID allows the Component Object Model (COM) to inspect the application's
		/// security settings. An attempt to call <c>Register</c> with ROTFLAGS_ALLOWANYCLIENT and no explicit AppUserModelID will fail. You
		/// can call <c>Register</c> without the ROTFLAGS_ALLOWANYCLIENT flag and the application will work correctly, but only within its
		/// own security level.
		/// </para>
		/// <para>
		/// The value retrieved in the Register method's [out] parameter is used to identify the entry in later calls to retrieve or remove
		/// it from the ROT.
		/// </para>
		/// <para>When to Implement</para>
		/// <para>
		/// Applications that open file types that can be opened by other applications should implement <c>IFileIsInUse</c>. An
		/// application's implementation of this interface enables Windows Explorer to discover the source of sharing errors, which enables
		/// users to address and retry operations that fail due to those errors.
		/// </para>
		/// <para>When to Use</para>
		/// <para>
		/// An application calls <c>IFileIsInUse</c> to communicate with other applications to resolve sharing errors. These errors occur in
		/// response to user action in the file system. For example, when a user attempts to rename a folder while a file in that folder is
		/// open in an application, the renaming operation fails. Windows Explorer can call that appplication's implementation of
		/// <c>IFileIsInUse</c> to help the user identify the conflict and resolve this issue.
		/// </para>
		/// <para>Sample</para>
		/// <para>
		/// See the File Is in Use sample, which demonstrates how to implement <c>IFileIsInUse</c> and register a file with the ROT. It then
		/// shows how to customize the <c>File In Use</c> dialog to display additional information and options for files currently opened in
		/// an application.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nn-shobjidl_core-ifileisinuse
		[PInvokeData("shobjidl_core.h", MSDNShortId = "68a4ab3d-165e-4917-8915-77f15901dbad")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("64a1cbf0-3a1a-4461-9158-376969693950")]
		public interface IFileIsInUse
		{
			/// <summary>Retrieves the name of the application that is using the file.</summary>
			/// <param name="ppszName">
			/// <para>Type: <c>LPWSTR*</c></para>
			/// <para>The address of a pointer to a buffer that, when this method returns successfully, receives the application name.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// This information can be passed to the user in a dialog box so that the user knows the source of the conflict and can act
			/// accordingly. For instance "File.txt is in use by Litware."
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifileisinuse-getappname HRESULT
			// GetAppName( LPWSTR *ppszName );
			[PreserveSig]
			HRESULT GetAppName([MarshalAs(UnmanagedType.LPWStr)] out string ppszName);

			/// <summary>Gets a value that indicates how the file in use is being used.</summary>
			/// <param name="pfut">
			/// <para>Type: <c>FILE_USAGE_TYPE*</c></para>
			/// <para>Pointer to a value that, when this method returns successfully, receives one of the FILE_USAGE_TYPE values.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifileisinuse-getusage HRESULT GetUsage(
			// FILE_USAGE_TYPE *pfut );
			[PreserveSig]
			HRESULT GetUsage(out FILE_USAGE_TYPE pfut);

			/// <summary>
			/// Determines whether the file can be closed and whether the UI is capable of switching to the window of the application that
			/// is using the file.
			/// </summary>
			/// <param name="pdwCapFlags">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>
			/// A pointer to a value that, when this method returns successfully, receives the capability flags. One or both of the
			/// following values:
			/// </para>
			/// <para>OF_CAP_CANSWITCHTO (0x0001)</para>
			/// <para>0x0001. The UI can switch to the top-level window of the application that is using the file.</para>
			/// <para>OF_CAP_CANCLOSE (0x0002)</para>
			/// <para>0x0002. The file can be closed.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// The capabilities returned by this method can be used in the composition of the dialog box presented to the user that informs
			/// them of the sharing conflict. For instance, if the OF_CAP_CANSWITCHTO flag is retrieved, a button can be added to the dialog
			/// box that will switch the user to the conflicting application window (based on the <c>HWND</c> information retrieved by
			/// IFileIsInUse::GetSwitchToHWND) so that the user can address the situation as they see fit. If the OF_CAP_CANCLOSE flag is
			/// retrieved, the dialog box can present a <c>Close</c> button that calls the CloseFile method.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifileisinuse-getcapabilities HRESULT
			// GetCapabilities( DWORD *pdwCapFlags );
			[PreserveSig]
			HRESULT GetCapabilities(out OF_CAP pdwCapFlags);

			/// <summary>Retrieves the handle of the top-level window of the application that is using the file.</summary>
			/// <param name="phwnd">
			/// <para>Type: <c>HWND*</c></para>
			/// <para>A pointer to an <c>HWND</c> value that, when this method returns successfully, receives the window handle.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>Only files that return the capability flag OF_CAP_CANSWITCHTO can be switched to.</remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifileisinuse-getswitchtohwnd HRESULT
			// GetSwitchToHWND( HWND *phwnd );
			[PreserveSig]
			HRESULT GetSwitchToHWND(out HWND phwnd);

			/// <summary>Closes the file currently in use.</summary>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// Only files that return the capability flag OF_CAP_CANCLOSE can be closed by this method. If that flag is returned, the user
			/// can be presented with a dialog box that includes a <c>Close</c> option that calls this method.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifileisinuse-closefile HRESULT CloseFile( );
			[PreserveSig]
			HRESULT CloseFile();
		}

		/// <summary>Exposes methods that store file system information for optimizing calls to IShellFolder::ParseDisplayName.</summary>
		/// <remarks>
		/// <para>
		/// <c>IFileSystemBindData</c> stores the file system information in a WIN32_FIND_DATA structure. The object that implements
		/// <c>IFileSystemBindData</c> is then stored in a bind context that is passed to IShellFolder::ParseDisplayName.
		/// </para>
		/// <para>
		/// Implement <c>IFileSystemBindData</c> when you want to optimize calls to IShellFolder::ParseDisplayName and you already have the
		/// WIN32_FIND_DATA structure's file information available to you.
		/// </para>
		/// <para>
		/// To store the WIN32_FIND_DATA information prior to calling IShellFolder::ParseDisplayName, the client uses the following procedure.
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Create an instance of the object that exposes the <c>IFileSystemBindData</c> interface.</term>
		/// </item>
		/// <item>
		/// <term>Use IFileSystemBindData::SetFindData to store the data in the object.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Store the object in a bind context through the IBindCtx::RegisterObjectParam method. Set the pszKey parameter to the string and
		/// the punk parameter to the address of the <c>IFileSystemBindData</c> interface.
		/// </term>
		/// </item>
		/// </list>
		/// <para>The bind context is then passed with the call to IShellFolder::ParseDisplayName.</para>
		/// <para><c>Note</c> Prior to Windows Vista this interface was declared in Shlobj.h.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ifilesystembinddata
		[PInvokeData("shobjidl_core.h", MSDNShortId = "f5099bb3-21a7-4708-ac48-d32a14646614")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("01E18D10-4D8B-11d2-855D-006008059367")]
		public interface IFileSystemBindData
		{
			/// <summary>Stores file system information in a WIN32_FIND_DATA structure. This information is used by ParseDisplayName.</summary>
			/// <param name="pfd">
			/// <para>Type: <c>const WIN32_FIND_DATA*</c></para>
			/// <para>A pointer to the WIN32_FIND_DATA structure that specifies the data you want to store.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>Always returns <c>S_OK</c>.</para>
			/// </returns>
			/// <remarks>
			/// After the client stores the file information, the instance of the object itself must be stored in a bind context by using
			/// the IBindCtx::RegisterObjectParam method with the pszKey parameter set to .
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifilesystembinddata-setfinddata HRESULT
			// SetFindData( const WIN32_FIND_DATAW *pfd );
			[PreserveSig]
			HRESULT SetFindData(in WIN32_FIND_DATA pfd);

			/// <summary>Gets the file system information stored in the WIN32_FIND_DATA structure.</summary>
			/// <param name="pfd">
			/// <para>Type: <c>WIN32_FIND_DATA*</c></para>
			/// <para>A pointer to the WIN32_FIND_DATA structure that receives the data.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>Returns S_OK.</para>
			/// </returns>
			/// <remarks>
			/// This method provides bind context information to IShellFolder::ParseDisplayName. The client accesses the object by calling
			/// IBindCtx::GetObjectParam with the pszKey parameter set to the string "File System Bind Data".
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifilesystembinddata-getfinddata HRESULT
			// GetFindData( WIN32_FIND_DATAW *pfd );
			[PreserveSig]
			HRESULT GetFindData(out WIN32_FIND_DATA pfd);
		}

		/// <summary>
		/// Extends IFileSystemBindData, which stores file system information for optimizing calls to IShellFolder::ParseDisplayName. This
		/// interface adds the ability set or get file ID or junction class identifier (CLSID).
		/// </summary>
		/// <remarks>
		/// <para>This interface also provides the methods of the IFileSystemBindData interface, from which it inherits.</para>
		/// <para>
		/// To pass the information expressed in this interface to a data source IShellFolder::ParseDisplayName, an IBindCtx object is
		/// created (use CreateBindCtx) and populated with an object that implements IFileSystemBindData by calling the following:
		/// </para>
		/// <para>Where pfsbd is the object that implements <c>IFileSystemBindData</c>.</para>
		/// <para>Implementers of IShellFolder::ParseDisplayName first make the following call.</para>
		/// <para>Next the implementer calls one of the <c>Get</c> methods listed above to retrieve the parameters.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ifilesystembinddata2
		[PInvokeData("shobjidl_core.h", MSDNShortId = "c9659147-e2b6-4040-b939-42b7efec32d7")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("3acf075f-71db-4afa-81f0-3fc4fdf2a5b8")]
		public interface IFileSystemBindData2 : IFileSystemBindData
		{
			/// <summary>Stores file system information in a WIN32_FIND_DATA structure. This information is used by ParseDisplayName.</summary>
			/// <param name="pfd">
			/// <para>Type: <c>const WIN32_FIND_DATA*</c></para>
			/// <para>A pointer to the WIN32_FIND_DATA structure that specifies the data you want to store.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>Always returns <c>S_OK</c>.</para>
			/// </returns>
			/// <remarks>
			/// After the client stores the file information, the instance of the object itself must be stored in a bind context by using
			/// the IBindCtx::RegisterObjectParam method with the pszKey parameter set to .
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifilesystembinddata-setfinddata HRESULT
			// SetFindData( const WIN32_FIND_DATAW *pfd );
			[PreserveSig]
			new HRESULT SetFindData(in WIN32_FIND_DATA pfd);

			/// <summary>Gets the file system information stored in the WIN32_FIND_DATA structure.</summary>
			/// <param name="pfd">
			/// <para>Type: <c>WIN32_FIND_DATA*</c></para>
			/// <para>A pointer to the WIN32_FIND_DATA structure that receives the data.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>Returns S_OK.</para>
			/// </returns>
			/// <remarks>
			/// This method provides bind context information to IShellFolder::ParseDisplayName. The client accesses the object by calling
			/// IBindCtx::GetObjectParam with the pszKey parameter set to the string "File System Bind Data".
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifilesystembinddata-getfinddata HRESULT
			// GetFindData( WIN32_FIND_DATAW *pfd );
			[PreserveSig]
			new HRESULT GetFindData(out WIN32_FIND_DATA pfd);

			/// <summary>Sets the unique file identifier for the current file.</summary>
			/// <param name="liFileID">
			/// <para>Type: <c>LARGE_INTEGER</c></para>
			/// <para>
			/// A unique file identifier for the current file. liFileID is a value that is a concatenation of the values nFileIndexHigh and
			/// nFileIndexlow, noted in structure _by_handle_file_information.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifilesystembinddata2-setfileid HRESULT
			// SetFileID( LARGE_INTEGER liFileID );
			[PreserveSig]
			HRESULT SetFileID(long liFileID);

			/// <summary>Gets the unique file identifier for the current file.</summary>
			/// <param name="pliFileID">
			/// <para>Type: <c>LARGE_INTEGER*</c></para>
			/// <para>
			/// When this method returns successfully, receives a pointer to the unique file identifier for the current file. pliFileID is a
			/// pointer to a value that is a concatenation of the values nFileIndexHigh and nFileIndexlow, noted in structure _by_handle_file_information.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifilesystembinddata2-getfileid HRESULT
			// GetFileID( LARGE_INTEGER *pliFileID );
			[PreserveSig]
			HRESULT GetFileID(out long pliFileID);

			/// <summary>
			/// Sets the class identifier (CLSID) of the object that implements IShellFolder, if the current item is a junction point.
			/// </summary>
			/// <param name="clsid">
			/// <para>Type: <c>REFCLSID</c></para>
			/// <para>The CLSID for the object that implements IShellFolder with a junction point as its current item.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifilesystembinddata2-setjunctionclsid
			// HRESULT SetJunctionCLSID( REFCLSID clsid );
			[PreserveSig]
			HRESULT SetJunctionCLSID(in Guid clsid);

			/// <summary>
			/// Gets the class identifier (CLSID) of the object that implements IShellFolder for the item, if the item is a junction point.
			/// </summary>
			/// <param name="pclsid">
			/// <para>Type: <c>CLSID*</c></para>
			/// <para>
			/// When this method returns successfully, receives a pointer to the CLSID of the object that implements IShellFolder for the
			/// current item, if the item is a junction point.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifilesystembinddata2-getjunctionclsid
			// HRESULT GetJunctionCLSID( CLSID *pclsid );
			[PreserveSig]
			HRESULT GetJunctionCLSID(out Guid pclsid);
		}

		/// <summary>
		/// Exposes methods that the Shell uses to retrieve flags and info tip information for an item that resides in an IShellFolder
		/// implementation. Info tips are usually displayed inside a tooltip control.
		/// </summary>
		[ComImport, Guid("00021500-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb761359")]
		public interface IQueryInfo
		{
			/// <summary>Gets the information tip.</summary>
			/// <param name="dwFlags">
			/// Flags that direct the handling of the item from which you're retrieving the info tip text. This value is commonly zero (QITIPF_DEFAULT).
			/// </param>
			/// <param name="ppwszTip">
			/// The address of a Unicode string pointer that, when this method returns successfully, receives the tip string pointer.
			/// Applications that implement this method must allocate memory for ppwszTip by calling CoTaskMemAlloc. Calling applications
			/// must call CoTaskMemFree to free the memory when it is no longer needed.
			/// </param>
			/// &gt;
			void GetInfoTip(QITIP dwFlags, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string ppwszTip);

			/// <summary>Gets the information flags for an item. This method is not currently used.</summary>
			/// <returns>
			/// A pointer to a value that receives the flags for the item. If no flags are to be returned, this value should be set to zero.
			/// </returns>
			uint GetInfoFlags();
		}

		/// <summary>Enumerates the specified <see cref="IEnumIDList"/> instance with an optional fetch size.</summary>
		/// <param name="idList">The identifier list to enumerate. If this value is <see langword="null"/>, this will return an empty set.</param>
		/// <param name="fetchSize">Size of the block of PIDL instances to fetch with a single call.</param>
		/// <returns>A sequence of <see cref="PIDL"/> instances from <paramref name="idList"/>.</returns>
		/// <exception cref="ArgumentOutOfRangeException">fetchSize - You must specify a number greater than or equal to 1.</exception>
		public static IEnumerable<PIDL> Enumerate(this IEnumIDList idList, int fetchSize = 1)
		{
			if (fetchSize < 1) throw new ArgumentOutOfRangeException(nameof(fetchSize), "You must specify a number greater than or equal to 1.");
			if (idList is null) yield break;
			var pidls = new IntPtr[fetchSize];
			HRESULT hr;
			while ((hr = idList.Next((uint)pidls.Length, pidls, out var cnt)).Succeeded && cnt > 0)
			{
				for (int i = 0; i < cnt; i++)
					yield return new PIDL(pidls[i]);
				if (hr == HRESULT.S_FALSE)
					yield break;
			}
			hr.ThrowIfFailed();
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
		/// A pointer to an ITEMIDLIST structure that contains the first SHITEMID structure from the ITEMIDLIST structure specified by pidl.
		/// Returns NULL on failure.
		/// </returns>
		[DllImport(Lib.Shell32, ExactSpelling = true, SetLastError = false)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb776435")]
		public static extern PIDL ILCloneFirst(IntPtr pidl);

		/// <summary>Combines two ITEMIDLIST structures.</summary>
		/// <param name="pidl1">A pointer to the first ITEMIDLIST structure.</param>
		/// <param name="pidl2">
		/// A pointer to the second ITEMIDLIST structure. This structure is appended to the structure pointed to by pidl1.
		/// </param>
		/// <returns>
		/// Returns an ITEMIDLIST containing the combined structures. If you set either pidl1 or pidl2 to NULL, the returned ITEMIDLIST
		/// structure is a clone of the non-NULL parameter. Returns NULL if pidl1 and pidl2 are both set to NULL.
		/// </returns>
		[DllImport(Lib.Shell32, ExactSpelling = true, SetLastError = false)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb776437")]
		public static extern PIDL ILCombine(IntPtr pidl1, IntPtr pidl2);

		/// <summary>Returns the ITEMIDLIST structure associated with a specified file path.</summary>
		/// <param name="pszPath">
		/// A pointer to a null-terminated Unicode string that contains the path. This string should be no more than MAX_PATH characters in
		/// length, including the terminating null character.
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
		/// Returns a pointer to the SHITEMID structure that follows the one specified by pidl. Returns NULL if pidl points to the last
		/// SHITEMID structure.
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
		/// <param name="fImmediate">
		/// A Boolean value that is set to TRUE to test for immediate parents of pidl2, or FALSE to test for any parents of pidl2.
		/// </param>
		/// <returns>
		/// Returns TRUE if pidl1 is a parent of pidl2. If fImmediate is set to TRUE, the function only returns TRUE if pidl1 is the
		/// immediate parent of pidl2. Otherwise, the function returns FALSE.
		/// </returns>
		[DllImport(Lib.Shell32, ExactSpelling = true, SetLastError = false)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb776449")]
		public static extern bool ILIsParent(IntPtr pidl1, IntPtr pidl2, [MarshalAs(UnmanagedType.Bool)] bool fImmediate);

		/// <summary>Retrieves the next SHITEMID structure in an ITEMIDLIST structure.</summary>
		/// <param name="pidl">A constant, unaligned, relative PIDL for which the next SHITEMID structure is being retrieved.</param>
		/// <returns>
		/// When this function returns, contains one of three results: If pidl is valid and not the last SHITEMID in the ITEMIDLIST, then it
		/// contains a pointer to the next ITEMIDLIST structure. If the last ITEMIDLIST structure is passed, it contains NULL, which signals
		/// the end of the PIDL. For other values of pidl, the return value is meaningless.
		/// </returns>
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb776454")]
		public static IntPtr ILNext(IntPtr pidl)
		{
			var size = ILGetItemSize(pidl);
			return size == 0 ? IntPtr.Zero : pidl.Offset(size);
		}

		/// <summary>Removes the last SHITEMID structure from an ITEMIDLIST structure.</summary>
		/// <param name="pidl">
		/// A pointer to the ITEMIDLIST structure to be shortened. When the function returns, this variable points to the shortened structure.
		/// </param>
		/// <returns>Returns TRUE if successful, FALSE otherwise.</returns>
		[DllImport(Lib.Shell32, ExactSpelling = true, SetLastError = false)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb776456")]
		public static extern bool ILRemoveLastID(IntPtr pidl);

		/// <summary>Returns the ITEMIDLIST structure associated with a specified file path.</summary>
		/// <param name="pszPath">
		/// A pointer to a null-terminated Unicode string that contains the path. This string should be no more than MAX_PATH characters in
		/// length, including the terminating null character.
		/// </param>
		/// <returns>Returns a pointer to an ITEMIDLIST structure that corresponds to the path.</returns>
		[DllImport(Lib.Shell32, EntryPoint = "ILCreateFromPathW", SetLastError = true)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd378420")]
		public static extern IntPtr IntILCreateFromPath([MarshalAs(UnmanagedType.LPWStr)] string pszPath);

		/// <summary>
		/// Specifies a unique application-defined Application User Model ID (AppUserModelID) that identifies the current process to the
		/// taskbar. This identifier allows an application to group its associated processes and windows under a single taskbar button.
		/// </summary>
		/// <param name="AppID">Pointer to the AppUserModelID to assign to the current process.</param>
		[DllImport(Lib.Shell32, ExactSpelling = true)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd378422")]
		public static extern HRESULT SetCurrentProcessExplicitAppUserModelID([MarshalAs(UnmanagedType.LPWStr)] string AppID);

		/// <summary>
		/// <para>Returns an enumeration object for a specified set of file name extension handlers.</para>
		/// </summary>
		/// <param name="pszExtra">
		/// <para>Type: <c>PCWSTR</c></para>
		/// <para>
		/// A pointer to a null-terminated buffer that contains a single file type extension, for instance ".jpg". Only handlers associated
		/// with the given extension are enumerated. If this value is <c>NULL</c>, all handlers for all extensions are enumerated.
		/// </para>
		/// </param>
		/// <param name="afFilter">
		/// <para>Type: <c>ASSOC_FILTER</c></para>
		/// <para>
		/// Specifies the enumeration handler filter applied to the full list of handlers that results from the value given in . One of the
		/// following values.
		/// </para>
		/// <para>ASSOC_FILTER_NONE</para>
		/// <para>Return all handlers.</para>
		/// <para>ASSOC_FILTER_RECOMMENDED</para>
		/// <para>
		/// Return only recommended handlers. A handler sets its recommended status in the registry when it is installed. An initial status
		/// of non-recommended can later be promoted to recommended as a result of user action.
		/// </para>
		/// </param>
		/// <param name="ppEnumHandler">
		/// <para>Type: <c>IEnumAssocHandlers**</c></para>
		/// <para>When this method returns, contains the address of a pointer to an IEnumAssocHandlers object.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-shassocenumhandlers SHSTDAPI
		// SHAssocEnumHandlers( PCWSTR pszExtra, ASSOC_FILTER afFilter, IEnumAssocHandlers **ppEnumHandler );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shobjidl_core.h", MSDNShortId = "83db466b-e00c-4015-879f-c5c222f45b8c")]
		public static extern HRESULT SHAssocEnumHandlers([MarshalAs(UnmanagedType.LPWStr)] string pszExtra, ASSOC_FILTER afFilter, out IEnumAssocHandlers ppEnumHandler);

		/// <summary>
		/// <para>Gets an enumeration interface that provides access to handlers associated with a given protocol.</para>
		/// </summary>
		/// <param name="protocol">
		/// <para>Type: <c>PCWSTR</c></para>
		/// <para>Pointer to a string that specifies the protocol.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>A reference to the IID of the interface to retrieve through , typically IID_IEnumAssocHandlers.</para>
		/// </param>
		/// <param name="enumHandlers">
		/// <para>Type: <c>void**</c></para>
		/// <para>When this method returns, contains the interface pointer requested in . This is typically IEnumAssocHandlers.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// It is recommended that you use the <c>IID_PPV_ARGS</c> macro, defined in Objbase.h, to package the and parameters. This macro
		/// provides the correct IID based on the interface pointed to by the value in , which eliminates the possibility of a coding error.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-shassocenumhandlersforprotocolbyapplication
		// SHSTDAPI SHAssocEnumHandlersForProtocolByApplication( PCWSTR protocol, REFIID riid, void **enumHandlers );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shobjidl_core.h", MSDNShortId = "8bc3b9ce-5909-46a0-b5f1-35ab808aaa55")]
		public static extern HRESULT SHAssocEnumHandlersForProtocolByApplication([MarshalAs(UnmanagedType.LPWStr)] string protocol, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object enumHandlers);

		/// <summary>Gets an enumeration interface that provides access to handlers associated with a given protocol.</summary>
		/// <typeparam name="TIntf">The type of the interface to retrieve, typically IID_IEnumAssocHandlers.</typeparam>
		/// <param name="protocol">
		/// <para>Type: <c>PCWSTR</c></para>
		/// <para>Pointer to a string that specifies the protocol.</para>
		/// </param>
		/// <returns>
		/// When this method returns, contains the interface pointer requested in <typeparamref name="TIntf"/>. This is typically IEnumAssocHandlers.
		/// </returns>
		/// <remarks>
		/// It is recommended that you use the <c>IID_PPV_ARGS</c> macro, defined in Objbase.h, to package the and parameters. This macro
		/// provides the correct IID based on the interface pointed to by the value in , which eliminates the possibility of a coding error.
		/// </remarks>
		[PInvokeData("shobjidl_core.h", MSDNShortId = "8bc3b9ce-5909-46a0-b5f1-35ab808aaa55")]
		public static TIntf SHAssocEnumHandlersForProtocolByApplication<TIntf>(string protocol) where TIntf : class =>
			IidGetObj<TIntf>((in Guid g, out object o) => SHAssocEnumHandlersForProtocolByApplication(protocol, g, out o));

		/// <summary>
		/// Creates an IApplicationAssociationRegistration object based on the stock implementation of the interface provided by Windows.
		/// </summary>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>A reference to the IID of the requested interface.</para>
		/// </param>
		/// <param name="ppv">
		/// <para>Type: <c>void**</c></para>
		/// <para>When this function returns, contains the address of a pointer to the IApplicationAssociationRegistration object.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-shcreateassociationregistration SHSTDAPI
		// SHCreateAssociationRegistration( REFIID riid, void **ppv );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shobjidl_core.h", MSDNShortId = "7998f49d-2515-4c77-991e-62c0fefa43df")]
		public static extern HRESULT SHCreateAssociationRegistration(in Guid riid, out IApplicationAssociationRegistration ppv);

		/// <summary>
		/// Creates an IApplicationAssociationRegistration object based on the stock implementation of the interface provided by Windows.
		/// </summary>
		/// <returns>When this function returns, contains the address of a pointer to the IApplicationAssociationRegistration object.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-shcreateassociationregistration SHSTDAPI
		// SHCreateAssociationRegistration( REFIID riid, void **ppv );
		[PInvokeData("shobjidl_core.h", MSDNShortId = "7998f49d-2515-4c77-991e-62c0fefa43df")]
		public static IApplicationAssociationRegistration SHCreateAssociationRegistration()
		{
			SHCreateAssociationRegistration(typeof(IApplicationAssociationRegistration).GUID, out var ppv).ThrowIfFailed();
			return ppv;
		}

		/// <summary>
		/// <para>Creates a standard icon extractor, whose defaults can be further configured via the IDefaultExtractIconInit interface.</para>
		/// </summary>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>A reference to interface ID.</para>
		/// </param>
		/// <param name="ppv">
		/// <para>Type: <c>void**</c></para>
		/// <para>The address of IDefaultExtractIconInit interface pointer.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>The intended usage for this function is as follows:</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-shcreatedefaultextracticon HRESULT
		// SHCreateDefaultExtractIcon( REFIID riid, void **ppv );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shobjidl_core.h", MSDNShortId = "483dc9ae-4820-47f1-888e-ad7a6bdf3d29")]
		public static extern HRESULT SHCreateDefaultExtractIcon(in Guid riid, out IDefaultExtractIconInit ppv);

		/// <summary>
		/// <para>Creates a file operation that sets the default properties on the Shell item that have not already been set.</para>
		/// </summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the source shell item. See IShellItem.</para>
		/// </param>
		/// <param name="ppFileOp">
		/// <para>Type: <c>IFileOperation**</c></para>
		/// <para>The address of the IFileOperation interface pointer.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The list of properties to set a default value comes from the <c>SetDefaultsFor</c> registry entry under the ProgID for the file
		/// association of the item. The list is prefixed by and contains the canonical names of the properties to set the default value,
		/// for example, . The possible properties for this list are System.Author, System.Document.DateCreated, and System.Photo.DateTaken.
		/// If the <c>SetDefaultsFor</c> entry does not exist on the ProgID, this function uses the default found on the
		/// <c>SetDefaultsFor</c> entry of <c>HKEY_CLASSES_ROOT</c>&lt;b&gt;*.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl/nf-shobjidl-shcreatedefaultpropertiesop SHSTDAPI
		// SHCreateDefaultPropertiesOp( IShellItem *psi, IFileOperation **ppFileOp );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shobjidl.h", MSDNShortId = "5202ac48-16e7-4d64-8a69-2493036e1e11")]
		public static extern HRESULT SHCreateDefaultPropertiesOp(IShellItem psi, out IFileOperation ppFileOp);

		/// <summary>
		/// Creates and initializes a Shell item object from a pointer to an item identifier list (PIDL). The resulting shell item object
		/// supports the IShellItem interface.
		/// </summary>
		/// <param name="pidl">The source PIDL.</param>
		/// <param name="riid">A reference to the IID of the requested interface.</param>
		/// <param name="ppv">
		/// When this function returns, contains the interface pointer requested in riid. This will typically be IShellItem or IShellItem2.
		/// </param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.Shell32, ExactSpelling = true)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762133")]
		public static extern HRESULT SHCreateItemFromIDList(PIDL pidl, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppv);

		/// <summary>
		/// Creates and initializes a Shell item object from a pointer to an item identifier list (PIDL). The resulting shell item object
		/// supports the IShellItem interface.
		/// </summary>
		/// <typeparam name="TIntf">The type of the requested interface. This will typically be IShellItem or IShellItem2.</typeparam>
		/// <param name="pidl">The source PIDL.</param>
		/// <returns>When this function returns, contains the interface pointer requested.</returns>
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762133")]
		public static TIntf SHCreateItemFromIDList<TIntf>(PIDL pidl) where TIntf : class =>
			IidGetObj<TIntf>((in Guid g, out object o) => SHCreateItemFromIDList(pidl, g, out o));

		/// <summary>Creates and initializes a Shell item object from a parsing name.</summary>
		/// <param name="pszPath">A pointer to a display name.</param>
		/// <param name="pbc">
		/// Optional. A pointer to a bind context used to pass parameters as inputs and outputs to the parsing function. These passed
		/// parameters are often specific to the data source and are documented by the data source owners. For example, the file system data
		/// source accepts the name being parsed (as a WIN32_FIND_DATA structure), using the STR_FILE_SYS_BIND_DATA bind context parameter.
		/// <para>
		/// STR_PARSE_PREFER_FOLDER_BROWSING can be passed to indicate that URLs are parsed using the file system data source when
		/// possible.Construct a bind context object using CreateBindCtx and populate the values using IBindCtx::RegisterObjectParam. See
		/// Bind Context String Keys for a complete list of these.See the Parsing With Parameters Sample for an example of the use of this parameter.
		/// </para>
		/// <para>If no data is being passed to or received from the parsing function, this value can be NULL.</para>
		/// </param>
		/// <param name="riid">A reference to the IID of the interface to retrieve through ppv, typically IID_IShellItem or IID_IShellItem2.</param>
		/// <param name="ppv">
		/// When this method returns successfully, contains the interface pointer requested in riid. This is typically IShellItem or IShellItem2.
		/// </param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.Shell32, ExactSpelling = true)]
		[PInvokeData("Shlobjidl.h", MSDNShortId = "bb762134")]
		public static extern HRESULT SHCreateItemFromParsingName(
			[In, MarshalAs(UnmanagedType.LPWStr)] string pszPath,
			[In, Optional] IBindCtx pbc,
			in Guid riid,
			[MarshalAs(UnmanagedType.Interface, IidParameterIndex = 2)] out object ppv);

		/// <summary>Creates and initializes a Shell item object from a parsing name.</summary>
		/// <typeparam name="T">The type of the interface to retrieve, typically IID_IShellItem or IID_IShellItem2.</typeparam>
		/// <param name="pszPath">A pointer to a display name.</param>
		/// <param name="pbc">
		/// Optional. A pointer to a bind context used to pass parameters as inputs and outputs to the parsing function. These passed
		/// parameters are often specific to the data source and are documented by the data source owners. For example, the file system data
		/// source accepts the name being parsed (as a WIN32_FIND_DATA structure), using the STR_FILE_SYS_BIND_DATA bind context parameter.
		/// <para>
		/// STR_PARSE_PREFER_FOLDER_BROWSING can be passed to indicate that URLs are parsed using the file system data source when
		/// possible.Construct a bind context object using CreateBindCtx and populate the values using IBindCtx::RegisterObjectParam. See
		/// Bind Context String Keys for a complete list of these.See the Parsing With Parameters Sample for an example of the use of this parameter.
		/// </para>
		/// <para>If no data is being passed to or received from the parsing function, this value can be NULL.</para>
		/// </param>
		/// <returns>
		/// When this method returns successfully, contains the interface pointer requested in <typeparamref name="T"/>. This is typically
		/// IShellItem or IShellItem2.
		/// </returns>
		[PInvokeData("Shlobjidl.h", MSDNShortId = "bb762134")]
		public static T SHCreateItemFromParsingName<T>(string pszPath, IBindCtx pbc = null) where T : class =>
			IidGetObj<T>((in Guid g, out object o) => SHCreateItemFromParsingName(pszPath, pbc, g, out o));

		/// <summary>Creates and initializes a Shell item object from a relative parsing name.</summary>
		/// <param name="psiParent">A pointer to the parent Shell item.</param>
		/// <param name="pszName">
		/// A pointer to a null-terminated, Unicode string that specifies a display name that is relative to the psiParent.
		/// </param>
		/// <param name="pbc">A pointer to a bind context that controls the parsing operation. This parameter can be NULL.</param>
		/// <param name="riid">A reference to an interface ID.</param>
		/// <param name="ppv">
		/// When this function returns, contains the interface pointer requested in riid. This will usually be IShellItem or IShellItem2.
		/// </param>
		[DllImport(Lib.Shell32, CharSet = CharSet.Unicode, ExactSpelling = true)]
		[SecurityCritical, SuppressUnmanagedCodeSecurity]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762135")]
		public static extern HRESULT SHCreateItemFromRelativeName([In, MarshalAs(UnmanagedType.Interface)] IShellItem psiParent, [In, MarshalAs(UnmanagedType.LPWStr)] string pszName,
			[In, Optional, MarshalAs(UnmanagedType.Interface)] IBindCtx pbc, in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 3)] out object ppv);

		/// <summary>Creates and initializes a Shell item object from a relative parsing name.</summary>
		/// <typeparam name="TIntf">The type of the requested interface. This will typically be IShellItem or IShellItem2.</typeparam>
		/// <param name="psiParent">A pointer to the parent Shell item.</param>
		/// <param name="pszName">
		/// A pointer to a null-terminated, Unicode string that specifies a display name that is relative to the psiParent.
		/// </param>
		/// <param name="pbc">A pointer to a bind context that controls the parsing operation. This parameter can be NULL.</param>
		/// <returns>
		/// When this function returns, contains the interface pointer requested in riid. This will usually be IShellItem or IShellItem2.
		/// </returns>
		[SecurityCritical, SuppressUnmanagedCodeSecurity]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762135")]
		public static TIntf SHCreateItemFromRelativeName<TIntf>(IShellItem psiParent, string pszName, IBindCtx pbc = null) where TIntf : class =>
			IidGetObj<TIntf>((in Guid g, out object o) => SHCreateItemFromRelativeName(psiParent, pszName, pbc, g, out o));

		/// <summary>Creates a Shell item object for a single file that exists inside a known folder.</summary>
		/// <param name="kfid">A reference to the KNOWNFOLDERID, a GUID that identifies the folder that contains the item.</param>
		/// <param name="dwKFFlags">
		/// Flags that specify special options in the object retrieval. This value can be 0; otherwise, one or more of the KNOWN_FOLDER_FLAG values.
		/// </param>
		/// <param name="pszItem">
		/// A pointer to a null-terminated buffer that contains the file name of the new item as a Unicode string. This parameter can also
		/// be NULL. In this case, an IShellItem that represents the known folder itself is created.
		/// </param>
		/// <param name="riid">A reference to an interface ID.</param>
		/// <param name="ppv">
		/// When this function returns, contains the interface pointer requested in riid. This will usually be IShellItem or IShellItem2.
		/// </param>
		[DllImport(Lib.Shell32, CharSet = CharSet.Unicode, ExactSpelling = true)]
		[SecurityCritical, SuppressUnmanagedCodeSecurity]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762136")]
		public static extern HRESULT SHCreateItemInKnownFolder(in Guid kfid, [In] KNOWN_FOLDER_FLAG dwKFFlags,
			[In, Optional, MarshalAs(UnmanagedType.LPWStr)] string pszItem, in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 3)] out object ppv);

		/// <summary>Creates a Shell item object for a single file that exists inside a known folder.</summary>
		/// <typeparam name="TIntf">The type of the requested interface. This will typically be IShellItem or IShellItem2.</typeparam>
		/// <param name="kfid">A reference to the KNOWNFOLDERID that identifies the folder that contains the item.</param>
		/// <param name="dwKFFlags">
		/// Flags that specify special options in the object retrieval. This value can be 0; otherwise, one or more of the KNOWN_FOLDER_FLAG values.
		/// </param>
		/// <param name="pszItem">
		/// A pointer to a null-terminated buffer that contains the file name of the new item as a Unicode string. This parameter can also
		/// be NULL. In this case, an IShellItem that represents the known folder itself is created.
		/// </param>
		/// <returns>
		/// When this function returns, contains the interface pointer requested in riid. This will usually be IShellItem or IShellItem2.
		/// </returns>
		[SecurityCritical, SuppressUnmanagedCodeSecurity]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762136")]
		public static TIntf SHCreateItemInKnownFolder<TIntf>(KNOWNFOLDERID kfid, KNOWN_FOLDER_FLAG dwKFFlags = 0, string pszItem = null) where TIntf : class =>
			IidGetObj<TIntf>((in Guid g, out object o) => SHCreateItemInKnownFolder(kfid.Guid(), dwKFFlags, pszItem, g, out o));

		/// <summary>Create a Shell item, given a parent folder and a child item ID.</summary>
		/// <param name="pidlParent">
		/// The IDList of the parent folder of the item being created; the IDList of psfParent. This parameter can be NULL, if psfParent is specified.
		/// </param>
		/// <param name="psfParent">
		/// A pointer to IShellFolder interface that specifies the shell data source of the child item specified by the pidl.This parameter
		/// can be NULL, if pidlParent is specified.
		/// </param>
		/// <param name="pidl">A child item ID relative to its parent folder specified by psfParent or pidlParent.</param>
		/// <param name="riid">A reference to an interface ID.</param>
		/// <param name="ppvItem">
		/// When this function returns, contains the interface pointer requested in riid. This will usually be IShellItem or IShellItem2.
		/// </param>
		[DllImport(Lib.Shell32, CharSet = CharSet.Unicode, ExactSpelling = true)]
		[SecurityCritical, SuppressUnmanagedCodeSecurity]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762137")]
		public static extern HRESULT SHCreateItemWithParent([In, Optional] PIDL pidlParent, [In, Optional, MarshalAs(UnmanagedType.Interface)] IShellFolder psfParent,
			[In] PIDL pidl, in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 3)] out object ppvItem);

		/// <summary>Create a Shell item, given a parent folder and a child item ID.</summary>
		/// <typeparam name="TIntf">The type of the requested interface. This will typically be IShellItem or IShellItem2.</typeparam>
		/// <param name="pidlParent">
		/// The IDList of the parent folder of the item being created; the IDList of psfParent. This parameter cannot be NULL.
		/// </param>
		/// <param name="pidl">A child item ID relative to its parent folder specified by psfParent or pidlParent.</param>
		/// <returns>
		/// When this function returns, contains the interface pointer requested in riid. This will usually be IShellItem or IShellItem2.
		/// </returns>
		[SecurityCritical, SuppressUnmanagedCodeSecurity]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762137")]
		public static TIntf SHCreateItemWithParent<TIntf>([In] PIDL pidlParent, [In] PIDL pidl) where TIntf : class =>
			IidGetObj<TIntf>((in Guid g, out object o) => SHCreateItemWithParent(pidlParent, null, pidl, g, out o));

		/// <summary>Create a Shell item, given a parent folder and a child item ID.</summary>
		/// <typeparam name="TIntf">The type of the requested interface. This will typically be IShellItem or IShellItem2.</typeparam>
		/// <param name="psfParent">
		/// A pointer to IShellFolder interface that specifies the shell data source of the child item specified by the pidl. This parameter
		/// cannot be NULL.
		/// </param>
		/// <param name="pidl">A child item ID relative to its parent folder specified by psfParent or pidlParent.</param>
		/// <returns>
		/// When this function returns, contains the interface pointer requested in riid. This will usually be IShellItem or IShellItem2.
		/// </returns>
		[SecurityCritical, SuppressUnmanagedCodeSecurity]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762137")]
		public static TIntf SHCreateItemWithParent<TIntf>([In] IShellFolder psfParent, [In] PIDL pidl) where TIntf : class =>
			IidGetObj<TIntf>((in Guid g, out object o) => SHCreateItemWithParent(PIDL.Null, psfParent, pidl, g, out o));

		/// <summary>Creates a Shell item array object.</summary>
		/// <param name="pidlParent">
		/// <para>Type: <c>PCIDLIST_ABSOLUTE</c></para>
		/// <para>
		/// The ID list of the parent folder of the items specified in ppidl. If psf is specified, this parameter can be <c>NULL</c>. If
		/// this pidlParent is not specified, it is computed from the psf parameter using IPersistFolder2.
		/// </para>
		/// </param>
		/// <param name="psf">
		/// <para>Type: <c>IShellFolder*</c></para>
		/// <para>
		/// The Shell data source object that is the parent of the child items specified in ppidl. If pidlParent is specified, this
		/// parameter can be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="cidl">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of elements in the array specified by ppidl.</para>
		/// </param>
		/// <param name="ppidl">
		/// <para>Type: <c>PCUITEMID_CHILD_ARRAY</c></para>
		/// <para>The list of child item IDs for which the array is being created. This value can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="ppsiItemArray">
		/// <para>Type: <c>IShellItemArray**</c></para>
		/// <para>When this function returns, contains the address of an IShellItemArray interface pointer.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-shcreateshellitemarray SHSTDAPI
		// SHCreateShellItemArray( PCIDLIST_ABSOLUTE pidlParent, IShellFolder *psf, UINT cidl, PCUITEMID_CHILD_ARRAY ppidl, IShellItemArray
		// **ppsiItemArray );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shobjidl_core.h", MSDNShortId = "024ccbc7-97f1-4cb5-8588-9c9b1f747336")]
		public static extern HRESULT SHCreateShellItemArray([In, Optional] PIDL pidlParent, [In, MarshalAs(UnmanagedType.Interface), Optional] IShellFolder psf,
			[In, Optional] uint cidl, [In, Optional] IntPtr[] ppidl, out IShellItemArray ppsiItemArray);

		/// <summary>
		/// <para>Creates a Shell item array object from a data object.</para>
		/// </summary>
		/// <param name="pdo">
		/// <para>Type: <c>IDataObject*</c></para>
		/// <para>A pointer to IDataObject interface.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>A reference to the desired interface ID.</para>
		/// </param>
		/// <param name="ppv">
		/// <para>Type: <c>void**</c></para>
		/// <para>When this method returns, contains the interface pointer requested in . This is typically IShellItemArray.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function is useful for Shell extensions that implement IShellExtInit and are passed a data object to the
		/// IShellExtInit::Initialize method; for example, context menu handlers.
		/// </para>
		/// <para>
		/// This API lets you convert the data object into a Shell item that the handler can consume. It is recommend that handlers use a
		/// Shell item array rather than clipboard formats like <c>CF_HDROP</c> and <c>CFSTR_SHELLIDLIST</c> (also known as HIDA) as it
		/// leads to simpler code and allows some performance improvements.
		/// </para>
		/// <para>
		/// The resulting shell item array holds a reference to the source data object. Therefore, that data object must remain valid for
		/// the lifetime of the shell item array. Notably, the data objects passed to IDropTarget methods are no longer valid after the drop
		/// operation completes.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-shcreateshellitemarrayfromdataobject SHSTDAPI
		// SHCreateShellItemArrayFromDataObject( IDataObject *pdo, REFIID riid, void **ppv );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shobjidl_core.h", MSDNShortId = "91e65c9a-0600-42e3-97f5-2a5960e1ec89")]
		public static extern HRESULT SHCreateShellItemArrayFromDataObject(IDataObject pdo, in Guid riid, out IShellItemArray ppv);

		/// <summary>Creates a Shell item array object from a data object.</summary>
		/// <param name="pdo">
		/// <para>Type: <c>IDataObject*</c></para>
		/// <para>A pointer to IDataObject interface.</para>
		/// </param>
		/// <returns>When this method returns, contains the interface pointer requested. This is typically IShellItemArray.</returns>
		/// <remarks>
		/// <para>
		/// This function is useful for Shell extensions that implement IShellExtInit and are passed a data object to the
		/// IShellExtInit::Initialize method; for example, context menu handlers.
		/// </para>
		/// <para>
		/// This API lets you convert the data object into a Shell item that the handler can consume. It is recommend that handlers use a
		/// Shell item array rather than clipboard formats like <c>CF_HDROP</c> and <c>CFSTR_SHELLIDLIST</c> (also known as HIDA) as it
		/// leads to simpler code and allows some performance improvements.
		/// </para>
		/// <para>
		/// The resulting shell item array holds a reference to the source data object. Therefore, that data object must remain valid for
		/// the lifetime of the shell item array. Notably, the data objects passed to IDropTarget methods are no longer valid after the drop
		/// operation completes.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-shcreateshellitemarrayfromdataobject SHSTDAPI
		// SHCreateShellItemArrayFromDataObject( IDataObject *pdo, REFIID riid, void **ppv );
		[PInvokeData("shobjidl_core.h", MSDNShortId = "91e65c9a-0600-42e3-97f5-2a5960e1ec89")]
		public static IShellItemArray SHCreateShellItemArrayFromDataObject(IDataObject pdo)
		{
			SHCreateShellItemArrayFromDataObject(pdo, typeof(IShellItemArray).GUID, out var o).ThrowIfFailed();
			return o;
		}

		/// <summary>Creates a Shell item array object from a list of ITEMIDLIST structures.</summary>
		/// <param name="cidl">The number of elements in the array.</param>
		/// <param name="rgpidl">A list of cidl constant pointers to ITEMIDLIST structures.</param>
		/// <param name="ppsiItemArray">When this function returns, contains an IShellItemArray interface pointer.</param>
		[DllImport(Lib.Shell32, CharSet = CharSet.Unicode, ExactSpelling = true)]
		[SecurityCritical, SuppressUnmanagedCodeSecurity]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762146")]
		public static extern HRESULT SHCreateShellItemArrayFromIDLists(uint cidl, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] IntPtr[] rgpidl, out IShellItemArray ppsiItemArray);

		/// <summary>
		/// <para>Creates an array of one element from a single Shell item.</para>
		/// </summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>Pointer to IShellItem object that represents the item.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>A reference to the IID of the interface to retrieve through , typically IID_IShellItemArray.</para>
		/// </param>
		/// <param name="ppv">
		/// <para>Type: <c>void**</c></para>
		/// <para>When this method returns, contains the interface pointer requested in . This is typically a pointer to an IShellItemArray.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>This function creates a one-element array from a single item. To create an array from the contents of a folder, use SHCreateShellItemArray.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-shcreateshellitemarrayfromshellitem SHSTDAPI
		// SHCreateShellItemArrayFromShellItem( IShellItem *psi, REFIID riid, void **ppv );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shobjidl_core.h", MSDNShortId = "93401708-6f11-474d-8009-24554f316e79")]
		public static extern HRESULT SHCreateShellItemArrayFromShellItem([In] IShellItem psi, in Guid riid, out IShellItemArray ppv);

		/// <summary>
		/// <para>Creates an IShellItem or related object based on an item specified by an IDataObject.</para>
		/// </summary>
		/// <param name="pdtobj">
		/// <para>Type: <c>IDataObject*</c></para>
		/// <para>A pointer to the source IDataObject instance.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Type: <c>DATAOBJ_GET_ITEM_FLAGS</c></para>
		/// <para>
		/// One or more values from the DATAOBJ_GET_ITEM_FLAGS enumeration to specify options regarding the target object. This value can be 0.
		/// </para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>A reference to the IID of the interface to retrieve through , typically IID_IShellItem.</para>
		/// </param>
		/// <param name="ppv">
		/// <para>Type: <c>void**</c></para>
		/// <para>When this method returns, contains the interface pointer requested in . This is typically IShellItem.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// It is recommended that you use the <c>IID_PPV_ARGS</c> macro, defined in Objbase.h, to package the and parameters. This macro
		/// provides the correct IID based on the interface pointed to by the value in , which eliminates the possibility of a coding error.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-shgetitemfromdataobject HRESULT
		// SHGetItemFromDataObject( IDataObject *pdtobj, DATAOBJ_GET_ITEM_FLAGS dwFlags, REFIID riid, void **ppv );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shobjidl_core.h", MSDNShortId = "1d7b9ffa-9980-4d68-85e4-7bab667be168")]
		public static extern HRESULT SHGetItemFromDataObject(IDataObject pdtobj, DATAOBJ_GET_ITEM_FLAGS dwFlags, in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 2)] out object ppv);

		/// <summary>Creates an IShellItem or related object based on an item specified by an IDataObject.</summary>
		/// <typeparam name="TIntf">The type of the requested interface. This will typically be IShellItem or IShellItem2.</typeparam>
		/// <param name="pdtobj">
		/// <para>Type: <c>IDataObject*</c></para>
		/// <para>A pointer to the source IDataObject instance.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Type: <c>DATAOBJ_GET_ITEM_FLAGS</c></para>
		/// <para>
		/// One or more values from the DATAOBJ_GET_ITEM_FLAGS enumeration to specify options regarding the target object. This value can be 0.
		/// </para>
		/// </param>
		/// <returns>When this method returns, contains the interface pointer requested. This is typically IShellItem.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-shgetitemfromdataobject HRESULT
		// SHGetItemFromDataObject( IDataObject *pdtobj, DATAOBJ_GET_ITEM_FLAGS dwFlags, REFIID riid, void **ppv );
		[PInvokeData("shobjidl_core.h", MSDNShortId = "1d7b9ffa-9980-4d68-85e4-7bab667be168")]
		public static TIntf SHGetItemFromDataObject<TIntf>(IDataObject pdtobj, DATAOBJ_GET_ITEM_FLAGS dwFlags) where TIntf : class =>
			IidGetObj<TIntf>((in Guid g, out object o) => SHGetItemFromDataObject(pdtobj, dwFlags, g, out o));

		/// <summary>
		/// <para>Retrieves an IShellItem for an object.</para>
		/// </summary>
		/// <param name="punk">
		/// <para>Type: <c>IUnknown*</c></para>
		/// <para>A pointer to the IUnknown of the object.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>Reference to the desired IID.</para>
		/// </param>
		/// <param name="ppv">
		/// <para>Type: <c>void**</c></para>
		/// <para>When this method returns, contains the interface pointer requested in . This is typically IShellItem or a related interface.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// From the standpoint of performance, this method is preferred to SHGetIDListFromObject in those cases where the IDList is already
		/// bound to a folder.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-shgetitemfromobject SHSTDAPI
		// SHGetItemFromObject( IUnknown *punk, REFIID riid, void **ppv );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shobjidl_core.h", MSDNShortId = "0ef494c0-81c7-4fbd-9c37-78861d8ac63b")]
		public static extern HRESULT SHGetItemFromObject([MarshalAs(UnmanagedType.IUnknown)] object punk, in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 1)] out object ppv);

		/// <summary>Retrieves an IShellItem for an object.</summary>
		/// <typeparam name="TIntf">The type of the requested interface. This is typically IShellItem or a related interface.</typeparam>
		/// <param name="punk">
		/// <para>Type: <c>IUnknown*</c></para>
		/// <para>A pointer to the IUnknown of the object.</para>
		/// </param>
		/// <returns>When this method returns, contains the interface pointer requested. This is typically IShellItem or a related interface.</returns>
		/// <remarks>
		/// From the standpoint of performance, this method is preferred to SHGetIDListFromObject in those cases where the IDList is already
		/// bound to a folder.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-shgetitemfromobject SHSTDAPI
		// SHGetItemFromObject( IUnknown *punk, REFIID riid, void **ppv );
		[PInvokeData("shobjidl_core.h", MSDNShortId = "0ef494c0-81c7-4fbd-9c37-78861d8ac63b")]
		public static TIntf SHGetItemFromObject<TIntf>(object punk) where TIntf : class =>
			IidGetObj<TIntf>((in Guid g, out object o) => SHGetItemFromObject(punk, g, out o));

		/// <summary>
		/// <para>Retrieves an object that supports IPropertyStore or related interfaces from a pointer to an item identifier list (PIDL).</para>
		/// </summary>
		/// <param name="pidl">
		/// <para>Type: <c>PCIDLIST_ABSOLUTE</c></para>
		/// <para>A pointer to an item ID list.</para>
		/// </param>
		/// <param name="flags">
		/// <para>Type: <c>GETPROPERTYSTOREFLAGS</c></para>
		/// <para>One or more values from the GETPROPERTYSTOREFLAGS constants. This parameter can also be <c>NULL</c>.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>A reference to the desired interface ID.</para>
		/// </param>
		/// <param name="ppv">
		/// <para>Type: <c>void**</c></para>
		/// <para>
		/// When this function returns, contains the interface pointer requested in . This is typically IPropertyStore or a related interface.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>None</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-shgetpropertystorefromidlist SHSTDAPI
		// SHGetPropertyStoreFromIDList( PCIDLIST_ABSOLUTE pidl, GETPROPERTYSTOREFLAGS flags, REFIID riid, void **ppv );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shobjidl_core.h", MSDNShortId = "2a3c3c80-1bfc-4da0-ba6e-ac9e9a5c3e5b")]
		public static extern HRESULT SHGetPropertyStoreFromIDList(PIDL pidl, GETPROPERTYSTOREFLAGS flags, in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 2)] out object ppv);

		/// <summary>
		/// Retrieves an object that supports IPropertyStore or related interfaces from a pointer to an item identifier list (PIDL).
		/// </summary>
		/// <typeparam name="TIntf">The type of the requested interface. This is typically IPropertyStore or a related interface.</typeparam>
		/// <param name="pidl">
		/// <para>Type: <c>PCIDLIST_ABSOLUTE</c></para>
		/// <para>A pointer to an item ID list.</para>
		/// </param>
		/// <param name="flags">
		/// <para>Type: <c>GETPROPERTYSTOREFLAGS</c></para>
		/// <para>One or more values from the GETPROPERTYSTOREFLAGS constants. This parameter can also be <c>NULL</c>.</para>
		/// </param>
		/// <returns>
		/// When this function returns, contains the interface pointer requested. This is typically IPropertyStore or a related interface.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-shgetpropertystorefromidlist SHSTDAPI
		// SHGetPropertyStoreFromIDList( PCIDLIST_ABSOLUTE pidl, GETPROPERTYSTOREFLAGS flags, REFIID riid, void **ppv );
		[PInvokeData("shobjidl_core.h", MSDNShortId = "2a3c3c80-1bfc-4da0-ba6e-ac9e9a5c3e5b")]
		public static TIntf SHGetPropertyStoreFromIDList<TIntf>(PIDL pidl, GETPROPERTYSTOREFLAGS flags) where TIntf : class =>
			IidGetObj<TIntf>((in Guid g, out object o) => SHGetPropertyStoreFromIDList(pidl, flags, g, out o));

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
		public static extern HRESULT SHGetPropertyStoreFromParsingName([In, MarshalAs(UnmanagedType.LPWStr)] string pszPath, [In, Optional] IBindCtx pbc,
			GETPROPERTYSTOREFLAGS flags, in Guid riid, out IPropertyStore propertyStore);

		/// <summary>
		/// <para>
		/// Retrieves the temporary property for the given item. A temporary property is a read/write store that holds properties only for
		/// the lifetime of the IShellItem object, rather than being persisted back into the item.
		/// </para>
		/// </summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the item for which the temporary property is to be retrieved.</para>
		/// </param>
		/// <param name="propkey">
		/// <para>Type: <c>REFPROPERTYKEY</c></para>
		/// <para>The property key.</para>
		/// </param>
		/// <param name="ppropvar">
		/// <para>Type: <c>PROPVARIANT*</c></para>
		/// <para>A pointer to the temporary property for the item.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-shgettemporarypropertyforitem SHSTDAPI
		// SHGetTemporaryPropertyForItem( IShellItem *psi, REFPROPERTYKEY propkey, PROPVARIANT *ppropvar );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shobjidl_core.h", MSDNShortId = "53953a5a-04a2-4749-a03b-8cbd5ac889f1")]
		public static extern HRESULT SHGetTemporaryPropertyForItem(IShellItem psi, in PROPERTYKEY propkey, PROPVARIANT ppropvar);

		/// <summary>
		/// <para>Applies the default set of properties on a Shell item.</para>
		/// </summary>
		/// <param name="hwnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the item's parent window, which receives error notifications. This value can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the IShellItem object that represents the item.</para>
		/// </param>
		/// <param name="dwFileOpFlags">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Flags that customize the operation. See IFileOperation::SetOperationFlags for flag values.</para>
		/// </param>
		/// <param name="pfops">
		/// <para>Type: <c>IFileOperationProgressSink*</c></para>
		/// <para>
		/// A pointer to an IFileOperationProgressSink object used to follow the progress of the operation. See IFileOperation::Advise for
		/// details. This value can be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The list of properties to set a default value comes from the <c>SetDefaultsFor</c> registry entry under the ProgID for the file
		/// association of the item. The list is prefixed by "" and contains the canonical names of the properties to set the default value,
		/// for example, "". The possible properties for this list are System.Author, System.Document.DateCreated, and
		/// System.Photo.DateTaken. If the <c>SetDefaultsFor</c> entry does not exist on the ProgID, this function uses the default found on
		/// the <c>SetDefaultsFor</c> entry of <c>HKEY_CLASSES_ROOT</c>&lt;b&gt;*.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl/nf-shobjidl-shsetdefaultproperties SHSTDAPI SHSetDefaultProperties(
		// HWND hwnd, IShellItem *psi, DWORD dwFileOpFlags, IFileOperationProgressSink *pfops );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shobjidl.h", MSDNShortId = "c3ab80a3-c1f3-4223-9fe3-f7fe48c36460")]
		public static extern HRESULT SHSetDefaultProperties(HWND hwnd, IShellItem psi, FILEOP_FLAGS dwFileOpFlags, IFileOperationProgressSink pfops);

		/// <summary>
		/// <para>
		/// Sets a temporary property for the specified item. A temporary property is kept in a read/write store that holds properties only
		/// for the lifetime of the IShellItem object, instead of writing them back into the item.
		/// </para>
		/// </summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the item on which the temporary property is to be set.</para>
		/// </param>
		/// <param name="propkey">
		/// <para>Type: <c>REFPROPERTYKEY</c></para>
		/// <para>Reference to the PROPERTYKEY that identifies the temporary property that is being set.</para>
		/// </param>
		/// <param name="propvar">
		/// <para>Type: <c>REFPROPVARIANT</c></para>
		/// <para>Reference to a PROPVARIANT that contains the value of the temporary property.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>A temporary value can only be read with SHGetTemporaryPropertyForItem or by passing GPS_TEMPORARY to IShellItem2::GetPropertyStore.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-shsettemporarypropertyforitem SHSTDAPI
		// SHSetTemporaryPropertyForItem( IShellItem *psi, REFPROPERTYKEY propkey, REFPROPVARIANT propvar );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shobjidl_core.h", MSDNShortId = "779b1b2e-cd4b-404f-9d50-ac87b81640d2")]
		public static extern HRESULT SHSetTemporaryPropertyForItem(IShellItem psi, in PROPERTYKEY propkey, PROPVARIANT propvar);

		/// <summary>
		/// <para>Deprecated. Returns a pointer to an ITEMIDLIST structure when passed a path.</para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>Type: <c>PCWSTR</c></para>
		/// <para>A pointer to a null-terminated string that contains the path to be converted to a PIDL.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>PIDLIST_ABSOLUTE</c></para>
		/// <para>Returns a pointer to an ITEMIDLIST structure if successful, or <c>NULL</c> otherwise.</para>
		/// </returns>
		/// <remarks>
		/// <para>Prior to Windows 7, this function was declared in Shlobj.h. In Windows 7 and later versions, it is declared in Shobjidl.h.</para>
		/// <para>
		/// <c>Note</c> This function is available through Windows 7 and Windows Server 2003. It is possible that it will not be present in
		/// future versions of Windows.
		/// </para>
		/// <para>An alternative to this function is as follows:</para>
		/// <list type="number">
		/// <item>Call SHGetDesktopFolder to obtain IShellFolder for the desktop folder.</item>
		/// <item>Get the IShellFolder's bind context (IBindCtx).</item>
		/// <item>Call IShellFolder::ParseDisplayName with the IBindCtx and the path.</item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-shsimpleidlistfrompath PIDLIST_ABSOLUTE
		// SHSimpleIDListFromPath( PCWSTR pszPath );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shobjidl_core.h", MSDNShortId = "349974c2-4ab9-4eb2-897d-a5934893ed07")]
		public static extern PIDL SHSimpleIDListFromPath([MarshalAs(UnmanagedType.LPWStr)] string pszPath);

		/// <summary>Clones an ITEMIDLIST structure.</summary>
		/// <param name="pidl">A pointer to the ITEMIDLIST structure to be cloned.</param>
		/// <returns>Returns a pointer to a copy of the ITEMIDLIST structure pointed to by pidl.</returns>
		[DllImport(Lib.Shell32, EntryPoint = "ILClone", SetLastError = false)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb776433")]
		internal static extern IntPtr IntILClone(IntPtr pidl);

		/// <summary>Combines two ITEMIDLIST structures.</summary>
		/// <param name="pidl1">A pointer to the first ITEMIDLIST structure.</param>
		/// <param name="pidl2">
		/// A pointer to the second ITEMIDLIST structure. This structure is appended to the structure pointed to by pidl1.
		/// </param>
		/// <returns>
		/// Returns an ITEMIDLIST containing the combined structures. If you set either pidl1 or pidl2 to NULL, the returned ITEMIDLIST
		/// structure is a clone of the non-NULL parameter. Returns NULL if pidl1 and pidl2 are both set to NULL.
		/// </returns>
		[DllImport(Lib.Shell32, EntryPoint = "ILCombine", SetLastError = false)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb776437")]
		internal static extern IntPtr IntILCombine(IntPtr pidl1, IntPtr pidl2);

		private static T IidGetObj<T>(IidFunc f) where T : class
		{
			f(typeof(T).GUID, out var ppv).ThrowIfFailed();
			return (T)ppv;
		}

		/// <summary>Implements CLSID_ApplicationAssociationRegistration to create IApplicationAssociationRegistration.</summary>
		[PInvokeData("shobjidl_core.h")]
		[ComImport, Guid("591209c7-767b-42b2-9fba-44ee4615f2c7"), ClassInterface(ClassInterfaceType.None)]
		public class ApplicationAssociationRegistration { }

		/// <summary>Implements CLSID_ApplicationDestinations to create IApplicationDestinations.</summary>
		[PInvokeData("shobjidl_core.h")]
		[ComImport, Guid("86c14003-4d6b-4ef3-a7b4-0506663b2e68"), ClassInterface(ClassInterfaceType.None)]
		public class ApplicationDestinations { }

		/// <summary>Class interface for IEnumerableObjectCollection.</summary>
		[ComImport, Guid("2d3468c1-36a7-43b6-ac24-d3f02fd9607a"), ClassInterface(ClassInterfaceType.None)]
		public class CEnumerableObjectCollection { }
	}
}