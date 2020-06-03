using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>Values that indicate the reason that a docked accessibility app window has been undocked. Used by IAccessibilityDockingServiceCallback::Undocked.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/ne-shobjidl-undock_reason typedef enum UNDOCK_REASON {
		// UR_RESOLUTION_CHANGE, UR_MONITOR_DISCONNECT } ;
		[PInvokeData("shobjidl.h", MSDNShortId = "NE:shobjidl.UNDOCK_REASON")]
		public enum UNDOCK_REASON
		{
			/// <summary>The accessibility window was undocked because the screen resolution has changed.</summary>
			UR_RESOLUTION_CHANGE,

			/// <summary>The monitor on which the accessibility window was docked has been disconnected.</summary>
			UR_MONITOR_DISCONNECT,
		}

		/// <summary>
		/// Docks an application window to the bottom of a monitor when a Windows Store app is visible and not snapped, or when the launcher
		/// is visible.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nn-shobjidl-iaccessibilitydockingservice
		[ComImport, Guid("8849DC22-CEDF-4C95-998D-051419DD3F76"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(AccessibilityDockingService))]
		public interface IAccessibilityDockingService
		{
			/// <summary>Retrieves the dimensions available on a specific screen for displaying an accessibility window.</summary>
			/// <param name="hMonitor">
			/// <para>Type: <c>HMONITOR</c></para>
			/// <para>
			/// The handle of the monitor whose available docking size is to be retrieved. For information on how to retrieve an
			/// <c>HMONITOR</c>, see MonitorFromWindow.
			/// </para>
			/// </param>
			/// <param name="pcxFixed">
			/// <para>Type: <c>UINT*</c></para>
			/// <para>
			/// When this method returns successfully, this parameter receives the fixed width, in physical pixels, available for docking on
			/// the specified monitor. Any window docked to this monitor will be sized to this width.
			/// </para>
			/// <para>If the method fails, this value is set to 0.</para>
			/// <para>If this value is <c>NULL</c>, an access violation will occur.</para>
			/// </param>
			/// <param name="pcyMax">
			/// <para>Type: <c>UINT*</c></para>
			/// <para>
			/// When this method returns successfully, this parameter receives the maximum height, in physical pixels, available for a
			/// docked window on the specified monitor.
			/// </para>
			/// <para>If the method fails, this value is set to 0.</para>
			/// <para>If this value is <c>NULL</c>, an access violation will occur.</para>
			/// </param>
			/// <remarks>
			/// <para>When to use</para>
			/// <para>
			/// A docked accessibility window is limited in the amount of space that it can use on any screen. Therefore, before trying to
			/// dock an accessibility window, call this function to get the available dimensions. You cannot dock any window that would
			/// cause a Windows Store app to have access to less than 768 vertical screen pixels.
			/// </para>
			/// <para>Examples</para>
			/// <para>This example shows this method in use.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-iaccessibilitydockingservice-getavailablesize HRESULT
			// GetAvailableSize( HMONITOR hMonitor, UINT *pcxFixed, UINT *pcyMax );
			void GetAvailableSize(HMONITOR hMonitor, out uint pcxFixed, out uint pcyMax);

			/// <summary>Docks the specified window handle to the specified monitor handle.</summary>
			/// <param name="hwnd">The accessibility application window that will be docked on the passed monitor handle.</param>
			/// <param name="hMonitor">The monitor on which the accessibility application window will be docked.</param>
			/// <param name="cyRequested">TBD</param>
			/// <param name="pCallback">The callback pointer on which the accessibility application will receive the Undock notification.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>The window handle or monitor handle is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>The calling process is not a UIAcess accessibility application or the calling process does not own the window.</term>
			/// </item>
			/// <item>
			/// <term>IMM_E_DOCKOCCUPIED</term>
			/// <term>There is already another window occupying the docking space. Only one window can be docked at a time.</term>
			/// </item>
			/// <item>
			/// <term>IMM_E_INSUFFICIENTHEIGHT</term>
			/// <term>
			/// The requested uHeight is larger than the maximum allowed docking height for the specified monitor. However, if this error
			/// code is being returned, it means that this monitor does support docking, though at a height indicated by a call to the
			/// GetAvailableSize method.
			/// </term>
			/// </item>
			/// <item>
			/// <term>HRESULT_FROM_WIN32(ERROR_INVALID_MONITOR_HANDLE)</term>
			/// <term>The monitor specified by the monitor handle does not support docking.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-iaccessibilitydockingservice-dockwindow HRESULT
			// DockWindow( HWND hwnd, HMONITOR hMonitor, UINT cyRequested, IAccessibilityDockingServiceCallback *pCallback );
			void DockWindow(HWND hwnd, HMONITOR hMonitor, [Optional] uint cyRequested, IAccessibilityDockingServiceCallback pCallback);

			/// <summary>Undocks the specified window handle if it is currently docked.</summary>
			/// <param name="hwnd">TBD</param>
			/// <remarks>
			/// <para>This method can only be used to undock windows that belong to the calling process.</para>
			/// <para>Examples</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-iaccessibilitydockingservice-undockwindow HRESULT
			// UndockWindow( HWND hwnd );
			void UndockWindow(HWND hwnd);
		}

		/// <summary>Receives Acessibility Window Docking events.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nn-shobjidl-iaccessibilitydockingservicecallback
		[PInvokeData("shobjidl.h", MSDNShortId = "NN:shobjidl.IAccessibilityDockingServiceCallback")]
		[ComImport, Guid("157733FD-A592-42E5-B594-248468C5A81B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IAccessibilityDockingServiceCallback
		{
			/// <summary>Undocks the accessibility window so that it will not be automatically moved to its previous location.</summary>
			/// <param name="undockReason">Specifies the reason why the accessibility application's window was undocked.</param>
			/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-iaccessibilitydockingservicecallback-undocked HRESULT
			// Undocked( UNDOCK_REASON undockReason );
			[PreserveSig]
			HRESULT Undocked(UNDOCK_REASON undockReason);
		}

		/// <summary>CoClass for IAccessibilityDockingService</summary>
		[PInvokeData("shobjidl.h")]
		[ComImport, Guid("29CE1D46-B481-4AA0-A08A-D3EBC8ACA402"), ClassInterface(ClassInterfaceType.None)]
		public class AccessibilityDockingService { }
	}
}