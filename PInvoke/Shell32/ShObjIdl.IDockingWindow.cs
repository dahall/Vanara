namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>
	/// Exposes methods that notify the docking window object of changes, including showing, hiding, and impending removal. This
	/// interface is implemented by window objects that can be docked within the border space of a Windows Explorer window.
	/// </summary>
	/// <remarks>
	/// <para>
	/// <c>IDockingWindow</c> is derived from IOleWindow. See the following topics for details on these methods also available to
	/// <c>IDockingWindow</c> through that inheritance.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Additional IDockingWindow Methods</term>
	/// </listheader>
	/// <item>
	/// <term>IDockingWindow::GetWindow</term>
	/// </item>
	/// <item>
	/// <term>IDockingWindow::ContextSensitiveHelp</term>
	/// </item>
	/// </list>
	/// <para>When to Implement</para>
	/// <para>
	/// Implement <c>IDockingWindow</c> when you want to display a window inside a browser frame. This is typically used for user
	/// interface windows, such as toolbars.
	/// </para>
	/// <para>When to Use</para>
	/// <para>
	/// You do not usually use the <c>IDockingWindow</c> interface directly. The Shell browser uses this interface to support docked
	/// windows inside the browser frame.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-idockingwindow
	[ComImport, Guid("012dd920-7b26-11d0-8ca9-00a0c92dbfe8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDockingWindow : Ole32.IOleWindow
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
		/// Five types of windows comprise the windows hierarchy. When a object is active in place, it has access to some or all of
		/// these windows.
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
		/// The window containing the active in-place object. The object application creates this window and installs it as a child of
		/// its hatch window, which is a child of the container's parent window.
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
		/// <param name="fEnterMode">
		/// <see langword="true"/> if help mode should be entered; <see langword="false"/> if it should be exited.
		/// </param>
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
		/// When SHIFT+F1 is pressed, either the frame or active object can receive the keystrokes. If the container's frame receives
		/// the keystrokes, it calls its containing document's IOleWindow::ContextSensitiveHelp method with <paramref
		/// name="fEnterMode"/> set to <see langword="true"/>. This propagates the help state to all of its in-place objects so they can
		/// correctly handle the mouse click or WM_COMMAND.
		/// </para>
		/// <para>
		/// If an active object receives the SHIFT+F1 keystrokes, it calls the container's IOleWindow::ContextSensitiveHelp method with
		/// <paramref name="fEnterMode"/> set to <see langword="true"/>, which then recursively calls each of its in-place sites until
		/// there are no more to be notified. The container then calls its document's or frame's IOleWindow::ContextSensitiveHelp method
		/// with <paramref name="fEnterMode"/> set to <see langword="true"/>.
		/// </para>
		/// <para>When in context-sensitive help mode, an object that receives the mouse click can either:</para>
		/// <list type="bullet">
		/// <item>Ignore the click if it does not support context-sensitive help.</item>
		/// <item>
		/// Tell all the other objects to exit context-sensitive help mode with ContextSensitiveHelp set to FALSE and then provide help
		/// for that context.
		/// </item>
		/// </list>
		/// <para>
		/// An object in context-sensitive help mode that receives a WM_COMMAND should tell all the other in-place objects to exit
		/// context-sensitive help mode and then provide help for the command.
		/// </para>
		/// <para>
		/// If a container application is to support context-sensitive help on menu items, it must either provide its own message filter
		/// so that it can intercept the F1 key or ask the OLE library to add a message filter by calling OleSetMenuDescriptor, passing
		/// valid, non-NULL values for the lpFrame and lpActiveObj parameters.
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
		HRESULT ShowDW([MarshalAs(UnmanagedType.Bool)] bool fShow);

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
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idockingwindow-closedw HRESULT CloseDW(
		// DWORD dwReserved );
		[PreserveSig]
		HRESULT CloseDW(uint dwReserved);

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
		/// Pointer to the site's IUnknown interface. The docking window object should call the QueryInterface method for this
		/// interface, requesting IID_IDockingWindowSite. The docking window object then uses that interface to negotiate its border
		/// space. It is the docking window object's responsibility to release this interface when it is no longer needed.
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
		/// window object's window is determined by subtracting prcBorder-&gt;left from prcBorder-&gt;right. Its height is contained in
		/// the <c>top</c> member of the BORDERWIDTHS structure.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idockingwindow-resizeborderdw HRESULT
		// ResizeBorderDW( LPCRECT prcBorder, IUnknown *punkToolbarSite, BOOL fReserved );
		[PreserveSig]
		HRESULT ResizeBorderDW([In, Optional] PRECT? prcBorder, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? punkToolbarSite, [MarshalAs(UnmanagedType.Bool)] bool fReserved);
	}
}