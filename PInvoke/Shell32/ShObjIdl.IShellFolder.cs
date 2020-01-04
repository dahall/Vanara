using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security;
using static Vanara.PInvoke.Ole32;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>
		/// Determines the types of items included in an enumeration. These values are used with the IShellFolder::EnumObjects method.
		/// </summary>
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

			/// <summary>
			/// Include hidden items in the enumeration. This does not include hidden system items. (To include hidden system items, use SHCONTF_INCLUDESUPERHIDDEN.)
			/// </summary>
			SHCONTF_INCLUDEHIDDEN = 0x00080,

			/// <summary>
			/// No longer used; always assumed. IShellFolder::EnumObjects can return without validating the enumeration object. Validation
			/// can be postponed until the first call to IEnumIDList::Next. Use this flag when a user interface might be displayed prior to
			/// the first IEnumIDList::Next call. For a user interface to be presented, hwnd must be set to a valid window handle.
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

			/// <summary>
			/// Windows Vista and later. Enumerate items as a simple list even if the folder itself is not structured in that way.
			/// </summary>
			SHCONTF_FLATLIST = 0x04000,

			/// <summary>
			/// Windows Vista and later. The calling application is monitoring for change notifications. This means that the enumerator does
			/// not have to return all results. Items can be reported through change notifications.
			/// </summary>
			SHCONTF_ENABLE_ASYNC = 0x08000,

			/// <summary>
			/// Windows 7 and later. Include hidden system items in the enumeration. This value does not include hidden non-system items. (To
			/// include hidden non-system items, use SHCONTF_INCLUDEHIDDEN.)
			/// </summary>
			SHCONTF_INCLUDESUPERHIDDEN = 0x10000
		}

		/// <summary>
		/// Defines the values used with the IShellFolder::GetDisplayNameOf and IShellFolder::SetNameOf methods to specify the type of file
		/// or folder names used by those methods.
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
			/// The name is used for parsing. That is, it can be passed to IShellFolder::ParseDisplayName to recover the object's PIDL. The
			/// form this name takes depends on the particular object. When SHGDN_FORPARSING is used alone, the name is relative to the
			/// desktop. When combined with SHGDN_INFOLDER, the name is relative to the folder from which the request was made.
			/// </summary>
			SHGDN_FORPARSING = 0x8000,

			/// <summary>
			/// The name is relative to the folder from which the request was made. This is the name display to the user when used in the
			/// context of the folder. For example, it is used in the view and in the address bar path segment for the folder. This name
			/// should not include disambiguation information—for instance "username" instead of "username (on Machine)" for a particular
			/// user's folder. Use this flag in combinations with SHGDN_FORPARSING and SHGDN_FOREDITING.
			/// </summary>
			SHGDN_INFOLDER = 1,

			/// <summary>
			/// When not combined with another flag, return the parent-relative name that identifies the item, suitable for displaying to the
			/// user. This name often does not include extra information such as the file name extension and does not need to be unique. This
			/// name might include information that identifies the folder that contains the item. For instance, this flag could cause
			/// IShellFolder::GetDisplayNameOf to return the string "username (on Machine)" for a particular user's folder.
			/// </summary>
			SHGDN_NORMAL = 0
		}

		/// <summary>A standard OLE enumerator used by a client to determine the available search objects for a folder.</summary>
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0E700BE1-9DB6-11d1-A1CE-00C04FD75D13")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb761992")]
		public interface IEnumExtraSearch
		{
			/// <summary>Used to request information on one or more search objects.</summary>
			/// <param name="celt">
			/// The number of search objects to be enumerated, starting from the current object. If celt is too large, the method should stop
			/// and return the actual number of search objects in pceltFetched.
			/// </param>
			/// <param name="rgelt">
			/// A pointer to an array of pceltFetched EXTRASEARCH structures containing information on the enumerated objects.
			/// </param>
			/// <param name="pceltFetched">The number of objects actually enumerated. This may be less than celt.</param>
			/// <returns>Returns S_OK if successful, or a COM-defined error code otherwise.</returns>
			[PreserveSig]
			HRESULT Next([In] uint celt,
				[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] EXTRASEARCH[] rgelt,
				out uint pceltFetched);

			/// <summary>Skip a specified number of objects.</summary>
			/// <param name="celt">The number of objects to skip.</param>
			/// <returns>Returns S_OK if successful, or a COM-defined error code otherwise.</returns>
			[PreserveSig]
			HRESULT Skip([In] uint celt);

			/// <summary>Used to reset the enumeration index to zero.</summary>
			void Reset();

			/// <summary>Used to request a duplicate of the enumerator object to preserve its current state.</summary>
			/// <returns>A pointer to the IEnumExtraSearch interface of a new enumerator object.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			IEnumExtraSearch Clone();
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
			/// Optional. A pointer to a bind context used to pass parameters as inputs and outputs to the parsing function. These passed
			/// parameters are often specific to the data source and are documented by the data source owners. For example, the file system
			/// data source accepts the name being parsed (as a WIN32_FIND_DATA structure), using the STR_FILE_SYS_BIND_DATA bind context
			/// parameter. STR_PARSE_PREFER_FOLDER_BROWSING can be passed to indicate that URLs are parsed using the file system data source
			/// when possible. Construct a bind context object using CreateBindCtx and populate the values using
			/// IBindCtx::RegisterObjectParam. See Bind Context String Keys for a complete list of these. If no data is being passed to or
			/// received from the parsing function, this value can be NULL.
			/// </param>
			/// <param name="pszDisplayName">
			/// A null-terminated Unicode string with the display name. Because each Shell folder defines its own parsing syntax, the form
			/// this string can take may vary. The desktop folder, for instance, accepts paths such as "C:\My Docs\My File.txt". It also will
			/// accept references to items in the namespace that have a GUID associated with them using the "::{GUID}" syntax.
			/// </param>
			/// <param name="pchEaten">
			/// A pointer to a ULONG value that receives the number of characters of the display name that was parsed. If your application
			/// does not need this information, set pchEaten to NULL, and no value will be returned.
			/// </param>
			/// <param name="ppidl">
			/// When this method returns, contains a pointer to the PIDL for the object. The returned item identifier list specifies the item
			/// relative to the parsing folder. If the object associated with pszDisplayName is within the parsing folder, the returned item
			/// identifier list will contain only one SHITEMID structure. If the object is in a subfolder of the parsing folder, the returned
			/// item identifier list will contain multiple SHITEMID structures. If an error occurs, NULL is returned in this address.
			/// <para>When it is no longer needed, it is the responsibility of the caller to free this resource by calling CoTaskMemFree.</para>
			/// </param>
			/// <param name="pdwAttributes">
			/// The value used to query for file attributes. If not used, it should be set to NULL. To query for one or more attributes,
			/// initialize this parameter with the SFGAO flags that represent the attributes of interest. On return, those attributes that
			/// are true and were requested will be set.
			/// </param>
			void ParseDisplayName(HWND hwnd, [In, Optional] IBindCtx pbc, [MarshalAs(UnmanagedType.LPWStr)] string pszDisplayName, out uint pchEaten, out PIDL ppidl, [In, Out] ref SFGAO pdwAttributes);

			/// <summary>
			/// Enables a client to determine the contents of a folder by creating an item identifier enumeration object and returning its
			/// IEnumIDList interface. The methods supported by that interface can then be used to enumerate the folder's contents.
			/// </summary>
			/// <param name="hwnd">
			/// If user input is required to perform the enumeration, this window handle should be used by the enumeration object as the
			/// parent window to take user input. An example would be a dialog box to ask for a password or prompt the user to insert a CD or
			/// floppy disk. If hwndOwner is set to NULL, the enumerator should not post any messages, and if user input is required, it
			/// should silently fail.
			/// </param>
			/// <param name="grfFlags">
			/// Flags indicating which items to include in the enumeration. For a list of possible values, see the SHCONTF enumerated type.
			/// </param>
			/// <returns>
			/// The address that receives a pointer to the IEnumIDList interface of the enumeration object created by this method. If an
			/// error occurs or no suitable subobjects are found, ppenumIDList is set to NULL.
			/// </returns>
			IEnumIDList EnumObjects(HWND hwnd, SHCONTF grfFlags);

			/// <summary>
			/// Retrieves a handler, typically the Shell folder object that implements IShellFolder for a particular item. Optional
			/// parameters that control the construction of the handler are passed in the bind context.
			/// </summary>
			/// <param name="pidl">
			/// The address of an ITEMIDLIST structure (PIDL) that identifies the subfolder. This value can refer to an item at any level
			/// below the parent folder in the namespace hierarchy. The structure contains one or more SHITEMID structures, followed by a
			/// terminating NULL.
			/// </param>
			/// <param name="pbc">
			/// A pointer to an IBindCtx interface on a bind context object that can be used to pass parameters to the construction of the
			/// handler. If this parameter is not used, set it to NULL. Because support for this parameter is optional for folder object
			/// implementations, some folders may not support the use of bind contexts.
			/// <para>
			/// Information that can be provided in the bind context includes a BIND_OPTS structure that includes a grfMode member that
			/// indicates the access mode when binding to a stream handler. Other parameters can be set and discovered using
			/// IBindCtx::RegisterObjectParam and IBindCtx::GetObjectParam.
			/// </para>
			/// </param>
			/// <param name="riid">
			/// The identifier of the interface to return. This may be IID_IShellFolder, IID_IStream, or any other interface that identifies
			/// a particular handler.
			/// </param>
			/// <returns>
			/// When this method returns, contains the address of a pointer to the requested interface. If an error occurs, a NULL pointer is
			/// returned at this address.
			/// </returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			object BindToObject([In] PIDL pidl, [In, Optional] IBindCtx pbc, in Guid riid);

			/// <summary>Requests a pointer to an object's storage interface.</summary>
			/// <param name="pidl">
			/// The address of an ITEMIDLIST structure that identifies the subfolder relative to its parent folder. The structure must
			/// contain exactly one SHITEMID structure followed by a terminating zero.
			/// </param>
			/// <param name="pbc">
			/// The optional address of an IBindCtx interface on a bind context object to be used during this operation. If this parameter is
			/// not used, set it to NULL. Because support for pbc is optional for folder object implementations, some folders may not support
			/// the use of bind contexts.
			/// </param>
			/// <param name="riid">
			/// The IID of the requested storage interface. To retrieve an IStream, IStorage, or IPropertySetStorage interface pointer, set
			/// riid to IID_IStream, IID_IStorage, or IID_IPropertySetStorage, respectively.
			/// </param>
			/// <returns>
			/// The address that receives the interface pointer specified by riid. If an error occurs, a NULL pointer is returned in this address.
			/// </returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			object BindToStorage([In] PIDL pidl, [In, Optional] IBindCtx pbc, in Guid riid);

			/// <summary>Determines the relative order of two file objects or folders, given their item identifier lists.</summary>
			/// <param name="lParam">
			/// A value that specifies how the comparison should be performed.
			/// <para>
			/// The lower sixteen bits of lParam define the sorting rule. Most applications set the sorting rule to the default value of
			/// zero, indicating that the two items should be compared by name. The system does not define any other sorting rules. Some
			/// folder objects might allow calling applications to use the lower sixteen bits of lParam to specify folder-specific sorting
			/// rules. The rules and their associated lParam values are defined by the folder.
			/// </para>
			/// <para>
			/// When the system folder view object calls IShellFolder::CompareIDs, the lower sixteen bits of lParam are used to specify the
			/// column to be used for the comparison.
			/// </para>
			/// <para>
			/// The upper sixteen bits of lParam are used for flags that modify the sorting rule. The system currently defines these modifier flags.
			/// </para>
			/// <list>
			/// <item>
			/// <term>SHCIDS_ALLFIELDS</term>
			/// <description>
			/// Version 5.0. Compare all the information contained in the ITEMIDLIST structure, not just the display names. This flag is
			/// valid only for folder objects that support the IShellFolder2 interface. For instance, if the two items are files, the folder
			/// should compare their names, sizes, file times, attributes, and any other information in the structures. If this flag is set,
			/// the lower sixteen bits of lParam must be zero.
			/// </description>
			/// </item>
			/// <item>
			/// <term>SHCIDS_CANONICALONLY</term>
			/// <description>
			/// Version 5.0. When comparing by name, compare the system names but not the display names. When this flag is passed, the two
			/// items are compared by whatever criteria the Shell folder determines are most efficient, as long as it implements a consistent
			/// sort function. This flag is useful when comparing for equality or when the results of the sort are not displayed to the user.
			/// This flag cannot be combined with other flags.
			/// </description>
			/// </item>
			/// </list>
			/// </param>
			/// <param name="pidl1">
			/// A pointer to the first item's ITEMIDLIST structure. It will be relative to the folder. This ITEMIDLIST structure can contain
			/// more than one element; therefore, the entire structure must be compared, not just the first element.
			/// </param>
			/// <param name="pidl2">
			/// A pointer to the second item's ITEMIDLIST structure. It will be relative to the folder. This ITEMIDLIST structure can contain
			/// more than one element; therefore, the entire structure must be compared, not just the first element.
			/// </param>
			/// <returns>
			/// If this method is successful, the CODE field of the HRESULT contains one of the following values. For information regarding
			/// the extraction of the CODE field from the returned HRESULT, see Remarks. If this method is unsuccessful, it returns a COM
			/// error code.
			/// </returns>
			[PreserveSig]
			HRESULT CompareIDs(IntPtr lParam, [In] PIDL pidl1, [In] PIDL pidl2);

			/// <summary>Requests an object that can be used to obtain information from or interact with a folder object.</summary>
			/// <param name="hwndOwner">
			/// A handle to the owner window. If you have implemented a custom folder view object, your folder view window should be created
			/// as a child of hwndOwner.
			/// </param>
			/// <param name="riid">A reference to the IID of the interface to retrieve through ppv, typically IID_IShellView.</param>
			/// <returns>
			/// When this method returns successfully, contains the interface pointer requested in riid. This is typically IShellView. See
			/// the Remarks section for more details.
			/// </returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			object CreateViewObject(HWND hwndOwner, in Guid riid);

			/// <summary>Gets the attributes of one or more file or folder objects contained in the object represented by IShellFolder.</summary>
			/// <param name="cidl">The number of items from which to retrieve attributes.</param>
			/// <param name="apidl">
			/// The address of an array of pointers to ITEMIDLIST structures, each of which uniquely identifies an item relative to the
			/// parent folder. Each ITEMIDLIST structure must contain exactly one SHITEMID structure followed by a terminating zero.
			/// </param>
			/// <param name="rgfInOut">
			/// Pointer to a single ULONG value that, on entry, contains the bitwise SFGAO attributes that the calling application is
			/// requesting. On exit, this value contains the requested attributes that are common to all of the specified items.
			/// </param>
			void GetAttributesOf(uint cidl, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] IntPtr[] apidl, ref SFGAO rgfInOut);

			/// <summary>Gets an object that can be used to carry out actions on the specified file objects or folders.</summary>
			/// <param name="hwndOwner">
			/// A handle to the owner window that the client should specify if it displays a dialog box or message box.
			/// </param>
			/// <param name="cidl">The number of file objects or subfolders specified in the apidl parameter.</param>
			/// <param name="apidl">
			/// The address of an array of pointers to ITEMIDLIST structures, each of which uniquely identifies a file object or subfolder
			/// relative to the parent folder. Each item identifier list must contain exactly one SHITEMID structure followed by a
			/// terminating zero.
			/// </param>
			/// <param name="riid">
			/// A reference to the IID of the interface to retrieve through ppv. This can be any valid interface identifier that can be
			/// created for an item. The most common identifiers used by the Shell are listed in the comments at the end of this reference.
			/// </param>
			/// <param name="rgfReserved">Reserved.</param>
			/// <returns>When this method returns successfully, contains the interface pointer requested in riid.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			object GetUIObjectOf(HWND hwndOwner, uint cidl, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] IntPtr[] apidl, in Guid riid, IntPtr rgfReserved = default);

			/// <summary>Retrieves the display name for the specified file object or subfolder.</summary>
			/// <param name="pidl">
			/// <para>Type: <c>PCUITEMID_CHILD</c></para>
			/// <para>PIDL that uniquely identifies the file object or subfolder relative to the parent folder.</para>
			/// </param>
			/// <param name="uFlags">
			/// <para>Type: <c>SHGDNF</c></para>
			/// <para>
			/// Flags used to request the type of display name to return. For a list of possible values, see the SHGDNF enumerated type.
			/// </para>
			/// </param>
			/// <param name="pName">
			/// <para>
			/// When this method returns, contains the display name. The type of name returned in this structure can be the requested type,
			/// but the Shell folder might return a different type.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// Normally, pidl can refer only to items contained by the parent folder. The PIDL must be single-level and contain exactly one
			/// SHITEMID structure followed by a terminating zero. If you want to retrieve the display name of an item that is deeper than
			/// one level away from the parent folder, use SHBindToParent to bind with the item's immediate parent folder and then pass the
			/// item's single-level PIDL to <c>IShellFolder::GetDisplayNameOf</c>.
			/// </para>
			/// <para>
			/// Also, if the SHGDN_FORPARSING flag is set in uFlags and the SHGDN_INFOLDER flag is not set, pidl can refer to an object at
			/// any level below the parent folder in the namespace hierarchy. At one time, pidl could be a multilevel PIDL, relative to the
			/// parent folder, and could contain multiple SHITEMID structures. However, this is no longer supported and pidl should now
			/// refer only to a single child item.
			/// </para>
			/// <para>
			/// The flags specified in uFlags are hints about the intended use of the name. They do not guarantee that IShellFolder will
			/// return the requested form of the name. If that form is not available, a different one might be returned. In particular,
			/// there is no guarantee that the name returned by the SHGDN_FORPARSING flag will be successfully parsed by
			/// IShellFolder::ParseDisplayName. There are also some combinations of flags that might cause the <c>GetDisplayNameOf</c>/
			/// <c>ParseDisplayName</c> round trip to not return the original identifier list. This occurrence is exceptional, but you
			/// should check to be sure.
			/// </para>
			/// <para>
			/// <c>Note</c> The parsing name that is returned when uFlags has the SHGDN_FORPARSING flag set is not necessarily a normal text
			/// string. Virtual folders such as My Computer might return a string containing the folder object's GUID in the form
			/// "::{GUID}". Developers who implement <c>IShellFolder::GetDisplayNameOf</c> are encouraged to return parse names that are as
			/// close to the display names as possible, because the end user often needs to type or edit these names.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellfolder-getdisplaynameof
			// HRESULT GetDisplayNameOf( PCUITEMID_CHILD pidl, SHGDNF uFlags, STRRET *pName );
			void GetDisplayNameOf([In] PIDL pidl, SHGDNF uFlags, out STRRET pName); //[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(STRRETMarshaler))] out string pName);

			/// <summary>Sets the display name of a file object or subfolder, changing the item identifier in the process.</summary>
			/// <param name="hwnd">A handle to the owner window of any dialog or message box that the client displays.</param>
			/// <param name="pidl">
			/// A pointer to an ITEMIDLIST structure that uniquely identifies the file object or subfolder relative to the parent folder. The
			/// structure must contain exactly one SHITEMID structure followed by a terminating zero.
			/// </param>
			/// <param name="pszName">A pointer to a null-terminated string that specifies the new display name.</param>
			/// <param name="uFlags">
			/// Flags that indicate the type of name specified by the pszName parameter. For a list of possible values and combinations of
			/// values, see SHGDNF.
			/// </param>
			/// <param name="ppidlOut">
			/// Optional. If specified, the address of a pointer to an ITEMIDLIST structure that receives the ITEMIDLIST of the renamed item.
			/// The caller requests this value by passing a non-null ppidlOut. Implementations of IShellFolder::SetNameOf must return a
			/// pointer to the new ITEMIDLIST in the ppidlOut parameter.
			/// </param>
			void SetNameOf([Optional] HWND hwnd, [In] PIDL pidl, [MarshalAs(UnmanagedType.LPWStr)] string pszName, SHGDNF uFlags, out PIDL ppidlOut);
		}

		/// <summary>
		/// Extends the capabilities of IShellFolder. Its methods provide a variety of information about the contents of a Shell folder.
		/// </summary>
		/// <seealso cref="Vanara.PInvoke.Shell32.IShellFolder"/>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("93F2F68C-1D1B-11d3-A30E-00C04F79ABD1")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb775075")]
		public interface IShellFolder2 : IShellFolder
		{
			/// <summary>Translates the display name of a file object or a folder into an item identifier list.</summary>
			/// <param name="hwnd">
			/// A window handle. The client should provide a window handle if it displays a dialog or message box. Otherwise set hwnd to NULL
			/// </param>
			/// <param name="pbc">
			/// Optional. A pointer to a bind context used to pass parameters as inputs and outputs to the parsing function. These passed
			/// parameters are often specific to the data source and are documented by the data source owners. For example, the file system
			/// data source accepts the name being parsed (as a WIN32_FIND_DATA structure), using the STR_FILE_SYS_BIND_DATA bind context
			/// parameter. STR_PARSE_PREFER_FOLDER_BROWSING can be passed to indicate that URLs are parsed using the file system data source
			/// when possible. Construct a bind context object using CreateBindCtx and populate the values using
			/// IBindCtx::RegisterObjectParam. See Bind Context String Keys for a complete list of these. If no data is being passed to or
			/// received from the parsing function, this value can be NULL.
			/// </param>
			/// <param name="pszDisplayName">
			/// A null-terminated Unicode string with the display name. Because each Shell folder defines its own parsing syntax, the form
			/// this string can take may vary. The desktop folder, for instance, accepts paths such as "C:\My Docs\My File.txt". It also will
			/// accept references to items in the namespace that have a GUID associated with them using the "::{GUID}" syntax.
			/// </param>
			/// <param name="pchEaten">
			/// A pointer to a ULONG value that receives the number of characters of the display name that was parsed. If your application
			/// does not need this information, set pchEaten to NULL, and no value will be returned.
			/// </param>
			/// <param name="ppidl">
			/// When this method returns, contains a pointer to the PIDL for the object. The returned item identifier list specifies the item
			/// relative to the parsing folder. If the object associated with pszDisplayName is within the parsing folder, the returned item
			/// identifier list will contain only one SHITEMID structure. If the object is in a subfolder of the parsing folder, the returned
			/// item identifier list will contain multiple SHITEMID structures. If an error occurs, NULL is returned in this address.
			/// <para>When it is no longer needed, it is the responsibility of the caller to free this resource by calling CoTaskMemFree.</para>
			/// </param>
			/// <param name="pdwAttributes">
			/// The value used to query for file attributes. If not used, it should be set to NULL. To query for one or more attributes,
			/// initialize this parameter with the SFGAO flags that represent the attributes of interest. On return, those attributes that
			/// are true and were requested will be set.
			/// </param>
			new void ParseDisplayName(HWND hwnd, [In, Optional] IBindCtx pbc, [MarshalAs(UnmanagedType.LPWStr)] string pszDisplayName, out uint pchEaten, out PIDL ppidl, [In, Out] ref SFGAO pdwAttributes);

			/// <summary>
			/// Enables a client to determine the contents of a folder by creating an item identifier enumeration object and returning its
			/// IEnumIDList interface. The methods supported by that interface can then be used to enumerate the folder's contents.
			/// </summary>
			/// <param name="hwnd">
			/// If user input is required to perform the enumeration, this window handle should be used by the enumeration object as the
			/// parent window to take user input. An example would be a dialog box to ask for a password or prompt the user to insert a CD or
			/// floppy disk. If hwndOwner is set to NULL, the enumerator should not post any messages, and if user input is required, it
			/// should silently fail.
			/// </param>
			/// <param name="grfFlags">
			/// Flags indicating which items to include in the enumeration. For a list of possible values, see the SHCONTF enumerated type.
			/// </param>
			/// <returns>
			/// The address that receives a pointer to the IEnumIDList interface of the enumeration object created by this method. If an
			/// error occurs or no suitable subobjects are found, ppenumIDList is set to NULL.
			/// </returns>
			new IEnumIDList EnumObjects(HWND hwnd, SHCONTF grfFlags);

			/// <summary>
			/// Retrieves a handler, typically the Shell folder object that implements IShellFolder for a particular item. Optional
			/// parameters that control the construction of the handler are passed in the bind context.
			/// </summary>
			/// <param name="pidl">
			/// The address of an ITEMIDLIST structure (PIDL) that identifies the subfolder. This value can refer to an item at any level
			/// below the parent folder in the namespace hierarchy. The structure contains one or more SHITEMID structures, followed by a
			/// terminating NULL.
			/// </param>
			/// <param name="pbc">
			/// A pointer to an IBindCtx interface on a bind context object that can be used to pass parameters to the construction of the
			/// handler. If this parameter is not used, set it to NULL. Because support for this parameter is optional for folder object
			/// implementations, some folders may not support the use of bind contexts.
			/// <para>
			/// Information that can be provided in the bind context includes a BIND_OPTS structure that includes a grfMode member that
			/// indicates the access mode when binding to a stream handler. Other parameters can be set and discovered using
			/// IBindCtx::RegisterObjectParam and IBindCtx::GetObjectParam.
			/// </para>
			/// </param>
			/// <param name="riid">
			/// The identifier of the interface to return. This may be IID_IShellFolder, IID_IStream, or any other interface that identifies
			/// a particular handler.
			/// </param>
			/// <returns>
			/// When this method returns, contains the address of a pointer to the requested interface. If an error occurs, a NULL pointer is
			/// returned at this address.
			/// </returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			new object BindToObject([In] PIDL pidl, [In, Optional] IBindCtx pbc, in Guid riid);

			/// <summary>Requests a pointer to an object's storage interface.</summary>
			/// <param name="pidl">
			/// The address of an ITEMIDLIST structure that identifies the subfolder relative to its parent folder. The structure must
			/// contain exactly one SHITEMID structure followed by a terminating zero.
			/// </param>
			/// <param name="pbc">
			/// The optional address of an IBindCtx interface on a bind context object to be used during this operation. If this parameter is
			/// not used, set it to NULL. Because support for pbc is optional for folder object implementations, some folders may not support
			/// the use of bind contexts.
			/// </param>
			/// <param name="riid">
			/// The IID of the requested storage interface. To retrieve an IStream, IStorage, or IPropertySetStorage interface pointer, set
			/// riid to IID_IStream, IID_IStorage, or IID_IPropertySetStorage, respectively.
			/// </param>
			/// <returns>
			/// The address that receives the interface pointer specified by riid. If an error occurs, a NULL pointer is returned in this address.
			/// </returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			new object BindToStorage([In] PIDL pidl, [In, Optional] IBindCtx pbc, in Guid riid);

			/// <summary>Determines the relative order of two file objects or folders, given their item identifier lists.</summary>
			/// <param name="lParam">
			/// A value that specifies how the comparison should be performed.
			/// <para>
			/// The lower sixteen bits of lParam define the sorting rule. Most applications set the sorting rule to the default value of
			/// zero, indicating that the two items should be compared by name. The system does not define any other sorting rules. Some
			/// folder objects might allow calling applications to use the lower sixteen bits of lParam to specify folder-specific sorting
			/// rules. The rules and their associated lParam values are defined by the folder.
			/// </para>
			/// <para>
			/// When the system folder view object calls IShellFolder::CompareIDs, the lower sixteen bits of lParam are used to specify the
			/// column to be used for the comparison.
			/// </para>
			/// <para>
			/// The upper sixteen bits of lParam are used for flags that modify the sorting rule. The system currently defines these modifier flags.
			/// </para>
			/// <list>
			/// <item>
			/// <term>SHCIDS_ALLFIELDS</term>
			/// <description>
			/// Version 5.0. Compare all the information contained in the ITEMIDLIST structure, not just the display names. This flag is
			/// valid only for folder objects that support the IShellFolder2 interface. For instance, if the two items are files, the folder
			/// should compare their names, sizes, file times, attributes, and any other information in the structures. If this flag is set,
			/// the lower sixteen bits of lParam must be zero.
			/// </description>
			/// </item>
			/// <item>
			/// <term>SHCIDS_CANONICALONLY</term>
			/// <description>
			/// Version 5.0. When comparing by name, compare the system names but not the display names. When this flag is passed, the two
			/// items are compared by whatever criteria the Shell folder determines are most efficient, as long as it implements a consistent
			/// sort function. This flag is useful when comparing for equality or when the results of the sort are not displayed to the user.
			/// This flag cannot be combined with other flags.
			/// </description>
			/// </item>
			/// </list>
			/// </param>
			/// <param name="pidl1">
			/// A pointer to the first item's ITEMIDLIST structure. It will be relative to the folder. This ITEMIDLIST structure can contain
			/// more than one element; therefore, the entire structure must be compared, not just the first element.
			/// </param>
			/// <param name="pidl2">
			/// A pointer to the second item's ITEMIDLIST structure. It will be relative to the folder. This ITEMIDLIST structure can contain
			/// more than one element; therefore, the entire structure must be compared, not just the first element.
			/// </param>
			/// <returns>
			/// If this method is successful, the CODE field of the HRESULT contains one of the following values. For information regarding
			/// the extraction of the CODE field from the returned HRESULT, see Remarks. If this method is unsuccessful, it returns a COM
			/// error code.
			/// </returns>
			[PreserveSig]
			new HRESULT CompareIDs(IntPtr lParam, [In] PIDL pidl1, [In] PIDL pidl2);

			/// <summary>Requests an object that can be used to obtain information from or interact with a folder object.</summary>
			/// <param name="hwndOwner">
			/// A handle to the owner window. If you have implemented a custom folder view object, your folder view window should be created
			/// as a child of hwndOwner.
			/// </param>
			/// <param name="riid">A reference to the IID of the interface to retrieve through ppv, typically IID_IShellView.</param>
			/// <returns>
			/// When this method returns successfully, contains the interface pointer requested in riid. This is typically IShellView. See
			/// the Remarks section for more details.
			/// </returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			new object CreateViewObject(HWND hwndOwner, in Guid riid);

			/// <summary>Gets the attributes of one or more file or folder objects contained in the object represented by IShellFolder.</summary>
			/// <param name="cidl">The number of items from which to retrieve attributes.</param>
			/// <param name="apidl">
			/// The address of an array of pointers to ITEMIDLIST structures, each of which uniquely identifies an item relative to the
			/// parent folder. Each ITEMIDLIST structure must contain exactly one SHITEMID structure followed by a terminating zero.
			/// </param>
			/// <param name="rgfInOut">
			/// Pointer to a single ULONG value that, on entry, contains the bitwise SFGAO attributes that the calling application is
			/// requesting. On exit, this value contains the requested attributes that are common to all of the specified items.
			/// </param>
			new void GetAttributesOf(uint cidl, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] IntPtr[] apidl, ref SFGAO rgfInOut);

			/// <summary>Gets an object that can be used to carry out actions on the specified file objects or folders.</summary>
			/// <param name="hwndOwner">
			/// A handle to the owner window that the client should specify if it displays a dialog box or message box.
			/// </param>
			/// <param name="cidl">The number of file objects or subfolders specified in the apidl parameter.</param>
			/// <param name="apidl">
			/// The address of an array of pointers to ITEMIDLIST structures, each of which uniquely identifies a file object or subfolder
			/// relative to the parent folder. Each item identifier list must contain exactly one SHITEMID structure followed by a
			/// terminating zero.
			/// </param>
			/// <param name="riid">
			/// A reference to the IID of the interface to retrieve through ppv. This can be any valid interface identifier that can be
			/// created for an item. The most common identifiers used by the Shell are listed in the comments at the end of this reference.
			/// </param>
			/// <param name="rgfReserved">Reserved.</param>
			/// <returns>When this method returns successfully, contains the interface pointer requested in riid.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			new object GetUIObjectOf(HWND hwndOwner, uint cidl, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] IntPtr[] apidl, in Guid riid, IntPtr rgfReserved = default);

			/// <summary>Retrieves the display name for the specified file object or subfolder.</summary>
			/// <param name="pidl">PIDL that uniquely identifies the file object or subfolder relative to the parent folder.</param>
			/// <param name="uFlags">
			/// Flags used to request the type of display name to return. For a list of possible values, see the SHGDNF enumerated type.
			/// </param>
			/// <returns>
			/// When this method returns, contains a pointer to a STRRET structure in which to return the display name. The type of name
			/// returned in this structure can be the requested type, but the Shell folder might return a different type.
			/// </returns>
			[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(STRRETMarshaler))]
			new string GetDisplayNameOf([In] PIDL pidl, SHGDNF uFlags);

			/// <summary>Sets the display name of a file object or subfolder, changing the item identifier in the process.</summary>
			/// <param name="hwnd">A handle to the owner window of any dialog or message box that the client displays.</param>
			/// <param name="pidl">
			/// A pointer to an ITEMIDLIST structure that uniquely identifies the file object or subfolder relative to the parent folder. The
			/// structure must contain exactly one SHITEMID structure followed by a terminating zero.
			/// </param>
			/// <param name="pszName">A pointer to a null-terminated string that specifies the new display name.</param>
			/// <param name="uFlags">
			/// Flags that indicate the type of name specified by the pszName parameter. For a list of possible values and combinations of
			/// values, see SHGDNF.
			/// </param>
			/// <param name="ppidlOut">
			/// Optional. If specified, the address of a pointer to an ITEMIDLIST structure that receives the ITEMIDLIST of the renamed item.
			/// The caller requests this value by passing a non-null ppidlOut. Implementations of IShellFolder::SetNameOf must return a
			/// pointer to the new ITEMIDLIST in the ppidlOut parameter.
			/// </param>
			new void SetNameOf(HWND hwnd, [In] PIDL pidl, [MarshalAs(UnmanagedType.LPWStr)] string pszName, SHGDNF uFlags, out PIDL ppidlOut);

			/// <summary>Returns the globally unique identifier (GUID) of the default search object for the folder.</summary>
			/// <returns>The GUID of the default search object.</returns>
			Guid GetDefaultSearchGUID();

			/// <summary>Requests a pointer to an interface that allows a client to enumerate the available search objects.</summary>
			/// <returns>The address of a pointer to an enumerator object's IEnumExtraSearch interface.</returns>
			[return: MarshalAs(UnmanagedType.IUnknown)]
			IEnumExtraSearch EnumSearches();

			/// <summary>Gets the default sorting and display columns.</summary>
			/// <param name="dwRes">Reserved. Set to zero.</param>
			/// <param name="pSort">A pointer to a value that receives the index of the default sorted column.</param>
			/// <param name="pDisplay">A pointer to a value that receives the index of the default display column.</param>
			[PreserveSig]
			void GetDefaultColumn(uint dwRes, out uint pSort, out uint pDisplay);

			/// <summary>Gets the default state for a specified column.</summary>
			/// <param name="iColumn">An integer that specifies the column number.</param>
			/// <returns>
			/// A pointer to a value that contains flags that indicate the default column state. This parameter can include a combination of
			/// the following flags.
			/// </returns>
			SHCOLSTATE GetDefaultColumnState(uint iColumn);

			/// <summary>
			/// Gets detailed information, identified by a property set identifier (FMTID) and a property identifier (PID), on an item in a
			/// Shell folder.
			/// </summary>
			/// <param name="pidl">
			/// A PIDL of the item, relative to the parent folder. This method accepts only single-level PIDLs. The structure must contain
			/// exactly one SHITEMID structure followed by a terminating zero. This value cannot be NULL.
			/// </param>
			/// <param name="pscid">A pointer to an SHCOLUMNID structure that identifies the column.</param>
			/// <returns>
			/// A pointer to a VARIANT with the requested information. The value is fully typed. The value returned for properties from the
			/// property system must conform to the type specified in that property definition's typeInfo as the legacyType attribute.
			/// </returns>
			object GetDetailsEx(PIDL pidl, PROPERTYKEY pscid);

			/// <summary>Gets detailed information, identified by a column index, on an item in a Shell folder.</summary>
			/// <param name="pidl">
			/// PIDL of the item for which you are requesting information. This method accepts only single-level PIDLs. The structure must
			/// contain exactly one SHITEMID structure followed by a terminating zero. If this parameter is set to NULL, the title of the
			/// information field specified by iColumn is returned.
			/// </param>
			/// <param name="iColumn">
			/// The zero-based index of the desired information field. It is identical to the column number of the information as it is
			/// displayed in a Windows Explorer Details view.
			/// </param>
			/// <returns>
			/// The zero-based index of the desired information field. It is identical to the column number of the information as it is
			/// displayed in a Windows Explorer Details view.
			/// </returns>
			SHELLDETAILS GetDetailsOf(PIDL pidl, uint iColumn);

			/// <summary>Converts a column to the appropriate property set ID (FMTID) and property ID (PID).</summary>
			/// <param name="iColumn">The column ID.</param>
			/// <returns>A pointer to an SHCOLUMNID structure containing the FMTID and PID.</returns>
			PROPERTYKEY MapColumnToSCID(uint iColumn);
		}

		/// <summary>Extension method to simplify using the <see cref="IShellFolder.BindToObject"/> method.</summary>
		/// <typeparam name="T">Type of the interface to get.</typeparam>
		/// <param name="sf">An <see cref="IShellFolder"/> instance.</param>
		/// <param name="pidl">
		/// The address of an ITEMIDLIST structure (PIDL) that identifies the subfolder. This value can refer to an item at any level below
		/// the parent folder in the namespace hierarchy. The structure contains one or more SHITEMID structures, followed by a terminating NULL.
		/// </param>
		/// <param name="pbc">
		/// A pointer to an IBindCtx interface on a bind context object that can be used to pass parameters to the construction of the
		/// handler. If this parameter is not used, set it to NULL. Because support for this parameter is optional for folder object
		/// implementations, some folders may not support the use of bind contexts.
		/// <para>
		/// Information that can be provided in the bind context includes a BIND_OPTS structure that includes a grfMode member that indicates
		/// the access mode when binding to a stream handler. Other parameters can be set and discovered using IBindCtx::RegisterObjectParam
		/// and IBindCtx::GetObjectParam.
		/// </para>
		/// </param>
		/// <returns>Receives the interface pointer requested in <typeparamref name="T"/>.</returns>
		public static T BindToObject<T>(this IShellFolder sf, [In] PIDL pidl, [In, Optional] IBindCtx pbc) where T : class => (T)sf.BindToObject(pidl, pbc, typeof(T).GUID);

		/// <summary>Extension method to simplify using the <see cref="IShellFolder.BindToStorage"/> method.</summary>
		/// <typeparam name="T">Type of the interface to get.</typeparam>
		/// <param name="sf">An <see cref="IShellFolder"/> instance.</param>
		/// <param name="pidl">
		/// The address of an ITEMIDLIST structure that identifies the subfolder relative to its parent folder. The structure must contain
		/// exactly one SHITEMID structure followed by a terminating zero.
		/// </param>
		/// <param name="pbc">
		/// The optional address of an IBindCtx interface on a bind context object to be used during this operation. If this parameter is not
		/// used, set it to NULL. Because support for pbc is optional for folder object implementations, some folders may not support the use
		/// of bind contexts.
		/// </param>
		/// <returns>Receives the interface pointer requested in <typeparamref name="T"/>.</returns>
		public static T BindToStorage<T>(this IShellFolder sf, [In] PIDL pidl, [In, Optional] IBindCtx pbc) where T : class => (T)sf.BindToStorage(pidl, pbc, typeof(T).GUID);

		/// <summary>
		/// Enables a client to determine the contents of a folder by creating an item identifier enumeration object and returning its
		/// IEnumIDList interface. The methods supported by that interface can then be used to enumerate the folder's contents.
		/// </summary>
		/// <param name="sf">An <see cref="IShellFolder"/> instance.</param>
		/// <param name="grfFlags">
		/// Flags indicating which items to include in the enumeration. For a list of possible values, see the SHCONTF enumerated type.
		/// </param>
		/// <param name="hwnd">
		/// If user input is required to perform the enumeration, this window handle should be used by the enumeration object as the parent
		/// window to take user input. An example would be a dialog box to ask for a password or prompt the user to insert a CD or floppy
		/// disk. If hwndOwner is set to NULL, the enumerator should not post any messages, and if user input is required, it should
		/// silently fail.
		/// </param>
		/// <returns>An enumeration of the PIDL for the folder content items.</returns>
		public static IEnumerable<PIDL> EnumObjects(this IShellFolder sf, SHCONTF grfFlags = SHCONTF.SHCONTF_FOLDERS | SHCONTF.SHCONTF_NONFOLDERS, HWND hwnd = default) =>
			sf.EnumObjects(hwnd, grfFlags).Enumerate();

		/// <summary>Extension method to simplify using the <see cref="IShellFolder.CreateViewObject"/> method.</summary>
		/// <typeparam name="T">Type of the interface to get.</typeparam>
		/// <param name="sf">An <see cref="IShellFolder"/> instance.</param>
		/// <param name="hwndOwner">
		/// A handle to the owner window. If you have implemented a custom folder view object, your folder view window should be created as a
		/// child of hwndOwner.
		/// </param>
		/// <returns>Receives the interface pointer requested in <typeparamref name="T"/>.</returns>
		public static T CreateViewObject<T>(this IShellFolder sf, HWND hwndOwner) where T : class => (T)sf.CreateViewObject(hwndOwner, typeof(T).GUID);

		/// <summary>Retrieves the display name for the specified file object or subfolder.</summary>
		/// <param name="sf">An <see cref="IShellFolder"/> instance.</param>
		/// <param name="uFlags">
		/// <para>Type: <c>SHGDNF</c></para>
		/// <para>Flags used to request the type of display name to return. For a list of possible values, see the SHGDNF enumerated type.</para>
		/// </param>
		/// <param name="pidl">
		/// <para>Type: <c>PCUITEMID_CHILD</c></para>
		/// <para>PIDL that uniquely identifies the file object or subfolder relative to the parent folder.</para>
		/// </param>
		/// <returns>
		/// When this method returns, contains the display name. The type of name returned can be the requested type, but the Shell folder
		/// might return a different type.
		/// </returns>
		/// <remarks>
		/// <para>
		/// Normally, pidl can refer only to items contained by the parent folder. The PIDL must be single-level and contain exactly one
		/// SHITEMID structure followed by a terminating zero. If you want to retrieve the display name of an item that is deeper than one
		/// level away from the parent folder, use SHBindToParent to bind with the item's immediate parent folder and then pass the item's
		/// single-level PIDL to <c>IShellFolder::GetDisplayNameOf</c>.
		/// </para>
		/// <para>
		/// Also, if the SHGDN_FORPARSING flag is set in uFlags and the SHGDN_INFOLDER flag is not set, pidl can refer to an object at any
		/// level below the parent folder in the namespace hierarchy. At one time, pidl could be a multilevel PIDL, relative to the parent
		/// folder, and could contain multiple SHITEMID structures. However, this is no longer supported and pidl should now refer only to a
		/// single child item.
		/// </para>
		/// <para>
		/// The flags specified in uFlags are hints about the intended use of the name. They do not guarantee that IShellFolder will return
		/// the requested form of the name. If that form is not available, a different one might be returned. In particular, there is no
		/// guarantee that the name returned by the SHGDN_FORPARSING flag will be successfully parsed by IShellFolder::ParseDisplayName.
		/// There are also some combinations of flags that might cause the <c>GetDisplayNameOf</c>/ <c>ParseDisplayName</c> round trip to
		/// not return the original identifier list. This occurrence is exceptional, but you should check to be sure.
		/// </para>
		/// <para>
		/// <c>Note</c> The parsing name that is returned when uFlags has the SHGDN_FORPARSING flag set is not necessarily a normal text
		/// string. Virtual folders such as My Computer might return a string containing the folder object's GUID in the form "::{GUID}".
		/// Developers who implement <c>IShellFolder::GetDisplayNameOf</c> are encouraged to return parse names that are as close to the
		/// display names as possible, because the end user often needs to type or edit these names.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellfolder-getdisplaynameof
		// HRESULT GetDisplayNameOf( PCUITEMID_CHILD pidl, SHGDNF uFlags, STRRET *pName );
		public static string GetDisplayNameOf(this IShellFolder sf, SHGDNF uFlags, PIDL pidl) { sf.GetDisplayNameOf(pidl ?? PIDL.Null, uFlags, out var p); return p; }

		/// <summary>Extension method to simplify using the <see cref="IShellFolder.GetUIObjectOf"/> method.</summary>
		/// <typeparam name="T">Type of the interface to get.</typeparam>
		/// <param name="sf">An <see cref="IShellFolder"/> instance.</param>
		/// <param name="hwndOwner">
		/// A handle to the owner window that the client should specify if it displays a dialog box or message box.
		/// </param>
		/// <param name="apidl">
		/// An array of pointers to ITEMIDLIST structures, each of which uniquely identifies a file object or subfolder relative to the
		/// parent folder. Each item identifier list must contain exactly one SHITEMID structure followed by a terminating zero.
		/// </param>
		/// <returns>Receives the interface pointer requested in <typeparamref name="T"/>.</returns>
		public static T GetUIObjectOf<T>(this IShellFolder sf, HWND hwndOwner, PIDL[] apidl) where T : class => (T)sf.GetUIObjectOf(hwndOwner, (uint)apidl.Length, Array.ConvertAll(apidl, p => p.DangerousGetHandle()), typeof(T).GUID);

		/// <summary>
		/// Used by an IEnumExtraSearch enumerator object to return information on the search objects supported by a Shell Folder object.
		/// </summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb773283")]
		public struct EXTRASEARCH
		{
			/// <summary>A search object's GUID.</summary>
			public Guid guidSearch;

			/// <summary>
			/// A Unicode string containing the search object's friendly name. It will be used to identify the search engine on the Search
			/// Assistant menu.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
			public string wszFriendlyName;

			/// <summary>The URL that will be displayed in the search pane.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2084)]
			public string wszUrl;
		}
	}
}