using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>A message id for <see cref="IShellMenuCallback.CallbackSM"/>.</summary>
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IShellMenuCallback")]
		public enum SMC : uint
		{
			/// <summary>The callback is called to init a menuband.</summary>
			SMC_INITMENU = 0x00000001,

			/// <summary>The callback is called to init a menuband.</summary>
			SMC_CREATE = 0x00000002,

			/// <summary>The callback is called when menu is collapsing.</summary>
			SMC_EXITMENU = 0x00000003,

			/// <summary>The callback is called to return uint values.</summary>
			SMC_GETINFO = 0x00000005,

			/// <summary>The callback is called to return uint values.</summary>
			SMC_GETSFINFO = 0x00000006,

			/// <summary>The callback is called to get some object.</summary>
			SMC_GETOBJECT = 0x00000007,

			/// <summary>The callback is called to get some object.</summary>
			SMC_GETSFOBJECT = 0x00000008,

			/// <summary>The callback is called to execute an shell folder item.</summary>
			SMC_SFEXEC = 0x00000009,

			/// <summary>The callback is called when an item is selected.</summary>
			SMC_SFSELECTITEM = 0x0000000A,

			/// <summary>Menus have completely refreshed. Reset your state..</summary>
			SMC_REFRESH = 0x00000010,

			/// <summary>Demote an item.</summary>
			SMC_DEMOTE = 0x00000011,

			/// <summary>Promote an item, wParam = SMINV_* flag.</summary>
			SMC_PROMOTE = 0x00000012,

			/// <summary>Returns Default icon location in wParam, index in lParam.</summary>
			SMC_DEFAULTICON = 0x00000016,

			/// <summary>Notifies item is not in the order stream..</summary>
			SMC_NEWITEM = 0x00000017,

			/// <summary>Notifies of a expansion via the chevron.</summary>
			SMC_CHEVRONEXPAND = 0x00000019,

			/// <summary>S_OK display, S_FALSE not..</summary>
			SMC_DISPLAYCHEVRONTIP = 0x0000002A,

			/// <summary>Called to save the passed object.</summary>
			SMC_SETSFOBJECT = 0x0000002D,

			/// <summary>Called when a Change notify is received. lParam points to SMCSHCHANGENOTIFYSTRUCT.</summary>
			SMC_SHCHANGENOTIFY = 0x0000002E,

			/// <summary>Called to get the chevron tip text. wParam = Tip title, Lparam = TipText Both MAX_PATH.</summary>
			SMC_CHEVRONGETTIP = 0x0000002F,

			/// <summary>Called requesting if it's ok to drop. wParam = IDropTarget..</summary>
			SMC_SFDDRESTRICTED = 0x00000030,

			/// <summary>Same as SFEXEC, but the middle mouse button caused the exec..</summary>
			SMC_SFEXEC_MIDDLE = 0x00000031,

			/// <summary>callback returns the default autoexpand state lParam = ref uint to recieve flags.</summary>
			SMC_GETAUTOEXPANDSTATE = 0x00000041,

			/// <summary>Notify that the menu is expanding/contracting.</summary>
			SMC_AUTOEXPANDCHANGE = 0x00000042,

			/// <summary>Used to add items to a context menu.</summary>
			SMC_GETCONTEXTMENUMODIFIER = 0x00000043,

			/// <summary>used to get a context menu to display when user right clicks on the background.</summary>
			SMC_GETBKCONTEXTMENU = 0x00000044,

			/// <summary>allows client to overwrite open/explore verb action on an item.</summary>
			SMC_OPEN = 0x00000045,
		}

		/// <summary>Flags for <see cref="SMDATA.dwMask"/></summary>
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NS:shobjidl_core.tagSMDATA")]
		[Flags]
		public enum SMDM
		{
			/// <summary>Using the <see cref="SMDATA.pidlFolder"/> value.</summary>
			SMDM_SHELLFOLDER = 0x00000001,

			/// <summary>Using the <see cref="SMDATA.hmenu"/> value.</summary>
			SMDM_HMENU = 0x00000002,

			/// <summary/>
			SMDM_TOOLBAR = 0x00000004,
		}

		/// <summary/>
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IShellMenuCallback")]
		[Flags]
		public enum SMINFOFLAGS
		{
			/// <summary/>
			SMIF_ICON = 0x1,

			/// <summary/>
			SMIF_ACCELERATOR = 0x2,

			/// <summary/>
			SMIF_DROPTARGET = 0x4,

			/// <summary/>
			SMIF_SUBMENU = 0x8,

			/// <summary/>
			SMIF_CHECKED = 0x20,

			/// <summary/>
			SMIF_DROPCASCADE = 0x40,

			/// <summary/>
			SMIF_HIDDEN = 0x80,

			/// <summary/>
			SMIF_DISABLED = 0x100,

			/// <summary/>
			SMIF_TRACKPOPUP = 0x200,

			/// <summary/>
			SMIF_DEMOTED = 0x400,

			/// <summary/>
			SMIF_ALTSTATE = 0x800,

			/// <summary/>
			SMIF_DRAGNDROP = 0x1000,

			/// <summary/>
			SMIF_NEW = 0x2000
		}

		/// <summary/>
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IShellMenuCallback")]
		[Flags]
		public enum SMINFOMASK
		{
			/// <summary/>
			SMIM_TYPE = 0x1,

			/// <summary/>
			SMIM_FLAGS = 0x2,

			/// <summary/>
			SMIM_ICON = 0x4
		}

		/// <summary/>
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IShellMenuCallback")]
		public enum SMINFOTYPE
		{
			/// <summary/>
			SMIT_SEPARATOR = 0x1,

			/// <summary/>
			SMIT_STRING = 0x2
		}

		/// <summary>Flags that control how the menu operates.</summary>
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IShellMenu")]
		[Flags]
		public enum SMINIT
		{
			/// <summary>No options.</summary>
			SMINIT_DEFAULT = 0x00000000,

			/// <summary>Do not allow drag-and-drop.</summary>
			SMINIT_RESTRICT_DRAGDROP = 0x00000002,

			/// <summary>This is the top band.</summary>
			SMINIT_TOPLEVEL = 0x00000004,

			/// <summary>Do not destroy the band when the window is closed.</summary>
			SMINIT_CACHED = 0x00000010,

			/// <summary/>
			SMINIT_AUTOEXPAND = 0x00000100,

			/// <summary/>
			SMINIT_AUTOTOOLTIP = 0x00000200,

			/// <summary/>
			SMINIT_DROPONCONTAINER = 0x00000400,

			/// <summary>Specifies a vertical band.</summary>
			SMINIT_VERTICAL = 0x10000000,

			/// <summary>Specifies a horizontal band.</summary>
			SMINIT_HORIZONTAL = 0x20000000,
		}

		/// <summary>Flags that control how the menu is redrawn.</summary>
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IShellMenu")]
		[Flags]
		public enum SMINV
		{
			/// <summary>Use to redraw entire menu. Set psmd to <see langword="null"/>.</summary>
			SMINV_REFRESH = 0x00000001,

			/// <summary>Use when supplying a value to psmd.</summary>
			SMINV_ID = 0x00000008,
		}

		/// <summary>Flags that specify how the menu operates.</summary>
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IShellMenu")]
		[Flags]
		public enum SMSET
		{
			/// <summary>Attach the menu to the top of the parent menu.</summary>
			SMSET_TOP = 0x10000000,

			/// <summary>Attach the menu to the bottom of the parent menu.</summary>
			SMSET_BOTTOM = 0x20000000,

			/// <summary>
			/// The menu band does not own the menu named in hwnd, so should that menu eventually be replaced, it should not be destroyed.
			/// </summary>
			SMSET_DONTOWN = 0x00000001,
		}

		/// <summary>Exposes methods that interact with Shell menus such as the <c>Start</c> menu, and the <c>Favorites</c> menu.</summary>
		/// <remarks>
		/// To get a pointer to this interface, call CoCreateInstance with the rclsid parameter set to CLSID_MenuBand and the riid parameter
		/// set to IID_IShellMenu. You must first initialize the interface by calling IShellMenu::Initialize, and then initialize the menu
		/// band by calling IShellMenu::SetShellFolder.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ishellmenu
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IShellMenu")]
		[ComImport, Guid("EE1F7637-E138-11d1-8379-00C04FD918D0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(MenuBand))]
		public interface IShellMenu
		{
			/// <summary>Initializes a menu band.</summary>
			/// <param name="psmc">
			/// <para>Type: <c>IShellMenuCallback*</c></para>
			/// <para>
			/// A pointer to an IShellMenuCallback interface. This interface receives notifications from the menu. This value can be <c>NULL</c>.
			/// </para>
			/// </param>
			/// <param name="uId">
			/// <para>Type: <c>UINT</c></para>
			/// <para>The identifier of the selected menu item. Set this parameter to -1 for the menu itself.</para>
			/// </param>
			/// <param name="uIdAncestor">Type: <c>UINT</c></param>
			/// <param name="dwFlags">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Flags that control how the menu operates.</para>
			/// <para>A combination of the following option values:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>SMINIT_DEFAULT</term>
			/// <term>No options.</term>
			/// </item>
			/// <item>
			/// <term>SMINIT_RESTRICT_DRAGDROP</term>
			/// <term>Do not allow drag-and-drop.</term>
			/// </item>
			/// <item>
			/// <term>SMINIT_TOPLEVEL</term>
			/// <term>This is the top band.</term>
			/// </item>
			/// <item>
			/// <term>SMINIT_CACHED</term>
			/// <term>Do not destroy the band when the window is closed.</term>
			/// </item>
			/// </list>
			/// <para>In addition to the values above, one of the following layout options:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>SMINIT_VERTICAL</term>
			/// <term>Specifies a vertical band.</term>
			/// </item>
			/// <item>
			/// <term>SMINIT_HORIZONTAL</term>
			/// <term>Specifies a horizontal band.</term>
			/// </item>
			/// </list>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellmenu-initialize HRESULT Initialize(
			// IShellMenuCallback *psmc, UINT uId, UINT uIdAncestor, DWORD dwFlags );
			void Initialize([In, Optional] IShellMenuCallback psmc, uint uId, uint uIdAncestor, SMINIT dwFlags);

			/// <summary>Gets information from the IShellMenu::Initialize method.</summary>
			/// <param name="ppsmc">
			/// <para>Type: <c>IShellMenuCallback**</c></para>
			/// <para>
			/// When this method returns, contains the address of a pointer to the IShellMenuCallback interface that you specified when you
			/// called IShellMenu::Initialize. This pointer can be <c>NULL</c>.
			/// </para>
			/// </param>
			/// <param name="puId">
			/// <para>Type: <c>UINT*</c></para>
			/// <para>
			/// When this method returns, contains a pointer to a <c>UINT</c> value that receives the uID value that you specified when you
			/// called IShellMenu::Initialize. This pointer can be <c>NULL</c>.
			/// </para>
			/// </param>
			/// <param name="puIdAncestor">
			/// <para>Type: <c>UINT*</c></para>
			/// <para>
			/// When this method returns, contains a pointer to a <c>UINT</c> value that receives the uIdAncestor value that you specified
			/// when you called IShellMenu::Initialize. This pointer can be <c>NULL</c>.
			/// </para>
			/// </param>
			/// <param name="pdwFlags">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>
			/// When this method returns, contains a pointer to a <c>DWORD</c> value that receives the dwFlags value that you specified when
			/// you called IShellMenu::Initialize. This pointer can be <c>NULL</c>.
			/// </para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellmenu-getmenuinfo HRESULT GetMenuInfo(
			// IShellMenuCallback **ppsmc, UINT *puId, UINT *puIdAncestor, DWORD *pdwFlags );
			void GetMenuInfo(out IShellMenuCallback ppsmc, out uint puId, out uint puIdAncestor, out SMINIT pdwFlags);

			/// <summary>Specifies the folder for the menu band to browse.</summary>
			/// <param name="psf">
			/// <para>Type: <c>IShellFolder*</c></para>
			/// <para>A pointer to the folder's IShellFolder interface. This pointer can be <c>NULL</c>.</para>
			/// </param>
			/// <param name="pidlFolder">
			/// <para>Type: <c>PCIDLIST_ABSOLUTE</c></para>
			/// <para>The folder's fully qualified ITEMIDLIST. This value can be <c>NULL</c>.</para>
			/// </param>
			/// <param name="hKey">
			/// <para>Type: <c>HKEY</c></para>
			/// <para>An HKEY with an "Order" value that is used to store the order of the menu. This value can be <c>NULL</c>.</para>
			/// </param>
			/// <param name="dwFlags">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Flags that specify how the menu band operates.</para>
			/// <para>SMSET_BOTTOM</para>
			/// <para>Put this folder at the bottom of the menu.</para>
			/// <para>SMSET_USEBKICONEXTRACTION</para>
			/// <para>Use the background icon extractor.</para>
			/// <para>SMSET_HASEXPANDABLEFOLDERS</para>
			/// <para>This folder contains expandable folders.</para>
			/// <para>SMSET_COLLAPSEONEMPTY</para>
			/// <para>Collapse the menu if empty.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>Call this method after you call IShellMenu::Initialize.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellmenu-setshellfolder HRESULT
			// SetShellFolder( IShellFolder *psf, PCIDLIST_ABSOLUTE pidlFolder, HKEY hKey, DWORD dwFlags );
			void SetShellFolder([In, Optional] IShellFolder psf, [In, Optional] PIDL pidlFolder, [In, Optional] HKEY hKey, SMSET dwFlags);

			/// <summary>Gets the folder that the menu band is set to browse.</summary>
			/// <param name="pdwFlags">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>When this method returns successfully, contains a pointer to a set of flag values that specify how the menu band operates.</para>
			/// <para>Can return any of the following flags.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>SMINIT_DEFAULT</term>
			/// <term>No options.</term>
			/// </item>
			/// <item>
			/// <term>SMINIT_RESTRICT_DRAGDROP</term>
			/// <term>Do not allow drag-and-drop.</term>
			/// </item>
			/// <item>
			/// <term>SMINIT_TOPLEVEL</term>
			/// <term>This is the top band.</term>
			/// </item>
			/// <item>
			/// <term>SMINIT_CACHED</term>
			/// <term>Do not destroy the band when the window is closed.</term>
			/// </item>
			/// </list>
			/// <para>Always returns one of the following flags.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>SMINIT_VERTICAL</term>
			/// <term>Specifies a vertical band.</term>
			/// </item>
			/// <item>
			/// <term>SMINIT_HORIZONTAL</term>
			/// <term>Specifies a horizontal band.</term>
			/// </item>
			/// </list>
			/// </param>
			/// <param name="ppidl">
			/// <para>Type: <c>PCIDLIST_ABSOLUTE*</c></para>
			/// <para>When this method returns, contains the address of the folder's fully qualified ITEMIDLIST.</para>
			/// </param>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>The REFIID for the target folder.</para>
			/// </param>
			/// <param name="ppv">
			/// <para>Type: <c>void**</c></para>
			/// <para>
			/// When this method returns successfully, contains the address of a pointer to the Shell folder object referenced by the riid.
			/// </para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellmenu-getshellfolder HRESULT
			// GetShellFolder( DWORD *pdwFlags, PIDLIST_ABSOLUTE *ppidl, REFIID riid, void **ppv );
			void GetShellFolder(out SMINIT pdwFlags, out PIDL ppidl, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object ppv);

			/// <summary>Appends a static menu to the menu band.</summary>
			/// <param name="hmenu">
			/// <para>Type: <c>HMENU</c></para>
			/// <para>The handle of the static menu that is to be appended. This value can be <c>NULL</c>.</para>
			/// </param>
			/// <param name="hwnd">
			/// <para>Type: <c>HWND</c></para>
			/// <para>The <c>HWND</c> of the owner window. This value can be <c>NULL</c>.</para>
			/// </param>
			/// <param name="dwFlags">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Flags that specify how the menu operates.</para>
			/// <para>SMSET_BOTTOM</para>
			/// <para>Attach the menu to the bottom of the parent menu.</para>
			/// <para>SMSET_TOP</para>
			/// <para>Attach the menu to the top of the parent menu.</para>
			/// <para>SMSET_DONTOWN</para>
			/// <para>The menu band does not own the menu named in hwnd, so should that menu eventually be replaced, it should not be destroyed.</para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellmenu-setmenu HRESULT SetMenu( HMENU
			// hmenu, HWND hwnd, DWORD dwFlags );
			void SetMenu([In, Optional] HMENU hmenu, [In, Optional] HWND hwnd, SMSET dwFlags);

			/// <summary>Gets the menu information set by calling IShellMenu::SetMenu.</summary>
			/// <param name="phmenu">
			/// <para>Type: <c>HMENU*</c></para>
			/// <para>
			/// When this method returns, contains a pointer to an <c>HMENU</c> value that receives the hmenu value that you specified when
			/// you called IShellMenu::SetMenu. This value can be <c>NULL</c>.
			/// </para>
			/// </param>
			/// <param name="phwnd">
			/// <para>Type: <c>HWND*</c></para>
			/// <para>
			/// When this method returns, contains a pointer to an <c>HWND</c> value that receives the hwnd value that you specified when
			/// you called IShellMenu::SetMenu. This value can be <c>NULL</c>.
			/// </para>
			/// </param>
			/// <param name="pdwFlags">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>
			/// When this method returns, contains a pointer to a <c>DWORD</c> value that receives the dwFlags value that you specified when
			/// you called IShellMenu::SetMenu. This value can be <c>NULL</c>.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellmenu-getmenu HRESULT GetMenu( HMENU
			// *phmenu, HWND *phwnd, DWORD *pdwFlags );
			void GetMenu(out HMENU phmenu, out HWND phwnd, out SMSET pdwFlags);

			/// <summary>Redraws an item in a menu band.</summary>
			/// <param name="psmd">
			/// <para>Type: <c>LPSMDATA</c></para>
			/// <para>
			/// A pointer to an SMDATA structure that identifies the item to be redrawn. Set this value to <c>NULL</c> to redraw the entire menu.
			/// </para>
			/// </param>
			/// <param name="dwFlags">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// Flags that control how the menu is redrawn. If psmd is <c>NULL</c>, set dwFlags to SMINV_REFRESH. If psmd is set to a valid
			/// SMDATA structure, set dwFlags to SMINV_ID | SMINV_REFRESH.
			/// </para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellmenu-invalidateitem HRESULT
			// InvalidateItem( LPSMDATA psmd, DWORD dwFlags );
			void InvalidateItem([In, Optional] IntPtr psmd, [In] SMINV dwFlags);

			/// <summary>Gets a filled SMDATA structure.</summary>
			/// <returns>
			/// <para>Type: <c>LPSMDATA</c></para>
			/// <para>When this method returns, contains a pointer to an SMDATA structure that contains information about the menu band.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellmenu-getstate HRESULT GetState(
			// LPSMDATA psmd );
			SMDATA GetState();

			/// <summary>Adds a menu to the menuband.</summary>
			/// <param name="punk">
			/// <para>Type: <c>IUnknown*</c></para>
			/// <para>A pointer to an object that supports <c>CLSID_MenuToolbarBase</c> in its QueryInterface method.</para>
			/// </param>
			/// <param name="dwFlags">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Flags that control how the menu operates.</para>
			/// <para>SMSET_TOP</para>
			/// <para>Bias this namespace to the top of the menu.</para>
			/// <para>SMSET_BOTTOM</para>
			/// <para>Bias this namespace to the bottom of the menu.</para>
			/// <para>SMSET_DONTOWN</para>
			/// <para>The Menuband does not own the non-ref counted object.</para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellmenu-setmenutoolbar HRESULT
			// SetMenuToolbar( IUnknown *punk, DWORD dwFlags );
			void SetMenuToolbar([In, MarshalAs(UnmanagedType.IUnknown)] object punk, SMSET dwFlags);
		}

		/// <summary>A callback interface that exposes a method that receives messages from a menu band.</summary>
		/// <remarks>
		/// Once you have created the menu band object, pass a pointer to this interface to the menu band object by calling
		/// IShellMenu::Initialize. You receive messages from the menu band through the IShellMenuCallback::CallbackSM method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ishellmenucallback
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IShellMenuCallback")]
		[ComImport, Guid("4CA300A1-9B8D-11d1-8B22-00C04FD918D0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IShellMenuCallback
		{
			/// <summary>Receives messages from a menu band object.</summary>
			/// <param name="psmd">
			/// <para>Type: <c>LPSMDATA</c></para>
			/// <para>A pointer to a SMDATA structure that contains information about the menu.</para>
			/// </param>
			/// <param name="uMsg">
			/// <para>Type: <c>UINT</c></para>
			/// <para>A message ID. This will be one of the SMC_XXX values. See Shell Messages and Notifications for a complete list.</para>
			/// </param>
			/// <param name="wParam">
			/// <para>Type: <c>WPARAM</c></para>
			/// <para>A WPARAM value that contains additional information. See the specific SMC_XXX message reference for details.</para>
			/// </param>
			/// <param name="lParam">
			/// <para>Type: <c>LPARAM</c></para>
			/// <para>An LPARAM value that contains additional information. See the specific SMC_XXX message reference for details.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellmenucallback-callbacksm HRESULT
			// CallbackSM( LPSMDATA psmd, UINT uMsg, WPARAM wParam, LPARAM lParam );
			[PreserveSig]
			HRESULT CallbackSM(ref SMDATA psmd, SMC uMsg, [In] IntPtr wParam, [In] IntPtr lParam);
		}

		/// <summary>Contains information from a menu band.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/ns-shobjidl_core-smdata typedef struct tagSMDATA { DWORD dwMask;
		// DWORD dwFlags; HMENU hmenu; HWND hwnd; UINT uId; UINT uIdParent; UINT uIdAncestor; IUnknown *punk; PIDLIST_ABSOLUTE pidlFolder;
		// PUITEMID_CHILD pidlItem; IShellFolder *psf; void *pvUserData; } SMDATA, *LPSMDATA;
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NS:shobjidl_core.tagSMDATA")]
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct SMDATA
		{
			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>A mask that is always set to SMDM_HMENU.</para>
			/// </summary>
			public SMDM dwMask;

			/// <summary>Type: <c>DWORD</c></summary>
			public uint dwFlags;

			/// <summary>
			/// <para>Type: <c>HMENU</c></para>
			/// <para>The static menu portion of the menu band.</para>
			/// </summary>
			public HMENU hmenu;

			/// <summary>
			/// <para>Type: <c>HWND</c></para>
			/// <para>The HWND value of the owner window.</para>
			/// </summary>
			public HWND hwnd;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>The identifier of the menu item. This value is -1 for the menu itself.</para>
			/// </summary>
			public uint uId;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>The identifier of the parent menu.</para>
			/// </summary>
			public uint uIdParent;

			/// <summary>Type: <c>UINT</c></summary>
			public uint uIdAncestor;

			/// <summary>
			/// <para>Type: <c>IUknown*</c></para>
			/// <para>A pointer to the IUnknown interface of the MenuBand object.</para>
			/// </summary>
			public IntPtr punk;

			/// <summary>
			/// <para>Type: <c>PIDLIST_ABSOLUTE</c></para>
			/// <para>The ITEMIDLIST of the shell folder portion of the menu.</para>
			/// </summary>
			public IntPtr pidlFolder;

			/// <summary>
			/// <para>Type: <c>PUITEMID_CHILD</c></para>
			/// <para>The ITEMIDLIST of the selected item in the shell folder portion of the menu.</para>
			/// </summary>
			public IntPtr pidlItem;

			/// <summary>
			/// <para>Type: <c>IShellFolder*</c></para>
			/// <para>A pointer to the IShellFolder interface for the folder associated with the shell folder portion of the menu.</para>
			/// </summary>
			public IntPtr psf;

			/// <summary>
			/// <para>Type: <c>void*</c></para>
			/// <para>A pointer to a user-defined data structure.</para>
			/// </summary>
			public IntPtr pvUserData;
		}

		/// <summary>CLSID_MenuBand</summary>
		[ComImport, Guid("5b4dae26-b807-11d0-9815-00c04fd91972"), ClassInterface(ClassInterfaceType.None)]
		public class MenuBand { }
	}
}