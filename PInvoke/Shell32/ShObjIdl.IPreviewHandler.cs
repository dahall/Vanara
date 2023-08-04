namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>Exposes methods for the display of rich previews.</summary>
	// https://msdn.microsoft.com/en-us/library/windows/desktop/bb775315(v=vs.85).aspx
	[PInvokeData("Shobjidl.h", MSDNShortId = "bb775315")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("8895b1c6-b41f-4c1c-a562-0d564250836f")]
	public interface IPreviewHandler
	{
		/// <summary>
		/// Sets the parent window of the previewer window, as well as the area within the parent to be used for the previewer window.
		/// </summary>
		/// <param name="hwnd">A handle to the parent window.</param>
		/// <param name="prc">A pointer to a RECT defining the area for the previewer.</param>
		/// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[PreserveSig]
		HRESULT SetWindow([In] HWND hwnd, in RECT prc);

		/// <summary>Directs the preview handler to change the area within the parent hwnd that it draws into.</summary>
		/// <param name="prc">A pointer to a RECT to be used for the preview.</param>
		/// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[PreserveSig]
		HRESULT SetRect(in RECT prc);

		/// <summary>
		/// Directs the preview handler to load data from the source specified in an earlier Initialize method call, and to begin
		/// rendering to the previewer window.
		/// </summary>
		/// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[PreserveSig]
		HRESULT DoPreview();

		/// <summary>
		/// Directs the preview handler to cease rendering a preview and to release all resources that have been allocated based on the
		/// item passed in during the initialization.
		/// </summary>
		/// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[PreserveSig]
		HRESULT Unload();

		/// <summary>Directs the preview handler to set focus to itself.</summary>
		/// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[PreserveSig]
		HRESULT SetFocus();

		/// <summary>
		/// Directs the preview handler to return the HWND from calling the GetFocus Function.
		/// </summary>
		/// <param name="phwnd">When this method returns, contains a pointer to the HWND returned from calling the GetFocus Function from the preview
		/// handler's foreground thread.</param>
		/// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[PreserveSig]
		HRESULT QueryFocus(out HWND phwnd);

		/// <summary>
		/// Directs the preview handler to handle a keystroke passed up from the message pump of the process in which the preview handler
		/// is running.
		/// </summary>
		/// <param name="pmsg">A pointer to a window message.</param>
		/// <returns>
		/// If the keyboard shortcut is one that the host intends to handle, the host will process it and return S_OK; otherwise, it
		/// returns S_FALSE.
		/// </returns>
		[PreserveSig]
		HRESULT TranslateAccelerator(in MSG pmsg);
	}

	/// <summary>
	/// Enables preview handlers to pass keyboard shortcuts to the host. This interface retrieves a list of keyboard shortcuts and
	/// directs the host to handle a keyboard shortcut.
	/// </summary>
	// https://msdn.microsoft.com/en-us/library/windows/desktop/bb775309(v=vs.85).aspx
	[PInvokeData("Shobjidl.h", MSDNShortId = "bb775309")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("fec87aaf-35f9-447a-adb7-20234491401a")]
	public interface IPreviewHandlerFrame
	{
		/// <summary>Gets a list of the keyboard shortcuts for the preview host.</summary>
		/// <param name="pinfo">A pointer to a PREVIEWHANDLERFRAMEINFO structure that receives accelerator table information.</param>
		/// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[PreserveSig]
		HRESULT GetWindowContext(out PREVIEWHANDLERFRAMEINFO pinfo);

		/// <summary>Directs the host to handle an keyboard shortcut passed from the preview handler.</summary>
		/// <param name="pmsg">A pointer to a WM_COMMAND or WM_SYSCOMMAND window message that corresponds to a keyboard shortcut.</param>
		/// <returns>
		/// If the keyboard shortcut is one that the host intends to handle, the host will process it and return S_OK; otherwise, it
		/// returns S_FALSE.
		/// </returns>
		[PreserveSig]
		HRESULT TranslateAccelerator(in MSG pmsg);
	}

	/// <summary>Exposes methods for applying color and font information to preview handlers.</summary>
	// https://msdn.microsoft.com/en-us/library/windows/desktop/bb775299(v=vs.85).aspx
	[PInvokeData("Shobjidl.h", MSDNShortId = "bb775299")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("196bf9a5-b346-4ef0-aa1e-5dcdb76768b1")]
	public interface IPreviewHandlerVisuals
	{
		/// <summary>Sets the background color of the preview handler.</summary>
		/// <param name="color">A value of type COLORREF to use for the preview handler background.</param>
		/// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[PreserveSig]
		HRESULT SetBackgroundColor(COLORREF color);

		/// <summary>Sets the font attributes to be used for text within the preview handler.</summary>
		/// <param name="plf">A pointer to a LOGFONTW Structure containing the necessary attributes for the font to use.</param>
		/// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[PreserveSig]
		HRESULT SetFont(in LOGFONT plf);

		/// <summary>Sets the color of the text within the preview handler.</summary>
		/// <param name="color">A value of type COLORREF to use for the preview handler text color.</param>
		/// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[PreserveSig]
		HRESULT SetTextColor(COLORREF color);
	}

	/// <summary><para>Accelerator table structure. Used by IPreviewHandlerFrame::GetWindowContext.</para></summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/ns-shobjidl_core-previewhandlerframeinfo
	// typedef struct PREVIEWHANDLERFRAMEINFO { HACCEL haccel; UINT cAccelEntries; } PREVIEWHANDLERFRAMEINFO;
	[PInvokeData("shobjidl_core.h", MSDNShortId = "dd93675e-fd69-4fa3-a8e7-5238c27783d8")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PREVIEWHANDLERFRAMEINFO
	{
		/// <summary>A handle to the accelerator table.</summary>
		public HACCEL haccel;

		/// <summary>The number of entries in the accelerator table.</summary>
		public uint cAccelEntries;
	}
}