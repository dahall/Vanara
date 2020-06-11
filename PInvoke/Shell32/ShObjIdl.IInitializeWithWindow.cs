using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>
		/// Exposes a method through which a client can provide an owner window to a Windows Runtime object used in a desktop application.
		/// </summary>
		/// <remarks>
		/// <para>When to implement</para>
		/// <para>
		/// Implement this interface if your object needs to be provided with an owner window, generally to display UI. Most third-party
		/// applications will not need to implement this interface.
		/// </para>
		/// <para>When to use</para>
		/// <para>
		/// Use this interface if you will provide a window to an object. A common scenario in which this interface is used is a Windows
		/// Store desktop browser.
		/// </para>
		/// <para>
		/// This interface is implemented by the following objects. Note that this is necessarily an incomplete list; refer to an individual
		/// object's documentation to determine whether that object implements this interface.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Windows.UI.Popups.PopupMenu</term>
		/// </item>
		/// <item>
		/// <term>Windows.UI.Popups.MessageDialog</term>
		/// </item>
		/// <item>
		/// <term>Windows.Storage.Pickers.FileOpenPicker</term>
		/// </item>
		/// <item>
		/// <term>Windows.Storage.Pickers.FileSavePicker</term>
		/// </item>
		/// <item>
		/// <term>Windows.Storage.Pickers.FolderPicker</term>
		/// </item>
		/// <item>
		/// <term>CLSID_DragDropHelper</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-iinitializewithwindow
		[ComImport, Guid("3E68D4BD-7135-4D10-8018-9FB6D9F33FA1"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IInitializeWithWindow
		{
			/// <summary>Specifies an owner window to be used by a Windows Runtime object that is used in a desktop app.</summary>
			/// <param name="hwnd">The handle of the window to be used as the owner window.</param>
			/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iinitializewithwindow-initialize HRESULT
			// Initialize( HWND hwnd );
			[PreserveSig]
			HRESULT Initialize(HWND hwnd);
		}
	}
}