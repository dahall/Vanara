using static Vanara.PInvoke.ShlwApi;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>Defines shortcut menu restrictions used by IDefaultFolderMenuInitialize::GetMenuRestrictions and IDefaultFolderMenuInitialize::SetMenuRestrictions.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/ne-shobjidl_core-default_folder_menu_restrictions typedef enum
	// DEFAULT_FOLDER_MENU_RESTRICTIONS { DFMR_DEFAULT, DFMR_NO_STATIC_VERBS, DFMR_STATIC_VERBS_ONLY, DFMR_NO_RESOURCE_VERBS,
	// DFMR_OPTIN_HANDLERS_ONLY, DFMR_RESOURCE_AND_FOLDER_VERBS_ONLY, DFMR_USE_SPECIFIED_HANDLERS, DFMR_USE_SPECIFIED_VERBS,
	// DFMR_NO_ASYNC_VERBS, DFMR_NO_NATIVECPU_VERBS } ;
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NE:shobjidl_core.DEFAULT_FOLDER_MENU_RESTRICTIONS")]
	[Flags]
	public enum DEFAULT_FOLDER_MENU_RESTRICTIONS
	{
		/// <summary>No restrictions.</summary>
		DFMR_DEFAULT = 0x0000,

		/// <summary>Don't use the handler for static verbs.</summary>
		DFMR_NO_STATIC_VERBS = 0x0008,

		/// <summary>Static verbs only. No dynamic IContextMenu verbs allowed.</summary>
		DFMR_STATIC_VERBS_ONLY = 0x0010,

		/// <summary>Don't add verbs for cut, copy, paste, link, delete, rename, or properties.</summary>
		DFMR_NO_RESOURCE_VERBS = 0x0020,

		/// <summary>Only load opt-in handlers that have the registry value "ContextMenuOptIn" under HKCR\CLSID&lt;handler clsid&gt;</summary>
		DFMR_OPTIN_HANDLERS_ONLY = 0x0040,

		/// <summary>
		/// Only load resource verbs (cut, copy, paste, link, delete, rename, and properties) and folder verbs added by IContextMenuCB.
		/// </summary>
		DFMR_RESOURCE_AND_FOLDER_VERBS_ONLY = 0x0080,

		/// <summary>Use handlers with CLSID values that were added through IDefaultFolderMenuInitialize::SetHandlerClsid</summary>
		DFMR_USE_SPECIFIED_HANDLERS = 0x0100,

		/// <summary>Only load handlers that support the specified verbs.</summary>
		DFMR_USE_SPECIFIED_VERBS = 0x0200,

		/// <summary>Ignore async verbs.</summary>
		DFMR_NO_ASYNC_VERBS = 0x0400,

		/// <summary>Ignore verbs that are registered for the native CPU architecture.</summary>
		DFMR_NO_NATIVECPU_VERBS = 0x0800,
	}

	/// <summary>
	/// <para>
	/// Provides methods used to get and set shortcut menu information. This information is the same as that provided to <see
	/// cref="SHCreateDefaultContextMenu"/> through the <see cref="DEFCONTEXTMENU"/> structure.
	/// </para>
	/// <para><c>Note</c> Do not use this method to reinitialize a shortcut menu; use IShellExtInit::Initialize instead.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-idefaultfoldermenuinitialize
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IDefaultFolderMenuInitialize")]
	[ComImport, Guid("7690aa79-f8fc-4615-a327-36f7d18f5d91"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDefaultFolderMenuInitialize
	{
		/// <summary>Sets context menu info for the IDefaultFolderMenuInitialize object.</summary>
		/// <param name="hwnd">A handle to the shortcut menu.</param>
		/// <param name="pcmcb">
		/// <para>Type: <c>IContextMenuCB*</c></para>
		/// <para>The address of the object that defines the callback for the shortcut menu.</para>
		/// </param>
		/// <param name="pidlFolder">
		/// <para>Type: <c>PCIDLIST_ABSOLUTE</c></para>
		/// <para>
		/// The address of an item identifier list that specifies the folder of the items. If NULL, this is computed from the psf parameter.
		/// </para>
		/// </param>
		/// <param name="psf">
		/// <para>Type: <c>IShellFolder*</c></para>
		/// <para>The folder of the items.</para>
		/// </param>
		/// <param name="cidl">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The count of items in the apidl parameter.</para>
		/// </param>
		/// <param name="apidl">
		/// <para>Type: <c>PCUITEMID_CHILD_ARRAY</c></para>
		/// <para>A pointer to an array of PIDL structures, each of which is an item to be operated on.</para>
		/// </param>
		/// <param name="punkAssociation">
		/// <para>Type: <c>IUnknown*</c></para>
		/// <para>The address of an IQueryAssociations object that specifies where to load extensions from.</para>
		/// </param>
		/// <param name="cKeys">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The count of items in the aKeys parameter. May be zero.</para>
		/// </param>
		/// <param name="aKeys">
		/// <para>Type: <c>const HKEY*</c></para>
		/// <para>Specifies where to load extensions from.</para>
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/ja-jp/windows/win32/api/shobjidl_core/nf-shobjidl_core-idefaultfoldermenuinitialize-initialize
		// HRESULT Initialize( HWND hwnd, IContextMenuCB *pcmcb, PCIDLIST_ABSOLUTE pidlFolder, IShellFolder *psf, UINT cidl,
		// PCUITEMID_CHILD_ARRAY apidl, IUnknown *punkAssociation, UINT cKeys, const HKEY *aKeys );
		[PreserveSig]
		HRESULT Initialize(HWND hwnd, [In, Optional] IContextMenuCB? pcmcb, [In, Optional] PIDL pidlFolder, [In, Optional] IShellFolder? psf,
			uint cidl, [In, MarshalAs(UnmanagedType.LPArray)] IntPtr[] apidl, [In, Optional] IQueryAssociations? punkAssociation,
			uint cKeys, [In, Optional, MarshalAs(UnmanagedType.LPArray)] HKEY[]? aKeys);

		/// <summary>Sets shortcut menu restrictions for the IDefaultFolderMenuInitialize object.</summary>
		/// <param name="dfmrValues">
		/// A bitwise combination of the DEFAULT_FOLDER_MENU_RESTRICTIONS values that specify the restrictions to set.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idefaultfoldermenuinitialize-setmenurestrictions
		// HRESULT SetMenuRestrictions( DEFAULT_FOLDER_MENU_RESTRICTIONS dfmrValues );
		[PreserveSig]
		HRESULT SetMenuRestrictions(DEFAULT_FOLDER_MENU_RESTRICTIONS dfmrValues);

		/// <summary>Gets shortcut menu restrictions that are currently set for the IDefaultFolderMenuInitialize object.</summary>
		/// <param name="dfmrMask">
		/// A bitwise combination of the DEFAULT_FOLDER_MENU_RESTRICTIONS values that specify the mask of the restrictions to get.
		/// </param>
		/// <param name="pdfmrValues">A bitwise combination of the DEFAULT_FOLDER_MENU_RESTRICTIONS values that specify the restrictions.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idefaultfoldermenuinitialize-getmenurestrictions
		// HRESULT GetMenuRestrictions( DEFAULT_FOLDER_MENU_RESTRICTIONS dfmrMask, DEFAULT_FOLDER_MENU_RESTRICTIONS *pdfmrValues );
		[PreserveSig]
		HRESULT GetMenuRestrictions(DEFAULT_FOLDER_MENU_RESTRICTIONS dfmrMask, out DEFAULT_FOLDER_MENU_RESTRICTIONS pdfmrValues);

		/// <summary>Sets the shortcut menu handler for the IDefaultFolderMenuInitialize object.</summary>
		/// <param name="rclsid">
		/// <para>Type: <c>REFCLSID</c></para>
		/// <para>The CLSID for the object defines the shortcut menu handler.</para>
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idefaultfoldermenuinitialize-sethandlerclsid
		// HRESULT SetHandlerClsid( REFCLSID rclsid );
		[PreserveSig]
		HRESULT SetHandlerClsid(in Guid rclsid);
	}
}