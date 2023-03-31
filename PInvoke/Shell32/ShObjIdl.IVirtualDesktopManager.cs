using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>Exposes methods that enable an application to interact with groups of windows that form virtual workspaces.</summary>
	/// <remarks>
	/// <para>
	/// The user can group a collection of windows together to create a virtual desktop. Every window is considered to be part of a
	/// virtual desktop. When one virtual desktop is hidden, all of the windows associated with it are also hidden. This enables the
	/// user to create multiple working environments and to be able to switch between them. Similarly, when a virtual desktop is
	/// selected to be active, the windows associated with that virtual desktop are displayed on the screen.
	/// </para>
	/// <para>
	/// To support this concept, applications should avoid automatically switching the user from one virtual desktop to another. Only
	/// the user should instigate that change. In order to support this, newly created windows should appear on the currently active
	/// virtual desktop. In addition, if an application can reuse currently active windows, it should only reuse windows if they are on
	/// the currently active virtual desktop. Otherwise, a new window should be created.
	/// </para>
	/// <para>
	/// In the above image, the user has two virtual desktops and <c>VD2</c> is the currently active virtual desktop. If the user clicks
	/// a link in an outlook message, there's a URI activation that should open the link in an Internet Explorer window. If the user has
	/// configured IE to open links in the current window, it would normally use the currently open window. However, in this case, IE is
	/// on an inactive virtual desktop. In this scenario, IE should create a new window in the currently active virtual desktop.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ivirtualdesktopmanager
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IVirtualDesktopManager")]
	[ComImport, Guid("a5cd92ff-29be-454c-8d04-d82879fb3f1b"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(VirtualDesktopManager))]
	public interface IVirtualDesktopManager
	{
		/// <summary>Indicates whether the provided window is on the currently active virtual desktop.</summary>
		/// <param name="topLevelWindow">The window of interest.</param>
		/// <returns><c>True</c> if the topLevelWindow is on the currently active virtual desktop, otherwise <c>false</c>.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ivirtualdesktopmanager-iswindowoncurrentvirtualdesktop
		// HRESULT IsWindowOnCurrentVirtualDesktop( HWND topLevelWindow, BOOL *onCurrentDesktop );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool IsWindowOnCurrentVirtualDesktop(HWND topLevelWindow);

		/// <summary>Gets the identifier for the virtual desktop hosting the provided top-level window.</summary>
		/// <param name="topLevelWindow">The top level window for the virtual desktop you are interested in.</param>
		/// <returns>The identifier for the virtual desktop hosting the topLevelWindow.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ivirtualdesktopmanager-getwindowdesktopid
		// HRESULT GetWindowDesktopId( HWND topLevelWindow, GUID *desktopId );
		Guid GetWindowDesktopId(HWND topLevelWindow);

		/// <summary>Moves a window to the specified virtual desktop.</summary>
		/// <param name="topLevelWindow">The window to move.</param>
		/// <param name="desktopId">The identifier of the virtual desktop to move the GetWindowDesktopId to get a window's identifier.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ivirtualdesktopmanager-movewindowtodesktop
		// HRESULT MoveWindowToDesktop( HWND topLevelWindow, REFGUID desktopId );
		void MoveWindowToDesktop(HWND topLevelWindow, in Guid desktopId);
	}

	/// <summary>CLSID_VirtualDesktopManager</summary>
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IVirtualDesktopManager")]
	[ComImport, Guid("aa509086-5ca9-4c25-8f95-589d3c07b48a"), ClassInterface(ClassInterfaceType.None)]
	public class VirtualDesktopManager { }
}