using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using static Vanara.PInvoke.Ole32;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>Flags for <see cref="IFolderView2.SetText(FVTEXTTYPE, string)"/>.</summary>
		[PInvokeData("shobjidl_core.h", MSDNShortId = "72528831-ec5d-417e-94dd-7345b5fd7de6")]
		public enum FVTEXTTYPE
		{
			/// <summary>Set the text to display when there are no items in the view.</summary>
			FVST_EMPTYTEXT = 0
		}

		/// <summary>
		/// Exposes methods that retrieve information about a folder's display options, select specified items in that folder, and set the folder's view mode.
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
			void SetCurrentViewMode(FOLDERVIEWMODE ViewMode);

			/// <summary>Gets the folder object.</summary>
			/// <param name="riid">Reference to the desired IID to represent the folder.</param>
			/// <param name="ppv">When this method returns, contains the interface pointer requested in <paramref name="riid"/>. This is typically IShellFolder or a related interface. This can also be an IShellItemArray with a single element.</param>
			void GetFolder(in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppv);

			/// <summary>Gets the identifier of a specific item in the folder view, by index.</summary>
			/// <param name="iItemIndex">The index of the item in the view.</param>
			/// <param name="ppidl">The address of a pointer to a PIDL containing the item's identifier information.</param>
			void Item(int iItemIndex, out PIDL ppidl);

			/// <summary>Gets the number of items in the folder. This can be the number of all items, or a subset such as the number of selected items.</summary>
			/// <param name="uFlags">Flags from the _SVGIO enumeration that limit the count to certain types of items.</param>
			/// <returns>The number of items (files and folders) displayed in the folder view.</returns>
			int ItemCount(SVGIO uFlags);

			/// <summary>Gets the address of an enumeration object based on the collection of items in the folder view.</summary>
			/// <param name="uFlags">_SVGIO values that limit the enumeration to certain types of items.</param>
			/// <param name="riid">Reference to the desired IID to represent the folder.</param>
			/// <param name="ppv">When this method returns, contains the interface pointer requested in <paramref name="riid"/>. This is typically an IEnumIDList, IDataObject, or IShellItemArray. If an error occurs, this value is NULL.</param>
			void Items(SVGIO uFlags, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppv);

			/// <summary>Gets the index of an item in the folder's view which has been marked by using the SVSI_SELECTIONMARK in IFolderView::SelectItem.</summary>
			/// <returns>The index of the marked item.</returns>
			int GetSelectionMarkedItem();

			/// <summary>Gets the index of the item that currently has focus in the folder's view.</summary>
			/// <returns>The index of the item.</returns>
			int GetFocusedItem();

			/// <summary>Gets the position of an item in the folder's view.</summary>
			/// <param name="pidl">A pointer to an ITEMIDLIST interface.</param>
			/// <returns>The position of the item's upper-left corner.</returns>
			Point GetItemPosition([In] PIDL pidl);

			/// <summary>Gets a POINT structure containing the width (x) and height (y) dimensions, including the surrounding white space, of an item.</summary>
			/// <returns>The current sizing dimensions of the items in the folder's view.</returns>
			Point GetSpacing();

			/// <summary>Gets a pointer to a POINT structure containing the default width (x) and height (y) measurements of an item, including the surrounding white space.</summary>
			/// <returns>The default sizing dimensions of the items in the folder's view.</returns>
			Point GetDefaultSpacing();

			/// <summary>Gets the current state of the folder's Auto Arrange mode.</summary>
			/// <returns>Returns S_OK if the folder is in Auto Arrange mode; S_FALSE if it is not.</returns>
			[PreserveSig]
			HRESULT GetAutoArrange();

			/// <summary>Selects an item in the folder's view.</summary>
			/// <param name="iItem">The index of the item to select in the folder's view.</param>
			/// <param name="dwFlags">One of the _SVSIF constants that specify the type of selection to apply.</param>
			void SelectItem(int iItem, SVSIF dwFlags);

			/// <summary>Allows the selection and positioning of items visible in the folder's view.</summary>
			/// <param name="cidl">The number of items to select.</param>
			/// <param name="apidl">A pointer to an array of size <paramref name="cidl"/> that contains the PIDLs of the items.</param>
			/// <param name="apt">A pointer to an array of <paramref name="cidl"/> structures containing the locations each corresponding element in <paramref name="apidl"/> should be positioned.</param>
			/// <param name="dwFlags">One of the _SVSIF constants that specifies the type of selection to apply.</param>
			void SelectAndPositionItems(uint cidl, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] PIDL[] apidl, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] Point[] apt, SVSIF dwFlags);
		}

		/// <summary>
		/// Exposes methods that retrieve information about a folder's display options, select specified items in that folder, and set the folder's view mode.
		/// </summary>
		/// <seealso cref="Vanara.PInvoke.Shell32.IFolderView" />
		[ComImport, Guid("1af3a467-214f-4298-908e-06b03e0b39f9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb761848")]
		public interface IFolderView2 : IFolderView
		{
			/// <summary>Gets an address containing a value representing the folder's current view mode.</summary>
			/// <returns>The folder's current view mode.</returns>
			new FOLDERVIEWMODE GetCurrentViewMode();

			/// <summary>Sets the selected folder's view mode.</summary>
			/// <param name="ViewMode">One of the following values from the FOLDERVIEWMODE enumeration.</param>
			new void SetCurrentViewMode(FOLDERVIEWMODE ViewMode);

			/// <summary>Gets the folder object.</summary>
			/// <param name="riid">Reference to the desired IID to represent the folder.</param>
			/// <param name="ppv">When this method returns, contains the interface pointer requested in <paramref name="riid"/>. This is typically IShellFolder or a related interface. This can also be an IShellItemArray with a single element.</param>
			new void GetFolder(in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppv);

			/// <summary>Gets the identifier of a specific item in the folder view, by index.</summary>
			/// <param name="iItemIndex">The index of the item in the view.</param>
			/// <param name="ppidl">The address of a pointer to a PIDL containing the item's identifier information.</param>
			new void Item(int iItemIndex, out PIDL ppidl);

			/// <summary>Gets the number of items in the folder. This can be the number of all items, or a subset such as the number of selected items.</summary>
			/// <param name="uFlags">Flags from the _SVGIO enumeration that limit the count to certain types of items.</param>
			/// <returns>The number of items (files and folders) displayed in the folder view.</returns>
			new int ItemCount(SVGIO uFlags);

			/// <summary>Gets the address of an enumeration object based on the collection of items in the folder view.</summary>
			/// <param name="uFlags">_SVGIO values that limit the enumeration to certain types of items.</param>
			/// <param name="riid">Reference to the desired IID to represent the folder.</param>
			/// <param name="ppv">When this method returns, contains the interface pointer requested in <paramref name="riid"/>. This is typically an IEnumIDList, IDataObject, or IShellItemArray. If an error occurs, this value is NULL.</param>
			new void Items(SVGIO uFlags, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppv);

			/// <summary>Gets the index of an item in the folder's view which has been marked by using the SVSI_SELECTIONMARK in IFolderView::SelectItem.</summary>
			/// <returns>The index of the marked item.</returns>
			new int GetSelectionMarkedItem();

			/// <summary>Gets the index of the item that currently has focus in the folder's view.</summary>
			/// <returns>The index of the item.</returns>
			new int GetFocusedItem();

			/// <summary>Gets the position of an item in the folder's view.</summary>
			/// <param name="pidl">A pointer to an ITEMIDLIST interface.</param>
			/// <returns>The position of the item's upper-left corner.</returns>
			new Point GetItemPosition([In] PIDL pidl);

			/// <summary>Gets a POINT structure containing the width (x) and height (y) dimensions, including the surrounding white space, of an item.</summary>
			/// <returns>The current sizing dimensions of the items in the folder's view.</returns>
			new Point GetSpacing();

			/// <summary>Gets a pointer to a POINT structure containing the default width (x) and height (y) measurements of an item, including the surrounding white space.</summary>
			/// <returns>The default sizing dimensions of the items in the folder's view.</returns>
			new Point GetDefaultSpacing();

			/// <summary>Gets the current state of the folder's Auto Arrange mode.</summary>
			/// <returns>Returns S_OK if the folder is in Auto Arrange mode; S_FALSE if it is not.</returns>
			[PreserveSig]
			new HRESULT GetAutoArrange();

			/// <summary>Selects an item in the folder's view.</summary>
			/// <param name="iItem">The index of the item to select in the folder's view.</param>
			/// <param name="dwFlags">One of the _SVSIF constants that specify the type of selection to apply.</param>
			new void SelectItem(int iItem, SVSIF dwFlags);

			/// <summary>Allows the selection and positioning of items visible in the folder's view.</summary>
			/// <param name="cidl">The number of items to select.</param>
			/// <param name="apidl">A pointer to an array of size <paramref name="cidl"/> that contains the PIDLs of the items.</param>
			/// <param name="apt">A pointer to an array of <paramref name="cidl"/> structures containing the locations each corresponding element in <paramref name="apidl"/> should be positioned.</param>
			/// <param name="dwFlags">One of the _SVSIF constants that specifies the type of selection to apply.</param>
			new void SelectAndPositionItems(uint cidl, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] PIDL[] apidl, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] Point[] apt, SVSIF dwFlags);

			/// <summary>Groups the view by the given property key and direction.</summary>
			/// <param name="key"><para>Type: <c>REFPROPERTYKEY</c></para>
			/// <para>A PROPERTYKEY by which the view should be grouped.</para></param>
			/// <param name="fAscending"><para>Type: <c>BOOL</c></para>
			/// <para>A value of type <c>BOOL</c> to indicate sort order of the groups.</para></param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-setgroupby
			// HRESULT SetGroupBy( REFPROPERTYKEY key, BOOL fAscending );
			void SetGroupBy(in PROPERTYKEY key, [MarshalAs(UnmanagedType.Bool)] bool fAscending);

			/// <summary>Retrieves the property and sort order used for grouping items in the folder display.</summary>
			/// <param name="pkey"><para>Type: <c>PROPERTYKEY*</c></para>
			/// <para>A pointer to the PROPERTYKEY by which the view is grouped.</para></param>
			/// <param name="pfAscending"><para>Type: <c>BOOL*</c></para>
			/// <para>A pointer to a value of type <c>BOOL</c> that indicates sort order of the groups.</para></param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-getgroupby
			// HRESULT GetGroupBy( PROPERTYKEY *pkey, BOOL *pfAscending );
			void GetGroupBy(out PROPERTYKEY pkey, [MarshalAs(UnmanagedType.Bool)] out bool pfAscending);

			/// <summary>Retrieves the property and sort order used for grouping items in the folder display.</summary>
			/// <param name="pkey"><para>Type: <c>PROPERTYKEY*</c></para>
			/// <para>A pointer to the PROPERTYKEY by which the view is grouped.</para></param>
			/// <param name="pfAscending"><para>Type: <c>BOOL*</c></para>
			/// <para>A pointer to a value of type <c>BOOL</c> that indicates sort order of the groups.</para></param>
			void RemoteGetGroupBy(out PROPERTYKEY pkey, [MarshalAs(UnmanagedType.Bool)] out bool pfAscending);

			/// <summary>
			///   <para>[This method is still implemented, but should be considered deprecated as of Windows 7. It might not be implemented in future versions of Windows. It cannot be used with items in search results or library views, so consider using the item's existing properties or, if applicable, emitting properties from your namespace or property handler. See Developing Property Handlers for Windows Search for more information.]</para><para>Caches a property for an item in the view's property cache.</para>
			/// </summary>
			/// <param name="pidl"><para>Type: <c>PCUITEMID_CHILD</c></para><para>A PIDL that identifies the item.</para></param>
			/// <param name="propkey"><para>Type: <c>REFPROPERTYKEY</c></para><para>The PROPERTYKEY which is to be stored.</para></param>
			/// <param name="propvar"><para>Type: <c>const PROPVARIANT*</c></para><para>A pointer to a PROPVARIANT structure in which the PROPERTYKEY is stored.</para></param>
			/// <remarks>The property is displayed in the view, but not written to the underlying item.</remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-setviewproperty
			// DEPRECATED_HRESULT SetViewProperty( PCUITEMID_CHILD pidl, REFPROPERTYKEY propkey, REFPROPVARIANT propvar );
			[Obsolete]
			void SetViewProperty([In] PIDL pidl, in PROPERTYKEY propkey, [In] PROPVARIANT propvar);

			/// <summary>
			///   <para>[This method is still implemented, but should be considered deprecated as of Windows 7. It might not be implemented in future versions of Windows. It cannot be used with items in search results or library views, so consider using the item's existing properties or, if applicable, emitting properties from your namespace or property handler. See Developing Property Handlers for Windows Search for more information.]</para><para>Gets a property value for a given property key from the view's cache.</para>
			/// </summary>
			/// <param name="pidl"><para>Type: <c>PCUITEMID_CHILD</c></para><para>A pointer to an item identifier list (PIDL).</para></param>
			/// <param name="propkey"><para>Type: <c>REFPROPERTYKEY</c></para><para>The PROPERTYKEY to be retrieved.</para></param>
			/// <param name="ppropvar"><para>Type: <c>PROPVARIANT*</c></para><para>A pointer to a PROPVARIANT structure in which the PROPERTYKEY is stored.</para></param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-getviewproperty
			// DEPRECATED_HRESULT GetViewProperty( PCUITEMID_CHILD pidl, REFPROPERTYKEY propkey, PROPVARIANT *ppropvar );
			[Obsolete]
			void GetViewProperty([In] PIDL pidl, in PROPERTYKEY propkey, [In, Out] PROPVARIANT ppropvar);

			/// <summary>
			///   <para>[This method is still implemented, but should be considered deprecated as of Windows 7. It might not be implemented in future versions of Windows. It cannot be used with items in search results or library views, so consider using the item's existing properties or, if applicable, emitting properties from your namespace or property handler. See Developing Property Handlers for Windows Search for more information.]</para><para>Set the list of tile properties for an item.</para>
			/// </summary>
			/// <param name="pidl"><para>Type: <c>PCUITEMID_CHILD</c></para><para>A pointer to an item identifier list (PIDL).</para></param>
			/// <param name="pszPropList"><para>Type: <c>LPCWSTR</c></para><para>A pointer to a Unicode string containing a list of properties.</para></param>
			/// <remarks>
			/// The pszPropList parameter must be of the form "prop:&lt;canonical-property-name&gt;;&lt;canonical-property-name&gt;" where "&lt;canonical-property-name&gt;" is replaced by an actual canonical property name. The parameter can contain one or more properties delimited by semicolons.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-settileviewproperties
			// DEPRECATED_HRESULT SetTileViewProperties( PCUITEMID_CHILD pidl, LPCWSTR pszPropList );
			[Obsolete]
			void SetTileViewProperties([In] PIDL pidl, [MarshalAs(UnmanagedType.LPWStr)] string pszPropList);

			/// <summary>
			///   <para>[This method is still implemented, but should be considered deprecated as of Windows 7. It might not be implemented in future versions of Windows. It cannot be used with items in search results or library views, so consider using the item's existing properties or, if applicable, emitting properties from your namespace or property handler. See Developing Property Handlers for Windows Search for more information.]</para><para>Sets the list of extended tile properties for an item.</para>
			/// </summary>
			/// <param name="pidl"><para>Type: <c>PCUITEMID_CHILD</c></para><para>A pointer to an item identifier list (PIDL).</para></param>
			/// <param name="pszPropList"><para>Type: <c>LPCWSTR</c></para><para>A pointer to a Unicode string containing a list of properties.</para></param>
			/// <remarks>
			/// The pszPropList parameter must be of the form "prop:&lt;canonical-property-name&gt;;&lt;canonical-property-name&gt;" where "&lt;canonical-property-name&gt;" is an actual canonical property name. It can contain one or more properties delimited by semicolons.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-setextendedtileviewproperties
			// DEPRECATED_HRESULT SetExtendedTileViewProperties( PCUITEMID_CHILD pidl, LPCWSTR pszPropList );
			[Obsolete]
			void SetExtendedTileViewProperties([In] PIDL pidl, [MarshalAs(UnmanagedType.LPWStr)] string pszPropList);

			/// <summary>Sets the default text to be used when there are no items in the view.</summary>
			/// <param name="iType"><para>Type: <c>FVTEXTTYPE</c></para><para>This value should be set to the following flag.</para><para>FVST_EMPTYTEXT</para><para>Set the text to display when there are no items in the view.</para></param>
			/// <param name="pwszText"><para>Type: <c>LPCWSTR</c></para><para>A pointer to a Unicode string that contains the text to be used.</para></param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-settext
			// HRESULT SetText( FVTEXTTYPE iType, LPCWSTR pwszText );
			void SetText(FVTEXTTYPE iType, [MarshalAs(UnmanagedType.LPWStr)] string pwszText);

			/// <summary>Sets and applies specified folder flags.</summary>
			/// <param name="dwMask"><para>Type: <c>DWORD</c></para><para>The value of type <c>DWORD</c> that specifies the bitmask indicating which items in the structure are desired or valid.</para></param>
			/// <param name="dwFlags"><para>Type: <c>DWORD</c></para><para>The value of type <c>DWORD</c> that contains one or more FOLDERFLAGS.</para></param>
			/// <remarks>
			///   <c>For Windows 7 or later:</c> This method must be used in combination with the FVO_CUSTOMPOSITION flag from the FOLDERVIEWOPTIONS enumeration.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-setcurrentfolderflags
			// HRESULT SetCurrentFolderFlags( DWORD dwMask, DWORD dwFlags );
			void SetCurrentFolderFlags(FOLDERFLAGS dwMask, FOLDERFLAGS dwFlags);

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
			/// <remarks>
			/// Returns E_INVALIDARG if the column count provided does not equal the count of sort columns in the view.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-getsortcolumncount
			// HRESULT GetSortColumnCount( int *pcColumns );
			int GetSortColumnCount();

			/// <summary>Sets and sorts the view by the given sort columns.</summary>
			/// <param name="rgSortColumns"><para>Type: <c>const SORTCOLUMN*</c></para><para>A pointer to a SORTCOLUMN structure. The size of this structure is determined by cColumns.</para></param>
			/// <param name="cColumns"><para>Type: <c>int</c></para><para>The count of columns to sort by.</para></param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-setsortcolumns
			// HRESULT SetSortColumns( const SORTCOLUMN *rgSortColumns, int cColumns );
			void SetSortColumns([In] SORTCOLUMN[] rgSortColumns, int cColumns);

			/// <summary>Gets the sort columns currently applied to the view.</summary>
			/// <param name="rgSortColumns"><para>Type: <c>const SORTCOLUMN*</c></para><para>A pointer to a SORTCOLUMN structure. The size of this structure is determined by cColumns.</para></param>
			/// <param name="cColumns"><para>Type: <c>int</c></para><para>The count of columns to sort by.</para></param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-getsortcolumns
			// HRESULT GetSortColumns( SORTCOLUMN *rgSortColumns, int cColumns );
			void GetSortColumns([In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] SORTCOLUMN[] rgSortColumns, int cColumns);

			/// <summary>Retrieves an object that represents a specified item.</summary>
			/// <param name="iItem"><para>Type: <c>int</c></para><para>The zero-based index of the item to retrieve.</para></param>
			/// <param name="riid"><para>Type: <c>REFIID</c></para><para>Reference to the desired IID to represent the item, such as IID_IShellItem.</para></param>
			/// <param name="ppv"><para>Type: <c>void**</c></para><para>When this method returns, contains the interface pointer requested in <paramref name="riid"/>. This is typically IShellItem.</para></param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-getitem
			// HRESULT GetItem( int iItem, REFIID riid, void **ppv );
			void GetItem(int iItem, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppv);

			/// <summary>Gets the next visible item in relation to a given index in the view.</summary>
			/// <param name="iStart"><para>Type: <c>int</c></para>
			/// <para>The zero-based position at which to start searching for a visible item.</para></param>
			/// <param name="fPrevious"><para>Type: <c>BOOL</c></para>
			/// <para>
			///   <c>TRUE</c> to find the first visible item before iStart. <c>FALSE</c> to find the first visible item after iStart.</para></param>
			/// <param name="piItem"><para>Type: <c>int*</c></para>
			/// <para>When this method returns, contains a pointer to a value that receives the index of the visible item in the view.</para></param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Return code</term>
			///     <term>Description</term>
			///   </listheader>
			///   <item>
			///     <term>S_OK</term>
			///     <term>Item retrieved.</term>
			///   </item>
			///   <item>
			///     <term>S_FALSE</term>
			///     <term>Item not found. Note that this is a success code.</term>
			///   </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-getvisibleitem
			// HRESULT GetVisibleItem( int iStart, BOOL fPrevious, int *piItem );
			[PreserveSig]
			HRESULT GetVisibleItem(int iStart, [MarshalAs(UnmanagedType.Bool)] bool fPrevious, out int piItem);

			/// <summary>Locates the currently selected item at or after a given index.</summary>
			/// <param name="iStart">The index position from which to start searching for the currently selected item.</param>
			/// <param name="piItem">A pointer to a value that receives the index of the item in the view.</param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>Returns S_OK if a selected item was found, or an error value otherwise, including the following:</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Return code</term>
			///     <term>Description</term>
			///   </listheader>
			///   <item>
			///     <term>S_FALSE</term>
			///     <term>Item not found. Note that this is a success code. The operation was successful in searching the view, it simply did not find a currently selected item after the given index (iStart). It is possible that no item was selected, or that the selected item had an index less than iStart.</term>
			///   </item>
			/// </list>
			/// </returns>
			[PreserveSig]
			HRESULT GetSelectedItem(int iStart, out int piItem);

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
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-getselection
			// HRESULT GetSelection( BOOL fNoneImpliesFolder, IShellItemArray **ppsia );
			[PreserveSig]
			HRESULT GetSelection([MarshalAs(UnmanagedType.Bool)] bool fNoneImpliesFolder, out IShellItemArray ppsia);

			/// <summary>Gets the selection state including check state.</summary>
			/// <param name="pidl"><para>Type: <c>PCUITEMID_CHILD</c></para>
			/// <para>A PIDL of the item.</para></param>
			/// <returns>
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>
			/// Zero or one of the following _SVSIF constants that specify the current type of selection: <c>SVSI_FOCUSED</c>,
			/// <c>SVSI_SELECT</c>, <c>SVSI_CHECK</c>, or <c>SVSI_CHECK2</c>. Other <c>_SVSIF</c> constants are not returned by this API.
			/// </para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-getselectionstate
			// HRESULT GetSelectionState( PCUITEMID_CHILD pidl, DWORD *pdwFlags );
			SVSIF GetSelectionState([In] PIDL pidl);

			/// <summary>Invokes the given verb on the current selection.</summary>
			/// <param name="pszVerb"><para>Type: <c>LPCSTR</c></para><para>A pointer to a Unicode string containing a verb.</para></param>
			/// <remarks>If pszVerb is <c>NULL</c>, then the default verb is invoked on the selection.</remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-invokeverbonselection
			// HRESULT InvokeVerbOnSelection( LPCSTR pszVerb );
			void InvokeVerbOnSelection([MarshalAs(UnmanagedType.LPWStr)] string pszVerb);

			/// <summary>Sets and applies the view mode and image size.</summary>
			/// <param name="uViewMode"><para>Type: <c>FOLDERVIEWMODE</c></para><para>The FOLDERVIEWMODE to be applied.</para></param>
			/// <param name="iImageSize"><para>Type: <c>int</c></para><para>The size of the image in pixels.</para></param>
			/// <remarks>If iImageSize is -1 then the current default icon size for the view mode is used.</remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-setviewmodeandiconsize
			// HRESULT SetViewModeAndIconSize( FOLDERVIEWMODE uViewMode, int iImageSize );
			void SetViewModeAndIconSize(FOLDERVIEWMODE uViewMode, int iImageSize);

			/// <summary>Gets the current view mode and icon size applied to the view.</summary>
			/// <param name="puViewMode"><para>Type: <c>FOLDERVIEWMODE*</c></para><para>A pointer to the current FOLDERVIEWMODE.</para></param>
			/// <param name="piImageSize"><para>Type: <c>int*</c></para><para>A pointer to the size of the icon in pixels.</para></param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-getviewmodeandiconsize
			// HRESULT GetViewModeAndIconSize( FOLDERVIEWMODE *puViewMode, int *piImageSize );
			void GetViewModeAndIconSize(out FOLDERVIEWMODE puViewMode, out int piImageSize);

			/// <summary>Turns on group subsetting and sets the number of visible rows of items in each group.</summary>
			/// <param name="cVisibleRows"><para>Type: <c>UINT</c></para><para>The number of rows to be visible.</para></param>
			/// <remarks>If cVisibleRows is zero, subsetting is turned off.</remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-setgroupsubsetcount
			// HRESULT SetGroupSubsetCount( UINT cVisibleRows );
			void SetGroupSubsetCount(uint cVisibleRows);

			/// <summary>Gets the count of visible rows displayed for a group's subset.</summary>
			/// <returns>
			/// <para>Type: <c>UINT*</c></para>
			/// <para>The number of rows currently visible.</para>
			/// </returns>
			/// <remarks>If group subsetting is disabled the number of rows is zero.</remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-getgroupsubsetcount
			// HRESULT GetGroupSubsetCount( UINT *pcVisibleRows );
			uint GetGroupSubsetCount();

			/// <summary>Sets redraw on and off.</summary>
			/// <param name="fRedrawOn"><para>Type: <c>BOOL</c></para><para>a <c>BOOL</c> value.</para></param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-setredraw
			// HRESULT SetRedraw( BOOL fRedrawOn );
			void SetRedraw([MarshalAs(UnmanagedType.Bool)] bool fRedrawOn);

			/// <summary>
			/// Checks to see if this view sourced the current drag-and-drop or cut-and-paste operation (used by drop target objects).
			/// </summary>
			/// <returns>
			///   <para>Type: <c>HRESULT</c></para><para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-ismoveinsamefolder
			// HRESULT IsMoveInSameFolder( );
			[PreserveSig]
			HRESULT IsMoveInSameFolder();

			/// <summary>Starts a rename operation on the current selection.</summary>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifolderview2-dorename
			// HRESULT DoRename( );
			void DoRename();
		}

		/// <summary>Stores information about how to sort a column that is displayed in the folder view.</summary>
		/// <remarks>
		/// Each column displayed in the folder view (for example, "details" view mode), is associated with a property that has a PROPERTYKEY ID. When you want to sort the view by a particular property, you specify the property key for that property.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/ns-shobjidl_core-sortcolumn
		// typedef struct SORTCOLUMN { PROPERTYKEY propkey; SORTDIRECTION direction; } SORTCOLUMN;
		[PInvokeData("shobjidl_core.h", MSDNShortId = "3ca4c318-6462-4e22-813c-ef7b3ef03230")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SORTCOLUMN
		{
			/// <summary><para>Type: <c>PROPERTYKEY</c></para><para>The ID of the column by which the user will sort. A PROPERTYKEY structure. For example, for the &quot;Name&quot; column, the property key is PKEY_ItemNameDisplay.</para></summary>
			public PROPERTYKEY propkey;
			/// <summary><para>Type: <c>SORTDIRECTION</c></para><para>The direction in which the items are sorted. One of the following values.</para><para>SORT_DESCENDING</para><para>The items are sorted in ascending order. Whether the sort is alphabetical, numerical, and so on, is determined by the data type of the column indicated in <c>propkey</c>.</para><para>SORT_ASCENDING</para><para>The items are sorted in descending order. Whether the sort is alphabetical, numerical, and so on, is determined by the data type of the column indicated in <c>propkey</c>.</para></summary>
			public SORTDIRECTION direction;
		}

		/// <summary>
		/// The direction in which the items are sorted.
		/// </summary>
		[PInvokeData("shobjidl_core.h", MSDNShortId = "3ca4c318-6462-4e22-813c-ef7b3ef03230")]
		public enum SORTDIRECTION
		{
			/// <summary>The items are sorted in ascending order. Whether the sort is alphabetical, numerical, and so on, is determined by the data type of the column indicated in <see cref="SORTCOLUMN.propkey"/>.</summary>
			SORT_DESCENDING = -1,
			/// <summary>The items are sorted in descending order. Whether the sort is alphabetical, numerical, and so on, is determined by the data type of the column indicated in <see cref="SORTCOLUMN.propkey"/>.</summary>
			SORT_ASCENDING = 1
		}
	}
}