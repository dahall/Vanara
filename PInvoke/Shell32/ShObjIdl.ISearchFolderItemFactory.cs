using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.Ole32;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
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

		/// <summary>
		/// Exposes methods that create and modify search folders. The Set methods are called first to set up the parameters of the search.
		/// When not called, default values will be used instead. ISearchFolderItemFactory::GetIDList and
		/// ISearchFolderItemFactory::GetShellItem return the two forms of the search specified by these parameters.
		/// </summary>
		/// <remarks>To implement this interface use class ID <c>CLSID_SearchFolderItemFactory</c>.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nn-shobjidl_core-isearchfolderitemfactory
		[PInvokeData("shobjidl_core.h", MSDNShortId = "a684b373-6de4-4b4a-bbae-85e1c5a7e04a")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("a0ffbc28-5482-4366-be27-3e81e78e06c2"), CoClass(typeof(SearchFolderItemFactory))]
		public interface ISearchFolderItemFactory
		{
			/// <summary>Sets the search folder display name, as specified.</summary>
			/// <param name="pszDisplayName">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>A pointer to a folder display name as a Unicode string.</para>
			/// </param>
			/// <remarks>Calling this method is required. A display name must be set.</remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-isearchfolderitemfactory-setdisplayname
			// HRESULT SetDisplayName( LPCWSTR pszDisplayName );
			void SetDisplayName([MarshalAs(UnmanagedType.LPWStr)] string pszDisplayName);

			/// <summary>Sets a search folder type ID, as specified.</summary>
			/// <param name="ftid">
			/// <para>Type: <c>FOLDERTYPEID</c></para>
			/// <para>The FOLDERTYPEID, which is a <c>GUID</c> used to identify folder types within the system. The default is <c>FOLDERTYPID_Library</c></para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-isearchfolderitemfactory-setfoldertypeid
			// HRESULT SetFolderTypeID( FOLDERTYPEID ftid );
			void SetFolderTypeID(FOLDERTYPEID ftid);

			/// <summary>
			/// Sets folder logical view mode. The default settings are based on the which is set by the
			/// ISearchFolderItemFactory::SetFolderTypeID method.
			/// </summary>
			/// <param name="flvm">
			/// <para>Type: <c>FOLDERLOGICALVIEWMODE</c></para>
			/// <para>The FOLDERLOGICALVIEWMODE value.</para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-isearchfolderitemfactory-setfolderlogicalviewmode
			// HRESULT SetFolderLogicalViewMode( FOLDERLOGICALVIEWMODE flvm );
			void SetFolderLogicalViewMode(FOLDERLOGICALVIEWMODE flvm);

			/// <summary>
			/// Sets the search folder icon size, as specified. The default settings are based on the which is set by the
			/// ISearchFolderItemFactory::SetFolderTypeID method.
			/// </summary>
			/// <param name="iIconSize">
			/// <para>Type: <c>int</c></para>
			/// <para>The icon size.</para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-isearchfolderitemfactory-seticonsize
			// HRESULT SetIconSize( int iIconSize );
			void SetIconSize(int iIconSize);

			/// <summary>
			/// Creates a new column list whose columns are all visible, given an array of PROPERTYKEY structures. The default is based on <c>FolderTypeID</c>.
			/// </summary>
			/// <param name="cVisibleColumns">
			/// <para>Type: <c>UINT</c></para>
			/// <para>The number of array elements.</para>
			/// </param>
			/// <param name="rgKey">
			/// <para>Type: <c>const PROPERTYKEY*</c></para>
			/// <para>A pointer to an array of PROPERTYKEY structures.</para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-isearchfolderitemfactory-setvisiblecolumns
			// HRESULT SetVisibleColumns( UINT cVisibleColumns, const PROPERTYKEY *rgKey );
			void SetVisibleColumns(uint cVisibleColumns, [In] PROPERTYKEY[] rgKey);

			/// <summary>Creates a list of sort column directions, as specified.</summary>
			/// <param name="cSortColumns">
			/// <para>Type: <c>UINT</c></para>
			/// <para>The number of sort columns.</para>
			/// </param>
			/// <param name="rgSortColumns">
			/// <para>Type: <c>SORTCOLUMN*</c></para>
			/// <para>A pointer to an array of SORTCOLUMN structures containing sort direction. The default is <c>PKEY_ItemNameDisplay</c>.</para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-isearchfolderitemfactory-setsortcolumns
			// HRESULT SetSortColumns( UINT cSortColumns, SORTCOLUMN *rgSortColumns );
			void SetSortColumns(uint cSortColumns, [In] SORTCOLUMN[] rgSortColumns);

			/// <summary>Sets a group column, as specified. If no group column is specified, no grouping occurs.</summary>
			/// <param name="keyGroup">
			/// <para>Type: <c>REFPROPERTYKEY</c></para>
			/// <para>A reference to a group column PROPERTYKEY.</para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-isearchfolderitemfactory-setgroupcolumn
			// HRESULT SetGroupColumn( REFPROPERTYKEY keyGroup );
			void SetGroupColumn(in PROPERTYKEY keyGroup);

			/// <summary>
			/// Creates a list of stack keys, as specified. If this method is not called, by default the folder will not be stacked.
			/// </summary>
			/// <param name="cStackKeys">
			/// <para>Type: <c>UINT</c></para>
			/// <para>The number of stacks keys.</para>
			/// </param>
			/// <param name="rgStackKeys">
			/// <para>Type: <c>PROPERTYKEY*</c></para>
			/// <para>A pointer to an array of PROPERTYKEY structures containing stack key information.</para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-isearchfolderitemfactory-setstacks HRESULT
			// SetStacks( UINT cStackKeys, PROPERTYKEY *rgStackKeys );
			void SetStacks(uint cStackKeys, [In] PROPERTYKEY[] rgStackKeys);

			/// <summary>Sets search scope, as specified.</summary>
			/// <param name="psiaScope">
			/// <para>Type: <c>IShellItemArray*</c></para>
			/// <para>
			/// A pointer to the list of locations to search. The search will include this location and all its subcontainers. The default is <c>FOLDERID_Profile</c>
			/// </para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-isearchfolderitemfactory-setscope HRESULT
			// SetScope( IShellItemArray *psiaScope );
			void SetScope([In] IShellItemArray psiaScope);

			/// <summary>
			/// Sets the ICondition of the search. When this method is not called, the resulting search will have no filters applied.
			/// </summary>
			/// <param name="pCondition">
			/// <para>Type: <c>ICondition*</c></para>
			/// <para>A pointer to an ICondition interface.</para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-isearchfolderitemfactory-setcondition
			// HRESULT SetCondition( ICondition *pCondition );
			void SetCondition([In] ICondition pCondition);

			/// <summary>Gets the search folder as a IShellItem.</summary>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>A reference to the desired IID.</para>
			/// </param>
			/// <param name="ppv">
			/// <para>Type: <c>void**</c></para>
			/// <para>The IShellItem interface pointer specified in riid.</para>
			/// </param>
			/// <remarks>When the retrieved IShellItem is enumerated, it returns the search results.</remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-isearchfolderitemfactory-getshellitem
			// HRESULT GetShellItem( REFIID riid, void **ppv );
			[return: MarshalAs(UnmanagedType.IUnknown)]
			object GetShellItem(in Guid riid);

			/// <summary>Gets the search folder as an ITEMIDLIST.</summary>
			/// <returns>
			/// <para>Type: <c>PIDLIST_ABSOLUTE*</c></para>
			/// <para>When this method returns successfully, contains a PIDL.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-isearchfolderitemfactory-getidlist HRESULT
			// GetIDList( PIDLIST_ABSOLUTE *ppidl );
			PIDL GetIDList();
		}

		/// <summary>Extension method to simplify using the <see cref="ISearchFolderItemFactory.GetShellItem"/> method.</summary>
		/// <typeparam name="T">Type of the interface to get.</typeparam>
		/// <param name="sfif">An <see cref="ISearchFolderItemFactory"/> instance.</param>
		/// <returns>Receives the interface pointer requested in <typeparamref name="T"/>.</returns>
		public static T GetShellItem<T>(this ISearchFolderItemFactory sfif) where T : class => (T)sfif.GetShellItem(typeof(T).GUID);

		/// <summary>CLSID_SearchFolderItemFactory</summary>
		[PInvokeData("shobjidl_core.h", MSDNShortId = "a684b373-6de4-4b4a-bbae-85e1c5a7e04a")]
		[ComImport, Guid("14010e02-bbbd-41f0-88e3-eda371216584"), ClassInterface(ClassInterfaceType.None)]
		public class SearchFolderItemFactory { }
	}
}