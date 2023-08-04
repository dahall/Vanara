namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>
	/// Provides methods that enable apps to be informed of state changes and location for the input pane. The input pane is a UI
	/// element, an on-screen keyboard or handwriting panel, that appears when the user performs an action that requires them to enter
	/// information, such as selecting a search box or an entry field in a form. Apps can then adjust their UI so that the input pane
	/// does not obscure items that the user might need to access while the input pane is shown.
	/// </summary>
	/// <remarks>
	/// <para>When to implement</para>
	/// <para>Do not implement this interface; the implementation is supplied with Windows as CLSID_FrameworkInputPane.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-iframeworkinputpane
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IFrameworkInputPane")]
	[ComImport, Guid("5752238B-24F0-495A-82F1-2FD593056796"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(FrameworkInputPane))]
	public interface IFrameworkInputPane
	{
		/// <summary>
		/// Registers the app's input pane handler object to receive notifications on behalf of a window when an event triggers the
		/// input pane. This method differs from AdviseWithHWND in that it references its window through an object that implements ICoreWindow.
		/// </summary>
		/// <param name="pWindow">
		/// <para>Type: <c>IUnknown*</c></para>
		/// <para>
		/// A pointer to the window (an object that implements ICoreWindow) for which the handler should listen for input pane events.
		/// </para>
		/// </param>
		/// <param name="pHandler">
		/// <para>Type: <c>IFrameworkInputPaneHandler*</c></para>
		/// <para>An IFrameworkInputPaneHandler interface pointer to the handler instance for this app.</para>
		/// </param>
		/// <param name="pdwCookie">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>
		/// A pointer to a value that, when this method returns successfully, receives a cookie for that can be used later to unregister
		/// the handler through the Unadvise method.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iframeworkinputpane-advise HRESULT Advise(
		// IUnknown *pWindow, IFrameworkInputPaneHandler *pHandler, DWORD *pdwCookie );
		void Advise([In, MarshalAs(UnmanagedType.IUnknown)] object pWindow, IFrameworkInputPaneHandler pHandler, out uint pdwCookie);

		/// <summary>
		/// Registers the app's input pane handler object to receive notifications on behalf of a window when an event triggers the
		/// input pane. This method differs from Advise in that it references its window through an <c>HWND</c>.
		/// </summary>
		/// <param name="hwnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>The handle of the window for which the handler should listen for input pane events.</para>
		/// </param>
		/// <param name="pHandler">
		/// <para>Type: <c>IFrameworkInputPaneHandler*</c></para>
		/// <para>An IFrameworkInputPaneHandler interface pointer to the handler instance for this app.</para>
		/// </param>
		/// <param name="pdwCookie">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>
		/// A pointer to a value that, when this method returns successfully, receives a cookie for that can be used later to unregister
		/// the handler through the Unadvise method.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iframeworkinputpane-advisewithhwnd HRESULT
		// AdviseWithHWND( HWND hwnd, IFrameworkInputPaneHandler *pHandler, DWORD *pdwCookie );
		void AdviseWithHWND(HWND hwnd, IFrameworkInputPaneHandler pHandler, out uint pdwCookie);

		/// <summary>Unregisters an app's input pane handler object so that it no longer receives notifications.</summary>
		/// <param name="dwCookie">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>A cookie that identifies the handler. This value was obtained when you registered the handler through the Advise method.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iframeworkinputpane-unadvise HRESULT
		// Unadvise( DWORD dwCookie );
		void Unadvise(uint dwCookie);

		/// <summary>Gets the current location of the input pane.</summary>
		/// <returns>
		/// <para>Type: <c>RECT*</c></para>
		/// <para>
		/// A pointer to a RECT structure that, when this method returns successfully, receives the location of the input pane, in
		/// screen coordinates. If the input pane is not visible, this structure receives an empty rectangle.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iframeworkinputpane-location HRESULT
		// Location( RECT *prcInputPaneScreenLocation );
		RECT Location();
	}

	/// <summary>
	/// Enables an app to be notified when the input pane (the on-screen keyboard or handwriting panel) is being shown or hidden. This
	/// allows the app window to adjust its display so that no input areas (such as a text box) are obscured by the input pane.
	/// </summary>
	/// <remarks>
	/// <para>When to implement</para>
	/// <para>Implement this interface if your app needs to be informed when the input pane is shown or hidden, or its screen coordinates.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-iframeworkinputpanehandler
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IFrameworkInputPaneHandler")]
	[ComImport, Guid("226C537B-1E76-4D9E-A760-33DB29922F18"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IFrameworkInputPaneHandler
	{
		/// <summary>
		/// Called before the input pane is shown, to allow the app window to make any necessary adjustments to its UI in response to
		/// the reduced screen space available to it. This is particularly important for input elements, such as text boxes, that are
		/// used in conjunction with the input pane.
		/// </summary>
		/// <param name="prcInputPaneScreenLocation">
		/// <para>Type: <c>RECT*</c></para>
		/// <para>A pointer to a RECT structure that supplies the screen coordinates that the input pane will occupy.</para>
		/// </param>
		/// <param name="fEnsureFocusedElementInView">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>
		/// A pointer to a value that is set to <c>true</c> if the app should attempt to keep its currently focused element (such as a
		/// text box) in view, which could require the app to move the element or rearrange its UI.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iframeworkinputpanehandler-showing HRESULT
		// Showing( RECT *prcInputPaneScreenLocation, BOOL fEnsureFocusedElementInView );
		[PreserveSig]
		HRESULT Showing(in RECT prcInputPaneScreenLocation, [MarshalAs(UnmanagedType.Bool)] bool fEnsureFocusedElementInView);

		/// <summary>Called when the input pane is about to leave the display.</summary>
		/// <param name="fEnsureFocusedElementInView">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>
		/// A pointer to a value that is set to <c>true</c> if the app should attempt to keep its currently focused element (such as a
		/// text box) in view, which could require the app to rearrange its UI or move the element, usually back to its layout before
		/// the input pane was shown.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iframeworkinputpanehandler-hiding HRESULT
		// Hiding( BOOL fEnsureFocusedElementInView );
		[PreserveSig]
		HRESULT Hiding([MarshalAs(UnmanagedType.Bool)] bool fEnsureFocusedElementInView);
	}

	/// <summary>CoClass for FrameworkInputPane</summary>
	[PInvokeData("shobjidl.h")]
	[ComImport, Guid("D5120AA3-46BA-44C5-822D-CA8092C1FC72"), ClassInterface(ClassInterfaceType.None)]
	public class FrameworkInputPane { }
}