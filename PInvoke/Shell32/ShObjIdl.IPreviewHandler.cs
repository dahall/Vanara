using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>Exposes methods for the display of rich previews.</summary>
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("8895b1c6-b41f-4c1c-a562-0d564250836f")]
		[PInvokeData("Shobjidl.h")]
		public interface IPreviewHandler
		{
			/// <summary>
			/// Sets the parent window of the previewer window, as well as the area within the parent to be used for the previewer window.
			/// </summary>
			/// <param name="hwnd">A handle to the parent window.</param>
			/// <param name="prc">A pointer to a RECT defining the area for the previewer.</param>
			void SetWindow([In] HandleRef hwnd, [In, MarshalAs(UnmanagedType.LPStruct)] RECT prc);

			/// <summary>Directs the preview handler to change the area within the parent hwnd that it draws into.</summary>
			/// <param name="prc">A pointer to a RECT to be used for the preview.</param>
			void SetRect([In, MarshalAs(UnmanagedType.LPStruct)] RECT prc);

			/// <summary>
			/// Directs the preview handler to load data from the source specified in an earlier Initialize method call, and to begin
			/// rendering to the previewer window.
			/// </summary>
			void DoPreview();

			/// <summary>
			/// Directs the preview handler to cease rendering a preview and to release all resources that have been allocated based on the
			/// item passed in during the initialization.
			/// </summary>
			void Unload();

			/// <summary>Directs the preview handler to set focus to itself.</summary>
			void SetFocus();

			/// <summary>Directs the preview handler to return the HWND from calling the GetFocus Function.</summary>
			/// <returns>
			/// When this method returns, contains a pointer to the HWND returned from calling the GetFocus Function from the preview
			/// handler's foreground thread.
			/// </returns>
			IntPtr QueryFocus();

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
			HRESULT TranslateAccelerator([In, MarshalAs(UnmanagedType.LPStruct)] MSG pmsg);
		}

		/// <summary>
		/// Enables preview handlers to pass keyboard shortcuts to the host. This interface retrieves a list of keyboard shortcuts and
		/// directs the host to handle a keyboard shortcut.
		/// </summary>
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("fec87aaf-35f9-447a-adb7-20234491401a")]
		[PInvokeData("Shobjidl.h")]
		public interface IPreviewHandlerFrame
		{
			/// <summary>Gets a list of the keyboard shortcuts for the preview host.</summary>
			/// <returns>A pointer to a PREVIEWHANDLERFRAMEINFO structure that receives accelerator table information.</returns>
			PREVIEWHANDLERFRAMEINFO GetWindowContext();

			/// <summary>Directs the host to handle an keyboard shortcut passed from the preview handler.</summary>
			/// <param name="pmsg">A pointer to a WM_COMMAND or WM_SYSCOMMAND window message that corresponds to a keyboard shortcut.</param>
			/// <returns>
			/// If the keyboard shortcut is one that the host intends to handle, the host will process it and return S_OK; otherwise, it
			/// returns S_FALSE.
			/// </returns>
			[PreserveSig]
			HRESULT TranslateAccelerator([In, MarshalAs(UnmanagedType.LPStruct)] MSG pmsg);
		}

		/// <summary>Exposes methods for applying color and font information to preview handlers.</summary>
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("196bf9a5-b346-4ef0-aa1e-5dcdb76768b1")]
		[PInvokeData("Shobjidl.h")]
		public interface IPreviewHandlerVisuals
		{
			/// <summary>Sets the background color of the preview handler.</summary>
			/// <param name="color">A value of type COLORREF to use for the preview handler background.</param>
			void SetBackgroundColor(COLORREF color);

			/// <summary>Sets the font attributes to be used for text within the preview handler.</summary>
			/// <param name="plf">A pointer to a LOGFONTW Structure containing the necessary attributes for the font to use.</param>
			void SetFont([In, MarshalAs(UnmanagedType.LPStruct)] LOGFONT plf);

			/// <summary>Sets the color of the text within the preview handler.</summary>
			/// <param name="color">A value of type COLORREF to use for the preview handler text color.</param>
			void SetTextColor(COLORREF color);
		}

		/// <summary>Accelerator table structure. Used by IPreviewHandlerFrame::GetWindowContext.</summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("Shobjidl.h")]
		public struct PREVIEWHANDLERFRAMEINFO
		{
			/// <summary>A handle to the accelerator table.</summary>
			public IntPtr haccel;

			/// <summary>The number of entries in the accelerator table.</summary>
			public uint cAccelEntries;
		}
	}
}