using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>The view mode of the band object. This is one of the following values.</summary>
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IDeskBand")]
		[Flags]
		public enum DBIF : uint
		{
			/// <summary>Band object is displayed in a horizontal band.</summary>
			DBIF_VIEWMODE_NORMAL = 0x0000,

			/// <summary>Band object is displayed in a vertical band.</summary>
			DBIF_VIEWMODE_VERTICAL = 0x0001,

			/// <summary>Band object is displayed in a floating band.</summary>
			DBIF_VIEWMODE_FLOATING = 0x0002,

			/// <summary>Band object is displayed in a transparent band.</summary>
			DBIF_VIEWMODE_TRANSPARENT = 0x0004
		}

		/// <summary>
		/// The set of flags that determine which members of this structure are being requested by the caller. One or more of the following values:
		/// </summary>
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NS:shobjidl_core.DESKBANDINFO")]
		[Flags]
		public enum DBIM : uint
		{
			/// <summary>ptMinSize is requested.</summary>
			DBIM_MINSIZE = 0x0001,

			/// <summary>ptMaxSize is requested.</summary>
			DBIM_MAXSIZE = 0x0002,

			/// <summary>ptIntegral is requested.</summary>
			DBIM_INTEGRAL = 0x0004,

			/// <summary>ptActual is requested.</summary>
			DBIM_ACTUAL = 0x0008,

			/// <summary>wszTitle is requested.</summary>
			DBIM_TITLE = 0x0010,

			/// <summary>dwModeFlags is requested.</summary>
			DBIM_MODEFLAGS = 0x0020,

			/// <summary>crBkgnd is requested.</summary>
			DBIM_BKCOLOR = 0x0040
		}

		/// <summary>
		/// A value that receives a set of flags that specify the mode of operation for the band object. One or more of the following values:
		/// </summary>
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NS:shobjidl_core.DESKBANDINFO")]
		[Flags]
		public enum DBIMF : uint
		{
			/// <summary>The band uses default properties. The other mode flags modify this flag.</summary>
			DBIMF_NORMAL = 0x0000,

			/// <summary>
			/// Windows XP and later: The band object is of a fixed sized and position. With this flag, a sizing grip is not displayed on the
			/// band object.
			/// </summary>
			DBIMF_FIXED = 0x0001,

			/// <summary>
			/// DBIMF_FIXEDBMP Windows XP and later: The band object uses a fixed bitmap (.bmp) file as its background. Note that backgrounds
			/// are not supported in all cases, so the bitmap may not be seen even when this flag is set.
			/// </summary>
			DBIMF_FIXEDBMP = 0x0004,

			/// <summary>
			/// The height of the band object can be changed. The ptIntegral member defines the step value by which the band object can be resized.
			/// </summary>
			DBIMF_VARIABLEHEIGHT = 0x0008,

			/// <summary>Windows XP and later: The band object cannot be removed from the band container.</summary>
			DBIMF_UNDELETEABLE = 0x0010,

			/// <summary>The band object is displayed with a sunken appearance.</summary>
			DBIMF_DEBOSSED = 0x0020,

			/// <summary>The band is displayed with the background color specified in crBkgnd.</summary>
			DBIMF_BKCOLOR = 0x0040,

			/// <summary>
			/// Windows XP and later: If the full band object cannot be displayed (that is, the band object is smaller than ptActual, a chevron
			/// is shown to indicate that there are more options available. These options are displayed when the chevron is clicked.
			/// </summary>
			DBIMF_USECHEVRON = 0x0080,

			/// <summary>Windows XP and later: The band object is displayed in a new row in the band container.</summary>
			DBIMF_BREAK = 0x0100,

			/// <summary>Windows XP and later: The band object is the first object in the band container.</summary>
			DBIMF_ADDTOFRONT = 0x0200,

			/// <summary>Windows XP and later: The band object is displayed in the top row of the band container.</summary>
			DBIMF_TOPALIGN = 0x0400,

			/// <summary>Windows Vista and later: No sizing grip is ever displayed to allow the user to move or resize the band object.</summary>
			DBIMF_NOGRIPPER = 0x0800,

			/// <summary>
			/// Windows Vista and later: A sizing grip that allows the user to move or resize the band object is always shown, even if that band
			/// object is the only one in the container.
			/// </summary>
			DBIMF_ALWAYSGRIPPER = 0x1000,

			/// <summary>Windows Vista and later: The band object should not display margins.</summary>
			DBIMF_NOMARGINS = 0x2000
		}

		/// <summary>
		/// <para>Used to obtain information about a band object.</para>
		/// <para>
		/// <c>Important</c> You should use thumbnail toolbars in new development in place of desk bands, which are not supported as of Windows 7.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>This interface also provides the methods of the IOleWindow and IDockingWindow interfaces, from which it inherits.</para>
		/// <para>When to Implement</para>
		/// <para>Implement <c>IDeskBand</c> if you are implementing a band object.</para>
		/// <para>When to Use</para>
		/// <para>
		/// You do not call this interface directly. <c>IDeskBand</c> is used by the Shell or the browser to obtain display information for a
		/// band object.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ideskband
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IDeskBand")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("EB0FE172-1A3A-11D0-89B3-00A0C90A90AC")]
		public interface IDeskBand : IDockingWindow
		{
			/// <summary>
			/// Retrieves a handle to one of the windows participating in in-place activation (frame, document, parent, or in-place object window).
			/// </summary>
			/// <param name="phwnd">A pointer to a variable that receives the window handle.</param>
			/// <returns>
			/// This method returns S_OK on success. Other possible return values include the following.
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <description>E_FAIL</description>
			/// <description>The object is windowless.</description>
			/// </item>
			/// <item>
			/// <description>E_OUTOFMEMORY</description>
			/// <description>There is insufficient memory available for this operation.</description>
			/// </item>
			/// <item>
			/// <description>E_UNEXPECTED</description>
			/// <description>An unexpected error has occurred.</description>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// Five types of windows comprise the windows hierarchy. When a object is active in place, it has access to some or all of these windows.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Window</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <description>Frame</description>
			/// <description>The outermost main window where the container application's main menu resides.</description>
			/// </item>
			/// <item>
			/// <description>Document</description>
			/// <description>The window that displays the compound document containing the embedded object to the user.</description>
			/// </item>
			/// <item>
			/// <description>Pane</description>
			/// <description>
			/// The subwindow of the document window that contains the object's view. Applicable only for applications with split-pane windows.
			/// </description>
			/// </item>
			/// <item>
			/// <description>Parent</description>
			/// <description>
			/// The container window that contains that object's view. The object application installs its window as a child of this window.
			/// </description>
			/// </item>
			/// <item>
			/// <description>In-place</description>
			/// <description>
			/// The window containing the active in-place object. The object application creates this window and installs it as a child of its
			/// hatch window, which is a child of the container's parent window.
			/// </description>
			/// </item>
			/// </list>
			/// <para>
			/// Each type of window has a different role in the in-place activation architecture. However, it is not necessary to employ a
			/// separate physical window for each type. Many container applications use the same window for their frame, document, pane, and
			/// parent windows.
			/// </para>
			/// </remarks>
			[PreserveSig]
			new HRESULT GetWindow(out HWND phwnd);

			/// <summary>Determines whether context-sensitive help mode should be entered during an in-place activation session.</summary>
			/// <param name="fEnterMode"><see langword="true"/> if help mode should be entered; <see langword="false"/> if it should be exited.</param>
			/// <returns>
			/// <para>
			/// This method returns S_OK if the help mode was entered or exited successfully, depending on the value passed in <paramref
			/// name="fEnterMode"/>. Other possible return values include the following. <br/>
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <description>E_INVALIDARG</description>
			/// <description>The specified <paramref name="fEnterMode"/> value is not valid.</description>
			/// </item>
			/// <item>
			/// <description>E_OUTOFMEMORY</description>
			/// <description>There is insufficient memory available for this operation.</description>
			/// </item>
			/// <item>
			/// <description>E_UNEXPECTED</description>
			/// <description>An unexpected error has occurred.</description>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>Applications can invoke context-sensitive help when the user:</para>
			/// <list type="bullet">
			/// <item>presses SHIFT+F1, then clicks a topic</item>
			/// <item>presses F1 when a menu item is selected</item>
			/// </list>
			/// <para>
			/// When SHIFT+F1 is pressed, either the frame or active object can receive the keystrokes. If the container's frame receives the
			/// keystrokes, it calls its containing document's IOleWindow::ContextSensitiveHelp method with <paramref name="fEnterMode"/> set to
			/// <see langword="true"/>. This propagates the help state to all of its in-place objects so they can correctly handle the mouse
			/// click or WM_COMMAND.
			/// </para>
			/// <para>
			/// If an active object receives the SHIFT+F1 keystrokes, it calls the container's IOleWindow::ContextSensitiveHelp method with
			/// <paramref name="fEnterMode"/> set to <see langword="true"/>, which then recursively calls each of its in-place sites until there
			/// are no more to be notified. The container then calls its document's or frame's IOleWindow::ContextSensitiveHelp method with
			/// <paramref name="fEnterMode"/> set to <see langword="true"/>.
			/// </para>
			/// <para>When in context-sensitive help mode, an object that receives the mouse click can either:</para>
			/// <list type="bullet">
			/// <item>Ignore the click if it does not support context-sensitive help.</item>
			/// <item>
			/// Tell all the other objects to exit context-sensitive help mode with ContextSensitiveHelp set to FALSE and then provide help for
			/// that context.
			/// </item>
			/// </list>
			/// <para>
			/// An object in context-sensitive help mode that receives a WM_COMMAND should tell all the other in-place objects to exit
			/// context-sensitive help mode and then provide help for the command.
			/// </para>
			/// <para>
			/// If a container application is to support context-sensitive help on menu items, it must either provide its own message filter so
			/// that it can intercept the F1 key or ask the OLE library to add a message filter by calling OleSetMenuDescriptor, passing valid,
			/// non-NULL values for the lpFrame and lpActiveObj parameters.
			/// </para>
			/// </remarks>
			[PreserveSig]
			new HRESULT ContextSensitiveHelp([MarshalAs(UnmanagedType.Bool)] bool fEnterMode);

			/// <summary>Instructs the docking window object to show or hide itself.</summary>
			/// <param name="fShow">
			/// <para>Type: <c>BOOL</c></para>
			/// <para>
			/// <c>TRUE</c> if the docking window object should show its window. <c>FALSE</c> if the docking window object should hide its
			/// window and return its border space by calling SetBorderSpaceDW with zero values.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idockingwindow-showdw HRESULT ShowDW( BOOL
			// fShow );
			[PreserveSig]
			new HRESULT ShowDW([MarshalAs(UnmanagedType.Bool)] bool fShow);

			/// <summary>
			/// Notifies the docking window object that it is about to be removed from the frame. The docking window object should save any
			/// persistent information at this time.
			/// </summary>
			/// <param name="dwReserved">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Reserved. This parameter should always be zero.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idockingwindow-closedw HRESULT CloseDW( DWORD
			// dwReserved );
			[PreserveSig]
			new HRESULT CloseDW(uint dwReserved);

			/// <summary>
			/// Notifies the docking window object that the frame's border space has changed. In response to this method, the IDockingWindow
			/// implementation must call SetBorderSpaceDW, even if no border space is required or a change is not necessary.
			/// </summary>
			/// <param name="prcBorder">
			/// <para>Type: <c>LPCRECT</c></para>
			/// <para>Pointer to a RECT structure that contains the frame's available border space.</para>
			/// </param>
			/// <param name="punkToolbarSite">
			/// <para>Type: <c>IUnknown*</c></para>
			/// <para>
			/// Pointer to the site's IUnknown interface. The docking window object should call the QueryInterface method for this interface,
			/// requesting IID_IDockingWindowSite. The docking window object then uses that interface to negotiate its border space. It is the
			/// docking window object's responsibility to release this interface when it is no longer needed.
			/// </para>
			/// </param>
			/// <param name="fReserved">
			/// <para>Type: <c>BOOL</c></para>
			/// <para>Reserved. This parameter should always be zero.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The prcBorder parameter contains the frame's entire available border space. The docking window object should negotiate its
			/// border space and then use this information to position itself.
			/// </para>
			/// <para>
			/// For example, if the docking window object requires 25 pixels at the top of the border space, it should negotiate for this
			/// through the following steps:
			/// </para>
			/// <list type="number">
			/// <item>
			/// <term>Allocate a BORDERWIDTHS structure and set its <c>top</c> member to 25.</term>
			/// </item>
			/// <item>
			/// <term>Call RequestBorderSpaceDW to request the space.</term>
			/// </item>
			/// <item>
			/// <term>If the request is approved by RequestBorderSpaceDW, call SetBorderSpaceDW to allocate the space.</term>
			/// </item>
			/// </list>
			/// <para>
			/// The docking window object can then position its window at prcBorder-&gt;left and prcBorder-&gt;top. The width of the docking
			/// window object's window is determined by subtracting prcBorder-&gt;left from prcBorder-&gt;right. Its height is contained in the
			/// <c>top</c> member of the BORDERWIDTHS structure.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idockingwindow-resizeborderdw HRESULT
			// ResizeBorderDW( LPCRECT prcBorder, IUnknown *punkToolbarSite, BOOL fReserved );
			[PreserveSig]
			new HRESULT ResizeBorderDW([In, Optional] PRECT prcBorder, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object punkToolbarSite, [MarshalAs(UnmanagedType.Bool)] bool fReserved = false);

			/// <summary>
			/// <para>Gets state information for a band object.</para>
			/// <para>
			/// <c>Important</c> You should use thumbnail toolbars in new development in place of desk bands, which are not supported as of
			/// Windows 7.
			/// </para>
			/// </summary>
			/// <param name="dwBandID">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The identifier of the band, assigned by the container. The band object can retain this value if it is required.</para>
			/// </param>
			/// <param name="dwViewMode">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The view mode of the band object. One of the following values:</para>
			/// <para>DBIF_VIEWMODE_NORMAL</para>
			/// <para>The band object is being displayed in a horizontal band.</para>
			/// <para>DBIF_VIEWMODE_VERTICAL</para>
			/// <para>The band object is being displayed in a vertical band.</para>
			/// <para>DBIF_VIEWMODE_FLOATING</para>
			/// <para>The band object is being displayed in a floating band.</para>
			/// <para>DBIF_VIEWMODE_TRANSPARENT</para>
			/// <para>The band object is being displayed in a transparent band.</para>
			/// </param>
			/// <param name="pdbi">
			/// <para>Type: <c>DESKBANDINFO*</c></para>
			/// <para>
			/// Pointer to a DESKBANDINFO structure that receives the band information for the object. The <c>dwMask</c> member of this
			/// structure indicates the specific information that is being requested.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ideskband-getbandinfo HRESULT GetBandInfo(
			// DWORD dwBandID, DWORD dwViewMode, DESKBANDINFO *pdbi );
			[PreserveSig]
			HRESULT GetBandInfo(uint dwBandID, DBIF dwViewMode, ref DESKBANDINFO pdbi);
		}

		/// <summary>
		/// <para>Exposes methods to enable and query translucency effects in a deskband object.</para>
		/// <para>
		/// <c>Important</c> You should use thumbnail toolbars in new development in place of desk bands, which are not supported as of Windows 7.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>This interface also provides the methods of the IOleWindow, IDockingWindow, and IDeskBand interfaces, from which it inherits.</para>
		/// <para>
		/// If implemented in all active deskbands, this interface allows the taskbar to be displayed using translucent effects. If an active
		/// deskband does not implement <c>IDeskBand2</c>, then translucency is disabled for the entire taskbar.
		/// </para>
		/// <para>A deskband can implement <c>IDeskBand2</c> as a communication conduit between itself and the taskbar as follows:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// Taskbar calls IDeskBand2::CanRenderComposited to learn if a deskband supports translucency. If one or more do not, the entire
		/// taskbar is rendered opaque.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Taskbar calls IDeskBand2::SetCompositionState as appropriate in response to a user turning translucent effects on or off. The
		/// taskbar should attempt to render itself translucent or opaque in response to this call.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IDeskBand2::GetCompositionState is the counterpart of IDeskBand2::SetCompositionState.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nn-shobjidl-ideskband2
		[PInvokeData("shobjidl.h", MSDNShortId = "NN:shobjidl.IDeskBand2")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("79D16DE4-ABEE-4021-8D9D-9169B261D657")]
		public interface IDeskBand2 : IDeskBand
		{
			/// <summary>
			/// Retrieves a handle to one of the windows participating in in-place activation (frame, document, parent, or in-place object window).
			/// </summary>
			/// <param name="phwnd">A pointer to a variable that receives the window handle.</param>
			/// <returns>
			/// This method returns S_OK on success. Other possible return values include the following.
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <description>E_FAIL</description>
			/// <description>The object is windowless.</description>
			/// </item>
			/// <item>
			/// <description>E_OUTOFMEMORY</description>
			/// <description>There is insufficient memory available for this operation.</description>
			/// </item>
			/// <item>
			/// <description>E_UNEXPECTED</description>
			/// <description>An unexpected error has occurred.</description>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// Five types of windows comprise the windows hierarchy. When a object is active in place, it has access to some or all of these windows.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Window</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <description>Frame</description>
			/// <description>The outermost main window where the container application's main menu resides.</description>
			/// </item>
			/// <item>
			/// <description>Document</description>
			/// <description>The window that displays the compound document containing the embedded object to the user.</description>
			/// </item>
			/// <item>
			/// <description>Pane</description>
			/// <description>
			/// The subwindow of the document window that contains the object's view. Applicable only for applications with split-pane windows.
			/// </description>
			/// </item>
			/// <item>
			/// <description>Parent</description>
			/// <description>
			/// The container window that contains that object's view. The object application installs its window as a child of this window.
			/// </description>
			/// </item>
			/// <item>
			/// <description>In-place</description>
			/// <description>
			/// The window containing the active in-place object. The object application creates this window and installs it as a child of its
			/// hatch window, which is a child of the container's parent window.
			/// </description>
			/// </item>
			/// </list>
			/// <para>
			/// Each type of window has a different role in the in-place activation architecture. However, it is not necessary to employ a
			/// separate physical window for each type. Many container applications use the same window for their frame, document, pane, and
			/// parent windows.
			/// </para>
			/// </remarks>
			[PreserveSig]
			new HRESULT GetWindow(out HWND phwnd);

			/// <summary>Determines whether context-sensitive help mode should be entered during an in-place activation session.</summary>
			/// <param name="fEnterMode"><see langword="true"/> if help mode should be entered; <see langword="false"/> if it should be exited.</param>
			/// <returns>
			/// <para>
			/// This method returns S_OK if the help mode was entered or exited successfully, depending on the value passed in <paramref
			/// name="fEnterMode"/>. Other possible return values include the following. <br/>
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <description>E_INVALIDARG</description>
			/// <description>The specified <paramref name="fEnterMode"/> value is not valid.</description>
			/// </item>
			/// <item>
			/// <description>E_OUTOFMEMORY</description>
			/// <description>There is insufficient memory available for this operation.</description>
			/// </item>
			/// <item>
			/// <description>E_UNEXPECTED</description>
			/// <description>An unexpected error has occurred.</description>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>Applications can invoke context-sensitive help when the user:</para>
			/// <list type="bullet">
			/// <item>presses SHIFT+F1, then clicks a topic</item>
			/// <item>presses F1 when a menu item is selected</item>
			/// </list>
			/// <para>
			/// When SHIFT+F1 is pressed, either the frame or active object can receive the keystrokes. If the container's frame receives the
			/// keystrokes, it calls its containing document's IOleWindow::ContextSensitiveHelp method with <paramref name="fEnterMode"/> set to
			/// <see langword="true"/>. This propagates the help state to all of its in-place objects so they can correctly handle the mouse
			/// click or WM_COMMAND.
			/// </para>
			/// <para>
			/// If an active object receives the SHIFT+F1 keystrokes, it calls the container's IOleWindow::ContextSensitiveHelp method with
			/// <paramref name="fEnterMode"/> set to <see langword="true"/>, which then recursively calls each of its in-place sites until there
			/// are no more to be notified. The container then calls its document's or frame's IOleWindow::ContextSensitiveHelp method with
			/// <paramref name="fEnterMode"/> set to <see langword="true"/>.
			/// </para>
			/// <para>When in context-sensitive help mode, an object that receives the mouse click can either:</para>
			/// <list type="bullet">
			/// <item>Ignore the click if it does not support context-sensitive help.</item>
			/// <item>
			/// Tell all the other objects to exit context-sensitive help mode with ContextSensitiveHelp set to FALSE and then provide help for
			/// that context.
			/// </item>
			/// </list>
			/// <para>
			/// An object in context-sensitive help mode that receives a WM_COMMAND should tell all the other in-place objects to exit
			/// context-sensitive help mode and then provide help for the command.
			/// </para>
			/// <para>
			/// If a container application is to support context-sensitive help on menu items, it must either provide its own message filter so
			/// that it can intercept the F1 key or ask the OLE library to add a message filter by calling OleSetMenuDescriptor, passing valid,
			/// non-NULL values for the lpFrame and lpActiveObj parameters.
			/// </para>
			/// </remarks>
			[PreserveSig]
			new HRESULT ContextSensitiveHelp([MarshalAs(UnmanagedType.Bool)] bool fEnterMode);

			/// <summary>Instructs the docking window object to show or hide itself.</summary>
			/// <param name="fShow">
			/// <para>Type: <c>BOOL</c></para>
			/// <para>
			/// <c>TRUE</c> if the docking window object should show its window. <c>FALSE</c> if the docking window object should hide its
			/// window and return its border space by calling SetBorderSpaceDW with zero values.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idockingwindow-showdw HRESULT ShowDW( BOOL
			// fShow );
			[PreserveSig]
			new HRESULT ShowDW([MarshalAs(UnmanagedType.Bool)] bool fShow);

			/// <summary>
			/// Notifies the docking window object that it is about to be removed from the frame. The docking window object should save any
			/// persistent information at this time.
			/// </summary>
			/// <param name="dwReserved">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Reserved. This parameter should always be zero.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idockingwindow-closedw HRESULT CloseDW( DWORD
			// dwReserved );
			[PreserveSig]
			new HRESULT CloseDW(uint dwReserved);

			/// <summary>
			/// Notifies the docking window object that the frame's border space has changed. In response to this method, the IDockingWindow
			/// implementation must call SetBorderSpaceDW, even if no border space is required or a change is not necessary.
			/// </summary>
			/// <param name="prcBorder">
			/// <para>Type: <c>LPCRECT</c></para>
			/// <para>Pointer to a RECT structure that contains the frame's available border space.</para>
			/// </param>
			/// <param name="punkToolbarSite">
			/// <para>Type: <c>IUnknown*</c></para>
			/// <para>
			/// Pointer to the site's IUnknown interface. The docking window object should call the QueryInterface method for this interface,
			/// requesting IID_IDockingWindowSite. The docking window object then uses that interface to negotiate its border space. It is the
			/// docking window object's responsibility to release this interface when it is no longer needed.
			/// </para>
			/// </param>
			/// <param name="fReserved">
			/// <para>Type: <c>BOOL</c></para>
			/// <para>Reserved. This parameter should always be zero.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The prcBorder parameter contains the frame's entire available border space. The docking window object should negotiate its
			/// border space and then use this information to position itself.
			/// </para>
			/// <para>
			/// For example, if the docking window object requires 25 pixels at the top of the border space, it should negotiate for this
			/// through the following steps:
			/// </para>
			/// <list type="number">
			/// <item>
			/// <term>Allocate a BORDERWIDTHS structure and set its <c>top</c> member to 25.</term>
			/// </item>
			/// <item>
			/// <term>Call RequestBorderSpaceDW to request the space.</term>
			/// </item>
			/// <item>
			/// <term>If the request is approved by RequestBorderSpaceDW, call SetBorderSpaceDW to allocate the space.</term>
			/// </item>
			/// </list>
			/// <para>
			/// The docking window object can then position its window at prcBorder-&gt;left and prcBorder-&gt;top. The width of the docking
			/// window object's window is determined by subtracting prcBorder-&gt;left from prcBorder-&gt;right. Its height is contained in the
			/// <c>top</c> member of the BORDERWIDTHS structure.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idockingwindow-resizeborderdw HRESULT
			// ResizeBorderDW( LPCRECT prcBorder, IUnknown *punkToolbarSite, BOOL fReserved );
			[PreserveSig]
			new HRESULT ResizeBorderDW([In, Optional] PRECT prcBorder, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object punkToolbarSite, [MarshalAs(UnmanagedType.Bool)] bool fReserved = false);

			/// <summary>
			/// <para>Gets state information for a band object.</para>
			/// <para>
			/// <c>Important</c> You should use thumbnail toolbars in new development in place of desk bands, which are not supported as of
			/// Windows 7.
			/// </para>
			/// </summary>
			/// <param name="dwBandID">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The identifier of the band, assigned by the container. The band object can retain this value if it is required.</para>
			/// </param>
			/// <param name="dwViewMode">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The view mode of the band object. One of the following values:</para>
			/// <para>DBIF_VIEWMODE_NORMAL</para>
			/// <para>The band object is being displayed in a horizontal band.</para>
			/// <para>DBIF_VIEWMODE_VERTICAL</para>
			/// <para>The band object is being displayed in a vertical band.</para>
			/// <para>DBIF_VIEWMODE_FLOATING</para>
			/// <para>The band object is being displayed in a floating band.</para>
			/// <para>DBIF_VIEWMODE_TRANSPARENT</para>
			/// <para>The band object is being displayed in a transparent band.</para>
			/// </param>
			/// <param name="pdbi">
			/// <para>Type: <c>DESKBANDINFO*</c></para>
			/// <para>
			/// Pointer to a DESKBANDINFO structure that receives the band information for the object. The <c>dwMask</c> member of this
			/// structure indicates the specific information that is being requested.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ideskband-getbandinfo HRESULT GetBandInfo(
			// DWORD dwBandID, DWORD dwViewMode, DESKBANDINFO *pdbi );
			[PreserveSig]
			new HRESULT GetBandInfo(uint dwBandID, DBIF dwViewMode, ref DESKBANDINFO pdbi);

			/// <summary>
			/// <para>Indicates the deskband's ability to be displayed as translucent.</para>
			/// <para>
			/// <c>Important</c> You should use thumbnail toolbars in new development in place of desk bands, which are not supported as of
			/// Windows 7.
			/// </para>
			/// </summary>
			/// <param name="pfCanRenderComposited">
			/// <para>Type: <c>BOOL*</c></para>
			/// <para>When this method returns, contains a <c>BOOL</c> indicating ability.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-ideskband2-canrendercomposited HRESULT
			// CanRenderComposited( BOOL *pfCanRenderComposited );
			[PreserveSig]
			HRESULT CanRenderComposited([MarshalAs(UnmanagedType.Bool)] out bool pfCanRenderComposited);

			/// <summary>
			/// <para>Sets the composition state.</para>
			/// <para>
			/// <c>Important</c> You should use thumbnail toolbars in new development in place of desk bands, which are not supported as of
			/// Windows 7.
			/// </para>
			/// </summary>
			/// <param name="fCompositionEnabled">
			/// <para>Type: <c>BOOL</c></para>
			/// <para><c>TRUE</c> to enable the composition state; otherwise, <c>FALSE</c>.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-ideskband2-setcompositionstate HRESULT
			// SetCompositionState( BOOL fCompositionEnabled );
			[PreserveSig]
			HRESULT SetCompositionState([MarshalAs(UnmanagedType.Bool)] bool fCompositionEnabled);

			/// <summary>
			/// <para>Gets the composition state.</para>
			/// <para>
			/// <c>Important</c> You should use thumbnail toolbars in new development in place of desk bands, which are not supported as of
			/// Windows 7.
			/// </para>
			/// </summary>
			/// <param name="pfCompositionEnabled">
			/// <para>Type: <c>BOOL*</c></para>
			/// <para>When this method returns, contains a <c>BOOL</c> that indicates state.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-ideskband2-getcompositionstate HRESULT
			// GetCompositionState( BOOL *pfCompositionEnabled );
			[PreserveSig]
			HRESULT GetCompositionState([MarshalAs(UnmanagedType.Bool)] out bool pfCompositionEnabled);
		}

		/// <summary>Receives information about a band object. This structure is used with the deprecated IDeskBand::GetBandInfo method.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/ns-shobjidl_core-deskbandinfo typedef struct DESKBANDINFO { DWORD
		// dwMask; POINTL ptMinSize; POINTL ptMaxSize; POINTL ptIntegral; POINTL ptActual; WCHAR wszTitle[256]; DWORD dwModeFlags; COLORREF
		// crBkgnd; } DESKBANDINFO;
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NS:shobjidl_core.DESKBANDINFO")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct DESKBANDINFO
		{
			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The set of flags that determine which members of this structure are being requested by the caller. One or more of the following values:
			/// </para>
			/// <para>DBIM_MINSIZE</para>
			/// <para><c>ptMinSize</c> is requested.</para>
			/// <para>DBIM_MAXSIZE</para>
			/// <para><c>ptMaxSize</c> is requested.</para>
			/// <para>DBIM_INTEGRAL</para>
			/// <para><c>ptIntegral</c> is requested.</para>
			/// <para>DBIM_ACTUAL</para>
			/// <para><c>ptActual</c> is requested.</para>
			/// <para>DBIM_TITLE</para>
			/// <para><c>wszTitle</c> is requested.</para>
			/// <para>DBIM_MODEFLAGS</para>
			/// <para><c>dwModeFlags</c> is requested.</para>
			/// <para>DBIM_BKCOLOR</para>
			/// <para><c>crBkgnd</c> is requested.</para>
			/// </summary>
			public DBIM dwMask;

			/// <summary>
			/// <para>Type: <c>POINTL</c></para>
			/// <para>
			/// A POINTL structure that receives the minimum size of the band object. The minimum width is given in the <c>POINTL</c>
			/// structure's <c>x</c> member and the minimum height is given in the <c>y</c> member.
			/// </para>
			/// </summary>
			public SIZE ptMinSize;

			/// <summary>
			/// <para>Type: <c>POINTL</c></para>
			/// <para>
			/// A POINTL structure that receives the maximum size of the band object. The maximum height is given in the <c>POINTL</c>
			/// structure's <c>y</c> member and the <c>x</c> member is ignored. If the band object has no limit for its maximum height, (LONG)-1
			/// should be used.
			/// </para>
			/// </summary>
			public SIZE ptMaxSize;

			/// <summary>
			/// <para>Type: <c>POINTL</c></para>
			/// <para>
			/// A POINTL structure that receives the sizing step value (increment) in which the band object is resized. The vertical step value
			/// is given in the <c>POINTL</c> structure's <c>y</c> member and the <c>x</c> member is ignored.
			/// </para>
			/// <para>The <c>dwModeFlags</c> member must contain the DBIMF_VARIABLEHEIGHT flag; otherwise, <c>ptIntegral</c> is ignored.</para>
			/// </summary>
			public SIZE ptIntegral;

			/// <summary>
			/// <para>Type: <c>POINTL</c></para>
			/// <para>
			/// A POINTL structure that receives the ideal size of the band object. The ideal width is given in the <c>POINTL</c> structure's
			/// <c>x</c> member and the ideal height is given in the <c>y</c> member. The band container attempts to use these values, but the
			/// band is not guaranteed to be this size.
			/// </para>
			/// </summary>
			public SIZE ptActual;

			/// <summary>
			/// <para>Type: <c>WCHAR[256]</c></para>
			/// <para>A <c>WCHAR</c> buffer that receives the title of the band.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
			public string wszTitle;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// A value that receives a set of flags that specify the mode of operation for the band object. One or more of the following values:
			/// </para>
			/// <para>DBIMF_NORMAL</para>
			/// <para>The band uses default properties. The other mode flags modify this flag.</para>
			/// <para>DBIMF_FIXED</para>
			/// <para>
			/// <c>Windows XP and later:</c> The band object is of a fixed sized and position. With this flag, a sizing grip is not displayed on
			/// the band object.
			/// </para>
			/// <para>DBIMF_FIXEDBMP</para>
			/// <para>
			/// <c>Windows XP and later:</c> The band object uses a fixed bitmap (.bmp) file as its background. Note that backgrounds are not
			/// supported in all cases, so the bitmap may not be seen even when this flag is set.
			/// </para>
			/// <para>DBIMF_VARIABLEHEIGHT</para>
			/// <para>
			/// The height of the band object can be changed. The <c>ptIntegral</c> member defines the step value by which the band object can
			/// be resized.
			/// </para>
			/// <para>DBIMF_UNDELETEABLE</para>
			/// <para><c>Windows XP and later:</c> The band object cannot be removed from the band container.</para>
			/// <para>DBIMF_DEBOSSED</para>
			/// <para>The band object is displayed with a sunken appearance.</para>
			/// <para>DBIMF_BKCOLOR</para>
			/// <para>The band is displayed with the background color specified in <c>crBkgnd</c>.</para>
			/// <para>DBIMF_USECHEVRON</para>
			/// <para>
			/// <c>Windows XP and later:</c> If the full band object cannot be displayed (that is, the band object is smaller than
			/// <c>ptActual</c>, a chevron is shown to indicate that there are more options available. These options are displayed when the
			/// chevron is clicked.
			/// </para>
			/// <para>DBIMF_BREAK</para>
			/// <para><c>Windows XP and later:</c> The band object is displayed in a new row in the band container.</para>
			/// <para>DBIMF_ADDTOFRONT</para>
			/// <para><c>Windows XP and later:</c> The band object is the first object in the band container.</para>
			/// <para>DBIMF_TOPALIGN</para>
			/// <para><c>Windows XP and later:</c> The band object is displayed in the top row of the band container.</para>
			/// <para>DBIMF_NOGRIPPER</para>
			/// <para><c>Windows Vista and later:</c> No sizing grip is ever displayed to allow the user to move or resize the band object.</para>
			/// <para>DBIMF_ALWAYSGRIPPER</para>
			/// <para>
			/// <c>Windows Vista and later:</c> A sizing grip that allows the user to move or resize the band object is always shown, even if
			/// that band object is the only one in the container.
			/// </para>
			/// <para>DBIMF_NOMARGINS</para>
			/// <para><c>Windows Vista and later:</c> The band object should not display margins.</para>
			/// </summary>
			public DBIMF dwModeFlags;

			/// <summary>
			/// <para>Type: <c>COLORREF</c></para>
			/// <para>
			/// A COLORREF structure that receives the background color of the band. The <c>dwModeFlags</c> member must contain the
			/// <c>DBIMF_BKCOLOR</c> flag; otherwise, <c>crBkgnd</c> is ignored.
			/// </para>
			/// </summary>
			public COLORREF crBkgnd;
		}
	}
}