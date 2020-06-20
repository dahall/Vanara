using System;
using System.Collections.Generic;
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
			/// <remarks>
			/// In the case of the system folder view object, if the description at pszDesc matches one of the category names listed in the
			/// folder's <c>Arrange Icons By</c> menu, a dot is placed by that name when the menu is displayed, either through the
			/// <c>View</c> menu or through the context menu.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-icategorizer-getdescription HRESULT
			// GetDescription( LPWSTR pszDesc, UINT cch );
			void GetDescription([MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDesc, uint cch);

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
			/// <remarks>
			/// <para>
			/// The <c>ICategorizer::GetCategory</c> method accepts an array of pointers to item identifier lists (PIDLs) and fills an array
			/// of category identifiers.
			/// </para>
			/// <para><c>Important</c> The value -1 is an invalid category identifier.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-icategorizer-getcategory HRESULT
			// GetCategory( UINT cidl, PCUITEMID_CHILD_ARRAY apidl, DWORD *rgCategoryIds );
			void GetCategory(uint cidl, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] IntPtr[] apidl, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] uint[] rgCategoryIds);

			/// <summary>Gets information about a category, such as the default display and the text to display in the UI.</summary>
			/// <param name="dwCategoryId">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>A <c>DWORD</c> that specifies a category identifier.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>CATEGORY_INFO*</c></para>
			/// <para>When this method returns, contains a pointer to a CATEGORY_INFO structure that contains the category information.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-icategorizer-getcategoryinfo HRESULT
			// GetCategoryInfo( DWORD dwCategoryId, CATEGORY_INFO *pci );
			CATEGORY_INFO GetCategoryInfo(uint dwCategoryId);

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
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-icategorizer-comparecategory HRESULT
			// CompareCategory( CATSORT_FLAGS csfFlags, DWORD dwCategoryId1, DWORD dwCategoryId2 );
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
			/// <returns>
			/// <para>Type: <c>IEnumGUID**</c></para>
			/// <para>
			/// When this method returns, contains the address of a pointer to an <c>IEnumGUID</c> interface that specifies a list of GUIDs
			/// that represent categories.
			/// </para>
			/// </returns>
			/// <remarks>
			/// In the case of the system folder view object, <c>ICategoryProvider::EnumCategories</c> is used to obtain additional
			/// categories that are not associated with a column. When the list of category GUIDs is returned through penum, the UI attempts
			/// to retrieve the name of each category. That name is then displayed as a category choice. In the case of Windows XP, that
			/// choice appears in the folder's <c>Arrange Icons By</c> menu.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-icategoryprovider-enumcategories HRESULT
			// EnumCategories( IEnumGUID **penum );
			IEnumGUID EnumCategories();

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
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-icategoryprovider-getcategoryname HRESULT
			// GetCategoryName( const GUID *pguid, LPWSTR pszName, UINT cch );
			void GetCategoryName(in Guid pguid, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszName, uint cch);

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
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-icategoryprovider-createcategory HRESULT
			// CreateCategory( const GUID *pguid, REFIID riid, void **ppv );
			void CreateCategory(in Guid pguid, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppv);
		}

		/// <summary>A standard OLE enumerator used by a client to determine the available search objects for a folder.</summary>
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0E700BE1-9DB6-11d1-A1CE-00C04FD75D13")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb761992")]
		public interface IEnumExtraSearch
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
				[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] EXTRASEARCH[] rgelt,
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
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iobjectwithfolderenummode-setmode HRESULT
			// SetMode( FOLDER_ENUM_MODE feMode );
			void SetMode(FOLDER_ENUM_MODE feMode);

			/// <summary>Retrieves the enumeration mode of the parsed item.</summary>
			/// <returns>
			/// <para>Type: <c>FOLDER_ENUM_MODE*</c></para>
			/// <para>
			/// Pointer to a value that, when this method returns successfully, receives one of the FOLDER_ENUM_MODE values specifying the
			/// enumeration mode.
			/// </para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iobjectwithfolderenummode-getmode HRESULT
			// GetMode( FOLDER_ENUM_MODE *pfeMode );
			FOLDER_ENUM_MODE GetMode();
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
			/// this string can take may vary. The desktop folder, for instance, accepts paths such as "C:\My Docs\My File.txt". It also
			/// will accept references to items in the namespace that have a GUID associated with them using the "::{GUID}" syntax.
			/// </param>
			/// <param name="pchEaten">
			/// A pointer to a ULONG value that receives the number of characters of the display name that was parsed. If your application
			/// does not need this information, set pchEaten to NULL, and no value will be returned.
			/// </param>
			/// <param name="ppidl">
			/// When this method returns, contains a pointer to the PIDL for the object. The returned item identifier list specifies the
			/// item relative to the parsing folder. If the object associated with pszDisplayName is within the parsing folder, the returned
			/// item identifier list will contain only one SHITEMID structure. If the object is in a subfolder of the parsing folder, the
			/// returned item identifier list will contain multiple SHITEMID structures. If an error occurs, NULL is returned in this address.
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
			/// parent window to take user input. An example would be a dialog box to ask for a password or prompt the user to insert a CD
			/// or floppy disk. If hwndOwner is set to NULL, the enumerator should not post any messages, and if user input is required, it
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
			/// When this method returns, contains the address of a pointer to the requested interface. If an error occurs, a NULL pointer
			/// is returned at this address.
			/// </returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			object BindToObject([In] PIDL pidl, [In, Optional] IBindCtx pbc, in Guid riid);

			/// <summary>Requests a pointer to an object's storage interface.</summary>
			/// <param name="pidl">
			/// The address of an ITEMIDLIST structure that identifies the subfolder relative to its parent folder. The structure must
			/// contain exactly one SHITEMID structure followed by a terminating zero.
			/// </param>
			/// <param name="pbc">
			/// The optional address of an IBindCtx interface on a bind context object to be used during this operation. If this parameter
			/// is not used, set it to NULL. Because support for pbc is optional for folder object implementations, some folders may not
			/// support the use of bind contexts.
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
			/// <returns>
			/// <para>Type: <c>void**</c></para>
			/// <para>
			/// When this method returns successfully, contains the interface pointer requested in riid. This is typically IShellView. See
			/// the Remarks section for more details.
			/// </para>
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
			// HRESULT CreateViewObject( HWND hwndOwner, REFIID riid, void **ppv );
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
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellfolder-getdisplaynameof HRESULT
			// GetDisplayNameOf( PCUITEMID_CHILD pidl, SHGDNF uFlags, STRRET *pName );
			void GetDisplayNameOf([In] PIDL pidl, SHGDNF uFlags, out STRRET pName); //[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(STRRETMarshaler))] out string pName);

			/// <summary>Sets the display name of a file object or subfolder, changing the item identifier in the process.</summary>
			/// <param name="hwnd">A handle to the owner window of any dialog or message box that the client displays.</param>
			/// <param name="pidl">
			/// A pointer to an ITEMIDLIST structure that uniquely identifies the file object or subfolder relative to the parent folder.
			/// The structure must contain exactly one SHITEMID structure followed by a terminating zero.
			/// </param>
			/// <param name="pszName">A pointer to a null-terminated string that specifies the new display name.</param>
			/// <param name="uFlags">
			/// Flags that indicate the type of name specified by the pszName parameter. For a list of possible values and combinations of
			/// values, see SHGDNF.
			/// </param>
			/// <param name="ppidlOut">
			/// Optional. If specified, the address of a pointer to an ITEMIDLIST structure that receives the ITEMIDLIST of the renamed
			/// item. The caller requests this value by passing a non-null ppidlOut. Implementations of IShellFolder::SetNameOf must return
			/// a pointer to the new ITEMIDLIST in the ppidlOut parameter.
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
			/// this string can take may vary. The desktop folder, for instance, accepts paths such as "C:\My Docs\My File.txt". It also
			/// will accept references to items in the namespace that have a GUID associated with them using the "::{GUID}" syntax.
			/// </param>
			/// <param name="pchEaten">
			/// A pointer to a ULONG value that receives the number of characters of the display name that was parsed. If your application
			/// does not need this information, set pchEaten to NULL, and no value will be returned.
			/// </param>
			/// <param name="ppidl">
			/// When this method returns, contains a pointer to the PIDL for the object. The returned item identifier list specifies the
			/// item relative to the parsing folder. If the object associated with pszDisplayName is within the parsing folder, the returned
			/// item identifier list will contain only one SHITEMID structure. If the object is in a subfolder of the parsing folder, the
			/// returned item identifier list will contain multiple SHITEMID structures. If an error occurs, NULL is returned in this address.
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
			/// parent window to take user input. An example would be a dialog box to ask for a password or prompt the user to insert a CD
			/// or floppy disk. If hwndOwner is set to NULL, the enumerator should not post any messages, and if user input is required, it
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
			/// When this method returns, contains the address of a pointer to the requested interface. If an error occurs, a NULL pointer
			/// is returned at this address.
			/// </returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			new object BindToObject([In] PIDL pidl, [In, Optional] IBindCtx pbc, in Guid riid);

			/// <summary>Requests a pointer to an object's storage interface.</summary>
			/// <param name="pidl">
			/// The address of an ITEMIDLIST structure that identifies the subfolder relative to its parent folder. The structure must
			/// contain exactly one SHITEMID structure followed by a terminating zero.
			/// </param>
			/// <param name="pbc">
			/// The optional address of an IBindCtx interface on a bind context object to be used during this operation. If this parameter
			/// is not used, set it to NULL. Because support for pbc is optional for folder object implementations, some folders may not
			/// support the use of bind contexts.
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
			/// <returns>
			/// <para>Type: <c>void**</c></para>
			/// <para>
			/// When this method returns successfully, contains the interface pointer requested in riid. This is typically IShellView. See
			/// the Remarks section for more details.
			/// </para>
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
			new void GetDisplayNameOf([In] PIDL pidl, SHGDNF uFlags, out STRRET pName);

			/// <summary>Sets the display name of a file object or subfolder, changing the item identifier in the process.</summary>
			/// <param name="hwnd">A handle to the owner window of any dialog or message box that the client displays.</param>
			/// <param name="pidl">
			/// A pointer to an ITEMIDLIST structure that uniquely identifies the file object or subfolder relative to the parent folder.
			/// The structure must contain exactly one SHITEMID structure followed by a terminating zero.
			/// </param>
			/// <param name="pszName">A pointer to a null-terminated string that specifies the new display name.</param>
			/// <param name="uFlags">
			/// Flags that indicate the type of name specified by the pszName parameter. For a list of possible values and combinations of
			/// values, see SHGDNF.
			/// </param>
			/// <param name="ppidlOut">
			/// Optional. If specified, the address of a pointer to an ITEMIDLIST structure that receives the ITEMIDLIST of the renamed
			/// item. The caller requests this value by passing a non-null ppidlOut. Implementations of IShellFolder::SetNameOf must return
			/// a pointer to the new ITEMIDLIST in the ppidlOut parameter.
			/// </param>
			new void SetNameOf(HWND hwnd, [In] PIDL pidl, [MarshalAs(UnmanagedType.LPWStr)] string pszName, SHGDNF uFlags, out PIDL ppidlOut);

			/// <summary>Returns the globally unique identifier (GUID) of the default search object for the folder.</summary>
			/// <returns>The GUID of the default search object.</returns>
			Guid GetDefaultSearchGUID();

			/// <summary>Requests a pointer to an interface that allows a client to enumerate the available search objects.</summary>
			/// <returns>The address of a pointer to an enumerator object's IEnumExtraSearch interface.</returns>
			IEnumExtraSearch EnumSearches();

			/// <summary>Gets the default sorting and display columns.</summary>
			/// <param name="dwRes">Reserved. Set to zero.</param>
			/// <param name="pSort">A pointer to a value that receives the index of the default sorted column.</param>
			/// <param name="pDisplay">A pointer to a value that receives the index of the default display column.</param>
			[PreserveSig]
			void GetDefaultColumn([Optional] uint dwRes, out uint pSort, out uint pDisplay);

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
			/// <para>Flags specifying how the icon is to display. This parameter can be zero or one of the following values from <see cref="IExtractIcon"/>.</para>
			/// <para>GIL_FORSHELL</para>
			/// <para>The icon is to be displayed in a Shell folder.</para>
			/// <para>GIL_OPENICON</para>
			/// <para>
			/// The icon should be in the open state if both open-state and closed-state images are available. If this flag is not
			/// specified, the icon should be in the closed state. This flag is typically used for folder objects.
			/// </para>
			/// </param>
			/// <returns>
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
			/// </returns>
			/// <remarks>
			/// <para>
			/// If you are unable to retrieve an icon for this object using <c>GetIconOf</c>, use the GetUIObjectOf method to retrieve an
			/// object that supports the Extract method.
			/// </para>
			/// <para><c>IShellIcon::GetIconOf</c> fails if CoInitialize is not called first.</para>
			/// <para>Note to Calling Applications</para>
			/// <para>The index returned is from the system image list.</para>
			/// <para>Note to Implementers</para>
			/// <para>
			/// If the icon index used is not one of the standard images listed, it is the implementer's responsibility to add the image to
			/// the system image list and then place the index into the lpIconIndex parameter. To prevent the system image list from growing
			/// too large, each image should only be added once.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellicon-geticonof HRESULT GetIconOf(
			// PCUITEMID_CHILD pidl, UINT flags, int *pIconIndex );
			int GetIconOf([In] PIDL pidl, GetIconLocationFlags flags);
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
		public static T BindToObject<T>(this IShellFolder sf, [In] PIDL pidl, [In, Optional] IBindCtx pbc) where T : class => (T)sf.BindToObject(pidl, pbc, typeof(T).GUID);

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
		public static T BindToStorage<T>(this IShellFolder sf, [In] PIDL pidl, [In, Optional] IBindCtx pbc) where T : class => (T)sf.BindToStorage(pidl, pbc, typeof(T).GUID);

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
		public static T CreateViewObject<T>(this IShellFolder sf, HWND hwndOwner) where T : class => (T)sf.CreateViewObject(hwndOwner, typeof(T).GUID);

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
		public static T GetUIObjectOf<T>(this IShellFolder sf, HWND hwndOwner, PIDL[] apidl) where T : class => (T)sf.GetUIObjectOf(hwndOwner, (uint)apidl.Length, Array.ConvertAll(apidl, p => p.DangerousGetHandle()), typeof(T).GUID);

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

		/// <summary>CLSID_NetworkConnections</summary>
		[PInvokeData("shobjidl_core.h")]
		[ComImport, Guid("7007ACC7-3202-11D1-AAD2-00805FC1270E"), ClassInterface(ClassInterfaceType.None)]
		public class NetworkConnections { }

		/// <summary>CLSID_NetworkExplorerFolder</summary>
		[PInvokeData("shobjidl_core.h")]
		[ComImport, Guid("F02C1A0D-BE21-4350-88B0-7367FC96EF3C"), ClassInterface(ClassInterfaceType.None)]
		public class NetworkExplorerFolder { }

		/// <summary>CLSID_NetworkPlaces</summary>
		[PInvokeData("shobjidl_core.h")]
		[ComImport, Guid("208D2C60-3AEA-1069-A2D7-08002B30309D"), ClassInterface(ClassInterfaceType.None)]
		public class NetworkPlaces { }

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

		/// <summary>CLSID_NetworkDomain</summary>
		[PInvokeData("shlguid.h")]
		[ComImport, Guid("46e06680-4bf0-11d1-83ee-00a0c90dc849"), ClassInterface(ClassInterfaceType.None)]
		public class NetworkDomain { }

		/// <summary>CLSID_NetworkServer</summary>
		[PInvokeData("shlguid.h")]
		[ComImport, Guid("c0542a90-4bf0-11d1-83ee-00a0c90dc849"), ClassInterface(ClassInterfaceType.None)]
		public class NetworkServer { }

		/// <summary>CLSID_NetworkShare</summary>
		[PInvokeData("shlguid.h")]
		[ComImport, Guid("54a754c0-4bf1-11d1-83ee-00a0c90dc849"), ClassInterface(ClassInterfaceType.None)]
		public class NetworkShare { }

		/// <summary>CLSID_MyComputer</summary>
		[PInvokeData("shlguid.h")]
		[ComImport, Guid("20D04FE0-3AEA-1069-A2D8-08002B30309D"), ClassInterface(ClassInterfaceType.None)]
		public class MyComputer { }

		/// <summary>CLSID_Internet</summary>
		[PInvokeData("shlguid.h")]
		[ComImport, Guid("871C5380-42A0-1069-A2EA-08002B30309D"), ClassInterface(ClassInterfaceType.None)]
		public class Internet { }

		/// <summary>CLSID_RecycleBin</summary>
		[PInvokeData("shlguid.h")]
		[ComImport, Guid("645FF040-5081-101B-9F08-00AA002F954E"), ClassInterface(ClassInterfaceType.None)]
		public class RecycleBin { }

		/// <summary>CLSID_ControlPanel</summary>
		[PInvokeData("shlguid.h")]
		[ComImport, Guid("21EC2020-3AEA-1069-A2DD-08002B30309D"), ClassInterface(ClassInterfaceType.None)]
		public class ControlPanel { }

		/// <summary>CLSID_Printers</summary>
		[PInvokeData("shlguid.h")]
		[ComImport, Guid("2227A280-3AEA-1069-A2DE-08002B30309D"), ClassInterface(ClassInterfaceType.None)]
		public class Printers { }

		/// <summary>CLSID_MyDocuments</summary>
		[PInvokeData("shlguid.h")]
		[ComImport, Guid("450D8FBA-AD25-11D0-98A8-0800361B1103"), ClassInterface(ClassInterfaceType.None)]
		public class MyDocuments { }
	}
}