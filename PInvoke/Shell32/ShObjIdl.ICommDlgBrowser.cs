using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>A value that controls the behavior of the view when in common dialog mode.</summary>
	[Flags]
	[PInvokeData("Shobjidl.h")]
	public enum CDB2GVF
	{
		/// <summary>All files, including hidden and system files, should be shown. In Windows XP, this is the only recognized flag.</summary>
		CDB2GVF_SHOWALLFILES = 0x00000001,

		/// <summary>This browser is designated to choose a file to save.</summary>
		CDB2GVF_ISFILESAVE = 0x00000002,

		/// <summary>Not used.</summary>
		CDB2GVF_ALLOWPREVIEWPANE = 0x00000004,

		/// <summary>Do not show a "select" verb on an item's context menu.</summary>
		CDB2GVF_NOSELECTVERB = 0x00000008,

		/// <summary>IncludeObject should not be called.</summary>
		CDB2GVF_NOINCLUDEITEM = 0x00000010,

		/// <summary>This browser is designated to pick folders.</summary>
		CDB2GVF_ISFOLDERPICKER = 0x00000020,

		/// <summary>Windows 7 and later. Displays a UAC shield on the selected item when CDB2GVF_NOSELECTVERB is not specified.</summary>
		CDB2GVF_ADDSHIELD = 0x00000040,
	}

	/// <summary>Values for ICommDlgBrowser2::Notify method.</summary>
	[PInvokeData("Shobjidl.h")]
	public enum CDB2N
	{
		/// <summary>Indicates that the shortcut menu is no longer displayed.</summary>
		CDB2N_CONTEXTMENU_DONE = 0x00000001,

		/// <summary>Indicates that the shortcut menu is about to be displayed.</summary>
		CDB2N_CONTEXTMENU_START = 0x00000002
	}

	/// <summary>Indicates a change in the selection state in ICommDlgBrowser::OnStateChange.</summary>
	[PInvokeData("Shobjidl.h")]
	public enum CDBOSC
	{
		/// <summary>The focus has been set to the view.</summary>
		CDBOSC_SETFOCUS = 0x00000000,

		/// <summary>The view has lost the focus.</summary>
		CDBOSC_KILLFOCUS = 0x00000001,

		/// <summary>The selection has changed.</summary>
		CDBOSC_SELCHANGE = 0x00000002,

		/// <summary>An item has been renamed.</summary>
		CDBOSC_RENAME = 0x00000003,

		/// <summary>An item has been checked or unchecked.</summary>
		CDBOSC_STATECHANGE = 0x00000004,
	}

	/// <summary>
	/// Exposed by the common file dialog boxes to be used when they host a Shell browser. If supported, ICommDlgBrowser exposes methods
	/// that allow a Shell view to handle several cases that require different behavior in a dialog box than in a normal Shell view. You
	/// obtain an ICommDlgBrowser interface pointer by calling QueryInterface on the IShellBrowser object.
	/// </summary>
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("000214F1-0000-0000-C000-000000000046")]
	[PInvokeData("Shobjidl.h", MSDNShortId = "bf89ac6e-6c2e-4944-885c-9ab62f58fe71")]
	public interface ICommDlgBrowser
	{
		/// <summary>Called when a user double-clicks in the view or presses the ENTER key.</summary>
		/// <param name="ppshv">A pointer to the view's IShellView interface.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[PreserveSig]
		HRESULT OnDefaultCommand([In] IShellView ppshv);

		/// <summary>Called after a state, identified by the uChange parameter, has changed in the IShellView interface.</summary>
		/// <param name="ppshv">A pointer to the view's IShellView interface.</param>
		/// <param name="uChange">Change in the selection state. This parameter can be one of the following values.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[PreserveSig]
		HRESULT OnStateChange([In] IShellView ppshv, CDBOSC uChange);

		/// <summary>Allows the common dialog box to filter objects that the view displays.</summary>
		/// <param name="ppshv">A pointer to the view's IShellView interface.</param>
		/// <param name="pidl">A PIDL, relative to the folder, that identifies the object.</param>
		/// <returns>The browser should return S_OK to include the object in the view, or S_FALSE to hide it.</returns>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[PreserveSig]
		HRESULT IncludeObject([In] IShellView ppshv, [In] IntPtr pidl);
	}

	/*
	 * ICommDlgBrowser2 causes grief in .NET for some reason, so it is being left out.
	 *
	/// <summary>
	/// Extends the capabilities of ICommDlgBrowser. This interface is exposed by the common file dialog boxes when they host a Shell
	/// browser. A pointer to ICommDlgBrowser2 can be obtained by calling QueryInterface on the IShellBrowser object.
	/// </summary>
	/// <seealso cref="Vanara.PInvoke.Shell32.ICommDlgBrowser"/>
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("10339516-2894-11d2-9039-00C04F8EEB3E")]
	[PInvokeData("Shobjidl.h", MSDNShortId = "07a416a2-340d-4308-a6f3-cf6f19f3c906")]
	private interface ICommDlgBrowser2 : ICommDlgBrowser
	{
		/// <summary>Called when a user double-clicks in the view or presses the ENTER key.</summary>
		/// <param name="ppshv">A pointer to the view's IShellView interface.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		[PreserveSig]
		new HRESULT OnDefaultCommand([In] IShellView ppshv);

		/// <summary>Called after a state, identified by the uChange parameter, has changed in the IShellView interface.</summary>
		/// <param name="ppshv">A pointer to the view's IShellView interface.</param>
		/// <param name="uChange">Change in the selection state. This parameter can be one of the following values.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		[PreserveSig]
		new HRESULT OnStateChange([In] IShellView ppshv, CDBOSC uChange);

		/// <summary>Allows the common dialog box to filter objects that the view displays.</summary>
		/// <param name="ppshv">A pointer to the view's IShellView interface.</param>
		/// <param name="pidl">A PIDL, relative to the folder, that identifies the object.</param>
		/// <returns>The browser should return S_OK to include the object in the view, or S_FALSE to hide it.</returns>
		[PreserveSig]
		new HRESULT IncludeObject([In] IShellView ppshv, [In] PIDL pidl);

		/// <summary>Called by a Shell view to notify the common dialog box hosting it that an event has occurred.</summary>
		/// <param name="ppshv">A pointer to the view's IShellView interface.</param>
		/// <param name="dwNotifyType">A flag that can can take one of the following two values.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		[PreserveSig]
		HRESULT Notify([In] IShellView ppshv, CDB2N dwNotifyType);

		/// <summary>Called by the Shell view to get the default shortcut menu text.</summary>
		/// <param name="ppshv">A pointer to the view's IShellView interface.</param>
		/// <param name="pszText">A pointer to a buffer that is used by the Shell browser to return the default shortcut menu text.</param>
		/// <param name="cchMax">
		/// The size of the pszText buffer, in characters. It should be at least the maximum allowable path length (MAX_PATH) in size.
		/// </param>
		/// <returns>
		/// Returns S_OK if a new default shortcut menu text was returned in pshv. If S_FALSE is returned, use the normal default text.
		/// Otherwise, returns a standard COM error value.
		/// </returns>
		[PreserveSig]
		HRESULT GetDefaultMenuText([In] IShellView ppshv, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszText, int cchMax);

		/// <summary>Called when the view must determine if special customization needs to be made for the common dialog browser.</summary>
		/// <param name="pdwFlags">A DWORD value that controls the behavior of the view when in common dialog mode.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		[PreserveSig]
		HRESULT GetViewFlags(out CDB2GVF pdwFlags);
	}
	*/

	/// <summary>Extends the capabilities of ICommDlgBrowser2, and used by the common file dialog boxes when they host a Shell browser.</summary>
	/// <seealso cref="Vanara.PInvoke.Shell32.ICommDlgBrowser"/>
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("c8ad25a1-3294-41ee-8165-71174bd01c57")]
	[PInvokeData("Shobjidl.h", MSDNShortId = "c9286061-8ac8-452b-9204-193bc6b571cb")]
	public interface ICommDlgBrowser3 //: ICommDlgBrowser // Don't derive as it seems to cause problems with memory allocations.
	{
		/// <summary>Called when a user double-clicks in the view or presses the ENTER key.</summary>
		/// <param name="ppshv">A pointer to the view's IShellView interface.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[PreserveSig]
		HRESULT OnDefaultCommand([In] IShellView ppshv);

		/// <summary>Called after a state, identified by the uChange parameter, has changed in the IShellView interface.</summary>
		/// <param name="ppshv">A pointer to the view's IShellView interface.</param>
		/// <param name="uChange">Change in the selection state. This parameter can be one of the following values.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[PreserveSig]
		HRESULT OnStateChange([In] IShellView ppshv, CDBOSC uChange);

		/// <summary>Allows the common dialog box to filter objects that the view displays.</summary>
		/// <param name="ppshv">A pointer to the view's IShellView interface.</param>
		/// <param name="pidl">A PIDL, relative to the folder, that identifies the object.</param>
		/// <returns>The browser should return S_OK to include the object in the view, or S_FALSE to hide it.</returns>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[PreserveSig]
		HRESULT IncludeObject([In] IShellView ppshv, [In] IntPtr pidl);

		/// <summary>Called by the Shell view to get the default shortcut menu text.</summary>
		/// <param name="ppshv">A pointer to the view's IShellView interface.</param>
		/// <param name="pszText">A pointer to a buffer that is used by the Shell browser to return the default shortcut menu text.</param>
		/// <param name="cchMax">
		/// The size of the pszText buffer, in characters. It should be at least the maximum allowable path length (MAX_PATH) in size.
		/// </param>
		/// <returns>
		/// Returns S_OK if a new default shortcut menu text was returned in pshv. If S_FALSE is returned, use the normal default text.
		/// Otherwise, returns a standard COM error value.
		/// </returns>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[PreserveSig]
		HRESULT GetDefaultMenuText([In] IShellView ppshv, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszText, int cchMax);

		/// <summary>Called when the view must determine if special customization needs to be made for the common dialog browser.</summary>
		/// <param name="pdwFlags">A DWORD value that controls the behavior of the view when in common dialog mode.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[PreserveSig]
		HRESULT GetViewFlags(out CDB2GVF pdwFlags);

		/// <summary>Called by a Shell view to notify the common dialog box hosting it that an event has occurred.</summary>
		/// <param name="ppshv">A pointer to the view's IShellView interface.</param>
		/// <param name="dwNotifyType">A flag that can can take one of the following two values.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[PreserveSig]
		HRESULT Notify([In] IShellView ppshv, CDB2N dwNotifyType);

		/// <summary>Gets the current filter as a Unicode string.</summary>
		/// <param name="pszFileSpec">Contains a pointer to the current filter path/file as a Unicode string.</param>
		/// <param name="cchFileSpec">Specifies the path/file length, in characters.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[PreserveSig]
		HRESULT GetCurrentFilter([MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFileSpec, int cchFileSpec);

		/// <summary>Called after a specified column is clicked in the IShellView interface.</summary>
		/// <param name="ppshv">A pointer to the IShellView interface of the hosted view.</param>
		/// <param name="iColumn">The index of the column clicked.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[PreserveSig]
		HRESULT OnColumnClicked([In] IShellView ppshv, int iColumn);

		/// <summary>Called after a specified preview is created in the IShellView interface.</summary>
		/// <param name="ppshv">A pointer to the IShellView interface of the hosted view.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[PreserveSig]
		HRESULT OnPreViewCreated([In] IShellView ppshv);
	}

	/// <summary>Exposed by a client to specify how to filter the enumeration of a Shell folder by a server application.</summary>
	/// <remarks>
	/// <para>
	/// This interface is most often used with SHBrowseForFolder to filter the contents of the tree view displayed in a folder selection
	/// dialog box. To use <c>IFolderFilter</c> with <c>SHBrowseForFolder</c>, the BIF_NEWDIALOGSTYLE flag must be set.
	/// </para>
	/// <para>
	/// When your application calls SHBrowseForFolder, you become a client of the folder browser object. The folder browser object
	/// communicates with you by sending messages to a callback function, BrowseCallbackProc. The <c>BFFM_IUNKNOWN</c> message handled
	/// by that callback function contains a pointer to the folder browser's IUnknown interface. To filter the display of a folder's
	/// contents, do the following:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>Use the folder browser's QueryInterface method to request a pointer to the IFolderFilterSite interface.</term>
	/// </item>
	/// <item>
	/// <term>Call IFolderFilterSite::SetFilter, passing it a pointer to your <c>IFolderFilter</c> interface.</term>
	/// </item>
	/// <item>
	/// <term>
	/// The folder browser then queries IFolderFilter::GetEnumFlags and IFolderFilter::ShouldShowto determine how to filter the enumeration.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ifolderfilter
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IFolderFilter")]
	[ComImport, Guid("9CC22886-DC8E-11d2-B1D0-00C04F8EEB3E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IFolderFilter
	{
		/// <summary>
		/// Specifies whether an individual item should be allowed through the filter and which should be blocked. When used with
		/// SHBrowseForFolder, specifies which items should be shown in the dialog box tree view and which should not. The determination
		/// to show or not show an item is up to the application.
		/// </summary>
		/// <param name="psf">
		/// <para>Type: <c>IShellFolder*</c></para>
		/// <para>A pointer to the folder's IShellFolder interface.</para>
		/// </param>
		/// <param name="pidlFolder">
		/// <para>Type: <c>PCIDLIST_ABSOLUTE</c></para>
		/// <para>The PIDL of the folder.</para>
		/// </param>
		/// <param name="pidlItem">
		/// <para>Type: <c>PCUITEMID_CHILD</c></para>
		/// <para>The relative PIDL of the child item of pidlFolder in question.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// Returns S_OK if the item should be shown, S_FALSE if it should not be shown, or a standard error code if an error is
		/// encountered. If an error is encountered, the item is not shown.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>The host calls this method for each item in the folder referred to by psf or pidlFolder.</para>
		/// <para>
		/// It is recommended that your implementation convert the psf and pidlItem information into an IShellItem, which is easier to
		/// consume. The following example shows this:
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifolderfilter-shouldshow HRESULT
		// ShouldShow( IShellFolder *psf, PCIDLIST_ABSOLUTE pidlFolder, PCUITEMID_CHILD pidlItem );
		[PreserveSig]
		HRESULT ShouldShow([In] IShellFolder psf, [In, Optional] PIDL pidlFolder, [In] PIDL pidlItem);

		/// <summary>
		/// Allows a client to specify which classes of objects in a Shell folder should be enumerated. When used with
		/// SHBrowseForFolder, specifies the class or classes of items that should be shown in the dialog box tree view and which class
		/// or classes should not.
		/// </summary>
		/// <param name="psf">
		/// <para>Type: <c>IShellFolder*</c></para>
		/// <para>A pointer to the folder's IShellFolder interface.</para>
		/// </param>
		/// <param name="pidlFolder">
		/// <para>Type: <c>PCIDLIST_ABSOLUTE</c></para>
		/// <para>The PIDL of the folder.</para>
		/// </param>
		/// <param name="phwnd">
		/// <para>Type: <c>HWND*</c></para>
		/// <para>A pointer to the host's window handle.</para>
		/// </param>
		/// <param name="pgrfFlags">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>One or more SHCONTF values that specify the classes of object to enumerate.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifolderfilter-getenumflags HRESULT
		// GetEnumFlags( IShellFolder *psf, PCIDLIST_ABSOLUTE pidlFolder, HWND *phwnd, DWORD *pgrfFlags );
		[PreserveSig]
		HRESULT GetEnumFlags([In] IShellFolder psf, [In] PIDL pidlFolder, out HWND phwnd, ref SHCONTF pgrfFlags);
	}

	/// <summary>Exported by a host to allow clients to specify how to filter a Shell folder enumeration.</summary>
	/// <remarks>
	/// <para>
	/// The most common use of this interface is when your application calls SHBrowseForFolder. When you call this function, you become
	/// a client of the folder browser object. That object communicates with you by sending messages to a callback function,
	/// BrowseCallbackProc. The BFFM_IUNKNOWN message contains a pointer to the folder browser's IUnknown interface. To filter folder enumeration:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>
	/// Use the IUnknown pointer to call the folder browser's QueryInterface method, and request a pointer to the
	/// <c>IFolderFilterSite</c> interface.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Call IFolderFilterSite::SetFilter, and pass the folder browser a pointer to your IFolderFilter (IUnknown or IFilterFolder?) interface.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The folder browser will then query the two methods of the <c>IFolderFilterSite</c> interface to determine how to filter the enumeration.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ifolderfiltersite
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IFolderFilterSite")]
	[ComImport, Guid("C0A651F5-B48B-11d2-B5ED-006097C686F6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IFolderFilterSite
	{
		/// <summary>Exposed by a host to allow clients to pass the host their IUnknown interface pointers.</summary>
		/// <param name="punk">
		/// <para>Type: <c>IUnknown*</c></para>
		/// <para>
		/// A pointer to the client's IUnknown interface. To notify the host to terminate filtering and stop calling your IFolderFilter
		/// interface, set this parameter to <c>NULL</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// After you get a pointer to the host's IFolderFilterSite interface, call this method to pass the host a pointer to your
		/// IUnknown interface. The host will then use this pointer to call your QueryInterface method to request a pointer to your
		/// IFolderFilter interface. If this call fails, <c>IFolderFilterSite::SetFilter</c> returns <c>E_NOINTERFACEAVAILABLE</c>. If
		/// the call is successful, the host will then call the <c>IFolderFilter</c> interface's two methods to determine how to
		/// enumerate the contents of the folder.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifolderfiltersite-setfilter HRESULT
		// SetFilter( IUnknown *punk );
		void SetFilter([In, MarshalAs(UnmanagedType.IUnknown)] object punk);
	}
}