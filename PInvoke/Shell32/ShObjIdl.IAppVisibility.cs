namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>Specifies whether a display is showing desktop windows instead of Windows Store apps.</summary>
	/// <remarks>The <c>MONITOR_APP_VISIBILITY</c> enum is used by the GetAppVisibilityOnMonitor method.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/ne-shobjidl_core-monitor_app_visibility typedef enum
	// MONITOR_APP_VISIBILITY { MAV_UNKNOWN, MAV_NO_APP_VISIBLE, MAV_APP_VISIBLE } ;
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NE:shobjidl_core.MONITOR_APP_VISIBILITY")]
	public enum MONITOR_APP_VISIBILITY
	{
		/// <summary>The display state is not known.</summary>
		MAV_UNKNOWN,

		/// <summary>The display is showing desktop windows.</summary>
		MAV_NO_APP_VISIBLE,

		/// <summary>The display is not showing desktop windows.</summary>
		MAV_APP_VISIBLE,
	}

	/// <summary>Provides functionality to determine whether the display is showing Windows Store apps.</summary>
	/// <remarks>
	/// <para>
	/// Use the <c>IAppVisibility</c> interface to determine when a display is showing Windows Store apps. This is useful for
	/// accessibility tools and other applications.
	/// </para>
	/// <para>Use the IsLauncherVisible method to determine when the Start screen is visible.</para>
	/// <para>Don't implement the <c>IAppVisibility</c> interface. Instead, call the CoCreateInstance function with <c>CLSID_AppVisibility</c>.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-iappvisibility
	[ComImport, Guid("2246EA2D-CAEA-4444-A3C4-6DE827E44313"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(AppVisibility))]
	public interface IAppVisibility
	{
		/// <summary>Queries the current mode of the specified monitor.</summary>
		/// <param name="hMonitor">The monitor to query.</param>
		/// <returns>The current mode of hMonitor.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iappvisibility-getappvisibilityonmonitor
		// HRESULT GetAppVisibilityOnMonitor( HMONITOR hMonitor, MONITOR_APP_VISIBILITY *pMode );
		MONITOR_APP_VISIBILITY GetAppVisibilityOnMonitor(HMONITOR hMonitor);

		/// <summary>Gets a value that indicates whether the Start screen is displayed.</summary>
		/// <returns><c>TRUE</c> if the Start screen is displayed; otherwise, <c>FALSE.</c></returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iappvisibility-islaunchervisible HRESULT
		// IsLauncherVisible( BOOL *pfVisible );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool IsLauncherVisible();

		/// <summary>Registers an advise sink object to receive notification of changes to the display.</summary>
		/// <param name="pCallback">The client's advise sink that receives outgoing calls from the connection point.</param>
		/// <param name="pdwCookie">
		/// A token that uniquely identifies this connection. Use this token to delete the connection by passing it to the Unadvise method.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iappvisibility-advise HRESULT Advise(
		// IAppVisibilityEvents *pCallback, DWORD *pdwCookie );
		void Advise(IAppVisibilityEvents pCallback, out uint pdwCookie);

		/// <summary>Cancels a connection that was previously established by using Advise.</summary>
		/// <param name="dwCookie">
		/// A token that uniquely identifies the connection to cancel, which is provided by a previous call to to the Advise method.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iappvisibility-unadvise HRESULT Unadvise(
		// DWORD dwCookie );
		void Unadvise(uint dwCookie);
	}

	/// <summary>Enables applications to receive notifications of state changes in a display and of changes in Start screen visibility.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-iappvisibilityevents
	[ComImport, Guid("6584CE6B-7D82-49C2-89C9-C6BC02BA8C38"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAppVisibilityEvents
	{
		/// <summary>Notifies a client that the mode of a display has changed.</summary>
		/// <param name="hMonitor">The display that has a changing mode.</param>
		/// <param name="previousMode">
		/// The previous mode of hMonitor, which may be <c>MAV_UNKNOWN</c> if the client was unaware of the display previously.
		/// </param>
		/// <param name="currentMode">The current mode of hMonitor, which will not be <c>MAV_UNKNOWN</c>.</param>
		/// <returns>The return value is ignored.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iappvisibilityevents-appvisibilityonmonitorchanged
		// HRESULT AppVisibilityOnMonitorChanged( HMONITOR hMonitor, MONITOR_APP_VISIBILITY previousMode, MONITOR_APP_VISIBILITY
		// currentMode );
		[PreserveSig]
		HRESULT AppVisibilityOnMonitorChanged(HMONITOR hMonitor, MONITOR_APP_VISIBILITY previousMode, MONITOR_APP_VISIBILITY currentMode);

		/// <summary>Notifies a client that visibility of the Start screen has changed.</summary>
		/// <param name="currentVisibleState"><c>TRUE</c> if the Start screen is displayed; otherwise, <c>FALSE.</c></param>
		/// <returns>The return value is ignored.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iappvisibilityevents-launchervisibilitychange
		// HRESULT LauncherVisibilityChange( BOOL currentVisibleState );
		[PreserveSig]
		HRESULT LauncherVisibilityChange([MarshalAs(UnmanagedType.Bool)] bool currentVisibleState);
	}

	/// <summary>CoClass for AppVisibility</summary>
	[PInvokeData("shobjidl.h")]
	[ComImport, Guid("7E5FE3D9-985F-4908-91F9-EE19F9FD1514"), ClassInterface(ClassInterfaceType.None)]
	public class AppVisibility { }
}