using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>Enables access to DataTransferManager methods in a Windows Store app that manages multiple windows.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-idatatransfermanagerinterop
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IDataTransferManagerInterop")]
		[ComImport, Guid("3A3DCD6C-3EAB-43DC-BCDE-45671CE800C8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IDataTransferManagerInterop
		{
			/// <summary>Gets the DataTransferManager instance for the specified window.</summary>
			/// <param name="appWindow">The window whose DataTransferManager instance is to be retrieved.</param>
			/// <param name="riid">The requested interface ID of the DataTransferManager instance.</param>
			/// <param name="dataTransferManager">Receives the DataTransferManager instance.</param>
			/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
			/// <remarks>
			/// This method is equivalent to the DataTransferManager.GetForCurrentView method, except that you specify a window from a
			/// multi-window Windows Store app.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idatatransfermanagerinterop-getforwindow
			// HRESULT GetForWindow( HWND appWindow, REFIID riid, void **dataTransferManager );
			[PreserveSig]
			HRESULT GetForWindow(HWND appWindow, in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 1)] out object dataTransferManager);

			/// <summary>Displays the UI for sharing content for the specified window.</summary>
			/// <param name="appWindow">The window to show the share UI for.</param>
			/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
			/// <remarks>
			/// This method is equivalent to the DataTransferManager.ShowShareUI method, except that you specify a window from a
			/// multi-window Windows Store app.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idatatransfermanagerinterop-showshareuiforwindow
			// HRESULT ShowShareUIForWindow( HWND appWindow );
			[PreserveSig]
			HRESULT ShowShareUIForWindow(HWND appWindow);
		}
	}
}