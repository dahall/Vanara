using System.Runtime.InteropServices.ComTypes;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.PropSys;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary/>
	public const int MAX_COLUMN_NAME_LEN = 80;

	/// <summary>
	/// <para>
	/// Used by members of the IColumnManager interface to specify which set of columns are being requested, either all or only those
	/// currently visible.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/ne-shobjidl_core-cm_enum_flags typedef enum CM_ENUM_FLAGS {
	// CM_ENUM_ALL, CM_ENUM_VISIBLE } ;
	[PInvokeData("shobjidl_core.h", MSDNShortId = "9706ae59-d172-4518-8090-375b1a0ff4fb")]
	public enum CM_ENUM_FLAGS
	{
		/// <summary>Enumerate all.</summary>
		CM_ENUM_ALL = 0x00000001,

		/// <summary>Enumerate visible.</summary>
		CM_ENUM_VISIBLE = 0x00000002,
	}

	/// <summary>
	/// <para>Indicates which values in the CM_COLUMNINFO structure should be set during calls to IColumnManager::SetColumnInfo.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/ne-shobjidl_core-cm_mask typedef enum CM_MASK { CM_MASK_WIDTH,
	// CM_MASK_DEFAULTWIDTH, CM_MASK_IDEALWIDTH, CM_MASK_NAME, CM_MASK_STATE } ;
	[PInvokeData("shobjidl_core.h", MSDNShortId = "c6ba9410-7c56-428c-9ad9-4e769c047863")]
	public enum CM_MASK
	{
		/// <summary>The uWidth member is specified.</summary>
		CM_MASK_WIDTH = 0x00000001,

		/// <summary>The uDefaultWidth member is specified.</summary>
		CM_MASK_DEFAULTWIDTH = 0x00000002,

		/// <summary>The uIdealWidth member is specified.</summary>
		CM_MASK_IDEALWIDTH = 0x00000004,

		/// <summary>The wszName member is specified.</summary>
		CM_MASK_NAME = 0x00000008,

		/// <summary>The dwState member is specified.</summary>
		CM_MASK_STATE = 0x00000010,
	}

	/// <summary>
	/// <para>
	/// Specifies width values in pixels and includes special support for default and autosize. Used by members of the IColumnManager
	/// interface through the CM_COLUMNINFO structure.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/ne-shobjidl_core-cm_set_width_value typedef enum
	// CM_SET_WIDTH_VALUE { CM_WIDTH_USEDEFAULT, CM_WIDTH_AUTOSIZE } ;
	[PInvokeData("shobjidl_core.h", MSDNShortId = "c5778bcc-fc9e-499a-b5e5-31c4f2df4871")]
	public enum CM_SET_WIDTH_VALUE
	{
		/// <summary>Use the default width.</summary>
		CM_WIDTH_USEDEFAULT = -1,

		/// <summary>Use the auto-size width.</summary>
		CM_WIDTH_AUTOSIZE = -2,
	}

	/// <summary>
	/// <para>Specifies column state values. Used by members of the IColumnManager interface through the CM_COLUMNINFO structure.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/ne-shobjidl_core-cm_state typedef enum CM_STATE {
	// CM_STATE_NONE, CM_STATE_VISIBLE, CM_STATE_FIXEDWIDTH, CM_STATE_NOSORTBYFOLDERNESS, CM_STATE_ALWAYSVISIBLE } ;
	[PInvokeData("shobjidl_core.h", MSDNShortId = "a614dfdc-9535-40c4-9a17-5ab032113508")]
	public enum CM_STATE
	{
		/// <summary>The column is not currently displayed.</summary>
		CM_STATE_NONE = 0x00000000,

		/// <summary>The column is currently displayed.</summary>
		CM_STATE_VISIBLE = 0x00000001,

		/// <summary>The column cannot be resized.</summary>
		CM_STATE_FIXEDWIDTH = 0x00000002,

		/// <summary>Do not sort folders separately.</summary>
		CM_STATE_NOSORTBYFOLDERNESS = 0x00000004,

		/// <summary>The column cannot be hidden.</summary>
		CM_STATE_ALWAYSVISIBLE = 0x00000008,
	}

	/// <summary>
	/// <para>Used by IFolderViewSettings::GetViewMode and ISearchFolderItemFactory::SetFolderLogicalViewMode to describe the view mode.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/ne-shobjidl_core-folderlogicalviewmode typedef enum
	// FOLDERLOGICALVIEWMODE { FLVM_UNSPECIFIED, FLVM_FIRST, FLVM_DETAILS, FLVM_TILES, FLVM_ICONS, FLVM_LIST, FLVM_CONTENT, FLVM_LAST } ;
	[PInvokeData("shobjidl_core.h", MSDNShortId = "4b30a335-ed80-4774-82d4-bc93c95ee80c")]
	public enum FOLDERLOGICALVIEWMODE
	{
		/// <summary>The view is not specified.</summary>
		FLVM_UNSPECIFIED,

		/// <summary>The minimum valid enumeration value. Used for validation purposes only.</summary>
		FLVM_FIRST,

		/// <summary>Details view.</summary>
		FLVM_DETAILS,

		/// <summary>Tiles view.</summary>
		FLVM_TILES,

		/// <summary>Icons view.</summary>
		FLVM_ICONS,

		/// <summary>Windows 7 and later. List view.</summary>
		FLVM_LIST,

		/// <summary>Windows 7 and later. Content view.</summary>
		FLVM_CONTENT,

		/// <summary>The maximum valid enumeration value. Used for validation purposes only.</summary>
		FLVM_LAST,
	}

	/// <summary>Flags for <see cref="IFolderView2.SetText(FVTEXTTYPE, string)"/>.</summary>
	[PInvokeData("shobjidl_core.h", MSDNShortId = "72528831-ec5d-417e-94dd-7345b5fd7de6")]
	public enum FVTEXTTYPE
	{
		/// <summary>Set the text to display when there are no items in the view.</summary>
		FVST_EMPTYTEXT = 0
	}

	/// <summary>The direction in which the items are sorted.</summary>
	[PInvokeData("shobjidl_core.h", MSDNShortId = "3ca4c318-6462-4e22-813c-ef7b3ef03230")]
	public enum SORTDIRECTION
	{
		/// <summary>
		/// The items are sorted in ascending order. Whether the sort is alphabetical, numerical, and so on, is determined by the data
		/// type of the column indicated in <see cref="SORTCOLUMN.propkey"/>.
		/// </summary>
		SORT_DESCENDING = -1,

		/// <summary>
		/// The items are sorted in descending order. Whether the sort is alphabetical, numerical, and so on, is determined by the data
		/// type of the column indicated in <see cref="SORTCOLUMN.propkey"/>.
		/// </summary>
		SORT_ASCENDING = 1
	}

	/// <summary>
	/// Exposes methods that enable inspection and manipulation of columns in the Windows Explorer Details view. Each column is
	/// referenced by a PROPERTYKEY structure, which names a property.
	/// </summary>
	/// <remarks>
	/// <para>
	/// This interface can be accessed even when the Windows Explorer window is in a non-column view mode such as icons, thumbnails, or
	/// tiles. It affects those views, as well as views in which the column header control displays the set of columns to which
	/// <c>IColumnManager</c> provides access.
	/// </para>
	/// <para>
	/// The default implementation of the Windows Explorer view object, created by SHCreateShellFolderViewEx, supports this interface
	/// retrieved through QueryInterface. Code that runs in the Windows Explorer (such as view callbacks, context menus or drop targets)
	/// can access the view object using IServiceProvider::QueryService, querying for <c>SID_SFolderView</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nn-shobjidl_core-icolumnmanager
	[PInvokeData("shobjidl_core.h", MSDNShortId = "d01cacd8-1867-4f44-bbc3-876bd727c0fe")]
	[ComImport, Guid("d8ec27bb-3f3b-4042-b10a-4acfd924d453"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IColumnManager
	{
		/// <summary>Sets the state for a specified column.</summary>
		/// <param name="propkey">
		/// <para>Type: <c>REFPROPERTYKEY</c></para>
		/// <para>A reference to a PROPERTYKEY structure that identifies the column.</para>
		/// </param>
		/// <param name="pcmci">
		/// <para>Type: <c>const CM_COLUMNINFO*</c></para>
		/// <para>A pointer to a CM_COLUMNINFO structure that contains the state to set for this column.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-icolumnmanager-setcolumninfo HRESULT
		// SetColumnInfo( REFPROPERTYKEY propkey, const CM_COLUMNINFO *pcmci );
		void SetColumnInfo(in PROPERTYKEY propkey, in CM_COLUMNINFO pcmci);

		/// <summary>Gets information about each column: width, visibility, display name, and state.</summary>
		/// <param name="propkey">
		/// <para>Type: <c>REFPROPERTYKEY</c></para>
		/// <para>A reference to a PROPERTYKEY structure.</para>
		/// </param>
		/// <param name="pcmci">
		/// <para>Type: <c>CM_COLUMNINFO*</c></para>
		/// <para>
		/// A pointer to a CM_COLUMNINFO structure. On entry, set this structure's <c>dwMask</c> member to specify the information to
		/// retrieve. Also set its <c>cbSize</c> member. When this method returns successfully, the structure contains the requested information.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-icolumnmanager-getcolumninfo HRESULT
		// GetColumnInfo( REFPROPERTYKEY propkey, CM_COLUMNINFO *pcmci );
		void GetColumnInfo(in PROPERTYKEY propkey, ref CM_COLUMNINFO pcmci);

		/// <summary>Gets the column count for either the visible columns or the complete set of columns.</summary>
		/// <param name="dwFlags">
		/// <para>Type: <c>CM_ENUM_FLAGS</c></para>
		/// <para>
		/// A value from the CM_ENUM_FLAGS enumeration that specifies whether to show only visible columns or all columns regardless of visibility.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>UINT*</c></para>
		/// <para>Contains a pointer to the column count.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-icolumnmanager-getcolumncount HRESULT
		// GetColumnCount( CM_ENUM_FLAGS dwFlags, UINT *puCount );
		uint GetColumnCount(CM_ENUM_FLAGS dwFlags);

		/// <summary>
		/// Gets an array of PROPERTYKEY structures that represent the columns that the view supports. Includes either all columns or
		/// only those currently visible.
		/// </summary>
		/// <param name="dwFlags">
		/// <para>Type: <c>CM_ENUM_FLAGS</c></para>
		/// <para>
		/// A value from the CM_ENUM_FLAGS enumeration that specifies whether to show only visible columns or all columns regardless of visibility.
		/// </para>
		/// </param>
		/// <param name="rgkeyOrder">
		/// <para>Type: <c>PROPERTYKEY*</c></para>
		/// <para>On success, contains a pointer to an array of PROPERTYKEY structures that represent the columns.</para>
		/// </param>
		/// <param name="cColumns">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The length of the rgkeyOrder array.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-icolumnmanager-getcolumns HRESULT
		// GetColumns( CM_ENUM_FLAGS dwFlags, PROPERTYKEY *rgkeyOrder, UINT cColumns );
		void GetColumns(CM_ENUM_FLAGS dwFlags, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] PROPERTYKEY[] rgkeyOrder, uint cColumns);

		/// <summary>Sets the collection of columns for the view to display.</summary>
		/// <param name="rgkeyOrder">
		/// <para>Type: <c>const PROPERTYKEY*</c></para>
		/// <para>A pointer to an array of PROPERTYKEY structures that specify the columns to display.</para>
		/// </param>
		/// <param name="cVisible">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the rgkeyOrder array.</para>
		/// </param>
		/// <remarks>
		/// <c>Note</c><c>IColumnManager::SetColumns</c> clears the state of all columns, so IColumnManager::SetColumnInfo must be
		/// called afterward to set the state of individual columns.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-icolumnmanager-setcolumns HRESULT
		// SetColumns( const PROPERTYKEY *rgkeyOrder, UINT cVisible );
		void SetColumns([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] PROPERTYKEY[] rgkeyOrder, uint cVisible);
	}

	/// <summary>
	/// Exposes methods that retrieve information about a folder's display options, select specified items in that folder, and set the
	/// folder's view mode.
	/// </summary>
	[ComImport, Guid("cde725b0-ccc9-4519-917e-325d72fab4ce"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[PInvokeData("Shobjidl.h", MSDNShortId = "bb761848")]
	public interface IFolderView
	{
		/// <summary>Gets an address containing a value representing the folder's current view mode.</summary>
		/// <returns>The folder's current view mode.</returns>
		FOLDERVIEWMODE GetCurrentViewMode();

		/// <summary>Sets the selected folder's view mode.</summary>
		/// <param name="ViewMode">One of the following values from the FOLDERVIEWMODE enumeration.</param>
		void SetCurrentViewMode([In] FOLDERVIEWMODE ViewMode);

		/// <summary>Gets the folder object.</summary>
		/// <param name="riid">Reference to the desired IID to represent the folder.</param>
		/// <returns>
		/// When this method returns, contains the interface pointer requested in <paramref name="riid"/>. This is typically
		/// IShellFolder or a related interface. This can also be an IShellItemArray with a single element.
		/// </returns>
		[return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)]
		object GetFolder(in Guid riid);

		/// <summary>Gets the identifier of a specific item in the folder view, by index.</summary>
		/// <param name="iItemIndex">The index of the item in the view.</param>
		/// <returns>The address of a pointer to a PIDL containing the item's identifier information.</returns>
		PIDL Item([In] int iItemIndex);

		/// <summary>
		/// Gets the number of items in the folder. This can be the number of all items, or a subset such as the number of selected items.
		/// </summary>
		/// <param name="uFlags">Flags from the _SVGIO enumeration that limit the count to certain types of items.</param>
		/// <returns>The number of items (files and folders) displayed in the folder view.</returns>
		int ItemCount([In] SVGIO uFlags);

		/// <summary>Gets the address of an enumeration object based on the collection of items in the folder view.</summary>
		/// <param name="uFlags">_SVGIO values that limit the enumeration to certain types of items.</param>
		/// <param name="riid">Reference to the desired IID to represent the folder.</param>
		/// <returns>
		/// When this method returns, contains the interface pointer requested in <paramref name="riid"/>. This is typically an
		/// IEnumIDList, IDataObject, or IShellItemArray. If an error occurs, this value is NULL.
		/// </returns>
		[return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)]
		object? Items([In] SVGIO uFlags, in Guid riid);

		/// <summary>Gets the index of an item in the folder's view which has been marked by using the SVSI_SELECTIONMARK in IFolderView::SelectItem.</summary>
		/// <returns>The index of the marked item.</returns>
		int GetSelectionMarkedItem();

		/// <summary>Gets the index of the item that currently has focus in the folder's view.</summary>
		/// <returns>The index of the item.</returns>
		int GetFocusedItem();

		/// <summary>Gets the position of an item in the folder's view.</summary>
		/// <param name="pidl">A pointer to an ITEMIDLIST interface.</param>
		/// <returns>The position of the item's upper-left corner.</returns>
		POINT GetItemPosition([In] PIDL pidl);

		/// <summary>
		/// Gets a POINT structure containing the width (x) and height (y) dimensions, including the surrounding white space, of an item.
		/// </summary>
		/// <returns>The current sizing dimensions of the items in the folder's view.</returns>
		POINT GetSpacing();

		/// <summary>
		/// Gets a pointer to a POINT structure containing the default width (x) and height (y) measurements of an item, including the
		/// surrounding white space.
		/// </summary>
		/// <returns>The default sizing dimensions of the items in the folder's view.</returns>
		POINT GetDefaultSpacing();

		/// <summary>Gets the current state of the folder's Auto Arrange mode.</summary>
		/// <returns>Returns S_OK if the folder is in Auto Arrange mode; S_FALSE if it is not.</returns>
		[PreserveSig]
		HRESULT GetAutoArrange();

		/// <summary>Selects an item in the folder's view.</summary>
		/// <param name="iItem">The index of the item to select in the folder's view.</param>
		/// <param name="dwFlags">One of the _SVSIF constants that specify the type of selection to apply.</param>
		void SelectItem([In] int iItem, [In] SVSIF dwFlags);

		/// <summary>Allows the selection and positioning of items visible in the folder's view.</summary>
		/// <param name="cidl">The number of items to select.</param>
		/// <param name="apidl">A pointer to an array of size <paramref name="cidl"/> that contains the PIDLs of the items.</param>
		/// <param name="apt">
		/// A pointer to an array of <paramref name="cidl"/> structures containing the locations each corresponding element in <paramref
		/// name="apidl"/> should be positioned.
		/// </param>
		/// <param name="dwFlags">One of the _SVSIF constants that specifies the type of selection to apply.</param>
		void SelectAndPositionItems([In] uint cidl, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] IntPtr[] apidl, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] POINT[] apt, [In] SVSIF dwFlags);
	}

	/// <summary>
	/// Exposes methods that retrieve information about a folder's display options, select specified items in that folder, and set the
	/// folder's view mode.
	/// </summary>
	/// <seealso cref="IFolderView"/>
	[ComImport, Guid("1af3a467-214f-4298-908e-06b03e0b39f9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[PInvokeData("Shobjidl.h", MSDNShortId = "bb761848")]
	public interface IFolderView2 : IFolderView
	{
		/// <summary>Gets an address containing a value representing the folder's current view mode.</summary>
		/// <returns>The folder's current view mode.</returns>
		new FOLDERVIEWMODE GetCurrentViewMode();

		/// <summary>Sets the selected folder's view mode.</summary>
		/// <param name="ViewMode">One of the following values from the FOLDERVIEWMODE enumeration.</param>
		new void SetCurrentViewMode([In] FOLDERVIEWMODE ViewMode);

		/// <summary>Gets the folder object.</summary>
		/// <param name="riid">Reference to the desired IID to represent the folder.</param>
		/// <returns>
		/// When this method returns, contains the interface pointer requested in <paramref name="riid"/>. This is typically
		/// IShellFolder or a related interface. This can also be an IShellItemArray with a single element.
		/// </returns>
		[return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)]
		new object GetFolder(in Guid riid);

		/// <summary>Gets the identifier of a specific item in the folder view, by index.</summary>
		/// <param name="iItemIndex">The index of the item in the view.</param>
		/// <returns>The address of a pointer to a PIDL containing the item's identifier information.</returns>
		new PIDL Item([In] int iItemIndex);

		/// <summary>
		/// Gets the number of items in the folder. This can be the number of all items, or a subset such as the number of selected items.
		/// </summary>
		/// <param name="uFlags">Flags from the _SVGIO enumeration that limit the count to certain types of items.</param>
		/// <returns>The number of items (files and folders) displayed in the folder view.</returns>
		new int ItemCount([In] SVGIO uFlags);

		/// <summary>Gets the address of an enumeration object based on the collection of items in the folder view.</summary>
		/// <param name="uFlags">_SVGIO values that limit the enumeration to certain types of items.</param>
		/// <param name="riid">Reference to the desired IID to represent the folder.</param>
		/// <returns>
		/// When this method returns, contains the interface pointer requested in <paramref name="riid"/>. This is typically an
		/// IEnumIDList, IDataObject, or IShellItemArray. If an error occurs, this value is NULL.
		/// </returns>
		[return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)]
		new object? Items([In] SVGIO uFlags, in Guid riid);

		/// <summary>Gets the index of an item in the folder's view which has been marked by using the SVSI_SELECTIONMARK in IFolderView::SelectItem.</summary>
		/// <returns>The index of the marked item.</returns>
		new int GetSelectionMarkedItem();

		/// <summary>Gets the index of the item that currently has focus in the folder's view.</summary>
		/// <returns>The index of the item.</returns>
		new int GetFocusedItem();

		/// <summary>Gets the position of an item in the folder's view.</summary>
		/// <param name="pidl">A pointer to an ITEMIDLIST interface.</param>
		/// <returns>The position of the item's upper-left corner.</returns>
		new POINT GetItemPosition([In] PIDL pidl);

		/// <summary>
		/// Gets a POINT structure containing the width (x) and height (y) dimensions, including the surrounding white space, of an item.
		/// </summary>
		/// <returns>The current sizing dimensions of the items in the folder's view.</returns>
		new POINT GetSpacing();

		/// <summary>
		/// Gets a pointer to a POINT structure containing the default width (x) and height (y) measurements of an item, including the
		/// surrounding white space.
		/// </summary>
		/// <returns>The default sizing dimensions of the items in the folder's view.</returns>
		new POINT GetDefaultSpacing();

		/// <summary>Gets the current state of the folder's Auto Arrange mode.</summary>
		/// <returns>Returns S_OK if the folder is in Auto Arrange mode; S_FALSE if it is not.</returns>
		[PreserveSig]
		new HRESULT GetAutoArrange();

		/// <summary>Selects an item in the folder's view.</summary>
		/// <param name="iItem">The index of the item to select in the folder's view.</param>
		/// <param name="dwFlags">One of the _SVSIF constants that specify the type of selection to apply.</param>
		new void SelectItem([In] int iItem, [In] SVSIF dwFlags);

		/// <summary>Allows the selection and positioning of items visible in the folder's view.</summary>
		/// <param name="cidl">The number of items to select.</param>
		/// <param name="apidl">A pointer to an array of size <paramref name="cidl"/> that contains the PIDLs of the items.</param>
		/// <param name="apt">
		/// A pointer to an array of <paramref name="cidl"/> structures containing the locations each corresponding element in <paramref
		/// name="apidl"/> should be positioned.
		/// </param>
		/// <param name="dwFlags">One of the _SVSIF constants that specifies the type of selection to apply.</param>
		new void SelectAndPositionItems([In] uint cidl, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] IntPtr[] apidl, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] POINT[] apt, [In] SVSIF dwFlags);

		/// <summary>Groups the view by the given property key and direction.</summary>
		/// <param name="key">
		/// <para>Type: <c>REFPROPERTYKEY</c></para>
		/// <para>A PROPERTYKEY by which the view should be grouped.</para>
		/// </param>
		/// <param name="fAscending">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>A value of type <c>BOOL</c> to indicate sort order of the groups.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-setgroupby HRESULT
		// SetGroupBy( REFPROPERTYKEY key, BOOL fAscending );
		void SetGroupBy(in PROPERTYKEY key, [MarshalAs(UnmanagedType.Bool)] bool fAscending);

		/// <summary>Retrieves the property and sort order used for grouping items in the folder display.</summary>
		/// <param name="pkey">
		/// <para>Type: <c>PROPERTYKEY*</c></para>
		/// <para>A pointer to the PROPERTYKEY by which the view is grouped.</para>
		/// </param>
		/// <param name="pfAscending">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>A pointer to a value of type <c>BOOL</c> that indicates sort order of the groups.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-getgroupby HRESULT
		// GetGroupBy( PROPERTYKEY *pkey, BOOL *pfAscending );
		void GetGroupBy(out PROPERTYKEY pkey, [MarshalAs(UnmanagedType.Bool)] out bool pfAscending);

		/// <summary>
		/// <para>
		/// [This method is still implemented, but should be considered deprecated as of Windows 7. It might not be implemented in
		/// future versions of Windows. It cannot be used with items in search results or library views, so consider using the item's
		/// existing properties or, if applicable, emitting properties from your namespace or property handler. See Developing Property
		/// Handlers for Windows Search for more information.]
		/// </para>
		/// <para>Caches a property for an item in the view's property cache.</para>
		/// </summary>
		/// <param name="pidl">
		/// <para>Type: <c>PCUITEMID_CHILD</c></para>
		/// <para>A PIDL that identifies the item.</para>
		/// </param>
		/// <param name="propkey">
		/// <para>Type: <c>REFPROPERTYKEY</c></para>
		/// <para>The PROPERTYKEY which is to be stored.</para>
		/// </param>
		/// <param name="propvar">
		/// <para>Type: <c>const PROPVARIANT*</c></para>
		/// <para>A pointer to a PROPVARIANT structure in which the PROPERTYKEY is stored.</para>
		/// </param>
		/// <remarks>The property is displayed in the view, but not written to the underlying item.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-setviewproperty
		// DEPRECATED_HRESULT SetViewProperty( PCUITEMID_CHILD pidl, REFPROPERTYKEY propkey, REFPROPVARIANT propvar );
		[Obsolete]
		void SetViewProperty([In] PIDL pidl, in PROPERTYKEY propkey, [In] PROPVARIANT propvar);

		/// <summary>
		/// <para>
		/// [This method is still implemented, but should be considered deprecated as of Windows 7. It might not be implemented in
		/// future versions of Windows. It cannot be used with items in search results or library views, so consider using the item's
		/// existing properties or, if applicable, emitting properties from your namespace or property handler. See Developing Property
		/// Handlers for Windows Search for more information.]
		/// </para>
		/// <para>Gets a property value for a given property key from the view's cache.</para>
		/// </summary>
		/// <param name="pidl">
		/// <para>Type: <c>PCUITEMID_CHILD</c></para>
		/// <para>A pointer to an item identifier list (PIDL).</para>
		/// </param>
		/// <param name="propkey">
		/// <para>Type: <c>REFPROPERTYKEY</c></para>
		/// <para>The PROPERTYKEY to be retrieved.</para>
		/// </param>
		/// <param name="ppropvar">
		/// <para>Type: <c>PROPVARIANT*</c></para>
		/// <para>A pointer to a PROPVARIANT structure in which the PROPERTYKEY is stored.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-getviewproperty
		// DEPRECATED_HRESULT GetViewProperty( PCUITEMID_CHILD pidl, REFPROPERTYKEY propkey, PROPVARIANT *ppropvar );
		[Obsolete]
		void GetViewProperty([In] PIDL pidl, in PROPERTYKEY propkey, [In, Out] PROPVARIANT ppropvar);

		/// <summary>
		/// <para>
		/// [This method is still implemented, but should be considered deprecated as of Windows 7. It might not be implemented in
		/// future versions of Windows. It cannot be used with items in search results or library views, so consider using the item's
		/// existing properties or, if applicable, emitting properties from your namespace or property handler. See Developing Property
		/// Handlers for Windows Search for more information.]
		/// </para>
		/// <para>Set the list of tile properties for an item.</para>
		/// </summary>
		/// <param name="pidl">
		/// <para>Type: <c>PCUITEMID_CHILD</c></para>
		/// <para>A pointer to an item identifier list (PIDL).</para>
		/// </param>
		/// <param name="pszPropList">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a Unicode string containing a list of properties.</para>
		/// </param>
		/// <remarks>
		/// The pszPropList parameter must be of the form "prop:&lt;canonical-property-name&gt;;&lt;canonical-property-name&gt;" where
		/// "&lt;canonical-property-name&gt;" is replaced by an actual canonical property name. The parameter can contain one or more
		/// properties delimited by semicolons.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-settileviewproperties
		// DEPRECATED_HRESULT SetTileViewProperties( PCUITEMID_CHILD pidl, LPCWSTR pszPropList );
		[Obsolete]
		void SetTileViewProperties([In] PIDL pidl, [In, MarshalAs(UnmanagedType.LPWStr)] string pszPropList);

		/// <summary>
		/// <para>
		/// [This method is still implemented, but should be considered deprecated as of Windows 7. It might not be implemented in
		/// future versions of Windows. It cannot be used with items in search results or library views, so consider using the item's
		/// existing properties or, if applicable, emitting properties from your namespace or property handler. See Developing Property
		/// Handlers for Windows Search for more information.]
		/// </para>
		/// <para>Sets the list of extended tile properties for an item.</para>
		/// </summary>
		/// <param name="pidl">
		/// <para>Type: <c>PCUITEMID_CHILD</c></para>
		/// <para>A pointer to an item identifier list (PIDL).</para>
		/// </param>
		/// <param name="pszPropList">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a Unicode string containing a list of properties.</para>
		/// </param>
		/// <remarks>
		/// The pszPropList parameter must be of the form "prop:&lt;canonical-property-name&gt;;&lt;canonical-property-name&gt;" where
		/// "&lt;canonical-property-name&gt;" is an actual canonical property name. It can contain one or more properties delimited by semicolons.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-setextendedtileviewproperties
		// DEPRECATED_HRESULT SetExtendedTileViewProperties( PCUITEMID_CHILD pidl, LPCWSTR pszPropList );
		[Obsolete]
		void SetExtendedTileViewProperties([In] PIDL pidl, [In, MarshalAs(UnmanagedType.LPWStr)] string pszPropList);

		/// <summary>Sets the default text to be used when there are no items in the view.</summary>
		/// <param name="iType">
		/// <para>Type: <c>FVTEXTTYPE</c></para>
		/// <para>This value should be set to the following flag.</para>
		/// <para>FVST_EMPTYTEXT</para>
		/// <para>Set the text to display when there are no items in the view.</para>
		/// </param>
		/// <param name="pwszText">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a Unicode string that contains the text to be used.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-settext HRESULT SetText(
		// FVTEXTTYPE iType, LPCWSTR pwszText );
		void SetText([In] FVTEXTTYPE iType, [In, MarshalAs(UnmanagedType.LPWStr)] string? pwszText);

		/// <summary>Sets and applies specified folder flags.</summary>
		/// <param name="dwMask">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The value of type <c>DWORD</c> that specifies the bitmask indicating which items in the structure are desired or valid.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The value of type <c>DWORD</c> that contains one or more FOLDERFLAGS.</para>
		/// </param>
		/// <remarks>
		/// <c>For Windows 7 or later:</c> This method must be used in combination with the FVO_CUSTOMPOSITION flag from the
		/// FOLDERVIEWOPTIONS enumeration.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-setcurrentfolderflags
		// HRESULT SetCurrentFolderFlags( DWORD dwMask, DWORD dwFlags );
		void SetCurrentFolderFlags([In] FOLDERFLAGS dwMask, [In] FOLDERFLAGS dwFlags);

		/// <summary>Gets the currently applied folder flags.</summary>
		/// <returns>
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>A pointer to a <c>DWORD</c> with any FOLDERFLAGS that have been applied to the folder.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-getcurrentfolderflags
		// HRESULT GetCurrentFolderFlags( DWORD *pdwFlags );
		FOLDERFLAGS GetCurrentFolderFlags();

		/// <summary>Gets the count of sort columns currently applied to the view.</summary>
		/// <returns>
		/// <para>Type: <c>int*</c></para>
		/// <para>A pointer to an <c>int</c>.</para>
		/// </returns>
		/// <remarks>Returns E_INVALIDARG if the column count provided does not equal the count of sort columns in the view.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-getsortcolumncount HRESULT
		// GetSortColumnCount( int *pcColumns );
		int GetSortColumnCount();

		/// <summary>Sets and sorts the view by the given sort columns.</summary>
		/// <param name="rgSortColumns">
		/// <para>Type: <c>const SORTCOLUMN*</c></para>
		/// <para>A pointer to a SORTCOLUMN structure. The size of this structure is determined by cColumns.</para>
		/// </param>
		/// <param name="cColumns">
		/// <para>Type: <c>int</c></para>
		/// <para>The count of columns to sort by.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-setsortcolumns HRESULT
		// SetSortColumns( const SORTCOLUMN *rgSortColumns, int cColumns );
		void SetSortColumns([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] SORTCOLUMN[] rgSortColumns, [In] int cColumns);

		/// <summary>Gets the sort columns currently applied to the view.</summary>
		/// <param name="rgSortColumns">
		/// <para>Type: <c>const SORTCOLUMN*</c></para>
		/// <para>A pointer to a SORTCOLUMN structure. The size of this structure is determined by cColumns.</para>
		/// </param>
		/// <param name="cColumns">
		/// <para>Type: <c>int</c></para>
		/// <para>The count of columns to sort by.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-getsortcolumns HRESULT
		// GetSortColumns( SORTCOLUMN *rgSortColumns, int cColumns );
		void GetSortColumns([In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] SORTCOLUMN[] rgSortColumns, [In] int cColumns);

		/// <summary>Retrieves an object that represents a specified item.</summary>
		/// <param name="iItem">
		/// <para>Type: <c>int</c></para>
		/// <para>The zero-based index of the item to retrieve.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>Reference to the desired IID to represent the item, such as IID_IShellItem.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>void**</c></para>
		/// <para>When this method returns, contains the interface pointer requested in <paramref name="riid"/>. This is typically IShellItem.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-getitem HRESULT GetItem( int
		// iItem, REFIID riid, void **ppv );
		[return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)]
		object GetItem([In] int iItem, in Guid riid);

		/// <summary>Gets the next visible item in relation to a given index in the view.</summary>
		/// <param name="iStart">
		/// <para>Type: <c>int</c></para>
		/// <para>The zero-based position at which to start searching for a visible item.</para>
		/// </param>
		/// <param name="fPrevious">
		/// <para>Type: <c>BOOL</c></para>
		/// <para><c>TRUE</c> to find the first visible item before iStart. <c>FALSE</c> to find the first visible item after iStart.</para>
		/// </param>
		/// <param name="piItem">
		/// <para>Type: <c>int*</c></para>
		/// <para>When this method returns, contains a pointer to a value that receives the index of the visible item in the view.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Item retrieved.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>Item not found. Note that this is a success code.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-getvisibleitem HRESULT
		// GetVisibleItem( int iStart, BOOL fPrevious, int *piItem );
		[PreserveSig]
		HRESULT GetVisibleItem([In] int iStart, [In, MarshalAs(UnmanagedType.Bool)] bool fPrevious, out int piItem);

		/// <summary>Locates the currently selected item at or after a given index.</summary>
		/// <param name="iStart">The index position from which to start searching for the currently selected item.</param>
		/// <param name="piItem">A pointer to a value that receives the index of the item in the view.</param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if a selected item was found, or an error value otherwise, including the following:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>
		/// Item not found. Note that this is a success code. The operation was successful in searching the view, it simply did not find
		/// a currently selected item after the given index (iStart). It is possible that no item was selected, or that the selected
		/// item had an index less than iStart.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		[PreserveSig]
		HRESULT GetSelectedItem([In] int iStart, out int piItem);

		/// <summary>
		/// <para>Gets the current selection as an IShellItemArray.</para>
		/// </summary>
		/// <param name="fNoneImpliesFolder">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If <c>TRUE</c>, this method returns an IShellItemArray containing the parent folder when there is no current selection.</para>
		/// </param>
		/// <param name="ppsia">
		/// <para>Type: <c>IShellItemArray**</c></para>
		/// <para>The address of a pointer to an IShellItemArray.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the following values, or an error otherwise.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The operation completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The IShellItemArray returned has zero items.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-getselection HRESULT
		// GetSelection( BOOL fNoneImpliesFolder, IShellItemArray **ppsia );
		[PreserveSig]
		HRESULT GetSelection([In, MarshalAs(UnmanagedType.Bool)] bool fNoneImpliesFolder, out IShellItemArray ppsia);

		/// <summary>Gets the selection state including check state.</summary>
		/// <param name="pidl">
		/// <para>Type: <c>PCUITEMID_CHILD</c></para>
		/// <para>A PIDL of the item.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>
		/// Zero or one of the following _SVSIF constants that specify the current type of selection: <c>SVSI_FOCUSED</c>,
		/// <c>SVSI_SELECT</c>, <c>SVSI_CHECK</c>, or <c>SVSI_CHECK2</c>. Other <c>_SVSIF</c> constants are not returned by this API.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-getselectionstate HRESULT
		// GetSelectionState( PCUITEMID_CHILD pidl, DWORD *pdwFlags );
		SVSIF GetSelectionState([In] PIDL pidl);

		/// <summary>Invokes the given verb on the current selection.</summary>
		/// <param name="pszVerb">
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>A pointer to a Unicode string containing a verb.</para>
		/// </param>
		/// <remarks>If pszVerb is <c>NULL</c>, then the default verb is invoked on the selection.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-invokeverbonselection
		// HRESULT InvokeVerbOnSelection( LPCSTR pszVerb );
		void InvokeVerbOnSelection([In, MarshalAs(UnmanagedType.LPStr)] string? pszVerb);

		/// <summary>Sets and applies the view mode and image size.</summary>
		/// <param name="uViewMode">
		/// <para>Type: <c>FOLDERVIEWMODE</c></para>
		/// <para>The FOLDERVIEWMODE to be applied.</para>
		/// </param>
		/// <param name="iImageSize">
		/// <para>Type: <c>int</c></para>
		/// <para>The size of the image in pixels.</para>
		/// </param>
		/// <remarks>If iImageSize is -1 then the current default icon size for the view mode is used.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-setviewmodeandiconsize
		// HRESULT SetViewModeAndIconSize( FOLDERVIEWMODE uViewMode, int iImageSize );
		void SetViewModeAndIconSize([In] FOLDERVIEWMODE uViewMode, [In] int iImageSize = -1);

		/// <summary>Gets the current view mode and icon size applied to the view.</summary>
		/// <param name="puViewMode">
		/// <para>Type: <c>FOLDERVIEWMODE*</c></para>
		/// <para>A pointer to the current FOLDERVIEWMODE.</para>
		/// </param>
		/// <param name="piImageSize">
		/// <para>Type: <c>int*</c></para>
		/// <para>A pointer to the size of the icon in pixels.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-getviewmodeandiconsize
		// HRESULT GetViewModeAndIconSize( FOLDERVIEWMODE *puViewMode, int *piImageSize );
		void GetViewModeAndIconSize(out FOLDERVIEWMODE puViewMode, out int piImageSize);

		/// <summary>Turns on group subsetting and sets the number of visible rows of items in each group.</summary>
		/// <param name="cVisibleRows">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of rows to be visible.</para>
		/// </param>
		/// <remarks>If cVisibleRows is zero, subsetting is turned off.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-setgroupsubsetcount HRESULT
		// SetGroupSubsetCount( UINT cVisibleRows );
		void SetGroupSubsetCount([In] uint cVisibleRows);

		/// <summary>Gets the count of visible rows displayed for a group's subset.</summary>
		/// <returns>
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The number of rows currently visible.</para>
		/// </returns>
		/// <remarks>If group subsetting is disabled the number of rows is zero.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-getgroupsubsetcount HRESULT
		// GetGroupSubsetCount( UINT *pcVisibleRows );
		uint GetGroupSubsetCount();

		/// <summary>Sets redraw on and off.</summary>
		/// <param name="fRedrawOn">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>a <c>BOOL</c> value.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-setredraw HRESULT SetRedraw(
		// BOOL fRedrawOn );
		void SetRedraw([In, MarshalAs(UnmanagedType.Bool)] bool fRedrawOn);

		/// <summary>
		/// Checks to see if this view sourced the current drag-and-drop or cut-and-paste operation (used by drop target objects).
		/// </summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-ismoveinsamefolder HRESULT
		// IsMoveInSameFolder( );
		[PreserveSig]
		HRESULT IsMoveInSameFolder();

		/// <summary>Starts a rename operation on the current selection.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-dorename HRESULT DoRename( );
		void DoRename();
	}

	/// <summary>Exposes a method that hosts an IFolderView object in a window.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nn-shobjidl-ifolderviewhost
	[PInvokeData("shobjidl.h", MSDNShortId = "NN:shobjidl.IFolderViewHost")]
	[ComImport, Guid("1ea58f02-d55a-411d-b09e-9e65ac21605b"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(FolderViewHost))]
	public interface IFolderViewHost
	{
		/// <summary>Initializes the object that hosts an IFolderView object.</summary>
		/// <param name="hwndParent">
		/// <para>Type: <c>HWND</c></para>
		/// <para>The handle of the window that contains the IFolderViewHost object.</para>
		/// </param>
		/// <param name="pdo">
		/// <para>Type: <c>IDataObject*</c></para>
		/// <para>The address of a pointer to a data object.</para>
		/// </param>
		/// <param name="prc">
		/// <para>Type: <c>RECT*</c></para>
		/// <para>The address of a pointer to a <c>RECT</c> structure that specifies the dimensions of the folder view.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-ifolderviewhost-initialize HRESULT Initialize( HWND
		// hwndParent, IDataObject *pdo, RECT *prc );
		void Initialize([In] HWND hwndParent, [In] IDataObject pdo, in RECT prc);
	}

	/// <summary>Exposes methods to obtain folder view settings.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ifolderviewsettings
	[ComImport, Guid("ae8c987d-8797-4ed3-be72-2a47dd938db0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IFolderViewSettings
	{
		/// <summary>Gets an ordered list of columns that corresponds to the column enumerated.</summary>
		/// <param name="riid">A reference to the interface identifier (IID) of the IPropertyDescriptionList.</param>
		/// <returns>
		/// <para>Type: <c>IPropertyDescriptionList**</c></para>
		/// <para>The address of an IPropertyDescriptionList interface pointer.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifolderviewsettings-getcolumnpropertylist
		// HRESULT GetColumnPropertyList( REFIID riid, void **ppv );
		IPropertyDescriptionList GetColumnPropertyList(in Guid riid);

		/// <summary>Gets a grouping property.</summary>
		/// <param name="pkey">
		/// <para>Type: <c>PROPERTYKEY*</c></para>
		/// <para>A pointer to a PROPERTYKEY structure indicating the key by which content is grouped.</para>
		/// </param>
		/// <param name="pfGroupAscending">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>A pointer to a value indicating whether grouping order is ascending.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifolderviewsettings-getgroupbyproperty
		// HRESULT GetGroupByProperty( PROPERTYKEY *pkey, BOOL *pfGroupAscending );
		void GetGroupByProperty(out PROPERTYKEY pkey, [MarshalAs(UnmanagedType.Bool)] out bool pfGroupAscending);

		/// <summary>Gets a folder's logical view mode.</summary>
		/// <returns>
		/// <para>Type: <c>FOLDERLOGICALVIEWMODE*</c></para>
		/// <para>A pointer to a FOLDERLOGICALVIEWMODE value.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifolderviewsettings-getviewmode HRESULT
		// GetViewMode( FOLDERLOGICALVIEWMODE *plvm );
		FOLDERLOGICALVIEWMODE GetViewMode();

		/// <summary>Gets the folder icon size.</summary>
		/// <returns>
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer to the icon size.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifolderviewsettings-geticonsize HRESULT
		// GetIconSize( UINT *puIconSize );
		uint GetIconSize();

		/// <summary>Gets folder view options flags.</summary>
		/// <param name="pfolderMask">
		/// <para>Type: <c>FOLDERFLAGS*</c></para>
		/// <para>A pointer to a mask for folder view options.</para>
		/// </param>
		/// <param name="pfolderFlags">
		/// <para>Type: <c>FOLDERFLAGS*</c></para>
		/// <para>A pointer to a flag for folder view options.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifolderviewsettings-getfolderflags HRESULT
		// GetFolderFlags( FOLDERFLAGS *pfolderMask, FOLDERFLAGS *pfolderFlags );
		void GetFolderFlags(out FOLDERFLAGS pfolderMask, out FOLDERFLAGS pfolderFlags);

		/// <summary>Gets sort column information.</summary>
		/// <param name="rgSortColumns">
		/// <para>Type: <c>SORTCOLUMN*</c></para>
		/// <para>A pointer to an array of SORTCOLUMN structures.</para>
		/// </param>
		/// <param name="cColumnsIn">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The source column count.</para>
		/// </param>
		/// <param name="pcColumnsOut">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer to the rgSortColumns array length.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifolderviewsettings-getsortcolumns HRESULT
		// GetSortColumns( SORTCOLUMN *rgSortColumns, UINT cColumnsIn, UINT *pcColumnsOut );
		void GetSortColumns([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] SORTCOLUMN[] rgSortColumns, uint cColumnsIn, out uint pcColumnsOut);

		/// <summary>Gets group count for visible rows.</summary>
		/// <returns>
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer to group count.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifolderviewsettings-getgroupsubsetcount
		// HRESULT GetGroupSubsetCount( UINT *pcVisibleRows );
		uint GetGroupSubsetCount();
	}

	/// <summary>
	/// <para>Exposes methods that hold items from a data object.</para>
	/// <para>
	/// An <c>IResultsFolder</c> is a folder that can hold items from all over the namespace and represent them to the user in a single folder.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl/nn-shobjidl-iresultsfolder
	[PInvokeData("shobjidl.h", MSDNShortId = "db44052b-bd26-412f-9f2a-66a0c53b65ac")]
	[ComImport, Guid("96E5AE6D-6AE1-4b1c-900C-C6480EAA8828"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IResultsFolder
	{
		/// <summary>Adds an item to a results folder.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to an IShellItem.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl/nf-shobjidl-iresultsfolder-additem HRESULT AddItem( IShellItem
		// *psi );
		void AddItem([In] IShellItem psi);

		/// <summary>Inserts a pointer to an item identifier list (PIDL) into a results folder.</summary>
		/// <param name="pidl">
		/// <para>Type: <c>PCIDLIST_ABSOLUTE</c></para>
		/// <para>A pointer to the IDList of the given object relative to the Desktop.</para>
		/// </param>
		/// <param name="ppidlAdded">
		/// <para>Type: <c>PITEMID_CHILD*</c></para>
		/// <para>A PIDL consisting of 0 or 1 SHITEMID structures, relative to a parent folder. This parameter maybe <c>NULL</c>.</para>
		/// </param>
		/// <remarks>
		/// The PIDL received represents the item that was just added and is a unique representation of this item generated by this
		/// results folder. It is only valid when used in reference to this results folder and should not be combined with a PIDL to
		/// another folder, including the folder this item originally came from.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl/nf-shobjidl-iresultsfolder-addidlist HRESULT AddIDList(
		// PCIDLIST_ABSOLUTE pidl, PITEMID_CHILD *ppidlAdded );
		void AddIDList([In] PIDL pidl, out PIDL ppidlAdded);

		/// <summary>Removes an item from a results folder.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to an IShellItem.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl/nf-shobjidl-iresultsfolder-removeitem HRESULT RemoveItem(
		// IShellItem *psi );
		void RemoveItem([In] IShellItem psi);

		/// <summary>Removes a pointer to an item identifier list (PIDL) from a results folder.</summary>
		/// <param name="pidl">
		/// <para>Type: <c>PCIDLIST_ABSOLUTE</c></para>
		/// <para>A PIDL relative to the Desktop.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl/nf-shobjidl-iresultsfolder-removeidlist HRESULT RemoveIDList(
		// PCIDLIST_ABSOLUTE pidl );
		void RemoveIDList([In] PIDL pidl);

		/// <summary>Removes all items from a results folder.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl/nf-shobjidl-iresultsfolder-removeall HRESULT RemoveAll( );
		void RemoveAll();
	}

	/// <summary>Extension method to simplify using the <see cref="IFolderView.GetFolder"/> method.</summary>
	/// <typeparam name="T">Type of the interface to get.</typeparam>
	/// <param name="fv">An <see cref="IFolderView"/> instance.</param>
	/// <returns>Receives the interface pointer requested in <typeparamref name="T"/>.</returns>
	public static T GetFolder<T>(this IFolderView fv) where T : class => (T)fv.GetFolder(typeof(T).GUID);

	/// <summary>Extension method to simplify using the <see cref="IFolderView2.GetItem"/> method.</summary>
	/// <typeparam name="T">Type of the interface to get.</typeparam>
	/// <param name="fv">An <see cref="IFolderView2"/> instance.</param>
	/// <param name="iItem">
	/// <para>Type: <c>int</c></para>
	/// <para>The zero-based index of the item to retrieve.</para>
	/// </param>
	/// <returns>Receives the interface pointer requested in <typeparamref name="T"/>.</returns>
	public static T? GetItem<T>(this IFolderView2 fv, int iItem) where T : class { try { return (T)fv.GetItem(iItem, typeof(T).GUID); } catch { return null; } }

	/// <summary>Extension method to simplify using the <see cref="IFolderView.Items"/> method.</summary>
	/// <typeparam name="T">Type of the interface to get.</typeparam>
	/// <param name="fv">An <see cref="IFolderView"/> instance.</param>
	/// <param name="uFlags">_SVGIO values that limit the enumeration to certain types of items.</param>
	/// <returns>Receives the interface pointer requested in <typeparamref name="T"/>.</returns>
	public static T? Items<T>(this IFolderView fv, SVGIO uFlags) where T : class => (T?)fv.Items(uFlags, typeof(T).GUID);

	/// <summary>Extension method to simplify using the <see cref="IFolderView2.GetItem"/> method.</summary>
	/// <typeparam name="T">Type of the interface to get.</typeparam>
	/// <param name="fv">An <see cref="IFolderView2"/> instance.</param>
	/// <param name="iItem">
	/// <para>Type: <c>int</c></para>
	/// <para>The zero-based index of the item to retrieve.</para>
	/// </param>
	/// <param name="item">The interface pointer requested in <typeparamref name="T"/>.</param>
	/// <returns><see langword="true"/> if the item is found; <see langword="false"/> otherwise.</returns>
	public static bool TryGetItem<T>(this IFolderView2 fv, int iItem, out T? item) where T : class { try { item = (T)fv.GetItem(iItem, typeof(T).GUID); return true; } catch { item = null; return false; } }

	/// <summary>
	/// <para>Defines column information. Used by members of the IColumnManager interface.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/ns-shobjidl_core-cm_columninfo typedef struct CM_COLUMNINFO {
	// DWORD cbSize; DWORD dwMask; DWORD dwState; UINT uWidth; UINT uDefaultWidth; UINT uIdealWidth; WCHAR wszName[80]; } CM_COLUMNINFO;
	[PInvokeData("shobjidl_core.h", MSDNShortId = "b4437aa7-9682-4819-a353-936179e84005")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct CM_COLUMNINFO
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The size of the structure, in bytes.</para>
		/// </summary>
		public uint cbSize;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>One or more values from the CM_MASK enumeration that specify which members of this structure are valid.</para>
		/// </summary>
		public CM_MASK dwMask;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>One or more values from the CM_STATE enumeration that specify the state of the column.</para>
		/// </summary>
		public CM_STATE dwState;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>One of the members of the CM_SET_WIDTH_VALUE enumeration that specifies the column width.</para>
		/// </summary>
		public CM_SET_WIDTH_VALUE uWidth;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The default width of the column.</para>
		/// </summary>
		public uint uDefaultWidth;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The ideal width of the column.</para>
		/// </summary>
		public uint uIdealWidth;

		/// <summary>
		/// <para>Type: <c>WCHAR[MAX_COLUMN_NAME_LEN]</c></para>
		/// <para>A buffer of size MAX_COLUMN_NAME_LEN that contains the name of the column as a null-terminated Unicode string.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_COLUMN_NAME_LEN)]
		public string? wszName;

		/// <summary>Initializes a new instance of the <see cref="CM_COLUMNINFO"/> struct for retrieval of specified items.</summary>
		/// <param name="mask">The mask of items to retrieve.</param>
		public CM_COLUMNINFO(CM_MASK mask) : this()
		{
			cbSize = (uint)Marshal.SizeOf(this);
			dwMask = mask;
		}
	}

	/// <summary>Stores information about how to sort a column that is displayed in the folder view.</summary>
	/// <remarks>
	/// Each column displayed in the folder view (for example, "details" view mode), is associated with a property that has a
	/// PROPERTYKEY ID. When you want to sort the view by a particular property, you specify the property key for that property.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/ns-shobjidl_core-sortcolumn typedef struct SORTCOLUMN {
	// PROPERTYKEY propkey; SORTDIRECTION direction; } SORTCOLUMN;
	[PInvokeData("shobjidl_core.h", MSDNShortId = "3ca4c318-6462-4e22-813c-ef7b3ef03230")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SORTCOLUMN
	{
		/// <summary>
		/// <para>Type: <c>PROPERTYKEY</c></para>
		/// <para>
		/// The ID of the column by which the user will sort. A PROPERTYKEY structure. For example, for the "Name" column, the property
		/// key is PKEY_ItemNameDisplay.
		/// </para>
		/// </summary>
		public PROPERTYKEY propkey;

		/// <summary>
		/// <para>Type: <c>SORTDIRECTION</c></para>
		/// <para>The direction in which the items are sorted. One of the following values.</para>
		/// <para>SORT_DESCENDING</para>
		/// <para>
		/// The items are sorted in ascending order. Whether the sort is alphabetical, numerical, and so on, is determined by the data
		/// type of the column indicated in <c>propkey</c>.
		/// </para>
		/// <para>SORT_ASCENDING</para>
		/// <para>
		/// The items are sorted in descending order. Whether the sort is alphabetical, numerical, and so on, is determined by the data
		/// type of the column indicated in <c>propkey</c>.
		/// </para>
		/// </summary>
		public SORTDIRECTION direction;
	}

	/// <summary>CoClass for IFolderViewHost</summary>
	[PInvokeData("shobjidl.h")]
	[ComImport, Guid("20b1cb23-6968-4eb9-b7d4-a66d00d07cee"), ClassInterface(ClassInterfaceType.None)]
	public class FolderViewHost { }
}