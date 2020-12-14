using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security;
using System.Text;
using static Vanara.PInvoke.Ole32;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>Provides a set of flags for use with the CATEGORY_INFO structure.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/ne-shobjidl_core-categoryinfo_flags typedef enum
		// CATEGORYINFO_FLAGS { CATINFO_NORMAL, CATINFO_COLLAPSED, CATINFO_HIDDEN, CATINFO_EXPANDED, CATINFO_NOHEADER,
		// CATINFO_NOTCOLLAPSIBLE, CATINFO_NOHEADERCOUNT, CATINFO_SUBSETTED, CATINFO_SEPARATE_IMAGES, CATINFO_SHOWEMPTY } ;
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NE:shobjidl_core.CATEGORYINFO_FLAGS")]
		[Flags]
		public enum CATEGORYINFO_FLAGS
		{
			/// <summary>0x00000000. Applies default properties for the category.</summary>
			CATINFO_NORMAL = 0x00000000,

			/// <summary>0x00000001. The category should appear as collapsed</summary>
			CATINFO_COLLAPSED = 0x00000001,

			/// <summary>0x00000002. The category should appear as hidden.</summary>
			CATINFO_HIDDEN = 0x00000002,

			/// <summary>0x00000004. The category should appear as expanded.</summary>
			CATINFO_EXPANDED = 0x00000004,

			/// <summary>0x00000008. The category has no header.</summary>
			CATINFO_NOHEADER = 0x00000008,

			/// <summary>0x00000010. The category cannot be collapsed.</summary>
			CATINFO_NOTCOLLAPSIBLE = 0x00000010,

			/// <summary>0x00000020. The count of items in the category should not be displayed in the header.</summary>
			CATINFO_NOHEADERCOUNT = 0x00000020,

			/// <summary>0x00000040. Windows 7 and later. The category should appear subsetted.</summary>
			CATINFO_SUBSETTED = 0x00000040,

			/// <summary/>
			CATINFO_SEPARATE_IMAGES = 0x00000080,

			/// <summary/>
			CATINFO_SHOWEMPTY = 0x00000100,
		}

		/// <summary>Specifies methods for sorting category data.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/ne-shobjidl_core-catsort_flags
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NE:shobjidl_core.CATSORT_FLAGS")]
		[Flags]
		public enum CATSORT_FLAGS
		{
			/// <summary>Use the default sort order.</summary>
			CATSORT_DEFAULT,

			/// <summary>Use a method that sorts on category names.</summary>
			CATSORT_NAME,
		}

		/// <summary>
		/// Used by IObjectWithFolderEnumMode::GetMode and IObjectWithFolderEnumMode::SetMode methods to get and set the display modes for
		/// the folders.
		/// </summary>
		/// <remarks>
		/// If an item does not support the enumeration mode value (because it is not a folder or it does not provide the enumeration mode)
		/// then it is created in the default enumeration mode.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/ne-shobjidl_core-folder_enum_mode typedef enum FOLDER_ENUM_MODE
		// { FEM_VIEWRESULT, FEM_NAVIGATION } ;
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NE:shobjidl_core.FOLDER_ENUM_MODE")]
		public enum FOLDER_ENUM_MODE
		{
			/// <summary>Display mode to view the contents of a folder.</summary>
			FEM_VIEWRESULT,

			/// <summary>Display mode to view the contents of the folders in the navigation pane.</summary>
			FEM_NAVIGATION,
		}

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
			/// Windows 7 and later. Include hidden system items in the enumeration. This value does not include hidden non-system items.
			/// (To include hidden non-system items, use SHCONTF_INCLUDEHIDDEN.)
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
			/// When not combined with another flag, return the parent-relative name that identifies the item, suitable for displaying to
			/// the user. This name often does not include extra information such as the file name extension and does not need to be unique.
			/// This name might include information that identifies the folder that contains the item. For instance, this flag could cause
			/// IShellFolder::GetDisplayNameOf to return the string "username (on Machine)" for a particular user's folder.
			/// </summary>
			SHGDN_NORMAL = 0
		}

		/// <summary>Exposes methods that are used to obtain information about item identifier lists.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-icategorizer
		[ComImport, Guid("a3b14589-9174-49a8-89a3-06a1ae2b9ba7"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ICategorizer
		{
			/// <summary>Gets the name of a categorizer, such as Group By Device Type, that can be displayed in the UI.</summary>
			/// <param name="pszDesc">
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>When this method returns, contains a pointer to a string of length cch that contains the categorizer name.</para>
			/// </param>
			/// <param name="cch">
			/// <para>Type: <c>UINT</c></para>
			/// <para>The number of characters in the pszDesc buffer.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// In the case of the system folder view object, if the description at pszDesc matches one of the category names listed in the
			/// folder's <c>Arrange Icons By</c> menu, a dot is placed by that name when the menu is displayed, either through the
			/// <c>View</c> menu or through the context menu.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-icategorizer-getdescription
			[PreserveSig]
			HRESULT GetDescription([MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDesc, uint cch);

			/// <summary>Gets a list of categories associated with a list of identifiers.</summary>
			/// <param name="cidl">
			/// <para>Type: <c>UINT</c></para>
			/// <para>The number of items in an item identifier list array.</para>
			/// </param>
			/// <param name="apidl">
			/// <para>Type: <c>PCUITEMID_CHILD_ARRAY*</c></para>
			/// <para>A pointer to an array of cidl item identifier list pointers.</para>
			/// </param>
			/// <param name="rgCategoryIds">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>When this method returns, contains a pointer to an array of cidl category identifiers.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The <c>ICategorizer::GetCategory</c> method accepts an array of pointers to item identifier lists (PIDLs) and fills an array
			/// of category identifiers.
			/// </para>
			/// <para><c>Important</c> The value -1 is an invalid category identifier.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-icategorizer-getcategory
			[PreserveSig]
			HRESULT GetCategory(uint cidl, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] IntPtr[] apidl, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] uint[] rgCategoryIds);

			/// <summary>Gets information about a category, such as the default display and the text to display in the UI.</summary>
			/// <param name="dwCategoryId">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>A <c>DWORD</c> that specifies a category identifier.</para>
			/// </param>
			/// <param name="pci">
			/// <para>Type: <c>CATEGORY_INFO*</c></para>
			/// <para>When this method returns, contains a pointer to a CATEGORY_INFO structure that contains the category information.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-icategorizer-getcategoryinfo
			[PreserveSig]
			HRESULT GetCategoryInfo(uint dwCategoryId, out CATEGORY_INFO pci );

			/// <summary>Determines the relative order of two items in their item identifier lists, and hence in the UI.</summary>
			/// <param name="csfFlags">
			/// <para>Type: <c>CATSORT_FLAGS</c></para>
			/// <para>A flag that specifies how the comparison should be performed. The parameter should be one of the values in CATSORT_FLAGS.</para>
			/// </param>
			/// <param name="dwCategoryId1">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>A <c>DWORD</c> that specifies the first category identifier to use in the comparison.</para>
			/// </param>
			/// <param name="dwCategoryId2">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>A <c>DWORD</c> that specifies the second category identifier to use in the comparison.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>
			/// If this method is successful, the CODE field of the HRESULT contains a value that specifies the outcome of the comparison,
			/// otherwise it returns a COM error code.
			/// </para>
			/// </returns>
			/// <remarks>
			/// <para>The following table shows the values returned in the CODE field of the HRESULT.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Less than zero</term>
			/// <term>The first item should precede the second (dwCategoryId1 &lt; dwCategoryId2).</term>
			/// </listheader>
			/// <item>
			/// <term>Greater than zero</term>
			/// <term>The first item should follow the second (dwCategoryId1 &gt; dwCategoryId2).</term>
			/// </item>
			/// <item>
			/// <term>Zero</term>
			/// <term>The two items are the same (dwCategoryId1 = dwCategoryId2).</term>
			/// </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-icategorizer-comparecategory
			[PreserveSig]
			HRESULT CompareCategory(CATSORT_FLAGS csfFlags, uint dwCategoryId1, uint dwCategoryId2);
		}

		/// <summary>Exposes a list of categorizers registered on an IShellFolder.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-icategoryprovider
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.ICategoryProvider")]
		[ComImport, Guid("9af64809-5864-4c26-a720-c1f78c086ee3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ICategoryProvider
		{
			/// <summary>Determines whether a column can be used as a category.</summary>
			/// <param name="pscid">
			/// <para>Type: <c>const SHCOLUMNID*</c></para>
			/// <para>
			/// A pointer to a SHCOLUMNID structure that identifies the column. Valid only when S_OK is returned. The GUID contained in this
			/// structure is then passed to ICategoryProvider::CreateCategory.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>Returns S_OK if the column can be used as a category or S_FALSE if not.</para>
			/// </returns>
			/// <remarks>
			/// When using the System Folder View Object in Category view ( <c>Show in Groups</c>), the titles of columns for which this
			/// method returns S_OK appear in the upper portion of the <c>Arrange Icons By</c> submenu.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-icategoryprovider-cancategorizeonscid
			// HRESULT CanCategorizeOnSCID( const SHCOLUMNID *pscid );
			[PreserveSig]
			HRESULT CanCategorizeOnSCID(in PROPERTYKEY pscid);

			/// <summary>Enables the folder to override the default grouping.</summary>
			/// <param name="pguid">
			/// <para>Type: <c>GUID*</c></para>
			/// <para>Not used.</para>
			/// </param>
			/// <param name="pscid">
			/// <para>Type: <c>SHCOLUMNID*</c></para>
			/// <para>When this method returns, contains a pointer to a SHCOLUMNID structure.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>Returns S_OK if successful, or an error value otherwise, including the following:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_FALSE</term>
			/// <term>There is no default group.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// <c>ICategoryProvider::GetDefaultCategory</c> returns an SHCOLUMNID structure that is used by the default categorizer. The
			/// method returns S_FALSE if a default group is not supported.
			/// </para>
			/// <para>
			/// <c>ICategoryProvider::GetDefaultCategory</c> is called only when a folder is first opened. After that, the user's grouping
			/// choice is cached in the property bag storing the state of the view. To force a call to
			/// <c>ICategoryProvider::GetDefaultCategory</c> after the folder is first opened, the <c>Shell</c> and <c>ShellNoRoam</c>
			/// registry keys must be deleted. They are found in the following location.
			/// </para>
			/// <para><c>Software</c><c>Microsoft</c><c>Windows</c><c>Shell</c><c>ShellNoRoam</c></para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-icategoryprovider-getdefaultcategory
			// HRESULT GetDefaultCategory( GUID *pguid, SHCOLUMNID *pscid );
			[PreserveSig]
			HRESULT GetDefaultCategory(out Guid pguid, out PROPERTYKEY pscid);

			/// <summary>Gets a GUID that represents the categorizer to use for the specified Shell column.</summary>
			/// <param name="pscid">
			/// <para>Type: <c>const SHCOLUMNID*</c></para>
			/// <para>A pointer to a SHCOLUMNID structure.</para>
			/// </param>
			/// <param name="pguid">
			/// <para>Type: <c>GUID*</c></para>
			/// <para>
			/// When this method returns, contains a pointer to a GUID that represents the categorizer to use for the SHCOLUMNID pointed to
			/// by pscid.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>Returns either S_OK on success or S_FALSE on failure.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-icategoryprovider-getcategoryforscid
			// HRESULT GetCategoryForSCID( const SHCOLUMNID *pscid, GUID *pguid );
			[PreserveSig]
			HRESULT GetCategoryForSCID(in PROPERTYKEY pscid, out Guid pguid);

			/// <summary>Gets the enumerator for the list of GUIDs that represent categories.</summary>
			/// <param name="penum">
			/// <para>Type: <c>IEnumGUID**</c></para>
			/// <para>
			/// When this method returns, contains the address of a pointer to an <c>IEnumGUID</c> interface that specifies a list of GUIDs
			/// that represent categories.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// In the case of the system folder view object, <c>ICategoryProvider::EnumCategories</c> is used to obtain additional
			/// categories that are not associated with a column. When the list of category GUIDs is returned through penum, the UI attempts
			/// to retrieve the name of each category. That name is then displayed as a category choice. In the case of Windows XP, that
			/// choice appears in the folder's <c>Arrange Icons By</c> menu.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-icategoryprovider-enumcategories
			[PreserveSig]
			HRESULT EnumCategories(out IEnumGUID penum);

			/// <summary>Gets the name of the specified category.</summary>
			/// <param name="pguid">
			/// <para>Type: <c>const GUID*</c></para>
			/// <para>A pointer to a GUID.</para>
			/// </param>
			/// <param name="pszName">
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>When this method returns, contains a pointer to a string that receives the name of the category.</para>
			/// </param>
			/// <param name="cch">
			/// <para>Type: <c>UINT</c></para>
			/// <para>An integer that receives the number of characters in the string.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-icategoryprovider-getcategoryname HRESULT
			// GetCategoryName( const GUID *pguid, LPWSTR pszName, UINT cch );
			[PreserveSig]
			HRESULT GetCategoryName(in Guid pguid, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszName, uint cch);

			/// <summary>Creates a category object.</summary>
			/// <param name="pguid">
			/// <para>Type: <c>const GUID*</c></para>
			/// <para>A pointer to the <c>GUID</c> for the category object.</para>
			/// </param>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>The identifier of the object to return. Currently, the only value supported by the system folder view object is IID_ICategorizer.</para>
			/// </param>
			/// <param name="ppv">
			/// <para>Type: <c>void**</c></para>
			/// <para>When this method returns, contains the address of a pointer to the category object.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-icategoryprovider-createcategory HRESULT
			// CreateCategory( const GUID *pguid, REFIID riid, void **ppv );
			[PreserveSig]
			HRESULT CreateCategory(in Guid pguid, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppv);
		}

		/// <summary>A standard OLE enumerator used by a client to determine the available search objects for a folder.</summary>
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0E700BE1-9DB6-11d1-A1CE-00C04FD75D13")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb761992")]
		public interface IEnumExtraSearch : Vanara.Collections.ICOMEnum<EXTRASEARCH>
		{
			/// <summary>Used to request information on one or more search objects.</summary>
			/// <param name="celt">
			/// The number of search objects to be enumerated, starting from the current object. If celt is too large, the method should
			/// stop and return the actual number of search objects in pceltFetched.
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

		/// <summary>Exposes methods that get and set enumeration modes of a parsed item.</summary>
		/// <remarks>
		/// <para>When to Implement</para>
		/// <para>This interface is implemented as part of a Shell namespace extension, specifically the IShellFolder interface.</para>
		/// <para>When to Use</para>
		/// <para>
		/// This interface is used by the IShellFolder::ParseDisplayName method to retrieve the FOLDER_ENUM_MODE value which controls the
		/// enumeration mode of the parsed item.
		/// </para>
		/// <para>
		/// Items with different enumeration modes compare canonically different (SHCIDS_CANONICALONLY) because they enumerate different
		/// sets of items.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-iobjectwithfolderenummode
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IObjectWithFolderEnumMode")]
		[ComImport, Guid("6a9d9026-0e6e-464c-b000-42ecc07de673"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IObjectWithFolderEnumMode
		{
			/// <summary>Sets the enumeration mode of the parsed item.</summary>
			/// <param name="feMode">
			/// <para>Type: <c>FOLDER_ENUM_MODE</c></para>
			/// <para>One of the FOLDER_ENUM_MODE values that specify the enumeration mode.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iobjectwithfolderenummode-setmode
			[PreserveSig]
			HRESULT SetMode(FOLDER_ENUM_MODE feMode);

			/// <summary>Retrieves the enumeration mode of the parsed item.</summary>
			/// <param name="pfeMode">
			/// <para>Type: <c>FOLDER_ENUM_MODE*</c></para>
			/// <para>Pointer to a value that, when this method returns successfully, receives one of the FOLDER_ENUM_MODE values specifying the enumeration mode.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iobjectwithfolderenummode-getmode
			[PreserveSig]
			HRESULT GetMode(out FOLDER_ENUM_MODE pfeMode);
		}

		/// <summary>Exposed by all Shell namespace folder objects, its methods are used to manage folders.</summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("000214E6-0000-0000-C000-000000000046")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb775075")]
		public interface IShellFolder
		{
			/// <summary>Translates the display name of a file object or a folder into an item identifier list.</summary>
			/// <param name="hwnd">
			/// <para>Type: <c>HWND</c></para>
			/// <para>
			/// A window handle. The client should provide a window handle if it displays a dialog or message box. Otherwise set hwnd to <c>NULL</c>.
			/// </para>
			/// </param>
			/// <param name="pbc">
			/// <para>Type: <c>IBindCtx*</c></para>
			/// <para>
			/// Optional. A pointer to a bind context used to pass parameters as inputs and outputs to the parsing function. These passed
			/// parameters are often specific to the data source and are documented by the data source owners. For example, the file system
			/// data source accepts the name being parsed (as a WIN32_FIND_DATA structure), using the STR_FILE_SYS_BIND_DATA bind context
			/// parameter. STR_PARSE_PREFER_FOLDER_BROWSING can be passed to indicate that URLs are parsed using the file system data source
			/// when possible. Construct a bind context object using CreateBindCtx and populate the values using
			/// IBindCtx::RegisterObjectParam. See <c>Bind Context String Keys</c> for a complete list of these.
			/// </para>
			/// <para>If no data is being passed to or received from the parsing function, this value can be <c>NULL</c>.</para>
			/// </param>
			/// <param name="pszDisplayName">
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A null-terminated Unicode string with the display name. Because each Shell folder defines its own parsing syntax, the form
			/// this string can take may vary. The desktop folder, for instance, accepts paths such as "C:\My Docs\My File.txt". It also
			/// will accept references to items in the namespace that have a GUID associated with them using the "::{GUID}" syntax. For
			/// example, to retrieve a fully qualified identifier list for the control panel from the desktop folder, you can use the following:
			/// </para>
			/// <para><c>::{CLSID for Control Panel}\::{CLSID for printers folder}</c></para>
			/// </param>
			/// <param name="pchEaten">
			/// <para>Type: <c>ULONG*</c></para>
			/// <para>
			/// A pointer to a <c>ULONG</c> value that receives the number of characters of the display name that was parsed. If your
			/// application does not need this information, set pchEaten to <c>NULL</c>, and no value will be returned.
			/// </para>
			/// </param>
			/// <param name="ppidl">
			/// <para>Type: <c>PIDLIST_RELATIVE*</c></para>
			/// <para>
			/// When this method returns, contains a pointer to the PIDL for the object. The returned item identifier list specifies the
			/// item relative to the parsing folder. If the object associated with pszDisplayName is within the parsing folder, the returned
			/// item identifier list will contain only one SHITEMID structure. If the object is in a subfolder of the parsing folder, the
			/// returned item identifier list will contain multiple <c>SHITEMID</c> structures. If an error occurs, <c>NULL</c> is returned
			/// in this address.
			/// </para>
			/// <para>When it is no longer needed, it is the responsibility of the caller to free this resource by calling CoTaskMemFree.</para>
			/// </param>
			/// <param name="pdwAttributes">
			/// <para>Type: <c>ULONG*</c></para>
			/// <para>
			/// The value used to query for file attributes. If not used, it should be set to <c>NULL</c>. To query for one or more
			/// attributes, initialize this parameter with the SFGAO flags that represent the attributes of interest. On return, those
			/// attributes that are true and were requested will be set.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// Some Shell folders may not implement <c>IShellFolder::ParseDisplayName</c>. Each folder that does will define its own
			/// parsing syntax.
			/// </para>
			/// <para>
			/// <c>ParseDisplayName</c> is not expected to handle the relative path or parent folder indicators ("." or ".."). It is up to
			/// the caller to remove these appropriately.
			/// </para>
			/// <para>
			/// Do not use the SFGAO_VALIDATE flag in pdwAttributes to verify the existence of the item whose name is being parsed.
			/// <c>IShellFolder::ParseDisplayName</c> implicitly validates the existence of the item unless that behavior is overridden by a
			/// special bind context parameter.
			/// </para>
			/// <para>
			/// Querying for some attributes may be relatively slow and use significant amounts of memory. For example, to determine if a
			/// file is shared, the Shell will load network components. This procedure may require the loading of several DLLs. The purpose
			/// of pdwAttributes is to allow you to restrict the query to only that information that is needed. The following code fragment
			/// illustrates how to find out if a file is compressed.
			/// </para>
			/// <para>
			/// <code>LPITEMIDLIST pidl; ULONG cbEaten; DWORD dwAttribs = SFGAO_COMPRESSED; hres = psf-&gt;ParseDisplayName(NULL, NULL, lpwszDisplayName, &amp;cbEaten, // This can be NULL &amp;pidl, &amp;dwAttribs); if(dwAttribs &amp; SFGAO_COMPRESSED) { // Do something with the compressed file }</code>
			/// </para>
			/// <para>
			/// Since pdwAttributes is an in/out parameter, it should always be initialized. If you pass in an uninitialized value, some of
			/// the bits may be inadvertantly set. <c>IShellFolder::ParseDisplayName</c> will then query for the corresponding attributes,
			/// which may lead to undesirable delays or memory demands. If you do not wish to query for attributes, set pdwAttributes to
			/// <c>NULL</c> to avoid unpredictable behavior.
			/// </para>
			/// <para>This method is similar to the IParseDisplayName::ParseDisplayName method.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellfolder-parsedisplayname
			[PreserveSig]
			HRESULT ParseDisplayName(HWND hwnd, [In, Optional] IBindCtx pbc, [MarshalAs(UnmanagedType.LPWStr)] string pszDisplayName, out uint pchEaten, out PIDL ppidl, [In, Out] ref SFGAO pdwAttributes);

			/// <summary>
			/// Enables a client to determine the contents of a folder by creating an item identifier enumeration object and returning its
			/// IEnumIDList interface. The methods supported by that interface can then be used to enumerate the folder's contents.
			/// </summary>
			/// <param name="hwnd">
			/// <para>Type: <c>HWND</c></para>
			/// <para>
			/// If user input is required to perform the enumeration, this window handle should be used by the enumeration object as the
			/// parent window to take user input. An example would be a dialog box to ask for a password or prompt the user to insert a CD
			/// or floppy disk. If hwndOwner is set to <c>NULL</c>, the enumerator should not post any messages, and if user input is
			/// required, it should silently fail.
			/// </para>
			/// </param>
			/// <param name="grfFlags">
			/// <para>Type: <c>SHCONTF</c></para>
			/// <para>
			/// Flags indicating which items to include in the enumeration. For a list of possible values, see the SHCONTF enumerated type.
			/// </para>
			/// </param>
			/// <param name="ppenumIDList">
			/// <para>Type: <c>IEnumIDList**</c></para>
			/// <para>
			/// The address that receives a pointer to the IEnumIDList interface of the enumeration object created by this method. If an
			/// error occurs or no suitable subobjects are found, ppenumIDList is set to <c>NULL</c>.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>Returns
			/// <code>S_OK</code>
			/// if successful, or an error value otherwise. Some implementations may also return
			/// <code>S_FALSE</code>
			/// , indicating that there are no children matching the grfFlags that were passed in. If
			/// <code>S_FALSE</code>
			/// is returned, ppenumIDList is set to
			/// <code>NULL</code>
			/// .
			/// </para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// If the method returns S_OK, then ppenumIDList receives a pointer to an enumerator. In this case, the calling application
			/// must free the returned IEnumIDList object by calling its <c>Release</c> method.
			/// </para>
			/// <para>
			/// If the method returns S_FALSE, then the folder contains no suitable subobjects and the pointer specified in ppenumIDList is
			/// set to <c>NULL</c>.
			/// </para>
			/// <para>If the method fails, an error value is returned and the pointer specified in ppenumIDList is set to <c>NULL</c>.</para>
			/// <para>
			/// If the folder contains no suitable subobjects, then the <c>IShellFolder::EnumObjects</c> method is permitted either to set
			/// *ppenumIDList to <c>NULL</c> and return S_FALSE, or to set *ppenumIDList to an enumerator that produces no objects and
			/// return S_OK. Calling applications must be prepared for both success cases.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellfolder-enumobjects
			[PreserveSig]
			HRESULT EnumObjects(HWND hwnd, SHCONTF grfFlags, out IEnumIDList ppenumIDList);

			/// <summary>
			/// Retrieves a handler, typically the Shell folder object that implements IShellFolder for a particular item. Optional
			/// parameters that control the construction of the handler are passed in the bind context.
			/// </summary>
			/// <param name="pidl">
			/// <para>Type: <c>PCUIDLIST_RELATIVE</c></para>
			/// <para>
			/// The address of an ITEMIDLIST structure (PIDL) that identifies the subfolder. This value can refer to an item at any level
			/// below the parent folder in the namespace hierarchy. The structure contains one or more SHITEMID structures, followed by a
			/// terminating <c>NULL</c>.
			/// </para>
			/// </param>
			/// <param name="pbc">
			/// <para>Type: <c>IBindCtx*</c></para>
			/// <para>
			/// A pointer to an IBindCtx interface on a bind context object that can be used to pass parameters to the construction of the
			/// handler. If this parameter is not used, set it to <c>NULL</c>. Because support for this parameter is optional for folder
			/// object implementations, some folders may not support the use of bind contexts.
			/// </para>
			/// <para>
			/// Information that can be provided in the bind context includes a BIND_OPTS structure that includes a <c>grfMode</c> member
			/// that indicates the access mode when binding to a stream handler. Other parameters can be set and discovered using
			/// IBindCtx::RegisterObjectParam and IBindCtx::GetObjectParam.
			/// </para>
			/// </param>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>
			/// The identifier of the interface to return. This may be <c>IID_IShellFolder</c>, <c>IID_IStream</c>, or any other interface
			/// that identifies a particular handler.
			/// </para>
			/// </param>
			/// <param name="ppv">
			/// <para>Type: <c>void**</c></para>
			/// <para>
			/// When this method returns, contains the address of a pointer to the requested interface. If an error occurs, a <c>NULL</c>
			/// pointer is returned at this address.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// Applications use <c>IShellFolder::BindToObject</c><c>(..., IID_IShellFolder, ...)</c> to obtain the Shell folder object for
			/// a subitem. Clients should pass the canonical interface IID that is used to identify a specific handler. For example,
			/// <c>IID_IShellFolder</c> identifies the folder handler and <c>IID_IStream</c> identifies the stream handler. Implementations
			/// can support binding to handlers using derived interfaces as well, such as <c>IID_IShellFolder2</c>. A Shell namespace
			/// extension can implement this function by creating the Shell folder object for the specified subitem and then calling
			/// QueryInterface to communicate with the object through its interface pointer.
			/// </para>
			/// <para>
			/// Implementations of <c>BindToObject</c> can optimize any call to it by quickly failing for IID values that it does not
			/// support. For example, if the Shell folder object of the subitem does not support IRemoteComputer, the implementation should
			/// return <c>E_NOINTERFACE</c> immediately instead of needlessly creating the Shell folder object for the subitem and then
			/// finding that <c>IRemoteComputer</c> was not supported after all.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellfolder-bindtoobject
			[PreserveSig]
			HRESULT BindToObject([In] PIDL pidl, [In, Optional] IBindCtx pbc, in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 2)] out object ppv);

			/// <summary>Requests a pointer to an object's storage interface.</summary>
			/// <param name="pidl">
			/// <para>Type: <c>PCUIDLIST_RELATIVE</c></para>
			/// <para>
			/// The address of an ITEMIDLIST structure that identifies the subfolder relative to its parent folder. The structure must
			/// contain exactly one SHITEMID structure followed by a terminating zero.
			/// </para>
			/// </param>
			/// <param name="pbc">
			/// <para>Type: <c>IBindCtx*</c></para>
			/// <para>
			/// The optional address of an IBindCtx interface on a bind context object to be used during this operation. If this parameter
			/// is not used, set it to <c>NULL</c>. Because support for pbc is optional for folder object implementations, some folders may
			/// not support the use of bind contexts.
			/// </para>
			/// </param>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>
			/// The IID of the requested storage interface. To retrieve an IStream, IStorage, or IPropertySetStorage interface pointer, set
			/// riid to <c>IID_IStream</c>, <c>IID_IStorage</c>, or <c>IID_IPropertySetStorage</c>, respectively.
			/// </para>
			/// </param>
			/// <param name="ppv">
			/// <para>Type: <c>void**</c></para>
			/// <para>
			/// The address that receives the interface pointer specified by riid. If an error occurs, a <c>NULL</c> pointer is returned in
			/// this address.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// Namespace extensions have the option of allowing applications to bind to an object that represents an item's storage. If
			/// this option is supported, <c>IShellFolder::BindToStorage</c> returns a specified interface pointer that can then be used to
			/// access the contents of object. See the IMoniker::BindToStorage reference for further discussion.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellfolder-bindtostorage
			[PreserveSig]
			HRESULT BindToStorage([In] PIDL pidl, [In, Optional] IBindCtx pbc, in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 2)] out object ppv);

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
			/// The upper sixteen bits of lParam are used for flags that modify the sorting rule. The system currently defines these
			/// modifier flags.
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
			/// items are compared by whatever criteria the Shell folder determines are most efficient, as long as it implements a
			/// consistent sort function. This flag is useful when comparing for equality or when the results of the sort are not displayed
			/// to the user. This flag cannot be combined with other flags.
			/// </description>
			/// </item>
			/// </list>
			/// </param>
			/// <param name="pidl1">
			/// A pointer to the first item's ITEMIDLIST structure. It will be relative to the folder. This ITEMIDLIST structure can contain
			/// more than one element; therefore, the entire structure must be compared, not just the first element.
			/// </param>
			/// <param name="pidl2">
			/// A pointer to the second item's ITEMIDLIST structure. It will be relative to the folder. This ITEMIDLIST structure can
			/// contain more than one element; therefore, the entire structure must be compared, not just the first element.
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
			/// <para>Type: <c>HWND</c></para>
			/// <para>
			/// A handle to the owner window. If you have implemented a custom folder view object, your folder view window should be created
			/// as a child of hwndOwner.
			/// </para>
			/// </param>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>A reference to the IID of the interface to retrieve through ppv, typically IID_IShellView.</para>
			/// </param>
			/// <param name="ppv">
			/// <para>Type: <c>void**</c></para>
			/// <para>
			/// When this method returns successfully, contains the interface pointer requested in riid. This is typically IShellView. See
			/// the Remarks section for more details.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// To support this request, create an object that exposes the interface indicated by riid and return a pointer to that interface.
			/// </para>
			/// <para>
			/// The primary purpose of this method is to provide Windows Explorer with the folder object's folder view object. Windows
			/// Explorer requests a folder view object by setting riid to IID_IShellView. The folder view object displays the contents of
			/// the folder in the Windows Explorer folder view. The folder view object must be independent of the Shell folder object,
			/// because Windows Explorer may call this method more than once to create multiple folder view objects. A new view object must
			/// be created each time this method is called. Your folder object can respond in one of two ways to this request. It can:
			/// </para>
			/// <list type="bullet">
			/// <item>
			/// <term>Create a custom folder view object and return a pointer to its IShellView interface.</term>
			/// </item>
			/// <item>
			/// <term>Create a system folder view object and return a pointer to its IShellView interface.</term>
			/// </item>
			/// </list>
			/// <para>
			/// This method is also used to request objects that expose one of several optional interfaces, including IContextMenu or
			/// IExtractIcon. In this context, <c>CreateViewObject</c> is similar in usage to IShellFolder::GetUIObjectOf. However, you call
			/// <c>IShellFolder::GetUIObjectOf</c> to request an object for one of the items contained by a folder. Call
			/// <c>IShellFolder::CreateViewObject</c> to request an object for the folder itself. The most commonly requested interfaces are:
			/// </para>
			/// <list type="bullet">
			/// <item>
			/// <term>IQueryInfo</term>
			/// </item>
			/// <item>
			/// <term>IShellDetails</term>
			/// </item>
			/// <item>
			/// <term>IDropTarget</term>
			/// </item>
			/// </list>
			/// <para>
			/// We recommend that you use the <c>IID_PPV_ARGS</c> macro, defined in Objbase.h, to package the riid and ppv parameters. This
			/// macro provides the correct IID based on the interface pointed to by the value in ppv, which eliminates the possibility of a
			/// coding error in riid that could lead to unexpected results.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellfolder-createviewobject
			[PreserveSig]
			HRESULT CreateViewObject(HWND hwndOwner, in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 1)] out object ppv);

			/// <summary>Gets the attributes of one or more file or folder objects contained in the object represented by IShellFolder.</summary>
			/// <param name="cidl">
			/// <para>Type: <c>UINT</c></para>
			/// <para>The number of items from which to retrieve attributes.</para>
			/// </param>
			/// <param name="apidl">
			/// <para>Type: <c>PCUITEMID_CHILD_ARRAY*</c></para>
			/// <para>
			/// The address of an array of pointers to ITEMIDLIST structures, each of which uniquely identifies an item relative to the
			/// parent folder. Each <c>ITEMIDLIST</c> structure must contain exactly one SHITEMID structure followed by a terminating zero.
			/// </para>
			/// </param>
			/// <param name="rgfInOut">
			/// <para>Type: <c>SFGAOF*</c></para>
			/// <para>
			/// Pointer to a single <c>ULONG</c> value that, on entry, contains the bitwise SFGAO attributes that the calling application is
			/// requesting. On exit, this value contains the requested attributes that are common to all of the specified items.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>To optimize this operation, do not return unspecified flags.</para>
			/// <para>
			/// For a folder object, the SFGAO_BROWSABLE attribute implies that the client can bind to this object as shown in a general
			/// form here.
			/// </para>
			/// <para>
			/// <code>IShellFolder::BindToObject(..., pidl, IID_IShellFolder, &amp;psfItem);</code>
			/// </para>
			/// <para>The client can then create an IShellView on that item through this statement.</para>
			/// <para>
			/// <code>psfItem-&gt;CreateViewObject(..., IID_IShellView,...);</code>
			/// </para>
			/// <para>
			/// The SFGAO_DROPTARGET attribute implies that the client can bind to an instance of IDropTarget for this folder by calling
			/// IShellFolder::GetUIObjectOf as shown here.
			/// </para>
			/// <para>
			/// <code>IShellFolder::GetUIObjectOf(hwnd, 1, &amp;pidl, IID_IDropTarget, NULL, &amp;pv)</code>
			/// </para>
			/// <para>
			/// The SFGAO_NONENUMERATED attribute indicates an item that is not returned by the enumerator created by the
			/// IShellFolder::EnumObjects method.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellfolder-getattributesof HRESULT
			// GetAttributesOf( UINT cidl, PCUITEMID_CHILD_ARRAY apidl, SFGAOF *rgfInOut );
			[PreserveSig]
			HRESULT GetAttributesOf(uint cidl, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] IntPtr[] apidl, ref SFGAO rgfInOut);

			/// <summary>Gets an object that can be used to carry out actions on the specified file objects or folders.</summary>
			/// <param name="hwndOwner">
			/// <para>Type: <c>HWND</c></para>
			/// <para>A handle to the owner window that the client should specify if it displays a dialog box or message box.</para>
			/// </param>
			/// <param name="cidl">
			/// <para>Type: <c>UINT</c></para>
			/// <para>The number of file objects or subfolders specified in the apidl parameter.</para>
			/// </param>
			/// <param name="apidl">
			/// <para>Type: <c>PCUITEMID_CHILD_ARRAY</c></para>
			/// <para>
			/// The address of an array of pointers to ITEMIDLIST structures, each of which uniquely identifies a file object or subfolder
			/// relative to the parent folder. Each item identifier list must contain exactly one SHITEMID structure followed by a
			/// terminating zero.
			/// </para>
			/// </param>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>
			/// A reference to the IID of the interface to retrieve through ppv. This can be any valid interface identifier that can be
			/// created for an item. The most common identifiers used by the Shell are listed in the comments at the end of this reference.
			/// </para>
			/// </param>
			/// <param name="rgfReserved">
			/// <para>Type: <c>UINT*</c></para>
			/// <para>Reserved.</para>
			/// </param>
			/// <param name="ppv">
			/// <para>Type: <c>void**</c></para>
			/// <para>When this method returns successfully, contains the interface pointer requested in riid.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// If cidl is greater than one, the <c>IShellFolder::GetUIObjectOf</c> implementation should only succeed if it can create one
			/// object for all items specified in apidl. If the implementation cannot create one object for all items, this method will fail.
			/// </para>
			/// <para>
			/// The following are the most common interface identifiers the Shell uses when requesting an interface from this method. The
			/// list also indicates if cidl can be greater than one for the requested interface.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Interface Identifier</term>
			/// <term>Allowed cidl Value</term>
			/// </listheader>
			/// <item>
			/// <term>IContextMenu</term>
			/// <term>The cidl parameter can be greater than or equal to one.</term>
			/// </item>
			/// <item>
			/// <term>IContextMenu2</term>
			/// <term>The cidl parameter can be greater than or equal to one.</term>
			/// </item>
			/// <item>
			/// <term>IDataObject</term>
			/// <term>The cidl parameter can be greater than or equal to one.</term>
			/// </item>
			/// <item>
			/// <term>IDropTarget</term>
			/// <term>The cidl parameter can only be one.</term>
			/// </item>
			/// <item>
			/// <term>IExtractIcon</term>
			/// <term>The cidl parameter can only be one.</term>
			/// </item>
			/// <item>
			/// <term>IQueryInfo</term>
			/// <term>The cidl parameter can only be one.</term>
			/// </item>
			/// </list>
			/// <para>
			/// We recommend that you use the <c>IID_PPV_ARGS</c> macro, defined in Objbase.h, to package the riid and ppv parameters. This
			/// macro provides the correct IID based on the interface pointed to by the value in ppv, which eliminates the possibility of a
			/// coding error in riid that could lead to unexpected results.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellfolder-getuiobjectof HRESULT
			// GetUIObjectOf( HWND hwndOwner, UINT cidl, PCUITEMID_CHILD_ARRAY apidl, REFIID riid, UINT *rgfReserved, void **ppv );
			[PreserveSig]
			HRESULT GetUIObjectOf(HWND hwndOwner, uint cidl, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] IntPtr[] apidl, in Guid riid,
				[In, Out, Optional] IntPtr rgfReserved, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 3)] out object ppv);

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
			/// <para>Type: <c>STRRET*</c></para>
			/// <para>
			/// When this method returns, contains a pointer to a STRRET structure in which to return the display name. The type of name
			/// returned in this structure can be the requested type, but the Shell folder might return a different type.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>It is the caller's responsibility to free resources allocated by this function.</para>
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
			/// The simplest way to retrieve the display name from the structure pointed to by pName is to pass it to either StrRetToBuf or
			/// StrRetToStr. These functions take a STRRET structure and return the name. You can also examine the structure's <c>uType</c>
			/// member, and retrieve the name from the appropriate member.
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
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellfolder-getdisplaynameof HRESULT
			// GetDisplayNameOf( PCUITEMID_CHILD pidl, SHGDNF uFlags, STRRET *pName );
			[PreserveSig]
			HRESULT GetDisplayNameOf([In] PIDL pidl, SHGDNF uFlags, out STRRET pName);

			/// <summary>Sets the display name of a file object or subfolder, changing the item identifier in the process.</summary>
			/// <param name="hwnd">
			/// <para>Type: <c>HWND</c></para>
			/// <para>A handle to the owner window of any dialog or message box that the client displays.</para>
			/// </param>
			/// <param name="pidl">
			/// <para>Type: <c>PCUITEMID_CHILD</c></para>
			/// <para>
			/// A pointer to an ITEMIDLIST structure that uniquely identifies the file object or subfolder relative to the parent folder.
			/// The structure must contain exactly one SHITEMID structure followed by a terminating zero.
			/// </para>
			/// </param>
			/// <param name="pszName">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>A pointer to a null-terminated string that specifies the new display name.</para>
			/// </param>
			/// <param name="uFlags">
			/// <para>Type: <c>SHGDNF</c></para>
			/// <para>
			/// Flags that indicate the type of name specified by the pszName parameter. For a list of possible values and combinations of
			/// values, see SHGDNF.
			/// </para>
			/// </param>
			/// <param name="ppidlOut">
			/// <para>Type: <c>PITEMID_CHILD*</c></para>
			/// <para>
			/// Optional. If specified, the address of a pointer to an ITEMIDLIST structure that receives the <c>ITEMIDLIST</c> of the
			/// renamed item. The caller requests this value by passing a non-null ppidlOut. Implementations of
			/// <c>IShellFolder::SetNameOf</c> must return a pointer to the new <c>ITEMIDLIST</c> in the ppidlOut parameter.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>Changing the display name of a file system object, or a folder within it, renames the file or directory.</para>
			/// <para>
			/// Before calling this method, applications should call IShellFolder::GetAttributesOf and check that the SFGAO_CANRENAME flag
			/// is set. Note that this flag is essentially a hint to namespace clients. It does not necessarily imply that
			/// <c>IShellFolder::SetNameOf</c> will succeed or fail.
			/// </para>
			/// <para>
			/// Implementers of <c>IShellFolder::SetNameOf</c> must call SHChangeNotify with both the old and new absolute PIDLs once the
			/// renaming of an object is complete. This following example shows the call to <c>SHChangeNotify</c> following the renaming of
			/// a folder object.
			/// </para>
			/// <para>
			/// <code>SHChangeNotify(SHCNE_RENAMEFOLDER, SHCNF_IDLIST, pidlFullOld, pidlFullNew);</code>
			/// </para>
			/// <para>This call prevents both the old and new names being displayed in the view.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellfolder-setnameof HRESULT SetNameOf(
			// HWND hwnd, PCUITEMID_CHILD pidl, LPCWSTR pszName, SHGDNF uFlags, PITEMID_CHILD *ppidlOut );
			[PreserveSig]
			HRESULT SetNameOf([Optional] HWND hwnd, [In] PIDL pidl, [MarshalAs(UnmanagedType.LPWStr)] string pszName, SHGDNF uFlags, out PIDL ppidlOut);
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
			/// <para>Type: <c>HWND</c></para>
			/// <para>
			/// A window handle. The client should provide a window handle if it displays a dialog or message box. Otherwise set hwnd to <c>NULL</c>.
			/// </para>
			/// </param>
			/// <param name="pbc">
			/// <para>Type: <c>IBindCtx*</c></para>
			/// <para>
			/// Optional. A pointer to a bind context used to pass parameters as inputs and outputs to the parsing function. These passed
			/// parameters are often specific to the data source and are documented by the data source owners. For example, the file system
			/// data source accepts the name being parsed (as a WIN32_FIND_DATA structure), using the STR_FILE_SYS_BIND_DATA bind context
			/// parameter. STR_PARSE_PREFER_FOLDER_BROWSING can be passed to indicate that URLs are parsed using the file system data source
			/// when possible. Construct a bind context object using CreateBindCtx and populate the values using
			/// IBindCtx::RegisterObjectParam. See <c>Bind Context String Keys</c> for a complete list of these.
			/// </para>
			/// <para>If no data is being passed to or received from the parsing function, this value can be <c>NULL</c>.</para>
			/// </param>
			/// <param name="pszDisplayName">
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A null-terminated Unicode string with the display name. Because each Shell folder defines its own parsing syntax, the form
			/// this string can take may vary. The desktop folder, for instance, accepts paths such as "C:\My Docs\My File.txt". It also
			/// will accept references to items in the namespace that have a GUID associated with them using the "::{GUID}" syntax. For
			/// example, to retrieve a fully qualified identifier list for the control panel from the desktop folder, you can use the following:
			/// </para>
			/// <para><c>::{CLSID for Control Panel}\::{CLSID for printers folder}</c></para>
			/// </param>
			/// <param name="pchEaten">
			/// <para>Type: <c>ULONG*</c></para>
			/// <para>
			/// A pointer to a <c>ULONG</c> value that receives the number of characters of the display name that was parsed. If your
			/// application does not need this information, set pchEaten to <c>NULL</c>, and no value will be returned.
			/// </para>
			/// </param>
			/// <param name="ppidl">
			/// <para>Type: <c>PIDLIST_RELATIVE*</c></para>
			/// <para>
			/// When this method returns, contains a pointer to the PIDL for the object. The returned item identifier list specifies the
			/// item relative to the parsing folder. If the object associated with pszDisplayName is within the parsing folder, the returned
			/// item identifier list will contain only one SHITEMID structure. If the object is in a subfolder of the parsing folder, the
			/// returned item identifier list will contain multiple <c>SHITEMID</c> structures. If an error occurs, <c>NULL</c> is returned
			/// in this address.
			/// </para>
			/// <para>When it is no longer needed, it is the responsibility of the caller to free this resource by calling CoTaskMemFree.</para>
			/// </param>
			/// <param name="pdwAttributes">
			/// <para>Type: <c>ULONG*</c></para>
			/// <para>
			/// The value used to query for file attributes. If not used, it should be set to <c>NULL</c>. To query for one or more
			/// attributes, initialize this parameter with the SFGAO flags that represent the attributes of interest. On return, those
			/// attributes that are true and were requested will be set.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// Some Shell folders may not implement <c>IShellFolder::ParseDisplayName</c>. Each folder that does will define its own
			/// parsing syntax.
			/// </para>
			/// <para>
			/// <c>ParseDisplayName</c> is not expected to handle the relative path or parent folder indicators ("." or ".."). It is up to
			/// the caller to remove these appropriately.
			/// </para>
			/// <para>
			/// Do not use the SFGAO_VALIDATE flag in pdwAttributes to verify the existence of the item whose name is being parsed.
			/// <c>IShellFolder::ParseDisplayName</c> implicitly validates the existence of the item unless that behavior is overridden by a
			/// special bind context parameter.
			/// </para>
			/// <para>
			/// Querying for some attributes may be relatively slow and use significant amounts of memory. For example, to determine if a
			/// file is shared, the Shell will load network components. This procedure may require the loading of several DLLs. The purpose
			/// of pdwAttributes is to allow you to restrict the query to only that information that is needed. The following code fragment
			/// illustrates how to find out if a file is compressed.
			/// </para>
			/// <para>
			/// <code>LPITEMIDLIST pidl; ULONG cbEaten; DWORD dwAttribs = SFGAO_COMPRESSED; hres = psf-&gt;ParseDisplayName(NULL, NULL, lpwszDisplayName, &amp;cbEaten, // This can be NULL &amp;pidl, &amp;dwAttribs); if(dwAttribs &amp; SFGAO_COMPRESSED) { // Do something with the compressed file }</code>
			/// </para>
			/// <para>
			/// Since pdwAttributes is an in/out parameter, it should always be initialized. If you pass in an uninitialized value, some of
			/// the bits may be inadvertantly set. <c>IShellFolder::ParseDisplayName</c> will then query for the corresponding attributes,
			/// which may lead to undesirable delays or memory demands. If you do not wish to query for attributes, set pdwAttributes to
			/// <c>NULL</c> to avoid unpredictable behavior.
			/// </para>
			/// <para>This method is similar to the IParseDisplayName::ParseDisplayName method.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellfolder-parsedisplayname
			[PreserveSig]
			new HRESULT ParseDisplayName(HWND hwnd, [In, Optional] IBindCtx pbc, [MarshalAs(UnmanagedType.LPWStr)] string pszDisplayName, out uint pchEaten, out PIDL ppidl, [In, Out] ref SFGAO pdwAttributes);

			/// <summary>
			/// Enables a client to determine the contents of a folder by creating an item identifier enumeration object and returning its
			/// IEnumIDList interface. The methods supported by that interface can then be used to enumerate the folder's contents.
			/// </summary>
			/// <param name="hwnd">
			/// <para>Type: <c>HWND</c></para>
			/// <para>
			/// If user input is required to perform the enumeration, this window handle should be used by the enumeration object as the
			/// parent window to take user input. An example would be a dialog box to ask for a password or prompt the user to insert a CD
			/// or floppy disk. If hwndOwner is set to <c>NULL</c>, the enumerator should not post any messages, and if user input is
			/// required, it should silently fail.
			/// </para>
			/// </param>
			/// <param name="grfFlags">
			/// <para>Type: <c>SHCONTF</c></para>
			/// <para>
			/// Flags indicating which items to include in the enumeration. For a list of possible values, see the SHCONTF enumerated type.
			/// </para>
			/// </param>
			/// <param name="ppenumIDList">
			/// <para>Type: <c>IEnumIDList**</c></para>
			/// <para>
			/// The address that receives a pointer to the IEnumIDList interface of the enumeration object created by this method. If an
			/// error occurs or no suitable subobjects are found, ppenumIDList is set to <c>NULL</c>.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>Returns
			/// <code>S_OK</code>
			/// if successful, or an error value otherwise. Some implementations may also return
			/// <code>S_FALSE</code>
			/// , indicating that there are no children matching the grfFlags that were passed in. If
			/// <code>S_FALSE</code>
			/// is returned, ppenumIDList is set to
			/// <code>NULL</code>
			/// .
			/// </para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// If the method returns S_OK, then ppenumIDList receives a pointer to an enumerator. In this case, the calling application
			/// must free the returned IEnumIDList object by calling its <c>Release</c> method.
			/// </para>
			/// <para>
			/// If the method returns S_FALSE, then the folder contains no suitable subobjects and the pointer specified in ppenumIDList is
			/// set to <c>NULL</c>.
			/// </para>
			/// <para>If the method fails, an error value is returned and the pointer specified in ppenumIDList is set to <c>NULL</c>.</para>
			/// <para>
			/// If the folder contains no suitable subobjects, then the <c>IShellFolder::EnumObjects</c> method is permitted either to set
			/// *ppenumIDList to <c>NULL</c> and return S_FALSE, or to set *ppenumIDList to an enumerator that produces no objects and
			/// return S_OK. Calling applications must be prepared for both success cases.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellfolder-enumobjects
			[PreserveSig]
			new HRESULT EnumObjects(HWND hwnd, SHCONTF grfFlags, out IEnumIDList ppenumIDList);

			/// <summary>
			/// Retrieves a handler, typically the Shell folder object that implements IShellFolder for a particular item. Optional
			/// parameters that control the construction of the handler are passed in the bind context.
			/// </summary>
			/// <param name="pidl">
			/// <para>Type: <c>PCUIDLIST_RELATIVE</c></para>
			/// <para>
			/// The address of an ITEMIDLIST structure (PIDL) that identifies the subfolder. This value can refer to an item at any level
			/// below the parent folder in the namespace hierarchy. The structure contains one or more SHITEMID structures, followed by a
			/// terminating <c>NULL</c>.
			/// </para>
			/// </param>
			/// <param name="pbc">
			/// <para>Type: <c>IBindCtx*</c></para>
			/// <para>
			/// A pointer to an IBindCtx interface on a bind context object that can be used to pass parameters to the construction of the
			/// handler. If this parameter is not used, set it to <c>NULL</c>. Because support for this parameter is optional for folder
			/// object implementations, some folders may not support the use of bind contexts.
			/// </para>
			/// <para>
			/// Information that can be provided in the bind context includes a BIND_OPTS structure that includes a <c>grfMode</c> member
			/// that indicates the access mode when binding to a stream handler. Other parameters can be set and discovered using
			/// IBindCtx::RegisterObjectParam and IBindCtx::GetObjectParam.
			/// </para>
			/// </param>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>
			/// The identifier of the interface to return. This may be <c>IID_IShellFolder</c>, <c>IID_IStream</c>, or any other interface
			/// that identifies a particular handler.
			/// </para>
			/// </param>
			/// <param name="ppv">
			/// <para>Type: <c>void**</c></para>
			/// <para>
			/// When this method returns, contains the address of a pointer to the requested interface. If an error occurs, a <c>NULL</c>
			/// pointer is returned at this address.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// Applications use <c>IShellFolder::BindToObject</c><c>(..., IID_IShellFolder, ...)</c> to obtain the Shell folder object for
			/// a subitem. Clients should pass the canonical interface IID that is used to identify a specific handler. For example,
			/// <c>IID_IShellFolder</c> identifies the folder handler and <c>IID_IStream</c> identifies the stream handler. Implementations
			/// can support binding to handlers using derived interfaces as well, such as <c>IID_IShellFolder2</c>. A Shell namespace
			/// extension can implement this function by creating the Shell folder object for the specified subitem and then calling
			/// QueryInterface to communicate with the object through its interface pointer.
			/// </para>
			/// <para>
			/// Implementations of <c>BindToObject</c> can optimize any call to it by quickly failing for IID values that it does not
			/// support. For example, if the Shell folder object of the subitem does not support IRemoteComputer, the implementation should
			/// return <c>E_NOINTERFACE</c> immediately instead of needlessly creating the Shell folder object for the subitem and then
			/// finding that <c>IRemoteComputer</c> was not supported after all.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellfolder-bindtoobject
			[PreserveSig]
			new HRESULT BindToObject([In] PIDL pidl, [In, Optional] IBindCtx pbc, in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 2)] out object ppv);

			/// <summary>Requests a pointer to an object's storage interface.</summary>
			/// <param name="pidl">
			/// <para>Type: <c>PCUIDLIST_RELATIVE</c></para>
			/// <para>
			/// The address of an ITEMIDLIST structure that identifies the subfolder relative to its parent folder. The structure must
			/// contain exactly one SHITEMID structure followed by a terminating zero.
			/// </para>
			/// </param>
			/// <param name="pbc">
			/// <para>Type: <c>IBindCtx*</c></para>
			/// <para>
			/// The optional address of an IBindCtx interface on a bind context object to be used during this operation. If this parameter
			/// is not used, set it to <c>NULL</c>. Because support for pbc is optional for folder object implementations, some folders may
			/// not support the use of bind contexts.
			/// </para>
			/// </param>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>
			/// The IID of the requested storage interface. To retrieve an IStream, IStorage, or IPropertySetStorage interface pointer, set
			/// riid to <c>IID_IStream</c>, <c>IID_IStorage</c>, or <c>IID_IPropertySetStorage</c>, respectively.
			/// </para>
			/// </param>
			/// <param name="ppv">
			/// <para>Type: <c>void**</c></para>
			/// <para>
			/// The address that receives the interface pointer specified by riid. If an error occurs, a <c>NULL</c> pointer is returned in
			/// this address.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// Namespace extensions have the option of allowing applications to bind to an object that represents an item's storage. If
			/// this option is supported, <c>IShellFolder::BindToStorage</c> returns a specified interface pointer that can then be used to
			/// access the contents of object. See the IMoniker::BindToStorage reference for further discussion.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellfolder-bindtostorage
			[PreserveSig]
			new HRESULT BindToStorage([In] PIDL pidl, [In, Optional] IBindCtx pbc, in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 2)] out object ppv);

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
			/// The upper sixteen bits of lParam are used for flags that modify the sorting rule. The system currently defines these
			/// modifier flags.
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
			/// items are compared by whatever criteria the Shell folder determines are most efficient, as long as it implements a
			/// consistent sort function. This flag is useful when comparing for equality or when the results of the sort are not displayed
			/// to the user. This flag cannot be combined with other flags.
			/// </description>
			/// </item>
			/// </list>
			/// </param>
			/// <param name="pidl1">
			/// A pointer to the first item's ITEMIDLIST structure. It will be relative to the folder. This ITEMIDLIST structure can contain
			/// more than one element; therefore, the entire structure must be compared, not just the first element.
			/// </param>
			/// <param name="pidl2">
			/// A pointer to the second item's ITEMIDLIST structure. It will be relative to the folder. This ITEMIDLIST structure can
			/// contain more than one element; therefore, the entire structure must be compared, not just the first element.
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
			/// <para>Type: <c>HWND</c></para>
			/// <para>
			/// A handle to the owner window. If you have implemented a custom folder view object, your folder view window should be created
			/// as a child of hwndOwner.
			/// </para>
			/// </param>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>A reference to the IID of the interface to retrieve through ppv, typically IID_IShellView.</para>
			/// </param>
			/// <param name="ppv">
			/// <para>Type: <c>void**</c></para>
			/// <para>
			/// When this method returns successfully, contains the interface pointer requested in riid. This is typically IShellView. See
			/// the Remarks section for more details.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// To support this request, create an object that exposes the interface indicated by riid and return a pointer to that interface.
			/// </para>
			/// <para>
			/// The primary purpose of this method is to provide Windows Explorer with the folder object's folder view object. Windows
			/// Explorer requests a folder view object by setting riid to IID_IShellView. The folder view object displays the contents of
			/// the folder in the Windows Explorer folder view. The folder view object must be independent of the Shell folder object,
			/// because Windows Explorer may call this method more than once to create multiple folder view objects. A new view object must
			/// be created each time this method is called. Your folder object can respond in one of two ways to this request. It can:
			/// </para>
			/// <list type="bullet">
			/// <item>
			/// <term>Create a custom folder view object and return a pointer to its IShellView interface.</term>
			/// </item>
			/// <item>
			/// <term>Create a system folder view object and return a pointer to its IShellView interface.</term>
			/// </item>
			/// </list>
			/// <para>
			/// This method is also used to request objects that expose one of several optional interfaces, including IContextMenu or
			/// IExtractIcon. In this context, <c>CreateViewObject</c> is similar in usage to IShellFolder::GetUIObjectOf. However, you call
			/// <c>IShellFolder::GetUIObjectOf</c> to request an object for one of the items contained by a folder. Call
			/// <c>IShellFolder::CreateViewObject</c> to request an object for the folder itself. The most commonly requested interfaces are:
			/// </para>
			/// <list type="bullet">
			/// <item>
			/// <term>IQueryInfo</term>
			/// </item>
			/// <item>
			/// <term>IShellDetails</term>
			/// </item>
			/// <item>
			/// <term>IDropTarget</term>
			/// </item>
			/// </list>
			/// <para>
			/// We recommend that you use the <c>IID_PPV_ARGS</c> macro, defined in Objbase.h, to package the riid and ppv parameters. This
			/// macro provides the correct IID based on the interface pointed to by the value in ppv, which eliminates the possibility of a
			/// coding error in riid that could lead to unexpected results.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellfolder-createviewobject
			[PreserveSig]
			new HRESULT CreateViewObject(HWND hwndOwner, in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 1)] out object ppv);

			/// <summary>Gets the attributes of one or more file or folder objects contained in the object represented by IShellFolder.</summary>
			/// <param name="cidl">
			/// <para>Type: <c>UINT</c></para>
			/// <para>The number of items from which to retrieve attributes.</para>
			/// </param>
			/// <param name="apidl">
			/// <para>Type: <c>PCUITEMID_CHILD_ARRAY*</c></para>
			/// <para>
			/// The address of an array of pointers to ITEMIDLIST structures, each of which uniquely identifies an item relative to the
			/// parent folder. Each <c>ITEMIDLIST</c> structure must contain exactly one SHITEMID structure followed by a terminating zero.
			/// </para>
			/// </param>
			/// <param name="rgfInOut">
			/// <para>Type: <c>SFGAOF*</c></para>
			/// <para>
			/// Pointer to a single <c>ULONG</c> value that, on entry, contains the bitwise SFGAO attributes that the calling application is
			/// requesting. On exit, this value contains the requested attributes that are common to all of the specified items.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>To optimize this operation, do not return unspecified flags.</para>
			/// <para>
			/// For a folder object, the SFGAO_BROWSABLE attribute implies that the client can bind to this object as shown in a general
			/// form here.
			/// </para>
			/// <para>
			/// <code>IShellFolder::BindToObject(..., pidl, IID_IShellFolder, &amp;psfItem);</code>
			/// </para>
			/// <para>The client can then create an IShellView on that item through this statement.</para>
			/// <para>
			/// <code>psfItem-&gt;CreateViewObject(..., IID_IShellView,...);</code>
			/// </para>
			/// <para>
			/// The SFGAO_DROPTARGET attribute implies that the client can bind to an instance of IDropTarget for this folder by calling
			/// IShellFolder::GetUIObjectOf as shown here.
			/// </para>
			/// <para>
			/// <code>IShellFolder::GetUIObjectOf(hwnd, 1, &amp;pidl, IID_IDropTarget, NULL, &amp;pv)</code>
			/// </para>
			/// <para>
			/// The SFGAO_NONENUMERATED attribute indicates an item that is not returned by the enumerator created by the
			/// IShellFolder::EnumObjects method.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellfolder-getattributesof HRESULT
			// GetAttributesOf( UINT cidl, PCUITEMID_CHILD_ARRAY apidl, SFGAOF *rgfInOut );
			[PreserveSig]
			new HRESULT GetAttributesOf(uint cidl, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] IntPtr[] apidl, ref SFGAO rgfInOut);

			/// <summary>Gets an object that can be used to carry out actions on the specified file objects or folders.</summary>
			/// <param name="hwndOwner">
			/// <para>Type: <c>HWND</c></para>
			/// <para>A handle to the owner window that the client should specify if it displays a dialog box or message box.</para>
			/// </param>
			/// <param name="cidl">
			/// <para>Type: <c>UINT</c></para>
			/// <para>The number of file objects or subfolders specified in the apidl parameter.</para>
			/// </param>
			/// <param name="apidl">
			/// <para>Type: <c>PCUITEMID_CHILD_ARRAY</c></para>
			/// <para>
			/// The address of an array of pointers to ITEMIDLIST structures, each of which uniquely identifies a file object or subfolder
			/// relative to the parent folder. Each item identifier list must contain exactly one SHITEMID structure followed by a
			/// terminating zero.
			/// </para>
			/// </param>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>
			/// A reference to the IID of the interface to retrieve through ppv. This can be any valid interface identifier that can be
			/// created for an item. The most common identifiers used by the Shell are listed in the comments at the end of this reference.
			/// </para>
			/// </param>
			/// <param name="rgfReserved">
			/// <para>Type: <c>UINT*</c></para>
			/// <para>Reserved.</para>
			/// </param>
			/// <param name="ppv">
			/// <para>Type: <c>void**</c></para>
			/// <para>When this method returns successfully, contains the interface pointer requested in riid.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// If cidl is greater than one, the <c>IShellFolder::GetUIObjectOf</c> implementation should only succeed if it can create one
			/// object for all items specified in apidl. If the implementation cannot create one object for all items, this method will fail.
			/// </para>
			/// <para>
			/// The following are the most common interface identifiers the Shell uses when requesting an interface from this method. The
			/// list also indicates if cidl can be greater than one for the requested interface.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Interface Identifier</term>
			/// <term>Allowed cidl Value</term>
			/// </listheader>
			/// <item>
			/// <term>IContextMenu</term>
			/// <term>The cidl parameter can be greater than or equal to one.</term>
			/// </item>
			/// <item>
			/// <term>IContextMenu2</term>
			/// <term>The cidl parameter can be greater than or equal to one.</term>
			/// </item>
			/// <item>
			/// <term>IDataObject</term>
			/// <term>The cidl parameter can be greater than or equal to one.</term>
			/// </item>
			/// <item>
			/// <term>IDropTarget</term>
			/// <term>The cidl parameter can only be one.</term>
			/// </item>
			/// <item>
			/// <term>IExtractIcon</term>
			/// <term>The cidl parameter can only be one.</term>
			/// </item>
			/// <item>
			/// <term>IQueryInfo</term>
			/// <term>The cidl parameter can only be one.</term>
			/// </item>
			/// </list>
			/// <para>
			/// We recommend that you use the <c>IID_PPV_ARGS</c> macro, defined in Objbase.h, to package the riid and ppv parameters. This
			/// macro provides the correct IID based on the interface pointed to by the value in ppv, which eliminates the possibility of a
			/// coding error in riid that could lead to unexpected results.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellfolder-getuiobjectof HRESULT
			// GetUIObjectOf( HWND hwndOwner, UINT cidl, PCUITEMID_CHILD_ARRAY apidl, REFIID riid, UINT *rgfReserved, void **ppv );
			[PreserveSig]
			new HRESULT GetUIObjectOf(HWND hwndOwner, uint cidl, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] IntPtr[] apidl, in Guid riid,
				[In, Out, Optional] IntPtr rgfReserved, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 3)] out object ppv);

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
			/// <para>Type: <c>STRRET*</c></para>
			/// <para>
			/// When this method returns, contains a pointer to a STRRET structure in which to return the display name. The type of name
			/// returned in this structure can be the requested type, but the Shell folder might return a different type.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>It is the caller's responsibility to free resources allocated by this function.</para>
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
			/// The simplest way to retrieve the display name from the structure pointed to by pName is to pass it to either StrRetToBuf or
			/// StrRetToStr. These functions take a STRRET structure and return the name. You can also examine the structure's <c>uType</c>
			/// member, and retrieve the name from the appropriate member.
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
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellfolder-getdisplaynameof HRESULT
			// GetDisplayNameOf( PCUITEMID_CHILD pidl, SHGDNF uFlags, STRRET *pName );
			[PreserveSig]
			new HRESULT GetDisplayNameOf([In] PIDL pidl, SHGDNF uFlags, out STRRET pName);

			/// <summary>Sets the display name of a file object or subfolder, changing the item identifier in the process.</summary>
			/// <param name="hwnd">
			/// <para>Type: <c>HWND</c></para>
			/// <para>A handle to the owner window of any dialog or message box that the client displays.</para>
			/// </param>
			/// <param name="pidl">
			/// <para>Type: <c>PCUITEMID_CHILD</c></para>
			/// <para>
			/// A pointer to an ITEMIDLIST structure that uniquely identifies the file object or subfolder relative to the parent folder.
			/// The structure must contain exactly one SHITEMID structure followed by a terminating zero.
			/// </para>
			/// </param>
			/// <param name="pszName">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>A pointer to a null-terminated string that specifies the new display name.</para>
			/// </param>
			/// <param name="uFlags">
			/// <para>Type: <c>SHGDNF</c></para>
			/// <para>
			/// Flags that indicate the type of name specified by the pszName parameter. For a list of possible values and combinations of
			/// values, see SHGDNF.
			/// </para>
			/// </param>
			/// <param name="ppidlOut">
			/// <para>Type: <c>PITEMID_CHILD*</c></para>
			/// <para>
			/// Optional. If specified, the address of a pointer to an ITEMIDLIST structure that receives the <c>ITEMIDLIST</c> of the
			/// renamed item. The caller requests this value by passing a non-null ppidlOut. Implementations of
			/// <c>IShellFolder::SetNameOf</c> must return a pointer to the new <c>ITEMIDLIST</c> in the ppidlOut parameter.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>Changing the display name of a file system object, or a folder within it, renames the file or directory.</para>
			/// <para>
			/// Before calling this method, applications should call IShellFolder::GetAttributesOf and check that the SFGAO_CANRENAME flag
			/// is set. Note that this flag is essentially a hint to namespace clients. It does not necessarily imply that
			/// <c>IShellFolder::SetNameOf</c> will succeed or fail.
			/// </para>
			/// <para>
			/// Implementers of <c>IShellFolder::SetNameOf</c> must call SHChangeNotify with both the old and new absolute PIDLs once the
			/// renaming of an object is complete. This following example shows the call to <c>SHChangeNotify</c> following the renaming of
			/// a folder object.
			/// </para>
			/// <para>
			/// <code>SHChangeNotify(SHCNE_RENAMEFOLDER, SHCNF_IDLIST, pidlFullOld, pidlFullNew);</code>
			/// </para>
			/// <para>This call prevents both the old and new names being displayed in the view.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellfolder-setnameof HRESULT SetNameOf(
			// HWND hwnd, PCUITEMID_CHILD pidl, LPCWSTR pszName, SHGDNF uFlags, PITEMID_CHILD *ppidlOut );
			[PreserveSig]
			new HRESULT SetNameOf([Optional] HWND hwnd, [In] PIDL pidl, [MarshalAs(UnmanagedType.LPWStr)] string pszName, SHGDNF uFlags, out PIDL ppidlOut);

			/// <summary>Returns the globally unique identifier (GUID) of the default search object for the folder.</summary>
			/// <param name="pguid">
			/// <para>Type: <c>GUID*</c></para>
			/// <para>The GUID of the default search object.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>Returns S_OK if successful, or a COM error value otherwise.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellfolder2-getdefaultsearchguid HRESULT
			// GetDefaultSearchGUID( GUID *pguid );
			[PreserveSig]
			HRESULT GetDefaultSearchGUID(out Guid pguid);

			/// <summary>Requests a pointer to an interface that allows a client to enumerate the available search objects.</summary>
			/// <param name="ppenum">
			/// <para>Type: <c>IEnumExtraSearch**</c></para>
			/// <para>The address of a pointer to an enumerator object's IEnumExtraSearch interface.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>Returns S_OK if successful, or a COM error value otherwise.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellfolder2-enumsearches
			[PreserveSig]
			HRESULT EnumSearches(out IEnumExtraSearch ppenum);

			/// <summary>Gets the default sorting and display columns.</summary>
			/// <param name="dwRes">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Reserved. Set to zero.</para>
			/// </param>
			/// <param name="pSort">
			/// <para>Type: <c>ULONG*</c></para>
			/// <para>A pointer to a value that receives the index of the default sorted column.</para>
			/// </param>
			/// <param name="pDisplay">
			/// <para>Type: <c>ULONG*</c></para>
			/// <para>A pointer to a value that receives the index of the default display column.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>Returns S_OK if successful, or a COM error value otherwise.</para>
			/// </returns>
			/// <remarks>
			/// <para>Notes to Users</para>
			/// <para>
			/// Both column indexes returned by this method are intended for use by an application that is presenting a folder view of this folder.
			/// </para>
			/// <para>
			/// The column specified by pSort is the one that should be used for sorting the items in the folder. To determine the sorting
			/// order of any pair of items, pass their PIDLs to CompareIDs. Specify the column by setting the lParam parameter of
			/// <c>CompareIDs</c> to the value pointed to by pSort.
			/// </para>
			/// <para>
			/// If a view will display only one string to represent an item, it should be taken from the column specified by pDisplay. Pass
			/// the column index and the item's PIDL to IShellFolder2::GetDetailsOf to retrieve the string.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// This method is part of a namespace extension's folder object implementation. It is typically called by a folder view object
			/// to ask the folder object which column in Microsoft Windows Explorer Details view should be used to sort the items in the
			/// folder. For example, a folder object that represents a transaction log might set pSort to the column that displays the
			/// transaction time. The items will then be sorted by the time the transaction took place, rather than by name.
			/// </para>
			/// <para>
			/// Some clients might call this method to request the index of the column with the names that should be displayed in tree view.
			/// Set pDisplay to the appropriate column index. The client will then obtain the display names by calling IShellFolder2::GetDetailsOf.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellfolder2-getdefaultcolumn
			[PreserveSig]
			HRESULT GetDefaultColumn([Optional] uint dwRes, out uint pSort, out uint pDisplay);

			/// <summary>Gets the default state for a specified column.</summary>
			/// <param name="iColumn">
			/// <para>Type: <c>UINT</c></para>
			/// <para>An integer that specifies the column number.</para>
			/// </param>
			/// <param name="pcsFlags">
			/// <para>Type: <c>SHCOLSTATEF*</c></para>
			/// <para>
			/// A pointer to a value that contains flags that indicate the default column state. This parameter can include a combination of
			/// the following flags.
			/// </para>
			/// <para>SHCOLSTATE_TYPE_STR</para>
			/// <para>A string.</para>
			/// <para>SHCOLSTATE_TYPE_INT</para>
			/// <para>An integer.</para>
			/// <para>SHCOLSTATE_TYPE_DATE</para>
			/// <para>A date.</para>
			/// <para>SHCOLSTATE_ONBYDEFAULT</para>
			/// <para>Should be shown by default in the Windows Explorer Details view.</para>
			/// <para>SHCOLSTATE_SLOW</para>
			/// <para>
			/// Recommends that the folder view extract column information asynchronously, on a background thread, because extracting this
			/// information can be time consuming.
			/// </para>
			/// <para>SHCOLSTATE_EXTENDED</para>
			/// <para>Provided by a handler, not the folder object.</para>
			/// <para>SHCOLSTATE_SECONDARYUI</para>
			/// <para>Not displayed in the shortcut menu, but listed in the More dialog box.</para>
			/// <para>SHCOLSTATE_HIDDEN</para>
			/// <para>Not displayed in the user interface.</para>
			/// <para>SHCOLSTATE_PREFER_VARCMP</para>
			/// <para>Uses default sorting rather than CompareIDs to get the sort order.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellfolder2-getdefaultcolumnstate
			[PreserveSig]
			HRESULT GetDefaultColumnState(uint iColumn, out SHCOLSTATE pcsFlags);

			/// <summary>
			/// Gets detailed information, identified by a property set identifier (FMTID) and a property identifier (PID), on an item in a
			/// Shell folder.
			/// </summary>
			/// <param name="pidl">
			/// <para>Type: <c>PCUITEMID_CHILD</c></para>
			/// <para>
			/// A PIDL of the item, relative to the parent folder. This method accepts only single-level PIDLs. The structure must contain
			/// exactly one SHITEMID structure followed by a terminating zero. This value cannot be <c>NULL</c>.
			/// </para>
			/// </param>
			/// <param name="pscid">
			/// <para>Type: <c>const SHCOLUMNID*</c></para>
			/// <para>A pointer to an SHCOLUMNID structure that identifies the column.</para>
			/// </param>
			/// <param name="pv">
			/// <para>Type: <c>VARIANT*</c></para>
			/// <para>
			/// A pointer to a <c>VARIANT</c> with the requested information. The value is fully typed. The value returned for properties
			/// from the property system must conform to the type specified in that property definition's typeInfo as the legacyType attribute.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// This function is a more robust version of IShellFolder2::GetDetailsOf. It provides access to the information that is
			/// displayed in the Windows Explorer Details view of a Shell folder. The primary difference is that <c>GetDetailsEx</c> allows
			/// you to identify the column with an FMTID and PID structure instead of having to first determine the column index.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellfolder2-getdetailsex
			[PreserveSig]
			HRESULT GetDetailsEx([In] PIDL pidl, in PROPERTYKEY pscid, [MarshalAs(UnmanagedType.Struct)] out object pv);

			/// <summary>Gets detailed information, identified by a column index, on an item in a Shell folder.</summary>
			/// <param name="pidl">
			/// <para>Type: <c>PCUITEMID_CHILD</c></para>
			/// <para>
			/// PIDL of the item for which you are requesting information. This method accepts only single-level PIDLs. The structure must
			/// contain exactly one SHITEMID structure followed by a terminating zero. If this parameter is set to <c>NULL</c>, the title of
			/// the information field specified by iColumn is returned.
			/// </para>
			/// </param>
			/// <param name="iColumn">
			/// <para>Type: <c>UINT</c></para>
			/// <para>
			/// The zero-based index of the desired information field. It is identical to the column number of the information as it is
			/// displayed in a Windows Explorer Details view.
			/// </para>
			/// </param>
			/// <param name="psd">
			/// <para>Type: <c>SHELLDETAILS*</c></para>
			/// <para>A pointer to a SHELLDETAILS structure that contains the information.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The <c>IShellFolder2::GetDetailsOf</c> method is identical to GetDetailsOf. For a more robust way to retrieve item
			/// information that does not require you to know the column index, use IShellFolder2::GetDetailsEx.
			/// </para>
			/// <para>
			/// The <c>IShellFolder2::GetDetailsOf</c> method provides access to the information that is displayed in the Windows Explorer
			/// Details view of a Shell folder. The column numbers, headings, and information that you see in the Details view are identical
			/// to those of <c>IShellFolder2::GetDetailsOf</c>. Note that the available information fields and their column numbers vary
			/// depending on the particular folder. You can enumerate the available fields by calling this method with pidl set to
			/// <c>NULL</c>, and examining the title associated with each column index. Bear in mind that these titles can be localized and
			/// might not be the same for all locales.
			/// </para>
			/// <para>
			/// File system folders have a large, standard set of information fields. The first four fields are standard for all file system folders.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Column index</term>
			/// <term>Column title</term>
			/// </listheader>
			/// <item>
			/// <term>0</term>
			/// <term>Name</term>
			/// </item>
			/// <item>
			/// <term>1</term>
			/// <term>Size</term>
			/// </item>
			/// <item>
			/// <term>2</term>
			/// <term>Type</term>
			/// </item>
			/// <item>
			/// <term>3</term>
			/// <term>Date Modified</term>
			/// </item>
			/// </list>
			/// <para>
			/// File system folders can support a number of additional fields. However, they are not required to do so, and the column
			/// indexes assigned to these fields might vary.
			/// </para>
			/// <para>
			/// Each virtual folder has its own unique set of information fields. Normally, the item's display name is in column zero, but
			/// the order and content of the remaining fields depend on the implementation of the particular folder object.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellfolder2-getdetailsof
			[PreserveSig]
			HRESULT GetDetailsOf([In] PIDL pidl, uint iColumn, out SHELLDETAILS psd);

			/// <summary>Converts a column to the appropriate property set ID (FMTID) and property ID (PID).</summary>
			/// <param name="iColumn">
			/// <para>Type: <c>UINT</c></para>
			/// <para>The column ID.</para>
			/// </param>
			/// <param name="pscid">
			/// <para>Type: <c>SHCOLUMNID*</c></para>
			/// <para>A pointer to an SHCOLUMNID structure containing the FMTID and PID.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellfolder2-mapcolumntoscid
			[PreserveSig]
			HRESULT MapColumnToSCID(uint iColumn, out PROPERTYKEY pscid);
		}

		/// <summary>Exposes a method that obtains an icon index for an IShellFolder object.</summary>
		/// <remarks>
		/// <para>
		/// Implement <c>IShellIcon</c> when creating an IShellFolder implementation to provide a quick way to obtain the icon for an object
		/// in the folder.
		/// </para>
		/// <para>
		/// If <c>IShellIcon</c> is not implemented by an IShellFolder object, IShellFolder::GetUIObjectOf is used to retrieve an icon for
		/// all objects.
		/// </para>
		/// <para>Use <c>IShellIcon</c> when retrieving the icon index for an item in a Shell folder.</para>
		/// <para>
		/// <c>IShellIcon</c> allows an application to obtain the icon for any object within a folder by using only one instance of the
		/// interface. IExtractIcon, on the other hand, requires that a separate instance of the interface be created for each object.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ishellicon
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IShellIcon")]
		[ComImport, Guid("000214E5-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IShellIcon
		{
			/// <summary>Gets an icon for an object inside a specific folder.</summary>
			/// <param name="pidl">
			/// <para>Type: <c>LPCITEMIDLIST</c></para>
			/// <para>The address of the ITEMIDLIST structure that specifies the relative location of the folder.</para>
			/// </param>
			/// <param name="flags">
			/// <para>Type: <c>UINT</c></para>
			/// <para>Flags specifying how the icon is to display. This parameter can be zero or one of the following values.</para>
			/// <para>GIL_FORSHELL</para>
			/// <para>The icon is to be displayed in a Shell folder.</para>
			/// <para>GIL_OPENICON</para>
			/// <para>The icon should be in the open state if both open-state and closed-state images are available. If this flag is not specified, the icon should be in the closed state. This flag is typically used for folder objects.</para>
			/// </param>
			/// <param name="pIconIndex">
			/// <para>Type: <c>LPINT</c></para>
			/// <para>The address of the index of the icon in the system image list. The following standard image list indexes can be returned.</para>
			/// <para>0</para>
			/// <para>Document (blank page, not associated)</para>
			/// <para>1</para>
			/// <para>Document (with data on the page)</para>
			/// <para>2</para>
			/// <para>Application (file name extension must be .exe, .com, or .bat)</para>
			/// <para>3</para>
			/// <para>Folder (plain)</para>
			/// <para>4</para>
			/// <para>Folder (open)</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>Returns S_OK if lpIconIndex contains the correct system image list index, or S_FALSE if an icon can't be obtained for this object.</para>
			/// </returns>
			/// <remarks>
			/// <para>If you are unable to retrieve an icon for this object using <c>GetIconOf</c>, use the GetUIObjectOf method to retrieve an object that supports the Extract method.</para>
			/// <para><c>IShellIcon::GetIconOf</c> fails if CoInitialize is not called first.</para>
			/// <para>Note to Calling Applications</para>
			/// <para>The index returned is from the system image list.</para>
			/// <para>Note to Implementers</para>
			/// <para>If the icon index used is not one of the standard images listed, it is the implementer's responsibility to add the image to the system image list and then place the index into the lpIconIndex parameter. To prevent the system image list from growing too large, each image should only be added once.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellicon-geticonof
			[PreserveSig]
			HRESULT GetIconOf([In] PIDL pidl, GetIconLocationFlags flags, out int pIconIndex);
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
		/// Information that can be provided in the bind context includes a BIND_OPTS structure that includes a grfMode member that
		/// indicates the access mode when binding to a stream handler. Other parameters can be set and discovered using
		/// IBindCtx::RegisterObjectParam and IBindCtx::GetObjectParam.
		/// </para>
		/// </param>
		/// <returns>Receives the interface pointer requested in <typeparamref name="T"/>.</returns>
		public static T BindToObject<T>(this IShellFolder sf, [In] PIDL pidl, [In, Optional] IBindCtx pbc) where T : class
		{
			sf.BindToObject(pidl, pbc, typeof(T).GUID, out var o).ThrowIfFailed();
			return (T)o;
		}

		/// <summary>Extension method to simplify using the <see cref="IShellFolder.BindToStorage"/> method.</summary>
		/// <typeparam name="T">Type of the interface to get.</typeparam>
		/// <param name="sf">An <see cref="IShellFolder"/> instance.</param>
		/// <param name="pidl">
		/// The address of an ITEMIDLIST structure that identifies the subfolder relative to its parent folder. The structure must contain
		/// exactly one SHITEMID structure followed by a terminating zero.
		/// </param>
		/// <param name="pbc">
		/// The optional address of an IBindCtx interface on a bind context object to be used during this operation. If this parameter is
		/// not used, set it to NULL. Because support for pbc is optional for folder object implementations, some folders may not support
		/// the use of bind contexts.
		/// </param>
		/// <returns>Receives the interface pointer requested in <typeparamref name="T"/>.</returns>
		public static T BindToStorage<T>(this IShellFolder sf, [In] PIDL pidl, [In, Optional] IBindCtx pbc) where T : class
		{
			sf.BindToStorage(pidl, pbc, typeof(T).GUID, out var o).ThrowIfFailed();
			return (T)o;
		}

		/// <summary>Extension method to simplify using the <see cref="IShellFolder.CreateViewObject"/> method.</summary>
		/// <typeparam name="T">
		/// <para>This is typically IShellView.</para>
		/// <para>
		/// This method is also used to request objects that expose one of several optional interfaces, including IContextMenu or
		/// IExtractIcon. In this context, <c>CreateViewObject</c> is similar in usage to IShellFolder::GetUIObjectOf. However, you call
		/// <c>IShellFolder::GetUIObjectOf</c> to request an object for one of the items contained by a folder. Call
		/// <c>IShellFolder::CreateViewObject</c> to request an object for the folder itself. The most commonly requested interfaces are:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>IQueryInfo</term>
		/// </item>
		/// <item>
		/// <term>IShellDetails</term>
		/// </item>
		/// <item>
		/// <term>IDropTarget</term>
		/// </item>
		/// </list>
		/// </typeparam>
		/// <param name="sf">An <see cref="IShellFolder"/> instance.</param>
		/// <param name="hwndOwner">
		/// A handle to the owner window. If you have implemented a custom folder view object, your folder view window should be created as
		/// a child of hwndOwner.
		/// </param>
		/// <remarks>
		/// <para>To support this request, create an object that exposes the interface indicated by riid and return a pointer to that interface.</para>
		/// <para>
		/// The primary purpose of this method is to provide Windows Explorer with the folder object's folder view object. Windows Explorer
		/// requests a folder view object by setting riid to IID_IShellView. The folder view object displays the contents of the folder in
		/// the Windows Explorer folder view. The folder view object must be independent of the Shell folder object, because Windows
		/// Explorer may call this method more than once to create multiple folder view objects. A new view object must be created each time
		/// this method is called. Your folder object can respond in one of two ways to this request. It can:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Create a custom folder view object and return a pointer to its IShellView interface.</term>
		/// </item>
		/// <item>
		/// <term>Create a system folder view object and return a pointer to its IShellView interface.</term>
		/// </item>
		/// </list>
		/// </remarks>
		public static T CreateViewObject<T>(this IShellFolder sf, HWND hwndOwner) where T : class
		{
			sf.CreateViewObject(hwndOwner, typeof(T).GUID, out var o).ThrowIfFailed();
			return (T)o;
		}

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
		public static IEnumerable<PIDL> EnumObjects(this IShellFolder sf, SHCONTF grfFlags = SHCONTF.SHCONTF_FOLDERS | SHCONTF.SHCONTF_NONFOLDERS, HWND hwnd = default)
		{
			sf.EnumObjects(hwnd, grfFlags, out var eo).ThrowIfFailed();
			using var peo = InteropServices.ComReleaserFactory.Create(eo);
			return eo.Enumerate().ToArray();
		}

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
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellfolder-getdisplaynameof HRESULT
		// GetDisplayNameOf( PCUITEMID_CHILD pidl, SHGDNF uFlags, STRRET *pName );
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
		public static T GetUIObjectOf<T>(this IShellFolder sf, HWND hwndOwner, params PIDL[] apidl) where T : class => GetUIObjectOf<T>(sf, hwndOwner, Array.ConvertAll(apidl, p => p.DangerousGetHandle()));

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
		public static T GetUIObjectOf<T>(this IShellFolder sf, HWND hwndOwner, params IntPtr[] apidl) where T : class
		{
			sf.GetUIObjectOf(hwndOwner, (uint)apidl.Length, apidl, typeof(T).GUID, default, out var o).ThrowIfFailed();
			return (T)o;
		}

		/// <summary>Extension method to simplify using the <see cref="IShellFolder.GetUIObjectOf"/> method.</summary>
		/// <typeparam name="T">Type of the interface to get.</typeparam>
		/// <param name="sf">An <see cref="IShellFolder"/> instance.</param>
		/// <param name="apidl">
		/// An array of pointers to ITEMIDLIST structures, each of which uniquely identifies a file object or subfolder relative to the
		/// parent folder. Each item identifier list must contain exactly one SHITEMID structure followed by a terminating zero.
		/// </param>
		/// <param name="ppv">When this method returns successfully, contains the interface pointer requested in <typeparamref name="T"/>.</param>
		/// <param name="hwndOwner">
		/// A handle to the owner window that the client should specify if it displays a dialog box or message box.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		public static HRESULT GetUIObjectOf<T>(this IShellFolder sf, IntPtr[] apidl, out T ppv, HWND hwndOwner = default) where T : class
		{
			var hr = sf.GetUIObjectOf(hwndOwner, (uint)apidl.Length, apidl, typeof(T).GUID, default, out var o);
			ppv = hr.Succeeded ? (T)o : default;
			return hr;
		}

		/// <summary>Extension method to simplify using the <see cref="IShellFolder.GetUIObjectOf"/> method.</summary>
		/// <typeparam name="T">Type of the interface to get.</typeparam>
		/// <param name="sf">An <see cref="IShellFolder"/> instance.</param>
		/// <param name="pidl">
		/// A pointer to ITEMIDLIST structures, which uniquely identifies a file object or subfolder relative to the parent folder. Each
		/// item identifier list must contain exactly one SHITEMID structure followed by a terminating zero.
		/// </param>
		/// <param name="ppv">When this method returns successfully, contains the interface pointer requested in <typeparamref name="T"/>.</param>
		/// <param name="hwndOwner">
		/// A handle to the owner window that the client should specify if it displays a dialog box or message box.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		public static HRESULT GetUIObjectOf<T>(this IShellFolder sf, IntPtr pidl, out T ppv, HWND hwndOwner = default) where T : class =>
			GetUIObjectOf<T>(sf, new[] { pidl }, out ppv, hwndOwner);

		/// <summary>Specifies methods for sorting category data.</summary>
		/// <summary>
		/// Contains category information. A component category is a group of logically-related Component Object Model (COM) classes that
		/// share a common category identifier (CATID).
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/ns-shobjidl_core-category_info typedef struct CATEGORY_INFO {
		// CATEGORYINFO_FLAGS cif; WCHAR wszName[260]; } CATEGORY_INFO;
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NS:shobjidl_core.CATEGORY_INFO")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 4)]
		public struct CATEGORY_INFO
		{
			/// <summary>
			/// <para>Type: <c>CATEGORYINFO_FLAGS</c></para>
			/// <para>A flag from CATEGORYINFO_FLAGS that specifies the type of information to retrieve.</para>
			/// </summary>
			public CATEGORYINFO_FLAGS cif;

			/// <summary>
			/// <para>Type: <c>WCHAR[260]</c></para>
			/// <para>A character array that specifies the name of the category.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
			public string wszName;
		}

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

		/// <summary>CLSID_ControlPanel</summary>
		[PInvokeData("shlguid.h")]
		[ComImport, Guid("21EC2020-3AEA-1069-A2DD-08002B30309D"), ClassInterface(ClassInterfaceType.None)]
		public class ControlPanel { }

		/// <summary>CLSID_Internet</summary>
		[PInvokeData("shlguid.h")]
		[ComImport, Guid("871C5380-42A0-1069-A2EA-08002B30309D"), ClassInterface(ClassInterfaceType.None)]
		public class Internet { }

		/// <summary>CLSID_MyComputer</summary>
		[PInvokeData("shlguid.h")]
		[ComImport, Guid("20D04FE0-3AEA-1069-A2D8-08002B30309D"), ClassInterface(ClassInterfaceType.None)]
		public class MyComputer { }

		/// <summary>CLSID_MyDocuments</summary>
		[PInvokeData("shlguid.h")]
		[ComImport, Guid("450D8FBA-AD25-11D0-98A8-0800361B1103"), ClassInterface(ClassInterfaceType.None)]
		public class MyDocuments { }

		/// <summary>CLSID_NetworkConnections</summary>
		[PInvokeData("shobjidl_core.h")]
		[ComImport, Guid("7007ACC7-3202-11D1-AAD2-00805FC1270E"), ClassInterface(ClassInterfaceType.None)]
		public class NetworkConnections { }

		/// <summary>CLSID_NetworkDomain</summary>
		[PInvokeData("shlguid.h")]
		[ComImport, Guid("46e06680-4bf0-11d1-83ee-00a0c90dc849"), ClassInterface(ClassInterfaceType.None)]
		public class NetworkDomain { }

		/// <summary>CLSID_NetworkExplorerFolder</summary>
		[PInvokeData("shobjidl_core.h")]
		[ComImport, Guid("F02C1A0D-BE21-4350-88B0-7367FC96EF3C"), ClassInterface(ClassInterfaceType.None)]
		public class NetworkExplorerFolder { }

		/// <summary>CLSID_NetworkPlaces</summary>
		[PInvokeData("shobjidl_core.h")]
		[ComImport, Guid("208D2C60-3AEA-1069-A2D7-08002B30309D"), ClassInterface(ClassInterfaceType.None)]
		public class NetworkPlaces { }

		/// <summary>CLSID_NetworkServer</summary>
		[PInvokeData("shlguid.h")]
		[ComImport, Guid("c0542a90-4bf0-11d1-83ee-00a0c90dc849"), ClassInterface(ClassInterfaceType.None)]
		public class NetworkServer { }

		/// <summary>CLSID_NetworkShare</summary>
		[PInvokeData("shlguid.h")]
		[ComImport, Guid("54a754c0-4bf1-11d1-83ee-00a0c90dc849"), ClassInterface(ClassInterfaceType.None)]
		public class NetworkShare { }

		/// <summary>CLSID_Printers</summary>
		[PInvokeData("shlguid.h")]
		[ComImport, Guid("2227A280-3AEA-1069-A2DE-08002B30309D"), ClassInterface(ClassInterfaceType.None)]
		public class Printers { }

		/// <summary>CLSID_RecycleBin</summary>
		[PInvokeData("shlguid.h")]
		[ComImport, Guid("645FF040-5081-101B-9F08-00AA002F954E"), ClassInterface(ClassInterfaceType.None)]
		public class RecycleBin { }

		/// <summary>CLSID_ScheduledTasks</summary>
		[PInvokeData("shobjidl_core.h")]
		[ComImport, Guid("D6277990-4C6A-11CF-8D87-00AA0060F5BF"), ClassInterface(ClassInterfaceType.None)]
		public class ScheduledTasks { }

		/// <summary>CLSID_ShellDesktop</summary>
		[PInvokeData("shobjidl_core.h")]
		[ComImport, Guid("00021400-0000-0000-C000-000000000046"), ClassInterface(ClassInterfaceType.None)]
		public class ShellDesktop { }

		/// <summary>CLSID_ShellFSFolder</summary>
		[PInvokeData("shobjidl_core.h")]
		[ComImport, Guid("F3364BA0-65B9-11CE-A9BA-00AA004AE837"), ClassInterface(ClassInterfaceType.None)]
		public class ShellFSFolder { }
	}
}