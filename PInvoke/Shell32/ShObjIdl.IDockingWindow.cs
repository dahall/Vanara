using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
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
			/// <returns>A pointer to a variable that receives the window handle.</returns>
			new HWND GetWindow();

			/// <summary>Determines whether context-sensitive help mode should be entered during an in-place activation session.</summary>
			/// <param name="fEnterMode"><c>true</c> if help mode should be entered; <c>false</c> if it should be exited.</param>
			new void ContextSensitiveHelp([MarshalAs(UnmanagedType.Bool)] bool fEnterMode);

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
			HRESULT ResizeBorderDW([In, Optional] PRECT prcBorder, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object punkToolbarSite, [MarshalAs(UnmanagedType.Bool)] bool fReserved);
		}
	}
}